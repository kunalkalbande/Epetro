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
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using DBOperations; 

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for CustomerWiseReconsi.
	/// </summary>
	public class CustomerWiseReconsi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateFrom;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateTo;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.DataGrid GridReport;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnExcel;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerwiseReconsi.aspx,Class:PetrolPumpClass,Method:page_load"+ "  EXCEPTION "+ex.Message+"  userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				GridReport.Visible=false;
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="38";
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
				txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
				Textbox1.Text = DateTime.Now.Day+ "/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year;
			}
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
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to Returns date in MM/DD/YYYY format.
		/// </summary>
		public DateTime ToMMddYYYY(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];			
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);			
			return(dt);
		}

		/// <summary>
		/// This method is not used
		/// </summary>
		protected string Stop(string str)
		{
			if(str.IndexOf(".")>0)
			{
				string ret=str.Substring(0,str.IndexOf(".")+3);
				return ret;
			}
			else
				return str;
		}
		
		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DateTime.Compare(ToMMddYYYY(txtDateFrom.Text),ToMMddYYYY(Textbox1.Text))>0)
				{
					MessageBox.Show("Date From Should be less than Date To");
					GridReport.Visible=false;
				}
				else
				{
					/*PetrolPumpClass  obj=new PetrolPumpClass();
					SqlDataReader SqlDtr;
					string sql;
					#region Bind DataGrid
					sql="select distinct m.invoice_no, m.invoice_date, m.vehicle_no,m.net_amount,m.slip_no,c.cust_name from sales_master m,Slip s, Customer c where m.cust_id=c.cust_id and c.cust_id=s.cust_id and s.cust_id=m.cust_id and m.slip_no!=0 and m.Invoice_Date  between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(Textbox1.Text) +"')";
					SqlDtr =obj.GetRecordSet(sql);
					GridReport.DataSource=SqlDtr;
					GridReport.DataBind();*/
					strOrderBy = "Cust_Name ASC";
					Session["Column"] = "Cust_Name";
					Session["Order"] = "ASC";
					BindTheData();
					
					//					if(GridReport.Items.Count==0)
					//					{
					//						MessageBox.Show("Data not available");
					//						GridReport.Visible=false;
					//					}
					//					else
					//					{
					//						GridReport.Visible=true;
					//					}
					//SqlDtr.Close();
					//#endregion
				}
				CreateLogFiles.ErrorLog("Form:CustomerwiseReconsi.aspx,Class:PetrolPumpClass,Method:btnShow_Click"+ " CustomerwiseReconcelation Report  Viewed "+" userid "+ uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerwiseReconsi.aspx,Class:PetrolPumpClass,Method:btnShow_Click"+  " CustomerwiseReconcelation Report  Viewed "+"  EXCEPTION "+ex.Message+" userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select distinct m.invoice_no, m.invoice_date, m.vehicle_no,m.net_amount,m.slip_no,c.cust_name from sales_master m,Slip s, Customer c where m.cust_id=c.cust_id and c.cust_id=s.cust_id and s.cust_id=m.cust_id and m.slip_no!=0 and m.Invoice_Date  between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(Textbox1.Text) +"')";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "custout");
			DataTable dtCustomers = ds.Tables["custout"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count==0)
			{
				MessageBox.Show("Data not available");
				GridReport.Visible=false;
			}
			else
			{
				GridReport.DataSource=dv;
				GridReport.DataBind();
				GridReport.Visible=true;
			}
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
				CreateLogFiles.ErrorLog("Form:CustomerWiseReconsi.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This Method is used to make the report file.
		/// </summary>
		public void MakingReport() // Prafull
		{
			System.Data.SqlClient.SqlDataReader rdr=null;
			string sql  = "";
			string info = "";
			double Total = 0;
			
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CustomerWiseSlipReport.txt";
			StreamWriter sw = new StreamWriter(path);

			sql="select distinct m.invoice_no, m.invoice_date, m.vehicle_no,m.net_amount,m.slip_no,c.cust_name from sales_master m,Slip s, Customer c where m.cust_id=c.cust_id and c.cust_id=s.cust_id and s.cust_id=m.cust_id and m.slip_no!=0 and m.Invoice_Date  between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(Textbox1.Text) +"') order by "+Cache["strOrderBy"]+"";
						
			dbobj.SelectQuery(sql,ref rdr);
			/*
+------------------------------+-------+----------+--------------+-----------+
| Customer Name                |Slip No|Invoice No| Vehicle No   | Amount    |
+------------------------------+-------+----------+--------------+-----------+
 Vishal H Kadam                 1234567 1234567890 12345678901234 12345678901      

						 
			 */
			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu
				

			// Condensed
			sw.Write((char)27);//added by vishnu
			sw.Write((char)15);
			sw.WriteLine("");
			//**********
			string des="------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("======================================================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("CUSTOMER WISE SLIP REPORT From "+txtDateFrom.Text.ToString()+" To "+Textbox1.Text.ToString(),des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("======================================================",des.Length));
			sw.WriteLine("+------------------------------+-------+----------+--------------+-----------+");
			sw.WriteLine("| Customer Name                |Slip No|Invoice No| Vehicle No   | Amount    |");
			sw.WriteLine("+------------------------------+-------+----------+--------------+-----------+");
			//             Vishal H Kadam                 1234567 1234567890 12345678901234 12345678901 

			if(rdr.HasRows)
			{
				while(rdr.Read())  // 
				{
					Total = Total +System.Convert.ToDouble(rdr["net_amount"].ToString().Trim());
					// info: to display the string into the specified formats
					info = " {0,-30:S} {1,7:D} {2,10:D} {3,-14:S} {4,11:F}";
					sw.WriteLine(info,GenUtil.TrimLength(rdr["cust_name"].ToString().Trim(),30),
						rdr["slip_no"].ToString().Trim(),
						rdr["invoice_no"].ToString(),
						rdr["vehicle_no"].ToString().Trim(),
						GenUtil.strNumericFormat(rdr["net_amount"].ToString().Trim())
						);
				}

				sw.WriteLine("+------------------------------+-------+----------+--------------+-----------+");
				sw.WriteLine("                                                          Total  :{0,11:F}",GenUtil.strNumericFormat(Total.ToString()) );
				sw.WriteLine("+------------------------------+-------+----------+--------------+-----------+");
			}
			dbobj.Dispose();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string sql="";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\CustomerWiseReconsi.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			double Total = 0;
			sql="select distinct m.invoice_no, m.invoice_date, m.vehicle_no,m.net_amount,m.slip_no,c.cust_name from sales_master m,Slip s, Customer c where m.cust_id=c.cust_id and c.cust_id=s.cust_id and s.cust_id=m.cust_id and m.slip_no!=0 and m.Invoice_Date  between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(Textbox1.Text) +"') order by "+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+Textbox1.Text);
			sw.WriteLine("Customer Name\tSlip No\tInvoice No\tVehicle No\tAmount");
			while(rdr.Read())
			{
				Total = Total +System.Convert.ToDouble(rdr["net_amount"].ToString().Trim());
				sw.WriteLine(rdr["cust_name"].ToString().Trim()+"\t"+
					rdr["slip_no"].ToString().Trim()+"\t"+
					rdr["invoice_no"].ToString()+"\t"+
					rdr["vehicle_no"].ToString().Trim()+"\t"+
					GenUtil.strNumericFormat(rdr["net_amount"].ToString().Trim())
					);
			}
			sw.WriteLine("Total\t\t\t\t"+GenUtil.strNumericFormat(Total.ToString()));
			rdr.Close();
			sw.Close();
		}

		/// <summary>
		/// This method is not used
		/// </summary>
		private string GetString(string str,string spc)
		{
			if(str.Length>spc.Length)
				return str;
			else
				return str+spc.Substring(0,spc.Length-str.Length)+"  ";			
		}
				
		/// <summary>
		/// This method is not used
		/// </summary>
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5)
		{
			while(rdr.Read())
			{
				if(rdr["cust_name"].ToString().Trim().Length>len1)
					len1=rdr["cust_name"].ToString().Trim().Length;
				if(rdr["slip_no"].ToString().Trim().Length>len2)
					len2=rdr["slip_no"].ToString().Trim().Length;					
				if(rdr["invoice_no"].ToString().Trim().Length>len3)
					len3=rdr["invoice_no"].ToString().Trim().Length;					
				if(rdr["vehicle_no"].ToString().Trim().Length>len4)
					len4=rdr["vehicle_no"].ToString().Trim().Length;
				if(rdr["net_amount"].ToString().Trim().Length>len5)
					len5=rdr["net_amount"].ToString().Trim().Length;					
			}
		}
		
		/// <summary>
		/// This method is not used
		/// </summary>
		private string GetString(string str,int maxlen,string spc)
		{		
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
		}

		/// <summary>
		/// This method is not used
		/// </summary>
		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
		}
	
		/// <summary>
		/// This method is used to sends the text file to print server to print.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
				MakingReport();
					
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CustomerWiseSlipReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:CustomerwiseReconsi.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CustomerwiseReconcelation Report  Viewed "+" userid  "+uid);
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerwiseReconsi.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CustomerwiseReconcelation Report  Viewed  "+ "  EXCEPTION "+ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerwiseReconsi.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CustomerwiseReconcelation Report  Viewed  "+ "  EXCEPTION "+se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerwiseReconsi.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CustomerwiseReconcelation Report  Viewed  "+ "  EXCEPTION "+es.Message+"  userid  "+uid);
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:CustomerwiseReconsi.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CustomerwiseReconcelation Report  Viewed  "+ "  EXCEPTION "+ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// Prepares the excel report file CustomerWiseReconsi.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:CustomerWiseReconsi.aspx,Method: btnExcel_Click, CustomerWiseReconsi Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:CustomerWiseReconsi.aspx,Method:btnExcel_Click  CustomerWiseReconsi Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
		
		double Tot=0;
		/// <summary>
		/// This method is used to calculate the total amount.
		/// </summary>
		public string GetTotal(string str)
		{
			Tot+=double.Parse(str);
			Cache["amt"]=Tot.ToString();
			return str;
		}
	}
}