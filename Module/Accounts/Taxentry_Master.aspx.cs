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
using EPetro.Sysitem.Classes ;
using RMG;

namespace EPetro.Module.Accounts
{
	/// <summary>
	/// Summary description for TaxEntry.
	/// </summary>
	public class TaxEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator7;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator8;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator9;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator10;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator11;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtrdc;
		protected System.Web.UI.WebControls.TextBox txtetax;
		protected System.Web.UI.WebControls.TextBox txtrpg_chg;
		protected System.Web.UI.WebControls.TextBox txt_rpgschg;
		protected System.Web.UI.WebControls.TextBox txt_ltchg;
		protected System.Web.UI.WebControls.TextBox txt_tchg;
		protected System.Web.UI.WebControls.TextBox txt_lst;
		protected System.Web.UI.WebControls.TextBox txt_lstschg;
		protected System.Web.UI.WebControls.TextBox txt_lfrecov;
		protected System.Web.UI.WebControls.TextBox txt_dochg;
		protected System.Web.UI.WebControls.DropDownList drp_pname;
		protected System.Web.UI.WebControls.TextBox txt_olvy;
		protected System.Web.UI.WebControls.DropDownList unit_etax;
		protected System.Web.UI.WebControls.DropDownList unit_rpgchg;
		protected System.Web.UI.WebControls.DropDownList unit_rpgschg;
		protected System.Web.UI.WebControls.DropDownList unit_ltchg;
		protected System.Web.UI.WebControls.DropDownList unit_tchg;
		protected System.Web.UI.WebControls.DropDownList unit_olv;
		protected System.Web.UI.WebControls.DropDownList unit_lst;
		protected System.Web.UI.WebControls.DropDownList unit_lstschg;
		protected System.Web.UI.WebControls.DropDownList unit_lfrecov;
		protected System.Web.UI.WebControls.DropDownList unit_dochg;
		protected System.Web.UI.WebControls.DropDownList unit_rdc;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk1;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk2;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk3;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk4;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk5;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk6;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk7;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk8;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk9;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk11;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkall;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBOperations.DBUtil obj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
		
