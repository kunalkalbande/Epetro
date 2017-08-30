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


namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for SalesInvoice.
	/// </summary>
	public class SalesInvoice : System.Web.UI.Page
	{  // SqlDataReader rdr;
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.DropDownList dropInvoiceNo;
		protected System.Web.UI.WebControls.Label lblInvoiceNo;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.TextBox lblInvoiceDate;
		protected System.Web.UI.WebControls.DropDownList DropSalesType;
		protected System.Web.UI.WebControls.Label lblSlipNo;
		protected System.Web.UI.WebControls.DropDownList DropUnderSalesMan;
		protected System.Web.UI.WebControls.DropDownList DropCustName;
		protected System.Web.UI.WebControls.TextBox txtVehicleNo;
		protected System.Web.UI.WebControls.Label hiddenCustID;
		protected System.Web.UI.WebControls.DropDownList DropType1;
		protected System.Web.UI.WebControls.DropDownList DropProd1;
		protected System.Web.UI.WebControls.DropDownList DropPack1;
		protected System.Web.UI.WebControls.TextBox txtRate1;
		protected System.Web.UI.WebControls.TextBox txtAmount1;
		protected System.Web.UI.WebControls.DropDownList DropType2;
		protected System.Web.UI.WebControls.DropDownList DropProd2;
		protected System.Web.UI.WebControls.DropDownList DropPack2;
		protected System.Web.UI.WebControls.TextBox txtRate2;
		protected System.Web.UI.WebControls.TextBox txtAmount2;
		protected System.Web.UI.WebControls.DropDownList DropType3;
		protected System.Web.UI.WebControls.DropDownList DropProd3;
		protected System.Web.UI.WebControls.DropDownList DropPack3;
		protected System.Web.UI.WebControls.TextBox txtRate3;
		protected System.Web.UI.WebControls.TextBox txtAmount3;
		protected System.Web.UI.WebControls.DropDownList DropType4;
		protected System.Web.UI.WebControls.DropDownList DropProd4;
		protected System.Web.UI.WebControls.DropDownList DropPack4;
		protected System.Web.UI.WebControls.TextBox txtQty4;
		protected System.Web.UI.WebControls.TextBox txtRate4;
		protected System.Web.UI.WebControls.TextBox txtAmount4;
		protected System.Web.UI.WebControls.DropDownList DropType5;
		protected System.Web.UI.WebControls.DropDownList DropProd5;
		protected System.Web.UI.WebControls.DropDownList DropPack5;
		protected System.Web.UI.WebControls.TextBox txtQty5;
		protected System.Web.UI.WebControls.TextBox txtRate5;
		protected System.Web.UI.WebControls.TextBox txtAmount5;
		protected System.Web.UI.WebControls.DropDownList DropType6;
		protected System.Web.UI.WebControls.DropDownList DropProd6;
		protected System.Web.UI.WebControls.DropDownList DropPack6;
		protected System.Web.UI.WebControls.TextBox txtQty6;
		protected System.Web.UI.WebControls.TextBox txtRate6;
		protected System.Web.UI.WebControls.TextBox txtAmount6;
		protected System.Web.UI.WebControls.DropDownList DropType7;
		protected System.Web.UI.WebControls.DropDownList DropProd7;
		protected System.Web.UI.WebControls.DropDownList DropPack7;
		protected System.Web.UI.WebControls.TextBox txtQty7;
		protected System.Web.UI.WebControls.TextBox txtRate7;
		protected System.Web.UI.WebControls.TextBox txtAmount7;
		protected System.Web.UI.WebControls.DropDownList DropType8;
		protected System.Web.UI.WebControls.DropDownList DropProd8;
		protected System.Web.UI.WebControls.DropDownList DropPack8;
		protected System.Web.UI.WebControls.TextBox txtQty8;
		protected System.Web.UI.WebControls.TextBox txtRate8;
		protected System.Web.UI.WebControls.TextBox txtAmount8;
		protected System.Web.UI.WebControls.TextBox txtPromoScheme;
		protected System.Web.UI.WebControls.TextBox txtGrandTotal;
		protected System.Web.UI.WebControls.TextBox txtDisc;
		protected System.Web.UI.WebControls.DropDownList DropDiscType;
		protected System.Web.UI.WebControls.TextBox txtNetAmount;
		protected System.Web.UI.WebControls.Label lblEntryBy;
		protected System.Web.UI.WebControls.Label lblEntryTime;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator4;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.TextBox txtQty2;
		protected System.Web.UI.WebControls.TextBox txtQty1;
		protected System.Web.UI.WebControls.TextBox txtAvStock1;
		protected System.Web.UI.WebControls.TextBox txtAvStock2;
		protected System.Web.UI.WebControls.TextBox txtAvStock3;
		protected System.Web.UI.WebControls.TextBox txtAvStock4;
		protected System.Web.UI.WebControls.TextBox txtAvStock5;
		protected System.Web.UI.WebControls.TextBox txtAvStock6;
		protected System.Web.UI.WebControls.TextBox txtAvStock7;
		protected System.Web.UI.WebControls.TextBox txtAvStock8;
		protected System.Web.UI.WebControls.TextBox txtQty3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName8;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack8;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack7;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtVen;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.HtmlControls.HtmlInputText lblPlace;
		protected System.Web.UI.HtmlControls.HtmlInputText lblDueDate;
		protected System.Web.UI.HtmlControls.HtmlInputText lblCurrBalance;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBox1;
		protected System.Web.UI.WebControls.TextBox TxtCrLimit1;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtCrLimit;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtEnd;
		protected System.Web.UI.HtmlControls.HtmlInputText Txtstart;
		protected System.Web.UI.WebControls.TextBox txtSlipNo;
		protected System.Web.UI.WebControls.TextBox TextSelect;
		
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);	
	
		string uid;
		protected System.Web.UI.WebControls.TextBox TextBox7;
		protected System.Web.UI.WebControls.TextBox txtTempQty1;
		protected System.Web.UI.WebControls.TextBox txtTempQty2;
		protected System.Web.UI.WebControls.TextBox txtTempQty3;
		protected System.Web.UI.WebControls.TextBox txtTempQty5;
		protected System.Web.UI.WebControls.TextBox txtTempQty6;
		protected System.Web.UI.WebControls.TextBox txtTempQty7;
		protected System.Web.UI.WebControls.TextBox txtTempQty4;
		protected System.Web.UI.WebControls.TextBox txtTempQty8;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty8;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpQty1;
		protected System.Web.UI.WebControls.Label lblMessage;
		static string[] ProductType = new string[12];
		static string[] ProductName = new string[12];
		static string[] ProductPack = new string[12];
		static string[] ProductQty = new string[12];
		ArrayList arrSlip = new ArrayList();
		public int flag = 0;
		public static string Cust_ID = "";

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
		public bool  cashMemo = false;
		public bool  date = false;
		public bool  vehicle = false;
		
		static string msg="";
		protected System.Web.UI.WebControls.TextBox txtRemark;
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.DropDownList DropCashDiscType;
		protected System.Web.UI.WebControls.TextBox txtCashDisc;
		protected System.Web.UI.WebControls.TextBox txtVAT;
		protected System.Web.UI.WebControls.RadioButton No;
		protected System.Web.UI.WebControls.RadioButton Yes;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtVatRate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtVatValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSlipTemp;
		protected System.Web.UI.HtmlControls.HtmlInputHidden SlipNo;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.HtmlControls.HtmlInputText lblCreditLimit;
		protected System.Web.UI.HtmlControls.HtmlInputHidden lblVehicleNo;
		protected System.Web.UI.WebControls.DropDownList DropVehicleNo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtcustinfo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden temptext;
		protected System.Web.UI.HtmlControls.HtmlInputHidden lblTinNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempDelinfo;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.TextBox txtChallanNo;
		protected System.Web.UI.WebControls.TextBox txtChallanDate;
		protected System.Web.UI.WebControls.Panel PanChallan;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempminmax;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempInvoiceDate;
		public bool  address = false;

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
				txtMessage.Text =(Session["Message"].ToString());
				txtVatRate.Value  = (Session["VAT_Rate"].ToString());  
				//getSlips(); //Mahesh
				//GetProducts();//Mahesh
				//FetchData();
			}
			catch(Exception ex)
			{				
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:pageload"+ ex.Message+"  EXCEPTION "+"   "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(tempDelinfo.Value=="Yes")
			{
				DeleteTheRec();
			}
			if(!IsPostBack)
			{
				try
				{
                    TextBox1.Attributes.Add("readonly", "readonly");
                    TxtCrLimit1.Attributes.Add("readonly", "readonly");
                    lblInvoiceDate.Attributes.Add("readonly", "readonly");
                    txtChallanDate.Attributes.Add("readonly", "readonly");
                    lblPlace.Attributes.Add("readonly", "readonly");
                    lblDueDate.Attributes.Add("readonly", "readonly");
                    lblCurrBalance.Attributes.Add("readonly", "readonly");
                    lblCreditLimit.Attributes.Add("readonly", "readonly");
                    txtAvStock1.Attributes.Add("readonly", "readonly");
                    txtRate1.Attributes.Add("readonly", "readonly");
                    txtAmount1.Attributes.Add("readonly", "readonly");
                    txtAvStock2.Attributes.Add("readonly", "readonly");
                    txtRate2.Attributes.Add("readonly", "readonly");
                    txtAmount2.Attributes.Add("readonly", "readonly");
                    txtAvStock3.Attributes.Add("readonly", "readonly");
                    txtRate3.Attributes.Add("readonly", "readonly");
                    txtAmount3.Attributes.Add("readonly", "readonly");
                    txtAvStock4.Attributes.Add("readonly", "readonly");
                    txtRate4.Attributes.Add("readonly", "readonly");
                    txtAmount4.Attributes.Add("readonly", "readonly");
                    txtAvStock5.Attributes.Add("readonly", "readonly");
                    txtRate5.Attributes.Add("readonly", "readonly");
                    txtAmount5.Attributes.Add("readonly", "readonly");
                    txtAvStock6.Attributes.Add("readonly", "readonly");
                    txtRate6.Attributes.Add("readonly", "readonly");
                    txtAmount6.Attributes.Add("readonly", "readonly");
                    txtAvStock7.Attributes.Add("readonly", "readonly");
                    txtRate7.Attributes.Add("readonly", "readonly");
                    txtAmount7.Attributes.Add("readonly", "readonly");
                    txtAvStock8.Attributes.Add("readonly", "readonly");
                    txtRate8.Attributes.Add("readonly", "readonly");
                    txtAmount8.Attributes.Add("readonly", "readonly");
                    txtGrandTotal.Attributes.Add("readonly", "readonly");
                    txtMessage.Attributes.Add("readonly", "readonly");
                    txtVAT.Attributes.Add("readonly", "readonly");
                    txtNetAmount.Attributes.Add("readonly", "readonly");



                    checkPrevileges();
					txtChallanDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					lblInvoiceDate.Text=GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());  
					//lblEntryTime.Text=DateTime.Now.ToString();
                    lblEntryTime.Text= DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm:ss tt");
                    lblEntryBy.Text =Session["User_Name"].ToString();
					DropDownList[] ProductType={DropType1, DropType2, DropType3, DropType4, DropType5, DropType6, DropType7, DropType8 };
					InventoryClass  obj=new InventoryClass ();
					SqlDataReader SqlDtr;
					string sql;
					//getCustomerinfo();
					GetNextInvoiceNo();
					PanChallan.Visible=false;
					#region Fetch the Product Types and fill in the ComboBoxes
					sql="select distinct Category from Products";
					for(int j=0;j<ProductType.Length;j++)
					{
						SqlDtr = obj.GetRecordSet(sql); 
						while(SqlDtr.Read())
						{				
							ProductType[j].Items.Add(SqlDtr.GetValue(0).ToString());  
						}					
						SqlDtr.Close();
					}
					#endregion

					#region Fetch All Customer ID and fill in the ComboBox
					sql="select Cust_Name from Customer order by Cust_Name";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropCustName.Items.Add (SqlDtr.GetValue(0).ToString ());				
					}
					SqlDtr.Close ();		
					#endregion

					#region Fetch All SalesMan and Fill in the ComboBox
					sql = "Select Emp_Name from Employee where Designation ='Sales Man'";
					SqlDtr = obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						DropUnderSalesMan.Items.Add (SqlDtr.GetValue(0).ToString ());				
					}
					SqlDtr.Close ();		
					#endregion
					//FetchData();
					/////////////////////////////////////////////////////////
					txtSlipNo.ToolTip = "Please Select Customer";
					getSlips(); 
					GetProducts();                    
					//FillSlipArray();
					//FetchData();
				}

				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:pageload.   EXCEPTION: "+ ex.Message+"  User_ID: "+uid);   
				}
				//////////////////////////////////////////////////////////

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
            lblInvoiceDate.Text = Request.Form["lblInvoiceDate"] == null ? GenUtil.str2DDMMYYYY(System.DateTime.Now.ToShortDateString()) : Request.Form["lblInvoiceDate"].ToString().Trim();
        }

		/// <summary>
		/// This method is used to check the slip no is used or not with the help of java script on run time.
		/// </summary>
		public void FillSlipArray()
		{
			SqlDataReader rdr=null;
			dbobj.SelectQuery("select Slip_No from sales_master where slip_no>0 order by slip_no",ref rdr);
			while(rdr.Read())
			{
				arrSlip.Add(rdr["Slip_No"].ToString());
			}
			rdr.Close();
			//MessageBox.Show(arrSlip.Count.ToString());
		}

		/// <summary>
		/// Get the slip no from Sales_master table.
		/// </summary>
		public void getSlips()
		{
			InventoryClass obj = new InventoryClass();
			SqlDataReader SqlDtr = null;
			string sql = "Select Slip_No from Sales_Master where slip_no>0";
			//dbobj.SelectQuery(sql,ref SqlDtr); 
			SqlDtr = obj.GetRecordSet(sql);
			string temp = "";
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					temp = temp + SqlDtr.GetValue(0).ToString()+"#";
				}
			}
			SqlDtr.Close ();
			txtSlipTemp.Value = temp;
		}

		/// <summary>
		/// This method checks the pre print template file and disables the pre print button.
		/// </summary>
		public void checkPrePrint()
		{
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
				Button1.Enabled = false; 
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
			string Module="4";
			string SubModule="4";
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
			if(Add_Flag=="0" && Edit_Flag=="0" && View_flag =="0")
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			if(Edit_Flag=="0" )
				btnEdit.Enabled=false; 
			if(Add_Flag=="0")
			{
				btnSave.Enabled = false; 
				Button1.Enabled = false; 
			}
			#endregion				
		}

		/// <summary>
		/// Fetch the customer information and put it into a hiddent fields for java script.
		/// </summary>
		public void FetchData()
		{
			InventoryClass obj=new InventoryClass ();
			SqlDataReader rdr=null;
			SqlDataReader rdr1=null;
			SqlDataReader rdr2=null;
			SqlDataReader rdr3=null;
			string str1="";
			string str2 ="";

			DateTime duedate;
			string duedatestr ="";
			IEnumerator enum1=DropCustName.Items.GetEnumerator();
			enum1.MoveNext(); 
			while(enum1.MoveNext())
			{
				string s=enum1.Current.ToString(); 
				dbobj.SelectQuery("select City,CR_Days,Curr_Credit,Cust_ID  from Customer where Cust_Name='"+s+"'",ref rdr);
				if(rdr.Read())
				{
					duedate=DateTime.Now.AddDays(System.Convert.ToDouble(rdr["CR_Days"]));
					duedatestr=(duedate.ToShortDateString());
					str1 = str1+s.Trim()+"~"+rdr["City"].ToString().Trim()+"~"+GenUtil.str2DDMMYYYY(duedatestr.Trim())+"~"+GenUtil.strNumericFormat(rdr["Curr_Credit"].ToString().Trim())+"~"+rdr["Cust_ID"].ToString().Trim()+"~";
					dbobj.SelectQuery("select top 1 Balance,BalanceType from customerledgertable where CustID="+rdr["Cust_ID"]+" order by EntryDate Desc", ref rdr1);
					if(rdr1.Read())
					{
						str1 = str1+GenUtil.strNumericFormat(rdr1["Balance"].ToString().Trim())+"~"+rdr1["BalanceType"].ToString().Trim()+"~";	
					}
					else
					{
						str1 = str1+"0"+"~"+" "+"~";	
					}
					rdr1.Close();

					dbobj.SelectQuery("select Start_No,End_No  from  Slip where Cust_ID='"+rdr["Cust_ID"]+"'",ref rdr2);
					if(rdr2.Read())
					{
						if(rdr2["Start_No"].ToString()!="" && rdr2["End_No"].ToString()!="")
						{  
							str1 = str1+rdr2["Start_No"].ToString().Trim()+"~"+rdr2["End_No"].ToString().Trim()+"#"; 
						}
						else
						{ 
							str1 = str1+"0~0#";
						}
					}
					else
					{
						str1 = str1+"0~0#";
					} 
					rdr2.Close();

					dbobj.SelectQuery("Select * from Customer_Vehicles where Cust_ID="+rdr["Cust_ID"],ref rdr3);  
					if(rdr3.HasRows)
					{
						str2 = str2 + s+"~";
						while(rdr3.Read())
						{
							if(!rdr3["Vehicle_No1"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No1"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No2"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No2"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No3"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No3"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No4"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No4"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No5"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No5"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No6"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No6"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No7"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No7"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No8"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No8"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No9"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No9"].ToString().Trim()+"~";
							if(!rdr3["Vehicle_No10"].ToString().Trim().Equals(""))
								str2 = str2 + rdr3["Vehicle_No10"].ToString().Trim()+"~";
						}
						str2 = str2 + "#";
					}
					rdr3.Close(); 
				}
				rdr.Close();
			}
			TxtVen.Value =str1; 
			lblVehicleNo.Value = str2;
			//Response.Write(str2); 
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
			this.DropSalesType.SelectedIndexChanged += new System.EventHandler(this.DropSalesType_SelectedIndexChanged);
			this.DropCustName.SelectedIndexChanged += new System.EventHandler(this.DropCustName_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This method is used to fill the product name with the help of given Product Type.
		/// </summary>
		public void Type_Changed(DropDownList ddType,DropDownList ddProd,DropDownList ddPack)
		{
			try
			{
				ddProd.Items.Clear(); 
				ddProd.Items.Add("Select");
				ddPack.Items.Clear();
				if(ddType.SelectedItem.Value.ToUpper() == "FUEL")
					ddPack.Enabled=false;
				else
				{
					ddPack.Enabled=true;
					ddPack.Items.Add("Select");
				}
				if(ddType.SelectedIndex ==0)
					return;
			
				InventoryClass obj = new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;

				#region Fetch Product Name and fill in the ComboBox
				sql="select distinct Prod_Name from Products where Category='"+ ddType.SelectedItem.Value + "'";
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					ddProd.Items.Add(SqlDtr.GetValue(0).ToString());   
				}
				SqlDtr.Close (); 			
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:Type_Changed().   EXCEPTION: "+ ex.Message+"  User_ID: "+uid);   
			}
		}

		/// <summary>
		/// This method is used to fatch product pack and sales rate according to given product name and fill into the dropdownlist.
		/// </summary>
		public void Prod_Changed(DropDownList ddType, DropDownList ddProd,DropDownList ddPack,TextBox txtPurRate)
		{
			ddPack.Items.Clear(); 
			txtPurRate.Text="";
			if(ddProd.SelectedIndex==0)
				return;
			
			InventoryClass obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
			#region Fetch Package Types Regarding Product Name			
			sql="Select Pack_Type from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"' and Category='"+ddType.SelectedItem.Value+"'";
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read ())
			{
				ddPack.Items.Add(SqlDtr.GetValue(0).ToString ());
			}
			SqlDtr.Close();
			#endregion

			#region Fetch Sales Rate Regarding Product Name		
			sql= "select top 1 Sal_Rate from Price_Updation where Prod_ID=(select  Prod_ID from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"' and Pack_Type='"+ ddPack.SelectedItem.Value +"') order by eff_date desc";
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read ())
			{
				txtPurRate.Text=SqlDtr.GetValue(0).ToString();
			}
			SqlDtr.Close();
			#endregion
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		private string GetString(string str,string spc)
		{
			if(str.Length>spc.Length)
				return str;
			else
				return str+spc.Substring(0,spc.Length-str.Length)+"  ";			
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6,ref int len7,ref int len8,ref int len9,ref int len10,ref int len11,ref int len12,ref int len13,ref int len14,ref int len15,ref int len16,ref int len17,ref  int len18,ref int len19,ref int len20,ref int len21,ref int len22,ref int len23,ref int len24,ref int len25,ref int len26,ref int len27,ref int len28,ref  int len29,ref  int len30,ref int len31,ref int len32,ref int len33,ref int len34,ref  int len35,ref int len36,ref int len37,ref int len38,ref int len39,ref int len40,ref  int len41,ref int len42)
		{
			while(rdr.Read())
			{
				if(rdr["InvoiceNo"].ToString().Trim().Length>len1)
					len1=rdr["InvoiceNo"].ToString().Trim().Length;					
				if(rdr["ToDate"].ToString().Trim().Length>len2)
					len2=rdr["ToDate"].ToString().Trim().Length;	
				if(rdr["CustomerName"].ToString().Trim().Length>len3)
					len3=rdr["CustomerName"].ToString().Trim().Length;	
				if(rdr["Place"].ToString().Trim().Length>len4)
					len4=rdr["Place"].ToString().Trim().Length;
				if(rdr["DueDate"].ToString().Trim().Length>len5)
					len5=rdr["DueDate"].ToString().Trim().Length;		
				if(rdr["CurrentBalance"].ToString().Trim().Length>len6)
					len6=rdr["CurrentBalance"].ToString().Trim().Length;	
				if(rdr["VehicleNo"].ToString().Trim().Length>len7)
					len7=rdr["VehicleNo"].ToString().Trim().Length;	
				if(rdr["Prod1"].ToString().Trim().Length>len8)
					len8=rdr["Prod1"].ToString().Trim().Length;			
				if(rdr["Prod2"].ToString().Trim().Length>len9)
					len9=rdr["Prod2"].ToString().Trim().Length;	
				if(rdr["Prod3"].ToString().Trim().Length>len10)
					len10=rdr["Prod3"].ToString().Trim().Length;					
				if(rdr["Prod4"].ToString().Trim().Length>len11)
					len11=rdr["Prod4"].ToString().Trim().Length;	
				if(rdr["Prod5"].ToString().Trim().Length>len12)
					len12=rdr["Prod5"].ToString().Trim().Length;		
				if(rdr["Prod6"].ToString().Trim().Length>len13)
					len13=rdr["Prod6"].ToString().Trim().Length;		
				if(rdr["Prod7"].ToString().Trim().Length>len41)
					len41=rdr["Prod7"].ToString().Trim().Length;		
				if(rdr["Prod8"].ToString().Trim().Length>len42)
					len42=rdr["Prod8"].ToString().Trim().Length;	
	
				if(rdr["Qty1"].ToString().Trim().Length>len14)
					len14=rdr["Qty1"].ToString().Trim().Length;		
				if(rdr["Qty2"].ToString().Trim().Length>len15)
					len15=rdr["Qty2"].ToString().Trim().Length;		
				if(rdr["Qty3"].ToString().Trim().Length>len16)
					len16=rdr["Qty3"].ToString().Trim().Length;		
				if(rdr["Qty4"].ToString().Trim().Length>len17)
					len17=rdr["Qty4"].ToString().Trim().Length;		
				if(rdr["Qty5"].ToString().Trim().Length>len18)
					len18=rdr["Qty5"].ToString().Trim().Length;		
				if(rdr["Qty6"].ToString().Trim().Length>len19)
					len19=rdr["Qty6"].ToString().Trim().Length;		
				if(rdr["Qty7"].ToString().Trim().Length>len20)
					len20=rdr["Qty7"].ToString().Trim().Length;		
				if(rdr["Qty8"].ToString().Trim().Length>len21)
					len21=rdr["Qty8"].ToString().Trim().Length;		
				if(rdr["Rate1"].ToString().Trim().Length>len22)
					len22=rdr["Rate1"].ToString().Trim().Length;	
				if(rdr["Rate2"].ToString().Trim().Length>len23)
					len23=rdr["Rate2"].ToString().Trim().Length;		
				if(rdr["Rate3"].ToString().Trim().Length>len24)
					len24=rdr["Rate3"].ToString().Trim().Length;		
				if(rdr["Rate4"].ToString().Trim().Length>len25)
					len25=rdr["Rate4"].ToString().Trim().Length;		
				if(rdr["Rate5"].ToString().Trim().Length>len26)
					len26=rdr["Rate5"].ToString().Trim().Length;		
				if(rdr["Rate6"].ToString().Trim().Length>len27)
					len27=rdr["Rate6"].ToString().Trim().Length;		
				if(rdr["Rate7"].ToString().Trim().Length>len28)
					len28=rdr["Rate7"].ToString().Trim().Length;		
				if(rdr["Rate8"].ToString().Trim().Length>len29)
					len29=rdr["Rate8"].ToString().Trim().Length;	
	
				if(rdr["Amt1"].ToString().Trim().Length>len30)
					len30=rdr["Amt1"].ToString().Trim().Length;		
				if(rdr["Amt2"].ToString().Trim().Length>len31)
					len31=rdr["Amt2"].ToString().Trim().Length;		
				if(rdr["Amt3"].ToString().Trim().Length>len32)
					len32=rdr["Amt3"].ToString().Trim().Length;		
				if(rdr["Amt4"].ToString().Trim().Length>len33)
					len33=rdr["Amt4"].ToString().Trim().Length;		
				if(rdr["Amt5"].ToString().Trim().Length>len34)
					len34=rdr["Amt5"].ToString().Trim().Length;		
				if(rdr["Amt6"].ToString().Trim().Length>len35)
					len35=rdr["Amt6"].ToString().Trim().Length;		
				if(rdr["Amt7"].ToString().Trim().Length>len36)
					len36=rdr["Amt7"].ToString().Trim().Length;		
				if(rdr["Amt8"].ToString().Trim().Length>len37)
					len37=rdr["Amt8"].ToString().Trim().Length;		

				if(rdr["Total"].ToString().Trim().Length>len38)
					len38=rdr["Total"].ToString().Trim().Length;		
				if(rdr["Promo"].ToString().Trim().Length>len39)
					len39=rdr["Promo"].ToString().Trim().Length;		
				if(rdr["Remarks"].ToString().Trim().Length>len40)
					len40=rdr["Remarks"].ToString().Trim().Length;		
			}
		}
		
		/// <summary>
		/// This method is not used.
		/// </summary>
		private string GetString(string str,int maxlen,string spc)
		{
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
		}
	
		/// <summary>
		/// This method is not used.
		/// </summary>
		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
		}

		/// <summary>
		/// This method writes a line to a report file.
		/// </summary>
		public void Write2File(StreamWriter sw, string info)
		{
			sw.WriteLine(info);
		}

		/// <summary>
		/// This method saves the sales details into Sales_Details table.
		/// </summary>
		public void Save(string ProdName,string PackType, string Qty, string Rate,string Amount,string Qty1,string Invoice_date,string Amt)
		{
			InventoryClass obj=new InventoryClass();
			obj.Product_Name=ProdName ;
			obj.Package_Type=PackType ;
			obj.Qty=Qty;
			obj.QtyTemp = Qty1; 
			obj.Rate=Rate;
			obj.Amount=Amount;
			obj.Product_Name1="";
			//obj.Inv_date = Invoice_date;
			obj.Invoice_Date = System.Convert.ToDateTime(Invoice_date);
			obj.NetAmount=Amt;
			obj.Sales_Type=DropSalesType.SelectedItem.Text;
			if(lblInvoiceNo.Visible==true)
			{
				obj.Invoice_No=lblInvoiceNo.Text;
				obj.InsertSalesDetail();
			}	
			else
			{
				obj.Invoice_No=dropInvoiceNo.SelectedItem.Value;
				obj.InsertSalesDetail(); 
			}
		}


		public void compareSlipNo()
		{
			InventoryClass obj=new InventoryClass(); 
			SqlDataReader  SqlDtr;
			string sql;
		
			sql= "select Start_No,End_No  from  Slip where Cust_ID='"+TextBox1 +"'";  
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read ())
			{
				Txtstart.Value=SqlDtr.GetValue(0).ToString();
				TxtEnd.Value=SqlDtr.GetValue(1).ToString();
			}
			SqlDtr.Close();
		}

        public void GetProductsType()
        {
           
            try
            {
                InventoryClass obj = new InventoryClass();
                InventoryClass obj1 = new InventoryClass();
                SqlDataReader SqlDtr;
                string sql;
                //SqlDataReader rdr = null;
                int count = 0;
                int count1 = 0;
                dbobj.ExecuteScalar("Select Count(Prod_id) from  products", ref count);
                dbobj.ExecuteScalar("select count(distinct p.Prod_ID) from products p, Price_Updation pu where p.Prod_id = pu.Prod_id", ref count1);
                
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
                #endregion
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:cashbilling.aspx,Method:GetProducts().  EXCEPTION: " + ex.Message + "  user " + uid);
            }

        }
        /// <summary>
        /// Inserts data in controls containing in Product Details
        /// </summary>
        private void InsertDataInControls()
        {
            DropProd1.Items.Clear();
            DropProd2.Items.Clear();
            DropProd3.Items.Clear();
            DropProd4.Items.Clear();
            DropProd5.Items.Clear();
            DropProd6.Items.Clear();
            DropProd7.Items.Clear();
            DropProd8.Items.Clear();

            GetProducts();

            string[] strArrayOne = new string[] { "" };
            strArrayOne = temptext.Value.Split(',');

            DropProd1.Items.Add("Select");
            DropProd2.Items.Add("Select");
            DropProd3.Items.Add("Select");
            DropProd4.Items.Add("Select");
            DropProd5.Items.Add("Select");
            DropProd6.Items.Add("Select");
            DropProd7.Items.Add("Select");
            DropProd8.Items.Add("Select");

            for (int i = 0; i <= strArrayOne.Length - 1; i++)
            {
                string[] strArraytwo = new string[] { "" };
                strArraytwo = strArrayOne[i].Split(':');

                if (DropType1.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {                        
                        DropProd1.Items.Add(strArraytwo[1]);

                        DropPack1.Enabled = false;
                        txtAvStock1.Enabled = false;
                    }
                    else
                    {
                        
                        DropProd1.Items.Add(strArraytwo[1]);
                    }                    
                }
                if (DropType2.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {                       
                        DropProd2.Items.Add(strArraytwo[1]);

                        DropPack2.Enabled = false;
                        txtAvStock2.Enabled = false;
                    }
                    else
                    {                        
                        DropProd2.Items.Add(strArraytwo[1]);
                    }
                }
                if (DropType3.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {

                        DropProd3.Items.Add(strArraytwo[1]);

                        DropPack3.Enabled = false;
                        txtAvStock3.Enabled = false;
                    }
                    else
                    {
                        DropProd3.Items.Add(strArraytwo[1]);
                    }
                }
                if (DropType4.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {
                        DropProd4.Items.Add(strArraytwo[1]);

                        DropPack4.Enabled = false;
                        txtAvStock4.Enabled = false;
                    }
                    else
                    {
                        DropProd4.Items.Add(strArraytwo[1]);
                    }
                }
                if (DropType5.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {
                        DropProd5.Items.Add(strArraytwo[1]);

                        DropPack5.Enabled = false;
                        txtAvStock5.Enabled = false;
                    }
                    else
                    {
                        DropProd5.Items.Add(strArraytwo[1]);
                    }
                }
                if (DropType6.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {
                        DropProd6.Items.Add(strArraytwo[1]);

                        DropPack6.Enabled = false;
                        txtAvStock6.Enabled = false;
                    }
                    else
                    {
                        DropProd6.Items.Add(strArraytwo[1]);
                    }
                }
                if (DropType7.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {
                        DropProd7.Items.Add(strArraytwo[1]);

                        DropPack7.Enabled = false;
                        txtAvStock7.Enabled = false;
                    }
                    else
                    {
                        DropProd7.Items.Add(strArraytwo[1]);
                    }
                }
                if (DropType8.SelectedValue == strArraytwo[0])
                {
                    if (strArraytwo[0] == "Fuel")
                    {
                        DropProd8.Items.Add(strArraytwo[1]);

                        DropPack8.Enabled = false;
                        txtAvStock8.Enabled = false;
                    }
                    else
                    {
                        DropProd8.Items.Add(strArraytwo[1]);
                    }
                }
            }
        }

        /// <summary>
        /// It calls the save_updateInvoice() function to save or update the Invoice Details and calls the reportmaking4() fucntion to creates the print file and calls the print() code fire the print of passing file.
        /// </summary>
        private void btnSave_Click(object sender, System.EventArgs e)
		{                        
            StringBuilder erroMessage = new StringBuilder();
            if (txtSlipNo.Visible == true && txtSlipNo.Text == string.Empty)
            {
                erroMessage.Append("- Please Enter Slip No.");
                erroMessage.Append("\n");
            }
            if (DropUnderSalesMan.SelectedIndex == 0)
            {
                erroMessage.Append("- Please select Sales Man");
                erroMessage.Append("\n");
            }
            if (DropCustName.SelectedIndex == 0)
            {
                erroMessage.Append("- Please select Customer Name");
                erroMessage.Append("\n");
            }
            if (txtVehicleNo.Text == string.Empty)
            {
                erroMessage.Append("- Please Enter Vehicle No");
                erroMessage.Append("\n");
            }
            if (DropType1.SelectedIndex == 0)
            {
                erroMessage.Append("- Please select atleast one Product Type");
                erroMessage.Append("\n");
            }
            if (txtQty1.Text == string.Empty)
            {
                erroMessage.Append("- Please Fill Quantity");
                erroMessage.Append("\n");
            }
            if (erroMessage.Length > 0)
            {
                MessageBox.Show(erroMessage.ToString());
                InsertDataInControls();
                return;
            }

            InventoryClass obj=new InventoryClass();            
            SqlDataReader  SqlDtr=null;
			string sql;
            //***************
            

            if (DropSalesType.SelectedItem.Text.Equals("Credit Card Sale"))
			{
				dbobj.SelectQuery("select * from Organisation",ref SqlDtr);
				if(SqlDtr.Read())
				{
					if(SqlDtr["CreditCard"].ToString().Equals(""))
					{
						MessageBox.Show("Please Create The Credit Card Sale A/C");
						return;
					}
				}
			}
			if(DropSalesType.SelectedItem.Text.Equals("Fleet Card Sale"))
			{
				dbobj.SelectQuery("select * from Organisation",ref SqlDtr);
				if(SqlDtr.Read())
				{
					if(SqlDtr["FleetCard"].ToString().Equals(""))
					{
						MessageBox.Show("Please Create The Fleet Card Sale A/C");
						return;
					}
				}
			}
			//***************
			if(DropSalesType.SelectedItem.Text.Equals("Slip Wise Credit"))
			{
				double NetAmt=double.Parse(txtNetAmount.Text);
				//double CrAmt=double.Parse(lblCreditLimit.Value);
				double CrAmt=0;
				sql= "select Curr_Credit from Customer where Cust_Name='"+DropCustName.SelectedItem.Text.Trim()+"'";  
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read ())
				{
					CrAmt=System.Convert.ToDouble(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
				if(CrAmt != 0)
				{
					if(NetAmt > CrAmt)
					{
						MessageBox.Show("Credit Limit is less than Net Amount");
						return;
					}
				}
			}
			
			Button1.Enabled = false;     
			save_updateInvoive(); 
			if(flag == 0)
			{
				reportmaking4();
				//this code hide by Mahesh, stop the print command. 
				//				string home_drive = Environment.SystemDirectory;
				//				home_drive = home_drive.Substring(0,2); 
				//				print(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\SalesInvoiceReport.txt");
				Clear();
				clear1();
				if(lblInvoiceNo.Visible==true)
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:btnSave_Click - InvoiceNo : " + lblInvoiceNo.Text  );
				else
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:btnSave_Click - InvoiceNo : " + dropInvoiceNo.SelectedItem.Text  );
				GetNextInvoiceNo();
                GetProducts();                
				getSlips();
				//FetchData();
				lblInvoiceNo.Visible=true;
				dropInvoiceNo.Visible=false;
				btnEdit.Visible=true;
				//lblSlipNo.Visible=false;
				//txtSlipNo.Visible=false;
				Button1.Enabled = true;  
			}
			else
			{
				flag = 0;
				checkPrevileges();
				checkPrePrint(); 
				return;
			}
			checkPrevileges();
			checkPrePrint();
           
        }


        /// <summary>
        /// To insert or update to sales_master and sales_details tables with the help of stored procedures.
        /// </summary>
        public void save_updateInvoive()
		{
			SqlDataReader rdr = null;
			InventoryClass  obj=new InventoryClass();
			try
			{
				if(lblInvoiceNo.Visible==true)
				{				
					int count = 0;
					// This part of code is use to solve the double click problem, Its checks the sales invoice no. and display the popup, that it is saved.
					dbobj.ExecuteScalar("Select count(Invoice_No) from Sales_Master where Invoice_No = "+lblInvoiceNo.Text.Trim(),ref count);
					if(count > 0)
					{
						MessageBox.Show("Sales Invoice Saved");
						Clear();
						clear1();
						GetNextInvoiceNo();
                        GetProducts();                        
						getSlips();
						lblInvoiceNo.Visible=true; 
						dropInvoiceNo.Visible=false;
						btnEdit.Visible=true;
						//lblSlipNo.Visible=false;
						//txtSlipNo.Visible=false;
						btnSave.Enabled = true;
						Button1.Enabled = true; 
						flag = 1;
						return ;
					}
				}
			
				// if slip no. is visible then saves it else, do not save the slip no.
				if(txtSlipNo.Visible==true)
				{
					string a=txtSlipNo.Text.ToString();
					if(a.Trim().Equals("") || a.Trim().Equals(" "))
					{
						MessageBox.Show("Please Enter Slip No");
						flag = 1;
						return;
					}
					
					//SqlDataReader rdr=null;
					//int 
					//dbobj.ExecuteScalar("select * from slip where cust_id=(select cust_id from customer where cust_name='"+DropCustName.SelectedItem.Text+"')",ref rdr);
					//if(rdr.Read())
					//{
						
					//}
					//if(int.Parse(a) < int.Parse(Txtstart .Value) ||  int.Parse(txtSlipNo.Text.ToString()) > int.Parse(TxtEnd.Value))
					//{
					//essageBox.Show("Slip Number is not Valid"); 
					//	flag = 1;
					//	return;
					//}
					if(lblInvoiceNo.Visible==true)
					{
						dbobj.SelectQuery("select  Slip_No from sales_master where Slip_No='"+a.Trim()+"'", ref rdr);
						if(rdr.Read())
						{
							MessageBox.Show("Slip No. "+a.Trim()+" already used");   
							flag = 1;
							return;
					 
						}
						rdr.Close();
					}
					else
					{
						string no="";
						dbobj.SelectQuery("select slip_no from sales_master where  Invoice_No = "+dropInvoiceNo.SelectedItem.Value,ref rdr);
						if(rdr.Read())
						{
							no = rdr.GetValue(0).ToString();  
						}
						rdr.Close();
						if(!a.Trim().Equals(no))
						{
							dbobj.SelectQuery("select slip_no from sales_master where  Slip_no = '"+a.Trim()+"'",ref rdr );
							if(rdr.Read())
							{
								MessageBox.Show("Slip No. "+a.Trim()+" already used");   
								flag = 1;
								return;
							}
							rdr.Close();
						}
					}
					
					/*if(float.Parse( TxtCrLimit.Value) <float.Parse( txtNetAmount.Text))
					{  
						MessageBox.Show("Credit Limit is less than Net Amount");
						flag = 1;
						return;
					}*/
					
					obj.Invoice_Date = System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(lblInvoiceDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()) ; 
					//obj.Invoice_Date=DateTime.Now;
					obj.Sales_Type=DropSalesType.SelectedItem.Value;
					obj.Under_SalesMan =DropUnderSalesMan.SelectedItem.Value;
					obj.Customer_Name =DropCustName.SelectedItem.Value ;
					obj.Place =lblPlace.Value.ToString();
					if(DropVehicleNo.Visible ==true)
						obj.Vehicle_No=DropVehicleNo.SelectedItem.Text  ;
					else
						obj.Vehicle_No=txtVehicleNo.Text ;

					obj.Grand_Total =txtGrandTotal.Text ;
					if(txtDisc.Text.Trim() =="")
						obj.Discount ="0.0";
					else
						obj.Discount =txtDisc.Text;
					obj.Discount_Type=DropDiscType.SelectedItem.Value ;
					obj.Net_Amount =txtNetAmount.Text ;
					obj.Promo_Scheme=txtPromoScheme.Text;
					obj.Remerk =txtRemark.Text;
					obj.Entry_By =lblEntryBy.Text ;
					obj.Entry_Time =DateTime.Parse(lblEntryTime .Text);
					if(txtCashDisc.Text.Trim() =="")
						obj.Cash_Discount  ="0.0";
					else
						obj.Cash_Discount  = txtCashDisc.Text.Trim() ;
					obj.Cash_Disc_Type =DropCashDiscType.SelectedItem.Value ;
					obj.VAT_Amount = txtVAT.Text.Trim();   
					if(txtSlipNo.Text=="")
						obj.Slip_No="0"; 
					else
						obj.Slip_No =txtSlipNo.Text; 

					obj.Cr_Plus="0";
					obj.Dr_Plus=txtNetAmount.Text;	
					obj.Credit_Limit = lblCreditLimit.Value.ToString();   
					if(txtChallanNo.Text=="")
						obj.ChallanNo="";
					else
						obj.ChallanNo=txtChallanNo.Text;
					if(PanChallan.Visible==true)
						obj.ChallanDate=GenUtil.str2MMDDYYYY(txtChallanDate.Text);
					else
						obj.ChallanDate="";
					// If the ID label is visible then saves the invoice otherwise update.
					if(lblInvoiceNo.Visible==true)
					{
						obj.Invoice_No =lblInvoiceNo.Text;
						obj.InsertSalesMaster();
						obj.UpdateCustomerBalance();
					}
					else
					{
						obj.Invoice_No=dropInvoiceNo.SelectedItem.Value;   
						UpdateProductQty();
						int CustomerID=0;
						dbobj.ExecuteScalar("Select Cust_ID from  customer where cust_name='"+DropCustName.SelectedItem.Text+"'",ref CustomerID);
						if(Cust_ID!=CustomerID.ToString())
						{
							int xx=0;
							dbobj.Insert_or_Update("delete from Sales_Master where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",ref xx);
							dbobj.Insert_or_Update("delete from Accountsledgertable where Particulars='Sales Invoice ("+dropInvoiceNo.SelectedItem.Text+")'",ref xx);
							dbobj.Insert_or_Update("delete from Customerledgertable where Particular='Sales Invoice ("+dropInvoiceNo.SelectedItem.Text+")'",ref xx);
							dbobj.Insert_or_Update("delete from LedgDetails where Cust_id='"+Cust_ID+"' and Bill_No='"+dropInvoiceNo.SelectedItem.Text+"'",ref xx);
							dbobj.Insert_or_Update("delete from Invoice_Transaction where Cust_id='"+Cust_ID+"' and Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",ref xx);
							obj.InsertSalesMaster();
						}
						else
							obj.UpdateSalesMaster();
						CustomerUpdate();
					}
					string temp;
					DropDownList[] ProdType = {DropType1,DropType2,DropType3,DropType4,DropType5,DropType6,DropType7,DropType8};
					HtmlInputHidden[] ProdName={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
					HtmlInputHidden[] PackType={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
					TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
					TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
					TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8};			
					TextBox[]  Quantity = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8 };
					double Count=0;
					for(int i=0;i<ProdName.Length;i++)
					{
						if(Rate[i].Text!=""||Rate[i].Text!="0")
							Count++;
					}
					for(int j=0;j<ProdName.Length;j++)
					{
						if(Rate[j].Text==""||Rate[j].Text=="0")
							continue;
						//**************
						double Amt=0,CashDisc=0;
						if(Amount[j].Text!="")
						{
							if(txtCashDisc.Text!="")
							{
								if(Amount[j].Text!="")
									Amt=double.Parse(Amount[j].Text)-(double.Parse(Amount[j].Text)*double.Parse(txtCashDisc.Text)/100);
								CashDisc=Amt;
							}
							if(Yes.Checked)
							{
								Amt=Amt*double.Parse(txtVatRate.Value)/100;
								CashDisc=CashDisc-Amt;
							}
							if(txtDisc.Text!="")
								CashDisc=CashDisc-(double.Parse(txtDisc.Text)/Count);
							if(CashDisc==0)
								CashDisc=double.Parse(Amount[j].Text);
						}

						//**************
						if(lblInvoiceNo.Visible==true || Quantity[j].Text=="")
						{
							temp = Qty[j].Text.ToString(); 
						}
						else
						{
							//temp = System.Convert.ToString(System.Convert.ToDouble(Qty[j].Text)-System.Convert.ToDouble(Quantity[j].Text)); 
							temp = Qty[j].Text; 
						}
						//Save(ProdName[j].Value,PackType[j].Value,Qty[j].Text.ToString(),Rate[j].Text.ToString (),Amount[j].Text.ToString (),temp,GenUtil.str2MMDDYYYY(lblInvoiceDate.Text.ToString()),GenUtil.strNumericFormat(CashDisc.ToString()));
						Save(ProdName[j].Value,PackType[j].Value,Qty[j].Text.ToString(),Rate[j].Text.ToString (),Amount[j].Text.ToString (),temp,GenUtil.str2MMDDYYYY(lblInvoiceDate.Text.ToString())+" "+DateTime.Now.TimeOfDay.ToString(),GenUtil.strNumericFormat(CashDisc.ToString()));
						if(lblInvoiceNo.Visible==false)
							StockMaster(ProdType[j].SelectedItem.Text,ProdName[j].Value,PackType[j].Value);
					}
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:save_updateInvoice()"+" Sales Invoice for  Invoice No."+obj.Invoice_No+" ,"+"for Customer Name  "+obj.Customer_Name+",  "+" Under Salesman "+obj.Under_SalesMan+" and NetAmount  "+obj.Net_Amount+"  is Saved "+" userid "+"   "+uid);
					if(lblInvoiceNo.Visible==true)
					{
						MessageBox.Show("Sales Invoice Saved");
					}
					else
					{
						SeqStockMaster();
						MessageBox.Show("Sales Invoice Updated");
					}
				}
				else 
				{
					//obj.Invoice_Date = System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(lblInvoiceDate.Text));
					obj.Invoice_Date = System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(lblInvoiceDate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
					//obj.Invoice_Date = DateTime.Now;
					obj.Sales_Type=DropSalesType.SelectedItem.Value;
					obj.Under_SalesMan =DropUnderSalesMan.SelectedItem.Value;
					obj.Customer_Name =DropCustName.SelectedItem.Value ;
					obj.Place =lblPlace.Value.ToString();
					if(DropVehicleNo.Visible ==true)
						obj.Vehicle_No=DropVehicleNo.SelectedItem.Text  ;
					else
						obj.Vehicle_No=txtVehicleNo.Text ;
					obj.Grand_Total =txtGrandTotal.Text ;
					if(txtDisc.Text=="")
						obj.Discount ="0.0";
					else
						obj.Discount =txtDisc.Text;
					obj.Discount_Type=DropDiscType.SelectedItem.Value ;
					obj.Net_Amount =txtNetAmount.Text ;
					obj.Promo_Scheme=txtPromoScheme.Text;
					obj.Remerk =txtRemark.Text;
					obj.Entry_By =lblEntryBy.Text ;
					obj.Entry_Time =DateTime.Parse(lblEntryTime .Text);
					if(txtCashDisc.Text.Trim() =="")
						obj.Cash_Discount  ="0.0";
					else
						obj.Cash_Discount  = txtCashDisc.Text.Trim() ;
					obj.Cash_Disc_Type =DropCashDiscType.SelectedItem.Value ;
					obj.VAT_Amount = txtVAT.Text.Trim();   
					if(txtSlipNo.Text=="")
						obj.Slip_No="0"; 
					else
						obj.Slip_No =txtSlipNo.Text; 
					obj.Cr_Plus="0";
					obj.Dr_Plus=txtNetAmount.Text;	
					obj.Credit_Limit = lblCreditLimit.Value.ToString(); 
					if(txtChallanNo.Text=="")
						obj.ChallanNo="";
					else
						obj.ChallanNo=txtChallanNo.Text;
					if(PanChallan.Visible==true)
						obj.ChallanDate=GenUtil.str2MMDDYYYY(txtChallanDate.Text);
					else
						obj.ChallanDate="";
					if(lblInvoiceNo.Visible==true)
					{
						obj.Invoice_No =lblInvoiceNo.Text;
						obj.InsertSalesMaster();
						obj.UpdateCustomerBalance();
					}
					else
					{
						obj.Invoice_No=dropInvoiceNo.SelectedItem.Value;
						UpdateProductQty();
						int CustomerID=0;
						dbobj.ExecuteScalar("Select Cust_ID from  customer where cust_name='"+DropCustName.SelectedItem.Text+"'",ref CustomerID);
						if(Cust_ID!=CustomerID.ToString())
						{
							int xx=0;
							dbobj.Insert_or_Update("delete from Sales_Master where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",ref xx);
							dbobj.Insert_or_Update("delete from Accountsledgertable where Particulars='Sales Invoice ("+dropInvoiceNo.SelectedItem.Text+")'",ref xx);
							dbobj.Insert_or_Update("delete from Customerledgertable where Particular='Sales Invoice ("+dropInvoiceNo.SelectedItem.Text+")'",ref xx);
							dbobj.Insert_or_Update("delete from LedgDetails where Cust_id='"+Cust_ID+"' and Bill_No='"+dropInvoiceNo.SelectedItem.Text+"'",ref xx);
							dbobj.Insert_or_Update("delete from Invoice_Transaction where Cust_id='"+Cust_ID+"' and Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",ref xx);
							obj.InsertSalesMaster();
						}
						else
							obj.UpdateSalesMaster();
						CustomerUpdate();
					}	
					string temp;
					DropDownList[] ProdType = {DropType1,DropType2,DropType3,DropType4,DropType5,DropType6,DropType7,DropType8};
					HtmlInputHidden[] ProdName={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
					HtmlInputHidden[] PackType={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
					TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
					TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
					TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8};			
					TextBox[]  Quantity = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8 };
					double Count=0;
					for(int i=0;i<ProdName.Length;i++)
					{
						if(Rate[i].Text!="")
							Count++;
					}
					for(int j=0;j<ProdName.Length ;j++)
					{
						if(Rate[j].Text==""||Rate[j].Text=="0")
							continue;
						//**************
						double Amt=0,CashDisc=0;
						if(Amount[j].Text!="")
						{
							if(txtCashDisc.Text!="")
							{
								if(Amount[j].Text!="")
									Amt=double.Parse(Amount[j].Text)-(double.Parse(Amount[j].Text)*double.Parse(txtCashDisc.Text)/100);
								CashDisc=Amt;
							}
							if(Yes.Checked)
							{
								Amt=Amt*double.Parse(txtVatRate.Value)/100;
								CashDisc=CashDisc+Amt;
							}
							if(txtDisc.Text!="")
								CashDisc=CashDisc-(double.Parse(txtDisc.Text)/Count);
							if(CashDisc==0)
								CashDisc=double.Parse(Amount[j].Text);
						}
						
						//**************
						if(lblInvoiceNo.Visible==true || Quantity[j].Text =="")
						{
							temp = Qty[j].Text; 
						}
						else
						{
							//temp = System.Convert.ToString(System.Convert.ToDouble(Qty[j].Text)-System.Convert.ToDouble(Quantity[j].Text)); 
							temp = Qty[j].Text; 
						}
						//Save(ProdName[j].Value,PackType[j].Value,Qty[j].Text.ToString(),Rate[j].Text.ToString (),Amount[j].Text.ToString (),temp,GenUtil.str2MMDDYYYY(lblInvoiceDate.Text.ToString()),GenUtil.strNumericFormat(CashDisc.ToString()));
						Save(ProdName[j].Value,PackType[j].Value,Qty[j].Text.ToString(),Rate[j].Text.ToString (),Amount[j].Text.ToString (),temp,GenUtil.str2DDMMYYYY(lblInvoiceDate.Text.ToString())+" "+DateTime.Now.TimeOfDay.ToString(),GenUtil.strNumericFormat(CashDisc.ToString()));
						if(lblInvoiceNo.Visible==false)
							StockMaster(ProdType[j].SelectedItem.Text,ProdName[j].Value,PackType[j].Value);
					}
					if(lblInvoiceNo.Visible==true)
					{
						MessageBox.Show("Sales Invoice Saved");
					}
					else
					{
						SeqStockMaster();
						MessageBox.Show("Sales Invoice Updated");
					}
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:save_updateInvoice()"+" Fuel Purchase Invoice for  Invoice No."+obj.Invoice_No+" ,"+"for Vender Name  "+obj.Vendor_Name+  "on Date "+obj.Vendor_Name+" and NetAmount  "+obj.Net_Amount+"  is Saved "+" userid "+"   "+"   "+uid);
				}	
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoise.aspx,Method:save_updateInvoice(),Class:InventoryClass"+"  Sales Invoise for  Invoice No."+obj.Invoice_No+" ,"+"for Customer Name  "+obj.Customer_Name+ "  Under Salesman "+obj.Under_SalesMan+" and NetAmount  "+obj.Net_Amount+"  is Saved "+"  EXCEPTION  "+ex.Message+" userid "+"   "+"   "+uid);
			}
		}

		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void clear1()
		{
			//DropPack1.SelectedIndex=0;
			//DropPack2.SelectedIndex=0;
			//DropPack3.SelectedIndex=0;
			//DropPack4.SelectedIndex=0;
			//DropPack5.SelectedIndex=0;
			//DropPack6.SelectedIndex=0;
			//DropPack7.SelectedIndex=0;
			//DropPack8.SelectedIndex=0;

			DropDownList[] ProdType={DropType1, DropType2, DropType3, DropType4, DropType5, DropType6, DropType7, DropType8};
			DropDownList[] ProdName={DropProd1, DropProd2, DropProd3, DropProd4, DropProd5, DropProd6, DropProd7, DropProd8};
			DropDownList[] PackType={DropPack1, DropPack2, DropPack3, DropPack4, DropPack5, DropPack6, DropPack7, DropPack8};
			
			TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
			TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
			TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8}; 			
			TextBox[]  AvStock = {txtAvStock1,txtAvStock2,txtAvStock3,txtAvStock4,txtAvStock5,txtAvStock6,txtAvStock7,txtAvStock8};

			for (int i=0;i<ProdType.Length;i++) 
			{
				ProdType[i].Enabled = true;
				ProdName[i].Enabled = true;
				PackType[i].Enabled = true;
				Qty[i].Enabled = true;
				Rate[i].Enabled = true;
				Amount[i].Enabled = true;
				AvStock[i].Enabled = true;
			}
			lblInvoiceDate.Text=GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());
			#region Clear All Products Details
			DropType1.SelectedIndex=0;
			DropType2.SelectedIndex=0;
			DropType3.SelectedIndex=0;
			DropType4.SelectedIndex=0;
			DropType5.SelectedIndex=0;
			DropType6.SelectedIndex=0;
			DropType7.SelectedIndex=0;
			DropType8.SelectedIndex=0;
			DropProd1.SelectedIndex=0;
			DropProd2.SelectedIndex=0;
			DropProd3.SelectedIndex=0;
			DropProd4.SelectedIndex=0;
			DropProd5.SelectedIndex=0;
			DropProd6.SelectedIndex=0;
			DropProd7.SelectedIndex=0;
			DropProd8.SelectedIndex=0;
			DropPack1.Items.Clear();  
			DropPack2.Items.Clear();
			DropPack3.Items.Clear();
			DropPack4.Items.Clear();
			DropPack5.Items.Clear();
			DropPack6.Items.Clear();
			DropPack7.Items.Clear();
			DropPack8.Items.Clear();
			//DropPack1.SelectedIndex=0;
			//DropPack2.SelectedIndex=0;
			//DropPack3.SelectedIndex=0;
			//DropPack4.SelectedIndex=0;
			//DropPack5.SelectedIndex=0;
			//DropPack6.SelectedIndex=0;
			//DropPack7.SelectedIndex=0;
			//DropPack8.SelectedIndex=0;
			txtQty1.Text="";
			txtQty2.Text="";
			txtQty3.Text="";
			txtQty4.Text="";
			txtQty5.Text="";
			txtQty6.Text="";
			txtQty7.Text="";
			txtQty8.Text="";
			txtRate1.Text="";
			txtRate2.Text="";
			txtRate3.Text="";
			txtRate4.Text="";
			txtRate5.Text="";
			txtRate6.Text="";
			txtRate7.Text="";
			txtRate8.Text="";
			txtAmount1.Text=""; 
			txtAmount1.Text=""; 
			txtAmount2.Text=""; 
			txtAmount3.Text=""; 
			txtAmount4.Text=""; 
			txtAmount5.Text=""; 
			txtAmount6.Text=""; 
			txtAmount7.Text=""; 
			txtAmount8.Text=""; 
			#endregion

			#region Clear All Av. Stock TextBoxes
			txtAvStock1.Text="";
			txtAvStock2.Text="";
			txtAvStock3.Text="";
			txtAvStock4.Text="";
			txtAvStock5.Text="";
			txtAvStock6.Text="";
			txtAvStock7.Text="";
			txtAvStock8.Text="";
			#endregion

			#region Clear Hidden TextBoxex
			txtProdName1.Value=""; 
			txtProdName2.Value=""; 
			txtProdName3.Value=""; 
			txtProdName4.Value=""; 
			txtProdName5.Value=""; 
			txtProdName6.Value=""; 
			txtProdName7.Value=""; 
			txtProdName8.Value=""; 
			txtPack1.Value="";
			txtPack2.Value="";
			txtPack3.Value="";
			txtPack4.Value="";
			txtPack5.Value="";
			txtPack6.Value="";
			txtPack7.Value="";
			txtPack8.Value="";
			txtTempQty1.Text="";  
			txtTempQty2.Text="";
			txtTempQty3.Text="";
			txtTempQty4.Text="";
			txtTempQty5.Text="";
			txtTempQty6.Text="";
			txtTempQty7.Text="";
			txtTempQty8.Text="";
			tmpQty1.Value = "";
			tmpQty2.Value = "";
			tmpQty3.Value = "";
			tmpQty4.Value = "";
			tmpQty5.Value = "";
			tmpQty6.Value = "";
			tmpQty7.Value = "";
			tmpQty8.Value = "";
			lblTinNo.Value="";
			#endregion
			for(int i=0;i<ProductType.Length;i++)
			{
				ProductType[i]="";
				ProductName[i]="";
				ProductPack[i]="";
				ProductQty[i]="";
			}
		}
		
		/// <summary>
		/// To insert the values in the duplicate sales invoice table with the help of stored procedures.
		/// </summary>
		public void SaveForReport()
		{
			Sysitem.Classes.InventoryClass obj=new InventoryClass();
			obj.InvoiceNo =lblInvoiceNo.Text.ToString();
			obj.ToDate= lblInvoiceDate.Text;
			obj.CustomerName=DropCustName.SelectedItem.Value.ToString();
			obj.Place =lblPlace .Value.ToString();
			obj.DueDate=lblDueDate.Value.ToString();
			obj.CurrentBalance =lblCurrBalance.Value.ToString();
			obj.VehicleNo=txtVehicleNo.Text.ToString();
			obj.Prod1=txtProdName1.Value.ToString(); 
			obj.Prod2=txtProdName2.Value.ToString();
			obj.Prod3=txtProdName3.Value.ToString();
			obj.Prod4=txtProdName4.Value.ToString();
			obj.Prod5=txtProdName5.Value.ToString();
			obj.Prod6=txtProdName6.Value.ToString();
			obj.Prod7=txtProdName7.Value.ToString();
			obj.Prod8=txtProdName8.Value.ToString();
			obj.Qty1=txtQty1.Text.ToString();
			obj.Qty2=txtQty2.Text .ToString();
			obj.Qty3 =txtQty3.Text .ToString();
			obj.Qty4=txtQty4.Text.ToString();  
			obj.Qty5=txtQty5.Text.ToString();
			obj.Qty6 =txtQty6.Text.ToString();
			obj.Qty7=txtQty7.Text.ToString();
			obj.Qty8=txtQty8.Text.ToString();
			obj.Rate1=txtRate1.Text.ToString();
			obj.Rate2 =txtRate2.Text.ToString();
			obj.Rate3 =txtRate3.Text.ToString();
			obj.Rate4 =txtRate4.Text.ToString();
			obj.Rate5=txtRate5.Text.ToString();
			obj.Rate6=txtRate6.Text.ToString();
			obj.Rate7=txtRate7.Text.ToString();
			obj.Rate8=txtRate8.Text.ToString();
			obj.Amt1 =txtAmount1.Text.ToString();
			obj.Amt2=txtAmount2 .Text.ToString();
			obj.Amt3=txtAmount3 .Text.ToString();
			obj.Amt4=txtAmount4.Text.ToString();
			obj.Amt5=txtAmount5.Text.ToString();
			obj.Amt6 =txtAmount6.Text.ToString();
			obj.Amt7=txtAmount7.Text.ToString();
			obj.Amt8=txtAmount8.Text.ToString();  
			obj.Total =txtNetAmount.Text.ToString();
			obj.Promo=txtPromoScheme.Text.ToString();
			obj.Remarks=txtRemark.Text.ToString() ;
			obj.InsertSalesInvoiceDuplicate();
		}

		/// <summary>
		/// Sales Type is credit then display the Text field to enter the slip no. else hide it.
		/// </summary>
		private void DropSalesType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropSalesType.SelectedIndex==3)
			{
				lblSlipNo.Visible=true;
				txtSlipNo.Visible=true;
				PanChallan.Visible=false;
				Requiredfieldvalidator2.Visible = true;
			}
				//			else if(DropSalesType.SelectedIndex==0 || DropSalesType.SelectedIndex==1)
				//			{
				//				lblSlipNo.Visible=false;
				//				txtSlipNo.Visible=false;
				//				PanChallan.Visible=true;
				//				Requiredfieldvalidator2.Visible = false;
				//			}
			else
			{
				lblSlipNo.Visible=false;
				txtSlipNo.Visible=false;
				PanChallan.Visible=true;
				Requiredfieldvalidator2.Visible = false; 
			}
		}

		/// <summary>
		/// To Fetch the All Invoice Number and fill in Combo.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			clear1();
			Clear();
			lblInvoiceNo.Visible=false;
			btnEdit.Visible=false;
			dropInvoiceNo.Visible=true;
			btnSave.Enabled = true;
			Button1.Enabled = true;  
			checkPrePrint();
			string[] In_no=new string[99999];//**
			int i=0,j=0;//**
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr;
			string sql;

			#region Fetch the All Invoice Number and fill in Combo
			dropInvoiceNo.Items.Clear();  
			dropInvoiceNo.Items.Add("Select"); 
			sql="select Invoice_No from Sales_Master order by Invoice_No";
			SqlDtr=obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				//dropInvoiceNo.Items.Add(SqlDtr.GetValue(0).ToString());
				In_no[i]=SqlDtr.GetValue(0).ToString();
				i++;
			}
			SqlDtr.Close ();		
			for(j=0;j<i;j++)
			{
				if(In_no[j].Length != 6)
					dropInvoiceNo.Items.Add(In_no[j]);
			}
			#endregion
		}

		/// <summary>
		/// To retrieve the all values from the database according to selected value in the dropdownlist.
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
					//Clear();
					clear1();
					DropDownList[] ProdType={DropType1, DropType2, DropType3, DropType4, DropType5, DropType6, DropType7, DropType8};
					DropDownList[] ProdName={DropProd1, DropProd2, DropProd3, DropProd4, DropProd5, DropProd6, DropProd7, DropProd8};
					DropDownList[] PackType={DropPack1, DropPack2, DropPack3, DropPack4, DropPack5, DropPack6, DropPack7, DropPack8};
			
					HtmlInputHidden[] Name={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
					HtmlInputHidden[] Type={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
					TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
					TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
					TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8}; 			
					TextBox[]  AvStock = {txtAvStock1,txtAvStock2,txtAvStock3,txtAvStock4,txtAvStock5,txtAvStock6,txtAvStock7,txtAvStock8};
					TextBox[]  tempQty = {txtTempQty1, txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8}; 
					HtmlInputHidden[] tmpQty = {tmpQty1,tmpQty2,tmpQty3,tmpQty4,tmpQty5,tmpQty6,tmpQty7,tmpQty8};

					InventoryClass  obj=new InventoryClass ();
					SqlDataReader SqlDtr;
					string sql,sql1;
					SqlDataReader rdr=null;
					int i=0;
					#region Get Data from Sales Master Table regarding Invoice No.
					sql="select * from Sales_Master where Invoice_No='"+ dropInvoiceNo.SelectedItem.Value +"'" ;
					SqlDtr=obj.GetRecordSet(sql); 
					if(SqlDtr.Read())
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
						tempInvoiceDate.Value=GenUtil.str2DDMMYYYY(strDate);
						DropSalesType.SelectedIndex=(DropSalesType.Items.IndexOf((DropSalesType.Items.FindByValue (SqlDtr.GetValue(2).ToString()))));
						DropUnderSalesMan.SelectedIndex=(DropUnderSalesMan.Items.IndexOf((DropUnderSalesMan.Items.FindByValue(SqlDtr.GetValue(4).ToString()))));
						if(getCustomerVehicles(SqlDtr["Cust_ID"].ToString()) == true)
						{
							DropVehicleNo.SelectedIndex = DropVehicleNo.Items.IndexOf(DropVehicleNo.Items.FindByValue(SqlDtr.GetValue(5).ToString().Trim()));   
						}
						else
						{
							txtVehicleNo.Text=SqlDtr.GetValue(5).ToString();
						}
						txtGrandTotal.Text=SqlDtr.GetValue(6).ToString();
						txtGrandTotal.Text = GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()); 
						txtDisc.Text=SqlDtr.GetValue(7).ToString(); 
						txtDisc.Text = GenUtil.strNumericFormat(txtDisc.Text.ToString()); 
						DropDiscType.SelectedIndex= DropDiscType.Items.IndexOf((DropDiscType.Items.FindByValue(SqlDtr.GetValue(8).ToString())));
						txtNetAmount.Text =SqlDtr.GetValue(9).ToString(); 
						txtNetAmount.Text = GenUtil.strNumericFormat(txtNetAmount.Text.ToString());
						txtPromoScheme.Text= SqlDtr.GetValue(10).ToString(); 
						txtRemark.Text=SqlDtr.GetValue(11).ToString();  
						lblEntryBy.Text=SqlDtr.GetValue(12).ToString();  
						lblEntryTime.Text= SqlDtr.GetValue(13).ToString();  
						//if(SqlDtr.GetValue(2).ToString().Equals("Credit"))
						//	txtSlipNo.Visible = true;
						//else
						//	txtSlipNo.Visible = false;
 
						txtSlipNo.Text= SqlDtr.GetValue(14).ToString();
						SlipNo.Value = txtSlipNo.Text;
						txtCashDisc.Text=SqlDtr.GetValue(15).ToString(); 
						txtCashDisc.Text = GenUtil.strNumericFormat(txtCashDisc.Text.ToString()); 
						DropCashDiscType.SelectedIndex= DropCashDiscType.Items.IndexOf((DropCashDiscType.Items.FindByValue(SqlDtr.GetValue(16).ToString())));
						txtVAT.Text =  SqlDtr.GetValue(17).ToString();
						txtChallanNo.Text=SqlDtr["ChallanNo"].ToString();
						if(!SqlDtr["ChallanDate"].ToString().Equals("1/1/1900"))
							txtChallanDate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["ChallanDate"].ToString()));
						else
							txtChallanDate.Text="";
						//if(SqlDtr["Sales_Type"].ToString().Equals("Credit Card Sale") || SqlDtr["Sales_Type"].ToString().Equals("Fleet Card Sale"))
						if(SqlDtr["Sales_Type"].ToString().Equals("Slip Wise Credit"))
						{
							PanChallan.Visible=false;
							txtSlipNo.Visible=true;
							lblSlipNo.Visible=true;
						}
						else
						{
							PanChallan.Visible=true;
							txtSlipNo.Visible=false;
							lblSlipNo.Visible=false;
						}
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
					sql="select Cust_Name, City,CR_Days,Op_Balance,Curr_Credit,c.cust_id from Customer as c, sales_master as s where c.Cust_ID= s.Cust_ID and s.Invoice_No='"+dropInvoiceNo.SelectedValue +"'";
					SqlDtr=obj.GetRecordSet(sql);
					Cust_ID="0";
					if(SqlDtr.Read())
					{
				
						DropCustName.SelectedIndex=DropCustName.Items.IndexOf(DropCustName.Items.FindByValue(SqlDtr.GetValue(0).ToString()));
						lblPlace.Value=SqlDtr.GetValue(1).ToString();
						DateTime duedate=DateTime.Now.AddDays(System.Convert.ToDouble(SqlDtr.GetValue(2).ToString()));
						string duedatestr=(duedate.ToShortDateString());
						lblDueDate.Value =GenUtil.str2DDMMYYYY(duedatestr);
						lblCurrBalance.Value=GenUtil.strNumericFormat(SqlDtr.GetValue(3).ToString());
						TxtCrLimit.Value = SqlDtr.GetValue(4).ToString();
						lblCreditLimit.Value  = SqlDtr.GetValue(4).ToString();
						Cust_ID=SqlDtr["Cust_ID"].ToString();
					}
					SqlDtr.Close();
					sql="select top 1 balance,balancetype  from CustomerLedgerTable as c, sales_master as s where c.CustID= s.Cust_ID and s.Invoice_No='"+dropInvoiceNo.SelectedValue +"' order by entrydate desc";
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.Read())
					{
						lblCurrBalance.Value=GenUtil.strNumericFormat(SqlDtr.GetValue(0).ToString())+" "+SqlDtr.GetValue(1).ToString();
					}
					SqlDtr.Close();
					#endregion
					#region Get Customer Slip
					sql="select start_no, end_no from slip,  sales_master as sm where slip.Cust_ID = sm.Cust_ID and Invoice_No='"+dropInvoiceNo.SelectedValue +"'";
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.Read())
					{
						Txtstart.Value = SqlDtr.GetValue(0).ToString();
						TxtEnd.Value  =  SqlDtr.GetValue(1).ToString();
					}
					else
					{
						Txtstart.Value = "0";
						TxtEnd.Value  =  "0";
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
						ProdType[i].Enabled = true;
						ProdName[i].Enabled = true;
						PackType[i].Enabled = true;
						Qty[i].Enabled = true;
						Rate[i].Enabled = true;
						Amount[i].Enabled = true;
						AvStock[i].Enabled = true;
						ProdType[i].SelectedIndex=ProdType[i].Items.IndexOf(ProdType[i].Items.FindByValue(SqlDtr.GetValue(0).ToString ()));
						Type_Changed(ProdType[i] ,ProdName[i] ,PackType[i] );  
						ProdName[i].SelectedIndex=ProdName[i].Items.IndexOf(ProdName[i].Items.FindByValue(SqlDtr["Prod_Name"].ToString ()));
						Prod_Changed(ProdType[i], ProdName[i] ,PackType[i] ,Rate[i]);    
						Name[i].Value=SqlDtr.GetValue(1).ToString();   
						PackType[i].SelectedIndex=PackType[i].Items.IndexOf(PackType[i].Items.FindByValue(SqlDtr.GetValue(2).ToString ()));
						Type[i].Value=SqlDtr.GetValue(2).ToString();   
						Qty[i].Text=SqlDtr.GetValue(3).ToString();
						tempQty[i].Text   = Qty[i].Text ;
						tmpQty[i].Value  = SqlDtr.GetValue(3).ToString();  
						Rate[i].Text=SqlDtr.GetValue(4).ToString();
						Amount[i].Text=SqlDtr.GetValue(5).ToString();
						//*************
						ProductType[i]=SqlDtr.GetValue(0).ToString ();
						ProductName[i]=SqlDtr.GetValue(1).ToString ();
						ProductPack[i]=SqlDtr.GetValue(2).ToString ();
						ProductQty[i]=SqlDtr.GetValue(3).ToString();
						//*************
						sql1="select top 1 Closing_Stock from Stock_Master where productid="+SqlDtr.GetValue(6).ToString()+" order by stock_date desc";
						dbobj.SelectQuery(sql1,ref rdr); 
						if(rdr.Read())
						{
							//AvStock [i].Text =rdr["Closing_Stock"]+" "+SqlDtr.GetValue(7).ToString();
							AvStock [i].Text =Math.Round(double.Parse(rdr["Closing_Stock"].ToString()),2)+" "+SqlDtr.GetValue(7).ToString();
						}	
						else
						{
							AvStock [i].Text ="0"+" "+SqlDtr.GetValue(7).ToString();
						}
						Qty[i].ToolTip = "Actual Available Stock = "+Qty[i].Text.ToString()+" + "+ AvStock[i].Text.ToString();
						rdr.Close();
						i++;
					}
					/* Hide this code by Mahesh on 04.10.007 - because sales more products on edit time.
					while(i<8)
					{
						ProdType[i].SelectedIndex=0;
						ProdType[i].Enabled = false;
                        				
						ProdName[i].SelectedIndex=0;
						ProdName[i].Enabled = false;

						PackType[i].Items.Clear();
						PackType[i].SelectedIndex=0;
						PackType[i].Enabled = false;
                        

						Qty[i].Text="";
						Qty[i].Enabled = false; 
						tempQty[i].Text ="";
						tempQty[i].Enabled = false;

						tmpQty[i].Value = "";

						Rate[i].Text="";
						Rate[i].Enabled = false;
						Amount[i].Text="";
						Amount[i].Enabled = false;
						AvStock [i].Text="";
						AvStock [i].Enabled = false;
						i++;
					}
					*/
					SqlDtr.Close();
					#endregion
					GetSlipNo();
				
				}
				//CreateLogFiles.ErrorLog("Form:Sales Invoisee.aspx,Method:dropInvoiceNo_SelectedIndexChanged " +" Sales invoice is viewed for invoice no: "+dropInvoiceNo.SelectedItem.Value.ToString()+" userid "+"   "+"   "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Sales Invoice.aspx,Method:dropInvoiceNo_SelectedIndexChanged " +" Sales invoise is update for invoise no: "+dropInvoiceNo.SelectedItem.Value.ToString()+" EXCEPTION  "+ex.Message+"  userid "+"   "+"   "+uid);
			}
		}

		/// <summary>
		/// This method is used to fatch the sales rate according to given product name and type and fill into the dropdownlist.
		/// </summary>
		public void Pack_Changed(DropDownList ddProd,DropDownList ddPack,TextBox txtPurRate)
		{
			InventoryClass obj=new InventoryClass();
			SqlDataReader  SqlDtr;
			string sql;

			#region Fetch Sales Rate Regarding Product Name		
			sql= "select top 1 Sal_Rate from Price_Updation where Prod_ID=(select  Prod_ID from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"' and Pack_Type='"+ ddPack.SelectedItem.Value +"') order by eff_date desc";
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read ())
			{
				txtPurRate.Text=SqlDtr.GetValue(0).ToString();
			}
			SqlDtr.Close();
			#endregion			
		}

		/// <summary>
		/// This displays the customer information afterb selecttion of a customer, as well display the vehicle nos of a customer if entered by the Customer vehicle entry form into drop down if present else display the text field to enter the vehicle no.
		/// </summary>
		private void DropCustName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// This displays the customer information afterb selecttion of a customer, as well display the vehicle nos of a customer if entered by the Customer vehicle entry form into drop down if present else display the text field to enter the vehicle no.
			
			try
			{
				if(DropCustName.SelectedIndex == 0)
				{
					MessageBox.Show("Please Select Customer Name"); 
					return;
				}
				string cust_id = "";
				lblPlace.Value = "";
				lblDueDate.Value = "";
				TxtCrLimit.Value = "";
				lblCreditLimit.Value = "";
				lblCurrBalance.Value = "";
				Txtstart.Value = "";
				TxtEnd.Value = "";
				txtSlipNo.Text="";
				SlipNo.Value="";
				SqlDataReader SqlDtr = null;
				DateTime duedate = DateTime.Now ;
				string duedatestr = "";
				//dbobj.SelectQuery("Select City, Cr_Days, Curr_Credit, Cust_ID from Customer where Cust_Name='"+DropCustName.SelectedItem.Text.Trim()+"'",ref SqlDtr); 
				dbobj.SelectQuery("Select City, Cr_Days, Curr_Credit, Cust_ID,Tin_No from Customer where Cust_Name='"+DropCustName.SelectedItem.Text.Trim()+"'",ref SqlDtr); 
				if(SqlDtr.Read())
				{
					lblPlace.Value  = SqlDtr.GetValue(0).ToString();
					duedate=DateTime.Now.AddDays(System.Convert.ToDouble(SqlDtr["CR_Days"]));
					duedatestr=(duedate.ToShortDateString());
					lblDueDate.Value  = GenUtil.str2DDMMYYYY(duedatestr);  
					TxtCrLimit.Value  = GenUtil.strNumericFormat(SqlDtr.GetValue(2).ToString());  
					lblCreditLimit.Value  = GenUtil.strNumericFormat(SqlDtr.GetValue(2).ToString());
					cust_id = SqlDtr.GetValue(3).ToString();
					lblTinNo.Value=SqlDtr.GetValue(4).ToString();
				}
				SqlDtr.Close();

				dbobj.SelectQuery("Select top 1 Balance,BalanceType from CustomerLedgerTable where CustID="+cust_id+" order by EntryDate Desc",ref SqlDtr); 
				if(SqlDtr.Read())
				{
					lblCurrBalance.Value = GenUtil.strNumericFormat(SqlDtr.GetValue(0).ToString())+" "+SqlDtr.GetValue(1).ToString();  
   
				}
				SqlDtr.Close();
				GetSlipNo();
				//txtSlipNo.ToolTip="Start No : "+Txtstart.Value+" , End No : "+TxtEnd.Value;
				getCustomerVehicles(cust_id); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Sales Invoice.aspx,Method:DropCustName_SelectedIndexChanged().  EXCEPTION  "+ex.Message+"  userid "+"   "+"   "+uid);
			}
		}

		/// <summary>
		/// This method is used to fatch the all slip no according to customer Id
		/// Show the information in the tooltip when goes to cursor in slip no textbox.
		/// </summary>
		public void GetSlipNo()
		{
			SqlDataReader SqlDtr=null;
			msg="";
			FillSlipArray();
			dbobj.SelectQuery("Select Start_no, End_No from Slip where Cust_ID = (select cust_id from customer where cust_name='"+DropCustName.SelectedItem.Text.Trim()+"')",ref SqlDtr);
			if(SqlDtr.HasRows)
			{
				//int Flag=0;//*****Mahesh, Date : 23.02.007
				//dbobj.SelectQuery("Select Slip_No from Sales_Master order by slip_no",ref SqlDtr);
				//********
				
				//********
				Txtstart.Value="";
				TxtEnd.Value="";
				int Flag=0;
				while(SqlDtr.Read())
				{
					//if(Flag==0)//*****Mahesh, Date : 23.02.007
					//{
					//*******************
					int count=0;
					int Start=int.Parse(SqlDtr["Start_no"].ToString());
					int End=int.Parse(SqlDtr["End_no"].ToString());
					int TS=End - Start;
					while(Start<=End)
					{
						for(int i=0;i<arrSlip.Count;i++)
						{
							if(Start==int.Parse(arrSlip[i].ToString()))
							{
								count++;
								//break;
							}
							else
							{
								continue;
							}
						}
						Start++;
					}
					//else
					//{
					if(count==TS+1)
						Flag=1;
					else
						Flag=0;
					//break;
					
					
					//*******************
					if(!SqlDtr.GetValue(0).ToString().Trim().Equals("") && Flag==0)
					{
						Txtstart.Value += SqlDtr.GetValue(0).ToString()+":";
						TxtEnd.Value += SqlDtr.GetValue(1).ToString()+"#";
						msg+="StartNo: "+SqlDtr.GetValue(0).ToString()+" EndNo: "+SqlDtr.GetValue(1).ToString()+",";
						//Flag=1;
					}
					//}
				}
				//else
				//Txtstart.Value = "0";
				//txtSlipNo.ToolTip="Start No : "+StartNo[i].ToString()+" , End No : "+EndNo[i].ToString();
				//}
				//if(!SqlDtr.GetValue(1).ToString().Trim().Equals(""))    
				//TxtEnd.Value = SqlDtr.GetValue(1).ToString();
				//else
				//TxtEnd.Value = "0";
						
				
					
			}
			else
			{
				Txtstart.Value = "0:";
				TxtEnd.Value = "0#";
				msg="Slip No Is Not Issue For '"+DropCustName.SelectedItem.Text+"'";
			}
			SqlDtr.Close();
			txtSlipNo.ToolTip=msg;
		}

		public void getCustomerinfo()
		{
			/*	try
				{
	//				if(DropCustName.SelectedIndex == 0)
	//				{
	//					MessageBox.Show("Please Select Customer Name"); 
	//					return;
	//				}
					string cust_id = "";
	//				lblPlace.Value = "";
	//				lblDueDate.Value = "";
	//				TxtCrLimit.Value = "";
	//				lblCreditLimit.Value = "";
	//				lblCurrBalance.Value = "";
	//				Txtstart.Value = "";
	//				TxtEnd.Value = "";
					string str="";
					SqlDataReader SqlDtr = null;
					SqlDataReader rdr = null;
					DateTime duedate = DateTime.Now ;
					string duedatestr = "";
					dbobj.SelectQuery("Select City, Cr_Days, Curr_Credit, Cust_ID,Cust_name from Customer",ref SqlDtr); 
					while(SqlDtr.Read())
					{
						str=str+SqlDtr.GetValue(4).ToString()+":";
						str  = str + SqlDtr.GetValue(0).ToString()+":";
						duedate=DateTime.Now.AddDays(System.Convert.ToDouble(SqlDtr["CR_Days"]));
						duedatestr=(duedate.ToShortDateString());
						str  = str + GenUtil.str2DDMMYYYY(duedatestr)+":";  
						TxtCrLimit.Value  = GenUtil.strNumericFormat(SqlDtr.GetValue(2).ToString());  
						str  = str + GenUtil.strNumericFormat(SqlDtr.GetValue(2).ToString())+":";
						cust_id = SqlDtr.GetValue(3).ToString();	
				
						dbobj.SelectQuery("Select top 1 Balance,BalanceType from CustomerLedgerTable where CustID="+cust_id+" order by EntryDate Desc",ref rdr); 
						if(rdr.Read())
						{
							str = str + GenUtil.strNumericFormat(rdr.GetValue(0).ToString())+":"+rdr.GetValue(1).ToString()+":";  
   
						}
						rdr.Close();
						dbobj.SelectQuery("Select Start_no, End_No from Slip where Cust_ID = "+cust_id,ref rdr);
						if(rdr.HasRows)
						{
							while(rdr.Read())
							{
								if(!rdr.GetValue(0).ToString().Trim().Equals(""))    
									Txtstart.Value = rdr.GetValue(0).ToString();
								else
									Txtstart.Value = "0";

								if(!rdr.GetValue(1).ToString().Trim().Equals(""))    
									TxtEnd.Value = rdr.GetValue(1).ToString();
								else
									TxtEnd.Value = "0";
  
							}
						}
						else
						{
							Txtstart.Value = "0";
							TxtEnd.Value = "0";
  
						}

						rdr.Close();

				
					dbobj.SelectQuery("Select * from Customer_Vehicles where Cust_ID ="+cust_id,ref rdr); 
					if(rdr.HasRows)
					{
						DropVehicleNo.Visible = true;
						txtVehicleNo.Visible = false; 
						RequiredFieldValidator1.Visible = false;
						RequiredFieldValidator3.Visible = true; 
						DropVehicleNo.Items.Clear();
						DropVehicleNo.Items.Add("Select");
						while(rdr.Read())
						{
							if(!rdr.GetValue(2).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(2).ToString())+":";         
							if(!rdr.GetValue(3).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(3).ToString())+":"; 
							if(!rdr.GetValue(4).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(4).ToString())+":"; 
							if(!rdr.GetValue(5).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(5).ToString())+":"; 
							if(!rdr.GetValue(6).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(6).ToString())+":"; 
							if(!rdr.GetValue(7).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(7).ToString())+":"; 
							if(!rdr.GetValue(8).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(8).ToString())+":"; 
							if(!rdr.GetValue(9).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(9).ToString())+":"; 
							if(!rdr.GetValue(10).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(10).ToString())+":"; 
							if(!rdr.GetValue(11).ToString().Trim().Equals(""))
								str=str+(rdr.GetValue(11).ToString())+":"; 
						
						}
						rdr.Close();
						//return true;
					}
					else
					{
						DropVehicleNo.Visible = false;
						txtVehicleNo.Visible  =true;
						RequiredFieldValidator1.Visible = true;
						RequiredFieldValidator3.Visible = false; 
						//txtVehicleNo.Text = "";
						//return false;
					}
					str=str+"#";
				}
				SqlDtr.Close();
				txtcustinfo.Value=str;
				}			
		
				catch(Exception ex)

				{
					CreateLogFiles.ErrorLog("Form:Sales Invoice.aspx,Method:DropCustName_SelectedIndexChanged().  EXCEPTION  "+ex.Message+"  userid "+"   "+"   "+uid);
				}*/
		}

		/// <summary>
		/// To display the vehicle nos of a customer if entered by the Customer vehicle entry form into drop down if present else display the text field to enter the vehicle no. 
		/// </summary>
		public bool getCustomerVehicles(string cust_id)
		{
			try
			{
				SqlDataReader SqlDtr =null;
				dbobj.SelectQuery("Select * from Customer_Vehicles where Cust_ID ="+cust_id,ref SqlDtr); 
				if(SqlDtr.HasRows)
				{
					DropVehicleNo.Visible = true;
					txtVehicleNo.Visible = false; 
					RequiredFieldValidator1.Visible = false;
					RequiredFieldValidator3.Visible = true; 
					DropVehicleNo.Items.Clear();
					DropVehicleNo.Items.Add("Select");
					while(SqlDtr.Read())
					{
						if(!SqlDtr.GetValue(2).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(2).ToString());         
						if(!SqlDtr.GetValue(3).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(3).ToString()); 
						if(!SqlDtr.GetValue(4).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(4).ToString()); 
						if(!SqlDtr.GetValue(5).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(5).ToString()); 
						if(!SqlDtr.GetValue(6).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(6).ToString()); 
						if(!SqlDtr.GetValue(7).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(7).ToString()); 
						if(!SqlDtr.GetValue(8).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(8).ToString()); 
						if(!SqlDtr.GetValue(9).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(9).ToString()); 
						if(!SqlDtr.GetValue(10).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(10).ToString()); 
						if(!SqlDtr.GetValue(11).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add(SqlDtr.GetValue(11).ToString()); 

					}
					SqlDtr.Close();
					return true;
				}
				else
				{
					DropVehicleNo.Visible = false;
					txtVehicleNo.Visible  =true;
					RequiredFieldValidator1.Visible = true;
					RequiredFieldValidator3.Visible = false; 
					txtVehicleNo.Text = "";
					return false;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Sales Invoice.aspx,Method:getCustomerVehicles().  EXCEPTION  "+ex.Message+"  userid "+"   "+"   "+uid);
			}
			return true;
		}
		
		/// <summary>
		/// This method clears the form.
		/// </summary>
		public void Clear()
		{
			tempInvoiceDate.Value="";
			DropSalesType.SelectedIndex=3;
			txtSlipNo.Text="";
			SlipNo.Value="";
			PanChallan.Visible=false;
			lblSlipNo.Visible=true;
			txtSlipNo.Visible=true;
			DropUnderSalesMan.SelectedIndex=0;
			DropCustName.SelectedIndex=0;
			lblPlace .Value="";
			lblDueDate.Value="";
			lblCurrBalance .Value="";
			txtVehicleNo.Text="";
			DropVehicleNo.Visible = false;
			txtVehicleNo.Visible = true;
			txtPromoScheme.Text="";
			txtRemark.Text="";
			txtGrandTotal.Text="";
			lblCreditLimit.Value = "";
			txtDisc.Text="";
			txtNetAmount.Text="";
			DropDiscType.SelectedIndex=0;
			txtVAT.Text = "";
			txtCashDisc.Text = "";
			DropCashDiscType.SelectedIndex = 0;
			Yes.Checked = false;
			No.Checked = true;
			msg="";
			//PanChallan.Visible=false;
			txtChallanDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtChallanNo.Text="";
			tempDelinfo.Value="";
		}
	
		/// <summary>
		/// To retrieve the next invoice no from the database.Inntial starts with 1001.
		/// </summary>
		public void GetNextInvoiceNo()
		{
			//InventoryClass  obj=new InventoryClass ();
			//SqlDataReader SqlDtr;
			//string sql;
			
			#region Fetch the Next Invoice Number
			Find_ID();
			/*
			sql="select max(Invoice_No)+1 from Sales_Master";
			SqlDtr=obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				lblInvoiceNo.Text =SqlDtr.GetValue(0).ToString ();				
				if(lblInvoiceNo.Text=="")
					lblInvoiceNo.Text ="1001";
			}
			SqlDtr.Close ();		
			*/
			#endregion
		}

		/// <summary>
		/// To fatch the next Invoice_No of Sales_Master
		/// To Create By Mahesh Date :- 09.11.06 10:45AM
		/// </summary>
		public void Find_ID()
		{
			InventoryClass obj=new InventoryClass();	
			SqlDataReader SqlDtr=null;
			string[] m=new string[99998];
			string[] m11=new string[99998];
			string sql1="select Invoice_No from Sales_Master";
			SqlDtr=obj.GetRecordSet(sql1);
			int j=0;
			while(SqlDtr.Read())
			{
				m[j] =SqlDtr.GetValue(0).ToString ();				
				j++;
			}
			SqlDtr.Close ();
			int mm=0;
			for(int n=0;n<j;n++)
			{
				if(m[n].Length != 6)
				{
					m11[n]=m[n];
					mm++;
				}
			}
			if(mm > 0)
				lblInvoiceNo.Text=System.Convert.ToString(System.Convert.ToDouble(m11[mm-1])+1);
			if(lblInvoiceNo.Text=="")
				lblInvoiceNo.Text="1001";
		}

		protected bool CheckStock()
		{
			bool ok=false;
			return ok;
		}
		
		/// <summary>
		/// This method is used to sends the text file to print server to print.
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
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,60000);

				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:print"+" Sales Invoise is Print  userid   "+"   "+uid);
				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);

					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					byte[] msg = Encoding.ASCII.GetBytes(fileName+"<EOF>");

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
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:print"+ ane.Message+"  EXCEPTION "+" user "+uid);
				} 
				catch (SocketException se) 
				{
					
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:print"+se.Message+"  EXCEPTION "+" user "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:print"+ es.Message+"  EXCEPTION "+" user "+uid);
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:print"+ ex.Message+"  EXCEPTION "+" user "+uid);
			}
		}


		/// <summary>
		/// This method checks the price updation for all the products is available or not?
		/// </summary>
		public void GetProducts()
		{
			try
			{
				InventoryClass  obj=new InventoryClass ();
				InventoryClass  obj1=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;
				SqlDataReader rdr=null; 
				int count = 0;
				int count1 = 0;
				dbobj.ExecuteScalar("Select Count(Prod_id) from  products",ref count);
				/*
				sql = "select distinct p.Prod_ID,Category,Prod_Name,Pack_Type,Unit from products p, Price_Updation pu where p.Prod_id = pu.Prod_id order by Category,Prod_Name";
				SqlDtr = obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{			
					count1 = count1+1;
				}					
				SqlDtr.Close();
				*/
				dbobj.ExecuteScalar("select count(distinct p.Prod_ID) from products p, Price_Updation pu where p.Prod_id = pu.Prod_id",ref count1);
				if(count != count1)
				{
					lblMessage.Text = "Price updation not available for some products";
				}

				#region Fetch the Product Types and fill in the ComboBoxes
				string str="",MinMax="";
				sql="select distinct p.Prod_ID,Category,Prod_Name,Pack_Type,Unit,minlabel,maxlabel,reorderlable from products p, Price_Updation pu where p.Prod_id = pu.Prod_id order by Category,Prod_Name";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					#region Fetch Sales Rate
					str=str+ SqlDtr["Category"]+":"+SqlDtr["Prod_Name"]+":"+SqlDtr["Pack_Type"];
					sql= "select top 1 Sal_Rate from Price_Updation where Prod_ID="+SqlDtr["Prod_ID"]+" order by eff_date desc";
					//dbobj.SelectQuery(sql,ref rdr); 
					rdr = obj1.GetRecordSet(sql);
					if(rdr.Read())
						str=str+":"+rdr["Sal_Rate"];
					else
						str=str+":0";
					rdr.Close();
					#endregion
					//********
					MinMax=MinMax+SqlDtr["Prod_Name"]+":"+SqlDtr["Pack_Type"]+":"+SqlDtr["minlabel"]+":"+SqlDtr["maxlabel"]+":"+SqlDtr["reorderlable"]+"~";
					//********
					#region Fetch Closing Stock
					sql="select top 1 Closing_Stock from Stock_Master where productid="+SqlDtr["Prod_ID"]+" order by stock_date desc";
					//dbobj.SelectQuery(sql,ref rdr); 
					rdr = obj1.GetRecordSet(sql);
					if(rdr.Read())
						str=str+":"+Math.Round(double.Parse(rdr["Closing_Stock"].ToString()),2)+":"+SqlDtr["Unit"]+",";
					else
						str=str+":0"+":"+SqlDtr["Unit"]+",";
					rdr.Close();
					#endregion
				}
				SqlDtr.Close();
				temptext.Value=str;
				tempminmax.Value=MinMax;
				#endregion		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:GetProducts().  EXCEPTION: "+ ex.Message+"  user "+uid);
			}

		}

		// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		//		public void reportmaking4()
		//		{
		//			try
		//			{
		//				string home_drive = Environment.SystemDirectory;
		//				home_drive = home_drive.Substring(0,2); 
		//				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SalesInvoiceReport.txt";
		//				string info = "";
		//				string strInvNo="";
		//				string strDiscType="";
		//				double disc_amt=0;
		//				string msg ="";
		//				StreamWriter sw = new StreamWriter(path);
		//				// Condensed
		//
		//				sw.Write((char)15);
		//				sw.WriteLine("");
		//				//**********
		//				string des="------------------------------------------------------------------";
		//				string Address=GenUtil.GetAddress();
		//				string[] addr=Address.Split(new char[] {':'},Address.Length);
		//				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
		//				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
		//				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
		//				sw.WriteLine(des);
		//				//**********
		//				sw.WriteLine(GenUtil.GetCenterAddr("=================",des.Length));
		//				sw.WriteLine(GenUtil.GetCenterAddr("SALES INVOICE",des.Length));
		//				sw.WriteLine(GenUtil.GetCenterAddr("=================",des.Length));
		//				if(lblInvoiceNo.Visible==true)
		//					strInvNo= lblInvoiceNo.Text;
		//				else
		//					strInvNo= dropInvoiceNo.SelectedItem.Value;   
		// 				sw.WriteLine(" Invoice No : " + strInvNo+ "                              Date : " + lblInvoiceDate.Text.ToString());
		//				sw.WriteLine(" Customer Name           : " + DropCustName.SelectedItem.Text);
		//				sw.WriteLine(" Place                   :  "+lblPlace.Value);
		//				sw.WriteLine(" Due Date                :  "+lblDueDate.Value);
		//				sw.WriteLine(" Current balance         :  "+lblCurrBalance.Value);
		//				sw.WriteLine(" Credit Limit            :  "+lblCreditLimit.Value);
		//				if(DropVehicleNo.Visible == true)
		//				sw.WriteLine(" Vehicle Number          :  "+DropVehicleNo.SelectedItem.Text);
		//				else
		//				sw.WriteLine(" Vehicle Number          :  "+txtVehicleNo.Text);
		//				//******
		//				sw.WriteLine(" Tin No                  :  "+lblTinNo.Value);
		//				//******
		//				sw.WriteLine("+------------------------------+-----------+----------+----------+");
		//				sw.WriteLine("|Product                       | Quantity  |   Rate   |  Amount  |");
		//				sw.WriteLine("+------------------------------+-----------+----------+----------+");
		//				info = " {0,-30:S} {1,10:F}  {2,10:F} {3,10:F}";
		//				sw.WriteLine(info,txtProdName1.Value ,txtQty1.Text,txtRate1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()) );
		//				sw.WriteLine(info,txtProdName2.Value ,txtQty2.Text,txtRate2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim())); 
		//				sw.WriteLine(info,txtProdName3.Value ,txtQty3.Text,txtRate3.Text,GenUtil.strNumericFormat(txtAmount3.Text.ToString().Trim())); 
		//				sw.WriteLine(info,txtProdName4.Value ,txtQty4.Text,txtRate4.Text,GenUtil.strNumericFormat(txtAmount4.Text.ToString().Trim())); 
		//				sw.WriteLine(info,txtProdName5.Value ,txtQty5.Text,txtRate5.Text,GenUtil.strNumericFormat(txtAmount5.Text.ToString().Trim())); 
		//				sw.WriteLine(info,txtProdName6.Value ,txtQty6.Text,txtRate6.Text,GenUtil.strNumericFormat(txtAmount6.Text.ToString().Trim())); 
		//				sw.WriteLine(info,txtProdName7.Value ,txtQty7.Text,txtRate7.Text,GenUtil.strNumericFormat(txtAmount7.Text.ToString().Trim())); 
		//				sw.WriteLine(info,txtProdName8.Value ,txtQty8.Text,txtRate8.Text,GenUtil.strNumericFormat(txtAmount8.Text.ToString().Trim())); 
		//				sw.WriteLine("+------------------------------+-----------+----------+----------+");
		//				sw.WriteLine("                               Grand Total           : {0,10:F}" , GenUtil.strNumericFormat(txtGrandTotal.Text.ToString() ));
		//				disc_amt=0;
		//				msg ="";
		//				if(txtCashDisc .Text=="")
		//				{
		//					strDiscType="";
		//					msg = "";
		//				}
		//				else
		//				{
		//					disc_amt = System.Convert.ToDouble(txtCashDisc.Text.ToString()); 
		//					strDiscType= DropCashDiscType.SelectedItem.Text;
		//					if(strDiscType.Trim().Equals("%"))
		//					{
		//						double temp =0;
		//						if(txtGrandTotal.Text.Trim() != "")
		//							temp = System.Convert.ToDouble(txtGrandTotal.Text.Trim().ToString());
		// 
		//						disc_amt  = (temp*disc_amt/100);
		//						msg = "("+txtCashDisc.Text.ToString()+strDiscType+")";
		//						
		//					}
		//					else
		//					{
		//						msg ="("+strDiscType+")";
		//					}			
		//				}
		//				sw.WriteLine("                               Cash Discount{0,-8:S} : {1,10:F}" ,msg,GenUtil.strNumericFormat(disc_amt.ToString()));
		//				string Vat_Rate = "";
		//				string amount = "0";
		//				if(Yes.Checked)
		//				{
		//					Vat_Rate = "("+Session["VAT_Rate"].ToString()+"%)";
		//					amount = txtVAT.Text.Trim();  
		// 
		//				}
		// 
		//				sw.WriteLine("                               VAT          {0,-8:S} : {1,10:F}" ,Vat_Rate,GenUtil.strNumericFormat(amount));
		//				disc_amt=0;
		//				msg ="";
		//				if(txtDisc.Text=="")
		//				{
		//					strDiscType="";
		//					msg = "";
		//				}
		//				else
		//				{
		//					disc_amt = System.Convert.ToDouble(txtDisc.Text.ToString()); 
		//					strDiscType= DropDiscType.SelectedItem.Text;
		//					if(strDiscType.Trim().Equals("%"))
		//					{
		//						double temp =0;
		//						if(txtGrandTotal.Text.Trim() != "")
		//							temp = System.Convert.ToDouble(txtGrandTotal.Text.Trim().ToString());
		// 
		//						disc_amt  = (temp*disc_amt/100);
		//						msg = "("+txtDisc.Text.ToString()+strDiscType+")";
		//						
		//					}
		//					else
		//					{
		//						msg ="("+strDiscType+")";
		//					}			
		//				}
		//				sw.WriteLine("                               Discount     {0,-8:S} : {1,10:F}" ,msg,GenUtil.strNumericFormat(disc_amt.ToString()));
		//				sw.WriteLine("                               Net Amount            : {0,10:F}" , GenUtil.strNumericFormat(txtNetAmount.Text.ToString()));
		//				sw.WriteLine("+----------------------------------------------------------------+");
		//				sw.WriteLine("Promo Scheme : " + txtPromoScheme.Text);
		//				sw.WriteLine("Remarks      : " + txtRemark.Text);
		//				sw.WriteLine("Message      : " + txtMessage.Text);
		//				sw.WriteLine("");
		//				sw.WriteLine("");
		//				sw.WriteLine("");
		//				sw.WriteLine("                                               Signature");
		//
		//				sw.Close();		
		//			}
		//			catch(Exception ex)
		//			{
		//                CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:reportmaking4().  EXCEPTION: "+ ex.Message+"  user "+uid);
		//			}
		//		}


		/// <summary>
		/// This Method to write into the report file to print.
		/// </summary>
		public void reportmaking4()//modified by vishnu
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SalesInvoiceReport.txt";
				string info = "";
				string strInvNo="";
				string strDiscType="";
				double disc_amt=0;
				string msg ="";
				StreamWriter sw = new StreamWriter(path);
				// Condensed
				
				/*sw.Write((char)27);//added by vishnu for A4
				sw.Write((char)38);
				sw.Write((char)108);
				sw.Write((char)50);
				sw.Write((char)54);
				sw.Write((char)65);*/

				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				
				sw.Write((char)27);
				sw.Write((char)15);
				
				
				/*sw.Write((char)27);//added by vishnu
				sw.Write((char)106);
				sw.Write((char)255);

				sw.Write((char)27);//added by vishnu
				sw.Write((char)106);
				sw.Write((char)255);*/
			
				sw.WriteLine("");
				//**********
				string des="------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("=================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("SALES INVOICE  ",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("=================",des.Length));
				if(lblInvoiceNo.Visible==true)
					strInvNo= lblInvoiceNo.Text;
				else
					strInvNo= dropInvoiceNo.SelectedItem.Value;   
				sw.WriteLine(" Invoice No : " + strInvNo+ "                              Date : " + lblInvoiceDate.Text.ToString());
				sw.WriteLine(" Customer Name           : " + DropCustName.SelectedItem.Text);
				sw.WriteLine(" Place                   :  "+lblPlace.Value);
				sw.WriteLine(" Due Date                :  "+lblDueDate.Value);
				sw.WriteLine(" Current balance         :  "+lblCurrBalance.Value);
				sw.WriteLine(" Credit Limit            :  "+lblCreditLimit.Value);
				if(DropVehicleNo.Visible == true)
					sw.WriteLine(" Vehicle Number          :  "+DropVehicleNo.SelectedItem.Text);
				else
					sw.WriteLine(" Vehicle Number          :  "+txtVehicleNo.Text);
				//******
				sw.WriteLine(" Tin No                  :  "+lblTinNo.Value);
				//******
				sw.WriteLine("+------------------------------+-----------+----------+----------+");
				sw.WriteLine("|Product                       | Quantity  |   Rate   |  Amount  |");
				sw.WriteLine("+------------------------------+-----------+----------+----------+");
				info = " {0,-30:S} {1,10:F}  {2,10:F} {3,10:F}";
				sw.WriteLine(info,txtProdName1.Value ,txtQty1.Text,txtRate1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()) );
				sw.WriteLine(info,txtProdName2.Value ,txtQty2.Text,txtRate2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim())); 
				sw.WriteLine(info,txtProdName3.Value ,txtQty3.Text,txtRate3.Text,GenUtil.strNumericFormat(txtAmount3.Text.ToString().Trim())); 
				sw.WriteLine(info,txtProdName4.Value ,txtQty4.Text,txtRate4.Text,GenUtil.strNumericFormat(txtAmount4.Text.ToString().Trim())); 
				sw.WriteLine(info,txtProdName5.Value ,txtQty5.Text,txtRate5.Text,GenUtil.strNumericFormat(txtAmount5.Text.ToString().Trim())); 
				sw.WriteLine(info,txtProdName6.Value ,txtQty6.Text,txtRate6.Text,GenUtil.strNumericFormat(txtAmount6.Text.ToString().Trim())); 
				sw.WriteLine(info,txtProdName7.Value ,txtQty7.Text,txtRate7.Text,GenUtil.strNumericFormat(txtAmount7.Text.ToString().Trim())); 
				sw.WriteLine(info,txtProdName8.Value ,txtQty8.Text,txtRate8.Text,GenUtil.strNumericFormat(txtAmount8.Text.ToString().Trim())); 
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
					strDiscType= DropCashDiscType.SelectedItem.Text;
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
					strDiscType= DropDiscType.SelectedItem.Text;
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
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:reportmaking4().  EXCEPTION: "+ ex.Message+"  user "+uid);
			}
		}

		/// <summary>
		/// This method is used to trim the product length if >=15.
		/// </summary>
		public string trimProduct(string str)
		{
			if(str.Length > 15 )
				return str.Substring(0,15);
			else
				return str;
		}

		/// <summary>
		/// This method read the pre print template and sets the  values in global variables.
		/// </summary>
		public void getTemplateDetails()
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\InvoiceDesigner\PrePrintTemplate.INI";
			StreamReader  sr = new StreamReader(path);
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

			string[] strarr = data[0].Split(new Char[] {'x'},data[0].Length);
			overallPrintWidth = float.Parse(strarr[0].Trim());
			overallPrintHeight = float.Parse(strarr[1].Trim()); 
			string[] strarr1 = data[1].Split(new Char[] {'x'},data[1].Length);
			effectivePrintWidth = float.Parse(strarr1[0].Trim());
			effectivePrintHeight = float.Parse(strarr1[1].Trim());
			header = float.Parse(data[2].Trim());
			body = float.Parse(data[3].Trim());
			footer = float.Parse(data[4].Trim());
			rate = float.Parse(data[5].Trim());
			quantity = float.Parse(data[6].Trim());
			amount = float.Parse(data[7].Trim());
			total = float.Parse(data[8].Trim());
			string[] strarr2 = data[9].Split(new Char[] {'x'},data[9].Length);
			cashPos = float.Parse(strarr2[0].Trim());
			cashPosHeight = float.Parse(strarr2[1].Trim());

			if(data[10].Trim().Equals("True"))
			{
				cashMemo = true;
			}
			else
			{
				cashMemo = false;
			}
			 
			if(data[11].Trim().Equals("True"))
			{
				date = true;
			}
			else
			{
				date = false;
			}

			if(data[12].Trim().Equals("True"))
			{
				vehicle = true;
			}
			else
			{
				vehicle = false;
			}

			if(data[13].Trim().Equals("True"))
			{
				address = true;
			}
			else
			{
				address = false;
			}
		}

		/// <summary>
		/// This method is not used.
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
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SalesInvoicePrePrintReport.txt";
				string info = "";
				string strInvNo="";
				StreamWriter sw = new StreamWriter(path);
				string blank = "                                                                                                ";
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
				//sw.Write((char)27);
				//sw.Write((char)67); 
				//sw.Write((char)23); 
				

				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);

				sw.Write((char)27);
				sw.Write((char)15); // SI 15 0F Select condensed mode - Works

				sw.Write((char)27);//added by vishnu
				sw.Write((char)106);
				sw.Write((char)255);

				sw.Write((char)27);//added by vishnu
				sw.Write((char)106);
				sw.Write((char)255);
			
				
				//sw.WriteLine("Test Invoice");						
				if(lblInvoiceNo.Visible==true)
					strInvNo= lblInvoiceNo.Text;
				else
					strInvNo= dropInvoiceNo.SelectedItem.Value;   

				str = blank.Substring(1,System.Convert.ToInt32(Math.Round(NOC1 * cashPos)));

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
					sw.WriteLine(str + lblPlace.Value);
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
				int a  = System.Convert.ToInt32((Math.Ceiling(effectivePrintWidth - (rate + quantity + amount)) * NOC));
				int t = System.Convert.ToInt32(Math.Ceiling((total * NOC) - 1));

				//info = "{0,-" + p + ":S} {1,-" + r + ":F} {2,-" + q + ":F} {3," + a + ":F}";
				info = "{0,-" + p + ":S} {1," + r + ":F} {2," + q + ":F} {3," + a + ":F}";

				sw.WriteLine(info,trimProduct(txtProdName1.Value.ToString()+" "+txtPack1.Value.Trim()) ,txtRate1.Text,txtQty1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()) );
				sw.WriteLine(info,trimProduct(txtProdName2.Value.ToString()+" "+txtPack2.Value.Trim()) ,txtRate2.Text,txtQty2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim()));
				sw.WriteLine(info,trimProduct(txtProdName3.Value.ToString()+" "+txtPack3.Value.Trim()) ,txtRate3.Text,txtQty3.Text,GenUtil.strNumericFormat(txtAmount3.Text.ToString().Trim()));
				sw.WriteLine(info,trimProduct(txtProdName4.Value.ToString()+" "+txtPack4.Value.Trim()) ,txtRate4.Text,txtQty4.Text,GenUtil.strNumericFormat(txtAmount4.Text.ToString().Trim()));
				sw.WriteLine(info,trimProduct(txtProdName5.Value.ToString()+" "+txtPack5.Value.Trim()) ,txtRate5.Text,txtQty5.Text,GenUtil.strNumericFormat(txtAmount5.Text.ToString().Trim()));
				sw.WriteLine(info,trimProduct(txtProdName6.Value.ToString()+" "+txtPack6.Value.Trim()) ,txtRate6.Text,txtQty6.Text,GenUtil.strNumericFormat(txtAmount6.Text.ToString().Trim()));
				sw.WriteLine(info,trimProduct(txtProdName7.Value.ToString()+" "+txtPack7.Value.Trim()) ,txtRate7.Text,txtQty7.Text,GenUtil.strNumericFormat(txtAmount7.Text.ToString().Trim()));
				sw.WriteLine(info,trimProduct(txtProdName8.Value.ToString()+" "+txtPack8.Value.Trim()) ,txtRate8.Text,txtQty8.Text,GenUtil.strNumericFormat(txtAmount8.Text.ToString().Trim()));
						
				for (int i = 0; i < System.Convert.ToInt32(skip2 * 10); ++i)
				{
					sw.WriteLine();
				}

				sw.WriteLine(info,"" ,"","",GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()) );
				//sw.WriteLine(blank.Substring(1,t) + GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()) );
			
				// back to normal
				sw.Write((char)27);
				sw.Write((char)51);
				sw.Write((char)10);

				//deselect condensed
				sw.Write((char)18);
				sw.Write((char)12);

				sw.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:prePrint().  EXCEPTION: "+ ex.Message+"  user "+uid);
			}
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		public void prePrint1()
		{
			//Response.Write(txtAvStock1.Text);  
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SalesInvoicePrePrintReport.txt";
			string info = "";
			string strInvNo="";
			string strDiscType="";
			StreamWriter sw = new StreamWriter(path);
			sw.WriteLine("           =============");
			sw.WriteLine("           SALES1 INVOICE ");
			sw.WriteLine("           =============");
			if(lblInvoiceNo.Visible==true)
				strInvNo= lblInvoiceNo.Text;
			else
				strInvNo= dropInvoiceNo.SelectedItem.Value;   
 
			sw.WriteLine(" Invoice No   : " + strInvNo);
			sw.WriteLine(" Date         : " + lblInvoiceDate.Text.ToString());
			sw.WriteLine(" Customer     : " + DropCustName.SelectedItem.Text);
			sw.WriteLine(" Place        : "+lblPlace.Value);
			sw.WriteLine(" Due Date     : "+lblDueDate.Value);
			sw.WriteLine(" Current Bal. : "+lblCurrBalance.Value);
			sw.WriteLine(" Vehicle No.  : "+txtVehicleNo.Text);
			sw.WriteLine("+---------------+------+------+--------+");
			sw.WriteLine("|Product        |Qty.  |Rate  | Amount |");
			sw.WriteLine("+---------------+------+------+--------+");
			//info = " {0,-30:S} {1,10:F}  {2,10:F} {3,10:F}";
			info = " {0,-15:S} {1,6:F} {2,6:F} {3,9:F}";
			sw.WriteLine(info,trimProduct(txtProdName1.Value.ToString())  ,txtQty1.Text,txtRate1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()) );
			sw.WriteLine(info,trimProduct(txtProdName2.Value.ToString()) ,txtQty2.Text,txtRate2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim()));
			sw.WriteLine(info,trimProduct(txtProdName3.Value.ToString()) ,txtQty3.Text,txtRate3.Text,GenUtil.strNumericFormat(txtAmount3.Text.ToString().Trim()));
			sw.WriteLine(info,trimProduct(txtProdName4.Value.ToString()) ,txtQty4.Text,txtRate4.Text,GenUtil.strNumericFormat(txtAmount4.Text.ToString().Trim()));
			sw.WriteLine(info,trimProduct(txtProdName5.Value.ToString()) ,txtQty5.Text,txtRate5.Text,GenUtil.strNumericFormat(txtAmount5.Text.ToString().Trim()));
			sw.WriteLine(info,trimProduct(txtProdName6.Value.ToString()) ,txtQty6.Text,txtRate6.Text,GenUtil.strNumericFormat(txtAmount6.Text.ToString().Trim()));
			sw.WriteLine(info,trimProduct(txtProdName7.Value.ToString()) ,txtQty7.Text,txtRate7.Text,GenUtil.strNumericFormat(txtAmount7.Text.ToString().Trim()));
			sw.WriteLine(info,trimProduct(txtProdName8.Value.ToString()) ,txtQty8.Text,txtRate8.Text,GenUtil.strNumericFormat(txtAmount8.Text.ToString().Trim()));
			sw.WriteLine("+---------------+------+------+--------+");
			sw.WriteLine("           Grand Total      : {0,10:F}" , GenUtil.strNumericFormat(txtGrandTotal.Text.ToString()) );
			double disc_amt=0;
			string msg ="";
			if(txtDisc.Text=="")
			{
				strDiscType="";
				msg = "";
				//disc_amt ="";
			}
			else
			{
				disc_amt = System.Convert.ToDouble(txtDisc.Text.ToString()); 
				strDiscType= DropDiscType.SelectedItem.Text;
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
			sw.WriteLine("           Discount{0,-8:S} : {1,10:S}",msg,GenUtil.strNumericFormat(disc_amt.ToString()));
			sw.WriteLine("           Net Amount       : {0,10:F}" , GenUtil.strNumericFormat(txtNetAmount.Text.ToString()) );
			sw.WriteLine("+--------------------------------------+");
			string promo = txtPromoScheme.Text.Trim();
			if(promo.Length > 25)
				promo = promo.Substring(0,25); 
			sw.WriteLine("Promo Scheme : " + promo);

			string remark = txtRemark.Text.Trim();
			if(remark.Length > 25)
				remark = remark.Substring(0,25); 
			sw.WriteLine("Remarks      : " + remark);

			string message = txtMessage.Text.Trim();
			if(message.Length > 25)
				message = message.Substring(0,25);
			sw.WriteLine("Message      : " + message);
			sw.WriteLine("");
			sw.WriteLine("");
			sw.WriteLine("");
			sw.WriteLine("                           Signature");

			sw.Close();	
			//insert();
		}

		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void reportmaking44()  // To be removed
		{

			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SalesInvoiceReport.txt";
		
			StreamWriter sw = new StreamWriter(path);
			System.Data.SqlClient.SqlDataReader rdr=null;
           
			string sql="";
			string str1="";
			string str4="";
			string str6="";
			string str8="";
			string str10="";
			string str12="";
			string str14="";
			string str16="";
			string str18="";
			string str20="";
			string str22="";
			string str24="";
			string str26="";
			string str28="";
			string str30="";
			string str32="";
			string str34="";
			string str36="";
			string str38="";
			string str40="";
			string str42="";
			string str44="";
			string str46="";
			string str48="";
			string str50="";
			string str52="";
			string str54="";
			string str56="";
			string str58="";
			string str60="";
			string str62="";
			string str64="";
			string str66="";
			string str68="";
			string str70="";
			string str72="";
			string str74="";
			string str76="";
			string str78="";
			string str80="";
			string str82="";
		
			sql="select InvoiceNo,ToDate,CustomerName,Place,DueDate,CurrentBalance,VehicleNo,Prod1,Prod2,Prod3,Prod4,Prod5,Prod6,Prod7,Prod8,Qty1,Qty2,Qty3,Qty4,Qty5,Qty6,Qty7,Qty8,Rate1,Rate2,Rate3,Rate4,Rate5,Rate6,Rate7,Rate8,Amt1,Amt2,Amt3,Amt4,Amt5,Amt6,Amt7,Amt8,Total,Promo,Remarks from Salesinv  where InvoiceNo=(Select Max(InvoiceNo) from SalesInv)";
			dbobj.SelectQuery(sql,ref rdr);
			dbobj.SelectQuery(sql,ref rdr);
			
			if(rdr.Read())
			{
				str1=rdr["InvoiceNo"].ToString();
			}
			string str2=System.DateTime .Now.Day + "-" +System.DateTime .Now.Month +"-"+System.DateTime .Now.Year ;
							
			string str3="Invoice No : " +str1+"             Date : "+str2;

			Write2File(sw,"               ==================== ");
			Write2File(sw,"                   SALES REPORT     ");
			Write2File(sw,"               ==================== ");
			Write2File(sw,str3);
			Write2File(sw,"--------------------------------------------");

			dbobj.SelectQuery(sql,ref rdr);

			if(rdr.Read())
			{
				str4=rdr["CustomerName"].ToString();
			
			}
			string str5="Customer Name      : "  +str4;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str6=rdr["Place"].ToString();
			
			}
			string str7="Place              :  " +str6;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str8=rdr["DueDate"].ToString();
			
			}
			string str9="Due Date           :  " +str8;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str10=rdr["CurrentBalance"].ToString();
			
			}
			string str11="Current Balance    :  " +str10;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str12=rdr["VehicleNo"].ToString();
			
			}
			string str13="Vehicle No         :  " +str12;
			//  for Product

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str14=rdr["Prod1"].ToString();
			}
			string str15= str14;
			
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str16=rdr["Prod2"].ToString();
			}
			string str17= str16;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str18=rdr ["Prod3"].ToString();
			}
			string str19= str18;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str20=rdr["Prod4"].ToString();
			}
			string str21= str20;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str22=rdr["Prod5"].ToString();
			}
			string str23= str22;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str24=rdr["Prod6"].ToString();
			}
			string str25= str24;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str26=rdr["Prod7"].ToString();
			}
			string str27= str26;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str28=rdr["Prod8"].ToString();
			}
			string str29= str28;

			//for Qty

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str30=rdr["Qty1"].ToString();
			}
			string str31= str30;
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str32=rdr["Qty2"].ToString();
			}
			string str33= str32;
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str34=rdr["Qty3"].ToString();
			}
			string str35= str34;
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str36=rdr["Qty4"].ToString();
			}
			string str37= str36;
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str38=rdr["Qty5"].ToString();
			}
			string str39= str38;
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str40=rdr["Qty6"].ToString();
			}
			string str41= str40;
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str42=rdr["Qty7"].ToString();
			}
			string str43= str42;
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str44=rdr["Qty8"].ToString();
			}

			//for Rate
			string str45= str44;
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str46=rdr["Rate1"].ToString();
			}

			string str47= str46;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str48=rdr["Rate2"].ToString();
			}
			string str49= str48;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str50=rdr["Rate3"].ToString();
			}
			string str51= str50;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str52=rdr["Rate4"].ToString();
			}
			string str53= str52;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str54=rdr["Rate5"].ToString();
			}
			string str55= str54;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str56=rdr["Rate6"].ToString();
			}
			string str57= str56;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str58=rdr["Rate7"].ToString();
			}
			string str59= str58;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str60=rdr["Rate8"].ToString();
			}
			string str61= str60;
			//for Amount
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str62=rdr["Amt1"].ToString();
			}
			string str63= str62;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str64=rdr["Amt2"].ToString();
			}
			string str65= str64;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str66=rdr["Amt3"].ToString();
			}
			string str67= str66;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str68=rdr["Amt4"].ToString();
			}
			string str69= str68;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str70=rdr["Amt5"].ToString();
			}
			string str71= str70;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str72=rdr["Amt6"].ToString();
			}
			string str73= str72;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str74=rdr["Amt7"].ToString();
			}
			string str75= str74;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str76=rdr["Amt8"].ToString();
			}
			string str77= str76;
           
			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str78=rdr["Total"].ToString();
			}
			string str79= str78;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str80=rdr["Promo"].ToString();
			}
			string str81= str80;

			dbobj.SelectQuery(sql,ref rdr);
			if(rdr.Read())
			{
				str82=rdr["Remarks"].ToString();
			}
			string str83= str80;

			Write2File(sw,str5);
			Write2File(sw,str7); 
			Write2File(sw,str9); 
			Write2File(sw,str11); 
			Write2File(sw,str13); 

			Write2File(sw,"--------------------------------------------------"); 
			Write2File(sw,"Prod             Qty   Rate     Amt"); 
			Write2File(sw,"--------------------------------------------------"); 
			
			// For product 
			if (str15.Length < 16)
			{
				str15 = str15 + MakeString(16 - str15.Length);
			}
			if (str17.Length < 16)
			{
				str17 = str17 + MakeString(16 - str17.Length);
			}
			if (str19.Length < 16)
			{
				str19 = str19 + MakeString(16 - str19.Length);
			}
			if (str21.Length < 16)
			{
				str21= str21 + MakeString(16 - str21.Length);
			}
			if (str23.Length < 16)
			{
				str23 = str23 + MakeString(16 - str23.Length);
			}
			if (str25.Length < 16)
			{
				str25 = str25 + MakeString(16 - str25.Length);
			}
			if (str27.Length < 16)
			{
				str27 = str27 + MakeString(16 - str27.Length);
			}
			if (str29.Length < 16)
			{
				str29 = str29 + MakeString(16 - str29.Length);
			}
		
			//end product
			// for Qty
			if (str31.Length < 6)
			{
				str31 = str31 + MakeString(6 - str31.Length);
			}

			if (str33.Length < 6)
			{
				str33 = str33 + MakeString(6 - str33.Length);
			}
			if (str35.Length < 6)
			{
				str35 = str35 + MakeString(6 - str35.Length);
			}

			if (str35.Length < 6)
			{
				str35 = str35 + MakeString(6 - str35.Length);
			}
			if (str37.Length < 6)
			{
				str37 = str37 + MakeString(6 - str37.Length);
			}
			if (str39.Length < 6)
			{
				str39 = str39 + MakeString(6 - str39.Length);

			}
			if (str41.Length < 6)
			{
				str41 = str41 + MakeString(6 - str41.Length);
			}
			if (str43.Length < 6)
			{
				str43 = str43 + MakeString(6 - str43.Length);
			}
			if (str45.Length < 6)
			{
				str45 = str45 + MakeString(6 - str45.Length);
			}

			// End Qty


			// for rate
			if (str47.Length < 5)
			{
				str47 = str47 + MakeString(5 - str47.Length);
			}
			if (str49.Length < 5)
			{
				str49 = str49 + MakeString(5 - str49.Length);
			}
			if (str51.Length < 5)
			{
				str51 = str51 + MakeString(5 - str51.Length);
			}
			if (str53.Length < 5)
			{
				str53 = str53 + MakeString(5 - str53.Length);
			}

			if (str55.Length < 5)
			{
				str55 = str55 + MakeString(5 - str55.Length);
			}

			if (str57.Length < 5)
			{
				str57 = str57 + MakeString(5 - str57.Length);
			}

			if (str59.Length < 5)
			{
				str59 = str59 + MakeString(5 - str59.Length);
			}

			if (str61.Length < 5)
			{
				str61 = str61 + MakeString(5 - str61.Length);
			}


			//end 

			// for amt
			if (str63.Length < 5)
			{
				str63 = str63  + MakeString(5 - str63.Length);
			}

			if (str65.Length < 5)
			{
				str65 = str65  + MakeString(5 - str65.Length);
			}

			if (str67.Length < 5)
			{
				str67 = str67  + MakeString(5 - str67.Length);
			}
			if (str69.Length < 5)
			{
				str69 = str69  + MakeString(5 - str69.Length);
			}

			if (str71.Length < 5)
			{
				str71 = str71  + MakeString(5 - str71.Length);
			}

			if (str73.Length < 5)
			{
				str73 = str73  + MakeString(5 - str73.Length);
			}

			if (str75.Length < 5)
			{
				str75 = str75  + MakeString(5 - str75.Length);
			}

			if (str77.Length < 5)
			{
				str77 = str77  + MakeString(5 - str77.Length);
			}


			//end amt

			string gap = "  ";

			Write2File(sw,str15 + gap + str31 + gap + str47 + gap + str63);
			Write2File(sw,str17 + gap + str33 + gap + str49 + gap + str65);
			Write2File(sw,str19 + gap + str35 + gap + str51 + gap + str67);
			Write2File(sw,str21 + gap + str37 + gap + str53 + gap + str69);
			Write2File(sw,str23 + gap + str39 + gap + str55 + gap + str71);
			Write2File(sw,str25 + gap + str41 + gap + str57 + gap + str73);
			Write2File(sw,str27 + gap + str43 + gap + str59 + gap + str75);
			Write2File(sw,str29 + gap + str45 + gap + str61 + gap + str77);			
	
			
			Write2File(sw,"------------------------------------------------"); 
			Write2File(sw,"	           Total :      "+str79);
			Write2File(sw,"- -----------------------------------------------"); 
			Write2File(sw,"                                                                                           ");
			Write2File(sw,"Promo Scheme :"  +str81); 
			Write2File(sw,"                                                                                           ");
			Write2File(sw,"Remarks      :"  +str83); 
			Write2File(sw,"                                                                                           ");
			Write2File(sw,"                                                                                           ");
			Write2File(sw,"                                                                                           ");
			Write2File(sw,"                          Signature"); 
			sw.Close();
		}

		/// <summary>
		/// Its calls the save_updateInvoice() fucntion to save or update invoice details and calls the prePrint() and Print() fucntion to create and print the SalesInvoicePrePrintReport.txt file.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try 
			{
				print();
				//				btnSave.Enabled = false;
				//				save_updateInvoive();
				//				if(flag == 0)
				//				{
				//					prePrint();
				//					string home_drive = Environment.SystemDirectory;
				//					home_drive = home_drive.Substring(0,2); 
				//					print(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\SalesInvoicePrePrintReport.txt");
				//					Clear();
				//					clear1();
				//					CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:btnPrePrint_Click - InvoiceNo : " + lblInvoiceNo.Text  );
				//					GetNextInvoiceNo();
				//					GetProducts();
				//					//FetchData();
				//			
				//					lblInvoiceNo.Visible=true; 
				//					dropInvoiceNo.Visible=false;
				//					btnEdit.Visible=true;
				//					lblSlipNo.Visible=false;
				//					txtSlipNo.Visible=false;
				//					btnSave.Enabled = true;
				//				
				//				}
				//				else
				//				{
				//						flag = 0;
				//					btnSave.Enabled = true;
				//					checkPrevileges();
				//					checkPrePrint(); 
				//					    return ;
				//				}
				//				checkPrevileges();
				//				checkPrePrint();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:Button1_Click  EXCEPTION :  "+ ex.Message+"   "+uid);
			}
		}

		/// <summary>
		/// This method is used to sends the text file to print server to print.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\SalesInvoiceReport.txt<EOF>");

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
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+ane.Message+" userid "+ uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+se.Message+" userid "+ uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+es.Message+" userid "+ uid);
				}
				//CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:print EXCEPTION  "+es.Message+" userid "+ uid);
			} 
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:print EXCEPTION  "+es.Message+" userid "+ uid);
			}
		}

		/// <summary>
		/// This method update the products qty before sales in edit time.
		/// </summary>
		public void UpdateProductQty()
		{
			for(int i=0;i<ProductType.Length;i++)
			{
				InventoryClass obj = new InventoryClass();
				SqlDataReader rdr;
				SqlCommand cmd;
				SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
				string str="";
				if(ProductType[i]=="" || ProductName[i]=="" || ProductQty[i]=="")
					continue;
				else
				{
					
					str="select Prod_ID from Products where Category='"+ProductType[i].ToString()+"' and Prod_Name='"+ProductName[i].ToString()+"' and Pack_Type='"+ProductPack[i].ToString()+"'";
					rdr=obj.GetRecordSet(str);
					if(rdr.Read())
					{
						Con.Open();
						//cmd = new SqlCommand("update Stock_Master set sales=sales-"+double.Parse(ProductQty[i].ToString())+", Closing_Stock=Closing_Stock+"+double.Parse(ProductQty[i].ToString())+" where ProductID='"+rdr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(Stock_Date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(lblInvoiceDate.Text)+"'",Con);
						cmd = new SqlCommand("update Stock_Master set sales=sales-"+double.Parse(ProductQty[i].ToString())+", Closing_Stock=Closing_Stock+"+double.Parse(ProductQty[i].ToString())+" where ProductID='"+rdr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(Stock_Date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(tempInvoiceDate.Value)+"'",Con);
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
		
		/// <summary>
		/// This method delete the particular invoice no from all tables but some information contain in master table.
		/// </summary>
		public void DeleteTheRec()
		{
			try
			{
				DropDownList[] DropType={DropType1,DropType2,DropType3,DropType4,DropType5,DropType6,DropType7,DropType8};
				HtmlInputHidden[] ProdName={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
				HtmlInputHidden[] PackType={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
				TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr=null;//,SqlDtr=null;
				SqlCommand cmd;
				SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
				Con.Open();
				cmd = new SqlCommand("delete from Sales_Master where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				/*
				Con.Open();
				cmd = new SqlCommand("delete from monthwise1 where Invoice_No='"+FromDate+ToDate+dropInvoiceNo.SelectedItem.Text+"'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				Con.Open();
				cmd = new SqlCommand("delete from Sales_Oil where Invoice_No='"+FromDate+ToDate+dropInvoiceNo.SelectedItem.Text+"'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				*/
				Con.Open();
				cmd = new SqlCommand("delete from Accountsledgertable where Particulars='Sales Invoice ("+dropInvoiceNo.SelectedItem.Text+")'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name='"+DropCustName.SelectedItem.Text+"') order by entry_date";
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
				if(DropSalesType.SelectedItem.Text.Equals("Fleet Card Sale"))
				{
					str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name=(select FleetCard from organisation)) order by entry_date";
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
				}
				else if(DropSalesType.SelectedItem.Text.Equals("Credit Card Sale"))
				{
					str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name=(select CreditCard from organisation)) order by entry_date";
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
				}
				Con.Open();
				cmd = new SqlCommand("delete from Customerledgertable where Particular='Sales Invoice ("+dropInvoiceNo.SelectedItem.Text+")'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				string str1="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer where Cust_Name='"+DropCustName.SelectedItem.Text+"') order by entrydate";
				rdr=obj.GetRecordSet(str1);
				Bal=0;
				while(rdr.Read())
				{
					if(rdr["BalanceType"].ToString().Equals("Dr."))
						Bal+=double.Parse(rdr["DebitAmount"].ToString())-double.Parse(rdr["CreditAmount"].ToString());
					else
						Bal+=double.Parse(rdr["CreditAmount"].ToString())-double.Parse(rdr["DebitAmount"].ToString());
					if(Bal.ToString().StartsWith("-"))
						Bal=double.Parse(Bal.ToString().Substring(1));
					Con.Open();
					cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					Con.Close();
					cmd.Dispose();
				}
				rdr.Close();
				Con.Open();
				cmd = new SqlCommand("delete from LedgDetails where Bill_No='"+dropInvoiceNo.SelectedItem.Text+"'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				Con.Open();
				cmd = new SqlCommand("delete from Invoice_Transaction where Invoice_No='"+dropInvoiceNo.SelectedItem.Text+"'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				Con.Open();
				cmd = new SqlCommand("Update Customer_Balance set DR_Amount = DR_Amount-'"+double.Parse(txtNetAmount.Text)+"' where Cust_ID = (select Cust_ID from Customer where Cust_Name='"+DropCustName.SelectedItem.Text+"' and city='"+lblPlace.Value+"')",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				for(int i=0;i<8;i++)
				{
					if(DropType[i].SelectedItem.Text.Equals("Type") || ProdName[i].Value=="" || Qty[i].Text=="")
						continue;
					else
					{
						Con.Open();
						cmd = new SqlCommand("update Stock_Master set sales=sales-'"+double.Parse(Qty[i].Text)+"',closing_stock=closing_stock+'"+double.Parse(Qty[i].Text)+"' where ProductID=(select Prod_ID from Products where Category='"+DropType[i].SelectedItem.Text+"' and Prod_Name='"+ProdName[i].Value+"' and Pack_Type='"+PackType[i].Value+"') and cast(floor(cast(cast(Stock_Date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(lblInvoiceDate.Text)+"'",Con);
						cmd.ExecuteNonQuery();
						Con.Close();
						cmd.Dispose();
					}
				}
				SeqStockMaster();
				MessageBox.Show("Sales Transaction Deleted");
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:btnDelete_Click - InvoiceNo : " +dropInvoiceNo.SelectedItem.Text+" Deleted, user : "+uid);
				Clear();
				clear1();
				GetNextInvoiceNo();
				GetProducts();                
				FetchData();
				lblInvoiceNo.Visible=true;
				dropInvoiceNo.Visible=false;
				btnEdit.Visible=true;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SalesInvoice.aspx,Method:btnDelete_Click - InvoiceNo : " +dropInvoiceNo.SelectedItem.Text+" ,Exception : "+ex.Message+" user : "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to update the product stock after sales in edit time.
		/// </summary>
		public void SeqStockMaster()
		{
			for(int i=0;i<ProductType.Length;i++)
			{
				if(ProductType[i]=="" || ProductName[i]=="" || ProductQty[i]=="")
					continue;
				else
				{
					InventoryClass obj = new InventoryClass();
					InventoryClass obj1 = new InventoryClass();
					SqlCommand cmd;
					SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
					SqlDataReader rdr1=null,rdr=null;
					string str="select Prod_ID from Products where Category='"+ProductType[i].ToString()+"' and Prod_Name='"+ProductName[i].ToString()+"' and Pack_Type='"+ProductPack[i].ToString()+"'";
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
		
		public void StockMaster(string PType,string PName, string PackType)
		{
			InventoryClass obj = new InventoryClass();
			InventoryClass obj1 = new InventoryClass();
			string[] Name=null;
			if(PName.IndexOf(":")>0)
			{
				Name = PName.Split(new char[] {':'},PName.Length);
				PName = Name[0].ToString();
			}
			SqlCommand cmd;
							
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			SqlDataReader rdr1=null,rdr=null;
			string str="select Prod_ID from Products where Category='"+PType+"' and Prod_Name='"+PName+"' and Pack_Type='"+PackType+"'";
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
		
		//		public void customerUpdate()
		//		{
		//			SqlDataReader rdr=null;
		//			SqlCommand cmd;
		//			InventoryClass obj =new InventoryClass();
		//			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
		//			double Bal=0;
		//			string BalType="";
		//			int i=0;
		//				
		//			string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master l,Customer c where Cust_Name=Ledger_Name and Cust_ID='"+Cust_ID+"') order by entry_date";
		//			rdr=obj.GetRecordSet(str);
		//			Bal=0;
		//			BalType="";
		//			i=0;
		//			while(rdr.Read())
		//			{
		//				if(i==0)
		//				{
		//					BalType=rdr["Bal_Type"].ToString();
		//					i++;
		//				}
		//				if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
		//				{
		//					if(BalType=="Cr")
		//					{
		//						Bal+=double.Parse(rdr["Credit_Amount"].ToString());
		//						BalType="Cr";
		//					}
		//					else
		//					{
		//						Bal-=double.Parse(rdr["Credit_Amount"].ToString());
		//						if(Bal<0)
		//						{
		//							Bal=double.Parse(Bal.ToString().Substring(1));
		//							BalType="Cr";
		//						}
		//						else
		//							BalType="Dr";
		//					}
		//				}
		//				else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
		//				{
		//					if(BalType=="Dr")
		//						Bal+=double.Parse(rdr["Debit_Amount"].ToString());
		//					else
		//					{
		//						Bal-=double.Parse(rdr["Debit_Amount"].ToString());
		//						if(Bal<0)
		//						{
		//							Bal=double.Parse(Bal.ToString().Substring(1));
		//							BalType="Dr";
		//						}
		//						else
		//							BalType="Cr";
		//					}
		//				}
		//				Con.Open();
		//				cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
		//				cmd.ExecuteNonQuery();
		//				cmd.Dispose();
		//				Con.Close();
		//							
		//			}
		//			rdr.Close();
		//				
		//			string str1="select * from CustomerLedgerTable where CustID='"+Cust_ID+"' order by entrydate";
		//			rdr=obj.GetRecordSet(str1);
		//			Bal=0;
		//			i=0;
		//			BalType="";
		//			while(rdr.Read())
		//			{
		//				if(i==0)
		//				{
		//					BalType=rdr["BalanceType"].ToString();
		//					i++;
		//				}
		//				if(double.Parse(rdr["CreditAmount"].ToString())!=0)
		//				{
		//					if(BalType=="Cr.")
		//					{
		//						Bal+=double.Parse(rdr["CreditAmount"].ToString());
		//						BalType="Cr.";
		//					}
		//					else
		//					{
		//						Bal-=double.Parse(rdr["CreditAmount"].ToString());
		//						if(Bal<0)
		//						{
		//							Bal=double.Parse(Bal.ToString().Substring(1));
		//							BalType="Cr.";
		//						}
		//						else
		//							BalType="Dr.";
		//					}
		//				}
		//				else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
		//				{
		//					if(BalType=="Dr.")
		//						Bal+=double.Parse(rdr["DebitAmount"].ToString());
		//					else
		//					{
		//						Bal-=double.Parse(rdr["DebitAmount"].ToString());
		//						if(Bal<0)
		//						{
		//							Bal=double.Parse(Bal.ToString().Substring(1));
		//							BalType="Dr.";
		//						}
		//						else
		//							BalType="Cr.";
		//					}
		//				}
		//				Con.Open();
		//				cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
		//				cmd.ExecuteNonQuery();
		//				cmd.Dispose();
		//				Con.Close();
		//			}
		//			rdr.Close();
		//		}

		string Invoice_Date="";
		/// <summary>
		/// This method is used to update the customer balance after sales.
		/// </summary>
		public void CustomerUpdate()
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			double Bal=0;
			string BalType="",str="";
			int i=0;
			//************************
			if(DateTime.Compare(System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(tempInvoiceDate.Value.ToString())),System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(lblInvoiceDate.Text)))>0)
				Invoice_Date=GenUtil.str2MMDDYYYY(lblInvoiceDate.Text);
			else
				Invoice_Date=GenUtil.str2MMDDYYYY(tempInvoiceDate.Value);
			
			rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master l,Customer c where Cust_Name=Ledger_Name and Cust_ID='"+Cust_ID+"') and Entry_Date<='"+Invoice_Date+"' order by entry_date desc");
			if(rdr.Read())
				str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master l,Customer c where Cust_Name=Ledger_Name and Cust_ID='"+Cust_ID+"') and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
			else
				str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master l,Customer c where Cust_Name=Ledger_Name and Cust_ID='"+Cust_ID+"') order by entry_date";
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
			rdr.Close();
			
			//*************************
			rdr = obj.GetRecordSet("select top 1 EntryDate from CustomerLedgerTable where CustID='"+Cust_ID.ToString()+"' and EntryDate<='"+Invoice_Date+"' order by entrydate desc");
			if(rdr.Read())
				str="select * from CustomerLedgerTable where CustID='"+Cust_ID+"' and EntryDate>='"+rdr.GetValue(0).ToString()+"' order by entrydate";
			else
				str="select * from CustomerLedgerTable where CustID='"+Cust_ID+"' order by entrydate";
			rdr.Close();
			//*************************
			rdr=obj.GetRecordSet(str);
			Bal=0;
			i=0;
			BalType="";
			while(rdr.Read())
			{
				if(i==0)
				{
					BalType=rdr["BalanceType"].ToString();
					Bal = double.Parse(rdr["Balance"].ToString());
					i++;
				}
				else
				{
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
					cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					Con.Close();
				}
			}
			rdr.Close();
		}
	}
}