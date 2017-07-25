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

namespace EPetro.Module.Admin
{
	/// <summary>
	/// Summary description for Roles.
	/// </summary>
	public class Roles : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblRoleID;
		protected System.Web.UI.WebControls.TextBox txtRoleName;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.DropDownList dropRoleID;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
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
				uid=(Session["User_Name"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:Page_Load"+"  EXCEPTION  "+ex.Message+" userid   "+uid);
				Response.Redirect("ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				#region Check Privileges if the user is admin then grant the access
				if(Session["User_ID"].ToString ()!="1001")
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				#endregion
				GetNextRoleID();
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
			this.dropRoleID.SelectedIndexChanged += new System.EventHandler(this.dropRoleID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to Clears the form.
		/// </summary>
		public void Clear()
		{
			lblRoleID.Text="";
			txtRoleName.Text="";
			txtDesc.Text="";  
		}

		/// <summary>
		/// This method is used to Retrieve next role id from database.
		/// </summary>
		public void GetNextRoleID()
		{
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr;
			string sql;
			try
			{
				#region Fetch Next Role ID
				sql="select max(Role_ID)+1 from Roles";
				SqlDtr =obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					lblRoleID.Text=SqlDtr.GetSqlValue(0).ToString ();
					if (lblRoleID.Text=="Null")
						lblRoleID.Text ="1001";
				}		
				SqlDtr.Close();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:GetNextRoleID   EXCEPTION: "+ex.Message+" userid   "+uid);
			}
		}

		/// <summary>
		/// This method is used to update the record according to select role ID from dropdownlist in edit time.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			EmployeeClass obj=new EmployeeClass();
			obj.Role_Name=txtRoleName.Text.ToString();
			obj.Description =txtDesc.Text.ToString();
			try
			{
				if(dropRoleID.Visible)
				{
					obj.Role_ID=dropRoleID.SelectedItem.Value;
					obj.UpdateRoles();
					CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:btnUpdateClick   Role  name "+obj.Role_Name +" Updated   "+uid);
					MessageBox.Show("Role Updated");
				}
				else
				{
					#region Check Role Already Created or Not
					int count=0;
					DBOperations.DBUtil  dbobj=new DBOperations.DBUtil();
					dbobj.ExecuteScalar("select count(*) from Roles where Role_Name='"+ txtRoleName.Text.Trim() +"'",ref count);
					if(count>0)
					{
						MessageBox.Show("Role already Exists");
						return;
					}
					#endregion

					obj.Role_ID = lblRoleID.Text.ToString();
					obj.InsertRoles();	
					CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:btnUpdate_Click   Role Name "+obj.Role_Name +" Created   "+uid);
					MessageBox.Show("Role Created");
				}
				Clear();
				GetNextRoleID();
				lblRoleID.Visible=true;
				dropRoleID.Visible=false;
				btnEdit.Visible=true;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:btnUpdate_Click   EXCEPTION: "+ex.Message+" userid   "+uid);
			}
		}

		/// <summary>
		/// This method is used to Fatch all role id in combobox. 
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			lblRoleID.Visible=false;
			btnEdit.Visible=false;
			dropRoleID.Visible=true;
			try
			{
				#region	Fetch All Role ID
				dropRoleID.Items.Clear();
				dropRoleID.Items.Add("Select");
				DBOperations.DBUtil obj=new DBOperations.DBUtil();
				SqlDataReader SqlDtr=null;
				obj.SelectQuery("select Role_ID from Roles",ref SqlDtr);
				while(SqlDtr.Read())
				{
					dropRoleID.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:btnEdit_Click   EXCEPTION: "+ex.Message+" userid   "+uid);
			}
		}

		/// <summary>
		/// This method is used to retrieve the all values from the database according to selected value in the dropdownlist.
		/// </summary>
		private void dropRoleID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				Clear();
				DBOperations.DBUtil obj=new DBOperations.DBUtil();
				SqlDataReader SqlDtr=null;

				obj.SelectQuery("select * from roles where Role_Id='"+ dropRoleID.SelectedItem.Value +"'",ref SqlDtr);
				while(SqlDtr.Read())
				{
					txtRoleName.Text=SqlDtr.GetValue(1).ToString();
					txtDesc.Text=SqlDtr.GetValue(2).ToString();
				}
				SqlDtr.Close();
				CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:dropRoleID_SelectedIndexChanged    "+"  userid "+uid);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Please select Role ID");
				CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:dropRoleID_SelectedIndexChanged"+ ex.Message+"  EXCEPTION  "+uid);
			}
		}

		/// <summary>
		/// This method is esed to delete the record according to selected value from the dropdownlist.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				CreateLogFiles.ErrorLog("Form:Roles.aspx,Method: btnDelete_Click"+ uid);
			
				if(dropRoleID.SelectedIndex==0)
				{
					RMG.MessageBox.Show("Please select the Role ID");
					return;
				}
				int output=0;
				DBOperations.DBUtil obj=new DBOperations.DBUtil();
				obj.ExecuteScalar("select count(*) from User_master where Role_ID='" + dropRoleID.SelectedItem.Value + "'",ref output);
				if(output>0) 
				{
					MessageBox.Show("Selected Role cannot be Deleted");
					return;
				}
				else
				{
					obj.Insert_or_Update("delete from roles where Role_Id='"+ dropRoleID.SelectedItem.Value +"'",ref output);
					dropRoleID.Items.Remove(dropRoleID.SelectedItem.Value); 
					MessageBox.Show("Role Deleted");
					dropRoleID.Visible=false;
					lblRoleID.Visible=true;
					Clear();
					GetNextRoleID();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Please select Role ID");
				CreateLogFiles.ErrorLog("Form:Roles.aspx,Method:btnDelete_Click"+ ex.Message+"  EXCEPTION  "+uid);
			}
		}
	}
}