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
using System.Drawing.Design;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using RMG;


namespace EPetro.Module.Master
{
	/// <summary>
	/// Created by	: Anand Mittal
	/// Created on	:
	///	Description	: This form is used for record the Employee Shifts at Any Petrol Pump.
	///				By Click on the Add Button Next Shift ID Generated and the all the controls will
	///				Clear. After Clicking the Save button the Data Will Save to the Shift Table.
	/// Tables Used	:
	///				1. Shift
	///	stored procedures :	
	///				1. ProInsertShift - This Stored Procedures Accepts 5 input type Paramenters 
	///				   and fire the insert command to save the record in the Shift Table.
	///				2. ProUpdateShift - This Stored Procedures Accepts 5 input type Paramenters 
	///				   and fire the Update command to Update the record in the Shift Table.
	///				3. proDeleteShift - This Stored Procedures Accepts Shift ID as input type Paramenters 
	///				   and fire the Delete command to Delete the record in the Shift Table.   
	/// </summary>
	public class Shift_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblShiftID;
		protected System.Web.UI.WebControls.DropDownList DropHour1;
		protected System.Web.UI.WebControls.DropDownList DropMinute1;
		protected System.Web.UI.WebControls.DropDownList DropHour2;
		protected System.Web.UI.WebControls.DropDownList DropMinute2;
		protected System.Web.UI.WebControls.TextBox TxtRemark;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox txtShiftName;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator4;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DropDownList DropShiftID;
		protected System.Web.UI.WebControls.Button Edit1;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox TextBox;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		string uid;
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				Edit1.Visible=false; 
			}
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:pageeload"+"  EXCEPTION  "+ex.Message+"  user  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				checkPrevileges();
				GetNextEmpID();
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
			string Module="2";
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
			if(Add_Flag=="0" && Edit_Flag=="0" && Del_Flag=="0")
			{
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}
			if(Add_Flag=="0")
				btnUpdate.Enabled=false;
			if(Edit_Flag=="0")
				btnEdit.Enabled=false;
			if(Del_Flag=="0")
				btnDelete.Enabled=false;
			#endregion
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
			this.DropShiftID.SelectedIndexChanged += new System.EventHandler(this.DropShiftID_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.Edit1.Click += new System.EventHandler(this.Edit1_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.ID = "Shift_Entry";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// To insert the values from the database with the help of stored procedures. 
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			MasterClass obj=new MasterClass();
			try
			{
				EmployeeClass obj1=new EmployeeClass();
				SqlDataReader SqlDtr;
				string sql1="select shift_ID from shift where Shift_Name='"+txtShiftName.Text.ToString()+"'";
				SqlDtr=obj1.GetRecordSet(sql1);
				if(SqlDtr.HasRows)
				{
					MessageBox.Show("Shift "+txtShiftName.Text.ToString()+" Already Exist");
					return;
				}
				SqlDtr.Close();
				obj.Shift_Name=txtShiftName.Text.ToString(); 
				obj.Time_From=DropHour1.SelectedItem.Value.ToString()+":"+ DropMinute1.SelectedItem.Value.ToString(); 
				obj.Time_To=DropHour2.SelectedItem.Value.ToString()+":"+ DropMinute2 .SelectedItem.Value.ToString();
				obj.Remark =StringUtil.FirstCharUpper(TxtRemark.Text.ToString());
				obj.Shift_ID =lblShiftID.Text.ToString ();
				obj.InsertShift();
				lblShiftID.Visible=true;
				DropShiftID.Visible=false;
				Clear();
				checkPrevileges();
				MessageBox.Show("Shift Saved");
				CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:btnUpdate_Click"+"Shift Id "+ obj.Shift_ID +" Shift Name  "+obj.Shift_Name    +"  Shift Time From " +  	obj.Time_From+"  Upto time "+ 	obj.Time_To + "  userid  "+uid);
				GetNextEmpID();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:btnUpdate_Click"+"Shift Id "+ obj.Shift_ID +" Shift Name  "+obj.Shift_Name    +"  Shift Time From " +  	obj.Time_From+"  Upto time "+ 	obj.Time_To + "  EXCEPTION  "+ex.Message+ "  userid  "+uid);
			}
		}

		/// <summary>
		/// Insert the values in the database after assigning the shift.
		/// </summary>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				lblShiftID.Visible=true;
				DropShiftID.Visible=false;
				btnEdit.Enabled=false; 
				btnUpdate.Enabled=true; 
				btnDelete.Enabled=false;
				CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:btnAdd_Click"+" EXCEPTION  "+uid);
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ProductWiseSales.aspx,Method:btnAdd_Click"+ ex.Message+"EXCEPTION" +uid);
			}
		}

		/// <summary>
		/// Returns Next Shift from shift table. Initially starts with 1001.
		/// </summary>
		public void GetNextEmpID()
		{
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr;
			SqlDtr =obj.GetNextShiftID();
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					lblShiftID.Text=SqlDtr.GetValue(0).ToString ();
					if (lblShiftID.Text.ToString().Trim().Equals(""))
						lblShiftID.Text="1001"; 
				}		
			}
			else
				lblShiftID.Text = "1001";
			SqlDtr.Close();
		}
	
		/// <summary>
		/// This function to retrieve max shift id from the database. Initially starts with 1001.
		/// </summary>
		public void FillID()
		{
			MasterClass obj=new MasterClass();
			SqlDataReader SqlDTRed;
			SqlDTRed=obj.GetNextShiftID();
			while(SqlDTRed.Read())
			{
				lblShiftID.Text=SqlDTRed.GetValue(0).ToString ();
				if (lblShiftID.Text=="")
					lblShiftID.Text="1001"; 
			}
		}

		/// <summary>
		/// To fill all shift id and shift name from the database in the dropdownlist.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				btnEdit.Visible=false;
				Edit1.Visible=true;
				btnDelete.Enabled = true;
				Edit1.Enabled = true; 
				lblShiftID.Visible=false;
				DropShiftID.Visible=true;
				Clear(); 
				EmployeeClass obj=new EmployeeClass();
				SqlDataReader SqlDtr;
				string sql;
				sql="select Shift_ID,Shift_Name from Shift";
				SqlDtr=obj.GetRecordSet(sql);
				DropShiftID.Items.Clear();
				DropShiftID.Items.Add("Select");
				while(SqlDtr.Read())
				{
					DropShiftID.Items.Add(SqlDtr.GetValue(0).ToString()+':'+SqlDtr.GetValue(1).ToString()); 
				}
				CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:btnEdit_Click"+uid);
				SqlDtr.Close();
				GetNextEmpID();
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:btnEdit_Click"+ "EXCEPTION"+ex.Message+uid);
			}
		}

		/// <summary>
		/// To delete the record from the database according to selected shift in the dropdownlist.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				btnEdit.Visible=true;
				Edit1.Visible=false;
				if(DropShiftID.SelectedIndex==0)
				{
					MessageBox.Show("Please select the Shift ID to Delete");
				}
				else
				{
					MasterClass obj=new MasterClass ();
					string sub=DropShiftID.SelectedItem.Value;
					string[] subShift=sub.Split(new char[] {':'},sub.Length);
					//obj.Shift_ID=DropShiftID.SelectedItem.Value;
					if(subShift.Length>=2)
						obj.Shift_ID=subShift[0];
					else
						obj.Shift_ID=DropShiftID.SelectedItem.Text;
					obj.DeleteShift();
					MessageBox.Show("Shift Deleted");
					GetNextEmpID();
					Clear();
					lblShiftID.Visible=true;
					DropShiftID.Visible=false;
					checkPrevileges();
					CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:btnDelete_Click"+"  shift id   "+ obj.Shift_ID+"   is DELETED    "+" userid " +uid);
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:btnDelete_Click"+ ex.Message+"EXCEPTION "+uid);
			}
		}
		
		/// <summary>
		/// To retrieve the all values from the database according to selected shift from the dropdownlist.
		/// </summary>
		private void DropShiftID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				EmployeeClass obj=new EmployeeClass();
				SqlDataReader SqlDtr;
				string sql;
				//**********
				string shift=DropShiftID.SelectedItem.Value;
				string[] shift_id=shift.Split(new char[] {':'},shift.Length);
				//**********
				sql="select shift_Name,Remark, datepart(hour,Time_From),"+
					"datepart(minute, Time_From),"+
					"datepart(hour,Time_To),"+
					"datepart(minute, Time_To)"+
					//**"from shift where Shift_ID='"+ DropShiftID.SelectedItem.Value+ "'";
					"from shift where Shift_ID='"+ shift_id[0] + "'";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					txtShiftName.Text=SqlDtr.GetValue(0).ToString(); 
					TxtRemark.Text=SqlDtr.GetValue(1).ToString();
					DropHour1.SelectedIndex=DropHour1.Items.IndexOf(DropHour1.Items.FindByValue(SqlDtr.GetValue(2).ToString()));   
					DropMinute1.SelectedIndex=DropMinute1.Items.IndexOf(DropMinute1.Items.FindByValue(SqlDtr.GetValue(3).ToString()));   
					DropHour2.SelectedIndex=DropHour2.Items.IndexOf(DropHour2.Items.FindByValue(SqlDtr.GetValue(4).ToString()));   
					DropMinute2.SelectedIndex=DropMinute2.Items.IndexOf(DropMinute2.Items.FindByValue(SqlDtr.GetValue(5).ToString()));   
					CreateLogFiles.ErrorLog("Form:ShiftEntry.aspx,Method:DropShiftID_SelectedIndexChanged"+" Shift Name  Updated to"+txtShiftName.Text +" userid " +uid);
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ShiftEntry.aspx,Method:DropShiftID_SelectedIndexChanged"+" Shift Name  is Updated to "+txtShiftName.Text +"   EXCEPTION  "+ex.Message+"  userid    " +uid );
			}
		}
		
		/// <summary>
		/// This funmction to clear the form.
		/// </summary>
		public void Clear()
		{
			DropShiftID.SelectedIndex=0;
			txtShiftName.Text=""; 
			DropHour1.SelectedIndex=0;
			DropHour2.SelectedIndex=0;
			DropMinute1.SelectedIndex=0;
			DropMinute2.SelectedIndex=0; 
			TxtRemark.Text=""; 
		}

		/// <summary>
		/// To update the shift entry according to the selected employee from the dropdownlist.
		/// </summary>
		private void Edit1_Click(object sender, System.EventArgs e)
		{
			try
			{
				btnEdit.Visible=true;
				Edit1.Visible=false;
				if(DropShiftID.Visible==true)
				{
					MasterClass obj=new MasterClass();
					obj.Shift_Name=txtShiftName.Text.ToString(); 
					obj.Time_From=DropHour1.SelectedItem.Value.ToString()+":"+ DropMinute1.SelectedItem.Value.ToString(); 
					obj.Time_To=DropHour2.SelectedItem.Value.ToString()+":"+ DropMinute2 .SelectedItem.Value.ToString();
					obj.Remark =TxtRemark.Text.ToString();
					//**********
					string shift=DropShiftID.SelectedItem.Value;
					string[] shift_id=shift.Split(new char[] {':'},shift.Length);
					//**********
					//obj.Shift_ID =DropShiftID.SelectedItem.Value;
					obj.Shift_ID =shift_id[0];
					obj.UpdateShift();
					GetNextEmpID();
					Clear();
					lblShiftID.Visible=true;
					DropShiftID.Visible=false;
					checkPrevileges();
					CreateLogFiles.ErrorLog("Form:Shift_Entry.aspx,Method:Edit1_Click"+"  Shift id  "+obj.Shift_ID+"  is UPDATED  "+"   userid  "+uid);
					MessageBox.Show("Shift Updated");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Shift_Etry.aspx,Method:Edit1_Click"+ ex.Message+"EXCEPTION"+uid);				
			}
		}
	}
}