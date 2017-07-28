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
	/// Summary description for CreditFleetCardSalesReport.
	/// </summary>
	public class CreditFleetCardSalesReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateFrom;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateTo;
		protected System.Web.UI.WebControls.DropDownList DropSalesType;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DataGrid GridSalesReport;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		string strOrderBy="";

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required textboxes values 
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
				CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method:page_load  EXCEPTION "+ es.Message+" userid "+  uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="34";
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
		/// This function return date mm/dd/yyyy format.
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
		/// This method is used to show the data in datagrid with the help of BindTheData() function.
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
					#endregion
				}
				CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method:btnShow_Click  CreditFleetCardSales Report   Viewed "+"  userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SaleBook.aspx,Method:btnShow_Click  CreditFleetCardSales Report   Viewed "+"  EXCEPTION  "+ ex.Message+"  userid  "+uid);
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
			if(DropSalesType.SelectedItem.Text.Equals("Combine Sales"))
				//sqlstr="select * from vw_CreditFleetCardSales where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				sqlstr="select * from vw_SaleBook where (Sales_Type='Credit Card Sale' or Sales_Type='Fleet Card Sale') and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			else
				//sqlstr="select * from vw_CreditFleetCardSales where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				sqlstr="select * from vw_SaleBook where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
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
		private string GetString(string str,int maxlen,string spc)
		{
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
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
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CreditFleetCardSalesReport.txt";
				StreamWriter sw = new StreamWriter(path);
				string strDate="";
				string strDueDate="";
				string promo = "";
				//				if(DropSalesType.SelectedItem.Text.Equals("Combine Sales"))
				//					sql="select * from vw_CreditFleetCardSales where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				//				else
				//					sql="select * from vw_CreditFleetCardSales where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				//sql="select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast (invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				if(DropSalesType.SelectedItem.Text.Equals("Combine Sales"))
					sql="select * from vw_SaleBook where (Sales_Type='Credit Card Sale' or Sales_Type='Fleet Card Sale') and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				else
					sql="select * from vw_SaleBook where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
				sql=sql+" order by "+Cache["SalesBook"];
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
				sw.WriteLine("Sales Type : "+DropSalesType.SelectedItem.Text.ToString());
				//sw.WriteLine("+----+--------------------+---------------+-------------+------+----------+--------------------+----------+---------------+--------+------+--------+--------------------+----+----------+");
				//sw.WriteLine("|Cust|  Customer Name     |     City      |Customer Type|Inv.No|Inv. Date |   Under Salesman   |Pack. Type| Product Name  |Quantity| Rate |Discount|    Promo Scheme    |Cr. | Due Date |");
				//sw.WriteLine("| ID |                    |               |             |      |          |                    |          |               |        |      |        |                    |Days|          |");
				//sw.WriteLine("+----+--------------------+---------------+-------------+------+----------+--------------------+----------+---------------+--------+------+--------+--------------------+----+----------+"); 
				// 1234 12345678901234567890 123456789012345 1234567890123 123456 1234567890 12345678901234567890 1234567890 123456789012345 12345678 123456 12345678 12345678901234567890 1234 1234567890
			
				sw.WriteLine("+-------------+---------+---------+-----+----------+--------------+---------+------------+--------+------+----+---------+----+----------+");
				sw.WriteLine("|Customer Name|  Place  |Customer |Invo.| Invoice  |Under Salesman|  Pack.  |Product Name|Quantity|Price |Disc| Invoice |Cr. | Due Date |");
				sw.WriteLine("|             |         |Category | No  |  Date    |              |  Type   |            | in ltr.|      |ount| Amount  |Days|          |");
				sw.WriteLine("+-------------+---------+---------+-----+----------+--------------+---------+------------+--------+------+----+---------+----+----------+"); 
				//			   1234567890123 123456789 123456789 12345 1234567890 12345678901234 123456789 123456789012 12345678 123456 1234 123456789 1234 1234567890
				if(rdr.HasRows)
				{
					// info : to set the string format.
					//info = " {0,-4:S} {1,-20:S} {2,-15:S} {3,-13:S} {4,-6:S} {5,-10:S} {6,-20:S} {7,-10:S} {8,-15:S} {9,-8:S} {10,6:F} {11,-8:S} {12,-20:S} {13,-4:S} {14,-10:S}";
					info = " {0,-13:S} {1,-9:S} {2,-9:S} {3,-5:S} {4,-10:S} {5,-14:S} {6,-9:S} {7,-12:S} {8,8:S} {9,6:F} {10,4:S} {11,9:S} {12,4:S} {13,-10:S}";
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
							GenUtil.TrimLength(rdr["City"].ToString().Trim(),9),
							GenUtil.TrimLength(rdr["Cust_Type"].ToString().Trim(),9),
							rdr["Invoice_No"].ToString().Trim(),
							GenUtil.str2DDMMYYYY(strDate),
							GenUtil.TrimLength(rdr["Under_SalesMan"].ToString().Trim(),14),
							GenUtil.TrimLength(rdr["Pack_Type"].ToString().Trim(),9),
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
				
				sw.WriteLine("+-------------+---------+---------+-----+----------+--------------+---------+------------+--------+------+----+---------+----+----------+");
				sw.WriteLine(info,"  Total","","","","","","","",GenUtil.strNumericFormat(Cache["os"].ToString()),"","",GenUtil.strNumericFormat(Cache["amt"].ToString()),"","");
				sw.WriteLine("+-------------+---------+---------+-----+----------+--------------+---------+------------+--------+------+----+---------+----+----------+");

		
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
			string path = home_drive+@"\ePetro_ExcelFile\CreditFleetCardSalesReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			string strDate="";
			string strDueDate="";
			string promo = "";
			//			if(DropSalesType.SelectedItem.Text.Equals("Combine Sales"))
			//				sql="select * from vw_CreditFleetCardSales where cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			//			else
			//				sql="select * from vw_CreditFleetCardSales where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			if(DropSalesType.SelectedItem.Text.Equals("Combine Sales"))
				sql="select * from vw_SaleBook where (Sales_Type='Credit Card Sale' or Sales_Type='Fleet Card Sale') and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			else
				sql="select * from vw_SaleBook where Sales_Type='"+DropSalesType.SelectedItem.Text+"' and cast(floor(cast(invoice_date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			sql=sql+" order by "+Cache["SalesBook"];
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+Textbox1.Text);
			sw.WriteLine("Sales Type\t"+DropSalesType.SelectedItem.Text.ToString());
			sw.WriteLine("Customer Name\tPlace\tCustomer Category\tInvoice No\tInvoice Date\tUnder Salesman\tPack. Type\tProduct Name\tQuantity In Ltr\tPrice\tDiscount\tInvoice Amount\tCr. Days\tDue Date");
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
						rdr["City"].ToString().Trim()+"\t"+
						rdr["Cust_Type"].ToString().Trim()+"\t"+
						rdr["Invoice_No"].ToString().Trim()+"\t"+
						GenUtil.str2DDMMYYYY(strDate)+"\t"+
						rdr["Under_SalesMan"].ToString().Trim()+"\t"+
						rdr["Pack_Type"].ToString().Trim()+"\t"+
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
		/// This method is used to sends the text file to print server to print.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CreditFleetCardSalesReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method:BtnPrint_Click   CreditFleetCardSales Report   userid  "+uid);
					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method:BtnPrint_Click, CreditFleetCardSales Report Printed    EXCEPTION  "+ ane.Message+" userid  "+  uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method:BtnPrint_Click, CreditFleetCardSales Report Printed  EXCEPTION  "+ se.Message+"  userid  "+  uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
	
					CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method:BtnPrint_Click, CreditFleetCardSales Report Printed   EXCEPTION "+es.Message+"  userid  "+  uid);
				}

			} 
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method:BtnPrint_Click, CreditFleetCardSales Report Printed  EXCEPTION   "+ es.Message+"  userid  "+  uid);
			}
		}
		
		double amt=0,amt1=0,amt2=0;
		int count=0,i=0,status=0,Flag=0;
		/// <summary>
		/// This method is used to check the invoice no and return "---" and in last return invoice amount.
		/// </summary>
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
				os1 = System.Convert.ToDouble( mystr[1].ToString())*1000;
				os+=System.Convert.ToDouble( mystr[1].ToString())*1000;
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
		/// This method is used to prepares the excel report file CreditFleetCardSalesReport.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridSalesReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method: btnExcel_Click, CreditFleetCardSales Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:CreditFleetCardSalesReport.aspx,Method:btnExcel_Click   CreditFleetCardSales Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}