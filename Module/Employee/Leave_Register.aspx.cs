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
using EPetro.Sysitem.Classes;
using RMG;
using System.Text;

namespace EPetro.Module.Employee
{
	/// <summary>
	/// Summary description for Leave_Register.
	/// </summary>
	public class Leave_Register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtReason;
		protected System.Web.UI.WebControls.Button btnApply;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTO;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.DropDownList DropEmpName;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
	
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Leave_Register.aspx,Method:pageload"+"EXCEPTION  "+ ex.Message+ uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);	
				return;
			}

			// Sets todays date in from and to date text boxes.
			
			if(!Page.IsPostBack)
			{
                txtDateFrom.Attributes.Add("readonly", "readonly");
                txtDateTO.Attributes.Add("readonly", "readonly");
                #region Check Privileges
                int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
				string SubModule="6";
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
				try
				{
					txtDateFrom.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
					txtDateTO.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();  
					#region Fetch Employee ID and Name of All Employee
					EmployeeClass  obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string sql;
	
					sql="select Emp_ID,Emp_Name from Employee order by Emp_Name";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropEmpName.Items.Add(SqlDtr.GetValue(0).ToString ()+":"+SqlDtr.GetValue(1).ToString());				
					}
					SqlDtr.Close();
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Leave_Register.aspx,Method:pageload"+"EXCEPTION  "+ ex.Message+ uid);
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
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method converts the dd/mm/yyyy date to mm/dd/yyyy
		/// </summary>
		public DateTime ToMMddYYYY(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];			
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);			
			return(dt);
		}

		/// <summary>
		/// This method is used to save the employee leave with the help of ProLeaveEntry Procedure
		/// before check the date if Leave save already in this given date then first delete the record 
		/// and save the record update otherwise save the record in Leave_Register table.
		/// </summary>
		private void btnApply_Click(object sender, System.EventArgs e)
		{
			EmployeeClass obj=new EmployeeClass();
            StringBuilder erroMessage = new StringBuilder();
            try
			{
                if (DropEmpName.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select Employee ID");
                    erroMessage.Append("\n");
                }

                if (txtReason.Text == string.Empty)
                {
                    erroMessage.Append("- Please Specify the Reason of Leave");
                    erroMessage.Append("\n");
                }

                if (erroMessage.Length > 0)
                {
                    MessageBox.Show(erroMessage.ToString());
                    return;
                }

                #region Check Validation
                if (DateTime.Compare(ToMMddYYYY(txtDateFrom.Text), ToMMddYYYY(txtDateTO.Text)) > 0)
                {
                    MessageBox.Show("Date From Should Be Less Than Date To");
                    return;
                }
                
                int Count=0;
				string str = "select count(*) from Leave_Register where Emp_ID='"+DropEmpName.SelectedItem.Value.Substring(0,DropEmpName.SelectedItem.Value.LastIndexOf(":"))+"' and cast(floor(cast(cast(date_from as datetime) as float)) as datetime) <='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(cast(date_to as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and isSanction=1";
				dbobj.ExecuteScalar(str,ref Count);
				if(Count>0)
				{
					MessageBox.Show("Employee already allow leave is given date");
					return;
				}
				str = "select * from Leave_Register where Emp_ID='"+DropEmpName.SelectedItem.Value.Substring(0,DropEmpName.SelectedItem.Value.LastIndexOf(":"))+"' and cast(floor(cast(cast(date_from as datetime) as float)) as datetime) <='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(cast(date_to as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and isSanction=0";
				dbobj.ExecuteScalar(str,ref Count);
				if(Count>0)
				{
					int x=0;
					dbobj.Insert_or_Update("delete from Leave_Register where Emp_ID='"+DropEmpName.SelectedItem.Value.Substring(0,DropEmpName.SelectedItem.Value.LastIndexOf(":"))+"' and cast(floor(cast(cast(date_from as datetime) as float)) as datetime) <='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(cast(date_to as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and isSanction=0",ref x);
				}
				#endregion
				obj.Emp_Name = DropEmpName.SelectedItem.Value.Substring(0,DropEmpName.SelectedItem.Value.LastIndexOf(":"));
				obj.Date_From  =GenUtil.str2MMDDYYYY(txtDateFrom.Text);
				obj.Date_To  = GenUtil.str2MMDDYYYY(txtDateTO.Text);
				obj.Reason =StringUtil.FirstCharUpper(txtReason.Text.ToString());
				// calls fuction to insert the leave
				obj.InsertLeave  ();
				MessageBox.Show("Leave Application Saved");
				Clear();
				CreateLogFiles.ErrorLog("Form:Leave_Register.aspx,Method:btnApply_Click"+"  empname  :" + obj.Emp_Name   +" datefrom  "+ obj.Date_From  + "        uptodate   "+obj.Date_To  +" for Reason "+ obj.Reason  +"  is saved  "+"  userid:   "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Leave_Register.aspx,Method:btnApply_Click"+"  empname  :" + obj.Emp_Name    +"  is saved  "+"  EXCEPTION  "+ex.Message  +"  userid:   "+uid);
			}
		}

		/// <summary>
		/// This Method to clear the form.
		/// </summary>
		public void Clear()
		{
			DropEmpName.SelectedIndex=0;
			//txtDateFrom.Text="";
			//txtDateTO.Text="";
			txtReason.Text="";
			txtDateFrom.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
			txtDateTO.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();  
		}
	}
}