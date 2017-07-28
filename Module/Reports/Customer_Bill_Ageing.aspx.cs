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
using System.Data.SqlClient;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;


namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for Customer_Bill_Ageing.
	/// </summary>
	public class Customer_Bill_Ageing : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid GridReport;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateFrom;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateTo;
		protected System.Web.UI.WebControls.ValidationSummary vsCustWiseSales;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.Button Update;
		protected System.Web.UI.WebControls.Button Update1;
		protected System.Web.UI.WebControls.CheckBox c;
		protected System.Web.UI.WebControls.TextBox InterestText;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DropDownList DropCustName;
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
                txtDateFrom.Attributes.Add("readonly", "readonly");
                Textbox1.Attributes.Add("readonly", "readonly");
                uid =(Session["User_Name"].ToString());
				// if the user is admin. then visible the update interest button and make the Ineterest Text field editable to modify or vice versa.
				if(Session["User_ID"].ToString().Equals("1001") )
				{
					InterestText.ReadOnly = false;
					Update1.Visible = true;              
				}
				else
				{
					InterestText.ReadOnly = true;
					Update1.Visible = false;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_bill_Ageing.aspx,Method:pageload"+ ex.Message+" EXCEPTION  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				try
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="18";
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
					//Fetch The Interest Rate from mmisc_cd table and insert it into Interest Rate Text Field.
					System.Data.SqlClient.SqlDataReader rdr=null;
					dbobj.SelectQuery("Select Key_Descr from mmisc_cd where key_type = 'Interest'",ref rdr);
					if(rdr.Read())
						InterestText.Text = rdr["Key_Descr"].ToString();
					else
						InterestText.Text = "0";
					rdr.Close();
					dbobj.SelectQuery("select distinct Cust_Name from vw_Cust_Ageing",ref rdr);
					DropCustName.Items.Clear();
					DropCustName.Items.Add("All");
					while(rdr.Read())
					{
						DropCustName.Items.Add(rdr["cust_Name"].ToString());
					}
					rdr.Close();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Customer_bill_Ageing.aspx,Method:pageload()  EXCEPTION :"+ ex.Message+" User: "+uid);
				}
			}
		}

		/// <summary>
		/// This method is not used
		/// </summary>
		private string GetString(string str,string spc)
		{
			if(str.Length>spc.Length)
				return str;
			else
				return str+spc.Substring(0,spc.Length-str.Length)+"  ";			
		}
				
		/// <summary>
		/// This method is not used
		/// </summary>
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6)
		{
			while(rdr.Read())
			{
				if(rdr["Cust_ID"].ToString().Trim().Length>len1)
					len1=rdr["Cust_ID"].ToString().Trim().Length;					
				if(rdr["Cust_Name"].ToString().Trim().Length>len2)
					len2=rdr["Cust_Name"].ToString().Trim().Length;					
				if(rdr["City"].ToString().Trim().Length>len3)
					len3=rdr["City"].ToString().Trim().Length;
				if(rdr["Invoice_No"].ToString().Trim().Length>len4)
					len4=rdr["Invoice_No"].ToString().Trim().Length;					
				if(rdr["Invoice_Date"].ToString().Trim().Length>len5)
					len5=rdr["Invoice_Date"].ToString().Trim().Length;					
				if(rdr["Cr_Days"].ToString().Trim().Length>len6)
					len6=rdr["Cr_Days"].ToString().Trim().Length;	
							
			}
		}
		
		/// <summary>
		/// This method is not used
		/// </summary>
		private string GetString(string str,int maxlen,string spc)
		{		
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
		}

		/// <summary>
		/// This method is used to return the space according to given length.
		/// </summary>
		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
		}
		
		/// <summary>
		/// This Method is used to write into the report file to print.
		/// </summary>
		public void MakingReport()
		{
			/*
+----+-------------------------+------------+------+----------+------------+----+----------+-------+-------+-----------+
|Cust|    Customer Name        |   City     | Inv. |Inv. Date |Bill Amount | Cr.| Due Date | Total |Overdue|Amt. with  |
| ID |                         |            |  No. |          |            |Days|          |DueDays| Days  |Interest   |
+----+-------------------------+------------+------+----------+------------+----+----------+-------+-------+-----------+
 1001 1234567890123456789012345 Gwalior      123456 1234567890 123456789012 1234 1234567890 1234567 1234567 12345678901            	
			*/		
			//string sql        = "";
			string info       = "";
			string strDate    = "";
			string strDueDate = "";
		
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\BillAgeingReport.txt";
			StreamWriter sw = new StreamWriter(path);
			System.Data.SqlClient.SqlDataReader rdr=null;
			string sqlstr="";     			
			if(DropCustName.SelectedIndex==0)
				sqlstr = "select c.*,s.* from vw_Cust_Ageing c,Sales_Master s where c.Invoice_No=s.Invoice_No and cast(floor(cast(c.invoice_date as float)) as datetime)>='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and cast(floor(cast(c.invoice_date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(Textbox1.Text)).ToShortDateString()+"'" ;
			else
				sqlstr = "select c.*,s.* from vw_Cust_Ageing c,Sales_Master s where c.Invoice_No=s.Invoice_No and Cust_Name='"+DropCustName.SelectedItem.Text+"' and cast(floor(cast(c.invoice_date as float)) as datetime)>='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and cast(floor(cast(c.invoice_date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(Textbox1.Text)).ToShortDateString()+"'" ;
			dbobj.SelectQuery(sqlstr,ref rdr);
			string subTitle = "From "+txtDateFrom.Text.ToString()+" To "+Textbox1.Text.ToString();
			if(c.Checked && !InterestText.Text.ToString().Trim().Equals("0")) 
				subTitle = subTitle+" with "+InterestText.Text.ToString().Trim()+"% Interest";
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu
			//Condensed
			sw.Write((char)27);
			sw.Write((char)15);
			// Condensed
			//sw.Write((char)15);
			sw.WriteLine("");
			//**********
			string des="+-------------------------+---------+------------+------------+------+----------+------------+----+----------+-------+-------+-----------+";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			//************
			//			sw.WriteLine("                               S.T.No. 024/MRN/1/MRN/1757/4,       C.S.T.No. MRN/1/MRN/926");
			//			sw.WriteLine("                                                     RAJE FILLING CENTRE");
			//			sw.WriteLine("                                   Dealer – INDIAN OIL CORP.A.B.Road, Banmor Distt. Morena");
			//			sw.WriteLine("                                                    Tinn No – 23975501757");
			//			sw.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
			
			//************
			sw.WriteLine(GenUtil.GetCenterAddr("=============================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("CUSTOMER BILL AGEING REPORT",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=============================",des.Length));
			//sw.WriteLine("+-------+------------------------------+------------+-------+----------+--------------+-------+----------+------+-------+--------------+");
			//sw.WriteLine("|Cust.ID|Cust.Name                     |City        |Inv.No.|Inv.Date  | Bill Amount  |Cr.Days|Due Date  |>7Days|>15Days|30Days & Above|");
			//sw.WriteLine("+-------+------------------------------+------------+-------+----------+--------------+-------+----------+------+-------+--------------+");
			//sw.WriteLine("+-------+------------------------------+------------+-------+----------+--------------+-------+----------+--------------+------------------+");
			//sw.WriteLine("|Cust.ID|Cust.Name                     |City        |Inv.No.|Inv.Date  | Bill Amount  |Cr.Days|Due Date  |Total Due Days|Total Overdue Days|");
			//sw.WriteLine("+-------+------------------------------+------------+-------+----------+--------------+-------+----------+--------------+------------------+");
			//                         XXXX    123456789012345678901234567890 123456789012  XXXX   DD/MM/YYYY  12345678.90    XX     DD/MM/YYYY       999            999
			sw.WriteLine("Customer Name : "+DropCustName.SelectedItem.Text);
			sw.WriteLine(subTitle);
			sw.WriteLine("+-------------------------+---------+------------+------------+------+----------+------------+----+----------+-------+-------+-----------+");
			sw.WriteLine("|     Customer Name       | Slip_No | Vehicle No |   City     | Inv. |Inv. Date |Bill Amount | Cr.| Due Date | Total |Overdue| Amt. With |");
			sw.WriteLine("|                         |         |            |            |  No. |          |            |Days|          |DueDays| Days  | Interest  |");
			sw.WriteLine("+-------------------------+---------+------------+------------+------+----------+------------+----+----------+-------+-------+-----------+");
			//			   1234567890123456789012345 123456789 123456789012 123456789012 123456 1234567890 123456789012 1234 1234567890 1234567 1234567 12345678901            	
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					// info used to set the display format of the string.
					info = " {0,-25:S} {1,9:S} {2,-12:S} {3,-12:S} {4,-6:S} {5,-10:S} {6,12:S} {7,4:S} {8,-10:S} {9,7:S} {10,7:S} {11,11:S}";
					
					// Trim the Time part from Date
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

					// Calculate Due Date

					strDueDate=rdr["due_date"].ToString(); 
					pos = strDueDate.IndexOf(" ");
					if(pos != -1)
					{
						strDueDate = strDueDate.Substring(0,pos);
					}
					else
					{
						strDueDate = "";					
					}

					sw.WriteLine(info,GenUtil.TrimLength(rdr["Cust_Name"].ToString().Trim(),25),
						GenUtil.TrimLength(rdr["slip_no"].ToString(),9),
						GenUtil.TrimLength(rdr["vehicle_No"].ToString(),12),
						rdr["city"].ToString().Trim(),
						rdr["Invoice_No"].ToString().Trim(),
						GenUtil.str2DDMMYYYY(strDate),
						GenUtil.strNumericFormat(rdr["Net_Amount"].ToString().Trim()),
						rdr["Cr_Days"].ToString().Trim(),
						GenUtil.str2DDMMYYYY(strDueDate),
						rdr["tcr"].ToString().Trim(),
						rdr["tdd"].ToString().Trim(),
						CalcInterest(rdr["Net_Amount"].ToString().Trim(),rdr["tdd"].ToString().Trim())
						);
				}
			}
			
			sw.WriteLine("+-------------------------+---------+------------+------------+------+----------+------------+----+----------+-------+-------+-----------+");
			sw.WriteLine(info,"Total","","","","","",GenUtil.strNumericFormat(Cache["Amount"].ToString()),"","","","",GenUtil.strNumericFormat(Cache["Amt1"].ToString()));
			sw.WriteLine("+-------------------------+---------+------------+------------+------+----------+------------+----+----------+-------+-------+-----------+");
			// deselect Condensed
			//			sw.Write((char)18);
			//			sw.Write((char)12);
			sw.Close();
		}
		
		/// <summary>
		/// This Method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string sql="";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\CustomerBillAgeing.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			if(DropCustName.SelectedIndex==0)
				sql = "select c.*,s.* from vw_Cust_Ageing c,Sales_Master s where c.Invoice_No=s.Invoice_No and cast(floor(cast(c.invoice_date as float)) as datetime)>='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and cast(floor(cast(c.invoice_date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(Textbox1.Text)).ToShortDateString()+"'";
			else
				sql = "select c.*,s.* from vw_Cust_Ageing c,Sales_Master s where c.Invoice_No=s.Invoice_No and Cust_Name='"+DropCustName.SelectedItem.Text+"' and cast(floor(cast(c.invoice_date as float)) as datetime)>='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and cast(floor(cast(c.invoice_date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(Textbox1.Text)).ToShortDateString()+"'";
			dbobj.SelectQuery(sql,ref rdr);
			string subTitle = "";
			if(c.Checked && !InterestText.Text.ToString().Trim().Equals("0")) 
				subTitle = "Interest\t"+InterestText.Text.ToString().Trim()+"%";
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+Textbox1.Text);
			sw.WriteLine("Customer Name\t"+DropCustName.SelectedItem.Text);
			sw.WriteLine(subTitle);
			sw.WriteLine("Customer Name\tSlip No\tVehicle No\tCity\tInvoice No\tInvoice Date\tBill Amount\tCredit Days\tDue Date\tTotal DueDate\tOverdue Days\tAmt. With Interest");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(rdr["Cust_Name"].ToString().Trim()+"\t"+
						rdr["slip_no"].ToString().Trim()+"\t"+
						rdr["Vehicle_No"].ToString().Trim()+"\t"+
						rdr["City"].ToString()+"\t"+
						rdr["Invoice_No"].ToString().Trim()+"\t"+
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Invoice_Date"].ToString().Trim()))+"\t"+
						GenUtil.strNumericFormat(rdr["Net_Amount"].ToString().Trim())+"\t"+
						rdr["Cr_Days"].ToString().Trim()+"\t"+
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["due_date"].ToString()))+"\t"+
						rdr["tcr"].ToString().Trim()+"\t"+
						rdr["tdd"].ToString().Trim()+"\t"+           
						CalcInterest(rdr["Net_Amount"].ToString().Trim(),rdr["tdd"].ToString().Trim())
						);
				}
			}
			sw.WriteLine("Total\t\t\t\t\t\t"+GenUtil.strNumericFormat(Cache["Amount"].ToString())+"\t\t\t\t\t"+GenUtil.strNumericFormat(Cache["Amt1"].ToString()));
			rdr.Close();
			sw.Close();
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
			this.Update1.Click += new System.EventHandler(this.Update1_Click);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		/// <summary>
		/// This method returns the date in MM/DD/YYYY format.
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
		/// This method is not used.
		/// </summary>
		protected string Stop(string str)
		{
			if(str.IndexOf(".")>0)
			{
				string ret=str.Substring(0,str.IndexOf(".")+3);
				return ret;
			}
			else
				return str;
		}

		/// <summary>
		/// This method called from ".aspx" page to calculate the interest if the check box is checked.
		/// </summary>
		double amt1=0;
		protected string CalcInterest(string str,string ttd)
		{
			double amt=0;
			
			double interest=0;
			// if the check box is checkd then calculate intrest.
			if(c.Checked)
			{
				interest = System.Convert.ToDouble(InterestText.Text.ToString());
				if(interest == 0)
					return "";
				else
				{
					if(!str.Trim().Equals("")  )
					{
						amt = System.Convert.ToDouble(str);
						//amt = amt+(amt*(interest/100));
						amt = ((amt*(interest/100))/365)*System.Convert.ToDouble(ttd);
					}
					else
						amt = 0;
					amt1+=System.Convert.ToDouble(GenUtil.strNumericFormat(amt.ToString()));
					Cache["Amt1"]=GenUtil.strNumericFormat(amt1.ToString()); 
					return GenUtil.strNumericFormat(amt.ToString()); 
					
				}				
			}
			else
				Cache["Amt1"]="";
			return "";
		}

		public string strOrderBy="";
		string sqlstr="";
		/// <summary>
		/// To show the customer information in between to and from date.
		/// To calculate interest in given textbox when check box is checked then calculate amount with interest per day
		/// Otherwise not calculate the interest.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{     
			try
			{
				if(DateTime.Compare(ToMMddYYYY(txtDateFrom.Text),ToMMddYYYY(Textbox1.Text))>0)
				{
					MessageBox.Show("Date From Should be less than Date To");
					GridReport.Visible=false;
				}
				else
				{
					PetrolPumpClass  obj=new PetrolPumpClass();
					//SqlDataReader SqlDtr;
					//string sql;

					#region Bind DataGrid
					//*********
					
					strOrderBy = "Cust_Name ASC";
					Session["Column"] = "Cust_Name";
					Session["Order"] = "ASC";
					//BindTheData();

					//*********
					
					//SqlDtr =obj.GetRecordSet(sql);
					//GridReport.DataSource=SqlDtr;
					//GridReport.DataBind();
					BindTheData();
					if(GridReport.Items.Count==0)
					{
						MessageBox.Show("Data not available");
						GridReport.Visible=false;
					}
					else
					{
						GridReport.Visible=true;
					}
					//SqlDtr.Close();
					#endregion
				}
				CreateLogFiles.ErrorLog("Form:Customer_Billing.aspx,Class:PetrolPumpClass.cs ,Method:btnShow_Click"+"Customer Ageing Report viewed "+" userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_Billing.aspx,Class:PetrolPumpClass.cs ,Method:btnShow_Click"+"Customer Ageing Report viewed "+" EXCEPTION  "+ex.Message+" userid "+uid);
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
				CreateLogFiles.ErrorLog("Form:Customer_Bill_Ageing.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon11 =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			if(DropCustName.SelectedIndex==0)
				//sqlstr = "select * from vw_Cust_Ageing where cast(floor(cast(invoice_date as float)) as datetime)>='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(Textbox1.Text)).ToShortDateString()+"'" ;
				sqlstr = "select c.*,s.* from vw_Cust_Ageing c,Sales_Master s where c.Invoice_No=s.Invoice_No and cast(floor(cast(c.invoice_date as float)) as datetime)>='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and cast(floor(cast(c.invoice_date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(Textbox1.Text)).ToShortDateString()+"'" ;
			else
				sqlstr = "select c.*,s.* from vw_Cust_Ageing c,Sales_Master s where Cust_Name='"+DropCustName.SelectedItem.Text+"' and c.Invoice_No=s.Invoice_No and cast(floor(cast(c.invoice_date as float)) as datetime)>='"+System.Convert.ToDateTime(ToMMddYYYY(txtDateFrom.Text)).ToShortDateString()+"' and cast(floor(cast(c.invoice_date as float)) as datetime)<='"+System.Convert.ToDateTime(ToMMddYYYY(Textbox1.Text)).ToShortDateString()+"'" ;
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon11);
			da.Fill(ds, "vw_Cust_Ageing");
			DataTable dtCustomers = ds.Tables["vw_Cust_Ageing"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			GridReport.DataSource = dv;
			GridReport.DataBind();
		}

		/// <summary>
		/// This method is used to sends the text file to print server to print.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
				
				MakingReport();
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\BillAgeingReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:Customer_bill_Ageing.aspx,Method:BtnPrint_Click"+"  Cusetomer Ageing Report Printed "+" EXCEPTION  "+ane.Message+" userid " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:Customer_bill_Ageing.aspx,Method:BtnPrint_Click"+"  Cusetomer Ageing Report Printed "+" EXCEPTION  "+se.Message+"  userid  " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:Customer_bill_Ageing.aspx,Method:BtnPrint_Click"+"  Cusetomer Ageing Report Printed "+"  EXCEPTION "+es.Message+"  userid " +uid);
				}
				CreateLogFiles.ErrorLog("Form:Customer_bill_Ageing.aspx,Method:BtnPrint_Click"+"  Cusetomer Ageing Report Printed "+"  " +uid);
			} 
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:Customer_bill_Ageing.aspx,Method:BtnPrint_Click"+"  Cusetomer Ageing Report Printed "+" EXCEPTION  "+es.Message+" userid "+ uid);
			}
		}

		double amount=0;
		/// <summary>
		/// This method is used to calculate the total amount.
		/// </summary>
		protected string SumAmount(string amt)
		{
			amount+=System.Convert.ToDouble(amt);
			Cache["Amount"]=amount;
			return GenUtil.strNumericFormat(amt);
		}

		/// <summary>
		/// This method is used to update the interest.
		/// </summary>
		private void Update1_Click(object sender, System.EventArgs e)
		{
			// Method to update the ineterst rate . but only by administrator.
			try
			{
				string strInterest = InterestText.Text.ToString().Trim();  
				if(strInterest.Equals(""))
				{
					MessageBox.Show("Please enter Interest Rate");
					return ;
				}
				int i=0;
				dbobj.Insert_or_Update("Update mmisc_cd set Key_Descr = '"+strInterest+"' where key_type = 'Interest'",ref i);
				MessageBox.Show("Interest Updated"); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Customer_bill_Ageing.aspx,Method:Update1_Click"+"  Cusetomer Ageing Report Printed "+" EXCEPTION  "+ex.Message+" userid "+ uid);			
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file CustomerBillAgeing.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:Customer_Bill_Ageing.aspx,Method: btnExcel_Click, Customer_Bill_Ageing Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:Customer_Bill_Ageing.aspx,Method:btnExcel_Click   Customer_Bill_Ageing Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}