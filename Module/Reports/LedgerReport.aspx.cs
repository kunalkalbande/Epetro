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
	/// Summary description for CustomerLedger.
	/// </summary>
	public class CustomerLedger : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Button cmdrpt;
		protected System.Web.UI.WebControls.Button BtnPrint;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		protected System.Web.UI.WebControls.DropDownList DropPartyName;
		string uid = "";
		static string strOrderBy="";
		public double debit_total = 0;
		public double credit_total = 0;
		public string balance = "";
		public string baltype = "";
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.DataGrid CustomerGrid;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DataGrid TotalSales;
		protected System.Web.UI.WebControls.DropDownList DropReportType;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
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
					string SubModule="25";
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
					getParties(); 
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"  "+ uid );
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
		}

		/// <summary>
		/// This method is used to fetch the parties(customer) and city from customer table and fills the Party name combo.
		/// </summary>
		public void getParties()
		{
			ArrayList Party=new ArrayList();
			SqlDataReader SqlDtr = null;
			dbobj.SelectQuery("Select Cust_Name+':'+City from Customer order by Cust_Name" ,ref SqlDtr);
			DropPartyName.Items.Clear();
			DropPartyName.Items.Add("Select");
			while(SqlDtr.Read())
			{
				//DropPartyName.Items.Add(SqlDtr.GetValue(0).ToString()); 
				Party.Add(SqlDtr.GetValue(0).ToString());
			}
			SqlDtr.Close();

			dbobj.SelectQuery("Select Supp_Name+':'+City from Supplier order by Supp_Name" ,ref SqlDtr);
			while(SqlDtr.Read())
			{
				//DropPartyName.Items.Add(SqlDtr.GetValue(0).ToString()); 
				Party.Add(SqlDtr.GetValue(0).ToString());
			}
			SqlDtr.Close();

			dbobj.SelectQuery("Select Emp_Name+':'+City from Employee order by emp_Name" ,ref SqlDtr);
			while(SqlDtr.Read())
			{
				//DropPartyName.Items.Add(SqlDtr.GetValue(0).ToString()); 
				Party.Add(SqlDtr.GetValue(0).ToString());
			}
			SqlDtr.Close();

			dbobj.SelectQuery("Select Ledger_Name from Ledger_Master where Sub_grp_ID=117",ref SqlDtr);
			while(SqlDtr.Read())
			{
				//DropPartyName.Items.Add(SqlDtr.GetValue(0).ToString()); 
				Party.Add(SqlDtr.GetValue(0).ToString()+":");
			}
			SqlDtr.Close();

			dbobj.SelectQuery("Select Ledger_Name from Ledger_Master where Sub_grp_ID=118",ref SqlDtr);
			while(SqlDtr.Read())
			{
				//DropPartyName.Items.Add(SqlDtr.GetValue(0).ToString()); 
				Party.Add(SqlDtr.GetValue(0).ToString()+":");
			}
			//			dbobj.SelectQuery("Select Ledger_Name from Ledger_Master where Sub_grp_ID>118",ref SqlDtr);
			//			while(SqlDtr.Read())
			//			{
			//				//DropPartyName.Items.Add(SqlDtr.GetValue(0).ToString()); 
			//				Party.Add(SqlDtr.GetValue(0).ToString()+":");
			//			}
			//			SqlDtr.Close();
			Party.Add("Sales A/C");
			Party.Add("Purchase A/C");
			Party.Sort();
			for(int i=0;i<Party.Count;i++)
			{
				DropPartyName.Items.Add(Party[i].ToString());
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
		/// This method is used to checks the validity of filled and selected values before firing a query.
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
			if(DropPartyName.SelectedIndex  == 0)
			{
				ErrorMessage = ErrorMessage + " - Please Select Party Name\n";
				flag = false;
			}
			
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
		/// This method is used to calculates the total debit amount by passing value
		/// </summary>
		protected void TotalDebit(double _debittotal)
		{
			debit_total  += _debittotal; 
		}

		/// <summary>
		/// This method is used to calculates total credit amount by passing value
		/// </summary>
		protected void TotalCredit(double _credittotal)
		{
			credit_total  += _credittotal; 
		}

		/// <summary>
		/// Its set the last Balance value and called from .aspx page from closing balance template coulumn
		/// </summary>
		protected string setBal(string _balance)
		{
			balance  = _balance; 
			return _balance;
		}
		double Balance=0;
		protected string setBalance(string _Bal)
		{
			Balance  += double.Parse(_Bal);
			return GenUtil.strNumericFormat(Balance.ToString());
		}
		double Balance1=0;
		protected string setBalance1(string _Debit,string _Credit)
		{
			if(DropPartyName.SelectedItem.Text.Equals("Sales A/C"))
				Balance1  += double.Parse(_Debit);
			else if(DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
				Balance1  += double.Parse(_Credit);
			return GenUtil.strNumericFormat(Balance1.ToString());
		}
		//double CBal=0;
		protected string setCBal(string _Debit,string _Credit)
		{
			string baltype=" Dr";
			double bal=double.Parse(_Credit)-Double.Parse(_Debit);
			if(bal>=0)
				baltype=" Cr";
			else
				baltype=" Dr";
			return GenUtil.strNumericFormat(System.Convert.ToString(Math.Abs(bal)))+baltype;
		}
		
		double Debit=0;
		/// <summary>
		/// This method is used to calculate the debit amount.
		/// </summary>
		protected string GetDebit(string dr)
		{
			Debit+=double.Parse(dr);
			Cache["dr"]=Debit.ToString();
			return dr;
		}

		double Credit=0;
		/// <summary>
		/// This method is used to calculate the debit amount.
		/// </summary>
		protected string GetCredit(string cr)
		{
			Credit+=double.Parse(cr);
			Cache["cr"]=Credit.ToString();
			return cr;
		}
		protected string setMonth()
		{
			double Bal=double.Parse(Cache["dr"].ToString())-double.Parse(Cache["cr"].ToString());
			string type= "Dr";
			if(Bal>=0)
				type=" Dr";
			else
				type=" Cr";
			return GenUtil.strNumericFormat(System.Convert.ToString(Math.Abs(Bal)))+type;
		}
		/// <summary>
		/// Its set last Balance Type and called from .aspx page from closing balance template coulumn
		/// </summary>
		protected string setType(string _baltype)
		{
			baltype  = _baltype; 
			return _baltype;
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemTotal(object sender,DataGridItemEventArgs e)
		{
			try
			{
				// If datagrid item is a bound column other than header and footer
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
				{
					string str = e.Item.Cells[1].Text;
					string trans_no = "";
					// if transaction type is Opening Balance then show the blank value in transaction no.
					if(str.StartsWith("Opening"))
					{
						e.Item.Cells[0].Text = "&nbsp;";
					}
					else
					{
						// else show take the substring and display the no. in transaction no. and assign the remaining substring to transaction type.
						trans_no = str.Substring(str.IndexOf("(")+1);
						trans_no = trans_no.Substring(0,trans_no.Length-1);
						str = str.Substring(0,str.IndexOf("("));
						e.Item.Cells[0].Text = trans_no ;
						e.Item.Cells[1].Text = str.Trim();
					}
					// Calls the Totaldebit() and TotalCredit() function to increment the total values for each row.
					//This function hidden by mahesh (08/11/06)
					//TotalDebit(Double.Parse(e.Item.Cells[3].Text));
					//TotalCredit(Double.Parse(e.Item.Cells[4].Text));
				}
				else if(e.Item.ItemType == ListItemType.Footer)
				{
					//if the row or item type is footer then display the calculated total debit, credit and last balance with type in the footer. nfi and "N" used to format the double no. in #,###.00 format.
					//sum of cell[3],cell[4] hidden by mahesh (08/11/06)
					//e.Item.Cells[3].Text = debit_total.ToString("N",nfi);
					//e.Item.Cells[4].Text = credit_total.ToString("N",nfi);
					e.Item.Cells[5].Text = "(CB) "+balance+" "+baltype;                
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid );
			}
		}
		
		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemTotal2(object sender,DataGridItemEventArgs e)
		{
			try
			{
				// If datagrid item is a bound column other than header and footer
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
				{
					string str = e.Item.Cells[1].Text;
					string trans_no = "";
					// if transaction type is Opening Balance then show the blank value in transaction no.
					if(str.StartsWith("Opening"))
					{
						e.Item.Cells[0].Text = "&nbsp;";
					}
					else
					{
						// else show take the substring and display the no. in transaction no. and assign the remaining substring to transaction type.
						trans_no = str.Substring(str.IndexOf("(")+1);
						trans_no = trans_no.Substring(0,trans_no.Length-1);
						str = str.Substring(0,str.IndexOf("("));
						e.Item.Cells[0].Text = trans_no ;
						e.Item.Cells[1].Text = str.Trim();
					}
					// Calls the Totaldebit() and TotalCredit() function to increment the total values for each row.
					//This function hidden by mahesh (08/11/06)
					//TotalDebit(Double.Parse(e.Item.Cells[3].Text));
					//TotalCredit(Double.Parse(e.Item.Cells[4].Text)); 
				}
				else if(e.Item.ItemType == ListItemType.Footer)
				{
					//if the row or item type is footer then display the calculated total debit, credit and last balance with type in the footer. nfi and "N" used to format the double no. in #,###.00 format.
					//sum of cell[3],cell[4] hidden by mahesh (08/11/06)
					//e.Item.Cells[3].Text = debit_total.ToString("N",nfi);
					//e.Item.Cells[4].Text = credit_total.ToString("N",nfi);
					e.Item.Cells[5].Text = "(CB) "+GenUtil.strNumericFormat(Balance1.ToString())+" Dr";
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid );
			}
		}
		
		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemTotal1(object sender,DataGridItemEventArgs e)
		{
			try
			{
				// If datagrid item is a bound column other than header and footer
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
				{
					
					string str = e.Item.Cells[1].Text;
					// if transaction type is Opening Balance then  do not show the Datagrid1.
					if(str.StartsWith("Opening"))
					{
						Datagrid1.Visible=false;

					}
					
					else
					{
						SqlDataReader SqlDtr=null;
						dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
						if(SqlDtr.Read())
						{
							Ledger_ID = SqlDtr.GetValue(0).ToString();  
						}
						SqlDtr.Close();
						
						dbobj.SelectQuery("Select top 1 Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) < '"+ToMMddYYYY(txtDateFrom.Text)+"' order by Entry_Date desc",ref SqlDtr); 
						string bt="";
						string bl="";
						if(SqlDtr.Read())
						{
							bt=SqlDtr.GetValue(5).ToString();
							bl=SqlDtr.GetValue(4).ToString();
						}
						if(bt.Equals("Dr"))
						{
							e.Item.Cells[3].Text = GenUtil.strNumericFormat(bl);
							e.Item.Cells[4].Text = "0.00";
						}
						else
						{
							e.Item.Cells[4].Text = GenUtil.strNumericFormat(bl);
							e.Item.Cells[3].Text = "0.00";
						}
						
						e.Item.Cells[0].Text = "&nbsp;";
						e.Item.Cells[1].Text = "Opening Balance";
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid );
			}
		}

		/// <summary>
		/// This event occurres after pressing the view button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdrpt_Click(object sender, System.EventArgs e)
		{
			try
			{
				//Checks the validity of inputs.
				if(!checkValidity())
				{
					return;
				}
				strOrderBy = "Entry_Date ASC";
				Session["Column"] = "Entry_Date";
				Session["Order"] = "ASC";
				BindTheData();
				/*
						SqlDataReader SqlDtr = null;
						string drop_value = DropPartyName.SelectedItem.Text.Trim();  
						string party_name = "";
						string Ledger_ID = "";
						string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
						if(strArr.Length > 0)
						{
						   party_name = strArr[0].Trim(); 
						}
						// Take the customer name, fires the query to obtain the ledger id then again fire the query to fetch the transaction details and bind to the datagrid.
						//dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master lm, Ledger_Master_Sub_grp lmsg where Ledger_Name = '"+party_name+"' and lm.Sub_grp_ID = lmsg.sub_grp_id and lmsg.Sub_grp_Name = 'Sundry Debtors'",ref SqlDtr); 
						dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
						if(SqlDtr.Read())
						{
							Ledger_ID = SqlDtr.GetValue(0).ToString();  
						}
						SqlDtr.Close();
						dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type  from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"'",ref SqlDtr); 
						CustomerGrid.DataSource = SqlDtr;
						CustomerGrid.DataBind();
						if(CustomerGrid.Items.Count==0)
						{
							CustomerGrid.Visible=false;
							MessageBox.Show("Data not available");
							return;
						}
						else
						{
							CustomerGrid.Visible=true;
						}
						SqlDtr.Close ();
						*/
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:cmdrpt_Click(),   User_ID:"+ uid ); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:cmdrpt_Click()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid ); 
			}
		}

		string party_name = "";
		string Ledger_ID = "";
		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			//SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			//SqlDataReader SqlDtr = null;
			SqlConnection sqlcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			SqlConnection sqlcon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			//**************
			SqlDataReader SqlDtr = null;
			if(DropReportType.SelectedIndex==0)
			{
				string  sql="";
				int Flag=0;
				string drop_value = DropPartyName.SelectedItem.Text.Trim();
				if(drop_value.IndexOf(":")>0)
				{
					string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
					if(strArr.Length > 0)
					{
						party_name = strArr[0].Trim();
					}
					dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
					if(SqlDtr.Read())
					{
						Ledger_ID = SqlDtr.GetValue(0).ToString();  
					}
					SqlDtr.Close();
					Flag=0;
					sql="Select top 1 Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) < '"+ToMMddYYYY(txtDateFrom.Text)+"' order by Entry_Date desc"; 
				}
				else if(drop_value=="Sales A/C")
				{
					Flag=1;
					sql="Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where (particulars like 'Sales Invoice (%' or particulars like 'Sales in Cash(%') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"'"; 
				}
				else if(drop_value=="Purchase A/C")
				{
					Flag=1;
					sql="Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where particulars like 'Purchase Invoice (%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"'"; 
				}
				SqlDataAdapter da=new SqlDataAdapter(sql,sqlcon);
				DataSet ds=new DataSet();
				da.Fill(ds,"AccountsLedgerTable");
				DataTable dtcustomer=ds.Tables["AccountsLedgerTable"];
				DataView dv=new DataView(dtcustomer);
				dv.Sort=strOrderBy;
				Cache["strorderby"]=strOrderBy;
				TotalSales.Visible=false;
				Datagrid2.Visible=false;
				if(Flag==0)
				{
					Datagrid1.DataSource=dv;
					if(dv.Count!=0)
						//	Datagrid1.DataSource = SqlDtr;
						//	Datagrid1.DataBind();
						//	if(Datagrid1.Items.Count!=0)
					{
						Datagrid1.DataBind();
						Datagrid1.Visible=true;
						CustomerGrid.ShowHeader=false;	
					}
					else
					{
						Datagrid1.Visible=false;
						CustomerGrid.ShowHeader=true;
	
					}
				}
				else
				{
					Datagrid1.Visible=false;
					CustomerGrid.Visible=false;
					CustomerGrid.ShowHeader=false;
					TotalSales.DataSource=dv;
					if(dv.Count!=0)
					{
						TotalSales.DataBind();
						TotalSales.Visible=true;
					}
					else
					{
						TotalSales.Visible=false;
						MessageBox.Show("Data Not Available");
					}
				}
				//**************


				/*********************mahesh****************
				string drop_value = DropPartyName.SelectedItem.Text.Trim();  
			
				string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
				if(strArr.Length > 0)
				{
					party_name = strArr[0].Trim(); 
				}
				// Take the customer name, fires the query to obtain the ledger id then again fire the query to fetch the transaction details and bind to the datagrid.
				//dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master lm, Ledger_Master_Sub_grp lmsg where Ledger_Name = '"+party_name+"' and lm.Sub_grp_ID = lmsg.sub_grp_id and lmsg.Sub_grp_Name = 'Sundry Debtors'",ref SqlDtr); 
				dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
				if(SqlDtr.Read())
				{
					Ledger_ID = SqlDtr.GetValue(0).ToString();  
				}
				SqlDtr.Close();
				//dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type  from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"'",ref SqlDtr); 
				string sqlstr="Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type  from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"'";
				DataSet ds= new DataSet();
				SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
				da.Fill(ds, "AccountsLedgerTable");
				DataTable dtCustomers = ds.Tables["AccountsLedgerTable"];
				DataView dv=new DataView(dtCustomers);
				dv.Sort = strOrderBy;
				Cache["strOrderBy"]=strOrderBy;
				if(dv.Count!=0)
				{
					CustomerGrid.DataSource = dv;
					CustomerGrid.DataBind();
					CustomerGrid.Visible=true;
				}
				else
				{
					MessageBox.Show("Data not available");
					CustomerGrid.Visible=false;
				}
				SqlCon.Dispose();
				************************mahesh*********************/
				//string  sql1="Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by Entry_Date"; 
				if(Flag == 0)
				{
					string  sql1="Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"'";
					SqlDataAdapter da1=new SqlDataAdapter(sql1,sqlcon1);
					//CustomerGrid.DataSource = SqlDtr;
					//	CustomerGrid.DataBind();
					DataSet ds1=new DataSet();	
					da1.Fill(ds1," AccountsLedgerTable");
					DataTable dtcustomer1=ds1.Tables[" AccountsLedgerTable"]; 
					DataView dv1=new DataView(dtcustomer1);
					dv1.Sort=strOrderBy;
					Cache["strOrderBy"]=strOrderBy;
					CustomerGrid.DataSource=dv1;
					if(dv1.Count==0)
						//	if(CustomerGrid.Items.Count==0)
					{
						CustomerGrid.Visible=false;
						Datagrid1.Visible=false;
						Datagrid2.Visible=false;
						MessageBox.Show("Data not available");
						return;
					}
					else
					{
						CustomerGrid.DataBind();
						CustomerGrid.Visible=true;
					}
				}
				//	SqlDtr.Close ();
				/*	//******bhal*********
					string  sql="select distinct b.state r1,me.mccd r2,me.mcname r3,me.mctype r4,me.place r5,cme.customername r6,c.cust_type r7 from beat_master b,machanic_entry me, customermechanicentry cme,customer c where b.state in(select state from beat_master where city =me.place) and cme.customername in(select customername from customermechanicentry where customermechid=me.custid) and c.cust_type in(select cust_type from customer where cust_name=cme.customername)";
					SqlDataAdapter da=new SqlDataAdapter(sql,sqlcon);
					DataSet ds=new DataSet();	
					da.Fill(ds,"customermechanicentry");
					DataTable dtcustomer=ds.Tables["customermechanicentry"]; 
					DataView dv=new DataView(dtcustomer);
					dv.Sort=strorderby;
					Cache["strorderby"]=strorderby;
					DataGrid1.DataSource=dv;
					if(dv.Count!=0)
					{
						DataGrid1.DataBind();
						DataGrid1.Visible=true;
					}
					else
					{
						DataGrid1.Visible=false;
						MessageBox.Show("Data Not Available");
					}*/
				sqlcon.Dispose();
				sqlcon1.Dispose();
			}
			else
			{
				string sql="";
				string drop_value=DropPartyName.SelectedItem.Text.Trim();
				string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
				sql="Select substring(datename(month,entry_date),0,4)+' '+substring(datename(year,entry_date),3,4) entry_date,sum(Debit_Amount) Debit_Amount,sum(Credit_Amount) Credit_Amount from AccountsLedgerTable where ledger_id=(select ledger_id from ledger_master where ledger_name='"+strArr[0].ToString()+"') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2DDMMYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2DDMMYYYY(txtDateTo.Text)+"' group by datename(month,entry_date),datename(year,entry_date)";
				SqlDataAdapter da=new SqlDataAdapter(sql,sqlcon);
				DataSet ds=new DataSet();
				da.Fill(ds,"AccountsLedgerTable");
				DataTable dtcustomer=ds.Tables["AccountsLedgerTable"]; 
				DataView dv=new DataView(dtcustomer);
				dv.Sort=strOrderBy;
				Cache["strorderby"]=strOrderBy;
				Datagrid2.DataSource=dv;
				if(dv.Count!=0)
				{
					Datagrid2.DataBind();
					Datagrid2.Visible=true;
					TotalSales.Visible=false;
					Datagrid1.Visible=false;
					CustomerGrid.Visible=false;
					CustomerGrid.ShowHeader=false;
				}
				else
				{
					TotalSales.Visible=false;
					Datagrid1.Visible=false;
					Datagrid2.Visible=false;
					CustomerGrid.Visible=false;
					CustomerGrid.ShowHeader=false;
					MessageBox.Show("Data Not Available");
				}
			}
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
				CreateLogFiles.ErrorLog("Form:LedgerReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This event occurres after pressing the print button.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			/*
			 *              ============================================= 
							Customer Ledger From mm/dd/yyyy to mm/dd/yyyy
							=============================================

			+----------+----------------+----------+-----------+-----------+---------------+
			|Trans. No |Transaction Type|   Date   |   Debit   |   Credit  |Closing Balance| 
			+----------+----------------+----------+-----------+-----------+---------------+
			 1234567890 1234567890123456 mm/dd/yyyy 12345678901 12345678901 123456789012345 
			 */ 
			try
			{
				// checks for input validity.
				if(!checkValidity())
				{
					return;
				}

				// Get the home drive and opens the file CustomerLedger.txt in EPetroPrintServices folder.
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				//string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CustomerLedgerReport.txt";
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CustomerLedger.txt";
				//StreamWriter sw = new StreamWriter(path);
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
				string info = "";		
				SqlDataReader SqlDtr = null;
				if(DropReportType.SelectedIndex==0)
				{
					
					string drop_value = DropPartyName.SelectedItem.Text.Trim();  
					string party_name = "";
					string Ledger_ID = "";
					string trans_type = "";
					string trans_id = "";
					double debit = 0;
					double credit = 0;
					string bal = "";
					string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
					if(strArr.Length > 0)
					{
						party_name = strArr[0].Trim(); 
						//**}
						//	dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master lm, Ledger_Master_Sub_grp lmsg where Ledger_Name = '"+party_name+"' and lm.Sub_grp_ID = lmsg.sub_grp_id and lmsg.Sub_grp_Name = 'Sundry Debtors'",ref SqlDtr); 
						dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 

						if(SqlDtr.Read())
						{
							Ledger_ID = SqlDtr.GetValue(0).ToString();  
						}
						SqlDtr.Close();
					}
					/*
					else if(drop_value=="Sales A/C")
					{
						dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where (particulars like 'Sales Invoice (%' or particulars like 'Sales in Cash(%') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"'",ref SqlDtr); 
					}
					else if(drop_value=="Purchase A/C")
					{
						dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where particulars like 'Purchase Invoice (%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"'",ref SqlDtr); 
					}
					*/
					
					//MessageBox.Show("ready for printing");//only for testing
					//**********
					string des="--------------------------------------------------------------------------------";
					string Address=GenUtil.GetAddress();
					string[] addr=Address.Split(new char[] {':'},Address.Length);
					sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
					sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
					sw.WriteLine(des);
					//**********
					sw.WriteLine(GenUtil.GetCenterAddr("=============================================",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("Customer Ledger From "+txtDateFrom.Text+" to "+txtDateTo.Text,des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("=============================================",des.Length));
					sw.WriteLine(" Report Type :"+DropReportType.SelectedItem.Text);
					sw.WriteLine(" Party Name  : "+DropPartyName.SelectedItem.Text);
					sw.WriteLine(" Remark      : (CB) Closing Balance");
					sw.WriteLine("+------+----------------+----------+-----------+-----------+-------------------+");
					sw.WriteLine("|Trans.| Transaction    |   Date   |   Debit   |   Credit  |  Closing Balance  | ");
					sw.WriteLine("|  ID  |     Type       |          |           |           |                   |");  
					sw.WriteLine("+------+----------------+----------+-----------+-----------+-------------------+");
					//             123456 1234567890123456 mm/dd/yyyy 12345678901 12345678901 123456789012345678

					// To format the string to display into the printout.
					info = " {0,-6:S} {1,-16:S} {2,-10:S} {3,11:F} {4,11:F} {5,19:S}";
 
					//***********************
					string bt="";
					string bl="";
					string dbt="";
					string cdt="";
					//SqlDataReader SqlDtr=null;
					if(Datagrid1.Items.Count!=0)
					{
					
						dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
						if(SqlDtr.Read())
						{
							Ledger_ID = SqlDtr.GetValue(0).ToString();  
						}
						SqlDtr.Close();
						
						dbobj.SelectQuery("Select top 1 Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) < '"+ToMMddYYYY(txtDateFrom.Text)+"' order by Entry_Date desc",ref SqlDtr); 
					
						if(SqlDtr.Read())
						{
							bt=SqlDtr.GetValue(5).ToString();
							bl=SqlDtr.GetValue(4).ToString();
						}
					
						if(bt.Equals("Dr"))
						{
							dbt = GenUtil.strNumericFormat(bl);
							cdt = "0.00";
						}
						else
						{
							cdt = GenUtil.strNumericFormat(bl);
							dbt = "0.00";
						}
						sw.WriteLine(info,"","Opening Balance",GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr.GetValue(0).ToString())),dbt,cdt,bl+" "+bt);
					}
					string BalType="";
					SqlDtr.Close();
					//***********************
					//dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type  from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strOrderBy"]+"",ref SqlDtr); 
					if(TotalSales.Visible==false)
					{
						dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strOrderBy"],ref SqlDtr); 
						if(SqlDtr.HasRows)
						{
							while(SqlDtr.Read())
							{
								// if transaction type is opening balane then display the blank value in transaction ID.
								trans_type = SqlDtr["Particulars"].ToString();
								if(trans_type.StartsWith("Opening"))
								{
									trans_id = "";
								}
								else
								{
									trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
									trans_id = trans_id.Substring(0,trans_id.Length-1);
									trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
								}
								// Calculate the total debit and credit and set the last value of balance and balance type into Bal.
								debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
								credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
								bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
  
 
								sw.WriteLine(info,trans_id,
									GenUtil.TrimLength(trans_type,16),
									GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString())), 
									GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString()),
									GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString()),
									GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString()); 
							}	
						}
						else
						{
							MessageBox.Show("Data not available" );
							return;
						}
					}
					else
					{
						if(DropPartyName.SelectedItem.Text.Equals("Sales A/C"))
						{
							dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where (Particulars like 'Sales Invoice (%' or Particulars like 'Sales in Cash(%') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strorderby"],ref SqlDtr); 
							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									// if transaction type is opening balane then display the blank value in transaction ID.
									trans_type = SqlDtr["Particulars"].ToString();
									if(trans_type.StartsWith("Opening"))
									{
										trans_id = "";
									}
									else
									{
										trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
										trans_id = trans_id.Substring(0,trans_id.Length-1);
										trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
									}
									// Calculate the total debit and credit and set the last value of balance and balance type into Bal.
									//debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
									//credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
									//bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
								
									BalType=SqlDtr["Bal_Type"].ToString();
									sw.WriteLine(info,trans_id,
										GenUtil.TrimLength(trans_type,16),
										GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString())), 
										GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString()),
										GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString()),
										GenUtil.strNumericFormat(setBalance(SqlDtr["Debit_Amount"].ToString()))+" "+SqlDtr["Bal_Type"].ToString()); 
								}	
							}
						}
						else if(DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
						{
							dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where Particulars like 'Purchase Invoice (%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strorderby"],ref SqlDtr); 
							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									// if transaction type is opening balane then display the blank value in transaction ID.
									trans_type = SqlDtr["Particulars"].ToString();
									if(trans_type.StartsWith("Opening"))
									{
										trans_id = "";
									}
									else
									{
										trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
										trans_id = trans_id.Substring(0,trans_id.Length-1);
										trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
									}
									// Calculate the total debit and credit and set the last value of balance and balance type into Bal.
									debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
									credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
									bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
  
									BalType=SqlDtr["Bal_Type"].ToString();
									sw.WriteLine(info,trans_id,
										GenUtil.TrimLength(trans_type,16),
										GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString())), 
										GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString()),
										GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString()),
										GenUtil.strNumericFormat(setBalance(SqlDtr["Credit_Amount"].ToString()))+" "+SqlDtr["Bal_Type"].ToString()); 
								}	
							}
						}
					}
					SqlDtr.Close ();
					sw.WriteLine("+------+----------------+----------+-----------+-----------+-------------------+");
					if(DropPartyName.SelectedItem.Text.Equals("Sales A/C") || DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
						sw.WriteLine(info,"Total:","","","","","(CB)"+GenUtil.strNumericFormat(Balance.ToString())+" "+BalType);
					else
						sw.WriteLine(info,"Total:","","","","","(CB)"+bal);
					sw.WriteLine("+------+----------------+----------+-----------+-----------+-------------------+");
				}
				else
				{
					string des="---------------------------------------------------------------------";
					string Address=GenUtil.GetAddress();
					string[] addr=Address.Split(new char[] {':'},Address.Length);
					sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
					sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
					sw.WriteLine(des);
					//**********
					sw.WriteLine(GenUtil.GetCenterAddr("=============================================",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("Customer Ledger From "+txtDateFrom.Text+" to "+txtDateTo.Text,des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("=============================================",des.Length));
					sw.WriteLine("Report Type : "+DropReportType.SelectedItem.Text);
					sw.WriteLine("Party Name  : "+DropPartyName.SelectedItem.Text);
					sw.WriteLine("Remark      : (CB) Closing Balance");
					sw.WriteLine("+----------+----------------+-----------------+---------------------+");
					sw.WriteLine("|  Month   |  Debit Amoun t |  Credit Amount  |   Closing Balance   |");
					sw.WriteLine("+----------+----------------+-----------------+---------------------+");
					//             1234567890 1234567890123456 12345678901234567 123456789012345678901

					// To format the string to display into the printout.
					info = " {0,-10:S} {1,16:S} {2,17:S} {3,21:F}";
					string drop_value=DropPartyName.SelectedItem.Text.Trim();
					string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
					//string sql="Select substring(datename(month,entry_date),0,4)+' '+substring(datename(year,entry_date),3,4) entry_date,sum(Debit_Amount) Debit_Amount,sum(Credit_Amount) Credit_Amount from AccountsLedgerTable where ledger_id=(select ledger_id from ledger_master where ledger_name='"+strArr[0].ToString()+"') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2DDMMYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2DDMMYYYY(txtDateTo.Text)+"' group by datename(month,entry_date),datename(year,entry_date)";
					dbobj.SelectQuery("Select substring(datename(month,entry_date),0,4)+' '+substring(datename(year,entry_date),3,4) entry_date,sum(Debit_Amount) Debit_Amount,sum(Credit_Amount) Credit_Amount from AccountsLedgerTable where ledger_id=(select ledger_id from ledger_master where ledger_name='"+strArr[0].ToString()+"') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2DDMMYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2DDMMYYYY(txtDateTo.Text)+"' group by datename(month,entry_date),datename(year,entry_date)",ref SqlDtr);
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,SqlDtr["entry_date"].ToString(),
							GenUtil.strNumericFormat(GetDebit(SqlDtr["Debit_Amount"].ToString())),
							GenUtil.strNumericFormat(GetCredit(SqlDtr["Credit_Amount"].ToString())),
							setCBal(SqlDtr["Debit_Amount"].ToString(),SqlDtr["Credit_Amount"].ToString())
							);
					}
					sw.WriteLine("+----------+----------------+-----------------+---------------------+");
					sw.WriteLine(info,"Total",GenUtil.strNumericFormat(Cache["dr"].ToString()),GenUtil.strNumericFormat(Cache["cr"].ToString()),setMonth());
					sw.WriteLine("+----------+----------------+-----------------+---------------------+");
				}
				sw.Close(); 
				Print(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:BtnPrint_Click()  EXCEPTION  "+ex.Message+".  User_ID:"+ uid );  
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
			string path = home_drive+@"\ePetro_ExcelFile\LedgerReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader SqlDtr=null;
			string drop_value = DropPartyName.SelectedItem.Text.Trim();  
			string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
			if(DropReportType.SelectedIndex==0)
			{
				string party_name = "";
				string Ledger_ID = "";
				string trans_type = "";
				string trans_id = "";
				double debit = 0;
				double credit = 0;
				string bal = "";
			
				if(strArr.Length > 0)
				{
					party_name = strArr[0].Trim(); 
				}
				//	dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master lm, Ledger_Master_Sub_grp lmsg where Ledger_Name = '"+party_name+"' and lm.Sub_grp_ID = lmsg.sub_grp_id and lmsg.Sub_grp_Name = 'Sundry Debtors'",ref SqlDtr); 
				dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 

				if(SqlDtr.Read())
				{
					Ledger_ID = SqlDtr.GetValue(0).ToString();  
				}
				SqlDtr.Close();
				sw.WriteLine("From Date\t"+txtDateFrom.Text);
				sw.WriteLine("To Date\t"+txtDateTo.Text);
				sw.WriteLine("Party Name\t"+DropPartyName.SelectedItem.Text);
				sw.WriteLine("Trans. ID\tTransaction Type\tDate\tDebit\tCredit\tClosing Balance");
				string bt="";
				string bl="";
				string dbt="";
				string cdt="";
				if(Datagrid1.Items.Count!=0)
				{
					dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
					if(SqlDtr.Read())
					{
						Ledger_ID = SqlDtr.GetValue(0).ToString();  
					}
					SqlDtr.Close();
					dbobj.SelectQuery("Select top 1 Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) < '"+ToMMddYYYY(txtDateFrom.Text)+"' order by Entry_Date desc",ref SqlDtr); 
					if(SqlDtr.Read())
					{
						bt=SqlDtr.GetValue(5).ToString();
						bl=SqlDtr.GetValue(4).ToString();
					}
					if(bt.Equals("Dr"))
					{
						dbt = GenUtil.strNumericFormat(bl);
						cdt = "0.00";
					}
					else
					{
						cdt = GenUtil.strNumericFormat(bl);
						dbt = "0.00";
					}
					sw.WriteLine("\tOpening Balance\t"+GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr.GetValue(0).ToString()))+"\t"+dbt+"\t"+cdt+"\t"+bl+" "+bt);
				}
				SqlDtr.Close();
				string BalType="";
				if(TotalSales.Visible==false)
				{
					dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strOrderBy"],ref SqlDtr); 
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							// if transaction type is opening balane then display the blank value in transaction ID.
							trans_type = SqlDtr["Particulars"].ToString();
							if(trans_type.StartsWith("Opening"))
								trans_id = "";
							else
							{
								trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
								trans_id = trans_id.Substring(0,trans_id.Length-1);
								trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
							}
							// Calculate the total debit and credit and set the last value of balance and balance type into Bal.
							debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
							credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
							bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
							sw.WriteLine(trans_id+"\t"+
								trans_type+"\t"+
								GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString()))+"\t"+
								GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString())+"\t"+
								GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString())+"\t"+
								GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString()); 
						}	
					}
				}
				else
				{
					if(DropPartyName.SelectedItem.Text.Equals("Sales A/C"))
					{
						dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where (Particulars like 'Sales Invoice (%' or Particulars like 'Sales in Cash(%') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strorderby"],ref SqlDtr); 
						if(SqlDtr.HasRows)
						{
							while(SqlDtr.Read())
							{
								// if transaction type is opening balane then display the blank value in transaction ID.
								trans_type = SqlDtr["Particulars"].ToString();
								if(trans_type.StartsWith("Opening"))
								{
									trans_id = "";
								}
								else
								{
									trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
									trans_id = trans_id.Substring(0,trans_id.Length-1);
									trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
								}
								// Calculate the total debit and credit and set the last value of balance and balance type into Bal.
								//debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
								//credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
								//bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
  
								BalType=SqlDtr["Bal_Type"].ToString();
								sw.WriteLine(trans_id+"\t"+
									trans_type+"\t"+
									GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString()))+"\t"+
									GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString())+"\t"+
									GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString())+"\t"+
									GenUtil.strNumericFormat(setBalance(SqlDtr["Debit_Amount"].ToString()))+" "+SqlDtr["Bal_Type"].ToString()); 
							}	
						}
					}
					else if(DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
					{
						dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where Particulars like 'Purchase Invoice (%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strorderby"],ref SqlDtr); 
						if(SqlDtr.HasRows)
						{
							while(SqlDtr.Read())
							{
								// if transaction type is opening balane then display the blank value in transaction ID.
								trans_type = SqlDtr["Particulars"].ToString();
								if(trans_type.StartsWith("Opening"))
								{
									trans_id = "";
								}
								else
								{
									trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
									trans_id = trans_id.Substring(0,trans_id.Length-1);
									trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
								}
								// Calculate the total debit and credit and set the last value of balance and balance type into Bal.
								//debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
								//credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
								//bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
  
								BalType=SqlDtr["Bal_Type"].ToString();
								sw.WriteLine(trans_id+"\t"+
									trans_type+"\t"+
									GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString()))+"\t"+
									GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString())+"\t"+
									GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString())+"\t"+
									GenUtil.strNumericFormat(setBalance(SqlDtr["Credit_Amount"].ToString()))+" "+SqlDtr["Bal_Type"].ToString()); 
							}	
						}
					}
				}
				SqlDtr.Close ();
				if(DropPartyName.SelectedItem.Text.Equals("Sales A/C") || DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
					sw.WriteLine("Total\t\t\t\t\t"+"(CB)"+GenUtil.strNumericFormat(Balance.ToString())+" "+BalType);
				else
					sw.WriteLine("Total\t\t\t\t\t"+"(CB)"+bal);
			}
			else
			{
				sw.WriteLine("Report Type\t"+DropReportType.SelectedItem.Text);
				sw.WriteLine("Party Name\t"+DropPartyName.SelectedItem.Text);
				sw.WriteLine("Month\tDebit Amount\tCredit Amount\tClosing Balance");
				//string drop_value=DropPartyName.SelectedItem.Text.Trim();
				//string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
				//string sql="Select substring(datename(month,entry_date),0,4)+' '+substring(datename(year,entry_date),3,4) entry_date,sum(Debit_Amount) Debit_Amount,sum(Credit_Amount) Credit_Amount from AccountsLedgerTable where ledger_id=(select ledger_id from ledger_master where ledger_name='"+strArr[0].ToString()+"') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2DDMMYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2DDMMYYYY(txtDateTo.Text)+"' group by datename(month,entry_date),datename(year,entry_date)";
				dbobj.SelectQuery("Select substring(datename(month,entry_date),0,4)+' '+substring(datename(year,entry_date),3,4) entry_date,sum(Debit_Amount) Debit_Amount,sum(Credit_Amount) Credit_Amount from AccountsLedgerTable where ledger_id=(select ledger_id from ledger_master where ledger_name='"+strArr[0].ToString()+"') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2DDMMYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2DDMMYYYY(txtDateTo.Text)+"' group by datename(month,entry_date),datename(year,entry_date)",ref SqlDtr);
				while(SqlDtr.Read())
				{
					sw.WriteLine(SqlDtr["entry_date"].ToString()+"\t"+
						GenUtil.strNumericFormat(GetDebit(SqlDtr["Debit_Amount"].ToString()))+"\t"+
						GenUtil.strNumericFormat(GetCredit(SqlDtr["Credit_Amount"].ToString()))+"\t"+
						setCBal(SqlDtr["Debit_Amount"].ToString(),SqlDtr["Credit_Amount"].ToString())
						);
				}
				sw.WriteLine("Total"+"\t"+GenUtil.strNumericFormat(Cache["dr"].ToString())+"\t"+GenUtil.strNumericFormat(Cache["cr"].ToString())+"\t"+setMonth());
			}
			dbobj.Dispose();
			sw.Close();
		}

		/// <summary>
		/// This function displays returns the date from passed datetime string.
		/// </summary>
		public string trimDate(string str)
		{
			if(str.IndexOf(" ")>0)
			{
				return str = str.Substring(0,str.IndexOf(" "));  
			}

			return str;
		}

		/// <summary>
		/// contacst the Print_WiindowServices via socket and sends the CustomerLedger.txt file name to print.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CustomerLedger.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print. Report Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());

					 
					CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print  EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Datagrid1.Visible==true || CustomerGrid.Visible==true || TotalSales.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:LedgerReport.aspx,Method: btnExcel_Click, Ledger Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:LedgerReport.aspx,Method:btnExcel_Click   Ledger Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}