/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DBOperations;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using EPetro.Sysitem.Classes ;
using System.IO;
using System.Text;
using RMG;


namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for ProductWiseSales.
	/// </summary>
	public class ProductWiseSales : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Button cmdrpt;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.DataGrid grdLeg1;
		string uid = "";
		protected System.Web.UI.WebControls.Button btnExcel;
		string strOrderBy="";

		/// <summary>
		/// This method is used for setting the Session variable for userId
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
                txtDateFrom.Attributes.Add("readonly", "readonly");
                txtDateTo.Attributes.Add("readonly", "readonly");
                uid =(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:Page_Load    EXCEPTION: "+ ex.Message+ ". User: "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="11";
				string[,] Priv=(string[,]) Session["Privileges"];
				for(i=0;i<Priv.GetLength(0);i++)
				{
					if(Priv[i,0]== Module &&  Priv[i,1]==SubModule)
					{						
						View_flag=Priv[i,2];
						Add_Flag=Priv[i,3];
						Edit_Flag=Priv[i,4];
						Del_Flag=Priv[i,5];
						break;
					}
				}	
				if(View_flag=="0")
				{
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
				txtDateFrom.Text=DateTime.Now.Day+ "/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year;
				txtDateTo.Text=DateTime.Now.Day+ "/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year;
			}
		}

		/// <summary>
		/// This methos is used to create  the report file .txt to print.
		/// </summary>
		public void makingReport()
		{
			/*
							   =========================            
								 PRODUCT SALES REPORT               
							   =========================            
			+-------------------------+---------------------+-----------+
			|                         |     Sales.Type      |           |
			|      Product Name       |----------+----------|  Amount   |
			|                         | Pkg      |  Ltr     |           |
			+-------------------------+----------+----------+-----------+
			 1234567890123456789012345 20X1234   1234567890  12345678.00
			*/
			System.Data.SqlClient.SqlDataReader rdr=null;
			string sql="";
			string info= "";
			string strPack = "";
			string strSales = "";
			string[] strParts;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\ProductWiseReport.txt";
			StreamWriter sw = new StreamWriter(path);		
		     			
			sql="select p.Prod_Name + ' ' + p.Pack_Type AS Prod_Name, p.Pack_Type, sum(cast(sd.qty as float)) as Sales, sum(cast(sd.qty as float)*cast(sd.Rate as float)) as Amount from Products p, Sales_Master sm, Sales_Details sd where p.Prod_ID = sd.Prod_ID and sm.Invoice_No=sd.Invoice_No and cast(floor(cast(sm.Invoice_Date as float)) as datetime)>= '"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and  cast(floor(cast(sm.Invoice_Date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateTo.Text)).ToShortDateString()+"' group by p.Prod_Name, p.Pack_Type order by "+Cache["strOrderBy"]+"";
			
			dbobj.SelectQuery(sql,ref rdr);

			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu
			// Condensed
			sw.Write((char)27);
			sw.Write((char)15);
			sw.WriteLine("");
			// Condensed
			//sw.Write((char)15);
			//sw.WriteLine("");
			//**********
			string des="-------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("=================================================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("PRODUCT SALES REPORT From "+txtDateFrom.Text.ToString()+" To "+txtDateTo.Text.ToString(),des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=================================================",des.Length));
			sw.WriteLine("+-------------------------+---------------------+-----------+");
			sw.WriteLine("|                         |     Sales.Type      |           | ");
			sw.WriteLine("|     Product Name        |----------+----------|  Amount   |");
			sw.WriteLine("|                         | Pkg      |  Ltr/Kg  |           |");
			sw.WriteLine("+-------------------------+----------+----------+-----------+");
			//                     1234567890123456789012345 20X1234    1234567890 12345678.00	
			if(rdr.HasRows)
			{
				// info : to set string format.
				info = " {0,-25:S} {1,-7:S}   {2,10:S}  {3,11:F}";
				while(rdr.Read())
				{
					
					strSales = rdr["Sales"].ToString().Trim();

					if(rdr["Pack_Type"].ToString().Trim().Equals("") || rdr["Pack_Type"].ToString().Trim().IndexOf("Loose") > -1  )
					{
						strPack  = strSales;  
						strSales = "";
					}
					else
					{            
						strParts = rdr["Pack_Type"].ToString().Trim().Split(new char[] {'X'},rdr["Pack_Type"].ToString().Trim().Length);
						double tot = System.Convert.ToDouble(strParts[0]) *  System.Convert.ToDouble(strParts[1]) * System.Convert.ToDouble(strSales);
						strPack = "" + tot;
					}
					
					sw.WriteLine(info,GenUtil.TrimLength(rdr["Prod_Name"].ToString().Trim(),25),						
						GenUtil.strNumericFormat(strSales),
						GenUtil.strNumericFormat(strPack),				
						GenUtil.strNumericFormat(rdr["Amount"].ToString()));
				}
			}
			sw.WriteLine("+-------------------------+----------+----------+-----------+");
			sw.WriteLine(info,"Total",GenUtil.strNumericFormat(Cache["salesp"].ToString()),GenUtil.strNumericFormat(Cache["sales1"].ToString()),GenUtil.strNumericFormat((Cache["amount"]).ToString()));
			sw.WriteLine("+-------------------------+----------+----------+-----------+");
			dbobj.Dispose();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string sql="",strPack = "",strSales = "";
			string[] strParts;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\ProductWiseSales.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select p.Prod_Name + ' ' + p.Pack_Type AS Prod_Name, p.Pack_Type, sum(cast(sd.qty as float)) as Sales, sum(cast(sd.qty as float)*cast(sd.Rate as float)) as Amount from Products p, Sales_Master sm, Sales_Details sd where p.Prod_ID = sd.Prod_ID and sm.Invoice_No=sd.Invoice_No and cast(floor(cast(sm.Invoice_Date as float)) as datetime)>= '"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and  cast(floor(cast(sm.Invoice_Date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateTo.Text)).ToShortDateString()+"' group by p.Prod_Name, p.Pack_Type order by "+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("Form Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+txtDateTo.Text);
			sw.WriteLine("Product Name\tSales Type(Pkg)\tSales Type(Ltr/kg)\tAmount");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					strSales = rdr["Sales"].ToString().Trim();
					if(rdr["Pack_Type"].ToString().Trim().Equals("") || rdr["Pack_Type"].ToString().Trim().IndexOf("Loose") > -1  )
					{
						strPack  = strSales;  
						strSales = "";
					}
					else
					{            
						strParts = rdr["Pack_Type"].ToString().Trim().Split(new char[] {'X'},rdr["Pack_Type"].ToString().Trim().Length);
						double tot = System.Convert.ToDouble(strParts[0]) *  System.Convert.ToDouble(strParts[1]) * System.Convert.ToDouble(strSales);
						strPack = "" + tot;
					}
					sw.WriteLine(rdr["Prod_Name"].ToString().Trim()+"\t"+
						GenUtil.strNumericFormat(strSales)+"\t"+
						GenUtil.strNumericFormat(strPack)+"\t"+
						GenUtil.strNumericFormat(rdr["Amount"].ToString()));
				}
			}
			sw.WriteLine("Total\t"+GenUtil.strNumericFormat(Cache["salesp"].ToString())+"\t"+GenUtil.strNumericFormat(Cache["sales1"].ToString())+"\t"+GenUtil.strNumericFormat((Cache["amount"]).ToString()));
			dbobj.Dispose();
			sw.Close();
		}
		
		/// <summary>
		/// This method multiplies the package with actual qty. called from .aspx.
		/// </summary>
		public double sales1=0;
		protected double Multiply(string str)
		{
			string[] mystr=str.Split(new char[]{'X'},str.Length);
			if(str.Trim().IndexOf("Loose") == -1)
			{
				double ans=1;
				foreach(string val in mystr)
				{
					if(val.Length>0 && !val.Trim().Equals(""))
						ans*=double.Parse(val,System.Globalization.NumberStyles.Float);
				}
				//***************
				sales1+=ans;
				Cache["sales1"]=System.Convert.ToString(sales1);
				//***************
				return ans;
			}
			else
			{
				if(!mystr[1].Trim().Equals(""))
				{
					//**********
					sales1+=System.Convert.ToDouble( mystr[1].ToString()) ; 
					Cache["sales1"]=System.Convert.ToString(sales1);
					//*********
					return System.Convert.ToDouble( mystr[1].ToString()); 
				}
				else
					return 0;
			}
		}
		
		/// <summary>
		/// This methos is used to calculate the total amount
		/// </summary>
		public double ans1=0;
		protected double totalamount(string str) 
		{
			ans1+=System.Convert.ToDouble(str);
			Cache["amount"]=System.Convert.ToString(ans1);
			return System.Convert.ToDouble(str);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdrpt.Click += new System.EventHandler(this.cmdrpt_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private DateTime getdate(string dat,bool to)
		{
			//int dd=mm=yy=0;
			string[] dt=dat.Split(new char[]{'/'},dat.Length);
			if(to)
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0])+1);			
			else
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));			
		}

		/// <summary>
		/// This method is used to check the package type
		/// </summary>
		public double salesp=0;
		protected string Check(string cs, string type)
		{
			if(type.ToUpper().Length==0 || type.IndexOf("Loose") > -1 )
			{
				Cache["salesp"]="0";
				return "&nbsp;";
			}
			else
			{
				//**********
				salesp+=System.Convert.ToDouble(cs);
				Cache["salesp"]=System.Convert.ToString(salesp);
				//*******
				return cs;
			}
		}

		/// <summary>
		/// This method is used to return date in mm/DD/YYYY format.
		/// </summary>
		public DateTime ToMMddYYYY(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];
			//strarr=str.Split(new char[]{'/'},str.Length);
            strarr = str.IndexOf("/") > 0 ? str.Split(new char[] { '/' }, str.Length) : str.Split(new char[] { '-' }, str.Length);
            dd =Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);
			return(dt);
		}
		
		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void cmdrpt_Click(object sender, System.EventArgs e)
		{  	
			try
			{
				// Fetch the details and bind the data grid. 
				strOrderBy = "Prod_Name ASC";
				Session["Column"] = "Prod_Name";
				Session["Order"] = "ASC";
				BindTheData();
				//				System.Data.SqlClient.SqlDataReader rdr=null;
				//				string sql="";
				//				sql="select p.Prod_Name + ' ' + p.Pack_Type AS Prod_Name, p.Pack_Type, sum(cast(sd.qty as float)) as Sales, sum(cast(sd.qty as float)*cast(sd.Rate as float)) as Amount from Products p, Sales_Master sm, Sales_Details sd where p.Prod_ID = sd.Prod_ID and sm.Invoice_No=sd.Invoice_No and cast(floor(cast(sm.Invoice_Date as float)) as datetime)>= '"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and  cast(floor(cast(sm.Invoice_Date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateTo.Text)).ToShortDateString()+"' group by p.Prod_Name, p.Pack_Type";
				//
				//				dbobj.SelectQuery(sql,ref rdr);
				//				if(rdr.HasRows)
				//				{
				//					grdLeg1.DataSource=rdr;
				//					grdLeg1.DataBind();
				//					grdLeg1.Visible=true;
				//				}
				//				else
				//				{
				//					grdLeg1.Visible=false;
				//					RMG.MessageBox.Show("Data not available");
				//				}
				//				dbobj.Dispose();
				CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:cmdrpt_Click");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:cmdrpt_Click"+ ex.Message+". User: "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select p.Prod_Name + ' ' + p.Pack_Type AS Prod_Name, p.Pack_Type, sum(cast(sd.qty as float)) as Sales, sum(cast(sd.qty as float)*cast(sd.Rate as float)) as Amount from Products p, Sales_Master sm, Sales_Details sd where p.Prod_ID = sd.Prod_ID and sm.Invoice_No=sd.Invoice_No and cast(floor(cast(sm.Invoice_Date as float)) as datetime)>= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and  cast(floor(cast(sm.Invoice_Date as float)) as datetime)<='"+ GenUtil.str2MMDDYYYY(txtDateTo.Text) + "' group by p.Prod_Name, p.Pack_Type";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "Products");
			DataTable dtCustomers = ds.Tables["Products"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				grdLeg1.DataSource = dv;
				grdLeg1.DataBind();
				grdLeg1.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				grdLeg1.Visible=false;
			}
			SqlCon.Dispose();
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnSortCommand"
		/// </summary>
		public void SortCommand_Click(object sender,DataGridSortCommandEventArgs e)
		{
			try
			{
				//Check to see if same column clicked again
				if(e.SortExpression.ToString().Equals(Session["Column"]))
				{
					if(Session["Order"].Equals("ASC"))
					{
						strOrderBy=e.SortExpression.ToString() +" DESC";
						Session["Order"]="DESC";
					}
					else
					{
						strOrderBy=e.SortExpression.ToString() +" ASC";
						Session["Order"]="ASC";
					}
				}
					//Different column selected, so default to ascending order
				else
				{
					strOrderBy = e.SortExpression.ToString() +" ASC";
					Session["Order"] = "ASC";
				}
				Session["Column"] = e.SortExpression.ToString();
				BindTheData();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}
		
		/// <summary>
		/// This method is not used.
		/// </summary>
		private string GetString(string str,string spc)
		{
			if(str.Length>spc.Length)
				return str;
			else
				return str+spc.Substring(0,spc.Length-str.Length)+"  ";			
		}
	
		/// <summary>
		/// This method is not used.
		/// </summary>
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len3)
		{
			while(rdr.Read())
			{
				if(rdr["Prod_Name"].ToString().Trim().Length>len1)
					len1=rdr["Prod_Name"].ToString().Trim().Length;					
				if(rdr["Amount"].ToString().Trim().Length>len3)
					len3=rdr["Amount"].ToString().Trim().Length;
			}
		}
		/// <summary>
		/// This method is not used.
		/// </summary>
		private string GetString(string str,int maxlen,string spc)
		{		
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
		}
		/// <summary>
		/// This method is not used.
		/// </summary>
		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
		}

		/// <summary>
		/// This method is used to Sends the text file to print server to print.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
				makingReport();
				// Establish the remote endpoint for the socket.
				// The name of the
				// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,60000);

				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );

				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);

					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\ProductWiseReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:print");
                
				} 
				catch (ArgumentNullException ane) 
				{
					//Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:print"+ ane.Message+". User: "+uid);
				} 
				catch (SocketException se) 
				{
					///Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:print"+ se.Message+". User: "+uid);
				} 
				catch (Exception es) 
				{
					//Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:print"+ es.Message+". User: "+uid);
				}

			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:print"+ ex.Message+". User: "+uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(grdLeg1.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method: btnExcel_Click, ProductWiseSales Report Convert Into Excel Format ,  userid  "+uid);
				}
				else
				{
					MessageBox.Show("Please Click the View Button First");
					return;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:btnExcel_Click   ProductWiseSales Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}