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
using System.Data.SqlClient;
using RMG;
using DBOperations;
using System.Net;
using System.Net.Sockets;

using System.IO;
using System.Text;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for SaleBook.
	/// </summary>
	public class SaleBook : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateTo;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.DataGrid GridSalesReport;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		//protected System.Web.UI.WebControls.DropDownList DropSalesType;
		protected System.Web.UI.WebControls.Button btnExcel;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		protected System.Web.UI.WebControls.CheckBox chkCashSale;
		protected System.Web.UI.WebControls.CheckBox chkCreditSale;
		protected System.Web.UI.WebControls.CheckBox chkFleetSale;
		protected System.Web.UI.WebControls.CheckBox chkGeneralSale;
		protected System.Web.UI.WebControls.CheckBox chkSlipWiseSale;
		string strOrderBy="";
	
		/// <summary>
		/// This method is used for setting the Session variable for userId
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
                txtDateFrom.Attributes.Add("readonly", "readonly");
                Textbox1.Attributes.Add("readonly", "readonly");
                uid =(Session["User_Name"].ToString());
			}
			catch(Exception es)
			{
				CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:page_load  EXCEPTION "+ es.Message+" userid "+  uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
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
				if(View_flag=="0")
				{
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
				txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
				Textbox1.Text = DateTime.Now.Day+ "/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year;
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
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// This method is used to return date mm/dd/yyyy format.
		/// </summary>
		# region DateTime Function...
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
		# endregion

		/// <summary>
		/// This method is used to call the BindTheData() function for view the report.
		/// </summary>
		# region Show Button...
		private void btnShow_Click(object sender, System.EventArgs e)
		{    
			try
			{
				if(DateTime.Compare(ToMMddYYYY(txtDateFrom.Text),ToMMddYYYY(Textbox1.Text))>0)
				{
					MessageBox.Show("Date From Should be less than Date To");
					GridSalesReport.Visible=false;
				}
				else
				{
					#region Bind DataGrid
					strOrderBy = "Invoice_No ASC";
					Session["Column"] = "Invoice_No";
					Session["Order"] = "ASC";
					BindTheData();
					//					sql="select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
					//					SqlDtr =obj.GetRecordSet(sql);
					//					GridSalesReport.DataSource=SqlDtr;
					//					GridSalesReport.DataBind();
					//					if(GridSalesReport.Items.Count==0)
					//					{
					//						MessageBox.Show("Data not available");
					//						GridSalesReport.Visible=false;
					//					}
					//					else
					//					{
					//						GridSalesReport.Visible=true;
					//					}
					//					SqlDtr.Close();
					#endregion 
				}
				CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:btnShow_Click  Sale Book Report   Viewed "+"  userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:btnShow_Click  Sale Book Report   Viewed "+"  EXCEPTION  "+ ex.Message+"  userid  "+uid);
			}
		}
		# endregion 

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="";
			/*
			if(DropSalesType.SelectedItem.Text.Equals("Combine Sales"))
				sqlstr="(select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
			else if(DropSalesType.SelectedItem.Text.Equals("Cash Sale"))
				sqlstr="select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			else if(DropSalesType.SelectedItem.Text.Equals("Slip Wise Credit"))
				sqlstr="select * from vw_SaleBook where (Sales_Type='Credit' or Sales_Type='Slip Wise Credit') and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			else
				sqlstr="select * from vw_SaleBook where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			*/
			
			if(chkSlipWiseSale.Checked==true || chkCashSale.Checked==true || chkCreditSale.Checked==true || chkFleetSale.Checked==true || chkGeneralSale.Checked==true)
			{
				//sqlstr="(select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
				int f=0;
				sqlstr="(select * from vw_SaleBook s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' and (";
				if(chkCreditSale.Checked)
				{
					sqlstr+="s.Sales_Type='Credit Card Sale'";
					f=1;
				}

				if(chkFleetSale.Checked)
				{
					//if(cr== 0 && fl == 0 && gen == 0 && sl == 0)
					if(f==0)
						sqlstr+="s.Sales_Type='Fleet Card Sale'";
					else
						sqlstr+=" or s.Sales_Type='Fleet Card Sale'";
					f=1;
				}
				if(chkGeneralSale.Checked)
				{
					if(f==0)
						sqlstr+="s.Sales_Type='General Credit'";
					else
						sqlstr+=" or s.Sales_Type='General Credit'";
					f=1;
				}
				if(chkSlipWiseSale.Checked)
				{
					if(f==0)
						sqlstr+="s.Sales_Type='Slip Wise Credit'";
					else
						sqlstr+=" or s.Sales_Type='Slip Wise Credit'";
					f=1;
				}
				if(f!=0)
					sqlstr+="))";
				if(chkCashSale.Checked)
				{
					if(f==0)
						//sqlstr="(select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select * from CashBilling where custname='Deleted' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
						sqlstr="select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
					else
						sqlstr+=" union (select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
				}
			}
			else
			{
				MessageBox.Show("Please Select Atleast One CheckBox");
				GridSalesReport.Visible=false;
				return;
			}
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds,"Sales_Master");
			DataTable dtCustomers = ds.Tables[0];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["SalesBook"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridSalesReport.DataSource = dv;
				GridSalesReport.DataBind();
				GridSalesReport.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridSalesReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:SalesBook.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
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
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6,ref int len7,ref int len8, ref int len9,ref int len10,ref int len11,ref int len12,ref int len13,ref int len14)
		{
			while(rdr.Read())
			{
				if(rdr["Cust_ID"].ToString().Trim().Length>len1)
					len1=rdr["Cust_ID"].ToString().Trim().Length;					
				if(rdr["Cust_Name"].ToString().Trim().Length>len2)
					len2=rdr["Cust_Name"].ToString().Trim().Length;					
				if(rdr["City"].ToString().Trim().Length>len3)
					len3=rdr["City"].ToString().Trim().Length;
				if(rdr["Cust_Type"].ToString().Trim().Length>len4)
					len4=rdr["Cust_Type"].ToString().Trim().Length;					
				if(rdr["Invoice_No"].ToString().Trim().Length>len5)
					len5=rdr["Invoice_No"].ToString().Trim().Length;					
				if(rdr["Invoice_Date"].ToString().Trim().Length>len6)
					len6=rdr["Invoice_Date"].ToString().Trim().Length;	
				if(rdr["Under_SalesMan"].ToString().Trim().Length>len7)
					len7=rdr["Under_SalesMan"].ToString().Trim().Length;	
				if(rdr["Pack_Type"].ToString().Trim().Length>len8)
					len8=rdr["Pack_Type"].ToString().Trim().Length;	
				if(rdr["Prod_Name"].ToString().Trim().Length>len9)
					len9=rdr["Prod_Name"].ToString().Trim().Length;	
				if(rdr["Qty"].ToString().Trim().Length>len10)
					len10=rdr["Qty"].ToString().Trim().Length;	
				if(rdr["Rate"].ToString().Trim().Length>len11)
					len11=rdr["Rate"].ToString().Trim().Length;	
				if(rdr["Discount"].ToString().Trim().Length>len12)
					len12=rdr["Discount"].ToString().Trim().Length;	
				if(rdr["Promo_Scheme"].ToString().Trim().Length>len13)
					len13=rdr["Promo_Scheme"].ToString().Trim().Length;	
				if(rdr["Cr_Days"].ToString().Trim().Length>len14)
					len14=rdr["Cr_Days"].ToString().Trim().Length;	
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
		/// This Method is used to prepare the report file.
		/// </summary>
		public void makingReport()
		{
			/*
																	=========================================
																	SALES REPORT From 01/07/2006 To 9/7/2006
																	=========================================
+----+--------------------+---------------+-------------+------+----------+--------------------+-------+---------------+--------+------+--------+--------------------+----+----------+
|Cust|Customer Name       |     City      |Customer Type|Inv.No|Inv. Date |   Under Salesman   | Pack. | Product Name  |Quantity| Rate |Discount|    Promo Scheme    |Cr. | Due Date |
| ID |                    |               |             |      |          |                    | Type  |               |        |      |        |                    |Days|          |
+----+--------------------+---------------+-------------+------+----------+--------------------+-------+---------------+--------+------+--------+--------------------+----+----------+
 1234 12345678901234567890 123456789012345 1234567890123 123456 1234567890 12345678901234567890 1234567 123456789012345 12345678 123456 12345678 12345678901234567890 1234 1234567890
 */
			try
			{
				System.Data.SqlClient.SqlDataReader rdr=null;
				string sql="";
				string info = "";
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SalesBookReport.txt";
				StreamWriter sw = new StreamWriter(path);
				string strDate="";
				string strDueDate="";
				string promo = "";
				/*
				if(DropSalesType.SelectedItem.Text.Equals("Combine Sales"))
					sql="(select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
				else if(DropSalesType.SelectedItem.Text.Equals("Cash Sale"))
					sql="select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				else if(DropSalesType.SelectedItem.Text.Equals("Slip Wise Credit"))
					sql="select * from vw_SaleBook where (Sales_Type='Credit' or Sales_Type='Slip Wise Credit') and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				else
					sql="select * from vw_SaleBook where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				*/
				int f=0;
				if(chkSlipWiseSale.Checked==true || chkCashSale.Checked==true || chkCreditSale.Checked==true || chkFleetSale.Checked==true || chkGeneralSale.Checked==true)
				{
					//sqlstr="(select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
					f=0;
					//sql="(select * from vw_SaleBook s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' and (";
					sql="select * from vw_SaleBook s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' and (";
					if(chkCreditSale.Checked)
					{
						sql+="s.Sales_Type='Credit Card Sale'";
						f=1;
					}

					if(chkFleetSale.Checked)
					{
						//if(cr== 0 && fl == 0 && gen == 0 && sl == 0)
						if(f==0)
							sql+="s.Sales_Type='Fleet Card Sale'";
						else
							sql+=" or s.Sales_Type='Fleet Card Sale'";
						f=1;
					}
					if(chkGeneralSale.Checked)
					{
						if(f==0)
							sql+="s.Sales_Type='General Credit'";
						else
							sql+=" or s.Sales_Type='General Credit'";
						f=1;
					}
					if(chkSlipWiseSale.Checked)
					{
						if(f==0)
							sql+="s.Sales_Type='Slip Wise Credit'";
						else
							sql+=" or s.Sales_Type='Slip Wise Credit'";
						f=1;
					}
					if(f!=0)
						sql+=")";
					//sql+="";
					if(chkCashSale.Checked)
					{
						if(f==0)
							sql="select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
						else
							sql+=" union select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' order by s."+Cache["SalesBook"]+"";
						f=2;
					}
					else
						sql+=" order by s."+Cache["SalesBook"]+"";
				}
				else
				{
					MessageBox.Show("Please Select Atleast One CheckBox");
					return;
				}
				//sql="select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast (invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				//if(f!=2)
				//	sql=sql+" order by "+Cache["SalesBook"];
				dbobj.SelectQuery(sql,ref rdr);


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
		
				//************
				string des="-----------------------------------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("=========================================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("SALES REPORT From "+txtDateFrom.Text.ToString()+" To "+Textbox1.Text.ToString(),des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("=========================================",des.Length));
				//sw.WriteLine("Sales Type : "+DropSalesType.SelectedItem.Text.ToString());
				string str="";
				if(chkSlipWiseSale.Checked)
					str+="Slip Wise Credit,";
				if(chkCreditSale.Checked)
					str+="Credit Card Sale,";
				if(chkFleetSale.Checked)
					str+="Fleet Card Sale,";
				if(chkCashSale.Checked)
					str+="Cash Card Sale,";
				if(chkGeneralSale.Checked)
					str+="General Credit,";
				sw.WriteLine("Sales Type : "+str);
				//sw.WriteLine("+----+--------------------+---------------+-------------+------+----------+--------------------+----------+---------------+--------+------+--------+--------------------+----+----------+");
				//sw.WriteLine("|Cust|  Customer Name     |     City      |Customer Type|Inv.No|Inv. Date |   Under Salesman   |Pack. Type| Product Name  |Quantity| Rate |Discount|    Promo Scheme    |Cr. | Due Date |");
				//sw.WriteLine("| ID |                    |               |             |      |          |                    |          |               |        |      |        |                    |Days|          |");
				//sw.WriteLine("+----+--------------------+---------------+-------------+------+----------+--------------------+----------+---------------+--------+------+--------+--------------------+----+----------+"); 
				// 1234 12345678901234567890 123456789012345 1234567890123 123456 1234567890 12345678901234567890 1234567890 123456789012345 12345678 123456 12345678 12345678901234567890 1234 1234567890
			
				sw.WriteLine("+-------------+--------+----------+---------+------+----------+-------------+------------+--------+------+----+---------+----+----------+");
				sw.WriteLine("|Customer Name| Slip No|Vehicle_No|  Place  |Invo. | Invoice  |UnderSalesman|Product Name|Quantity|Price |Disc| Invoice |Cr. | Due Date |");
				sw.WriteLine("|             |        |          |         | No   |  Date    |             |            | in ltr.|      |ount| Amount  |Days|          |");
				sw.WriteLine("+-------------+--------+----------+---------+------+----------+-------------+------------+--------+------+----+---------+----+----------+"); 
				//			   1234567890123 12345678 1234567890 123456789 123456 1234567890 1234567890123 123456789012 12345678 123456 1234 123456789 1234 1234567890
				if(rdr.HasRows)
				{
					// info : to set the string format.
					//info = " {0,-4:S} {1,-20:S} {2,-15:S} {3,-13:S} {4,-6:S} {5,-10:S} {6,-20:S} {7,-10:S} {8,-15:S} {9,-8:S} {10,6:F} {11,-8:S} {12,-20:S} {13,-4:S} {14,-10:S}";
					info = " {0,-13:S} {1,-8:S} {2,-10:S} {3,-9:S} {4,-6:S} {5,-10:S} {6,-13:S} {7,-12:S} {8,8:S} {9,6:F} {10,4:S} {11,9:S} {12,4:S} {13,-10:S}";
					while(rdr.Read())
					{					
						strDate = rdr["Invoice_Date"].ToString().Trim();
						int pos = strDate.IndexOf(" ");
				
						if(pos != -1)
						{
							strDate = strDate.Substring(0,pos);
						}
						else
						{
							strDate = "";					
						}
                    
						strDueDate = rdr["Due_date"].ToString().Trim();
						pos = -1;
						pos = strDueDate.IndexOf(" ");
				
						if(pos != -1)
						{
							strDueDate = strDueDate.Substring(0,pos);
						}
						else
						{
							strDueDate = "";					
						}
					
						promo = rdr["Promo_Scheme"].ToString().Trim();

						if (promo.Length > 20)
						{
							promo = promo.Substring(0,20);
						}

						sw.WriteLine(info,GenUtil.TrimLength(rdr["Cust_Name"].ToString().Trim(),13),
							GenUtil.TrimLength(rdr["slip_no"].ToString().Trim(),8),
							GenUtil.TrimLength(rdr["vehicle_no"].ToString().Trim(),10),
							GenUtil.TrimLength(rdr["City"].ToString().Trim(),9),
							//GenUtil.TrimLength(rdr["Cust_Type"].ToString().Trim(),9),
							rdr["Invoice_No"].ToString().Trim(),
							GenUtil.str2DDMMYYYY(strDate),
							GenUtil.TrimLength(rdr["Under_SalesMan"].ToString().Trim(),13),
							//GenUtil.TrimLength(rdr["Pack_Type"].ToString().Trim(),9),
							GenUtil.TrimLength(rdr["Prod_Name"].ToString().Trim(),12),
							GenUtil.strNumericFormat((Multiply(rdr["Pack_Type"].ToString()+"X"+rdr["Qty"].ToString())).ToString()),
							//rdr["Qty"].ToString(),
							GenUtil.strNumericFormat(rdr["Rate"].ToString().Trim()),
							rdr["Discount"].ToString().Trim(),
							Multiply1(rdr["Invoice_No"].ToString()),
							rdr["Cr_Days"].ToString().Trim(),
							GenUtil.str2DDMMYYYY(strDueDate)
							);

					}
				}
				
				sw.WriteLine("+-------------+--------+----------+---------+------+----------+-------------+------------+--------+------+----+---------+----+----------+");
				sw.WriteLine(info,"  Total","","","","","","","",GenUtil.strNumericFormat(Cache["os"].ToString()),"","",GenUtil.strNumericFormat(Cache["amt"].ToString()),"","");
				sw.WriteLine("+-------------+--------+----------+---------+------+----------+-------------+------------+--------+------+----+---------+----+----------+");

		
				dbobj.Dispose();
				// deselect Condensed
				//sw.Write((char)18);
				//sw.Write((char)12);
				sw.Close();
				//Session["From_Date"] = txtDateFrom.Text;
				//Session["To_Date"] = Textbox1.Text;
				//Response.Redirect("SalesBook_PrintPreview.aspx",false); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:makingReport().  EXCEPTION "+ ex.Message+" userid "+  uid);
			}
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
			string path = home_drive+@"\ePetro_ExcelFile\SalesBookReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			string strDate="";
			string strDueDate="";
			string promo = "";
			/*
			if(DropSalesType.SelectedItem.Text.Equals("Combine Sales"))
				sql="(select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
			else if(DropSalesType.SelectedItem.Text.Equals("Cash Sale"))
				sql="select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			else if(DropSalesType.SelectedItem.Text.Equals("Slip Wise Credit"))
				sql="select * from vw_SaleBook where (Sales_Type='Credit' or Sales_Type='Slip Wise Credit') and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			else
				sql="select * from vw_SaleBook where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			*/
			int f=0;
			if(chkSlipWiseSale.Checked==true || chkCashSale.Checked==true || chkCreditSale.Checked==true || chkFleetSale.Checked==true || chkGeneralSale.Checked==true)
			{
				//sqlstr="(select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select * from vw_CashBilling where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
				f=0;
				//				sql="(select * from vw_SaleBook s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' and (";
				//				if(chkCreditSale.Checked)
				//				{
				//					sql+="s.Sales_Type='Credit Card Sale'";
				//					f=1;
				//				}
				//
				//				if(chkFleetSale.Checked)
				//				{
				//					//if(cr== 0 && fl == 0 && gen == 0 && sl == 0)
				//					if(f==0)
				//						sql+="s.Sales_Type='Fleet Card Sale'";
				//					else
				//						sql+=" or s.Sales_Type='Fleet Card Sale'";
				//					f=1;
				//				}
				//				if(chkGeneralSale.Checked)
				//				{
				//					if(f==0)
				//						sql+="s.Sales_Type='General Credit'";
				//					else
				//						sql+=" or s.Sales_Type='General Credit'";
				//					f=1;
				//				}
				//				if(chkSlipWiseSale.Checked)
				//				{
				//					if(f==0)
				//						sql+="s.Sales_Type='Slip Wise Credit'";
				//					else
				//						sql+=" or s.Sales_Type='Slip Wise Credit'";
				//					f=1;
				//				}
				//				if(f!=0)
				//					sql+="))";
				//				if(chkCashSale.Checked)
				//				{
				//					if(f==0)
				//						sql="(select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
				//					else
				//						sql+=" union (select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"')";
				//					f=2;
				//				}
				sql="select * from vw_SaleBook s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' and (";
				if(chkCreditSale.Checked)
				{
					sql+="s.Sales_Type='Credit Card Sale'";
					f=1;
				}

				if(chkFleetSale.Checked)
				{
					//if(cr== 0 && fl == 0 && gen == 0 && sl == 0)
					if(f==0)
						sql+="s.Sales_Type='Fleet Card Sale'";
					else
						sql+=" or s.Sales_Type='Fleet Card Sale'";
					f=1;
				}
				if(chkGeneralSale.Checked)
				{
					if(f==0)
						sql+="s.Sales_Type='General Credit'";
					else
						sql+=" or s.Sales_Type='General Credit'";
					f=1;
				}
				if(chkSlipWiseSale.Checked)
				{
					if(f==0)
						sql+="s.Sales_Type='Slip Wise Credit'";
					else
						sql+=" or s.Sales_Type='Slip Wise Credit'";
					f=1;
				}
				if(f!=0)
					sql+=")";
				//sql+="";
				if(chkCashSale.Checked)
				{
					if(f==0)
						sql="select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
					else
						sql+=" union select * from vw_CashBilling s,sales_master sm where sm.invoice_no=s.invoice_no and cast(floor(cast(s.invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(s.invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' order by s."+Cache["SalesBook"]+"";
					f=2;
				}
				else
					sql+=" order by s."+Cache["SalesBook"]+"";
			}
			else
			{
				MessageBox.Show("Please Select Atleast One CheckBox");
				return;
			}
			//if(f!=2)
			//	sql=sql+" order by "+Cache["SalesBook"];
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+Textbox1.Text);
			//sw.WriteLine("Sales Type\t"+DropSalesType.SelectedItem.Text.ToString());
			string str="";
			if(chkSlipWiseSale.Checked)
				str+="Slip Wise Credit\t";
			if(chkCreditSale.Checked)
				str+="Credit Card Sale\t";
			if(chkFleetSale.Checked)
				str+="Fleet Card Sale\t";
			if(chkCashSale.Checked)
				str+="Cash Card Sale\t";
			if(chkGeneralSale.Checked)
				str+="General Credit\t";
			sw.WriteLine("Sales Type :\t"+str);
			sw.WriteLine("Customer Name\tSlip_No\tVehicle_No\tPlace\tInvoice No\tInvoice Date\tUnder Salesman\tProduct Name\tQuantity In Ltr\tPrice\tDiscount\tInvoice Amount\tCr. Days\tDue Date");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{					
					strDate = rdr["Invoice_Date"].ToString().Trim();
					int pos = strDate.IndexOf(" ");
					if(pos != -1)
						strDate = strDate.Substring(0,pos);
					else
						strDate = "";					
					strDueDate = rdr["Due_date"].ToString().Trim();
					pos = -1;
					pos = strDueDate.IndexOf(" ");
					if(pos != -1)
						strDueDate = strDueDate.Substring(0,pos);
					else
						strDueDate = "";					
					promo = rdr["Promo_Scheme"].ToString().Trim();
					if (promo.Length > 20)
						promo = promo.Substring(0,20);
					sw.WriteLine(rdr["Cust_Name"].ToString().Trim()+"\t"+
						rdr["slip_no"].ToString().Trim()+"\t"+
						rdr["vehicle_no"].ToString().Trim()+"\t"+
						rdr["City"].ToString().Trim()+"\t"+
						//rdr["Cust_Type"].ToString().Trim()+"\t"+
						rdr["Invoice_No"].ToString().Trim()+"\t"+
						GenUtil.str2DDMMYYYY(strDate)+"\t"+
						rdr["Under_SalesMan"].ToString().Trim()+"\t"+
						//rdr["Pack_Type"].ToString().Trim()+"\t"+
						rdr["Prod_Name"].ToString().Trim()+"\t"+
						GenUtil.strNumericFormat((Multiply(rdr["Pack_Type"].ToString()+"X"+rdr["Qty"].ToString())).ToString())+"\t"+
						//rdr["Qty"].ToString(),
						GenUtil.strNumericFormat(rdr["Rate"].ToString().Trim())+"\t"+
						rdr["Discount"].ToString().Trim()+"\t"+
						Multiply1(rdr["Invoice_No"].ToString())+"\t"+
						rdr["Cr_Days"].ToString().Trim()+"\t"+
						GenUtil.str2DDMMYYYY(strDueDate)
						);
				}
			}
			sw.WriteLine("Total\t\t\t\t\t\t\t\t"+GenUtil.strNumericFormat(Cache["os"].ToString())+"\t\t\t"+GenUtil.strNumericFormat(Cache["amt"].ToString()));
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This methos is used to sends the text file to print server to print.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			makingReport();

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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\SalesBookReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:BtnPrint_Click   Sale Book Report   userid  "+uid);
					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:BtnPrint_Click, Sales Book Report Printed    EXCEPTION  "+ ane.Message+" userid  "+  uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:BtnPrint_Click, Sales Book Report Printed  EXCEPTION  "+ se.Message+"  userid  "+  uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
	
					CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:BtnPrint_Click, Sales Book Report Printed   EXCEPTION "+es.Message+"  userid  "+  uid);
				}
			} 
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:BtnPrint_Click, Sales Book Report Printed  EXCEPTION   "+ es.Message+"  userid  "+  uid);
			}
		}

		double amt=0,amt1=0,amt2=0;
		int count=0,i=0,status=0,Flag=0;
		protected string Multiply1(string inv_no)
		{
			PetrolPumpClass  obj=new PetrolPumpClass();
			SqlDataReader SqlDtr;
			string sql;
			in_amt=0;
			//in_amt=double.Parse(qty)*double.Parse(price);
			//amt2+=in_amt;
			//Cache["amt"]=System.Convert.ToString(amt2);
			if(Flag==0)
			{
				Cache["Invoice_No"]=inv_no;
				Flag=1;
			}
			else if(Flag==3)
			{
				Cache["Invoice_No"] = inv_no;
			}
			if(status==0)
			{
				sql = "(select count(*) from vw_SaleBook where Invoice_No="+Cache["Invoice_No"].ToString()+") union (select count(*) from vw_CashBilling where Invoice_No="+Cache["Invoice_No"].ToString()+")";
				SqlDtr =obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					count += int.Parse(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
				status=1;
			}
			if(i<count)
			{
				amt += System.Convert.ToDouble(in_amt);
				Flag=2;
				i++;
			}
			if(i==count)
			{
				//amt1=amt;
				string sql1 = "select Net_Amount from Sales_Master where Invoice_No="+Cache["Invoice_No"].ToString();
				SqlDtr =obj.GetRecordSet(sql1);
				while(SqlDtr.Read())
				{
					amt1 = double.Parse(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
				amt2+=amt1;
				Cache["amt"]=System.Convert.ToString(amt2);
				amt=0;
				status=0;
				i=0;
				Flag=3;
				count=0;
				//Cache["Invoice_No"] = invoice_no;
			}
			else
			{
				amt1=0;
				Flag=4;
			}
			//Invoice_Amt += double.Parse(_Amount);
			//Cache["Invoice_Amt"]=System.Convert.ToString(Invoice_Amt);
			if(Flag==4)
				return "---";
			else if(Flag==3)
				return GenUtil.strNumericFormat(amt1.ToString());
			return "";
		}

		/// <summary>
		/// This Method multiplies the package quantity with Quantity.
		/// </summary>
		public double os=0,os1=0,in_amt=0;
		protected double Multiply(string str)
		{
			//*******
			string[] str1=str.Split(new char[] {':'},str.Length);
			//*******
			string[] mystr=str1[0].Split(new char[]{'X'},str1[0].Length);
			// check the package type is loose or not.
			if(str1[0].Trim().IndexOf(" ") == -1)
			{
				if(str1[0].Trim().IndexOf("Loose") == -1)
				{
					double ans=1;
					foreach(string val in mystr)
					{
						if(val.Length>0 && !val.Trim().Equals(""))
							ans*=double.Parse(val,System.Globalization.NumberStyles.Float);
					}
					//******
					os+=ans;
					Cache["os"]=System.Convert.ToString(os);
					//******
					return ans;
				}
				else
				{
					if(!mystr[1].Trim().Equals(""))
					{
						//*******
						os+=System.Convert.ToDouble( mystr[1].ToString());
						Cache["os"]=System.Convert.ToString(os);
						//*******
						return System.Convert.ToDouble( mystr[1].ToString()); 
					}
					else
					{
						os=0;
						Cache["os"]=System.Convert.ToString("0");
						return 0;
					}
					
				}
			}
			else
			{
				//os1 = System.Convert.ToDouble( mystr[1].ToString())*1000;
				os1 = System.Convert.ToDouble( mystr[1].ToString());
				//os+=System.Convert.ToDouble( mystr[1].ToString())*1000;
				os+=System.Convert.ToDouble( mystr[1].ToString());
				Cache["os"]=System.Convert.ToString(os);
				//return System.Convert.ToDouble( mystr[1].ToString()); 	
				return os1;
			}
		}

		/// <summary>
		/// This method is used to check the date when retrieve from the database
		/// if date is "1/1/1900" then pass the blank values 
		/// </summary>
		public string BlankDate(string dt)
		{
			if(dt=="01/01/1900")
				dt="";
			return dt;
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridSalesReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method: btnExcel_Click, SaleBook Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:btnExcel_Click   SaleBook Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}