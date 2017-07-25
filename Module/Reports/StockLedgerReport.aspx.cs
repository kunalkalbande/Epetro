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
	/// Summary description for StockLedgerReport.
	/// </summary>
	public class StockLedgerReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button cmdrpt;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.DropDownList drpProductName;
		protected System.Web.UI.WebControls.DropDownList drpTransType;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		protected System.Web.UI.WebControls.DataGrid Stock_Ledger;
		string uid = "";
		protected System.Web.UI.WebControls.Button btnExcel;
		string strOrderBy="";

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
				if(!Page.IsPostBack)
				{
					txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					txtDateTo.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					getProducts();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="21";
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
				CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:Page_Load"+ " EXCEPTION "  +ex.Message+"  userid  "+uid);  
			}
		}

		/// <summary>
		/// Fetches the products and pack type from products table and fills the Product Name combo.
		/// </summary>
		public void getProducts()
		{
			SqlDataReader SqlDtr = null;
			drpProductName.Items.Clear();
			drpProductName.Items.Add("Select");
               
			dbobj.SelectQuery("Select case when pack_type != '' then Prod_Name+':'+Pack_Type else Prod_Name  end from products order by Prod_Name",ref SqlDtr);
			while(SqlDtr.Read())
			{
				drpProductName.Items.Add(SqlDtr.GetValue(0).ToString());    
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
			this.cmdrpt.Click += new System.EventHandler(this.cmdrpt_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to Check the validity of filled form.
		/// </summary>
		public bool checkValidity()
		{
			string ErrorMessage = "";
			bool flag = true;
			if(drpProductName.SelectedIndex  == 0)
			{
				ErrorMessage = ErrorMessage + " - Please Select Product\n";
				flag = false;
			}
			/****
			if(drpTransType.SelectedIndex  == 0)
			{
				ErrorMessage = ErrorMessage + " - Please Select Transaction Type\n";
				flag = false;
			}
			****/
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
		/// This method is used to Return date in MM/DD/YYYY format
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
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void cmdrpt_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!checkValidity())
				{
					return;
				}
                   
				string prod_name ="";
				string pack1 = "";
				string pack2 = "";
				string trans_type ="";
				string Cat = "";
				prod_name = drpProductName.SelectedItem.Value.ToString().Trim();

				// check if product contains the package then split it into pack1 and pack2 . Incase of fuel category and Loose Oil pack the pack1 and pack2 will be 0.
				if(prod_name.LastIndexOf(":") > -1)
				{
					string[] strArr = prod_name.Split(new char[] {':'},prod_name.Length);
					prod_name = strArr[0].Trim();
					if(strArr[1].Trim().IndexOf("Loose") > -1)
					{
						pack1 = "0";
						pack2 = "0";
						Cat = "Loose";
					}
					else
					{
						string[] strPack = strArr[1].Trim().Split(new char[] {'X'} ,strArr[1].Length);
						pack1 = strPack[0].Trim();
						pack2 = strPack[1].Trim();
						Cat = "Others";
					}
                    
				}
				else
				{
					pack1 = "0";
					pack2 = "0";
					Cat = "Fuel";

				}
				trans_type = drpTransType.SelectedItem.Value.ToString().Trim();
     
				// Response.Write(prod_name+"#"+pack1+"#"+pack2+"#"+trans_type); 
				//exec sp_StockLedger 'Servo 4t',2,4,'Sales','06/12/2006','06/13/2006'
				object obj = null;
				// Calls the procedure sp_StockLedger and creates the temporary table Stock_Ledger.
				dbobj.ExecProc(OprType.Insert,"sp_stockLedger",ref obj,"@Prod_Name",prod_name,"@Pack11",pack1,"@Pack22" ,pack2,"@Trans_Type",trans_type,"@fromdate",GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim()),"@Todate",GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()),"@Cat",Cat);
				//**
				strOrderBy = "Trans_Date ASC";
				Session["Column"] = "Trans_Date";
				Session["Order"] = "ASC";
				BindTheData();
				//**
				//               SqlDataReader SqlDtr = null;
				//
				//               dbobj.SelectQuery("Select * from Stock_Ledger order by trans_date ",ref SqlDtr);
				//				if(SqlDtr.HasRows)
				//				{
				//					Stock_Ledger.Visible = true;
				//					Stock_Ledger.DataSource = SqlDtr;
				//					Stock_Ledger.DataBind();
				//				}
				//				else
				//				{
				//					Stock_Ledger.Visible = false;
				//					MessageBox.Show("Data not available" );
				//				}
				//				SqlDtr.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:cmdrpt_Click"+ " EXCEPTION "  +ex.Message+"  userid  "+uid); 
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="Select * from Stock_Ledger order by trans_date";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "Stock_Ledger");
			DataTable dtCustomers = ds.Tables["Stock_Ledger"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				Stock_Ledger.DataSource = dv;
				Stock_Ledger.DataBind();
				Stock_Ledger.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				Stock_Ledger.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This is calls from the .aspx page to check , if the value is zero then return &nbsp to display the space in grid.;
		/// </summary>
		public string checkValue(string str)
		{
			if(str.Equals("0")|| str == null)
			{
				return "&nbsp;";
			}
			return str;
		}

		/// <summary>
		/// This is calls from the btnPrint_Click page to check , if the value is zero then return "" to display the blank value in report file.;
		/// </summary>
		public string checkValue1(string str)
		{
			if(str.Equals("0")|| str == null)
			{
				return "";
			}
			return str;
		}

		/// <summary>
		/// Its fires the sp_StockLedger procedure and fetch the values from Stock_Ledger Report and writes the return values into StockLedgerReport.txt file.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{

			if(!checkValidity())
			{
				return;
			}
			/*
								   =================================================
								   Stock Ledger Report From mm/dd/yyyy To mm/dd/yyyy
								   =================================================

			Product Name     : Petrol(MS)
			Transaction Type : Sales
			+----------------------+-----+----------+------------+------------+------------+ 
			|                      |     |          |     IN     |    OUT     |CLOSING BAL.|
			|    Transaction       |Trans|   Date   |----+-------|----+-------|----+-------|
			|       Type           |  ID |          |Qty.|Qty. in|Qty.|Qty. in|Bal.|Bal. in|
			|                      |     |          |Nos |  Ltr. |Nos |  Ltr. |Nos |  Ltr. |
			+----------------------+-----+----------+----+-------+----+-------+----+-------+
			 Opening Balance        1001  mm/dd/yyyy 1234 1234567 1234 1234567 1234 1234567
			 Closing Balance       
			 Purchase Invoice      
			 Stock Adjustment(OUT) 
			 123456789012345678|
			+----------------------+-----+----------+----+-------+----+-------+----+-------+
			*/

			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\StockLedgerReport.txt";
				StreamWriter sw = new StreamWriter(path);
				string info = "";


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
				string des="-----------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("=================================================",des.Length));  
				sw.WriteLine(GenUtil.GetCenterAddr("Stock Ledger Report From "+txtDateFrom.Text.Trim()+" To "+txtDateTo.Text.Trim(),des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("=================================================",des.Length));
				sw.WriteLine("");
				sw.WriteLine("Product Name     : "+drpProductName.SelectedItem.Value);
				sw.WriteLine("Transaction Type : "+drpTransType.SelectedItem.Value);
				sw.WriteLine("+----------------------+-------+----------+------------------+------------------+-------------------+");
				sw.WriteLine("|                      |       |          |        IN        |       OUT        |    CLOSING BAL.   |");
				sw.WriteLine("|    Transaction       | Trans |   Date   |-------+----------|-------+----------|--------+----------|");
				sw.WriteLine("|       Type           |   ID  |          |  Qty. | Qty. in  |  Qty. | Qty. in  |  Bal.  | Bal. in  |");
				sw.WriteLine("|                      |       |          |  Nos  |   Ltr.   |  Nos  |   Ltr.   |  Nos   |   Ltr.   |"); 
				sw.WriteLine("+----------------------+-------+----------+-------+----------+-------+----------+--------+----------+");
				//  123456789012345678901 1001        mm/dd/yyyy 12345678 12345678 12345678 12345678
				info = " {0,-22:S} {1,-7:S} {2,-10:S} {3,7:F} {4,10:F} {5,7:F} {6,10:F} {7,8:F} {8,10:F}";

				string prod_name ="";
				string pack1 = "";
				string pack2 = "";
				string trans_type ="";
				string Cat = "";
				prod_name = drpProductName.SelectedItem.Value.ToString().Trim();
				if(prod_name.LastIndexOf(":") > -1)
				{
					string[] strArr = prod_name.Split(new char[] {':'},prod_name.Length);
					prod_name = strArr[0].Trim();
					if(strArr[1].Trim().IndexOf("Loose") > -1)
					{
						pack1 = "0";
						pack2 = "0";
						Cat = "Loose";
					}
					else
					{
						string[] strPack = strArr[1].Trim().Split(new char[] {'X'} ,strArr[1].Length);
						pack1 = strPack[0].Trim();
						pack2 = strPack[1].Trim();
						Cat = "Others";
					}
                    
				}
				else
				{
					pack1 = "0";
					pack2 = "0";
					Cat = "Fuel";

				}
				int f = 0;
				trans_type = drpTransType.SelectedItem.Value.ToString().Trim();
				object obj = null;
				dbobj.ExecProc(OprType.Insert,"sp_stockLedger",ref obj,"@Prod_Name",prod_name,"@Pack11",pack1,"@Pack22" ,pack2,"@Trans_Type",trans_type,"@fromdate",GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim()),"@Todate",GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()),"@Cat",Cat );
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("Select * from Stock_Ledger order by "+Cache["strOrderBy"]+"",ref SqlDtr);
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,GenUtil.TrimLength(SqlDtr.GetValue(0).ToString(),22),
							SqlDtr.GetValue(1).ToString(),
							GenUtil.str2MMDDYYYY(trimDate(SqlDtr.GetValue(2).ToString())),
							GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(3).ToString())),
							GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(4).ToString())),
							GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(5).ToString())),
							GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(6).ToString())),
							GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(7).ToString())),
							GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(8).ToString())));
					} 
				}
				else
				{
					Stock_Ledger.Visible = false;
					f = 1;
					sw.Close(); 
					MessageBox.Show("Data not available" );
					return;
				}
				SqlDtr.Close(); 
				sw.WriteLine("+----------------------+-------+----------+-------+----------+-------+----------+--------+----------+");
				SqlDtr.Close();
				sw.Close(); 
				if(f == 0)
					Print(); 
				else
					return; 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:btnPrint_Click"+ " EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		
		}
		
		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			//string sql="";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\StockLedgerReport.xls";
			StreamWriter sw = new StreamWriter(path);
			string prod_name ="";
			string pack1 = "";
			string pack2 = "";
			string trans_type ="";
			string Cat = "";
			prod_name = drpProductName.SelectedItem.Value.ToString().Trim();
			if(prod_name.LastIndexOf(":") > -1)
			{
				string[] strArr = prod_name.Split(new char[] {':'},prod_name.Length);
				prod_name = strArr[0].Trim();
				if(strArr[1].Trim().IndexOf("Loose") > -1)
				{
					pack1 = "0";
					pack2 = "0";
					Cat = "Loose";
				}
				else
				{
					string[] strPack = strArr[1].Trim().Split(new char[] {'X'} ,strArr[1].Length);
					pack1 = strPack[0].Trim();
					pack2 = strPack[1].Trim();
					Cat = "Others";
				}
                    
			}
			else
			{
				pack1 = "0";
				pack2 = "0";
				Cat = "Fuel";

			}
			trans_type = drpTransType.SelectedItem.Value.ToString().Trim();
			object obj1 = null;
			dbobj.ExecProc(OprType.Insert,"sp_stockLedger",ref obj1,"@Prod_Name",prod_name,"@Pack11",pack1,"@Pack22" ,pack2,"@Trans_Type",trans_type,"@fromdate",GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim()),"@Todate",GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()),"@Cat",Cat );
			SqlDataReader SqlDtr = null;
			dbobj.SelectQuery("Select * from Stock_Ledger order by "+Cache["strOrderBy"]+"",ref SqlDtr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+txtDateTo.Text);
			sw.WriteLine("Product Name\t"+drpProductName.SelectedItem.Value);
			sw.WriteLine("Transaction Type\t"+drpTransType.SelectedItem.Value);
			sw.WriteLine("Transaction Type\tTrans ID\tDate\tIN (Qty Nos)\tIN (Qty Ltr)\tOUT (Qty Nos)\tOUT (Qty Ltr)\tClosing Bal(Nos)\tClosing Bal(Ltr)");
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					sw.WriteLine(SqlDtr.GetValue(0).ToString()+"\t"+
						SqlDtr.GetValue(1).ToString()+"\t"+
						GenUtil.str2MMDDYYYY(trimDate(SqlDtr.GetValue(2).ToString()))+"\t"+
						GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(3).ToString()))+"\t"+
						GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(4).ToString()))+"\t"+
						GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(5).ToString()))+"\t"+
						GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(6).ToString()))+"\t"+
						GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(7).ToString()))+"\t"+
						GenUtil.strNumericFormat(checkValue1(SqlDtr.GetValue(8).ToString())));
				} 
			}
			SqlDtr.Close(); 
			dbobj.Dispose();
			sw.Close();
		}
		/// <summary>
		/// This method is used to return date in without timing.
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
		/// This method is used to Contacts the server and sends the StockLedgerReport.txt file name to print.
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
					CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\StockLedgerReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:print. Report Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());

					 
					CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:print  EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Stock_Ledger.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method: btnExcel_Click, StockLedger Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:StockLedgerReport.aspx,Method:btnExcel_Click   StockLedger Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}