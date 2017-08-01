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
using RMG;
using System.Text;

namespace EPetro.Module.Employee
{
	/// <summary>
	/// Summary description for OT_Register.
	/// </summary>
	public class OT_Register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropEmpID;
		protected System.Web.UI.WebControls.DropDownList DropHour1;
		protected System.Web.UI.WebControls.DropDownList DropMinute1;
		protected System.Web.UI.WebControls.DropDownList DropHour2;
		protected System.Web.UI.WebControls.DropDownList DropMinute2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator4;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator8;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
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
				CreateLogFiles.ErrorLog("Form:OT_Register.aspx,Method:pageload"+ex.Message+ "EXCEPTION  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			txtDate.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
			if(!Page.IsPostBack)
			{
                txtDate.Attributes.Add("readonly", "readonly");
                #region Check Privileges
                int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
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
				if(Add_Flag=="0")
				{
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
				try
				{
					EmployeeClass  obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string sql;
					#region Employee ID and Name of All Employees
					sql="select Emp_ID,Emp_Name from Employee order by Emp_Name";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropEmpID.Items.Add (SqlDtr.GetValue(0).ToString()+":"+SqlDtr.GetValue(1).ToString());				
					}
					SqlDtr.Close();
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:OT_Register.aspx,Method:pageload"+ex.Message+ "EXCEPTION  "+uid);
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.ID = "OT_Register";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// This method is used to Returs date in MM/DD/YYYY
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
		/// This method used to check whether the OT time is present between the Shift start and End Time.
		/// </summary>
		public bool isTimeBetween(int shiftHrF,int shiftMinF,int shiftHrTo,int shiftMinTo,int hour,int minute)
		{
			if(shiftHrF < shiftHrTo)
			{
				if(hour > shiftHrF && hour < shiftHrTo)
					return false;
				else if( hour == shiftHrF)
				{
					if(minute >= shiftMinF)
						return false;
					return true;
				}
				else if(hour == shiftHrTo)
				{
					if(minute < shiftMinTo)
						return false;
					return true;
				}
				return true;
			}
			else if(shiftHrF > shiftHrTo)
			{
				if(hour > shiftHrF || hour < shiftHrTo)
					return false;
				else if( hour == shiftHrF)
				{
					if(minute >= shiftMinF)
						return false;
					return true;
				}
				else if( hour == shiftHrTo)
				{
					if(minute < shiftMinTo)
						return false;
					return true;
				}
				return true;
			}
			else
			{
				if(shiftHrTo == hour)
				{
					if(minute >= shiftMinF && minute < shiftMinTo)
						return false;
				}
				return true;
			}
		}


		/// <summary>
		/// This calls  isTimeBetween() to check the OT start and end time is present in between shift start and end time.
		/// </summary>
		public bool isOverTimeExclusive(int shiftHrF, int shiftMinF, int shiftHrTo, int shiftMinTo, int hourFrom, int minuteFrom, int hourTo, int minuteTo)
		{
			if(!(isTimeBetween(shiftHrF,shiftMinF,shiftHrTo,shiftMinTo,hourFrom,minuteFrom) &&
				isTimeBetween(shiftHrF,shiftMinF,shiftHrTo,shiftMinTo,hourTo,minuteTo))
				)
				return false;
			return true;
		}

        /// <summary>
        /// This method is used to insert and update the record with the help of stored procedures.
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EmployeeClass obj1 = new EmployeeClass();
            EmployeeClass obj2 = new EmployeeClass();
            StringBuilder erroMessage = new StringBuilder();
            try
            {               
                if (DropEmpID.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select Employee ID");
                    erroMessage.Append("\n");
                }

                if (DropHour1.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select Time From");
                    erroMessage.Append("\n");
                }

                if (DropMinute1.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select Time From");
                    erroMessage.Append("\n");
                }

                if (DropHour2.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select Time To");
                    erroMessage.Append("\n");
                }

                if (DropMinute2.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select Time To");
                    erroMessage.Append("\n");
                }

                if (erroMessage.Length > 0)
                {
                    MessageBox.Show(erroMessage.ToString());
                    return;
                }
                string id = "";
                string sql = "";
                SqlDataReader SqlDtr;
                DateTime dt;
                string shiftfrom = "";
                string shiftto = "";
                obj1.Emp_ID = DropEmpID.SelectedItem.Value.Substring(0, DropEmpID.SelectedItem.Value.LastIndexOf(":"));
                id = obj1.Emp_ID;
                obj1.OT_Date = ToMMddYYYY(txtDate.Text).ToShortDateString();
                string OtFrom = DropHour1.SelectedItem.Value.ToString() + ":" + DropMinute1.SelectedItem.Value.ToString() + ":" + 00;
                dt = Convert.ToDateTime(OtFrom);
                string str1 = dt.ToString("t");
                obj1.OT_From = str1;
                string OtTo = DropHour2.SelectedItem.Value.ToString() + ":" + DropMinute2.SelectedItem.Value.ToString();
                obj1.OT_To = OtTo.ToString();
                sql = "select  count (status)  from attandance_register where att_date='" + ToMMddYYYY(txtDate.Text).ToShortDateString() + "' and Emp_ID=" + id + " and status =1";
                SqlDtr = obj1.GetRecordSet(sql);
                if (SqlDtr.Read())
                {
                    int status = SqlDtr.GetInt32(0);
                    SqlDtr.Close();
                    if (status == 1)
                    {
                        SqlDataReader SqlDtr1;
                        string sql1 = "SELECT Time_from,Time_To FROM SHIFT where shift_id= any(select shift_id from shift_Assignment where emp_id=" + id + ")";
                        SqlDtr1 = obj2.GetRecordSet(sql1);
                        if (SqlDtr1.HasRows)
                        {
                            while (SqlDtr1.Read())
                            {
                                shiftfrom = SqlDtr1.GetValue(0).ToString();
                                shiftto = SqlDtr1.GetValue(1).ToString();
                            }
                            string[] strarr = new string[2];
                            strarr = shiftfrom.Split(new char[] { ':' }, shiftfrom.Length);
                            int shiftHrF = Int32.Parse(strarr[0]);
                            int shiftMinF = Int32.Parse(strarr[1]);
                            strarr = shiftto.Split(new char[] { ':' }, shiftto.Length);
                            int shiftHrTo = Int32.Parse(strarr[0]);
                            int shiftMinTo = Int32.Parse(strarr[1]);
                            strarr = OtFrom.Split(new char[] { ':' }, OtFrom.Length);
                            int hourFrom = Int32.Parse(strarr[0]);
                            int minuteFrom = Int32.Parse(strarr[1]);
                            strarr = OtTo.Split(new char[] { ':' }, OtTo.Length);
                            int hourTo = Int32.Parse(strarr[0]);
                            int minuteTo = Int32.Parse(strarr[1]);
                            if (!isOverTimeExclusive(shiftHrF, shiftMinF, shiftHrTo, shiftMinTo, hourFrom, minuteFrom, hourTo, minuteTo))
                            {
                                MessageBox.Show("Overtime Cannot Be Assigned During The Shift Timing");
                                return;
                            }
                        }
                        obj1.InsertOverTimeRegister();
                        MessageBox.Show("Overtime Assigned");
                    }
                    else
                    {
                        MessageBox.Show("Cannot Assign Overtime For An Absent Employee");
                    }
                }
                CreateLogFiles.ErrorLog("Form:OT_Register.aspx,Method:btnUpdate_Click" + "EMPLOYEE ID IS" + obj1.Emp_ID + "  OT date from " + obj1.OT_From + "  upto the OT " + obj1.OT_To + "  ondate " + obj1.OT_Date + " is saved  " + " userid " + uid);
                Clear();
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:OT_Register.aspx,Method:btnUpdate_Click" + "EMPLOYEE ID IS" + "  OT date from " + obj1.OT_From + "  upto the OT " + obj1.OT_To + "  ondate " + obj1.OT_Date + " is saved  " + "  EXCEPTION  " + ex.Message + "  userid " + uid);
            }
        }

        /// <summary>
        /// This Method to clear the form.
        /// </summary>
        public void Clear()
		{
			DropEmpID.SelectedIndex=0;
			//txtDate.Text="";
			DropHour1.SelectedIndex=0;
			DropHour2.SelectedIndex=0;
			DropMinute1.SelectedIndex=0;
			DropMinute2.SelectedIndex=0;
		}        
    }
}