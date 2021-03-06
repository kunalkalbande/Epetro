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
using DBOperations;
using RMG;
using System.Text;

namespace EPetro.Module.Parties
{
	/// <summary>
	/// Summary description for Customer_Entry.
	/// </summary>
	public class Customer_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFName;
		protected System.Web.UI.WebControls.TextBox txtMName;
		protected System.Web.UI.WebControls.TextBox txtLName;
		protected System.Web.UI.WebControls.DropDownList DropType;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.TextBox txtCRLimit;
		protected System.Web.UI.WebControls.TextBox txtOpBalance;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList DropCrDay;
		protected System.Web.UI.WebControls.Label LblCustomerID;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.TextBox txtPhoneOff;
		protected System.Web.UI.WebControls.TextBox txtPhoneRes;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.DropDownList DropBal;
		protected System.Web.UI.WebControls.TextBox txtTinNo;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtbeatname;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator7;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Entry.aspx,Class:PartiesClass.cs ,Method:onpageload" + ex.Message+" EXCEPTION  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				try
				{
					getbeat();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="3";
					string SubModule="2";
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
					if(Add_Flag=="0")
					{
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					}
					#endregion

					//					for(i=1;i<=30;i++)
					//					{
					//						DropCrDay.Items.Add(i.ToString ());
					//					}

					PartiesClass obj=new PartiesClass();
					SqlDataReader SqlDtr;
					string sql;
					GetNextCustomerID();

			
					#region Fetch Extra Cities from Database and add to the ComboBox
					sql="select distinct City from Beat_Master order by City asc";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropCity.Items.Add(SqlDtr.GetValue(0).ToString()); 
				
					}
					SqlDtr.Close();
					#endregion

					#region Fetch Extra Cities from Database and add to the ComboBox
					sql="select distinct state from Beat_Master order by state asc";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
				
