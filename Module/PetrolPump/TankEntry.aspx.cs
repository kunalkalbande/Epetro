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
using DBOperations;
using RMG;

namespace EPetro.Module.PetrolPump
{
	/// <summary>
	/// Summary description for TankEntry.
	/// </summary>
	public class TankEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTankID;
		protected System.Web.UI.WebControls.DropDownList DropProdName;
		protected System.Web.UI.WebControls.TextBox txtCapacity;
		protected System.Web.UI.WebControls.TextBox txtWaterStock;
		protected System.Web.UI.WebControls.TextBox txtOpeningStock;
		protected System.Web.UI.WebControls.TextBox txtReserveStock;
		protected System.Web.UI.WebControls.TextBox txtProdAbbr;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DropDownList DropTankID;
		protected System.Web.UI.WebControls.Button Button1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtVen;
		protected System.Web.UI.WebControls.TextBox lblTankName;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next Tank ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{	
				Button1.Visible=false;
				getTankNo();
			}
			fillID();
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:page_load"+ ex.Message+"EXCEPTION  "+uid);
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
			string Module="5";
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
			this.DropTankID.SelectedIndexChanged += new System.EventHandler(this.DropTankID_SelectedIndexChanged);
			this.DropProdName.SelectedIndexChanged += new System.EventHandler(this.DropProdName_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to perform the insert statement and check the data is valid or not. 
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			PetrolPumpClass obj=new PetrolPumpClass(); 
			try
			{
				if(!checkAcc_Period())
				{
					RMG.MessageBox.Show("Please enter the Accounts Period from Organization Details");
					return;
				}
				if(lblTankID.Text=="")
				{
					RMG.MessageBox.Show("Please Enter Tank ID");
					return;
				}
				if(lblTankName.Text=="Tank-5")
				{
					MessageBox.Show(DropProdName.SelectedItem.Value+ " can have maximum four Tanks");
					return;
				}
				int count = 0;
				dbobj.ExecuteScalar("Select Count(Tank_ID) from Tank where Prod_AbbName = '"+txtProdAbbr.Text.Trim()+"'",ref count);
				if(count > 0)
				{
					MessageBox.Show("The Short Name is already exist");
					return;
				}

				#region Saving The Record
				obj.TankName=lblTankName.Text; 
				obj.ProdName1=DropProdName.SelectedItem.Value.ToString();
				//***************
				//string str=DropProdName.SelectedItem.Value.ToString();
				string tank1=lblTankName.Text;
				string[] tank=tank1.Split(new char[] {'-'},tank1.Length);
				obj.ProdName=DropProdName.SelectedItem.Value.ToString()+tank[1]; 
				//***************
				obj.ProdAbbName=txtProdAbbr.Text;
				obj.Capacity=txtCapacity.Text;
				obj.WaterStock=txtWaterStock.Text;
				obj.ReserveStock=txtReserveStock.Text;
				obj.OpeningStock=txtOpeningStock.Text;
				if(lblTankID.Visible==true)
				{
					obj.TankID=lblTankID.Text;
					obj.InsertTank();	
					fillID();
					MessageBox.Show("Tank Entry Saved");
				}
				else
				{
				}
				#endregion
				CreateLogFiles.ErrorLog("Form:Tank_Entry.aspx,Class:Employeee.cs,Methd: btnUpdate_Click   "+" tank id "+"  Tank name "+obj.TankName+" product Name  " +obj.ProdName   +" Capacity   "+  obj.Capacity	 + " IS SAVED   "+" User "+ uid);
				getTankNo();	
				Clear();
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Tank_Entry.aspx,Class:Employeee.cs,Methd: btnUpdate_Click().  EXCEPTION  "+ex.Message+" User "+uid);
			}
		}

		/// <summary>
		/// Its checks the before save that the account period is inserted in organisaton table or not.
		/// </summary>
		public bool checkAcc_Period()
		{
			SqlDataReader SqlDtr = null;
			int c = 0;
			dbobj.SelectQuery("Select count(Acc_Date_From) from Organisation",ref SqlDtr);
			if(SqlDtr.Read())
			{
				c = System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());  
			}
			SqlDtr.Close();

