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
	/// Summary description for StockAdjustment.
	/// </summary>
	public class StockAdjustment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.DropDownList DropOutProd1;
		protected System.Web.UI.WebControls.DropDownList DropOutProd2;
		protected System.Web.UI.WebControls.DropDownList DropOutProd3;
		protected System.Web.UI.WebControls.DropDownList DropOutProd4;
		protected System.Web.UI.WebControls.DropDownList DropInProd1;
		protected System.Web.UI.WebControls.DropDownList DropInProd2;
		protected System.Web.UI.WebControls.DropDownList DropInProd3;
		protected System.Web.UI.WebControls.DropDownList DropInProd4;
		protected System.Web.UI.WebControls.TextBox txtOutStoreIn1;
		protected System.Web.UI.WebControls.TextBox txtOutStoreIn2;
		protected System.Web.UI.WebControls.TextBox txtOutQtyPack1;
		protected System.Web.UI.WebControls.TextBox txtOutQtyLtr1;
		protected System.Web.UI.WebControls.TextBox txtOutQtyPack2;
		protected System.Web.UI.WebControls.TextBox txtOutQtyLtr2;
		protected System.Web.UI.WebControls.TextBox txtOutStoreIn3;
		protected System.Web.UI.WebControls.TextBox txtOutQtyPack3;
		protected System.Web.UI.WebControls.TextBox txtOutQtyLtr3;
		protected System.Web.UI.WebControls.TextBox txtOutStoreIn4;
		protected System.Web.UI.WebControls.TextBox txtOutQtyPack4;
		protected System.Web.UI.WebControls.TextBox txtOutQtyLtr4;
		protected System.Web.UI.WebControls.TextBox txtInStoreIn1;
		protected System.Web.UI.WebControls.TextBox txtInQtyPack1;
		protected System.Web.UI.WebControls.TextBox txtInQtyLtr1;
		protected System.Web.UI.WebControls.TextBox txtInStoreIn2;
		protected System.Web.UI.WebControls.TextBox txtInQtyPack2;
		protected System.Web.UI.WebControls.TextBox txtInQtyLtr2;
		protected System.Web.UI.WebControls.TextBox txtInStoreIn3;
		protected System.Web.UI.WebControls.TextBox txtInQtyPack3;
		protected System.Web.UI.WebControls.TextBox txtInQtyLtr3;
		protected System.Web.UI.WebControls.TextBox txtInStoreIn4;
		protected System.Web.UI.WebControls.TextBox txtInQtyPack4;
		protected System.Web.UI.WebControls.TextBox txtInQtyLtr4;
		protected System.Web.UI.WebControls.TextBox txtTotalInQtyPack;
		protected System.Web.UI.WebControls.TextBox txtTotalOutQtyPack;
		protected System.Web.UI.WebControls.TextBox txtTotalOutQtyLtr;
		protected System.Web.UI.WebControls.TextBox txtTotalInQtyLtr;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTemp;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTemp1;
		protected System.Web.UI.WebControls.Label lblSAV_ID;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtQty;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpOutQtyLtr1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpOutQtyLtr2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpOutQtyLtr3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpOutQtyLtr4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpInQtyLtr1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpInQtyLtr2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpInQtyLtr3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tmpInQtyLtr4;
		protected System.Web.UI.WebControls.Button Button1;
		string uid = "";

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
				uid=(Session["User_Name"].ToString());
				if(!Page.IsPostBack)
				{
                    txtOutStoreIn1.Attributes.Add("readonly", "readonly");
                    txtOutStoreIn2.Attributes.Add("readonly", "readonly");
                    txtOutStoreIn3.Attributes.Add("readonly", "readonly");
                    txtOutStoreIn4.Attributes.Add("readonly", "readonly");
                    txtTotalOutQtyPack.Attributes.Add("readonly", "readonly");
                    txtTotalOutQtyLtr.Attributes.Add("readonly", "readonly");
                    txtInStoreIn1.Attributes.Add("readonly", "readonly");
                    txtInStoreIn2.Attributes.Add("readonly", "readonly");
                    txtInStoreIn3.Attributes.Add("readonly", "readonly");
                    txtInStoreIn4.Attributes.Add("readonly", "readonly");
                    txtTotalInQtyPack.Attributes.Add("readonly", "readonly");
                    txtTotalInQtyLtr.Attributes.Add("readonly", "readonly");






                    checkPrevileges(); 
					fillCombo();
					getStoreIn();
					getID();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:page_load  EXCEPTION: "+ ex.Message+".  UserID: "+uid);	
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
		}

		/// <summary>
		/// Its checks the User Privilegs.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="4";
			string SubModule="8";
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
				btnPrint.Enabled = false; 
			}
			#endregion				
		}

		/// <summary>
		/// Its fills all the Product Name combos with Product Names and their packege.
		/// </summary>
		public void fillCombo()
		{
			DropDownList[] Products = {DropOutProd1,DropOutProd2,DropOutProd3,DropOutProd4,DropInProd1,DropInProd2,DropInProd3,DropInProd4};
			try
			{
				SqlDataReader SqlDtr = null;
				for(int i= 0; i< Products.Length; i++)
				{
					Products[i].Items.Clear();
					Products[i].Items.Add("Select"); 
				}

				dbobj.SelectQuery("Select case when pack_type != '' then Prod_Name+':'+Pack_Type else Prod_Name  end from products order by Prod_Name",ref SqlDtr);
				while(SqlDtr.Read())
				{
					for(int i= 0; i< Products.Length; i++)
					{
						Products[i].Items.Add(SqlDtr.GetValue(0).ToString() ); 
					}
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:fillCombo()  EXCEPTION: "+ ex.Message+".  UserID: "+uid);	
			}
		}

		/// <summary>
		/// This function  fetches the products store in location, Category, Package and quantity. And add this into hidden fields to use in java script.
		/// </summary>
		public void getStoreIn()
		{
			SqlDataReader SqlDtr = null;
			SqlDataReader SqlDtr1= null;
			SqlDataReader SqlDtr2 = null;
			string product_info="";
			string product_info1 = "";
			string product_info2 = "";

			try
			{
				dbobj.SelectQuery("Select case when pack_type != '' then Prod_Name+':'+Pack_Type else Prod_Name  end,Category,Store_In,Pack_Type,Prod_ID from products",ref SqlDtr);
				while(SqlDtr.Read())
				{
					if(SqlDtr.GetValue(1).ToString().Equals("Fuel"))
					{
						dbobj.SelectQuery("Select Prod_AbbName from tank where Tank_ID = "+SqlDtr.GetValue(2).ToString()+"", ref SqlDtr1);
						if(SqlDtr1.Read())
						{
							product_info = product_info+SqlDtr.GetValue(0).ToString().Trim() +"~"+SqlDtr.GetValue(1).ToString().Trim() +"~"+SqlDtr1.GetValue(0).ToString().Trim()+"~"+" "+"#";    
							product_info1 = product_info1+SqlDtr.GetValue(0).ToString().Trim()+"~"+"1X1#";
						}
						SqlDtr1.Close();
					}
					else
					{
						product_info = product_info+SqlDtr.GetValue(0).ToString().Trim() +"~"+SqlDtr.GetValue(1).ToString().Trim() +"~"+SqlDtr.GetValue(2).ToString().Trim() +"~"+SqlDtr.GetValue(3).ToString().Trim()+"#";    
						product_info1 = product_info1+SqlDtr.GetValue(0).ToString().Trim()+"~"+SqlDtr.GetValue(3).ToString()+"#";
					}
					dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = "+SqlDtr.GetValue(4).ToString()+" order by stock_date desc",ref SqlDtr2);
					if(SqlDtr2.Read())
					{
						product_info2 = product_info2 + SqlDtr.GetValue(0).ToString().Trim() +"~"  +SqlDtr2.GetValue(0).ToString()+"#";  
					}
					SqlDtr2.Close() ;
				}
				SqlDtr.Close();
			
				txtTemp.Value = product_info;
				txtTemp1.Value = product_info1;
				txtQty.Value = product_info2;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:getStoreIn()  EXCEPTION: "+ ex.Message+".  UserID: "+uid);	
			}
		}

		/// <summary>
		/// Its fetches the Max. Stock Adjustment ID from Stock_Adjustment to display on screen.
		/// </summary>
		public void getID()
		{
			SqlDataReader SqlDtr = null;
			try
			{
				dbobj.SelectQuery("Select max(SAV_ID)+1 from Stock_Adjustment",ref SqlDtr);
				if(SqlDtr.Read())
				{
					if(!SqlDtr.GetValue(0).ToString().Trim().Equals(""))   
						lblSAV_ID.Text  = SqlDtr.GetValue(0).ToString();  
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:getID()  EXCEPTION: "+ ex.Message+".  UserID: "+uid);	
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Its fetch the values from screen and calls the save fucntion for each row.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			DropDownList[] Products = {DropOutProd1,DropOutProd2,DropOutProd3,DropOutProd4,DropInProd1,DropInProd2,DropInProd3,DropInProd4};
			TextBox[] QtyPack = {txtOutQtyPack1 ,txtOutQtyPack2,txtOutQtyPack3 ,txtOutQtyPack4 ,txtInQtyPack1 ,txtInQtyPack2 ,txtInQtyPack3 ,txtInQtyPack4 };
			TextBox[] QtyLtr = {txtOutQtyLtr1 ,txtOutQtyLtr2,txtOutQtyLtr3 ,txtOutQtyLtr4 ,txtInQtyLtr1 ,txtInQtyLtr2 ,txtInQtyLtr3 ,txtInQtyLtr4 };
			TextBox[] Store_In = {txtOutStoreIn1,txtOutStoreIn2,txtOutStoreIn3,txtOutStoreIn4,txtInStoreIn1,txtInStoreIn2,txtInStoreIn3,txtInStoreIn4 };

			try
			{
				int count = 0;
				for(int i = 0; i< Products.Length-4; i++)
				{
					if(Products[i].SelectedIndex == 0 && Products[i+4].SelectedIndex == 0 )
						count++;

					if(Products[i].SelectedIndex == 0 && Products[i+4].SelectedIndex != 0 )
					{
						MessageBox.Show("Please Select the OUT Product at Row "+(i+1));
						return;
					}

					if(Products[i].SelectedIndex != 0 && Products[i+4].SelectedIndex == 0 )
					{
						MessageBox.Show("Please Select the IN Product at Row "+(i+1));
						return;
					}
				  
				}

				if(count == 4 )
				{
					MessageBox.Show("Please Select Product");
					return;
				}


				string prod_name1= "";
				string pack1 = "";
				string prod_name2= "";
				string pack2 = "";
				string qty1 = "";
				string qty2 = "";
				string store1 = "";
				string store2 = "";
				string type1 = "";
				string type2 = "";
				string sav_id = lblSAV_ID.Text.ToString(); 

				for(int i = 0; i< Products.Length-4; i++)
				{
					if(Products[i].SelectedIndex != 0 && Products[i+4].SelectedIndex != 0)
					{
						// Fetch the OUT products package and quantity if the product is of category Fuel or if the package is Loose then  take the Ltr quantity.
						if(Products[i].SelectedItem.ToString().IndexOf(":") > -1  )
						{
							string[] arr = Products[i].SelectedItem.ToString().Split(new char[] {':'}  ,Products[i].SelectedItem.ToString().Length );
							prod_name1 = arr[0].Trim();
							pack1 = arr[1].Trim();
							if(pack1.IndexOf("Loose") > -1)
							{
								qty1 = QtyLtr[i].Text.Trim();
							}
							else
							{
								qty1 = QtyPack[i].Text.Trim(); 
							}
							store1 = Store_In[i].Text.Trim ();
							type1 = "Other" ;
						}
						else
						{
							prod_name1  = Products[i].SelectedItem.ToString().Trim();
							pack1 = "";
							qty1 = QtyLtr[i].Text.Trim();
							store1 = Store_In[i].Text.Trim ();
							type1 = "Fuel";
						}

						// Fetch the IN Products packages and quantity.if the product is of category Fuel or if the package is Loose then  take the Ltr quantity.
						if(Products[i+4].SelectedItem.ToString().IndexOf(":") > -1 )
						{
							string[] arr1 = Products[i+4].SelectedItem.ToString().Split(new char[] {':'}  ,Products[i+4].SelectedItem.ToString().Length );
							prod_name2 = arr1[0].Trim();
							pack2 = arr1[1].Trim();
							if(pack2.IndexOf("Loose") > -1)
							{
								qty2 = QtyLtr[i+4].Text.Trim();
							}
							else
							{
								qty2 = QtyPack[i+4].Text.Trim();
							}
							store2 = Store_In[i+4].Text.Trim ();
							type2 = "Other";
						}
						else
						{
							prod_name2  = Products[i+4].SelectedItem.ToString().Trim();
							pack2 = "";
							qty2 = QtyLtr[i+4].Text.Trim();
							store2 = Store_In[i+4].Text.Trim ();
							type2 = "Fuel";
						}
						save(sav_id,prod_name1,pack1,store1,type1,qty1,prod_name2,pack2,store2,type2,qty2);   
					}
					else
						continue;
				}

				MessageBox.Show("Stock Adjustment Saved"); 
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:btnPrint_Click  Stock Adjustment with ID "+lblSAV_ID.Text+" saved. UserID: "+uid);	
				makingReport();
				//Print();
				clear();
				getID(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:btnPrint_Click  EXCEPTION: "+ ex.Message+".  UserID: "+uid);	
			}
		}
		
		/// <summary>
		/// its calls the procedure ProInsertStockAdjustment to insert the stock adjustment details of each product.
		/// </summary>
		public void save(string sav_id, string prod_name1,string pack1,string store1,string type1,string qty1,string prod_name2,string pack2,string store2,string type2, string qty2)
		{
			try
			{
				object obj = null;
				dbobj.ExecProc(OprType.Insert,"ProInsertStockAdjustment",ref obj,"@SAV_ID",sav_id,"@Out_Product",prod_name1,"@pack1",pack1,"@Store1",store1,"@Type1",type1,"@Out_Qty",qty1,"@In_Product",prod_name2,"@Pack2",pack2 ,"@Store2",store2,"@Type2",type2,"@In_Qty",qty2,"@Entry_By",uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:Save()  EXCEPTION: "+ ex.Message+".  UserID: "+uid);	
			}
		}

		/// <summary>
		/// This method is used to clears the form.
		/// </summary>
		public void clear()
		{
			DropDownList[] Products = {DropOutProd1,DropOutProd2,DropOutProd3,DropOutProd4,DropInProd1,DropInProd2,DropInProd3,DropInProd4};
			TextBox[] QtyPack = {txtOutQtyPack1 ,txtOutQtyPack2,txtOutQtyPack3 ,txtOutQtyPack4 ,txtInQtyPack1 ,txtInQtyPack2 ,txtInQtyPack3 ,txtInQtyPack4 };
			TextBox[] QtyLtr = {txtOutQtyLtr1 ,txtOutQtyLtr2,txtOutQtyLtr3 ,txtOutQtyLtr4 ,txtInQtyLtr1 ,txtInQtyLtr2 ,txtInQtyLtr3 ,txtInQtyLtr4 };
			HtmlInputHidden[] QtyLtr1 = {tmpOutQtyLtr1 ,tmpOutQtyLtr2,tmpOutQtyLtr3 ,tmpOutQtyLtr4 ,tmpInQtyLtr1 ,tmpInQtyLtr2 ,tmpInQtyLtr3 ,tmpInQtyLtr4 };
			TextBox[] Store_In = {txtOutStoreIn1,txtOutStoreIn2,txtOutStoreIn3,txtOutStoreIn4,txtInStoreIn1,txtInStoreIn2,txtInStoreIn3,txtInStoreIn4 };
			for(int i =0; i < Products.Length ; i++)
			{
				Products[i].SelectedIndex = 0;
				QtyPack[i].Enabled = true;
				QtyPack[i].Text = "";
				QtyLtr[i].Enabled = true;
				QtyLtr[i].Text = "";
				QtyLtr1[i].Value = "";
				Store_In[i].Text = "";
              
			}
			txtTotalInQtyLtr.Text = "";
			txtTotalInQtyPack.Text = "";
			txtTotalOutQtyLtr.Text = "";
			txtTotalOutQtyPack.Text = ""; 
	
		}

		/// <summary>
		/// Fetch the details from screen and writes into a StockAdjustment.txt file.
		/// </summary>
		public void makingReport()
		{
			/*
													   ========================
													   Stock Adjustment Voucher
													   ========================

			+------------------------------------------------------+------------------------------------------------------+
			|                          OUT                         |                           IN                         |
			+--------------------+---------------+-------+---------+--------------------+---------------+-------+---------+
			|                    |               | Qty.  |         |                    |               | Qty.  |         |
			|   Product Name &   |   Store In    |  in   | Qty. in |   Product Name &   |   Store In    |  in   | Qty. in |
			|      Package       |               | Pack. |   Ltr.  |      Package       |               | Pack. |   Ltr.  |
			+--------------------+---------------+-------+---------+--------------------+---------------+-------+---------+
			 12345678901234567890 123456789012345 123.555 123456789 12345678901234567890 123456789012345 123.555 123456789 
                                                                                                                
                                                                                                               
                                                                                                               
                                                                                                                
                                                                                                                   
                                                                                                               
                                                                                                               
			+--------------------+---------------+-------+---------+--------------------+---------------+-------+---------+
								  Total Out:      1234.55 123456789                      Total IN:       1234.55 123456789        
			+------------------------------------------------------+------------------------------------------------------+
			*/
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\StockAdjustment.txt";
				StreamWriter sw = new StreamWriter(path);
				DropDownList[] Products = {DropOutProd1,DropOutProd2,DropOutProd3,DropOutProd4,DropInProd1,DropInProd2,DropInProd3,DropInProd4};
				TextBox[] QtyPack = {txtOutQtyPack1 ,txtOutQtyPack2,txtOutQtyPack3 ,txtOutQtyPack4 ,txtInQtyPack1 ,txtInQtyPack2 ,txtInQtyPack3 ,txtInQtyPack4 };
				HtmlInputHidden[] QtyLtr = {tmpOutQtyLtr1 ,tmpOutQtyLtr2,tmpOutQtyLtr3 ,tmpOutQtyLtr4 ,tmpInQtyLtr1 ,tmpInQtyLtr2 ,tmpInQtyLtr3 ,tmpInQtyLtr4 };
				TextBox[] QtyLtr1 = {txtOutQtyLtr1 ,txtOutQtyLtr2,txtOutQtyLtr3 ,txtOutQtyLtr4 ,txtInQtyLtr1 ,txtInQtyLtr2 ,txtInQtyLtr3 ,txtInQtyLtr4 };
				TextBox[] Store_In = {txtOutStoreIn1,txtOutStoreIn2,txtOutStoreIn3,txtOutStoreIn4,txtInStoreIn1,txtInStoreIn2,txtInStoreIn3,txtInStoreIn4 };
				for(int i = 0; i < QtyLtr1.Length ; i++)
				{
					if(QtyLtr1[i].Text.Trim()  != "")
					{
						QtyLtr[i].Value =  QtyLtr1[i].Text.Trim();
					}
				}

				string info = "";

				// Condensed
				sw.Write((char)15);
				sw.WriteLine("");
				//**********
				string des="----------------------------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("==========================",des.Length)) ;
				sw.WriteLine(GenUtil.GetCenterAddr("Stock Adjustment Voucher",des.Length)) ;
				sw.WriteLine(GenUtil.GetCenterAddr("==========================",des.Length)) ;
				sw.WriteLine("") ;
				sw.WriteLine("+----------------------------------------------------------------+----------------------------------------------------------------+") ;
				sw.WriteLine("|                              OUT                               |                               IN                               |") ;
				sw.WriteLine("+------------------------------+---------------+-------+---------+------------------------------+---------------+-------+---------+") ;
				sw.WriteLine("|                              |               | Qty.  |         |                              |               | Qty.  |         |") ;
				sw.WriteLine("|     Product Name &           |   Store In    |  in   | Qty. in |     Product Name &           |   Store In    |  in   | Qty. in |") ;
				sw.WriteLine("|         Package              |               | Pack. |   Ltr.  |        Package               |               | Pack. |   Ltr.  |") ;
				sw.WriteLine("+------------------------------+---------------+-------+---------+------------------------------+---------------+-------+---------+") ;
				// " 1234567890123456789012345 123456789012345 123.555 123456789 12345678901234567890 123456789012345 123.555 123456789 ";
				info = " {0,-30:S} {1,-15:S} {2,7:F} {3,9:F} {4,-30:S} {5,-15:S} {6,7:F} {7,9:F}";
				if(Products[0].SelectedIndex != 0)
				{
			
					sw.WriteLine(info,Products[0].SelectedItem.Text.Trim(),Store_In[0].Text.Trim(),QtyPack[0].Text.Trim(),QtyLtr[0].Value.Trim(),Products[4].SelectedItem.Text.Trim(),Store_In[4].Text.Trim(),QtyPack[4].Text.Trim(),QtyLtr[4].Value.Trim()); 
				}
				else
					sw.WriteLine(info,"","","","","","","",""); 

				if(Products[1].SelectedIndex != 0)
					sw.WriteLine(info,Products[1].SelectedItem.Text.Trim(),Store_In[1].Text.Trim(),QtyPack[1].Text.Trim(),QtyLtr[1].Value.Trim(),Products[5].SelectedItem.Text.Trim(),Store_In[5].Text.Trim(),QtyPack[5].Text.Trim(),QtyLtr[5].Value.Trim()); 
				else
					sw.WriteLine(info,"","","","","","","","");

				if(Products[2].SelectedIndex != 0)
					sw.WriteLine(info,Products[2].SelectedItem.Text.Trim(),Store_In[2].Text.Trim(),QtyPack[2].Text.Trim(),QtyLtr[2].Value.Trim(),Products[6].SelectedItem.Text.Trim(),Store_In[6].Text.Trim(),QtyPack[6].Text.Trim(),QtyLtr[6].Value.Trim()); 
				else
					sw.WriteLine(info,"","","","","","","","");

				if(Products[3].SelectedIndex != 0)
					sw.WriteLine(info,Products[3].SelectedItem.Text.Trim(),Store_In[3].Text.Trim(),QtyPack[3].Text.Trim(),QtyLtr[3].Value.Trim(),Products[7].SelectedItem.Text.Trim(),Store_In[7].Text.Trim(),QtyPack[7].Text.Trim(),QtyLtr[7].Value.Trim()); 
				else
					sw.WriteLine(info,"","","","","","","",""); 
				sw.WriteLine("+------------------------------+---------------+-------+---------+------------------------------+---------------+-------+---------+") ;
				sw.WriteLine("                                Total Out:      {0,7:F} {1,9:F}                                Total IN:       {2,7:F} {3,9:F} ",txtTotalOutQtyPack.Text,txtTotalOutQtyLtr.Text,txtTotalInQtyPack.Text,txtTotalInQtyLtr.Text); 
				sw.WriteLine("+------------------------------+---------------+-------+---------+------------------------------+---------------+-------+---------+") ;
				// deselect Condensed
				//sw.Write((char)18);
				//sw.Write((char)12);
				sw.Close();		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:makingReport()  EXCEPTION: "+ ex.Message+".  UserID: "+uid);	
			}
		}

		/// <summary>
		/// This method is used to sends the StockAdjustment.txt file name to print server.
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
					CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\StockAdjustment.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					//CreateLogFiles.ErrorLog("Form:Vehiclereport.aspx,Method:print"+ "  Daily sales record  Printed   userid  "+uid);
					CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:print"+ " Report Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockAdjustment.aspx,Method:print"+ " EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// Method to write into the report file to print.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			//makingReport();
			Print();
		}
	}
}