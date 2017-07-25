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
using DBOperations;

namespace EPetro.Module.Parties
{
	/// <summary>
	/// Summary description for View_Customer.
	/// </summary>
	public class View_Customer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtCustID;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtPlace;
		protected System.Web.UI.WebControls.DataGrid GridSearch;
		protected System.Web.UI.WebControls.LinkButton btnSearch;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
		string strOrderBy="";
		protected System.Web.UI.WebControls.TextBox txtbeatname;
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
				CreateLogFiles.ErrorLog("Form:Customer_list.aspx,Method:on_pageload  "+ " EXCEPTION "+uid +ex.Message);
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.GridSearch.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.GridSearch_PageIndexChanged);
			this.GridSearch.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.GridSearch_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to search the record according to input value otherwise to retrieve all records from the database(default).
		/// </summary>
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			GridSearch.CurrentPageIndex=0;
			strOrderBy = "Cust_ID ASC";
			Session["Column"] = "Cust_ID";
			Session["Order"] = "ASC";
			gridInit();
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
				gridInit();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_List.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This is used to binding the grid.
		/// </summary>
		public void gridInit()
		{
			try
			{
				PartiesClass obj=new PartiesClass();
				DataSet ds;
				ds=obj.ShowCustomerInfo(txtCustID.Text,txtName.Text,txtPlace.Text);
				//****
				DataTable dt=ds.Tables[0];
				DataView dv=new DataView(dt);
				dv.Sort=strOrderBy;
				Cache["strOrderBy"]=strOrderBy;
				//****
				//if(ds.Tables[0].Rows.Count>0)
				if(dv.Count>0)
				{
					GridSearch.DataSource=dv;
					GridSearch.DataBind();
					GridSearch.Visible=true;
				}
				else
				{
					MessageBox.Show("Customer not Found");
					GridSearch.Visible=false;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_list.aspx,Method:on_pageload  EXCEPTION: "+ex.Message+" User_ID: "+uid);
			}
		}

		/// <summary>
		/// This is used to make paging the grid onclicking of datagridheader.
		/// only five record show at a time.
		/// </summary>
		private void GridSearch_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				GridSearch.CurrentPageIndex =e.NewPageIndex;
				//gridInit();
				PartiesClass obj=new PartiesClass();
				DataSet ds;
				ds=obj.ShowCustomerInfo(txtCustID.Text,txtName.Text,txtPlace.Text );
				//****
				DataTable dt=ds.Tables[0];
				DataView dv=new DataView(dt);
				dv.Sort=System.Convert.ToString(Cache["strOrderBy"]);
				//****
				GridSearch.DataSource=dv;
				GridSearch.DataBind();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_list.aspx,Method:GridSearch_PageIndexChanged  EXCEPTION "+ex.Message+" User_ID: "+uid);
			}
		}

		/// <summary>
		/// This method is used to delete the selected records from the database.
		/// </summary>
		private void GridSearch_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				checkPrivileges();
				if(Del_Flag =="0")
				{
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					return;
				}
				SqlConnection sqlConn=new SqlConnection();
				string strCon=System.Configuration.ConfigurationSettings.AppSettings["Epetro"];
				SqlCommand sqlCmd=new SqlCommand();
				sqlCmd.CommandText="Delete from Customer Where Cust_ID='"+e.Item.Cells[0].Text+"'";
				sqlConn.ConnectionString=strCon;
				sqlConn.Open();
				sqlCmd.Connection=sqlConn;
				sqlCmd.ExecuteNonQuery();
				//sqlCmd.CommandText="Delete from Customer Where Cust_ID='"+e.Item.Cells[0].Text+"'";
				sqlCmd.Dispose();
				sqlConn.Close();
				//*********
				sqlCmd.CommandText="Delete from Ledger_Master Where Ledger_Name='"+e.Item.Cells[1].Text+"'";
				sqlConn.ConnectionString=strCon;
				sqlConn.Open();
				sqlCmd.Connection=sqlConn;
				sqlCmd.ExecuteNonQuery();
				sqlCmd.Dispose();
				sqlConn.Close();
				//*********
				CreateLogFiles.ErrorLog("Form:Customer_list.aspx,Method:GridSearch_DeleteCommand"+"  Customer ID  "+e.Item.Cells[0].Text+"  IS DELETED   "+" USERID      "+uid );
				
				MessageBox.Show("Customer Deleted");
				gridInit();
				Response.Redirect("Customer_List.aspx",false);

			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_list.aspx,Method:GridSearch_DeleteCommand"+"  Customer ID  "+e.Item.Cells[0].Text+"  IS DELETED   "+" USERID "+uid +"      "+"EXCEPTION   "+"   "+ex.Message);
			}
		}
	}
}