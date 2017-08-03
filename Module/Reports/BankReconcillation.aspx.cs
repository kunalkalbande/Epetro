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
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;
using DBOperations; 

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for BankReconcillation.
	/// </summary>
	public class BankReconcillation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.DropDownList DropBank;
		protected System.Web.UI.WebControls.DataGrid DgridBankRecon;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		public string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnExcel;
		string uid="";
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				uid=(Session["User_Name"].ToString());
                
				if(! IsPostBack)
				{
					//DgridBankRecon.Visible=false;
					
					//	txtDateFrom.Text = DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 		
					//	txtDateTo.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="37";
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
						return;
					}
					#endregion 

					InventoryClass obj = new InventoryClass();
					SqlDataReader rdr;
					string str="select Ledger_Name from Ledger_Master where sub_grp_id='117' or sub_grp_id='126' or sub_grp_id='127'";
					rdr = obj.GetRecordSet(str);
					DropBank.Items.Clear();
					DropBank.Items.Add("Select");
					while(rdr.Read())
					{
						DropBank.Items.Add(rdr.GetValue(0).ToString());
					}
					rdr.Close();
				}
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BankReconcillation.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"  "+ uid );
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
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
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is not used.
		/// </summary>
		private void btnView_Click(object sender, System.EventArgs e)
		{
            //			strOrderBy = "Cust_Name ASC";
            //			Session["Column"] = "Cust_Name";
            //			Session["Order"] = "ASC";
            //			BindTheData();
            
        }

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			//string sqlstr="select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from Ledger_Master lm,AccountsLedgerTable alt where lm.Ledger_ID=alt.Ledger_ID and lm.Sub_grp_ID=118";
			//string sqlstr="select distinct lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from Ledger_Master lm,AccountsLedgerTable alt where lm.Ledger_ID=alt.Ledger_ID and alt.Particulars not like('Opening%') and alt.Particulars not like('Credit%') and alt.Particulars not like('Sales%') and alt.Particulars not like('Debit%') and alt.Particulars not like('Purchase%')";// and lm.Ledger_Name not like('Cash%') and lm.Ledger_Name not like('%Bank%')";
			//string sqlstr="select distinct lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from Ledger_Master lm,AccountsLedgerTable alt where lm.Ledger_ID=alt.Ledger_ID and alt.Particulars like('Payment%') and lm.Ledger_Name like('%Bank%')";
			//Mahesh** string sqlstr="select distinct lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from Ledger_Master lm,AccountsLedgerTable alt where lm.Ledger_ID=alt.Ledger_ID and (alt.Particulars like('Payment%') or (lm.sub_grp_id=117 and alt.Particulars not like('sales%') and alt.Particulars not like('opening%')))";
			string sqlstr="(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where (alt.particulars like 'payment%' or alt.particulars like 'receipt%') and alt.ledger_id=lm.ledger_id and (lm.sub_grp_id='117' or lm.sub_grp_id='126' or lm.sub_grp_id='127'))union(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where alt.particulars like 'contra%' and Credit_amount>0 and alt.ledger_id=lm.ledger_id and (lm.sub_grp_id='117' or lm.sub_grp_id='126' or lm.sub_grp_id='127'))";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "AccountsLedgerTable");
			DataTable dtCustomers = ds.Tables["AccountsLedgerTable"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count==0)
			{
				MessageBox.Show("Data not available");
				DgridBankRecon.Visible=false;
			}
			else
			{
				DgridBankRecon.DataSource=dv;
				DgridBankRecon.DataBind();
				DgridBankRecon.Visible=true;
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

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemDataBound(object sender,DataGridItemEventArgs e)
		{
			try
			{
				// If datagrid item is a bound column other than header and footer
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
				{
					string str = e.Item.Cells[1].Text;
					string trans_no = "";
					// if transaction type is Opening Balance then show the blank value in transaction no.
					if(str.StartsWith("Cash"))
					{
						//e.Item.Cells[0].Text = "Reguler Sale";

					}
					else
					{
						// else show take the substring and display the no. in transaction no. and assign the remaining substring to transaction type.
						trans_no = str.Substring(str.IndexOf("(")+1);
						trans_no = trans_no.Substring(0,trans_no.Length-1);  
						str = str.Substring(0,str.IndexOf("("));
						//e.Item.Cells[0].Text = trans_no ;
						//**

						//**
						e.Item.Cells[1].Text = str.Trim(); 
						
					}
					//					// Calls the Totaldebit() and TotalCredit() function to increment the total values for each row.
					//					//This function hidden by mahesh (08/11/06)
					//					//TotalDebit(Double.Parse(e.Item.Cells[3].Text));
					//					//TotalCredit(Double.Parse(e.Item.Cells[4].Text)); 
				}
				//				else if(e.Item.ItemType == ListItemType.Footer)
				//				{
				//					//if the row or item type is footer then display the calculated total debit, credit and last balance with type in the footer. nfi and "N" used to format the double no. in #,###.00 format.
				//					//sum of cell[3],cell[4] hidden by mahesh (08/11/06)
				//					//e.Item.Cells[3].Text = debit_total.ToString("N",nfi);
				//					//e.Item.Cells[4].Text = credit_total.ToString("N",nfi);
				//					e.Item.Cells[5].Text = "(CB) "+balance+" "+baltype;                
				//				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BankReconcillation.aspx,Method:ItemDataBound()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid );
			}
		}
		
		double ddr=0,ccr=0;
		/// <summary>
		/// This method return calculated the total Debit amount
		/// </summary>
		public string TotalDebit(string type,string acc_name,string dr)
		{
			if(type.StartsWith("Payment") && acc_name.StartsWith("Cash"))
				ddr -= double.Parse(dr);
			else
				ddr += double.Parse(dr);
			Cache["ddr"]=ddr.ToString();
			return dr;
		}

		/// <summary>
		/// This method return calculated the total Credit amount
		/// </summary>
		public string TotalCredit(string type,string ac_name,string cr)
		{
			if(type.StartsWith("Payment") && ac_name.StartsWith("State"))
				ccr += System.Convert.ToDouble(cr);
			else if(type.StartsWith("Payment") && ac_name.StartsWith("Cash"))
				ccr += System.Convert.ToDouble(cr);
			else
				ccr += double.Parse(cr);
			Cache["ccr"]=ccr.ToString();
			return cr;
		}

		/// <summary>
		/// This method is used to prepares the report file BankReconcillation.txt for printing.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
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
					CreateLogFiles.ErrorLog("Form:BankReconcillation.aspx,Class:PetrolPumpClass.cs,Method:btnPrint_Clickt    BankReconcillation Report  Printed"+"  userid  " +uid);
					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\BankReconcillation.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:BankReconcillation.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    BankReconcillation Report  Printed"+"  EXCEPTION "+ane.Message+"  userid  " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:BankReconcillation.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    BankReconcillation Report  Printed"+"  EXCEPTION "+se.Message+"  userid  " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:BankReconcillation.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    BankReconcillation Report  Printed"+"  EXCEPTION "+es.Message+"  userid  " +uid);
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:BankReconcillation.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    BankReconcillation Report  Printed"+"  EXCEPTION "+ex.Message+"  userid  " +uid);
			}

		}

		/// <summary>
		/// This Method is used to prepare the report file .txt to print
		/// </summary>
		public void makingReport()
		{
			/*
										========================                              
										   Bank Reconcillation                                 
										========================                              
+-------+----------------------+-----------+-----------+-----------+----------+
	  |Prod_ID|  Product Name           | Pack_Type | Pur_Rate  | Sal_Rate  |Eff_Date  |
	  +-------+-------------------------+-----------+-----------+-----------+----------+
	   1001    1234567890123456789012345 1X20777     12345678.00 12345678.00 DD/MM/YYYY
			*/
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\BankReconcillation1.txt";
			StreamWriter sw = new StreamWriter(path);

			string sql="";
			string info = "";
			//string strDate = "";

			//sql="select distinct lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from Ledger_Master lm,AccountsLedgerTable alt where lm.Ledger_ID=alt.Ledger_ID and alt.Particulars not like('Opening%') and alt.Particulars not like('Credit%') and alt.Particulars not like('Sales%') and alt.Particulars not like('Debit%') and alt.Particulars not like('Purchase%')";// and lm.Ledger_Name not like('Cash%') and lm.Ledger_Name not like('%Bank%')";
			sql="(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where (alt.particulars like 'payment%' or alt.particulars like 'receipt%') and alt.ledger_id=lm.ledger_id and (lm.sub_grp_id='117' or lm.sub_grp_id='126' or lm.sub_grp_id='127'))union(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where alt.particulars like 'contra%' and Credit_amount>0 and alt.ledger_id=lm.ledger_id and (lm.sub_grp_id='117' or lm.sub_grp_id='126' or lm.sub_grp_id='127'))";
			dbobj.SelectQuery(sql,ref rdr);
			// Condensed
			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu
			//sw.Write((char)15);
			sw.WriteLine("");
			//**********
			string des="-------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("=======================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Bank Reconcillation",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=======================",des.Length));
			sw.WriteLine("+------------+--------------+-----------+-----------+----------+--------------+");
			sw.WriteLine("|Account Name| Voucher Type |   Debit   |   Credit  |Posted On |Reconcilled On|");
			sw.WriteLine("+------------+--------------+-----------+-----------+----------+--------------+");
			//             123456789012 12345678901234 12345678901 12345678901 1234567890 12345678901234
			//																   --------DD/MM/YYYY-------
			double ddr=0,ccr=0;        
			if(rdr.HasRows)
			{
				// info : to set the format the displaying string.
				info = " {0,-12:S} {1,-14:S} {2,11:S} {3,11:F} {4,10:F} {5,-14:S}"; 
				ddr+=double.Parse(rdr["Debit"].ToString());
				ccr+=double.Parse(rdr["Credit"].ToString());
				while(rdr.Read())
				{
					sw.WriteLine(info,GenUtil.TrimLength(rdr["Cust_Name"].ToString().Trim(),12),
						GenUtil.TrimLength(CheckType(rdr["Type"].ToString().Trim()),14),
						GenUtil.strNumericFormat(rdr["Debit"].ToString()),
						GenUtil.strNumericFormat(rdr["Credit"].ToString().Trim()),
						GenUtil.trimDate(GenUtil.str2DDMMYYYY(rdr["Entry"].ToString().Trim())),""
						//GenUtil.str2DDMMYYYY(strDate)
						);
				}
			}
			sw.WriteLine("+------------+--------------+-----------+-----------+----------+--------------+");
			sw.WriteLine(info,"   Total","",ddr.ToString(),ccr.ToString(),"","");  
			sw.WriteLine("+------------+--------------+-----------+-----------+----------+--------------+");
			
			dbobj.Dispose();
			sw.Close();

		}

		public string CheckType(string str)
		{
			if(str.IndexOf("(")>0)
			{
				string[] strType=str.Split(new char[] {'('},str.Length);
				return(strType[0]);
			}
			return(str);
		}

		/// <summary>
		/// This method is used to prepares the excel report file BankReconcillation.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				//if(DgridBankRecon.Visible==true)
				//{
				ConvertToExcel();
				MessageBox.Show("Successfully Convert File Into Excel Fromat");
				CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Class:PetrolPumpClass.cs,Method:btnExcel_Click    Leave Report Convert Into Excel Format, userid  "+uid);
				//}
				//else
				//{
				//	MessageBox.Show("Please Click the View Button First");
				//	return;
				//}
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Class:PetrolPumpClass.cs,Method:btnExcel_Click    Leave Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}

        protected void btnShow_Click(object sender, EventArgs e)
        {
            StringBuilder errorMessage = new StringBuilder();
            if (DropBank.SelectedIndex == 0)
            {
                errorMessage.Append("Please Select Bank Name");
                errorMessage.Append("\n");

            }
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage.ToString());
                return;
            }
        }

        /// <summary>
        /// This Method is used to write into the excel report file to print.
        /// </summary>
        public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string sql="";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\BankReconcillation.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr;
			sql="(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where (alt.particulars like 'payment%' or alt.particulars like 'receipt%') and alt.ledger_id=lm.ledger_id and (lm.sub_grp_id='117' or lm.sub_grp_id='126' or lm.sub_grp_id='127'))union(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where alt.particulars like 'contra%' and Credit_amount>0 and alt.ledger_id=lm.ledger_id and (lm.sub_grp_id='117' or lm.sub_grp_id='126' or lm.sub_grp_id='127'))";
			rdr=obj.GetRecordSet(sql);
			sw.WriteLine("Account Name\tVoucher Type\tDebit\tCredit\tPosted On\tReconcilled On");
			double ddr=0,ccr=0;
			while(rdr.Read())
			{
				ddr+=double.Parse(rdr["Debit"].ToString());
				ccr+=double.Parse(rdr["Credit"].ToString());
				sw.WriteLine(rdr["Cust_Name"].ToString().Trim()+"\t"+
					CheckType(rdr["Type"].ToString().Trim())+"\t"+
					GenUtil.strNumericFormat(rdr["Debit"].ToString())+"\t"+
					GenUtil.strNumericFormat(rdr["Credit"].ToString().Trim())+"\t"+
					GenUtil.trimDate(GenUtil.str2DDMMYYYY(rdr["Entry"].ToString().Trim()))+"\t"+""
					);
			}
			sw.WriteLine("Total\t\t"+ddr.ToString()+"\t"+ccr.ToString());  
			rdr.Close();
			sw.Close();
		}
	}
}