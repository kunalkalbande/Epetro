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

namespace EPetro.Module.Employee
{
	/// <summary>
	/// Summary description for Employee_List.
	/// </summary>
	public class Employee_List : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtEmpID;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtDesig;
		protected System.Web.UI.HtmlControls.HtmlTable Main;
		protected System.Web.UI.WebControls.DataGrid GridSearch;
		protected System.Web.UI.WebControls.LinkButton btnSearch;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		string strOrderBy="";
		string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
		
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.GridSearch.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.GridSearch_PageIndexChanged);
			this.GridSearch.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.GridSearch_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Search the record in the table according to input values
		/// If input value not given then fatch all records from the table.
		/// </summary>
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				strOrderBy = "Emp_ID ASC";
				Session["Column"] = "Emp_ID";
				Session["Order"] = "ASC";
				BindTheData();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:EmployeeList.aspx,Class:Employee.cs,Method:btnSearch_Click"+  "EXCEPTION"+ ex.Message+  uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid. 
		/// </summary>
		public void BindTheData()
		{
			GridSearch.CurrentPageIndex=0;
			DataSet ds;
			EmployeeClass  obj=new EmployeeClass();
			ds=obj.ShowEmployeeInfo(txtEmpID.Text.Trim ().ToString(),txtName.Text.Trim ().ToString() , txtDesig.Text.Trim ().ToString());
			//****
			DataTable dt=ds.Tables[0];
			DataView dv=new DataView(dt);
			dv.Sort=strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			//****
			//**if(ds.Tables[0].Rows.Count>0)
			if(dv.Count>0)
			{
				GridSearch.DataSource=dv;
				GridSearch.DataBind();
				GridSearch.Visible=true;
			}
			else
			{
				MessageBox.Show("Employee Not Found");
				GridSearch.Visible=false;
			}
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnSortCommand"
		/// </summary>
		public void SortCommand_Click(object sender,DataGridSortCommandEventArgs e)
		{
			try
			{
				//Check to see if same column clicked again
				if(e.SortExpression.ToString().Equals(Session["Column"]))
				{
					if(Session["Order"].Equals("ASC"))
					{
						strOrderBy=e.SortExpression.ToString() +" DESC";
						Session["Order"]="DESC";
					}
					else
					{
						strOrderBy=e.SortExpression.ToString() +" ASC";
						Session["Order"]="ASC";
					}
				}
					//Different column selected, so default to ascending order
				else
				{
					strOrderBy = e.SortExpression.ToString() +" ASC";
					Session["Order"] = "ASC";
				}
				Session["Column"] = e.SortExpression.ToString();
				BindTheData();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Employee_List.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used for changing the index of page.
		/// </summary>
		private void GridSearch_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			GridSearch.CurrentPageIndex =(int)e.NewPageIndex ;
			DataSet ds;
			try
			{
				EmployeeClass  obj=new EmployeeClass();
				ds=obj.ShowEmployeeInfo(txtEmpID.Text.Trim ().ToString(),txtName.Text.Trim ().ToString() , txtDesig.Text.Trim ().ToString());
				//***Mahesh, Date :- 12/12/06*
				DataTable dt=ds.Tables[0];
				DataView dv=new DataView(dt);
				dv.Sort=System.Convert.ToString(Cache["strOrderBy"]);
				//****
				GridSearch.DataSource=dv;
				GridSearch.DataBind();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:EmployeeList.aspx,Class:Employee.cs,Method:GridSearch_PageIndexChanged"+  "EXCEPTION"+ ex.Message+  uid);
			}
		}

		/// <summary>
		/// This method is used for setting the Session variable for userId
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
				CreateLogFiles.ErrorLog("Form:EmployeeList.aspx,Class:Employee.cs,Method:page_Load"+  "EXCEPTION"+ ex.Message+  uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
                
				#region Check Privileges
				checkPrivileges();
				if(View_flag=="0")
				{
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
			}
		}

		/// <summary>
		/// This method checks the user privileges from session.
		/// </summary>
		public void checkPrivileges()
		{
			int i;
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
		}
		
		/// <summary>
		/// This method is used to delete the selected record from the database.
		/// </summary>
		private void GridSearch_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			checkPrivileges();
			if(Del_Flag =="0")
			{
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				return;
			}
			SqlConnection sqlConn=new SqlConnection();
			try
			{
				string strCon=System.Configuration.ConfigurationSettings.AppSettings["Epetro"];
				SqlCommand sqlCmd=new SqlCommand();
				sqlCmd.CommandText="Delete from Employee Where Emp_ID='"+e.Item.Cells[0].Text+"'";
				sqlConn.ConnectionString=strCon;
				sqlConn.Open();
				sqlCmd.Connection=sqlConn;
				sqlCmd.ExecuteNonQuery();
				sqlCmd.Dispose();
				sqlConn.Close();
				//**********
				sqlCmd.CommandText="Delete from Ledger_Master Where Ledger_Name='"+e.Item.Cells[1].Text+"'";
				sqlConn.ConnectionString=strCon;
				sqlConn.Open();
				sqlCmd.Connection=sqlConn;
				sqlCmd.ExecuteNonQuery();
				sqlCmd.Dispose();
				sqlConn.Close();
				//**********
				MessageBox.Show("Employee Deleted");
				CreateLogFiles.ErrorLog("Form:EmployeeList.aspx,Class:Employee.cs,Method:GridSearch_DeleteCommand"+" Employee "+ e.Item.Cells[0].Text+" IS DELETED "+"  "+" USER ID "+ uid);
				Response.Redirect("Employee_List.aspx",false);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:EmployeeList.aspx,Class:Employee.cs,Method:GridSearch_DeleteCommand"+" Employee "+ e.Item.Cells[0].Text+" IS DELETED "+"  "+ex.Message+"  USERID  "+ uid);
			}
		}
	}
}