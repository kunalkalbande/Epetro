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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for FuelPurchase.
	/// </summary>
	public class FuelPurchase : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtTax1;
		protected System.Web.UI.WebControls.TextBox txtTax2;
		protected System.Web.UI.WebControls.TextBox txtTax3;
		protected System.Web.UI.WebControls.TextBox txtTax4;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		public string tempstr="****";
		protected System.Web.UI.WebControls.TextBox temptext;
		protected System.Web.UI.WebControls.Label lblEntryTime;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext9;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext1;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext2;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext4;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext5;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext6;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext7;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext8;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext10;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext11;
		protected System.Web.UI.HtmlControls.HtmlInputText Duptext13;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox1;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox2;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox3;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox4;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox5;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox6;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox7;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox8;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox9;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox10;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox11;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox12;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox13;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox14;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox15;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox16;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox17;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox18;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox19;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox20;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox21;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox22;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox23;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox24;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox25;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox26;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox27;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox28;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox29;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox30;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox31;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox32;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox33;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox34;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox35;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox36;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox37;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox38;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox39;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox40;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox41;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox42;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox43;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox44;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox45;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox46;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox47;
		protected System.Web.UI.HtmlControls.HtmlInputText FuelText;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox textselect;
		protected System.Web.UI.WebControls.Label lblPlace1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblInvoiceNo;
		protected System.Web.UI.WebControls.DropDownList DropInvoiceNo;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Label lblInvoiceDate;
		protected System.Web.UI.WebControls.DropDownList DropModeType;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.DropDownList DropVendorID;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtVehicleNo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.TextBox txtVInvoiceNo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox txtVInvoiceDate;
		protected System.Web.UI.WebControls.Label lblComp1;
		protected System.Web.UI.WebControls.Label lblComp2;
		protected System.Web.UI.WebControls.Label lblComp3;
		protected System.Web.UI.WebControls.Label lblComp4;
		protected System.Web.UI.WebControls.DropDownList DropProd1;
		protected System.Web.UI.WebControls.DropDownList DropProd2;
		protected System.Web.UI.WebControls.DropDownList DropProd3;
		protected System.Web.UI.WebControls.DropDownList DropProd4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.TextBox txtQty1;
		protected System.Web.UI.WebControls.TextBox txtQty2;
		protected System.Web.UI.WebControls.TextBox txtQty3;
		protected System.Web.UI.WebControls.TextBox txtQty4;
		protected System.Web.UI.WebControls.TextBox txtRate1;
		protected System.Web.UI.WebControls.TextBox txtRate2;
		protected System.Web.UI.WebControls.TextBox txtRate3;
		protected System.Web.UI.WebControls.TextBox txtRate4;
		protected System.Web.UI.WebControls.TextBox txtDensityInPhysical1;
		protected System.Web.UI.WebControls.TextBox txtDensityInPhysical2;
		protected System.Web.UI.WebControls.TextBox txtDensityInPhysical3;
		protected System.Web.UI.WebControls.TextBox txtDensityInPhysical4;
		protected System.Web.UI.WebControls.TextBox txtTempInPhysical1;
		protected System.Web.UI.WebControls.TextBox txtTempInPhysical2;
		protected System.Web.UI.WebControls.TextBox txtTempInPhysical3;
		protected System.Web.UI.WebControls.TextBox txtTempInPhysical4;
		protected System.Web.UI.WebControls.TextBox txtConDensity1;
		protected System.Web.UI.WebControls.TextBox txtConDensity2;
		protected System.Web.UI.WebControls.TextBox txtConDensity3;
		protected System.Web.UI.WebControls.TextBox txtConDensity4;
		protected System.Web.UI.WebControls.TextBox txtDenConv1;
		protected System.Web.UI.WebControls.TextBox txtDenConv2;
		protected System.Web.UI.WebControls.TextBox txtDenConv3;
		protected System.Web.UI.WebControls.TextBox txtDenConv4;
		protected System.Web.UI.WebControls.TextBox txtDensityVariation1;
		protected System.Web.UI.WebControls.TextBox txtDensityVariation2;
		protected System.Web.UI.WebControls.TextBox txtDensityVariation3;
		protected System.Web.UI.WebControls.TextBox txtDensityVariation4;
		protected System.Web.UI.WebControls.TextBox txtDenAfterDec1;
		protected System.Web.UI.WebControls.TextBox txtDenAfterDec2;
		protected System.Web.UI.WebControls.TextBox txtDenAfterDec3;
		protected System.Web.UI.WebControls.TextBox txtDenAfterDec4;
		protected System.Web.UI.WebControls.TextBox txtTempAfterDec1;
		protected System.Web.UI.WebControls.TextBox txtTempAfterDec2;
		protected System.Web.UI.WebControls.TextBox txtTempAfterDec3;
		protected System.Web.UI.WebControls.TextBox txtTempAfterDec4;
		protected System.Web.UI.WebControls.TextBox txtConvDenAfterDec1;
		protected System.Web.UI.WebControls.TextBox txtConvDenAfterDec2;
		protected System.Web.UI.WebControls.TextBox txtConvDenAfterDec3;
		protected System.Web.UI.WebControls.TextBox txtConvDenAfterDec4;
		protected System.Web.UI.WebControls.TextBox txtReduction1;
		protected System.Web.UI.WebControls.TextBox txtReduction2;
		protected System.Web.UI.WebControls.TextBox txtReduction3;
		protected System.Web.UI.WebControls.TextBox txtReduction4;
		protected System.Web.UI.WebControls.TextBox txtEntryTax1;
		protected System.Web.UI.WebControls.TextBox txtEntryTax2;
		protected System.Web.UI.WebControls.TextBox txtEntryTax3;
		protected System.Web.UI.WebControls.TextBox txtEntryTax4;
		protected System.Web.UI.WebControls.TextBox txtRPGCharge1;
		protected System.Web.UI.WebControls.TextBox txtRPGCharge2;
		protected System.Web.UI.WebControls.TextBox txtRPGCharge3;
		protected System.Web.UI.WebControls.TextBox txtRPGCharge4;
		protected System.Web.UI.WebControls.TextBox txtRPGSurcharge1;
		protected System.Web.UI.WebControls.TextBox txtRPGSurcharge2;
		protected System.Web.UI.WebControls.TextBox txtRPGSurcharge3;
		protected System.Web.UI.WebControls.TextBox txtRPGSurcharge4;
		protected System.Web.UI.WebControls.TextBox txtLTC1;
		protected System.Web.UI.WebControls.TextBox txtLTC2;
		protected System.Web.UI.WebControls.TextBox txtLTC3;
		protected System.Web.UI.WebControls.TextBox txtLTC4;
		protected System.Web.UI.WebControls.TextBox txtTransportCharge1;
		protected System.Web.UI.WebControls.TextBox txtTransportCharge2;
		protected System.Web.UI.WebControls.TextBox txtTransportCharge3;
		protected System.Web.UI.WebControls.TextBox txtTransportCharge4;
		protected System.Web.UI.WebControls.TextBox txtOther1;
		protected System.Web.UI.WebControls.TextBox txtOther2;
		protected System.Web.UI.WebControls.TextBox txtOther3;
		protected System.Web.UI.WebControls.TextBox txtOther4;
		protected System.Web.UI.WebControls.TextBox txtLST1;
		protected System.Web.UI.WebControls.TextBox txtLST2;
		protected System.Web.UI.WebControls.TextBox txtLST3;
		protected System.Web.UI.WebControls.TextBox txtLST4;
		protected System.Web.UI.WebControls.TextBox txtLSTSurcharge1;
		protected System.Web.UI.WebControls.TextBox txtLSTSurcharge2;
		protected System.Web.UI.WebControls.TextBox txtLSTSurcharge3;
		protected System.Web.UI.WebControls.TextBox txtLSTSurcharge4;
		protected System.Web.UI.WebControls.TextBox txtLFR1;
		protected System.Web.UI.WebControls.TextBox txtLFR2;
		protected System.Web.UI.WebControls.TextBox txtLFR3;
		protected System.Web.UI.WebControls.TextBox txtLFR4;
		protected System.Web.UI.WebControls.TextBox txtDO1;
		protected System.Web.UI.WebControls.TextBox txtDO2;
		protected System.Web.UI.WebControls.TextBox txtDO3;
		protected System.Web.UI.WebControls.TextBox txtDO4;
		protected System.Web.UI.WebControls.TextBox txtAmount1;
		protected System.Web.UI.WebControls.TextBox txtAmount2;
		protected System.Web.UI.WebControls.TextBox txtAmount3;
		protected System.Web.UI.WebControls.TextBox txtAmount4;
		protected System.Web.UI.WebControls.Button cmdtot;
		protected System.Web.UI.WebControls.TextBox txtPromoScheme;
		protected System.Web.UI.WebControls.TextBox txtGrandTotal;
		protected System.Web.UI.WebControls.TextBox txtRemark;
		protected System.Web.UI.WebControls.TextBox txtDisc;
		protected System.Web.UI.WebControls.DropDownList DropDiscType;
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.TextBox txtNetAmount;
		protected System.Web.UI.WebControls.Label lblEntryBy;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputText lblPlace;
		protected System.Web.UI.WebControls.TextBox TextBox51;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtVen;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRate;
		protected System.Web.UI.HtmlControls.HtmlInputText txtReduction;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLTC;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLSTSurcharge;
		protected System.Web.UI.HtmlControls.HtmlInputText txtUnit6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEntryTax6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRPGCharge6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRPGSurcharge6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTransportCharge6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOther6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLSTSurcharge6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFR6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtDO6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtUnit;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEntryTax;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRPGCharge;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRPGSurcharge;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTransportCharge;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOther;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLST;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFR;
		protected System.Web.UI.HtmlControls.HtmlInputText txtDO;
		protected System.Web.UI.HtmlControls.HtmlInputText txtUnit5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtReduction5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEntryTax5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRPGCharge5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRPGSurcharge5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLTC5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTransportCharge5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOther5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLST5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLSTSurcharge5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFR5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtDO5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtReduction6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLTC6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLST6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtUnit7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtReduction7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEntryTax7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRPGCharge7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRPGSurcharge7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLTC7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTransportCharge7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOther7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLST7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLSTSurcharge7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFR7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtDO7;
		protected System.Web.UI.WebControls.Label lblETime;
		protected System.Web.UI.WebControls.TextBox txtTempQty1;
		protected System.Web.UI.WebControls.TextBox txtTempQty2;
		protected System.Web.UI.WebControls.TextBox txtTempQty3;
		protected System.Web.UI.WebControls.TextBox txtTempQty4;
		PetrolPumpClass ppc=new PetrolPumpClass();
		static string[] ProductType = new string[12];
		static string[] ProductName = new string[12];
		static string[] ProductPack = new string[12];
		static string[] ProductQty = new string[12];
		protected System.Web.UI.HtmlControls.HtmlInputText lblTinNo;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.TextBox TotalDisc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempRate1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempRate2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempRate3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempRate4;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempInvoiceInfo;
		string uid;
		static string Vendor_ID="0";

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
				// This displays the Message from Session to Message Text Box. from Organisation.
				txtMessage.Text = (Session["Message"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:pageload"+" EXCEPTION "+ex.Message+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			//btnDelete.Visible=false;
			if(tempInvoiceInfo.Value=="Yes")
			{
				DeleteTheRec();
			}
			if(!IsPostBack)
			{
				try
				{
                    lblPlace.Attributes.Add("readonly", "readonly");
                    txtVInvoiceDate.Attributes.Add("readonly", "readonly");
                    txtRate1.Attributes.Add("readonly", "readonly");
                    txtRate2.Attributes.Add("readonly", "readonly");
                    txtRate3.Attributes.Add("readonly", "readonly");
                    txtRate4.Attributes.Add("readonly", "readonly");
                    txtDensityVariation1.Attributes.Add("readonly", "readonly");
                    txtDensityVariation2.Attributes.Add("readonly", "readonly");
                    txtDensityVariation3.Attributes.Add("readonly", "readonly");
                    txtDensityVariation4.Attributes.Add("readonly", "readonly");
                    txtReduction1.Attributes.Add("readonly", "readonly");
                    txtReduction2.Attributes.Add("readonly", "readonly");
                    txtReduction3.Attributes.Add("readonly", "readonly");
                    txtReduction4.Attributes.Add("readonly", "readonly");
                    txtEntryTax1.Attributes.Add("readonly", "readonly");
                    txtEntryTax2.Attributes.Add("readonly", "readonly");
                    txtEntryTax3.Attributes.Add("readonly", "readonly");
                    txtEntryTax4.Attributes.Add("readonly", "readonly");
                    txtRPGCharge1.Attributes.Add("readonly", "readonly");
                    txtRPGCharge2.Attributes.Add("readonly", "readonly");
                    txtRPGCharge3.Attributes.Add("readonly", "readonly");
                    txtRPGCharge4.Attributes.Add("readonly", "readonly");
                    txtRPGSurcharge1.Attributes.Add("readonly", "readonly");
                    txtRPGSurcharge2.Attributes.Add("readonly", "readonly");
                    txtRPGSurcharge3.Attributes.Add("readonly", "readonly");
                    txtRPGSurcharge4.Attributes.Add("readonly", "readonly");
                    txtLTC1.Attributes.Add("readonly", "readonly");
                    txtLTC2.Attributes.Add("readonly", "readonly");
                    txtLTC3.Attributes.Add("readonly", "readonly");
                    txtLTC4.Attributes.Add("readonly", "readonly");
                    txtTransportCharge1.Attributes.Add("readonly", "readonly");
                    txtTransportCharge2.Attributes.Add("readonly", "readonly");
                    txtTransportCharge3.Attributes.Add("readonly", "readonly");
                    txtTransportCharge4.Attributes.Add("readonly", "readonly");
                    txtOther1.Attributes.Add("readonly", "readonly");
                    txtOther2.Attributes.Add("readonly", "readonly");
                    txtOther3.Attributes.Add("readonly", "readonly");
                    txtOther4.Attributes.Add("readonly", "readonly");
                    txtLST1.Attributes.Add("readonly", "readonly");
                    txtLST2.Attributes.Add("readonly", "readonly");
                    txtLST3.Attributes.Add("readonly", "readonly");
                    txtLST4.Attributes.Add("readonly", "readonly");
                    txtLSTSurcharge1.Attributes.Add("readonly", "readonly");
                    txtLSTSurcharge2.Attributes.Add("readonly", "readonly");
                    txtLSTSurcharge3.Attributes.Add("readonly", "readonly");
                    txtLSTSurcharge4.Attributes.Add("readonly", "readonly");
                    txtLFR1.Attributes.Add("readonly", "readonly");
                    txtLFR2.Attributes.Add("readonly", "readonly");
                    txtLFR3.Attributes.Add("readonly", "readonly");
                    txtLFR4.Attributes.Add("readonly", "readonly");
                    txtDO1.Attributes.Add("readonly", "readonly");
                    txtDO2.Attributes.Add("readonly", "readonly");
                    txtDO3.Attributes.Add("readonly", "readonly");
                    txtDO4.Attributes.Add("readonly", "readonly");
                    txtAmount1.Attributes.Add("readonly", "readonly");
                    txtAmount2.Attributes.Add("readonly", "readonly");
                    txtAmount3.Attributes.Add("readonly", "readonly");
                    txtAmount4.Attributes.Add("readonly", "readonly");
                    txtGrandTotal.Attributes.Add("readonly", "readonly");
                    TotalDisc.Attributes.Add("readonly", "readonly");
                    txtMessage.Attributes.Add("readonly", "readonly");
                    txtNetAmount.Attributes.Add("readonly", "readonly");
                    DropInvoiceNo .Visible=false;
					Vendor_ID="0";
					checkPrevileges();
					//txtGrandTotal.Attributes.Add("onblur","javascript:GetGrandTotal()");
					//txtGrandTotal.Attributes.Add("onclick","javascript:GetGrandTotal()");
					lblInvoiceDate.Text=GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());
					lblEntryTime.Text=DateTime.Now.ToString();
					//lblETime.Text=DateTime.Now.ToString();
                    lblETime.Text= DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm:ss tt");
                    TotalDisc.Text="";
					lblEntryBy.Text =Session["User_Name"].ToString();
					DropDownList[] Product={DropProd1, DropProd2, DropProd3, DropProd4};
					InventoryClass obj=new InventoryClass ();
					SqlDataReader SqlDtr;
					string sql;
					GetNextInvoiceNo();
			
					#region To Check the price updation or Tax entry is present for all the products, if not then displays the message.
					int count = 0;
					int count1 = 0;
					dbobj.ExecuteScalar("Select Count(Prod_id) from  products where Category = 'Fuel'",ref count);
					sql = "select distinct Prod_Name from Products p,Price_Updation pu,tax_entry te where p.prod_id = pu.Prod_id and p.prod_id = te.Productid  and p.Category = 'fuel'";
					SqlDtr = obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						count1 = count1+1;
					}
					SqlDtr.Close();
					if(count != count1)
					{
						lblMessage.Text = "Price updation/ Tax entry not available for some products";
					}
					#endregion
				
					#region Fetch the Products Name and fill in the ComboBoxes
					sql = "select distinct Prod_Name from Products p,Price_Updation pu,tax_entry te where p.prod_id = pu.Prod_id and p.prod_id = te.Productid  and p.Category = 'fuel'";
					for(int j=0;j<Product.Length;j++)
					{
						SqlDtr = obj.GetRecordSet(sql); 
						while(SqlDtr.Read())
						{			
							Product[j].Items.Add(SqlDtr.GetValue(0).ToString());  
						}					
						SqlDtr.Close();
					}
				
					calculateProd();
					#endregion

					#region Fetch the Next Invoice Number
					sql="select max(Invoice_No)+1 from Purchase_Master";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						lblInvoiceNo.Text =SqlDtr.GetValue(0).ToString ();				
						if(lblInvoiceNo.Text=="")
							lblInvoiceNo.Text ="1001";
					}
					SqlDtr.Close ();		
					#endregion

					#region Fetch All Supplier ID and fill in the ComboBox
					sql="select Supp_Name from Supplier order by supp_id";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropVendorID.Items.Add (SqlDtr.GetValue(0).ToString ());				
					}
					SqlDtr.Close ();		
					#endregion
					
					CreateLogFiles.ErrorLog("Form:FuelPurchace.aspx,Method:pageload.   User_ID: "+uid);
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:pageload"+" EXCEPTION "+ex.Message+uid);
				}
			}
			fetchCity();
			//DropInvoiceNo.Attributes.Add("OnBlur","getTaxRate1();");
		}

		/// <summary>
		/// This Method is used to check the user previllegs.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="4";
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
			if(Add_Flag=="0" && View_flag =="0" && Edit_Flag == "0")
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			if(Add_Flag == "0")
				btnSave.Enabled = false;
			if(Edit_Flag =="0")
				btnEdit.Enabled = false;  
			#endregion
		}

		/// <summary>
		/// This Method is used to get the Products details and insert it into the Hidden HTML Field.
		/// </summary>
		public void calculateProd()
		{
			InventoryClass obj=new InventoryClass ();
			SqlDataReader rdr=null;
			string pid="";
			string str1="";
			string Prate="";
			
			IEnumerator enum1=DropProd1.Items.GetEnumerator();
			enum1.MoveNext(); 
			while(enum1.MoveNext())
			{
				string s=enum1.Current.ToString(); 
						
				dbobj.SelectQuery("select Prod_ID from products where prod_name like '"+s +"'","Prod_ID",ref pid);
				str1=str1+s+"~"+pid+"~";
				dbobj.SelectQuery("select top 1 Pur_Rate from Price_Updation where Prod_ID='"+pid+"' order by eff_date desc","Pur_Rate",ref Prate );
				str1=str1+Prate+"~";  
				dbobj.SelectQuery("select * from tax_entry where productid='"+pid+"'",ref rdr);			
				
				if(rdr.Read())
				{
					str1=str1+ rdr["reduction"].ToString()+"~"+rdr["entry_tax"].ToString()+"~"+rdr["rpg_charge"].ToString()+"~"+rdr["rpg_surcharge"].ToString()+"~"+rdr["LT_charge"].ToString()+"~"+rdr["tran_charge"].ToString()+"~"+rdr["other_lvy"].ToString()+"~"+rdr["LST"].ToString()+"~"+rdr["LST_surcharge"].ToString()+"~"+rdr["LF_recov"].ToString()+"~"+rdr["dofobc_charge"].ToString()+"~"+rdr["unit_rdc"].ToString()+"~"+rdr["unit_etax"].ToString()+"~"+rdr["unit_rpgchg"].ToString()+"~"+rdr["unit_rpgschg"].ToString()+"~"+rdr["unit_ltchg"].ToString()+"~"+rdr["unit_tchg"].ToString()+"~"+rdr["unit_olvy"].ToString()+"~"+rdr["unit_lst"].ToString()+"~"+rdr["unit_lstschg"].ToString()+"~"+rdr["unit_lfrecov"].ToString()+"~"+rdr["unit_dochg"].ToString()+"#";
					dbobj.Dispose();
				}
			}
			FuelText .Value=str1; 
		}

		/// <summary>
		/// Fetch The cities of each supplier and store in a hidden field.
		/// </summary>
		public void fetchCity()
		{
			try
			{
				string city="";
				string Tin_No="";
				string str1="";
				IEnumerator enum1=DropVendorID.Items.GetEnumerator();
				enum1.MoveNext(); 
				while(enum1.MoveNext())
				{
					string s=enum1.Current.ToString(); 
					dbobj.SelectQuery("Select City from Supplier where Supp_Name like '"+s+"'","City",ref city);
					dbobj.SelectQuery("Select Tin_No from Supplier where Supp_Name like '"+s+"'","Tin_No",ref Tin_No);
					str1=str1+s+"~"+city+"~"+Tin_No+"#";
				}
				TxtVen.Value=str1; 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:fetchCity()"+" EXCEPTION "+ex.Message+uid);
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
			this.DropInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.DropInvoiceNo_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.txtTempInPhysical1.TextChanged += new System.EventHandler(this.txtTempInPhysical1_TextChanged);
			this.txtTempInPhysical2.TextChanged += new System.EventHandler(this.txtTempInPhysical2_TextChanged);
			this.txtTempInPhysical3.TextChanged += new System.EventHandler(this.txtTempInPhysical3_TextChanged);
			this.txtTempInPhysical4.TextChanged += new System.EventHandler(this.txtTempInPhysical4_TextChanged);
			this.txtTempAfterDec1.TextChanged += new System.EventHandler(this.txtTempAfterDec1_TextChanged);
			this.txtTempAfterDec2.TextChanged += new System.EventHandler(this.txtTempAfterDec2_TextChanged);
			this.txtTempAfterDec3.TextChanged += new System.EventHandler(this.txtTempAfterDec3_TextChanged);
			this.txtTempAfterDec4.TextChanged += new System.EventHandler(this.txtTempAfterDec4_TextChanged);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// This Method is used to save or update the Fuel Purchase Details with the help of stored procedure.
		/// </summary>
		public void Save1(string Compartment, string ProdName, string Density_in_Physical, string Temp_in_Physical,string Conv_Density_Phy, string Density_in_Invoice_Conv, string Density_Variation, string Den_After_Dec, string Temp_After_Dec, string Conv_Den_After_Dec, string Qty, string Rate,string Amount,string temp,string Inv_date, string Reduction,string Entry_tax, string RPG_Charge, string RPG_Surcharge, string LTC, string Trans_Charge, string OLV, string LST, string LST_Surcharge, string LFR, string DOFOBC_Charge)
		{
			InventoryClass obj=new InventoryClass();
			obj.Invoice_No=DropInvoiceNo.SelectedItem .Value.ToString();
			obj.Compartment=Compartment;  
			obj.Prod_Name=ProdName ;
			obj.Density_in_Physical=Density_in_Physical;
			obj.Temp_in_Physical=Temp_in_Physical;
			obj.Converted_Density_Phy=Conv_Density_Phy ; 
			obj.Density_in_Invoice_Conv=Density_in_Invoice_Conv;
			obj.Density_Variation=Density_Variation;
			obj.Density_After_Dec=Den_After_Dec;
			obj.Temp_After_Dec=Temp_After_Dec;
			obj.Conv_Den_After_Dec=Conv_Den_After_Dec;
			obj.Qty=Qty;
			obj.Rate=Rate;
			obj.Amount=Amount;
			obj.Vendor_Name=DropVendorID.SelectedItem.Text;
			obj.City =lblPlace.Value.ToString(); 
			obj.tempQty = temp;
			obj.Inv_date = Inv_date;
			obj.Reduction  = Reduction;
			obj.Entry_Tax = Entry_tax;
			obj.RPG_Charge = RPG_Charge;
			obj.RPG_Surcharge = RPG_Surcharge;
			obj.LTC = LTC;
			obj.Trans_Charge = Trans_Charge;
			obj.OLV = OLV;
			obj.LST = LST;
			obj.LST_Sucharge = LST_Surcharge;
			obj.LFR = LFR;
			obj.DOFOBC_Charge = DOFOBC_Charge;
			obj.MasterUpdateFuelPurchaseDetail();
		}

		/// <summary>
		/// This Method is used to insert the Fuel Purchase Details with the help of 'ProFuelPurchaseDetailsEntry'
		/// procedure.
		/// </summary>
		public void Save(string Compartment, string ProdName, string Density_in_Physical, string Temp_in_Physical,string Conv_Density_Phy, string Density_in_Invoice_Conv, string Density_Variation, string Den_After_Dec, string Temp_After_Dec, string Conv_Den_After_Dec, string Qty, string Rate,string Amount, string Reduction,string Entry_tax, string RPG_Charge, string RPG_Surcharge, string LTC, string Trans_Charge, string OLV, string LST, string LST_Surcharge, string LFR, string DOFOBC_Charge)
		{
			InventoryClass obj=new InventoryClass();
			obj.Vendor_Name=DropVendorID.SelectedItem.Text;
			obj.City =lblPlace.Value.ToString(); 
			obj.Invoice_No=lblInvoiceNo.Text;
			obj.Compartment=Compartment;  
			obj.Product_Name=ProdName ;
			obj.Density_in_Physical=Density_in_Physical;
			obj.Temp_in_Physical=Temp_in_Physical;
			obj.Converted_Density_Phy=Conv_Density_Phy ; 
			obj.Density_in_Invoice_Conv=Density_in_Invoice_Conv;
			obj.Density_Variation=Density_Variation;
			obj.Density_After_Dec=Den_After_Dec;
			obj.Temp_After_Dec=Temp_After_Dec;
			obj.Conv_Den_After_Dec=Conv_Den_After_Dec;
			obj.Qty=Qty;
			obj.Rate=Rate;
			obj.Amount=Amount;
			obj.Reduction  = Reduction;
			obj.Entry_Tax = Entry_tax;
			obj.RPG_Charge = RPG_Charge;
			obj.RPG_Surcharge = RPG_Surcharge;
			obj.LTC = LTC;
			obj.Trans_Charge = Trans_Charge;
			obj.OLV = OLV;
			obj.LST = LST;
			obj.LST_Sucharge = LST_Surcharge;
			obj.LFR = LFR;
			obj.DOFOBC_Charge = DOFOBC_Charge;
			obj.InsertFuelPurchaseDetail();
		}

		/// <summary>
		/// This method is used to sends the text file to print server to print.
		/// </summary>
		public void Print()
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\FuelPurchaseReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
		
					CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:print  userid "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:print   EXCEPTION  "+ ane.Message+"userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:print   EXCEPTION  "+se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:print   EXCEPTION "+es.Message+"  userid  "+uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:print"+" EXCEPTION "+ex.Message+"  userid  "+uid);
			}
		}
		
		/// <summary>
		/// This method is not used
		/// </summary>
		private string GetString(string str,string spc)
		{
			if(str.Length>spc.Length)
				return str;
			else
				return str+spc.Substring(0,spc.Length-str.Length)+"  ";			
		}
				
		/// <summary>
		/// This method is not used
		/// </summary>
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6,ref int len7,ref int len8,ref int len9,ref int len10,ref int len11,ref int len12,ref int len13)
		{
			while(rdr.Read())
			{
				if(rdr["Invoice_No"].ToString().Trim().Length>len1)
					len1=rdr["Invoice_No"].ToString().Trim().Length;					
				if(rdr["Invoice_Date"].ToString().Trim().Length>len2)
					len2=rdr["Invoice_Date"].ToString().Trim().Length;	
				if(rdr["Sales_Type"].ToString().Trim().Length>len3)
					len3=rdr["Sales_Type"].ToString().Trim().Length;	
				if(rdr["Under_SalesMan"].ToString().Trim().Length>len4)
					len4=rdr["Under_SalesMan"].ToString().Trim().Length;
				if(rdr["Vehicle_No"].ToString().Trim().Length>len5)
					len5=rdr["Vehicle_No"].ToString().Trim().Length;					
				if(rdr["Grand_Total"].ToString().Trim().Length>len6)
					len6=rdr["Grand_Total"].ToString().Trim().Length;	
				if(rdr["Discount"].ToString().Trim().Length>len7)
					len7=rdr["Discount"].ToString().Trim().Length;	
				if(rdr["Net_Amount"].ToString().Trim().Length>len8)
					len8=rdr["Net_Amount"].ToString().Trim().Length;					
				if(rdr["Promo_Scheme"].ToString().Trim().Length>len9)
					len9=rdr["Promo_Scheme"].ToString().Trim().Length;	
				if(rdr["Remark"].ToString().Trim().Length>len10)
					len10=rdr["Remark"].ToString().Trim().Length;					
				if(rdr["Entry_By"].ToString().Trim().Length>len11)
					len11=rdr["Entry_By"].ToString().Trim().Length;	
				if(rdr["Entry_Time"].ToString().Trim().Length>len12)
					len12=rdr["Entry_Time"].ToString().Trim().Length;		
				if(rdr["Slip_No"].ToString().Trim().Length>len13)
					len13=rdr["Slip_No"].ToString().Trim().Length;		
			}
		}
		
		/// <summary>
		/// This method is not used
		/// </summary>
		private string GetString(string str,int maxlen,string spc)
		{		
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
		}
		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
		}

		public void Write2File(StreamWriter sw, string info)
		{
			sw.WriteLine(info);
		}

		/// <summary>
		/// This method make the double value round and put the Two Precision . ".00"
		/// </summary>
		public string makeRound(string str)
		{
			double d= 0.0;
			if(str.Equals("")) 
			{
				return str;
			}
			else
			{
				try
				{
					d = System.Math.Round(System.Convert.ToDouble(str),2); 
					str = d.ToString(); 
				}
				catch(Exception e)
				{
					str = "0";		
					CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:makeRound"+" EXCEPTION "+e.Message+"  userid  "+uid);
				}
				return str;
			}
		}

		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void reportmaking()
		{
			try
			{
				//	#region
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\FuelPurchaseReport.txt";
				string denVar1="";
				string denVar2="";
				string denVar3="";
				string denVar4="";
				string strINVNo = "";
		
				StreamWriter sw = new StreamWriter(path);
	
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

				//**********
				string des="-------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
			
				//sw.WriteLine(GenUtil.GetCenterAddr("=======================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("FUEL PURCHASE INVOICE",des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("=======================",des.Length));
				if(lblInvoiceNo.Visible==true)
				{
					strINVNo = lblInvoiceNo.Text; 
				}
				else
				{
					strINVNo = DropInvoiceNo.SelectedItem.Value;	
				}
				sw.WriteLine(" Invoice No : " + strINVNo+ "                                         " + " Date : " + lblInvoiceDate.Text.ToString() );
				sw.WriteLine("+-----------------------------------------------------------------------------+");
				string info33=" {0,-22:S} {1,-24:S} {2,-13:S} {3,-16:S}";
				sw.WriteLine(info33,"Vendor Name         : ",GenUtil.TrimLength(DropVendorID.SelectedItem.Text,24),"Place      : ",GenUtil.TrimLength(lblPlace.Value.ToString(),16));
				sw.WriteLine(info33,"Vendor Invoice No   : ",txtVInvoiceNo.Text,"Vehicle No : ",txtVehicleNo.Text);
				sw.WriteLine(info33,"Vendor Invoice Date : ",txtVInvoiceDate.Text,"Tin No     : ",lblTinNo.Value);
				/*sw.WriteLine("Vendor Name          : " + DropVendorID.SelectedItem.Text);
				sw.WriteLine("Place                :  " + lblPlace.Value.ToString());//rdr["place"].ToString());
				sw.WriteLine("Vendor Invoice No    :  " + txtVInvoiceNo.Text);
				sw.WriteLine("Vendor Invoice Date  :  " + txtVInvoiceDate.Text);
				sw.WriteLine("Vehicle No           :  " + txtVehicleNo.Text);
				sw.WriteLine("Tin No               :  " + lblTinNo.Value);*/
				sw.WriteLine("+-----------------+--------------+--------------+--------------+--------------+");
				sw.WriteLine("|                 |Compartment-1 |Compartment-2 |Compartment-3 |Compartment-4 |");
				sw.WriteLine("+-----------------+--------------+--------------+--------------+--------------+");
				//******************
				string[] dd1=new string[15];
				string[] dd2=new string[15];
				string[] d11=new string[15];
				string[] d22=new string[15];
				string[] d33=new string[15];
				string[] d44=new string[15];
				//******************
				string info1 = " Product Name     : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info1,DropProd1.SelectedItem.Text.ToString().Equals("Select")? " " : DropProd1.SelectedItem.Text.ToString(),
					DropProd2.SelectedItem.Text.ToString().Equals("Select")? " " : DropProd2.SelectedItem.Text.ToString(),
					DropProd3.SelectedItem.Text.ToString().Equals("Select")? " " : DropProd3.SelectedItem.Text.ToString(),
					DropProd4.SelectedItem.Text.ToString().Equals("Select")? " " : DropProd4.SelectedItem.Text.ToString());
				//******
				if(DropProd1.SelectedIndex!=0)
					d11[0]=DropProd1.SelectedItem.Text;
				else
					d11[0]="";
				if(DropProd2.SelectedIndex!=0)
					d22[0]=DropProd2.SelectedItem.Text;
				else
					d22[0]="";
				if(DropProd3.SelectedIndex!=0)
					d33[0]=DropProd3.SelectedItem.Text;
				else
					d33[0]="";
				if(DropProd4.SelectedIndex!=0)
					d44[0]=DropProd4.SelectedItem.Text;
				else
					d44[0]="";
				//*************
				string info2 = " Qty In Ltr       : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info2,txtQty1.Text ,
					txtQty2.Text,
					txtQty3.Text,
					txtQty4.Text);		
				//******
				d11[1]=txtQty1.Text;
				d22[1]=txtQty2.Text;
				d33[1]=txtQty3.Text;
				d44[1]=txtQty4.Text;
				//******
				string info3 = " Rate In Ltr      : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";		
				sw.WriteLine(info3, txtRate1.Text,
					txtRate2.Text,
					txtRate3.Text,
					txtRate4.Text);
				//******
				d11[2]=txtRate1.Text;
				d22[2]=txtRate2.Text;
				d33[2]=txtRate3.Text;
				d44[2]=txtRate4.Text;
				//******
				string info4 = " Reduction Other  : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info4,"-"+makeRound(txtReduction1.Text.ToString()) ,
					"-"+makeRound(txtReduction2.Text.ToString()),
					"-"+makeRound(txtReduction3.Text.ToString()),
					"-"+makeRound(txtReduction4.Text.ToString()));
				//******
				d11[3]=txtReduction1.Text;
				d22[3]=txtReduction2.Text;
				d33[3]=txtReduction3.Text;
				d44[3]=txtReduction4.Text;
				//******
				string info5 = " Entry Tax        : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info5,makeRound(txtEntryTax1.Text.ToString()),
					makeRound(txtEntryTax2.Text.ToString()),
					makeRound(txtEntryTax3.Text.ToString()),
					makeRound(txtEntryTax4.Text.ToString()));
				//******
				d11[4]=txtEntryTax1.Text;
				d22[4]=txtEntryTax2.Text;
				d33[4]=txtEntryTax3.Text;
				d44[4]=txtEntryTax4.Text;
				//******
				string info6 = " RPG Charge       : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info6,makeRound(txtRPGCharge1.Text.ToString()) ,
					makeRound(txtRPGCharge2.Text.ToString()),
					makeRound(txtRPGCharge3.Text.ToString()) ,
					makeRound(txtRPGCharge4.Text.ToString()));
				//******
				d11[5]=txtRPGCharge1.Text;
				d22[5]=txtRPGCharge2.Text;
				d33[5]=txtRPGCharge3.Text;
				d44[5]=txtRPGCharge4.Text;
				//******
				string info7 = " RPG SurCharge    : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info7, makeRound(txtRPGSurcharge1.Text.ToString()) ,
					makeRound(txtRPGSurcharge2.Text.ToString()),
					makeRound(txtRPGSurcharge3.Text.ToString()),
					makeRound(txtRPGSurcharge4.Text.ToString()));
				//******
				d11[6]=txtRPGSurcharge1.Text;
				d22[6]=txtRPGSurcharge2.Text;
				d33[6]=txtRPGSurcharge3.Text;
				d44[6]=txtRPGSurcharge4.Text;
				//******
				string info8 = " Local Trans.Chrg.: {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info8,makeRound(txtLTC1.Text.ToString()) ,
					makeRound(txtLTC2.Text.ToString()) ,
					makeRound(txtLTC3.Text.ToString()),
					makeRound(txtLTC4.Text.ToString()));
				//******
				d11[7]=txtLTC1.Text;
				d22[7]=txtLTC2.Text;
				d33[7]=txtLTC3.Text;
				d44[7]=txtLTC4.Text;
				//******
				string info9 = " Trans. Charge    : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info9,makeRound(txtTransportCharge1.Text.ToString()) ,
					makeRound(txtTransportCharge2.Text.ToString()),
					makeRound(txtTransportCharge3.Text.ToString()),
					makeRound(txtTransportCharge4.Text.ToString()));
				//******
				d11[8]=txtTransportCharge1.Text;
				d22[8]=txtTransportCharge2.Text;
				d33[8]=txtTransportCharge3.Text;
				d44[8]=txtTransportCharge4.Text;
				//******
				string info10 = " Other Levies     : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info10,makeRound(txtOther1.Text.ToString()) ,
					makeRound(txtOther2.Text.ToString()),
					makeRound(txtOther3.Text.ToString()),
					makeRound(txtOther4.Text.ToString()));
				//******
				d11[9]=txtOther1.Text;
				d22[9]=txtOther2.Text;
				d33[9]=txtOther3.Text;
				d44[9]=txtOther4.Text;
				//******
				string info11 = " Vat              : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info11,makeRound(txtLST1.Text.ToString()) ,
					makeRound(txtLST2.Text.ToString()),
					makeRound(txtLST3.Text.ToString()),
					makeRound(txtLST4.Text.ToString()));
				//******
				d11[10]=txtLST1.Text;
				d22[10]=txtLST2.Text;
				d33[10]=txtLST3.Text;
				d44[10]=txtLST4.Text;
				//******
				string info12 = " LST Surchargs    : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info12,makeRound(txtLSTSurcharge1.Text.ToString()) ,
					makeRound(txtLSTSurcharge2.Text.ToString()),
					makeRound(txtLSTSurcharge3.Text.ToString()),
					makeRound(txtLSTSurcharge4.Text.ToString()));
				//******
				d11[11]=txtLSTSurcharge1.Text;
				d22[11]=txtLSTSurcharge2.Text;
				d33[11]=txtLSTSurcharge3.Text;
				d44[11]=txtLSTSurcharge4.Text;
				//******
				string info13 = " Lic.Fee Recovery : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info13, makeRound(txtLFR1.Text.ToString()) ,
					makeRound(txtLFR2.Text.ToString()),
					makeRound(txtLFR3.Text.ToString()),
					makeRound(txtLFR4.Text.ToString()));
				//******
				d11[12]=txtLFR1.Text;
				d22[12]=txtLFR2.Text;
				d33[12]=txtLFR3.Text;
				d44[12]=txtLFR4.Text;
				//******
				string info14 = " DO/FO/BC Charge  : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info14, makeRound(txtDO1.Text.ToString()) ,
					makeRound(txtDO2.Text.ToString()),
					makeRound(txtDO3.Text.ToString()),
					makeRound(txtDO4.Text.ToString()));
				//******
				d11[13]=txtDO1.Text;
				d22[13]=txtDO2.Text;
				d33[13]=txtDO3.Text;
				d44[13]=txtDO4.Text;
				//******
				string info15= "|Total Amount     : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}|";
				
				sw.WriteLine("+-----------------+--------------+--------------+--------------+--------------+");
				sw.WriteLine(info15, GenUtil.strNumericFormat(txtAmount1.Text.ToString()) ,GenUtil.strNumericFormat(txtAmount2.Text.ToString()) ,GenUtil.strNumericFormat(txtAmount3.Text.ToString()) ,GenUtil.strNumericFormat(txtAmount4.Text.ToString()) );
				sw.WriteLine("+-----------------+--------------+--------------+--------------+--------------+");
				//******
				d11[14]=txtAmount1.Text;
				d22[14]=txtAmount2.Text;
				d33[14]=txtAmount3.Text;
				d44[14]=txtAmount4.Text;
				//******
				//********************************************************************Add By Mahesh-22.08.007
				int d1=DropProd1.SelectedIndex;
				int d2=DropProd2.SelectedIndex;
				int d3=DropProd3.SelectedIndex;
				int d4=DropProd4.SelectedIndex;
				int count=0;
				if(d1==d2 && d1==d3 && d1==d4 && d1!=0 && d2!=0 && d3!=0 && d4!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d22[i])+double.Parse(d33[i])+double.Parse(d44[i]));
					}
					count=1;
				}
				else if(d1==d2 && d1==d3 && d1!=d4 && d1!=0 && d2!=0 && d3!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d22[i])+double.Parse(d33[i]));
					}
					count=1;
				}
				else if(d1==d3 && d1==d4 && d1!=d2 && d1!=0 && d3!=0 && d4!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d33[i])+double.Parse(d44[i]));
					}
					count=1;
				}
				else if(d1==d2 && d1==d4 && d1!=d3 && d1!=0 && d2!=0 && d4!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d22[i])+double.Parse(d44[i]));
					}
					count=1;
				}
				else if(d2==d3 && d2==d4 && d2!=d1 && d2!=0 && d3!=0 && d4!=0)
				{
					dd1[0]=d22[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d22[i])+double.Parse(d33[i])+double.Parse(d44[i]));
					}
					count=1;
				}
				else if(d1==d2 && d3==d4 && d1!=0 && d2!=0 && d3!=0 && d4!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d22[i]));
					}
					dd2[0]=d33[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd2[i]=System.Convert.ToString(double.Parse(d33[i])+double.Parse(d44[i]));
					}
					count=2;
				}
				else if(d1==d3 && d2==d4 && d1!=0 && d2!=0 && d3!=0 && d4!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d33[i]));
					}
					dd2[0]=d22[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd2[i]=System.Convert.ToString(double.Parse(d22[i])+double.Parse(d44[i]));
					}
					count=2;
				}
				else if(d1==d4 && d2==d3 && d1!=0 && d2!=0 && d3!=0 && d4!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d44[i]));
					}
					dd2[0]=d22[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd2[i]=System.Convert.ToString(double.Parse(d22[i])+double.Parse(d33[i]));
					}
					count=2;
				}
				else if(d1==d2 && d1!=0 && d2!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d22[i]));
					}
					count=1;
				}
				else if(d1==d3 && d1!=0 && d3!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d33[i]));
					}
					count=1;
				}
				else if(d1==d4 && d1!=0 && d4!=0)
				{
					dd1[0]=d11[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d11[i])+double.Parse(d44[i]));
					}
					count=1;
				}
				else if(d2==d3 && d2!=0 && d3!=0)
				{
					dd1[0]=d22[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d22[i])+double.Parse(d33[i]));
					}
					count=1;
				}
				else if(d2==d4 && d2!=0 && d4!=0)
				{
					dd1[0]=d22[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d22[i])+double.Parse(d44[i]));
					}
					count=1;
				}
				else if(d3==d4 && d3!=0 && d4!=0)
				{
					dd1[0]=d33[0];
					for(int i=1;i<d11.Length;i++)
					{
						dd1[i]=System.Convert.ToString(double.Parse(d33[i])+double.Parse(d44[i]));
					}
					count=1;
				}
				else
				{
					count=0;
				}
				if(count!=0)
				{
					string[] info={info1,info2,info3,info4,info5,info6,info7,info8,info9,info10,info11,info12,info13,info14,info15};
					if(count==1)
					{
						for(int i=0;i<dd1.Length;i++)
						{
							sw.WriteLine(info[i],dd1[i].ToString(),"","","");
						}
					}
					else if(count==2)
					{
						for(int i=0;i<dd1.Length;i++)
						{
							sw.WriteLine(info[i],dd1[i].ToString(),dd2[i].ToString(),"","");
						}
					}
					//sw.WriteLine("+-----------------+--------------+--------------+--------------+--------------+");
				}

				//********************************************************************
				//**sw.WriteLine("Grand Total       : {0,12:F}", GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()) );
			
				double disc_amt=0;//,Tot_disc_amt=0;
				double amt=0;
				double amt1=0;
				string msg ="";
				string strDiscType = "";
				if(txtDisc.Text=="")
				{
					strDiscType="";
					msg = "";
				}
				else
				{
					disc_amt = System.Convert.ToDouble(txtDisc.Text.ToString()); 
					amt=disc_amt;
					amt1=disc_amt;
					strDiscType= DropDiscType.SelectedItem.Text;
					if(strDiscType.Trim().Equals("%"))
					{
						double temp =0;
						if(txtGrandTotal.Text.Trim() != "")
							temp = System.Convert.ToDouble(txtGrandTotal.Text.Trim().ToString());
 
						disc_amt  = (temp*disc_amt/100);
						msg = "("+txtDisc.Text.ToString()+strDiscType+")";
						//****
						if(count!=0)
						{
							if(count==1)
								amt = (double.Parse(dd1[14].ToString())*amt/100);
							else if(count==2)
							{
								amt = (double.Parse(dd1[14].ToString())*amt/100);
								amt1 = (double.Parse(dd2[14].ToString())*amt1/100);
							}
						}
						//****
					}
					else if(strDiscType.Trim().Equals("KL"))
					{
						double temp =0,t1,t2,t3,t4;
						//if(txtGrandTotal.Text.Trim() != "")
						//	temp = System.Convert.ToDouble(txtGrandTotal.Text.Trim().ToString());
						if(txtQty1.Text=="")
							t1=0;
						else
							t1=System.Convert.ToDouble(txtQty1.Text);
						if(txtQty2.Text=="")
							t2=0;
						else
							t2=System.Convert.ToDouble(txtQty2.Text);
						if(txtQty3.Text=="")
							t3=0;
						else
							t3=System.Convert.ToDouble(txtQty3.Text);
						if(txtQty4.Text=="")
							t4=0;
						else
							t4=System.Convert.ToDouble(txtQty4.Text);
						temp=t1+t2+t3+t4;
						disc_amt  = (temp*disc_amt);
						//****
						if(count!=0)
						{
							if(count==1)
								amt = (double.Parse(dd1[1].ToString())*amt);
							else if(count==2)
							{
								amt = (double.Parse(dd1[1].ToString())*amt);
								amt1 = (double.Parse(dd2[1].ToString())*amt1);
							}
						}
						//****
						msg = "("+txtDisc.Text.ToString()+strDiscType+")";
					}
					else
					{
						msg ="("+strDiscType+")";
					}			
				}
				if(count==0)
					sw.WriteLine(" Discount{0,-8:S} : {1,-14:F} " ,msg,GenUtil.strNumericFormat(disc_amt.ToString()));
				else if(count==1)
					sw.WriteLine(" Discount{0,-8:S} : {1,-14:F} " ,msg,GenUtil.strNumericFormat(amt.ToString()));
				else if(count==2)
					sw.WriteLine(" Discount{0,-8:S} : {1,-14:F} {2,-14:F}" ,msg,GenUtil.strNumericFormat(amt.ToString()),GenUtil.strNumericFormat(amt1.ToString()));
				if(count!=0)
					sw.WriteLine("+-----------------------------------------------------------------------------+");
				sw.WriteLine(" Total Invoice Amount Including All Products    : {0,12:F}" , GenUtil.strNumericFormat(txtNetAmount.Text.ToString()) );
				sw.WriteLine("+-----------------------------------------------------------------------------+");
				//sw.WriteLine(GenUtil.GetCenterAddr("=====================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Quality Measurement",des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("=====================",des.Length));
				sw.WriteLine("+-----------------+--------------+--------------+--------------+--------------+");
				sw.WriteLine("|                 |Compartment-1 |Compartment-2 |Compartment-3 |Compartment-4 |");
				sw.WriteLine("+-----------------+--------------+--------------+--------------+--------------+");
			
				string info16 = " Density Physical : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info16,txtDensityInPhysical1.Text,
					txtDensityInPhysical2.Text,
					txtDensityInPhysical3.Text,
					txtDensityInPhysical4.Text);
				string info17 = " Temp. Physical   : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info17,txtTempInPhysical1.Text,
					txtTempInPhysical2.Text,
					txtTempInPhysical3.Text,
					txtTempInPhysical4.Text);
				string info18 = " Conv. Dens. (Phy): {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info18,txtConDensity1.Text,
					txtConDensity2.Text,
					txtConDensity3.Text,
					txtConDensity4.Text);

				string info20 = " Conv Dens (Inv.) : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info20,txtDenConv1.Text,
					txtDenConv2.Text,
					txtDenConv3.Text,
					txtDenConv4.Text);
				if(!txtDensityVariation1.Text.ToString().Trim().Equals(""))
				{
					denVar1=System.Convert.ToString(System.Math.Round(System.Convert.ToDouble(txtDensityVariation1.Text),4));
				}
				else
				{
					denVar1="";
				}
				if(!txtDensityVariation2.Text.ToString().Trim().Equals(""))
				{
					denVar2=System.Convert.ToString(System.Math.Round(System.Convert.ToDouble(txtDensityVariation2.Text),4));
				}
				else
				{
					denVar2="";
				}
				if(!txtDensityVariation3.Text.ToString().Trim().Equals("") )
				{
					denVar3=System.Convert.ToString(System.Math.Round(System.Convert.ToDouble(txtDensityVariation3.Text),4));
				}
				else
				{
					denVar3="";
				}
				if(!txtDensityVariation4.Text.ToString().Trim().Equals("") )
				{
					denVar4=System.Convert.ToString(System.Math.Round(System.Convert.ToDouble(txtDensityVariation4.Text),4));
				}
				else
				{
					denVar4="";
				}
				string info21 = " Dens. Variation  : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info21,denVar1,
					denVar2,
					denVar3,
					denVar4);
				string info22 = " Dens. Atf. Decan.: {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info22,txtDenAfterDec1.Text,
					txtDenAfterDec2.Text,
					txtDenAfterDec3.Text,
					txtDenAfterDec4.Text);

				string info23 = " Temp. Aft. Decan.: {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info23,txtTempAfterDec1.Text,
					txtTempAfterDec2.Text,
					txtTempAfterDec3.Text,
					txtTempAfterDec4.Text);

				string info24 = " Conv Dens Decan  : {0,-14:S} {1,-14:S} {2,-14:S} {3,-13:S}";
				sw.WriteLine(info24, txtConvDenAfterDec1.Text,
					txtConvDenAfterDec2.Text,
					txtConvDenAfterDec3.Text,
					txtConvDenAfterDec4.Text);

				sw.WriteLine("+-----------------+--------------+--------------+--------------+--------------+");
				sw.WriteLine(" Promo Scheme     : " + txtPromoScheme.Text);
				sw.WriteLine(" Remarks          : " + txtRemark.Text);
				sw.WriteLine(" Message          : "  + txtMessage.Text);
				//sw.WriteLine("");
				//sw.WriteLine("");
				//sw.WriteLine("");
				//sw.WriteLine("");
				sw.WriteLine("                                                                Signature");
				sw.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:reportmaking().   EXCEPTION "+ex.Message+uid);
			}
		}

		/// <summary>
		/// Insert the all values in the duplicate table of fuel.
		/// </summary>
		public void ForReport()
		{
			InventoryClass obj=new InventoryClass();
			obj.InvoiceNo =lblInvoiceNo .Text.ToString();
			obj.InvoiceDate =lblInvoiceDate .Text.ToString();
			obj.VendorName=DropVendorID .SelectedItem.Value.ToString();
			obj.VendorInvoiceNo=txtVInvoiceNo .Text.ToString();
			obj.Place =lblPlace.Value.ToString();
			obj.VendorInvoiceDate =txtVInvoiceDate .Text.ToString();
			obj.VehicleNo=txtVehicleNo .Text.ToString();
			
			obj.ProdName1 =DropProd1 .SelectedItem.Value.ToString();
			obj.ProdName2 =DropProd2.SelectedItem.Value.ToString();
			obj.ProdName3 =DropProd3.SelectedItem.Value.ToString();
			obj.ProdName4=DropProd4.SelectedItem.Value.ToString();
			
			obj.QtyInLtr1 =txtQty1 .Text.ToString();
			obj.QtyInLtr2 =txtQty2.Text.ToString();
			obj.QtyInLtr3 =txtQty3.Text.ToString();
			obj.QtyInLtr4 =txtQty4 .Text.ToString();		
			
			obj.Rate1 =Duptext1.Value .ToString(); 
			obj.Rate2 =TextBox27.Value.ToString();
			obj.Rate3 =TextBox14.Value.ToString();
			obj.Rate4 =TextBox12.Value.ToString();
			
			obj.ReducOther1=Duptext2.Value.ToString();
			obj.ReducOther2=TextBox28.Value.ToString();
			obj.ReducOther3 =TextBox45.Value.ToString();
			obj.ReducOther4 =TextBox13.Value.ToString();
			
			obj.EntryTax1 =TextBox40.Value.ToString();
			obj.EntryTax2 =TextBox29.Value.ToString();
			obj.EntryTax3=TextBox16.Value.ToString();
			obj.EntryTax4=TextBox1.Value.ToString();
			
			obj.RpgCharge1 =Duptext4 .Value.ToString();
			obj.RpgCharge2 =TextBox30 .Value.ToString();
			obj.RpgCharge3=TextBox17.Value.ToString();
			obj.RpgCharge4 =TextBox2.Value.ToString();
			
			obj.Ltc1=Duptext6 .Value.ToString();
			obj.Ltc2=TextBox32 .Value.ToString();
			obj.Ltc3 =TextBox19.Value.ToString();
			obj.Ltc4=TextBox4.Value.ToString();
			
			obj.TranCharge1=Duptext8 .Value.ToString();
			obj.TranCharge2=TextBox33.Value.ToString();
			obj.TranCharge3=TextBox20.Value.ToString();
			obj.TranCharge4=TextBox5 .Value.ToString();
			
			obj.Olv1=Duptext7.Value.ToString();
			obj.Olv2=TextBox34.Value.ToString();
			obj.Olv3=TextBox21.Value.ToString();
			obj.Olv4=TextBox6.Value.ToString();
			
			obj.Lst1 =Duptext9 .Value.ToString();
			obj.Lst2 =TextBox35.Value.ToString();
			obj.Lst3 =TextBox22.Value.ToString();
			obj.Lst4=TextBox7.Value.ToString();
			
			obj.Lfr1 =Duptext11 .Value.ToString();
			obj.Lfr2 =TextBox43.Value.ToString();
			obj.Lfr3 =TextBox24 .Value.ToString();
			obj.Lfr4=TextBox9.Value.ToString();
			
			// for dfb charge
			obj.TemInv1 =TextBox38.Value.ToString();
			obj.TemInv2 =TextBox47.Value.ToString();
			obj.TemInv3 =TextBox25.Value.ToString();
			obj.TemInv4 =TextBox10.Value.ToString();

			// fro total
			obj.TotalAmount =Duptext13.Value.ToString();
			obj.TotalAmount1 =TextBox39.Value.ToString();
			obj.TotalAmount2 =TextBox26.Value.ToString();
			obj.TotalAmount3 =TextBox11.Value.ToString();

			// for rposcg
			obj.DfbCharge1 =Duptext5.Value.ToString();
			obj.DfbCharge2 =TextBox31.Value.ToString();
			obj.DfbCharge3 =TextBox18.Value.ToString();
			obj.DfbCharge4 =TextBox3.Value.ToString();
		
			//for lst schg
			obj.DenPhy1=Duptext10.Value.ToString();
			obj.DenPhy2=TextBox46.Value.ToString();
			obj.DenPhy3=TextBox23.Value.ToString();
			obj.DenPhy4=TextBox8.Value.ToString();

			obj.DenP1=txtDensityInPhysical1.Text.ToString();
			obj.DenP2=txtDensityInPhysical2.Text.ToString();
			obj.DenP3=txtDensityInPhysical3.Text.ToString();
			obj.DenP4=txtDensityInPhysical4.Text.ToString();
		
			obj.TemPhy1=txtTempInPhysical1 .Text.ToString();
			obj.TemPhy2=txtTempInPhysical2 .Text.ToString();
			obj.TemPhy3=txtTempInPhysical3 .Text.ToString();
			obj.TemPhy4=txtTempInPhysical4 .Text.ToString();
			
			obj.ConvDenPhy1 =txtConDensity1 .Text.ToString();
			obj.ConvDenPhy2 =txtConDensity2 .Text.ToString();
			obj.ConvDenPhy3 =txtConDensity3 .Text.ToString();
			obj.ConvDenPhy4 =txtConDensity4 .Text.ToString();
			
			obj.DenInv1 =txtDenConv1.Text.ToString();
			obj.DenInv2 =txtDenConv2.Text.ToString();
			obj.DenInv3 =txtDenConv3.Text.ToString();
			obj.DenInv4 =txtDenConv4.Text.ToString();
			
			obj.DensVaria1 =txtDensityVariation1 .Text.ToString();
			obj.DensVaria2 =txtDensityVariation2 .Text.ToString();
			obj.DensVaria3 =txtDensityVariation3 .Text.ToString();
			obj.DensVaria4 =txtDensityVariation4 .Text.ToString();
			
			obj.DenAftDec1=txtConvDenAfterDec1 .Text.ToString();
			obj.DenAftDec2=txtConvDenAfterDec2 .Text.ToString();
			obj.DenAftDec3=txtConvDenAfterDec3 .Text.ToString();
			obj.DenAftDec4=txtConvDenAfterDec4 .Text.ToString();
			
			obj.TempAftDec1 =txtDenAfterDec1 .Text.ToString();
			obj.TempAftDec2 =txtDenAfterDec2 .Text.ToString();
			obj.TempAftDec3 =txtDenAfterDec3 .Text.ToString();
			obj.TempAftDec4 =txtDenAfterDec4 .Text.ToString();
			
			obj.ConvDenInv1 =txtDenConv1.Text.ToString();
			obj.ConvDenInv2 =txtDenConv2.Text.ToString();
			obj.ConvDenInv3 =txtDenConv3.Text.ToString();
			obj.ConvDenInv4 =txtDenConv4.Text.ToString();
			
			obj.ConvDenAft1 =txtConvDenAfterDec1.Text.ToString();
			obj.ConvDenAft2 =txtConvDenAfterDec2.Text.ToString();
			obj.ConvDenAft3 =txtConvDenAfterDec3.Text.ToString();
			obj.ConvDenAft4 =txtConvDenAfterDec4.Text.ToString();
			//			
			obj.TotalAmount =txtAmount1.Text.ToString();
			obj.TotalAmount =txtAmount1.Text.ToString();
			obj.TotalAmount =txtAmount1.Text.ToString();
			obj.TotalAmount =txtAmount1.Text.ToString();

			obj.Discount =txtDisc.Text .ToString();
			obj.NetAmount =txtNetAmount.Text .ToString();
			obj.Promo =txtPromoScheme .Text.ToString();
			obj.Remarks=txtRemark.Text.ToString();

			obj.InsertFuelDDupli();
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		public void for1()
		{
			System.Data.SqlClient.SqlDataReader rdr=null;
			Prod_Changed(DropProd1,txtRate1);
			//object op=null;			
			string pid="";
			dbobj.SelectQuery("select Prod_ID from products where prod_name like '"+DropProd1.SelectedItem.Text+"'","Prod_ID",ref pid);
			dbobj.SelectQuery("select * from tax_entry where productid='"+pid+"'",ref rdr);			
			if(rdr.Read())
			{
				txtReduction1.Text= rdr["reduction"].ToString();
				//txtRate1.Text=//rdr["reduction"].ToString();
				txtEntryTax1.Text=rdr["entry_tax"].ToString();
				txtRPGCharge1.Text=rdr["rpg_charge"].ToString();
				txtRPGSurcharge1.Text=rdr["rpg_surcharge"].ToString();
				txtLTC1.Text=rdr["LT_charge"].ToString();
				txtTransportCharge1.Text=rdr["tran_charge"].ToString();
				txtOther1.Text=rdr["other_lvy"].ToString();
				txtLST1.Text=rdr["LST"].ToString();
				txtLSTSurcharge1.Text=rdr["LST_surcharge"].ToString();
				//txtTransportCharge1.Text=rdr["Tran_charge"].ToString();
				txtLFR1.Text=rdr["LF_recov"].ToString();
				txtDO1.Text=rdr["dofobc_charge"].ToString();
				//				txtRO1.Text=rdr["ro_charge"].ToString();
				dbobj.Dispose();
			}
		}

		/// <summary>
		/// This method to update the purchase master with the help of stored procedure like ProPurchaseMasterEntry
		/// and MasterUpdatePurchaseMaster.
		/// </summary>
		public void update()
		{
			InventoryClass obj=new InventoryClass();
			obj.Invoice_No =DropInvoiceNo.SelectedItem.Value .ToString(); 
			obj.Invoice_Date =System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(lblInvoiceDate.Text.ToString()));
			//obj.Invoice_Date =DateTime.Now;
			obj.Mode_of_Payment=DropModeType.SelectedItem.Text;
			obj.Vehicle_No=txtVehicleNo.Text.ToString();
			obj.Vndr_Invoice_No=txtVInvoiceNo.Text.ToString();
			obj.Vndr_Invoice_Date=GenUtil.str2MMDDYYYY (txtVInvoiceDate.Text.ToString());
			obj.Promo_Scheme =txtPromoScheme.Text.ToString();
			obj.Remerk=txtRemark.Text;
			obj.Invoice_No=DropInvoiceNo.SelectedItem.Value.ToString();        
			obj.Grand_Total = txtGrandTotal.Text.ToString();
			obj.Discount = txtDisc.Text.ToString();
			obj.Discount_Type = DropDiscType.SelectedItem.Value.ToString();
			obj.Net_Amount = txtNetAmount.Text.ToString();
			obj.Cash_Discount  ="0.0";
			obj.Cash_Disc_Type ="" ;
			obj.VAT_Amount = "0.0";   
			obj.Vendor_Name=DropVendorID.SelectedItem.Value ;
			obj.City=lblPlace.Value .ToString();
			obj.Entry_By =lblEntryBy.Text ;
			obj.Entry_Time=DateTime.Parse(lblEntryTime .Text);
			int VendorID=0;
			dbobj.ExecuteScalar("Select Supp_ID from  Supplier where Supp_Name='"+DropVendorID.SelectedItem.Text+"'",ref VendorID);
			if(Vendor_ID!=VendorID.ToString())
			{
				int xx=0;
				dbobj.Insert_or_Update("delete from Purchase_Master where Invoice_No='"+DropInvoiceNo.SelectedItem.Text+"'",ref xx);
				dbobj.Insert_or_Update("delete from Accountsledgertable where Particulars='Purchase Invoice ("+DropInvoiceNo.SelectedItem.Text+")'",ref xx);
				dbobj.Insert_or_Update("delete from Vendorledgertable where Particular='Purchase Invoice ("+DropInvoiceNo.SelectedItem.Text+")'",ref xx);
				obj.InsertPurchaseMaster();
			}
			else
				obj.updateMasterPurchase();
			customerUpdate();
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		public void updateProduct()
		{
			InventoryClass  obj=new InventoryClass ();
			obj.Prod_Name=DropProd1.SelectedItem.Value.ToString();
			obj.UpdateProducts();
		}
		
		/// <summary>
		/// This method is used to save or update the fuel purchase invoice no with the help of stored procedure.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			InventoryClass  obj=new InventoryClass();
			try
			{
                StringBuilder errorMessage = new StringBuilder();
                if (DropVendorID.SelectedIndex==0)
                {
                    errorMessage.Append("- Please Select Vender Name");
                    errorMessage.Append("\n");
                }
                if (txtVehicleNo.Text == string.Empty)
                {
                    errorMessage.Append("- Please Enter Vehicle no.");
                    errorMessage.Append("\n");
                }
                if (txtVInvoiceNo.Text == string.Empty)
                {
                    errorMessage.Append("- Please Enter Invoice no.");
                    errorMessage.Append("\n");
                }
                if (txtVInvoiceDate.Text == string.Empty)
                {
                    errorMessage.Append("- Please Enter Invoice Date");
                    errorMessage.Append("\n");
                }
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());
                    return;
                }
                if (DropProd1.SelectedIndex!=0)
				{
					if(txtQty1.Text=="")
					{
						MessageBox.Show("Please Enter The Qty");
						return;
					}
				}
				if(DropProd2.SelectedIndex!=0)
				{
					if(txtQty2.Text=="")
					{
						MessageBox.Show("Please Enter The Qty");
						return;
					}
				}
				if(DropProd3.SelectedIndex!=0)
				{
					if(txtQty3.Text=="")
					{
						MessageBox.Show("Please Enter The Qty");
						return;
					}
				}
				if(DropProd4.SelectedIndex!=0)
				{
					if(txtQty4.Text=="")
					{
						MessageBox.Show("Please Enter The Qty");
						return;
					}
				}
				//Err.ErrorLog(Server.MapPath("Logs/ErrorLog"),"Form:FuelPerchase.aspx,Method:btnSaved_Click,Class:PartiesClass.cs " );
				if(lblInvoiceNo.Visible==true)
				{
					obj.Invoice_No = lblInvoiceNo.Text ;
					int count = 0;
					// This part of code is use to solve the double click problem, Its checks the Purchase Invoice no. and display the popup, that it is saved.
					dbobj.ExecuteScalar("Select count(Invoice_No) from Purchase_Master where Invoice_No = "+lblInvoiceNo.Text.Trim(),ref count);
					if(count > 0)
					{
						MessageBox.Show("Purchase Invoice Saved");
						Clear();
						GetNextInvoiceNo();
						return ;
					}
					else
					{
						obj.Invoice_Date=DateTime.Now;
						obj.Mode_of_Payment =DropModeType.SelectedItem.Value ;
						obj.Vendor_Name=DropVendorID.SelectedItem.Text;
						obj.City =lblPlace.Value.ToString(); 
						obj.Vehicle_No=txtVehicleNo.Text ;
						obj.Vndr_Invoice_No =txtVInvoiceNo.Text ;
						obj.Vndr_Invoice_Date=GenUtil.str2MMDDYYYY(txtVInvoiceDate.Text );					obj.Grand_Total =txtGrandTotal.Text ;
						if(txtDisc.Text=="")
							obj.Discount ="0.0";
						else
							obj.Discount =txtDisc.Text;
						obj.Discount_Type=DropDiscType.SelectedItem.Value ;
						obj.Net_Amount =txtNetAmount.Text ;
						obj.Promo_Scheme=txtPromoScheme.Text;
						obj.Remerk =txtRemark.Text;
						obj.Entry_By =lblEntryBy.Text ;
						obj.Entry_Time=DateTime.Parse(lblEntryTime .Text);	
						obj.Cash_Discount  ="0.0";
						obj.Cash_Disc_Type ="" ;
						obj.VAT_Amount = "0.0"; 
						obj.InsertPurchaseMaster();	
						Label[]  Compartment={lblComp1, lblComp2, lblComp3, lblComp4}; 
						DropDownList[] ProdName={DropProd1, DropProd2, DropProd3, DropProd4};
						TextBox[]  Density_in_Physical={txtDensityInPhysical1, txtDensityInPhysical2, txtDensityInPhysical3, txtDensityInPhysical4}; 
						TextBox[]  Temp_in_Physical={txtTempInPhysical1, txtTempInPhysical2, txtTempInPhysical3, txtTempInPhysical4}; 
						TextBox[]  Conv_Density_Phy={txtConDensity1, txtConDensity2, txtConDensity3, txtConDensity4}; 
						TextBox[]  Density_in_Invoice_conv={txtDenConv1, txtDenConv2, txtDenConv3, txtDenConv4}; 
						TextBox[]  Density_Variation={txtDensityVariation1, txtDensityVariation2, txtDensityVariation3, txtDensityVariation4}; 
						TextBox[]  Den_After_Dec={txtDenAfterDec1, txtDenAfterDec2, txtDenAfterDec3, txtDenAfterDec4}; 
						TextBox[]  Temp_After_Dec={txtTempAfterDec1, txtTempAfterDec2, txtTempAfterDec3, txtTempAfterDec4}; 
						TextBox[]  Conv_Den_After_Dec={txtConvDenAfterDec1, txtConvDenAfterDec2, txtConvDenAfterDec3, txtConvDenAfterDec4}; 
						TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4};
						TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4};
						TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4};
						TextBox[]  Reduction = {txtReduction1,txtReduction2,txtReduction3,txtReduction4 }; 
						TextBox[]  Entry_Tax = {txtEntryTax1,txtEntryTax2,txtEntryTax3,txtEntryTax4 };  
						TextBox[]  RPG_Charges = {txtRPGCharge1,txtRPGCharge2,txtRPGCharge3,txtRPGCharge4 }; 
						TextBox[]  RPG_Surcharge = {txtRPGSurcharge1,txtRPGSurcharge2,txtRPGSurcharge3,txtRPGSurcharge4 }; 
						TextBox[]  LTC = {txtLTC1,txtLTC2,txtLTC3,txtLTC4 };
						TextBox[]  Trans_Charge = {txtTransportCharge1,txtTransportCharge2,txtTransportCharge3,txtTransportCharge4 }; 
						TextBox[]  OLV = {txtOther1,txtOther2 ,txtOther3 ,txtOther4}; 
						TextBox[]  LST = {txtLST1,txtLST2,txtLST3,txtLST4 }; 
						TextBox[]  LST_Surcharge = {txtLSTSurcharge1,txtLSTSurcharge2,txtLSTSurcharge3,txtLSTSurcharge4 };
						TextBox[]  LFR = {txtLFR1,txtLFR2 ,txtLFR3 ,txtLFR4};
						TextBox[]  DOFOBC_Charge = {txtDO1,txtDO2,txtDO3,txtDO4 };

						for(int j=0;j<ProdName.Length ;j++)
						{
							if(ProdName[j].SelectedIndex ==0)
								continue;
					
							Save(Compartment[j].Text.ToString(), ProdName[j].SelectedItem.ToString(), Density_in_Physical[j].Text.ToString(), Temp_in_Physical[j].Text.ToString(), Conv_Density_Phy[j].Text.ToString(), Density_in_Invoice_conv[j].Text.ToString(), Density_Variation[j].Text.ToString(), Den_After_Dec[j].Text.ToString(), Temp_After_Dec[j].Text.ToString(), Conv_Den_After_Dec[j].Text.ToString(), Qty[j].Text.ToString(),Rate[j].Text.ToString (),Amount[j].Text.ToString (),Reduction[j].Text.ToString(), Entry_Tax[j].Text.ToString(), RPG_Charges[j].Text.ToString(), RPG_Surcharge[j].Text.ToString(),LTC[j].Text.ToString(), Trans_Charge[j].Text.ToString(),OLV[j].Text.ToString(),LST[j].Text.ToString(),LST_Surcharge[j].Text.ToString(),LFR[j].Text.ToString(),DOFOBC_Charge[j].Text.ToString ());
						}
						
						reportmaking();
						//Print();
						MessageBox.Show("Purchase Invoice Saved");
						Clear();
						GetNextInvoiceNo();
						CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:btnSaved_Click,Class:PartiesClass.cs"+" Fuel Purchase Invoise for  Invoice No."+obj.Invoice_No+" ,"+"for Vender Name  "+obj.Vendor_Name+  "on Date "+obj.Vendor_Name+"  is Saved "+" userid "+uid);
					}
				}
				else
				{
					string strCheck = "";
					strCheck =DropInvoiceNo.SelectedItem.Value.ToString();
			
					if(strCheck.Equals("Select"))
					{
						MessageBox.Show("Please Select Invoice No");
					}
					else
					{
						update();
						masterden();
				
						reportmaking();
						//Print();
						lblInvoiceNo.Visible=true;
						DropInvoiceNo.Visible=false;
						btnEdit.Visible=true;
						MessageBox.Show("Purchase Invoice Updated");
						Clear();
						GetNextInvoiceNo();
						lblInvoiceDate.Text=GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());
						CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:btnSaved_Click,  Fuel Purchase Invoice Updated  "+" userid "+uid);
					}
				}
				checkPrevileges();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:btnSaved_Click,Class:PartiesClass.cs"+" Fuel Purchase Invoise for  Invoice No."+obj.Invoice_No+" ,"+"for Vender Name  "+obj.Vendor_Name+  "on Date "+obj.Vendor_Name+"  is Saved "+"  EXCEPTION  "+ex.Message +" userid "+uid);
			}
		}
		
		/// <summary>
		/// This method is not used.
		/// </summary>
		string Check1(string str)
		{
			if(str.Length>0&&Char.IsDigit(str,0))
				return	float.Parse(str,System.Globalization.NumberStyles.Float).ToString();
			else
				return "0.0";
		}

		/// <summary>
		/// this is used to split the date.
		/// </summary>
		private DateTime getdate(string dat,bool to)
		{
			//int dd=mm=yy=0;
			string[] dt=dat.Split(new char[]{'/'},dat.Length);
			if(to)
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
			else
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
		}

		/// <summary>
		/// this is used to fetch packtype & Rate.
		/// </summary>
		public void Prod_Changed(DropDownList ddProd,TextBox txtPurRate)
		{
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr;
			string sql;

			#region Fetch Purchase Rate Regarding Product Name		
			sql= "select top 1 Pur_Rate from Price_Updation where Prod_ID=(select  Prod_ID from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"') order by eff_date desc";
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read ())
			{
				txtPurRate.Text=SqlDtr.GetValue(0).ToString();
			}
			SqlDtr.Close();
			#endregion			
		}

		/// <summary>
		/// This Method is used to clears the whole form.
		/// </summary>
		public void Clear()
		{
			Vendor_ID="0";
			DropModeType.SelectedIndex=0;
			DropVendorID.SelectedIndex=0;
			lblPlace.Value="";
			txtVehicleNo.Text="";
			txtVInvoiceNo.Text="";
			txtVInvoiceDate.Text=""; 
			txtPromoScheme.Text="";
			txtRemark.Text="";
			tempRate1.Value="";
			tempRate2.Value="";
			tempRate3.Value="";
			tempRate4.Value="";
			txtGrandTotal.Text="";
			txtDisc.Text="";
			txtNetAmount.Text="";
			txtLTC1.Text="";
			txtLTC2.Text="";
			txtLTC3.Text="";
			txtDenAfterDec1.Text="";
			txtDenAfterDec2.Text="";
			txtDenAfterDec3.Text="";
			txtDenAfterDec4.Text="";
			txtTempAfterDec1.Text="";
			txtTempAfterDec2.Text="";
			txtTempAfterDec3.Text="";
			txtTempAfterDec4.Text="";
			txtConvDenAfterDec1.Text="";
			txtConvDenAfterDec2.Text="";
			txtConvDenAfterDec3.Text="";
			txtConvDenAfterDec4.Text="";
			txtLTC4.Text="";
			txtLSTSurcharge1.Text="";
			txtLSTSurcharge2.Text="";
			txtLSTSurcharge3.Text="";
			txtLSTSurcharge4.Text="";
			txtDenConv1.Text="";
			txtDenConv2.Text="";
			txtDenConv3.Text="";
			txtDenConv4.Text="";
			DropDiscType.SelectedIndex=0;
			tempInvoiceInfo.Value="";
			for(int i=0;i<ProductType.Length;i++)
			{
				ProductType[i]="";
				ProductName[i]="";
				ProductPack[i]="";
				ProductQty[i]="";
			}
			#region Clear All Products Details
			DropProd1.SelectedIndex=0;
			DropProd2.SelectedIndex=0;
			DropProd3.SelectedIndex=0;
			DropProd4.SelectedIndex=0;
			
			txtDensityInPhysical1.Text="";
			txtDensityInPhysical2.Text="";
			txtDensityInPhysical3.Text="";
			txtDensityInPhysical4.Text="";
		
			txtTempInPhysical1.Text="";
			txtTempInPhysical2.Text="";
			txtTempInPhysical3.Text="";
			txtTempInPhysical4.Text="";
			txtDensityVariation1.Text="";
			txtDensityVariation2.Text="";
			txtDensityVariation3.Text="";
			txtDensityVariation4.Text="";
			txtConDensity1.Text="";
			txtConDensity2.Text="";
			txtConDensity3.Text="";
			txtConDensity4.Text="";
			txtQty1.Text="";
			txtQty2.Text="";
			txtQty3.Text="";
			txtQty4.Text="";
			txtTempQty1.Text = ""; 
			txtTempQty2.Text = "";
			txtTempQty3.Text = "";
			txtTempQty4.Text = "";
			txtRate1.Text="";
			txtRate2.Text="";
			txtRate3.Text="";
			txtRate4.Text="";
			txtAmount1.Text=""; 
			txtAmount1.Text=""; 
			txtAmount2.Text=""; 
			txtAmount3.Text=""; 
			txtAmount4.Text=""; 
			txtReduction1.Text="";
			txtReduction2.Text="";
			txtReduction3.Text="";
			txtReduction4.Text="";
			txtEntryTax1.Text="";
			txtEntryTax2.Text="";
			txtEntryTax3.Text="";
			txtEntryTax4.Text="";
			txtRPGCharge1.Text="";
			txtRPGCharge2.Text="";
			txtRPGCharge3.Text="";
			txtRPGCharge4.Text="";
			txtRPGSurcharge1.Text="";
			txtRPGSurcharge2.Text="";
			txtRPGSurcharge3.Text="";
			txtRPGSurcharge4.Text="";
			txtLTC1.Text="";
			txtLTC2.Text="";
			txtLTC3.Text="";
			txtLTC4.Text="";
			txtTransportCharge1.Text="";
			txtTransportCharge2.Text="";
			txtTransportCharge3.Text="";
			txtTransportCharge4.Text="";
			txtOther1.Text="";
			txtOther2.Text="";
			txtOther3.Text="";
			txtOther4.Text="";
			txtLST1.Text="";
			txtLST2.Text="";
			txtLST3.Text="";
			txtLST4.Text="";
			txtLFR1.Text="";
			txtLFR2.Text="";
			txtLFR3.Text="";
			txtLFR4.Text="";
			txtDO1.Text="";
			txtDO2.Text="";
			txtDO3.Text="";
			txtDO4.Text="";

			// Clear Hidden Fields
			txtReduction.Value="";
			txtEntryTax.Value="";
			txtRPGCharge.Value=""; 
			txtRPGSurcharge.Value ="";
			txtLTC.Value="";
			txtTransportCharge.Value="";
			txtOther.Value ="";
			txtLST.Value="";
			txtLSTSurcharge.Value="";
			txtLFR.Value="";
			txtDO.Value="";
			txtUnit.Value =""; 

			txtReduction5.Value="";
			txtEntryTax5.Value="";
			txtRPGCharge5.Value=""; 
			txtRPGSurcharge5.Value ="";
			txtLTC5.Value="";
			txtTransportCharge5.Value="";
			txtOther5.Value ="";
			txtLST5.Value="";
			txtLSTSurcharge5.Value="";
			txtLFR5.Value="";
			txtDO5.Value="";
			txtUnit5.Value =""; 

			txtReduction6.Value="";
			txtEntryTax6.Value="";
			txtRPGCharge6.Value=""; 
			txtRPGSurcharge6.Value ="";
			txtLTC6.Value="";
			txtTransportCharge6.Value="";
			txtOther6.Value ="";
			txtLST6.Value="";
			txtLSTSurcharge6.Value="";
			txtLFR6.Value="";
			txtDO6.Value="";
			txtUnit6.Value =""; 

			txtReduction7.Value="";
			txtEntryTax7.Value="";
			txtRPGCharge7.Value=""; 
			txtRPGSurcharge7.Value ="";
			txtLTC7.Value="";
			txtTransportCharge7.Value="";
			txtOther7.Value ="";
			txtLST7.Value="";
			txtLSTSurcharge7.Value="";
			txtLFR7.Value="";
			txtDO7.Value="";
			txtUnit7.Value =""; 
			lblTinNo.Value="";
			#endregion
		}

		/// <summary>
		/// This method is used to gets the next invoice no . to display on a screen
		/// </summary>
		public void GetNextInvoiceNo()
		{
			InventoryClass obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql; 

			#region Fetch the Next Invoice Number
			sql="select max(Invoice_No)+1 from Purchase_Master";
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
		
		/// <summary>
		/// This method is used to check the given string is blank or not if string is blank than return the zero.
		/// </summary>
		string Check(string str)
		{
			if(str.Equals(""))
				return "0.0";
			else
				return str;
		}

		public void cmdtot_Click(object sender, System.EventArgs e)
		{
			double tot;			
			checked
			{
				Single init_cost=(Single.Parse(Check(txtQty1.Text))*Single.Parse(Check(txtRate1.Text)));
				Single reduc=Single.Parse(Check(txtQty1.Text))*Single.Parse(Check(txtReduction1.Text));
				Single etax=(init_cost*Single.Parse(Check(txtEntryTax1.Text.Trim())))/100;
				Single rpocg=Single.Parse(Check(txtQty1.Text))*Single.Parse(Check(txtRPGCharge1.Text));
				Single rposcg=Single.Parse(Check(txtQty1.Text))*Single.Parse(Check(txtRPGSurcharge1.Text));
				Single ltchg=Single.Parse(Check(txtQty1.Text))*Single.Parse(Check(txtLTC1.Text));
				Single tcchg=Single.Parse(Check(txtQty1.Text))*Single.Parse(Check(txtTransportCharge1.Text));
				Single lst=(init_cost+reduc+etax+rpocg+rposcg+ltchg+tcchg)*Single.Parse(Check(txtLST1.Text))/100;
				Single lstschg=lst*Single.Parse(Check(txtLSTSurcharge1.Text))/100;
				Single lfrecov=Single.Parse(Check(txtQty1.Text))*Single.Parse(Check(txtLFR1.Text));
				tot=Math.Round(init_cost+reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov);
				txtAmount1.Text=tot.ToString();

				init_cost=(Single.Parse(Check(txtQty2.Text))*Single.Parse(Check(txtRate2.Text)));
				reduc=-Single.Parse(Check(txtQty2.Text))*Single.Parse(Check(txtReduction2.Text));
				etax=(init_cost*Single.Parse(Check(txtEntryTax2.Text.Trim())))/100;
				rpocg=Single.Parse(Check(txtQty2.Text))*Single.Parse(Check(txtRPGCharge2.Text));
				rposcg=Single.Parse(Check(txtQty2.Text))*Single.Parse(Check(txtRPGSurcharge2.Text));
				ltchg=Single.Parse(Check(txtQty2.Text))*Single.Parse(Check(txtLTC2.Text));
				tcchg=Single.Parse(Check(txtQty2.Text))*Single.Parse(Check(txtTransportCharge2.Text));
				lst=(init_cost+reduc+etax+rpocg+rposcg+ltchg+tcchg)*Single.Parse(Check(txtLST2.Text))/100;
				lstschg=lst*Single.Parse(Check(txtLSTSurcharge2.Text))/100;
				lfrecov=Single.Parse(Check(txtQty2.Text))*Single.Parse(Check(txtLFR2.Text));
				tot=Math.Round(init_cost+reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov);
				txtAmount2.Text=tot.ToString();

				init_cost=(Single.Parse(Check(txtQty3.Text))*Single.Parse(Check(txtRate3.Text)));
				reduc=-Single.Parse(Check(txtQty3.Text))*Single.Parse(Check(txtReduction3.Text));
				etax=(init_cost*Single.Parse(Check(txtEntryTax3.Text.Trim())))/100;
				rpocg=Single.Parse(Check(txtQty3.Text))*Single.Parse(Check(txtRPGCharge3.Text));
				rposcg=Single.Parse(Check(txtQty3.Text))*Single.Parse(Check(txtRPGSurcharge3.Text));
				ltchg=Single.Parse(Check(txtQty3.Text))*Single.Parse(Check(txtLTC3.Text));
				tcchg=Single.Parse(Check(txtQty3.Text))*Single.Parse(Check(txtTransportCharge3.Text));
				lst=(init_cost+reduc+etax+rpocg+rposcg+ltchg+tcchg)*Single.Parse(Check(txtLST3.Text))/100;
				lstschg=lst*Single.Parse(Check(txtLSTSurcharge3.Text))/100;
				lfrecov=Single.Parse(Check(txtQty3.Text))*Single.Parse(Check(txtLFR3.Text));
				tot=Math.Round(init_cost+reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov);
				txtAmount3.Text=tot.ToString();

				init_cost=(Single.Parse(Check(txtQty4.Text))*Single.Parse(Check(txtRate4.Text)));
				reduc=-Single.Parse(Check(txtQty4.Text))*Single.Parse(Check(txtReduction4.Text));
				etax=(init_cost*Single.Parse(Check(txtEntryTax4.Text.Trim())))/100;
				rpocg=Single.Parse(Check(txtQty4.Text))*Single.Parse(Check(txtRPGCharge4.Text));
				rposcg=Single.Parse(Check(txtQty4.Text))*Single.Parse(Check(txtRPGSurcharge4.Text));
				ltchg=Single.Parse(Check(txtQty4.Text))*Single.Parse(Check(txtLTC4.Text));
				tcchg=Single.Parse(Check(txtQty4.Text))*Single.Parse(Check(txtTransportCharge4.Text));
				lst=(init_cost+reduc+etax+rpocg+rposcg+ltchg+tcchg)*Single.Parse(Check(txtLST4.Text))/100;
				lstschg=lst*Single.Parse(Check(txtLSTSurcharge4.Text))/100;
				lfrecov=Single.Parse(Check(txtQty4.Text))*Single.Parse(Check(txtLFR4.Text));
				tot=Math.Round(init_cost+reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov);
				txtAmount4.Text=tot.ToString();
				tot=Double.Parse(Check(txtAmount1.Text))+Double.Parse(Check(txtAmount2.Text))+Double.Parse(Check(txtAmount3.Text))+Double.Parse(Check(txtAmount4.Text));
				txtGrandTotal.Text=tot.ToString();
				txtNetAmount.Text=tot.ToString();
			}
		}


		public void masterden()
		{
			string temp = "";
			Label[]  Compartment={lblComp1, lblComp2, lblComp3, lblComp4}; 
			DropDownList[] ProdName={DropProd1, DropProd2, DropProd3, DropProd4};
			TextBox[]  Density_in_Physical={txtDensityInPhysical1, txtDensityInPhysical2, txtDensityInPhysical3, txtDensityInPhysical4}; 
			TextBox[]  Temp_in_Physical={txtTempInPhysical1, txtTempInPhysical2, txtTempInPhysical3, txtTempInPhysical4}; 
			TextBox[]  Conv_Density_Phy={txtConDensity1, txtConDensity2, txtConDensity3, txtConDensity4}; 
			TextBox[]  Density_in_Invoice_conv={txtDenConv1, txtDenConv2, txtDenConv3, txtDenConv4}; 
			TextBox[]  Density_Variation={txtDensityVariation1, txtDensityVariation2, txtDensityVariation3, txtDensityVariation4}; 
			TextBox[]  Den_After_Dec={txtDenAfterDec1, txtDenAfterDec2, txtDenAfterDec3, txtDenAfterDec4}; 
			TextBox[]  Temp_After_Dec={txtTempAfterDec1, txtTempAfterDec2, txtTempAfterDec3, txtTempAfterDec4}; 
			TextBox[]  Conv_Den_After_Dec={txtConvDenAfterDec1, txtConvDenAfterDec2, txtConvDenAfterDec3, txtConvDenAfterDec4}; 
			TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4};
			TextBox[]  tempQty = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4};
			TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4};
			TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4};
			TextBox[]  Reduction = {txtReduction1,txtReduction2,txtReduction3,txtReduction4 }; 
			TextBox[]  Entry_Tax = {txtEntryTax1,txtEntryTax2,txtEntryTax3,txtEntryTax4 };  
			TextBox[]  RPG_Charges = {txtRPGCharge1,txtRPGCharge2,txtRPGCharge3,txtRPGCharge4 }; 
			TextBox[]  RPG_Surcharge = {txtRPGSurcharge1,txtRPGSurcharge2,txtRPGSurcharge3,txtRPGSurcharge4 }; 
			TextBox[]  LTC = {txtLTC1,txtLTC2,txtLTC3,txtLTC4 };
			TextBox[]  Trans_Charge = {txtTransportCharge1,txtTransportCharge2,txtTransportCharge3,txtTransportCharge4 }; 
			TextBox[]  OLV = {txtOther1,txtOther2 ,txtOther3 ,txtOther4}; 
			TextBox[]  LST = {txtLST1,txtLST2,txtLST3,txtLST4 }; 
			TextBox[]  LST_Surcharge = {txtLSTSurcharge1,txtLSTSurcharge2,txtLSTSurcharge3,txtLSTSurcharge4 };
			TextBox[]  LFR = {txtLFR1,txtLFR2 ,txtLFR3 ,txtLFR4};
			TextBox[]  DOFOBC_Charge = {txtDO1,txtDO2,txtDO3,txtDO4 };

			for(int j=0;j<ProdName.Length ;j++)
			{
				if(ProdName[j].SelectedIndex ==0)
					continue;
				if(tempQty[j].Text == "")
					temp = Qty[j].Text.ToString();
				else
					temp = System.Convert.ToString(System.Convert.ToDouble(Qty[j].Text)-System.Convert.ToDouble(tempQty[j].Text)); 
				Save1(Compartment[j].Text.ToString(), ProdName[j].SelectedItem.ToString(), Density_in_Physical[j].Text.ToString(), Temp_in_Physical[j].Text.ToString(), Conv_Density_Phy[j].Text.ToString(), Density_in_Invoice_conv[j].Text.ToString(), Density_Variation[j].Text.ToString(), Den_After_Dec[j].Text.ToString(), Temp_After_Dec[j].Text.ToString(), Conv_Den_After_Dec[j].Text.ToString(), Qty[j].Text.ToString(),Rate[j].Text.ToString (),Amount[j].Text.ToString (),temp,GenUtil.str2MMDDYYYY(lblInvoiceDate.Text.ToString()),Reduction[j].Text.ToString(), Entry_Tax[j].Text.ToString(), RPG_Charges[j].Text.ToString(), RPG_Surcharge[j].Text.ToString(),LTC[j].Text.ToString(), Trans_Charge[j].Text.ToString(),OLV[j].Text.ToString(),LST[j].Text.ToString(),LST_Surcharge[j].Text.ToString(),LFR[j].Text.ToString(),DOFOBC_Charge[j].Text.ToString ());
			}
		}

		/// <summary>
		/// This method is used to fatch the record according to select purchase invoice no from dropdownlist.
		/// </summary>
		private void DropInvoiceNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			textselect.Text=DropInvoiceNo.SelectedItem.Value.ToString();
			try
			{
				if(textselect.Text=="Select")
				{
					MessageBox.Show("Please Select Invoice No");
				}
				else
				{
					Clear();		
					InventoryClass  obj=new InventoryClass ();
					InventoryClass  obj1=new InventoryClass ();
					SqlDataReader SqlDtr,SqlDtr1;
					string sql1,sql2;
					string strDate,strDate2,strNetAmt;
					strNetAmt = "";
					string sql="select P.Invoice_Date,P.Vehicle_No,P.Vndr_Invoice_No,P.Vndr_Invoice_Date,P.Promo_Scheme,P.Remark, s.Supp_Name,s.City,p.Grand_Total,p.Discount,p.Discount_Type,p.Net_Amount,p.Mode_Of_Payment,s.supp_id from purchase_master as p,supplier as s where invoice_no="+ DropInvoiceNo.SelectedItem.Value +"and s.Supp_ID=P.Vendor_ID";
				
					SqlDtr=obj.GetRecordSet(sql); 
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							strDate = SqlDtr.GetValue(0).ToString().Trim();
							int pos = strDate.IndexOf(" ");
				
							if(pos != -1)
							{
								strDate = strDate.Substring(0,pos);
							}
							else
							{
								strDate = "";					
							}

							lblInvoiceDate.Text= GenUtil.str2DDMMYYYY(strDate);
							txtVehicleNo.Text=SqlDtr.GetValue(1).ToString(); 
							txtVInvoiceNo.Text =SqlDtr.GetValue(2).ToString();
						
							strDate2 = SqlDtr.GetValue(3).ToString().Trim();
							int pos1 = strDate2.IndexOf(" ");
				
							if(pos1 != -1)
							{
								strDate2 = strDate2.Substring(0,pos1);
							}
							else
							{
								strDate2 = "";					
							}
							txtVInvoiceDate.Text = GenUtil.str2DDMMYYYY(strDate2); 
							txtPromoScheme.Text =SqlDtr.GetValue(4).ToString();
							txtRemark.Text=SqlDtr.GetValue(5).ToString(); 
							DropVendorID.SelectedIndex=(DropVendorID .Items.IndexOf((DropVendorID .Items.FindByValue (SqlDtr.GetValue(6).ToString()))));
							lblPlace.Value=SqlDtr.GetValue(7).ToString();
						
							txtGrandTotal.Text= GenUtil.strNumericFormat(SqlDtr.GetValue(8).ToString());
							txtDisc.Text = GenUtil.strNumericFormat(SqlDtr.GetValue(9).ToString());
							DropDiscType.SelectedIndex =(DropDiscType.Items.IndexOf((DropDiscType.Items.FindByValue(SqlDtr.GetValue(10).ToString()))));     
							strNetAmt = SqlDtr.GetValue(11).ToString();
							if(!strNetAmt.Equals("")) 
								txtNetAmount.Text  = GenUtil.strNumericFormat(System.Convert.ToString(System.Math.Round(System.Convert.ToDouble(strNetAmt),2))); 
							DropModeType.SelectedIndex = (DropModeType.Items.IndexOf((DropModeType.Items.FindByValue(SqlDtr.GetValue(12).ToString()))));         
							Vendor_ID = SqlDtr["Supp_ID"].ToString();
						}
					}
					SqlDtr.Close();
					//int i=0;
					sql1="select * from Fuel_Purchase_Details where Invoice_No='"+ DropInvoiceNo.SelectedItem.Value +"'";/*  and Compartment='Comp. I'" ;*/
					SqlDtr=obj.GetRecordSet(sql1);
					// Fills the compartments according to their values.
					if(SqlDtr.HasRows )
					{
						while(SqlDtr.Read())
						{
							if(SqlDtr.GetValue(1).ToString().Equals("Comp. I"))
							{
								sql2="select p.Prod_Name, t.Reduction,t.entry_tax,t.rpg_charge,t.rpg_surcharge,t.LT_Charge,t.Tran_charge,t.Other_lvy,t.LST,t.LST_surcharge,t.LF_recov,t.dofobc_charge,t.unit_rdc,t.unit_etax,t.unit_rpgchg,t.unit_rpgschg,t.unit_ltchg,t.unit_tchg,t.unit_olvy,t.unit_lst,t.unit_lstschg,t.unit_lfrecov,t.unit_dochg  from Products p,Fuel_Purchase_Details f,Tax_entry t where p.Prod_ID=t.ProductId and p.Prod_ID=f.Prod_ID and p.Category='fuel'and f.Invoice_No='"+DropInvoiceNo.SelectedValue +"'and f.compartment='"+SqlDtr.GetValue(1).ToString()+"'";
								SqlDtr1=obj1.GetRecordSet(sql2);
								if(SqlDtr1.HasRows )
								{
									while(SqlDtr1.Read())
									{
										DropProd1.SelectedIndex=(DropProd1 .Items.IndexOf((DropProd1 .Items.FindByValue (SqlDtr1.GetValue(0).ToString()))));
										txtReduction.Value=SqlDtr1.GetValue(1).ToString();
										txtEntryTax.Value=SqlDtr1.GetValue(2).ToString();
										txtRPGCharge.Value=SqlDtr1.GetValue(3).ToString(); 
										txtRPGSurcharge.Value =SqlDtr1.GetValue(4).ToString();
										txtLTC.Value=SqlDtr1.GetValue(5).ToString(); 
										txtTransportCharge.Value=SqlDtr1.GetValue(6).ToString();
										txtOther.Value =SqlDtr1.GetValue(7).ToString(); 
										txtLST.Value=SqlDtr1.GetValue(8).ToString();  
										txtLSTSurcharge.Value=SqlDtr1.GetValue(9).ToString();
										txtLFR.Value=SqlDtr1.GetValue(10).ToString();
										txtDO.Value=SqlDtr1.GetValue(11).ToString(); 
										txtUnit.Value = SqlDtr1.GetValue(12).ToString()+"#"+ SqlDtr1.GetValue(13).ToString()+"#"+SqlDtr1.GetValue(14).ToString()+"#"+SqlDtr1.GetValue(15).ToString()+"#"+SqlDtr1.GetValue(16).ToString()+"#"+SqlDtr1.GetValue(17).ToString()+"#"+SqlDtr1.GetValue(18).ToString()+"#"+SqlDtr1.GetValue(19).ToString()+"#"+SqlDtr1.GetValue(20).ToString()+"#"+SqlDtr1.GetValue(21).ToString()+"#"+SqlDtr1.GetValue(22).ToString();
									}
								}
								SqlDtr1.Close();
								txtQty1.Text=SqlDtr.GetValue(11).ToString();
								txtTempQty1.Text = txtQty1.Text; 
								txtRate1.Text=SqlDtr.GetValue(12).ToString();
								txtAmount1.Text=SqlDtr.GetValue(13).ToString();
								txtDensityInPhysical1.Text=SqlDtr.GetValue(3).ToString();
								txtTempInPhysical1 .Text=SqlDtr.GetValue(4).ToString();
								txtConDensity1 .Text=SqlDtr.GetValue(5).ToString();
								txtDenConv1.Text=SqlDtr.GetValue(6).ToString();
								txtDensityVariation1 .Text=SqlDtr.GetValue(7).ToString(); 
								txtDenAfterDec1 .Text=SqlDtr.GetValue(8).ToString();
								txtTempAfterDec1.Text=SqlDtr.GetValue(9).ToString();
								txtConvDenAfterDec1.Text=SqlDtr.GetValue(10).ToString();
								txtReduction1.Text=SqlDtr.GetValue(15).ToString();
								txtEntryTax1.Text = SqlDtr.GetValue(16).ToString(); 
								txtRPGCharge1.Text = SqlDtr.GetValue(17).ToString();  
								txtRPGSurcharge1.Text = SqlDtr.GetValue(18).ToString();   
								txtLTC1.Text = SqlDtr.GetValue(19).ToString();   
								txtTransportCharge1.Text = SqlDtr.GetValue(20).ToString();   
								txtOther1.Text = SqlDtr.GetValue(21).ToString();   
								txtLST1.Text = SqlDtr.GetValue(22).ToString();   
								txtLSTSurcharge1.Text = SqlDtr.GetValue(23).ToString();   
								txtLFR1.Text = SqlDtr.GetValue(24).ToString();   
								txtDO1.Text = SqlDtr.GetValue(25).ToString();   
								string Prate="";
								dbobj.SelectQuery("select top 1 Pur_Rate from Price_Updation where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' order by eff_date desc","Pur_Rate",ref Prate);
								tempRate1.Value=Prate;
							}
							else if(SqlDtr.GetValue(1).ToString().Equals("Comp. II"))
							{
								sql2="select p.Prod_Name,t.Reduction,t.entry_tax,t.rpg_charge,t.rpg_surcharge,t.LT_Charge,t.Tran_charge,t.Other_lvy,t.LST,t.LST_surcharge,t.LF_recov,t.dofobc_charge,t.unit_rdc,t.unit_etax,t.unit_rpgchg,t.unit_rpgschg,t.unit_ltchg,t.unit_tchg,t.unit_olvy,t.unit_lst,t.unit_lstschg,t.unit_lfrecov,t.unit_dochg from Products p,Fuel_Purchase_Details f,Tax_entry t where p.Prod_ID=t.ProductId and p.Prod_ID=f.Prod_ID and p.Category='fuel'and f.Invoice_No='"+DropInvoiceNo.SelectedValue +"'and f.compartment='"+SqlDtr.GetValue(1).ToString()+"'";
								SqlDtr1=obj1.GetRecordSet(sql2);
								if(SqlDtr1.HasRows )
								{
									while(SqlDtr1.Read())
									{
										DropProd2.SelectedIndex=(DropProd2 .Items.IndexOf((DropProd2 .Items.FindByValue (SqlDtr1.GetValue(0).ToString()))));
										txtReduction5.Value=SqlDtr1.GetValue(1).ToString();
										txtEntryTax5.Value=SqlDtr1.GetValue(2).ToString();
										txtRPGCharge5.Value=SqlDtr1.GetValue(3).ToString(); 
										txtRPGSurcharge5.Value =SqlDtr1.GetValue(4).ToString();
										txtLTC5.Value=SqlDtr1.GetValue(5).ToString(); 
										txtTransportCharge5.Value=SqlDtr1.GetValue(6).ToString();
										txtOther5.Value=SqlDtr1.GetValue(7).ToString(); 
										txtLST5.Value=SqlDtr1.GetValue(8).ToString();  
										txtLSTSurcharge5.Value=SqlDtr1.GetValue(9).ToString();
										txtLFR5.Value=SqlDtr1.GetValue(10).ToString();
										txtDO5.Value=SqlDtr1.GetValue(11).ToString();  
										txtUnit5.Value = SqlDtr1.GetValue(12).ToString()+"#"+ SqlDtr1.GetValue(13).ToString()+"#"+SqlDtr1.GetValue(14).ToString()+"#"+SqlDtr1.GetValue(15).ToString()+"#"+SqlDtr1.GetValue(16).ToString()+"#"+SqlDtr1.GetValue(17).ToString()+"#"+SqlDtr1.GetValue(18).ToString()+"#"+SqlDtr1.GetValue(19).ToString()+"#"+SqlDtr1.GetValue(20).ToString()+"#"+SqlDtr1.GetValue(21).ToString()+"#"+SqlDtr1.GetValue(22).ToString();
									}
								}
								SqlDtr1.Close();
								txtQty2.Text=SqlDtr.GetValue(11).ToString();
								txtTempQty2.Text = txtQty2.Text;
								txtRate2.Text=SqlDtr.GetValue(12).ToString();
								txtAmount2.Text=SqlDtr.GetValue(13).ToString();
								txtDensityInPhysical2.Text=SqlDtr.GetValue(3).ToString();
								txtTempInPhysical2.Text=SqlDtr.GetValue(4).ToString();
								txtConDensity2.Text=SqlDtr.GetValue(5).ToString();
								txtDenConv2.Text=SqlDtr.GetValue(6).ToString();
								txtDensityVariation2.Text=SqlDtr.GetValue(7).ToString(); 
								txtDenAfterDec2.Text=SqlDtr.GetValue(8).ToString();
								txtTempAfterDec2.Text=SqlDtr.GetValue(9).ToString();
								txtConvDenAfterDec2.Text=SqlDtr.GetValue(10).ToString();
								txtReduction2.Text=SqlDtr.GetValue(15).ToString();
								txtEntryTax2.Text = SqlDtr.GetValue(16).ToString(); 
								txtRPGCharge2.Text = SqlDtr.GetValue(17).ToString();  
								txtRPGSurcharge2.Text = SqlDtr.GetValue(18).ToString();   
								txtLTC2.Text = SqlDtr.GetValue(19).ToString();   
								txtTransportCharge2.Text = SqlDtr.GetValue(20).ToString();   
								txtOther2.Text = SqlDtr.GetValue(21).ToString();   
								txtLST2.Text = SqlDtr.GetValue(22).ToString();   
								txtLSTSurcharge2.Text = SqlDtr.GetValue(23).ToString();   
								txtLFR2.Text = SqlDtr.GetValue(24).ToString();   
								txtDO2.Text = SqlDtr.GetValue(25).ToString();  
								string Prate="";
								dbobj.SelectQuery("select top 1 Pur_Rate from Price_Updation where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' order by eff_date desc","Pur_Rate",ref Prate);
								tempRate2.Value=Prate;
							}
							else if(SqlDtr.GetValue(1).ToString().Equals("Comp. III"))
							{
								sql2="select p.Prod_Name,t.Reduction,t.entry_tax,t.rpg_charge,t.rpg_surcharge,t.LT_Charge,t.Tran_charge,t.Other_lvy,t.LST,t.LST_surcharge,t.LF_recov,t.dofobc_charge,t.unit_rdc,t.unit_etax,t.unit_rpgchg,t.unit_rpgschg,t.unit_ltchg,t.unit_tchg,t.unit_olvy,t.unit_lst,t.unit_lstschg,t.unit_lfrecov,t.unit_dochg  from Products p,Fuel_Purchase_Details f,Tax_entry t where p.Prod_ID=t.ProductId and p.Prod_ID=f.Prod_ID and p.Category='fuel'and f.Invoice_No='"+DropInvoiceNo.SelectedValue +"'and f.compartment='"+SqlDtr.GetValue(1).ToString()+"'";
								SqlDtr1=obj1.GetRecordSet(sql2);
								if(SqlDtr1.HasRows )
								{
									while(SqlDtr1.Read())
									{
										DropProd3.SelectedIndex=(DropProd3.Items.IndexOf((DropProd3 .Items.FindByValue (SqlDtr1.GetValue(0).ToString()))));
										txtReduction6.Value=SqlDtr1.GetValue(1).ToString();
										txtEntryTax6.Value=SqlDtr1.GetValue(2).ToString();
										txtRPGCharge6.Value=SqlDtr1.GetValue(3).ToString(); 
										txtRPGSurcharge6.Value =SqlDtr1.GetValue(4).ToString();
										txtLTC6.Value=SqlDtr1.GetValue(5).ToString(); 
										txtTransportCharge6.Value=SqlDtr1.GetValue(6).ToString();
										txtOther6.Value=SqlDtr1.GetValue(7).ToString(); 
										txtLST6.Value=SqlDtr1.GetValue(8).ToString();  
										txtLSTSurcharge6.Value=SqlDtr1.GetValue(9).ToString();
										txtLFR6.Value=SqlDtr1.GetValue(10).ToString();
										txtDO6.Value=SqlDtr1.GetValue(11).ToString();
										txtUnit6.Value = SqlDtr1.GetValue(12).ToString()+"#"+ SqlDtr1.GetValue(13).ToString()+"#"+SqlDtr1.GetValue(14).ToString()+"#"+SqlDtr1.GetValue(15).ToString()+"#"+SqlDtr1.GetValue(16).ToString()+"#"+SqlDtr1.GetValue(17).ToString()+"#"+SqlDtr1.GetValue(18).ToString()+"#"+SqlDtr1.GetValue(19).ToString()+"#"+SqlDtr1.GetValue(20).ToString()+"#"+SqlDtr1.GetValue(21).ToString()+"#"+SqlDtr1.GetValue(22).ToString();
									}
								}
								SqlDtr1.Close();
								txtQty3.Text=SqlDtr.GetValue(11).ToString();
								txtTempQty3.Text = txtQty3.Text;
								txtRate3.Text=SqlDtr.GetValue(12).ToString();
								txtAmount3.Text=SqlDtr.GetValue(13).ToString();
								txtDensityInPhysical3.Text=SqlDtr.GetValue(3).ToString();
								txtTempInPhysical3.Text=SqlDtr.GetValue(4).ToString();
								txtConDensity3.Text=SqlDtr.GetValue(5).ToString();
								txtDenConv3.Text=SqlDtr.GetValue(6).ToString();
								txtDensityVariation3.Text=SqlDtr.GetValue(7).ToString(); 
								txtDenAfterDec3.Text=SqlDtr.GetValue(8).ToString();
								txtTempAfterDec3.Text=SqlDtr.GetValue(9).ToString();
								txtConvDenAfterDec3.Text=SqlDtr.GetValue(10).ToString();
								txtReduction3.Text=SqlDtr.GetValue(15).ToString();
								txtEntryTax3.Text = SqlDtr.GetValue(16).ToString(); 
								txtRPGCharge3.Text = SqlDtr.GetValue(17).ToString();  
								txtRPGSurcharge3.Text = SqlDtr.GetValue(18).ToString();   
								txtLTC3.Text = SqlDtr.GetValue(19).ToString();   
								txtTransportCharge3.Text = SqlDtr.GetValue(20).ToString();   
								txtOther3.Text = SqlDtr.GetValue(21).ToString();   
								txtLST3.Text = SqlDtr.GetValue(22).ToString();   
								txtLSTSurcharge3.Text = SqlDtr.GetValue(23).ToString();   
								txtLFR3.Text = SqlDtr.GetValue(24).ToString();   
								txtDO3.Text = SqlDtr.GetValue(25).ToString();  
								string Prate="";
								dbobj.SelectQuery("select top 1 Pur_Rate from Price_Updation where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' order by eff_date desc","Pur_Rate",ref Prate);
								tempRate3.Value=Prate;
							}
							else if(SqlDtr.GetValue(1).ToString().Equals("Comp. IV"))
							{
								sql2="select p.Prod_Name,t.Reduction,t.entry_tax,t.rpg_charge,t.rpg_surcharge,t.LT_Charge,t.Tran_charge,t.Other_lvy,t.LST,t.LST_surcharge,t.LF_recov,t.dofobc_charge,t.unit_rdc,t.unit_etax,t.unit_rpgchg,t.unit_rpgschg,t.unit_ltchg,t.unit_tchg,t.unit_olvy,t.unit_lst,t.unit_lstschg,t.unit_lfrecov,t.unit_dochg  from Products p,Fuel_Purchase_Details f,Tax_entry t where p.Prod_ID=t.ProductId and p.Prod_ID=f.Prod_ID and p.Category='fuel'and f.Invoice_No='"+DropInvoiceNo.SelectedValue +"'and f.compartment='"+SqlDtr.GetValue(1).ToString()+"'";
								SqlDtr1=obj1.GetRecordSet(sql2);
								if(SqlDtr1.HasRows )
								{
									while(SqlDtr1.Read())
									{
										DropProd4.SelectedIndex=(DropProd4.Items.IndexOf((DropProd4.Items.FindByValue (SqlDtr1.GetValue(0).ToString()))));
										txtReduction7.Value=SqlDtr1.GetValue(1).ToString();
										txtEntryTax7.Value=SqlDtr1.GetValue(2).ToString();
										txtRPGCharge7.Value=SqlDtr1.GetValue(3).ToString(); 
										txtRPGSurcharge7.Value =SqlDtr1.GetValue(4).ToString();
										txtLTC7.Value=SqlDtr1.GetValue(5).ToString(); 
										txtTransportCharge7.Value=SqlDtr1.GetValue(6).ToString();
										txtOther7.Value=SqlDtr1.GetValue(7).ToString(); 
										txtLST7.Value=SqlDtr1.GetValue(8).ToString();  
										txtLSTSurcharge7.Value=SqlDtr1.GetValue(9).ToString();
										txtLFR7.Value=SqlDtr1.GetValue(10).ToString();
										txtDO7.Value=SqlDtr1.GetValue(11).ToString();  
										txtUnit7.Value = SqlDtr1.GetValue(12).ToString()+"#"+ SqlDtr1.GetValue(13).ToString()+"#"+SqlDtr1.GetValue(14).ToString()+"#"+SqlDtr1.GetValue(15).ToString()+"#"+SqlDtr1.GetValue(16).ToString()+"#"+SqlDtr1.GetValue(17).ToString()+"#"+SqlDtr1.GetValue(18).ToString()+"#"+SqlDtr1.GetValue(19).ToString()+"#"+SqlDtr1.GetValue(20).ToString()+"#"+SqlDtr1.GetValue(21).ToString()+"#"+SqlDtr1.GetValue(22).ToString();
									}
								}
								SqlDtr1.Close();
								txtQty4.Text=SqlDtr.GetValue(11).ToString();
								txtTempQty4.Text = txtQty4.Text;
								txtRate4.Text=SqlDtr.GetValue(12).ToString();
								txtAmount4.Text=SqlDtr.GetValue(13).ToString();
								txtDensityInPhysical4.Text=SqlDtr.GetValue(3).ToString();
								txtTempInPhysical4.Text=SqlDtr.GetValue(4).ToString();
								txtConDensity4.Text=SqlDtr.GetValue(5).ToString();
								txtDenConv4.Text=SqlDtr.GetValue(6).ToString();
								txtDensityVariation4.Text=SqlDtr.GetValue(7).ToString(); 
								txtDenAfterDec4.Text=SqlDtr.GetValue(8).ToString();
								txtTempAfterDec4.Text=SqlDtr.GetValue(9).ToString();
								txtConvDenAfterDec4.Text=SqlDtr.GetValue(10).ToString();
								txtReduction4.Text=SqlDtr.GetValue(15).ToString();
								txtEntryTax4.Text = SqlDtr.GetValue(16).ToString(); 
								txtRPGCharge4.Text = SqlDtr.GetValue(17).ToString();  
								txtRPGSurcharge4.Text = SqlDtr.GetValue(18).ToString();   
								txtLTC4.Text = SqlDtr.GetValue(19).ToString();   
								txtTransportCharge4.Text = SqlDtr.GetValue(20).ToString();   
								txtOther4.Text = SqlDtr.GetValue(21).ToString();   
								txtLST4.Text = SqlDtr.GetValue(22).ToString();   
								txtLSTSurcharge4.Text = SqlDtr.GetValue(23).ToString();   
								txtLFR4.Text = SqlDtr.GetValue(24).ToString();   
								txtDO4.Text = SqlDtr.GetValue(25).ToString();  
								string Prate="";
								dbobj.SelectQuery("select top 1 Pur_Rate from Price_Updation where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' order by eff_date desc","Pur_Rate",ref Prate);
								tempRate4.Value=Prate;
							}
						}
					}
					SqlDtr.Close();					
				}
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:DropInvoiceNo_SelectedIndexChanged,  "+" userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:DropInvoiceNo_SelectedIndexChanged() ,Class:PartiesClass.cs.  EXCEPTION  "+ex.Message +" userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to fill the all Fuel purchase invoice no in dropdownlist.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				DropInvoiceNo.Visible=true;
				lblInvoiceNo.Visible=false;
				btnEdit.Visible=false;
				btnSave.Enabled = true;  
				DropInvoiceNo.Items.Clear(); 
				DropInvoiceNo.Items.Add("Select");
				DropInvoiceNo.SelectedIndex = 0;
			
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string sql;
				#region Fetch All Invoice NO and fill in the ComboBox

				sql="select distinct Invoice_No from Fuel_Purchase_Details";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					DropInvoiceNo.Items.Add (SqlDtr.GetValue(0).ToString ());				
				}
				SqlDtr.Close ();		
				#endregion
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:btnEdit_Click,  "+" userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:btnEdit_Click ,Class:PartiesClass.cs.  EXCEPTION  "+ex.Message +" userid "+uid);
			}
		}

		/// <summary>
		/// This Function finalise By Mahesh, date 28/11/06,
		/// This function return Converted density according to input values
		/// Density & Tempreture from database Density_con_table.
		/// </summary>
		public string denconversion(int i)
		{
			InventoryClass obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql="";
			int Flag=0;
			try
			{	
				string[] con={txtConDensity1.Text,txtConDensity2.Text,txtConDensity3.Text,txtConDensity4.Text,txtConvDenAfterDec1.Text,txtConvDenAfterDec2.Text,txtConvDenAfterDec3.Text,txtConvDenAfterDec4.Text};
				string[] temp={txtTempInPhysical1.Text,txtTempInPhysical2.Text,txtTempInPhysical3.Text,txtTempInPhysical4.Text,txtTempAfterDec1.Text,txtTempAfterDec2.Text,txtTempAfterDec3.Text,txtTempAfterDec4.Text};
				string[] density={txtDensityInPhysical1.Text,txtDensityInPhysical2.Text,txtDensityInPhysical3.Text,txtDensityInPhysical4.Text,txtDenAfterDec1.Text,txtDenAfterDec2.Text,txtDenAfterDec3.Text,txtDenAfterDec4.Text};
				if(density[i]=="")
				{
					return "";
				}
				double den=System.Convert.ToDouble(density[i]);
				double temp1=System.Convert.ToDouble(temp[i]);
				
				//find the column name of density_con_table.
				//we can also incorporate +2 for converted density perfection.
				//mahesh Date : 28/11/06.
				if(den < 771)
				{
					den=den-680;
				}
				if(den > 789)
				{
					den=den-699;
				}
				den+=2;
				
				if(temp1 < -2.50 || temp1 > 65)
				{
					MessageBox.Show("Invalid Tempreture Value...");
					Flag=1;
				}
				sql = "select f"+den+" from Density_con_table where temp1="+temp[i]+""; 
				if(Flag==0)
				{
					SqlDtr = obj.GetRecordSet(sql);
					if(SqlDtr.Read())
					{
						con[i]=SqlDtr.GetValue(0).ToString();
						return con[i];
					}
					else
					{
						MessageBox.Show("Enter The Value After Point(.25,.5,.75)");
						return "";
					}
					//SqlDtr.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:denconversion(int) ,Class:PartiesClass.cs.  EXCEPTION  "+ex.Message +" userid "+uid);
			}
			return "";
		}

		/// <summary>
		/// This method is used to check the temparature and physical dencity.
		/// </summary>
		private void txtTempInPhysical1_TextChanged(object sender, System.EventArgs e)
		{
			double temp1=System.Convert.ToDouble(txtTempInPhysical1.Text);
			if(txtDensityInPhysical1.Text=="")
			{
				MessageBox.Show("Fill The Density In Physical");
				txtTempInPhysical1.Text="";
				return;
			}
			if(temp1 < -2.5 || temp1 > 65 )
			{
				MessageBox.Show("InValid Tempreture Value ( -2.5 To 65 )");
				txtTempInPhysical1.Text="";
				return;
			}
			txtConDensity1.Text=denconversion(0);
		}	
	
		/// <summary>
		/// This method is used to check the temparature and physical dencity.
		/// </summary>		
		private void txtTempInPhysical2_TextChanged(object sender, System.EventArgs e)
		{
			double temp1=System.Convert.ToDouble(txtTempInPhysical2.Text);
			if(txtDensityInPhysical2.Text=="")
			{
				MessageBox.Show("Fill The Density In Physical");
				txtTempInPhysical2.Text="";
				return;
			}
			if(temp1 < -2.5 || temp1 > 65 )
			{
				MessageBox.Show("InValid Tempreture Value ( -2.5 To 65 )");
				txtTempInPhysical2.Text="";
				return;
			}
			txtConDensity2.Text=denconversion(1);
		}

		/// <summary>
		/// This method is used to check the temparature and physical dencity.
		/// </summary>
		private void txtTempInPhysical3_TextChanged(object sender, System.EventArgs e)
		{
			double temp1=System.Convert.ToDouble(txtTempInPhysical3.Text);
			if(txtDensityInPhysical3.Text=="")
			{
				MessageBox.Show("Fill The Density In Physical");
				txtTempInPhysical3.Text="";
				return;
			}
			if(temp1 < -2.5 || temp1 > 65 )
			{
				MessageBox.Show("InValid Tempreture Value ( -2.5 To 65 )");
				txtTempInPhysical2.Text="";
				return;
			}
			txtConDensity3.Text=denconversion(2);
		}

		/// <summary>
		/// This method is used to check the temparature and physical dencity.
		/// </summary>
		private void txtTempInPhysical4_TextChanged(object sender, System.EventArgs e)
		{
			double temp1=System.Convert.ToDouble(txtTempInPhysical4.Text);
			if(txtDensityInPhysical4.Text=="")
			{
				MessageBox.Show("Fill The Density In Physical");
				txtTempInPhysical4.Text="";
				return;
			}
			if(temp1 < -2.5 || temp1 > 65 )
			{
				MessageBox.Show("InValid Tempreture Value ( -2.5 To 65 )");
				txtTempInPhysical4.Text="";
				return;
			}
			txtConDensity4.Text=denconversion(3);
		}

		/// <summary>
		/// This method is used to check the temparature and physical dencity.
		/// </summary>
		private void txtTempAfterDec1_TextChanged(object sender, System.EventArgs e)
		{
			double temp1=System.Convert.ToDouble(txtTempAfterDec1.Text);
			if(txtDenAfterDec1.Text=="")
			{
				MessageBox.Show("Fill The Density In Physical");
				txtTempAfterDec1.Text="";
				return;
			}
			if(temp1 < -2.5 || temp1 > 65 )
			{
				MessageBox.Show("InValid Tempreture Value ( -2.5 To 65 )");
				txtTempAfterDec1.Text="";
				return;
			}
			txtConvDenAfterDec1.Text=denconversion(4);
		}

		/// <summary>
		/// This method is used to check the temparature and physical dencity.
		/// </summary>
		private void txtTempAfterDec2_TextChanged(object sender, System.EventArgs e)
		{
			double temp1=System.Convert.ToDouble(txtTempAfterDec2.Text);
			if(txtDenAfterDec2.Text=="")
			{
				MessageBox.Show("Fill The Density In Physical");
				txtTempAfterDec2.Text="";
				return;
			}
			if(temp1 < -2.5 || temp1 > 65 )
			{
				MessageBox.Show("InValid Tempreture Value ( -2.5 To 65 )");
				txtTempAfterDec2.Text="";
				return;
			}
			txtConvDenAfterDec2.Text=denconversion(5);
		}

		/// <summary>
		/// This method is used to check the temparature and physical dencity.
		/// </summary>
		private void txtTempAfterDec3_TextChanged(object sender, System.EventArgs e)
		{
			double temp1=System.Convert.ToDouble(txtTempAfterDec3.Text);
			if(txtDenAfterDec3.Text=="")
			{
				MessageBox.Show("Fill The Density In Physical");
				txtTempAfterDec3.Text="";
				return;
			}
			if(temp1 < -2.5 || temp1 > 65 )
			{
				MessageBox.Show("InValid Tempreture Value ( -2.5 To 65 )");
				txtTempAfterDec3.Text="";
				return;
			}
			txtConvDenAfterDec3.Text=denconversion(6);
		}

		/// <summary>
		/// This method is used to check the temparature and physical dencity.
		/// </summary>
		private void txtTempAfterDec4_TextChanged(object sender, System.EventArgs e)
		{
			double temp1=System.Convert.ToDouble(txtTempAfterDec4.Text);
			if(txtDenAfterDec4.Text=="")
			{
				MessageBox.Show("Fill The Density In Physical");
				txtTempAfterDec4.Text="";
				return;
			}
			if(temp1 < -2.5 || temp1 > 65 )
			{
				MessageBox.Show("InValid Tempreture Value ( -2.5 To 65 )");
				txtTempAfterDec4.Text="";
				return;
			}
			txtConvDenAfterDec4.Text=denconversion(7);
		}

		/// <summary>
		/// This method is used to write into the report file to print.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			//reportmaking();
			Print();
		}
		
		/// <summary>
		/// This method is used to delete the particular record select from dropdownlist.
		/// </summary>
		public void DeleteTheRec()
		{
			try
			{
				DropDownList[] DropType={DropProd1,DropProd2,DropProd3,DropProd4};
				//HtmlInputHidden[] ProdName={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
				//HtmlInputHidden[] PackType={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
				TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4};
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				SqlCommand cmd;
				SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
				string st="select Invoice_No from Purchase_Master where Invoice_No='"+DropInvoiceNo.SelectedItem.Text+"'";
				rdr=obj.GetRecordSet(st);
				if(rdr.Read())
				{
					Con.Open();
					cmd = new SqlCommand("delete from Vendorledgertable where Particular='Purchase Invoice ("+rdr["Invoice_No"].ToString()+")'",Con);
					cmd.ExecuteNonQuery();
					Con.Close();
					cmd.Dispose();
					Con.Open();
					cmd = new SqlCommand("delete from Accountsledgertable where Particulars='Purchase Invoice ("+rdr["Invoice_No"].ToString()+")'",Con);
					cmd.ExecuteNonQuery();
					Con.Close();
					cmd.Dispose();
				}
				rdr.Close();
				string str1="select * from VendorLedgerTable where VendorID=(select Supp_ID from Supplier where Supp_Name='"+DropVendorID.SelectedItem.Text+"') order by entrydate";
				rdr=obj.GetRecordSet(str1);
				double Bal=0;
				while(rdr.Read())
				{
					if(rdr["BalanceType"].ToString().Equals("Dr."))
						Bal+=double.Parse(rdr["DebitAmount"].ToString())-double.Parse(rdr["CreditAmount"].ToString());
					else
						Bal+=double.Parse(rdr["CreditAmount"].ToString())-double.Parse(rdr["DebitAmount"].ToString());
					if(Bal.ToString().StartsWith("-"))
						Bal=double.Parse(Bal.ToString().Substring(1));
					Con.Open();
					cmd = new SqlCommand("update VendorLedgerTable set Balance='"+Bal.ToString()+"' where VendorID='"+rdr["VendorID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					Con.Close();
					cmd.Dispose();
				}
				rdr.Close();
				Con.Open();
				cmd = new SqlCommand("delete from Purchase_Master where Invoice_No='"+DropInvoiceNo.SelectedItem.Text+"'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				
				string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name='"+DropVendorID.SelectedItem.Text+"') order by entry_date";
				rdr=obj.GetRecordSet(str);
				Bal=0;
				while(rdr.Read())
				{
					if(rdr["Bal_Type"].ToString().Equals("Dr"))
						Bal+=double.Parse(rdr["Debit_Amount"].ToString())-double.Parse(rdr["Credit_Amount"].ToString());
					else
						Bal+=double.Parse(rdr["Credit_Amount"].ToString())-double.Parse(rdr["Debit_Amount"].ToString());
					if(Bal.ToString().StartsWith("-"))
						Bal=double.Parse(Bal.ToString().Substring(1));
					Con.Open();
					cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					Con.Close();
					cmd.Dispose();
				}
				rdr.Close();
				for(int i=0;i<4;i++)
				{
					if(DropType[i].SelectedItem.Text.Equals("Select") || Qty[i].Text=="")
						continue;
					else
					{
						Con.Open();
						//cmd = new SqlCommand("update Stock_Master set receipt=receipt-'"+double.Parse(Qty[i].Text)+"',closing_stock=closing_stock-'"+double.Parse(Qty[i].Text)+"' where ProductID=(select Prod_ID from Products where Category='"+DropType[i].SelectedItem.Text+"' and Prod_Name='"+ProdName[i].Value+"' and Pack_Type='"+PackType[i].Value+"') and cast(stock_date as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtVInvoiceDate.Text)+"'",Con);
						cmd = new SqlCommand("update Stock_Master set receipt=receipt-"+(double.Parse(Qty[i].Text)*1000)+",closing_stock=closing_stock-"+(double.Parse(Qty[i].Text)*1000)+" where ProductID=(select Prod_ID from Products where Prod_Name='"+DropType[i].SelectedItem.Text+"') and cast(floor(cast(cast(stock_date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(lblInvoiceDate.Text)+"'",Con);
						cmd.ExecuteNonQuery();
						Con.Close();
						cmd.Dispose();
					}
				}
				SeqStockMaster();
				CreateLogFiles.ErrorLog("Form:FuelInvoice.aspx,Method:btnDelete_Click - InvoiceNo : " + DropInvoiceNo.SelectedItem.Text+" Deleted, user : "+uid);
				Clear();
				//clear1();
				GetNextInvoiceNo();
				//GetProducts();
				//FatchInvoiceNo();
				//FatchInvoiceNo();
				lblInvoiceNo.Visible=true; 
				DropInvoiceNo.Visible=false;
				btnEdit.Visible=true;
				MessageBox.Show("Purchase Transaction Deleted");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelInvoice.aspx,Method:btnDelete_Click - InvoiceNo : " + DropInvoiceNo.SelectedItem.Text+" ,Exception : "+ex.Message+" user : "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to update the product stock after update the purchase invoice in edit time.
		/// </summary>
		public void SeqStockMaster()
		{
			DropDownList[] DropType={DropProd1,DropProd2,DropProd3,DropProd4};
			TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4}; 
			for(int i=0;i<DropType.Length;i++)
			{
				if(DropType[i].SelectedItem.Text.Equals("Select") || Qty[i].Text=="")
					continue;
				else
				{
					InventoryClass obj = new InventoryClass();
					InventoryClass obj1 = new InventoryClass();
					SqlCommand cmd;
					SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
					SqlDataReader rdr1=null,rdr=null;
					string str="select Prod_ID from Products where Prod_Name='"+DropType[i].SelectedItem.Text.ToString()+"'";
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
							cmd = new SqlCommand("update Stock_Master set opening_stock='"+OS.ToString()+"', Closing_Stock='"+CS.ToString()+"' where ProductID='"+rdr1["Productid"].ToString()+ "' and Stock_Date=CONVERT(datetime, '" + rdr1["stock_date"].ToString() + "', 103)",Con); 

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

		/// <summary>
		/// This method is used to update the customer balance after update the invoice no in edit time.
		/// </summary>
		public void customerUpdate()
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
			double Bal=0;
			string BalType="";
			int i=0;
				
			string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master l,supplier s where Supp_Name=Ledger_Name and Supp_ID='"+Vendor_ID+"') order by entry_date";
			rdr=obj.GetRecordSet(str);
			Bal=0;
			BalType="";
			i=0;
			while(rdr.Read())
			{
				if(i==0)
				{
					BalType=rdr["Bal_Type"].ToString();
					i++;
				}
				if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
				{
					if(BalType=="Cr")
					{
						Bal+=double.Parse(rdr["Credit_Amount"].ToString());
						BalType="Cr";
					}
					else
					{
						Bal-=double.Parse(rdr["Credit_Amount"].ToString());
						if(Bal<0)
						{
							Bal=double.Parse(Bal.ToString().Substring(1));
							BalType="Cr";
						}
						else
							BalType="Dr";
					}
				}
				else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
				{
					if(BalType=="Dr")
						Bal+=double.Parse(rdr["Debit_Amount"].ToString());
					else
					{
						Bal-=double.Parse(rdr["Debit_Amount"].ToString());
						if(Bal<0)
						{
							Bal=double.Parse(Bal.ToString().Substring(1));
							BalType="Dr";
						}
						else
							BalType="Cr";
					}
				}
				Con.Open();
				cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				Con.Close();
							
			}
			rdr.Close();
				
			string str1="select * from VendorLedgerTable where VendorID='"+Vendor_ID+"' order by entrydate";
			rdr=obj.GetRecordSet(str1);
			Bal=0;
			i=0;
			BalType="";
			while(rdr.Read())
			{
				if(i==0)
				{
					BalType=rdr["BalanceType"].ToString();
					i++;
				}
				if(double.Parse(rdr["CreditAmount"].ToString())!=0)
				{
					if(BalType=="Cr.")
					{
						Bal+=double.Parse(rdr["CreditAmount"].ToString());
						BalType="Cr.";
					}
					else
					{
						Bal-=double.Parse(rdr["CreditAmount"].ToString());
						if(Bal<0)
						{
							Bal=double.Parse(Bal.ToString().Substring(1));
							BalType="Cr.";
						}
						else
							BalType="Dr.";
					}
				}
				else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
				{
					if(BalType=="Dr.")
						Bal+=double.Parse(rdr["DebitAmount"].ToString());
					else
					{
						Bal-=double.Parse(rdr["DebitAmount"].ToString());
						if(Bal<0)
						{
							Bal=double.Parse(Bal.ToString().Substring(1));
							BalType="Dr.";
						}
						else
							BalType="Cr.";
					}
				}
				Con.Open();
				cmd = new SqlCommand("update VendorLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where VendorID='"+rdr["VendorID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				Con.Close();
			}
			rdr.Close();
		}
	}
}