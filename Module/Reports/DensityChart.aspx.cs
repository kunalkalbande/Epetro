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
using EPetro.Sysitem.Classes;
using System.Data.SqlClient;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using RMG;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for DencityReport.
	/// </summary>
	public class DencityReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Btnprint;
		protected System.Web.UI.WebControls.DataGrid GriddenReport;
		string uid;
		string strOrderBy="";

		/// <summary>
		/// This method is used for setting the Session variable for userId
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
				CreateLogFiles.ErrorLog("Form:DencityReport.aspx,Method:pageload"+ ex.Message+ "  EXCEPTION, User :" +uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="28";
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
				if(View_flag=="0")
				{
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
				CreateLogFiles.ErrorLog("Form:DencityReport.aspx,Method:pageload, User :" +uid);
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to call the  BindTheData() function for prepare the report.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				strOrderBy = "temp1 ASC";
				Session["Column"] = "temp1";
				Session["Order"] = "ASC";
				BindTheData();
				//				PetrolPumpClass  obj=new PetrolPumpClass();
				//				SqlDataReader SqlDtr;
				//				string sql;
				//				// select the machines and bind the data grid.
				//				sql="select * from Density_con_table";
				//				SqlDtr =obj.GetRecordSet(sql);
				//				GriddenReport.DataSource=SqlDtr;
				//				GriddenReport.DataBind();
				//				SqlDtr.Close();
				CreateLogFiles.ErrorLog("Form:DencityReport.aspx,Method:Button1_Click" +"  Dencity Report Viewed  "+" userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:DencityReport.aspx,Method: Button1_Click " +"  ,  "+ ex.Message+"  EXCEPTION  " +" userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select * from Density_con_table";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "Density_con_table");
			DataTable dtCustomers = ds.Tables["Density_con_table"];

			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			if(dv.Count!=0)
			{
				GriddenReport.DataSource = dv;
				GriddenReport.DataBind();
			}
			else
			{
				MessageBox.Show("Data not available");
				GriddenReport.Visible=false;
			}
			SqlCon.Dispose();
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
				CreateLogFiles.ErrorLog("Form:DensityReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}
	}
}