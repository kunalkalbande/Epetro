/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
    # region Directives...
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using EPetro.Sysitem.Classes ;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data .SqlClient ;
using System.Text;
using RMG;
# endregion

namespace Epetro.Form.Logistics
{
	/// <summary>
	/// Summary description for Vehicle.
	/// </summary>
	public class Vehicle : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropvech;
		protected System.Web.UI.WebControls.Button btnaddnew;
		protected System.Web.UI.WebControls.Button btneditsave;
		protected System.Web.UI.WebControls.TextBox txtveccategory;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.Button btnEdit;
		string uid="";

		/// <summary>
		/// Put user code to initialize the page here
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		# region Page Load...
		private void Page_Load(object sender, System.EventArgs e)
		{ 
			try
			{
				uid=(Session["User_Name"].ToString());
				if(!Page.IsPostBack)
				{
					# region Dropdown Vehicle_Type
				
					fillCategory();
					# endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method:page_load "+ " EXCEPTION  "+ex.Message+" userid "+ uid );
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
		}
		# endregion
		
		/// <summary>
		/// This method is used to fatch all vehicle in dropdownlist from the database.
		/// </summary>
		public void fillCategory()
		{
			try
			{
				Dropvech.Items.Clear();   
				btnaddnew.Enabled=true;
				btnDel.Enabled=true;
				btneditsave.Visible=false;
				btnEdit.Visible=true;
				SqlConnection con;
				SqlCommand cmdselect;
				SqlDataReader dtrdrive;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select Vehicle_Type  From Vehicle", con );
				dtrdrive = cmdselect.ExecuteReader();
				Dropvech.Items.Add("---Select---");
				while (dtrdrive.Read()) 
				{
					Dropvech.Items.Add(dtrdrive.GetString(0));
				}
				dtrdrive.Close();
				con.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method:fillCategory() "+ " EXCEPTION  "+ex.Message+" userid "+ uid );
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
			this.Dropvech.SelectedIndexChanged += new System.EventHandler(this.Dropvech_SelectedIndexChanged);
			this.btnaddnew.Click += new System.EventHandler(this.btnaddnew_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btneditsave.Click += new System.EventHandler(this.btneditsave_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This method is used to fatch the all type according to selected vehicle category.
		/// </summary>
		# region  Dropvech_SelectedIndexChanged...
		private void Dropvech_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con44;
				SqlCommand cmdselect44;
				SqlDataReader dtrdrive44;
				con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
				con44.Open ();
				cmdselect44 = new SqlCommand( "Select Vehicle_Type  From Vehicle where Vehicle_Type=@Vehicle_Type", con44 );
				cmdselect44.Parameters .Add ("@Vehicle_Type",Dropvech.SelectedItem .Text.ToString().Trim());
				dtrdrive44 = cmdselect44.ExecuteReader();
				while (dtrdrive44.Read()) 
				{
					txtveccategory.Text=dtrdrive44.GetString(0);
				}
				dtrdrive44.Close();
				con44.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method:Dropvech_SelectedIndexChanged() "+ " EXCEPTION  "+ex.Message+" userid "+ uid );
			}
				
		}
		# endregion
		
		/// <summary>
		/// This method is used to update the vehicle category.
		/// </summary>
		# region Edit Save button...
		private void btneditsave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtveccategory.Text.Trim()=="")
				{
					MessageBox.Show("Please enter Vehicle Category");
				}
				else
				{
					btnaddnew.Enabled=true;
					btnDel.Enabled=true;
					btneditsave.Visible=false;
					SqlConnection con2;
					SqlCommand cmdselect2;
					SqlDataReader dtredit2;
					string strUpdate;
					con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
					con2.Open ();
					strUpdate = "Update Vehicle set Vehicle_Type=@Vehicle_Type where Vehicle_Type=@Vehicle";
					cmdselect2 = new SqlCommand( strUpdate, con2);
					cmdselect2.Parameters .Add ("@Vehicle",Dropvech.SelectedItem.Text.ToString().Trim().ToUpper());
					cmdselect2.Parameters .Add ("@Vehicle_Type",txtveccategory.Text.ToString().Trim().ToUpper());
					dtredit2 = cmdselect2.ExecuteReader();
					MessageBox.Show("Vehicle Category Updated");
				 	
					CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method:btneditsave_Click Vehicle type"+Dropvech.SelectedItem.Text.ToString().Trim().ToUpper()+"  updated  userid  "+ uid );	
					Clear();
					fillCategory();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method:btneditsave_Click "+ " EXCEPTION  "+ex.Message+" userid  "+ uid );	
			}

		}
		# endregion

		/// <summary>
		/// This method is used to insert new vehicle category in the database.
		/// </summary>
		# region Add New Button...
		private void btnaddnew_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtveccategory.Text=="")
				{
					MessageBox.Show("Please enter Vehicle Category");
				}
				else
				{
					string sVehicle_Type=txtveccategory.Text;
					SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
					scon.Open();
					SqlCommand scom=new SqlCommand("Select Count(Vehicle_Type) from Vehicle where Vehicle_Type='" + sVehicle_Type +"'",scon);
					SqlDataReader sdtr=scom.ExecuteReader(); 
					int iCount=0;
					while(sdtr.Read())
					{
						iCount=Convert.ToInt32(sdtr.GetSqlValue(0).ToString());
					}
					if(iCount==0)
					{
					
						SqlConnection con;
						string strInsert;
						SqlCommand cmdInsert;
						con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
						con.Open ();
						strInsert = "Insert Vehicle(Vehicle_Type)values (@Vehicle_Type)";
						cmdInsert=new SqlCommand (strInsert,con);
						cmdInsert.Parameters .Add ("@Vehicle_Type",txtveccategory.Text.Trim().ToUpper());
			
						cmdInsert.ExecuteNonQuery();
						con.Close ();
						MessageBox.Show("Vehicle Category Saved");
						CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method:btnaddnew_Click   vehical category "+txtveccategory.Text.Trim().ToUpper()+" saved  userid "+ uid );		
						Clear();
						fillCategory();
					}
					else
					{
						MessageBox.Show("This Vehicle Category Already Exists");
					}
					scon.Close();
				}
			}
			catch(Exception  ex)
			{
				CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method:btnaddnew_Click "+ " EXCEPTION  "+ex.Message+" userid "+ uid );	
			}
		}
		# endregion
		
		/// <summary>
		/// This method is used to delete the selected vehicle category from the dropdownlist.
		/// </summary>
		# region Delete Button...
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Dropvech.SelectedIndex==0)
				{
					
					MessageBox.Show("Please Select Vehicle Category to be Deleted");
				}
				else
				{
					SqlConnection con10;
					SqlCommand cmdselect10;
					SqlDataReader dtredit10;
					string strdelete10;
					con10=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
					con10.Open ();
					strdelete10 = "Delete Vehicle where Vehicle_Type=@Vehicle_Type";
					cmdselect10 = new SqlCommand( strdelete10, con10);
					cmdselect10.Parameters .Add ("@Vehicle_Type",Dropvech.SelectedItem .Text .ToString () );
					dtredit10 = cmdselect10.ExecuteReader();
					MessageBox.Show("Vehicle Category Deleted");
				
					CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method: btnDel_Click   vehical category "+Dropvech.SelectedItem .Text .ToString ()+" deleted    userid  "+ uid );		
					Clear();
					fillCategory();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Vehical.aspx,Method: btnDel_Click   vehical category "+Dropvech.SelectedItem .Text .ToString ()+" deleted   Exception "+ex.Message+"   userid  "+ uid );		
			}
		}
		# endregion

		/// <summary>
		/// This function to clear the form.
		/// </summary>
		# region Clear Function...
		public void Clear()
		{
			txtveccategory.Text="";
			Dropvech.SelectedIndex=0;
		}
		# endregion

		/// <summary>
		/// This method is used when click this button then update or delete the vehicle record.
		/// </summary>
		# region Edit Button...
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			btnaddnew.Enabled=false;
			btnDel.Enabled=false;
			btneditsave.Visible=true;
			if(Dropvech.SelectedIndex==0)
			{
				MessageBox.Show("Please Select Vehicle Category to be Updated");
			}
			else
			{
				btnEdit.Visible = false; 
			}
		}
		# endregion 
	}
}