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
using DBOperations;
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
namespace EPetro.Module.Accounts
{
    /// <summary>
    /// Summary description for cashbill.
    /// </summary>
    public class cashbill : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.TextBox TextSelect;
        protected System.Web.UI.WebControls.TextBox TextBox2;
        protected System.Web.UI.WebControls.TextBox TxtCrLimit1;
        protected System.Web.UI.WebControls.TextBox txtTempQty1;
        protected System.Web.UI.WebControls.TextBox txtTempQty2;
        protected System.Web.UI.WebControls.Label lblMessage;
        protected System.Web.UI.WebControls.DropDownList dropInvoiceNo;
        protected System.Web.UI.WebControls.Label lblInvoiceNo;
        protected System.Web.UI.WebControls.Button btnEdit;
        protected System.Web.UI.WebControls.TextBox lblInvoiceDate;
        protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty4;
        protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty5;
        protected System.Web.UI.HtmlControls.HtmlInputText TxtVen;
        protected System.Web.UI.HtmlControls.HtmlInputText TextBox1;
        protected System.Web.UI.HtmlControls.HtmlInputText TxtEnd;
        protected System.Web.UI.HtmlControls.HtmlInputText Txtstart;
        protected System.Web.UI.HtmlControls.HtmlInputText TxtCrLimit;
        protected System.Web.UI.HtmlControls.HtmlInputHidden temptext;
        protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty1;
        protected System.Web.UI.HtmlControls.HtmlInputHidden tempInfo;
        protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty2;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtVatRate;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtVatValue;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtSlipTemp;
        protected System.Web.UI.HtmlControls.HtmlInputHidden SlipNo;
        protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden2;
        protected System.Web.UI.WebControls.TextBox txtVehicleNo;
        protected System.Web.UI.WebControls.CompareValidator CompareValidator4;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
        protected System.Web.UI.WebControls.DropDownList DropType1;
        protected System.Web.UI.WebControls.DropDownList DropProd1;
        protected System.Web.UI.WebControls.DropDownList DropPack1;
        protected System.Web.UI.WebControls.TextBox txtQty1;
        protected System.Web.UI.WebControls.TextBox txtAvStock1;
        protected System.Web.UI.WebControls.TextBox txtRate1;
        protected System.Web.UI.WebControls.TextBox txtAmount1;
        protected System.Web.UI.WebControls.DropDownList DropType2;
        protected System.Web.UI.WebControls.DropDownList DropProd2;
        protected System.Web.UI.WebControls.DropDownList DropPack2;
        protected System.Web.UI.WebControls.TextBox txtQty2;
        protected System.Web.UI.WebControls.TextBox txtAvStock2;
        protected System.Web.UI.WebControls.TextBox txtRate2;
        protected System.Web.UI.WebControls.TextBox txtAmount2;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName1;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack1;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName2;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack2;
        protected System.Web.UI.WebControls.TextBox txtRemark;
        protected System.Web.UI.WebControls.TextBox txtcustname;
        protected System.Web.UI.HtmlControls.HtmlInputHidden lblVehicleNo;
        string uid = "";
        public int flag = 0;

