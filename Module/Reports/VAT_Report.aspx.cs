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
using EPetro.Sysitem.Classes;
using RMG; 
using System.Data .SqlClient ;
using System.Net; 
using System.Net.Sockets ;
using System.IO ;
using System.Text;
using DBOperations;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for VAT_Report.
	/// </summary>
	public class VAT_Report : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DataGrid SalesGrid;
		protected System.Web.UI.WebControls.Label lblSalesHeading;
		protected System.Web.UI.WebControls.DataGrid PurchaseGrid;
		protected System.Web.UI.WebControls.Label lblPurchaseHeading;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		protected System.Web.UI.WebControls.DropDownList DropReportType;
		protected System.Web.UI.WebControls.Button cmdrpt;
		protected System.Web.UI.WebControls.Button BtnPrint;
		string uid = "";
		string strOrderBy="";
		string strOrderBy1="";
		public double grand_total = 0;
		public double vat_total = 0;
		public double net_total = 0;
		public double cash_discount = 0;
		protected System.Web.UI.WebControls.DropDownList DropReportCategory;
		public double other_discount = 0;
		protected System.Web.UI.WebControls.Button btnExcel;
		System.Globalization.NumberFormatInfo  nfi = new System.Globalization.CultureInfo("en-US",false).NumberFormat;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				uid=(Session["User_Name"].ToString());
				if(! IsPostBack)
				{
					txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					txtDateTo.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="22";
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
					if(View_flag=="0")
					{
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
						return;
					}
					#endregion 
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"  "+ uid );
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
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
			this.cmdrpt.Click += new System.EventHandler(this.cmdrpt_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to checks the validity of form input fields.
		/// </summary>
		public bool checkValidity()
		{
			string ErrorMessage = "";
			bool flag = true;
			
			if(txtDateFrom.Text.Trim().Equals(""))
			{
				ErrorMessage = ErrorMessage + " - Please Select From Date\n";
				flag = false;
			}
			if(txtDateTo.Text.Trim().Equals(""))
			{
				ErrorMessage = ErrorMessage + " - Please Select To Date\n";
				flag = false;
			}
			/*if(DropReportType.SelectedIndex  == 0)
			{
				ErrorMessage = ErrorMessage + " - Please Select Report\n";
				flag = false;
			}*/
			/*if(DropReportType.SelectedIndex  == 0)
			{
				ErrorMessage = ErrorMessage + " - Please Select Report\n";
				flag = false;
			}*/

			if(flag == false)
			{
				MessageBox.Show(ErrorMessage);
				return false;
			}
			if(System.DateTime.Compare(ToMMddYYYY(txtDateFrom.Text.Trim()),ToMMddYYYY(txtDateTo.Text.Trim())) > 0)
			{
				MessageBox.Show("Date From Should be less than Date To");
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// This method is used to return the data in MM/dd/YYYY format
		/// </summary>
		public DateTime ToMMddYYYY(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];			
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);			
			return(dt);
		}

		/// <summary>
		/// This methos is used to increment the grand total by the passing value.
		/// </summary>
		protected void GrandTotal(double _grandtotal)
		{
			grand_total += _grandtotal; 
		}

		/// <summary>
		/// This method is used to increment the vat total by passing value.
		/// </summary>
		protected void VATTotal(double _vattotal)
		{
			vat_total  += _vattotal; 
		}
		
		/// <summary>
		/// This method is used to increment the net total by passing value.
		/// </summary>
		protected void NetTotal(double _nettotal)
		{
			net_total  += _nettotal; 
		}
		/// <summary>
		/// This method is used to invrement the cash discount by passing value.
		/// </summary>
		protected void CashDiscount(double _cashdiscount)
		{
			cash_discount  += _cashdiscount; 
		}

		/// <summary>
		/// This method is used to increment the other discount by passing value.
		/// </summary>
		protected void OtherDiscount(double _otherdiscount)
		{
			other_discount  += _otherdiscount; 
		}

		/// <summary>
		/// This method is used to called from the data grid and declare in the data grid tag parameter OnItemDataBound
		/// </summary>
		public void ItemTotal(object sender,DataGridItemEventArgs e)
		{
			// If the cell item is not a header and footer then pass calls the total functions by passing the corressponding values.
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem )  )
			{
				GrandTotal(Double.Parse(e.Item.Cells[5].Text));
				CashDiscount(Double.Parse(e.Item.Cells[6].Text)); 
				VATTotal(Double.Parse(e.Item.Cells[7].Text));
				OtherDiscount(Double.Parse(e.Item.Cells[8].Text));
				NetTotal(Double.Parse(e.Item.Cells[9].Text));
			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				// else if the item cell is footer then display the final total values in corressponding cells and columns. the nfi is used to display the amount in #,###.00 format
				e.Item.Cells[5].Text =grand_total.ToString("N",nfi);   
				e.Item.Cells[6].Text = cash_discount.ToString("N",nfi); 
				e.Item.Cells[7].Text = vat_total.ToString("N",nfi);  
				e.Item.Cells[8].Text = other_discount.ToString("N",nfi);
				e.Item.Cells[9].Text = net_total.ToString("N",nfi);
				grand_total = 0;
				cash_discount = 0;
				vat_total = 0;
				other_discount = 0;
				net_total = 0;
			}
		}

		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// and also generate the query.
		/// </summary>
		private void cmdrpt_Click(object sender, System.EventArgs e)
		{
			string str="";
			string str1="";
			//SqlDataReader SqlDtr= null;
			try
			{
				if(!checkValidity())
				{
					return;
				}
				// if user select the report type Sales Report or Both then fire the query and fetch display the sales invoice with VAT.
				if(DropReportType.SelectedItem.Text == "Sales Report" || DropReportType.SelectedItem.Text == "Both")
				{
					//					dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, cast(Cash_Discount as varchar)+(case when cash_disc_type = 'Per' then '%' else ' Rs.' end) as Cash_Disc, VAT_Amount, cast(Discount as varchar)+(case when discount_type = 'Per' then '%' else ' Rs.' end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'",ref SqlDtr);
					if(DropReportCategory.SelectedItem.Text == "VAT")  
					{
						lblSalesHeading.Text = "Detailed VAT Report for Complete Party Wise/ Invoice Wise Sales";
						//dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'",ref SqlDtr);
						str="select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'";
					}
					if(DropReportCategory.SelectedItem.Text == "Non VAT")  
					{
						lblSalesHeading.Text = "Detailed Non VAT Report for Complete Party Wise/ Invoice Wise Sales";
						//dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount = 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'",ref SqlDtr);
						str="(select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount = 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') union (select invoice_no,invoice_date,promo_scheme,cust_type,discount,city,promo_scheme,cust_name,discount,city from vw_cashbilling where cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"')";
					}
					if(DropReportCategory.SelectedItem.Text == "Both")  
					{
						lblSalesHeading.Text = "Detailed VAT/ Non VAT Report for Complete Party Wise/ Invoice Wise Sales";
						//dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'",ref SqlDtr);
						//str="select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'";
						str="(select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') union (select invoice_no,invoice_date,promo_scheme,cust_type,discount,city,promo_scheme,cust_name,discount,city from vw_cashbilling where cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"')";
					}
					Cache["str"]=str;
					//					SalesGrid.DataSource = SqlDtr;
					//					SalesGrid.DataBind();
					//					if(SalesGrid.Items.Count==0)
					//					{
					//						lblSalesHeading.Visible = false; 
					//						SalesGrid.Visible=false;
					//						s++;
					//						
					//					
					//					}
					//					else
					//					{
					//						lblSalesHeading.Visible = true; 
					//						SalesGrid.Visible=true;
					//						
					//					}
					//					SqlDtr.Close ();
				}
				else
				{
					Cache["str"]="";
					//		lblSalesHeading.Visible = false; 
					//		SalesGrid.Visible=false;
					//		
				}

				// if user select the report type Purchase Report or Both then fire the query and fetch display the purchase invoice with VAT.
				if(DropReportType.SelectedItem.Text == "Purchase Report" || DropReportType.SelectedItem.Text == "Both")
				{
					if(DropReportCategory.SelectedItem.Text == "VAT")  
					{
						lblPurchaseHeading.Text = "Detailed VAT Report for Complete Party Wise/ Invoice Wise Purchase";
						//dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'",ref SqlDtr);
						str1="select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'";
					}
					if(DropReportCategory.SelectedItem.Text == "Non VAT")  
					{
						lblPurchaseHeading.Text = "Detailed Non VAT Report for Complete Party Wise/ Invoice Wise Purchase";
						//dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and VAT_Amount = 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'",ref SqlDtr);
						str1="select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and VAT_Amount = 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'";
					}
					if(DropReportCategory.SelectedItem.Text == "Both")  
					{
						lblPurchaseHeading.Text = "Detailed VAT/ Non VAT Report for Complete Party Wise/ Invoice Wise Purchase";
						//dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'",ref SqlDtr);
						str1="select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"'";
					}
					Cache["str1"]=str1;
					//					PurchaseGrid.DataSource = SqlDtr;
					//					PurchaseGrid.DataBind();
					//					if(PurchaseGrid.Items.Count==0)
					//					{
					//						lblPurchaseHeading.Visible = false; 
					//						PurchaseGrid.Visible=false;
					//						p++;
					//					}
					//					else
					//					{
					//						lblPurchaseHeading.Visible = true; 
					//						PurchaseGrid.Visible=true;
					//					}
					//					SqlDtr.Close ();
				}
				else
				{
					Cache["str1"]="";
					//	lblPurchaseHeading.Visible = false; 
					//	PurchaseGrid.Visible=false;
				}
				//				if(p>0 && s>0)
				//				{
				//					MessageBox.Show("Data not available");
				//				}
				//				else if(s>0 && DropReportType.SelectedItem.Text != "Both")
				//					MessageBox.Show("Sales Data not available");
				//				    else if(p > 0 && DropReportType.SelectedItem.Text != "Both")
				//					  MessageBox.Show("Purchase Data not available");

				strOrderBy = "invoice_no ASC";
				Cache["Column"] = "invoice_no";
				Cache["Order"] = "ASC";
				BindTheData();
				strOrderBy1 = "invoice_no ASC";
				Cache["Column1"] = "invoice_no";
				Cache["Order1"] = "ASC";
				BindTheData1();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:cmdrpt_Click  EXCEPTION  "+ex.Message+"  "+ uid );
			}
		}

		int s = 0;
		int p = 0;
		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr=System.Convert.ToString(Cache["str"]);
			DataSet ds= new DataSet();
			DataTable dtCustomers;
			DataView dv = new DataView();
			if(sqlstr!="")
			{
				SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
				da.Fill(ds, "Sales_Master");
				dtCustomers = ds.Tables["Sales_Master"];
				dv = new DataView(dtCustomers);
				dv.Sort = strOrderBy;
				Cache["strOrderBy"] = strOrderBy;
				SalesGrid.DataSource = dv;
			}
			//if(SalesGrid.Items.Count!=0)
			if(dv.Count != 0)
			{
				SalesGrid.DataBind();
				SalesGrid.Visible=true;
				lblSalesHeading.Visible = true; 
			}
			else
			{
				lblSalesHeading.Visible = false; 
				SalesGrid.Visible = false;
				s++;
			}
			//				else if(s>0 && DropReportType.SelectedItem.Text != "Both")
			//					MessageBox.Show("Sales Data not available");
			//				    else if(p > 0 && DropReportType.SelectedItem.Text != "Both")
			//					  MessageBox.Show("Purchase Data not available");
			SqlCon.Dispose();
		}

		/// <summary>
		/// This methos is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData1()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr1=System.Convert.ToString(Cache["str1"]);
			DataSet ds1 = new DataSet();
			DataTable dtCustomers1;
			DataView dv1 = new DataView();
			if(sqlstr1 != "")
			{
				SqlDataAdapter da1 = new SqlDataAdapter(sqlstr1, SqlCon);
				da1.Fill(ds1, "Purchase_Master");
				dtCustomers1 = ds1.Tables["Purchase_Master"];
				dv1=new DataView(dtCustomers1);
				dv1.Sort = strOrderBy1;
				Cache["strOrderBy1"]=strOrderBy1;
				PurchaseGrid.DataSource = dv1;
			}
			
			//if(PurchaseGrid.Items.Count!=0)
			if(dv1.Count!=0)
			{
				PurchaseGrid.DataBind();
				PurchaseGrid.Visible=true;
				lblPurchaseHeading.Visible = true; 
			}
			else
			{
				lblPurchaseHeading.Visible = false; 
				PurchaseGrid.Visible=false;
				p++;
			}
			if(p>0 && s>0)
			{
				MessageBox.Show("Data not available");
			}
			SqlCon.Dispose();
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnSortCommand"
		/// </summary>
		public void SortCommand_Click(object sender,DataGridSortCommandEventArgs e)
		{
			try
			{
				//Check to see if same column clicked again
				if(e.SortExpression.ToString().Equals(Cache["Column"]))
				{
					if(Cache["Order"].Equals("ASC"))
					{
						strOrderBy=e.SortExpression.ToString() +" DESC";
						Cache["Order"]="DESC";
					}
					else
					{
						strOrderBy=e.SortExpression.ToString() +" ASC";
						Cache["Order"]="ASC";
					}
				}
					//Different column selected, so default to ascending order
				else
				{
					strOrderBy = e.SortExpression.ToString() +" ASC";
					Cache["Order"] = "ASC";
				}
				Cache["Column"] = e.SortExpression.ToString();
				BindTheData();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnSortCommand"
		/// </summary>
		public void SortCommand1_Click(object sender,DataGridSortCommandEventArgs e)
		{
			try
			{
				//Check to see if same column clicked again
				if(e.SortExpression.ToString().Equals(Cache["Column1"]))
				{
					if(Cache["Order1"].Equals("ASC"))
					{
						strOrderBy1=e.SortExpression.ToString() +" DESC";
						Cache["Order1"]="DESC";
					}
					else
					{
						strOrderBy1=e.SortExpression.ToString() +" ASC";
						Cache["Order1"]="ASC";
					}
				}
					//Different column selected, so default to ascending order
				else
				{
					strOrderBy1 = e.SortExpression.ToString() +" ASC";
					Cache["Order1"] = "ASC";
				}
				Cache["Column1"] = e.SortExpression.ToString();
				BindTheData1();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method : ShortCommand1_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to creates the file VAT_Report.txt for print.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			int s = 0;
			int p = 0;
			SqlDataReader SqlDtr= null;
			
			try
			{
				if(!checkValidity())
				{
					return;
				}
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\VAT_Report.txt";
				StreamWriter sw = new StreamWriter(path);
				string info = "";

				/*
													   ========================================
													   VAT Report From 11/11/2000 To 11/12/2003
													   ========================================

											Detaild VAT Report for Complete Party Wise/ Invoice Wise Purchase 
											-----------------------------------------------------------------
				+-------+----------+-------------------------+--------------+----------+---------+--------+-------+--------+----------+
				|Invoice| Invoice  |    Vendor Name          |    Place     | Tin No.  | Product |  Cash  |  VAT  | Other  |Total Inv.|
				|  No.  |  Date    |                         |              |          |  Value  |Discount|       |Discount| Amount   |
				+-------+----------+-------------------------+--------------+----------+---------+--------+-------+--------+----------+
				 1001    dd/mm/yyyy 1234567890123456789012345 12345679012345 1234567890 123456.88 10.00 Rs.1234.00          1234567.99						  
  
				*/
				
				info = " {0,-7:S} {1,-10:S} {2,-31:S} {3,-14:S} {4,-11:S} {5,12:F} {6,9:F} {7,9:F} {8,9:F} {9,13:F}";

				sw.Write((char)27);//added by vishnu
				sw.Write((char)67);//added by vishnu
				sw.Write((char)0);//added by vishnu
				sw.Write((char)12);//added by vishnu
				sw.Write((char)27);//added by vishnu
				sw.Write((char)78);//added by vishnu
				sw.Write((char)5);//added by vishnu
				// Condensed
				sw.Write((char)27);//added by vishnu
				sw.Write((char)15);
				sw.WriteLine("");
				//**********
				string des="----------------------------------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				
				sw.WriteLine(GenUtil.GetCenterAddr("========================================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("VAT Report From "+txtDateFrom.Text+" To "+txtDateTo.Text,des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("========================================",des.Length));
			
				//if type is Sales Report or both then writes the information about sales .
				if(DropReportType.SelectedItem.Text == "Sales Report" || DropReportType.SelectedItem.Text == "Both")
				{
					grand_total = 0;
					cash_discount = 0;
					vat_total = 0;
					other_discount = 0;
					net_total = 0;

					sw.WriteLine("");
					if(DropReportCategory.SelectedItem.Text == "VAT")  
					{
						//sw.WriteLine("                             Detaild VAT Report for Complete Party Wise/ Invoice Wise Sales");
						//sw.WriteLine("		             --------------------------------------------------------------");
						sw.WriteLine(GenUtil.GetCenterAddr("Detaild VAT Report for Complete Party Wise/ Invoice Wise Sales",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------------------------------------",des.Length));
						dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"' order by "+Cache["strOrderBy"]+"",ref SqlDtr);
					}
					if(DropReportCategory.SelectedItem.Text == "Non VAT")  
					{
						sw.WriteLine(GenUtil.GetCenterAddr("Detaild Non VAT Report for Complete Party Wise/ Invoice Wise Sales",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("------------------------------------------------------------------",des.Length));
						dbobj.SelectQuery("(select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount = 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') union (select invoice_no,invoice_date,promo_scheme,cust_type,discount,city,promo_scheme,cust_name,discount,city from vw_cashbilling where cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') order by "+Cache["strOrderBy"]+"",ref SqlDtr);
					}
					if(DropReportCategory.SelectedItem.Text == "Both")  
					{
						sw.WriteLine(GenUtil.GetCenterAddr("Detaild VAT/ Non VAT Report for Complete Party Wise/ Invoice Wise Sales",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------------------------------",des.Length));
						dbobj.SelectQuery("(select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') union (select invoice_no,invoice_date,promo_scheme,cust_type,discount,city,promo_scheme,cust_name,discount,city from vw_cashbilling where cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') order by "+Cache["strOrderBy"]+"",ref SqlDtr);
					}
 
					if(SqlDtr.HasRows)
					{
						sw.WriteLine("+-------+----------+-------------------------------+--------------+-----------+------------+---------+---------+---------+-------------+");
						sw.WriteLine("|Invoice| Invoice  |      Customer Name            |    Place     | Tin No.   |  Product   |  Cash   |   VAT   | Other   | Total Inv.  |");
						sw.WriteLine("|  No.  |  Date    |                               |              |           |   Value    |Discount |         |Discount |  Amount     |");
						sw.WriteLine("+-------+----------+-------------------------------+--------------+-----------+------------+---------+---------+---------+-------------+");
						//						               1001    dd/mm/yyyy 1234567890123456789012345 12345679012345 1234567890 123456.88 10.00 Rs.1234.00          1234567.99	

						while(SqlDtr.Read())
						{
							sw.WriteLine(info,SqlDtr["Invoice_No"].ToString().Trim() ,
								GenUtil.str2DDMMYYYY(trimDate(SqlDtr["Invoice_Date"].ToString().Trim() ) ),
								GenUtil.TrimLength(SqlDtr["Cust_Name"].ToString().Trim(),31) ,
								GenUtil.TrimLength(SqlDtr["City"].ToString().Trim(),14),
								SqlDtr["Tin_No"].ToString().Trim(),
								Double.Parse(SqlDtr["Grand_Total"].ToString().Trim()).ToString("N",nfi) ,
								Double.Parse(SqlDtr["Cash_Disc"].ToString().Trim()).ToString("N",nfi) ,
								Double.Parse(SqlDtr["VAT_Amount"].ToString().Trim()).ToString("N",nfi), 
								Double.Parse(SqlDtr["Disc"].ToString().Trim()).ToString("N",nfi),
								Double.Parse(SqlDtr["Net_Amount"].ToString().Trim()).ToString("N",nfi)  
								);
							grand_total += System.Convert.ToDouble(Double.Parse(SqlDtr["Grand_Total"].ToString().Trim()).ToString("N",nfi));  
							cash_discount  += System.Convert.ToDouble(Double.Parse(SqlDtr["Cash_Disc"].ToString().Trim()).ToString("N",nfi));  
							vat_total += System.Convert.ToDouble(Double.Parse(SqlDtr["VAT_Amount"].ToString().Trim()).ToString("N",nfi));  
							other_discount += System.Convert.ToDouble(Double.Parse(SqlDtr["Disc"].ToString().Trim()).ToString("N",nfi));  
							net_total += System.Convert.ToDouble(Double.Parse(SqlDtr["Net_Amount"].ToString().Trim()).ToString("N",nfi));  
						}
						sw.WriteLine("+-------+----------+-------------------------------+--------------+-----------+------------+---------+---------+---------+-------------+");
						sw.WriteLine(info ,"Total:","","","","",grand_total.ToString("N",nfi),cash_discount.ToString("N",nfi),vat_total.ToString("N",nfi) ,other_discount.ToString("N",nfi),net_total.ToString("N",nfi)); 
						sw.WriteLine("+-------+----------+-------------------------------+--------------+-----------+------------+---------+---------+---------+-------------+");
					}
					else
					{
						s++;
					}
					SqlDtr.Close ();
				}

				//if type is Purchase Report or both then writes the information about purchase .
				if(DropReportType.SelectedItem.Text == "Purchase Report" || DropReportType.SelectedItem.Text == "Both")
				{
					grand_total = 0;
					cash_discount = 0;
					vat_total = 0;
					other_discount = 0;
					net_total = 0;
					sw.WriteLine("");
					if(DropReportCategory.SelectedItem.Text == "VAT")  
					{
						sw.WriteLine("                             Detaild VAT Report for Complete Party Wise/ Invoice Wise Purchase");
						sw.WriteLine("		             -----------------------------------------------------------------");
						dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"' order by "+Cache["strOrderBy1"]+"",ref SqlDtr);
					}
					if(DropReportCategory.SelectedItem.Text == "Non VAT")  
					{
						sw.WriteLine("                             Detaild Non VAT Report for Complete Party Wise/ Invoice Wise Purchase");
						sw.WriteLine("		             ---------------------------------------------------------------------");
						dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and VAT_Amount = 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"' order by "+Cache["strOrderBy1"]+"",ref SqlDtr);
					}
					if(DropReportCategory.SelectedItem.Text == "Both")  
					{
						sw.WriteLine("                             Detaild VAT/ Non VAT Report for Complete Party Wise/ Invoice Wise Purchase");
						sw.WriteLine("		             --------------------------------------------------------------------------");
						dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"' order by "+Cache["strOrderBy1"]+"",ref SqlDtr);
					}
					if(SqlDtr.HasRows)
					{
						sw.WriteLine("+-------+----------+-------------------------------+--------------+-----------+------------+---------+---------+---------+-------------+");
						sw.WriteLine("|Invoice| Invoice  |       Vendor Name             |    Place     |  Tin No.  |  Product   |  Cash   |  VAT    | Other   |  Total Inv. |");
						sw.WriteLine("|  No.  |  Date    |                               |              |           |   Value    |Discount |         |Discount |   Amount    |");
						sw.WriteLine("+-------+----------+-------------------------------+--------------+-----------+------------+---------+---------+---------+-------------+");
						//						               1001    dd/mm/yyyy 1234567890123456789012345 12345679012345 1234567890 123456.88 10.00 Rs.1234.00          1234567.99	
						while(SqlDtr.Read())
						{
							sw.WriteLine(info,SqlDtr["Invoice_No"].ToString().Trim() ,
								GenUtil.str2DDMMYYYY(trimDate(SqlDtr["Invoice_Date"].ToString().Trim() ) ),
								GenUtil.TrimLength(SqlDtr["Supp_Name"].ToString().Trim(),31) ,
								GenUtil.TrimLength(SqlDtr["City"].ToString().Trim(),14),
								SqlDtr["Tin_No"].ToString().Trim(),
								Double.Parse(SqlDtr["Grand_Total"].ToString().Trim()).ToString("N",nfi) ,
								Double.Parse(SqlDtr["Cash_Disc"].ToString().Trim()).ToString("N",nfi) ,
								Double.Parse(SqlDtr["VAT_Amount"].ToString().Trim()).ToString("N",nfi), 
								Double.Parse(SqlDtr["Disc"].ToString().Trim()).ToString("N",nfi),
								Double.Parse(SqlDtr["Net_Amount"].ToString().Trim()).ToString("N",nfi)  
								);
							grand_total += System.Convert.ToDouble(Double.Parse(SqlDtr["Grand_Total"].ToString().Trim()).ToString("N",nfi));  
							cash_discount  += System.Convert.ToDouble(Double.Parse(SqlDtr["Cash_Disc"].ToString().Trim()).ToString("N",nfi));  
							vat_total += System.Convert.ToDouble(Double.Parse(SqlDtr["VAT_Amount"].ToString().Trim()).ToString("N",nfi));  
							other_discount += System.Convert.ToDouble(Double.Parse(SqlDtr["Disc"].ToString().Trim()).ToString("N",nfi));  
							net_total += System.Convert.ToDouble(Double.Parse(SqlDtr["Net_Amount"].ToString().Trim()).ToString("N",nfi));  
						}
						sw.WriteLine("+-------+----------+-------------------------------+--------------+-----------+------------+---------+---------+---------+-------------+");
						sw.WriteLine(info ,"Total:","","","","",grand_total.ToString("N",nfi),cash_discount.ToString("N",nfi),vat_total.ToString("N",nfi) ,other_discount.ToString("N",nfi),net_total.ToString("N",nfi)); 
						sw.WriteLine("+-------+----------+-------------------------------+--------------+-----------+------------+---------+---------+---------+-------------+");
					}
					else
					{
						p++;
					}
					SqlDtr.Close ();
				}
				if(p>0 && s>0)
				{
					MessageBox.Show("Data not available");
					sw.Close(); 
					return;
				}
				else if(s>0 && DropReportType.SelectedItem.Text != "Both")
					MessageBox.Show("Sales Data not available");
				else if(p > 0 && DropReportType.SelectedItem.Text != "Both")
					MessageBox.Show("Purchase Data not available");
				// deselect Condensed
				//sw.Write((char)12);
				//sw.Write((char)27);
				//sw.Write((char)27);
				sw.Close();
				Print(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:BtnPrint_Click  EXCEPTION  "+ex.Message+"  "+ uid );
			}
		}

		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\VatReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader SqlDtr= null;
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+txtDateTo.Text);
			sw.WriteLine("Report Type\t"+DropReportType.SelectedItem.Text);
			sw.WriteLine("Report Category\t"+DropReportCategory.SelectedItem.Text);
			if(DropReportType.SelectedItem.Text == "Sales Report" || DropReportType.SelectedItem.Text == "Both")
			{
				grand_total = 0;
				cash_discount = 0;
				vat_total = 0;
				other_discount = 0;
				net_total = 0;
				sw.WriteLine("");
				if(DropReportCategory.SelectedItem.Text == "VAT")  
				{
					sw.WriteLine("Detaild VAT\tReport for\tComplete Party\tWise/ Invoice\tWise Sales");
					dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"' order by "+Cache["strOrderBy"]+"",ref SqlDtr);
				}
				if(DropReportCategory.SelectedItem.Text == "Non VAT")  
				{
					sw.WriteLine("Detaild Non\tVAT Report for\tComplete Party\tWise/ Invoice\tWise Sales");
					dbobj.SelectQuery("(select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and VAT_Amount = 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') union (select invoice_no,invoice_date,promo_scheme,cust_type,discount,city,promo_scheme,cust_name,discount,city from vw_cashbilling where cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') order by "+Cache["strOrderBy"]+"",ref SqlDtr);
				}
				if(DropReportCategory.SelectedItem.Text == "Both")  
				{
					sw.WriteLine("Detaild VAT/ Non\tVAT Report for\tComplete Party\tWise/ Invoice\tWise Sales");
					dbobj.SelectQuery("(select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, c.Cust_Name, c.City, c.Tin_No from Sales_Master s, Customer c where c.Cust_ID = s.Cust_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') union (select invoice_no,invoice_date,promo_scheme,cust_type,discount,city,promo_scheme,cust_name,discount,city from vw_cashbilling where cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"') order by "+Cache["strOrderBy"]+"",ref SqlDtr);
				}
				if(SqlDtr.HasRows)
				{
					sw.WriteLine("Invoice No\tInvoice Date\tCustomer Name\tPlace\tTin No.\tProduct\tCash Value\tVAT\tOther Discount\tTotal Inv. Amount");
					while(SqlDtr.Read())
					{
						sw.WriteLine(SqlDtr["Invoice_No"].ToString().Trim()+"\t"+
							GenUtil.str2DDMMYYYY(trimDate(SqlDtr["Invoice_Date"].ToString().Trim()))+"\t"+
							SqlDtr["Cust_Name"].ToString().Trim()+"\t"+
							SqlDtr["City"].ToString().Trim()+"\t"+
							SqlDtr["Tin_No"].ToString().Trim()+"\t"+
							Double.Parse(SqlDtr["Grand_Total"].ToString().Trim()).ToString("N",nfi)+"\t"+
							Double.Parse(SqlDtr["Cash_Disc"].ToString().Trim()).ToString("N",nfi)+"\t"+
							Double.Parse(SqlDtr["VAT_Amount"].ToString().Trim()).ToString("N",nfi)+"\t"+
							Double.Parse(SqlDtr["Disc"].ToString().Trim()).ToString("N",nfi)+"\t"+
							Double.Parse(SqlDtr["Net_Amount"].ToString().Trim()).ToString("N",nfi)  
							);
						grand_total += System.Convert.ToDouble(Double.Parse(SqlDtr["Grand_Total"].ToString().Trim()).ToString("N",nfi));  
						cash_discount  += System.Convert.ToDouble(Double.Parse(SqlDtr["Cash_Disc"].ToString().Trim()).ToString("N",nfi));  
						vat_total += System.Convert.ToDouble(Double.Parse(SqlDtr["VAT_Amount"].ToString().Trim()).ToString("N",nfi));  
						other_discount += System.Convert.ToDouble(Double.Parse(SqlDtr["Disc"].ToString().Trim()).ToString("N",nfi));  
						net_total += System.Convert.ToDouble(Double.Parse(SqlDtr["Net_Amount"].ToString().Trim()).ToString("N",nfi));  
					}
					sw.WriteLine("Total\t\t\t\t\t"+grand_total.ToString("N",nfi)+"\t"+cash_discount.ToString("N",nfi)+"\t"+vat_total.ToString("N",nfi)+"\t"+other_discount.ToString("N",nfi)+"\t"+net_total.ToString("N",nfi)); 
				}
				SqlDtr.Close ();
			}
			//if type is Purchase Report or both then writes the information about purchase .
			if(DropReportType.SelectedItem.Text == "Purchase Report" || DropReportType.SelectedItem.Text == "Both")
			{
				grand_total = 0;
				cash_discount = 0;
				vat_total = 0;
				other_discount = 0;
				net_total = 0;
				sw.WriteLine("");
				if(DropReportCategory.SelectedItem.Text == "VAT")  
				{
					sw.WriteLine("Detaild VAT\tReport for\tComplete Party\tWise/ Invoice\tWise Purchase");
					dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and VAT_Amount != 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"' order by "+Cache["strOrderBy1"]+"",ref SqlDtr);
				}
				if(DropReportCategory.SelectedItem.Text == "Non VAT")  
				{
					sw.WriteLine("Detaild Non\tVAT Report\tfor Complete\tParty Wise/ Invoice\tWise Purchase");
					dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and VAT_Amount = 0 and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"' order by "+Cache["strOrderBy1"]+"",ref SqlDtr);
				}
				if(DropReportCategory.SelectedItem.Text == "Both")  
				{
					sw.WriteLine("Detaild VAT/ Non\tVAT Report\tfor Complete\tParty Wise/ Invoice\tWise Purchase");
					dbobj.SelectQuery("select invoice_no, invoice_date,Grand_Total, (case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end) as Cash_Disc, VAT_Amount, (case when discount_type = 'Per' then ((Grand_Total-(case when cash_disc_type = 'Per' then (Grand_Total*Cash_Discount/100) else Cash_Discount end))+VAT_Amount)*Discount/100 else Discount end) as Disc, Net_Amount, s.Supp_Name, s.City, s.Tin_No from Purchase_Master p, Supplier s where s.Supp_ID = p.Vendor_ID and cast(floor(cast(Invoice_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()) +"' order by "+Cache["strOrderBy1"]+"",ref SqlDtr);
				}
				if(SqlDtr.HasRows)
				{
					sw.WriteLine("|Invoice No\tInvoice Date\tVendor Name\tPlace\tTin No.\tProduct\tCash Value\tVAT\tOther Discount\tTotal Inv. Amount");
					while(SqlDtr.Read())
					{
						sw.WriteLine(SqlDtr["Invoice_No"].ToString().Trim()+"\t"+
							GenUtil.str2DDMMYYYY(trimDate(SqlDtr["Invoice_Date"].ToString().Trim() ) )+"\t"+
							SqlDtr["Supp_Name"].ToString().Trim()+"\t"+
							SqlDtr["City"].ToString().Trim()+"\t"+
							SqlDtr["Tin_No"].ToString().Trim()+"\t"+
							Double.Parse(SqlDtr["Grand_Total"].ToString().Trim()).ToString("N",nfi)+"\t"+
							Double.Parse(SqlDtr["Cash_Disc"].ToString().Trim()).ToString("N",nfi)+"\t"+
							Double.Parse(SqlDtr["VAT_Amount"].ToString().Trim()).ToString("N",nfi)+"\t"+
							Double.Parse(SqlDtr["Disc"].ToString().Trim()).ToString("N",nfi)+"\t"+
							Double.Parse(SqlDtr["Net_Amount"].ToString().Trim()).ToString("N",nfi)  
							);
						grand_total += System.Convert.ToDouble(Double.Parse(SqlDtr["Grand_Total"].ToString().Trim()).ToString("N",nfi));  
						cash_discount  += System.Convert.ToDouble(Double.Parse(SqlDtr["Cash_Disc"].ToString().Trim()).ToString("N",nfi));  
						vat_total += System.Convert.ToDouble(Double.Parse(SqlDtr["VAT_Amount"].ToString().Trim()).ToString("N",nfi));  
						other_discount += System.Convert.ToDouble(Double.Parse(SqlDtr["Disc"].ToString().Trim()).ToString("N",nfi));  
						net_total += System.Convert.ToDouble(Double.Parse(SqlDtr["Net_Amount"].ToString().Trim()).ToString("N",nfi));  
					}
					sw.WriteLine("Total\t\t\t\t\t"+grand_total.ToString("N",nfi)+"\t"+cash_discount.ToString("N",nfi)+"\t"+vat_total.ToString("N",nfi)+"\t"+other_discount.ToString("N",nfi)+"\t"+net_total.ToString("N",nfi)); 
				}
				SqlDtr.Close ();
			}
			dbobj.Dispose();
			sw.Close();
		}
		
		/// <summary>
		/// Its remove the time from data field & only returns the date.
		/// </summary>
		public string trimDate(string strDate)
		{
			int pos = strDate.IndexOf(" ");
				
			if(pos != -1)
			{
				strDate = strDate.Substring(0,pos);
			}
			else
			{
				strDate = "";					
			}
			return strDate;
		}

		/// <summary>
		/// This method is used to sends the VAT_Report to print server.
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
					CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\VAT_Report.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:print. Report Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:print  EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(SalesGrid.Visible==true || PurchaseGrid.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method: btnExcel_Click, Vat Report Convert Into Excel Format ,  userid  "+uid);
				}
				else
				{
					MessageBox.Show("Please Click the View Button First");
					return;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:VAT_Report.aspx,Method:btnExcel_Click   Vat Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}