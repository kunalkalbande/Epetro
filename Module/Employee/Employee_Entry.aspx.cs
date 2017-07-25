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
using System.Data .SqlClient ;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPetro.Sysitem.Classes ;
using RMG;

namespace EPetro.Module.Employee
{
	/// <summary>
	/// Created by	: Anand Mittal
	/// Created on	:
	///	Description	: This form is used for record the Employee profile. Each time when we click SAVE PROFILE
	///				button the data filled in the form will saved and new Employee_ID will generate.
	///				After Saving the record a popup message will show for confirmation.
	/// Tables Used	:
	///				1. Employee
	///	stored procedures :	
	///				1. ProEmployeeEntry - This Stored Procedures Accepts 13 input type Paramenters 
	///				   and fire the insert command to save the record in the Employee Table.
	/// </summary>
	public class Employee_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFName;
		protected System.Web.UI.WebControls.TextBox txtMName;
		protected System.Web.UI.WebControls.TextBox txtLName;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.TextBox txtContactNo;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.DropDownList DropDesig;
		protected System.Web.UI.WebControls.TextBox txtSalary;
		protected System.Web.UI.WebControls.TextBox txtOT_Comp;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label LblEmployeeID;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox txtLicenseNo;
		protected System.Web.UI.WebControls.TextBox txtLicenseValidity;
		protected System.Web.UI.WebControls.TextBox txtLICvalidity;
		protected System.Web.UI.WebControls.TextBox txtLICNo;
		protected System.Web.UI.WebControls.DropDownList DropVehicleNo;
		protected System.Web.UI.WebControls.Label lblDrLicense;
		protected System.Web.UI.WebControls.Label lblLicenseVali;
		protected System.Web.UI.WebControls.Label lblLICValid;
		protected System.Web.UI.WebControls.Label lblLICPolicy;
		protected System.Web.UI.WebControls.Label lblVehicleNo;
		protected System.Web.UI.WebControls.TextBox txtbeatname;
		protected System.Web.UI.WebControls.TextBox txtopbal;
		protected System.Web.UI.WebControls.DropDownList DropType;
		protected System.Web.UI.WebControls.TextBox txtOther;
		string uid;
		
