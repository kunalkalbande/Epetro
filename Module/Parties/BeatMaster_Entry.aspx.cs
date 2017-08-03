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
using DBOperations;

namespace EPetro.Module.Parties
{
	/// <summary>
	/// Summary description for BeatMaster_Entry.
	/// </summary>
	public class BeatMaster_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBeatNo;
		protected System.Web.UI.WebControls.DropDownList DropBeatNo;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		protected System.Web.UI.WebControls.Button Edit1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{ 
			FillID();
			if(!Page.IsPostBack)
			{
				Edit1.Visible=false;
			}
			try
			{
				uid=(Session["User_Name"].ToString());
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx ,Method:pageload"+"  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx,Method:pageload"+"  EXCEPTION "+ ex.Message+"  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				checkPrevileges();
			}
		}

		/// <summary>
		/// This method checks the user privileges from session.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="3";
			string SubModule="1";
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
			if(Add_Flag=="0" && Edit_Flag=="0" && Del_Flag=="0")
			{
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}
			if(Add_Flag=="0")
				btnSave.Enabled=false;
			if(Edit_Flag=="0")
				btnEdit.Enabled=false;
			if(Del_Flag=="0")
				btnDelete.Enabled=false;
			#endregion
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
			this.DropBeatNo.SelectedIndexChanged += new System.EventHandler(this.DropBeatNo_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.Edit1.Click += new System.EventHandler(this.Edit1_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is not used.
		/// </summary>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			btnSave.CausesValidation=true;
			lblBeatNo.Visible=true;
			DropBeatNo.Visible=false; 
			btnEdit.Enabled=false;
			btnSave.Enabled=true;
			btnDelete.Enabled =false;
			Clear();
		}

		/// <summary>
		/// This Method is used to Fetch the next beat ID from Beat_Master table.
		/// </summary>
		public void FillID()
		{
			try
			{
				PartiesClass obj=new PartiesClass ();
				SqlDataReader SqlDtr;
				SqlDtr = obj.GetRecordSet ("select max(Beat_No)+1 from Beat_Master");
				while(SqlDtr.Read ())
				{
					lblBeatNo.Text =SqlDtr.GetValue(0).ToString ();
					if(lblBeatNo.Text =="")
					{
						lblBeatNo.Text ="1001";
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx,Method:FillID().  EXCEPTION "+ ex.Message+"  "+uid);
			}
		}

		/// <summary>
		/// This method is used to retrieve all Beat_no and City in combobox from the database.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			DropBeatNo.Visible=true;
			btnEdit.Visible=false;
			Edit1.Visible=true;
			Edit1.Enabled = true;
			btnDelete.Enabled = true;  
			btnSave.CausesValidation=false;
			lblBeatNo.Visible=false;
			
			//		
			Clear();
			try
			{
				PartiesClass  obj=new PartiesClass  ();
				SqlDataReader SqlDtr;
				SqlDtr = obj.GetRecordSet("select Beat_No,City from Beat_Master order by City");
				DropBeatNo.Items.Clear();
				DropBeatNo.Items.Add("Select");
				while(SqlDtr.Read ())
				{
					DropBeatNo.Items.Add(SqlDtr.GetValue(0).ToString ()+':'+SqlDtr.GetValue(1).ToString ());
				}	
				SqlDtr.Close(); 
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx,Method:btnEdit_Click().  EXCEPTION "+ ex.Message+"  "+uid);
			}
		}

		/// <summary>
		/// This method is used to insert all values in the database with the help of stored procedures.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			PartiesClass  obj = new PartiesClass ();
			try 
			{
                if (txtCity.Text == string.Empty)
                {
                    MessageBox.Show("Please Fill City");
                }
                else
                {
                    SqlDataReader SqlDtr;
                    string sql;
                    int flag = 0;
                    sql = "select City  from Beat_Master where City='" + txtCity.Text + "'";
                    SqlDtr = obj.GetRecordSet(sql);

                    if (SqlDtr.Read())
                    {
                        flag = 1;
                    }
                    else if (DropBeatNo.Visible == false)
                    {
                        obj.City = StringUtil.FirstCharUpper(txtCity.Text.ToString().Trim());
                        obj.State = StringUtil.FirstCharUpper(txtState.Text.ToString().Trim());
                        obj.Country = StringUtil.FirstCharUpper(txtCountry.Text.ToString().Trim());
                        obj.Beat_No = lblBeatNo.Text;
                        obj.InsertBeatMaster();
                        CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx,Method: btnSave_Click" + "  Beatno  " + obj.Beat_No + " city  " + obj.City + "   state  " + obj.State + " Country" + obj.Country + " IS SAVED  " + " userid  " + uid);
                        FillID();
                        lblBeatNo.Visible = true;
                        DropBeatNo.Visible = false;
                        MessageBox.Show("Beat details Saved");
                        Clear();
                    }
                    else if (DropBeatNo.Visible == true && DropBeatNo.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please select the Beat Number to Edit");
                    }
                    if (flag == 1)
                    {
                        RMG.MessageBox.Show("City already Exits");
                        SqlDtr.Close();
                    }
                    checkPrevileges();
                }
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx,Method: btnSave_Click"+"  Beatno  "+obj.Beat_No +" city  "+obj.City    +"   state  "+ obj.State   +" Country"+obj.Country+ ex.Message+" userid  "+ uid);
			}
		}

		/// <summary>
		/// This method is used to delete the record according to selected value from the dropdownlist.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			PartiesClass  obj=new PartiesClass  (); 
			try
			{
				if (DropBeatNo.Visible==true && DropBeatNo.SelectedIndex==0 )
				{
					MessageBox.Show("Please select the Beat Number to Delete");
				}
				else
				{		
					obj.Beat_No = DropBeatNo.SelectedItem.Value ;  
					obj.DeleteBeatMaster();
					MessageBox.Show("Beat deleted");
					CreateLogFiles.ErrorLog("Form:BeatMasterEntry.aspx,Method: btnDelete_Click"+"  Beat no  "+obj.Beat_No+"  is DELETED  " +"  user id  "+uid);
					Clear(); 
					btnEdit.Visible=true;
					Edit1.Visible=false;
					DropBeatNo.Visible=false;
					lblBeatNo.Visible=true;
					FillID();
					checkPrevileges();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BeatMasterEntry.aspx,Method: btnDelete_Click. EXCEPTION  "+ex.Message+"  user id  "+uid);
			}
		}

		/// <summary>
		/// This method is used to retrieve the all values from the database according to selected value in the dropdownlist.
		/// </summary>
		private void DropBeatNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropBeatNo.SelectedIndex==0)
					return;
				PartiesClass obj=new PartiesClass();
				SqlDataReader SqlDtr;
				string sql;
				//*****
				string beat_id=DropBeatNo.SelectedItem.Value;
				string[] beat=beat_id.Split(new char[] {':'},beat_id.Length);
				//*****
				//sql="Select * from Beat_Master where Beat_No='"+ DropBeatNo.SelectedItem.Value  +"'";
				sql="Select * from Beat_Master where Beat_No='"+ beat[0] +"'";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					txtCity.Text=SqlDtr.GetValue(1).ToString();
					txtState.Text=SqlDtr.GetValue(2).ToString();
					txtCountry.Text=SqlDtr.GetValue(3).ToString();
				}
				SqlDtr.Close();
								
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx,Method:DropBeatNo_SelectedIndexChanged"+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx,Method:DropBeatNo_SelectedIndexChange"+"  EXCEPTION "+ ex.Message+uid);
			}
		}

		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void Clear()
		{
			DropBeatNo.SelectedIndex=0;
			txtCity.Text="";
			txtState.Text="";
			txtCountry.Text=""; 
		}

		/// <summary>
		/// This method is used to update the records according to selected value from the dropdownlist.
		/// </summary>
		private void Edit1_Click(object sender, System.EventArgs e)
		{
			PartiesClass  obj1 = new PartiesClass ();
			try
			{	
				PartiesClass  obj = new PartiesClass ();
				obj1.City = StringUtil.FirstCharUpper(txtCity.Text.Trim());  
				obj1.State = StringUtil.FirstCharUpper(txtState.Text.Trim());
				obj1.Country=StringUtil.FirstCharUpper(txtCountry.Text.Trim()); 
				//*****
				string beat_id=DropBeatNo.SelectedItem.Value;
				string[] beat=beat_id.Split(new char[] {':'},beat_id.Length);
				//*****
				//obj1.Beat_No =DropBeatNo.SelectedItem.Value ; 
				obj1.Beat_No =beat[0]; 
				obj1.UpdateBeatMaster();
				MessageBox.Show("Beat Updated");
				Clear();
				DropBeatNo.Visible=false;
				lblBeatNo.Visible=true;
				Edit1.Visible=false;
				btnEdit.Visible=true; 
				checkPrevileges();
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx ,method Edit1_Click,"+"  Beat no   "+obj1.Beat_No +"City Updated to   "+obj1.City+"  user:"+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BeatMasterEntery.aspx ,method Edit1_Click,"+"  Beat no   "+obj1.Beat_No +"City Updated to   "+obj1.City+ "  EXCEPTION  "+ex.Message+"  user:"+uid);
			}
		}	
	}
}