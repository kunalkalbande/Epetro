/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
using DBOperations;
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
using System.Net;
using System.Net.Sockets;
using EPetro.Sysitem.Classes ;
using System.IO;
using System.Text;
using RMG;

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for StockReport.
	/// </summary>
	public class StockReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList drpstore;
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button cmdrpt;
		protected System.Web.UI.WebControls.DataGrid grdLeg;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.RadioButton RadioYes;
		protected System.Web.UI.WebControls.RadioButton RadioNo;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
                txtDateTo.Attributes.Add("readonly", "readonly");
                uid =(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockReport.aspx,Class:DBOperation_LETEST.cs,Method:page_load"+ ex.Message+"EXCEPTION"+uid);	
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{	
				try
				{
					RadioNo.Checked=true;
					RadioYes.Checked=false;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="12";
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
					}
					#endregion
					txtDateTo.Text=DateTime.Now.Day+ "/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year;
					System.Data.SqlClient.SqlDataReader rdr=null,rdr1=null;
					// Fetch the store location or tank id according to the product type and fill the combo.
					dbobj.SelectQuery("select distinct store_in from products",ref rdr);
					while(rdr.Read())
					{
						dbobj.SelectQuery("select tank_id,tank_name,prod_name from tank where tank_id like'"+rdr["store_in"].ToString()+"' order by tank_id",ref rdr1);
						if(rdr1.Read())
						{
							drpstore.Items.Add(rdr1["tank_name"].ToString()+":"+rdr1["prod_name"].ToString());					
						}
						else
							drpstore.Items.Add(rdr["store_in"].ToString());					
					}
					drpstore.Items.Insert(0,"All");
					dbobj.Dispose();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:StockReport.aspx,Method:page_load EXCEPTION  "+ex.Message+" userid "+ uid);
				}
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void cmdrpt_Click(object sender, System.EventArgs e)
		{  
			try
			{
				grdLeg.Visible=true;
				//System.Data.SqlClient.SqlDataReader rdr=null;
				string sql="";

				object op= null;
				//call the procedure and create the temp table. stk.
				dbobj.ExecProc(OprType.Insert,"sp_stock",ref op,"@fromdate",GenUtil.str2MMDDYYYY(txtDateTo.Text));
	
				if(txtDateTo.Text==System.DateTime.Now.ToShortDateString())
				{
					if(RadioYes.Checked)
					{
						if(drpstore.SelectedIndex>0)
						{
							if(drpstore.SelectedItem.Text.IndexOf(":")>0)
							{
								string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
								string tid="";
								dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
								//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
								sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";

							}
							else 
							{
								//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
								sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc)  and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
							}
						}
						else
							//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
							sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
					}
					else
					{
						if(drpstore.SelectedIndex>0)
						{
							if(drpstore.SelectedItem.Text.IndexOf(":")>0)
							{
								string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
								string tid="";
								dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
								sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
								//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";

							}
							else 
							{
								sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
								//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc)  and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
							}
						}
						else
							sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
						//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
					}
				}
				else if(drpstore.SelectedIndex>0)
				{
					if(RadioYes.Checked)
					{
						if(drpstore.SelectedItem.Text.IndexOf(":")>0)
						{
							string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
							string tid="";
							dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
							//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
							sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
						}
						else
						{
							//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
							sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						}
					}
					else
					{
						if(drpstore.SelectedItem.Text.IndexOf(":")>0)
						{
							string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
							string tid="";
							dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
							sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
							//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
						}
						else
						{
							sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
							//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						}
					}
				}
				else 
				{
					if(RadioYes.Checked)
					{
						//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
						sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
						//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.pur_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.pur_rate=(select top 1 pur_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
						Trace.Write(sql);
					}
					else
					{
						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
						//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
						Trace.Write(sql);
					}
				}
				Cache["sql"]=sql; 
				strOrderBy = "Product ASC";
				Session["Column"] = "Product";
				Session["Order"] = "ASC";
				BindTheData();
				//				dbobj.SelectQuery(sql,ref rdr);
				//				if(rdr.HasRows)
				//				{
				//					grdLeg.DataSource=rdr;
				//					grdLeg.DataBind();
				//				}
				//				else
				//				{
				//					RMG.MessageBox.Show("Data not available");
				//					grdLeg.Visible=false;
				//				}
				//				rdr.Close();
				CreateLogFiles.ErrorLog("Form:StokReport,Class:DBoperation_LETEST + Method:cmdrpt_Click  Stock Report Viewed   userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StokReport,Class:DBoperation_LETEST + Method:cmdrpt_Click,   Stock Report Viewed  EXCEPTION  "+ex.Message+" userid "+uid);		
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr=System.Convert.ToString(Cache["sql"]);
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "stock_master");
			DataTable dtCustomers = ds.Tables["stock_master"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				if(RadioYes.Checked)
				{
					grdLeg.DataSource = dv;
					grdLeg.DataBind();
					grdLeg.Visible=true;
					Datagrid1.Visible=false;
				}
				else
				{
					Datagrid1.DataSource = dv;
					Datagrid1.DataBind();
					grdLeg.Visible=false;
					Datagrid1.Visible=true;
				}
			}
			else
			{
				MessageBox.Show("Data not available");
				grdLeg.Visible=false;
				Datagrid1.Visible=false;
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
				if(e.SortExpression.ToString().Equals(Session["Column"]))
				{
					if(Session["Order"].Equals("ASC"))
					{
						strOrderBy=e.SortExpression.ToString() +" DESC";
						Session["Order"]="DESC";
					}
					else
					{
						strOrderBy=e.SortExpression.ToString() +" ASC";
						Session["Order"]="ASC";
					}
				}
					//Different column selected, so default to ascending order
				else
				{
					strOrderBy = e.SortExpression.ToString() +" ASC";
					Session["Order"] = "ASC";
				}
				Session["Column"] = e.SortExpression.ToString();
				BindTheData();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to prepare the report file .txt
		/// </summary>
		public void makingReport()
		{
			/*
						================                                
						  STOCK REPORT                                  
						================                                
+--------------------+---------------+-------------------------+
|                    |               |      Closing Stock      |
|     Product        |    Location   |-------------+-----------|
|                    |               |    Pkg      |  Lt/kg    |	
+--------------------+---------------+-------------+-----------+
 12345678901234567890 123456789012345 12345678.00   12345678.00  
			 */
			
			System.Data.SqlClient.SqlDataReader rdr=null;
			string sql="";
			string info="",info1="";

			object op= null;
			dbobj.ExecProc(OprType.Insert,"sp_stock",ref op,"@fromdate",GenUtil.str2MMDDYYYY(txtDateTo.Text));
			//			if(txtDateTo.Text==System.DateTime.Now.ToShortDateString())
			//			{
			//				if(drpstore.SelectedIndex>0)
			//				{
			//					if(drpstore.SelectedItem.Text.IndexOf(":")>0)
			//					{
			//						string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
			//						string tid="";
			//						dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
			//						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
			//
			//					}
			//					else 
			//					{
			//						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
			//					}
			//				}
			//				else
			//					sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
			//				
			//			}
			//			else if(drpstore.SelectedIndex>0)
			//			{
			//					
			//				if(drpstore.SelectedItem.Text.IndexOf(":")>0)
			//				{
			//					string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
			//					string tid="";
			//					dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
			//					sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
			//
			//				}
			//				else 
			//				{
			//					sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
			//				}
			//				
			//					
			//			}
			//			else 
			//			{
			//				//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
			//				sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate";
			//				Trace.Write(sql);
			//			}
			if(txtDateTo.Text==System.DateTime.Now.ToShortDateString())
			{
				if(RadioYes.Checked)
				{
					if(drpstore.SelectedIndex>0)
					{
						if(drpstore.SelectedItem.Text.IndexOf(":")>0)
						{
							string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
							string tid="";
							dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
							//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
							sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";

						}
						else 
						{
							//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
							sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc)  and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						}
					}
					else
						//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
						sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
				}
				else
				{
					if(drpstore.SelectedIndex>0)
					{
						if(drpstore.SelectedItem.Text.IndexOf(":")>0)
						{
							string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
							string tid="";
							dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
							sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
							//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";

						}
						else 
						{
							sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
							//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc)  and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						}
					}
					else
						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
					//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
				}
			}
			else if(drpstore.SelectedIndex>0)
			{
				if(RadioYes.Checked)
				{
					if(drpstore.SelectedItem.Text.IndexOf(":")>0)
					{
						string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
						string tid="";
						dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
						//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
						sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
					}
					else
					{
						//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
					}
				}
				else
				{
					if(drpstore.SelectedItem.Text.IndexOf(":")>0)
					{
						string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
						string tid="";
						dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
						//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
					}
					else
					{
						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
					}
				}
			}
			else 
			{
				if(RadioYes.Checked)
				{
					//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
					sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
					//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.pur_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.pur_rate=(select top 1 pur_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
					Trace.Write(sql);
				}
				else
				{
					sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
					//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
					Trace.Write(sql);
				}
			}
			//sql=sql+" order by a."+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\StockReport.txt";
			StreamWriter sw = new StreamWriter(path);


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
			string des="";
			if(RadioNo.Checked)
				des="--------------------------------------------------------------------------";
			else
				des="------------------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("===============================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("STOCK REPORT AS ON "+ txtDateTo.Text,des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("===============================",des.Length));
			sw.WriteLine("");
			sw.WriteLine("Location : "+drpstore.SelectedItem.Text);
			if(RadioYes.Checked)
			{
				sw.WriteLine("+------------------------------+---------------+-------------------------+---------------+");
				sw.WriteLine("|                              |               |      Closing Stock      |               |");
				sw.WriteLine("|           Product            |    Location   |-------------+-----------|    Amount     |");
				sw.WriteLine("|                              |               |    Pkg      |  Lt/kg    |               |");
				sw.WriteLine("+------------------------------+---------------+-------------+-----------+---------------+");
			}
			else
			{
				sw.WriteLine("+------------------------------+---------------+-------------------------+");
				sw.WriteLine("|                              |               |      Closing Stock      |");
				sw.WriteLine("|           Product            |    Location   |-------------+-----------|");
				sw.WriteLine("|                              |               |    Pkg      |  Lt/kg    |");
				sw.WriteLine("+------------------------------+---------------+-------------+-----------+");
			}
			//                 123456789012345678901234567890 123456789012345 12345678.00   12345678.00 
			string pack;
			string strPackCl;
			string[] strSplit;
			if(rdr.HasRows)
			{
				// info : set format of the string to display.
				info = " {0,-30:S} {1,-15:S} {2,13:S} {3,11:F}";
				info1 = " {0,-30:S} {1,-15:S} {2,11:S} {3,13:F} {4,15:F}";
				while(rdr.Read())
				{
					pack="";
					strPackCl="";
					// if product category is fuel hen not dipslay the package, display the tank abbr name. 
					if(RadioNo.Checked)
					{
						if(rdr["category"].ToString().ToUpper().Equals("FUEL"))
						{
							string prod_name="";
							dbobj.SelectQuery("select Prod_AbbName from tank where tank_id='"+rdr["store_in"].ToString().Trim()+"'","Prod_AbbName",ref prod_name);
							sw.WriteLine(info,GenUtil.TrimLength(rdr["Product"].ToString().Trim(),30),prod_name,"",rdr["closing_stock"].ToString()); 
						}
							// if package is Loose Oil the not display the package type.
						else if(rdr["pack_type"].ToString().IndexOf("Loose") != -1)
						{
							sw.WriteLine(info,GenUtil.TrimLength(rdr["Product"].ToString().Trim(),30),GenUtil.TrimLength(rdr["store_in"].ToString().Trim(),15),"",rdr["closing_stock"].ToString()); 
						}
						else
						{
							pack = rdr["pack_type"].ToString().Trim();

							if (pack.IndexOf("X")<0 || pack.Equals("") )
							{
								strPackCl = rdr["closing_stock"].ToString().Trim();
							
							}
							else
							{
								strSplit = pack.Split(new char []{'X'},pack.Length);
								double d1 = 1;
								double d2 = 1;
								if(!strSplit[0].Trim().Equals (""))
									d1 = System.Convert.ToDouble(strSplit[0]);
								if(!strSplit[1].Trim().Equals (""))
									d2 = System.Convert.ToDouble(strSplit[1]);
								strPackCl = rdr["closing_stock"].ToString().Trim();
								if(!strPackCl.Equals(""))
								{
									strPackCl = ""+System.Convert.ToDouble(strPackCl)*d1*d2 ;            
								}
							}
							
							sw.WriteLine(info,GenUtil.TrimLength(rdr["Product"].ToString().Trim(),30),GenUtil.TrimLength(rdr["store_in"].ToString().Trim(),15),rdr["closing_stock"].ToString(),strPackCl); 
						}
					}
					else
					{
						if(rdr["category"].ToString().ToUpper().Equals("FUEL"))
						{
							string prod_name="";
							dbobj.SelectQuery("select Prod_AbbName from tank where tank_id='"+rdr["store_in"].ToString().Trim()+"'","Prod_AbbName",ref prod_name);
							sw.WriteLine(info1,GenUtil.TrimLength(rdr["Product"].ToString().Trim(),30),prod_name,"",rdr["closing_stock"].ToString(),rdr["Sal_Rate"].ToString()); 
						}
							// if package is Loose Oil the not display the package type.
						else if(rdr["pack_type"].ToString().IndexOf("Loose") != -1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(rdr["Product"].ToString().Trim(),30),GenUtil.TrimLength(rdr["store_in"].ToString().Trim(),15),"",rdr["closing_stock"].ToString(),rdr["Sal_Rate"].ToString()); 
						}
						else
						{
							pack = rdr["pack_type"].ToString().Trim();

							if (pack.IndexOf("X")<0 || pack.Equals("") )
							{
								strPackCl = rdr["closing_stock"].ToString().Trim();
							
							}
							else
							{
								strSplit = pack.Split(new char []{'X'},pack.Length);
								double d1 = 1;
								double d2 = 1;
								if(!strSplit[0].Trim().Equals (""))
									d1 = System.Convert.ToDouble(strSplit[0]);
								if(!strSplit[1].Trim().Equals (""))
									d2 = System.Convert.ToDouble(strSplit[1]);
								strPackCl = rdr["closing_stock"].ToString().Trim();
								if(!strPackCl.Equals(""))
								{
									strPackCl = ""+System.Convert.ToDouble(strPackCl)*d1*d2 ;            
								}
							}
							
							sw.WriteLine(info1,GenUtil.TrimLength(rdr["Product"].ToString().Trim(),30),GenUtil.TrimLength(rdr["store_in"].ToString().Trim(),15),rdr["closing_stock"].ToString(),strPackCl,rdr["Sal_Rate"].ToString()); 
						}
					}
				}
			}
			if(RadioYes.Checked)
			{
				sw.WriteLine("+------------------------------+---------------+-------------+-----------+---------------+");
				sw.WriteLine(info1,"           Total","",Cache["csp"],Cache["cs"],Cache["Amount"].ToString());
				sw.WriteLine("+------------------------------+---------------+-------------+-----------+---------------+");
			}
			else
			{
				sw.WriteLine("+------------------------------+---------------+-------------+-----------+");
				sw.WriteLine(info,"           Total","",Cache["csp"],Cache["cs"]);
				sw.WriteLine("+------------------------------+---------------+-------------+-----------+");
			}
			dbobj.Dispose();
			rdr.Close();
			sw.Close(); 
		}
		
		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string sql="";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\StockReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			object op= null;
			dbobj.ExecProc(OprType.Insert,"sp_stock",ref op,"@fromdate",GenUtil.str2MMDDYYYY(txtDateTo.Text));
			//			if(txtDateTo.Text==System.DateTime.Now.ToShortDateString())
			//			{
			//				if(drpstore.SelectedIndex>0)
			//				{
			//					if(drpstore.SelectedItem.Text.IndexOf(":")>0)
			//					{
			//						string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
			//						string tid="";
			//						dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
			//						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
			//					}
			//					else 
			//					{
			//						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
			//					}
			//				}
			//				else
			//					sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
			//			}
			//			else if(drpstore.SelectedIndex>0)
			//			{
			//				if(drpstore.SelectedItem.Text.IndexOf(":")>0)
			//				{
			//					string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
			//					string tid="";
			//					dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
			//					sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
			//				}
			//				else 
			//				{
			//					sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
			//				}
			//			}
			//			else 
			//			{
			//				//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
			//				sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate";
			//				Trace.Write(sql);
			//			}
			if(txtDateTo.Text==System.DateTime.Now.ToShortDateString())
			{
				if(RadioYes.Checked)
				{
					if(drpstore.SelectedIndex>0)
					{
						if(drpstore.SelectedItem.Text.IndexOf(":")>0)
						{
							string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
							string tid="";
							dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
							//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
							sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";

						}
						else 
						{
							//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
							sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc)  and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						}
					}
					else
						//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
						sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
				}
				else
				{
					if(drpstore.SelectedIndex>0)
					{
						if(drpstore.SelectedItem.Text.IndexOf(":")>0)
						{
							string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
							string tid="";
							dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
							sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
							//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";

						}
						else 
						{
							sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
							//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b, price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc)  and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						}
					}
					else
						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
					//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
				}
			}
			else if(drpstore.SelectedIndex>0)
			{
				if(RadioYes.Checked)
				{
					if(drpstore.SelectedItem.Text.IndexOf(":")>0)
					{
						string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
						string tid="";
						dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
						//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
						sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
					}
					else
					{
						//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
					}
				}
				else
				{
					if(drpstore.SelectedItem.Text.IndexOf(":")>0)
					{
						string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
						string tid="";
						dbobj.SelectQuery("select tank_id from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
						//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ tid  +"'";
					}
					else
					{
						sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
						//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate and Store_in='"+ drpstore.SelectedItem.Text  +"'";
					}
				}
			}
			else 
			{
				if(RadioYes.Checked)
				{
					//sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
					sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
					//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.pur_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.pur_rate=(select top 1 pur_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
					Trace.Write(sql);
				}
				else
				{
					sql = "select a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty from vw_stockreport a , stk b where a.product=b.product and a.stock_date=b.sdate order by a.store_in";
					//sql = "select distinct a.stock_date,a.product, a.pack_type, a.store_in, a.closing_stock, a.category, a.totalqty,c.sal_rate from vw_stockreport a , stk b,price_updation c where a.product=b.product and c.sal_rate=(select top 1 sal_rate from price_updation where prod_id=a.prod_id order by eff_date desc) and a.stock_date=b.sdate order by a.store_in";
					Trace.Write(sql);
				}
			}
			//sql=sql+" order by a."+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("Date\t"+txtDateTo.Text);
			sw.WriteLine("Stock Location\t"+drpstore.SelectedItem.Text);
			if(RadioNo.Checked)
			{
				sw.WriteLine("Valuation\t"+"No");
				sw.WriteLine("Product Name\tLocation\tClosing Stock(Pkg)\tClosing Stock(Ltr/kg)");
			}
			else
			{
				sw.WriteLine("Valuation\t"+"Yes");
				sw.WriteLine("Product Name\tLocation\tClosing Stock(Pkg)\tClosing Stock(Ltr/kg)\tAmount");
			}
			string pack;
			string strPackCl;
			string[] strSplit;
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					pack="";
					strPackCl="";
					// if product category is fuel hen not dipslay the package, display the tank abbr name. 
					if(RadioNo.Checked)
					{
						if(rdr["category"].ToString().ToUpper().Equals("FUEL"))
						{
							string prod_name="";
							dbobj.SelectQuery("select Prod_AbbName from tank where tank_id='"+rdr["store_in"].ToString().Trim()+"'","Prod_AbbName",ref prod_name);
							sw.WriteLine(rdr["Product"].ToString().Trim()+"\t"+prod_name+"\t\t"+rdr["closing_stock"].ToString()); 
						}
							// if package is Loose Oil the not display the package type.
						else if(rdr["pack_type"].ToString().IndexOf("Loose") != -1)
						{
							sw.WriteLine(rdr["Product"].ToString().Trim()+"\t"+rdr["store_in"].ToString().Trim()+"\t\t"+rdr["closing_stock"].ToString()); 
						}
						else
						{
							pack = rdr["pack_type"].ToString().Trim();
							if (pack.IndexOf("X")<0 || pack.Equals("") )
							{
								strPackCl = rdr["closing_stock"].ToString().Trim();
							}
							else
							{
								strSplit = pack.Split(new char []{'X'},pack.Length);
								double d1 = 1;
								double d2 = 1;
								if(!strSplit[0].Trim().Equals (""))
									d1 = System.Convert.ToDouble(strSplit[0]);
								if(!strSplit[1].Trim().Equals (""))
									d2 = System.Convert.ToDouble(strSplit[1]);
								strPackCl = rdr["closing_stock"].ToString().Trim();
								if(!strPackCl.Equals(""))
								{
									strPackCl = ""+System.Convert.ToDouble(strPackCl)*d1*d2 ;            
								}
							}
							sw.WriteLine(rdr["Product"].ToString().Trim()+"\t"+rdr["store_in"].ToString().Trim()+"\t"+rdr["closing_stock"].ToString()+"\t"+strPackCl); 
						}
					}
					else
					{
						if(rdr["category"].ToString().ToUpper().Equals("FUEL"))
						{
							string prod_name="";
							dbobj.SelectQuery("select Prod_AbbName from tank where tank_id='"+rdr["store_in"].ToString().Trim()+"'","Prod_AbbName",ref prod_name);
							sw.WriteLine(rdr["Product"].ToString().Trim()+"\t"+prod_name+"\t\t"+rdr["closing_stock"].ToString()+"\t"+rdr["sal_rate"].ToString()); 
						}
							// if package is Loose Oil the not display the package type.
						else if(rdr["pack_type"].ToString().IndexOf("Loose") != -1)
						{
							sw.WriteLine(rdr["Product"].ToString().Trim()+"\t"+rdr["store_in"].ToString().Trim()+"\t\t"+rdr["closing_stock"].ToString()+"\t"+rdr["sal_rate"].ToString()); 
						}
						else
						{
							pack = rdr["pack_type"].ToString().Trim();
							if (pack.IndexOf("X")<0 || pack.Equals("") )
							{
								strPackCl = rdr["closing_stock"].ToString().Trim();
							}
							else
							{
								strSplit = pack.Split(new char []{'X'},pack.Length);
								double d1 = 1;
								double d2 = 1;
								if(!strSplit[0].Trim().Equals (""))
									d1 = System.Convert.ToDouble(strSplit[0]);
								if(!strSplit[1].Trim().Equals (""))
									d2 = System.Convert.ToDouble(strSplit[1]);
								strPackCl = rdr["closing_stock"].ToString().Trim();
								if(!strPackCl.Equals(""))
								{
									strPackCl = ""+System.Convert.ToDouble(strPackCl)*d1*d2 ;            
								}
							}
							sw.WriteLine(rdr["Product"].ToString().Trim()+"\t"+rdr["store_in"].ToString().Trim()+"\t"+rdr["closing_stock"].ToString()+"\t"+strPackCl+"\t"+rdr["sal_rate"].ToString()); 
						}
					}
				}
			}
			if(RadioNo.Checked)
				sw.WriteLine("Total\t\t"+Cache["csp"]+"\t"+Cache["cs"]);
			else
				sw.WriteLine("Total\t\t"+Cache["csp"]+"\t"+Cache["cs"]+"\t"+Cache["Amount"].ToString());
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
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
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5)
		{
			while(rdr.Read())
			{
				if(rdr["product"].ToString().Trim().Length>len1)
					len1=rdr["product"].ToString().Trim().Length;					
				if(IsTank(rdr["store_in"].ToString().Trim()).Length>len2)
					len2=IsTank(rdr["store_in"].ToString().Trim()).Length;					
				if(rdr["pack_type"].ToString().Trim().Length>len3)
					len3=22;
				if(rdr["closing_stock"].ToString().Trim().Length>len4)
					len4=rdr["closing_stock"].ToString().Trim().Length;					
				if(rdr["category"].ToString().Trim().Length>len5)
					len5=rdr["category"].ToString().Trim().Length;					
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
		//End report

		/// <summary>
		/// This method is used to check the Tank ID is exist or not.
		/// </summary>
		protected string IsTank(string str)
		{
			string op="";
			if(Char.IsDigit(str,0))
				dbobj.SelectQuery("select top 1 prod_abbname from tank where tank_id='"+str+"'","prod_abbname",ref op);
			if(op.Length>0)
				return op;
			else
				return str;
		}
		
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
		/// This method is used to multiply package qty. with actual qty. called from .aspx
		/// </summary>
		//double count=1,i=1;
		public double cs=0;
		protected string Multiply(string str)
		{
			string[] mystr=str.Split(new char[]{'X'},str.Length);
			if(str.Trim().IndexOf("Loose") == -1)
			{
				double ans=1;
				foreach(string val in mystr)
				{
					if(val.Length>0 && !val.Trim().Equals(""))
						ans*=double.Parse(val,System.Globalization.NumberStyles.Float);
				}
				//***************
				cs+=ans;
				Cache["cs"]=System.Convert.ToString(cs);
				//***************
				return ans.ToString() ;
			}
			else
			{
				if(!mystr[0].Trim().Equals(""))
				{
					//**********
					cs+=System.Convert.ToDouble( mystr[0].ToString()) ; 
					Cache["cs"]=System.Convert.ToString(cs);
					//*********
					return System.Convert.ToDouble( mystr[0].ToString()).ToString() ; 
				}
				else
					return "0";
			}
		}
		
		/// <summary>
		/// This method is used to multiply package qty. with actual qty. called from .aspx
		/// </summary>
		protected string Multiply1(string str)
		{
			string[] mystr=str.Split(new char[]{'X'},str.Length);
			if(str.Trim().IndexOf("Loose") == -1)
			{
				double ans=1;
				foreach(string val in mystr)
				{
					if(val.Length>0 && !val.Trim().Equals(""))
						ans*=double.Parse(val,System.Globalization.NumberStyles.Float);
				}
				//***************
				//cs+=ans;
				//Cache["cs"]=System.Convert.ToString(cs);
				//***************
				return ans.ToString() ;
			}
			else
			{
				if(!mystr[0].Trim().Equals(""))
				{
					//**********
					//cs+=System.Convert.ToDouble( mystr[0].ToString()) ; 
					//Cache["cs"]=System.Convert.ToString(cs);
					//*********
					return System.Convert.ToDouble( mystr[0].ToString()).ToString() ; 
				}
				else
					return "0";
			}
		}
		/// <summary>
		/// This method is used to check the category of product is fuel or packege is Loose Oil then return only space,,(Called from .aspx);
		/// </summary>
		//double count1=1,i1=1;
		public double csp=0;
		protected string Check(string cs, string type,string pack)
		{

			if(type.ToUpper().Equals("FUEL")|| pack.IndexOf("Loose")!= -1)
				return "&nbsp;";
			else
			{
				//**********
				csp+=System.Convert.ToDouble(cs);
				Cache["csp"]=System.Convert.ToString(csp);
				//*******
				return cs;
			}
		}

		/// <summary>
		/// This method is used to Returns the date in MM/DD/YYYY format.
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
		/// This method is used to Sends the text file to print server to print.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
				makingReport();
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\StockReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:StokReport,Class:DBoperation_LETEST + Method:btnPrint_Click,  Stock Report Printed  userid  "+uid);
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:StokReport,Class:DBoperation_LETEST + Method:btnPrint_Click,  Stock Report Printed  EXCEPTION   "+ane.Message +"  userid "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:StokReport,Class:DBoperation_LETEST + Method:btnPrint_Click,  Stock Report Printed  EXCEPTION   "+se.Message +"  userid "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:StokReport,Class:DBoperation_LETEST + Method:btnPrint_Click,  Stock Report Printed  EXCEPTION   "+es.Message  +"  userid "+uid);
				}
			} 
			catch (Exception es) 
			{						
				CreateLogFiles.ErrorLog("Form:StokReport,Class:DBoperation_LETEST + Method:btnPrint_Click,  Stock Report Printed  EXCEPTION   "+es.Message+"  userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(grdLeg.Visible==true || Datagrid1.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:StockReport.aspx,Method: btnExcel_Click, Stock Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:StockReport.aspx,Method:btnExcel_Click   Stock Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
		
		double Amount=0;
		/// <summary>
		/// This method is used to calculate the amount
		/// </summary>
		public string GetAmount(string Pkg,string Ltr,string Amt)
		{
			double Tot=0;
			if(Pkg != "" && Pkg != "&nbsp;")
				Tot=double.Parse(Pkg)*double.Parse(Amt);
			else
				Tot=double.Parse(Ltr)*double.Parse(Amt);
			Amount+=Tot;
			Cache["Amount"]=Amount.ToString();
			return GenUtil.strNumericFormat(Tot.ToString());
		}
	}
}