		/// <summary>
		/// Put user code to initialize the page here
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
				CreateLogFiles.ErrorLog("Form:Employee_Entry.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"  "+ uid );
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if (!IsPostBack)
			{
				try
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="2";
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
						//string msg="UnAthourized Visit to Employee Entry Page";
						//		dbobj.LogActivity(msg,Session["User_Name"].ToString());  
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					}
					#endregion
					fillDriverDetails();
					getbeat();
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string sql;
					GetNextEmpID();
					GetDesig();
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
					lblDrLicense.Visible = false;
					lblVehicleNo.Visible = false;
					lblLicenseVali.Visible = false;
					lblLICPolicy.Visible = false;
					lblLICValid.Visible = false;  
					txtLicenseNo.Visible = false;
					txtLicenseValidity.Visible  = false;
					txtLICNo.Visible = false;
					txtOther.Visible=false;
					txtLICvalidity.Visible = false;
					DropVehicleNo.Visible = false;
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Employee_Entry.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"  "+ uid );
				}
			}
		}

		public void GetDesig()
		{
			#region Fetch Designation from Database and add to the ComboBox
			InventoryClass obj = new InventoryClass();
			SqlDataReader SqlDtr;
			string sql="select distinct Designation from Employee order by Designation asc";
			SqlDtr=obj.GetRecordSet(sql);
			DropDesig.Items.Remove("Other");
			while(SqlDtr.Read())
			{
				DropDesig.SelectedIndex=DropDesig.Items.IndexOf(DropDesig.Items.FindByValue(SqlDtr.GetValue(0).ToString()));
				if(DropDesig.SelectedIndex==0)
					DropDesig.Items.Add(SqlDtr.GetValue(0).ToString());
			}
			DropDesig.Items.Add("Other");
			DropDesig.SelectedIndex=0;
			SqlDtr.Close();
			#endregion
		}
		/// <summary>
		/// This Method fetch the Vehcile No and ID and Fill the Vehicle No. Combo from Vehicleentry table.
		/// </summary>
		public void fillDriverDetails()
		{ 
			txtLicenseValidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;    
			txtLICvalidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;   
			DropVehicleNo.Items.Clear();
			DropVehicleNo.Items.Add("Select");
			SqlDataReader SqlDtr = null;
			dbobj.SelectQuery("Select vehicle_no from vehicleentry",ref SqlDtr);
			while(SqlDtr.Read())
			{
				DropVehicleNo.Items.Add(SqlDtr.GetValue(0).ToString());   
			}
			SqlDtr.Close();
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
			this.DropDesig.SelectedIndexChanged += new System.EventHandler(this.DropDesig_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This method is used to Insert the all values in the database with the help of stored procedure.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{       
			EmployeeClass obj=new EmployeeClass();
			string str2="";
			try
			{
				SqlDataReader SqlDr;
				if(DropDesig.SelectedItem.Text == "Driver")
				{
					if(txtLicenseNo.Text.Trim().Equals("") ) 
					{
						MessageBox.Show("Please enter License No");
						return;
					}
				}
				if(DropDesig.SelectedItem.Text == "Other")
				{
					if(txtOther.Text.Trim().Equals("") ) 
					{
						MessageBox.Show("Please enter Designation");
						return;
					}
				}
				string sql1; 
				string ename=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim() )) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim() ))+" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim() ));
				sql1="select Emp_Id from employee where Emp_Name='"+ename+"'";
				SqlDr=obj.GetRecordSet(sql1);
				if(SqlDr.HasRows)
				{
					MessageBox.Show("Employee Name  "+ename+" Already Exist");
					return;
				}
				SqlDr.Close();
				obj.Emp_ID = LblEmployeeID.Text.ToString();
				obj.Emp_Name =StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim() )) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim() ))+" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim() ));
				obj.Address =StringUtil.FirstCharUpper(txtAddress.Text.ToString());
				obj.EMail =txtEMail.Text;
				obj.City =DropCity.SelectedItem .Value.ToString ();
				obj.State  =DropState.SelectedItem .Value.ToString ();
				obj.Country  =DropCountry.SelectedItem .Value.ToString ();
				if(txtContactNo.Text.ToString()=="")
					obj.Phone="0";
				else 
					obj.Phone =txtContactNo.Text.ToString ();
				if(txtMobile.Text.ToString()=="")
					obj.Mobile="0";
				else 
					obj.Mobile =txtMobile.Text.ToString();
				if(DropDesig.SelectedItem.Text.Equals("Other"))
					obj.Designation = txtOther.Text.Trim();
				else
					obj.Designation = DropDesig.SelectedItem .Value.ToString ();
				obj.Salary =txtSalary.Text.ToString ();
				obj.OT_Compensation =txtOT_Comp.Text.ToString();
				obj.Dr_License_No  = txtLicenseNo.Text.ToString().Trim ();
				obj.Dr_License_validity  = GenUtil.str2MMDDYYYY (txtLicenseValidity.Text.Trim());
				obj.Dr_LIC_No = txtLICNo.Text.Trim();
				obj.Dr_LIC_validity = GenUtil.str2MMDDYYYY(txtLicenseValidity.Text.Trim()) ;  
				obj.OpBalance=txtopbal.Text.Trim().ToString();
				obj.BalType=DropType.SelectedItem.Text;
				string vehicle_no = DropVehicleNo.SelectedItem.Text.Trim();
				if(vehicle_no.Equals(""))
				{
					vehicle_no = "0";
				}
				obj.Vehicle_NO = vehicle_no; 
				// Call the function from employee class to execute the procedure to insert the record.
				obj.InsertEmployee ();	
				MessageBox.Show("Employee Saved");
				CreateLogFiles.ErrorLog("Form:Employee_Entry.aspx,Class:Employeee.cs,Methd: btnUpdate_Click   "+"Employee ID "+LblEmployeeID.Text.ToString()+"   Employee Name  " +obj.Emp_Name   +" city   "+ 	obj.City   +" Salary  "+ 	obj.Salary + " Designation "+ obj.Designation    +  " IS SAVED  "+" userid "+Session["User_Name"].ToString()+"    "+uid);
				Clear();
				GetDesig();
				GetNextEmpID();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Employee_Entry.aspx,Class:Employeee.cs,Methd: btnUpdate_Click   Exception: "+ex.Message +"   userid  "+str2+"  "+uid);
			}
		}

		/// <summary>
		/// This method is used to clear the form
		/// </summary>
		public void Clear()
		{
			LblEmployeeID.Text="";
			txtFName.Text="";
			txtMName.Text="";
			txtLName.Text="";
			txtEMail.Text="";
			txtAddress.Text="";
			txtOther.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry.SelectedIndex=0;
			DropDesig.SelectedIndex=0;
			txtContactNo.Text="";
			txtMobile.Text="";  
			txtOT_Comp.Text="";
			txtSalary.Text="";
			txtLicenseNo.Text = "";
			txtLICNo.Text = "";
			DropVehicleNo.SelectedIndex = 0;
			txtLicenseValidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;    
			txtLICvalidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;   
			txtLICNo.Visible=false;
			txtLicenseNo.Visible=false;
			DropVehicleNo.Visible=false;
			txtLicenseValidity.Visible=false;
			txtLICvalidity.Visible=false;
			txtOther.Visible=false;
		}

		/// <summary>
		/// Method to fetch the Next Employee ID from table employee and display in lable.
		/// The ID initially starts with 100001.
		/// </summary>
		public void GetNextEmpID()
		{
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr;

			#region Fetch Next Employee ID
			SqlDtr =obj.GetNextEmployeeID ();
			while(SqlDtr.Read())
			{
				LblEmployeeID.Text=SqlDtr.GetSqlValue(0).ToString ();
				if (LblEmployeeID.Text=="Null")
					LblEmployeeID.Text ="100001";
			}		
			SqlDtr.Close();
			#endregion
		}
		
		/// <summary>
		/// Retrieve all value according to input value of dropdownlist(Dropcity).
		/// This code is hidden by Mahesh, date :- 30/11/06 because
		/// (Before) state and country are retrieve from the database according to selected city
		/// (After) state and country retrieve with the help of javascript according to 
		/// selected city at client side.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
			// This is used to fetch the state and country according to selected city. This method set the coressponding values of state and country in there respective combos.
			sql="select State,Country from Beat_Master where City='"+ DropCity.SelectedItem.Value +"'" ;
			SqlDtr=obj.GetRecordSet(sql); 
			
			try
			{
				//CreateLogFiles.ErrorLog("Form:Employee_Entry.aspx,Method:DropCity_SelectedIndexChanged "+uid);
				while(SqlDtr.Read())
				{
				
					DropState.SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(SqlDtr.GetValue(0).ToString()))));
					DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry.Items.FindByValue(SqlDtr.GetValue(1).ToString()))));
				}
				SqlDtr.Close();
				//CreateLogFiles.ErrorLog("Form:Employee_Entry.aspx,Method:DropCity_SelectedIndexChanged "+uid);
				}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Employee_Entry.aspx,Method:DropCity_SelectedIndexChanged ,"+" state and country is select for city :"+  DropCity.SelectedItem.Value+  "  EXCEPTION" +ex.Message+" userid "+uid);

			}*/
		}

		/// <summary>
		/// Name : Mahesh, Date : 30/11/06
		/// Retrieve the state and country according to the selected city with the help
		/// of javascript.
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
		/// Retrieve the all value from the database according to input value of DropDesign.
		/// </summary>
		private void DropDesig_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// if designation is Driver then the Additional fields to enter the driver license details and vehicle Number is are visibles , Otherwise not visibles.
			if(DropDesig.SelectedItem.Text == "Driver")
			{
				txtOther.Text="";
				txtLicenseNo.Text = "";
				txtLicenseValidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;    
				txtLICvalidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;   
				txtLICNo.Text = "";
				DropVehicleNo.SelectedIndex = 0;
				txtLicenseNo.Visible = true;
				txtLicenseValidity.Visible  = true;
				txtLICNo.Visible = true;
				txtLICvalidity.Visible = true;
				DropVehicleNo.Visible = true;
				lblDrLicense.Visible = true;
				lblLicenseVali.Visible = true;
				lblLICPolicy.Visible = true;
				lblLICValid.Visible = true;  
				lblVehicleNo.Visible = true;
				txtOther.Visible=false;
			}
			else if(DropDesig.SelectedItem.Text == "Other")
			{
				txtOther.Text="";
				txtOther.Visible=true;
				txtLicenseNo.Text = "";
				txtLICNo.Text = "";
				txtLicenseValidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;    
				txtLICvalidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;   
				DropVehicleNo.SelectedIndex = 0;
				lblDrLicense.Visible = false;
				lblLicenseVali.Visible = false;
				lblLICPolicy.Visible = false;
				lblLICValid.Visible = false;  
				txtLicenseNo.Visible = false;
				txtLicenseValidity.Visible  = false;
				txtLICNo.Visible = false;
				txtLICvalidity.Visible = false;
				DropVehicleNo.Visible = false;
				lblVehicleNo.Visible = false;
			}
			else
			{
				txtOther.Text="";
				txtLicenseNo.Text = "";
				txtLICNo.Text = "";
				txtLicenseValidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;    
				txtLICvalidity.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;   
				DropVehicleNo.SelectedIndex = 0;
				lblDrLicense.Visible = false;
				lblLicenseVali.Visible = false;
				lblLICPolicy.Visible = false;
				lblLICValid.Visible = false;  
				txtLicenseNo.Visible = false;
				txtLicenseValidity.Visible  = false;
				txtLICNo.Visible = false;
				txtLICvalidity.Visible = false;
				DropVehicleNo.Visible = false;
				lblVehicleNo.Visible = false;
				txtOther.Visible=false;
			}
		}
	}
}