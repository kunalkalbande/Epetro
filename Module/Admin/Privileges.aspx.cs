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

namespace EPetro.Module.Admin
{
	/// <summary>
	/// Summary description for Privileges.
	/// </summary>
	public class Privileges : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropUserID;
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.WebControls.CheckBox chkView1;
		protected System.Web.UI.WebControls.CheckBox chkAdd1;
		protected System.Web.UI.WebControls.CheckBox chkEdit1;
		protected System.Web.UI.WebControls.CheckBox chkDel1;
		protected System.Web.UI.WebControls.CheckBox chkAdd2;
		protected System.Web.UI.WebControls.CheckBox chkEdit2;
		protected System.Web.UI.WebControls.CheckBox chkDel2;
		protected System.Web.UI.WebControls.CheckBox chkDel10;
		protected System.Web.UI.WebControls.CheckBox chkEdit10;
		protected System.Web.UI.WebControls.CheckBox chkAdd10;
		protected System.Web.UI.WebControls.CheckBox chkView10;
		protected System.Web.UI.WebControls.CheckBox chkDel9;
		protected System.Web.UI.WebControls.CheckBox chkEdit9;
		protected System.Web.UI.WebControls.CheckBox chkAdd9;
		protected System.Web.UI.WebControls.CheckBox chkView9;
		protected System.Web.UI.WebControls.CheckBox chkDel8;
		protected System.Web.UI.WebControls.CheckBox chkEdit8;
		protected System.Web.UI.WebControls.CheckBox chkAdd8;
		protected System.Web.UI.WebControls.CheckBox chkDel7;
		protected System.Web.UI.WebControls.CheckBox chkEdit7;
		protected System.Web.UI.WebControls.CheckBox chkAdd7;
		protected System.Web.UI.WebControls.CheckBox chkView7;
		protected System.Web.UI.WebControls.CheckBox chkDel6;
		protected System.Web.UI.WebControls.CheckBox chkEdit6;
		protected System.Web.UI.WebControls.CheckBox chkAdd6;
		protected System.Web.UI.WebControls.CheckBox chkView6;
		protected System.Web.UI.WebControls.CheckBox chkDel5;
		protected System.Web.UI.WebControls.CheckBox chkEdit5;
		protected System.Web.UI.WebControls.CheckBox chkAdd5;
		protected System.Web.UI.WebControls.CheckBox chkView5;
		protected System.Web.UI.WebControls.CheckBox chkAccount;
		protected System.Web.UI.WebControls.CheckBox chkEmployee;
		protected System.Web.UI.WebControls.Button btnAllocate;
		protected System.Web.UI.WebControls.Panel PanelAcc;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.CheckBox chkView13;
		protected System.Web.UI.WebControls.CheckBox chkView12;
		protected System.Web.UI.WebControls.CheckBox chkView11;
		protected System.Web.UI.WebControls.CheckBox chkDel13;
		protected System.Web.UI.WebControls.CheckBox chkEdit13;
		protected System.Web.UI.WebControls.CheckBox chkAdd13;
		protected System.Web.UI.WebControls.CheckBox chkDel12;
		protected System.Web.UI.WebControls.CheckBox chkEdit12;
		protected System.Web.UI.WebControls.CheckBox chkAdd12;
		protected System.Web.UI.WebControls.CheckBox chkDel11;
		protected System.Web.UI.WebControls.CheckBox chkEdit11;
		protected System.Web.UI.WebControls.CheckBox chkAdd11;
		protected System.Web.UI.WebControls.CheckBox chkParties;
		protected System.Web.UI.WebControls.Panel PanelParties;
		protected System.Web.UI.WebControls.CheckBox chkView16;
		protected System.Web.UI.WebControls.CheckBox chkView15;
		protected System.Web.UI.WebControls.CheckBox chkView14;
		protected System.Web.UI.WebControls.CheckBox chkDel16;
		protected System.Web.UI.WebControls.CheckBox chkEdit16;
		protected System.Web.UI.WebControls.CheckBox chkAdd16;
		protected System.Web.UI.WebControls.CheckBox chkDel15;
		protected System.Web.UI.WebControls.CheckBox chkEdit15;
		protected System.Web.UI.WebControls.CheckBox chkAdd15;
		protected System.Web.UI.WebControls.CheckBox chkDel14;
		protected System.Web.UI.WebControls.CheckBox chkEdit14;
		protected System.Web.UI.WebControls.CheckBox chkAdd14;
		protected System.Web.UI.WebControls.CheckBox chkInventory;
		protected System.Web.UI.WebControls.CheckBox chkDel18;
		protected System.Web.UI.WebControls.CheckBox chkEdit18;
		protected System.Web.UI.WebControls.CheckBox chkDel17;
		protected System.Web.UI.WebControls.CheckBox chkEdit17;
		protected System.Web.UI.WebControls.CheckBox chkAdd17;
		protected System.Web.UI.WebControls.CheckBox chkView17;
		protected System.Web.UI.WebControls.Panel PanelInventory;
		protected System.Web.UI.WebControls.CheckBox chkDel22;
		protected System.Web.UI.WebControls.CheckBox chkEdit22;
		protected System.Web.UI.WebControls.CheckBox chkAdd22;
		protected System.Web.UI.WebControls.CheckBox chkView22;
		protected System.Web.UI.WebControls.CheckBox chkDel21;
		protected System.Web.UI.WebControls.CheckBox chkEdit21;
		protected System.Web.UI.WebControls.CheckBox chkView21;
		protected System.Web.UI.WebControls.CheckBox chkDel20;
		protected System.Web.UI.WebControls.CheckBox chkEdit20;
		protected System.Web.UI.WebControls.CheckBox chkAdd20;
		protected System.Web.UI.WebControls.CheckBox chkView20;
		protected System.Web.UI.WebControls.CheckBox chkDel19;
		protected System.Web.UI.WebControls.CheckBox chkEdit19;
		protected System.Web.UI.WebControls.CheckBox chkAdd19;
		protected System.Web.UI.WebControls.CheckBox chkView19;
		protected System.Web.UI.WebControls.Panel PanelPetrolpump;
		protected System.Web.UI.WebControls.CheckBox chkPetrolPump;
		protected System.Web.UI.WebControls.CheckBox chkDel23;
		protected System.Web.UI.WebControls.CheckBox chkEdit23;
		protected System.Web.UI.WebControls.CheckBox chkAdd23;
		protected System.Web.UI.WebControls.CheckBox chkView23;
		protected System.Web.UI.WebControls.Panel PanelAdmin;
		protected System.Web.UI.WebControls.CheckBox chkAdmin;
		protected System.Web.UI.WebControls.CheckBox chkView24;
		protected System.Web.UI.WebControls.CheckBox chkAdd24;
		protected System.Web.UI.WebControls.CheckBox chkEdit24;
		protected System.Web.UI.WebControls.CheckBox chkDel24;
		protected System.Web.UI.WebControls.CheckBox chkDel25;
		protected System.Web.UI.WebControls.CheckBox chkAdd25;
		protected System.Web.UI.WebControls.CheckBox chkView25;
		protected System.Web.UI.WebControls.CheckBox chkDel27;
		protected System.Web.UI.WebControls.CheckBox chkEdit27;
		protected System.Web.UI.WebControls.CheckBox chkAdd27;
		protected System.Web.UI.WebControls.CheckBox chkView27;
		protected System.Web.UI.WebControls.CheckBox chkView28;
		protected System.Web.UI.WebControls.CheckBox chkAdd28;
		protected System.Web.UI.WebControls.CheckBox chkDel28;
		protected System.Web.UI.WebControls.CheckBox chkEdit29;
		protected System.Web.UI.WebControls.CheckBox chkAdd29;
		protected System.Web.UI.WebControls.CheckBox chkView29;
		protected System.Web.UI.WebControls.CheckBox chkView30;
		protected System.Web.UI.WebControls.CheckBox chkAdd30;
		protected System.Web.UI.WebControls.CheckBox chkEdit30;
		protected System.Web.UI.WebControls.CheckBox chkDel30;
		protected System.Web.UI.WebControls.CheckBox chkDel31;
		protected System.Web.UI.WebControls.CheckBox chkEdit31;
		protected System.Web.UI.WebControls.CheckBox chkAdd31;
		protected System.Web.UI.WebControls.CheckBox chkView31;
		protected System.Web.UI.WebControls.CheckBox chkView32;
		protected System.Web.UI.WebControls.CheckBox chkAdd32;
		protected System.Web.UI.WebControls.CheckBox chkEdit32;
		protected System.Web.UI.WebControls.CheckBox chkDel32;
		protected System.Web.UI.WebControls.CheckBox chkDel33;
		protected System.Web.UI.WebControls.CheckBox chkEdit33;
		protected System.Web.UI.WebControls.CheckBox chkAdd33;
		protected System.Web.UI.WebControls.CheckBox chkView33;
		protected System.Web.UI.WebControls.CheckBox chkView34;
		protected System.Web.UI.WebControls.CheckBox chkAdd34;
		protected System.Web.UI.WebControls.CheckBox chkEdit34;
		protected System.Web.UI.WebControls.CheckBox chkDel34;
		protected System.Web.UI.WebControls.CheckBox chkDel39;
		protected System.Web.UI.WebControls.CheckBox chkDel38;
		protected System.Web.UI.WebControls.CheckBox chkDel37;
		protected System.Web.UI.WebControls.CheckBox chkDel36;
		protected System.Web.UI.WebControls.CheckBox chkDel35;
		protected System.Web.UI.WebControls.CheckBox chkAdd35;
		protected System.Web.UI.WebControls.CheckBox chkEdit35;
		protected System.Web.UI.WebControls.CheckBox chkEdit36;
		protected System.Web.UI.WebControls.CheckBox chkEdit37;
		protected System.Web.UI.WebControls.CheckBox chkEdit38;
		protected System.Web.UI.WebControls.CheckBox chkEdit39;
		protected System.Web.UI.WebControls.CheckBox chkView35;
		protected System.Web.UI.WebControls.CheckBox chkView37;
		protected System.Web.UI.WebControls.CheckBox chkView36;
		protected System.Web.UI.WebControls.CheckBox chkAdd36;
		protected System.Web.UI.WebControls.CheckBox chkAdd37;
		protected System.Web.UI.WebControls.CheckBox chkAdd38;
		protected System.Web.UI.WebControls.CheckBox chkView38;
		protected System.Web.UI.WebControls.CheckBox chkView39;
		protected System.Web.UI.WebControls.CheckBox chkAdd39;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.Panel PanelEmp;
		protected System.Web.UI.WebControls.CheckBox chkView8;
		protected System.Web.UI.WebControls.CheckBox chkView18;
		protected System.Web.UI.WebControls.CheckBox chkAdd18;
		protected System.Web.UI.WebControls.CheckBox chkEdit25;
		protected System.Web.UI.WebControls.CheckBox chkEdit28;
		protected System.Web.UI.WebControls.CheckBox chkDel29;
		protected System.Web.UI.WebControls.CheckBox chkView40;
		protected System.Web.UI.WebControls.CheckBox chkAdd40;
		protected System.Web.UI.WebControls.CheckBox chkEdit40;
		protected System.Web.UI.WebControls.CheckBox chkDel40;
		protected System.Web.UI.WebControls.CheckBox chkView41;
		protected System.Web.UI.WebControls.CheckBox chkAdd41;
		protected System.Web.UI.WebControls.CheckBox chkEdit41;
		protected System.Web.UI.WebControls.CheckBox chkDel41;
		protected System.Web.UI.WebControls.CheckBox chkView42;
		protected System.Web.UI.WebControls.CheckBox chkAdd42;
		protected System.Web.UI.WebControls.CheckBox chkEdit42;
		protected System.Web.UI.WebControls.CheckBox chkDel42;
		protected System.Web.UI.WebControls.CheckBox chkView43;
		protected System.Web.UI.WebControls.CheckBox chkAdd43;
		protected System.Web.UI.WebControls.CheckBox chkEdit43;
		protected System.Web.UI.WebControls.CheckBox chkDel43;
		protected System.Web.UI.WebControls.CheckBox chkAdd21;
		protected System.Web.UI.WebControls.CheckBox chkView3;
		protected System.Web.UI.WebControls.CheckBox chkAdd3;
		protected System.Web.UI.WebControls.CheckBox chkEdit3;
		protected System.Web.UI.WebControls.CheckBox chkDel3;
		protected System.Web.UI.WebControls.CheckBox chkView4;
		protected System.Web.UI.WebControls.CheckBox chkAdd4;
		protected System.Web.UI.WebControls.CheckBox chkEdit4;
		protected System.Web.UI.WebControls.CheckBox chkDel4;
		protected System.Web.UI.WebControls.CheckBox chkView44;
		protected System.Web.UI.WebControls.CheckBox chkAdd44;
		protected System.Web.UI.WebControls.CheckBox chkEdit44;
		protected System.Web.UI.WebControls.CheckBox chkDel44;
		protected System.Web.UI.WebControls.CheckBox checkLogistics;
		protected System.Web.UI.WebControls.CheckBox chkView45;
		protected System.Web.UI.WebControls.CheckBox chkAdd45;
		protected System.Web.UI.WebControls.CheckBox chkEdit45;
		protected System.Web.UI.WebControls.CheckBox chkDel45;
		protected System.Web.UI.WebControls.CheckBox chkView46;
		protected System.Web.UI.WebControls.CheckBox chkAdd46;
		protected System.Web.UI.WebControls.CheckBox chkEdit46;
		protected System.Web.UI.WebControls.CheckBox chkDel46;
		protected System.Web.UI.WebControls.CheckBox chkView47;
		protected System.Web.UI.WebControls.CheckBox chkAdd47;
		protected System.Web.UI.WebControls.CheckBox chkEdit47;
		protected System.Web.UI.WebControls.CheckBox chkDel47;
		protected System.Web.UI.WebControls.Panel panelLogistics;
		protected System.Web.UI.WebControls.CheckBox chkView48;
		protected System.Web.UI.WebControls.CheckBox chkView49;
		protected System.Web.UI.WebControls.CheckBox chkView50;
		protected System.Web.UI.WebControls.CheckBox chkView51;
		protected System.Web.UI.WebControls.CheckBox chkView52;
		protected System.Web.UI.WebControls.CheckBox chkView53;
		protected System.Web.UI.WebControls.CheckBox chkView54;
		protected System.Web.UI.WebControls.CheckBox chkAdd48;
		protected System.Web.UI.WebControls.CheckBox chkEdit48;
		protected System.Web.UI.WebControls.CheckBox chkDel48;
		protected System.Web.UI.WebControls.CheckBox chkAdd49;
		protected System.Web.UI.WebControls.CheckBox chkEdit49;
		protected System.Web.UI.WebControls.CheckBox chkDel49;
		protected System.Web.UI.WebControls.CheckBox chkAdd50;
		protected System.Web.UI.WebControls.CheckBox chkEdit50;
		protected System.Web.UI.WebControls.CheckBox chkDel50;
		protected System.Web.UI.WebControls.CheckBox chkAdd51;
		protected System.Web.UI.WebControls.CheckBox chkEdit51;
		protected System.Web.UI.WebControls.CheckBox chkDel51;
		protected System.Web.UI.WebControls.CheckBox chkAdd52;
		protected System.Web.UI.WebControls.CheckBox chkEdit52;
		protected System.Web.UI.WebControls.CheckBox chkDel52;
		protected System.Web.UI.WebControls.CheckBox chkAdd53;
		protected System.Web.UI.WebControls.CheckBox chkEdit53;
		protected System.Web.UI.WebControls.CheckBox chkDel53;
		protected System.Web.UI.WebControls.CheckBox chkAdd54;
		protected System.Web.UI.WebControls.CheckBox chkEdit54;
		protected System.Web.UI.WebControls.CheckBox chkDel54;
		protected System.Web.UI.WebControls.CheckBox chkView55;
		protected System.Web.UI.WebControls.CheckBox chkAdd55;
		protected System.Web.UI.WebControls.CheckBox chkEdit55;
		protected System.Web.UI.WebControls.CheckBox chkDel55;
		protected System.Web.UI.WebControls.CheckBox chkView56;
		protected System.Web.UI.WebControls.CheckBox chkAdd56;
		protected System.Web.UI.WebControls.CheckBox chkEdit56;
		protected System.Web.UI.WebControls.CheckBox chkDel56;
		protected System.Web.UI.WebControls.CheckBox chkAdd57;
		protected System.Web.UI.WebControls.CheckBox chkEdit57;
		protected System.Web.UI.WebControls.CheckBox chkDel57;
		protected System.Web.UI.WebControls.CheckBox chkView58;
		protected System.Web.UI.WebControls.CheckBox chkAdd58;
		protected System.Web.UI.WebControls.CheckBox chkEdit58;
		protected System.Web.UI.WebControls.CheckBox chkDel58;
		protected System.Web.UI.WebControls.CheckBox chkView59;
		protected System.Web.UI.WebControls.CheckBox chkAdd59;
		protected System.Web.UI.WebControls.CheckBox chkEdit59;
		protected System.Web.UI.WebControls.CheckBox chkDel59;
		protected System.Web.UI.WebControls.CheckBox chkView60;
		protected System.Web.UI.WebControls.CheckBox chkAdd60;
		protected System.Web.UI.WebControls.CheckBox chkEdit60;
		protected System.Web.UI.WebControls.CheckBox chkDel60;
		protected System.Web.UI.WebControls.CheckBox chkView61;
		protected System.Web.UI.WebControls.CheckBox chkAdd61;
		protected System.Web.UI.WebControls.CheckBox chkEdit61;
		protected System.Web.UI.WebControls.CheckBox chkDel61;
		protected System.Web.UI.WebControls.CheckBox chkAdd62;
		protected System.Web.UI.WebControls.CheckBox chkView57;
		protected System.Web.UI.WebControls.CheckBox chkView62;
		protected System.Web.UI.WebControls.CheckBox chkEdit62;
		protected System.Web.UI.WebControls.CheckBox chkDel62;
		protected System.Web.UI.WebControls.CheckBox chkView63;
		protected System.Web.UI.WebControls.CheckBox chkAdd63;
		protected System.Web.UI.WebControls.CheckBox chkEdit63;
		protected System.Web.UI.WebControls.CheckBox chkDel63;
		protected System.Web.UI.WebControls.CheckBox chkAdd26;
		protected System.Web.UI.WebControls.CheckBox chkEdit26;
		protected System.Web.UI.WebControls.CheckBox chkDel26;
		protected System.Web.UI.WebControls.CheckBox chkView2;
		protected System.Web.UI.WebControls.CheckBox chkView26;
		protected System.Web.UI.WebControls.CheckBox chkView64;
		protected System.Web.UI.WebControls.CheckBox chkAdd64;
		protected System.Web.UI.WebControls.CheckBox chkEdit64;
		protected System.Web.UI.WebControls.CheckBox chkDel64;
		protected System.Web.UI.WebControls.CheckBox chkView65;
		protected System.Web.UI.WebControls.CheckBox chkAdd65;
		protected System.Web.UI.WebControls.CheckBox chkEdit65;
		protected System.Web.UI.WebControls.CheckBox chkDel65;
		protected System.Web.UI.WebControls.CheckBox chkView66;
		protected System.Web.UI.WebControls.CheckBox chkAdd66;
		protected System.Web.UI.WebControls.CheckBox chkEdit66;
		protected System.Web.UI.WebControls.CheckBox chkDel66;
		protected System.Web.UI.WebControls.CheckBox chkView67;
		protected System.Web.UI.WebControls.CheckBox chkAdd67;
		protected System.Web.UI.WebControls.CheckBox chkEdit67;
		protected System.Web.UI.WebControls.CheckBox chkDel67;
		protected System.Web.UI.WebControls.CheckBox chkView68;
		protected System.Web.UI.WebControls.CheckBox chkAdd68;
		protected System.Web.UI.WebControls.CheckBox chkEdit68;
		protected System.Web.UI.WebControls.CheckBox chkDel68;
		protected System.Web.UI.WebControls.CheckBox chkView69;
		protected System.Web.UI.WebControls.CheckBox chkAdd69;
		protected System.Web.UI.WebControls.CheckBox chkEdit69;
		protected System.Web.UI.WebControls.CheckBox chkDel69;
		protected System.Web.UI.WebControls.CheckBox chkView70;
		protected System.Web.UI.WebControls.CheckBox chkAdd70;
		protected System.Web.UI.WebControls.CheckBox chkEdit70;
		protected System.Web.UI.WebControls.CheckBox chkDel70;
		protected System.Web.UI.WebControls.CheckBox chkView71;
		protected System.Web.UI.WebControls.CheckBox chkAdd71;
		protected System.Web.UI.WebControls.CheckBox chkEdit71;
		protected System.Web.UI.WebControls.CheckBox chkDel71;
		protected System.Web.UI.WebControls.CheckBox chkView72;
		protected System.Web.UI.WebControls.CheckBox chkAdd72;
		protected System.Web.UI.WebControls.CheckBox chkEdit72;
		protected System.Web.UI.WebControls.CheckBox chkDel72;
		protected System.Web.UI.WebControls.CheckBox chkView73;
		protected System.Web.UI.WebControls.CheckBox chkAdd73;
		protected System.Web.UI.WebControls.CheckBox chkEdit73;
		protected System.Web.UI.WebControls.CheckBox chkDel73;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{ 
				uid=(Session["User_Name"].ToString ());
				CreateLogFiles.ErrorLog("Form:Privileges.aspx,Method:Page_load    userid  "+uid  );	
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Privileges.aspx,Method:Page_load   EXCEPTION:  "+ex.Message+" userid  "+uid  );
				Response.Redirect("ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				#region Check Privileges if user id admin then grant the access
				if(Session["User_ID"].ToString ()!="1001")
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				#endregion

				EmployeeClass obj=new EmployeeClass();
				SqlDataReader SqlDtr; 
				string sql;
				try
				{
					#region Fetch All Users Information
					sql="select LoginName from User_Master order by LoginName";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropUserID.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					SqlDtr.Close();
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Privileges.aspx,Method:Page_load   EXCEPTION:  "+ex.Message+" userid  "+uid  );
				}
				btnAllocate.Visible=false;
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
			this.DropUserID.SelectedIndexChanged += new System.EventHandler(this.DropUserID_SelectedIndexChanged);
			this.chkAccount.CheckedChanged += new System.EventHandler(this.chkAccount_CheckedChanged);
			this.chkEmployee.CheckedChanged += new System.EventHandler(this.chkEmployee_CheckedChanged);
			this.chkParties.CheckedChanged += new System.EventHandler(this.chkParties_CheckedChanged);
			this.chkInventory.CheckedChanged += new System.EventHandler(this.chkInventory_CheckedChanged);
			this.chkPetrolPump.CheckedChanged += new System.EventHandler(this.chkPetrolPump_CheckedChanged);
			this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
			this.checkLogistics.CheckedChanged += new System.EventHandler(this.checkLogistics_CheckedChanged);
			this.btnAllocate.Click += new System.EventHandler(this.btnAllocate_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// This method is used to fatch and putting the value from database according to select user id from dropdownlist.
		/// </summary>
		private void DropUserID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int a=0;
			int Modules=7;
			int[] SubModules={5,8,6,9,4,38,3};
			CheckBox[] ChkView={chkView1, chkView2, chkView3, chkView4, chkView61, chkView5, chkView6, chkView7, chkView8, chkView9, chkView10, chkView11, chkView12, chkView13, chkView14, chkView15, chkView16, chkView17, chkView18, chkView19, chkView20, chkView21, chkView22, chkView23, chkView24, chkView25, chkView26, chkView64, chkView27, chkView28, chkView29, chkView30, chkView31, chkView32, chkView33, chkView34, chkView35, chkView36, chkView37, chkView38, chkView39, chkView40, chkView41,chkView42,chkView43,chkView44,chkView45,chkView46,chkView47,chkView48,chkView49,chkView50,chkView51,chkView52,chkView53,chkView54,chkView55,chkView56,chkView57,chkView62,chkView63,chkView65,chkView66,chkView67,chkView68,chkView69,chkView70,chkView71,chkView72,chkView73,chkView58,chkView59,chkView60};
			CheckBox[] ChkAdd={chkAdd1, chkAdd2, chkAdd3, chkAdd4, chkAdd61, chkAdd5, chkAdd6, chkAdd7, chkAdd8, chkAdd9, chkAdd10, chkAdd11, chkAdd12, chkAdd13, chkAdd14, chkAdd15, chkAdd16, chkAdd17, chkAdd18, chkAdd19, chkAdd20, chkAdd21, chkAdd22, chkAdd23, chkAdd24, chkAdd25, chkAdd26, chkAdd64, chkAdd27, chkAdd28, chkAdd29, chkAdd30, chkAdd31, chkAdd32, chkAdd33, chkAdd34, chkAdd35, chkAdd36, chkAdd37, chkAdd38, chkAdd39, chkAdd40, chkAdd41,chkAdd42,chkAdd43,chkAdd44,chkAdd45,chkAdd46,chkAdd47,chkAdd48,chkAdd49,chkAdd50,chkAdd51,chkAdd52,chkAdd53,chkAdd54,chkAdd55,chkAdd56,chkAdd57,chkAdd62,chkAdd63,chkAdd65,chkAdd66,chkAdd67,chkAdd68,chkAdd69,chkAdd70,chkAdd71,chkAdd72,chkAdd73,chkAdd58,chkAdd59,chkAdd60};
			CheckBox[] ChkEdit={chkEdit1, chkEdit2, chkEdit3, chkEdit4, chkEdit61, chkEdit5, chkEdit6, chkEdit7, chkEdit8, chkEdit9, chkEdit10, chkEdit11, chkEdit12, chkEdit13, chkEdit14, chkEdit15, chkEdit16, chkEdit17, chkEdit18, chkEdit19, chkEdit20, chkEdit21, chkEdit22, chkEdit23, chkEdit24, chkEdit25, chkEdit26, chkEdit64, chkEdit27, chkEdit28, chkEdit29, chkEdit30, chkEdit31, chkEdit32, chkEdit33, chkEdit34, chkEdit35, chkEdit36, chkEdit37, chkEdit38, chkEdit39, chkEdit40, chkEdit41,chkEdit42,chkEdit43,chkEdit44,chkEdit45,chkEdit46,chkEdit47,chkEdit48,chkEdit49,chkEdit50,chkEdit51,chkEdit52,chkEdit53,chkEdit54,chkEdit55,chkEdit56,chkEdit57,chkEdit62,chkEdit63,chkEdit65,chkEdit66,chkEdit67,chkEdit68,chkEdit69,chkEdit70,chkEdit71,chkEdit72,chkEdit73,chkEdit58,chkEdit59,chkEdit60};
			CheckBox[] ChkDel={chkDel1, chkDel2, chkDel3, chkDel4, chkDel61, chkDel5, chkDel6, chkDel7, chkDel8, chkDel9, chkDel10, chkDel11, chkDel12, chkDel13, chkDel14, chkDel15, chkDel16, chkDel17, chkDel18, chkDel19, chkDel20, chkDel21, chkDel22, chkDel23, chkDel24, chkDel25, chkDel26, chkDel64, chkDel27, chkDel28, chkDel29, chkDel30, chkDel31, chkDel32, chkDel33, chkDel34, chkDel35, chkDel36, chkDel37, chkDel38, chkDel39, chkDel40, chkDel41,chkDel42,chkDel43,chkDel44,chkDel45,chkDel46,chkDel47,chkDel48,chkDel49,chkDel50,chkDel51,chkDel52,chkDel53,chkDel54,chkDel55,chkDel56,chkDel57,chkDel62,chkDel63,chkDel65,chkDel66,chkDel67,chkDel68,chkDel69,chkDel70,chkDel71,chkDel72,chkDel73,chkDel58,chkDel59,chkDel60};

			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr; 
			string sql;
			try
			{

				#region Fetch User Name of Selected User
				string Userid="";
				sql="select UserID,UserName from User_Master where LoginName='"+DropUserID.SelectedItem.Value +"'";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					Userid=SqlDtr.GetValue(0).ToString(); 
					txtUserName.Text=SqlDtr.GetValue(1).ToString(); 
				}
				SqlDtr.Close();
				#endregion

				#region Fetch Privileges of the Selected User
				ClearCheckBox();
				sql="select * from privileges where User_ID='"+ Userid +"'";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{	
					a=0;

					PanelAcc.Visible=true;
					PanelEmp.Visible=true; 
					PanelParties.Visible=true;
					PanelInventory.Visible=true;
					PanelPetrolpump.Visible=true;
					PanelAdmin.Visible=true; 
					panelLogistics.Visible = true;  
					// means Main module
					for(int i=1;i<=Modules;i++)
					{
						//means page 
						for(int j=1;j<=SubModules[i-1];j++)
						{
							if((i==System.Convert.ToInt32(SqlDtr.GetValue(1)))&&(j==System.Convert.ToInt32(SqlDtr.GetValue(2))))
							{
								if(SqlDtr.GetValue(3).ToString()=="1")
									ChkView[a].Checked=true;
								else
									ChkView[a].Checked=false;
								if(SqlDtr.GetValue(4).ToString()=="1")
									ChkAdd[a].Checked=true;
								else
									ChkAdd[a].Checked=false;
								if(SqlDtr.GetValue(5).ToString()=="1")
									ChkEdit[a].Checked=true;
								else
									ChkEdit[a].Checked=false;
								if(SqlDtr.GetValue(6).ToString()=="1")
									ChkDel[a].Checked=true;
								else
									ChkDel[a].Checked=false;
							}
							a++;
						}
					}
				}
				SqlDtr.Close();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Privileges.aspx,Method:DropUserID_SelectedIndexChanged   EXCEPTION:  "+ex.Message+" userid  "+uid  );
			}
		}

		/// <summary>
		/// This method is used to unchecked the all checkboxes.
		/// </summary>
		public void ClearCheckBox()
		{
			foreach(Control ctl in Page.Controls)
			{
				foreach (Control childctl in ctl.Controls)
				{
					if(childctl is CheckBox)
					{
						((CheckBox)childctl).Checked=false;
					}
				}
			}
			foreach(Control ctl in PanelAcc.Controls)
			{
				if(ctl is CheckBox)
				{
					((CheckBox)ctl).Checked=false;
				}
			}
			foreach(Control ctl in PanelEmp.Controls)
			{
				if(ctl is CheckBox)
				{
					((CheckBox)ctl).Checked=false;
				}
			}
			foreach(Control ctl in PanelParties.Controls)
			{
				if(ctl is CheckBox)
				{
					((CheckBox)ctl).Checked=false;
				}
			}
			foreach(Control ctl in PanelInventory.Controls)
			{
				if(ctl is CheckBox)
				{
					((CheckBox)ctl).Checked=false;
				}
			}
			foreach(Control ctl in PanelPetrolpump.Controls)
			{
				if(ctl is CheckBox)
				{
					((CheckBox)ctl).Checked=false;
				}
			}
			foreach(Control ctl in panelLogistics.Controls)
			{
				if(ctl is CheckBox)
				{
					((CheckBox)ctl).Checked=false;
				}
			}
		}

		/// <summary>
		/// This method is used to reset the form.
		/// </summary>
		public void Clear()
		{
			DropUserID.SelectedIndex=0;
			txtUserName.Text="";
			ClearCheckBox();
			PanelAcc.Visible=false;
			PanelEmp.Visible=false;
			PanelParties.Visible=false;
			PanelInventory.Visible=false;
			PanelPetrolpump.Visible=false;
			PanelAdmin.Visible=false; 
			panelLogistics.Visible = false; 
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		private void btnAllocate_Click(object sender, System.EventArgs e)
		{
			if(chkAccount.Checked)
				PanelAcc.Visible=true;
			else
				PanelAcc.Visible=false;
			if(chkEmployee.Checked)
				PanelEmp.Visible=true; 
			else
				PanelEmp.Visible=false; 
			if(chkParties.Checked)
				PanelParties.Visible=true; 
			else
				PanelParties.Visible=false; 
			if(chkInventory.Checked)
				PanelInventory.Visible=true; 
			else
				PanelInventory.Visible=false; 
			if(chkPetrolPump.Checked)
				PanelPetrolpump.Visible=true; 
			else
				PanelPetrolpump.Visible=false; 
			if(chkPetrolPump.Checked)
				PanelAdmin.Visible=true; 
			else
				PanelAdmin.Visible=false; 

			if(checkLogistics.Checked)
				panelLogistics.Visible = true;
			else
				panelLogistics.Visible = false;
		}

		/// <summary>
		/// This method is used to Insert the all values in the database.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(DropUserID.SelectedIndex==0)
			{
				MessageBox.Show("Please select the User Name");
				return;
			}
			
			EmployeeClass obj=new EmployeeClass();
			int Modules=7;
			int a=0;
			int[] SubModules={5,8,6,9,4,38,3};
			CheckBox[] ChkView={chkView1, chkView2, chkView3, chkView4, chkView61, chkView5, chkView6, chkView7, chkView8, chkView9, chkView10, chkView11, chkView12, chkView13, chkView14, chkView15, chkView16, chkView17, chkView18, chkView19, chkView20, chkView21, chkView22, chkView23, chkView24, chkView25, chkView26, chkView64, chkView27, chkView28, chkView29, chkView30, chkView31, chkView32, chkView33, chkView34, chkView35, chkView36, chkView37, chkView38, chkView39, chkView40, chkView41,chkView42,chkView43,chkView44,chkView45,chkView46,chkView47,chkView48,chkView49,chkView50,chkView51,chkView52,chkView53,chkView54,chkView55,chkView56,chkView57,chkView62,chkView63,chkView65,chkView66,chkView67,chkView68,chkView69,chkView70,chkView71,chkView72,chkView73,chkView58,chkView59,chkView60};
			CheckBox[] ChkAdd={chkAdd1, chkAdd2, chkAdd3, chkAdd4, chkAdd61, chkAdd5, chkAdd6, chkAdd7, chkAdd8, chkAdd9, chkAdd10, chkAdd11, chkAdd12, chkAdd13, chkAdd14, chkAdd15, chkAdd16, chkAdd17, chkAdd18, chkAdd19, chkAdd20, chkAdd21, chkAdd22, chkAdd23, chkAdd24, chkAdd25, chkAdd26, chkAdd64, chkAdd27, chkAdd28, chkAdd29, chkAdd30, chkAdd31, chkAdd32, chkAdd33, chkAdd34, chkAdd35, chkAdd36, chkAdd37, chkAdd38, chkAdd39, chkAdd40, chkAdd41,chkAdd42,chkAdd43,chkAdd44,chkAdd45,chkAdd46,chkAdd47,chkAdd48,chkAdd49,chkAdd50,chkAdd51,chkAdd52,chkAdd53,chkAdd54,chkAdd55,chkAdd56,chkAdd57,chkAdd62,chkAdd63,chkAdd65,chkAdd66,chkAdd67,chkAdd68,chkAdd69,chkAdd70,chkAdd71,chkAdd72,chkAdd73,chkAdd58,chkAdd59,chkAdd60};
			CheckBox[] ChkEdit={chkEdit1, chkEdit2, chkEdit3, chkEdit4, chkEdit61, chkEdit5, chkEdit6, chkEdit7, chkEdit8, chkEdit9, chkEdit10, chkEdit11, chkEdit12, chkEdit13, chkEdit14, chkEdit15, chkEdit16, chkEdit17, chkEdit18, chkEdit19, chkEdit20, chkEdit21, chkEdit22, chkEdit23, chkEdit24, chkEdit25, chkEdit26, chkEdit64, chkEdit27, chkEdit28, chkEdit29, chkEdit30, chkEdit31, chkEdit32, chkEdit33, chkEdit34, chkEdit35, chkEdit36, chkEdit37, chkEdit38, chkEdit39, chkEdit40, chkEdit41,chkEdit42,chkEdit43,chkEdit44,chkEdit45,chkEdit46,chkEdit47,chkEdit48,chkEdit49,chkEdit50,chkEdit51,chkEdit52,chkEdit53,chkEdit54,chkEdit55,chkEdit56,chkEdit57,chkEdit62,chkEdit63,chkEdit65,chkEdit66,chkEdit67,chkEdit68,chkEdit69,chkEdit70,chkEdit71,chkEdit72,chkEdit73,chkEdit58,chkEdit59,chkEdit60};
			CheckBox[] ChkDel={chkDel1, chkDel2, chkDel3, chkDel4, chkDel61, chkDel5, chkDel6, chkDel7, chkDel8, chkDel9, chkDel10, chkDel11, chkDel12, chkDel13, chkDel14, chkDel15, chkDel16, chkDel17, chkDel18, chkDel19, chkDel20, chkDel21, chkDel22, chkDel23, chkDel24, chkDel25, chkDel26, chkDel64, chkDel27, chkDel28, chkDel29, chkDel30, chkDel31, chkDel32, chkDel33, chkDel34, chkDel35, chkDel36, chkDel37, chkDel38, chkDel39, chkDel40, chkDel41,chkDel42,chkDel43,chkDel44,chkDel45,chkDel46,chkDel47,chkDel48,chkDel49,chkDel50,chkDel51,chkDel52,chkDel53,chkDel54,chkDel55,chkDel56,chkDel57,chkDel62,chkDel63,chkDel65,chkDel66,chkDel67,chkDel68,chkDel69,chkDel70,chkDel71,chkDel72,chkDel73,chkDel58,chkDel59,chkDel60};
			try
			{
				for(int i=0;i<Modules;i++)
				{
					for(int j=0;j<SubModules[i];j++)
					{
						obj.Login_Name=DropUserID.SelectedItem.Value;
						obj.Module_ID=System.Convert.ToString(i+1);
						obj.SubModule_ID=System.Convert.ToString(j+1);
						
						if(ChkView[a].Checked)
							obj.View_Flag="1";
						else
							obj.View_Flag="0";
						if(ChkAdd[a].Checked)
							obj.Add_Flag="1";
						else
							obj.Add_Flag="0";
						if(ChkEdit[a].Checked)
							obj.Edit_Flag="1";
						else
							obj.Edit_Flag="0";
						if(ChkDel[a].Checked)
							obj.Del_Flag="1";
						else
							obj.Del_Flag="0";
						obj.InsertPriveleges();
						a++;
					}
				}
				CreateLogFiles.ErrorLog("Form:Privileges.aspx,Method:btnSave_Click  Privilegs of User  "+obj.Login_Name +" Updated.  "+uid  );
				MessageBox.Show("Privileges Allocated");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Privileges.aspx,Method:btnSave_Click   EXCEPTION:  "+ex.Message+" userid  "+uid  );
			}
		}

		/// <summary>
		/// This method is used to if the Account check box is checked then display the coressponding 
		/// panel and checks all the check box.
		/// </summary>
		private void chkAccount_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkAccount.Checked)
			{
				PanelAcc.Visible=true; 
				foreach(Control ctl in PanelAcc.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=true;
					}
				}
			}
			else
			{
				PanelAcc.Visible=false;
				foreach(Control ctl in PanelAcc.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=false;
					}
				}
			}
		}

		/// <summary>
		/// if the employee check box is checked then display the coressponding panel and checks all the check box.
		/// </summary>
		private void chkEmployee_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkEmployee.Checked)
			{
				PanelEmp.Visible=true;
				foreach(Control ctl in PanelEmp.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=true;
					}
				}
			}
			else
			{
				PanelEmp.Visible=false;
				foreach(Control ctl in PanelEmp.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=false;
					}
				}
			}
		}

		/// <summary>
		/// if the Parties check box is checked then display the coressponding panel and checks all the check box.
		/// </summary>
		private void chkParties_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkParties.Checked)
			{
				PanelParties.Visible=true;
				foreach(Control ctl in PanelParties.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=true;
					}
				}
				
			}
			else
			{
				PanelParties.Visible=false;
				foreach(Control ctl in PanelParties.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=false;
					}
				}
			}
		}

		/// <summary>
		/// if the Inventory check box is checked then display the coressponding panel and checks all the check box.
		/// </summary>
		private void chkInventory_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkInventory.Checked)
			{
				PanelInventory.Visible=true;
				foreach(Control ctl in PanelInventory.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=true;
					}
				}
			}
			else
			{
				PanelInventory.Visible=false;
				foreach(Control ctl in PanelInventory.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=false;
					}
				}
			}
		}

		/// <summary>
		/// if the Petrol Pump check box is checked then display the coressponding panel and checks all the check box.
		/// </summary>
		private void chkPetrolPump_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkPetrolPump.Checked)
			{
				PanelPetrolpump.Visible=true;
				foreach(Control ctl in PanelPetrolpump.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=true;
					}
				}
			}
			else
			{
				PanelPetrolpump.Visible=false;
				foreach(Control ctl in PanelPetrolpump.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=false;
					}
				}
			}
		}

		/// <summary>
		/// if the admin check box is checked then display the coressponding panel and checks all the check box.
		/// </summary>
		private void chkAdmin_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkAdmin.Checked)
			{
				PanelAdmin.Visible=true;
				foreach(Control ctl in PanelAdmin.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=true;
					}
				}
			}
			else
			{
				PanelAdmin.Visible=false;
				foreach(Control ctl in PanelAdmin.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=false;
					}
				}
			}
		}

		/// <summary>
		/// if the logistics check box is checked then display the coressponding panel and checks all the check box.
		/// </summary>
		private void checkLogistics_CheckedChanged(object sender, System.EventArgs e)
		{
			if(checkLogistics.Checked)
			{
				panelLogistics.Visible=true;
				foreach(Control ctl in panelLogistics.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=true;
					}
				}
			}
			else
			{
				panelLogistics.Visible=false;
				foreach(Control ctl in panelLogistics.Controls)
				{
					if(ctl is CheckBox)
					{
						((CheckBox)ctl).Checked=false;
					}
				}
			}
		}
	}
}