			if(c > 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		private void btnAdd_Click(object sender,System.EventArgs e)
		{
			btnSave.CausesValidation=true;
			Clear(); 
		}

		/// <summary>
		/// This method is used to fill the tank id into the combo box.
		/// </summary>
		public void fillID()
		{
			PetrolPumpClass obj=new PetrolPumpClass ();
			SqlDataReader SqlDtr;
			string sql;

			sql="select Max(Tank_ID)+1 from Tank";
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				lblTankID.Text=SqlDtr.GetValue(0).ToString();   
				if(lblTankID.Text=="")
					lblTankID.Text="1001";
			}
			SqlDtr.Close();
		}

		private void DropProdName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			try
			{
				PetrolPumpClass obj=new PetrolPumpClass();
				SqlDataReader SqlDtr;
				string sql;

				if(DropProdName.SelectedIndex<=0)
					return;

			#region Fetch the Next Tank Name of Selected Product
				sql="select count(*)+1 from Tank where Prod_Name='"+ DropProdName.SelectedItem.Value+"'";
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{	
					lblTankName.Text ="Tank-" + SqlDtr.GetValue(0).ToString(); 
				}
				SqlDtr.Close();
			#endregion
			}
			catch(Exception ex)
			{
				   CreateLogFiles.ErrorLog("Form:Tank_Entry.aspx,Class:Employeee.cs,Methd: btnUpdate_Click().  EXCEPTION  "+ex.Message+" User "+uid);
			}*/
		}

		/// <summary>
		/// Name : Mahesh, Date : 01/12/06.
		/// Fetch the Next Tank Name of Selected Product Name
		/// </summary>
		public void getTankNo()
		{
			try
			{
				InventoryClass obj=new InventoryClass ();
				SqlDataReader rdr=null;
				#region Fetch the Next Tank Name of Selected Product
				string Name="";
				string str1="";
					
				IEnumerator enum1=DropProdName.Items.GetEnumerator();
				enum1.MoveNext(); 
				while(enum1.MoveNext())
				{
					string s=enum1.Current.ToString(); 
					dbobj.SelectQuery("Select count(*)+1 from tank where Prod_Name like '"+s+"%'",ref rdr);
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
				CreateLogFiles.ErrorLog("Form:Tank_Entry.aspx,Class:Employeee.cs,Methd: getTankNo().  EXCEPTION  "+ex.Message+" User "+uid);
			}
		}


		private void btnEdit_Click(object sender, System.EventArgs e)
		{   
			try
			{
				Button1.Visible=true;
				btnEdit.Visible=false;
				Button1.Enabled = true;
				btnDelete.Enabled = true; 
 
				btnSave.CausesValidation=true;
				btnSave.Enabled=false;
				lblTankID.Visible=false;
				DropTankID.Visible=true;
				Clear(); 

				PetrolPumpClass obj=new PetrolPumpClass();
				SqlDataReader SqlDtr;
				string sql;
				
				CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:btnEdit_Click"+uid);
				#region Fetch Tank ID and Fill in the Combo Box
				//sql="select Tank_ID from Tank";
				sql="select Tank_ID,Prod_AbbName from Tank";
				SqlDtr=obj.GetRecordSet(sql);
				DropTankID.Items.Clear();
				DropTankID.Items.Add("Select");
				while(SqlDtr.Read())
				{
					DropTankID.Items.Add(SqlDtr.GetValue(0).ToString()+" : "+SqlDtr.GetValue(1).ToString());
				}
				SqlDtr.Close();
				fillID();
			
				#endregion 
				checkPrevileges();
				getTankNo();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:tnEdit_Click"+ ex.Message+"EXCEPTION  "+uid);
			}
		}

		/// <summary>
		/// This method to perform the delete operation according to selected tank from combo box.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				Button1.Visible=false;
				btnEdit.Visible=true;		
				if(DropTankID.SelectedIndex==0)
				{
					RMG.MessageBox.Show("Please Select the Tank ID");
					return;
				}
				PetrolPumpClass obj=new PetrolPumpClass();
				string sql;

				#region Delete The Record
				string str1=DropTankID.SelectedItem.Text;
				string[] str=str1.Split(new char[] {':'},str1.Length);
				//sql="delete from Tank where Tank_ID='"+ DropTankID.SelectedItem.Value +"'";
				sql="delete from Tank where Tank_ID='"+ str[0].Trim() +"'";
				obj.DeleteRecord(sql);
				//obj.DeleteRecord("delete from products where store_in = '"+ DropTankID.SelectedItem.Value+"'");
				obj.DeleteRecord("delete from products where store_in = '"+str[0].Trim()+"'");
				obj.DeleteRecord("delete from stock_master where ProductId='"+str[0].Trim()+"'");
				#endregion 

				MessageBox.Show("Tank Entry Deleted");
				CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:btnDelete_Click"+" Recored of  Tank id"+ DropTankID.SelectedItem.Value+" is  Deleted  "+" User "+uid);
				Clear();
				fillID();
				getTankNo();
				btnEdit.Enabled=true;
				btnSave.Enabled=true;
				lblTankID.Visible=true;
				DropTankID.Visible=false;
				checkPrevileges();
				CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:btnDelete_Click"+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:btnDelete_Click"+ " EXCEPTION"+ ex.Message+  uid);
			}
		}

		private void DropTankID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropTankID.SelectedIndex==0)
			{
				Clear();
				return;
			}
			else
			{
				try
				{
					btnSave.CausesValidation=true;
					PetrolPumpClass obj=new PetrolPumpClass();
					SqlDataReader SqlDtr;
					string sql,Prod_Name;
		
					#region Fetch Data regarding Selected Tank ID
					//*****
					string tank_id = DropTankID.SelectedItem.Value;
					string[] strtankid = tank_id.Split(new char[] {':'},tank_id.Length);
					//*****
					//sql="select * from Tank where Tank_ID='"+ DropTankID.SelectedItem.Value +"'";
					sql="select * from Tank where Tank_ID='"+ strtankid[0].ToString().Trim() +"'";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						lblTankName.Text=SqlDtr.GetValue(1).ToString();   
						Prod_Name=SqlDtr.GetValue(2).ToString();
						Prod_Name=Prod_Name.Substring(0,Prod_Name.Length-1);
						//DropProdName.SelectedIndex=DropProdName.Items.IndexOf(DropProdName.Items.FindByValue(SqlDtr.GetValue(2).ToString()));
						DropProdName.SelectedIndex=DropProdName.Items.IndexOf(DropProdName.Items.FindByValue(Prod_Name));
						txtProdAbbr.Text=SqlDtr.GetValue(3).ToString();
						txtCapacity.Text=SqlDtr.GetValue(4).ToString();
						txtWaterStock.Text=SqlDtr.GetValue(5).ToString();
						txtReserveStock.Text=SqlDtr.GetValue(6).ToString(); 
						txtOpeningStock.Text=SqlDtr.GetValue(7).ToString(); 
					}
					SqlDtr.Close();
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:DropTankID_SelectedIndexChanged().  EXCEPTION"+ ex.Message+  uid);
				}
			}
			
			checkPrevileges();
		}

		/// <summary>
		/// This method is used to Clears the whole form.
		/// </summary>
		public void Clear()
		{
			lblTankName.Text="";
			DropTankID.SelectedIndex=0;
			DropProdName.SelectedIndex=0; 
			txtProdAbbr.Text="";
			txtCapacity.Text="";
			txtWaterStock.Text="";
			txtReserveStock.Text="";
			txtOpeningStock.Text="";
		}

		/// <summary>
		/// This method to perform the update operaion according to selected tank from the combobox.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			PetrolPumpClass obj=new PetrolPumpClass(); 
			try
			{
				string tank11=DropTankID.SelectedItem.Value;
				string[] tank12=tank11.Split(new char[] {' '},tank11.Length);
				if(DropTankID.Visible==true)
				{
					int count = 0;
					int count1 = 0;
					dbobj.ExecuteScalar("Select Count(Tank_ID) from Tank where Prod_AbbName = '"+txtProdAbbr.Text.Trim()+"'",ref count);
					if(count > 0)
					{
						//dbobj.ExecuteScalar("Select Count(Tank_ID) from Tank where Prod_AbbName = '"+txtProdAbbr.Text.Trim()+"' and Tank_ID = "+DropTankID.SelectedItem.Text,ref count1);
						dbobj.ExecuteScalar("Select Count(Tank_ID) from Tank where Prod_AbbName = '"+txtProdAbbr.Text.Trim()+"' and Tank_ID = "+tank12[0],ref count1);
						if(count1 == 0)
						{
							MessageBox.Show("The Short Name already exist");
							return;
						}
					}
					Button1.Visible=false;
					btnEdit.Visible=true;
					//obj.TankID=DropTankID.SelectedItem.Value;
					
					obj.TankID=tank12[0];
					obj.TankName=lblTankName.Text; 
					obj.ProdName1=DropProdName.SelectedItem.Value.ToString();
					//***************
					//string str=DropProdName.SelectedItem.Value.ToString();
					string tank1=lblTankName.Text;
					string[] tank=tank1.Split(new char[] {'-'},tank1.Length);
					obj.ProdName=DropProdName.SelectedItem.Value.ToString()+tank[1]; 
					//***************
					//obj.ProdName=DropProdName.SelectedItem.Value.ToString(); 
					obj.ProdAbbName=txtProdAbbr.Text;
					obj.Capacity=txtCapacity.Text;
					obj.WaterStock=txtWaterStock.Text;
					obj.ReserveStock=txtReserveStock.Text;
					obj.OpeningStock=txtOpeningStock.Text;
					// call method to update the tank details.
					obj.UpdateTank();
					SeqStockMaster();
					fillID();
					Clear(); 
					getTankNo();
					lblTankID.Visible=true;
					DropTankID.Visible=false;
					btnSave.Enabled=true;
					checkPrevileges();
					MessageBox.Show("Tank Entry Updated");
					CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:Button1_Click"+" Recored of  "+ obj.TankID+" is  Updated  "+" User "+uid);
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TankEntry.aspx,Method:Button1_Click"+" Recored of  "+ obj.TankID+" is  Updated  "+"  EXCEPTION  "+ex.Message+" User "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to calculate the closing stock of product according to date after update or delete record from the database
		/// </summary>
		public void SeqStockMaster()
		{
			InventoryClass obj = new InventoryClass();
			InventoryClass obj1 = new InventoryClass();
			SqlCommand cmd;
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			SqlDataReader rdr1=null,rdr=null;
			string Tank=DropTankID.SelectedItem.Text;
			string[] TankID=Tank.Split(new char[] {':'},Tank.Length);
			string str="select Prod_ID from Products where Prod_Name=(select Prod_Name from Tank where Tank_ID='"+TankID[0].ToString().Trim()+"')";
			rdr=obj.GetRecordSet(str);
			if(rdr.Read())
			{
				string str1="select * from Stock_Master where Productid='"+rdr["Prod_ID"].ToString()+"' order by Stock_date";
				rdr1=obj1.GetRecordSet(str1);
				double OS=0,CS=0,k=0;
				while(rdr1.Read())
				{
					if(k==0)
					{
						OS=double.Parse(rdr1["opening_stock"].ToString());
						k++;
					}
					else
						OS=CS;
					CS=OS+double.Parse(rdr1["receipt"].ToString())-double.Parse(rdr1["sales"].ToString());
					Con.Open();
					cmd = new SqlCommand("update Stock_Master set opening_stock='"+OS.ToString()+"', Closing_Stock='"+CS.ToString()+"' where ProductID='"+rdr1["Productid"].ToString()+"' and Stock_Date='"+rdr1["stock_date"].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					Con.Close();
				}
				rdr1.Close();
			}
			rdr.Close();
		}
	}
}