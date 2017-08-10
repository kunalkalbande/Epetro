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
	/// Summary description for SalesReturn.
	/// </summary>
	public class SalesReturn : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.TextBox txtSlipNo;
		protected System.Web.UI.WebControls.TextBox txtPromoScheme;
		protected System.Web.UI.WebControls.TextBox txtGrandTotal;
		protected System.Web.UI.WebControls.TextBox txtRemark;
		protected System.Web.UI.WebControls.TextBox txtCashDisc;
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.RadioButton No;
		protected System.Web.UI.WebControls.RadioButton Yes;
		protected System.Web.UI.WebControls.TextBox txtVAT;
		protected System.Web.UI.WebControls.TextBox txtDisc;
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
		protected System.Web.UI.HtmlControls.HtmlInputText lblDueDate;
		protected System.Web.UI.HtmlControls.HtmlInputText lblCustName;
		protected System.Web.UI.HtmlControls.HtmlInputText lblVehicleNo;
		protected System.Web.UI.WebControls.DropDownList dropInvoiceNo;
		protected System.Web.UI.WebControls.Label lblInvoiceDate;
		protected System.Web.UI.WebControls.TextBox txtAmount1;
		protected System.Web.UI.WebControls.TextBox txtRate1;
		protected System.Web.UI.WebControls.TextBox txtQty1;
		protected System.Web.UI.WebControls.TextBox txtAmount2;
		protected System.Web.UI.WebControls.TextBox txtRate2;
		protected System.Web.UI.WebControls.TextBox txtQty2;
		protected System.Web.UI.WebControls.TextBox txtAmount3;
		protected System.Web.UI.WebControls.TextBox txtRate3;
		protected System.Web.UI.WebControls.TextBox txtQty3;
		protected System.Web.UI.WebControls.TextBox txtAmount4;
		protected System.Web.UI.WebControls.TextBox txtRate4;
		protected System.Web.UI.WebControls.TextBox txtQty4;
		protected System.Web.UI.WebControls.TextBox txtAmount5;
		protected System.Web.UI.WebControls.TextBox txtRate5;
		protected System.Web.UI.WebControls.TextBox txtQty5;
		protected System.Web.UI.WebControls.TextBox txtAmount6;
		protected System.Web.UI.WebControls.TextBox txtRate6;
		protected System.Web.UI.WebControls.TextBox txtQty6;
		protected System.Web.UI.WebControls.TextBox txtAmount7;
		protected System.Web.UI.WebControls.TextBox txtRate7;
		protected System.Web.UI.WebControls.TextBox txtQty7;
		protected System.Web.UI.WebControls.TextBox txtAmount8;
		protected System.Web.UI.WebControls.TextBox txtRate8;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.TextBox txtCashDiscType;
		protected System.Web.UI.WebControls.TextBox txtDiscType;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName4;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtProdName8;
		protected System.Web.UI.HtmlControls.HtmlInputText lblSalesType;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack4;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack6;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack7;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPack8;
		protected System.Web.UI.WebControls.TextBox txtQty8;
		DBUtil dbobj = new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check1;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check2;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check3;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check4;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check5;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check6;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check7;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox Check8;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckAll;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpNetAmount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpGrandTotal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpCashDisc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpVatAmount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpDisc;
		protected System.Web.UI.WebControls.Button btnPrint;	
		string uid= "";

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
                TextBox1.Attributes.Add("readonly", "readonly");
                TxtCrLimit1.Attributes.Add("readonly", "readonly");
                lblSalesType.Attributes.Add("readonly", "readonly");
                lblCustName.Attributes.Add("readonly", "readonly");
                lblPlace.Attributes.Add("readonly", "readonly");
                lblDueDate.Attributes.Add("readonly", "readonly");
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
					checkPrevileges(); 
					getInvoiceNo();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:page_load  EXCEPTION: "+ ex.Message+"  User: "+uid);	
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
		}

		/// <summary>
		/// Its Cheks the users privilegs.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="4";
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
		/// Its fetches all the invoie nos from sales_master except those r  present in Sales_return_master and fills the Sales Invoice No. drop down..
		/// </summary>
		public void getInvoiceNo()
		{
			try
			{
				string[] In_no=new string[99999];//**
				int i=0,j=0;//**
				SqlDataReader SqlDtr = null;
				dropInvoiceNo.Items.Clear();
				dropInvoiceNo.Items.Add("Select");  
				dbobj.SelectQuery("Select sm.Invoice_No from Sales_Master sm where sm.Invoice_No not in (Select Invoice_No from Sales_Return_Master)",ref SqlDtr);
				while(SqlDtr.Read())
				{
					//dropInvoiceNo.Items.Add(SqlDtr["Invoice_No"].ToString());   
					In_no[i]=SqlDtr.GetValue(0).ToString();
					i++;
				}
				SqlDtr.Close ();		
				for(j=0;j<i;j++)
				{
					if(In_no[j].Length != 6)
						dropInvoiceNo.Items.Add(In_no[j]);
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:getInvoiceNo()  EXCEPTION: "+ ex.Message+"  User: "+uid);	
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
		/// This event occurres after selecting the invoice no. its fetches the invoice details and display on a screen .
		/// </summary>
		private void dropInvoiceNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TextSelect.Text=dropInvoiceNo.SelectedItem.Value.ToString();
			try
			{
				if(TextSelect.Text=="Select")
				{
					MessageBox.Show("Please Select Invoice No");
				}
				else
				{
					HtmlInputText[] Name={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
					HtmlInputText[] Type={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
					TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
					TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
					TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8}; 			
					TextBox[]  tempQty = {txtTempQty1, txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8}; 
					HtmlInputHidden[] tmpQty = {tmpQty1,tmpQty2,tmpQty3,tmpQty4,tmpQty5,tmpQty6,tmpQty7,tmpQty8};
					HtmlInputCheckBox[] Check = {Check1,Check2,Check3,Check4,Check5,Check6,Check7,Check8};

					InventoryClass  obj=new InventoryClass ();
					SqlDataReader SqlDtr;
					string sql = "";
					int i=0;
					#region Get Data from Sales Master Table regarding Invoice No.
					sql="select * from Sales_Master where Invoice_No='"+ dropInvoiceNo.SelectedItem.Value +"'" ;
					SqlDtr=obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						string strDate = SqlDtr.GetValue(1).ToString().Trim();
						int pos = strDate.IndexOf(" ");
				
						if(pos != -1)
						{
							strDate = strDate.Substring(0,pos);
						}
						else
						{
							strDate = "";					
						}

						lblInvoiceDate.Text =GenUtil.str2DDMMYYYY(strDate);  
						lblSalesType.Value = SqlDtr.GetValue(2).ToString() ;
						lblVehicleNo.Value = SqlDtr.GetValue(5).ToString();
						txtGrandTotal.Text=SqlDtr.GetValue(6).ToString();
						txtGrandTotal.Text = GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()); 
						tmpGrandTotal.Value = txtGrandTotal.Text; 
						txtDisc.Text=SqlDtr.GetValue(7).ToString(); 
						txtDisc.Text = GenUtil.strNumericFormat(txtDisc.Text.ToString()); 
						tmpDisc.Value = txtDisc.Text;
						txtDiscType.Text = SqlDtr.GetValue(8).ToString(); 
						if(txtDiscType.Text =="Per")
							txtDiscType.Text = "%"; 
 
						txtNetAmount.Text =SqlDtr.GetValue(9).ToString(); 
						txtNetAmount.Text = GenUtil.strNumericFormat(txtNetAmount.Text.ToString());
						tmpNetAmount.Value = txtNetAmount.Text;
						txtPromoScheme.Text= SqlDtr.GetValue(10).ToString(); 
						txtRemark.Text=SqlDtr.GetValue(11).ToString();  
						txtSlipNo.Text= SqlDtr.GetValue(14).ToString(); 
						if(txtSlipNo.Text == "0")
							txtSlipNo.Text = ""; 
						txtCashDisc.Text=SqlDtr.GetValue(15).ToString(); 
						txtCashDisc.Text = GenUtil.strNumericFormat(txtCashDisc.Text.ToString()); 
						tmpCashDisc.Value = txtCashDisc.Text;
						txtCashDiscType.Text = SqlDtr.GetValue(16).ToString(); 
						if(txtCashDiscType.Text == "Per")
							txtCashDiscType.Text = "%";
						txtVAT.Text =  SqlDtr.GetValue(17).ToString();
						tmpVatAmount.Value = txtVAT.Text;
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
					#endregion
		
					#region Get Customer name and place regarding Customer ID
					sql="select Cust_Name, City,CR_Days,Op_Balance,CR_Limit from Customer as c, sales_master as s where c.Cust_ID= s.Cust_ID and s.Invoice_No='"+dropInvoiceNo.SelectedValue +"'";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
				
						lblCustName.Value = SqlDtr.GetValue(0).ToString();
						lblPlace.Value=SqlDtr.GetValue(1).ToString();
						DateTime duedate=DateTime.Now.AddDays(System.Convert.ToDouble(SqlDtr.GetValue(2).ToString()));
						string duedatestr=(duedate.ToShortDateString());
						lblDueDate.Value =GenUtil.str2DDMMYYYY(duedatestr);
						TxtCrLimit.Value = SqlDtr.GetValue(4).ToString();
					}
					SqlDtr.Close();
				
					#endregion
					#region Get Data from Sales Details Table regarding Invoice No.
					sql="select	p.Category,p.Prod_Name,p.Pack_Type,	sd.qty,sd.rate,sd.amount,p.Prod_ID,p.unit"+
						" from Products p, sales_Details sd"+
						" where p.Prod_ID=sd.prod_id and sd.invoice_no='"+ dropInvoiceNo.SelectedItem.Value +"'" ;
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						
						//Qty[i].Enabled = true;
						
						Name[i].Value=SqlDtr.GetValue(1).ToString();   
						Type[i].Value=SqlDtr.GetValue(2).ToString();   
						Qty[i].Text=SqlDtr.GetValue(3).ToString();
						tempQty[i].Text   = Qty[i].Text ;
						tmpQty[i].Value =  SqlDtr.GetValue(3).ToString();  
						Rate[i].Text=SqlDtr.GetValue(4).ToString();
						Amount[i].Text=SqlDtr.GetValue(5).ToString();
						Check[i].Checked = false;

						
						i++;
					}
					while(i<8)
					{
					
						Name[i].Value = "";  
						Type[i].Value = "";  
						Qty[i].Text="";
						Qty[i].Enabled = false; 
						tempQty[i].Text ="";
						tmpQty[i].Value = "";
						Rate[i].Text="";
						Amount[i].Text="";
						Check[i].Checked = false;
						
					
						i++;
					}
					SqlDtr.Close();
					CheckAll.Checked = false;
					#endregion
		
				}
				CreateLogFiles.ErrorLog("Form:Salesreturn.aspx,Method:dropInvoiceNo_SelectedIndexChanged " +" Sales invoice is viewed for invoice no: "+dropInvoiceNo.SelectedItem.Value.ToString()+"  userid:"+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:dropInvoiceNo_SelectedIndexChanged   EXCEPTION  "+ex.Message+"  userid: "+uid);
			}
	
		}
	
		/// <summary>
		/// This method is used to save the record in database with the help of stored procedure.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(dropInvoiceNo.SelectedIndex == 0)
				{
					MessageBox.Show("Please Select Invoice No.");
					return;  
				}
				int c = 0;
				// Its checks if any check box is selected or not , if not display the popup message.
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

	
				InventoryClass  obj=new InventoryClass ();
	
				obj.Invoice_No = dropInvoiceNo.SelectedItem.Text.Trim();    
				int count = 0;
				// This part of code is use to solve the double click problem, Its checks the sales return no. and display the popup, that it is saved.
				dbobj.ExecuteScalar("Select count(Invoice_No) from Sales_Return_Master where Invoice_No = "+dropInvoiceNo.SelectedItem.Text.Trim(),ref count);
				if(count > 0)
				{
					MessageBox.Show("Sales Return Saved");						
					clear(); 
					getInvoiceNo();
					return ;

				}
				obj.Customer_Name =lblCustName.Value.ToString() ;
				obj.Place =lblPlace.Value.ToString();
				
				obj.Grand_Total =txtGrandTotal.Text ;
				if(txtDisc.Text.Trim() =="")
					obj.Discount ="0.0";
				else
					obj.Discount =txtDisc.Text;
				obj.Discount_Type=txtDiscType.Text;  
				obj.Net_Amount =txtNetAmount.Text ;
				obj.Entry_By =lblEntryBy.Text ;
				obj.Entry_Time =DateTime.Parse(lblEntryTime .Text);
				if(txtCashDisc.Text.Trim() =="")
					obj.Cash_Discount  ="0.0";
				else
					obj.Cash_Discount  = txtCashDisc.Text.Trim() ;
				obj.Cash_Disc_Type = txtCashDiscType.Text; 
				obj.VAT_Amount = txtVAT.Text.Trim();   
			

				obj.Cr_Plus="0";
				double amount = System.Convert.ToDouble(txtNetAmount.Text)*-1;
				obj.Dr_Plus= amount.ToString(); 	
				//obj.Pre_Amount = tmpNetAmount.Value;//comment by Mahesh on 22.07.008
				obj.Pre_Amount = txtNetAmount.Text;
				// Calls the InsertSalesReturnMaster fucntion which calls the ProInsertSalesReturnMaster pocedure to enter the Sales Return master details.
				obj.InsertSalesReturnMaster();
				obj.UpdateCustomerBalance();
			
				// Calls the Save function only for return products.
				HtmlInputText[] ProdName={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
				HtmlInputText[] PackType={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
				TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
				TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
				TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8};			
				TextBox[]  Quantity = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8 };
				for(int j=0;j<ProdName.Length ;j++)
				{
					if(Check[j].Checked == false)
						continue;
					Save(ProdName[j].Value,PackType[j].Value,Qty[j].Text.ToString(),Rate[j].Text.ToString (),Amount[j].Text.ToString ());
				}
				
				CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:btnSave_Click()"+" Sales Return for  Invoice No."+obj.Invoice_No+" ,"+"of Customer Name  "+obj.Customer_Name+",  "+" and NetAmount  "+obj.Net_Amount+"  is Saved "+" userid "+"   "+uid);
				
				MessageBox.Show("Sales Return Saved");
				reportmaking();
				//print();
				clear(); 
				getInvoiceNo();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:btnSave_Click  EXCEPTION: "+ ex.Message+"  User: "+uid);	
			}
		}

		/// <summary>
		/// its Calls the InsertSalesReturnDetails fucntion which calls the ProInsertSalesReturn procedure to enter the return details of a product.
		/// </summary>
		public void Save(string ProdName,string PackType, string Qty, string Rate,string Amount)
		{
			InventoryClass obj=new InventoryClass();
			obj.Product_Name=ProdName ;
			obj.Package_Type=PackType ;
			obj.Qty=Qty;
			obj.Rate=Rate;
			obj.Amount=Amount;
			obj.Invoice_No=dropInvoiceNo.SelectedItem.Value;
			obj.InsertSalesReturnDetail(); 
		}
			
		/// <summary>
		/// Its clears the web form.
		/// </summary>
		public void clear()
		{
			dropInvoiceNo.SelectedIndex = 0;
			lblInvoiceDate.Text  = "";
			lblSalesType.Value = "";
			txtSlipNo.Text = "";
			lblCustName.Value  = "";
			lblPlace.Value  = "";
			lblDueDate.Value = "";
			lblVehicleNo.Value = "";
			txtPromoScheme.Text = "";
			txtRemark.Text = "";
			txtGrandTotal.Text = "";
			txtCashDisc.Text = "";
			txtCashDiscType.Text = "";
			txtVAT.Text = "";
			Yes.Checked = true;
			No.Checked = false;
			txtDisc.Text = "";
			txtDiscType.Text = "";
			txtNetAmount.Text = "";
			tmpNetAmount.Value ="";
			tmpGrandTotal.Value = "";
			tmpCashDisc.Value = "";
			tmpDisc.Value = "";
			tmpVatAmount.Value = "";

			HtmlInputText[] ProdName={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
			HtmlInputText[] PackType={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
			TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
			TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
			TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8};			
			TextBox[]  Quantity = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8 };
			HtmlInputHidden[] tmpQty = {tmpQty1,tmpQty2,tmpQty3,tmpQty4,tmpQty5,tmpQty6,tmpQty7,tmpQty8};
			HtmlInputCheckBox[] Check = {Check1,Check2,Check3,Check4,Check5,Check6,Check7,Check8};

			for(int j=0;j<ProdName.Length ;j++)
			{
				ProdName[j].Value = "";
				PackType[j].Value = "";
				Qty[j].Text = "";
				Rate[j].Text = "";
				Amount[j].Text = "";
				Quantity[j].Text = "";
				tmpQty[j].Value = ""; 
				Check[j].Checked = false;
			}
			CheckAll.Checked = false;
		}

		/// <summary>
		/// Its fetch the screen values and writes the details in SalesReturn.txt file to print but the details of only the Return products not others.
		/// </summary>
		public void reportmaking()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SalesReturnReport.txt";
				string info = "";
				string strInvNo="";
				string strDiscType="";
				double disc_amt=0;
				string msg ="";
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
						qty[j] = Qty[i].Text;
						rate[j] = Rate[i].Text;
						amt[j] = Amount[i].Text;
						j++;
					}
				}

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
				string des="-----------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("==============",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("SALES RETURN",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("==============",des.Length));
				strInvNo= dropInvoiceNo.SelectedItem.Value;   
 
				sw.WriteLine(" Invoice No : " + strInvNo+ "                              Date : " + lblInvoiceDate.Text.ToString());
				sw.WriteLine(" Customer Name     : " + lblCustName.Value);
				sw.WriteLine(" Place             :  "+lblPlace.Value);
				sw.WriteLine(" Due Date          :  "+lblDueDate.Value);
				sw.WriteLine(" Vehicle Number    :  "+lblVehicleNo.Value);
				sw.WriteLine("+------------------------------+-----------+----------+----------+");
				sw.WriteLine("|Product                       | Quantity  |   Rate   |  Amount  |");
				sw.WriteLine("+------------------------------+-----------+----------+----------+");
				info = " {0,-30:S} {1,10:F}  {2,10:F} {3,10:F}";
				// Writes the details of return products i.e. up to 8 products if less then display the sapces.
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
				sw.WriteLine("                                               Signature");

				sw.Close();	
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:reportmaking().  EXCEPTION: "+ ex.Message+"  User: "+uid);	
			}
		}
		
		/// <summary>
		/// This method is used to sends the SalesReturn.txt file name to print server.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\SalesReturnReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:print  ArgumentNullException : "+ane.Message+" Userid: "+uid);
				} 
				catch (SocketException se) 
				{
					CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:print  SocketException : "+se.Message+" Userid: "+uid);
				} 
				catch (Exception es) 
				{
					CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:print  Unexpected exception : "+ es.Message+" Userid: "+uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:SalesReturn.aspx,Method:print.   EXCEPTION: "+ex.Message+" User: "+uid);
			}
		}

		/// <summary>
		/// This method is used to sends the SalesReturn.txt file name to print server.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			//reportmaking();
			print();
		}
	}
}