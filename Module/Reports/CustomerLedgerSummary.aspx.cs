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
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Sockets;
using EPetro.Sysitem.Classes ;
using System.IO;
using System.Text;
using RMG;


namespace EPetro.Module.Accounts
{
	/// <summary>
	/// This report show the all customer ledger summary in debit or credit format.
	/// </summary>
	public class ViewAccounts : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList drpOptions;
		protected System.Web.UI.WebControls.DropDownList drpcustype;
		protected System.Web.UI.WebControls.Button cmdrpt;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.DataGrid grdLeg;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.DataGrid Datagrid3;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		public string strOrderBy="";	
		string uid;
		string dt1="";
		/*bhal*/	double totalcr=0;
		/*bhal*/	double totaldr=0;
		/*bhal*/	double totalcrlim=0;
		protected System.Web.UI.WebControls.Button btnExcel;
		/*bhal*/	double totaldrlim=0;

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
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:pageload" + ex.Message+"  EXCEPTION     userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			try
			{
				if(!IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="17";
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
					txtDateTo.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:pageload" + ex.Message+"    "+ex.StackTrace+"  EXCEPTION     userid  "+uid);
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
			this.cmdrpt.Click += new System.EventHandler(this.cmdrpt_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to return date in MM-DD-YYYY format.
		/// </summary>
		public string ToSplit(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			dt1 = yy+"-"+mm+"-"+dd;
			return(dt1);
		}
 
		/// <summary>
		/// This method is used to return date in MM/DD/YYYY format.
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
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void MakingReport()
		{
			// From Date = txtDateTo;
			// To Date   = txtDateFrom; 

			/*
									 =================================                     
										CUSTOMER OUTSTANDING REPORT                         
									 =================================                     
			+-------------------------+---------------+---------------+-----------+-----------+ 
			|     Customer Name       |     City      | Customer Type | Dr.Amount | Cr.Amount |
			+-------------------------+---------------+---------------+-----------+-----------+
			 1234567890123456789012345 123456789012345 123456789012345 12345678.00 12345678.00 
			*/
			
			try
			{
				System.Data.SqlClient.SqlDataReader rdr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CustomerLedgerReport.txt";
				StreamWriter sw = new StreamWriter(path);

				string info = "";
				string strOpBalDr= "";
				string strOpBalCr= "";
					
				object op=null;	
				int x=0;
				string sql="select distinct cust_id from Customer";
				// Called the Procedure Sp_CustOustanding for each customer, and create one custout temp. table.
				dbobj.SelectQuery(sql,ref rdr);
				while(rdr.Read())
					dbobj.ExecProc(OprType.Insert,"Sp_CustOutstanding ",ref op,"@id",Int32.Parse(rdr["cust_id"].ToString()),"@fromdate",getdate(txtDateTo.Text,true),"@todate",getdate(txtDateFrom.Text,true));
				rdr.Close();

				if(drpcustype.SelectedItem.Value=="All")  
				{
					sql = "select * from custout"; 
				}
				else
				{
					sql = "select * from custout where Cust_Type = '"+ drpcustype.SelectedItem.Value+"'";
				}
				sql=sql+" order by "+Cache["strOrderBy"]+"";
				dbobj.SelectQuery(sql,ref rdr);
				/*
				+-------------------------+---------------+---------------+-----------+-----------+-----------+-----------+---------------+
				|     Customer Name       |     City      | Customer Type |   Opening Balance     |   Closing Balance     | Total Balance |
				|                         |               |               | Dr.Amount | Cr.Amount | Dr.Amount | Cr.Amount |               |
				+-------------------------+---------------+---------------+-----------+-----------+-----------+-----------+---------------+
				*/
				string des="";
				
				sw.Write((char)27);//added by vishnu
				sw.Write((char)67);//added by vishnu
				sw.Write((char)0);//added by vishnu
				sw.Write((char)12);//added by vishnu
			
				sw.Write((char)27);//added by vishnu
				sw.Write((char)78);//added by vishnu
				sw.Write((char)5);//added by vishnu
				
				// Condensed
				sw.Write((char)15);
				sw.WriteLine("");
				if (drpOptions.SelectedItem.Value=="All")
				{
					//**********
					//des="------------------------------------------------------------------------------------------------------------------------";
					des="----------------------------------------------------------------------------------------------------------";
					string Address=GenUtil.GetAddress();
					string[] addr=Address.Split(new char[] {':'},Address.Length);
					sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
					sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
					sw.WriteLine(des);
					//**********
					sw.WriteLine(GenUtil.GetCenterAddr("===========================",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("CUSTOMER LEDGER SUMMARY",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("===========================",des.Length));
				}
				if (drpOptions.SelectedItem.Value=="Total Balance")
				{
					//**********
					//des="------------------------------------------------------------------------";
					des="----------------------------------------------------------";
					string Address=GenUtil.GetAddress();
					string[] addr=Address.Split(new char[] {':'},Address.Length);
					sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
					sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
					sw.WriteLine(des);
					//**********
					sw.WriteLine(GenUtil.GetCenterAddr("===========================",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("CUSTOMER LEDGER SUMMARY",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("===========================",des.Length));
				}
				if (drpOptions.SelectedItem.Value=="Opening Balance")
				{
					//**********
					//des="--------------------------------------------------------------------------------";
					des="------------------------------------------------------------------";
					string Address=GenUtil.GetAddress();
					string[] addr=Address.Split(new char[] {':'},Address.Length);
					sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
					sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
					sw.WriteLine(des);
					//**********
					sw.WriteLine(GenUtil.GetCenterAddr("===========================",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("CUSTOMER LEDGER SUMMARY",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("===========================",des.Length));
				}
				if (drpOptions.SelectedItem.Value=="Transaction")
				{
					//**********
					//des="--------------------------------------------------------------------------------";
					des="------------------------------------------------------------------";
					string Address=GenUtil.GetAddress();
					string[] addr=Address.Split(new char[] {':'},Address.Length);
					sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
					sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
					sw.WriteLine(des);
					//**********
					sw.WriteLine(GenUtil.GetCenterAddr("===========================",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("CUSTOMER LEDGER SUMMARY",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("===========================",des.Length));
				}
				
				sw.WriteLine("Customer Category : "+drpcustype.SelectedItem.Text.ToString()) ;
				sw.WriteLine("Balance Type      : "+drpOptions.SelectedItem.Text.ToString()) ;
				sw.WriteLine("From              : "+txtDateTo.Text.ToString()) ;
				sw.WriteLine("To                : "+txtDateFrom.Text.ToString()); 
				if (drpOptions.SelectedItem.Value=="All")
				{
					sw.WriteLine("+------------------------+---------------+-----------+-----------+-----------+-----------+---------------+");
					sw.WriteLine("|     Customer Name      |     City      |   Opening Balance     |     Transaction       |Closing Balance|");
					sw.WriteLine("|                        |               | Dr.Amount | Cr.Amount | Dr.Amount | Cr.Amount |               |");
					sw.WriteLine("+------------------------+---------------+-----------+-----------+-----------+-----------+---------------+");
					//			   123456789012345678901234 123456789012345 12345678901 12345678901 12345678901 12345678901 123456789012345
					//info = " {0,-24:S} {1,-15:S} {2,-13:S} {3,11:F} {4,11:F} {5,11:F} {6,11:F} {7,15:S}";
					info = " {0,-24:S} {1,-15:S} {2,11:S} {3,11:F} {4,11:F} {5,11:F} {6,15:F}";
				}

				if (drpOptions.SelectedItem.Value=="Opening Balance")
				{
					
					sw.WriteLine("+------------------------+---------------+-----------+-----------+");
					sw.WriteLine("|     Customer Name      |     City      |   Opening Balance     |");
					sw.WriteLine("|                        |               | Dr.Amount | Cr.Amount |");
					sw.WriteLine("+------------------------+---------------+-----------+-----------+");
					info = " {0,-24:S} {1,-15:S} {2,11:F} {3,11:F}";
				}

				if (drpOptions.SelectedItem.Value=="Transaction")
				{
					sw.WriteLine("+------------------------+---------------+-----------+-----------+");
					sw.WriteLine("|     Customer Name      |     City      |     Transaction       |");
					sw.WriteLine("|                        |               | Dr.Amount | Cr.Amount |");
					sw.WriteLine("+------------------------+---------------+-----------+-----------+");
					info = " {0,-24:S} {1,-15:S} {2,11:F} {3,11:F}";
				}

				if (drpOptions.SelectedItem.Value=="Total Balance")
				{
					
					sw.WriteLine("+------------------------+---------------+---------------+");
					sw.WriteLine("|     Customer Name      |     City      |Closing Balance|");
					sw.WriteLine("|                        |               |               |");
					sw.WriteLine("+------------------------+---------------+---------------+");
					info = " {0,-24:S} {1,-15:S} {2,15:S}";
				}

				/*
				sw.WriteLine("+-------------------------+---------------+---------------+-----------+-----------+");
				sw.WriteLine("|     Customer Name       |     City      | Customer Type | Dr.Amount | Cr.Amount |");
				sw.WriteLine("+-------------------------+---------------+---------------+-----------+-----------+");
				*/
				//              		       1234567890123456789012345 123456789012345 123456789012345 12345678.00 12345678.00 
                        
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{
						if (drpOptions.SelectedItem.Value=="All")
						{
							if(rdr["Balance_Type"].ToString().Equals("Dr."))
							{
								strOpBalDr = rdr["Op_Balance"].ToString().Trim();
								strOpBalCr = "0";
							}
							else
							{
								strOpBalCr = rdr["Op_Balance"].ToString().Trim();
								strOpBalDr = "0";
							}
							sw.WriteLine(info,GenUtil.TrimLength(rdr["Cust_Name"].ToString().Trim(),24),
								GenUtil.TrimLength(rdr["City"].ToString().Trim(),15),
								//GenUtil.TrimLength(rdr["Cust_Type"].ToString(),13),
								GenUtil.strNumericFormat(strOpBalDr),
								GenUtil.strNumericFormat(strOpBalCr),
								GenUtil.strNumericFormat(rdr["DebitAmount"].ToString()),
								GenUtil.strNumericFormat(rdr["CreditAmount"].ToString()),
								GenUtil.strNumericFormat(rdr["Balance"].ToString()) + " " + rdr["BalanceType"].ToString()
								);
						}
						if (drpOptions.SelectedItem.Value=="Opening Balance")
						{
							if(rdr["Balance_Type"].ToString().Equals("Dr."))
							{
								strOpBalDr = rdr["Op_Balance"].ToString().Trim();
								strOpBalCr = "0";
							}
							else
							{
								strOpBalCr = rdr["Op_Balance"].ToString().Trim();
								strOpBalDr = "0";
							}
							sw.WriteLine(info,GenUtil.TrimLength(rdr["Cust_Name"].ToString().Trim(),24),
								GenUtil.TrimLength(rdr["City"].ToString().Trim(),15),
								//GenUtil.TrimLength(rdr["Cust_Type"].ToString(),13),
								GenUtil.strNumericFormat(strOpBalDr),
								GenUtil.strNumericFormat(strOpBalCr)
								);
						}
						if (drpOptions.SelectedItem.Value=="Transaction")
						{
							if(rdr["Balance_Type"].ToString().Equals("Dr."))
							{
								strOpBalDr = rdr["Op_Balance"].ToString().Trim();
								strOpBalCr = "0";
							}
							else
							{
								strOpBalCr = rdr["Op_Balance"].ToString().Trim();
								strOpBalDr = "0";
							}
							sw.WriteLine(info,GenUtil.TrimLength(rdr["Cust_Name"].ToString().Trim(),24),
								GenUtil.TrimLength(rdr["City"].ToString().Trim(),15),
								//GenUtil.TrimLength(rdr["Cust_Type"].ToString(),13),
								GenUtil.strNumericFormat(rdr["DebitAmount"].ToString()),
								GenUtil.strNumericFormat(rdr["CreditAmount"].ToString())
								);
						}
						if (drpOptions.SelectedItem.Value=="Total Balance")
						{						
							sw.WriteLine(info,GenUtil.TrimLength(rdr["Cust_Name"].ToString().Trim(),24),
								GenUtil.TrimLength(rdr["City"].ToString().Trim(),15),
								//GenUtil.TrimLength(rdr["Cust_Type"].ToString(),13),
								GenUtil.strNumericFormat(rdr["Balance"].ToString()) + " " + rdr["BalanceType"].ToString()
							
								);
						}
					}
				}
				if (drpOptions.SelectedItem.Value=="All")
				{
					sw.WriteLine("+------------------------+---------------+-----------+-----------+-----------+-----------+---------------+");
					sw.WriteLine(info,"Total","",GenUtil.strNumericFormat((Cache["os1"]).ToString()),GenUtil.strNumericFormat((Cache["os2"]).ToString()),GenUtil.strNumericFormat((Cache["os"]).ToString()),GenUtil.strNumericFormat((Cache["tr"]).ToString()),Cache["closeAll"].ToString());
					sw.WriteLine("+------------------------+---------------+-----------+-----------+-----------+-----------+---------------+");
					// deselect Condensed
					//sw.Write((char)18);
					//sw.Write((char)12);
				}
				else if(drpOptions.SelectedItem.Value=="Total Balance")
				{
					sw.WriteLine("+------------------------+---------------+---------------+");
					sw.WriteLine(info,"Total","",Cache["closing"]);
					sw.WriteLine("+------------------------+---------------+---------------+");
				}
				else if(drpOptions.SelectedItem.Value=="Opening Balance")
				{
					sw.WriteLine("+------------------------+---------------+-----------+-----------+");
					sw.WriteLine(info,"Total","",GenUtil.strNumericFormat((Cache["os1"]).ToString()),GenUtil.strNumericFormat((Cache["os2"]).ToString()));
					sw.WriteLine("+------------------------+---------------+-----------+-----------+");
				}
				else if(drpOptions.SelectedItem.Value=="Transaction")
				{
					sw.WriteLine("+------------------------+---------------+-----------+-----------+");
					sw.WriteLine(info,"Total","",GenUtil.strNumericFormat((Cache["tr1"]).ToString()),GenUtil.strNumericFormat((Cache["tr2"]).ToString()));
					sw.WriteLine("+------------------------+---------------+-----------+-----------+");
				}

				dbobj.Insert_or_Update("truncate table custout", ref x);
				dbobj.Dispose();
				sw.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:makingReport() "+"  Customerwise Outstanding Report Viewed  for customer "+drpcustype.SelectedItem.Text+ "  for balance type "+ Session["Btype"].ToString()+"  EXCEPTION  "+ex.Message+" userid "+uid );
			}
		}
		
		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\CustomerLedgerSummary.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			object op=null;	
			int x=0;
			string strOpBalDr= "";
			string strOpBalCr= "";
			string sql="select distinct cust_id from Customer";
			// Called the Procedure Sp_CustOustanding for each customer, and create one custout temp. table.
			dbobj.SelectQuery(sql,ref rdr);
			while(rdr.Read())
				dbobj.ExecProc(OprType.Insert,"Sp_CustOutstanding ",ref op,"@id",Int32.Parse(rdr["cust_id"].ToString()),"@fromdate",getdate(txtDateTo.Text,true),"@todate",getdate(txtDateFrom.Text,true));
			rdr.Close();

			if(drpcustype.SelectedItem.Value=="All")  
			{
				sql = "select * from custout"; 
			}
			else
			{
				sql = "select * from custout where Cust_Type = '"+ drpcustype.SelectedItem.Value+"'";
			}
			sql=sql+" order by "+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			
			sw.WriteLine("Customer Category\t"+drpcustype.SelectedItem.Text.ToString()) ;
			sw.WriteLine("Balance Type\t"+drpOptions.SelectedItem.Text.ToString()) ;
			sw.WriteLine("From\t"+txtDateTo.Text.ToString()) ;
			sw.WriteLine("To\t"+txtDateFrom.Text.ToString()); 
			if(drpOptions.SelectedItem.Value=="All")
				sw.WriteLine("Customer Name\tCity\tOpening Bal Dr. Amt\tOpening Bal. Cr. Amt\tTransaction Dr. Amt\tTransaction Cr. Amt\tClosing Balance");
			else if(drpOptions.SelectedItem.Value=="Opening Balance")
				sw.WriteLine("Customer Name\tCity\tOpening Bal. Dr. Amt\tOpening Bal. Cr. Amt");
			else if(drpOptions.SelectedItem.Value=="Transaction")
				sw.WriteLine("Customer Name\tCity\tTransaction Dr. Amt\tTransaction Cr. Amt");
			else if(drpOptions.SelectedItem.Value=="Total Balance")
				sw.WriteLine("Customer Name\tCity\tClosing Balance");
			while(rdr.Read())
			{
				if(drpOptions.SelectedItem.Value=="All")
				{
					if(rdr["Balance_Type"].ToString().Equals("Dr."))
					{
						strOpBalDr = rdr["Op_Balance"].ToString().Trim();
						strOpBalCr = "0";
					}
					else
					{
						strOpBalCr = rdr["Op_Balance"].ToString().Trim();
						strOpBalDr = "0";
					}
					sw.WriteLine(rdr["Cust_Name"].ToString().Trim()+"\t"+
						rdr["City"].ToString().Trim()+"\t"+
						//rdr["Cust_Type"].ToString()+"\t"+
						GenUtil.strNumericFormat(strOpBalDr)+"\t"+
						GenUtil.strNumericFormat(strOpBalCr)+"\t"+
						GenUtil.strNumericFormat(rdr["DebitAmount"].ToString())+"\t"+
						GenUtil.strNumericFormat(rdr["CreditAmount"].ToString())+"\t"+
						GenUtil.strNumericFormat(rdr["Balance"].ToString()) + " " + rdr["BalanceType"].ToString()
						);
				}
				if (drpOptions.SelectedItem.Value=="Opening Balance")
				{
					if(rdr["Balance_Type"].ToString().Equals("Dr."))
					{
						strOpBalDr = rdr["Op_Balance"].ToString().Trim();
						strOpBalCr = "0";
					}
					else
					{
						strOpBalCr = rdr["Op_Balance"].ToString().Trim();
						strOpBalDr = "0";
					}
					sw.WriteLine(rdr["Cust_Name"].ToString().Trim()+"\t"+
						rdr["City"].ToString().Trim()+"\t"+
						//rdr["Cust_Type"].ToString()+"\t"+
						GenUtil.strNumericFormat(strOpBalDr)+"\t"+
						GenUtil.strNumericFormat(strOpBalCr)
						);
				}
				if (drpOptions.SelectedItem.Value=="Transaction")
				{
					if(rdr["Balance_Type"].ToString().Equals("Dr."))
					{
						strOpBalDr = rdr["Op_Balance"].ToString().Trim();
						strOpBalCr = "0";
					}
					else
					{
						strOpBalCr = rdr["Op_Balance"].ToString().Trim();
						strOpBalDr = "0";
					}
					sw.WriteLine(rdr["Cust_Name"].ToString().Trim()+"\t"+
						rdr["City"].ToString().Trim()+"\t"+
						//rdr["Cust_Type"].ToString()+"\t"+
						GenUtil.strNumericFormat(rdr["DebitAmount"].ToString())+"\t"+
						GenUtil.strNumericFormat(rdr["CreditAmount"].ToString())
						);
				}
				if (drpOptions.SelectedItem.Value=="Total Balance")
				{						
					sw.WriteLine(rdr["Cust_Name"].ToString().Trim()+"\t"+
						rdr["City"].ToString().Trim()+"\t"+
						//rdr["Cust_Type"].ToString()+"\t"+
						GenUtil.strNumericFormat(rdr["Balance"].ToString()) + " " + rdr["BalanceType"].ToString()
						);
				}
			}
			if (drpOptions.SelectedItem.Value=="All")
				sw.WriteLine("Total\t\t"+GenUtil.strNumericFormat((Cache["os1"]).ToString())+"\t"+GenUtil.strNumericFormat((Cache["os2"]).ToString())+"\t"+GenUtil.strNumericFormat((Cache["os"]).ToString())+"\t"+GenUtil.strNumericFormat((Cache["tr"]).ToString())+"\t"+Cache["closeAll"].ToString());
			else if(drpOptions.SelectedItem.Value=="Total Balance")
				sw.WriteLine("Total\t\t"+GenUtil.strNumericFormat(Cache["closing"].ToString()));
			else if(drpOptions.SelectedItem.Value=="Opening Balance")
				sw.WriteLine("Total\t\t"+GenUtil.strNumericFormat((Cache["os1"]).ToString())+"\t"+GenUtil.strNumericFormat((Cache["os2"]).ToString()));
			else if(drpOptions.SelectedItem.Value=="Transaction")
				sw.WriteLine("Total\t\t"+GenUtil.strNumericFormat((Cache["tr1"]).ToString())+"\t"+GenUtil.strNumericFormat((Cache["tr2"]).ToString()));

			dbobj.Insert_or_Update("truncate table custout", ref x);
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void cmdrpt_Click(object sender, System.EventArgs e)
		{   
			strOrderBy = "Cust_Name ASC";
			Session["Column"] = "Cust_Name";
			Session["Order"] = "ASC";
			BindTheData();
			/*Session["Btype"]=drpOptions.SelectedItem.Value;
			try
			{
				
				object op=null;	
				int x=0;
				System.Data.SqlClient.SqlDataReader rdr=null;
				string sql="select distinct cust_id from Customer";
				dbobj.SelectQuery(sql,ref rdr);
				while(rdr.Read())
					dbobj.ExecProc(OprType.Insert,"Sp_CustOutstanding ",ref op,"@id",Int32.Parse(rdr["cust_id"].ToString()),"@fromdate",getdate(txtDateTo.Text,true),"@todate",getdate(txtDateFrom.Text,true));
				rdr.Close();
				// if all customers selected .	
				
				if(drpcustype.SelectedItem.Value=="All")  
				{
					sql = "select * from custout"; 
				}
				else
				{
					sql = "select * from custout where Cust_Type = '"+ drpcustype.SelectedItem.Value+"'";
				}
				dbobj.SelectQuery(sql,ref rdr);
				if(drpOptions.SelectedItem.Value.Equals("Opening Balance"))
				{
					Datagrid1.DataSource = null;
					Datagrid1.DataBind(); 
					Datagrid2.DataSource = null;
					Datagrid2.DataBind(); 
					Datagrid3.DataSource = null;
					Datagrid3.DataBind(); 
					grdLeg.DataSource=null;				
					grdLeg.DataBind();
					if(rdr.HasRows)
					{
						grdLeg.DataSource=rdr;				
						grdLeg.DataBind();
					}
					else
					{
						MessageBox.Show("Data not available");
					}
					rdr.Close();
				}
				else if(drpOptions.SelectedItem.Value.Equals("Total Balance"))
				{    
					Datagrid1.DataSource = null;
					Datagrid1.DataBind(); 
					Datagrid2.DataSource = null;
					Datagrid2.DataBind(); 
					Datagrid3.DataSource = null;
					Datagrid3.DataBind(); 
					grdLeg.DataSource=null;				
					grdLeg.DataBind(); 
					if(rdr.HasRows)
					{
						Datagrid1.DataSource=rdr;				
						Datagrid1.DataBind();

					}
					else
					{
						MessageBox.Show("Data not available");
					}
					rdr.Close();
				}
				else if(drpOptions.SelectedItem.Value.Equals("Transaction"))
				{
					Datagrid1.DataSource = null;
					Datagrid1.DataBind(); 
					Datagrid2.DataSource = null;
					Datagrid2.DataBind(); 
					Datagrid3.DataSource = null;
					Datagrid3.DataBind(); 
					grdLeg.DataSource=null;				
					grdLeg.DataBind();
					if(rdr.HasRows)
					{
						Datagrid2.DataSource=rdr;				
						Datagrid2.DataBind();
					}
					else
					{
						MessageBox.Show("Data not available");
					}
					rdr.Close();
				}
				else if(drpOptions.SelectedItem.Value.Equals("All"))
				{
					Datagrid1.DataSource = null;
					Datagrid1.DataBind(); 
					Datagrid2.DataSource = null;
					Datagrid2.DataBind(); 
					Datagrid3.DataSource = null;
					Datagrid3.DataBind(); 
					grdLeg.DataSource=null;				
					grdLeg.DataBind();
					if(rdr.HasRows)
					{
						Datagrid3.DataSource=rdr;				
						Datagrid3.DataBind();
					}
					else
					{
						MessageBox.Show("Data not available");
					}
					rdr.Close();
				}
				else
					MessageBox.Show("Data not available");
				// Truncate the table after used
				dbobj.Insert_or_Update("truncate table custout", ref x);
				
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:cmdrpt_Click "+  Session["Btype"].ToString() +"Customerwise Outstanding Report Viewed   on date  "+ "  and date to --"+ToSplit(txtDateTo.Text)+"   For Customer  "+drpcustype.SelectedItem.Text+ "  for balance type  "+Session["Btype"].ToString() +"    userid "+uid );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:cmdrpt_Click  "+"  Customerwise Outstanding Report Viewed  for customer "+drpcustype.SelectedItem.Text+ "  for balance type "+ Session["Btype"].ToString()+"  EXCEPTION  "+ex.Message+" userid "+uid );
			}*/
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			Session["Btype"]=drpOptions.SelectedItem.Value;
			try
			{
				
				object op=null;	
				int x=0;
				System.Data.SqlClient.SqlDataReader rdr=null;
				string sql="select distinct cust_id from Customer";
				dbobj.SelectQuery(sql,ref rdr);
				while(rdr.Read())
					dbobj.ExecProc(OprType.Insert,"Sp_CustOutstanding ",ref op,"@id",Int32.Parse(rdr["cust_id"].ToString()),"@fromdate",getdate(txtDateTo.Text,true),"@todate",getdate(txtDateFrom.Text,true));
				rdr.Close();
				// if all customers selected .	
				SqlConnection SqlCon11 =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
				if(drpcustype.SelectedItem.Value=="All")  
				{
					sql = "select * from custout"; 
				}
				else
				{
					sql = "select * from custout where Cust_Type = '"+ drpcustype.SelectedItem.Value+"'";
				}
				//dbobj.SelectQuery(sql,ref rdr);
				DataSet ds= new DataSet();
				SqlDataAdapter da = new SqlDataAdapter(sql, SqlCon11);
				da.Fill(ds, "custout");
				DataTable dtCustomers = ds.Tables["custout"];
				DataView dv=new DataView(dtCustomers);
				dv.Sort = strOrderBy;
				Cache["strOrderBy"]=strOrderBy;
				if(drpOptions.SelectedItem.Value.Equals("Opening Balance"))
				{
					/*Datagrid1.DataSource = null;
					Datagrid1.DataBind(); 
					Datagrid2.DataSource = null;
					Datagrid2.DataBind(); 
					Datagrid3.DataSource = null;
					Datagrid3.DataBind(); 
					grdLeg.DataSource=null;				
					grdLeg.DataBind();*/
					//****
					//****
					//if(rdr.HasRows)
					if(dv.Count!=0)
					{
						grdLeg.DataSource=dv;				
						grdLeg.DataBind();
					}
					else
					{
						MessageBox.Show("Data not available");
					}
					//rdr.Close();
				}
				else if(drpOptions.SelectedItem.Value.Equals("Total Balance"))
				{    
					/*Datagrid1.DataSource = null;
					Datagrid1.DataBind(); 
					Datagrid2.DataSource = null;
					Datagrid2.DataBind(); 
					Datagrid3.DataSource = null;
					Datagrid3.DataBind(); 
					grdLeg.DataSource=null;				
					grdLeg.DataBind(); */
					//if(rdr.HasRows)
					if(dv.Count!=0)
					{
						Datagrid1.DataSource=dv;				
						Datagrid1.DataBind();

					}
					else
					{
						MessageBox.Show("Data not available");
					}
					//rdr.Close();
				}
				else if(drpOptions.SelectedItem.Value.Equals("Transaction"))
				{
					/*Datagrid1.DataSource = null;
					Datagrid1.DataBind(); 
					Datagrid2.DataSource = null;
					Datagrid2.DataBind(); 
					Datagrid3.DataSource = null;
					Datagrid3.DataBind(); 
					grdLeg.DataSource=null;				
					grdLeg.DataBind();*/
					//if(rdr.HasRows)
					if(dv.Count!=0)
					{
						Datagrid2.DataSource=dv;				
						Datagrid2.DataBind();
					}
					else
					{
						MessageBox.Show("Data not available");
					}
					//rdr.Close();
				}
				else if(drpOptions.SelectedItem.Value.Equals("All"))
				{
					/*Datagrid1.DataSource = null;
					Datagrid1.DataBind(); 
					Datagrid2.DataSource = null;
					Datagrid2.DataBind(); 
					Datagrid3.DataSource = null;
					Datagrid3.DataBind(); 
					grdLeg.DataSource=null;				
					grdLeg.DataBind();*/
					//if(rdr.HasRows)
					if(dv.Count!=0)
					{
						Datagrid3.DataSource=dv;				
						Datagrid3.DataBind();
					}
					else
					{
						MessageBox.Show("Data not available");
					}
					//rdr.Close();
				}
				else
					MessageBox.Show("Data not available");
				// Truncate the table after used
				dbobj.Insert_or_Update("truncate table custout", ref x);
				
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:cmdrpt_Click "+  Session["Btype"].ToString() +"Customerwise Outstanding Report Viewed   on date  "+ "  and date to --"+ToSplit(txtDateTo.Text)+"   For Customer  "+drpcustype.SelectedItem.Text+ "  for balance type  "+Session["Btype"].ToString() +"    userid "+uid );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:cmdrpt_Click  "+"  Customerwise Outstanding Report Viewed  for customer "+drpcustype.SelectedItem.Text+ "  for balance type "+ Session["Btype"].ToString()+"  EXCEPTION  "+ex.Message+" userid "+uid );
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
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid "+uid);
			}
		}

		private DateTime getdate(string dat,bool to)
		{
			string[] dt=dat.Split(new char[]{'/'},dat.Length);
			if(to)
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
			else
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
		}

		/// <summary>
		/// This method is used to Returns the value by adding the two precision after the "."
		/// </summary>
		double count=1,i=1,j=2,k=3;
		public double os=0,cs=0,tr=0;
		protected string Limit(string str)
		{
			if(!str.Equals("")) 
			{
				double temp = System.Math.Round(System.Convert.ToDouble(str),2);
				//totaldrlim+=temp;
				//totaldrlim=	System.Math.Round(System.Convert.ToDouble(totaldrlim),2);
				str = temp.ToString(); 
			}
			else
				str = "0.00";
			//**********
			if(count==i)
			{
				os+=System.Convert.ToDouble(str);
				Cache["os"]=System.Convert.ToString(os);
				i+=3;
			}
			if(count==j)
			{
				tr+=System.Convert.ToDouble(str);
				Cache["tr"]=System.Convert.ToString(tr);
				j+=3;
			}
			if(count==k)
			{
				cs+=System.Convert.ToDouble(str);
				Cache["cs"]=System.Convert.ToString(cs);
				k+=3;
			}
			count++;
			//**********
			return str;
		}

		/// <summary>
		/// This method is used to Returns the value by adding the two precision after the "."
		/// and calculate the total amount of opening bal,transaction and closing bal.
		/// </summary>
		double count2=1,i2=1,j2=2;
		public double tr1=0,tr2=0;
		protected string Limit2(string str)
		{
		
			if(!str.Equals("")) 
			{
				double temp = System.Math.Round(System.Convert.ToDouble(str),2);
				totalcrlim+=temp;
				totalcrlim=	System.Math.Round(System.Convert.ToDouble(totalcrlim),2);
				str = temp.ToString(); 
			}
			else
				str = "0.00";
			//**********
			if(count2==i2)
			{
				tr1+=System.Convert.ToDouble(str);
				Cache["tr1"]=System.Convert.ToString(tr1);
				i2+=2;
			}
			if(count2==j2)
			{
				tr2+=System.Convert.ToDouble(str);
				Cache["tr2"]=System.Convert.ToString(tr2);
				j2+=2;
			}
			count2++;
			//**********
			return str;
		}

		/// <summary>
		/// This method is used to Returns the value by adding the two precision after the "."
		/// </summary>
		public double cs1=0;
		protected string Limit1(string str)
		{
			if(!str.Equals("")) 
			{
				double temp = System.Math.Round(System.Convert.ToDouble(str),2);
				totaldrlim+=temp;
				totaldrlim=	System.Math.Round(System.Convert.ToDouble(totaldrlim),2);
				str = temp.ToString(); 
			}
			else
				str = "0.00";
			//**********
			cs1+=System.Convert.ToDouble(str);
			Cache["cs1"]=System.Convert.ToString(cs1);
			//**********
			return str;
		}
		
		/// <summary>
		/// This methods called from .aspx to check the balance type.
		/// </summary>
		public double os1=0,os2=0;
		protected string CheckCredit(string id)
		{
			System.Data.SqlClient.SqlDataReader rdr=null;
			dbobj.SelectQuery("select top 1 op_balance,balance_type from custout where cust_id='"+id+"'",ref rdr);
			if(rdr.Read())
			{
				string str="";
				if(rdr["balance_type"].ToString().ToUpper().Equals("CR."))
				{
					totalcr+= System.Convert.ToDouble(rdr["op_balance"]);
					str = rdr["op_balance"].ToString();
				}
				else
					str= "0";
				os2+=System.Convert.ToDouble(str);
				Cache["os2"]=System.Convert.ToString(os2);
				return str;
			}
			else
			{
				return "";
			}
		}

		/// <summary>
		/// This method is used to check the balance type is debit or not? called from .aspx
		/// </summary>
		protected string CheckDebit(string id)
		{
			System.Data.SqlClient.SqlDataReader rdr=null;
			
			dbobj.SelectQuery("select top 1 op_balance,balance_type from custout where cust_id='"+id+"'",ref rdr);
			string str="";
			if(rdr.Read())
			{
				if(rdr["balance_type"].ToString().ToUpper().Equals("DR."))
				{
					totaldr+= System.Convert.ToDouble(rdr["op_balance"]);
					str = rdr["op_balance"].ToString(); 
				}
				else
					str = "0";
				os1+=System.Convert.ToDouble(str);
				Cache["os1"]=System.Convert.ToString(os1);
				return str;
			}
			return "0";
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
		/// This method is not used.
		/// </summary>
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6)
		{
			while(rdr.Read())
			{
				if(rdr["Cust_Name"].ToString().Trim().Length>len1)
					len1=rdr["Cust_Name"].ToString().Trim().Length;					
				if(rdr["City"].ToString().Trim().Length>len2)
					len2=rdr["City"].ToString().Trim().Length;					
				if(rdr["Cust_Type"].ToString().Trim().Length>len3)
					len3=rdr["Cust_Type"].ToString().Trim().Length;
							
				if(rdr["DebitAmount"].ToString().Trim().Length>len4)
					len4=rdr["DebitAmount"].ToString().Trim().Length;					
				if(rdr["CreditAmount"].ToString().Trim().Length>len5)
					len5=rdr["CreditAmount"].ToString().Trim().Length;					
			}
		}

		/// <summary>
		/// This method is used to sends the text file to print server to print.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			Session["Btype"]=drpOptions.SelectedItem.Value;
			//CreateLogFiles Err = new CreateLogFiles();
			MakingReport();
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CustomerLedgerReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					//Err.ErrorLog(Server.MapPath("Logs/ErrorLog"),"Form:CustomerWiseOutstanding.aspx,Class:ObOpration_LATEST.cs,Method: BtnPrint_Click" );
					CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:BtnPrint_Click "+"  Customer Outstanding Report Printed  "+" userid "+uid );
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:BtnPrint_Click "+"  Customer Outstanding Report Printed  "+"  EXCEPTION  "+ ane.Message+" userid "+uid );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:BtnPrint_Click "+"  Customer Outstanding Report Printed  "+"  EXCEPTION  "+se.Message+" userid "+uid );
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:BtnPrint_Click "+"  Customer Outstanding Report Printed  "+"  EXCEPTION  "+ es.Message+" userid "+uid );
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerWiseOutstanding.aspx,Class:DbOperation_LETEST.cs,Method:BtnPrint_Click "+"  Customer Outstanding Report Printed  "+"  EXCEPTION  "+ ex.Message+" userid "+uid );
			}
		}

		public double baldr;
		public double balcr;
		public string CheckClosing(string bal,string baltype)
		{
			//System.Data.SqlClient.SqlDataReader rdr=null;
			//dbobj.SelectQuery("select top 1 op_balance,balance_type from custout where cust_id='"+id+"'",ref rdr);
			if(!bal.Equals(""))
			{
				if(baltype.Equals("Dr."))
					baldr+= System.Convert.ToDouble(bal);
				else
					balcr+= System.Convert.ToDouble(bal);
				return System.Convert.ToString(Math.Round(System.Convert.ToDouble(bal),2))+" "+baltype; 
			}
			else
				return "0";
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemTotalclosing(object sender,DataGridItemEventArgs e)
		{
			try
			{
				//public double baldr;
				//public double balcr;
				double s1=0;
				double s2=0;
				double s3=0;
				double s4=0;
				if(e.Item.ItemType == ListItemType.Footer)	
				{
					s1=baldr;
					s2=balcr;
					if(s1>s2)
					{
						s3=s1-s2;
						e.Item.Cells[3].Text =  System.Math.Round(System.Convert.ToDouble(s3),2)+" Dr."; 
						Cache["closing"]=   System.Math.Round(System.Convert.ToDouble(s3),2)+" Dr."; 
					}
					else
					{
						s4=s2-s1;
						e.Item.Cells[3].Text =  System.Math.Round(System.Convert.ToDouble(s4),2)+" Cr."; 
						Cache["closing"]=  System.Math.Round(System.Convert.ToDouble(s4),2)+" Cr."; 
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customeroutstanding.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid );
			}
		}

		//		public void ItemTotaltr(object sender,DataGridItemEventArgs e)
		//		{
		//			try
		//			{
		//				
		//				if(e.Item.ItemType == ListItemType.Footer)	
		//				{
		//					//e.Item.Cells[3].Text =  totaldrlim.ToString()+"Dr.     "+ totalcrlim.ToString()+"Cr."; 
		//					e.Item.Cells[3].Text =  System.Math.Round(System.Convert.ToDouble(totaldrlim),2)+"Dr.     "+ System.Math.Round(System.Convert.ToDouble(totalcrlim),2)+"Cr."; 
		//					Cache["trans"]=  System.Math.Round(System.Convert.ToDouble(totaldrlim),2)+"Dr.     "+ System.Math.Round(System.Convert.ToDouble(totalcrlim),2)+"Cr."; 
		//				}
		//			}
		//			catch(Exception ex)
		//			{
		//				CreateLogFiles.ErrorLog("Form:Customeroutstanding.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid );
		//			}
		//		}

		/// <summary>
		/// Its calls from data grid for calculation and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemTotal1(object sender,DataGridItemEventArgs e)
		{
			try
			{
				double s1=0;
				double s2=0;
				double s3=0;
				double s4=0;
				if(e.Item.ItemType == ListItemType.Footer)	
				{
					//					e.Item.Cells[3].Text =  totaldr.ToString()+"Dr.     "+ totalcr.ToString()+"Cr."; 
					//					e.Item.Cells[4].Text =  totaldrlim.ToString()+"Dr.     "+ totalcrlim.ToString()+"Cr."; 
					//e.Item.Cells[3].Text =  System.Math.Round(System.Convert.ToDouble(totaldr),2)+"Dr.     "+ System.Math.Round(System.Convert.ToDouble(totalcr),2)+"Cr."; 
					//Cache["openAll"]= System.Math.Round(System.Convert.ToDouble(totaldr),2)+"Dr.     "+ System.Math.Round(System.Convert.ToDouble(totalcr),2)+"Cr."; 
					//e.Item.Cells[4].Text =  System.Math.Round(System.Convert.ToDouble(totaldrlim),2)+"Dr.     "+ System.Math.Round(System.Convert.ToDouble(totalcrlim),2)+"Cr."; 
					//Cache["transAll"]=  System.Math.Round(System.Convert.ToDouble(totaldrlim),2)+"Dr.     "+ System.Math.Round(System.Convert.ToDouble(totalcrlim),2)+"Cr."; 
					//					totaldr=double.Parse(Cache["os1"].ToString());
					//					totaldrlim=double.Parse(Cache["os"].ToString());
					//					totalcr=double.Parse(Cache["os2"].ToString());
					//					totalcrlim=double.Parse(Cache["tr"].ToString());
					//
					//					s1=totaldr+totaldrlim;
					//					s2=totalcr+totalcrlim;
					s1=double.Parse(Cache["os1"].ToString())+double.Parse(Cache["os"].ToString());
					s2=double.Parse(Cache["os2"].ToString())+double.Parse(Cache["tr"].ToString());
					if(s1>s2)
					{
						s3=s1-s2;
						e.Item.Cells[4].Text = System.Math.Round(System.Convert.ToDouble(s3),2)+" Dr."; 
						//e.Item.Cells[5].Text = GenUtil.strNumericFormat(s3.ToString())+"Dr "; 
						Cache["closeAll"] = System.Math.Round(System.Convert.ToDouble(s3),2)+" Dr."; 
					}
					else
					{
						s4=s2-s1;
						e.Item.Cells[4].Text =  System.Math.Round(System.Convert.ToDouble(s4),2)+" cr."; 
						//e.Item.Cells[5].Text =  GenUtil.strNumericFormat(s4.ToString())+"cr."; 
						Cache["closeAll"]=  System.Math.Round(System.Convert.ToDouble(s4),2)+" cr."; 
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customeroutstanding.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid );
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(grdLeg.Visible==true || Datagrid1.Visible==true || Datagrid2.Visible==true || Datagrid3.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:CustomerLedgerSummary.aspx,Method: btnExcel_Click, CustomerLedgerSummary Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:CustomerLedgerSummary.aspx,Method:btnExcel_Click   CustomerLedgerSummary Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}