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

namespace EPetro.Module.PetrolPump
{
	/// <summary>
	/// Summary description for Daily_Entries.
	/// </summary>
	public class Daily_Entries : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropEntryDate;
		protected System.Web.UI.WebControls.Panel panEntry;
		string uid;
		public int EditCount=0;
		public string Remarks="";
		public ArrayList Tank = new ArrayList();
		public ArrayList Nozzle = new ArrayList();
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Daily_Entry ,Method:Page_load, EXCEPTION  "+ex.Message+", user : "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			try
			{
				if(!IsPostBack)
				{
					panEntry.Visible=false;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="5";
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
						//string msg="UnAthourized Visit to Daily Entries Page";
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					}
					#endregion
				}
				CreateLogFiles.ErrorLog("Form:Daily_Entry ,Method:Page_load,  user : "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Daily_Entry ,Method:Page_load, EXCEPTION  "+ex.Message+", user : "+uid);
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	
		/// <summary>
		/// This method is used to store all information of density from density table in arraylist
		/// </summary>
		public void FatchData()
		{
			if(DropEntryDate.SelectedIndex!=0)
			{
				SqlDataReader SqlDtr=null;
				dbobj.SelectQuery("select Density,Temprature,Converted_Density,Tank_Dip,Water_Dip,Testing,Remark from Daily_Tank_Reading d,Tank t where cast(floor(cast(cast(d.Entry_Date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(DropEntryDate.SelectedItem.Text)+"' and t.tank_id=d.tank_id order by t.prod_name",ref SqlDtr);
				while(SqlDtr.Read())
				{
					Tank.Add(GenUtil.strNumericFormat(SqlDtr.GetValue(0).ToString()));
					Tank.Add(GenUtil.strNumericFormat(SqlDtr.GetValue(1).ToString()));
					Tank.Add(GenUtil.strNumericFormat(SqlDtr.GetValue(2).ToString()));
					Tank.Add(GenUtil.strNumericFormat(SqlDtr.GetValue(3).ToString()));
					Tank.Add(GenUtil.strNumericFormat(SqlDtr.GetValue(4).ToString()));
					Tank.Add(GenUtil.strNumericFormat(SqlDtr.GetValue(5).ToString()));
					Remarks=SqlDtr.GetValue(6).ToString();
				}
				dbobj.SelectQuery("select reading from Daily_Meter_Reading d,nozzle n,machine m where cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(DropEntryDate.SelectedItem.Text)+"' and d.nozzle_id=n.nozzle_id and n.machine_id=m.machine_id order by machine_name,nozzle_name",ref SqlDtr);
				while(SqlDtr.Read())
				{
					Nozzle.Add(GenUtil.strNumericFormat(SqlDtr.GetValue(0).ToString()));
				}
			}
			else
			{
				MessageBox.Show("Please Select The Entry Date");
			}
		}
	}
}