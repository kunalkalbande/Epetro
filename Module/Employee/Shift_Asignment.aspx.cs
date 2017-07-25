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
using EPetro.Sysitem.Classes; 
using RMG;

namespace EPetro.Module.Employee
{
	/// <summary>
	/// Summary description for Shift_Asignment.
	/// </summary>
	public class Shift_Asignment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropShiftID;
		protected System.Web.UI.WebControls.TextBox txtShiftTime;
		protected System.Web.UI.WebControls.ListBox ListEmpAvailable;
		protected System.Web.UI.WebControls.Button btnIn;
		protected System.Web.UI.WebControls.ListBox ListEmpAssigned;
		protected System.Web.UI.WebControls.Button btn1;
		protected System.Web.UI.WebControls.Button btnout;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.CompareValidator cvShiftName;
		protected System.Web.UI.WebControls.ValidationSummary vsShiftAssignment;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid="";
		string shift1="";
		string emp="";
		static	int countNo1=0;
		static int countNo2=0;
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:shiftAssignment.aspx,Method:pageload"+ ex.Message+"  EXCEPTION  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if (!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
				string SubModule="5";
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
				if(Add_Flag=="0" && Edit_Flag == "0" && View_flag == "0")
				{
					//string msg="UnAthourized Visit to Shift Asignment Page";
					//dbobj.LogActivity(msg,Session["User_Name"].ToString());  
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				if(Add_Flag == "0")
					btnSubmit.Enabled = false; 
				#endregion

				try
				{
					// Fecth all the shifts and fill sthe combo
					EmployeeClass obj=new EmployeeClass ();
					SqlDataReader SqlDtr;
					string sql;
					sql="select Shift_Name from Shift order by Shift_ID";
					SqlDtr = obj.GetRecordSet (sql);
					while(SqlDtr.Read ())
					{
						DropShiftID.Items.Add(SqlDtr.GetValue(0).ToString ());   
					
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:shiftAssignment.aspx,Method:pageload"+ ex.Message+"  EXCEPTION  "+uid); 
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
			this.DropShiftID.SelectedIndexChanged += new System.EventHandler(this.DropShiftID_SelectedIndexChanged);
			this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
			this.btnout.Click += new System.EventHandler(this.buttonout_Click);
			this.btn1.Click += new System.EventHandler(this.btnOut_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This method is used to retrieve the all values from the database according to select the values
		/// from dropdownlist.
		/// </summary>
		private void DropShiftID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			countNo1=0;
			try
			{
				shift1= DropShiftID.SelectedItem.Value ;
				EmployeeClass obj=new EmployeeClass();
				SqlDataReader SqlDtr;
				string sql;

				#region Fetch Shift Timings
				sql="select datepart(hour,Time_From),"+
					"datepart(minute, Time_From),"+
					"datepart(hour,Time_To),"+
					"datepart(minute, Time_To)"+
					"from shift  where Shift_Name='" + DropShiftID.SelectedItem.Value +"'" ;
				SqlDtr = obj.GetRecordSet (sql);
				while(SqlDtr.Read ())
				{
					txtShiftTime.Text=SqlDtr.GetValue(0)+":"+ SqlDtr.GetValue(1)+ " - " + SqlDtr.GetValue(2)+":"+SqlDtr.GetValue(3);
					txtShiftTime.ToolTip=txtShiftTime.Text;
				}		
				SqlDtr.Close();
				#endregion
				#region	Fetch the Employees who are assigned for selected shift ID
				sql="select Emp_ID,Emp_Name from Employee where Emp_ID in(select Emp_ID "+
					"from Shift_Assignment where Shift_ID=(select Shift_ID from Shift where Shift_Name='"+DropShiftID.SelectedItem.Value
					+"'))";

				SqlDtr = obj.GetRecordSet (sql);
				ListEmpAssigned.Items.Clear (); 
				while(SqlDtr.Read ())

				{
					ListEmpAssigned.Items.Add(SqlDtr.GetValue(0) + " - " + SqlDtr.GetValue(1));
				}
				SqlDtr.Close(); 
				#endregion

				#region	Fetch the Employees who are Available for selected shift ID
				sql="select Emp_ID,Emp_Name from Employee where Emp_ID not in(select Emp_ID "+
					"from Shift_Assignment where Shift_ID=(select Shift_ID from Shift where Shift_Name='"+DropShiftID.SelectedItem.Value
					+"')  and  Shift_Date='"+DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString()+ "') and Emp_ID!=all(select Distinct Emp_id from Shift_Assignment)";
				SqlDtr = obj.GetRecordSet (sql);
				ListEmpAvailable.Items.Clear(); 
				while(SqlDtr.Read())
				{
					ListEmpAvailable.Items.Add(SqlDtr.GetValue(0) + " - " + SqlDtr.GetValue(1));
				}
				SqlDtr.Close();
				#endregion
          

				CreateLogFiles.ErrorLog("Form:Shift_assignment.aspx,Method:DropShiftID_SelectedIndexChanged"+"shiftname is  "+ shift1 +"    "+ uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Shift_assignment.aspx,Method:cmdrpt_Click"+ ex.Message+"  EXCEPTION  "+uid);
			}
		}
		
		/// <summary>
		/// This function to assign a shift to selected employee from the list(Left to Right).
		/// </summary>
		public void assign()
		{
			//countNo1=1;
			//countNo2=1;
				
			try
			{
				//ListEmpAssigned.Items.Add(ListEmpAvailable.SelectedItem.Value);  
				//ListEmpAvailable.Items.Remove(ListEmpAvailable.SelectedItem.Value);
				while(ListEmpAvailable.SelectedItem.Selected)
				{
					ListEmpAssigned.Items.Add(ListEmpAvailable.SelectedItem.Value);  
					ListEmpAvailable.Items.Remove(ListEmpAvailable.SelectedItem.Value);
				}
				//CreateLogFiles.ErrorLog("Form:Shift_assignment.aspx,Method:btnIn_Click"+"  userid "+uid);
			}
			catch(Exception)
			{
				//MessageBox.Show("Please Select An Employee");
				//CreateLogFiles.ErrorLog("Form:Shift_assignment.aspx,Method:btnIn_Click"+"  EXCCEPTION "+ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to move the value from one list to anather.
		/// </summary>
		private void btnIn_Click(object sender, System.EventArgs e)
		{			
			assign();
		}
		
		/// <summary>
		/// Insert the values in the database after assigning the shift.
		/// </summary>
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				EmployeeClass obj=new EmployeeClass();
				//if(countNo1==0 && countNo2==0)
				if(ListEmpAssigned.Items.Count==0)
				{
					MessageBox.Show("Please select an Employee from the Available Employee list");
				}
				else
				{
					string sql;
					obj.Shift_Date=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
					obj.Shift_ID=DropShiftID.SelectedItem.Value;
					sql="Delete From Shift_Assignment where Shift_ID=(select Shift_ID from Shift where shift_Name='"+ DropShiftID.SelectedItem.Value +"')";
	
					obj.ExecRecord(sql); 
					string emp="";
					for(int i=0;i<ListEmpAssigned.Items.Count;++i)
					{
						ListEmpAssigned.SelectedIndex =i;
						obj.Emp_ID = ListEmpAssigned.SelectedItem.Value; 
						emp=emp+"-"+obj.Emp_ID;
						obj.InsertShiftAssignment();
					} 
					countNo1=0;
					countNo2=0;   
					MessageBox.Show("Shift Assigned"); 
					Clear();
				  
					CreateLogFiles.ErrorLog("Form:Shift_Asignment.aspx,Method:btnSubmit_Click"+" Employee ID "+ emp+ "is selected for shift "+" userid "+  uid);
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Shift_Asignment.aspx,Method:btnSubmit_Click"+" Employee ID "+ emp+ "is selected for shift "+  shift1	+"  EXCEPTION  "+ex.Message+" userid "+  uid);	
			}
		}
		
		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void Clear()
		{
			DropShiftID.SelectedIndex=0;
			txtShiftTime.Text="";
			ListEmpAssigned.Items.Clear();
			ListEmpAvailable.Items.Clear();
		}
		
		/// <summary>
		/// To change the shift of employee from the list to selected(Right to Left). 
		/// </summary>
		private void buttonout_Click(object sender, System.EventArgs e)
		{
			//countNo2=1;
			//countNo1=1;
			//string empRemove="";
			//string empSelect="";
			try
			{
				/*
				EmployeeClass obj=new EmployeeClass();	
				ListEmpAvailable.Items.Add(ListEmpAssigned.SelectedItem.Value);   
				empRemove=ListEmpAssigned.SelectedItem.Value;
				empSelect=ListEmpAssigned.SelectedItem.Value;
				ListEmpAssigned.Items.Remove(ListEmpAssigned.SelectedItem.Value);
				*/
				while(ListEmpAssigned.SelectedItem.Selected)
				{
					ListEmpAvailable.Items.Add(ListEmpAssigned.SelectedItem.Value);
					ListEmpAssigned.Items.Remove(ListEmpAssigned.SelectedItem.Value);  
				}
				//CreateLogFiles.ErrorLog("Form:Shift_Asignment.aspx,Method:buttonout_Click"+"  Selected Employee is "+empSelect+"  empRemove  "+empRemove+"   userid "+uid);
			}
			catch(Exception)
			{
				//CreateLogFiles.ErrorLog("Form:Shift_Asignment.aspx,Method:buttonout_Click"+ex.Message+" EXCEPTION  "+uid);
			}		
		}
		
		/// <summary>
		/// Transfer all employee from left to right and right to left.
		/// </summary>
		private void btnOut_Click(object sender, System.EventArgs e)
		{
			countNo2=1;
			countNo1=1;
			if(btn1.Text.Trim().Equals(">>"))
			{
				try
				{
					btn1.Text="<<";
					foreach(System.Web.UI.WebControls.ListItem lst in ListEmpAvailable.Items)
						ListEmpAssigned.Items.Add(lst);
					ListEmpAvailable.Items.Clear();
					CreateLogFiles.ErrorLog("Form:Shift_Asignment.aspx,Method:btnOut_Click"+uid);
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Shift.aspx,Method:cmdrpt_Click"+ ex.Message+"EXCEPTION  "+uid);
				}
			}
			else
			{
				try
				{
					btn1.Text=">>";
					foreach(System.Web.UI.WebControls.ListItem lst in ListEmpAssigned.Items)
						ListEmpAvailable.Items.Add(lst);
					ListEmpAssigned.Items.Clear();
					CreateLogFiles.ErrorLog("Form:Shift_Asignment.aspx,Method:btnOut_Click"+uid);
					
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Shift_Asignment.aspx,Method:btnOut_Click"+ex.Message+"EXCEPTION  "+uid);
				}
			}
		}

		/// <summary>
		/// this function to return mm/dd/yyyy date format.
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
	}
}