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
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Employee
{
	/// <summary>
	/// Summary description for Salary_Statement.
	/// </summary>
	public class Salary_Statement : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.DataGrid GridMachineReport;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DropDownList DropMonth;
		protected System.Web.UI.WebControls.Button btnprint;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		TimeSpan sp = DateTime.Now.Subtract(new DateTime(DateTime.Now.Year ,DateTime.Now.Month,1));
		protected System.Web.UI.WebControls.DropDownList DropYear;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;   
		public double Net_Salary11=0;
		public double OverTime_Hour11=0;
		public double Total_Present11=0;
		public double Leave11=0;
		string uid;
		protected System.Web.UI.WebControls.Button btnExcel;
		string strOrderBy="";

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				//Response.Write(System.Convert.ToInt32(sp.Days)+1);  
				uid=(Session["User_Name"].ToString());
				//txtYear.Text = DateTime.Now.Year.ToString();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:pageload"+ ex.Message+" EXCEPTION "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				GridMachineReport.Visible=false;
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
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
					//	string msg="UnAthourized Visit to Salary Statement Page";
					//	dbobj.LogActivity(msg,Session["User_Name"].ToString());  
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
				DropYear.SelectedIndex=DropYear.Items.IndexOf(DropYear.Items.FindByValue(System.Convert.ToString(DateTime.Now.Year)));
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
			this.GridMachineReport.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.GridMachineReport_ItemDataBound);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to View the salary statement monthly to selected employee in the dropdown list.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			try
			{
				strOrderBy = "Emp_Name ASC";
				Session["Column"] = "Emp_Name";
				Session["Order"] = "ASC";
				BindTheData();
					
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:btnShow_Click"+"Userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:btnShow_Click"+ ex.Message+" EXCEPTION "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			EmployeeClass  obj=new EmployeeClass();
			SqlDataReader SqlDtr;
			string sql;
	    		
			// Fetch the attendance record for the selected month to check wheter the record is present for the selected month or not.
			//***sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex) +"/"+DateTime.Now.Year +"' ";
			sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex) +"/"+DropYear.SelectedItem.Text+"'";
			//Response.Write(sql); 

			SqlDtr =obj.GetRecordSet(sql);
			if(SqlDtr != null)
			{
				while(SqlDtr.Read())
				{
					if(SqlDtr.GetValue(0).ToString().Equals("NULLS") || !SqlDtr.GetValue(0).ToString().Trim().Equals("") )
					{
						GridMachineReport.Visible = true;
					}
					else
					{
						GridMachineReport.Visible = false;
						MessageBox.Show("Details not available");
						return;
					}
				}
			}
			SqlDtr.Close();
			// Fetch the employee id and its salary details ad bind the data grid.
			#region Bind DataGrid
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select emp_id,emp_name, salary, ot_compensation from employee";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "employee");
			DataTable dtCustomers = ds.Tables["employee"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridMachineReport.DataSource = dv;
				GridMachineReport.DataBind();
			}
			//			sql="select emp_id,emp_name, salary, ot_compensation from employee";
			//			SqlDtr =obj.GetRecordSet(sql);
			//			if(SqlDtr.HasRows)
			//			{		
			//					
			//				GridMachineReport.DataSource=SqlDtr;
			//				GridMachineReport.DataBind();
			//			}
			//				
			//			SqlDtr.Close();
			#endregion
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
				CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is call at the binding of datagrid.
		/// </summary>
		private void GridMachineReport_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			int Total_Present=0;
			float Total_OverTime=0;
			double Monthly_Salary=0;
			double OT_Compensation=0;
			double Net_Salary=0;
			//double Advance=0;//Not Used
			
			try
			{
				EmployeeClass  obj=new EmployeeClass();
				SqlDataReader SqlDtr;
				string sql;
				int Days_in_Months=30;
				//get the data difference from time span.
				int diff = System.Convert.ToInt32(sp.Days)+1;
				// here from_date = actual "To date".
				//**string from_date = DropMonth.SelectedIndex+"/"+diff+"/"+DateTime.Now.Year;
				string from_date = DropMonth.SelectedIndex+"/"+diff+"/"+DropYear.SelectedItem.Text;	
				// if the current month is not equals to selected month then set the to date i.e(from_date) as th final date of the month.
				if(DropMonth.SelectedIndex != DateTime.Now.Month)
				{
					//**from_date = DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year;
					from_date = DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text;
				}
				
				// if the month is not current month then diff  =  30;
				if(DropMonth.SelectedIndex != DateTime.Now.Month)
				{
					diff = 30;
				}
				else
				{
					//**if(DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month) == diff)
					if(DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DateTime.Now.Month) == diff)
						diff = 30;
				}
				
				//if(!e.Item.Cells[4].Text.ToString().Equals("Total Days"))    
				//	e.Item.Cells[4].Text = diff.ToString();  
				if(!e.Item.Cells[5].Text.ToString().Equals("Total Days"))    
					e.Item.Cells[5].Text = diff.ToString();  
				//string emp_id = e.Item.Cells[0].Text.ToString();
				string emp_id = e.Item.Cells[1].Text.ToString();
				if(emp_id.Trim().Equals("Emp ID") || emp_id.Trim().Equals("&nbsp;")|| emp_id.Trim().Equals(" "))
					emp_id = "0";
					
				else
				{
					int leave = 0;
					//sql = "select sum(datepart(day,dateadd(day,1,date_to)) - datepart(day,date_from)) from leave_register where cast(floor(cast(Date_From  as float))as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(date_to as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"' and emp_id = '"+ emp_id +"'";
					//**sql = "select sum(datediff(day,date_from,dateadd(day,1,date_to))) from leave_register where cast(floor(cast(Date_From  as float))as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(date_to as float)) as datetime) <= '"+from_date+"' and emp_id = '"+ emp_id +"' and isSanction = 1";
					sql = "select sum(datediff(day,date_from,dateadd(day,1,date_to))) from leave_register where cast(floor(cast(Date_From  as float))as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(date_to as float)) as datetime) <= '"+from_date+"' and emp_id = '"+ emp_id +"' and isSanction = 1";
					//if(emp_id.Equals("1002")) 
					//	Response.Write(sql+"<br><br>");
					SqlDtr =obj.GetRecordSet(sql);
					if(SqlDtr.HasRows )
					{
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Trim().Equals(""))
								leave = System.Convert.ToInt32(SqlDtr.GetValue(0).ToString()) ;
						}
					}
					SqlDtr.Close();

					//sql = "select sum(datediff(day,date_from,dateadd(day,1,'"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"'))) from leave_register where cast(floor(cast(date_from as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"' and cast(floor(cast(date_to as float)) as datetime) > '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"'and emp_id = '"+ emp_id +"'";
					sql = "select sum(datediff(day,date_from,dateadd(day,1,'"+from_date +"'))) from leave_register where cast(floor(cast(date_from as float)) as datetime) <= '"+from_date +"' and cast(floor(cast(date_to as float)) as datetime) > '"+from_date+"'and emp_id = '"+ emp_id +"' and isSanction = 1 and datepart(month,date_from) = datepart(month,'"+from_date +"')";
					//if(emp_id.Equals("1002")) 
					//Response.Write(sql+"<br><br>");

					SqlDtr =obj.GetRecordSet(sql);
					if(SqlDtr.HasRows  )
					{
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Trim().Equals(""))
								leave += System.Convert.ToInt32(SqlDtr.GetValue(0).ToString()) ;
						}
					}
					SqlDtr.Close();

					//date_to
					//**sql = "select case when cast(floor(cast(date_to as float)) as datetime) >= '"+from_date +"' then sum(datediff(day,'"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"',dateadd(day,1,'"+from_date +"'))) else sum(datediff(day,'"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"',dateadd(day,1,date_to))) end from leave_register where cast(floor(cast(date_from as float)) as datetime) < '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(date_to as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"'and emp_id = '"+ emp_id +"' and isSanction = 1 group by date_to";
					sql = "select case when cast(floor(cast(date_to as float)) as datetime) >= '"+from_date +"' then sum(datediff(day,'"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"',dateadd(day,1,'"+from_date +"'))) else sum(datediff(day,'"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"',dateadd(day,1,date_to))) end from leave_register where cast(floor(cast(date_from as float)) as datetime) < '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(date_to as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"'and emp_id = '"+ emp_id +"' and isSanction = 1 group by date_to";
					//if(emp_id.Equals("1002")) 
					//	Response.Write(sql+"<br><br>");


					SqlDtr =obj.GetRecordSet(sql);
					if(SqlDtr.HasRows )
					{
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Trim().Equals(""))
								leave += System.Convert.ToInt32(SqlDtr.GetValue(0).ToString()) ;
						}
					}
					SqlDtr.Close();

					//if(!e.Item.Cells[5].Text.ToString().Equals("Leave"))    
					if(!e.Item.Cells[6].Text.ToString().Equals("Leave"))    
					{
						//e.Item.Cells[5].Text = leave.ToString();  
						e.Item.Cells[6].Text = leave.ToString();  
						Leave11+=double.Parse(leave.ToString());
						Cache["Leave11"]=Leave11;
					}

					#region Bind Total Present Regarding Each Item				
					//**sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"' and emp_id='"+ emp_id +"'";
					sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text+"' and emp_id='"+ emp_id +"'";
					SqlDtr =obj.GetRecordSet(sql);
					if(SqlDtr.HasRows )
					{
						while(SqlDtr.Read())
						{
							//if(!e.Item.Cells[6].Text.ToString().Equals("Total Present"))
							if(!e.Item.Cells[7].Text.ToString().Equals("Total Present"))
							{
								if(!SqlDtr.GetValue(0).ToString().Equals("NULL") ||!SqlDtr.GetValue(0).ToString().Equals("")|| SqlDtr.GetValue(0).ToString() != null)
								{
									//e.Item.Cells[6].Text=SqlDtr.GetValue(0).ToString() ;
									e.Item.Cells[7].Text=SqlDtr.GetValue(0).ToString() ;
									Total_Present11+=double.Parse(SqlDtr.GetValue(0).ToString());
									Cache["Total_Present11"]=Total_Present11;
								}
							}
						}
					}
					SqlDtr.Close();
					#endregion
					#region Bind Total OverTime Hours Regarding Each Item
					//**string	Sql1 ="select sum(datepart(hour,Ot_To)-datepart(hour,Ot_From)) OT_Hour,sum(datepart(minute,Ot_To)-datepart(minute,Ot_From)) OT_Minute from OverTime_Register where cast(floor(cast(OT_Date as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(OT_Date as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"' and emp_id='"+ emp_id+"'";
					string	Sql1 ="select sum(datepart(hour,Ot_To)-datepart(hour,Ot_From)) OT_Hour,sum(datepart(minute,Ot_To)-datepart(minute,Ot_From)) OT_Minute from OverTime_Register where cast(floor(cast(OT_Date as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(OT_Date as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text+"' and emp_id='"+ emp_id+"'";
					//Response.Write(Sql1+"<br>"); 
					float hr=0;
					float mn1=0;
					SqlDtr = obj.GetRecordSet(Sql1);
					if(SqlDtr != null)
					{
						if(SqlDtr.HasRows)
						{
							if (SqlDtr.Read())
							{
								string	strh11=SqlDtr.GetValue(0).ToString();
								if(strh11==null||strh11.Equals(""))
								{
									strh11="0";
								}
								string	strm11=SqlDtr.GetValue(1).ToString();
								if(strm11==null || strm11.Equals(""))
								{
									strm11="0";
								}
								// Response.Write(strh11+"<br>" );
								//Response.Write(strm11+"<br>" );
								hr= float.Parse(strm11) / 60  +  float.Parse(strh11);
								//Response.Write(hr+"<br>" );
								mn1=float.Parse(strm11)% 60;
								//Response.Write(mn1+"<br>" );
								double hr1=System.Math.Floor(System.Convert.ToDouble(hr));
								//Response.Write(hr1+"<br>" );
								//string st="24";
								Total_OverTime=float.Parse(hr1.ToString());
								if(Total_OverTime<0)
								{
									//Total_OverTime=Total_OverTime+float.Parse(st);
									Total_OverTime=Math.Abs(Total_OverTime);
								}
								string	hr2=Total_OverTime.ToString()+"."+mn1.ToString() ;
								OverTime_Hour11 += double.Parse(hr2);
								Cache["OverTime_Hour11"]=OverTime_Hour11;
								//Response.Write(Total_OverTime+"<br>" );
								//if(!e.Item.Cells[7].Text.ToString().Equals("Overtime<br>Hours"))
								if(!e.Item.Cells[8].Text.ToString().Equals("Overtime<br>Hours"))
								{
									//e.Item.Cells[7].Text=GenUtil.strNumericFormat(hr2);
									e.Item.Cells[8].Text=GenUtil.strNumericFormat(hr2);
								}
							}
						}
					}
					SqlDtr.Close();
					#endregion
					#region Calculate Net Salary
				
					//Monthly_Salary=System.Convert.ToDouble(e.Item.Cells[2].Text.ToString());
					//OT_Compensation=System.Convert.ToDouble(e.Item.Cells[3].Text.ToString());
					Monthly_Salary=System.Convert.ToDouble(e.Item.Cells[3].Text.ToString());
					OT_Compensation=System.Convert.ToDouble(e.Item.Cells[4].Text.ToString());
					//if(e.Item.Cells[6].Text.Equals(""))
					if(e.Item.Cells[7].Text.Equals(""))
					{
						//e.Item.Cells[6].Text="0";
						e.Item.Cells[7].Text="0";
					}
					//if(e.Item.Cells[7].Text.Equals(""))
					if(e.Item.Cells[8].Text.Equals(""))
					{
						//e.Item.Cells[7].Text="0";
						e.Item.Cells[8].Text="0";
					}
					//Total_Present=System.Convert.ToInt32(e.Item.Cells[6].Text.ToString());
					Total_Present=System.Convert.ToInt32(e.Item.Cells[7].Text.ToString());
					Net_Salary=(Total_Present * Monthly_Salary / Days_in_Months);
					//Response.Write(Net_Salary+"&nbsp;&nbsp;"); 
					Net_Salary=Net_Salary + OT_Compensation * Total_OverTime;
					float min = 0.0f;
					if(mn1 != 0)
					{
						if(mn1 == 15)
							min = 0.25f;
						if(mn1 == 30)
							min = 0.50f;
						if(mn1 == 45)
							min = 0.75f;
					}
					Net_Salary=Net_Salary + (OT_Compensation * min);
					Net_Salary11+=double.Parse(GenUtil.strNumericFormat(Net_Salary.ToString()));	
					Cache["Net_Salary11"]=Net_Salary11;
					//Response.Write(Net_Salary+"<br>"); 
					//e.Item.Cells[8].Text = GenUtil.strNumericFormat(Net_Salary.ToString());
					e.Item.Cells[9].Text = GenUtil.strNumericFormat(Net_Salary.ToString());
					
				}
				#endregion
				//****************
				#region Bind Total Advance Regarding Each Employee
				//**sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"' and emp_id='"+ emp_id +"'";
				string Ledger_ID="",str11="",str12="",str="";//,BalType="";//Not Used
				SqlDtr = null;
				//dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name ='"+e.Item.Cells[1].Text.ToString()+"'",ref SqlDtr);
				dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name ='"+e.Item.Cells[2].Text.ToString()+"'",ref SqlDtr);
				if(SqlDtr.Read())
				{
					Ledger_ID = SqlDtr["Ledger_ID"].ToString(); 
				}
				SqlDtr.Close();
				if(Ledger_ID!="")
				{
					sql="select sum(cast(Debit_Amount as float)) advance from AccountsLedgerTable where cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text+"' and particulars like ('Payment%') and Ledger_ID="+Ledger_ID;
					SqlDtr =obj.GetRecordSet(sql);
					if(SqlDtr.HasRows )
					{
						while(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("NULL") ||!SqlDtr.GetValue(0).ToString().Equals("")|| SqlDtr.GetValue(0).ToString() != null)
							{
								str11=SqlDtr.GetValue(0).ToString();
							}
						}
					}
					SqlDtr.Close();
					sql="select Debit_Amount from AccountsLedgerTable where particulars like ('Opening%') and Ledger_ID="+Ledger_ID+" and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text+"'";
					SqlDtr =obj.GetRecordSet(sql);
					if(SqlDtr.HasRows )
					{
						while(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("NULL") ||!SqlDtr.GetValue(0).ToString().Equals("")|| SqlDtr.GetValue(0).ToString() != null)
							{
								str12=SqlDtr.GetValue(0).ToString();
							}
						}
					}
				}
				SqlDtr.Close();
				if(str12 != "" && str11 != "")
					str=System.Convert.ToString(System.Convert.ToDouble(str11)+System.Convert.ToDouble(str12));
				else
				{
					if(str11 !="")
						str=str11;
					else
						str=str12;
				}
				//e.Item.Cells[9].Text=str;
				e.Item.Cells[10].Text=str;
				#endregion
				//*************
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:GridMachineReport_ItemDataBound  Exception "+ex.Message+" userid is   "+uid);
			}
		}

		/// <summary>
		/// Method to write into the report file to print witht the help of GetData() function.
		/// </summary>
		private void btnprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:btnprint_Click   "+ uid);
				GetData();
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:btnprint_Click   "+ ex.Message+" EXCEPTION "+uid);
			}
		}

		/// <summary>
		/// This method writes a line to a report file.
		/// </summary>
		public void Write2File1(StreamWriter sw, string info)
		{
			sw.WriteLine(info);			
		}
		
		/// <summary>
		/// This function to create a text file for printing.
		/// Prepares the report file for printting.
		/// </summary>
		public void GetData()
		{   
			/*
			Salary Report As On July 2006

+----+-------------------------+--------+-----+-----+-----+-----+-----+--------+
|Emp.|          Name           |Monthly | OT  |Total|Leave|Total| OT  |  Net   |
|ID  |                         |Salary  |Comp.|Days |     |Pres.| Hrs | Salary |
+----+-------------------------+--------+-----+-----+-----+-----+-----+--------+
 1234 1234567890123456789012345 12345678 12345 12345 12345 12345 12345 12345678			 
			 */
			string sql="";
			
			int Total_Present;
			float Total_OverTime;
			double Monthly_Salary;
			double OT_Compensation;			
			double Net_Salary;
			double grandTotal=0;

			string str1, str2, str3, str4, str5, str6, str7,str8="", info,info1;
			str6 = "";
			SqlDataReader SqlDtr, SqlDtrOP, SqlDtrOT,SqlDtr1;
			int Days_in_Months=30;

			
			EmployeeClass  obj=new EmployeeClass();
			EmployeeClass  obj2=new EmployeeClass();
			EmployeeClass  obj3=new EmployeeClass();
			EmployeeClass  obj4=new EmployeeClass();
			EmployeeClass  obj5=new EmployeeClass();
			EmployeeClass  obj6=new EmployeeClass();
			EmployeeClass  obj7=new EmployeeClass();
			try
			{
				sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex) +"/"+DropYear.SelectedItem.Text +"' ";
				//Response.Write(sql); 

				SqlDtr =obj.GetRecordSet(sql);
				if(SqlDtr != null)
				{
					while(SqlDtr.Read())
					{
						
						if(SqlDtr.GetValue(0).ToString().Equals("NULLS") || !SqlDtr.GetValue(0).ToString().Trim().Equals("") )
						{
							//GridMachineReport.Visible = true;
						}
						else
						{
							//GridMachineReport.Visible = false;
							MessageBox.Show("Details not available");
							return;
						}
					}
				}
				SqlDtr.Close();

				int diff = System.Convert.ToInt32(sp.Days)+1;
				string from_date = DropMonth.SelectedIndex+"/"+diff+"/"+DropYear.SelectedItem.Text;
				if(DropMonth.SelectedIndex != DateTime.Now.Month)
				{
					from_date = DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text;
				}
				if(DropMonth.SelectedIndex != DateTime.Now.Month)
				{
					diff = 30;
				}
				else
				{
					if(DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DateTime.Now.Month) == diff)
						diff = 30;
				}
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SalaryReport.txt";
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
				string des="------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				//string title = "Salary Report As On " + DropMonth.SelectedItem.Text + " " + DropYear.SelectedItem.Text;
				sw.WriteLine(GenUtil.GetCenterAddr("====================================",des.Length));
				//Write2File1(sw,title);
				sw.WriteLine(GenUtil.GetCenterAddr("Salary Report As On " + DropMonth.SelectedItem.Text + " " + DropYear.SelectedItem.Text,des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("====================================",des.Length));
				Write2File1(sw,"");
				
				Write2File1(sw,"+----+------+-------------------------+--------+-----+-----+-----+-----+-----+--------+-------+");
				Write2File1(sw,"|S.No| Emp. |          Name           |Monthly | OT  |Total|Leave|Total| OT  |  Net   |Advance|");
				Write2File1(sw,"|    | ID   |                         |Salary  |Comp.|Days |     |Pres.| Hrs | Salary |       |");
				Write2File1(sw,"+----+------+-------------------------+--------+-----+-----+-----+-----+-----+--------+-------+");
				//1234 123456 1234567890123456789012345 12345678 12345  23    23    23   12345 12345678 1234567			 
				info = " {0,-4:D} {1,6:D} {2,-25:S} {3,8:F} {4,5:F}  {5,2:F}    {6,2:F}    {7,2:F}   {8,5:F} {9,8:F} {10,7:F}";
				info1 = " {0,-4:D} {1,6:D} {2,-25:S} {3,8:F} {4,5:F}  {5,2:F}    {6,2:F}   {7,2:F}   {8,5:F} {9,8:F} {10,7:F}";
				sql="select emp_id,emp_name, salary, ot_compensation from employee order by "+Cache["strOrderBy"].ToString()+"";
				SqlDtr = obj.GetRecordSet(sql);
				string strQueryOT  ="";
				string strQueryOP = "";
				double hr1=0;
				string strh="";
				int sno=0;
				while(SqlDtr.Read())                
				{
					//info = "";
					str1 = SqlDtr.GetValue(0).ToString ();
					str2 = SqlDtr.GetValue(1).ToString ();
					str3 = SqlDtr.GetValue(2).ToString ();
					str4 = SqlDtr.GetValue(3).ToString ();
					int leave = 0;
					
					sql = "select sum(datepart(day,dateadd(day,1,date_to)) - datepart(day,date_from)) from leave_register where cast(floor(cast(Date_From  as float))as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"' and cast(floor(cast(date_to as float)) as datetime) <= '"+from_date+"' and emp_id = '"+ str1  +"' and isSanction = 1";
							
					SqlDtr1 =obj4.GetRecordSet(sql);
					if(SqlDtr1.HasRows )
					{
						if(SqlDtr1.Read())
						{
							if(!SqlDtr1.GetValue(0).ToString().Trim().Equals(""))
								leave = System.Convert.ToInt32(SqlDtr1.GetValue(0).ToString()) ;
						}
					}
					SqlDtr1.Close();

					sql = "select sum(datediff(day,date_from,dateadd(day,1,'"+from_date +"'))) from leave_register where cast(floor(cast(date_from as float)) as datetime) <= '"+from_date +"' and cast(floor(cast(date_to as float)) as datetime) > '"+from_date+"'and emp_id = '"+ str1 +"' and isSanction = 1";
					SqlDtr1 =obj5.GetRecordSet(sql);
					if(SqlDtr1.HasRows  )
					{
						if(SqlDtr1.Read())
						{
							if(!SqlDtr1.GetValue(0).ToString().Trim().Equals(""))
								leave += System.Convert.ToInt32(SqlDtr1.GetValue(0).ToString()) ;
						}
					}
					SqlDtr1.Close();

					sql = "select sum(datediff(day,'"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"',dateadd(day,1,date_to))) from leave_register where cast(floor(cast(date_from as float)) as datetime) < '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"' and cast(floor(cast(date_to as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"'and emp_id = '"+ str1 +"' and isSanction = 1";
					
					SqlDtr1 =obj6.GetRecordSet(sql);
					if(SqlDtr1.HasRows )
					{
						if(SqlDtr1.Read())
						{
							if(!SqlDtr1.GetValue(0).ToString().Trim().Equals(""))
								leave += System.Convert.ToInt32(SqlDtr1.GetValue(0).ToString()) ;
						}
					}
					SqlDtr1.Close();
					strQueryOP="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text +"' and emp_id="+ str1;
					SqlDtrOP = obj2.GetRecordSet(strQueryOP);	
					if (SqlDtrOP.Read())
					{
						str5 = SqlDtrOP.GetValue(0).ToString ();
					}
					else
					{
						str5 = "0";
					}
					SqlDtrOP.Close();
					strQueryOT = "select sum(datepart(hour,Ot_To)-datepart(hour,Ot_From)) OT_Hour,sum(datepart(minute,Ot_To)-datepart(minute,Ot_From)) OT_Minute from OverTime_Register where cast(floor(cast(OT_Date as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"' and cast(floor(cast(OT_Date as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text +"' and emp_id=" + str1;
					SqlDtrOT = obj3.GetRecordSet(strQueryOT);	
					string	hr2="";
					string strm="";
					float hr = 0.0f;
					float mn1 = 0.0f;
					if (SqlDtrOT.Read())
					{
						strh=SqlDtrOT.GetValue(0).ToString();
						if(strh==null||strh.Equals(""))
						{
							strh="0";
						}
						strm=SqlDtrOT.GetValue(1).ToString();
						if(strm==null || strm.Equals(""))
						{
							strm="0";
						}
						// Calculate Total Present Hours
						hr= float.Parse(strm) / 60  +  float.Parse(strh);
						//Calculate total minutes
						mn1=float.Parse(strm)% 60;
						hr1=System.Math.Floor(System.Convert.ToDouble(hr));
						hr2=hr1.ToString()+"."+mn1.ToString() ;
						//str6 =hr2;
					}
					else
					{
						str6 = "0";
					}
					if (str5.Equals(""))
					{
						str5 = "0";
					}
					if (str6.Equals(""))
					{
						str6 = "0";
					}
					//****************
					
					#region Bind Total Advance Regarding Each Employee
					//**sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"' and emp_id='"+ emp_id +"'";
					string Ledger_ID="",str11="",str12="",str="";//,BalType="";//Not Used
					SqlDtr1 = null;
					dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name ='"+str2+"'	",ref SqlDtr1);
					if(SqlDtr1.Read())
					{
						Ledger_ID = SqlDtr1["Ledger_ID"].ToString(); 
					}
					SqlDtr1.Close();
					if(Ledger_ID!="")
					{
						sql="select sum(cast(Debit_Amount as float)) advance from AccountsLedgerTable where cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text+"' and particulars like ('Payment%') and Ledger_ID="+Ledger_ID+"";
						SqlDtr1 =obj7.GetRecordSet(sql);
						if(SqlDtr1.HasRows )
						{
							while(SqlDtr1.Read())
							{
								if(!SqlDtr1.GetValue(0).ToString().Equals("NULL") ||!SqlDtr1.GetValue(0).ToString().Equals("")|| SqlDtr1.GetValue(0).ToString() != null)
								{
									str11=SqlDtr1.GetValue(0).ToString();
								}
							}
						}
						SqlDtr1.Close();
						sql="select Debit_Amount from AccountsLedgerTable where particulars like ('Opening%') and Ledger_ID="+Ledger_ID+" and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text+"'";
						SqlDtr1 =obj7.GetRecordSet(sql);
						if(SqlDtr1.HasRows )
						{
							while(SqlDtr1.Read())
							{
								if(!SqlDtr1.GetValue(0).ToString().Equals("NULL") ||!SqlDtr1.GetValue(0).ToString().Equals("")|| SqlDtr1.GetValue(0).ToString() != null)
								{
									str12=SqlDtr1.GetValue(0).ToString();
								}
							}
						}
					}
					SqlDtr1.Close();
					if(str12 != "" && str11 != "")
						str=System.Convert.ToString(System.Convert.ToDouble(str11)+System.Convert.ToDouble(str12));
					else
					{
						if(str11 !="")
							str=str11;
						else
							str=str12;
					}
					str8=str;
					#endregion
					//*************
					Monthly_Salary=System.Convert.ToDouble(str3);
					//string st = "24" ;
					Total_Present=System.Convert.ToInt32(str5);
					Total_OverTime=float.Parse(hr1.ToString()) ;
					if(Total_OverTime<0)
					{
						//Total_OverTime=Total_OverTime+float.Parse(st);
						Total_OverTime=Math.Abs(Total_OverTime);
					}
					str6 = Total_OverTime.ToString()+"."+mn1.ToString();
					OT_Compensation=System.Convert.ToDouble(str4);
					// Calculate Net Salary.
					Net_Salary=(Total_Present * Monthly_Salary / Days_in_Months);
					Net_Salary=Net_Salary + OT_Compensation * Total_OverTime;
					float min = 0.0f;
					if(mn1 != 0)
					{
						if(mn1 == 15)
							min = 0.25f;
						if(mn1 == 30)
							min = 0.50f;
						if(mn1 == 45)
							min = 0.75f;
					}
					Net_Salary=Net_Salary + (OT_Compensation * min);
					Net_Salary=System.Math.Round(Net_Salary,2);
					grandTotal = grandTotal + Net_Salary;
					str7=System.Convert.ToString(Net_Salary);
					SqlDtrOT.Close();
					sno++;
					sw.WriteLine(info,sno.ToString(),str1,str2,GenUtil.strNumericFormat(str3),str4,diff.ToString(),leave.ToString() ,str5,GenUtil.strNumericFormat(str6),GenUtil.strNumericFormat(str7),str8);
				}

				Write2File1(sw,"+----+------+-------------------------+--------+-----+-----+-----+-----+-----+--------+-------+");
				//sw.WriteLine("                                                                 Total:{0,8:F}",GenUtil.strNumericFormat(grandTotal.ToString()));
				sw.WriteLine(info1,"","Total","","","","",Cache["Leave11"].ToString(),Cache["Total_Present11"].ToString(),Cache["OverTime_Hour11"],GenUtil.strNumericFormat(grandTotal.ToString()),"");
				Write2File1(sw,"+----+------+-------------------------+--------+-----+-----+-----+-----+-----+--------+-------+");
				sw.Close();
				SqlDtr.Close();		
			}
			catch(Exception ex)
			{		
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:GetData "+ ex.Message+" EXCEPTION "+uid);
			}
		}

		/// <summary>
		/// Sends the text file to print server to print.
		/// </summary>
		public void Print()
		{
			byte[] bytes = new byte[1024];
			try 
			{
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,60000);

				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:print  "+uid);
				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);

					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\SalaryReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:Print  "+ ane.Message+" EXCEPTION "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:Print  "+ se.Message+" EXCEPTION "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:Print  "+ es.Message+" EXCEPTION "+uid);
				}
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:Salary_statement.aspx,Method:print "+  ex.Message+" EXCEPTION  "+uid);
			}
		}
		
		int sno=0;
		/// <summary>
		/// This method is used to return the no in incresing order.
		/// </summary>
		public string GetSNo()
		{
			sno++;
			return sno.ToString();
		}

		/// <summary>
		/// This method is used to prepares the excel report file SalaryStatement.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridMachineReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:TankReport.aspx,Method: btnExcel_Click, Tank Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:Salary_Statement.aspx,Method:btnExcel_Click   Salary Statement Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}

		/// <summary>
		/// Method to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			string sql="";
			int Total_Present;
			float Total_OverTime;
			double Monthly_Salary;
			double OT_Compensation;			
			double Net_Salary;
			double grandTotal=0;
			string str1, str2, str3, str4, str5, str6, str7,str8="";
			str6 = "";
			SqlDataReader SqlDtr, SqlDtrOP, SqlDtrOT,SqlDtr1;
			int Days_in_Months=30;
			
			EmployeeClass  obj=new EmployeeClass();
			EmployeeClass  obj2=new EmployeeClass();
			EmployeeClass  obj3=new EmployeeClass();
			EmployeeClass  obj4=new EmployeeClass();
			EmployeeClass  obj5=new EmployeeClass();
			EmployeeClass  obj6=new EmployeeClass();
			EmployeeClass  obj7=new EmployeeClass();

			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\SalaryStatement.xls";
			StreamWriter sw = new StreamWriter(path);

			sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex) +"/"+DropYear.SelectedItem.Text +"' ";
			SqlDtr =obj.GetRecordSet(sql);
			if(SqlDtr != null)
			{
				while(SqlDtr.Read())
				{
					if(SqlDtr.GetValue(0).ToString().Equals("NULLS") || !SqlDtr.GetValue(0).ToString().Trim().Equals("") )
					{
					}
					else
					{
						MessageBox.Show("Details not available");
						return;
					}
				}
			}
			SqlDtr.Close();

			int diff = System.Convert.ToInt32(sp.Days)+1;
			string from_date = DropMonth.SelectedIndex+"/"+diff+"/"+DropYear.SelectedItem.Text;
			if(DropMonth.SelectedIndex != DateTime.Now.Month)
				from_date = DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text;
			if(DropMonth.SelectedIndex != DateTime.Now.Month)
				diff = 30;
			else
			{
				if(DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DateTime.Now.Month) == diff)
					diff = 30;
			}
			
			sw.WriteLine("                 Salary Report As On " + DropMonth.SelectedItem.Text + " " + DropYear.SelectedItem.Text);
			sw.WriteLine("Month\t"+DropMonth.SelectedItem.Text+"\tYear\t"+DropYear.SelectedItem.Text);
			sw.WriteLine("S.No\tEmployee ID\tName\tMonthly Salary\tOT Comp.\tTotal Days\tLeave\tTotal Pres.\tOT Hrs.\tNet Salary\tAdvance");
			sql="select emp_id,emp_name, salary, ot_compensation from employee order by "+Cache["strOrderBy"].ToString()+"";
			SqlDtr = obj.GetRecordSet(sql);
			string strQueryOT  ="";
			string strQueryOP = "";
			double hr1=0;
			string strh="";
			int sno=0;
			while(SqlDtr.Read())                
			{
				str1 = SqlDtr.GetValue(0).ToString ();
				str2 = SqlDtr.GetValue(1).ToString ();
				str3 = SqlDtr.GetValue(2).ToString ();
				str4 = SqlDtr.GetValue(3).ToString ();
				int leave = 0;
				sql = "select sum(datepart(day,dateadd(day,1,date_to)) - datepart(day,date_from)) from leave_register where cast(floor(cast(Date_From  as float))as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"' and cast(floor(cast(date_to as float)) as datetime) <= '"+from_date+"' and emp_id = '"+ str1  +"' and isSanction = 1";
				SqlDtr1 =obj4.GetRecordSet(sql);
				if(SqlDtr1.HasRows )
				{
					if(SqlDtr1.Read())
					{
						if(!SqlDtr1.GetValue(0).ToString().Trim().Equals(""))
							leave = System.Convert.ToInt32(SqlDtr1.GetValue(0).ToString()) ;
					}
				}
				SqlDtr1.Close();
				sql = "select sum(datediff(day,date_from,dateadd(day,1,'"+from_date +"'))) from leave_register where cast(floor(cast(date_from as float)) as datetime) <= '"+from_date +"' and cast(floor(cast(date_to as float)) as datetime) > '"+from_date+"'and emp_id = '"+ str1 +"' and isSanction = 1";
				SqlDtr1 =obj5.GetRecordSet(sql);
				if(SqlDtr1.HasRows  )
				{
					if(SqlDtr1.Read())
					{
						if(!SqlDtr1.GetValue(0).ToString().Trim().Equals(""))
							leave += System.Convert.ToInt32(SqlDtr1.GetValue(0).ToString()) ;
					}
				}
				SqlDtr1.Close();
				sql = "select sum(datediff(day,'"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"',dateadd(day,1,date_to))) from leave_register where cast(floor(cast(date_from as float)) as datetime) < '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"' and cast(floor(cast(date_to as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"'and emp_id = '"+ str1 +"' and isSanction = 1";
				SqlDtr1 =obj6.GetRecordSet(sql);
				if(SqlDtr1.HasRows )
				{
					if(SqlDtr1.Read())
					{
						if(!SqlDtr1.GetValue(0).ToString().Trim().Equals(""))
							leave += System.Convert.ToInt32(SqlDtr1.GetValue(0).ToString()) ;
					}
				}
				SqlDtr1.Close();
				strQueryOP="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text +"' and emp_id="+ str1;
				SqlDtrOP = obj2.GetRecordSet(strQueryOP);	
				if (SqlDtrOP.Read())
					str5 = SqlDtrOP.GetValue(0).ToString ();
				else
					str5 = "0";
				SqlDtrOP.Close();
				strQueryOT = "select sum(datepart(hour,Ot_To)-datepart(hour,Ot_From)) OT_Hour,sum(datepart(minute,Ot_To)-datepart(minute,Ot_From)) OT_Minute from OverTime_Register where cast(floor(cast(OT_Date as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text +"' and cast(floor(cast(OT_Date as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text +"' and emp_id=" + str1;
				SqlDtrOT = obj3.GetRecordSet(strQueryOT);	
				string	hr2="";
				string strm="";
				float hr = 0.0f;
				float mn1 = 0.0f;
				if (SqlDtrOT.Read())
				{
					strh=SqlDtrOT.GetValue(0).ToString();
					if(strh==null||strh.Equals(""))
					{
						strh="0";
					}
					strm=SqlDtrOT.GetValue(1).ToString();
					if(strm==null || strm.Equals(""))
					{
						strm="0";
					}
					// Calculate Total Present Hours
					hr= float.Parse(strm) / 60  +  float.Parse(strh);
					//Calculate total minutes
					mn1=float.Parse(strm)% 60;
					hr1=System.Math.Floor(System.Convert.ToDouble(hr));
					hr2=hr1.ToString()+"."+mn1.ToString() ;
					//str6 =hr2;
				}
				else
					str6 = "0";
				if (str5.Equals(""))
					str5 = "0";
				if (str6.Equals(""))
					str6 = "0";
				//****************
					
				#region Bind Total Advance Regarding Each Employee
				//**sql="select sum(cast(status as integer)) Total_Present from attandance_register where cast(floor(cast(cast(att_date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DateTime.Now.Year +"' and cast(floor(cast(cast(att_date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(DateTime.Now.Year,DropMonth.SelectedIndex)+"/"+DateTime.Now.Year +"' and emp_id='"+ emp_id +"'";
				string Ledger_ID="",str11="",str12="",str="";//,BalType="";//Not Used
				SqlDtr1 = null;
				dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Ledger_Name ='"+str2+"'	",ref SqlDtr1);
				if(SqlDtr1.Read())
				{
					Ledger_ID = SqlDtr1["Ledger_ID"].ToString(); 
				}
				SqlDtr1.Close();
				if(Ledger_ID!="")
				{
					sql="select sum(cast(Debit_Amount as float)) advance from AccountsLedgerTable where cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text+"' and particulars like ('Payment%') and Ledger_ID="+Ledger_ID+"";
					SqlDtr1 =obj7.GetRecordSet(sql);
					if(SqlDtr1.HasRows )
					{
						while(SqlDtr1.Read())
						{
							if(!SqlDtr1.GetValue(0).ToString().Equals("NULL") ||!SqlDtr1.GetValue(0).ToString().Equals("")|| SqlDtr1.GetValue(0).ToString() != null)
							{
								str11=SqlDtr1.GetValue(0).ToString();
							}
						}
					}
					SqlDtr1.Close();
					sql="select Debit_Amount from AccountsLedgerTable where particulars like ('Opening%') and Ledger_ID="+Ledger_ID+" and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) >= '"+DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text+"' and cast(floor(cast(cast(Entry_Date as datetime) as float)) as datetime) <= '"+DropMonth.SelectedIndex+"/"+DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),DropMonth.SelectedIndex)+"/"+DropYear.SelectedItem.Text+"'";
					SqlDtr1 =obj7.GetRecordSet(sql);
					if(SqlDtr1.HasRows )
					{
						while(SqlDtr1.Read())
						{
							if(!SqlDtr1.GetValue(0).ToString().Equals("NULL") ||!SqlDtr1.GetValue(0).ToString().Equals("")|| SqlDtr1.GetValue(0).ToString() != null)
							{
								str12=SqlDtr1.GetValue(0).ToString();
							}
						}
					}
				}
				SqlDtr1.Close();
				if(str12 != "" && str11 != "")
					str=System.Convert.ToString(System.Convert.ToDouble(str11)+System.Convert.ToDouble(str12));
				else
				{
					if(str11 !="")
						str=str11;
					else
						str=str12;
				}
				str8=str;
				#endregion
				//*************
				Monthly_Salary=System.Convert.ToDouble(str3);
				//string st = "24" ;
				Total_Present=System.Convert.ToInt32(str5);
				Total_OverTime=float.Parse(hr1.ToString()) ;
				if(Total_OverTime<0)
				{
					//Total_OverTime=Total_OverTime+float.Parse(st);
					Total_OverTime=Math.Abs(Total_OverTime);
				}
				str6 = Total_OverTime.ToString()+"."+mn1.ToString();
				OT_Compensation=System.Convert.ToDouble(str4);
				// Calculate Net Salary.
				Net_Salary=(Total_Present * Monthly_Salary / Days_in_Months);
				Net_Salary=Net_Salary + OT_Compensation * Total_OverTime;
				float min = 0.0f;
				if(mn1 != 0)
				{
					if(mn1 == 15)
						min = 0.25f;
					if(mn1 == 30)
						min = 0.50f;
					if(mn1 == 45)
						min = 0.75f;
				}
				Net_Salary=Net_Salary + (OT_Compensation * min);
				Net_Salary=System.Math.Round(Net_Salary,2);
				grandTotal = grandTotal + Net_Salary;
				str7=System.Convert.ToString(Net_Salary);
				SqlDtrOT.Close();
				sno++;
				sw.WriteLine(sno.ToString()+"\t"+str1+"\t"+str2+"\t"+GenUtil.strNumericFormat(str3)+"\t"+str4+"\t"+diff.ToString()+"\t"+leave.ToString()+"\t"+str5+"\t"+GenUtil.strNumericFormat(str6)+"\t"+GenUtil.strNumericFormat(str7)+"\t"+str8);
			}

			//Write2File1(sw,"+----+------+-------------------------+--------+-----+-----+-----+-----+-----+--------+-------+");
			//sw.WriteLine("                                                                 Total:{0,8:F}",GenUtil.strNumericFormat(grandTotal.ToString()));
			sw.WriteLine("\tTotal\t\t\t\t\t"+Cache["Leave11"].ToString()+"\t"+Cache["Total_Present11"].ToString()+"\t"+Cache["OverTime_Hour11"]+"\t"+GenUtil.strNumericFormat(grandTotal.ToString()));
			//Write2File1(sw,"+----+------+-------------------------+--------+-----+-----+-----+-----+-----+--------+-------+");
			sw.Close();
			SqlDtr.Close();		
		}
	}
}