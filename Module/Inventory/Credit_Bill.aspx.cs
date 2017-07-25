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
using System.Drawing.Imaging;
using System.IO.IsolatedStorage;

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for Credit_Bill.
	/// </summary>
	public class Credit_Bill : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBillNo;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Image imgSample;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		System.Globalization.NumberFormatInfo  nfi = new System.Globalization.CultureInfo("en-US",false).NumberFormat;
		protected System.Web.UI.WebControls.Label txtci1;
		protected System.Web.UI.WebControls.Label txtname1;
		protected System.Web.UI.WebControls.Label txtdet1;
		protected System.Web.UI.WebControls.Label txtadd1;
		protected System.Web.UI.WebControls.Label txtci11;
		string strOrderBy="";
		double Amount_Total = 0,Total_Qty = 0;
		protected System.Web.UI.WebControls.DropDownList DropBillNo;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTO;
		protected System.Web.UI.WebControls.Button printBtn;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DropDownList DropCustID;
		protected System.Web.UI.WebControls.DropDownList DropVehicleNo;
		protected System.Web.UI.WebControls.DataGrid GridCreditBill;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.DropDownList DropSalesType;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator7;
		string uid;

		/// <summary>
		/// Put user code to initialize the page here
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				FillOrgInfo();
				show();
				try
				{
					uid=(Session["User_Name"].ToString());
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Method=pageload"+ ex.Message+" EXCEPTION     "+uid);	
					Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
					return;
				}
				if(!IsPostBack)
				{
					DropBillNo.Visible=false;
					checkPrevileges();
					//lblDate.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
					//txtDateFrom.Text=lblDate.Text.ToString();
					txtDateFrom.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
					//txtDateTO.Text=lblDate.Text.ToString();
					txtDateTO.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
					InventoryClass obj=new InventoryClass();
					SqlDataReader SqlDtr;
					string sql;

					#region Fetch All Customer Name and fill in the ComboBox
					sql="select Cust_Name,City from Customer order by Cust_Name";
					SqlDtr=obj.GetRecordSet(sql);
			
					while(SqlDtr.Read())
					{
				
						DropCustID.Items.Add (SqlDtr.GetValue(0).ToString ()+ ":" +SqlDtr.GetValue(1).ToString ());				
					}
					SqlDtr.Close ();		
					#endregion

					GetNextBillNo();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx method  page_load"+ ex.Message+" EXCEPTION "+uid);
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
			string SubModule="5";
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
			if(Add_Flag=="0" && View_flag=="0" )
			{
				//	string msg="UnAthourized Visit to Credit Bill Page";
				//	dbobj.LogActivity(msg,Session["User_Name"].ToString());  
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}
			if(Add_Flag=="0")
				printBtn.Enabled = false;  
				
			#endregion
		}

		/// <summary>
		/// This method displays the Dealers Logo.
		/// </summary>
		public void show()
		{
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
			string filePath = "";

			sql="select Logo from Organisation where CompanyID='1001'" ;
			SqlDtr=obj.GetRecordSet(sql); 
			if(SqlDtr.Read())
			{
				filePath = SqlDtr["Logo"].ToString() ;
			}
			else
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				filePath =home_drive+@"\Inetpub\wwwroot\EPetro\CompanyLogo\Logo.jpg";
			}
			if(filePath.Trim().Equals(""))
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				filePath =home_drive+@"\Inetpub\wwwroot\EPetro\CompanyLogo\Logo.jpg";
			}
			imgSample.ImageUrl = filePath;
			SqlDtr.Close(); 
		}

		/// <summary>
		/// This Method is used to displays the organisation name and address.
		/// </summary>
		public void FillOrgInfo()
		{
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
			sql="select * from Organisation where CompanyID='1001'" ;
			SqlDtr=obj.GetRecordSet(sql); 
			while(SqlDtr.Read())
			{
				txtname1.Text =SqlDtr.GetValue(1).ToString();  
				txtdet1.Text=SqlDtr.GetValue(2).ToString(); 
				txtadd1.Text=SqlDtr.GetValue(3).ToString(); 
				txtci11.Text=SqlDtr.GetValue(4).ToString();
			}
			SqlDtr.Close();
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
			this.DropBillNo.SelectedIndexChanged += new System.EventHandler(this.DropBillNo_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.DropCustID.SelectedIndexChanged += new System.EventHandler(this.DropCustID_SelectedIndexChanged);
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to return the date in mm/dd/yyyy format.
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
		/// This method is used to retrieve the all values from the database according to selected value in the dropdownlist between the date.
		/// </summary>
		private void DropCustID_SelectedIndexChanged(object sender, System.EventArgs e)
		{   
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr= null;
			string temp = DropCustID.SelectedItem.Text.Trim();   
			string[] arr= temp.Split(new char[] {':'} ,temp.Length);
 
			SqlDtr = obj.GetRecordSet("Select cv.* from Customer_Vehicles cv, Customer c where cv.Cust_id = c.Cust_id and c.Cust_Name='"+arr[0].Trim()+"' and c.City = '"+arr[1].Trim()+"'");
			DropVehicleNo.Items.Clear();
			DropVehicleNo.Items.Add("All");  
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					if(!SqlDtr.GetValue(2).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(2).ToString().Trim()); 
					if(!SqlDtr.GetValue(3).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(3).ToString().Trim()); 
					if(!SqlDtr.GetValue(4).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(4).ToString().Trim()); 
					if(!SqlDtr.GetValue(5).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(5).ToString().Trim()); 
					if(!SqlDtr.GetValue(6).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(6).ToString().Trim()); 
					if(!SqlDtr.GetValue(7).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(7).ToString().Trim()); 
					if(!SqlDtr.GetValue(8).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(8).ToString().Trim()); 
					if(!SqlDtr.GetValue(9).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(9).ToString().Trim()); 
					if(!SqlDtr.GetValue(10).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(10).ToString().Trim()); 
					if(!SqlDtr.GetValue(11).ToString().Trim().Equals(""))
						DropVehicleNo.Items.Add( SqlDtr.GetValue(11).ToString().Trim()); 
				}
			}
			SqlDtr.Close(); 
		}

		/// <summary>
		/// This method is used to write into the report file to print.
		/// </summary>
		public void displayReport()
		{
			try
			{
				PetrolPumpClass obj1=new PetrolPumpClass();
				TextBox1.Text=DropCustID.SelectedValue.ToString(); 
				InventoryClass  obj=new InventoryClass ();
				//SqlDataReader SqlDtr;
				//string sql="";

				#region Bind DataGrid
				strOrderBy = "invoice_no ASC";
				Session["Column"] = "invoice_no";
				Session["Order"] = "ASC";
				BindTheData();
				//			if(DropVehicleNo.SelectedIndex == 0) 
				//			sql="select sm.invoice_no, slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = 'credit' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
				//			else
				//            sql="select sm.invoice_no, slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = 'credit' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
				//
				//			SqlDtr =obj.GetRecordSet(sql);
				//			GridCreditBill.DataSource=SqlDtr;
				//			GridCreditBill.DataBind();
				//			if(GridCreditBill.Items.Count==0)
				//			{
				//				MessageBox.Show("Data not available");
				//				GridCreditBill.Visible=false;
				//			}
				//			else
				//			{
				//				GridCreditBill.Visible=true;
				//			}
				//
				//			SqlDtr.Close();
				checkPrevileges();
				#endregion
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Class:PetrolPumpClass.cs,Method:displayReport()   Credit Bill Viewed for Bill NO  "+lblBillNo.Text.ToString()+"   Userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx ,method :displayReport() "+"  Coustmer :"+   DropCustID.SelectedValue.ToString()+"     is Selected "+ ex.Message+" EXCEPTION "+"  Userid  "+uid);
			}
		}

		/// <summary>
		/// To bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sql="";
			if(DropVehicleNo.SelectedIndex == 0)
			{
				//sql="select sm.invoice_no, slip_no slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount, challanNo slip_no from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and (sm.sales_type = 'Slip Wise Credit' or sm.sales_type = 'Credit') and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
				if(DropSalesType.SelectedItem.Text.Equals("All"))
					//**sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no , invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
					sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no , invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
				else
					//**sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no , invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = '"+DropSalesType.SelectedItem.Text.ToString()+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
					sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no , invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <='"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = '"+DropSalesType.SelectedItem.Text.ToString()+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
			}
			else
			{
				if(DropSalesType.SelectedItem.Text.Equals("All"))
					//**sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
					sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
				else
					//**sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = '"+DropSalesType.SelectedItem.Text.ToString()+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
					sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <='"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = '"+DropSalesType.SelectedItem.Text.ToString()+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
			}
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sql, SqlCon);
			da.Fill(ds, "Sales_Master");
			DataTable dtCustomers = ds.Tables[0];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridCreditBill.DataSource = dv;
				GridCreditBill.DataBind();
				GridCreditBill.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridCreditBill.Visible=false;
			}
			SqlCon.Dispose();
			//		SqlDtr =obj.GetRecordSet(sql);
			//		GridCreditBill.DataSource=SqlDtr;
			//		GridCreditBill.DataBind();
			//		if(GridCreditBill.Items.Count==0)
			//		{
			//			MessageBox.Show("Data not available");
			//			GridCreditBill.Visible=false;
			//		}
			//		else
			//		{
			//			GridCreditBill.Visible=true;
			//		}
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
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to prepares the report file for printting.
		/// </summary>
		public void reportmaking()  
		{
			/*
											======================                                   
												CREDIT BILL REPORT                                      
											======================                                   
			M/s        :
			Bill No    :
			Bill Date  :
		+----------+-----+-------------------------+----+-------+---------+-------------+
		|Inv.Date  |Slip |       Product Name      |Qty | Rate  | Amount  | Vehicle.No  |
		+----------+-----+-------------------------+----+-------+---------+-------------+
		 18/7/2006  12345 1234567890123456789012345 1235 1234567 123456.00 1234567890123 	DD/MM/YYYY  XXX    1234567890123456789012345 123456.78 123456.00  1234567.00  xxxxxxxxxx          	
			*/
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CreditBillReport.txt";
			StreamWriter sw = new StreamWriter(path);

			string sql="";
			string info = "";
			string strDate="";

			string abc = DropCustID.SelectedItem.Text;   
			string billno=lblBillNo.Text;
			//string billdate =lblDate.Text;
			string billdate =DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
			
			//sql="select sm.invoice_no, slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
			if(DropVehicleNo.SelectedIndex == 0) 
				//sql="select sm.invoice_no, slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and (sm.sales_type = 'Slip Wise Credit' or sm.sales_type = 'Credit') and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
				sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no ,invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name,qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
			else
				//sql="select sm.invoice_no, slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and (sm.sales_type = 'Slip Wise Credit' or sm.sales_type = 'Credit') and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"' order by "+Cache["strOrderBy"]; 
				sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no ,invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name,qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and sm.Sales_Type='"+DropSalesType.SelectedItem.Text+"' order by "+Cache["strOrderBy"];
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
			
			//**********
			string des="----------------------------------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr("DEALER : "+addr[1]+","+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("======================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("CREDIT BILL",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("======================",des.Length));
			sw.WriteLine("Party Name : " + abc);
			sw.WriteLine("Bill No    : " + billno);
			sw.WriteLine("Bill Date  : " + billdate+"                                 Bill Period : "+txtDateFrom.Text+" To "+txtDateTO.Text);
			sw.WriteLine("+----------+--------+------------+------------------------------+-----+--------+----------+--------------+");
			sw.WriteLine("|Inv.Date  |Slip No | Invoice No |       Product Name           | Qty |  Rate  | Amount   | Vehicle.No   |");
			sw.WriteLine("+----------+--------+------------+------------------------------+-----+--------+----------+--------------+");
			//             18/7/2006  12345678 123456789012 123456789012345678901234567890 12345 12345678 1234567.00 1234567890123 
			if(rdr.HasRows)
			{
				info = " {0,-10:S} {1,8:S} {2,12:S} {3,-30:S} {4,5:F} {5,8:F} {6,10:F} {7,-14:S}";
				while(rdr.Read())
				{
			
					// Trim Date
					strDate = rdr["invoice_date"].ToString().Trim();
					int pos = strDate.IndexOf(" ");
		
					if(pos != -1)
					{
						strDate = strDate.Substring(0,pos);
					}
					else
					{
						strDate = "";					
					}

					sw.WriteLine(info,GenUtil.str2DDMMYYYY(strDate),
						rdr["Slip_no"].ToString().Trim(),
						rdr["Invoice_No"].ToString().Trim(),
						strTrim(rdr["prod_Name"].ToString()),
						rdr["qty"].ToString().Trim(),
						rdr["rate"].ToString().Trim(),
						GenUtil.strNumericFormat(rdr["amount"].ToString().Trim()),
						rdr["Vehicle_no"].ToString().Trim());

				}
			}

			sw.WriteLine("+----------+--------+------------+------------------------------+-----+--------+----------+--------------+");
			sw.WriteLine(info,"Total","","","","","",GenUtil.strNumericFormat(Cache["Amount"].ToString()),"");
			sw.WriteLine("+----------+--------+------------+------------------------------+-----+--------+----------+--------------+");
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine(info,"","","","","","","","Signature");
			
			// deselect Condensed
			//sw.Write((char)18);
			//sw.Write((char)12);
			dbobj.Dispose();
			sw.Close();

			rdr.Close();
		}

		/// <summary>
		/// This method is used to prepares the report file for printting.
		/// </summary>
		public void reportmaking1()
		{
			/*
											======================                                   
												CREDIT BILL REPORT                                      
											======================                                   
			M/s        :
			Bill No    :
			Bill Date  :
		+----------+-----+-------------------------+----+-------+---------+-------------+
		|Inv.Date  |Slip |       Product Name      |Qty | Rate  | Amount  | Vehicle.No  |
		+----------+-----+-------------------------+----+-------+---------+-------------+
		 18/7/2006  12345 1234567890123456789012345 1235 1234567 123456.00 1234567890123 	DD/MM/YYYY  XXX    1234567890123456789012345 123456.78 123456.00  1234567.00  xxxxxxxxxx          	
			*/
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CreditBillReport.txt";
			StreamWriter sw = new StreamWriter(path);

			string sql="";
			string info = "";
			string strDate="";

			string abc = DropCustID.SelectedItem.Text;   
			string billno=lblBillNo.Text;
			//string billdate =lblDate.Text; 
			string billdate=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
			string[] BillNo1=new string[2];
			//sql="select sm.invoice_no, slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
			if(lblBillNo.Visible==true)
			{
				if(DropVehicleNo.SelectedIndex == 0)
				{
					if(DropSalesType.SelectedIndex==0)
						//sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
						//sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no ,invoice_date, vehicle_no, Prod_Name,qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
					else
						//sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type='"+DropSalesType.SelectedItem.Text+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
						//sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type='"+DropSalesType.SelectedItem.Text+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no ,invoice_date, vehicle_no, Prod_Name,qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and sm.Sales_Type='"+DropSalesType.SelectedItem.Text+"'";
				}
				else
				{
					if(DropSalesType.SelectedIndex==0)
						//sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"' order by "+Cache["strOrderBy"]; 
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <='"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'"; 
					else
						//sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type='"+DropSalesType.SelectedItem.Text+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"' order by "+Cache["strOrderBy"];
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <='"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type='"+DropSalesType.SelectedItem.Text+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'";
				}
			}
			else
			{
				string temp = DropBillNo.SelectedItem.Text;
				BillNo1=temp.Split(new char[] {':'},temp.Length);
				sql = "select Invoice_Date,Slip_No,Particulars Prod_Name,qty,rate,Amount,Vehicle_No,FromDate,ToDate,Cust_ID,Invoice_no from Print_Credit_Bill where Bill_No='"+BillNo1[0].ToString()+"'";
			}
			sql+= " order by "+Cache["strOrderBy"];
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
			
			//**********
			string des="-------------------------------------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr("DEALER : "+addr[1]+","+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("======================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("CREDIT BILL",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("======================",des.Length));
			sw.WriteLine("Party Name : " + abc);
			if(lblBillNo.Visible==true)
				sw.WriteLine("Bill No    : " + billno);
			else
				sw.WriteLine("Bill No    : " + BillNo1[0].ToString());
			sw.WriteLine("Bill Date  : " + billdate+"                                 Bill Period : "+txtDateFrom.Text+" To "+txtDateTO.Text);
			sw.WriteLine("+----------+--------+------------+------------------------------+-----+---------+------------+--------------+");
			sw.WriteLine("|Inv.Date  |Slip No | Invoice No |       Product Name           | Qty |  Rate   |   Amount   | Vehicle.No   |");
			sw.WriteLine("+----------+--------+------------+------------------------------+-----+---------+------------+--------------+");
			//             18/7/2006  12345678 123456789012 123456789012345678901234567890 12345 123456789 123456789.00 1234567890123 
			double Total=0,Total_Amount=0;
			info = " {0,-10:S} {1,8:S} {2,12:S} {3,-30:S} {4,5:F} {5,9:F} {6,12:F} {7,-14:S}";
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					// Trim Date
					strDate = rdr["invoice_date"].ToString().Trim();
					int pos = strDate.IndexOf(" ");
		
					if(pos != -1)
					{
						strDate = strDate.Substring(0,pos);
					}
					else
					{
						strDate = "";
					}
					
					if(rdr["prod_Name"].ToString().IndexOf("Diesel")>=0 || rdr["prod_Name"].ToString().IndexOf("Petrol")>=0)
					{
						Total+=double.Parse(rdr["qty"].ToString());
					}
					Total_Amount+=double.Parse(rdr["amount"].ToString());
					sw.WriteLine(info,GenUtil.str2DDMMYYYY(strDate),
						rdr["Slip_no"].ToString().Trim(),
						rdr["invoice_no"].ToString().Trim(),
						strTrim(rdr["prod_Name"].ToString()),
						rdr["qty"].ToString().Trim(),
						GenUtil.strNumericFormat(rdr["rate"].ToString().Trim()),
						GenUtil.strNumericFormat(rdr["amount"].ToString().Trim()),
						//Multiply1(rdr["invoice_no"].ToString().Trim()),
						rdr["Vehicle_no"].ToString().Trim());
				}
			}

			sw.WriteLine("+----------+--------+------------+------------------------------+-----+---------+------------+--------------+");
			//sw.WriteLine(info,"Total","","","","","",GenUtil.strNumericFormat(Cache["amt"].ToString()),"");
			sw.WriteLine(info,"Total","","","",Total.ToString(),"",GenUtil.strNumericFormat(Total_Amount.ToString()),"");
			sw.WriteLine("+----------+--------+------------+------------------------------+-----+---------+------------+--------------+");
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine(info,"","","","","","","","Signature");
			
			// deselect Condensed
			//sw.Write((char)18);
			//sw.Write((char)12);
			dbobj.Dispose();
			sw.Close();
			rdr.Close();
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
			string path = home_drive+@"\ePetro_ExcelFile\CreditBill.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			string[] BillNo=new string[2];
			if(lblBillNo.Visible==true)
			{
				//if(DropVehicleNo.SelectedIndex == 0) 
				//sql="select sm.invoice_no, slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and (sm.sales_type = 'Slip Wise Credit' or sm.sales_type = 'Credit') and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
				//else
				//sql="select sm.invoice_no, slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and (sm.sales_type = 'Slip Wise Credit' or sm.sales_type = 'Credit') and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"' order by "+Cache["strOrderBy"];
				//				if(DropVehicleNo.SelectedIndex == 0)
				//				{
				//					if(DropSalesType.SelectedIndex==0)
				//						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
				//					else
				//						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type='"+DropSalesType.SelectedItem.Text+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
				//				}
				//				else
				//				{
				//					if(DropSalesType.SelectedIndex==0)
				//						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"' order by "+Cache["strOrderBy"]; 
				//					else
				//						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type='"+DropSalesType.SelectedItem.Text+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"' order by "+Cache["strOrderBy"];
				//				}
				if(DropVehicleNo.SelectedIndex == 0)
				{
					if(DropSalesType.SelectedIndex==0)
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no ,invoice_date, vehicle_no, Prod_Name,qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id order by "+Cache["strOrderBy"];
					else
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no ,invoice_date, vehicle_no, Prod_Name,qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and sm.Sales_Type='"+DropSalesType.SelectedItem.Text+"' order by "+Cache["strOrderBy"];
				}
				else
				{
					if(DropSalesType.SelectedIndex==0)
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <='"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"' order by "+Cache["strOrderBy"]; 
					else
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <='"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type='"+DropSalesType.SelectedItem.Text+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"' order by "+Cache["strOrderBy"];
				}
			}
			else
			{
				string temp = DropBillNo.SelectedItem.Text;
				BillNo=temp.Split(new char[] {':'},temp.Length);
				sql = "select Invoice_Date,Slip_No,Particulars Prod_Name,qty,rate,Amount,Vehicle_No,FromDate,ToDate,Cust_ID,invoice_no from Print_Credit_Bill where Bill_No='"+BillNo[0].ToString()+"'";
			}
			dbobj.SelectQuery(sql,ref rdr);
			//sw.WriteLine("From Date\t"+txtDateFrom.Text);
			//sw.WriteLine("To Date\t"+txtDateTO.Text);
			sw.WriteLine("M / s\t"+DropCustID.SelectedItem.Text);
			if(lblBillNo.Visible==true)
				sw.WriteLine("Bill No\t"+lblBillNo.Text);
			else
				sw.WriteLine("Bill No\t"+BillNo[0].ToString());
			//sw.WriteLine("Bill Date\t"+lblDate.Text);
			sw.WriteLine("Date From\t"+txtDateFrom.Text+"\tDate To\t"+txtDateTO.Text);
			sw.WriteLine("Bill Date\t"+DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString());
			sw.WriteLine("Invoice Date\tSlip No\tInvoice No\tProduct Name\tQty\tRate\tAmount\tVehicle.No");
			double Total=0,Total_Amount=0;
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					if(rdr["prod_Name"].ToString().IndexOf("Diesel")>=0 || rdr["prod_Name"].ToString().IndexOf("Petrol")>=0)
					{
						Total+=double.Parse(rdr["qty"].ToString());
					}
					Total_Amount+=double.Parse(rdr["amount"].ToString());
					sw.WriteLine(GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["invoice_date"].ToString()))+"\t"+
						rdr["Slip_no"].ToString().Trim()+"\t"+
						rdr["invoice_no"].ToString().Trim()+"\t"+
						strTrim(rdr["prod_Name"].ToString())+"\t"+
						rdr["qty"].ToString().Trim()+"\t"+
						rdr["rate"].ToString().Trim()+"\t"+
						GenUtil.strNumericFormat(rdr["amount"].ToString().Trim())+"\t"+
						//Multiply1(rdr["invoice_no"].ToString())+"\t"+
						rdr["Vehicle_no"].ToString().Trim());
				}
			}
			//sw.WriteLine("Total\t\t\t\t\t\t\t"+GenUtil.strNumericFormat(Cache["amt"].ToString()));
			sw.WriteLine("Total\t\t\t\t"+Total.ToString()+"\t\t"+GenUtil.strNumericFormat(Total_Amount.ToString()));
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This function to trim the spaces according to length.
		/// </summary>
		public string strTrim(string str)
		{
			if(str.Length > 30)
			{
				str =str.Substring(0,30); 
			}
			return str;
		}

		/// <summary>
		/// This method is used to sends the text file to print server to print.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CreditBillReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Class:PetrolPumpClass.cs,Method:Print"+ uid);
		
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
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Class:PetrolPumpClass.cs,Method:Print"+ es.Message+"  EXCEPTION  "+uid);

			}
		}

		/// <summary>
		/// This method is used to crear the form.
		/// </summary>
		public void Clear()
		{
			txtDateFrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtDateTO.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			//lblDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			DropCustID.SelectedIndex=0;
			DropVehicleNo.SelectedIndex=0;
			DropSalesType.SelectedIndex=0;
		}

		/// <summary>
		/// Method to fetch the next Bill no from print_credit_bill table.
		/// </summary>
		public void GetNextBillNo()
		{
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr;
			string sql;

			#region Fetch the Next Bill No

			sql="select Max(Bill_No)+1 from Print_Credit_Bill";
			SqlDtr=obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				lblBillNo.Text=SqlDtr.GetValue(0).ToString();
				if(lblBillNo.Text=="")
				{
					lblBillNo.Text="1001";
				}
			}
			SqlDtr.Close ();		
			#endregion
		}

		/// <summary>
		/// This method is used to insert the record with the help of Save() function.
		/// </summary>
		private void printBtn_Click(object sender, System.EventArgs e)
		{
			Save();
		}
		
		/// <summary>
		/// This method is used to insert the value in database before check the condition.
		/// </summary>
		public void Save()
		{
			try
			{
				// The follwing code saves the credit bill as well as print it.
				if(DropCustID.SelectedIndex == 0)
				{
					MessageBox.Show("Please Select the Customer Name"); 
					return;
				}
				string	sql="";
				/*******************
				if(DropSalesType.SelectedIndex==0)
					//sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name,qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
					  sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no ,invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name,qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
				else
					//sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name,qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and sm.Sales_Type='"+DropSalesType.SelectedItem.Text+"'";
					sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no ,invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name,qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and sm.Sales_Type='"+DropSalesType.SelectedItem.Text+"'";
				***************************/
				if(DropVehicleNo.SelectedIndex == 0)
				{
					//sql="select sm.invoice_no, slip_no slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount, challanNo slip_no from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and (sm.sales_type = 'Slip Wise Credit' or sm.sales_type = 'Credit') and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
					if(DropSalesType.SelectedItem.Text.Equals("All"))
						//**sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no , invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no , invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
					else
						//**sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no , invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = '"+DropSalesType.SelectedItem.Text.ToString()+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no , invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <='"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = '"+DropSalesType.SelectedItem.Text.ToString()+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id";
				}
				else
				{
					if(DropSalesType.SelectedItem.Text.Equals("All"))
						//**sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
					else
						//**sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount from sales_master sm, sales_details sd, products p where sm.invoice_date between '"+ ToMMddYYYY(txtDateFrom.Text) +"' and dateadd(day,1,'"+ ToMMddYYYY(txtDateTO.Text) + "') and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = '"+DropSalesType.SelectedItem.Text.ToString()+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
						sql="select sm.invoice_no, case when slip_no=0 then challanno else slip_no end as slip_no, invoice_date, vehicle_no, prod_Name+ ' ' +Pack_Type Prod_Name, qty, rate, amount,Cust_ID from sales_master sm, sales_details sd, products p where cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(txtDateFrom.Text) +"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <='"+ GenUtil.str2MMDDYYYY(txtDateTO.Text) + "' and sm.cust_id in ( select cust_id from customer where cust_name=substring('"+ DropCustID.SelectedItem.Value +"',1,charindex(':','"+ DropCustID.SelectedItem.Value +"')-1)  and city=substring('"+ DropCustID.SelectedItem.Value +"',charindex(':','"+ DropCustID.SelectedItem.Value +"')+1,len('"+ DropCustID.SelectedItem.Value +"'))) and sm.sales_type = '"+DropSalesType.SelectedItem.Text.ToString()+"' and sm.invoice_no = sd.invoice_no and sd.prod_id = p.prod_id and Vehicle_No = '"+DropVehicleNo.SelectedItem.Text+"'" ; 
				}
				PetrolPumpClass obj=new PetrolPumpClass();
				PetrolPumpClass obj1=new PetrolPumpClass();
				SqlDataReader	SqlDtr2 =obj.GetRecordSet(sql);
				string sql1="";
				string[] BillNo=new string[2];
				//*********
				if(lblBillNo.Visible==false)
				{
					string temp = DropBillNo.SelectedItem.Text;
					BillNo=temp.Split(new char[] {':'},temp.Length);
					obj1.InsertRecord("delete from Print_Credit_Bill where Bill_No='"+BillNo[0].ToString()+"'");
				}
				//*********
				while(SqlDtr2.Read())
				{
					DateTime dt=System.Convert.ToDateTime(SqlDtr2.GetValue(2).ToString());
					//string str1=dt.ToShortDateString();
					string str1=DateTime.Now.ToString();
					string str2=SqlDtr2.GetValue(1).ToString();
					string str3=SqlDtr2.GetValue(4).ToString();
					string str4=SqlDtr2.GetValue(5).ToString();
					string str5=SqlDtr2.GetValue(6).ToString();
					string str6=SqlDtr2.GetValue(7).ToString();
					string str7=SqlDtr2.GetValue(3).ToString();
					//********
					string str8=SqlDtr2.GetValue(8).ToString();
					string str9=GenUtil.str2MMDDYYYY(txtDateFrom.Text);
					string str10=GenUtil.str2MMDDYYYY(txtDateTO.Text);
					string str11=SqlDtr2.GetValue(2).ToString();
					string str12=SqlDtr2.GetValue(0).ToString();
					//********
					if(lblBillNo.Visible==true)
						sql1="insert into Print_Credit_Bill(Bill_No,Bill_date,Slip_no,Particulars,Qty,Rate,Amount,Vehicle_No,Cust_ID,FromDate,ToDate,Invoice_Date,Invoice_No)values('"+lblBillNo.Text.ToString()+"','"+str1+"','"+str2+"','"+str3+"','"+str4+"','"+str5+"','"+str6+"','"+str7+"','"+str8+"','"+str9+"','"+str10+"','"+str11+"','"+str12+"')";
					else
						sql1="insert into Print_Credit_Bill(Bill_No,Bill_date,Slip_no,Particulars,Qty,Rate,Amount,Vehicle_No,Cust_ID,FromDate,ToDate,Invoice_Date,Invoice_No)values('"+BillNo[0].ToString()+"','"+str1+"','"+str2+"','"+str3+"','"+str4+"','"+str5+"','"+str6+"','"+str7+"','"+str8+"','"+str9+"','"+str10+"','"+str11+"','"+str12+"')";
					obj1.InsertRecord(sql1);
				}		 
				SqlDtr2.Close();
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Class:PetrolPumpClass.cs,Method:Print Bill No."+lblBillNo.Text.ToString()+" Saved. User Id = "+uid );
				MessageBox.Show("Credit Bill Saved");
				//reportmaking();
				reportmaking1();
				//Print();
				GetNextBillNo();
				checkPrevileges();
	
				txtDateFrom.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
				txtDateTO.Text=DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year.ToString();
				DropCustID.SelectedIndex=0;
				DropBillNo.Visible=false;
				btnEdit.Visible=true;
				lblBillNo.Visible=true;
				GridCreditBill.DataSource=null;
				GridCreditBill.DataBind();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Class:PetrolPumpClass.cs,Method:Save(), "+ ex.Message+"  EXCEPTION  "+uid);
			}
		}
		
		/// <summary>
		/// This method is not used.
		/// </summary>
		private void DropVehicleNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropCustID.SelectedIndex == 0)
			{
				MessageBox.Show("Please Select the Customer Name");
				return;
			}
			displayReport();
		}
		//		double amount=0;
		//		//To calculate the total amount.
		//		protected string SumAmount(string amt)
		//		{
		//			amount+=System.Convert.ToDouble(amt);
		//			Cache["Amount"]=amount;
		//			return GenUtil.strNumericFormat(amt);
		//		}

		/// <summary>
		/// This method is used to Prepares the excel report file CreditBill.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridCreditBill.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Method: btnExcel_Click, Credit_Bill Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Method:btnExcel_Click   Credit_Bill Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the report file LeaveReport.txt for printing.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			reportmaking1();
			Print();
			printBtn.Enabled=true;
			lblBillNo.Visible=true;
			DropBillNo.Visible=false;
			btnEdit.Visible=true;
			GridCreditBill.Visible=false;
			Clear();
		}

		/// <summary>
		/// This method is used to fill all Bill No in the dropdownlist from the database for 
		/// update and delete the record.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			btnEdit.Visible=false;
			DropBillNo.Visible=true;
			lblBillNo.Visible=false;
			printBtn.Enabled=false;
			InventoryClass obj = new InventoryClass();
			SqlDataReader rdr;
			string sql = "select distinct Bill_No,Cust_Name from print_credit_bill pcb,Customer c where pcb.Cust_ID=c.Cust_ID";
			rdr = obj.GetRecordSet(sql);
			DropBillNo.Items.Clear();
			DropBillNo.Items.Add("Select");
			while(rdr.Read())
			{
				DropBillNo.Items.Add(rdr.GetValue(0).ToString()+":"+rdr.GetValue(1).ToString());
			}
			rdr.Close();
		}

		/// <summary>
		/// This method is used to fatch and put the all value and also bind the datagrid acording to select the bill no 
		/// from the dropdownlist on edit time.
		/// </summary>
		private void DropBillNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			InventoryClass obj=new InventoryClass();
			InventoryClass obj1=new InventoryClass();
			SqlDataReader rdr,rdr1,SqlDtr=null;
			string temp = DropBillNo.SelectedItem.Text;
			string[] BillNo=temp.Split(new char[] {':'},temp.Length);
			string str="select Invoice_Date,Slip_No,Particulars Prod_Name,qty,rate,Amount,Vehicle_No,FromDate,ToDate,Cust_ID,Bill_Date,invoice_no from Print_Credit_Bill where Bill_No='"+BillNo[0].ToString()+"' order by invoice_no";
			rdr = obj.GetRecordSet(str);
			rdr1 = obj1.GetRecordSet(str);
			GridCreditBill.DataSource=rdr1;
			if(rdr1.HasRows)
			{
				GridCreditBill.DataBind();
				GridCreditBill.Visible=true;
				if(rdr.Read())
				{
					txtDateFrom.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["FromDate"].ToString()));
					txtDateTO.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["ToDate"].ToString()));
					//lblDate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Bill_Date"].ToString()));
					dbobj.SelectQuery("select Cust_Name,City from Customer where Cust_Name='"+BillNo[1].ToString()+"'",ref SqlDtr);
					if(SqlDtr.Read())
					{
						DropCustID.SelectedIndex=DropCustID.Items.IndexOf(DropCustID.Items.FindByValue(SqlDtr["Cust_Name"].ToString()+":"+SqlDtr["City"].ToString()));
					}
				}
			}
			else
			{
				MessageBox.Show("Data Not Available");
				GridCreditBill.Visible=false;
			}
		}

		/// <summary>
		/// This method is used to display the report with the help of displayReport() function.
		/// </summary>
		private void btnView_Click(object sender, System.EventArgs e)
		{
			try
			{
				/*
				PetrolPumpClass obj1=new PetrolPumpClass();
				TextBox1.Text=DropCustID.SelectedValue.ToString(); 
				if(DropCustID.SelectedIndex ==0)
				{
					MessageBox.Show("Please Select Customer Name");
					return;
				}
				
				InventoryClass  obj=new InventoryClass ();
				SqlDataReader SqlDtr= null;
				string temp = DropCustID.SelectedItem.Text.Trim();   
				string[] arr= temp.Split(new char[] {':'} ,temp.Length);
 
				SqlDtr = obj.GetRecordSet("Select cv.* from Customer_Vehicles cv, Customer c where cv.Cust_id = c.Cust_id and c.Cust_Name='"+arr[0].Trim()+"' and c.City = '"+arr[1].Trim()+"'");
				DropVehicleNo.Items.Clear();
				DropVehicleNo.Items.Add("All");  
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						if(!SqlDtr.GetValue(2).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(2).ToString().Trim()); 
						if(!SqlDtr.GetValue(3).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(3).ToString().Trim()); 
						if(!SqlDtr.GetValue(4).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(4).ToString().Trim()); 
						if(!SqlDtr.GetValue(5).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(5).ToString().Trim()); 
						if(!SqlDtr.GetValue(6).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(6).ToString().Trim()); 
						if(!SqlDtr.GetValue(7).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(7).ToString().Trim()); 
						if(!SqlDtr.GetValue(8).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(8).ToString().Trim()); 
						if(!SqlDtr.GetValue(9).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(9).ToString().Trim()); 
						if(!SqlDtr.GetValue(10).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(10).ToString().Trim()); 
						if(!SqlDtr.GetValue(11).ToString().Trim().Equals(""))
							DropVehicleNo.Items.Add( SqlDtr.GetValue(11).ToString().Trim()); 
					}
				}
				SqlDtr.Close(); 
				*/
				displayReport();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx ,method :View_Click, " +ex.Message+" EXCEPTION "+"  Userid  "+uid);
			}
		}
		
		double amt=0,amt1=0,amt2=0;
		int count=0,i=0,status=0,Flag=0;
		/// <summary>
		/// This method is used to check the invoice no if invoice no have one more product then show the "---" 
		/// and show the invoice amount in last according to given invoice no. if only one product in given
		/// invoice no then show the invoice amount only.
		/// </summary>
		protected string Multiply1(string inv_no)
		{
			PetrolPumpClass  obj=new PetrolPumpClass();
			SqlDataReader SqlDtr;
			string sql;
			int in_amt=0;
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
				sql = "select count(*) from sales_details where Invoice_No="+Cache["Invoice_No"].ToString()+"";
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
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemTotal(object sender,DataGridItemEventArgs e)
		{
			try
			{
				
				// If datagrid item is a bound column other than header and footer
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
				{
					TotalAmount(double.Parse(e.Item.Cells[6].Text));
					string ss=e.Item.Cells[3].Text;
					if(e.Item.Cells[3].Text.IndexOf("Diesel")>=0 || e.Item.Cells[3].Text.IndexOf("Petrol")>=0)
					{
						TotalQty(double.Parse(e.Item.Cells[4].Text));
					}
					//**********
					//SqlDataReader rdr=null;
					//dbobj.Insert_or_Update("select ",ref rdr);
					//**********
				}
				else if(e.Item.ItemType == ListItemType.Footer)
				{
					//if the row or item type is footer then display the calculated total debit, credit and last balance with type in the footer. nfi and "N" used to format the double no. in #,###.00 format.
					//sum of cell[3],cell[4] hidden by mahesh (08/11/06)
					//e.Item.Cells[3].Text = debit_total.ToString("N",nfi);
					//e.Item.Cells[4].Text = credit_total.ToString("N",nfi);
					e.Item.Cells[4].Text = Total_Qty.ToString();
					e.Item.Cells[6].Text = Amount_Total.ToString("N",nfi);
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Credit_Bill.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User ID "+ uid );
			}
		}

		/// <summary>
		/// This method is used to calculate the total Amount
		/// </summary>
		protected void TotalAmount(double _Amount)
		{
			Amount_Total  += _Amount;
		}

		/// <summary>
		/// This method is used to calculate the total qty
		/// </summary>
		protected void TotalQty(double _Qty)
		{
			Total_Qty  += _Qty;
		}
	}
}