						DropState.Items.Add(SqlDtr.GetValue(0).ToString()); 
				
					}
					SqlDtr.Close();
					#endregion

					#region Fetch Extra Cities from Database and add to the ComboBox
					sql="select distinct country from Beat_Master order by country asc";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
				
						DropCountry.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Customer_Entry.aspx,Class:PartiesClass.cs ,Method:onpageload" + ex.Message+" EXCEPTION  "+uid);
				}
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
			this.DropCity.SelectedIndexChanged += new System.EventHandler(this.DropCity_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
			dd=Int32.Parse(strarr[1]);
			mm=Int32.Parse(strarr[0]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);
			return(dt);
		}

		/// <summary>
		/// Its checks the before save that the account period is inserted in organisaton table or not.
		/// </summary>
		public bool checkAcc_Period()
		{
			int c = 0;
			try
			{
				SqlDataReader SqlDtr = null;
				
				dbobj.SelectQuery("Select count(Acc_Date_From) from Organisation",ref SqlDtr);
				if(SqlDtr.Read())
				{
					c = System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());  
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Entry.aspx,Class:PartiesClass.cs ,Method:checkAcc_Period(). EXCEPTION : " + ex.Message+"  User_ID: "+uid);
			}

			if(c > 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// This method is used to insert all values in the database with the help of stored procedures.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			PartiesClass obj=new PartiesClass();
			try
			{
                StringBuilder erroMessage = new StringBuilder();

                if (txtFName.Text == string.Empty)
                {
                    erroMessage.Append("- Please Fill Customer Name");
                    erroMessage.Append("\n");
                }

                if (DropType.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select Customer Type");
                    erroMessage.Append("\n");
                    //MessageBox.Show("Please select the Dealership");
                    //   return;
                }

                if (DropCity.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select City");
                    erroMessage.Append("\n");
                    //MessageBox.Show("Please select the Dealership");
                    //   return;
                }
                if (txtTinNo.Text != string.Empty)
                {
                    if (txtTinNo.Text.Length != 11)
                    {
                        erroMessage.Append("- Invalid Tin No");
                        erroMessage.Append("\n");
                    }
                }
                if (txtMobile.Text != string.Empty)
                {
                    if (txtMobile.Text.Length < 10)
                    {
                        erroMessage.Append("- Mobile No. Between 10 to 12 Digits");
                        erroMessage.Append("\n");
                    }
                }
                if (txtPhoneOff.Text != string.Empty)
                {
                    if (txtPhoneOff.Text.Length < 6)
                    {
                        erroMessage.Append("- Contact No. Between 6-12 Digits");
                        erroMessage.Append("\n");
                    }
                }
                if (txtPhoneRes.Text != string.Empty)
                {
                    if (txtPhoneRes.Text.Length < 6)
                    {
                        erroMessage.Append("- Contact No. Between 6-12 Digits");
                        erroMessage.Append("\n");
                    }
                }

                if (txtEMail.Text != string.Empty)
                {
                    string sPattern = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                    if (!System.Text.RegularExpressions.Regex.IsMatch(txtEMail.Text, sPattern))
                    {
                        erroMessage.Append("- Please Fill Valid E-mail");
                        erroMessage.Append("\n");
                    }
                }

                if (erroMessage.Length > 0)
                {
                    MessageBox.Show(erroMessage.ToString());
                    return;
                }

                if (!checkAcc_Period())
				{
					MessageBox.Show("Please enter the Accounts Period from Organization Details");
					return;
				}
				
				string cname=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim())) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim() ))+" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim() )); 
			
				SqlDataReader SqlDtr;
				// check the customer name is already exist or not.
				string sql1="select Cust_ID from customer where Cust_Name='"+cname+"'";
			
				SqlDtr=obj.GetRecordSet(sql1);
				
				if(SqlDtr.HasRows)
				{
					MessageBox.Show("Customer Name  "+cname+" Already Exist");
					return;
				}
				SqlDtr.Close();
				if(!txtTinNo.Text.Trim().Equals(""))
				{
					sql1 = "Select Tin_No from customer where Tin_No = '"+txtTinNo.Text.Trim()+"'";
					SqlDtr= obj.GetRecordSet(sql1);
					if(SqlDtr.HasRows)
					{
						MessageBox.Show("The Tin No. "+txtTinNo.Text.Trim()+" Already Exist");
						return;
				
					}
					SqlDtr.Close();
				}
				obj.Cust_ID=LblCustomerID.Text;
				if(txtMName.Text.ToString().Trim()!="" && txtLName.Text.ToString().Trim()!="")
					obj.Cust_Name =StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim())) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim()))+" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim())).Trim(); 
				else if(txtMName.Text.ToString().Trim()=="" && txtLName.Text.ToString().Trim()!="")
					obj.Cust_Name =StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim()))+" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim())).Trim(); 
				else
					obj.Cust_Name =StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim()));
				obj.Cust_Type=DropType.SelectedItem.Value.ToString(); 
				obj.Address=txtAddress.Text.Trim();
				obj.City=DropCity.SelectedItem.Value.ToString();
				obj.State=DropState.SelectedItem.Value.ToString();
				obj.Country=DropCountry.SelectedItem.Value.ToString(); 

				if(txtPhoneOff.Text=="")
					obj.Tel_Off="0";
				else
					obj.Tel_Off =txtPhoneOff.Text;
				if(txtPhoneRes.Text=="")
					obj.Tel_Res="0";
				else
					obj.Tel_Res =txtPhoneRes.Text;
				if(txtMobile.Text=="")
					obj.Mobile="0";
				else
					obj.Mobile =txtMobile.Text;
				obj.EMail =txtEMail.Text.Trim();
				obj.CR_Limit=txtCRLimit.Text ;
				if(DropCrDay.SelectedIndex==0)
					obj.CR_Days="0";
				else
					obj.CR_Days=DropCrDay.SelectedItem.Value.ToString();
				if(txtOpBalance.Text=="")
					obj.Op_Balance="0";
				else
					obj.Op_Balance=txtOpBalance.Text;
				obj.Balance_Type =DropBal.SelectedItem.Value.ToString();
				obj.EntryDate=GenUtil.str2DDMMYYYY(DateTime.Now.Date.ToShortDateString());
				obj.Tin_No = txtTinNo.Text.Trim(); 
				// Call to this method Inserts the customer details into the customer table.
				obj.InsertCustomer();
				MessageBox.Show("Customer Saved");
				CreateLogFiles.ErrorLog("Form:Customer_Entry.aspx,Class:PartiesClass.cs: Method:btnUpdate_Click "+" Cust Name  "+ obj.Cust_Name    +" Cust id  "+obj.Cust_ID +"Cust Type    "+ obj.Cust_Type  +"  Cust Address  "+ obj.Address   +" Cust City "+obj.City  +" Cust State  "+ obj.State   +" Cust Cuntry "+ GenUtil.str2DDMMYYYY(DateTime.Now.Date.ToShortDateString()) + "obj.Country" +" Opening Balance  "+  obj.Op_Balance  +"  date  "+obj.EntryDate +"    IS  SAVED    User  "+uid );
				Clear();
				GetNextCustomerID();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Entry.aspx,Class:PartiesClass.cs: Method:btnUpdate_Click "+" Cust Name  "+  obj.Cust_Name   +" Cust id  "+  obj.Cust_ID+"Cust Type    "+ obj.Cust_Type  +"  Cust Address  "+ obj.Address    +" Cust City "+ obj.City +" Cust State  "+ obj.State     +" Cust Cuntry "+ obj.Country +" Opening Balance  "+     obj.Op_Balance   +"  EXCEPTION "+ ex.Message  + "  User Type "+uid);
			}
		}

		/// <summary>
		/// This Method is used to clear the form.
		/// </summary>
		public void Clear()
		{
			LblCustomerID.Text="";
			txtFName.Text="";
			txtMName.Text="";
			txtLName.Text="";
			txtEMail.Text="";
			txtOpBalance.Text="";
			txtAddress.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry.SelectedIndex=0;
			DropType.SelectedIndex=0; 
			DropCrDay.SelectedIndex=0; 
			DropBal.SelectedIndex=0; 
			txtCRLimit.Text="";
			txtPhoneOff.Text="";
			txtPhoneRes.Text="";
			txtMobile.Text="";
			txtTinNo.Text = "";
		
		}

		/// <summary>
		/// This method is used to Returns the next Customer ID. from customer table.
		/// </summary>
		public void GetNextCustomerID()
		{
			try
			{
				PartiesClass obj=new PartiesClass();
				SqlDataReader SqlDtr;

				#region Fetch Next Customer ID
				SqlDtr =obj.GetNextCustomerID();
				while(SqlDtr.Read())
				{
					LblCustomerID.Text =SqlDtr.GetSqlValue(0).ToString ();
					if (LblCustomerID.Text=="Null")
						LblCustomerID.Text ="1001";
				}	
				SqlDtr.Close();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Entry.aspx,Class:PartiesClass.cs: Method:GetNextCustomerID().  EXCEPTION "+ ex.Message  + "  User  "+uid);
			}
		}

		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Select the state and country according to the selected city.
			/*
			try
			{
				
				InventoryClass  obj=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;
				sql="select State,Country from Beat_Master where City='"+ DropCity.SelectedItem.Value +"'" ;
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
				
					DropState.SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(SqlDtr.GetValue(0).ToString()))));
					DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry.Items.FindByValue(SqlDtr.GetValue(1).ToString()))));
				
				} 
        
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Entry.aspx,Class:PartiesClass.cs ,Method:DropCity_SelectedIndexChanged" + "EXCEPTION  "+ex.Message+uid);
				
			}*/
		}

		/// <summary>
		/// Name : Mahesh, Date : 30/11/06
		/// Select the state and country according to the selected city.
		/// </summary>
		public void getbeat()
		{
			try
			{
				InventoryClass  obj=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;
				string str="";
				sql="select City,State,Country from Beat_Master";
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					str=str+SqlDtr.GetValue(0).ToString()+":";
					str=str+SqlDtr.GetValue(1).ToString()+":";
					str=str+SqlDtr.GetValue(2).ToString()+"#";
				} 
				txtbeatname.Value=str;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Entry.aspx,Class:InventoryClass.cs ,Method:getBeat()" + "EXCEPTION  "+ex.Message+uid);
			}
		}
	}
}