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
using EPetro.Sysitem.Classes ;
using RMG;
using DBOperations;

namespace EPetro.Module.Parties
{
	/// <summary>
	/// Summary description for Supplier_List.
	/// </summary>
	public class Supplier_List : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm View_Customer;
		protected System.Web.UI.WebControls.TextBox txtSuppID;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtPlace;
		protected System.Web.UI.WebControls.LinkButton btnSearch;
		protected System.Web.UI.WebControls.DataGrid GridSearch;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		string strOrderBy="";
		string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";

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
				CreateLogFiles.ErrorLog("Form:Supplier_List.aspx,Method:page_load,Class:PartiesClass.cs "+ ex.Message+" EXCEPTION  "+uid);
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
			string SubModule="3";
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
		/// This method is used to bindind the datagrid.
		/// </summary>
		public void initGrid()
		{
			try
			{
				PartiesClass obj=new PartiesClass();
				DataSet ds;
				ds=obj.ShowSupplierInfo(txtSuppID.Text ,txtName.Text,txtPlace.Text );
				//****
				DataTable dt=ds.Tables[0];
				DataView dv=new DataView(dt);
				dv.Sort=System.Convert.ToString(Cache["strOrderBy"]);
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
					MessageBox.Show("Vendor not Found");
					GridSearch.Visible=false;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Supplier_List.aspx,Method:initGrid(),Class:PartiesClass.cs.  EXCEPTION: "+ ex.Message+"  User_ID: "+uid);
			}
		}

		/// <summary>
		/// To search the record according to input values otherwise all records are retrieve from the database. 
		/// </summary>
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			GridSearch.CurrentPageIndex =0; 
			Cache["strOrderBy"] = "Supp_ID ASC";
			Session["Column"] = "Supp_ID";
			Session["Order"] = "ASC";
			initGrid();
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
				Cache["strOrderBy"]=strOrderBy;
				initGrid();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Supplier_List.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This is used to go on the selected page index.
		/// </summary>
		private void GridSearch_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				GridSearch.CurrentPageIndex =e.NewPageIndex ;
				initGrid();
				//				PartiesClass obj=new PartiesClass();
				//				DataSet ds;
				//				ds=obj.ShowSupplierInfo(txtSuppID.Text ,txtName.Text,txtPlace.Text );
				//				GridSearch.DataSource=ds;
				//				GridSearch.DataBind();
				CreateLogFiles.ErrorLog("Form:Supplier_List.aspx,Method:GridSearch_PageIndexChanged,Class:PartiesClass.cs "+uid);

			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Supplier_List.aspx,Method:GridSearch_PageIndexChanged,Class:PartiesClass.cs EXCEPTION "+ ex.Message+"  User_ID: "+uid);

			}
		}

		/// <summary>
		/// This method is used to delete the selected record from datagrid.
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
				sqlCmd.CommandText="Delete from Supplier Where Supp_ID='"+e.Item.Cells[0].Text+"'";
				sqlConn.ConnectionString=strCon;
				sqlConn.Open();
				sqlCmd.Connection=sqlConn;
				sqlCmd.ExecuteNonQuery();
				sqlCmd.Dispose();
				sqlConn.Close();
				//***********
				sqlCmd.CommandText="Delete from Ledger_Master Where Ledger_Name='"+e.Item.Cells[1].Text+"'";
				sqlConn.ConnectionString=strCon;
				sqlConn.Open();
				sqlCmd.Connection=sqlConn;
				sqlCmd.ExecuteNonQuery();
				sqlCmd.Dispose();
				sqlConn.Close();
				//***********
				MessageBox.Show("Vendor Deleted");
				initGrid();
				Response.Redirect("Supplier_List.aspx",false);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Supplier_List.aspx,Method:GridSearch_DeleteCommand,Class:PartiesClass.cs  EXCEPTION: "+ ex.Message+"  User_ID: "+uid);
			}
		}
	}
}