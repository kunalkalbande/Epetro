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
	/// Summary description for NozzleEntry.
	/// </summary>
	public class NozzleEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.DropDownList DropTankID;
		protected System.Web.UI.WebControls.Label lblNozzleID;
		protected System.Web.UI.WebControls.DropDownList DropMachineID;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DropDownList DropNozzleID;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.HtmlControls.HtmlInputText TxtVen;
		protected System.Web.UI.WebControls.TextBox lblNozzleName;
		protected System.Web.UI.WebControls.TextBox txtsortname;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			FillID();
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:NozzleEntry.aspx,Method:page_load"+ ex.Message+"EXCEPTION  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				try
				{
					checkPrevileges();
					PetrolPumpClass obj=new PetrolPumpClass();
					SqlDataReader SqlDtr;
					string sql;

					#region Fetch all Machine Name 
					sql="select Machine_Name,Machine_Type from Machine";
					SqlDtr=obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						DropMachineID.Items.Add(SqlDtr.GetValue(0).ToString()+" : "+SqlDtr.GetValue(1).ToString());   
					}
					SqlDtr.Close();
					#endregion

					#region Fetch all Tank Name
					sql="select Prod_Name,Prod_AbbName from Tank order by Prod_Name";
					SqlDtr=obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						DropTankID.Items.Add(SqlDtr.GetValue(0).ToString()+":"+SqlDtr.GetValue(1).ToString());   
					}
					SqlDtr.Close();
					
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:NozzleEntry.aspx,Method:page_load  EXCEPTION: "+ ex.Message+" User_ID: "+uid);
				}
			}
			getNozzleNo();
		}

		/// <summary>
		/// This method checks the user privileges from session.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="5";
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
			this.DropNozzleID.SelectedIndexChanged += new System.EventHandler(this.DropNozzleID_SelectedIndexChanged);
			this.DropMachineID.SelectedIndexChanged += new System.EventHandler(this.DropMachineID_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
			lblNozzleID.Visible=true;
			DropNozzleID.Visible=false;
			btnEdit.Enabled=false;
			btnSave.Enabled=true;
			btnDelete.Enabled=false;
			Clear();
			FillID();
		}

		/// <summary>
		/// This function return next nozzle id from the nozzle table.
		/// </summary>
		public void FillID()
		{
			PetrolPumpClass obj=new PetrolPumpClass ();
			SqlDataReader SqlDtr;
			string sql;

			#region Fetch the Next Nozzle ID
			sql="select Max(Nozzle_ID)+1 from Nozzle";
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				lblNozzleID.Text=SqlDtr.GetValue(0).ToString();   
				if(lblNozzleID.Text=="")
					lblNozzleID.Text="1001";
			}
			SqlDtr.Close();
			#endregion
		}

		private void DropMachineID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			try
			{
				PetrolPumpClass obj=new PetrolPumpClass ();
				SqlDataReader  SqlDtr;
				string sql;

				if(DropMachineID.SelectedIndex<=0)
					return;

			#region Fetch the Next Nozzle Name of Selected Machine
				sql="select count(*)+1 from nozzle where machine_ID=(Select Machine_ID from Machine where Machine_Name='"+ DropMachineID.SelectedItem.Value+"')";
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					lblNozzleName.Text ="Nozzle-" + SqlDtr.GetValue(0).ToString();  
				}
				SqlDtr.Close();
			#endregion
			}
			catch(Exception ex)
			{
				   CreateLogFiles.ErrorLog("Form:NozzleEntry.aspx,Method:DropMachineID_SelectedIndexChanged  EXCEPTION: "+ ex.Message+" User_ID: "+uid);
			}
			*/
		}

		/// <summary>
		/// Name : Mahesh, Date : 01/12/06.
		/// Fetch the Next Nozzle Name of Selected Machine
		/// </summary>
		public void getNozzleNo()
		{
			try
			{
				InventoryClass obj=new InventoryClass ();
				SqlDataReader rdr=null;
				#region Fetch the Next Tank Name of Selected Product
				string Name="";
				string str1="";
				
				IEnumerator enum1=DropMachineID.Items.GetEnumerator();
				enum1.MoveNext(); 
				while(enum1.MoveNext())
				{
					string s=enum1.Current.ToString(); 
					string[] strMachineID=s.Split(new char[] {' '},s.Length);
					dbobj.SelectQuery("select count(*)+1 from nozzle where machine_ID=(Select Machine_ID from Machine where Machine_Name='"+strMachineID[0]+"')",ref rdr);
					if(rdr.Read())
					{
						Name=rdr.GetValue(0).ToString();
						str1=str1+s+"~"+Name+"#";
					}
				}
				TxtVen.Value=str1; 
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:NozzleEntry.aspx,Class:Inventory.cs,Methd: getNozzleNo().  EXCEPTION  "+ex.Message+" User "+uid);
			}
		}

		/// <summary>
		/// This method perform insert or update operation at a time
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{  
			PetrolPumpClass obj=new PetrolPumpClass(); 
			try
			{
				btnEdit.Enabled=true;			
				if(lblNozzleID.Text=="") 
				{
					RMG.MessageBox.Show("Please Enter Nozzle ID");
					return;
				}

				if(lblNozzleName.Text=="Nozzle-7" )
				{
					MessageBox.Show("Machine "+DropMachineID.SelectedItem.Value+ " can have maximum  six Nozzles");
					return;
				}

				#region Saving The Record
		
				SqlDataReader SqlDtr;
				string sql;
				obj.NozzelName=lblNozzleName.Text.Trim().ToString();
				obj.NozzleSortName=txtsortname.Text.Trim().ToString();

				#region Get Machine ID of Selected Machine
				string str=DropMachineID.SelectedItem.Value.ToString();
				string[] strmid=str.Split(new char[] {':'},str.Length);
				//sql="select Machine_ID from Machine where Machine_name='"+DropMachineID.SelectedItem.Value+"'";
				sql="select Machine_ID from Machine where Machine_name='"+strmid[0]+"'";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					obj.MachineID=SqlDtr.GetValue(0).ToString(); 
				}
				SqlDtr.Close();
				#endregion

				#region Get Tank ID of Selected Tank
				sql="select tank_ID from tank where Prod_AbbName=substring('"+ DropTankID.SelectedItem.Value+"',charindex(':','"+ DropTankID.SelectedItem.Value+"')+1,len('"+ DropTankID.SelectedItem.Value+"')) and Prod_Name=substring('"+DropTankID.SelectedItem.Value+"',1,charindex(':','"+ DropTankID.SelectedItem.Value+"')-1)";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					obj.TankID=SqlDtr.GetValue(0).ToString(); 
				}
				SqlDtr.Close();
				#endregion
				
				// if label of nozzle id is visible then save the nozzle details otherwise update the Nozzle details
				if(lblNozzleID.Visible==true)
				{
					obj.NozzelID=lblNozzleID.Text;
					obj.InsertNozzle();	
					FillID();
					lblNozzleID.Visible=true;
					DropNozzleID.Visible=false;
					MessageBox.Show("Nozzel Entry Saved");
					CreateLogFiles.ErrorLog("Form:NozzleEntry.aspx,Method:btnSave_Click"+"  Recored of Nozal ID "+ obj.MachineID +"  is saved  "+"  userid " +uid);
				}
				else
				{
					obj.NozzelID=DropNozzleID.SelectedItem.Value;
					obj.UpdateNozzle(); 
					lblNozzleID.Visible=true;
					DropNozzleID.Visible=false;
					MessageBox.Show("Nozzel Entry Updated");
					CreateLogFiles.ErrorLog("Form:NozzleEntry.aspx,Method:btnSave_Click"+"  Recored of Nozal ID "+ obj.MachineID +"  is Updated  "+"  userid " +uid);
				}
				#endregion
				getNozzleNo();
				Clear();
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:NozzleEntry.aspx,Method:btnSave_Click"+"  Recored of Nozal ID "+ obj.MachineID +"  is saved  "+ ex.Message+"  EXCEPTION  "+uid);
			}
		}

		/// <summary>
		/// This method is used to Fetch Nozzle ID and Fill in the Combo Box
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				btnEdit.Enabled=false;		
				lblNozzleID.Visible=false;
				DropNozzleID.Visible=true;
				Clear();
				PetrolPumpClass obj=new PetrolPumpClass();
				SqlDataReader SqlDtr;
				string sql;
				CreateLogFiles.ErrorLog("Form:NozzelEntry.aspx,Method:btnEdit_Click,  "+uid);

				#region Fetch Nozzle ID and Fill in the Combo Box
				//sql="select Nozzle_ID from Nozzle";
				sql="select Nozzle_ID from Nozzle";
				SqlDtr=obj.GetRecordSet(sql);
				DropNozzleID.Items.Clear();
				DropNozzleID.Items.Add("Select");
				while(SqlDtr.Read())
				{
					DropNozzleID.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
				FillID();
				getNozzleNo();
				checkPrevileges();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:NozzelEntry.aspx,Method:btnEdit_Click"+ ex.Message+"EXCEPTION  "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to Delete the record according to selected nozzle id from the combobox.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			PetrolPumpClass obj=new PetrolPumpClass();
			try
			{
				btnEdit.Enabled=true;		
				if(DropNozzleID.SelectedIndex==0)
				{
					RMG.MessageBox.Show("Please Click The Edit Button");
					return;
				}
				string sql;
				#region Delete Selected Nozzle
				sql="delete from Nozzle where Nozzle_ID='"+ DropNozzleID.SelectedItem.Value +"'";
				obj.DeleteRecord(sql);
				#endregion
				FillID();
				getNozzleNo();
				MessageBox.Show("Nozzel Entry Deleted");
				Clear();
				lblNozzleID.Visible=true;
				DropNozzleID.Visible=false;
				checkPrevileges();
				CreateLogFiles.ErrorLog("Form:NozzelEntry.aspx,Method:btnDelete_Click"+" Delete recored of  "+DropNozzleID.SelectedItem.Value+"  userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:NozzelEntry.aspx,Method:btnDelete_Click"+" Delete recored of  "+DropNozzleID.SelectedItem.Value+ ex.Message+"     EXCEPTION  "+"  userid  "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to Fetch Data Regarding Selected Nozzle ID
		/// </summary>
		private void DropNozzleID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropNozzleID.SelectedIndex==0)
				{
					Clear();
					return;
				}
				else
				{
					btnSave.Enabled = true;  
					btnSave.CausesValidation=true;
					PetrolPumpClass obj=new PetrolPumpClass();
					SqlDataReader SqlDtr;
					string sql;//,str="";

					#region Fetch Data Regarding Selected Nozzle ID
					/*sql="select Nozzle_name, machine_name, Prod_name+':'+Prod_AbbName"+
						" from Nozzle n, machine m, Tank t"+
						" where n.machine_id = m.machine_id"+
						" and n.tank_id = t.tank_id and nozzle_id = '"+ DropNozzleID.SelectedItem.Value +"'";*/
					sql="select Nozzle_name, machine_name+' : '+machine_type, Prod_name+':'+Prod_AbbName, NozzleSortName"+
						" from Nozzle n, machine m, Tank t"+
						" where n.machine_id = m.machine_id"+
						" and n.tank_id = t.tank_id and nozzle_id = '"+ DropNozzleID.SelectedItem.Value +"'";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						lblNozzleName.Text=SqlDtr.GetValue(0).ToString();   
						//str=SqlDtr.GetValue(0).ToString();   
						DropMachineID.SelectedIndex =DropMachineID.Items.IndexOf(DropMachineID.Items.FindByValue(SqlDtr.GetValue(1).ToString()));
						DropTankID.SelectedIndex =DropTankID.Items.IndexOf(DropTankID.Items.FindByValue(SqlDtr.GetValue(2).ToString()));
						txtsortname.Text=SqlDtr.GetValue(3).ToString();
					}
					SqlDtr.Close();
					//					string[] strname=str.Split(new char[] {':'},str.Length);
					//					lblNozzleName.Text=strname[0].Trim();
					//					if(str.IndexOf("/")>0)
					//						txtsortname.Text=strname[1].Trim();
					//					else
					//						txtsortname.Text="";
					#endregion 

				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:NozzelEntry.aspx,Method:DropNozzleID_SelectedIndexChanged"+" Nozal ID is updated to  "+DropNozzleID.SelectedItem.Value+" Nozal name updated to "+lblNozzleName+"  EXCEPTION "+ex.Message+ " userid "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to Clears the whole form.
		/// </summary>
		public void Clear()
		{
			lblNozzleName.Text="";
			DropNozzleID.SelectedIndex=0;
			DropMachineID.SelectedIndex=0;
			DropTankID.SelectedIndex=0;
			txtsortname.Text="";
		}
	}
}