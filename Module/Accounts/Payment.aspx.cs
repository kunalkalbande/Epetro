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
using System.Net;
using System.Net.Sockets;
using RMG; 
using System.IO;
using System.Text;
using DBOperations;

namespace EPetro.Module.Accounts
{
	/// <summary>
	/// Summary description for Payment.
	/// </summary>
	public class Payment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.HtmlControls.HtmlImage Img1;
		protected System.Web.UI.WebControls.TextBox txtAmount;
		protected System.Web.UI.WebControls.Button btnEdit1;
		protected System.Web.UI.WebControls.DropDownList DropBy;
		protected System.Web.UI.WebControls.TextBox txtBankname;
		protected System.Web.UI.WebControls.TextBox txtCheque;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBOperations.DBUtil dbobj= new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.HtmlControls.HtmlTextArea txtNarrartion;
		protected System.Web.UI.WebControls.DropDownList DropLedgerName;
		protected System.Web.UI.WebControls.DropDownList DropLedgerName1;
		protected System.Web.UI.WebControls.Panel PanBankInfo;
		protected System.Web.UI.WebControls.Panel PanAmount;
		protected System.Web.UI.WebControls.Button btnPrint;
		string uid;
		//static string LedgerID="0";
		static ArrayList LedgerID = new ArrayList();
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempPaymentID;
		public static string CheckCashMode="";
		
