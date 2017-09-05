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
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPetro.Sysitem.Classes ;
using DBOperations;
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;


namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for PurchaseInvoice.
	/// </summary>
	public class PurchaseInvoice : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtQty1;
		protected System.Web.UI.WebControls.TextBox txtRate1;
		protected System.Web.UI.WebControls.TextBox txtQty2;
		protected System.Web.UI.WebControls.TextBox txtRate2;
		protected System.Web.UI.WebControls.TextBox txtQty3;
		protected System.Web.UI.WebControls.TextBox txtRate3;
		protected System.Web.UI.WebControls.TextBox txtQty4;
		protected System.Web.UI.WebControls.TextBox txtRate4;
		protected System.Web.UI.WebControls.TextBox txtQty5;
		protected System.Web.UI.WebControls.TextBox txtRate5;
		protected System.Web.UI.WebControls.TextBox txtQty6;
		protected System.Web.UI.WebControls.TextBox txtRate6;
		protected System.Web.UI.WebControls.TextBox txtQty7;
		protected System.Web.UI.WebControls.TextBox txtRate7;
		protected System.Web.UI.WebControls.TextBox txtQty8;
		protected System.Web.UI.WebControls.TextBox txtRate8;
		protected System.Web.UI.WebControls.TextBox txtPromoScheme;
		protected System.Web.UI.WebControls.TextBox txtGrandTotal;
		protected System.Web.UI.WebControls.TextBox txtDisc;
		protected System.Web.UI.WebControls.DropDownList DropDiscType;
		protected System.Web.UI.WebControls.TextBox txtNetAmount;
		protected System.Web.UI.WebControls.Label lblEntryBy;
		protected System.Web.UI.WebControls.Label lblEntryTime;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblInvoiceNo;
		protected System.Web.UI.WebControls.TextBox lblInvoiceDate;
		protected System.Web.UI.WebControls.DropDownList DropModeType;
		protected System.Web.UI.WebControls.DropDownList DropType1;
		protected System.Web.UI.WebControls.DropDownList DropProd1;
		protected System.Web.UI.WebControls.DropDownList DropType2;
		protected System.Web.UI.WebControls.DropDownList DropProd2;
		protected System.Web.UI.WebControls.DropDownList DropType3;
		protected System.Web.UI.WebControls.DropDownList DropProd3;
		protected System.Web.UI.WebControls.DropDownList DropType4;
		protected System.Web.UI.WebControls.DropDownList DropProd4;
		protected System.Web.UI.WebControls.DropDownList DropType5;
		protected System.Web.UI.WebControls.DropDownList DropProd5;
		protected System.Web.UI.WebControls.DropDownList DropType6;
		protected System.Web.UI.WebControls.DropDownList DropProd6;
		protected System.Web.UI.WebControls.DropDownList DropType7;
		protected System.Web.UI.WebControls.DropDownList DropProd7;
		protected System.Web.UI.WebControls.DropDownList DropType8;
		protected System.Web.UI.WebControls.DropDownList DropProd8;
		protected System.Web.UI.WebControls.DropDownList DropPack1;
		protected System.Web.UI.WebControls.DropDownList DropPack2;
		protected System.Web.UI.WebControls.DropDownList DropPack3;
		protected System.Web.UI.WebControls.DropDownList DropPack4;
		protected System.Web.UI.WebControls.DropDownList DropPack5;
		protected System.Web.UI.WebControls.DropDownList DropPack6;
		protected System.Web.UI.WebControls.DropDownList DropPack7;
		protected System.Web.UI.WebControls.DropDownList DropPack8;
		protected System.Web.UI.WebControls.TextBox txtAmount1;
		protected System.Web.UI.WebControls.TextBox txtAmount2;
		protected System.Web.UI.WebControls.TextBox txtAmount3;
		protected System.Web.UI.WebControls.TextBox txtAmount4;
		protected System.Web.UI.WebControls.TextBox txtAmount5;
		protected System.Web.UI.WebControls.TextBox txtAmount6;
		protected System.Web.UI.WebControls.TextBox txtAmount7;
		protected System.Web.UI.WebControls.TextBox txtAmount8;
		protected System.Web.UI.WebControls.TextBox txtVehicleNo;
		protected System.Web.UI.WebControls.TextBox txtVInnvoiceNo;
		protected System.Web.UI.WebControls.TextBox txtVInvoiceDate;
		protected System.Web.UI.WebControls.DropDownList DropVendorID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden temptext;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack8;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPack1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProdName8;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtVen;
		protected System.Web.UI.HtmlControls.HtmlInputText lblPlace;
		protected System.Web.UI.WebControls.Button BtnEdit;
		protected System.Web.UI.WebControls.DropDownList DropInvoiceNo;
		protected System.Web.UI.WebControls.TextBox Txtselect;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox txtTempQty1;
		protected System.Web.UI.WebControls.TextBox txtTempQty2;
		protected System.Web.UI.WebControls.TextBox txtTempQty3;
		protected System.Web.UI.WebControls.TextBox txtTempQty4;
		protected System.Web.UI.WebControls.TextBox txtTempQty5;
		protected System.Web.UI.WebControls.TextBox txtTempQty6;
		protected System.Web.UI.WebControls.TextBox txtTempQty7;
		protected System.Web.UI.WebControls.TextBox txtTempQty8;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtRemark;
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.RadioButton Yes;
		protected System.Web.UI.WebControls.RadioButton No;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtVatRate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtVatValue;
		protected System.Web.UI.WebControls.DropDownList DropCashDiscType;
		protected System.Web.UI.WebControls.TextBox txtVAT;
		protected System.Web.UI.WebControls.Button btnPrint;
		static string[] ProductType = new string[12];
		static string[] ProductName = new string[12];
		static string[] ProductPack = new string[12];
		static string[] ProductQty = new string[12];
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempInvoiceInfo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempInvoiceNo;
		string uid;
		static string Vendor_ID="0",CheckMode="";
		protected System.Web.UI.WebControls.TextBox txtCashDisc;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				DropInvoiceNo.Visible=false;
			}
			BtnEdit.Visible=true;
			//if(tempDelinfo.Value=="Yes")
			//{
			//	DeleteTheRec();
			//	SeqStockMaster();
			//}
			try
			{
				uid=(Session["User_Name"].ToString());
				txtMessage.Text = (Session["Message"].ToString());
				txtVatRate.Value = (Session["VAT_Rate"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:pageload"+ex.Message+"  EXCEPTION "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(tempInvoiceInfo.Value=="Yes")
			{
				DeleteTheRec();
			}
			if(!IsPostBack)
			{
				try
				{
                    lblInvoiceDate.Attributes.Add("readonly", "readonly");
                    lblPlace.Attributes.Add("readonly", "readonly");
                    txtVInvoiceDate.Attributes.Add("readonly", "readonly");
                    txtRate1.Attributes.Add("readonly", "readonly");
                    txtAmount1.Attributes.Add("readonly", "readonly");
                    txtRate2.Attributes.Add("readonly", "readonly");
                    txtAmount2.Attributes.Add("readonly", "readonly");
                    txtRate3.Attributes.Add("readonly", "readonly");
                    txtAmount3.Attributes.Add("readonly", "readonly");
                    txtRate4.Attributes.Add("readonly", "readonly");
                    txtAmount4.Attributes.Add("readonly", "readonly");
                    txtRate5.Attributes.Add("readonly", "readonly");
                    txtAmount5.Attributes.Add("readonly", "readonly");
                    txtRate6.Attributes.Add("readonly", "readonly");
                    txtAmount6.Attributes.Add("readonly", "readonly");
                    txtRate7.Attributes.Add("readonly", "readonly");
                    txtAmount7.Attributes.Add("readonly", "readonly");
                    txtRate8.Attributes.Add("readonly", "readonly");
                    txtAmount8.Attributes.Add("readonly", "readonly");
                    txtGrandTotal.Attributes.Add("readonly", "readonly");
                    txtMessage.Attributes.Add("readonly", "readonly");
                    txtVAT.Attributes.Add("readonly", "readonly");
                    txtNetAmount.Attributes.Add("readonly", "readonly");

                    Vendor_ID ="0";
					CheckMode="";
					txtVInvoiceDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					checkPrevileges();
					lblInvoiceDate.Text=GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());  
					lblEntryTime.Text=DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm:ss tt");
                    lblEntryBy.Text =Session["User_Name"].ToString();
					DropDownList[] ProductType={DropType1, DropType2, DropType3, DropType4, DropType5, DropType6, DropType7, DropType8 };
					InventoryClass obj=new InventoryClass ();
					SqlDataReader SqlDtr;
					string sql;
					GetNextInvoiceNo();

					#region Fetch the Product Types and fill in the ComboBoxes
					sql="select distinct Category from Products where Category!='Fuel'";
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

					#region Fetch All Supplier ID and fill in the ComboBox
					sql="select Supp_Name from Supplier order by Supp_Name";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropVendorID.Items.Add (SqlDtr.GetValue(0).ToString ());				
					}
					SqlDtr.Close ();		
					#endregion

					//////////////////////////////////////////////////////////
					GetProducts();
					FatchInvoiceNo();
					//////////////////////////////////////////////////////////
					FetchCity();
					CreateLogFiles.ErrorLog("Form:OtherPurchace.aspx,Method:pageload.   User_ID: "+uid);
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:pageload.  EXCEPTION: "+ex.Message+" User_ID: "+uid);
				}
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
			if(Add_Flag=="0" && View_flag =="0" && Edit_Flag =="0")
			{
				//string msg="UnAthourized Visit to Purchase Invoice Page";
				//	dbobj.LogActivity(msg,Session["User_Name"].ToString());  
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}

			if(Add_Flag == "0")
				btnSave.Enabled = false;
			if(Edit_Flag == "0")
				BtnEdit.Enabled = false;   

			#endregion
		}

		/// <summary>
		/// To Fetch All Invoice NO and fill in the ComboBox.
		/// </summary>
		public void fillID()
		{
			try
			{
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
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:fillID().  EXCEPTION: "+ex.Message+" User_ID: "+uid);
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
			this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// This method is used to fetch the supplier city and put it into a hidden fields
		/// </summary>
		public void FetchCity()
		{
			string city="";
			string str1="";
					
			IEnumerator enum1=DropVendorID.Items.GetEnumerator();
			enum1.MoveNext(); 
			while(enum1.MoveNext())
			{
				string s=enum1.Current.ToString(); 
				dbobj.SelectQuery("Select City from Supplier where Supp_Name='"+s+"'","City",ref city);
				str1=str1+s+"~"+city+"#";
			}
			TxtVen.Value=str1; 
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		public void SaveForReport()
		{
			Sysitem.Classes.InventoryClass obj=new InventoryClass();
			obj.InvoiceNo =lblInvoiceNo.Text.ToString();
			obj.InvoiceDate= lblInvoiceDate.Text;
			obj.VendorName=DropVendorID.SelectedItem.Value.ToString();
			obj.Place =lblPlace.Value.ToString(); 
			obj.vendorInvoiceNo =txtVInnvoiceNo.Text.ToString();
			obj.vendorInvoiceDate=txtVInvoiceDate.Text.ToString();
			
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
			obj.InsertPurchaseInvoiceDuplicate();
		}

		/// <summary>
		/// this is used to fetch product name and fill the dropdown list according to given product type. 
		/// </summary>
		public void Type_Changed(DropDownList ddType,DropDownList ddProd,DropDownList ddPack)
		{
			try
			{
				ddProd.Items.Clear(); 
				ddProd.Items.Add("Select");
				ddPack.Items.Clear();
				if(ddType.SelectedItem.Value == "Fuel")
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
				CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:Type_Changed.  EXCEPTION: "+ex.Message+" User_ID: "+uid);
			}
		}

		/// <summary>
		/// This method is used to fatch the product pack type and rate according to given product name.
		/// </summary>
		public void Prod_Changed(DropDownList ddType, DropDownList ddProd,DropDownList ddPack,TextBox txtPurRate)
		{
			try
			{
				ddPack.Items.Clear(); 
				txtPurRate.Text="";
				if(ddProd.SelectedIndex ==0)
					return;
			
				InventoryClass obj=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;

				#region Fetch Package Types Regarding Product Name			
				sql="Select distinct Pack_Type from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"' and Category='"+ddType.SelectedItem.Value+"'";
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read ())
				{
					ddPack.Items.Add(SqlDtr.GetValue(0).ToString ());
				}
				SqlDtr.Close();
				#endregion

				#region Fetch Purchase Rate Regarding Product Name		
				sql= "select top 1 Pur_Rate from Price_Updation where Prod_ID=(select  Prod_ID from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"' and Pack_Type='"+ ddPack.SelectedItem.Value +"') order by eff_date desc";
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read ())
				{
					txtPurRate.Text=SqlDtr.GetValue(0).ToString();
				}
				SqlDtr.Close();
				#endregion			
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:Prod_Changed.  EXCEPTION: "+ex.Message+" User_ID: "+uid);	
			}
		}


		/// <summary>
		/// This fucntion saves the purchase details into a purchase_details table.
		/// </summary>
		public void Save(string ProdName,string PackType, string Qty, string Rate,string Amount)
		{
			InventoryClass obj=new InventoryClass();
			obj.Invoice_No=lblInvoiceNo.Text;
			obj.Product_Name=ProdName;
			obj.Package_Type=PackType;
			obj.Qty=Qty;
			obj.Rate=Rate;
			obj.Amount=Amount;  
			obj.InsertPurchaseDetail();
		}

		/// <summary>
		/// This method update the purchase details with the help of ProPurchaseDetailsupdate procedure.
		/// </summary>
		public void Save1(string ProdName,string PackType, string Qty, string Rate,string Amount,string Qty1,string Inv_date)
		{
			InventoryClass obj=new InventoryClass();
			obj.Invoice_No=DropInvoiceNo.SelectedItem.Value;  
			obj.Product_Name=ProdName;
			obj.Package_Type=PackType;
			obj.Qty=Qty;
			obj.Rate=Rate;
			obj.Amount=Amount;
			obj.QtyTemp = Qty1;
			obj.Inv_date = Inv_date; 
			obj.UpdatePurchaseDetail(); 
		}

		/// <summary>
		/// This is used to split the date.
		/// </summary>
		private DateTime getdate(string dat,bool to)
		{
			string[] dt=dat.Split(new char[]{'/'},dat.Length);
			if(to)
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
			else
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
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
				CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:print"+uid);
				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);

					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\PurchaseInvoiceReport.txt<EOF>");

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
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:print"+ex.Message+"  EXCEPTION "+uid);
			}
		}

        /// <summary>
        /// This method insert and update to the purchase_master and purchase_details
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            InventoryClass obj = new InventoryClass();
            try
            {
                StringBuilder erroMessage = new StringBuilder();

                if (DropVendorID.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select the Vendor Name");
                    erroMessage.Append("\n");
                }

                if (txtVehicleNo.Text == string.Empty)
                {
                    erroMessage.Append("- Please Enter the Vehicle No");
                    erroMessage.Append("\n");
                }

                if (txtVInnvoiceNo.Text == string.Empty)
                {
                    erroMessage.Append("- Please Enter the Vendor Invoice No");
                    erroMessage.Append("\n");
                }

                if (DropType1.SelectedIndex == 0)
                {
                    erroMessage.Append("- Please select the Product Type");
                    erroMessage.Append("\n");
                }
                   
                if (txtQty1.Text == string.Empty)
                {
                    erroMessage.Append("- Please Enter the Qty");
                    erroMessage.Append("\n");
                }

                if (erroMessage.Length > 0)
                {
                    MessageBox.Show(erroMessage.ToString());
                    return;
                }

                // if lable is visible then save otherwise update the invoice.
                if (lblInvoiceNo.Visible == true)
                {
                    obj.Invoice_No = lblInvoiceNo.Text;
                    int count = 0;
                    // This part of code is use to solve the double click problem, Its checks the purchase Invoice no. and display the popup, that it is saved.
                    dbobj.ExecuteScalar("Select count(Invoice_No) from Purchase_Master where Invoice_No = " + lblInvoiceNo.Text.Trim(), ref count);
                    if (count > 0)
                    {
                        MessageBox.Show("Purchase Invoice Saved");
                        GetProducts();
                        FatchInvoiceNo();
                        Clear();
                        clear1();
                        GetNextInvoiceNo();
                        lblInvoiceDate.Text = GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());
                        return;
                    }
                    else
                    {
                        //obj.Invoice_Date=System.Convert.ToDateTime(GenUtil.str2MMDDYYYY (lblInvoiceDate.Text.ToString() )) ;
                        obj.Invoice_Date = DateTime.Now;
                        obj.Mode_of_Payment = DropModeType.SelectedItem.Value;
                        obj.Vendor_Name = DropVendorID.SelectedItem.Value;
                        obj.City = lblPlace.Value.ToString();
                        obj.Vehicle_No = txtVehicleNo.Text;
                        obj.Vndr_Invoice_No = txtVInnvoiceNo.Text;
                        obj.Vndr_Invoice_Date = GenUtil.str2MMDDYYYY(txtVInvoiceDate.Text.ToString());
                        obj.Grand_Total = txtGrandTotal.Text;
                        if (txtDisc.Text == "")
                            obj.Discount = "0.0";
                        else
                            obj.Discount = txtDisc.Text;
                        obj.Discount_Type = DropDiscType.SelectedItem.Value;
                        obj.Net_Amount = txtNetAmount.Text;
                        obj.Promo_Scheme = txtPromoScheme.Text;
                        obj.Remerk = txtRemark.Text;
                        obj.Entry_By = lblEntryBy.Text;
                        obj.Entry_Time = DateTime.Parse(DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm:ss tt"));
                        if (txtCashDisc.Text.Trim() == "")
                            obj.Cash_Discount = "0.0";
                        else
                            obj.Cash_Discount = txtCashDisc.Text.Trim();
                        obj.Cash_Disc_Type = DropCashDiscType.SelectedItem.Value;
                        obj.VAT_Amount = txtVAT.Text.Trim();
                        obj.InsertPurchaseMaster();

                        HtmlInputHidden[] ProdName = { txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8 };
                        HtmlInputHidden[] PackType = { txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8 };
                        TextBox[] Qty = { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8 };
                        TextBox[] Rate = { txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8 };
                        TextBox[] Amount = { txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8 };
                        for (int j = 0; j < ProdName.Length; j++)
                        {
                            if (Rate[j].Text == "" || Rate[j].Text == "0")
                                continue;
                            Save(ProdName[j].Value, PackType[j].Value, Qty[j].Text.ToString(), Rate[j].Text.ToString(), Amount[j].Text.ToString());
                        }

                        MessageBox.Show("Purchase Invoice Saved");
                        CreateLogFiles.ErrorLog("Form:OtherlPerchase.aspx,Method:btnSaved_Click,Class:PartiesClass.cs" + " Fuel Purchase Invoise for  Invoice No." + obj.Invoice_No + " ," + "for Vender Name  " + obj.Vendor_Name + "on Date " + obj.Vendor_Name + " and NetAmount  " + obj.Net_Amount + "  is Saved " + " userid " + uid);
                        GetProducts();
                        FatchInvoiceNo();
                        reportmaking();
                        //print();
                        Clear();
                        clear1();
                        GetNextInvoiceNo();
                        lblInvoiceDate.Text = GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());
                    }
                    //CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:btnSave_Click. Purchase Invoice Saved,  User_ID: "+uid);
                }
                else
                {
                    string strChck = "";
                    strChck = DropInvoiceNo.SelectedItem.Value.ToString();
                    if (strChck.Equals("Select"))
                    {
                        MessageBox.Show("Please Select Invoice No");
                    }
                    else
                    {
                        string temp = "";
                        obj.Invoice_No = DropInvoiceNo.SelectedItem.Value;
                        obj.Invoice_Date = System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(lblInvoiceDate.Text.ToString()));
                        obj.Mode_of_Payment = DropModeType.SelectedItem.Value;
                        obj.Vendor_Name = DropVendorID.SelectedItem.Value;
                        obj.City = lblPlace.Value.ToString();
                        obj.Vehicle_No = txtVehicleNo.Text;
                        obj.Vndr_Invoice_No = txtVInnvoiceNo.Text;
                        obj.Vndr_Invoice_Date = GenUtil.str2MMDDYYYY(txtVInvoiceDate.Text.ToString());
                        obj.Grand_Total = txtGrandTotal.Text;
                        if (txtDisc.Text == "")
                            obj.Discount = "0.0";
                        else
                            obj.Discount = txtDisc.Text;
                        obj.Discount_Type = DropDiscType.SelectedItem.Value;
                        obj.Net_Amount = txtNetAmount.Text;
                        obj.Promo_Scheme = txtPromoScheme.Text;
                        obj.Remerk = txtRemark.Text;
                        obj.Entry_By = lblEntryBy.Text;
                        obj.Entry_Time = DateTime.Parse(lblEntryTime.Text);
                        if (txtCashDisc.Text.Trim() == "")
                            obj.Cash_Discount = "0.0";
                        else
                            obj.Cash_Discount = txtCashDisc.Text.Trim();
                        obj.Cash_Disc_Type = DropCashDiscType.SelectedItem.Value;
                        obj.VAT_Amount = txtVAT.Text.Trim();
                        UpdateProductQty();
                        int VendorID = 0;
                        dbobj.ExecuteScalar("Select Supp_ID from  Supplier where Supp_Name='" + DropVendorID.SelectedItem.Text + "'", ref VendorID);
                        if (Vendor_ID != VendorID.ToString())
                        {
                            int xx = 0;
                            dbobj.Insert_or_Update("delete from Purchase_Master where Invoice_No='" + DropInvoiceNo.SelectedItem.Text + "'", ref xx);
                            dbobj.Insert_or_Update("delete from Accountsledgertable where Particulars='Purchase Invoice (" + DropInvoiceNo.SelectedItem.Text + ")'", ref xx);
                            dbobj.Insert_or_Update("delete from Vendorledgertable where Particular='Purchase Invoice (" + DropInvoiceNo.SelectedItem.Text + ")'", ref xx);
                            obj.InsertPurchaseMaster();
                        }
                        else
                            obj.updateMasterPurchase();
                        customerUpdate();

                        //CreateLogFiles.ErrorLog("Form:OtherlPerchase.aspx,Method:btnSaved_Click,Class:PartiesClass.cs"+" Fuel Purchase Invoise for  Invoice No."+obj.Invoice_No+" ,"+"for Vender Name  "+obj.Vendor_Name+  "on Date "+obj.Vendor_Name+" and NetAmount  "+obj.Net_Amount+"  is Saved "+" userid "+uid);
                        HtmlInputHidden[] ProdName = { txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8 };
                        HtmlInputHidden[] PackType = { txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8 };
                        TextBox[] Qty = { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8 };
                        TextBox[] Rate = { txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8 };
                        TextBox[] Amount = { txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8 };
                        TextBox[] Quantity = { txtTempQty1, txtTempQty2, txtTempQty3, txtTempQty4, txtTempQty5, txtTempQty6, txtTempQty7, txtTempQty8 };
                        for (int j = 0; j < ProdName.Length; j++)
                        {
                            if (Rate[j].Text == "" || Rate[j].Text == "0")
                                continue;
                            //temp = System.Convert.ToString(System.Convert.ToDouble(Qty[j].Text)-System.Convert.ToDouble(Quantity[j].Text)); 
                            temp = Qty[j].Text;
                            Save1(ProdName[j].Value, PackType[j].Value, Qty[j].Text.ToString(), Rate[j].Text.ToString(), Amount[j].Text.ToString(), temp, GenUtil.str2MMDDYYYY(lblInvoiceDate.Text.ToString()));
                        }
                        reportmaking();
                        SeqStockMaster();
                        //print();

                        MessageBox.Show("Purchase Invoice Updated");
                        CreateLogFiles.ErrorLog("Form:OtherlPerchase.aspx,Method:btnSaved_Click,Class:PartiesClass.cs" + " Fuel Purchase Invoise for  Invoice No." + obj.Invoice_No + " ," + "for Vender Name  " + obj.Vendor_Name + "on Date " + obj.Vendor_Name + " and NetAmount  " + obj.Net_Amount + "  is Updated. " + " userid " + uid);
                        DropInvoiceNo.SelectedIndex = 0;
                        DropInvoiceNo.Visible = false;
                        lblInvoiceNo.Visible = true;
                        Clear();
                        clear1();
                        lblInvoiceDate.Text = GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());
                        //CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:btnSave_Click. Purchase Invoice Updated,  User_ID: "+uid);
                    }
                }
                checkPrevileges();
            }
            catch (Exception ex)
            {
                CreateLogFiles.ErrorLog("Form:OtherPerchase.aspx,Method:btnSaved_Click,Class:PartiesClass.cs" + " Fuel Purchase Invoise for  Invoice No." + obj.Invoice_No + " ," + "for Vender Name  " + obj.Vendor_Name + "on Date " + obj.Vendor_Name + " and NetAmount  " + obj.Net_Amount + "  EXCEPTION   " + ex.Message + "  userid " + uid);
            }
        }

        /// <summary>
        /// This method clear the form.
        /// </summary>
        public void clear1()
		{
			DropDownList[] ProdType={DropType1, DropType2, DropType3, DropType4, DropType5, DropType6, DropType7, DropType8};
			DropDownList[] ProdName={DropProd1, DropProd2, DropProd3, DropProd4, DropProd5, DropProd6, DropProd7, DropProd8};
			DropDownList[] PackType={DropPack1, DropPack2, DropPack3, DropPack4, DropPack5, DropPack6, DropPack7, DropPack8};
			TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
			TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
			TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8}; 			

			for (int i=0;i<ProdType.Length;i++) 
			{
				ProdType[i].Enabled = true;
				ProdName[i].Enabled = true;
				PackType[i].Enabled = true;
				Qty[i].Enabled = true;
				Rate[i].Enabled = true;
				Amount[i].Enabled = true;
			}
			lblInvoiceDate.Text=GenUtil.str2DDMMYYYY(DateTime.Today.ToShortDateString());
		}

		/// <summary>
		/// This method is used to fatch the sales rate according to given product name and pack type.
		/// </summary>
		public void Pack_Changed(DropDownList ddProd,DropDownList ddPack,TextBox txtPurRate)
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader  SqlDtr;
				string sql;

				#region Fetch Sales Rate Regarding Product Name		
				sql= "select top 1 Pur_Rate from Price_Updation where Prod_ID=(select  Prod_ID from Products where Prod_Name='"+ ddProd.SelectedItem.Value +"' and Pack_Type='"+ ddPack.SelectedItem.Value +"') order by eff_date desc";
				SqlDtr = obj.GetRecordSet(sql);
				while(SqlDtr.Read ())
				{
					txtPurRate.Text=SqlDtr.GetValue(0).ToString();
				}
				SqlDtr.Close();
				#endregion			
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OtherPerchase.aspx,Method:Pack_Changed  EXCEPTION   "+ex.Message+". Userid "+uid);
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
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void reportmaking()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\PurchaseInvoiceReport.txt";
					
				StreamWriter sw = new StreamWriter(path);
				string info = "";
				string strInvNo="";
				string strDiscType = "";
				double disc_amt=0;
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

				//**********
				string des="-----------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("==================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("PURCHASE INVOICE",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("==================",des.Length));
				if (lblInvoiceNo.Visible==true)
					strInvNo = lblInvoiceNo.Text;
				else
					strInvNo = DropInvoiceNo.SelectedItem.Text;   

				sw.WriteLine("Invoice No : " +strInvNo+ "                               Date : " +lblInvoiceDate.Text.ToString());
				sw.WriteLine("+----------------------------------------------------------------+");
				sw.WriteLine("Vendor Name             : " + DropVendorID.SelectedItem.Value);
				sw.WriteLine("Place                   :  " + lblPlace.Value);
				sw.WriteLine("Vendor Invoice No       :  " + txtVInnvoiceNo.Text);
				sw.WriteLine("Vendor Invoice Date     :  " + txtVInvoiceDate.Text);
				sw.WriteLine("+------------------------------+-----------+----------+----------+");
				sw.WriteLine("|      Product Name            | Quantity  |   Rate   |  Amount  |");
				sw.WriteLine("+------------------------------+-----------+----------+----------+");
				info = " {0,-30:S} {1,10:F}  {2,10:F} {3,10:F}";
				sw.WriteLine(info,txtProdName1.Value+" "+txtPack1.Value ,txtQty1.Text,txtRate1.Text,GenUtil.strNumericFormat(txtAmount1.Text.ToString().Trim()));
				sw.WriteLine(info,txtProdName2.Value+" "+txtPack2.Value ,txtQty2.Text,txtRate2.Text,GenUtil.strNumericFormat(txtAmount2.Text.ToString().Trim()));
				sw.WriteLine(info,txtProdName3.Value+" "+txtPack3.Value ,txtQty3.Text,txtRate3.Text,GenUtil.strNumericFormat(txtAmount3.Text.ToString().Trim()));
				sw.WriteLine(info,txtProdName4.Value+" "+txtPack4.Value ,txtQty4.Text,txtRate4.Text,GenUtil.strNumericFormat(txtAmount4.Text.ToString().Trim()));
				sw.WriteLine(info,txtProdName5.Value+" "+txtPack5.Value ,txtQty5.Text,txtRate5.Text,GenUtil.strNumericFormat(txtAmount5.Text.ToString().Trim()));
				sw.WriteLine(info,txtProdName6.Value+" "+txtPack6.Value ,txtQty6.Text,txtRate6.Text,GenUtil.strNumericFormat(txtAmount6.Text.ToString().Trim()));
				sw.WriteLine(info,txtProdName7.Value+" "+txtPack7.Value ,txtQty7.Text,txtRate7.Text,GenUtil.strNumericFormat(txtAmount7.Text.ToString().Trim()));
				sw.WriteLine(info,txtProdName8.Value+" "+txtPack8.Value ,txtQty8.Text,txtRate8.Text,GenUtil.strNumericFormat(txtAmount8.Text.ToString().Trim()));
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
				sw.WriteLine("                                                Signature");

				sw.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OtherPerchase.aspx,Method:reportmaking().  EXCEPTION   "+ex.Message+". User_id "+uid);
			}
		}

		/// <summary>
		/// This method is used to fatch the all vendor invoice no from purchase master table and stored in hidden textbox.
		/// </summary>
		public void FatchInvoiceNo()
		{
			InventoryClass obj = new InventoryClass();
			SqlDataReader rdr;
			string str="";
			string strstr="select Vndr_Invoice_No from Purchase_Master";
			rdr = obj.GetRecordSet(strstr);
			while(rdr.Read())
			{
				str+=rdr["Vndr_Invoice_No"].ToString()+"~";
			}
			tempInvoiceInfo.Value=str;
			rdr.Close();
		}
		
		/// <summary>
		/// This function to clear the form.
		/// </summary>
		public void Clear()
		{
			Vendor_ID="0";
			CheckMode="";
			tempInvoiceNo.Value="";
			tempInvoiceInfo.Value="";	
			DropModeType.SelectedIndex=0;
			DropVendorID.SelectedIndex=0;
			lblPlace.Value = "";
			txtVehicleNo.Text="";
			txtVInnvoiceNo.Text="";
			txtVInvoiceDate.Text=""; 
			txtPromoScheme.Text="";
			txtRemark.Text="";
			txtVInvoiceDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtGrandTotal.Text="";
			txtDisc.Text="";
			txtNetAmount.Text="";
			DropDiscType.SelectedIndex=0;
			DropCashDiscType.SelectedIndex = 0;
			txtCashDisc.Text = "";
			txtVAT.Text = "";
			Yes.Checked = true;
			No.Checked = false;

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
			DropPack1.Items.Add("Select");
			DropPack1.SelectedIndex=(DropPack1.Items.IndexOf((DropPack1.Items.FindByValue ("Select"))));

			DropPack2.Items.Clear();
			DropPack2.Items.Add("Select");
			DropPack2.SelectedIndex=(DropPack2.Items.IndexOf((DropPack2.Items.FindByValue ("Select"))));
			
			DropPack3.Items.Clear();
			DropPack3.Items.Add("Select");
			DropPack3.SelectedIndex=(DropPack3.Items.IndexOf((DropPack3.Items.FindByValue ("Select"))));
			
			DropPack4.Items.Clear();
			DropPack4.Items.Add("Select");
			DropPack4.SelectedIndex=(DropPack4.Items.IndexOf((DropPack4.Items.FindByValue ("Select"))));
			
			DropPack5.Items.Clear();
			DropPack5.Items.Add("Select");
			DropPack5.SelectedIndex=(DropPack5.Items.IndexOf((DropPack5.Items.FindByValue ("Select"))));
			
			DropPack6.Items.Clear();
			DropPack6.Items.Add("Select");
			DropPack6.SelectedIndex=(DropPack6.Items.IndexOf((DropPack6.Items.FindByValue ("Select"))));
			
			DropPack7.Items.Clear();
			DropPack7.Items.Add("Select");
			DropPack7.SelectedIndex=(DropPack7.Items.IndexOf((DropPack7.Items.FindByValue ("Select"))));
			
			DropPack8.Items.Clear();
			DropPack8.Items.Add("Select");
			DropPack8.SelectedIndex=(DropPack8.Items.IndexOf((DropPack8.Items.FindByValue ("Select"))));
			
					
			DropPack1.SelectedIndex=0;
			DropPack2.SelectedIndex=0;
			DropPack3.SelectedIndex=0;
			DropPack4.SelectedIndex=0;
			DropPack5.SelectedIndex=0;
			DropPack6.SelectedIndex=0;
			DropPack7.SelectedIndex=0;
			DropPack8.SelectedIndex=0;
			txtQty1.Text="";
			txtQty2.Text="";
			txtQty3.Text="";
			txtQty4.Text="";
			txtQty5.Text="";
			txtQty6.Text="";
			txtQty7.Text="";
			txtQty8.Text="";
			txtTempQty1.Text="";
			txtTempQty2.Text="";
			txtTempQty3.Text ="";
			txtTempQty4.Text ="";
			txtTempQty5.Text ="";
			txtTempQty6.Text="";
			txtTempQty7.Text="";
			txtTempQty8.Text="";

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

			#region Clear Hidden TextBoxex
			txtProdName1.Value=""; 
			txtProdName2.Value=""; 
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
		/// This method is used to return next invoice no from the database.
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
		/// This method checks the price updation for all the products is available or not?
		/// </summary>
		public void GetProducts()
		{
			try
			{
				InventoryClass obj=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql; 
				SqlDataReader rdr=null; 

				int count = 0;
				int count1 = 0;
				dbobj.ExecuteScalar("Select Count(Prod_id) from  products where Category != 'Fuel'",ref count);
				/* This code hide by Mahesh and apply single query for fatch the total no of rows.
				sql = "select distinct p.Prod_ID,Category,Prod_Name,Pack_Type from products p,price_updation pu where Category!='Fuel' and p.prod_id =pu.prod_id order by Category,Prod_Name";
				SqlDtr = obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{			
					count1 = count1+1;
				}					
				SqlDtr.Close();
				*/
				dbobj.ExecuteScalar("select count(distinct p.Prod_ID) from products p,price_updation pu where Category!='Fuel' and p.prod_id =pu.prod_id",ref count1);//add by Mahesh
				if(count != count1)
				{
					lblMessage.Text = "Price updation not available for some products";
				}	

				#region Fetch the Product Types and fill in the ComboBoxes
				string str="";
				sql="select distinct p.Prod_ID,Category,Prod_Name,Pack_Type from products p,price_updation pu where Category!='Fuel' and p.prod_id =pu.prod_id order by Category,Prod_Name";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					#region Fetch Purchase Rate
					str=str+ SqlDtr["Category"]+":"+SqlDtr["Prod_Name"]+":"+SqlDtr["Pack_Type"];
					sql= "select top 1 Pur_Rate from Price_Updation where Prod_ID="+SqlDtr["Prod_ID"]+" order by eff_date desc";
					dbobj.SelectQuery(sql,ref rdr); 
					if(rdr.Read())
						str=str+":"+rdr["Pur_Rate"]+",";
					else
						str=str+":0,";
					rdr.Close();
					#endregion
				}
				SqlDtr.Close();
				temptext.Value=str;
				#endregion	   
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OtherPerchase.aspx,Method:GetProducts().  EXCEPTION   "+ex.Message+". User_id "+uid);
			}
		}

		/// <summary>
		/// This method is used to Fetch All Invoice NO and fill in the ComboBox
		/// </summary>
		private void BtnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				BtnEdit.Visible=false; 
				DropInvoiceNo.Visible=true;
				lblInvoiceNo .Visible=false;
				btnSave.Enabled = true; 
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string sql;
				#region Fetch All Invoice NO and fill in the ComboBox
				DropInvoiceNo.Items.Clear();
				DropInvoiceNo.Items.Add("Select");   
				sql="select distinct Invoice_No from Purchase_Details";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					DropInvoiceNo.Items.Add (SqlDtr.GetValue(0).ToString ());				
				}
				SqlDtr.Close ();
				BtnEdit.Visible=false;
				#endregion 
				CreateLogFiles.ErrorLog("Form:PurchaceInvice.aspx,Method:BtnEdit_Click. User_ID: "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OtherPerchase.aspx,Method:BtnEdit_Click().  EXCEPTION   "+ex.Message+". User_id "+uid);
			}

		}

		/// <summary>
		/// This method is used to retrieve the all values from the database according to selected value in the dropdownlist.
		/// </summary>
		private void DropInvoiceNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			InventoryClass  obj=new InventoryClass ();
			try
			{
				Txtselect.Text=DropInvoiceNo.SelectedItem.Value.ToString();
				if(Txtselect.Text=="Select")
				{
					MessageBox.Show("Please Select Invoice No");
				}
				else
				{
					Clear();
					DropDownList[] ProdType={DropType1, DropType2, DropType3, DropType4, DropType5, DropType6, DropType7, DropType8};
					DropDownList[] ProdName={DropProd1, DropProd2, DropProd3, DropProd4, DropProd5, DropProd6, DropProd7, DropProd8};
					DropDownList[] PackType={DropPack1, DropPack2, DropPack3, DropPack4, DropPack5, DropPack6, DropPack7, DropPack8};
					HtmlInputHidden[] Name={txtProdName1, txtProdName2, txtProdName3, txtProdName4, txtProdName5, txtProdName6, txtProdName7, txtProdName8}; 
					HtmlInputHidden[] Type={txtPack1, txtPack2, txtPack3, txtPack4, txtPack5, txtPack6, txtPack7, txtPack8}; 
					TextBox[]  Qty={txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8}; 
					TextBox[]  Rate={txtRate1, txtRate2, txtRate3, txtRate4, txtRate5, txtRate6, txtRate7, txtRate8}; 
					TextBox[]  Amount={txtAmount1, txtAmount2, txtAmount3, txtAmount4, txtAmount5, txtAmount6, txtAmount7, txtAmount8}; 			
					TextBox[]  Quantity = {txtTempQty1,txtTempQty2,txtTempQty3,txtTempQty4,txtTempQty5,txtTempQty6,txtTempQty7,txtTempQty8 };
					SqlDataReader SqlDtr;
					string sql;
					string strDate,strDate1;
					int i=0;
					sql="select * from Purchase_Master where Invoice_No='"+ DropInvoiceNo.SelectedItem.Value +"'" ;
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
						tempInvoiceNo.Value=GenUtil.str2DDMMYYYY(strDate);
						DropModeType.SelectedIndex=(DropModeType.Items.IndexOf((DropModeType.Items.FindByValue (SqlDtr.GetValue(2).ToString()))));
						txtVehicleNo.Text=SqlDtr.GetValue(4).ToString();
						txtVInnvoiceNo.Text=SqlDtr.GetValue(5).ToString();
						txtVInvoiceDate.Text=GenUtil.str2DDMMYYYY(strDate1);
						txtGrandTotal.Text=SqlDtr.GetValue(7).ToString();
						txtGrandTotal.Text = GenUtil.strNumericFormat(txtGrandTotal.Text);
						txtDisc.Text=GenUtil.strNumericFormat(SqlDtr.GetValue(8).ToString()); 
						DropDiscType.SelectedIndex= DropDiscType.Items.IndexOf((DropDiscType.Items.FindByValue(SqlDtr.GetValue(9).ToString())));
						txtNetAmount.Text =SqlDtr.GetValue(10).ToString(); 
						txtNetAmount.Text = GenUtil.strNumericFormat(txtNetAmount.Text);
						txtPromoScheme.Text= SqlDtr.GetValue(11).ToString(); 
						txtRemark.Text=SqlDtr.GetValue(12).ToString();  
						lblEntryBy.Text=SqlDtr.GetValue(13).ToString();  
						lblEntryTime.Text= SqlDtr.GetValue(14).ToString();  
						txtCashDisc.Text=SqlDtr.GetValue(15).ToString(); 
						txtCashDisc.Text = GenUtil.strNumericFormat(txtCashDisc.Text.ToString()); 
						DropCashDiscType.SelectedIndex= DropCashDiscType.Items.IndexOf((DropCashDiscType.Items.FindByValue(SqlDtr.GetValue(16).ToString())));
						txtVAT.Text =  SqlDtr.GetValue(17).ToString();
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
						Vendor_ID=SqlDtr["Vendor_ID"].ToString();
						CheckMode=SqlDtr["Mode_of_Payment"].ToString();
					}
					SqlDtr.Close();
					sql="select s.Supp_Name,s.City from Supplier as s, Purchase_Master as p where p.Invoice_No='"+DropInvoiceNo.SelectedValue +"' and S.Supp_ID = P.Vendor_ID ";
					SqlDtr=obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						DropVendorID.SelectedIndex=(DropVendorID .Items.IndexOf((DropVendorID .Items.FindByValue (SqlDtr.GetValue(0).ToString()))));
						lblPlace.Value=SqlDtr.GetValue(1).ToString();  
					}   
					SqlDtr.Close();

					#region Get Data from Purchase Details Table regarding Invoice No.
					sql="select p.Category,p.Prod_Name,p.Pack_Type,	pd.qty,pd.rate,pd.amount"+
						" from Products p, Purchase_Details pd"+
						" where p.Prod_ID=pd.prod_id and pd.invoice_no='"+ DropInvoiceNo.SelectedItem.Value +"'" ;

					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						ProdType[i].Enabled = true; 
						ProdName[i].Enabled = true; 
						PackType[i].Enabled = true; 
						Rate[i].Enabled = true;
						Qty[i].Enabled = true;
						Amount[i].Enabled = true; 
						
						ProdType[i].SelectedIndex=ProdType[i].Items.IndexOf(ProdType[i].Items.FindByValue(SqlDtr.GetValue(0).ToString ()));
						Type_Changed(ProdType[i] ,ProdName[i] ,PackType[i] );  
				
						ProdName[i].SelectedIndex=ProdName[i].Items.IndexOf(ProdName[i].Items.FindByValue(SqlDtr.GetValue(1).ToString ()));
						Prod_Changed(ProdType[i], ProdName[i] ,PackType[i] ,Rate[i]);    
						Name[i].Value=SqlDtr.GetValue(1).ToString();   
						PackType[i].SelectedIndex=PackType[i].Items.IndexOf(PackType[i].Items.FindByValue(SqlDtr.GetValue(2).ToString ()));
						Type[i].Value=SqlDtr.GetValue(2).ToString();   
						Qty[i].Text=SqlDtr.GetValue(3).ToString();
						Quantity[i].Text = Qty[i].Text;
						Rate[i].Text=SqlDtr.GetValue(4).ToString();
						Amount[i].Text=SqlDtr.GetValue(5).ToString();
						//****
						ProductType[i]=SqlDtr.GetValue(0).ToString ();
						ProductName[i]=SqlDtr.GetValue(1).ToString ();
						ProductPack[i]=SqlDtr.GetValue(2).ToString ();
						ProductQty[i]=SqlDtr.GetValue(3).ToString();
						//****
						i++;
					}
					/*
					while(i<8)
					{
						ProdType[i].SelectedIndex=0;
						ProdType[i].Enabled = false; 
						ProdName[i].SelectedIndex=0;
						ProdName[i].Enabled = false; 
						PackType[i].Items.Clear();
						PackType[i].Items.Add("Select");
						PackType[i].SelectedIndex=(PackType[i].Items.IndexOf((PackType[i].Items.FindByValue ("Select"))));
						PackType[i].Enabled = false; 
						Qty[i].Text="";
						Qty[i].Enabled = false;
						Quantity[i].Text = "";
						Quantity[i].Enabled = false; 
						Rate[i].Text="";
						Rate[i].Enabled = false;
						Amount[i].Text="";
						Amount[i].Enabled = false; 
						i++;
					}
					*/
					SqlDtr.Close();
					#endregion

				}
				BtnEdit.Visible=false;
				
				CreateLogFiles.ErrorLog("Form:Perchaseinvoice.aspx,Method : DropInvoiceNo_SelectedIndexChanged "+" Invoise No :-"+"Invoice No="+DropInvoiceNo.SelectedItem.Value.ToString()+"  userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OtherPerchase.aspx,Method:btnSaved_Click,Class:PartiesClass.cs,Method : DropInvoiceNo_SelectedIndexChanged "+" Other Purchase Invoise  Updated to    :-"+"Invoice No="+obj.Invoice_No+"  EXCEPTION  "+ex.Message+"  userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to write into the report file to print.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			//reportmaking();
			print();
		}

		/// <summary>
		/// This method is used to update the product qty in edit time.
		/// </summary>
		public void UpdateProductQty()
		{
			for(int i=0;i<ProductType.Length;i++)
			{
				if(ProductType[i]=="" || ProductName[i]=="" || ProductQty[i]=="")
					continue;
				else
				{
					string cat=ProductType[i];
					string pn=ProductName[i];
					string pt=ProductPack[i];
					string qty=ProductQty[i];
					InventoryClass obj = new InventoryClass();
					SqlDataReader rdr;
					SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
					string str="select Prod_ID from Products where Category='"+ProductType[i].ToString()+"' and Prod_Name='"+ProductName[i].ToString()+"' and Pack_Type='"+ProductPack[i].ToString()+"'";
					rdr=obj.GetRecordSet(str);
					if(rdr.Read())
					{
						Con.Open();
						//SqlCommand cmd = new SqlCommand("update Stock_Master set receipt=receipt-"+double.Parse(ProductQty[i].ToString())+", Closing_Stock=Closing_Stock-"+double.Parse(ProductQty[i].ToString())+" where ProductID='"+rdr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(Stock_Date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(lblInvoiceDate.Text)+"'",Con);
						SqlCommand cmd = new SqlCommand("update Stock_Master set receipt=receipt-"+double.Parse(ProductQty[i].ToString())+", Closing_Stock=Closing_Stock-"+double.Parse(ProductQty[i].ToString())+" where ProductID='"+rdr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(Stock_Date as datetime) as float)) as datetime)='"+GenUtil.str2MMDDYYYY(tempInvoiceNo.Value)+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
					}
					rdr.Close();
				}
			}
		}
		
		/// <summary>
		/// This method is used to delete the particular record select from dropdownlist.
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
				for(int i=0;i<8;i++)
				{
					if(DropType[i].SelectedItem.Text.Equals("Type") || ProdName[i].Value=="" || PackType[i].Value=="")
						continue;
					else
					{
						Con.Open();
						cmd = new SqlCommand("update Stock_Master set receipt=receipt-'"+double.Parse(Qty[i].Text)+"',closing_stock=closing_stock-'"+double.Parse(Qty[i].Text)+"' where ProductID=(select Prod_ID from Products where Category='"+DropType[i].SelectedItem.Text+"' and Prod_Name='"+ProdName[i].Value+"' and Pack_Type='"+PackType[i].Value+"') and cast(stock_date as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtVInvoiceDate.Text)+"'",Con);
						cmd.ExecuteNonQuery();
						Con.Close();
						cmd.Dispose();
					}
				}
				SeqStockMaster();
				CreateLogFiles.ErrorLog("Form:PurchaseInvoice.aspx,Method:btnDelete_Click - InvoiceNo : " + DropInvoiceNo.SelectedItem.Text+" Deleted, user : "+uid);
				Clear();
				clear1();
				GetNextInvoiceNo();
				GetProducts();
				//FatchInvoiceNo();
				FatchInvoiceNo();
				lblInvoiceNo.Visible=true; 
				DropInvoiceNo.Visible=false;
				BtnEdit.Visible=true;
				MessageBox.Show("Purchase Transaction Deleted");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaseInvoice.aspx,Method:btnDelete_Click - InvoiceNo : " + DropInvoiceNo.SelectedItem.Text+" ,Exception : "+ex.Message+" user : "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to update the product stock after update the purchase invoice in edit time.
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
                            DateTime SD =System.Convert.ToDateTime(rdr1["stock_date"].ToString());

                            Con.Open();
							cmd = new SqlCommand("update Stock_Master set opening_stock='"+OS.ToString()+"', Closing_Stock='"+CS.ToString()+"' where ProductID='"+rdr1["Productid"].ToString()+"' and Stock_Date='"+ GenUtil.str2MMDDYYYY(SD.ToString())+ "'",Con);
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