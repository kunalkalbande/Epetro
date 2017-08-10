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
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using DBOperations; 

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for PurchaseReturn.
	/// </summary>
	public class PurchaseReturn : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Label lblInvoiceDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.TextBox txtQty1;
		protected System.Web.UI.WebControls.TextBox txtRate1;
		protected System.Web.UI.WebControls.TextBox txtAmount1;
		protected System.Web.UI.WebControls.TextBox txtQty2;
		protected System.Web.UI.WebControls.TextBox txtRate2;
		protected System.Web.UI.WebControls.TextBox txtAmount2;
		protected System.Web.UI.WebControls.TextBox txtQty3;
		protected System.Web.UI.WebControls.TextBox txtRate3;
		protected System.Web.UI.WebControls.TextBox txtAmount3;
		protected System.Web.UI.WebControls.TextBox txtQty4;
		protected System.Web.UI.WebControls.TextBox txtRate4;
		protected System.Web.UI.WebControls.TextBox txtAmount4;
		protected System.Web.UI.WebControls.TextBox txtQty5;
		protected System.Web.UI.WebControls.TextBox txtRate5;
		protected System.Web.UI.WebControls.TextBox txtAmount5;
		protected System.Web.UI.WebControls.TextBox txtQty6;
		protected System.Web.UI.WebControls.TextBox txtRate6;
		protected System.Web.UI.WebControls.TextBox txtAmount6;
		protected System.Web.UI.WebControls.TextBox txtQty7;
		protected System.Web.UI.WebControls.TextBox txtRate7;
		protected System.Web.UI.WebControls.TextBox txtAmount7;
		protected System.Web.UI.WebControls.TextBox txtQty8;
		protected System.Web.UI.WebControls.TextBox txtRate8;
		protected System.Web.UI.WebControls.TextBox txtAmount8;
		protected System.Web.UI.WebControls.TextBox txtPromoScheme;
		protected System.Web.UI.WebControls.TextBox txtGrandTotal;
		protected System.Web.UI.WebControls.TextBox txtRemark;
		protected System.Web.UI.WebControls.TextBox txtCashDisc;
		protected System.Web.UI.WebControls.TextBox txtCashDiscType;
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.RadioButton No;
		protected System.Web.UI.WebControls.RadioButton Yes;
		protected System.Web.UI.WebControls.TextBox txtVAT;
		protected System.Web.UI.WebControls.TextBox txtDisc;
		protected System.Web.UI.WebControls.TextBox txtDiscType;
		protected System.Web.UI.WebControls.TextBox txtNetAmount;
		protected System.Web.UI.WebControls.Label lblEntryBy;
		protected System.Web.UI.WebControls.Label lblEntryTime;
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
		protected System.Web.UI.HtmlControls.HtmlInputText lblPlace;
		protected System.Web.UI.HtmlControls.HtmlInputText lblVehicleNo;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName4;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack4;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName8;
		protected System.Web.UI.HtmlControls.HtmlInputText lblVendName;
		protected System.Web.UI.HtmlControls.HtmlInputText lblVendInvoiceNo;
		protected System.Web.UI.HtmlControls.HtmlInputText lblVendInvoiceDate;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack8;
		DBUtil dbobj = new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check1;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckAll;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpGrandTotal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpCashDisc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpVatAmount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpDisc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpNetAmount;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check2;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check3;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check4;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check5;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check6;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check7;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check8;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempTaxEntry;	
		string uid= "";

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
                TxtCrLimit1.Attributes.Add("readonly", "readonly");
                lblVendInvoiceNo.Attributes.Add("readonly", "readonly");
                lblVendInvoiceDate.Attributes.Add("readonly", "readonly");
                lblVendName.Attributes.Add("readonly", "readonly");
                lblPlace.Attributes.Add("readonly", "readonly");
                lblVehicleNo.Attributes.Add("readonly", "readonly");
                txtProdName1.Attributes.Add("readonly", "readonly");
                txtPack1.Attributes.Add("readonly", "readonly");
                txtRate1.Attributes.Add("readonly", "readonly");
                txtAmount1.Attributes.Add("readonly", "readonly");
                txtProdName2.Attributes.Add("readonly", "readonly");
                txtPack2.Attributes.Add("readonly", "readonly");
                txtRate2.Attributes.Add("readonly", "readonly");
                txtAmount2.Attributes.Add("readonly", "readonly");
                txtProdName3.Attributes.Add("readonly", "readonly");
                txtPack3.Attributes.Add("readonly", "readonly");
                txtRate3.Attributes.Add("readonly", "readonly");
                txtAmount3.Attributes.Add("readonly", "readonly");
                txtProdName4.Attributes.Add("readonly", "readonly");
                txtPack4.Attributes.Add("readonly", "readonly");
                txtRate4.Attributes.Add("readonly", "readonly");
                txtAmount4.Attributes.Add("readonly", "readonly");
                txtProdName5.Attributes.Add("readonly", "readonly");
                txtPack5.Attributes.Add("readonly", "readonly");
                txtRate5.Attributes.Add("readonly", "readonly");
                txtAmount5.Attributes.Add("readonly", "readonly");
                txtProdName6.Attributes.Add("readonly", "readonly");
                txtPack6.Attributes.Add("readonly", "readonly");
                txtRate6.Attributes.Add("readonly", "readonly");
                txtAmount6.Attributes.Add("readonly", "readonly");
                TextBox1.Attributes.Add("readonly", "readonly");
                txtProdName7.Attributes.Add("readonly", "readonly");
                txtPack7.Attributes.Add("readonly", "readonly");
                txtRate7.Attributes.Add("readonly", "readonly");
                txtAmount7.Attributes.Add("readonly", "readonly");
                txtProdName8.Attributes.Add("readonly", "readonly");
                txtPack8.Attributes.Add("readonly", "readonly");
                txtRate8.Attributes.Add("readonly", "readonly");
                txtAmount8.Attributes.Add("readonly", "readonly");
                txtPromoScheme.Attributes.Add("readonly", "readonly");
                txtGrandTotal.Attributes.Add("readonly", "readonly");
                txtRemark.Attributes.Add("readonly", "readonly");
                txtCashDisc.Attributes.Add("readonly", "readonly");
                txtCashDiscType.Attributes.Add("readonly", "readonly");
                txtMessage.Attributes.Add("readonly", "readonly");
                txtVAT.Attributes.Add("readonly", "readonly");
                txtDisc.Attributes.Add("readonly", "readonly");
                txtDiscType.Attributes.Add("readonly", "readonly");
                txtNetAmount.Attributes.Add("readonly", "readonly");





                uid =(Session["User_Name"].ToString());
				txtMessage.Text =(Session["Message"].ToString());
				txtVatRate.Value  = (Session["VAT_Rate"].ToString());  
				lblEntryBy.Text = uid;
				lblEntryTime.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm:ss tt");
                if (!Page.IsPostBack)
				{
					getTaxEntry();
					checkPrevileges(); 
					getInvoiceNo();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaseReturn.aspx,Method:page_load  EXCEPTION: "+ ex.Message+"  User: "+uid);	
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
		}

		/// <summary>
		/// Its Checks the user privileges
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="4";
			string SubModule="7";
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
			if(Add_Flag=="0"  && View_flag =="0")
			{
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				return;
			}

			if(Add_Flag=="0")
			{
				btnSave.Enabled = false; 
			}
			#endregion				
		}

		/// <summary>
		/// Its fetch the invoice no.s from Purchase_details table except those r present in Purchase_Return_Master table.
		/// </summary>
		public void getInvoiceNo()
		{
			try
			{
				SqlDataReader SqlDtr = null;
				dropInvoiceNo.Items.Clear();
				dropInvoiceNo.Items.Add("Select");
				//dbobj.SelectQuery("Select distinct pd.Invoice_No from Purchase_Details pd where pd.Invoice_No not in (Select Invoice_No from Purchase_Return_Master) ",ref SqlDtr);
				dbobj.SelectQuery("(Select distinct pd.Invoice_No from Purchase_Details pd where pd.Invoice_No not in (Select Invoice_No from Purchase_Return_Master)) union (Select distinct fpd.Invoice_No from Fuel_Purchase_Details fpd where fpd.Invoice_No not in (Select Invoice_No from Purchase_Return_Master))",ref SqlDtr);
				while(SqlDtr.Read())
				{
					dropInvoiceNo.Items.Add(SqlDtr["Invoice_No"].ToString());   
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaseReturn.aspx,Method:getInvoiceNo()  EXCEPTION: "+ ex.Message+"  User: "+uid);	
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
			this.dropInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.dropInvoiceNo_SelectedIndexChanged);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Its gets the selected invoice no. and display the details in form.
		/// </summary>
		private void dropInvoiceNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			InventoryClass  obj=new InventoryClass ();
			
			try
			{
				if(dropInvoiceNo.SelectedIndex == 0  )
				{
					MessageBox.Show("Please Select Invoice No");
				}
				else
				{
					Clear();
					HtmlInputText[] Name={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
					HtmlInputText[] Type={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
					TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
					TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
					TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8}; 			
					TextBox[]  Quantity = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8 };
					HtmlInputCheckBox[] Check = {Check1,Check2,Check3,Check4,Check5,Check6,Check7,Check8};
					HtmlInputHidden[] tmpQty = {tmpQty1,tmpQty2,tmpQty3,tmpQty4,tmpQty5,tmpQty6,tmpQty7,tmpQty8};
					SqlDataReader SqlDtr,rdr;
					string sql;
					string strDate,strDate1;
					int i=0;
					sql="select * from Purchase_Master where Invoice_No='"+ dropInvoiceNo.SelectedItem.Value +"'";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						strDate = SqlDtr.GetValue(1).ToString().Trim();
						int pos = strDate.IndexOf(" ");
						if(pos != -1)
						{
							strDate = strDate.Substring(0,pos);
						}
						else
						{
							strDate = "";
						}

						strDate1 = SqlDtr.GetValue(6).ToString().Trim();
						pos = strDate1.IndexOf(" ");
				
						if(pos != -1)
						{
							strDate1 = strDate1.Substring(0,pos);
						}
						else
						{
							strDate1 = "";
						}
						lblInvoiceDate.Text =GenUtil.str2DDMMYYYY(strDate);
						lblVehicleNo.Value=SqlDtr.GetValue(4).ToString();
						lblVendInvoiceNo.Value =SqlDtr.GetValue(5).ToString();
						lblVendInvoiceDate.Value =GenUtil.str2DDMMYYYY(strDate1);
						txtGrandTotal.Text=GenUtil.strNumericFormat(SqlDtr.GetValue(7).ToString());
						tmpGrandTotal.Value = GenUtil.strNumericFormat(SqlDtr.GetValue(7).ToString());
						txtDisc.Text=SqlDtr.GetValue(8).ToString();
						tmpDisc.Value = SqlDtr.GetValue(8).ToString();
						txtDiscType.Text = SqlDtr.GetValue(9).ToString();
						if(txtDiscType.Text =="Per")
							txtDiscType.Text = "%"; 
						txtNetAmount.Text =GenUtil.strNumericFormat(SqlDtr.GetValue(10).ToString());
						tmpNetAmount.Value = GenUtil.strNumericFormat(SqlDtr.GetValue(10).ToString());
						txtPromoScheme.Text= SqlDtr.GetValue(11).ToString();
						txtRemark.Text=SqlDtr.GetValue(12).ToString();
						lblEntryBy.Text=SqlDtr.GetValue(13).ToString();
						lblEntryTime.Text= SqlDtr.GetValue(14).ToString();
						txtCashDisc.Text=SqlDtr.GetValue(15).ToString();
						txtCashDisc.Text = GenUtil.strNumericFormat(txtCashDisc.Text.ToString());
						tmpCashDisc.Value = txtCashDisc.Text;
						txtCashDiscType.Text = SqlDtr.GetValue(16).ToString();
						if(txtCashDiscType.Text =="Per")
							txtCashDiscType.Text = "%";
						txtVAT.Text =  SqlDtr.GetValue(17).ToString();
						tmpVatAmount.Value = SqlDtr.GetValue(17).ToString();
						if(txtVAT.Text.Trim() == "0")
						{
							Yes.Checked = false;
							No.Checked = true;
						}
						else
						{
							No.Checked = false;
							Yes.Checked = true;
						}
					}
					SqlDtr.Close();
			
					sql="select s.Supp_Name,s.City from Supplier as s, Purchase_Master as p where p.Invoice_No='"+dropInvoiceNo.SelectedValue +"' and S.Supp_ID = P.Vendor_ID ";
					SqlDtr=obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						lblVendName.Value = SqlDtr.GetValue(0).ToString();
						lblPlace.Value=SqlDtr.GetValue(1).ToString();
					}
					SqlDtr.Close();

					#region Get Data from Purchase Details Table regarding Invoice No.
					sql="select p.Category,p.Prod_Name,p.Pack_Type,	pd.qty,pd.rate,pd.amount"+
						" from Products p, Purchase_Details pd"+
						" where p.Prod_ID=pd.prod_id and pd.invoice_no='"+ dropInvoiceNo.SelectedItem.Value +"'" ;
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							//Qty[i].Enabled = true;
							Check[i].Checked = false;
							Name[i].Value=SqlDtr.GetValue(1).ToString();   
							Type[i].Value=SqlDtr.GetValue(2).ToString();   
							Qty[i].Text=SqlDtr.GetValue(3).ToString();
							Quantity[i].Text = Qty[i].Text;
							tmpQty[i].Value = Qty[i].Text;
							Rate[i].Text=SqlDtr.GetValue(4).ToString();
							Amount[i].Text=SqlDtr.GetValue(5).ToString();
							i++;
						}
						while(i<8)
						{
				
							Qty[i].Text="";
							Qty[i].Enabled = false;
							tmpQty[i].Value = "";
							Check[i].Checked = false; 
							i++;
						}
						SqlDtr.Close();
					}
						//********************			
					else
					{
						InventoryClass  obj1=new InventoryClass ();
						sql="select p.Category,p.Prod_Name,p.Pack_Type,	pd.qty,pd.rate,pd.amount"+
							" from Products p, Fuel_Purchase_Details pd"+
							" where p.Prod_ID=pd.prod_id and pd.invoice_no='"+ dropInvoiceNo.SelectedItem.Value +"'" ;
						rdr=obj1.GetRecordSet(sql);
						if(rdr.HasRows)
						{
							while(rdr.Read())
							{
								//Qty[i].Enabled = true;
								Check[i].Checked = false;
								Name[i].Value=rdr.GetValue(1).ToString();   
								Type[i].Value=rdr.GetValue(2).ToString();   
								Qty[i].Text=rdr.GetValue(3).ToString();
								Quantity[i].Text = Qty[i].Text;
								tmpQty[i].Value = Qty[i].Text;
								Rate[i].Text=System.Convert.ToString(double.Parse(rdr.GetValue(4).ToString())/double.Parse(rdr.GetValue(3).ToString()));
								Amount[i].Text=rdr.GetValue(5).ToString();
								i++;
							}
							while(i<8)
							{
								Qty[i].Text="";
								Qty[i].Enabled = false;
								tmpQty[i].Value = "";
								Check[i].Checked = false; 
								Check[i].Disabled = true; 
								i++;
							}
							rdr.Close();
						}
					}
					//********************
					CheckAll.Checked = false;
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaseReturn.aspx,Method:btnSaved_Click,Class:PartiesClass.cs,Method :dropInvoiceNo_SelectedIndexChanged  EXCEPTION  "+ex.Message+"  userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to clears the form.
		/// </summary>
		public void Clear()
		{
			lblInvoiceDate.Text = "";
			lblVendInvoiceDate.Value = "";
			lblVendInvoiceNo.Value = "";
			lblVendName.Value = "";
			lblPlace.Value = "";
			lblVehicleNo.Value = "";
			txtPromoScheme.Text = "";
			txtRemark.Text = "";
			txtGrandTotal.Text = "";
			txtDisc.Text = "";
			txtDiscType.Text = "";
			txtVAT.Text = "";
			No.Checked = false;
			Yes.Checked = true;
			txtCashDisc.Text = "";
			txtCashDiscType.Text = "";
			txtNetAmount.Text = "";
			tmpNetAmount.Value = "";
			tmpGrandTotal.Value ="";
			tmpDisc.Value ="";
			tmpCashDisc.Value ="";
			tmpVatAmount.Value = "";

			HtmlInputText[] Name={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8};
			HtmlInputText[] Type={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8};
			TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8};
			TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8};
			TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8};
			TextBox[]  Quantity = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8 };
			HtmlInputCheckBox[] Check = {Check1,Check2,Check3,Check4,Check5,Check6,Check7,Check8};
			HtmlInputHidden[] tmpQty = {tmpQty1,tmpQty2,tmpQty3,tmpQty4,tmpQty5,tmpQty6,tmpQty7,tmpQty8};

			for(int i=0; i<Name.Length; i++)
			{
				Name[i].Value = "";
				Type[i].Value = "";
				Qty[i].Text = "";
				Rate[i].Text = "";
				Amount[i].Text = "";
				Quantity[i].Text = "";
				Check[i].Checked = false;
				Check[i].Disabled=false;
				tmpQty[i].Value = "";
			}
			CheckAll.Checked = false;
		}

		/// <summary>
		/// Its saves the purchase return details with the help of stored procedure.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			InventoryClass  obj = new InventoryClass();
			if(dropInvoiceNo.SelectedIndex == 0)
			{
				MessageBox.Show("Please Select Invoice No.");
				return;
			}

			int c = 0;
			HtmlInputCheckBox[] Check = {Check1,Check2,Check3,Check4,Check5,Check6,Check7,Check8};
			for(int i=0;i < Check.Length ; i++)
			{
				if(Check[i].Checked == false)
				{
					c++;
				}
			}
			if(c == 8)
			{
				MessageBox.Show("Please select a Product to return");
				return;
			}
			try
			{
				int count = 0;
				//This used to solve the double click problem. Its checks the Purchase Return and Invoice no and display the popup.
				dbobj.ExecuteScalar("Select count(Invoice_No) from Purchase_Return_Master where Invoice_No = "+dropInvoiceNo.SelectedItem.Text.Trim(),ref count);
				if(count > 0)
				{
					MessageBox.Show("Purchase Return Saved");
					Clear();
					getInvoiceNo();
					dropInvoiceNo.SelectedIndex = 0;
					return;
				}
				obj.Invoice_Date=System.Convert.ToDateTime(GenUtil.str2MMDDYYYY (lblInvoiceDate.Text.ToString()));
				obj.Vendor_Name=lblVendName.Value.ToString();
				obj.City=lblPlace.Value .ToString();
				obj.Vehicle_No=lblVehicleNo.Value;
				obj.Vendor_Invoice_No =lblVendInvoiceNo.Value;
				obj.Vendor_Invoice_Date=GenUtil.str2MMDDYYYY(lblVendInvoiceDate.Value);
				obj.Grand_Total =txtGrandTotal.Text;
				if(txtDisc.Text=="")
					obj.Discount ="0.0";
				else
					obj.Discount =txtDisc.Text;
				obj.Discount_Type=txtDiscType.Text;
				obj.Net_Amount =txtNetAmount.Text;
				obj.Promo_Scheme=txtPromoScheme.Text;
				obj.Remerk =txtRemark.Text;
				obj.Entry_By =lblEntryBy.Text;
				obj.Entry_Time =DateTime.Parse(lblEntryTime .Text);
				if(txtCashDisc.Text.Trim() =="")
					obj.Cash_Discount  ="0.0";
				else
					obj.Cash_Discount  = txtCashDisc.Text.Trim();
				obj.Cash_Disc_Type =txtDiscType.Text;
				obj.VAT_Amount = txtVAT.Text.Trim();
				obj.Invoice_No = dropInvoiceNo.SelectedItem.Text;
				obj.Pre_Amount = tmpNetAmount.Value;
				//Calls the InsertPurchaseReturnMaster which calls the ProInsertPurchaseReturnMaster procedure to insert the Purchase Return master details.
				obj.InsertPurchaseReturnMaster();
	
				HtmlInputText[]  ProdName={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8};
				HtmlInputText[]  PackType={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8};
				TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8};
				TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8};
				TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8};
				TextBox[]  Quantity = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8};
				//calls the save fucntion to save the purchase return details of only the return products.
				for(int j=0;j<ProdName.Length ;j++)
				{
					if(Check[j].Checked == false )
						continue;
					Save(ProdName[j].Value,PackType[j].Value,Qty[j].Text.ToString(),Rate[j].Text.ToString (),Amount[j].Text.ToString ());
				}
		
				MessageBox.Show("Purchase Return Saved");
				CreateLogFiles.ErrorLog("Form:PurchaseReturn.aspx,Method:btnSaved_Click,Class:PartiesClass.cs"+"  Purchase Return for  Invoice No."+obj.Invoice_No+" is Saved  Userid: "+uid);
				reportmaking(); 
				//print();
				Clear();
				getInvoiceNo();
				dropInvoiceNo.SelectedIndex = 0;  
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaseReturn.aspx,Method:btnSaved_Click,Class:PartiesClass.cs  EXCEPTION: "+ex.Message+"    Userid: "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to fatch the all tax entry according to product id and show the data with the help of java script.
		/// </summary>
		public void getTaxEntry()
		{
			SqlDataReader rdr=null,SqlDtr=null;
			string str=""; 
			dbobj.SelectQuery("select ProductId,Reduction,entry_tax,rpg_charge,rpg_surcharge,LT_Charge,Tran_charge,Other_lvy,LST,LST_surcharge,LF_recov,dofobc_charge,Unit_rdc,unit_etax,unit_rpgchg,unit_rpgschg,unit_ltchg,unit_tchg,unit_olvy,unit_lst,unit_lstschg,unit_lfrecov,unit_dochg from tax_entry",ref rdr);
			while(rdr.Read())
			{
				dbobj.SelectQuery("select Prod_Name from Products where Prod_ID="+rdr.GetValue(0).ToString(),ref SqlDtr);
				if(SqlDtr.Read())
				{
					str+=":"+SqlDtr.GetValue(0).ToString();
				}
				for(int i=1;i<23;i++)
				{
					str+=":"+rdr.GetValue(i).ToString();
				}
				str+="~";
			}
			tempTaxEntry.Value=str;
			//MessageBox.Show(tempTaxEntry.Value);
		}
		
		/// <summary>
		/// This calls the fucntion InsertPurchaseReturnDetails() which calls the Procedure ProInsertPurchaseReturnMaster to enter the details of return products.
		/// </summary>
		public void Save(string ProdName,string PackType, string Qty, string Rate,string Amount)
		{
			InventoryClass obj=new InventoryClass();
			obj.Product_Name=ProdName ;
			obj.Package_Type=PackType ;
			obj.Qty=Qty;
			obj.Rate=Rate;
			obj.Invoice_No=dropInvoiceNo.SelectedItem.Value;
			obj.InsertPurchaseReturnDetail(); 
		}
		
		/// <summary>
		/// Creates the report file PurchaseReturn.txt and fetch the screen details of a return products and writes it into a file for printing.
		/// </summary>
		public void reportmaking()
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\PurchaseReturnReport.txt";
					
			StreamWriter sw = new StreamWriter(path);
			string info = "";
			string strInvNo="";
			string strDiscType = "";
			double disc_amt=0;
			HtmlInputCheckBox[] Check = {Check1,Check2,Check3,Check4,Check5,Check6,Check7,Check8};
			HtmlInputText[]  ProdName={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
			HtmlInputText[]  PackType={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
			TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
			TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8};
			TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8};
			string[] products = {"","","","","","","",""};
			string[] qty = {"","","","","","","",""};
			string[] rate = {"","","","","","","",""};
			string[] amt = {"","","","","","","",""};
			int j = 0;
			for(int i = 0; i < Check.Length ; i++)
			{
				if(Check[i].Checked)
				{
					products[j] = ProdName[i].Value +" "+PackType[i].Value ;
					qty[j] = Qty[i].Text ;
					rate[j] = Rate[i].Text;
					amt[j] = Amount[i].Text;
					j++;
				}
			}

			string msg ="";

			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu
			// Condensed
			sw.Write((char)27);
			sw.Write((char)15);
			sw.WriteLine("");

			//*******************
			string des="------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//******************
			sw.WriteLine(GenUtil.GetCenterAddr("=================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("PURCHASE RETURN",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=================",des.Length));
			strInvNo = dropInvoiceNo.SelectedItem.Text;   

			sw.WriteLine("Invoice No : " +strInvNo+ "                               Date : " +lblInvoiceDate.Text.ToString());
			sw.WriteLine("+----------------------------------------------------------------+");
			sw.WriteLine("Vendor Name             : " + lblVendName.Value);
			sw.WriteLine("Place                   :  " + lblPlace.Value);
			sw.WriteLine("Vendor Invoice No       :  " + lblVendInvoiceNo.Value);
			sw.WriteLine("Vendor Invoice Date     :  " + lblVendInvoiceDate.Value);
			sw.WriteLine("+------------------------------+-----------+----------+----------+");
			sw.WriteLine("|      Product Name            | Quantity  |   Rate   |  Amount  |");
			sw.WriteLine("+------------------------------+-----------+----------+----------+");
			info = " {0,-30:S} {1,10:F}  {2,10:F} {3,10:F}";
			// Writes the return details  upto to 8 products and  otherwise if less then writes the blank value.
			sw.WriteLine(info,products[0]  ,qty[0],rate[0],GenUtil.strNumericFormat(amt[0]));
			sw.WriteLine(info,products[1]  ,qty[1],rate[1],GenUtil.strNumericFormat(amt[1]));
			sw.WriteLine(info,products[2]  ,qty[2],rate[2],GenUtil.strNumericFormat(amt[2]));
			sw.WriteLine(info,products[3]  ,qty[3],rate[3],GenUtil.strNumericFormat(amt[3]));
			sw.WriteLine(info,products[4]  ,qty[4],rate[4],GenUtil.strNumericFormat(amt[4]));
			sw.WriteLine(info,products[5]  ,qty[5],rate[5],GenUtil.strNumericFormat(amt[5]));
			sw.WriteLine(info,products[6]  ,qty[6],rate[6],GenUtil.strNumericFormat(amt[6]));
			sw.WriteLine(info,products[7]  ,qty[7],rate[7],GenUtil.strNumericFormat(amt[7]));
		
			sw.WriteLine("+------------------------------+-----------+----------+----------+");
		
			sw.WriteLine("                               Grand Total           : {0,10:F}" , GenUtil.strNumericFormat(txtGrandTotal.Text.ToString() ));
			disc_amt=0;
			msg ="";
			if(txtCashDisc .Text=="")
			{
				strDiscType="";
				msg = "";
			}
			else
			{
				disc_amt = System.Convert.ToDouble(txtCashDisc.Text.ToString()); 
				strDiscType= txtCashDiscType.Text ;
				if(strDiscType.Trim().Equals("%"))
				{
					double temp =0;
					if(txtGrandTotal.Text.Trim() != "")
						temp = System.Convert.ToDouble(txtGrandTotal.Text.Trim().ToString());
 
					disc_amt  = (temp*disc_amt/100);
					msg = "("+txtCashDisc.Text.ToString()+strDiscType+")";
						
				}
				else
				{
					msg ="("+strDiscType+")";
				}			
			}
			sw.WriteLine("                               Cash Discount{0,-8:S} : {1,10:F}" ,msg,GenUtil.strNumericFormat(disc_amt.ToString()));
			string Vat_Rate = "";
			string amount = "0";
			if(Yes.Checked)
			{
				Vat_Rate = "("+Session["VAT_Rate"].ToString()+"%)";
				amount = txtVAT.Text.Trim();  
			}
 
			sw.WriteLine("                               VAT          {0,-8:S} : {1,10:F}" ,Vat_Rate,GenUtil.strNumericFormat(amount));
			disc_amt=0;
			msg ="";
			if(txtDisc.Text=="")
			{
				strDiscType="";
				msg = "";
			}
			else
			{
				disc_amt = System.Convert.ToDouble(txtDisc.Text.ToString()); 
				strDiscType= txtDiscType.Text ;
				if(strDiscType.Trim().Equals("%"))
				{
					double temp =0;
					if(txtGrandTotal.Text.Trim() != "")
						temp = System.Convert.ToDouble(txtGrandTotal.Text.Trim().ToString());
 
					disc_amt  = (temp*disc_amt/100);
					msg = "("+txtDisc.Text.ToString()+strDiscType+")";
						
				}
				else
				{
					msg ="("+strDiscType+")";
				}			
			}
			sw.WriteLine("                               Discount     {0,-8:S} : {1,10:F}" ,msg,GenUtil.strNumericFormat(disc_amt.ToString()));
			sw.WriteLine("                               Net Amount            : {0,10:F}" , GenUtil.strNumericFormat(txtNetAmount.Text.ToString()));
			sw.WriteLine("+----------------------------------------------------------------+");
			sw.WriteLine("Promo Scheme : " + txtPromoScheme.Text);
			sw.WriteLine("Remarks      : " + txtRemark.Text);
			sw.WriteLine("Message      : " + txtMessage.Text);
			sw.WriteLine("");
			sw.WriteLine("");
			sw.WriteLine("");
			sw.WriteLine("                                                Signature");

			sw.Close();
		}

		/// <summary>
		/// This method is used to sends the PurchaseReturn.txt file to Print Server for printing purpose.
		/// </summary>
		public void print()
		{
			byte[] bytes = new byte[1024];
			// Connect to a remote device.
			try 
			{
				// Establish the remote endpoint for the socket.
				// The name of the
				// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,60000);

				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );
				
				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);

					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\PurchaseReturnReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
                
				} 
				catch (ArgumentNullException ane) 
				{
					CreateLogFiles.ErrorLog("Form:PurchaseReturn.aspx,Method:print  ArgumentNullException : "+ane.Message+" Userid: "+uid);
				} 
				catch (SocketException se) 
				{
					CreateLogFiles.ErrorLog("Form:PurchaseReturn.aspx,Method:print  SocketException : "+se.Message+" Userid: "+uid);
				} 
				catch (Exception es) 
				{
					CreateLogFiles.ErrorLog("Form:PurchaseReturn.aspx,Method:print  Unexpected exception : "+ es.Message+" Userid: "+uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:purchaseReturn.aspx,Method:print.   EXCEPTION: "+ex.Message+" User: "+uid);
			}
		}

		/// <summary>
		/// Sends the PurchaseReturn.txt file to Print Server for printing purpose.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			//reportmaking();
			print();
		}
	}
}