		/// <summary>
		/// Put user code to initialize the page here
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				//string uid;
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment,Method:PageLoad   "+" EXCEPTION "+ ex.Message+" userid "+ uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
                txtDate.Attributes.Add("readonly", "readonly");
                txtDate.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
				checkPrivileges();
				PanAmount.Visible=true;
				PanBankInfo.Visible=false;
				txtNarrartion.Value = ""; 
				fillCombo();
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				//LedgerID="0";
				LedgerID= new ArrayList();;
			}
		}

		/// <summary>
		/// This method is used to check the user previleges
		/// </summary>
		public void checkPrivileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="1";
			string SubModule="3";
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
			if(View_flag =="0" && Add_Flag=="0" && Edit_Flag=="0" && Del_Flag=="0")
			{
				string msg="UnAthourized Visit to Cash Payment Page";
								
				CreateLogFiles.ErrorLog("Form:Payment,Method:PageLoad "+msg+"  "+ uid);
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}
			if(Add_Flag=="0")
				btnSave.Enabled=false;
			if(Edit_Flag=="0")
			{
				 
				btnEdit.Enabled=false;
			}
			if(Del_Flag=="0")
			{
				
				btnDelete.Enabled=false;
			}
			#endregion
		}

		/// <summary>
		/// Method to fill the combos of Ledger Name and  By.
		/// Ledger Name Combo contains all ledger Names except the type Bank & cash
		/// By combo contains only Ledger names of the type bank and cash.
		/// </summary>
		public void fillCombo()
		{
			try
			{
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("Select Ledger_Name,Ledger_ID from Ledger_Master lm,Ledger_master_sub_grp lmsg  where  lm.sub_grp_id = lmsg.sub_grp_id and lmsg.sub_grp_name not like 'Bank%' and lmsg.sub_grp_name not like 'Cash in hand'  Order by Ledger_Name",ref SqlDtr);
				while(SqlDtr.Read())
				{
					//DropLedgerName.Items.Add(SqlDtr["Ledger_Name"].ToString().Trim());
					DropLedgerName.Items.Add(SqlDtr["Ledger_Name"].ToString()+";"+SqlDtr["Ledger_ID"].ToString());
				}
				SqlDtr.Close();

				dbobj.SelectQuery("Select Ledger_Name,sub_grp_name from Ledger_Master lm,Ledger_master_sub_grp lmsg  where  lm.sub_grp_id = lmsg.sub_grp_id   Order by Ledger_Name",ref SqlDtr);
				while(SqlDtr.Read())
				{
					string str = SqlDtr["sub_grp_name"].ToString();
					if(str.Equals("Cash in hand") || str.IndexOf("Bank") > -1)
					{
						DropBy.Items.Add(SqlDtr["Ledger_Name"].ToString());   
					}
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment,Method:fillCombo() Exception: "+ex.Message+"  User: "+ uid);     
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
			this.DropLedgerName1.SelectedIndexChanged += new System.EventHandler(this.DropLedgerName1_SelectedIndexChanged);
			this.btnEdit1.Click += new System.EventHandler(this.btnEdit1_Click);
			this.DropBy.SelectedIndexChanged += new System.EventHandler(this.DropBy_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to insert all values in the database with the help of stored procedures.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
                StringBuilder errorMessage=new StringBuilder();
                if (DropLedgerName.SelectedIndex == 0)
                {
                    errorMessage.Append("Please Select Ledger Name");
                    errorMessage.Append("\n");
                }
                if (DropBy.SelectedIndex == 0)
                {
                    errorMessage.Append("Please Select By Whom");
                    errorMessage.Append("\n");
                }
                if (txtAmount.Text==string.Empty)
                {
                    errorMessage.Append("Please Enter Amount");
                    errorMessage.Append("\n");
                }
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());
                    return;
                }
                string Ledger_Name = "";
				string By_Name = "";
				string Bank_name = "";
				string Cheque_No = "";
				string Date = "";
				string Amount = "";
				string narration="";
				string Ledger_ID ="";
				string By_ID = "";
				string Vouch_ID = "";
				string Invoice_Date="";

				Ledger_Name = DropLedgerName.SelectedItem.Text.Trim() ;
				By_Name = DropBy.SelectedItem.Text.Trim() ;   
				Bank_name = txtBankname.Text.Trim();
				Cheque_No = txtCheque.Text.Trim();
				Date = txtDate.Text.Trim();
				Date = GenUtil.str2DDMMYYYY(Date);
                DateTime dtDate = System.Convert.ToDateTime(Date);

                Amount = txtAmount.Text.Trim();
				narration = txtNarrartion.Value.Trim();
                DateTime Entry_Date = System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(Request.Form["txtDate"].ToString()) + " " + DateTime.Now.TimeOfDay.ToString());
                Invoice_Date = DateTime.Now.ToString();
				SqlDataReader SqlDtr = null;
				string strNew = DropLedgerName.SelectedItem.Text;
				string[] arrstrNew = strNew.Split(new char[] {';'},strNew.Length);
				//				dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name ='"+Ledger_Name+"'",ref SqlDtr);
				//				if(SqlDtr.Read())
				//				{
				//					Ledger_ID = SqlDtr["Ledger_ID"].ToString(); 
				//				}
				//				SqlDtr.Close();
				Ledger_ID=arrstrNew[1].ToString();

				dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name ='"+By_Name+"'",ref SqlDtr);
				if(SqlDtr.Read())
				{
					By_ID = SqlDtr["Ledger_ID"].ToString(); 
				}
				SqlDtr.Close();
             
				dbobj.SelectQuery("Select top 1 (voucher_ID+1)  from Payment_Transaction order by voucher_ID desc",ref SqlDtr);
				if(SqlDtr.Read())
				{
					Vouch_ID = SqlDtr.GetValue(0).ToString();   
				}
				else
				{
					Vouch_ID = "50001";
               
				}
				SqlDtr.Close();

				int c= 0;
				
				dbobj.Insert_or_Update("insert into payment_transaction values("+Vouch_ID+",'Payment',"+Ledger_ID+","+Amount+","+By_ID+","+Amount+",'"+Bank_name+"','"+Cheque_No+ "',CONVERT(datetime,'" + dtDate + "', 103),'"+narration+"','"+uid+"',CONVERT(datetime, '" + Entry_Date + "', 103))",ref c);
				object obj = null;
				//dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",Ledger_ID,"@Particulars","Payment ("+Vouch_ID+")","@Debit_Amount",Amount,"@Credit_Amount","0.0","@type","Dr"); 
				//dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",By_ID,"@Particulars","Payment ("+Vouch_ID+")","@Debit_Amount","0.0","@Credit_Amount",Amount,"@type","Cr"); 
				dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",Ledger_ID,"@Particulars","Payment ("+Vouch_ID+")","@Debit_Amount",Amount,"@Credit_Amount","0.0","@type","Dr","@Invoice_Date", System.Convert.ToDateTime(Invoice_Date)); 
				dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",By_ID,"@Particulars","Payment ("+Vouch_ID+")","@Debit_Amount","0.0","@Credit_Amount",Amount,"@type","Cr","@Invoice_Date", System.Convert.ToDateTime(Invoice_Date)); 
				dbobj.ExecProc(DBOperations.OprType.Insert,"ProCustomerLedgerEntry",ref obj,"@Voucher_ID",Vouch_ID,"@Ledger_ID",Ledger_ID,"@Amount" ,Amount,"@Type","Dr.","@Invoice_Date", System.Convert.ToDateTime(Invoice_Date));
				dbobj.ExecProc(DBOperations.OprType.Insert,"ProCustomerLedgerEntry",ref obj,"@Voucher_ID",Vouch_ID,"@Ledger_ID",By_ID,"@Amount" ,Amount,"@Type","Cr.","@Invoice_Date", System.Convert.ToDateTime(Invoice_Date));
				CustomerInsertUpdate(Ledger_ID,By_ID);
				if(c != 0)
				{
					MessageBox.Show("Payment Saved"); 
					CreateLogFiles.ErrorLog("Form:Payment,Method:btnSave_click Payment of Ledger name "+Ledger_Name+" with voucher_id "+Vouch_ID+" Saved  User: "+ uid);
					makingReport();
					//Print(); 
					clear();
				}
				checkPrivileges();
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment,Method:btnSave_click Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		/// <summary>
		/// This method is used to prepares the report file for printting.
		/// </summary>
		public void makingReport()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\Payment.txt";
				StreamWriter sw = new StreamWriter(path);


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
				
				//**********
				string des="---------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("=========",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Payment",des.Length)); 
				sw.WriteLine(GenUtil.GetCenterAddr("=========",des.Length));
				sw.WriteLine(""); 
				sw.WriteLine("Date : "+System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year );
				sw.WriteLine("");
				sw.WriteLine("Ledger Name: "+DropLedgerName.SelectedItem.Text );
				sw.WriteLine("By         : "+DropBy.SelectedItem.Text);
				if(DropBy.SelectedItem.Text.Equals("Cash"))
					sw.WriteLine("Amount     : "+GenUtil.strNumericFormat(txtAmount.Text.Trim()));
				else
				{
					sw.WriteLine("Bank Name  : {0,-30:S} Cheque No.: {1,-20:S}",txtBankname.Text.Trim(),txtCheque.Text.Trim());
					sw.WriteLine("Cheque Date: "+txtDate.Text.Trim());
					sw.WriteLine("Amount     : "+GenUtil.strNumericFormat(txtAmount.Text.Trim()));
				}
				sw.WriteLine("Narration  : "+checkStr(txtNarrartion.Value));
				sw.Close();
				 

			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment,Method:makingReport() Exception: "+ex.Message+"  User: "+ uid);     
			}
		}


		public string checkStr(string str)
		{
			if(str.IndexOf("\r\n") >0)
			{
				str = str.Replace("\r\n"," "); 
			}
			return str;
		}

		/// <summary>
		/// contacts the Print_WiindowServices via socket and sends the Payment.txt file name to print.
		/// </summary>
		public void Print()
		{
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\Payment.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:Payment.aspx,Method:print. Report Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:Payment.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:Payment.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:Payment.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment.aspx,Method:print  EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		}
	
		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void clear()
		{
			Entry_Date="";
			PanBankInfo.Visible=false;
			DropBy.SelectedIndex = 0;
			DropLedgerName.SelectedIndex = 0;
			txtBankname.Text = "";
			txtCheque.Text ="";
			txtDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtAmount.Text = "";
			txtNarrartion.Value = "";
			CheckCashMode="";
			tempPaymentID.Value="";
			LedgerID=new ArrayList();
		}
		
		/// <summary>
		/// This method is used to fatch the Ledger Name with Ledger ID and fill into the dropdownlist.
		/// </summary>
		private void btnEdit1_Click(object sender, System.EventArgs e)
		{
			try
			{
				clear();
				DropLedgerName1.Items.Clear();   
				DropLedgerName1.Items.Add("Select");  
				btnEdit1.Visible = false;
				
				DropLedgerName1.Visible = true;
				btnSave.Enabled = false;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				SqlDataReader SqlDtr = null;
				//dbobj.SelectQuery("select Ledger_Name+':'+cast(voucher_id as varchar) from Payment_transaction pt, Ledger_Master lm where pt.Ledger_ID_Dr = lm.Ledger_ID",ref SqlDtr);
				dbobj.SelectQuery("select Ledger_Name+';'+cast(Ledger_ID_Dr as varchar)+':'+cast(voucher_id as varchar) from Payment_transaction pt, Ledger_Master lm where pt.Ledger_ID_Dr = lm.Ledger_ID",ref SqlDtr);
				while(SqlDtr.Read())
				{
					DropLedgerName1.Items.Add(SqlDtr.GetValue(0).ToString().Trim());
				}
				SqlDtr.Close();
				checkPrivileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment,Method:btnEdit1_Click Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		static string Entry_Date="";
		/// <summary>
		/// To retrieve the all values from the database according to selected value in the dropdownlist.
		/// </summary>
		private void DropLedgerName1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				clear();
				if(DropLedgerName1.SelectedIndex == 0)
				{
					MessageBox.Show("Please select Ledger Name");
					return;
				}
				string str = DropLedgerName1.SelectedItem.Text;
				string[] strArr = str.Split(new char[] {':'},str.Length);
  
				SqlDataReader SqlDtr = null;
				SqlDataReader SqlDtr1 = null;
				dbobj.SelectQuery("Select * from payment_transaction where voucher_Id = "+strArr[1].Trim(),ref SqlDtr); 
				while(SqlDtr.Read())
				{
					tempPaymentID.Value=SqlDtr.GetValue(0).ToString();
					DropLedgerName.SelectedIndex = DropLedgerName.Items.IndexOf(DropLedgerName.Items.FindByText(strArr[0].Trim()));
					txtBankname.Text = SqlDtr["Bank_Name"].ToString().Trim() ;
					txtCheque.Text = SqlDtr["Cheque_No"].ToString().Trim();
					txtDate.Text = checkDate(GenUtil.str2DDMMYYYY(trimDate(SqlDtr["cheque_date"].ToString().Trim() )));
					txtAmount.Text = GenUtil.strNumericFormat(SqlDtr["Amount1"].ToString().Trim());
					txtNarrartion.Value  = SqlDtr["narration"].ToString().Trim();
					Entry_Date=SqlDtr["entry_date"].ToString();
					//LedgerID = SqlDtr["Ledger_ID_Dr"].ToString();
					LedgerID.Add(SqlDtr["Ledger_ID_Dr"].ToString());
					LedgerID.Add(SqlDtr["Ledger_ID_Cr"].ToString());
					dbobj.SelectQuery("Select Ledger_Name from Ledger_Master where Ledger_ID = "+SqlDtr["Ledger_ID_Cr"].ToString().Trim(),ref SqlDtr1);
					if(SqlDtr1.Read())
					{
						DropBy.SelectedIndex = DropBy.Items.IndexOf(DropBy.Items.FindByText(SqlDtr1["Ledger_Name"].ToString().Trim()));
						CheckCashMode=SqlDtr1["Ledger_Name"].ToString();
					}
					SqlDtr1.Close();
					if(DropBy.SelectedItem.Text.Equals("Cash"))
					{
						PanAmount.Visible=true;
						PanBankInfo.Visible=false;
					}
					else
					{
						PanAmount.Visible=true;
						PanBankInfo.Visible=true;
					}
				}
				SqlDtr.Close();
				checkPrivileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment,Method:DropLedgerName1_SelectedIndexChanged Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		/// <summary>
		/// This method is used to check the date when retrieve from the database
		/// if date is "1/1/1900" then pass the blank values 
		/// </summary>
		public string checkDate(string str)
		{
			if(!str.Trim().Equals(""))
			{
				if(str.Trim().Equals("1/1/1900"))
					str = "";
			}
			return str;
		}

		/// <summary>
		/// This method is used to seprate time from date and returns only date in mm/dd/yyyy
		/// </summary>
		public string trimDate(string strDate)
		{
			int pos = strDate.IndexOf(" ");
			if(pos != -1)
			{
				strDate = strDate.Substring(0,pos);
			}
			else
			{
				strDate = "";					
			}
			return strDate;
		}

		/// <summary>
		/// To update the records according to selected value from the dropdownlist.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			if(DropLedgerName1.SelectedIndex == 0)
			{
				MessageBox.Show("Please select Ledger Name");
				return;
			}		
			string Ledger_Name1 = "";
			string By_Name1 = "";
			string Bank_name1 = "";
			string Cheque_No1 = "";
			string Date1 = "";
			string Amount1 = "";
			string narration1="";
			string Ledger_ID1 ="";
			string By_ID1 = "";
			string Curr_Date="";
		
			try
			{
				Ledger_Name1 = DropLedgerName.SelectedItem.Text.Trim() ;
				By_Name1 = DropBy.SelectedItem.Text.Trim() ;   
				Bank_name1 = txtBankname.Text.Trim();
				Cheque_No1 = txtCheque.Text.Trim();
				Date1 = txtDate.Text.Trim();
				Date1 = GenUtil.str2MMDDYYYY(Date1);
				Amount1 = txtAmount.Text.Trim();
				narration1 = txtNarrartion.Value.Trim();
				SqlDataReader SqlDtr = null;
				Curr_Date=DateTime.Now.ToString();
				//***********************
				string strOld = DropLedgerName1.SelectedItem.Text;
				string[] arrstrOld = strOld.Split(new char[] {':'},strOld.Length);
				string[] arrOldLedger_ID = arrstrOld[0].Split(new char[] {';'},arrstrOld[0].Length);
				string OldLedger_ID="";
				string strNew = DropLedgerName.SelectedItem.Text;
				string[] arrstrNew = strNew.Split(new char[] {';'},strNew.Length);	
				OldLedger_ID=arrOldLedger_ID[1].ToString();
				//***********************
				//				dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name ='"+Ledger_Name1+"'",ref SqlDtr);
				//				if(SqlDtr.Read())
				//				{
				//					Ledger_ID1 = SqlDtr["Ledger_ID"].ToString(); 
				//				}
				//				SqlDtr.Close();
				Ledger_ID1=arrstrNew[1].ToString();
				dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name ='"+By_Name1+"'",ref SqlDtr);
				if(SqlDtr.Read())
				{
					By_ID1 = SqlDtr["Ledger_ID"].ToString();
				}
				SqlDtr.Close();
             
				string str = DropLedgerName1.SelectedItem.Text;
				string[] strArr = str.Split(new char[] {':'} ,str.Length);
				int c= 0;
				/**************	Comment by Mahesh on 17.07.008, b'coz when change the party in edit time can not reflact
				dbobj.Insert_or_Update("Update Payment_transaction set Ledger_ID_Dr = "+Ledger_ID1+",Amount1 = "+Amount1+",Ledger_ID_Cr = "+By_ID1+",Amount2 = "+Amount1+",Bank_Name='"+Bank_name1+"',Cheque_No='"+Cheque_No1+"',Cheque_date = '"+Date1+"',Narration ='"+narration1+"',Entered_By = '"+uid+"',Entry_Date = getDate() where Voucher_ID = "+strArr[1].Trim() ,ref c);
				object obj = null;
				object obj1 = null;
				//dbobj.ExecProc(DBOperations.OprType.Update,"ProUpdateAccountsLedger",ref obj,"@Voucher_ID",strArr[1].Trim(),"@Ledger_ID",By_ID1,"@Amount",Amount1,"@Type","Cr");
				//dbobj.ExecProc(DBOperations.OprType.Update,"ProUpdateAccountsLedger",ref obj,"@Voucher_ID",strArr[1].Trim(),"@Ledger_ID",Ledger_ID1,"@Amount",Amount1,"@Type","Dr");
				dbobj.ExecProc(DBOperations.OprType.Update,"ProUpdateAccountsLedger",ref obj,"@Voucher_ID",strArr[1].Trim(),"@Ledger_ID",Ledger_ID1,"@Amount",Amount1,"@Type","Dr","@Invoice_Date",Curr_Date);
				dbobj.ExecProc(DBOperations.OprType.Update,"ProUpdateAccountsLedger",ref obj,"@Voucher_ID",strArr[1].Trim(),"@Ledger_ID",By_ID1,"@Amount",Amount1,"@Type","Cr","@Invoice_Date",Curr_Date);
				//dbobj.Insert_or_Update("update accountsledgertable set credit_amount="+Amount1+", where Ledger_ID='"+By_ID1+"' and particulars='Payment ("+strArr[1].Trim()+")'",ref c);
				******************** end ***********************/
				//****************** add by Mahesh on 17.07.008
				SqlDataReader rdr=null;
				string Cust_ID="",OldCust_ID="",Vouch_ID="";
				Vouch_ID=tempPaymentID.Value;
				dbobj.SelectQuery("select Cust_ID from Customer,Ledger_Master where Ledger_Name = Cust_Name and Ledger_ID = '"+Ledger_ID1+"'",ref rdr);
				if(rdr.Read())
					Cust_ID=rdr["Cust_ID"].ToString();
				rdr.Close();
				dbobj.SelectQuery("select Cust_ID from Customer,Ledger_Master where Ledger_Name = Cust_Name and Ledger_ID = '"+OldLedger_ID+"'",ref rdr);
				if(rdr.Read())
					OldCust_ID=rdr["Cust_ID"].ToString();
				rdr.Close();

				if(arrstrOld[0].ToString().Equals(DropLedgerName.SelectedItem.Text))
				{
					dbobj.Insert_or_Update("Update Payment_transaction set Ledger_ID_Dr = "+Ledger_ID1+",Amount1 = "+Amount1+",Ledger_ID_Cr = "+By_ID1+",Amount2 = "+Amount1+",Bank_Name='"+Bank_name1+"',Cheque_No='"+Cheque_No1+"',Cheque_date = '"+Date1+"',Narration ='"+narration1+"',Entered_By = '"+uid+"',Entry_Date = '"+Entry_Date+"' where Voucher_ID = "+strArr[1].Trim() ,ref c);
					object obj = null;
					if(CheckCashMode.Equals(DropBy.SelectedItem.Text))
					{
						int x=0;
						dbobj.ExecProc(DBOperations.OprType.Update,"ProUpdateAccountsLedger",ref obj,"@Voucher_ID",strArr[1].Trim(),"@Ledger_ID",Ledger_ID1,"@Amount",Amount1,"@Type","Dr","@Invoice_Date",Entry_Date);
						/*Comment by Mahesh on 08.11.008
						 * because can not update data with the help of this stored procedure 
						 * then i have apply update query for update the data in cash account.
						 * and balance update by CustomerUpdate() function
						 */ 
						//dbobj.ExecProc(DBOperations.OprType.Update,"ProUpdateAccountsLedger",ref obj,"@Voucher_ID",strArr[1].Trim(),"@Ledger_ID",By_ID1,"@Amount",Amount1,"@Type","Cr","@Invoice_Date",Entry_Date);
						dbobj.Insert_or_Update("update AccountsLedgerTable set credit_amount='"+Amount1+"' where Ledger_ID='"+By_ID1+"' and particulars='Payment ("+strArr[1].ToString().Trim()+")'",ref x);
					}
					else
					{
						//if(OldCust_ID!="")
						//{
						dbobj.Insert_or_Update("delete from LedgDetails where Bill_No='"+strArr[1].Trim()+"' and Cust_ID='"+OldCust_ID+"'",ref c);
						dbobj.Insert_or_Update("delete from Invoice_Transaction where Invoice_No='"+strArr[1].Trim()+"' and Cust_ID='"+OldCust_ID+"'",ref c);
						dbobj.Insert_or_Update("delete from CustomerLedgerTable where Particular = 'Voucher("+strArr[1].Trim()+")' and CustID='"+OldCust_ID+"'",ref c);
						dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Payment ("+strArr[1].Trim()+")'",ref c);
						//}
						dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",Ledger_ID1,"@Particulars","Payment ("+Vouch_ID+")","@Debit_Amount",Amount1,"@Credit_Amount","0.0","@type","Dr","@Invoice_Date",Entry_Date); 
						dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",By_ID1,"@Particulars","Payment ("+Vouch_ID+")","@Debit_Amount","0.0","@Credit_Amount",Amount1,"@type","Cr","@Invoice_Date",Entry_Date); 
						dbobj.ExecProc(DBOperations.OprType.Insert,"ProCustomerLedgerEntry",ref obj,"@Voucher_ID",Vouch_ID,"@Ledger_ID",Ledger_ID1,"@Amount" ,Amount1,"@Type","Dr.","@Invoice_Date",Entry_Date);
						dbobj.ExecProc(DBOperations.OprType.Insert,"ProCustomerLedgerEntry",ref obj,"@Voucher_ID",Vouch_ID,"@Ledger_ID",By_ID1,"@Amount" ,Amount1,"@Type","Cr.","@Invoice_Date",Entry_Date);
					}
					//SeqCashAccount();
				}
				else
				{
					dbobj.Insert_or_Update("delete from LedgDetails where Bill_No='"+strArr[1].Trim()+"' and Cust_ID='"+OldCust_ID+"'",ref c);
					dbobj.Insert_or_Update("delete from Invoice_Transaction where Invoice_No='"+strArr[1].Trim()+"' and Cust_ID='"+OldCust_ID+"'",ref c);
					dbobj.Insert_or_Update("delete from payment_transaction where voucher_id = "+strArr[1].Trim(),ref c);
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Payment ("+strArr[1].Trim()+")'",ref c);
					if(OldCust_ID!="")
					{
						dbobj.Insert_or_Update("delete from CustomerLedgerTable where Particular = 'Voucher("+strArr[1].Trim()+")' and CustID='"+OldCust_ID+"'",ref c);
					}
					dbobj.Insert_or_Update("insert into payment_transaction values("+Vouch_ID+",'Payment',"+Ledger_ID1+","+Amount1+","+By_ID1+","+Amount1+",'"+Bank_name1+"','"+Cheque_No1+"','"+Date1+"','"+narration1+"','"+uid+"','"+Entry_Date+"')",ref c);
					object obj = null;
					dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",Ledger_ID1,"@Particulars","Payment ("+Vouch_ID+")","@Debit_Amount",Amount1,"@Credit_Amount","0.0","@type","Dr","@Invoice_Date",Entry_Date); 
					dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",By_ID1,"@Particulars","Payment ("+Vouch_ID+")","@Debit_Amount","0.0","@Credit_Amount",Amount1,"@type","Cr","@Invoice_Date",Entry_Date); 
					dbobj.ExecProc(DBOperations.OprType.Insert,"ProCustomerLedgerEntry",ref obj,"@Voucher_ID",Vouch_ID,"@Ledger_ID",Ledger_ID1,"@Amount" ,Amount1,"@Type","Dr.","@Invoice_Date",Entry_Date);
					dbobj.ExecProc(DBOperations.OprType.Insert,"ProCustomerLedgerEntry",ref obj,"@Voucher_ID",Vouch_ID,"@Ledger_ID",By_ID1,"@Amount" ,Amount1,"@Type","Cr.","@Invoice_Date",Entry_Date);
					LedgerID.Add(Ledger_ID1);
					//SeqCashAccount();
				}
				//*********************************************
				//if(c != 0)
				//{
				makingReport();
				CustomerUpdate();
				MessageBox.Show("Payment Updated");
				CreateLogFiles.ErrorLog("Form:Payment,Method:btnEdit_Click Payment of Ledger name "+Ledger_Name1+" with voucher_id "+strArr[1].Trim() +" Updated.  User : "+ uid);
				//Print(); 
				DropLedgerName1.Visible = false;
				btnEdit1.Visible = true; 
				clear();
				btnSave.Enabled = true;  
				//}
				checkPrivileges();
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;  
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment,Method:btnEdit_Click Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		/// <summary>
		/// This method is used to dalete the record according to selected value from the dropdownlist.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropLedgerName1.SelectedIndex == 0)
				{
					MessageBox.Show("Please select Ledger Name");
					return;
				}
				string str = DropLedgerName1.SelectedItem.Text;
				string[] strArr = str.Split(new char[] {':'},str.Length);
				int c = 0;
				dbobj.Insert_or_Update("delete from payment_transaction where voucher_id = "+strArr[1].Trim(),ref c);
				//*****
				dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Payment ("+strArr[1].Trim()+")'",ref c);
				dbobj.Insert_or_Update("delete from CustomerLedgerTable where Particular = 'Voucher("+strArr[1].Trim()+")'",ref c);
				//*****
				//if(c > 0)
				//{
				CustomerUpdate();
				MessageBox.Show("Payment Deleted"); 
				CreateLogFiles.ErrorLog("Form:Payment,Method:btnDelete_Click Payment of  voucher_id "+strArr[1].Trim() +" Deleted.  User : "+ uid);
				DropLedgerName1.Visible = false;
				btnEdit1.Visible = true; 
				clear();
				btnSave.Enabled = true;  
				//}
				checkPrivileges();
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;  
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment,Method:btnDelete_Click Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		/// <summary>
		/// If selected "Cash" then show amount textbox otherwise show bank information.
		/// Both are hide in the page_load events.
		/// </summary>
		
		private void DropBy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropBy.SelectedItem.Text.Trim().Equals("Cash"))
			{
				PanAmount.Visible=true;
				PanBankInfo.Visible=false;
				txtBankname.Text="";
				txtCheque.Text="";
				txtDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			}
			else
			{
				PanAmount.Visible=true;
				PanBankInfo.Visible=true;
			}
		}

		/// <summary>
		/// This method is used to print the txt file with the help of Print() funtion.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Print();
		}

		/// <summary>
		/// This method is used to update the customer balance according to date after insert the record.
		/// </summary>
		public void CustomerInsertUpdate(string Ledger_ID,string By_ID)
		{
			SqlDataReader rdr = null;
			object obj1 = null;
			dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref obj1,"@Ledger_ID",By_ID,"@Invoice_Date",DateTime.Now.Month+"/"+DateTime.Now.Day+"/"+DateTime.Now.Year);
			dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref obj1,"@Ledger_ID",Ledger_ID,"@Invoice_Date",DateTime.Now.Month+"/"+DateTime.Now.Day+"/"+DateTime.Now.Year);
			dbobj.SelectQuery("select cust_id from customer,ledger_master where ledger_name=cust_name and ledger_id='"+Ledger_ID+"'",ref rdr);
			if(rdr.Read())
			{
				dbobj.ExecProc(OprType.Insert,"UpdateCustomerLedgerForCustomer",ref obj1,"@Cust_ID",rdr["Cust_ID"].ToString(),"@Invoice_Date",DateTime.Now.Month+"/"+DateTime.Now.Day+"/"+DateTime.Now.Year);
			}
			rdr.Close();
		}
		
		/// <summary>
		/// This method is used to update the customer balance after update the record.
		/// </summary>
		public void CustomerUpdate()
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
			double Bal=0;
			string BalType="";
			int i=0;
			object obj1 = null;
			//****************************
			for(int p=0;p<LedgerID.Count;p++)
			{
				//if(btnEdit1.Visible!=true)
				//{
				dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref obj1,"@Ledger_ID",LedgerID[p].ToString(),"@Invoice_Date",GenUtil.trimDate(Entry_Date));
				dbobj.SelectQuery("select cust_id from customer,ledger_master where ledger_name=cust_name and ledger_id='"+LedgerID[p].ToString()+"'",ref rdr);
				if(rdr.Read())
				{
					dbobj.ExecProc(OprType.Insert,"UpdateCustomerLedgerForCustomer",ref obj1,"@Cust_ID",rdr["Cust_ID"].ToString(),"@Invoice_Date",GenUtil.trimDate(Entry_Date));
				}
				rdr.Close();
				//}
				//				else
				//				{
				//					dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref obj1,"@Ledger_ID",LedgerID,"@Invoice_Date",DateTime.Now.Month+"/"+DateTime.Now.Day+"/"+DateTime.Now.Year);
				//					dbobj.SelectQuery("select cust_id from customer,ledger_master where ledger_name=cust_name and ledger_id='"+LedgerID+"'",ref rdr);
				//					if(rdr.Read())
				//					{
				//						dbobj.ExecProc(OprType.Insert,"UpdateCustomerLedgerForCustomer",ref obj1,"@Cust_ID",rdr["Cust_ID"].ToString(),"@Invoice_Date",DateTime.Now.Month+"/"+DateTime.Now.Day+"/"+DateTime.Now.Year);
				//					}
				//					rdr.Close();
				//				}
			}
			//****************************
			//			string str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID+"' order by entry_date";
			//			rdr=obj.GetRecordSet(str);
			//			Bal=0;
			//			BalType="";
			//			i=0;
			//			while(rdr.Read())
			//			{
			//				if(i==0)
			//				{
			//					BalType=rdr["Bal_Type"].ToString();
			//					i++;
			//				}
			//				if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
			//				{
			//					if(BalType=="Cr")
			//					{
			//						Bal+=double.Parse(rdr["Credit_Amount"].ToString());
			//						BalType="Cr";
			//					}
			//					else
			//					{
			//						Bal-=double.Parse(rdr["Credit_Amount"].ToString());
			//						if(Bal<0)
			//						{
			//							Bal=double.Parse(Bal.ToString().Substring(1));
			//							BalType="Cr";
			//						}
			//						else
			//							BalType="Dr";
			//					}
			//				}
			//				else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
			//				{
			//					if(BalType=="Dr")
			//						Bal+=double.Parse(rdr["Debit_Amount"].ToString());
			//					else
			//					{
			//						Bal-=double.Parse(rdr["Debit_Amount"].ToString());
			//						if(Bal<0)
			//						{
			//							Bal=double.Parse(Bal.ToString().Substring(1));
			//							BalType="Dr";
			//						}
			//						else
			//							BalType="Cr";
			//					}
			//				}
			//				Con.Open();
			//				cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
			//				cmd.ExecuteNonQuery();
			//				cmd.Dispose();
			//				Con.Close();
			//							
			//			}
			//			rdr.Close();
			//				
			//			string str1="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID+"') order by entrydate";
			//			rdr=obj.GetRecordSet(str1);
			//			Bal=0;
			//			i=0;
			//			BalType="";
			//			while(rdr.Read())
			//			{
			//				if(i==0)
			//				{
			//					BalType=rdr["BalanceType"].ToString();
			//					i++;
			//				}
			//				if(double.Parse(rdr["CreditAmount"].ToString())!=0)
			//				{
			//					if(BalType=="Cr.")
			//					{
			//						Bal+=double.Parse(rdr["CreditAmount"].ToString());
			//						BalType="Cr.";
			//					}
			//					else
			//					{
			//						Bal-=double.Parse(rdr["CreditAmount"].ToString());
			//						if(Bal<0)
			//						{
			//							Bal=double.Parse(Bal.ToString().Substring(1));
			//							BalType="Cr.";
			//						}
			//						else
			//							BalType="Dr.";
			//					}
			//				}
			//				else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
			//				{
			//					if(BalType=="Dr.")
			//						Bal+=double.Parse(rdr["DebitAmount"].ToString());
			//					else
			//					{
			//						Bal-=double.Parse(rdr["DebitAmount"].ToString());
			//						if(Bal<0)
			//						{
			//							Bal=double.Parse(Bal.ToString().Substring(1));
			//							BalType="Dr.";
			//						}
			//						else
			//							BalType="Cr.";
			//					}
			//				}
			//				Con.Open();
			//				cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
			//				cmd.ExecuteNonQuery();
			//				cmd.Dispose();
			//				Con.Close();
			//			}
			//			rdr.Close();
		}
	}
}