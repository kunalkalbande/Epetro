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

namespace EPetro.Module.Accounts
{
	/// <summary>
	/// Summary description for Ledger
	/// </summary>
	public class Ledgre : System.Web.UI.Page
	{
		
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox TxtAmount;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DropDownList DropSub;
		protected System.Web.UI.WebControls.DropDownList DropGroup;
		protected System.Web.UI.WebControls.TextBox TextSub;
		protected System.Web.UI.WebControls.TextBox TextGroup;
		protected System.Web.UI.WebControls.CheckBox CheckBox2;
		protected System.Web.UI.WebControls.CheckBox CheckAsset;
		protected System.Web.UI.WebControls.CheckBox CheckIncome;
		protected System.Web.UI.WebControls.CheckBox CheckExpen;
		protected System.Web.UI.WebControls.TextBox TxtLedger;
		protected System.Web.UI.WebControls.TextBox TxtSub;
		protected System.Web.UI.WebControls.TextBox TxtGroup;
		protected System.Web.UI.WebControls.RadioButton RadioAsset;
		protected System.Web.UI.WebControls.RadioButton RadioLiab;
		protected System.Web.UI.WebControls.RadioButton RadioExp;
		protected System.Web.UI.WebControls.RadioButton RadioIncome;
		protected System.Web.UI.WebControls.TextBox TxtOpeningBal;
		protected System.Web.UI.WebControls.DropDownList DropBalType;
		protected System.Web.UI.WebControls.DropDownList dropLedgerName;
		protected System.Web.UI.HtmlControls.HtmlImage IMG2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTempGrp;
		protected System.Web.UI.WebControls.Button btnEdit1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtGrp;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid="";
		ArrayList al = new ArrayList();
	
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
				
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
               
			}
			if(!IsPostBack)
			{
				checkPrevileges();
				getSubGroup();
				getGroup();
				getParties();
				TxtSub.Text = "";
				TxtGroup.Text = ""; 
				TxtSub.Enabled =false;
				TxtGroup.Enabled =false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
			}
		}

		/// <summary>
		/// This method returns the parties (i.e. Customer and Vendor names) in the form array to compare 
		/// the Ledger Name not equals to Parties Names.
		/// </summary>
		/// <returns></returns>
		public object[] getParties()
		{
			try
			{
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("Select Cust_Name from  Customer",ref SqlDtr);
				while(SqlDtr.Read())
				{
					al.Add(SqlDtr["Cust_Name"].ToString());
				}
				SqlDtr.Close();

				dbobj.SelectQuery("Select Supp_Name from  Supplier",ref SqlDtr);
				while(SqlDtr.Read())
				{
					al.Add(SqlDtr["Supp_Name"].ToString());
				}
				SqlDtr.Close();
				return al.ToArray(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:getParties() Exception: "+ex.Message+"  User: "+ uid);     
				return null;
			}
		}
		

		/// <summary>
		/// This method checks the user privileges from session.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="1";
			string SubModule="1";
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
			if(View_flag=="0" && Add_Flag=="0" && Edit_Flag=="0" && Del_Flag=="0")
			{
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				return;
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
		/// This method fills the DropSub combo box with values of sub groups from Ledger_Master_Sub_grp
		/// </summary>
		public void getSubGroup()
		{
			try
			{
				DropSub.Items.Clear();
				DropSub.Items.Add("Select");
				DropSub.SelectedIndex = 0; 
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("select distinct sub_grp_name from Ledger_Master_Sub_Grp",ref SqlDtr );
				while(SqlDtr.Read())
				{
					DropSub.Items.Add(SqlDtr["sub_grp_name"].ToString());  
				}
				SqlDtr.Close();
				DropSub.Items.Add("Other");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:getSubGroup() Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		/// <summary>
		/// This Method Access all the group name from MGroup Table and fills the Group Name Combo
		/// </summary>
		public void getGroup()
		{
			try
			{			
				SqlDataReader SqlDtr = null;
				string str = "";
				string s = "";
				string s1="";
				IEnumerator enum1=DropSub.Items.GetEnumerator();
				enum1.MoveNext(); 
				while(enum1.MoveNext()) 
				{
					str  = enum1.Current.ToString();
					if(!str.Trim().Equals("Other")) 
					{
						dbobj.SelectQuery("select gr.Grp_Name,lmsg.Nature_Of_Group from Ledger_Master_Sub_Grp lmsg,mgroup gr where lmsg.sub_grp_name = '"+str.Trim()+"' and lmsg.Grp_ID = gr.Grp_ID",ref SqlDtr); 
						while(SqlDtr.Read())
						{
							s = s+str.Trim()+"~"+SqlDtr["Grp_Name"].ToString()+"~"+SqlDtr["Nature_Of_Group"].ToString()+"#";  
						}
					}
				}
				txtValue.Value = s;
				SqlDtr.Close(); 
				dbobj.SelectQuery("select distinct gr.Grp_Name from Ledger_Master_Sub_Grp lmsg,mgroup gr where  lmsg.Grp_ID = gr.Grp_ID",ref SqlDtr);
				while(SqlDtr.Read())
				{
					s1 = s1 + SqlDtr["Grp_name"].ToString()+"~";
				}
				SqlDtr.Close();
				txtGrp.Value = s1; 
			 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:getGroup() Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		/// <summary>
		/// This is used to fetch The Group after the server trip to avoid the blank value in the Combo box.
		/// </summary>
		public void fetchGroup()
		{
			try
			{
				DropGroup.Items.Clear();
				DropGroup.Items.Add("Select");
		
				SqlDataReader SqlDtr = null;
				if(DropSub.SelectedItem.Text.Trim() != "Other")
				{
					dbobj.SelectQuery("select gr.Grp_Name from Ledger_Master_Sub_Grp lmsg,mgroup gr where lmsg.sub_grp_name = '"+DropSub.SelectedItem.Text.Trim()+"' and lmsg.Grp_ID = gr.Grp_ID",ref SqlDtr);
				}
				else
				{
					TxtSub.Enabled = true; 
					dbobj.SelectQuery("select distinct gr.Grp_Name from Ledger_Master_Sub_Grp lmsg,mgroup gr where  lmsg.Grp_ID = gr.Grp_ID",ref SqlDtr);
				}
				while(SqlDtr.Read())
				{
					DropGroup.Items.Add(SqlDtr["Grp_Name"].ToString());
				}
				DropGroup.Items.Add("Other");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:fetchGroup() Exception: "+ex.Message+"  User: "+ uid);     
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
			this.dropLedgerName.SelectedIndexChanged += new System.EventHandler(this.dropLedgerName_SelectedIndexChanged);
			this.btnEdit1.Click += new System.EventHandler(this.btnEdit1_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Its checks the before save that the account period is inserted in organisaton table or not.
		/// </summary>
		public bool checkAcc_Period()
		{
			SqlDataReader SqlDtr = null;
			int c = 0;
			dbobj.SelectQuery("Select count(Acc_Date_From) from Organisation",ref SqlDtr);
			if(SqlDtr.Read())
			{
				c = System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());  
			}
			SqlDtr.Close();

			if(c > 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// This function is used to save the record before checking the all value with condition.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (TxtLedger.Text == string.Empty)
                {
                    MessageBox.Show("- Please Enter Ledger Name");
                    return;
                }
                string SubGrp = "";
				string Group = "";
				if(!checkAcc_Period())
				{
					MessageBox.Show("Please enter the Accounts Period from Organization Details ");
					fetchGroup();
					return;
				}
				// Check & Fetch The sub Group
				if(DropSub.SelectedIndex == 0)
				{
					MessageBox.Show("Please select Sub Group");
					fetchGroup();
					return;
				}
				else 
				{
					if(DropSub.SelectedItem.Text == "Other")
					{
						if(TxtSub.Text.Trim() == "")
						{
							MessageBox.Show("Please specify Other Sub Group");
							TxtSub.Enabled = true; 
							fetchGroup();
							return;
						}
						else
							SubGrp =TxtSub.Text.Trim(); 
					}
					else
					{
						SubGrp = DropSub.SelectedItem.Text.Trim(); 
					}
				}

				// Check & Fetch The  Group
				if(txtTempGrp.Value== "Select" )
				{
					MessageBox.Show("Please select Group");
					fetchGroup();
					return;
				}
				else 
				{
					if(txtTempGrp.Value == "Other")
					{
						if(TxtGroup.Text.Trim() == "")
						{
							MessageBox.Show("Please specify Other Group");
							TxtGroup.Enabled = true;
							fetchGroup();
							DropGroup.SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(txtTempGrp.Value));  
							return;
						}
						else
							Group =TxtGroup.Text.Trim(); 
					}
					else
					{
						Group = txtTempGrp.Value;
					}
				}
			/*	string FromDate  = GenUtil.str2MMDDYYYY(TxtFr.Text);
				string ToDate = GenUtil.str2MMDDYYYY(TxtTo1.Text); 
				if(DateTime.Compare(System.Convert.ToDateTime(FromDate),System.Convert.ToDateTime(ToDate))>0)
				{
					MessageBox.Show("Date From Should be less than Date To");
					fetchGroup();
					DropGroup .SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(Group));  
					return;
				}*/
				string ledgname = "";
				string nature = "";
				double Op_bal = 0;
				string bal_type = "";
				ledgname = TxtLedger.Text.Trim();
				string op_bal = "0";
				if(TxtOpeningBal.Text.Trim() != "")
					op_bal = TxtOpeningBal.Text.Trim();
 
				Op_bal = System.Convert.ToDouble(op_bal);
				bal_type = DropBalType.SelectedItem.Text.Trim();

				if(RadioAsset.Checked)
					nature = "Assets";
				else if(RadioLiab.Checked)
					nature = "Liabilities";
				else if(RadioExp.Checked)
					nature = "Expenses";
				else
					nature= "Income"; 
            
				int subgrpid = 0;
				SqlDataReader SqlDtr = null;
				// Get the sub_grp_id for selected Sub_Group Name and Nature Of Payment
				dbobj.SelectQuery("select sub_grp_Id from Ledger_Master_Sub_grp  where sub_grp_name = '"+SubGrp+"' and Nature_Of_group ='"+nature+"' and grp_id = (select top 1 grp_id from mgroup where grp_name = '"+Group+"')",ref SqlDtr);
				if(SqlDtr.Read()) 
				{
					subgrpid = System.Convert.ToInt32(SqlDtr["sub_grp_id"].ToString());  
				}
				SqlDtr.Close();
				// Check the Ledger Name matches with parties names.
			/*	object[] obj = getParties();
				for(int k = 0; k < obj.Length ; k++)
				{
					string str = obj[k].ToString();
 
					if(obj[k].ToString().Equals(ledgname))
					{
						MessageBox.Show("Ledger Name should be different than Customer/ Vendor Name");
						fetchGroup();
						DropGroup .SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(Group));  
						return;
					}
				}*/
				int count = 0,count1 = 0;

				// check the Ledger Name is already present for the selected sub group
				//dbobj.ExecuteScalar("Select count(Ledger_ID) from Ledger_Master where Ledger_Name like '"+TxtLedger.Text+"%' and Sub_grp_ID =118",ref count); 
				//if(count >= 1)
				if(DropSub.SelectedItem.Text.Equals("Cash in hand"))
				{
					dbobj.ExecuteScalar("Select count(*) from Ledger_Master where sub_grp_id=118",ref count1); 
					if(count1 > 0)
					{
						MessageBox.Show("Cash Account AlReady Exists");
						fetchGroup();
						DropGroup .SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(Group));
						return;
					}
				}
				dbobj.ExecuteScalar("Select count(Ledger_ID) from Ledger_Master where Ledger_Name = '"+ledgname+"' and Sub_grp_ID = "+subgrpid,ref count); 
				if(count > 0)
				{
					MessageBox.Show("Ledger Name is already exist for selected Sub Group ");
					fetchGroup();
					DropGroup .SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(Group));  
					return;
				}
				else
				{
					object op = null;
					dbobj.ExecProc(OprType.Insert,"ProInsertLedger",ref op,"@Ledger_Name",ledgname,"@SubGrp_Name",SubGrp,"@Group_Name",Group,"@Grp_Nature",nature,"@Op_Bal",Op_bal,"@Bal_Type",bal_type);
				}
				MessageBox.Show("Ledger Saved");	
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:btnSave_Click New Ledger of name "+ledgname+" Saved.  User: "+ uid);     
				clear();
				checkPrevileges(); 
				getSubGroup();
				getGroup();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:btnSave_Click Exception: "+ex.Message+"  User: "+ uid);     
			}
		}
 

		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void clear()
		{
			TxtLedger.Text = "";
			DropSub.SelectedIndex = 0;
			DropGroup.SelectedIndex = 0;
			TxtSub.Text = "";
			TxtGroup.Text = "";
			RadioAsset.Checked = true;
			TxtOpeningBal.Text = "";
			DropBalType.SelectedIndex = 0;
			//TxtFr.Text = "";
			//TxtTo1.Text = "";
			btnSave.Enabled = true;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnEdit1.Visible = true;
			TxtLedger.Visible = true; 
			dropLedgerName.Visible = false; 
			TxtLedger.Enabled=true;
			DropSub.Enabled=true;
			DropGroup.Enabled=true;
			RadioExp.Enabled=true;
			RadioIncome.Enabled=true;
			RadioLiab.Enabled=true;
         }


		/// <summary>
		/// To fill all ledger in the dropdownlist from the database.
		/// </summary>
		private void btnEdit1_Click(object sender, System.EventArgs e)
		{
			try
			{
				clear();
				dropLedgerName.Items.Clear();
				dropLedgerName.Items.Add("Select");
				dropLedgerName.SelectedIndex = 0;  
    
				btnSave.Enabled = false;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				checkPrevileges();
				btnEdit1.Visible = false;
				dropLedgerName.Visible = true; 	

				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("Select Ledger_name+':'+cast(Ledger_ID as varchar) from Ledger_Master order by Ledger_name",ref SqlDtr);
				while(SqlDtr.Read())
				{
					dropLedgerName.Items.Add(SqlDtr.GetValue(0).ToString());     
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:btnEdit1_Click Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		/// <summary>
		/// This method is used to retrieve all values from the database according to selected ledger name.
		/// </summary>
		private void dropLedgerName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(dropLedgerName.SelectedIndex == 0)
				{
					MessageBox.Show("Please select Ledger Name");
					fetchGroup();
					return;
				}
			
				string ledgname = dropLedgerName.SelectedItem.Text.ToString();   
				string[] strArr = ledgname.Split(new char[] {':'},ledgname.Length);
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("select ln.*,m.grp_name,lmsg.Sub_grp_Name,lmsg.Nature_of_group from Ledger_Master ln,mGroup m,Ledger_Master_Sub_Grp lmsg where Ledger_id = "+strArr[1].Trim()+" and Ledger_Name = '"+strArr[0].Trim()+"' and ln.sub_grp_id = lmsg.sub_grp_id and lmsg.grp_id = m.grp_id",ref SqlDtr);  
				if(SqlDtr.Read())
				{
					TxtLedger.Text = SqlDtr["Ledger_name"].ToString();
					DropSub.SelectedIndex = DropSub.Items.IndexOf(DropSub.Items.FindByText(SqlDtr["Sub_grp_Name"].ToString()));
					fetchGroup();
					DropGroup.SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(SqlDtr["grp_Name"].ToString()));
					txtTempGrp.Value = DropGroup.SelectedItem.Text;    
					string nature = SqlDtr["Nature_of_group"].ToString();
					if(nature.Equals("Assets"))
					{
						RadioAsset.Checked = false;
						RadioLiab.Checked = false;
						RadioExp.Checked = false;
						RadioIncome.Checked = false;
						RadioAsset.Checked = true;
					}
					else if(nature.Equals("Liabilities"))
					{
						RadioAsset.Checked = false;
						RadioLiab.Checked = false;
						RadioExp.Checked = false;
						RadioIncome.Checked = false;
						RadioLiab.Checked = true;
					}
					else if(nature.Equals("Expenses"))
					{
						RadioAsset.Checked = false;
						RadioLiab.Checked = false;
						RadioExp.Checked = false;
						RadioIncome.Checked = false;
						RadioExp.Checked = true;
					}
					else
					{
						RadioAsset.Checked = false;
						RadioLiab.Checked = false;
						RadioExp.Checked = false;
						RadioIncome.Checked = false;
						RadioIncome.Checked = true;
					}
					//***************
					dbobj.SelectQuery("select * from Organisation",ref SqlDtr);  
					if(SqlDtr.Read())
					{
						if((SqlDtr["FleetCard"].ToString().Equals(TxtLedger.Text) || SqlDtr["CreditCard"].ToString().Equals(TxtLedger.Text) || TxtLedger.Text.Equals("Cash")) && DropSub.SelectedItem.Text.Equals("Cash in hand"))
						{
							TxtLedger.Enabled=false;
							DropSub.Enabled=false;
							DropGroup.Enabled=false;
							RadioLiab.Enabled=false;
							RadioExp.Enabled=false;
							RadioIncome.Enabled=false;
						}
						else
						{
							TxtLedger.Enabled=true;
							DropSub.Enabled=true;
							DropGroup.Enabled=true;
							RadioLiab.Enabled=true;
							RadioExp.Enabled=true;
							RadioIncome.Enabled=true;
						}
					}
					//***************
					TxtOpeningBal.Text = SqlDtr["Op_Balance"].ToString();
					DropBalType.SelectedIndex = DropBalType.Items.IndexOf(DropBalType.Items.FindByText(SqlDtr["Bal_Type"].ToString())); 
					//TxtFr.Text = GenUtil.str2DDMMYYYY(trimDate(SqlDtr["Eff_From"].ToString()));  
					//TxtTo1.Text = GenUtil.str2DDMMYYYY(trimDate(SqlDtr["Eff_To"].ToString()));
				}
				SqlDtr.Read();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:dropLedgerName_SelectedIndexChanged Exception: "+ex.Message+"  User: "+ uid);     
			}         
		}

		/// <summary>
		/// this function seprate the time from the date and returns only date.
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
		/// This method is used to update the record according to select ledger from the dropdownlist.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			if(dropLedgerName.SelectedIndex == 0)
			{
				MessageBox.Show("Please select Ledger Name");
				fetchGroup();
				return;
			}
			try
			{           

				string SubGrp = "";
				string Group = "";
				// Check & Fetch The sub Group
				if(DropSub.SelectedIndex == 0)
				{
					MessageBox.Show("Please select Sub Group");
					fetchGroup();
					return;
				}
				else 
				{
					if(DropSub.SelectedItem.Text == "Other")
					{
						if(TxtSub.Text.Trim() == "")
						{
							MessageBox.Show("Please specify Other Sub Group");
							TxtSub.Enabled = true; 
							fetchGroup();
							return;
						}
						else
							SubGrp =TxtSub.Text.Trim(); 
					}
					else
					{
						SubGrp = DropSub.SelectedItem.Text.Trim(); 
					}
				}

				// Check & Fetch The  Group
				if(txtTempGrp.Value== "Select" )
				{
					MessageBox.Show("Please select Group");
					fetchGroup();
					return;
				}
				else 
				{
					if(txtTempGrp.Value == "Other")
					{
						if(TxtGroup.Text.Trim() == "")
						{
							MessageBox.Show("Please specify Other Group");
							TxtGroup.Enabled = true;
							fetchGroup();
							DropGroup.SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(txtTempGrp.Value));  
							return;
						}
						else
							Group =TxtGroup.Text.Trim(); 

					}
					else
					{
						//Group = DropGroup.SelectedItem.Text.Trim(); 
						Group = txtTempGrp.Value;

					}
				}
				/*string FromDate  = GenUtil.str2MMDDYYYY(TxtFr.Text);
				string ToDate = GenUtil.str2MMDDYYYY(TxtTo1.Text); 
				if(DateTime.Compare(System.Convert.ToDateTime(FromDate),System.Convert.ToDateTime(ToDate))>0)
				{
					MessageBox.Show("Date From Should be less than Date To");
					fetchGroup();
					DropGroup .SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(Group));  
					return;
				}*/
				string ledgname = "";
				string nature = "";
				double Op_bal = 0;
				string bal_type = "";
				ledgname = TxtLedger.Text.Trim();
				if(!TxtOpeningBal.Text.Equals(""))
					Op_bal = System.Convert.ToDouble(TxtOpeningBal.Text.ToString());
				bal_type = DropBalType.SelectedItem.Text.Trim();

				if(RadioAsset.Checked)
					nature = "Assets";
				else if(RadioLiab.Checked)
					nature = "Liabilities";
				else if(RadioExp.Checked)
					nature = "Expenses";
				else
					nature= "Income"; 
				string ledgname1 = "";
				ledgname1 = dropLedgerName.SelectedItem.Text.ToString();   
				string[] strArr = ledgname1.Split(new char[] {':'},ledgname1.Length);
			
				int subgrpid = 0;
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("select sub_grp_Id from Ledger_Master_Sub_grp  where sub_grp_name = '"+SubGrp+"' and Nature_Of_group ='"+nature+"' and grp_id = (select top 1 grp_id from mgroup where grp_name = '"+Group+"')",ref SqlDtr);
				if(SqlDtr.Read()) 
				{
					subgrpid = System.Convert.ToInt32(SqlDtr["sub_grp_id"].ToString());  
				}
				SqlDtr.Close();

				/*object[] obj1 = getParties();
				for(int k = 0; k < obj1.Length ; k++)
				{
					string str = obj1[k].ToString();
 
					if(obj1[k].ToString().Equals(ledgname))
					{
						MessageBox.Show("Ledger Name should be different than Customer/ Vendor Name");
						fetchGroup();
						DropGroup .SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(Group));  
						return;
					}
				}*/
				if(DropSub.SelectedItem.Text.Equals("Cash in hand") && TxtLedger.Enabled!=false)
				{
					MessageBox.Show("Cash Account AlReady Exists");
					//fetchGroup();
					//DropGroup .SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(Group));
					return;
				}
				int count = 0;
				dbobj.ExecuteScalar("Select count(Ledger_ID) from Ledger_Master where Ledger_Name = '"+ledgname +"' and Sub_grp_ID = "+subgrpid,ref count); 
				if(count > 0)
				{
					string id = "";
					dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name = '"+ledgname +"' and Sub_grp_ID = "+subgrpid,ref SqlDtr);
					if(SqlDtr.Read())
					{
						id = SqlDtr["Ledger_ID"].ToString();
					}
					SqlDtr.Close();
					if(!id.Equals(strArr[1]))
					{
						MessageBox.Show("Ledger Name is already exist for selected Sub Group ");
						fetchGroup();
						DropGroup .SelectedIndex = DropGroup.Items.IndexOf(DropGroup.Items.FindByText(Group));  
						return;
					}
				}
				
				string subgrpid1 = "";
				dbobj.SelectQuery("select sub_grp_Id from Ledger_Master where Ledger_id = "+strArr[1].Trim(),ref SqlDtr);
				while(SqlDtr.Read())
				{
					subgrpid1 =  SqlDtr["sub_grp_ID"].ToString();
					
				}
				SqlDtr.Close();
				object op = null;
				// Call Procedure to update the Ledger
				dbobj.ExecProc(OprType.Update,"ProUpdateLedger",ref op,"@Ledger_ID",strArr[1].Trim() ,"@Ledger_Name",ledgname,"@SubGrp_Name",SubGrp,"@Group_Name",Group,"@Grp_Nature",nature,"@Op_Bal",Op_bal,"@Bal_Type",bal_type);
				dbobj.ExecProc(OprType.Update,"UpdateAccountsLedger",ref op,"@Ledger_ID",strArr[1].Trim() ,"@Amount",Op_bal,"@Type",bal_type);
				// Procedure to update or delete the Unused newly created Group and Sub Groups.
				dbobj.ExecProc(OprType.Update,"ProUpdatesubgroup",ref op,"@subgrp_id",subgrpid1);
				
				MessageBox.Show("Ledger Updated");	
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:btnEdit_Click Ledger  ID "+strArr[1].Trim()+" of "+ledgname+" Updated.  User: "+ uid);     
				clear();
				checkPrevileges(); 
				getSubGroup();
				getGroup();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:btnEdit_Click Exception: "+ex.Message+"  User: "+ uid);     
			}
		}

		/// <summary>
		/// This method is used to delete the record from the database according to select Ledger on edit time.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(dropLedgerName.SelectedIndex == 0)
			{
				MessageBox.Show("Please select Ledger Name");
				fetchGroup();
				return;
			}
			try
			{
				string ledgname1 = "";
				ledgname1 = dropLedgerName.SelectedItem.Text.ToString();   
				string[] strArr = ledgname1.Split(new char[] {':'},ledgname1.Length);
				SqlDataReader SqlDtr = null;
				string id1 ="";
				string id2 = "";
				// Check  if the Voucher Transaction of the selected Ledger to delete is present or not.
				dbobj.SelectQuery("Select Ledg_ID_Cr, Ledg_ID_Dr from Voucher_Transaction where Ledg_ID_Cr = "+strArr[1].Trim()+" or Ledg_ID_Dr = "+strArr[1].Trim(),ref SqlDtr);
				while(SqlDtr.Read())
				{
					id1 = SqlDtr["Ledg_ID_Cr"].ToString();
					id2 = SqlDtr["Ledg_ID_Dr"].ToString();  
				}
				SqlDtr.Close();
				if(!id1.Trim().Equals("") || !id2.Trim().Equals(""))
				{
					MessageBox.Show("Unable to delete Ledger ");
					fetchGroup();
					return;
				}
				else
				{
					int c =0,Count=0;
					string subgrpid = "";
					dbobj.SelectQuery("select sub_grp_Id from Ledger_Master where Ledger_id = "+strArr[1].Trim(),ref SqlDtr);
					while(SqlDtr.Read())
					{
						subgrpid =  SqlDtr["sub_grp_ID"].ToString();
					
					}
					SqlDtr.Close();
					//*************** Add by Mahesh On 16.10.008, check if transaction is available than not delete the ledger and not then delete the ledger
					dbobj.ExecuteScalar("select count(*) from AccountsLedgerTable where Ledger_id = '"+strArr[1].Trim()+"' and particulars<>'Opening balance'",ref Count);
					if(Count>0)
					{
						MessageBox.Show("Please Remove The All Transaction Concerning Ledger");
						return;
					}
					//***************
					dbobj.Insert_or_Update("delete from Ledger_master where Ledger_Id = "+strArr[1].Trim(),ref c); 
					object op = null;
					dbobj.ExecProc(OprType.Update,"ProUpdatesubgroup",ref op,"@subgrp_id",subgrpid);
				}
				MessageBox.Show("Ledger Deleted");	
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:btnDelete_Click Ledger  ID "+strArr[1].Trim()+" Deleted.  User: "+ uid);     
				clear();
				checkPrevileges();
				getSubGroup();
				getGroup();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Ledger Creation,Method:btnDelete_Click Exception: "+ex.Message+"  User: "+ uid);     
			}
		}
	}
}
