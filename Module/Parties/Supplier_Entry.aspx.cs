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
	/// Summary description for Supplier_Entry.
	/// </summary>
	public class Supplier_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFName;
		protected System.Web.UI.WebControls.TextBox txtMName;
		protected System.Web.UI.WebControls.TextBox txtLName;
		protected System.Web.UI.WebControls.DropDownList DropType;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.TextBox txtOpBalance;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label lblSupplierID;
		protected System.Web.UI.WebControls.DropDownList DropBal;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.DropDownList DropCrDay;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.TextBox txtPhoneOff;
		protected System.Web.UI.WebControls.TextBox txtPhoneRes;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox txtTinNo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox txtbeatname;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
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
				CreateLogFiles.ErrorLog("Form:Supplier_Entry.aspx,Method:page_load"+"  EXCEPTION  "+ ex.Message+uid);
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
					if(Add_Flag=="0")
					{
						//	string msg="UnAthourized Visit to Vendor Entry Page";
						//	dbobj.LogActivity(msg,Session["User_Name"].ToString());  
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					}
					#endregion

					// Fills the Credit Limit combo with 30 Numbers.
					//					for(i=1;i<=30;i++)
					//					{
					//						DropCrDay.Items.Add(i.ToString ());
					//					}

					PartiesClass obj=new PartiesClass();
					SqlDataReader SqlDtr;
					string sql;

					GetNextSupplierID();
				
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
					CreateLogFiles.ErrorLog("Form:Supplier_Entry.aspx,Method:page_load"+"  EXCEPTION  "+ ex.Message+uid);
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
				txtbeatname.Text=str;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:getBeat()" + "EXCEPTION  "+ex.Message+uid);
			}
		}

		/// <summary>
		/// To insert all values in the database with the help of stored procedures.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			PartiesClass obj=new PartiesClass();
			try
			{
                StringBuilder erroMessage = new StringBuilder();                

                if (txtFName.Text == string.Empty)
                {
                    erroMessage.Append("- Please Enter Name");
                    erroMessage.Append("\n");
                }

                if (DropType.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select the Type");
                    erroMessage.Append("\n");
                }

                if (DropCity.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select the City");
                    erroMessage.Append("\n");
                }

                if (txtTinNo.Text == string.Empty)
                {
                    erroMessage.Append("- Please Enter the Tin No");
                    erroMessage.Append("\n");
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
				string sname=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim())) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim() ))+" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim() )); 				SqlDataReader SqlDtr;
				string sql1="select Supp_ID from supplier where Supp_Name='"+sname+"'";
				SqlDtr=obj.GetRecordSet(sql1);
				if(SqlDtr.HasRows)
				{
					MessageBox.Show("Vendor Name  "+sname+" Already Exist");
					return;
				}
				SqlDtr.Close();
				sql1 = "Select Tin_No from supplier where Tin_No = '"+txtTinNo.Text.Trim()+"'";
				SqlDtr= obj.GetRecordSet(sql1);
				if(SqlDtr.HasRows)
				{
					MessageBox.Show("The Tin No. "+txtTinNo.Text.Trim()+" Already Exist");
					return;
				}
				SqlDtr.Close();
				obj.Supp_ID=lblSupplierID.Text;
				if(txtMName.Text!="" && txtLName.Text!="")
					obj.Supp_Name=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim() )) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim())+" "+ (txtLName.Text.ToString().Trim()));
				else if(txtMName.Text=="" &&  txtLName.Text!="" )
					obj.Supp_Name=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim())) +" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim()));
				else if(txtMName.Text!="" &&  txtLName.Text=="")
					obj.Supp_Name=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim())) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim()));
				else if (txtLName.Text=="" &&  txtMName.Text=="")
					obj.Supp_Name=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim()));
				obj.Supp_Type=DropType.SelectedItem.Value.ToString(); 
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
				if(txtOpBalance.Text=="")
					obj.Op_Balance="0";
				else
					obj.Op_Balance=txtOpBalance.Text;
				obj.Balance_Type =DropBal.SelectedItem.Value.ToString();
				if(DropCrDay.SelectedIndex==0)
					obj.CR_Days="0";
				else
					obj.CR_Days=DropCrDay.SelectedItem.Value.ToString();
				obj.Tin_No = txtTinNo.Text.Trim(); 
				// call the function to insert the supplier details.
				obj.InsertSupplier();
				MessageBox.Show("Vendor Saved");
				Clear();
				GetNextSupplierID();
				CreateLogFiles.ErrorLog("Form:Vender_Entry.aspx, Method:btnUpdate_Click "+"   Supplier_ID "+	obj.Supp_ID  +"   Supplier Type   "+obj.Supp_Type+" supplier City "+obj.City+"  IS SAVED  " +"  user  "+uid );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Vender_Entry.aspx, Method:btnUpdate_Click ().  EXCEPTION:  "+ ex.Message+"  user  "+uid );
			}
		}
	
		/// <summary>
		/// This method is used to Clears the form.
		/// </summary>
		public void Clear()
		{
			lblSupplierID.Text="";
			txtFName.Text="";
			txtMName.Text="";
			txtLName.Text="";
			txtEMail.Text="";
			txtAddress.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry.SelectedIndex=0;
			DropType.SelectedIndex=0; 
			DropBal.SelectedIndex=0; 
			DropCrDay.SelectedIndex=0; 
			txtPhoneOff.Text="";
			txtPhoneRes.Text="";
			txtMobile.Text="";
			txtOpBalance.Text="";
			txtTinNo.Text = "";
		}

		/// <summary>
		/// This method is used to Returns the Next Supplier ID from table Supplier.
		/// </summary>
		public void GetNextSupplierID()
		{
			PartiesClass obj=new PartiesClass();
			SqlDataReader SqlDtr;
				
			#region Fetch Next Vendor ID
			SqlDtr =obj.GetNextSupplierID();
			while(SqlDtr.Read())
			{
				lblSupplierID.Text =SqlDtr.GetSqlValue(0) .ToString ();
				if (lblSupplierID.Text =="Null")
					lblSupplierID.Text ="1001";
			}	
			SqlDtr.Close();
			#endregion
		}

		/// <summary>
		/// Select the state and country according to the selected City.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
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
				CreateLogFiles.ErrorLog("Form:Supplier_Entry.aspx,Method:DropCity_SelectedIndexChanged().  EXCEPTION: "+ ex.Message+" User_ID: "+uid);
			}*/
		}
	}
}