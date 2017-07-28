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
using EPetro.Sysitem.Classes;
using System.Data.SqlClient;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using RMG;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for PriceList.
	/// </summary>
	public class PriceList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid GridReport;
		protected System.Web.UI.WebControls.Button Btnprint;
		protected System.Web.UI.WebControls.Button Button1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList DropProdName;
		string strOrderBy="";

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
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
				CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:pageload"+ ex.Message+ "  EXCEPTION" +uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
				txtDateTo.Text = DateTime.Now.Day+ "/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year;
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="7";
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
				SqlDataReader rdr=null;
				dbobj.SelectQuery("select distinct Prod_Name from Products order by Prod_Name",ref rdr);
				DropProdName.Items.Clear();
				DropProdName.Items.Add("All");
				while(rdr.Read())
				{
					DropProdName.Items.Add(rdr["Prod_Name"].ToString());
				}
				rdr.Close();

			}
		}

		//		private string GetString(string str,string spc)
		//		{
		//			if(str.Length>spc.Length)
		//				return str;
		//			else
		//				return str+spc.Substring(0,spc.Length-str.Length)+"  ";			
		//		}
				
		//		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6)
		//		{
		//			while(rdr.Read())
		//			{
		//				if(rdr["Prod_ID"].ToString().Trim().Length>len1)
		//					len1=rdr["Prod_ID"].ToString().Trim().Length;					
		//				if(rdr["Prod_Name"].ToString().Trim().Length>len2)
		//					len2=rdr["Prod_Name"].ToString().Trim().Length;					
		//				if(rdr["Pack_Type"].ToString().Trim().Length>len3)
		//					len3=rdr["Pack_Type"].ToString().Trim().Length;
		//				if(rdr["Pur_Rate"].ToString().Trim().Length>len4)
		//					len4=rdr["Pur_Rate"].ToString().Trim().Length;					
		//				if(rdr["Sal_Rate"].ToString().Trim().Length>len5)
		//					len5=rdr["Sal_Rate"].ToString().Trim().Length;					
		//				if(rdr["Eff_Date"].ToString().Trim().Length>len6)
		//					len6=rdr["Eff_Date"].ToString().Trim().Length;	
		//			}
		//		}
		
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
		/// This Method is used to prepare the report file .txt to print
		/// </summary>
		public void makingReport()
		{
			/*
										======================                              
										   PRICE LIST REPORT                                 
										======================                              
+-------+----------------------+-----------+-----------+-----------+----------+
	  |Prod_ID|  Product Name           | Pack_Type | Pur_Rate  | Sal_Rate  |Eff_Date  |
	  +-------+-------------------------+-----------+-----------+-----------+----------+
	   1001    1234567890123456789012345 1X20777     12345678.00 12345678.00 DD/MM/YYYY
			*/
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\PriceListReport.txt";
			StreamWriter sw = new StreamWriter(path);

			string sql="";
			string info = "";
			string strDate = "";

			//sql="select * from vw_PriceList order by "+Cache["strOrderBy"]+"";
			if(DropProdName.SelectedIndex==0)
				sql="select * from vw_PriceList where eff_date>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and eff_date<='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by "+Cache["strOrderBy"]+"";
			else
				sql="select * from vw_PriceList where eff_date>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and eff_date<='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' and Prod_name='"+DropProdName.SelectedItem.Text+"' order by "+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			// Condensed
			/*sw.Write((char)27);
			sw.Write((char)64);
			sw.Write((char)80);
			sw.Write((char)27);
			sw.Write((char)78);//added by vishnu//for jumping
			sw.Write((char)27);
			sw.Write((char)67);*/ //this code is working 


			/*sw.Write((char)27);//working properly
			sw.Write((char)67);
			sw.Write((char)0);
			sw.Write((char)12);
			
			sw.Write((char)27);
			sw.Write((char)78);
			sw.Write((char)5);*/
			//***added by vishnu ***//
			sw.Write((char)27);
			sw.Write((char)67);
			sw.Write((char)0);
			sw.Write((char)12);

			/*sw.Write((char)27);//paper
			sw.Write((char)106);
			sw.Write((char)255);

			sw.Write((char)27);
			sw.Write((char)106);
			sw.Write((char)255);*/
			
			sw.Write((char)27);
			sw.Write((char)78);
			sw.Write((char)5);

			//sw.Write((char)27);  //added by vishnu
			//sw.Write((char)69); //69 used for Emphasised printing

			sw.Write((char)27); //added by vishnu for condensed
			sw.Write((char)15);//
			
		
			sw.WriteLine("");
			//**********
			string des="--------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("======================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("PRICE LIST REPORT",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("======================",des.Length));
			sw.WriteLine(" From Date    : "+txtDateFrom.Text);
			sw.WriteLine(" To Date      : "+txtDateTo.Text);
			sw.WriteLine(" Product Name : "+DropProdName.SelectedItem.Text);
			sw.WriteLine("+-------+-----------------------+-----------+-----------+-----------+----------+");
			sw.WriteLine("|Prod.ID|  Product Name         | Pack.Type | Pur.Rate  |Sales Rate |Eff. Date |");
			sw.WriteLine("+-------+-----------------------+-----------+-----------+-----------+----------+");
			//             1001567 12345678901234567890123 12345678901 12345678.00 12345678.00 DD/MM/YYYY
        
			if(rdr.HasRows)
			{
				// info : to set the format the displaying string.
				info = " {0,-7:S} {1,-23:S} {2,-11:S} {3,11:F} {4,11:F} {5,-10:S}"; 
				while(rdr.Read())
				{
					strDate = rdr["Eff_Date"].ToString().Trim();
					int pos = strDate.IndexOf(" ");
				
					if(pos != -1)
					{
						strDate = strDate.Substring(0,pos);
					}
					else
					{
						strDate = "";					
					}
					sw.WriteLine(info,rdr["Prod_ID"].ToString().Trim(),
						GenUtil.TrimLength(rdr["Prod_Name"].ToString().Trim(),23),
						GenUtil.TrimLength(rdr["Pack_Type"].ToString(),11),
						GenUtil.strNumericFormat(rdr["Pur_Rate"].ToString().Trim()),
						GenUtil.strNumericFormat(rdr["sal_Rate"].ToString().Trim()),
						GenUtil.str2DDMMYYYY(strDate));
				}
			}
			sw.WriteLine("+-------+-----------------------+-----------+-----------+-----------+----------+");
			//deselect condensed
			sw.Write((char)27);
			sw.Write((char)18);//ad
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
			string path = home_drive+@"\ePetro_ExcelFile\PriceListReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			if(DropProdName.SelectedIndex==0)
				sql="select * from vw_PriceList where eff_date>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and eff_date<='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by "+Cache["strOrderBy"]+"";
			else
				sql="select * from vw_PriceList where eff_date>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and eff_date<='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' and Prod_name='"+DropProdName.SelectedItem.Text+"' order by "+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+txtDateTo.Text);
			sw.WriteLine("Product Name\t"+DropProdName.SelectedItem.Text);
			sw.WriteLine("Prod.ID\tProduct Name\tPack.Type\tPur.Rate\tSales Rate\tEff. Date");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(rdr["Prod_ID"].ToString().Trim()+"\t"+
						rdr["Prod_Name"].ToString().Trim()+"\t"+
						rdr["Pack_Type"].ToString()+"\t"+
						GenUtil.strNumericFormat(rdr["Pur_Rate"].ToString().Trim())+"\t"+
						GenUtil.strNumericFormat(rdr["sal_Rate"].ToString().Trim())+"\t"+
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Eff_Date"].ToString())));
				}
			}
			dbobj.Dispose();
			sw.Close();
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Btnprint.Click += new System.EventHandler(this.Btnprint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// This method is used Sends the text file to print server to print.
		/// </summary>
		private void Btnprint_Click(object sender, System.EventArgs e)
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
					CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Price List Report  Printed"+"  userid  " +uid);
					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\PriceListReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Price List Report  Printed"+"  EXCEPTION "+ane.Message+"  userid  " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Price List Report  Printed"+"  EXCEPTION "+se.Message+"  userid  " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Price List Report  Printed"+"  EXCEPTION "+es.Message+"  userid  " +uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Price List Report  Printed"+"  EXCEPTION "+ex.Message+"  userid  " +uid);
			}
		}

		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{ 
			try
			{
				//			PetrolPumpClass  obj=new PetrolPumpClass();
				//			SqlDataReader SqlDtr;
				//			string sql;

				#region Bind DataGrid
				strOrderBy = "Prod_ID ASC";
				Session["Column"] = "Prod_ID";
				Session["Order"] = "ASC";
				BindTheData();
				//			sql="select * from vw_PriceList order by Prod_id";
				//			SqlDtr =obj.GetRecordSet(sql);
				//			GridReport.DataSource=SqlDtr;
				//			GridReport.DataBind();
				//			SqlDtr.Close();
				#endregion
				CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:Button1_Click    Price List Report Viewed   "+  " userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:Button1_Click    Price List Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
				
			}
		}

		/// <summary>
		/// This methos is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			//string sqlstr="select * from vw_PriceList order by Prod_id";
			string sqlstr="";
			if(DropProdName.SelectedIndex==0)
				sqlstr="select * from vw_PriceList where eff_date>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and eff_date<='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'";
			else
				sqlstr="select * from vw_PriceList where eff_date>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and eff_date<='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' and Prod_name='"+DropProdName.SelectedItem.Text+"'";

			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "vw_PriceList");
			DataTable dtCustomers = ds.Tables["vw_PriceList"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"] = strOrderBy;
			if(dv.Count!=0)
			{
				GridReport.DataSource = dv;
				GridReport.DataBind();
				GridReport.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:PriceList.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:PriceList.aspx,Method: btnExcel_Click, PriceList Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:PriceList.aspx,Method:btnExcel_Click   PriceList Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}