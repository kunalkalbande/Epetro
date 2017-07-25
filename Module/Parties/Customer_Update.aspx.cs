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
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPetro.Sysitem.Classes ;
using RMG;
using DBOperations;

namespace EPetro.Module.Parties
{
	/// <summary>
	/// Summary description for Customer_Update_aspx.
	/// </summary>
	public class Customer_Update_aspx : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtPhoneRes;
		protected System.Web.UI.WebControls.TextBox txtPhoneOff;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.TextBox txtCRLimit;
		protected System.Web.UI.WebControls.DropDownList DropCrDay;
		protected System.Web.UI.WebControls.TextBox txtOpBalance;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList DropCustType;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.DropDownList DropBal;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label LblCustomerID;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox txtTinNo;
		protected System.Web.UI.WebControls.TextBox txtbeatname;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator7;
		protected System.Web.UI.WebControls.TextBox lblName;
		protected System.Web.UI.WebControls.TextBox TempCustName;
		string uid;

		/// <summary>
		/// Put user code to initialize the page here
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// and also fatch the customer information according to select customer ID in comes from url.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Update.aspx,Method:on_pageload,Class:PartiesClass.cs " + "EXCEPTION  "+ex.Message+"  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack)
			{
				try
				{
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
					if(Edit_Flag=="0")
					{
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					}
					#endregion
					getbeat();
					for(i=1;i<=30;i++)
					{
						DropCrDay.Items.Add(i.ToString ());
					}

					LblCustomerID.Text = Request.QueryString.Get("ID");
					PartiesClass obj=new PartiesClass();
					SqlDataReader SqlDtr;
					string sql;

					#region Fetch Extra Cities from Database and add to the ComboBox
					sql="select City from Beat_Master";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropCity.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
					sql="select distinct State from Beat_Master";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropState.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
					sql="select distinct Country from Beat_Master";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropCountry.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
					#endregion

					SqlDtr = obj.CustomerList(LblCustomerID.Text.ToString (),"",""  );
					while (SqlDtr.Read ())
					{
						lblName.Text =SqlDtr.GetValue(1).ToString ();
						TempCustName.Text=SqlDtr.GetValue(1).ToString ();
						DropCustType.SelectedIndex =DropCustType.Items.IndexOf(DropCustType.Items.FindByValue(SqlDtr.GetValue(2).ToString ()));
						txtAddress.Text =SqlDtr.GetValue(3).ToString ();
						DropCity.SelectedIndex =DropCity.Items.IndexOf(DropCity.Items.FindByValue(SqlDtr.GetValue(4).ToString ()));
						DropState.SelectedIndex =DropState.Items.IndexOf(DropState.Items.FindByValue(SqlDtr.GetValue(5).ToString ()));
						DropCountry.SelectedIndex =DropCountry.Items.IndexOf(DropCountry.Items.FindByValue(SqlDtr.GetValue(6).ToString ()));
						if(SqlDtr.GetValue(7).ToString().Equals("0"))
							txtPhoneRes.Text = "";
						else
							txtPhoneRes.Text =SqlDtr.GetValue(7).ToString ();

						if(SqlDtr.GetValue(8).ToString().Equals("0"))
							txtPhoneOff.Text = "";
						else
							txtPhoneOff.Text =SqlDtr.GetValue(8).ToString ();

						if(SqlDtr.GetValue(9).ToString().Equals("0"))
							txtMobile.Text = "";
						else
							txtMobile.Text =SqlDtr.GetValue(9).ToString ();

						txtEMail.Text =SqlDtr.GetValue(10).ToString ();
						txtCRLimit.Text =SqlDtr.GetValue(11).ToString ();
						DropCrDay.SelectedIndex=DropCrDay.Items.IndexOf(DropCrDay.Items.FindByValue(SqlDtr.GetValue(12).ToString ()));
						txtOpBalance.Text =SqlDtr.GetValue(13).ToString ();
						DropBal.SelectedIndex=DropBal.Items.IndexOf(DropBal.Items.FindByValue(SqlDtr.GetValue(14).ToString ()));
						txtTinNo.Text = SqlDtr.GetValue(15).ToString().Trim();   
					}
					SqlDtr.Close(); 
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Customer_Update.aspx,Method:on_pageload,Class:PartiesClass.cs " + "EXCEPTION  "+ex.Message+"  "+uid);
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
		/// This method is used to update the customer information according to selected customer in the dropdownlist.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			PartiesClass obj=new PartiesClass();
			SqlDataReader SqlDtr = null;
			try
			{
				if(!txtTinNo.Text.Trim().Equals(""))
				{
					string sql1 = "Select Tin_No,Cust_ID from customer where Tin_No = '"+txtTinNo.Text.Trim()+"'";
					SqlDtr= obj.GetRecordSet(sql1);
					if(SqlDtr.HasRows)
					{
						if(SqlDtr.Read())
						{
							if(!LblCustomerID.Text.Equals(SqlDtr["Cust_ID"].ToString() ) )
							{
								MessageBox.Show("The Tin No. "+txtTinNo.Text.Trim()+" Already Exist");
								return;
							}
						}
				
					}
					SqlDtr.Close();
				}
				obj.Cust_ID = LblCustomerID.Text;
				obj.TempCustName  =TempCustName.Text;
				obj.Cust_Name=StringUtil.OnlyFirstCharUpper(lblName.Text.ToString());
				obj.Cust_Type =DropCustType.SelectedItem.Value.ToString ();  
				obj.Address =txtAddress.Text.ToString();
				obj.City =DropCity.SelectedItem.Value.ToString ();
				obj.State=DropState.SelectedItem.Value.ToString ();
				obj.Country=DropCountry.SelectedItem.Value.ToString ();
				obj.EMail =txtEMail.Text.ToString ();
				if(txtPhoneRes.Text=="")
					obj.Tel_Res="0";
				else

					obj.Tel_Res =txtPhoneRes.Text ;
				if(txtPhoneOff.Text=="")

					obj.Tel_Off  ="0";
				else
					obj.Tel_Off  =txtPhoneOff.Text ;
				if(txtMobile.Text=="")
					obj.Mobile="0";
				else
					obj.Mobile =txtMobile.Text;
				if(txtCRLimit.Text=="")
					obj.CR_Limit="0";
				else
					obj.CR_Limit =txtCRLimit.Text;
				if(DropCrDay.SelectedIndex==0)
					obj.CR_Days="0";
				else
					obj.CR_Days=DropCrDay.SelectedItem.Value.ToString();
				if(txtOpBalance.Text=="")
					obj.Op_Balance="0";
				else
					obj.Op_Balance  =txtOpBalance.Text;
				obj.Balance_Type =DropBal.SelectedItem.Value.ToString();
				obj.Tin_No= txtTinNo.Text.Trim(); 
				// Calls method to update the customers details.
				obj.UpdateCustomer ();
				MessageBox.Show("Customer Updated");
				Clear();
				CreateLogFiles.ErrorLog("Form:Customer_Updates.aspx,Class:PartiesClass.cs: Method:btnUpdate_Click "+" Recored of  - Cust Name  "+ obj.Cust_Name    +" Cust id  "+obj.Cust_ID + "   IS   UPDATED "+"  User Type "+uid );
				Response.Redirect("Customer_List.aspx",false);

			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Updates.aspx,Class:PartiesClass.cs: Method:btnUpdate_Click "+" recored of  "+" Cust Name  "+ obj.Cust_Name    + " IS UPDATED "+" EXCEPTION   "+ex.Message+"  User Type "+uid );//Err.ErrorLog(Server.MapPath("Logs/ErrorLog"),"Form:Customer_Update.aspx,Method:btnUpdate_Click,Class:PartiesClass.cs " + ex.Message);
			}
		}	
	
		/// <summary>
		/// This method clears the form.
		/// </summary>
		public void Clear()
		{
			txtEMail.Text="";
			txtAddress.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry.SelectedIndex=0;
			DropCustType.SelectedIndex=0; 
			DropCrDay.SelectedIndex=0; 
			DropBal.SelectedIndex=0; 
			txtCRLimit.Text="";
			txtPhoneOff.Text="";
			txtPhoneRes.Text="";
			txtMobile.Text="";
			txtOpBalance.Text="";
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
				
					DropState.SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByText(SqlDtr.GetValue(0).ToString()))));
													
					DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry.Items.FindByValue(SqlDtr.GetValue(1).ToString()))));
				
				} 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Update.aspx,Class:Customer_Update.aspx.cs ,Method:DropCity_SelectedIndexChanged" + "EXCEPTION  "+ex.Message+uid);
			}*/
		}
	}
}