		/// <summary>
		/// Put user code to initialize the page here
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{ 
				//string User_ID;
				uid=(Session["User_Name"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TaxEntry_Master.aspx,Method:pageLoad"+ " EXCEPTION  "+ex.Message+" userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				checkPrivileges(); 

				// The code below fills the combo with products names of type fuel.
				System.Data.SqlClient.SqlDataReader rdr=null;
				obj.SelectQuery("select Prod_Name from products where Category = 'Fuel' order by Prod_Name", ref rdr);
				drp_pname.DataSource=rdr;
				drp_pname.DataValueField="Prod_Name" ;
				drp_pname.DataBind();
				drp_pname.Items.Insert(0,"Select");
				obj.Dispose();
			}		
		}

		/// <summary>
		/// This method checks the user previleges from session.
		/// </summary>
		public void checkPrivileges()
		{
			#region Check Privileges
			int i;
				
			string Module="3";
			string SubModule="6";
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
			if(View_flag =="0" && Add_Flag=="0" && Edit_Flag=="0" && Del_Flag=="0")
			{
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}
			if(Add_Flag=="0")
				btnAdd.Enabled=false;
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
			this.drp_pname.SelectedIndexChanged += new System.EventHandler(this.drp_pname_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.Button2_Click);
			this.btnEdit.Click += new System.EventHandler(this.Button1_Click);
			this.btnDelete.Click += new System.EventHandler(this.Button3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method insert the all values in the database with the help of stored procedures.
		/// </summary>
		private void Button2_Click(object sender, System.EventArgs e)
		{
			try
			{

				#region Check Validations
				if(drp_pname.SelectedIndex==0)
				{
					MessageBox.Show("Please Select The Product Name");
					return;
				}
				if(chk1.Checked&&txtrdc.Text=="")
				{
					MessageBox.Show("Please Fill Reduction Charges");
					return;
				}
				if(chk2.Checked&&txtetax.Text=="")
				{
					MessageBox.Show("Please Fill Entry Tax Charges");
					return;
				}
				if(chk3.Checked&&txtrpg_chg.Text=="")
				{
					MessageBox.Show("Please Fill RPG Charges");
					return;
				}
				if(chk4.Checked&&txt_rpgschg.Text=="")
				{
					MessageBox.Show("Please Fill RPG SurCharges");
					return;
				}
				if(chk5.Checked&&txt_ltchg.Text=="")
				{
					MessageBox.Show("Please Fill Local Transportation Charges");
					return;
				}
				if(chk6.Checked&&txt_tchg.Text=="")
				{
					MessageBox.Show("Please Fill Transportation Charges");
					return;
				}
				if(chk7.Checked&&txt_olvy.Text=="")
				{
					MessageBox.Show("Please Fill Other Levies Values");
					return;
				}
				if(chk8.Checked&&txt_lst.Text=="")
				{
					MessageBox.Show("Please Fill Local Sales Tax");
					return;
				}
				if(chk9.Checked&&txt_lstschg.Text=="")
				{
					MessageBox.Show("Please Fill LST SurCharges");
					return;
				}
				if(chk10.Checked&&txt_lfrecov.Text=="")
				{
					MessageBox.Show("Please Fill License Fee Recovery");
					return;
				}
				if(chk11.Checked&&txt_dochg.Text=="")
				{
					MessageBox.Show("Please Fill DO/ FO/ BC Charges");
					return;
				}
				#endregion
			
				object op=null;			
				string pid="";
				obj.SelectQuery("select Prod_ID from products where prod_name like '"+drp_pname.SelectedItem.Text+"'","Prod_ID",ref pid);
		
				obj.ExecProc(DBOperations.OprType.Insert,"sp_Taxentry",ref op,"@pid",pid,"@reduction",txtrdc.Text,"@etax",txtetax.Text,"@rpg_charge",txtrpg_chg.Text,"@rpg_scharge",txt_rpgschg.Text,"@ltchg",txt_ltchg.Text,"@tchg",txt_tchg.Text,"@oth_lvy",txt_olvy.Text,"@lst",txt_lst.Text,"@lst_schg",txt_lstschg.Text,"@lf_recov",txt_lfrecov.Text,"@dofobc_chg",txt_dochg.Text,"@unit_rdc",unit_rdc.SelectedItem.Text,"@unit_etax",unit_etax.SelectedItem.Text,"@unit_rpgchg",unit_rpgchg.SelectedItem.Text,"@unit_ltchg",unit_ltchg.SelectedItem.Text,"@unit_tchg",unit_tchg.SelectedItem.Text,"@unit_olvy",unit_olv.SelectedItem.Text,"@unit_lst",unit_lst.SelectedItem.Text,"@unit_lstschg",unit_lstschg.SelectedItem.Text,"@unit_lfrecov",unit_lfrecov.SelectedItem.Text,"@unit_dochg",unit_dochg.SelectedItem.Text,"@unit_rpgschg",unit_rpgschg.SelectedItem.Text);
	
				MessageBox.Show("Tax Entry Saved");
				Clear();
				drp_pname.SelectedIndex=0; 
				CreateLogFiles.ErrorLog("Form:TaxEntry_Master.aspx,Method:Button2_Click"+" Tax Entry for Product  "+drp_pname.SelectedItem.Text+" Is Saved "+"  userid  "+uid);
			}
			catch(Exception  ex)
			{
			
				CreateLogFiles.ErrorLog("Form:TaxEntry_Master.aspx,Method:Button2_Click"+" Tax Entry for Product  "+drp_pname.SelectedItem.Text+"  Is Saved  "+"  EXCEPTION  "+ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to retrieve the all values from the database according to selected value in the dropdownlist.
		/// </summary>
		private void drp_pname_SelectedIndexChanged(object sender, System.EventArgs e)
		{   
			try
			{
				checkPrivileges(); 
				System.Data.SqlClient.SqlDataReader rdr=null;
				string pid="";
				obj.SelectQuery("select Prod_ID from products where prod_name like '"+drp_pname.SelectedItem.Text+"'","Prod_ID",ref pid);
				obj.SelectQuery("select * from tax_entry where productid='"+pid+"'",ref rdr);
				if(rdr.Read())
				{
				
					if(Add_Flag == "0")
						btnAdd.Enabled=false;
					else
						btnAdd.Enabled=true;
					if(Edit_Flag == "0")
						btnEdit.Enabled=false;
					else
						btnEdit.Enabled=true;
					if(Del_Flag =="0")
						btnDelete.Enabled=false;
					else
						btnDelete.Enabled=true;
					txtrdc.Text= rdr["reduction"].ToString();
					txtetax.Text=rdr["entry_tax"].ToString();
					txtrpg_chg.Text=rdr["rpg_charge"].ToString();
					txt_rpgschg.Text=rdr["rpg_surcharge"].ToString();
					txt_ltchg.Text=rdr["LT_charge"].ToString();
					txt_tchg.Text=rdr["tran_charge"].ToString();
					txt_olvy.Text=rdr["other_lvy"].ToString();
					txt_lst.Text=rdr["LST"].ToString();
					txt_lstschg.Text=rdr["LST_surcharge"].ToString();
					txt_lfrecov.Text=rdr["LF_recov"].ToString();
					txt_dochg.Text=rdr["dofobc_charge"].ToString();

					if(rdr["unit_rdc"].ToString().Equals("KL"))
						unit_rdc.SelectedIndex=0;
					else
						unit_rdc.SelectedIndex=1;

					if(rdr["unit_etax"].ToString().Equals("KL"))
						unit_etax.SelectedIndex=0;
					else
						unit_etax.SelectedIndex=1;

					if(rdr["unit_rpgchg"].ToString().Equals("KL"))
						unit_rpgchg.SelectedIndex=0;
					else
						unit_rpgchg.SelectedIndex=1;

					if(rdr["unit_ltchg"].ToString().Equals("KL"))
						unit_ltchg.SelectedIndex=0;
					else
						unit_ltchg.SelectedIndex=1;

					if(rdr["unit_tchg"].ToString().Equals("KL"))
						unit_tchg.SelectedIndex=0;
					else
						unit_tchg.SelectedIndex=1;

					if(rdr["unit_olvy"].ToString().Equals("KL"))
						unit_olv.SelectedIndex=0;
					else
						unit_olv.SelectedIndex=1;

					if(rdr["unit_lst"].ToString().Equals("KL"))
						unit_lst.SelectedIndex=0;
					else
						unit_lst.SelectedIndex=1;
				
					if(rdr["unit_lstschg"].ToString().Equals("KL"))
						unit_lstschg.SelectedIndex=0;
					else
						unit_lstschg.SelectedIndex=1;

					if(rdr["unit_lfrecov"].ToString().Equals("KL"))
						unit_lfrecov.SelectedIndex=0;
					else
						unit_lfrecov.SelectedIndex=1;

					if(rdr["unit_dochg"].ToString().Equals("KL"))
						unit_dochg.SelectedIndex=0;
					else
						unit_dochg.SelectedIndex=1;



					if(rdr["unit_dochg"].ToString().Equals("KL"))
						unit_dochg.SelectedIndex=0;
					else
						unit_dochg.SelectedIndex=1;
					obj.Dispose();
				}
				else
				{
				
					if(Add_Flag == "0")
						btnAdd.Enabled=false;
					else
						btnAdd.Enabled=true;
					if(Edit_Flag == "0")
						btnEdit.Enabled=false;
					else
						btnEdit.Enabled=true;
					if(Del_Flag =="0")
						btnDelete.Enabled=false;
					else
						btnDelete.Enabled=true;
					Clear();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TaxEntry_Master.aspx,Method:drp_pname_SelectedIndexChanged"+" EXCEPTION "+ex.Message+uid);
			}
		}

		/// <summary>
		/// This method is used to update the records according to selected value from the dropdownlist.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			#region Check Validations
			if(drp_pname.SelectedIndex==0)
			{
				MessageBox.Show("Please Select The Product Name");
				return;
			}
			if(chk1.Checked&&txtrdc.Text=="")
			{
				MessageBox.Show("Please Fill Reduction Charges");
				return;
			}
			if(chk2.Checked&&txtetax.Text=="")
			{
				MessageBox.Show("Please Fill Entry Tax Charges");
				return;
			}
			if(chk3.Checked&&txtrpg_chg.Text=="")
			{
				MessageBox.Show("Please Fill RPG Charges");
				return;
			}
			if(chk4.Checked&&txt_rpgschg.Text=="")
			{
				MessageBox.Show("Please Fill RPG SurCharges");
				return;
			}
			if(chk5.Checked&&txt_ltchg.Text=="")
			{
				MessageBox.Show("Please Fill Local Transportation Charges");
				return;
			}
			if(chk6.Checked&&txt_tchg.Text=="")
			{
				MessageBox.Show("Please Fill Transportation Charges");
				return;
			}
			if(chk7.Checked&&txt_olvy.Text=="")
			{
				MessageBox.Show("Please Fill Other Levies Values");
				return;
			}
			if(chk8.Checked&&txt_lst.Text=="")
			{
				MessageBox.Show("Please Fill Local Sales Tax");
				return;
			}
			if(chk9.Checked&&txt_lstschg.Text=="")
			{
				MessageBox.Show("Please Fill LST SurCharges");
				return;
			}
			if(chk10.Checked&&txt_lfrecov.Text=="")
			{
				MessageBox.Show("Please Fill License Fee Recovery");
				return;
			}
			if(chk11.Checked&&txt_dochg.Text=="")
			{
				MessageBox.Show("Please Fill DO/ FO/ BC Charges");
				return;
			}
			//			if(chk12.Checked&&txt_ro.Text=="")
			//			{
			//				MessageBox.Show("Please Fill R/O Charges");
			//				return;
			//			}
			#endregion
			
			try
			{
				object op=null;			
				string pid="";
				obj.SelectQuery("select Prod_ID from products where prod_name like '"+drp_pname.SelectedItem.Text+"'","Prod_ID",ref pid);
			
				obj.ExecProc(DBOperations.OprType.Insert,"sp_TaxUpdate",ref op,"@pid",pid,"@reduction",txtrdc.Text,"@etax",txtetax.Text,"@rpg_charge",txtrpg_chg.Text,"@rpg_scharge",txt_rpgschg.Text,"@ltchg",txt_ltchg.Text,"@tchg",txt_tchg.Text,"@oth_lvy",txt_olvy.Text,"@lst",txt_lst.Text,"@lst_schg",txt_lstschg.Text,"@lf_recov",txt_lfrecov.Text,"@dofobc_chg",txt_dochg.Text,"@unit_rdc",unit_rdc.SelectedItem.Text,"@unit_etax",unit_etax.SelectedItem.Text,"@unit_rpgchg",unit_rpgchg.SelectedItem.Text,"@unit_ltchg",unit_ltchg.SelectedItem.Text,"@unit_tchg",unit_tchg.SelectedItem.Text,"@unit_olvy",unit_olv.SelectedItem.Text,"@unit_lst",unit_lst.SelectedItem.Text,"@unit_lstschg",unit_lstschg.SelectedItem.Text,"@unit_lfrecov",unit_lfrecov.SelectedItem.Text,"@unit_dochg",unit_dochg.SelectedItem.Text,"@unit_rpgschg",unit_rpgschg.SelectedItem.Text);

				MessageBox.Show("Tax Entry Updated");
				CreateLogFiles.ErrorLog("Form:TaxEntry_Master.aspx,Method:Button1_Click, Tax Entry for Product "+drp_pname.SelectedItem.Text+" is updated.  userid  "+uid);
				Clear();
				drp_pname.SelectedIndex=0; 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TaxEntry_Master.aspx,Method:Button1_Click. "+" EXCEPTION: "+ex.Message+".   User_ID: "+uid);
			}
		}

		/// <summary>
		/// This method is used to dalete the record according to selected value from the dropdownlist.
		/// </summary>
		private void Button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(drp_pname.SelectedIndex==0)
				{
					MessageBox.Show("Please Select The Product Name");
					return;
				}
				int x=0;
				string pid="";
				obj.SelectQuery("select Prod_ID from products where prod_name like '"+drp_pname.SelectedItem.Text+"'","Prod_ID",ref pid);
				obj.Insert_or_Update("delete from tax_entry where productid='"+pid+"'",ref x);

				MessageBox.Show("Tax Entry Deleted");
				Clear();
				drp_pname.SelectedIndex=0; 
				CreateLogFiles.ErrorLog("Form:TaxEntry_Master.aspx,Method:button_Click,  Deleted tax entry for product "+drp_pname.SelectedItem.Text +"  userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TaxEntry_Master.aspx,Method:button3_Click"+" EXCEPTION "+ex.Message+" userid  "+uid);
			}
		}

		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void Clear()
		{
			txtrdc.Text= "";
			txtetax.Text= "";
			txtrpg_chg.Text= "";
			txt_rpgschg.Text= "";
			txt_ltchg.Text= "";
			txt_tchg.Text= "";
			txt_olvy.Text= "";
			txt_lst.Text= "";
			txt_lstschg.Text= "";
			txt_lfrecov.Text= "";
			txt_dochg.Text= "";
		}
	}
}