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
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using DBOperations;
using System.Data.SqlClient;  

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for CashSalesInvoice.
	/// </summary>
	public class CashSalesInvoice : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextSelect;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TxtCrLimit1;
		protected System.Web.UI.WebControls.TextBox txtTempQty1;
		protected System.Web.UI.WebControls.TextBox txtTempQty2;
		protected System.Web.UI.WebControls.TextBox txtTempQty3;
		protected System.Web.UI.WebControls.TextBox txtTempQty4;
		protected System.Web.UI.WebControls.TextBox TextBox7;
		protected System.Web.UI.WebControls.TextBox txtTempQty5;
		protected System.Web.UI.WebControls.TextBox txtTempQty6;
		protected System.Web.UI.WebControls.TextBox txtTempQty7;
		protected System.Web.UI.WebControls.TextBox txtTempQty8;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList dropInvoiceNo;
		protected System.Web.UI.WebControls.Label lblInvoiceNo;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Label lblInvoiceDate;
		protected System.Web.UI.WebControls.Label lblEntryBy;
		protected System.Web.UI.WebControls.Label lblEntryTime;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty5;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtVen;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox1;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtEnd;
		protected System.Web.UI.HtmlControls.HtmlInputText Txtstart;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtCrLimit;
		protected System.Web.UI.HtmlControls.HtmlInputHidden temptext;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty8;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtVatRate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtVatValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSlipTemp;
		protected System.Web.UI.HtmlControls.HtmlInputHidden SlipNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden lblVehicleNo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator4;
		protected System.Web.UI.WebControls.TextBox txtAmount1;
		protected System.Web.UI.WebControls.TextBox txtRate1;
		protected System.Web.UI.WebControls.TextBox txtQty1;
		protected System.Web.UI.WebControls.DropDownList DropProd1;
		protected System.Web.UI.WebControls.TextBox txtAmount2;
		protected System.Web.UI.WebControls.TextBox txtRate2;
		protected System.Web.UI.WebControls.TextBox txtQty2;
		protected System.Web.UI.WebControls.DropDownList DropProd2;
		protected System.Web.UI.WebControls.TextBox txtAmount3;
		protected System.Web.UI.WebControls.TextBox txtRate3;
		protected System.Web.UI.WebControls.TextBox txtQty3;
		protected System.Web.UI.WebControls.DropDownList DropProd3;
		protected System.Web.UI.WebControls.TextBox txtAmount4;
		protected System.Web.UI.WebControls.TextBox txtRate4;
		protected System.Web.UI.WebControls.TextBox txtQty4;
		protected System.Web.UI.WebControls.DropDownList DropProd4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName4;
		protected System.Web.UI.WebControls.DropDownList DropVehicleNo;
		protected System.Web.UI.WebControls.TextBox txtVehicleNo;
		protected System.Web.UI.WebControls.DropDownList DropCustName;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPetrolSales;
		protected System.Web.UI.HtmlControls.HtmlInputText txtDieselSales;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSPetrolSales;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSDieselSales;
		protected System.Web.UI.WebControls.TextBox txtGrandTotal;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);	
	
		string uid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				//uid=(Session["User_Name"].ToString());
				//GetProducts();
				//FetchData();
			}
			catch(Exception ex)
			{				
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:pageload"+ ex.Message+"  EXCEPTION "+"   "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				try
				{
				//	checkPrevileges();
					lblInvoiceDate.Text=GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());  
					lblEntryTime.Text=DateTime.Now.ToString ();
					//lblEntryBy.Text =Session["User_Name"].ToString();
					
					InventoryClass  obj=new InventoryClass ();
					//SqlDataReader SqlDtr;
					//string sql;
					//GetNextInvoiceNo();
				
//					#region Fetch the Product Types and fill in the ComboBoxes
//					sql="select distinct Category from Products";
//					for(int j=0;j<ProductType.Length;j++)
//					{
//						SqlDtr = obj.GetRecordSet(sql); 
//						while(SqlDtr.Read())
//						{				
//							ProductType[j].Items.Add(SqlDtr.GetValue(0).ToString());  
//						}					
//						SqlDtr.Close();
//					}
//					#endregion

//					#region Fetch All Customer ID and fill in the ComboBox
//					sql="select Cust_Name from Customer order by Cust_Name";
//					SqlDtr=obj.GetRecordSet(sql);
//					while(SqlDtr.Read())
//					{
//						DropCustName.Items.Add (SqlDtr.GetValue(0).ToString ());				
//					}
//					SqlDtr.Close ();		
//					#endregion

					//FetchData();

					/////////////////////////////////////////////////////////
					//GetProducts();
					//FetchData();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:pageload.   EXCEPTION: "+ ex.Message+"  User_ID: "+uid);   
				}
				
				//////////////////////////////////////////////////////////
				///

				// This block of code first time on page load checks the pre print template file available or not according to it displays the warning message, and disables the pre print button.
				try
				{
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					string path = home_drive+@"\Inetpub\wwwroot\EPetro\InvoiceDesigner\PrePrintTemplate.INI";
					StreamReader  sr = new StreamReader(path);
					Button1.Enabled = true; 
					sr.Close();
				}
				catch(System.IO.FileNotFoundException)
				{
					MessageBox.Show("If you want to use Pre Print service then you have to execute PrintWizard\nto generate the Pre Print Template.");
					Button1.Enabled = false; 
				}
			}
		}

		public void GetNextInvoiceNo()
		{
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
	
			#region Fetch the Next Invoice Number
			sql="select max(Invoice_No)+1 from Sales_Master";
			SqlDtr=obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				lblInvoiceNo.Text =SqlDtr.GetValue(0).ToString ();				
				if(lblInvoiceNo.Text=="")
					lblInvoiceNo.Text ="1001";
			}
			SqlDtr.Close ();		
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
