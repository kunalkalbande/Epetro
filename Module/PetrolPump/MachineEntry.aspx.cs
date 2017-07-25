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
	/// Summary description for MachineEntry.
	/// </summary>
	public class MachineEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMachineName;
		protected System.Web.UI.WebControls.DropDownList DropMachineType;
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.Label lblDate;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.TextBox txtMachineName;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Label lblMachineID;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.DropDownList dropMachineID;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfv1;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:MAchineEntry.aspx,Class:PartiesClass.cs,Method:page_load "+ ex.Message+" EXCEPTION "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="5";
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
				if(Add_Flag=="0")
				{
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
				dropMachineID.Visible=false;
				lblMachineID.Visible=true;
				GetNextMachineID();
				GetMachines();
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
			this.dropMachineID.SelectedIndexChanged += new System.EventHandler(this.dropMachineID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to fill the all machine type in comboox at pageload events from the database. 
		/// </summary>
		public void GetMachines()
		{
			DropMachineType.Items.Remove("Other"); 
			SqlDataReader SqlDtr = null; 
			string sql="select distinct Machine_Type from Machine";
			dbobj.SelectQuery(sql,ref SqlDtr);  
			while(SqlDtr.Read())
			{
				if(DropMachineType.Items.IndexOf(DropMachineType.Items.FindByValue(SqlDtr.GetValue(0).ToString())) == -1)    
					DropMachineType.Items.Add(SqlDtr.GetValue(0).ToString());
			}
			SqlDtr.Close ();
			DropMachineType.Items.Add("Other");
		}

		/// <summary>
		/// This method is used to insert all values in the database with the help of stored procedures.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropMachineType.SelectedIndex == 0)
				{
					MessageBox.Show("Please Select the Machine Type"); 
					return;
				}
				else
				{
					if(DropMachineType.SelectedItem.Text.Equals("Other") && txtMachineName.Text.Trim().Equals(""))   
					{
						MessageBox.Show("Please Enter the Other Machine Type"); 
						txtMachineName.Enabled = true;
						return;
					}
				}
				PetrolPumpClass obj=new PetrolPumpClass();
				#region Saving The Record
		 
				obj.MachineID=lblMachineID.Text;
				obj.MachineName=lblMachineName.Text; 
				// if the machine name is Other then take the value from txtMachinename text box else get the value from drop down.
				string MachineType="";
				if(DropMachineType.SelectedItem.Text.Trim().Equals("Other"))
				{
					MachineType=StringUtil.OnlyFirstCharUpper(txtMachineName.Text.Trim());
					obj.MachineType= StringUtil.OnlyFirstCharUpper(txtMachineName.Text.Trim());
				}
				else
				{
					MachineType=DropMachineType.SelectedItem.Value.ToString(); 
					obj.MachineType=DropMachineType.SelectedItem.Value.ToString(); 
				}
				if(lblMachineID.Visible==true)
				{
					obj.InsertMachine();
					MessageBox.Show("Machine Entry Saved");
				}
				else
				{
					SqlConnection Con =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
					Con.Open();
					string mm = dropMachineID.SelectedItem.Text;
					string[] Machine = mm.Split(new char[] {':'},mm.Length);
					SqlCommand cmd=new SqlCommand("update Machine set Machine_Name='"+lblMachineName.Text+"', Machine_Type='"+MachineType+"' where Machine_ID='"+Machine[0].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					Con.Close();
					MessageBox.Show("Machine Entry Updated");
					btnSave.Text="Save";
					btnEdit.Visible=true;
					dropMachineID.Visible=false;
					lblMachineID.Visible=true;
				}
				#endregion
			
				
				CreateLogFiles.ErrorLog("Form:MachineEntry.aspx,Method:btnSave_Click"+"   Machine ID "+ obj.MachineID+ " , Machine Name "+  obj.MachineName+" ,Machin Type  "+	obj.MachineType+"  is Saved   "+"  userid "+uid);
				Clear();
				GetNextMachineID();
				GetMachines();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:MachineEntry.aspx,Method:btnSave_Click().  EXCEPTION "+ex.Message+"  userid "+uid);
			}
		}

		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void Clear()
		{
			dropMachineID.SelectedIndex=0;
			DropMachineType.SelectedIndex=0; 
			txtMachineName.Text = "";
		}

		/// <summary>
		/// This method is used to return the next machine name according to selected machine type in combobox.
		/// </summary>
		public void GetNextMachineID()
		{
			try
			{
				PetrolPumpClass obj=new PetrolPumpClass ();
				SqlDataReader SqlDtr;
				string sql;

				#region Fetch the Next Machine ID
				sql="select Max(Machine_ID)+1 from Machine";
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					lblMachineID.Text=SqlDtr.GetValue(0).ToString();   
					if(lblMachineID.Text=="")
						lblMachineID.Text="1001"; 
				}
				SqlDtr.Close();
				#endregion

				#region Fetch the Next Machine Name
				sql="select max(Machine_ID)-1000+1 from Machine";
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					lblMachineName.Text="M-"+SqlDtr.GetValue(0).ToString();   
					if(lblMachineName.Text=="M-")
						lblMachineName.Text="M-1"; 
				}
				SqlDtr.Close();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:MachineEntry.aspx,Method:GetNextMachineID().  EXCEPTION: "+ex.Message+"  userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to fatch the Machine ID with type from machine table and fill the dropdownlist on edit time.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				Clear();
				lblMachineID.Visible = false;
				dropMachineID.Visible = true;
				dropMachineID.Items.Clear();
				dropMachineID.Items.Add("Select");
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("Select Machine_ID,Machine_Type from Machine",ref SqlDtr);
				while(SqlDtr.Read())
				{
					dropMachineID.Items.Add(SqlDtr.GetValue(0).ToString()+":"+SqlDtr.GetValue(1).ToString());
				}
				btnSave .Text  = "Update";
				btnEdit.Visible=false;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Machine.aspx,Method:btnEdit_Click"+ " EXCEPTION  "+ex.Message+"   userid "+ uid );
			}
		}

		/// <summary>
		/// This method is used to fatch all information according to select the machine from dropdownlist 
		/// on edit time for edit or delete the record.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dropMachineID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlDataReader rdr=null;
				string mm = dropMachineID.SelectedItem.Text;
				string[] Machine = mm.Split(new char[] {':'},mm.Length);
				dbobj.SelectQuery("Select * from Machine where Machine_ID='"+Machine[0].ToString()+"'",ref rdr);
				if(rdr.Read())
				{
					DropMachineType.SelectedIndex=DropMachineType.Items.IndexOf(DropMachineType.Items.FindByValue(rdr.GetValue(2).ToString()));
					lblMachineName.Text=rdr.GetValue(1).ToString();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Machine.aspx,Method:dropMachineID_SelectedIndexChanged_Click"+ " EXCEPTION  "+ex.Message+"   userid "+ uid );
			}
		}

		/// <summary>
		/// This method is used to delete the particular record select from dropdownlist on edit time.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(btnEdit.Visible==false)
				{
					SqlConnection Con =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
					Con.Open();
					string mm = dropMachineID.SelectedItem.Text;
					string[] Machine = mm.Split(new char[] {':'},mm.Length);
					SqlCommand cmd=new SqlCommand("delete from Machine where Machine_ID='"+Machine[0].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					Con.Close();
					MessageBox.Show("Machine Deleted");
					btnSave.Text="Save";
					btnEdit.Visible=true;
					dropMachineID.Visible=false;
					lblMachineID.Visible=true;
					Clear();
					GetNextMachineID();
					GetMachines();
				}
				else
				{
					MessageBox.Show("Please click The Edit Button");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Machine.aspx,Method:btnDelete_Click"+ " EXCEPTION  "+ex.Message+"   userid "+ uid );
			}
		}
	}
}