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
using System.Data.SqlClient ;
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
	/// Summary description for Employee_Update.
	/// </summary>
	public class Employee_Update : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.TextBox txtContactNo;
		protected System.Web.UI.WebControls.TextBox txtOT_Comp;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox txtSalary;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.DropDownList DropDesig;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.Label LblEmployeeID;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator7;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.Label lblDrLicense;
		protected System.Web.UI.WebControls.TextBox txtLicenseNo;
		protected System.Web.UI.WebControls.Label lblLicenseVali;
		protected System.Web.UI.WebControls.TextBox txtLicenseValidity;
		protected System.Web.UI.WebControls.Label lblLICPolicy;
		protected System.Web.UI.WebControls.TextBox txtLICNo;
		protected System.Web.UI.WebControls.Label lblLICValid;
		protected System.Web.UI.WebControls.TextBox txtLICvalidity;
		protected System.Web.UI.WebControls.Label lblVehicleNo;
		protected System.Web.UI.WebControls.DropDownList DropVehicleNo;
		protected System.Web.UI.WebControls.TextBox txtbeatname;
		protected System.Web.UI.WebControls.TextBox txtopbal;
		protected System.Web.UI.WebControls.DropDownList DropType;
		protected System.Web.UI.WebControls.TextBox txtOther;
		protected System.Web.UI.WebControls.TextBox TempCustName;
		protected System.Web.UI.WebControls.TextBox lblName;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		string uid;
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// and also fatch the employee information according to select employee ID in comes from url.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception  ex)
			{
				CreateLogFiles.ErrorLog("Form:Employee_Update.aspx,Method:page_load"+" EXCEPTION  "+ ex.Message+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack)
			{
				getbeat();
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
				if(Edit_Flag=="0")
				{
					//	string msg="UnAthourized Visit to Enployee Entry Page";
					//dbobj.LogActivity(msg,Session["User_Name"].ToString());  
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
				try
				{
					LblEmployeeID.Text=Request.QueryString.Get("ID"); 
					MasterClass obj1=new MasterClass();
					EmployeeClass obj=new EmployeeClass (); 
					SqlDataReader SqlDtr;	
					string sql;
					GetDesig();
					#region Fetch Extra Cities,Designation,country and State from Database and add to the ComboBox
					sql="select distinct Country from Beat_Master";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropCountry.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
					sql="select distinct City from Beat_Master";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropCity.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					SqlDtr.Close();
					
					string sql1;
					sql1="select  distinct State from Beat_Master";
					SqlDtr=obj.GetRecordSet(sql1);
					while(SqlDtr.Read())
					{
						DropState.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					SqlDtr.Close();
				
					//string sql2;
				
					/*	sql2="select Designation from Employee";
						SqlDtr=obj.GetRecordSet(sql2);
						while(SqlDtr.Read())
						{
							DropDesig.Items.Add(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						*/

					DropVehicleNo.Items.Clear();
					DropVehicleNo.Items.Add("Select");
					SqlDtr = obj.GetRecordSet("Select vehicle_no from vehicleentry");
					while(SqlDtr.Read())
					{
						DropVehicleNo.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					SqlDtr.Close();

					txtLicenseNo .Text = "";
					txtLicenseValidity.Text = "";
					txtLICNo.Text = "";
					txtLICvalidity.Text = "";
					DropVehicleNo.SelectedIndex = 0; 
					txtOther.Text="";
					#endregion

					SqlDtr = obj.EmployeeList(LblEmployeeID.Text.ToString (),"",""  );
					while (SqlDtr.Read ())
					{
						lblName.Text =SqlDtr.GetValue(1).ToString ();
						TempCustName.Text=SqlDtr.GetValue(1).ToString ();
						if(DropDesig.Items.IndexOf(DropDesig.Items.FindByValue(SqlDtr.GetValue(2).ToString()))>0)
							DropDesig.SelectedIndex =DropDesig.Items.IndexOf(DropDesig.Items.FindByValue(SqlDtr.GetValue(2).ToString ()));
						else
						{
							DropDesig.SelectedIndex =DropDesig.Items.IndexOf(DropDesig.Items.FindByValue("Other"));
							txtOther.Text=SqlDtr.GetValue(2).ToString();
						}
						txtAddress.Text =SqlDtr.GetValue(3).ToString ();
						DropCity.SelectedIndex =DropCity.Items.IndexOf(DropCity.Items.FindByValue(SqlDtr.GetValue(4).ToString ()));
						DropState.SelectedIndex =DropState.Items.IndexOf(DropState.Items.FindByValue(SqlDtr.GetValue(5).ToString ()));
						// If the designation is driver then it shows the extra fields related to driver , else hide that fields.
						if(SqlDtr.GetValue(2).ToString().Trim().Equals("Driver"))
						{
							lblDrLicense.Visible = true;
							lblLicenseVali.Visible = true;
							lblLICPolicy.Visible  = true;
							lblLICValid.Visible = true;
							lblVehicleNo.Visible = true;
							txtLicenseNo .Visible = true;
							txtLicenseValidity.Visible  = true;
							txtLICNo.Visible = true;
							txtLICvalidity.Visible = true;
							DropVehicleNo.Visible =true;
							txtOther.Visible=false;
						}
						else if(DropDesig.SelectedItem.Text.Equals("Other"))
						{
							lblDrLicense.Visible = false;
							lblLicenseVali.Visible = false;
							lblLICPolicy.Visible  = false;
							lblLICValid.Visible = false;
							lblVehicleNo.Visible = false; 
							txtLicenseNo .Visible = false;
							txtLicenseValidity.Visible  = false;
							txtLICNo.Visible = false;
							txtLICvalidity.Visible = false;
							DropVehicleNo.Visible =false; 
							txtOther.Visible=true;
						}
						else
						{
							lblDrLicense.Visible = false;
							lblLicenseVali.Visible = false;
							lblLICPolicy.Visible  = false;
							lblLICValid.Visible = false;
							lblVehicleNo.Visible = false; 
							txtLicenseNo .Visible = false;
							txtLicenseValidity.Visible  = false;
							txtLICNo.Visible = false;
							txtLICvalidity.Visible = false;
							DropVehicleNo.Visible =false; 
							txtOther.Visible=false;
						}
						DropCountry.SelectedIndex =DropCountry.Items.IndexOf(DropCountry.Items.FindByValue(SqlDtr.GetValue(6).ToString ()));
						txtContactNo .Text =SqlDtr.GetValue(7).ToString ();
						if(txtContactNo.Text=="0")
							txtContactNo.Text="";
						txtMobile.Text =SqlDtr.GetValue(8).ToString ();
						if(txtMobile.Text=="0")
							txtMobile.Text="";
						txtEMail.Text =SqlDtr.GetValue(9).ToString ();
						txtSalary.Text =SqlDtr.GetValue(10).ToString ();
						txtOT_Comp.Text =SqlDtr.GetValue(11).ToString ();
						txtLicenseNo .Text = SqlDtr.GetValue(12).ToString();
						txtLicenseValidity.Text = GenUtil.str2DDMMYYYY(trimDate(SqlDtr.GetValue(13).ToString()));
						txtLICNo.Text = SqlDtr.GetValue(14).ToString();
						txtLICvalidity.Text = GenUtil.str2DDMMYYYY(trimDate(SqlDtr.GetValue(15).ToString()));
						//Response.Write(SqlDtr.GetValue(16).ToString());  
						SqlDataReader rdr = null;
						dbobj.SelectQuery("Select vehicle_no from vehicleentry where vehicledetail_id = "+SqlDtr.GetValue(16).ToString(),ref rdr);
						if(rdr.Read())
						{
							//Response.Write(rdr.GetValue(0).ToString ());  
							DropVehicleNo.SelectedIndex =DropVehicleNo.Items.IndexOf(DropVehicleNo.Items.FindByValue(rdr.GetValue(0).ToString ().Trim() ));
						}
						rdr.Close();
						rdr = null;
						dbobj.SelectQuery("Select Op_Balance,Bal_Type from Ledger_Master where Ledger_Name = '"+SqlDtr.GetValue(1).ToString()+"'",ref rdr);
						if(rdr.Read())
						{
							txtopbal.Text=rdr.GetValue(0).ToString();
							DropType.SelectedIndex =DropVehicleNo.Items.IndexOf(DropVehicleNo.Items.FindByValue(rdr.GetValue(1).ToString ().Trim() ));
						}
						rdr.Close();
					}
					
					SqlDtr.Close(); 

				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Employee_Update.aspx,Method:Page_Load() "+"EmployeeID.   EXCEPTION" + ex.Message+" userid  "+uid);
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
		/// This function rturn only date from date time
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
		/// Updated the employee information according to selected the employee with the 
		/// help of stored procedures.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			EmployeeClass obj=new EmployeeClass();
			try
			{
				obj.Emp_ID = LblEmployeeID.Text.ToString ();
				obj.TempEmpName=TempCustName.Text;
				obj.Emp_Name =lblName.Text ;
				obj.Address =txtAddress.Text.ToString();
				obj.EMail =txtEMail.Text.ToString ();
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
					obj.Designation = txtOther.Text;
				else
					obj.Designation =DropDesig.SelectedItem .Value.ToString ();
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
				// calls the update employee procedures through the UpdateEmployee() method.
				obj.UpdateEmployee ();
				MessageBox.Show("Employee Updated");
			
				CreateLogFiles.ErrorLog("Form:Employee_Update.aspx,Method:btnUpdate_Click"+"EmployeeID   " +LblEmployeeID.Text.ToString ()+  " IS UPDATED  "+" userid "+ uid);
				Response.Redirect("Employee_List.aspx",false);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Employee_Update.aspx,Method:btnUpdate_Click"+"EmployeeID  "+LblEmployeeID.Text.ToString()+ "  IS UPDATED "+"  EXCEPTION" + ex.Message+" userid  "+uid);
			}
		}

		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void Clear()
		{
			txtEMail.Text="";
			txtAddress.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry.SelectedIndex=0;
			DropDesig.SelectedIndex=0;
			txtContactNo.Text="";
			txtMobile.Text="";  
			txtOT_Comp.Text="";
			txtSalary.Text="";
		}

		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
			sql="select State,Country from Beat_Master where City='"+ DropCity.SelectedItem.Text +"'" ;
			SqlDtr=obj.GetRecordSet(sql); 
			string city1="";
			string country1="";
			string state1="";
			city1=DropCity.SelectedItem.Value ;
			try
			{
				while(SqlDtr.Read())
				{
					DropState.SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(SqlDtr.GetValue(0).ToString()))));
					DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry.Items.FindByValue(SqlDtr.GetValue(1).ToString()))));
				}
				
				CreateLogFiles.ErrorLog("Form:Employee_Update.aspx,Method:DropCity_SelectedIndexChanged, "+
					" Selected city,state and country is   "+ city1+"  ,"+state1+" and "+country1+"    "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Employee_Update.aspx,Method:DropCity_SelectedIndexChanged   EXCEPTION  "+ ex.Message+"  USERID "+uid);
			}
		*/
		}

		/// <summary>
		/// if select the Driver in the dropdownlist then view the driver information
		/// otherwise not.
		/// </summary>
		private void DropDesig_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// If Designation is driver then visible the extra fields.
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
				txtOther.Visible=true;
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