        public float overallPrintWidth = 0;
        public float overallPrintHeight = 0;
        public float effectivePrintWidth = 0;
        public float effectivePrintHeight = 0;
        public float header = 0;
        public float body = 0;
        public float footer = 0;
        public float rate = 0;
        public float quantity = 0;
        public float amount = 0;
        public float total = 0;
        public float cashPos = 0;
        public float cashPosHeight = 0;
        public bool cashMemo = false;
        public bool date = false;
        public bool vehicle = false;
        public bool address = false;
        public string[] arr = new string[50];
        public string[] arr1 = new string[50];
        public int k = 0;
        string DefaultTank = "";
        public int count = 0;
        static string[] ProductType = new string[2];
        static string[] ProductName = new string[2];
        static string[] ProductPack = new string[2];
        static string[] ProductQty = new string[2];
        public string[] ProdName = new string[30], Quantity11 = new string[30], Cash = new string[30], Sales = new string[30];
        public static int PrintDetail = 0;
        protected System.Web.UI.WebControls.TextBox txtGrandTotal;
        protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.Button btnSave;
        protected System.Web.UI.WebControls.RadioButton RadioButton1;
        protected System.Web.UI.WebControls.RadioButton Radiobutton2;
        protected System.Web.UI.WebControls.RadioButton rbi;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txttankdd11;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txttottank;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txttankno1;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txttankno2;
        protected System.Web.UI.WebControls.DropDownList DropProd11;
        protected System.Web.UI.WebControls.DropDownList DropProd12;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
        protected System.Web.UI.WebControls.Button btnPrePrint;
        protected System.Web.UI.WebControls.Label tempInvoice;
        DBUtil dbobj = new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"], true);

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
                uid = (Session["User_Name"].ToString());
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:pageload" + ex.Message + "  EXCEPTION " + "   " + uid);
                Response.Redirect("../../Sysitem/ErrorPage.aspx", false);
                return;
            }
            if (tempInfo.Value == "Yes")
            {
                DeleteTheRec();
            }
            try
            {




                //				settank();
                //				GetProducts();
                //				FuelWiseTotalLtr();
                if (!Page.IsPostBack)
                {
                    TextBox1.Attributes.Add("readonly", "readonly");
                    TxtCrLimit.Attributes.Add("readonly", "readonly");
                    lblInvoiceDate.Attributes.Add("readonly", "readonly");
                    txtAvStock1.Attributes.Add("readonly", "readonly");
                    txtRate1.Attributes.Add("readonly", "readonly");
                    txtAvStock2.Attributes.Add("readonly", "readonly");
                    txtRate2.Attributes.Add("readonly", "readonly");
                    txtGrandTotal.Attributes.Add("readonly", "readonly");
                    count = 0;
                    dropInvoiceNo.Visible = false;
                    checkPrevileges();
                    //GetProducts();
                    checkPrePrint();
                    lblInvoiceDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    DropDownList[] ProductType = { DropType1, DropType2 };
                    DropDownList[] ProductName = { DropProd1 };
                    InventoryClass obj = new InventoryClass();
                    SqlDataReader SqlDtr;
                    string sql;
                    GetNextInvoiceNo();
                    #region Fetch the Product Types and fill in the ComboBoxes
                    sql = "select distinct Category from Products";
                    for (int j = 0; j < ProductType.Length; j++)
                    {
                        SqlDtr = obj.GetRecordSet(sql);
                        while (SqlDtr.Read())
                        {
                            ProductType[j].Items.Add(SqlDtr.GetValue(0).ToString());
                        }
                        SqlDtr.Close();
                    }
                    #endregion
                    settank();
                    GetProducts();
                    FuelWiseTotalLtr();
                    CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:PageLoad.  user " + uid);
                }                
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:PageLoad.  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }

        /// <summary>
        /// This method checks the Cash Billing for all the products is available or not?
        /// </summary>
        public void GetProducts()
        {
            try
            {
                InventoryClass obj = new InventoryClass();
                InventoryClass obj1 = new InventoryClass();
                SqlDataReader SqlDtr;
                string sql;
                SqlDataReader rdr = null;
                int count = 0;
                int count1 = 0;
                dbobj.ExecuteScalar("Select Count(Prod_id) from  products", ref count);
                dbobj.ExecuteScalar("select count(distinct p.Prod_ID) from products p, Price_Updation pu where p.Prod_id = pu.Prod_id", ref count1);
                /*sql = "select distinct p.Prod_ID,Category,Prod_Name,Pack_Type,Unit from products p, Price_Updation pu where p.Prod_id = pu.Prod_id order by Category,Prod_Name";
				SqlDtr = obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{			
					count1 = count1+1;
				}					
				SqlDtr.Close();
				*/
                if (count != count1)
                {
                    lblMessage.Text = "Price updation not available for some products";
                }

                #region Fetch the Product Types and fill in the ComboBoxes
                string str = "";
                sql = "select distinct p.Prod_ID,Category,Prod_Name,Pack_Type,Unit from products p, Price_Updation pu where p.Prod_id = pu.Prod_id order by Category,Prod_Name";
                SqlDtr = obj.GetRecordSet(sql);
                while (SqlDtr.Read())
                {
                    #region Fetch Sales Rate
                    str = str + SqlDtr["Category"] + ":" + SqlDtr["Prod_Name"] + ":" + SqlDtr["Pack_Type"];
                    sql = "select top 1 Sal_Rate from Price_Updation where Prod_ID=" + SqlDtr["Prod_ID"] + " order by eff_date desc";
                    //dbobj.SelectQuery(sql,ref rdr); 
                    rdr = obj1.GetRecordSet(sql);
                    if (rdr.Read())
                        str = str + ":" + rdr["Sal_Rate"];
                    else
                        str = str + ":0";
                    rdr.Close();
                    #endregion
                    #region Fetch Closing Stock
                    sql = "select top 1 Closing_Stock from Stock_Master where productid=" + SqlDtr["Prod_ID"] + " order by stock_date desc";
                    //dbobj.SelectQuery(sql,ref rdr);
                    rdr = obj1.GetRecordSet(sql);
                    if (rdr.Read())
                        str = str + ":" + Math.Round(double.Parse(rdr["Closing_Stock"].ToString()), 2) + ":" + SqlDtr["Unit"];
                    else
                        str = str + ":0" + ":" + SqlDtr["Unit"];
                    rdr.Close();
                    #endregion
                    #region Fetch Tank's Sort Name
                    sql = "select Prod_AbbName from Tank where Prod_Name=(select Prod_Name from products where Prod_ID=" + SqlDtr["Prod_ID"] + " and category='Fuel')";
                    //dbobj.SelectQuery(sql,ref rdr); 
                    rdr = obj1.GetRecordSet(sql);
                    if (rdr.Read())
                        str = str + ":" + rdr["Prod_AbbName"] + ",";
                    else
                        str = str + ":" + ",";
                    rdr.Close();
                    #endregion
                }
                SqlDtr.Close();
                temptext.Value = str;
                //MessageBox.Show(str);
                #endregion
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:GetProducts().  EXCEPTION: " + ex.Message + "  user " + uid);
            }

        }

        /// <summary>
		/// This method checks the Cash Billing for all the products is available or not?
		/// </summary>
		public void GetProductsType()
        {
            try
            {
                InventoryClass obj = new InventoryClass();
                InventoryClass obj1 = new InventoryClass();
                SqlDataReader SqlDtr;
                string sql;
                SqlDataReader rdr = null;
                int count = 0;
                int count1 = 0;
                dbobj.ExecuteScalar("Select Count(Prod_id) from  products", ref count);
                dbobj.ExecuteScalar("select count(distinct p.Prod_ID) from products p, Price_Updation pu where p.Prod_id = pu.Prod_id", ref count1);
                /*sql = "select distinct p.Prod_ID,Category,Prod_Name,Pack_Type,Unit from products p, Price_Updation pu where p.Prod_id = pu.Prod_id order by Category,Prod_Name";
				SqlDtr = obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{			
					count1 = count1+1;
				}					
				SqlDtr.Close();
				*/
                if (count != count1)
                {
                    lblMessage.Text = "Price updation not available for some products";
                }

                #region Fetch the Product Types and fill in the ComboBoxes
                string str = "";
                sql = "select distinct p.Prod_ID,Category,Prod_Name,Pack_Type,Unit from products p, Price_Updation pu where p.Prod_id = pu.Prod_id order by Category,Prod_Name";
                SqlDtr = obj.GetRecordSet(sql);
                while (SqlDtr.Read())
                {
                    #region Fetch Sales Rate
                    str = str + SqlDtr["Category"] + ":" + SqlDtr["Prod_Name"] + ",";


                    #endregion
                }
                SqlDtr.Close();
                temptext.Value = str;
                //MessageBox.Show(str);
                #endregion
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:GetProducts().  EXCEPTION: " + ex.Message + "  user " + uid);
            }

        }

        /// <summary>
        /// This method is used to return next invoice no from the table. Initial starts with 500001.
        /// </summary>
        public void GetNextInvoiceNo()
        {
            try
            {
                InventoryClass obj = new InventoryClass();
                SqlDataReader SqlDtr;
                string sql;

                #region Fetch the Next Invoice Number
                sql = "select max(Invoice_No)+1 from cashbilling";
                SqlDtr = obj.GetRecordSet(sql);
                while (SqlDtr.Read())
                {
                    lblInvoiceNo.Text = SqlDtr.GetValue(0).ToString();
                    if (lblInvoiceNo.Text == "")
                        lblInvoiceNo.Text = "500001";
                }
                SqlDtr.Close();
                #endregion
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:GetNextInvoiceNo().  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }

        /// <summary>
        /// This method is used to check the previleges to access or not.
        /// </summary>
        public void checkPrevileges()
        {
            #region Check Privileges
            int i;
            string View_flag = "0", Add_Flag = "0", Edit_Flag = "0", Del_Flag = "0";
            string Module = "4";
            string SubModule = "9";
            string[,] Priv = (string[,])Session["Privileges"];
            for (i = 0; i < Priv.GetLength(0); i++)
            {
                if (Priv[i, 0] == Module && Priv[i, 1] == SubModule)
                {
                    View_flag = Priv[i, 2];
                    Add_Flag = Priv[i, 3];
                    Edit_Flag = Priv[i, 4];
                    Del_Flag = Priv[i, 5];
                    break;
                }
            }
            if (Add_Flag == "0" && Edit_Flag == "0" && View_flag == "0")
                Response.Redirect("../../Sysitem/AccessDeny.aspx", false);
            if (Edit_Flag == "0")
                btnEdit.Enabled = false;
            if (Add_Flag == "0")
            {
                btnSave.Enabled = false;
                Button1.Enabled = false;
            }
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
            this.dropInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.dropInvoiceNo_SelectedIndexChanged);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnPrePrint.Click += new System.EventHandler(this.btnPrePrint_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        /// <summary>
        /// This method is used to save the record with the help of Insert() function.
        /// </summary>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                Insert();
                PrintDetail = 1;
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:btnSave_Click().  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }

        /// <summary>
        /// Inserts data in controls containing in Product Details
        /// </summary>
        private void InsertDataInControls()
        {            
            DropProd1.Items.Clear();
            DropProd2.Items.Clear();
            
            GetProducts();

            string[] strArrayOne = new string[] { "" };
            strArrayOne = temptext.Value.Split(',');

            DropProd1.Items.Add("Select");
            DropProd2.Items.Add("Select");

            for (int i = 0; i <= strArrayOne.Length - 1; i++)
            {
                string[] strArraytwo = new string[] { "" };
                strArraytwo = strArrayOne[i].Split(':');

                if (DropType1.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {
                        DropProd1.Items.Add(strArraytwo[1] + ':' + strArraytwo[6]);                        
  
                        txtAvStock1.Enabled = false;                        
                        txtRate1.Text = string.Empty;
                    }
                    else
                    {
                        DropProd1.Items.Add(strArraytwo[1]);  

                        txtAvStock1.Enabled = false;                        
                        txtRate1.Text = string.Empty;
                    }
                }
                if (DropType2.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {
                        DropProd2.Items.Add(strArraytwo[1] + ':' + strArraytwo[6]);
                        
                        txtAvStock2.Enabled = false;
                        txtRate2.Text = string.Empty;
                    }
                    else
                    {
                        DropProd2.Items.Add(strArraytwo[1]);

                        txtAvStock2.Enabled = false;                       
                        txtRate2.Text = string.Empty;                        
                    }
                }
            }
        }

        /// <summary>
        /// Insert all details in the database with the help of stored procedures and 
        /// generate the print file also.
        /// </summary>
        public void Insert()
        {                        
            try
            {                                
                StringBuilder errorMessage = new StringBuilder();
                if (DropType1.SelectedIndex == 0)
                {
                    errorMessage.Append("- Please select Category");
                    errorMessage.Append("\n");
                }
                if (dropInvoiceNo.Visible == true && DropProd1.SelectedIndex == 0)
                {
                    errorMessage.Append("- Please select atleast one Product Name");
                    errorMessage.Append("\n");
                }
                if (txtQty1.Text == string.Empty)
                {
                    errorMessage.Append("- Please Fill Quantity");
                    errorMessage.Append("\n");
                }
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());
                    InsertDataInControls();
                    return;
                }

                if (txtRate1.Text == "" && txtAmount1.Text == "")
                {
                    MessageBox.Show("Please Select Product...");
                    //clear1();
                    InsertDataInControls();
                    return;
                }
                if (txtRate2.Text != "" && txtAmount2.Text == "")
                {
                    MessageBox.Show("Please Select Product or Qty...");
                    //clear1();
                    InsertDataInControls();
                    return;
                }
                InventoryClass obj = new InventoryClass();
                SqlDataReader SqlDtr;
                string sql;
                string count = "";
                sql = "select count(*) from Ledger_Master where Sub_grp_ID=118";
                SqlDtr = obj.GetRecordSet(sql);
                if (SqlDtr.HasRows)
                {
                    while (SqlDtr.Read())
                        count = SqlDtr.GetValue(0).ToString();
                }
                if (count == "0" || count == "")
                {
                    MessageBox.Show("Please create a Cash Account");
                    clear1();
                    return;
                }
                SqlDtr.Close();
                checkPrePrint();
                reportmaking4();
                prePrint();
                prePrintCashMemo();
                //InventoryClass  obj=new InventoryClass ();
                if (lblInvoiceNo.Visible == true)
                    obj.Invoice_date1 = GenUtil.str2DDMMYYYY(lblInvoiceDate.Text);
                else
                    obj.Invoice_date1 = GenUtil.str2DDMMYYYY(lblInvoiceDate.Text);
                obj.Cust_name1 = txtcustname.Text;
                obj.Vehicle_no1 = txtVehicleNo.Text;
                obj.Remark1 = txtRemark.Text;
                obj.Netamt1 = txtGrandTotal.Text;
                if (DropType1.SelectedItem.Value == "Fuel")
                    obj.Tankname = txtProdName1.Value;
                else
                    obj.Tankname = "";
                if (DropType2.SelectedItem.Value == "Fuel")
                    obj.Tankname1 = txtProdName2.Value;
                else
                    obj.Tankname1 = "";

                if (lblInvoiceNo.Visible == true)
                {
                    obj.Invoice_no1 = lblInvoiceNo.Text;
                    obj.InsertCashBilling();
                    CustomerUpdate();
                    MessageBox.Show("Cash Billing Saved");
                    CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method: btnsave,Action: CashBill is Save for Invoice_NO : " + lblInvoiceNo.Text + ". user " + uid);
                }
                else
                {
                    obj.Invoice_no1 = dropInvoiceNo.SelectedItem.Text;
                    UpdateProductQty();
                    obj.UpdateCashBilling();
                    CustomerUpdate();
                    MessageBox.Show("Cash Billing Update");
                    CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method: btnsave,Action: CashBill is Update for Invoince_NO : " + dropInvoiceNo.SelectedItem.Text + ". user " + uid);
                }

                string temp;
                DropDownList[] ProdType = { DropType1, DropProd2 };
                HtmlInputHidden[] ProdName = { txtProdName1, txtProdName2 };
                HtmlInputHidden[] ProdName1 = { txttankno1, txttankno2 };
                HtmlInputHidden[] PackType = { txtPack1, txtPack2 };
                TextBox[] Qty = { txtQty1, txtQty2 };
                TextBox[] Rate = { txtRate1, txtRate2 };
                TextBox[] Amount = { txtAmount1, txtAmount2 };
                TextBox[] Quantity = { txtTempQty1, txtTempQty2 };
                string prod1 = txtProdName1.Value;
                string[] name1 = new string[2];
                string prod2 = txtProdName2.Value;
                string[] name2 = new string[2];
                if (DropType1.SelectedItem.Text.Equals("Fuel"))
                {
                    name1 = prod1.Split(new char[] { ':' }, prod1.Length);
                    txttankno1.Value = name1[0];
                }
                if (DropType2.SelectedItem.Text.Equals("Fuel"))
                {
                    name2 = prod2.Split(new char[] { ':' }, prod2.Length);
                    txttankno2.Value = name2[0];
                }

                for (int j = 0; j < ProdName.Length; j++)
                {
                    if (Rate[j].Text == "" || Rate[j].Text == "0")
                        continue;

                    if (lblInvoiceNo.Visible == true || Quantity[j].Text == "")
                    {
                        temp = Qty[j].Text.ToString();
                    }
                    else
                    {
                        //temp = System.Convert.ToString(System.Convert.ToDouble(Qty[j].Text)-System.Convert.ToDouble(Quantity[j].Text)); 
                        temp = Qty[j].Text;
                    }

                    Save(ProdName[j].Value, ProdName1[j].Value, PackType[j].Value, Qty[j].Text.ToString(), Rate[j].Text.ToString(), Amount[j].Text.ToString(), temp, GenUtil.str2DDMMYYYY(lblInvoiceDate.Text.ToString()));
                    if (lblInvoiceNo.Visible == false)
                        StockMaster(ProdType[j].SelectedItem.Text, ProdName[j].Value, PackType[j].Value);
                }

                //CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:btnsave"+" Cash Bill for  Invoice No."+obj.Invoice_No+" ,"+"for Customer Name  "+obj.Cust_name1+", and NetAmount  "+obj.Netamt1+"  is Saved "+" userid "+"   "+uid);

                if (lblInvoiceNo.Visible == true)
                {

                    //MessageBox.Show("Cash Bill Saved");
                }
                else
                {
                    dropInvoiceNo.Visible = false;
                    lblInvoiceNo.Visible = true;
                    btnEdit.Visible = true;
                    SeqStockMaster();
                    //MessageBox.Show("Cash Bill Updated");
                }
                clear1();
                GetNextInvoiceNo();
                settank();
                GetProducts();
                FuelWiseTotalLtr();
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:btnsave.  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }

        /// <summary>
        /// This method saves the sales details into Sales_Details table with the help of stored procedure.
        /// </summary>
        public void Save(string ProdName, string ProdName1, string PackType, string Qty, string Rate, string Amount, string Qty1, string Invoice_date)
        {
            InventoryClass obj = new InventoryClass();
            obj.Product_Name = ProdName;
            obj.Product_Name1 = ProdName1;
            obj.Package_Type = PackType;
            obj.Qty = Qty;
            obj.QtyTemp = Qty1;
            obj.Rate = Rate;
            obj.Amount = Amount;
            //obj.Inv_date = Invoice_date;
            obj.Invoice_Date = System.Convert.ToDateTime(Invoice_date);
            obj.NetAmount = Amount;
            obj.Sales_Type = " ";
            if (lblInvoiceNo.Visible == true)
            {
                obj.Invoice_No = lblInvoiceNo.Text;
                obj.InsertSalesDetail();
            }
            else
            {
                obj.Invoice_No = dropInvoiceNo.SelectedItem.Value;
                obj.InsertSalesDetail();
            }
        }

        /// <summary>
        /// This method checks only Fuel products is available or not? and also return the product name,tank name,prod_AbbName,machine name,machine type and nozzle name
        /// </summary>
        public void settank()
        {
            try
            {
                InventoryClass obj = new InventoryClass();
                SqlDataReader SqlDtr;
                string sql;
                string str = "";
                sql = "select distinct t.tank_name,t.prod_name,m.machine_name,m.machine_type,n.nozzle_name from tank t,machine m,nozzle n where t.tank_name in(select tank_name from tank where tank_id=n.tank_id) and t.prod_name in(select Prod_name from tank where tank_id=n.tank_id) and m.machine_name in(select machine_name from machine where machine_id=n.machine_id) and m.machine_type in(select machine_type from machine where machine_id=n.machine_id) and n.nozzle_name in(select nozzle_name from nozzle where nozzle_id=n.nozzle_id)";
                SqlDtr = obj.GetRecordSet(sql);
                while (SqlDtr.Read())
                {
                    arr[k] = SqlDtr.GetValue(1).ToString() + ":" + SqlDtr.GetValue(0).ToString() + " / " + SqlDtr.GetValue(2).ToString() + " " + SqlDtr.GetValue(3).ToString() + " / " + SqlDtr.GetValue(4).ToString();
                    str = str + "," + SqlDtr.GetValue(1).ToString() + ":" + SqlDtr.GetValue(0).ToString() + " / " + SqlDtr.GetValue(2).ToString() + " " + SqlDtr.GetValue(3).ToString() + " / " + SqlDtr.GetValue(4).ToString();
                    k++;
                }
                txttottank.Value = str;
                //MessageBox.Show(str);
                SqlDtr.Close();
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:settank().  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }
        /*************
		public void tankname()
		{
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
			string dd="";
			sql="select tankno from cashbilling where invoice_no=500080";
			SqlDtr=obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				dd=SqlDtr.GetValue(0).ToString();
			}
			SqlDtr.Close ();
			for(int m=0;m<k;m++)
			{
				arr1[m]=Request.Params.Get("tank"+m);
				if(arr[m]==dd)
				{
					
					MessageBox.Show("Find");
					return;
				}
			}
		}
		/***********/

        /// <summary>
        /// This function to clear the form.
        /// </summary>
        public void clear1()
        {
            DropPack1.Items.Clear();
            DropPack2.Items.Clear();
            DropType1.SelectedIndex = 0;
            DropType2.SelectedIndex = 0;
            DropProd1.Items.Clear();
            DropProd2.Items.Clear();
            DropProd1.Items.Add("Select");
            DropProd2.Items.Add("Select");
            txtProdName1.Value = "";
            txtProdName2.Value = "";
            txttankno1.Value = "";
            txttankno2.Value = "";
            txtPack1.Value = "";
            txtPack2.Value = "";
            txtQty1.Text = "";
            txtQty2.Text = "";
            txtAmount1.Text = "";
            txtAmount2.Text = "";
            txtGrandTotal.Text = "";
            txtAvStock1.Text = "";
            txtAvStock2.Text = "";
            txtRate1.Text = "";
            txtRate2.Text = "";
            txtRemark.Text = "";
            txtcustname.Text = "";
            txtVehicleNo.Text = "";
            tmpQty1.Value = "";
            tmpQty2.Value = "";
            txtTempQty1.Text = "";
            txtTempQty2.Text = "";
            tempInfo.Value = "";
            lblInvoiceDate.Text = GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());

            DropType2.Enabled = true;
            DropProd2.Enabled = true;
            DropPack2.Enabled = true;
            txtQty2.Enabled = true;
            tempInvoice.Visible = false;
            tempInvoice.Text = "";
            for (int i = 0; i < ProductType.Length; i++)
            {
                ProductType[i] = "";
                ProductName[i] = "";
                ProductPack[i] = "";
                ProductQty[i] = "";
            }
        }

        /// <summary>
        /// This method is used to fill the all invoice no in the dropdownlist from the table.
        /// </summary>
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            try
            {
                clear1();
                lblInvoiceNo.Visible = false;
                dropInvoiceNo.Visible = true;
                btnEdit.Visible = false;
                InventoryClass obj = new InventoryClass();
                SqlDataReader SqlDtr;
                string sql;
                sql = "select Invoice_No from cashbilling";
                SqlDtr = obj.GetRecordSet(sql);
                dropInvoiceNo.Items.Clear();
                dropInvoiceNo.Items.Add("Select");
                while (SqlDtr.Read())
                {
                    dropInvoiceNo.Items.Add(SqlDtr.GetValue(0).ToString());
                }
                SqlDtr.Close();
                FuelWiseTotalLtr();
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:btnEdit.  user " + uid);
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:btnEdit.  EXCEPTION: " + ex.Message + "  user " + uid);
            }

        }

        /// <summary>
        /// This method is used to retrieve all values from the database according to selected invoice no in the dropdownlist.
        /// </summary>
        private void dropInvoiceNo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TextSelect.Text = dropInvoiceNo.SelectedItem.Value.ToString();
            try
            {
                if (TextSelect.Text == "Select")
                {
                    MessageBox.Show("Please Select Invoice No");
                }
                else
                {
                    DropDownList[] ProdType = { DropType1, DropType2 };
                    DropDownList[] ProdName = { DropProd1, DropProd2 };
                    DropDownList[] PackType = { DropPack1, DropPack2 };

                    HtmlInputHidden[] Name = { txtProdName1, txtProdName2 };
                    HtmlInputHidden[] Type = { txtPack1, txtPack2 };
                    TextBox[] Qty = { txtQty1, txtQty2 };
                    TextBox[] Rate = { txtRate1, txtRate2 };
                    TextBox[] Amount = { txtAmount1, txtAmount2 };
                    TextBox[] AvStock = { txtAvStock1, txtAvStock2 };
                    TextBox[] tempQty = { txtTempQty1, txtTempQty2 };
                    HtmlInputHidden[] tmpQty = { tmpQty1, tmpQty2 };
                    string prod_id1 = "";
                    string prod_id2 = "";
                    string[] prodname = { prod_id1, prod_id2 };
                    InventoryClass obj = new InventoryClass();
                    SqlDataReader SqlDtr;
                    string sql, sql1;
                    SqlDataReader rdr = null;
                    //************
                    DropProd1.Items.Clear();
                    DropProd1.Items.Add("Select");
                    DropProd2.Items.Clear();
                    DropProd2.Items.Add("Select");
                    #region Fetch Product Name and fill in the ComboBox
                    sql = "select distinct Prod_Name from Products where Category='Fuel'";
                    SqlDtr = obj.GetRecordSet(sql);
                    while (SqlDtr.Read())
                    {
                        sql = "select Prod_AbbName from Tank where Prod_Name='" + SqlDtr["Prod_Name"] + "'";
                        dbobj.SelectQuery(sql, ref rdr);
                        if (rdr.Read())
                        {
                            DropProd1.Items.Add(SqlDtr.GetValue(0).ToString() + ":" + rdr.GetValue(0).ToString());
                            DropProd2.Items.Add(SqlDtr.GetValue(0).ToString() + ":" + rdr.GetValue(0).ToString());
                        }
                        rdr.Close();

                    }
                    SqlDtr.Close();
                    #endregion
                    //					for(int h=0;h<k;h++)
                    //					{
                    //						DropProd1.Items.Add(arr[h]);
                    //						DropProd2.Items.Add(arr[h]);
                    //					}
                    //************

                    int i = 0;
                    Invoice_Date = "";
                    #region Get Data from Cashbilling Table regarding Invoice No.
                    sql = "select * from cashbilling where Invoice_No='" + dropInvoiceNo.SelectedItem.Value + "'";
                    SqlDtr = obj.GetRecordSet(sql);
                    if (SqlDtr.Read())
                    {
                        string strDate = SqlDtr.GetValue(1).ToString().Trim();
                        int pos = strDate.IndexOf(" ");

                        if (pos != -1)
                        {
                            strDate = strDate.Substring(0, pos);
                        }
                        else
                        {
                            strDate = "";
                        }

                        lblInvoiceDate.Text = GenUtil.str2DDMMYYYY(strDate);
                        Invoice_Date = strDate;
                        if (SqlDtr.GetValue(2).ToString().Equals("Deleted"))
                        {
                            txtcustname.Text = "";
                            tempInvoice.Text = " DELETED";
                            tempInvoice.Visible = true;
                        }
                        else
                        {
                            txtcustname.Text = SqlDtr.GetValue(2).ToString();
                            tempInvoice.Visible = false;
                            tempInvoice.Text = "";
                        }
                        txtVehicleNo.Text = SqlDtr.GetValue(3).ToString();
                        txtRemark.Text = SqlDtr.GetValue(4).ToString();
                        txtGrandTotal.Text = SqlDtr.GetValue(5).ToString();
                        txtProdName1.Value = SqlDtr.GetValue(6).ToString();
                        txtProdName2.Value = SqlDtr.GetValue(7).ToString();
                        DropProd1.SelectedIndex = DropProd1.Items.IndexOf(DropProd1.Items.FindByValue(SqlDtr.GetValue(6).ToString()));
                        DropProd2.SelectedIndex = DropProd2.Items.IndexOf(DropProd2.Items.FindByValue(SqlDtr.GetValue(7).ToString()));
                    }
                    SqlDtr.Close();
                    #endregion

                    #region Get Data from Sales Details Table regarding Invoice No.
                    if (tempInvoice.Visible == false)
                    {
                        sql = "select	p.Category,p.Prod_Name,p.Pack_Type,	sd.qty,sd.rate,sd.amount,p.Prod_ID,p.unit" +
                            " from Products p, sales_Details sd" +
                            " where p.Prod_ID=sd.prod_id and sd.invoice_no='" + dropInvoiceNo.SelectedItem.Value + "'";
                        SqlDtr = obj.GetRecordSet(sql);
                        //sql="select category,Prod_name,pack_type,unit from products where prod_id='"+prod_id1.ToString()+"'";
                        //SqlDtr=obj.GetRecordSet(sql);
                        while (SqlDtr.Read())
                        {
                            ProdType[i].Enabled = true;
                            ProdName[i].Enabled = true;
                            //ProdName[i].Visible = false;//**
                            //Name[i].Visible=true;//**
                            PackType[i].Enabled = true;
                            Qty[i].Enabled = true;
                            Rate[i].Enabled = true;
                            Amount[i].Enabled = true;
                            AvStock[i].Enabled = true;
                            ProdType[i].SelectedIndex = ProdType[i].Items.IndexOf(ProdType[i].Items.FindByValue(SqlDtr.GetValue(0).ToString()));
                            if (ProdType[i].SelectedItem.Value != "Fuel")
                            {
                                Type_Changed(ProdType[i], ProdName[i], PackType[i]);
                                ProdName[i].SelectedIndex = ProdName[i].Items.IndexOf(ProdName[i].Items.FindByValue(SqlDtr.GetValue(1).ToString()));
                                Name[i].Value = SqlDtr.GetValue(1).ToString();
                            }
                            else
                                PackType[i].Enabled = false;
                            Prod_Changed(ProdType[i], ProdName[i], PackType[i], Rate[i]);
                            //Prod_Changed(ProdType[i], ProdName[i] ,PackType[i]);    
                            //Name[i].Value=SqlDtr.GetValue(1).ToString();   
                            PackType[i].SelectedIndex = PackType[i].Items.IndexOf(PackType[i].Items.FindByValue(SqlDtr.GetValue(2).ToString()));
                            Type[i].Value = SqlDtr.GetValue(2).ToString();
                            Qty[i].Text = SqlDtr.GetValue(3).ToString();
                            tempQty[i].Text = Qty[i].Text;
                            tmpQty[i].Value = SqlDtr.GetValue(3).ToString();
                            Rate[i].Text = SqlDtr.GetValue(4).ToString();
                            Amount[i].Text = SqlDtr.GetValue(5).ToString();
                            //****
                            string pt = SqlDtr.GetValue(0).ToString();
                            string pn = SqlDtr.GetValue(1).ToString();
                            string pp = SqlDtr.GetValue(2).ToString();
                            string pq = SqlDtr.GetValue(3).ToString();
                            ProductType[i] = SqlDtr.GetValue(0).ToString();
                            ProductName[i] = SqlDtr.GetValue(1).ToString();
                            ProductPack[i] = SqlDtr.GetValue(2).ToString();
                            ProductQty[i] = SqlDtr.GetValue(3).ToString();
                            //****
                            sql1 = "select top 1 Closing_Stock from Stock_Master where productid=" + SqlDtr.GetValue(6).ToString() + " order by stock_date desc";
                            //sql1="select top 1 Closing_Stock from Stock_Master where productid="+prod_id1+" order by stock_date desc";
                            dbobj.SelectQuery(sql1, ref rdr);
                            if (rdr.Read())
                            {
                                AvStock[i].Text = Math.Round(double.Parse(rdr["Closing_Stock"].ToString()), 2) + " " + SqlDtr.GetValue(7).ToString();
                                //txtAvStock1.Text =System.Convert.ToString(rdr["Closing_Stock"]+" "+SqlDtr.GetValue(7).ToString());
                            }
                            else
                            {
                                AvStock[i].Text = "0" + " " + SqlDtr.GetValue(7).ToString();
                                //txtAvStock1.Text =rdr["Closing_Stock"]+" "+SqlDtr.GetValue(7).ToString();
                            }
                            Qty[i].ToolTip = "Actual Available Stock = " + Qty[i].Text.ToString() + " + " + AvStock[i].Text.ToString();
                            rdr.Close();
                            i++;
                        }
                    }
                    if (i == 0)
                    {
                        while (i < 2)
                        {
                            ProdType[i].SelectedIndex = 0;
                            ProdType[i].Enabled = false;
                            ProdName[i].SelectedIndex = 0;
                            ProdName[i].Enabled = false;
                            PackType[i].Items.Clear();
                            PackType[i].SelectedIndex = 0;
                            PackType[i].Enabled = false;
                            Qty[i].Text = "";
                            Qty[i].Enabled = false;
                            tempQty[i].Text = "";
                            tempQty[i].Enabled = false;
                            tmpQty[i].Value = "";
                            Rate[i].Text = "";
                            Rate[i].Enabled = false;
                            Amount[i].Text = "";
                            Amount[i].Enabled = false;
                            AvStock[i].Text = "";
                            AvStock[i].Enabled = false;
                            i++;
                        }
                    }
                    else
                    {
                        while (i < 2)
                        {
                            ProdType[i].SelectedIndex = 0;
                            ProdType[i].Enabled = true;
                            ProdName[i].SelectedIndex = 0;
                            ProdName[i].Enabled = true;
                            PackType[i].Items.Clear();
                            PackType[i].SelectedIndex = 0;
                            PackType[i].Enabled = true;
                            Qty[i].Text = "";
                            Qty[i].Enabled = true;
                            tempQty[i].Text = "";
                            tempQty[i].Enabled = true;
                            tmpQty[i].Value = "";
                            Rate[i].Text = "";
                            Rate[i].Enabled = true;
                            Amount[i].Text = "";
                            Amount[i].Enabled = true;
                            AvStock[i].Text = "";
                            AvStock[i].Enabled = true;
                            i++;
                        }
                    }
                    SqlDtr.Close();
                    FuelWiseTotalLtr();
                    #endregion
                    CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:dropInvoiceNo_SelectedIndexChanged " + " CashBill is viewed for invoice no: " + dropInvoiceNo.SelectedItem.Value.ToString() + " userid " + "   " + "   " + uid);
                }

            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:dropInvoiceno.  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }

        /// <summary>
        /// Change the package type according to product and fatch the saleRate of the product from price updation table.
        /// </summary>
        public void Prod_Changed(DropDownList ddType, DropDownList ddProd, DropDownList ddPack, TextBox txtPurRate)
        //public void Prod_Changed(DropDownList ddType, DropDownList ddProd,DropDownList ddPack)
        {
            //**********
            string prod = ddProd.SelectedItem.Value;
            string[] pp = prod.Split(new char[] { ':' }, prod.Length);
            //**********
            ddPack.Items.Clear();
            txtPurRate.Text = "";
            if (ddProd.SelectedIndex == 0)
                return;

            InventoryClass obj = new InventoryClass();
            SqlDataReader SqlDtr;
            string sql;
            #region Fetch Package Types Regarding Product Name			
            //sql="Select Pack_Type from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"' and Category='"+ddType.SelectedItem.Value+"'";
            sql = "Select Pack_Type from Products where Prod_Name='" + pp[0] + "' and Category='" + ddType.SelectedItem.Value + "'";
            SqlDtr = obj.GetRecordSet(sql);
            while (SqlDtr.Read())
            {
                ddPack.Items.Add(SqlDtr.GetValue(0).ToString());
            }
            SqlDtr.Close();
            #endregion

            #region Fetch Sales Rate Regarding Product Name		

            //sql= "select top 1 Sal_Rate from Price_Updation where Prod_ID=(select  Prod_ID from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"' and Pack_Type='"+ ddPack.SelectedItem.Value +"') order by eff_date desc";
            sql = "select top 1 Sal_Rate from Price_Updation where Prod_ID=(select  Prod_ID from Products where Prod_Name='" + pp[0] + "' and Pack_Type='" + ddPack.SelectedItem.Value + "') order by eff_date desc";
            SqlDtr = obj.GetRecordSet(sql);
            while (SqlDtr.Read())
            {
                txtPurRate.Text = SqlDtr.GetValue(0).ToString();
            }
            SqlDtr.Close();
            #endregion
        }

        public void Type_Changed(DropDownList ddType, DropDownList ddProd, DropDownList ddPack)
        {
            try
            {
                ddProd.Items.Clear();
                ddProd.Items.Add("Select");
                ddPack.Items.Clear();
                if (ddType.SelectedItem.Value.ToUpper() == "FUEL")
                    ddPack.Enabled = false;
                else
                {
                    ddPack.Enabled = true;
                    ddPack.Items.Add("Select");
                }
                if (ddType.SelectedIndex == 0)
                    return;

                InventoryClass obj = new InventoryClass();
                SqlDataReader SqlDtr;//,rdr=null;
                string sql;

                #region Fetch Product Name and fill in the ComboBox
                sql = "select distinct Prod_Name from Products where Category='" + ddType.SelectedItem.Value + "'";
                SqlDtr = obj.GetRecordSet(sql);
                while (SqlDtr.Read())
                {
                    ddProd.Items.Add(SqlDtr.GetValue(0).ToString());
                }
                SqlDtr.Close();
                #endregion
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:Type_Changed().   EXCEPTION: " + ex.Message + "  User_ID: " + uid);
            }
        }

        /// <summary>
        /// This method is used to prepares the report file for printting.
        /// </summary>
        public void reportmaking4()
        {
            try
            {
                string home_drive = Environment.SystemDirectory;
                home_drive = home_drive.Substring(0, 2);
                string path = home_drive + @"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CashInvoiceReport.txt";
                string info = "";
                string strInvNo = "";
                StreamWriter sw = new StreamWriter(path);
                sw.Write((char)15);
                sw.WriteLine("");
                //**********
                string des = "-----------------------------------------------------------------------------";
                string Address = GenUtil.GetAddress();
                string[] addr = Address.Split(new char[] { ':' }, Address.Length);
                sw.WriteLine(GenUtil.GetCenterAddr(addr[0], des.Length).ToUpper());
                sw.WriteLine(GenUtil.GetCenterAddr(addr[1] + addr[2], des.Length));
                sw.WriteLine(GenUtil.GetCenterAddr("Tin No : " + addr[3], des.Length));
                sw.WriteLine(des);
                //**********
                sw.WriteLine(GenUtil.GetCenterAddr("================", des.Length));
                sw.WriteLine(GenUtil.GetCenterAddr("CASH INVOICE", des.Length));
                sw.WriteLine(GenUtil.GetCenterAddr("================", des.Length));
                if (lblInvoiceNo.Visible == true)
                    strInvNo = lblInvoiceNo.Text;
                else
                    strInvNo = dropInvoiceNo.SelectedItem.Value;

                sw.WriteLine(" Invoice No : " + strInvNo + "                              Date : " + lblInvoiceDate.Text.ToString());
                sw.WriteLine(" Customer Name           :  " + txtcustname.Text);
                sw.WriteLine(" Vehicle Number          :  " + txtVehicleNo.Text);
                sw.WriteLine("+-----------------------------------------+-----------+----------+----------+");
                sw.WriteLine("|                Product                  | Quantity  |   Rate   |  Amount  |");
                sw.WriteLine("+-----------------------------------------+-----------+----------+----------+");
                info = " {0,-41:S} {1,10:F}  {2,10:F} {3,10:F}";
                if (txtAmount1.Text.Equals(""))
                    sw.WriteLine(info, txtProdName1.Value, txtQty1.Text, txtRate1.Text, txtAmount1.Text.ToString().Trim());
                else
                    //sw.WriteLine(info,txtProdName1.Value ,txtQty1.Text,txtRate1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()) );
                    sw.WriteLine(info, txtProdName1.Value, txtQty1.Text, txtRate1.Text, txtAmount1.Text.ToString().Trim());
                if (txtAmount2.Text.Equals(""))
                    sw.WriteLine(info, txtProdName2.Value, txtQty2.Text, txtRate2.Text, txtAmount2.Text.ToString().Trim());
                else
                    //sw.WriteLine(info,txtProdName2.Value ,txtQty2.Text,txtRate2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim())); 
                    sw.WriteLine(info, txtProdName2.Value, txtQty2.Text, txtRate2.Text, txtAmount2.Text.ToString().Trim());
                sw.WriteLine("+-----------------------------------------+-----------+----------+----------+");
                //sw.WriteLine(info,"                Net Total","","",GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()));
                sw.WriteLine(info, "                Net Total", "", "", txtGrandTotal.Text.ToString());
                sw.WriteLine("+-----------------------------------------+-----------+----------+----------+");
                sw.WriteLine(" Remarks      : " + txtRemark.Text);
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("                                                  Signature");

                sw.Close();
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:reportmaking4().  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }

        /// <summary>
        /// This method is used to calls the Insert() fucntion to save or update cash bill details 
        /// and calls the Print() fucntion to create and print the CashMemoReport.txt file.
        /// </summary>
        private void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (PrintDetail == 0)
                {
                    Insert();
                }
                string home_drive = Environment.SystemDirectory;
                home_drive = home_drive.Substring(0, 2);
                print(home_drive + "\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CashMemoReport.txt");
                clear1();
                PrintDetail = 0;
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:btnPrePrint_Click - InvoiceNo : " + lblInvoiceNo.Text);
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:Button1_Click  EXCEPTION :  " + ex.Message + "   " + uid);
            }
        }

        /// <summary>
        /// This method is used to generate the CashInvoicePrePrintReport.txt.
        /// </summary>
        public void prePrint()
        {
            try
            {
                int NOC = 14;  //18  1 inche = 18 characters
                int NOC1 = 15;
                double skip1 = 0.3;//0.5;
                double skip2 = 0.1;
                getTemplateDetails();
                string home_drive = Environment.SystemDirectory;
                home_drive = home_drive.Substring(0, 2);
                string path = home_drive + @"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CashInvoicePrePrintReport.txt";
                string info = "";
                string strInvNo = "";
                StreamWriter sw = new StreamWriter(path);
                string blank = "";
                string str = "";

                // The code present below contains some printer escape sequences.
                // Condensed Mode
                // SI 15 0F
                //  27 38 108 [n] [n] 66
                // 17 11 OnLine
                // 0 48 30
                // 27 38 108 49 79 Landspace 
                // ESC N 78 4E Set skip over perforation 
                // ESC C 67 43 Set page length in lines 
                // ESC @ 64 40 Initialize printer 
                // FF 12 0C Form feed 


                // Online			
                //sw.Write((char)17);	
                // 27,67,22---- 22 lines

                // Initialize
                sw.Write((char)27);
                sw.Write((char)64);
                // ESC P 80 50 Select 10 cpi 
                //sw.Write((char)27);
                //sw.Write((char)80); 

                // 22 lines/page
                sw.Write((char)27);
                sw.Write((char)67);
                sw.Write((char)23);

                // Condensed
                sw.Write((char)27);
                sw.Write((char)15); // SI 15 0F Select condensed mode - Works
                sw.WriteLine("");
                if (lblInvoiceNo.Visible == true)
                    strInvNo = lblInvoiceNo.Text;
                else
                    strInvNo = dropInvoiceNo.SelectedItem.Value;

                if (blank != "")
                    str = blank.Substring(1, System.Convert.ToInt32(Math.Round(NOC1 * cashPos)));

                if (cashMemo)
                {
                    sw.WriteLine(str + strInvNo);
                }
                else
                {
                    sw.WriteLine();
                }

                if (date)
                {
                    sw.WriteLine(str + lblInvoiceDate.Text.ToString());
                }
                else
                {
                    sw.WriteLine();
                }

                if (vehicle)
                {
                    sw.WriteLine(str + txtVehicleNo.Text);
                }
                else
                {
                    sw.WriteLine();
                }

                if (address)
                {
                    sw.WriteLine(str + txtcustname.Text);
                }
                else
                {
                    sw.WriteLine();
                }

                for (int i = 0; i < System.Convert.ToInt32(skip1 * 10); ++i)
                {
                    sw.WriteLine();
                }

                //  25/180 of an Inch  : 27 51 25
                sw.Write((char)27);
                sw.Write((char)51);
                sw.Write((char)25);

                //info = "{0,-15:S} {1,6:F} {2,6:F} {3,9:F}";
                info = "";
                int p = System.Convert.ToInt32(Math.Floor((rate * NOC) - 1));
                int r = System.Convert.ToInt32(Math.Floor((quantity * NOC) - 1));
                int q = System.Convert.ToInt32(Math.Floor((amount * NOC) - 1));
                int a = System.Convert.ToInt32((Math.Ceiling(effectivePrintWidth - (rate + quantity + amount)) * NOC));
                int t = System.Convert.ToInt32(Math.Ceiling((total * NOC) - 1));

                //info = "{0,-" + p + ":S} {1,-" + r + ":F} {2,-" + q + ":F} {3," + a + ":F}";
                info = "{0,-" + p + ":S} {1," + r + ":F} {2," + q + ":F} {3," + a + ":F}";

                //sw.WriteLine(info,trimProduct(txtProdName1.Value.ToString()+" "+txtPack1.Value.Trim()) ,txtRate1.Text,txtQty1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()));
                sw.WriteLine(info, trimProduct(txtProdName1.Value.ToString()), txtRate1.Text, txtQty1.Text, txtAmount1.Text.ToString().Trim());
                if (txtAmount2.Text.Equals(""))
                    sw.WriteLine(info, trimProduct(txtProdName2.Value.ToString()), txtRate2.Text, txtQty2.Text, txtAmount2.Text.ToString().Trim());
                else
                    //sw.WriteLine(info,trimProduct(txtProdName2.Value.ToString()+" "+txtPack2.Value.Trim()) ,txtRate2.Text,txtQty2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim()));
                    sw.WriteLine(info, trimProduct(txtProdName2.Value.ToString()), txtRate2.Text, txtQty2.Text, txtAmount2.Text.ToString().Trim());
                //				sw.WriteLine(info,trimProduct(txtProdName3.Value.ToString()+" "+txtPack3.Value.Trim()) ,txtRate3.Text,txtQty3.Text,GenUtil.strNumericFormat(txtAmount3.Text.ToString().Trim()));
                //				sw.WriteLine(info,trimProduct(txtProdName4.Value.ToString()+" "+txtPack4.Value.Trim()) ,txtRate4.Text,txtQty4.Text,GenUtil.strNumericFormat(txtAmount4.Text.ToString().Trim()));
                //				sw.WriteLine(info,trimProduct(txtProdName5.Value.ToString()+" "+txtPack5.Value.Trim()) ,txtRate5.Text,txtQty5.Text,GenUtil.strNumericFormat(txtAmount5.Text.ToString().Trim()));
                //				sw.WriteLine(info,trimProduct(txtProdName6.Value.ToString()+" "+txtPack6.Value.Trim()) ,txtRate6.Text,txtQty6.Text,GenUtil.strNumericFormat(txtAmount6.Text.ToString().Trim()));
                //				sw.WriteLine(info,trimProduct(txtProdName7.Value.ToString()+" "+txtPack7.Value.Trim()) ,txtRate7.Text,txtQty7.Text,GenUtil.strNumericFormat(txtAmount7.Text.ToString().Trim()));
                //				sw.WriteLine(info,trimProduct(txtProdName8.Value.ToString()+" "+txtPack8.Value.Trim()) ,txtRate8.Text,txtQty8.Text,GenUtil.strNumericFormat(txtAmount8.Text.ToString().Trim()));
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
                for (int i = 0; i < System.Convert.ToInt32(skip2 * 10); ++i)
                {
                    sw.WriteLine();
                }

                //sw.WriteLine(info,"" ,"","",GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()));
                sw.WriteLine(info, "", "", "", txtGrandTotal.Text.ToString());
                //sw.WriteLine(blank.Substring(1,t) + GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()) );

                // back to normal
                sw.Write((char)27);
                //**sw.Write((char)51);
                //**sw.Write((char)10);

                //deselect condensed
                sw.Write((char)1);
                //**sw.Write((char)12);

                sw.Close();
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:prePrint().  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }

        //trim the product length if >=15.
        public string trimProduct(string str)
        {
            if (str.Length > 16)
                return str.Substring(0, 15);
            else
                return str;
        }

        // This method checks the pre print template file and disables the pre print button.
        public void checkPrePrint()
        {
            try
            {
                string home_drive = Environment.SystemDirectory;
                home_drive = home_drive.Substring(0, 2);
                string path = home_drive + @"\Inetpub\wwwroot\EPetro\InvoiceDesigner\PrePrintTemplate.INI";
                StreamReader sr = new StreamReader(path);
                Button1.Enabled = true;
                sr.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                Button1.Enabled = false;
            }
        }

        // This method read the pre print template and sets the  values in global variables.
        public void getTemplateDetails()
        {
            string home_drive = Environment.SystemDirectory;
            home_drive = home_drive.Substring(0, 2);
            string path = home_drive + @"\Inetpub\wwwroot\EPetro\InvoiceDesigner\PrePrintTemplate.INI";
            StreamReader sr = new StreamReader(path);
            string[] data = new string[15];
            int n = 0;
            string info = "";

            while (sr.Peek() >= 0)
            {
                info = sr.ReadLine();
                if (info.StartsWith("[") || info.StartsWith("#"))
                {
                    continue;
                }
                else
                {
                    data[n++] = info;
                }
            }

            sr.Close();

            string[] strarr = data[0].Split(new Char[] { 'x' }, data[0].Length);
            overallPrintWidth = float.Parse(strarr[0].Trim());
            overallPrintHeight = float.Parse(strarr[1].Trim());
            string[] strarr1 = data[1].Split(new Char[] { 'x' }, data[1].Length);
            effectivePrintWidth = float.Parse(strarr1[0].Trim());
            effectivePrintHeight = float.Parse(strarr1[1].Trim());
            header = float.Parse(data[2].Trim());
            body = float.Parse(data[3].Trim());
            footer = float.Parse(data[4].Trim());
            rate = float.Parse(data[5].Trim());
            quantity = float.Parse(data[6].Trim());
            amount = float.Parse(data[7].Trim());
            total = float.Parse(data[8].Trim());
            string[] strarr2 = data[9].Split(new Char[] { 'x' }, data[9].Length);
            cashPos = float.Parse(strarr2[0].Trim());
            cashPosHeight = float.Parse(strarr2[1].Trim());

            if (data[10].Trim().Equals("True"))
            {
                cashMemo = true;
            }
            else
            {
                cashMemo = false;
            }

            if (data[11].Trim().Equals("True"))
            {
                date = true;
            }
            else
            {
                date = false;
            }

            if (data[12].Trim().Equals("True"))
            {
                vehicle = true;
            }
            else
            {
                vehicle = false;
            }

            if (data[13].Trim().Equals("True"))
            {
                address = true;
            }
            else
            {
                address = false;
            }
        }


        //Sends the text file to print server to print.
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
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 60000);

                // Create a TCP/IP  socket.
                Socket sender1 = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender1.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender1.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    string home_drive = Environment.SystemDirectory;
                    home_drive = home_drive.Substring(0, 2);
                    byte[] msg = Encoding.ASCII.GetBytes(home_drive + "\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CashInvoiceReport.txt<EOF>");

                    // Send the data through the socket.
                    int bytesSent = sender1.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = sender1.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.
                    sender1.Shutdown(SocketShutdown.Both);
                    sender1.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:print EXCEPTION  " + ane.Message + " userid " + uid);
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:print EXCEPTION  " + se.Message + " userid " + uid);
                }
                catch (Exception es)
                {
                    Console.WriteLine("Unexpected exception : {0}", es.ToString());
                    CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:print EXCEPTION  " + es.Message + " userid " + uid);
                }
                //CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+es.Message+" userid "+ uid);
            }
            catch (Exception es)
            {
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:print EXCEPTION  " + es.Message + " userid " + uid);
            }
        }

        /// <summary>
        /// This method is used to Sends the text file to print server to print.
        /// </summary>
        public void print(string fileName)
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
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 60000);

                // Create a TCP/IP  socket.
                Socket sender1 = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:print" + " CashBill is Print  userid   " + "   " + uid);
                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender1.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender1.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes(fileName + "<EOF>");

                    // Send the data through the socket.
                    int bytesSent = sender1.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = sender1.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.
                    sender1.Shutdown(SocketShutdown.Both);
                    sender1.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:print" + ane.Message + "  EXCEPTION " + " user " + uid);
                }
                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                    CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:print" + se.Message + "  EXCEPTION " + " user " + uid);
                }
                catch (Exception es)
                {
                    Console.WriteLine("Unexpected exception : {0}", es.ToString());
                    CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:print" + es.Message + "  EXCEPTION " + " user " + uid);
                }

            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:print" + ex.Message + "  EXCEPTION " + " user " + uid);
            }
        }

        //This function to generate the CashInvoicePrePrintReport.txt.
        //		public void prePrintCashMemo()
        //		{	
        //			try
        //			{
        //				int NOC = 14;  //18  1 inche = 18 characters
        //				int NOC1 = 15;
        //				double skip1 = 0.3;//0.5;
        //				double skip2 = 0.1;
        //				getTemplateDetails();
        //				string home_drive = Environment.SystemDirectory;
        //				home_drive = home_drive.Substring(0,2); 
        //				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CashMemoReport.txt";
        //				string info = "";
        //				string strInvNo="";
        //				StreamWriter sw = new StreamWriter(path);
        //				string blank = "                                                                                                ";
        //				string str = "";
        //
        //				// The code present below contains some printer escape sequences.
        //				// Condensed Mode
        //				// SI 15 0F
        //				//  27 38 108 [n] [n] 66
        //				// 17 11 OnLine
        //				// 0 48 30
        //				// 27 38 108 49 79 Landspace 
        //				// ESC N 78 4E Set skip over perforation 
        //				// ESC C 67 43 Set page length in lines 
        //				// ESC @ 64 40 Initialize printer 
        //				// FF 12 0C Form feed 
        //
        //
        //				// Online			
        //				//sw.Write((char)17);	
        //				// 27,67,22---- 22 lines
        //            
        //				// Initialize
        //				sw.Write((char)27);
        //				sw.Write((char)64);
        //				// ESC P 80 50 Select 10 cpi 
        //				//sw.Write((char)27);
        //				//sw.Write((char)80); 
        //
        //				// 22 lines/page
        //				sw.Write((char)27);
        //				sw.Write((char)67); 
        //				//**sw.Write((char)23); 
        //				sw.Write((char)20);
        //			
        //				// Condensed
        //				sw.Write((char)27);
        //				sw.Write((char)15); // SI 15 0F Select condensed mode - Works
        //				sw.WriteLine("");
        //				//*****************
        //				string info1="{0,-7:S} {1,-18:S} {2,-12:S} {3,-10:S}";
        //				string info2="{0,-9:S} {1,-21:S} {2,-10:S} {3,7:S}";
        //				//sw.WriteLine("");
        //				string des="---------------------------------------------------";
        //				string Address=GenUtil.GetAddress();
        //				string[] addr=Address.Split(new char[] {':'},Address.Length);
        //				sw.WriteLine(GenUtil.GetCenterAddr("Cash Memo",des.Length).ToUpper());
        //				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
        //				sw.WriteLine(GenUtil.GetCenterAddr("DEALERS : "+addr[1],des.Length));
        //				sw.WriteLine(GenUtil.GetCenterAddr(addr[2],des.Length));
        //				sw.WriteLine(info2," Tin No :",addr[3],"Phone No :",addr[4]);
        //				sw.WriteLine(des);
        //				if(lblInvoiceNo.Visible==true)
        //					sw.WriteLine(info1," No   :",lblInvoiceNo.Text,"      Date :",lblInvoiceDate.Text);
        //				else
        //					sw.WriteLine(info1," No   :",dropInvoiceNo.SelectedItem.Text,"      Date :",lblInvoiceDate.Text);
        //				sw.WriteLine(info1," Name :",GenUtil.TrimLength(txtcustname.Text.ToString(),18),"Vehicle No :",GenUtil.TrimLength(txtVehicleNo.Text,10));
        //				sw.WriteLine("+----------------+----------+----------+----------+");
        //				sw.WriteLine("|   Item Name    |   Qty    |   Rate   |  Amount  |");
        //				sw.WriteLine("+----------------+----------+----------+----------+");
        //				//             1234567890123456 1234567890 1234567890 1234567890
        //				//info = "{0,-15:S} {1,6:F} {2,6:F} {3,9:F}";
        //				//*********************************
        //				/**************Mahesh********	
        //				if(lblInvoiceNo.Visible==true)
        //					strInvNo= lblInvoiceNo.Text;
        //				else
        //					strInvNo= dropInvoiceNo.SelectedItem.Value;   
        //
        //				str = blank.Substring(1,System.Convert.ToInt32(Math.Round(NOC1 * cashPos)));
        //
        //				if (cashMemo)
        //				{
        //					sw.WriteLine(str + strInvNo);
        //				}
        //				else
        //				{
        //					sw.WriteLine();
        //				}
        //
        //				if (date)
        //				{
        //					sw.WriteLine(str + lblInvoiceDate.Text.ToString());
        //				}
        //				else
        //				{
        //					sw.WriteLine();
        //				}
        //			
        //				if (vehicle)
        //				{
        //					sw.WriteLine(str + txtVehicleNo.Text);
        //				}
        //				else
        //				{
        //					sw.WriteLine();
        //				}
        //
        //				if (address)
        //				{
        //					sw.WriteLine(str + txtcustname.Text);
        //				}
        //				else
        //				{
        //					sw.WriteLine();
        //				}
        //				
        //				for (int i = 0; i < System.Convert.ToInt32(skip1 * 10); ++i)
        //				{
        //					sw.WriteLine();
        //				}
        //				***********Mahesh***********/
        //				//  25/180 of an Inch  : 27 51 25
        //				sw.Write((char)27);
        //				sw.Write((char)51);
        //				sw.Write((char)25);
        //				//sw.WriteLine("");
        //			
        //				info = "";
        //				//				int p = System.Convert.ToInt32(Math.Floor((rate * NOC) - 1));
        //				//				int r = System.Convert.ToInt32(Math.Floor((quantity * NOC) - 1));
        //				//				int q = System.Convert.ToInt32(Math.Floor((amount * NOC) - 1));
        //				//				int a  = System.Convert.ToInt32((Math.Ceiling(effectivePrintWidth - (rate + quantity + amount)) * NOC));
        //				//				int t = System.Convert.ToInt32(Math.Ceiling((total * NOC) - 1));
        //
        //				//info = "{0,-" + p + ":S} {1,-" + r + ":F} {2,-" + q + ":F} {3," + a + ":F}";
        //				//info = "{0,-" + p + ":S} {1," + r + ":F} {2," + q + ":F} {3," + a + ":F}";
        //				info = " {0,-16:S} {1,10:F} {2,10:F} {3,10:F}";
        //				sw.WriteLine(info,trimProduct(txtProdName1.Value.ToString()+" "+txtPack1.Value.Trim()) ,txtRate1.Text,txtQty1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()));
        //				sw.WriteLine(info,trimProduct(txtProdName2.Value.ToString()+" "+txtPack2.Value.Trim()) ,txtRate2.Text,txtQty2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim()));
        //				//				sw.WriteLine(info,trimProduct(txtProdName3.Value.ToString()+" "+txtPack3.Value.Trim()) ,txtRate3.Text,txtQty3.Text,GenUtil.strNumericFormat(txtAmount3.Text.ToString().Trim()));
        //				//				sw.WriteLine(info,trimProduct(txtProdName4.Value.ToString()+" "+txtPack4.Value.Trim()) ,txtRate4.Text,txtQty4.Text,GenUtil.strNumericFormat(txtAmount4.Text.ToString().Trim()));
        //				//				sw.WriteLine(info,trimProduct(txtProdName5.Value.ToString()+" "+txtPack5.Value.Trim()) ,txtRate5.Text,txtQty5.Text,GenUtil.strNumericFormat(txtAmount5.Text.ToString().Trim()));
        //				//				sw.WriteLine(info,trimProduct(txtProdName6.Value.ToString()+" "+txtPack6.Value.Trim()) ,txtRate6.Text,txtQty6.Text,GenUtil.strNumericFormat(txtAmount6.Text.ToString().Trim()));
        //				//				sw.WriteLine(info,trimProduct(txtProdName7.Value.ToString()+" "+txtPack7.Value.Trim()) ,txtRate7.Text,txtQty7.Text,GenUtil.strNumericFormat(txtAmount7.Text.ToString().Trim()));
        //				//				sw.WriteLine(info,trimProduct(txtProdName8.Value.ToString()+" "+txtPack8.Value.Trim()) ,txtRate8.Text,txtQty8.Text,GenUtil.strNumericFormat(txtAmount8.Text.ToString().Trim()));
        //				//				sw.WriteLine("");
        //				//				sw.WriteLine("");
        //				//				sw.WriteLine("");
        //				//				sw.WriteLine("");
        //				//				sw.WriteLine("");
        //				//				sw.WriteLine("");
        //				//				for (int i = 0; i < System.Convert.ToInt32(skip2 * 10); ++i)
        //				//				{
        //				//					sw.WriteLine();
        //				//				}
        //				sw.WriteLine("+----------------+----------+----------+----------+");
        //				sw.WriteLine(info," E & O E." ,"","Total   ",GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()));
        //				sw.WriteLine("+----------------+----------+----------+----------+");
        //				//sw.WriteLine(blank.Substring(1,t) + GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()) );
        //				sw.WriteLine(" "+addr[5]);
        //				sw.WriteLine(" TAX PAID                                Signature");
        //				sw.WriteLine("");
        //				//sw.WriteLine(des);
        //				// back to normal
        //				sw.Write((char)27);
        //				sw.Write((char)51);
        //				sw.Write((char)10);
        //
        //				//deselect condensed
        //				sw.Write((char)27);
        //				//sw.Write((char)18);
        //
        //				sw.Close();
        //			}
        //			catch(Exception ex)
        //			{
        //				CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:prePrint().  EXCEPTION: "+ ex.Message+"  user "+uid);
        //			}
        //		}

        /// <summary>
        /// This Method to write into the report file to print.
        /// </summary>
        public void prePrintCashMemo()  //modified  by vishnu  and working properly
        {
            try
            {
                //int NOC = 14;  //18  1 inche = 18 characters
                //int NOC1 = 15;
                //double skip1 = 0.3;
                //double skip2 = 0.1;
                getTemplateDetails();
                string home_drive = Environment.SystemDirectory;
                home_drive = home_drive.Substring(0, 2);
                string path = home_drive + @"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CashMemoReport.txt";
                string info = "";
                //string strInvNo="";
                StreamWriter sw = new StreamWriter(path);
                //string blank = "                                                                                                ";
                //string str = "";

                // The code present below contains some printer escape sequences.
                // Condensed Mode
                // SI 15 0F
                //  27 38 108 [n] [n] 66
                // 17 11 OnLine
                // 0 48 30
                // 27 38 108 49 79 Landspace 
                // ESC N 78 4E Set skip over perforation 
                // ESC C 67 43 Set page length in lines 
                // ESC @ 64 40 Initialize printer 
                // FF 12 0C Form feed 


                // Online			
                //sw.Write((char)17);	
                // 27,67,22---- 22 lines

                // Initialize
                sw.Write((char)27);
                sw.Write((char)64);
                // ESC P 80 50 Select 10 cpi 
                //sw.Write((char)27);
                //sw.Write((char)80); 

                sw.Write((char)27);
                sw.Write((char)67);
                sw.Write((char)0); //added by vishnu
                sw.Write((char)3); //added by vishnu

                sw.Write((char)27);
                sw.Write((char)15);

                sw.Write((char)27);//Retract paper
                sw.Write((char)106);
                sw.Write((char)255);

                sw.Write((char)27);
                sw.Write((char)106);
                sw.Write((char)255);

                sw.Write((char)27);
                sw.Write((char)15);
                // SI 15 0F Select condensed mode - Works
                //sw.WriteLine("");
                //*****************
                string info1 = "{0,-16:S} {1,-12:S} {2,-9:S} {3,-10:S}";
                string info2 = "{0,-9:S} {1,-21:S} {2,-10:S} {3,7:S}";
                //sw.WriteLine("");
                string des = "--------------------------------------------------";
                string Address = GenUtil.GetAddress();
                string[] addr = Address.Split(new char[] { ':' }, Address.Length);
                sw.WriteLine(GenUtil.GetCenterAddr("Cash Memo", des.Length).ToUpper());
                sw.WriteLine(GenUtil.GetCenterAddr(addr[0], des.Length).ToUpper());
                sw.WriteLine(GenUtil.GetCenterAddr("DEALERS : " + addr[1], des.Length));
                sw.WriteLine(GenUtil.GetCenterAddr(addr[2], des.Length));
                sw.WriteLine(info2, " Tin No :", addr[3], "Phone No :", addr[4]);
                sw.WriteLine(des);
                if (lblInvoiceNo.Visible == true)
                    sw.WriteLine(info1, " Cash Memo No  :", lblInvoiceNo.Text, "   Date :", lblInvoiceDate.Text);
                else
                    sw.WriteLine(info1, " Cash Memo No  :", dropInvoiceNo.SelectedItem.Text, "   Date :", lblInvoiceDate.Text);
                sw.WriteLine(info1, " Customer Name :", GenUtil.TrimLength(txtcustname.Text.ToString(), 12), "Veh. No :", GenUtil.TrimLength(txtVehicleNo.Text, 10));
                sw.WriteLine("+----------------+----------+----------+----------+");
                sw.WriteLine("|   Item Name    |   Qty    |   Rate   |  Amount  |");
                sw.WriteLine("+----------------+----------+----------+----------+");
                //             1234567890123456 1234567890 1234567890 1234567890
                //info = "{0,-15:S} {1,6:F} {2,6:F} {3,9:F}";
                /************Mahesh***********/
                //  25/180 of an Inch  : 27 51 25
                sw.Write((char)27);
                sw.Write((char)51);
                sw.Write((char)25);

                //sw.WriteLine("");

                info = "";
                info = " {0,-16:S} {1,10:F} {2,10:F} {3,10:F}";
                //sw.WriteLine(info,trimProduct(txtProdName1.Value.ToString()+" "+txtPack1.Value.Trim()) ,txtRate1.Text,txtQty1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()));
                sw.WriteLine(info, trimProduct(txtProdName1.Value.ToString()), txtQty1.Text, txtRate1.Text, txtAmount1.Text.ToString().Trim());
                if (txtAmount2.Text.Equals(""))
                    sw.WriteLine(info, trimProduct(txtProdName2.Value.ToString()), txtQty2.Text, txtRate2.Text, txtAmount2.Text.ToString().Trim());
                else
                    //sw.WriteLine(info,trimProduct(txtProdName2.Value.ToString()+" "+txtPack2.Value.Trim()) ,txtRate2.Text,txtQty2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim()));
                    sw.WriteLine(info, trimProduct(txtProdName2.Value.ToString()), txtQty2.Text, txtRate2.Text, txtAmount2.Text.ToString().Trim());
                sw.WriteLine("+----------------+----------+----------+----------+");
                //sw.WriteLine(info," E & O E." ,"","Total   ",GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()));
                sw.WriteLine(info, " E & O E.", "", "Total   ", txtGrandTotal.Text.ToString());
                sw.WriteLine("+----------------+----------+----------+----------+");
                sw.WriteLine(" " + addr[5]);
                sw.WriteLine(" TAX PAID                                Signature");

                sw.Write((char)27);
                sw.Write((char)51);
                sw.Write((char)10);
                //deselect condensed
                sw.Write((char)27);
                sw.Write((char)18);//added by vishnu

                sw.Close();
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:prePrint().  EXCEPTION: " + ex.Message + "  user " + uid);
            }
        }

        //		public void prePrintCashMemo()//modified  by vishnu  and working properly
        //		{	
        //			try
        //			{
        //				int NOC = 14;  //18  1 inche = 18 characters
        //				int NOC1 = 15;
        //				double skip1 = 0.3;
        //				double skip2 = 0.1;
        //				getTemplateDetails();
        //				string home_drive = Environment.SystemDirectory;
        //				home_drive = home_drive.Substring(0,2); 
        //				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CashMemoReport.txt";
        //				string info = "";
        //				string strInvNo="";
        //				StreamWriter sw = new StreamWriter(path);
        //				string blank = "                                                                                                ";
        //				string str = "";
        //
        //				// The code present below contains some printer escape sequences.
        //				// Condensed Mode
        //				// SI 15 0F
        //				//  27 38 108 [n] [n] 66
        //				// 17 11 OnLine
        //				// 0 48 30
        //				// 27 38 108 49 79 Landspace 
        //				// ESC N 78 4E Set skip over perforation 
        //				// ESC C 67 43 Set page length in lines 
        //				// ESC @ 64 40 Initialize printer 
        //				// FF 12 0C Form feed 
        //
        //
        //				// Online			
        //				//sw.Write((char)17);	
        //				// 27,67,22---- 22 lines
        //            
        //				// Initialize
        //				sw.Write((char)27);
        //				sw.Write((char)64);
        //				// ESC P 80 50 Select 10 cpi 
        //				//sw.Write((char)27);
        //				//sw.Write((char)80); 
        //
        //				/* These lines works properly	*/
        //				  sw.Write((char)27);
        //				sw.Write((char)67); 
        //				sw.Write((char)0); //added by vishnu
        //				sw.Write((char)3); //added by vishnu
        //			
        //				// Condensed
        //				sw.Write((char)27);
        //				sw.Write((char)15); // SI 15 0F Select condensed mode - Works
        //				sw.WriteLine("");
        //				//*****************
        //				string info1="{0,-7:S} {1,-18:S} {2,-12:S} {3,-10:S}";
        //				string info2="{0,-9:S} {1,-21:S} {2,-10:S} {3,7:S}";
        //				//sw.WriteLine("");
        //				string des="---------------------------------------------------";
        //				string Address=GenUtil.GetAddress();
        //				string[] addr=Address.Split(new char[] {':'},Address.Length);
        //				sw.WriteLine(GenUtil.GetCenterAddr("Cash Memo",des.Length).ToUpper());
        //				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
        //				sw.WriteLine(GenUtil.GetCenterAddr("DEALERS : "+addr[1],des.Length));
        //				sw.WriteLine(GenUtil.GetCenterAddr(addr[2],des.Length));
        //				sw.WriteLine(info2," Tin No :",addr[3],"Phone No :",addr[4]);
        //				sw.WriteLine(des);
        //				if(lblInvoiceNo.Visible==true)
        //					sw.WriteLine(info1," No   :",lblInvoiceNo.Text,"      Date :",lblInvoiceDate.Text);
        //				else
        //					sw.WriteLine(info1," No   :",dropInvoiceNo.SelectedItem.Text,"      Date :",lblInvoiceDate.Text);
        //				sw.WriteLine(info1," Name :",GenUtil.TrimLength(txtcustname.Text.ToString(),18),"Vehicle No :",GenUtil.TrimLength(txtVehicleNo.Text,10));
        //				sw.WriteLine("+----------------+----------+----------+----------+");
        //				sw.WriteLine("|   Item Name    |   Qty    |   Rate   |  Amount  |");
        //				sw.WriteLine("+----------------+----------+----------+----------+");
        //				//             1234567890123456 1234567890 1234567890 1234567890
        //				//info = "{0,-15:S} {1,6:F} {2,6:F} {3,9:F}";
        //				/************Mahesh***********/
        //				//  25/180 of an Inch  : 27 51 25
        //				sw.Write((char)27); 
        //				sw.Write((char)51); 
        //				sw.Write((char)25); 
        //				//sw.WriteLine("");
        //			
        //				info = "";
        //				info = " {0,-16:S} {1,10:F} {2,10:F} {3,10:F}";
        //				sw.WriteLine(info,trimProduct(txtProdName1.Value.ToString()+" "+txtPack1.Value.Trim()) ,txtRate1.Text,txtQty1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()));
        //				sw.WriteLine(info,trimProduct(txtProdName2.Value.ToString()+" "+txtPack2.Value.Trim()) ,txtRate2.Text,txtQty2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim()));
        //				sw.WriteLine("+----------------+----------+----------+----------+");
        //				sw.WriteLine(info," E & O E." ,"","Total   ",GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()));
        //				sw.WriteLine("+----------------+----------+----------+----------+");
        //				sw.WriteLine(" "+addr[5]);
        //				sw.WriteLine(" TAX PAID                                Signature");
        //				sw.WriteLine("");
        //				sw.Write((char)27);
        //				sw.Write((char)51);
        //				sw.Write((char)10);
        //
        //
        //				//deselect condensed
        //				sw.Write((char)27);
        //				sw.Write((char)18);//added by vishnu
        //
        //				sw.Close();
        //			}
        //			catch(Exception ex)
        //			{
        //				CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:prePrint().  EXCEPTION: "+ ex.Message+"  user "+uid);
        //			}
        //		}
        //
        //
        //
        /// <summary>
        /// Its calls the Insert() fucntion to save or update invoice details and calls the 
        /// Print() fucntion to create and print the CashInvoicePrePrintReport.txt file.
        /// </summary>
        private void btnPrePrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (PrintDetail == 0)
                {
                    Insert();
                }
                string home_drive = Environment.SystemDirectory;
                home_drive = home_drive.Substring(0, 2);
                print(home_drive + "\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CashInvoicePrePrintReport.txt");
                clear1();
                PrintDetail = 0;
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:btnPrePrint_Click - InvoiceNo : " + lblInvoiceNo.Text);
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:btnPrePrint_Click  EXCEPTION :  " + ex.Message + "   " + uid);
            }
        }


        /// <summary>
        /// This method is used to calculate the qty in liter of fuel product according to current date.
        /// </summary>
        public void FuelWiseTotalLtr()
        {
            InventoryClass obj = new InventoryClass();
            SqlDataReader SqlDtr, rdr = null;
            string sql;
            int i = 0;
            count = 0;
            #region Fetch Total Quantity in Ltr accordeing to Fuel wise.
            sql = "select Prod_ID,Prod_Name from Products where Category='Fuel'";
            SqlDtr = obj.GetRecordSet(sql);
            while (SqlDtr.Read())
            {
                dbobj.SelectQuery("select sum(Qty) from sales_Details sd,sales_master sm where Prod_ID=" + SqlDtr["Prod_ID"].ToString() + " and sm.invoice_no=sd.invoice_no and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='" + DateTime.Now.ToString("MM/dd/yyyy") + "'", ref rdr);
                if (rdr.Read())
                    Quantity11[i] = rdr.GetValue(0).ToString();
                rdr.Close();
                if (Quantity11[i].Equals(""))
                    Quantity11[i] = "0";
                dbobj.SelectQuery("select sum(Qty) from sales_Details sd,cashbilling c where sd.Prod_ID=" + SqlDtr["Prod_ID"].ToString() + " and c.Invoice_No=sd.Invoice_No and cast(floor(cast(cast(c.invoice_date as datetime) as float)) as datetime)='" + DateTime.Now.ToString("MM/dd/yyyy") + "'", ref rdr);
                if (rdr.Read())
                    Cash[i] = rdr.GetValue(0).ToString();
                rdr.Close();
                if (Cash[i].Equals("") || Cash[i].Equals(null))
                    Cash[i] = "0";
                Sales[i] = System.Convert.ToString(double.Parse(Quantity11[i]) - double.Parse(Cash[i]));
                ProdName[i] = SqlDtr.GetValue(1).ToString();
                count++;
                i++;
            }
            SqlDtr.Close();
            #endregion
        }

        /// <summary>
        /// This method is used to delete the selected record from dropdownlist on edit time.
        /// </summary>
        public void DeleteTheRec()
        {
            try
            {
                DropDownList[] DropType = { DropType1, DropType2 };
                HtmlInputHidden[] ProdName = { txtProdName1, txtProdName2 };
                HtmlInputHidden[] PackType = { txtPack1, txtPack2 };
                TextBox[] Qty = { txtQty1, txtQty2 };
                InventoryClass obj = new InventoryClass();
                SqlDataReader rdr;
                SqlCommand cmd;
                SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
                //string st="select Invoice_No from Sales_Master where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'";
                //rdr=obj.GetRecordSet(st);
                //if(rdr.Read())
                //{
                /*Con.Open();
                cmd = new SqlCommand("delete from Vendorledgertable where Particular='Purchase Invoice ("+rdr["Invoice_No"].ToString()+")'",Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                cmd.Dispose();*/
                Con.Open();
                //cmd = new SqlCommand("delete from Accountsledgertable where Particulars='Sales in Cash("+rdr["Invoice_No"].ToString()+")'",Con);
                cmd = new SqlCommand("delete from Accountsledgertable where Particulars='Sales in Cash(" + dropInvoiceNo.SelectedItem.Text + ")'", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                cmd.Dispose();
                //}
                //rdr.Close();
                /*string str1="select * from VendorLedgerTable where VendorID=(select Supp_ID from Supplier where Supp_Name='"+DropVendorID.SelectedItem.Text+"') order by entrydate";
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
				rdr.Close();*/
                Con.Open();
                cmd = new SqlCommand("delete from Sales_Master where Invoice_No='" + dropInvoiceNo.SelectedItem.Text + "'", Con);
                //cmd = new SqlCommand("update Sales_Master set sales_type='',cust_id='',under_salesman='',vehicle_no='',grand_total='',discount='',discount_type='',net_amount='',Promo_scheme='',remark='',entry_by='',entry_time='',slip_no='',cash_discount='',cash_disc_type='',vat_amount='',challanno='',challandate='' where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                cmd.Dispose();
                //				Con.Open();
                //				//cmd = new SqlCommand("delete from Sales_Master where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",Con);
                //				cmd = new SqlCommand("update Sales_details set qty='',rate='',amount='' where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",Con);
                //				cmd.ExecuteNonQuery();
                //				Con.Close();
                //				cmd.Dispose();
                Con.Open();
                //cmd = new SqlCommand("delete from cashbilling where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",Con);
                cmd = new SqlCommand("update cashbilling set custname='Deleted',vehicleno='',remark='',netamt='',tank1='',tank2='' where Invoice_No='" + dropInvoiceNo.SelectedItem.Text + "'", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                cmd.Dispose();
                /****** Comment by Mahesh On 08.11.008 this code execute by stored procedures
				string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name='Cash') order by entry_date";
				rdr=obj.GetRecordSet(str);
				double Bal=0;
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
				*********************/
                CustomerUpdate();
                for (int i = 0; i < 2; i++)
                {
                    if (DropType[i].SelectedItem.Text.Equals("Type") || ProdName[i].Value == "")// || PackType[i].Value=="")
                        continue;
                    else
                    {
                        Con.Open();
                        if (DropType[i].SelectedItem.Text.Equals("Fuel"))
                        {
                            string temp = ProdName[i].Value;
                            string[] PN = temp.Split(new char[] { ':' }, temp.Length);
                            cmd = new SqlCommand("update Stock_Master set sales=sales-" + double.Parse(Qty[i].Text) + ",closing_stock=closing_stock+" + double.Parse(Qty[i].Text) + " where ProductID=(select Prod_ID from Products where Category='" + DropType[i].SelectedItem.Text + "' and Prod_Name='" + PN[0] + "') and cast(stock_date as smalldatetime)='" + GenUtil.str2MMDDYYYY(lblInvoiceDate.Text) + "'", Con);
                        }
                        else
                            cmd = new SqlCommand("update Stock_Master set sales=sales-" + double.Parse(Qty[i].Text) + ",closing_stock=closing_stock+" + double.Parse(Qty[i].Text) + " where ProductID=(select Prod_ID from Products where Category='" + DropType[i].SelectedItem.Text + "' and Prod_Name='" + ProdName[i].Value + "' and Pack_Type='" + PackType[i].Value + "') and cast(stock_date as smalldatetime)='" + GenUtil.str2MMDDYYYY(lblInvoiceDate.Text) + "'", Con);
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        cmd.Dispose();
                    }
                }
                SeqStockMaster();

                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:btnDelete_Click - InvoiceNo : " + dropInvoiceNo.SelectedItem.Text + " Deleted, user : " + uid);
                clear1();
                GetNextInvoiceNo();
                settank();
                GetProducts();
                FuelWiseTotalLtr();
                lblInvoiceNo.Visible = true;
                dropInvoiceNo.Visible = false;
                btnEdit.Visible = true;
                MessageBox.Show("Cash Transaction Deleted");
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbill.aspx,Method:btnDelete_Click - InvoiceNo : " + dropInvoiceNo.SelectedItem.Text + " ,Exception : " + ex.Message + " user : " + uid);
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
            for (int i = 0; i < ProductType.Length; i++)
            {
                if (ProductType[i] == "" || ProductName[i] == "" || ProductQty[i] == "")
                    continue;
                else
                {
                    SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
                    SqlDataReader rdr1 = null, rdr = null;
                    string str = "select Prod_ID from Products where Category='" + ProductType[i].ToString() + "' and Prod_Name='" + ProductName[i].ToString() + "' and Pack_Type='" + ProductPack[i].ToString() + "'";
                    rdr = obj.GetRecordSet(str);
                    if (rdr.Read())
                    {
                        string str1 = "select * from Stock_Master where Productid='" + rdr["Prod_ID"].ToString() + "' order by Stock_date";
                        rdr1 = obj1.GetRecordSet(str1);
                        double OS = 0, CS = 0, k = 0;
                        while (rdr1.Read())
                        {
                            if (k == 0)
                            {
                                OS = double.Parse(rdr1["opening_stock"].ToString());
                                k++;
                            }
                            else
                                OS = CS;
                            CS = OS + double.Parse(rdr1["receipt"].ToString()) - double.Parse(rdr1["sales"].ToString());
                            DateTime SD = System.Convert.ToDateTime(rdr1["stock_date"].ToString());
                            Con.Open();
                            cmd = new SqlCommand("update Stock_Master set opening_stock='" + OS.ToString() + "', Closing_Stock='" + CS.ToString() + "' where ProductID='" + rdr1["Productid"].ToString() + "' and Stock_Date='" + GenUtil.str2MMDDYYYY(SD.ToString()) + "'", Con);
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
        /// This method update the products qty before sales in edit time.
        /// </summary>
        public void UpdateProductQty()
        {
            InventoryClass obj = new InventoryClass();
            SqlDataReader rdr;
            SqlCommand cmd;
            for (int i = 0; i < ProductType.Length; i++)
            {
                SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
                string str = "";
                if (ProductType[i] == "" || ProductName[i] == "" || ProductQty[i] == "")
                    continue;
                else
                {
                    str = "select Prod_ID from Products where Category='" + ProductType[i].ToString() + "' and Prod_Name='" + ProductName[i].ToString() + "' and Pack_Type='" + ProductPack[i].ToString() + "'";
                    rdr = obj.GetRecordSet(str);
                    if (rdr.Read())
                    {
                        Con.Open();
                        cmd = new SqlCommand("update Stock_Master set sales=sales-" + double.Parse(ProductQty[i].ToString()) + ", Closing_Stock=Closing_Stock+" + double.Parse(ProductQty[i].ToString()) + " where ProductID='" + rdr["Prod_ID"].ToString() + "' and cast(floor(cast(cast(Stock_Date as datetime) as float)) as datetime)='" + GenUtil.str2MMDDYYYY(lblInvoiceDate.Text.ToString()) + "'", Con);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Con.Close();
                    }
                    rdr.Close();
                    /*
					if(SchProductType[i]=="" || SchProductName[i]=="" || SchProductQty[i]=="")
						continue;
					else
					{
						str="select Prod_ID from Products where Category='"+SchProductType[i].ToString()+"' and Prod_Name='"+SchProductName[i].ToString()+"' and Pack_Type='"+SchProductPack[i].ToString()+"'";
						rdr=obj.GetRecordSet(str);
						if(rdr.Read())
						{
							Con.Open();
							cmd = new SqlCommand("update Stock_Master set sales=sales-"+double.Parse(SchProductQty[i].ToString())+", Closing_Stock=Closing_Stock+"+double.Parse(SchProductQty[i].ToString())+" where ProductID='"+rdr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(Stock_Date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(lblInvoiceDate.Text)+"'",Con);
							cmd.ExecuteNonQuery();
							cmd.Dispose();
							Con.Close();
						}
						rdr.Close();
					}
					*/
                }
            }
        }                

        public void StockMaster(string PType, string PName, string PackType)
        {
            InventoryClass obj = new InventoryClass();
            InventoryClass obj1 = new InventoryClass();
            string[] Name = null;
            if (PName.IndexOf(":") > 0)
            {
                Name = PName.Split(new char[] { ':' }, PName.Length);
                PName = Name[0].ToString();
            }
            SqlCommand cmd;
            //			for(int i=0;i<ProductType.Length;i++)
            //			{
            //				if(ProductType[i]=="" || ProductName[i]=="" || ProductQty[i]=="")
            //					continue;
            //				else
            //				{

            SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
            SqlDataReader rdr1 = null, rdr = null;
            string str = "select Prod_ID from Products where Category='" + PType + "' and Prod_Name='" + PName + "' and Pack_Type='" + PackType + "'";
            rdr = obj.GetRecordSet(str);
            if (rdr.Read())
            {
                string str1 = "select * from Stock_Master where Productid='" + rdr["Prod_ID"].ToString() + "' order by Stock_date";
                rdr1 = obj1.GetRecordSet(str1);
                double OS = 0, CS = 0, k = 0;
                while (rdr1.Read())
                {
                    if (k == 0)
                    {
                        OS = double.Parse(rdr1["opening_stock"].ToString());
                        k++;
                    }
                    else
                        OS = CS;
                    CS = OS + double.Parse(rdr1["receipt"].ToString()) - double.Parse(rdr1["sales"].ToString());
                    DateTime SD = System.Convert.ToDateTime(rdr1["stock_date"].ToString());
                    Con.Open();
                    cmd = new SqlCommand("update Stock_Master set opening_stock='" + OS.ToString() + "', Closing_Stock='" + CS.ToString() + "' where ProductID='" + rdr1["Productid"].ToString() + "' and Stock_Date='" + GenUtil.str2MMDDYYYY(SD.ToString()) + "'", Con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Con.Close();
                }
                rdr1.Close();
            }
            rdr.Close();
            //}
            //}
        }

        static string Invoice_Date = "";
        /// <summary>
        /// This method is used to update the customer balance after sales.
        /// </summary>
        public void CustomerUpdate()
        {
            SqlDataReader rdr = null;
            SqlCommand cmd;
            InventoryClass obj = new InventoryClass();
            SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
            double Bal = 0;
            string BalType = "", str = "";
            int i = 0;
            object op = null;
            //************************
            int Ledger_ID = 0;
            dbobj.ExecuteScalar("select Ledger_ID from Ledger_Master where Sub_grp_ID=118 and Ledger_Name='Cash'", ref Ledger_ID);
            if (lblInvoiceNo.Visible != true)
            {
                //DateTime dt =
                if (DateTime.Compare(System.Convert.ToDateTime(Invoice_Date), System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(lblInvoiceDate.Text))) > 0)
                    //Invoice_Date = GenUtil.str2MMDDYYYY(lblInvoiceDate.Text);
                dbobj.ExecProc(OprType.Update, "UpdateAccountsLedgerForCustomer", ref op, "@Ledger_ID", Ledger_ID, "@Invoice_Date", GenUtil.str2MMDDYYYY(Invoice_Date));
            }
            else
            {
                dbobj.ExecProc(OprType.Update, "UpdateAccountsLedgerForCustomer", ref op, "@Ledger_ID", Ledger_ID, "@Invoice_Date", GenUtil.str2MMDDYYYY(lblInvoiceDate.Text.ToString()));
            }
            /*rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID=(Select top 1 Ledger_ID from Ledger_Master lm, Ledger_Master_Sub_Grp lmsg  where lm.Sub_grp_ID = lmsg.sub_grp_id and lmsg.Sub_grp_Name = 'Cash in hand') and Entry_Date<='"+Invoice_Date+"' order by entry_date desc");
			if(rdr.Read())
				str="select * from AccountsLedgerTable where Ledger_ID=(Select top 1 Ledger_ID from Ledger_Master lm, Ledger_Master_Sub_Grp lmsg  where lm.Sub_grp_ID = lmsg.sub_grp_id and lmsg.Sub_grp_Name = 'Cash in hand') and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
			else
				str="select * from AccountsLedgerTable where Ledger_ID=(Select top 1 Ledger_ID from Ledger_Master lm, Ledger_Master_Sub_Grp lmsg  where lm.Sub_grp_ID = lmsg.sub_grp_id and lmsg.Sub_grp_Name = 'Cash in hand') order by entry_date";
			rdr.Close();
			//*************************
			rdr=obj.GetRecordSet(str);
			Bal=0;
			BalType="";
			i=0;
			while(rdr.Read())
			{
				if(i==0)
				{
					BalType=rdr["Bal_Type"].ToString();
					Bal = double.Parse(rdr["Balance"].ToString());
					i++;
				}
				else
				{
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
			}
			rdr.Close();*/
        }
    }
}


