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
using EPetro.Sysitem.Classes ;
using System.Data.SqlClient;
using RMG;
using DBOperations;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for voucher.
	/// </summary>
	public class voucher : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblVid;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
		protected System.Web.UI.WebControls.DropDownList DropVoucherName;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator6;
		protected System.Web.UI.WebControls.DropDownList DropDownID;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnEdit1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTempContra;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txTempCredit;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTempDebit;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTempJournal;
		protected System.Web.UI.WebControls.DropDownList dropAccName1;
		protected System.Web.UI.WebControls.DropDownList dropAccName2;
		protected System.Web.UI.WebControls.DropDownList dropAccName3;
		protected System.Web.UI.WebControls.DropDownList dropAccName5;
		protected System.Web.UI.WebControls.DropDownList dropAccName6;
		protected System.Web.UI.WebControls.DropDownList dropAccName7;
		protected System.Web.UI.WebControls.DropDownList dropAccName4;
		protected System.Web.UI.WebControls.DropDownList dropAccName8;
		protected System.Web.UI.HtmlControls.HtmlInputText txtVouchID;
		protected System.Web.UI.WebControls.DropDownList dropType_1;
		protected System.Web.UI.WebControls.DropDownList dropType_5;
		protected System.Web.UI.WebControls.DropDownList dropType_2;
		protected System.Web.UI.WebControls.DropDownList dropType_6;
		protected System.Web.UI.WebControls.DropDownList dropType_3;
		protected System.Web.UI.WebControls.DropDownList dropType_7;
		protected System.Web.UI.WebControls.DropDownList dropType_4;
		protected System.Web.UI.WebControls.DropDownList dropType_8;
		protected System.Web.UI.WebControls.TextBox txtAmount1;
		protected System.Web.UI.WebControls.TextBox txtAmount5;
		protected System.Web.UI.WebControls.TextBox txtAmount2;
		protected System.Web.UI.WebControls.TextBox txtAmount6;
		protected System.Web.UI.WebControls.TextBox txtAmount3;
		protected System.Web.UI.WebControls.TextBox txtAmount7;
		protected System.Web.UI.WebControls.TextBox txtAmount4;
		protected System.Web.UI.WebControls.TextBox txtAmount8;
		protected System.Web.UI.WebControls.TextBox txtLCr;
		protected System.Web.UI.WebControls.TextBox txtRCr;
		protected System.Web.UI.WebControls.TextBox txtLDr;
		protected System.Web.UI.WebControls.TextBox txtRDr;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAccName1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAccName5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAccName2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAccName6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAccName3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAccName7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAccName4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAccName8;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtID;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtNarration;
		string id= "";
		string uid = "";
		int flag=0;
		static string Dr = "", Cr = "";
		string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
		static ArrayList LedgerID= new ArrayList();
		protected System.Web.UI.WebControls.Button Button1;
	
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
				string str = ex.ToString();
				CreateLogFiles.ErrorLog("Form:voucher,Method:PageLoad   "+" EXCEPTION "+ ex.Message+" userid "+ uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				LedgerID=new ArrayList();
				checkPrevileges();
				getID();
				txtNarration.Value = "";
				setValue();
				//txtDate.Enabled = false;
				DropDownID.Visible = false;  
				btnEdit.Enabled = false;
				btnDelete.Enabled = false; 
				txtDate.Text = DateTime.Now.Day.ToString()+"/"+ DateTime.Now.Month.ToString()+"/"+DateTime.Now.Year.ToString();
			}
			int count=dropAccName1.SelectedIndex;
			int count1=dropAccName5.SelectedIndex;
		}

		/// <summary>
		/// This method checks the User Privilegs from session.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
				
			string Module="1";
			string SubModule="4";
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
				//string msg="UnAthourized Visit to Voucher Type Page";
				//	dbobj.LogActivity(msg,Session["User_Name"].ToString());  
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}
			if(Add_Flag=="0")
				btnAdd.Enabled=false;
			if(Edit_Flag=="0")
			{
				//btnEdit1.Enabled = false;
				btnEdit.Enabled=false;
			}
			if(Del_Flag=="0")
			{
				//btnEdit1.Enabled = false;
				btnDelete.Enabled=false;
			}
			#endregion
		}

		/// <summary>
		/// This method used reset the combo to their initial value "Select".
		/// </summary>
		public void setValue()
		{
			txtAccName1.Value = "Select";
			txtAccName2.Value = "Select";
			txtAccName3.Value = "Select";
			txtAccName4.Value = "Select";
			txtAccName5.Value = "Select";
			txtAccName6.Value = "Select";
			txtAccName7.Value = "Select";
			txtAccName8.Value = "Select";
		}

		/// <summary>
		/// Method Returns the ID's of voucher type Contra, debit, Credit, Journal. sets all the Id's into HTML hidden fields.
		/// Contra ID starts with : 10001;
		/// Debit Note : 20001;
		/// Credit Note :30001;
		/// Journal    : 40001;
		/// </summary>
		public void getID()
		{
			try
			{
				string strContra = "";
				string strCreditNote = "";
				string strDebitNote = "";
				string strJournal = "";
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("Select max(Voucher_ID) from Voucher_Transaction where Voucher_Type ='Contra'",ref SqlDtr);
				if(SqlDtr.Read())
				{
					int id1 = 0;
					strContra = SqlDtr.GetValue(0).ToString();
					if(strContra.Equals("") || strContra.Equals("0"))
						strContra = "10001"+"~";
					else
					{
						id1 = (System.Convert.ToInt32(strContra)+1);  
						strContra = id1.ToString()+"~"; 
					}
				}
				else
				{
					strContra = "10001"+"~";   
				}
				SqlDtr.Close(); 

				dbobj.SelectQuery("Select max(Voucher_ID) from Voucher_Transaction where Voucher_Type ='Credit Note'",ref SqlDtr);
				if(SqlDtr.Read())
				{
					int id3 = 0;
					strCreditNote = SqlDtr.GetValue(0).ToString();
					if(strCreditNote.Equals("") || strCreditNote.Equals("0"))
						strCreditNote = "30001"+"~";
					else
					{
						id3 = (System.Convert.ToInt32(strCreditNote)+1);  
						strCreditNote = id3.ToString()+"~"; 
					}  
				}
				else
				{
					strCreditNote = "30001"+"~";   
				}
				SqlDtr.Close(); 

				dbobj.SelectQuery("Select max(Voucher_ID) from Voucher_Transaction where Voucher_Type ='Debit Note'",ref SqlDtr);
				if(SqlDtr.Read())
				{
					int id2 = 0;
					strDebitNote = SqlDtr.GetValue(0).ToString();
					if(strDebitNote.Equals("") || strDebitNote.Equals("0"))
						strDebitNote = "20001"+"~";
					else
					{
						id2 = (System.Convert.ToInt32(strDebitNote)+1);  
						strDebitNote = id2.ToString()+"~"; 
					}
  
				}
				else
				{
					strDebitNote = "20001"+"~";  
				}
				SqlDtr.Close(); 

				dbobj.SelectQuery("Select max(Voucher_ID) from Voucher_Transaction where Voucher_Type ='Journal'",ref SqlDtr);
				if(SqlDtr.Read())
				{
					int id4 = 0;
					strJournal = SqlDtr.GetValue(0).ToString();
					if(strJournal.Equals("") || strJournal.Equals("0"))
						strJournal = "40001"+"~";
					else
					{
						id4 = (System.Convert.ToInt32(strJournal)+1);  
						strJournal = id4.ToString()+"~"; 
					}
  
				}
				else
				{
					strJournal = "40001"+"~";   
				}
				SqlDtr.Close(); 


				dbobj.SelectQuery("select lm.Ledger_name+':'+cast(lm.Ledger_ID as varchar),lmsg.sub_grp_name from Ledger_Master lm,Ledger_Master_Sub_grp lmsg where lm.Sub_grp_ID = lmsg.Sub_grp_ID order by lm.Ledger_name",ref SqlDtr);
				while(SqlDtr.Read())
				{
					string subgrpname = SqlDtr.GetValue(1).ToString();
  
					if(subgrpname.Trim().StartsWith("Cash") || subgrpname.Trim().StartsWith("Bank"))
					{
						strContra = strContra +SqlDtr.GetValue(0).ToString()+"~"; 
						strDebitNote = strDebitNote +SqlDtr.GetValue(0).ToString()+"~";
						strCreditNote = strCreditNote +SqlDtr.GetValue(0).ToString()+"~";
					}
					else
					{
						strJournal = strJournal + SqlDtr.GetValue(0).ToString()+"~"; 
						strDebitNote = strDebitNote +SqlDtr.GetValue(0).ToString()+"~";
						strCreditNote = strCreditNote +SqlDtr.GetValue(0).ToString()+"~";

					}
    
				}
				SqlDtr.Close();

				txtTempContra.Value = strContra;
				txtTempJournal.Value =  strJournal;
				txTempCredit.Value = strCreditNote;
				txtTempDebit.Value = strDebitNote;  
			
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:voucher.aspx,Method:getID() EXCEPTION: "+ ex.Message+" userid :"+ uid);
			}
		}

		/// <summary>
		/// This method fills all the combo box with Ledger Names after server trip to avoid the blank values, 
		/// to set the last selected values.
		/// </summary>
		public void fillCombo()
		{
			try
			{
				ArrayList AccName = new ArrayList();
				SqlDataReader SqlDtr = null;
				string Vouch_Type = DropVoucherName.SelectedItem.Text;
				DropDownList[] dropAccName ={dropAccName1, dropAccName2, dropAccName3, dropAccName4, dropAccName5, dropAccName6, dropAccName7, dropAccName8};
				HtmlInputHidden[] txtAccName ={txtAccName1, txtAccName2, txtAccName3, txtAccName4, txtAccName5,txtAccName6, txtAccName7, txtAccName8}; 
				for(int k=0;k<dropAccName.Length;k++)
				{
					dropAccName[k].Items.Clear();
					dropAccName[k].Items.Add("Select");  
				}
				
				dbobj.SelectQuery("select lm.Ledger_name+':'+cast(lm.Ledger_ID as varchar),lmsg.sub_grp_name from Ledger_Master lm,Ledger_Master_Sub_grp lmsg where lm.Sub_grp_ID = lmsg.Sub_grp_ID ",ref SqlDtr);
				while(SqlDtr.Read())
				{
					//int i = 0;
					string subgrpname = SqlDtr.GetValue(1).ToString();
					if(Vouch_Type.Equals("Contra"))
					{
						if(subgrpname.Trim().StartsWith("Cash") || subgrpname.Trim().StartsWith("Bank"))
						{
							AccName.Add(SqlDtr.GetValue(0).ToString());
							//for(i = 0;i<dropAccName.Length;i++)
							//{
							//	dropAccName[i].Items.Add(SqlDtr.GetValue(0).ToString()); 
							//}
						}
					}
					if(Vouch_Type.Equals("Journal"))
					{
						if(!subgrpname.Trim().StartsWith("Cash") && !subgrpname.Trim().StartsWith("Bank"))
						{
							AccName.Add(SqlDtr.GetValue(0).ToString());
							//for(i = 0;i<dropAccName.Length;i++)
							//{
							//	dropAccName[i].Items.Add(SqlDtr.GetValue(0).ToString()); 
							//}
						}
					}
					if(Vouch_Type.Equals("Credit Note") || Vouch_Type.Equals("Debit Note"))
					{
						AccName.Add(SqlDtr.GetValue(0).ToString());
						//for(i = 0;i<dropAccName.Length;i++)
						//{
						//	dropAccName[i].Items.Add(SqlDtr.GetValue(0).ToString()); 
						//}
					}
				}
				SqlDtr.Close();
				AccName.Sort();
				for(int j=0;j<AccName.Count;j++)
				{
					for(int i = 0;i<dropAccName.Length;i++)
					{
						dropAccName[i].Items.Add(AccName[j].ToString());
					}
				}
				for(int j=0;j<dropAccName.Length;j++)
				{
					dropAccName[j].SelectedIndex =dropAccName[j].Items.IndexOf(dropAccName[j].Items.FindByText(txtAccName[j].Value ));      
				}
				txtVouchID.Value = id; 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:voucher.aspx,Method:fillCombo() EXCEPTION: "+ ex.Message+" userid :"+ uid);
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
			this.DropDownID.SelectedIndexChanged += new System.EventHandler(this.DropDownID_SelectedIndexChanged);
			this.btnEdit1.Click += new System.EventHandler(this.btnEdit1_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to save the record before check the value.
		/// </summary>
		public void Insert()
		{
			flag = 0;
			if(txtVouchID.Visible==true)
				id = txtID.Value;
			else
				id=DropDownID.SelectedItem.Text;
			if(txtAccName1.Value == "Select" && txtAccName2.Value == "Select"  && txtAccName3.Value == "Select"  && txtAccName4.Value == "Select"  && txtAccName5.Value == "Select"  && txtAccName6.Value == "Select"  && txtAccName7.Value == "Select"  && txtAccName8.Value == "Select" )
			{
				txtVouchID.Value = id;
				MessageBox.Show("Please Select Atleast One Account Name");
				//fillCombo();
				//setValue();
				flag=1;
				return;
			}
			DropDownList[] dropAccName ={dropAccName1, dropAccName2, dropAccName3, dropAccName4, dropAccName5, dropAccName6, dropAccName7, dropAccName8};
			HtmlInputHidden[] txtAccName ={txtAccName1, txtAccName2, txtAccName3, txtAccName4, txtAccName5,txtAccName6, txtAccName7, txtAccName8}; 
			TextBox[] Amount = {txtAmount1,txtAmount2,txtAmount3,txtAmount4,txtAmount5,txtAmount6,txtAmount7,txtAmount8};
			DropDownList[] dropType = {dropType_1 ,dropType_2,dropType_3,dropType_4,dropType_5,dropType_6,dropType_7,dropType_8};
			string narration = txtNarration.Value.Trim();
			string Vouch_Type = DropVoucherName.SelectedItem.Text;
			//string date = GenUtil.str2MMDDYYYY(txtDate.Text.ToString());
			for(int i=0; i<(txtAccName.Length/2);i++)
			{
				if(txtAccName[i].Value!="Select")
				{
					if(txtAccName[i].Value==txtAccName[i+4].Value)
					{
						MessageBox.Show("Can Not be Select Same Ledger Name");
						flag=1;
						return;
					}
					if(Amount[i].Text.Trim()== "" && Amount[i+4].Text.Trim()== "")
					{
						MessageBox.Show("Please Enter the Amount");
						flag=1;
						return;
					}
				}
			}
			DateTime Invoice_Date = System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtDate.Text.ToString())+" "+DateTime.Now.TimeOfDay.ToString());
			
			int intID = System.Convert.ToInt32(id.ToString());
			//int flag = 0;
			//flag = 0;
			for(int i=0; i<(dropAccName.Length/2);i++)
			{
				int c = 0;
				if(	txtAccName[i].Value != "Select" && txtAccName[i+4].Value == "Select")
				{
					MessageBox.Show("Please Select The Second Account Name");
					flag = 1;
					//break;
					return;
				}
				else if(txtAccName[i].Value == "Select" && txtAccName[i+4].Value != "Select")
				{
					MessageBox.Show("Please Select The First Account Name");
					flag = 1;
					//break;
					return;
				}
				
				if(txtAccName[i].Value != "Select" && txtAccName[i+4].Value != "Select" && Amount[i].Text.Trim()!= "" && Amount[i+4].Text.Trim()!= "")
				{
					string crID = "";
					string drID = "";
					string Amount_cr = "";
					string Amount_Dr = "";
					string L_Type ="";
					//string Invoice_Date="";

					string Ledg_ID =txtAccName[i].Value.ToString() ;
					string[] arr = Ledg_ID.Split(new char[] {':'},Ledg_ID.Length);
					string Ledg_ID1 =txtAccName[i+4].Value.ToString() ;
					string[] arr1 = Ledg_ID1.Split(new char[] {':'},Ledg_ID1.Length);
					//if(DropDownID.Visible==true)
					//	Invoice_Date=Entry_Date;
					//else
					//Invoice_Date = DateTime.Now.ToString();
					//	Invoice_Date = GenUtil.str2MMDDYYYY(txtDate.Text.ToString())+" "+DateTime.Today.TimeOfDay.ToString();
					if(dropType[i].SelectedItem.Text.Trim() == "Dr")
					{
						drID = arr[1];
						crID = arr1[1];
						Amount_Dr = Amount[i].Text.Trim();
						Amount_cr = Amount[i+4].Text.Trim();
						L_Type = "Dr";
					}
					else
					{
						drID = arr1[1];
						crID = arr[1];
						Amount_Dr = Amount[i+4].Text.Trim();
						Amount_cr = Amount[i].Text.Trim();
						L_Type = "Cr";
					}
						
					//dbobj.Insert_or_Update("Insert into Voucher_Transaction values("+intID+",'"+Vouch_Type.Trim()+"','"+date+"',"+crID.Trim() +","+Amount_cr.Trim() +","+drID.Trim() +","+Amount_Dr.Trim() +",'"+narration+"','"+L_Type+"')",ref c);
					dbobj.Insert_or_Update("Insert into Voucher_Transaction values("+intID+",'"+Vouch_Type.Trim()+"','"+Invoice_Date.ToString()+"',"+crID.Trim() +","+Amount_cr.Trim() +","+drID.Trim() +","+Amount_Dr.Trim() +",'"+narration+"','"+L_Type+"')",ref c);
					object obj = null;
					//dbobj.ExecProc(OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",drID.Trim(),"@Particulars",Vouch_Type.Trim()+" ("+intID+")","@Debit_Amount",Amount_Dr.Trim(),"@Credit_Amount","0.0","@type","Dr");
					dbobj.ExecProc(OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",drID.Trim(),"@Particulars",Vouch_Type.Trim()+" ("+intID+")","@Debit_Amount",Amount_Dr.Trim(),"@Credit_Amount","0.0","@type","Dr","@Invoice_Date",Invoice_Date);
					//System.Threading.Thread.Sleep(1000);
					//dbobj.ExecProc(OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",crID.Trim(),"@Particulars",Vouch_Type.Trim()+" ("+intID+")","@Debit_Amount","0.0","@Credit_Amount",Amount_cr.Trim(),"@type","Cr");
					dbobj.ExecProc(OprType.Insert,"ProInsertAccountsLedger",ref obj,"@Ledger_ID",crID.Trim(),"@Particulars",Vouch_Type.Trim()+" ("+intID+")","@Debit_Amount","0.0","@Credit_Amount",Amount_cr.Trim(),"@type","Cr","@Invoice_Date",Invoice_Date);
					dbobj.ExecProc(OprType.Insert,"ProCustomerLedgerEntry",ref obj,"@Voucher_ID",intID,"@Ledger_ID",drID.Trim(),"@Amount" ,Amount_Dr.Trim(),"@Type","Dr.","@Invoice_Date",Invoice_Date);
					dbobj.ExecProc(OprType.Insert,"ProCustomerLedgerEntry",ref obj,"@Voucher_ID",intID,"@Ledger_ID",crID.Trim(),"@Amount" ,Amount_cr.Trim(),"@Type","Cr.","@Invoice_Date",Invoice_Date);
					if(txtVouchID.Visible==true)
					{
						CustomerInsertUpdate(drID);
						CustomerInsertUpdate(crID);
					}
					intID++;
				}
			}
			if(DropDownID.Visible==true)
			{
				//if(DropVoucherName.SelectedIndex!=1)
				//{
				CustomerUpdate();
				//}
			}
		}

		/// <summary>
		/// This method is used to call the Save() function for save the voucher information.
		/// </summary>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				Insert();
				int intID=System.Convert.ToInt32(id.ToString());
				if(flag == 1)
				{
					txtVouchID.Value = id;
					//MessageBox.Show("Please Select The Account Name");
					fillCombo();
					//setValue();
					return;
				}
				else
				{
					MessageBox.Show("Voucher Saved"); 
					CreateLogFiles.ErrorLog("Form:voucher.aspx.cs,Method:btnAdd_Click, New Voucher of ID = "+(--intID)+" Saved  userid :"+ uid);
					makingReport();
					//Print(); 
					clear();
					getID();
				}
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:voucher.aspx.cs,Method:btnAdd_Click EXCEPTION: "+ ex.Message+" userid :"+ uid);
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
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\Voucher.txt";
				StreamWriter sw = new StreamWriter(path);
				string voucher_id = "";
				string lcr = "";
				string ldr = "";
				string rcr = "";
				string rdr = "";

				if(DropDownID.Visible == true )
				{
					voucher_id = DropDownID.SelectedItem.Text;  
				}
				else
				{
					voucher_id = txtID.Value; 
				}
				
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
				string des="------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("===============",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Voucher Entry",des.Length)); 
				sw.WriteLine(GenUtil.GetCenterAddr("===============",des.Length));
				sw.WriteLine("");
				sw.WriteLine("Voucher Type: {0,-14:S} Voucher ID: {1,-12:S} Voucher Date: {2,-10:S} ",DropVoucherName.SelectedItem.Text,voucher_id,txtDate.Text.Trim());
				sw.WriteLine("+------------------------------+-------------+------------------------------+-------------+");
				sw.WriteLine("|    Account Name              |    Amount   |       Account Name           |  Amount     |");
				sw.WriteLine("+------------------------------+-------------+------------------------------+-------------+");
				//   123456789012345678901234567890 1234567890123 123456789012345678901234 1234567890123
				string info = " {0,-30:S} {1,13:S} {2,-30:S} {3,13:S}";
				if(txtAccName1.Value != "Select")
				{
					sw.WriteLine(info,trimStr(txtAccName1 .Value.Trim()),txtAmount1.Text+" "+dropType_1.SelectedItem.Text,trimStr(txtAccName5.Value.Trim()),txtAmount5.Text+" "+dropType_5.SelectedItem.Text);      
				}
				else
				{
					sw.WriteLine(info,"","","","");  
				}
				if(txtAccName2.Value != "Select")
				{
					sw.WriteLine(info,trimStr(txtAccName2 .Value.Trim()),txtAmount2.Text+" "+dropType_2.SelectedItem.Text,trimStr(txtAccName6.Value.Trim()),txtAmount6.Text+" "+dropType_6.SelectedItem.Text);      
				}
				else
				{
					sw.WriteLine(info,"","","","");  
				}
				if(txtAccName3.Value != "Select")
				{
					sw.WriteLine(info,trimStr(txtAccName3 .Value.Trim()),txtAmount3.Text+" "+dropType_3.SelectedItem.Text,trimStr(txtAccName7.Value.Trim()),txtAmount7.Text+" "+dropType_7.SelectedItem.Text);      
				}
				else
				{
					sw.WriteLine(info,"","","","");  
				}

				if(txtAccName4.Value != "Select")
				{
					sw.WriteLine(info,trimStr(txtAccName4.Value.Trim()),txtAmount4.Text+" "+dropType_4.SelectedItem.Text,trimStr(txtAccName8.Value.Trim()),txtAmount8.Text+" "+dropType_8.SelectedItem.Text);      
				}
				else
				{
					sw.WriteLine(info,"","","","");  
				}


				sw.WriteLine("+------------------------------+-------------+------------------------------+-------------+");
				if(txtLCr.Text.Trim().Equals(""))
				{
					lcr = "0";
				}
				else
				{
					lcr = txtLCr.Text.Trim();  
				}
				if(txtLDr.Text.Trim().Equals(""))
				{
					ldr = "0";
				}
				else
				{
					ldr = txtLDr.Text.Trim();  
				}
				if(txtRCr.Text.Trim().Equals(""))
				{
					rcr = "0";
				}
				else
				{
					rcr = txtRCr.Text.Trim();  
				}
				if(txtRDr.Text.Trim().Equals(""))
				{
					rdr = "0";
				}
				else
				{
					rdr = txtRDr.Text.Trim();  
				}
				sw.WriteLine(info,"Total CR:",lcr+" Cr","",rcr+" Cr");
				sw.WriteLine(info,"Total DR:",ldr+" Dr","",rdr+" Dr");
				sw.WriteLine("+------------------------------+-------------+------------------------------+-------------+");
				sw.WriteLine("Narration :"+checkStr(txtNarration.Value));
				// deselect Condensed
				sw.Write((char)27);
				sw.Write((char)18);
				//sw.Write((char)12);
				sw.Close();	
				//sw.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:voucher.aspx.cs,Method:,makingReport() EXCEPTION: "+ ex.Message+" userid :"+ uid);
			}
		}

		/// <summary>
		/// This method is used to contacst the Print_WiindowServices via socket and sends the Voucher.txt 
		/// file name to print.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\Voucher.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:Voucher.aspx,Method:print. Report Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:Voucher.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:Voucher.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:Voucher.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Voucher.aspx,Method:print  EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		}
	
		/// <summary>
		/// This method is used to check the string length with passing argument.
		/// </summary>
		public string checkStr(string str)
		{
			if(str.IndexOf("\r\n") >0)
			{
				str = str.Replace("\r\n"," "); 
			}
			return str;
		}

		/// <summary>
		/// This method is used to trim the string length
		/// </summary>
		public string trimStr(string str)
		{
			if(str.Length > 30)
			{
				str = str.Substring(0,30); 
			}
			return str;
		}

		/// <summary>
		/// This method is used to clear the form.
		/// </summary>
		public void clear1()
		{
			LedgerID=new ArrayList();
			DropDownID.Visible = false;
			txtVouchID .Visible = true;
			btnEdit1.Visible = true;
			btnEdit.Enabled = false;  
			btnDelete.Enabled = false;
			btnAdd.Enabled = true;
			//txtDate.Enabled = false;
			txtDate.Text = DateTime.Now.Day.ToString()+"/"+ DateTime.Now.Month.ToString()+"/"+DateTime.Now.Year.ToString();
			DropVoucherName.Enabled = true; 

			DropDownList[] dropAccName ={dropAccName1, dropAccName2, dropAccName3, dropAccName4, dropAccName5, dropAccName6, dropAccName7, dropAccName8};
			TextBox[] Amount = {txtAmount1,txtAmount2,txtAmount3,txtAmount4,txtAmount5,txtAmount6,txtAmount7,txtAmount8};
			DropDownList[] dropType = {dropType_1 ,dropType_2,dropType_3,dropType_4,dropType_5,dropType_6,dropType_7,dropType_8};
			for(int i = 1;i<dropAccName.Length/2;i++)
			{
				dropAccName[i].Enabled = true;
				dropAccName[i+4].Enabled = true;
				Amount[i].Enabled = true;
				Amount[i+4].Enabled = true;
				dropType[i].Enabled = true;  
				dropType[i+4].Enabled = true;
			}
		
		}

		/// <summary>
		/// This method is used to clear the form.
		/// </summary>
		public void clear()
		{
			DropVoucherName.SelectedIndex = 0; 
			DropDownList[] dropAccName ={dropAccName1, dropAccName2, dropAccName3, dropAccName4, dropAccName5, dropAccName6, dropAccName7, dropAccName8};
			HtmlInputHidden[] txtAccName ={txtAccName1, txtAccName2, txtAccName3, txtAccName4, txtAccName5,txtAccName6, txtAccName7, txtAccName8}; 
			TextBox[] Amount = {txtAmount1,txtAmount2,txtAmount3,txtAmount4,txtAmount5,txtAmount6,txtAmount7,txtAmount8};
			DropDownList[] dropType = {dropType_1 ,dropType_2,dropType_3,dropType_4,dropType_5,dropType_6,dropType_7,dropType_8};
			for(int i = 0;i<dropAccName.Length;i++)
			{
				dropAccName[i].SelectedIndex = 0;
				txtAccName[i].Value = "Select";
				Amount[i].Text = "";
				dropType[i].SelectedIndex = 0; 
			}
			txtLCr.Text  = ""; 
			txtLDr.Text = "";
			txtRCr.Text = "";
			txtRDr.Text = "";
			txtNarration.Value = ""; 
			txtVouchID.Value =""; 
			Entry_Date="";
			Dr = "";
			Cr = "";
		}

		/// <summary>
		/// This method is used to fill the all Voucher id in the combo from the database.
		/// </summary>
		private void btnEdit1_Click(object sender, System.EventArgs e)
		{
			try
			{
				clear();
				DropDownID.Items.Clear();
				DropDownID.Items.Add("Select"); 
				//DropVoucherName.Enabled = false; 
				txtVouchID.Visible  = false;
				DropDownID.Visible = true;
				btnEdit1.Visible = false;
				btnAdd.Enabled  = false;
				btnEdit.Enabled = true;
				btnDelete.Enabled =  true;
				//txtDate.Enabled = false;
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("select voucher_id from voucher_transaction where voucher_type != 'Payment' order by Voucher_id",ref SqlDtr);
				while(SqlDtr.Read())
				{
					DropDownID.Items.Add(SqlDtr["voucher_id"].ToString());    
				}
				SqlDtr.Close();
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:voucher.aspx.cs,Method:btnEdit1_Click EXCEPTION: "+ ex.Message+" userid :"+ uid);
			}
		}
		
		static string Entry_Date="";
		/// <summary>
		/// This method is used to retrieve the all values from the database according to selected value in the dropdownlist.
		/// </summary>
		private void DropDownID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropDownID.SelectedIndex == 0)  
				{
					MessageBox.Show("Please select Voucher ID");
					fillCombo();
					setValue(); 
					return;
				}
				clear();
				string voucher_id = DropDownID.SelectedItem.Text;  
				//txtID.Value=DropDownID.SelectedItem.Text;

				SqlDataReader SqlDtr = null;
				SqlDataReader SqlDtr1 = null;
				SqlDataReader SqlDtr2 = null;
			
				dbobj.SelectQuery("Select * from voucher_transaction where Voucher_ID = "+ voucher_id,ref SqlDtr);
				if(SqlDtr.Read())
				{
					DropVoucherName.SelectedIndex = DropVoucherName.Items.IndexOf(DropVoucherName.Items.FindByText(SqlDtr["Voucher_Type"].ToString()));
					txtDate.Text = GenUtil.str2DDMMYYYY(trimDate(SqlDtr["voucher_date"].ToString ())); 
					Entry_Date=SqlDtr["Voucher_Date"].ToString();
					if(SqlDtr["L_Type"].ToString().Equals("Cr"))  
					{
						txtAmount1.Text = SqlDtr["Amount1"].ToString(); 
						txtAmount5.Text = SqlDtr["Amount2"].ToString();
						txtLCr.Text = SqlDtr["Amount1"].ToString();
						txtRDr.Text = SqlDtr["Amount2"].ToString();
						Cr=SqlDtr["Ledg_ID_Cr"].ToString();
						txtNarration.Value = SqlDtr["Narration"].ToString();  
						dropType_1.SelectedIndex = dropType_1.Items.IndexOf(dropType_1.Items.FindByText("Cr"));
						dropType_5.SelectedIndex = dropType_5.Items.IndexOf(dropType_5.Items.FindByText("Dr"));
						dbobj.SelectQuery("Select Ledger_Name+':'+cast(Ledger_ID as varchar) from Ledger_Master where Ledger_ID="+SqlDtr["Ledg_ID_Cr"].ToString(),ref SqlDtr1);
						//Entry_Date=SqlDtr["Voucher_Date"].ToString();
						if(SqlDtr1.Read())
						{
							txtAccName1.Value = SqlDtr1.GetValue(0).ToString();  
						}
						SqlDtr1.Close();
						Dr=SqlDtr["Ledg_ID_Dr"].ToString();
						dbobj.SelectQuery("Select Ledger_Name+':'+cast(Ledger_ID as varchar) from Ledger_Master where Ledger_ID="+SqlDtr["Ledg_ID_Dr"].ToString(),ref SqlDtr2);
						if(SqlDtr2.Read())
						{
							txtAccName5.Value = SqlDtr2.GetValue(0).ToString();  
						}
						SqlDtr2.Close();
						LedgerID.Add(SqlDtr["Ledg_ID_Dr"].ToString());
						LedgerID.Add(SqlDtr["Ledg_ID_Cr"].ToString());
					}
					else
					{
						txtAmount1.Text = SqlDtr["Amount2"].ToString(); 
						txtAmount5.Text = SqlDtr["Amount1"].ToString();
						txtLDr.Text = SqlDtr["Amount2"].ToString();
						txtRCr.Text = SqlDtr["Amount1"].ToString();
						txtNarration.Value = SqlDtr["Narration"].ToString();  
						dropType_1.SelectedIndex = dropType_1.Items.IndexOf(dropType_1.Items.FindByText("Dr"));
						dropType_5.SelectedIndex = dropType_5.Items.IndexOf(dropType_5.Items.FindByText("Cr"));
						Dr = SqlDtr["Ledg_ID_Dr"].ToString();
						dbobj.SelectQuery("Select Ledger_Name+':'+cast(Ledger_ID as varchar) from Ledger_Master where Ledger_ID="+SqlDtr["Ledg_ID_Dr"].ToString(),ref SqlDtr1);
						if(SqlDtr1.Read())
						{
							txtAccName1.Value = SqlDtr1.GetValue(0).ToString();  
						}
						SqlDtr1.Close();
						Cr=SqlDtr["Ledg_ID_Cr"].ToString();
						dbobj.SelectQuery("Select Ledger_Name+':'+cast(Ledger_ID as varchar) from Ledger_Master where Ledger_ID="+SqlDtr["Ledg_ID_Cr"].ToString(),ref SqlDtr2);
						if(SqlDtr2.Read())
						{
							txtAccName5.Value = SqlDtr2.GetValue(0).ToString();  
						}
						SqlDtr2.Close();
						LedgerID.Add(SqlDtr["Ledg_ID_Dr"].ToString());
						LedgerID.Add(SqlDtr["Ledg_ID_Cr"].ToString());
					}
					fillCombo();
					dropAccName1.SelectedIndex = dropAccName1.Items.IndexOf(dropAccName1.Items.FindByText(txtAccName1.Value.ToString()));
					dropAccName5.SelectedIndex = dropAccName1.Items.IndexOf(dropAccName1.Items.FindByText(txtAccName5.Value.ToString()));
					//DropVoucherName.Enabled = false;
				}
				SqlDtr.Close(); 

				// This code disables all the combo and Text Fields except first Row.
				DropDownList[] dropAccName ={dropAccName1, dropAccName2, dropAccName3, dropAccName4, dropAccName5, dropAccName6, dropAccName7, dropAccName8};
				TextBox[] Amount = {txtAmount1,txtAmount2,txtAmount3,txtAmount4,txtAmount5,txtAmount6,txtAmount7,txtAmount8};
				DropDownList[] dropType = {dropType_1 ,dropType_2,dropType_3,dropType_4,dropType_5,dropType_6,dropType_7,dropType_8};
				for(int i = 1;i<dropAccName.Length/2;i++)
				{
					dropAccName[i].Enabled = false;
					dropAccName[i+4].Enabled = false;
					Amount[i].Enabled = false;
					Amount[i+4].Enabled = false;
					dropType[i].Enabled = false;  
					dropType[i+4].Enabled = false;
				}
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:voucher.aspx.cs,Method:DropDownID_SelectedIndexChanged EXCEPTION: "+ ex.Message+" userid :"+ uid);
			}
		}

		/// <summary>
		/// This method return only date from date and time.
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
		/// This method update the voucher entry in edit time.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropDownID.SelectedIndex == 0)
				{
					MessageBox.Show("Please select Account Name");
					return;
				}
				if(txtAccName1.Value == "Select" || txtAccName5.Value == "Select" )
				{
					MessageBox.Show("Please select Account Name");
					fillCombo();
					return;
				}
				//				string voucher_type = DropVoucherName.SelectedItem.Text;
				//				string voucher_ID = DropDownID.SelectedItem.Text;
				//				string date = txtDate.Text.Trim();
				//				date = GenUtil.str2MMDDYYYY(date); 
				//				string narration = txtNarration.Value.Trim();  
				//				string crID = "";
				//				string drID = "";
				//				string Amount_cr = "";
				//				string Amount_Dr = "";
				//				string L_Type =""; 
				//
				//				string Ledg_ID =txtAccName1.Value.ToString() ;
				//				string[] arr = Ledg_ID.Split(new char[] {':'},Ledg_ID.Length);
				//				string Ledg_ID1 =txtAccName5.Value.ToString() ;
				//				string[] arr1 = Ledg_ID1.Split(new char[] {':'},Ledg_ID1.Length);
				//				if(dropType_1.SelectedItem.Text.Trim() == "Dr")
				//				{
				//					drID = arr[1];
				//					crID = arr1[1];
				//					Amount_Dr = txtAmount1.Text.Trim();
				//					Amount_cr = txtAmount5.Text.Trim();
				//					L_Type = "Dr";
				//				}
				//				else
				//				{
				//					drID = arr1[1];
				//					crID = arr[1];
				//					Amount_Dr = txtAmount5.Text.Trim();
				//					Amount_cr = txtAmount1.Text.Trim();
				//					L_Type = "Cr";
				//				}
				//				int c = 0;
				//				
				//				dbobj.Insert_or_Update("Update voucher_transaction set voucher_date ='"+date+"',Ledg_ID_Cr ="+crID.Trim()+",Amount1="+Amount_cr+",Ledg_ID_Dr="+drID.Trim()+",Amount2="+Amount_Dr+",Narration='"+narration+"',L_Type='"+L_Type+"' where Voucher_ID ="+voucher_ID,ref c);   
				//				object obj = null;
				//				dbobj.ExecProc(OprType.Update,"ProUpdateAccountsLedger",ref obj,"@Voucher_ID",voucher_ID,"@Ledger_ID",drID.Trim(),"@Amount",Amount_Dr,"@Type","Dr");
				//				dbobj.ExecProc(OprType.Update,"ProUpdateAccountsLedger",ref obj,"@Voucher_ID",voucher_ID,"@Ledger_ID",crID.Trim(),"@Amount",Amount_cr,"@Type","Cr");
				//				if(c > 0)
				//				{
				//					MessageBox.Show("Voucher Updated"); 
				//					CreateLogFiles.ErrorLog("Form:voucher,Method:btnEdit_Click, Voucher of ID = "+voucher_ID+" updated  userid :"+ uid);
				//					makingReport();
				//					//Print();
				//					clear1();
				//					clear();
				//					getID();
				//				}
				//				checkPrevileges();
				//****************
				
				int c = 0;
				dbobj.Insert_or_Update("delete from voucher_Transaction where voucher_id ="+DropDownID.SelectedItem.Text.Trim(),ref c);
				if(DropVoucherName.SelectedItem.Text.Equals("Contra"))
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars ='Contra ("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				else if(DropVoucherName.SelectedItem.Text.Equals("Journal"))
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars ='Journal ("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				else if(DropVoucherName.SelectedItem.Text.Equals("Credit Note"))
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars ='Credit Note ("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				else if(DropVoucherName.SelectedItem.Text.Equals("Debit Note"))
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars ='Debit Note ("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				dbobj.Insert_or_Update("delete from CustomerLedgerTable where Particular ='Voucher("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);

				Insert();

				MessageBox.Show("Voucher Updated"); 
				CreateLogFiles.ErrorLog("Form:voucher,Method:btnEdit_Click, Voucher of ID = "+DropDownID.SelectedItem.Text+" updated  userid :"+ uid);
				makingReport();
				//Print();
				clear1();
				clear();
				getID();
				checkPrevileges();
				//****************
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:voucher.aspx.cs,Method:btnEdit_Click EXCEPTION: "+ ex.Message+" userid :"+ uid);
			}
		}

		/// <summary>
		/// This method is used to dalete the record according to selected value from the dropdownlist.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropDownID.SelectedIndex == 0)
				{
					MessageBox.Show("Please select Account Name");
					return;
				}
				int c = 0;
				dbobj.Insert_or_Update("delete from voucher_Transaction where voucher_id ="+DropDownID.SelectedItem.Text.Trim(),ref c);
				//***********
				if(DropVoucherName.SelectedItem.Text.Equals("Contra"))
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars ='Contra ("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				else if(DropVoucherName.SelectedItem.Text.Equals("Journal"))
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars ='Journal ("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				else if(DropVoucherName.SelectedItem.Text.Equals("Credit Note"))
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars ='Credit Note ("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				else if(DropVoucherName.SelectedItem.Text.Equals("Debit Note"))
					dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars ='Debit Note ("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				dbobj.Insert_or_Update("delete from CustomerLedgerTable where Particular ='Voucher("+DropDownID.SelectedItem.Text.Trim()+")'",ref c);
				//*************
				//if(c > 0)
				//{
				CustomerUpdate();
				MessageBox.Show("Voucher Deleted"); 
				CreateLogFiles.ErrorLog("Form:voucher.aspx.cs,Method:btnDelete_Click Voucher of ID = "+DropDownID.SelectedItem.Text.Trim()+" deleted  userid :"+ uid);
				clear1();
				clear();
				getID();
				//}
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:voucher.aspx.cs,Method:btnDelete_Click EXCEPTION: "+ ex.Message+" userid :"+ uid);
			}
		}

		/// <summary>
		/// Prepares the report file Voucher.txt for printing.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			//makingReport();
			Print();
		}

		//		public void CustomerUpdate()
		//		{
		//			SqlDataReader rdr=null;
		//			SqlCommand cmd;
		//			InventoryClass obj =new InventoryClass();
		//			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
		//			double Bal=0;
		//			string BalType="",str="";
		//			int i=0;
		//			for(int n=0;n<2;n++)
		//			{
		//				if(n==0)
		//					str="select * from AccountsLedgerTable where Ledger_ID='"+Dr+"' order by entry_date";
		//				else
		//					str="select * from AccountsLedgerTable where Ledger_ID='"+Cr+"' order by entry_date";
		//				rdr=obj.GetRecordSet(str);
		//				Bal=0;
		//				BalType="";
		//				i=0;
		//				while(rdr.Read())
		//				{
		//					if(i==0)
		//					{
		//						BalType=rdr["Bal_Type"].ToString();
		//						i++;
		//					}
		//					if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
		//					{
		//						if(BalType=="Cr")
		//						{
		//							Bal+=double.Parse(rdr["Credit_Amount"].ToString());
		//							BalType="Cr";
		//						}
		//						else
		//						{
		//							Bal-=double.Parse(rdr["Credit_Amount"].ToString());
		//							if(Bal<0)
		//							{
		//								Bal=double.Parse(Bal.ToString().Substring(1));
		//								BalType="Cr";
		//							}
		//							else
		//								BalType="Dr";
		//						}
		//					}
		//					else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
		//					{
		//						if(BalType=="Dr")
		//							Bal+=double.Parse(rdr["Debit_Amount"].ToString());
		//						else
		//						{
		//							Bal-=double.Parse(rdr["Debit_Amount"].ToString());
		//							if(Bal<0)
		//							{
		//								Bal=double.Parse(Bal.ToString().Substring(1));
		//								BalType="Dr";
		//							}
		//							else
		//								BalType="Cr";
		//						}
		//					}
		//					Con.Open();
		//					cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
		//					cmd.ExecuteNonQuery();
		//					cmd.Dispose();
		//					Con.Close();
		//							
		//				}
		//				rdr.Close();
		//				
		//				if(n==0)
		//					str="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+Dr+"') order by entrydate";
		//				else
		//					str="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+Cr+"') order by entrydate";
		//				rdr=obj.GetRecordSet(str);
		//				Bal=0;
		//				i=0;
		//				BalType="";
		//				while(rdr.Read())
		//				{
		//					if(i==0)
		//					{
		//						BalType=rdr["BalanceType"].ToString();
		//						i++;
		//					}
		//					if(double.Parse(rdr["CreditAmount"].ToString())!=0)
		//					{
		//						if(BalType=="Cr.")
		//						{
		//							Bal+=double.Parse(rdr["CreditAmount"].ToString());
		//							BalType="Cr.";
		//						}
		//						else
		//						{
		//							Bal-=double.Parse(rdr["CreditAmount"].ToString());
		//							if(Bal<0)
		//							{
		//								Bal=double.Parse(Bal.ToString().Substring(1));
		//								BalType="Cr.";
		//							}
		//							else
		//								BalType="Dr.";
		//						}
		//					}
		//					else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
		//					{
		//						if(BalType=="Dr.")
		//							Bal+=double.Parse(rdr["DebitAmount"].ToString());
		//						else
		//						{
		//							Bal-=double.Parse(rdr["DebitAmount"].ToString());
		//							if(Bal<0)
		//							{
		//								Bal=double.Parse(Bal.ToString().Substring(1));
		//								BalType="Dr.";
		//							}
		//							else
		//								BalType="Cr.";
		//						}
		//					}
		//					Con.Open();
		//					cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
		//					cmd.ExecuteNonQuery();
		//					cmd.Dispose();
		//					Con.Close();
		//				}
		//				rdr.Close();
		//			}
		//		}

		/// <summary>
		/// This method is used for update the customer balance after update the record.
		/// </summary>
		public void CustomerUpdate()
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			double Bal=0;
			string BalType="",str="";
			int i=0;
			string tempDate="";
			object obj1=null;
			//*************************
			if(Entry_Date.IndexOf(" ")>0)
			{
				string[] CheckDate = Entry_Date.Split(new char[] {' '},Entry_Date.Length);
				if(DateTime.Compare(System.Convert.ToDateTime(CheckDate[0].ToString()),System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtDate.Text)))>0)
					tempDate=GenUtil.str2MMDDYYYY(txtDate.Text);
				else
					tempDate=CheckDate[0].ToString();
			}
			else
				tempDate=GenUtil.str2MMDDYYYY(txtDate.Text);
			for(int k=0;k<LedgerID.Count;k++)
			{
				dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref obj1,"@Ledger_ID",LedgerID[k].ToString(),"@Invoice_Date",tempDate.ToString());
				dbobj.SelectQuery("select cust_id from customer,ledger_master where ledger_name=cust_name and ledger_id='"+LedgerID[k].ToString()+"'",ref rdr);
				if(rdr.Read())
				{
					dbobj.ExecProc(OprType.Insert,"UpdateCustomerLedgerForCustomer",ref obj1,"@Cust_ID",rdr["Cust_ID"].ToString(),"@Invoice_Date",tempDate);
				}
				rdr.Close();
				//				rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date<='"+tempDate+"' order by entry_date desc");
				//				if(rdr.Read())
				//					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
				//				else
				//					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' order by entry_date";
				//				rdr.Close();
				//				//*************************
				//				//string str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID+"' order by entry_date";
				//				rdr=obj.GetRecordSet(str);
				//				Bal=0;
				//				BalType="";
				//				i=0;
				//				while(rdr.Read())
				//				{
				//					if(i==0)
				//					{
				//						BalType=rdr["Bal_Type"].ToString();
				//						Bal=double.Parse(rdr["Balance"].ToString());
				//						i++;
				//					}
				//					else
				//					{
				//						if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
				//						{
				//							if(BalType=="Cr")
				//							{
				//								string ss=rdr["Credit_Amount"].ToString();
				//								Bal+=double.Parse(rdr["Credit_Amount"].ToString());
				//								BalType="Cr";
				//							}
				//							else
				//							{
				//								string ss=rdr["Credit_Amount"].ToString();
				//								Bal-=double.Parse(rdr["Credit_Amount"].ToString());
				//								if(Bal<0)
				//								{
				//									Bal=double.Parse(Bal.ToString().Substring(1));
				//									BalType="Cr";
				//								}
				//								else
				//									BalType="Dr";
				//							}
				//						}
				//						else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
				//						{
				//							if(BalType=="Dr")
				//							{
				//								string ss=rdr["Debit_Amount"].ToString();
				//								Bal+=double.Parse(rdr["Debit_Amount"].ToString());
				//							}
				//							else
				//							{
				//								string ss=rdr["Debit_Amount"].ToString();
				//								Bal-=double.Parse(rdr["Debit_Amount"].ToString());
				//								if(Bal<0)
				//								{
				//									Bal=double.Parse(Bal.ToString().Substring(1));
				//									BalType="Dr";
				//								}
				//								else
				//									BalType="Cr";
				//							}
				//						}
				//						Con.Open();
				//						string str11="update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'";
				//						cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
				//						cmd.ExecuteNonQuery();
				//						cmd.Dispose();
				//						Con.Close();
				//					}		
				//				}
				//				rdr.Close();
				//				//*************************
				//				rdr = obj.GetRecordSet("select top 1 EntryDate from CustomerLedgerTable where CustID=(select Cust_ID from Customer,Ledger_Master where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID[k].ToString()+"') and EntryDate<='"+tempDate+"' order by entrydate desc");
				//				if(rdr.Read())
				//					str="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer,Ledger_Master where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID[k].ToString()+"') and EntryDate>='"+rdr.GetValue(0).ToString()+"' order by entrydate";
				//				else
				//					str="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID[k].ToString()+"') order by entrydate";
				//				rdr.Close();
				//				//*************************
				//				//string str1="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID+"') order by entrydate";
				//				rdr=obj.GetRecordSet(str);
				//				Bal=0;
				//				i=0;
				//				BalType="";
				//				while(rdr.Read())
				//				{
				//					if(i==0)
				//					{
				//						BalType=rdr["BalanceType"].ToString();
				//						Bal=double.Parse(rdr["Balance"].ToString());
				//						i++;
				//					}
				//					else
				//					{
				//						if(double.Parse(rdr["CreditAmount"].ToString())!=0)
				//						{
				//							if(BalType=="Cr.")
				//							{
				//								Bal+=double.Parse(rdr["CreditAmount"].ToString());
				//								BalType="Cr.";
				//							}
				//							else
				//							{
				//								Bal-=double.Parse(rdr["CreditAmount"].ToString());
				//								if(Bal<0)
				//								{
				//									Bal=double.Parse(Bal.ToString().Substring(1));
				//									BalType="Cr.";
				//								}
				//								else
				//									BalType="Dr.";
				//							}
				//						}
				//						else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
				//						{
				//							if(BalType=="Dr.")
				//								Bal+=double.Parse(rdr["DebitAmount"].ToString());
				//							else
				//							{
				//								Bal-=double.Parse(rdr["DebitAmount"].ToString());
				//								if(Bal<0)
				//								{
				//									Bal=double.Parse(Bal.ToString().Substring(1));
				//									BalType="Dr.";
				//								}
				//								else
				//									BalType="Cr.";
				//							}
				//						}
				//						Con.Open();
				//						cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
				//						cmd.ExecuteNonQuery();
				//						cmd.Dispose();
				//						Con.Close();
				//					}
				//				}
				//				rdr.Close();
			}
		}

		/// <summary>
		/// This method is used for update the customer balance after insert record.
		/// </summary>
		public void CustomerInsertUpdate(string Ledger_ID)
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			double Bal=0;
			string BalType="",str="";
			int i=0;
			object obj1 = null;
			/*************************
			if(Invoice_Date.IndexOf(" ")>0)
			{
				string[] CheckDate = Invoice_Date.Split(new char[] {' '},Invoice_Date.Length);
				if(DateTime.Compare(System.Convert.ToDateTime(CheckDate[0].ToString()),System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtDate.Text)))>0)
					Invoice_Date=GenUtil.str2MMDDYYYY(txtDate.Text);
			}
			else
				Invoice_Date=GenUtil.str2MMDDYYYY(txtDate.Text);
			//			for(int k=0;k<LedgerID.Count;k++)
			//			{
			***********/
			
			dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref obj1,"@Ledger_ID",Ledger_ID,"@Invoice_Date",GenUtil.str2MMDDYYYY(txtDate.Text));
			dbobj.SelectQuery("select cust_id from customer,ledger_master where ledger_name=cust_name and ledger_id='"+Ledger_ID+"'",ref rdr);
			if(rdr.Read())
			{
				dbobj.ExecProc(OprType.Insert,"UpdateCustomerLedgerForCustomer",ref obj1,"@Cust_ID",rdr["Cust_ID"].ToString(),"@Invoice_Date",GenUtil.str2MMDDYYYY(txtDate.Text));
			}
			rdr.Close();
			
			//			rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID='"+Ledger_ID+"' and Entry_Date<='"+GenUtil.str2MMDDYYYY(txtDate.Text)+"' order by entry_date desc");
			//			if(rdr.Read())
			//				str="select * from AccountsLedgerTable where Ledger_ID='"+Ledger_ID+"' and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
			//			else
			//				str="select * from AccountsLedgerTable where Ledger_ID='"+Ledger_ID+"' order by entry_date";
			//			rdr.Close();
			//			//*************************
			//			//string str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID+"' order by entry_date";
			//			rdr=obj.GetRecordSet(str);
			//			Bal=0;
			//			BalType="";
			//			i=0;
			//			while(rdr.Read())
			//			{
			//				if(i==0)
			//				{
			//					BalType=rdr["Bal_Type"].ToString();
			//					Bal=double.Parse(rdr["Balance"].ToString());
			//					i++;
			//				}
			//				else
			//				{
			//					if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
			//					{
			//						if(BalType=="Cr")
			//						{
			//							string ss=rdr["Credit_Amount"].ToString();
			//							Bal+=double.Parse(rdr["Credit_Amount"].ToString());
			//							BalType="Cr";
			//						}
			//						else
			//						{
			//							string ss=rdr["Credit_Amount"].ToString();
			//							Bal-=double.Parse(rdr["Credit_Amount"].ToString());
			//							if(Bal<0)
			//							{
			//								Bal=double.Parse(Bal.ToString().Substring(1));
			//								BalType="Cr";
			//							}
			//							else
			//								BalType="Dr";
			//						}
			//					}
			//					else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
			//					{
			//						if(BalType=="Dr")
			//						{
			//							string ss=rdr["Debit_Amount"].ToString();
			//							Bal+=double.Parse(rdr["Debit_Amount"].ToString());
			//						}
			//						else
			//						{
			//							string ss=rdr["Debit_Amount"].ToString();
			//							Bal-=double.Parse(rdr["Debit_Amount"].ToString());
			//							if(Bal<0)
			//							{
			//								Bal=double.Parse(Bal.ToString().Substring(1));
			//								BalType="Dr";
			//							}
			//							else
			//								BalType="Cr";
			//						}
			//					}
			//					Con.Open();
			//					string str11="update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'";
			//					cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
			//					cmd.ExecuteNonQuery();
			//					cmd.Dispose();
			//					Con.Close();
			//				}
			//			}
			//			rdr.Close();
			//			//*************************
			//			rdr = obj.GetRecordSet("select top 1 EntryDate from CustomerLedgerTable where CustID=(select Cust_ID from Customer,Ledger_Master where Ledger_Name=Cust_Name and Ledger_ID='"+Ledger_ID+"') and EntryDate<='"+GenUtil.str2MMDDYYYY(txtDate.Text)+"' order by entrydate desc");
			//			if(rdr.Read())
			//				str="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer,Ledger_Master where Ledger_Name=Cust_Name and Ledger_ID='"+Ledger_ID+"') and EntryDate>='"+rdr.GetValue(0).ToString()+"' order by entrydate";
			//			else
			//				str="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+Ledger_ID+"') order by entrydate";
			//			rdr.Close();
			//			//*************************
			//			//string str1="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID+"') order by entrydate";
			//			rdr=obj.GetRecordSet(str);
			//			Bal=0;
			//			i=0;
			//			BalType="";
			//			while(rdr.Read())
			//			{
			//				if(i==0)
			//				{
			//					BalType=rdr["BalanceType"].ToString();
			//					Bal=double.Parse(rdr["Balance"].ToString());
			//					i++;
			//				}
			//				else
			//				{
			//					if(double.Parse(rdr["CreditAmount"].ToString())!=0)
			//					{
			//						if(BalType=="Cr.")
			//						{
			//							Bal+=double.Parse(rdr["CreditAmount"].ToString());
			//							BalType="Cr.";
			//						}
			//						else
			//						{
			//							Bal-=double.Parse(rdr["CreditAmount"].ToString());
			//							if(Bal<0)
			//							{
			//								Bal=double.Parse(Bal.ToString().Substring(1));
			//								BalType="Cr.";
			//							}
			//							else
			//								BalType="Dr.";
			//						}
			//					}
			//					else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
			//					{
			//						if(BalType=="Dr.")
			//							Bal+=double.Parse(rdr["DebitAmount"].ToString());
			//						else
			//						{
			//							Bal-=double.Parse(rdr["DebitAmount"].ToString());
			//							if(Bal<0)
			//							{
			//								Bal=double.Parse(Bal.ToString().Substring(1));
			//								BalType="Dr.";
			//							}
			//							else
			//								BalType="Cr.";
			//						}
			//					}
			//					Con.Open();
			//					cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
			//					cmd.ExecuteNonQuery();
			//					cmd.Dispose();
			//					Con.Close();
			//				}
			//			}
			//			rdr.Close();
			//}
		}
	}
}