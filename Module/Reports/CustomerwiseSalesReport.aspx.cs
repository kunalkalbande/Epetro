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
using RMG;
using EPetro.Sysitem.Classes;
using System.Data.SqlClient;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for CustomerwiseSalesReport.
	/// </summary>
	public class CustomerwiseSalesReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateFrom;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateTo;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.DataGrid GridReport;
		protected System.Web.UI.WebControls.DropDownList DropCategory;
		protected System.Web.UI.WebControls.DropDownList DropType;
		protected System.Web.UI.WebControls.CompareValidator cvProductGroup;
		protected System.Web.UI.WebControls.ValidationSummary vsCustWiseSales;
		protected System.Web.UI.WebControls.CompareValidator cvCustCat;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		string uid="";
		protected System.Web.UI.WebControls.Button btnExcel;
		string strOrderBy="";
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
				// Put user code to initialize the page here
				if(!IsPostBack)
				{
					txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					Textbox1.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="19";
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
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerwiseSalesReport.aspx,Method:page_load"+ "  EXCEPTION "+ex.Message+"  userid  "+uid);
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
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
		/// This method is used to view the report and set the session variable for ascending or descending the record.
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
					//PetrolPumpClass  obj=new PetrolPumpClass();
					//SqlDataReader SqlDtr;
					//string sql;

					#region Bind DataGrid
					strOrderBy = "Cust_Name DESC";
					Session["Column"] = "Cust_Name";
					Session["Order"] = "DESC";
					BindTheData();
					/*
					sql="select * from vw_CustWiseSales where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(invoice_date as float)) as datetime) <='"+ ToMMddYYYY(Textbox1.Text).ToShortDateString() +"'";
					if(DropCategory.SelectedIndex!=0)
						sql=sql+ " and Prod_Type='"+ DropCategory.SelectedItem.Value +"'"; 
					if(DropType.SelectedIndex!=0)
						sql=sql+ " and Cust_Type='"+ DropType.SelectedItem.Value +"'";
					//Response.Write(sql); 
					SqlDtr =obj.GetRecordSet(sql);
					GridReport.DataSource=SqlDtr;
					GridReport.DataBind();
					if(GridReport.Items.Count==0)
					{
						MessageBox.Show("Data not available");
						GridReport.Visible=false;
					}
					else
					{
						GridReport.Visible=true;
					}
					SqlDtr.Close();
					*/
					#endregion
				}
				CreateLogFiles.ErrorLog("Form:CustomerWiseSalseReport,Method: btnShow_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Viewed "+ " userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerWiseSalseReport,Method: btnShow_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Viewed "+"   EXCEPTION   "+ex.Message+ " userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sql="";
			sql="select c.*,s.* from vw_CustWiseSales c,Sales_Master s where c.Invoice_No=s.Invoice_No and cast(floor(cast(c.invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(c.invoice_date as float)) as datetime) <='"+ ToMMddYYYY(Textbox1.Text).ToShortDateString() +"'";
			if(DropCategory.SelectedIndex!=0)
				sql=sql+ " and Prod_Type='"+ DropCategory.SelectedItem.Value +"'"; 
			if(DropType.SelectedIndex!=0)
				sql=sql+ " and Cust_Type='"+ DropType.SelectedItem.Value +"'";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sql, SqlCon);
			da.Fill(ds, "vw_CustWiseSales");
			DataTable dtCustomers = ds.Tables["vw_CustWiseSales"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridReport.DataSource = dv;
				GridReport.DataBind();
				GridReport.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:CustomerwiseSalesReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void MakingReport()
		{
			/*
												  ==========================                          
													CUSTOMER SALES REPORT                                    
												  ==========================                    
			+-------+-------------------------+----------+------+----------+--------------------+---------------+-----+---------+
			|Cust.ID|  Cutomer Name           |  Place   |Inv.No|Inv.Date  | Under Salesman     | Prod.Name     | Qty |  Price  |
			+-------+-------------------------+----------+------+----------+--------------------+---------------+-----+---------+
			 1234    1234567890123456789012345 1234567890 1234   DD/MM/YYYY 12345678901234567890 123456789012345 12345 123456.00
			+-------+-------------------------+----------+------+----------+--------------------+---------------+-----+---------+
			 */   
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CustomerReport.txt";
			StreamWriter sw = new StreamWriter(path);
			string sql="";
			string strDate = "";
			string info ="";
			
			//sql="select * from vw_CustWiseSales where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(invoice_date as float)) as datetime) <='"+ ToMMddYYYY(Textbox1.Text).ToShortDateString() +"'";
			sql="select c.*,s.* from vw_CustWiseSales c,Sales_Master s where c.Invoice_No=s.Invoice_No and cast(floor(cast(c.invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(c.invoice_date as float)) as datetime) <='"+ ToMMddYYYY(Textbox1.Text).ToShortDateString() +"'";
				
			if(DropCategory.SelectedIndex!=0)
				sql=sql+ " and Prod_Type='"+ DropCategory.SelectedItem.Value +"'"; 
			if(DropType.SelectedIndex!=0)
				sql=sql+ " and Cust_Type='"+ DropType.SelectedItem.Value +"'";
			sql=sql+" order by "+Cache["strOrderBy"].ToString()+"";
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
			string des="-------------------------------------------------------------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("========================================================",133));
			sw.WriteLine(GenUtil.GetCenterAddr("CUSTOMER WISE SALES REPORT FROM "+txtDateFrom.Text+" TO "+Textbox1.Text,133));
			sw.WriteLine(GenUtil.GetCenterAddr("========================================================",133));
			sw.WriteLine(" Product Group    : "+DropCategory.SelectedItem.Value);
			sw.WriteLine(" Customer Category: "+DropType.SelectedItem.Value);
			sw.WriteLine("+-------------------------+---------+---------------+------+----------+--------------------+--------------------+--------+------------+");
			sw.WriteLine("|     Cutomer Name        | Slip No |     Place     |Inv.No| Inv.Date |   Under Salesman   |      Prod.Name     |   Qty  |   Amount   |");
			sw.WriteLine("+-------------------------+---------+---------------+------+----------+--------------------+--------------------+--------+------------+");
			//             1234567890123456789012345 123456789 123456789012345 123456 1234567890 12345678901234567890 12345678901234567890 12345678 123456789012

			if(rdr.HasRows)
			{
				// info : to displays the each field in different format.
				info = " {0,-25:S} {1,9:S} {2,-15:D} {3,-6:S} {4,-10:S} {5,-20:S} {6,-20:F} {7,8:F} {8,12:F}";
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
					sw.WriteLine(info,GenUtil.TrimLength(rdr["Cust_Name"].ToString().Trim(),25),
						GenUtil.TrimLength(rdr["slip_no"].ToString(),9),
						GenUtil.TrimLength(rdr["Place"].ToString(),15),
						rdr["Invoice_No"].ToString().Trim(),
						strDate,
						GenUtil.TrimLength(rdr["Under_SalesMan"].ToString().Trim(),20),
						GenUtil.TrimLength(strTrim(rdr["Prod_Name"].ToString().Trim()),20),
						//rdr["Qty"].ToString().Trim(),
						GenUtil.strNumericFormat((Multiply(rdr["Prod_Name"].ToString()+"X"+rdr["Qty"])).ToString()),
						//rdr["Rate"].ToString().Trim()						              
						setAmt(rdr["rate"].ToString(),rdr["Invoice_No"].ToString())
						);
				}
			}
			
			sw.WriteLine("+-------------------------+---------+---------------+------+----------+--------------------+--------------------+--------+------------+");
			sw.WriteLine(info," Total ","","","","","","",GenUtil.strNumericFormat(Cache["os"].ToString()),GenUtil.strNumericFormat(Cache["Invoice_Amt"].ToString()));
			sw.WriteLine("+-------------------------+---------+---------------+------+----------+--------------------+--------------------+--------+------------+");
			// deselect Condensed
			//sw.Write((char)18);
			//sw.Write((char)12);
			sw.Close(); 	
		}
		
		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string sql="",strDate="";;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\CustomerWiseSalesReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			//sql="select * from vw_CustWiseSales where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(invoice_date as float)) as datetime) <='"+ ToMMddYYYY(Textbox1.Text).ToShortDateString() +"'";
			sql="select c.*,s.* from vw_CustWiseSales c,Sales_Master s where c.Invoice_No=s.Invoice_No and cast(floor(cast(c.invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(c.invoice_date as float)) as datetime) <='"+ ToMMddYYYY(Textbox1.Text).ToShortDateString() +"'";
			if(DropCategory.SelectedIndex!=0)
				sql=sql+ " and Prod_Type='"+ DropCategory.SelectedItem.Value +"'"; 
			if(DropType.SelectedIndex!=0)
				sql=sql+ " and Cust_Type='"+ DropType.SelectedItem.Value +"'";
			sql=sql+" order by "+Cache["strOrderBy"].ToString()+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+Textbox1.Text);
			sw.WriteLine("Product Group\t"+DropCategory.SelectedItem.Value);
			sw.WriteLine("Customer Category\t"+DropType.SelectedItem.Value);
			sw.WriteLine("Cutomer Name\tSlip NO\tPlace\tInv.No\tInv.Date\tUnder Salesman\tProd.Name\tQty\tPrice");

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
					sw.WriteLine(rdr["Cust_name"].ToString().Trim()+"\t"+
						rdr["Slip_no"].ToString().Trim()+"\t"+
						rdr["Place"].ToString()+"\t"+
						rdr["Invoice_No"].ToString().Trim()+"\t"+
						strDate+"\t"+
						rdr["Under_SalesMan"].ToString().Trim()+"\t"+
						strTrim(rdr["Prod_Name"].ToString().Trim())+"\t"+
						GenUtil.strNumericFormat((Multiply(rdr["Prod_Name"].ToString()+"X"+rdr["Qty"])).ToString())+"\t"+
						setAmt(rdr["rate"].ToString(),rdr["Invoice_No"].ToString())
						);
				}
			}
			sw.WriteLine("Total\t\t\t\t\t\t\t"+GenUtil.strNumericFormat(Cache["os"].ToString())+"\t"+GenUtil.strNumericFormat(Cache["Invoice_Amt"].ToString()));
			rdr.Close();
			sw.Close();
		}

		/// <summary>
		/// This function to trim the spaces according to length. 
		/// </summary>
		public string strTrim(string str)
		{
			if(str.Length > 15)
			{
				str = str.Substring(0,15); 
			}
			return str;
		}
		
		/// <summary>
		/// This method is not used.
		/// </summary>
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6,ref int len7,ref int len8,ref int len9,ref int len10)
		{
			while(rdr.Read())
			{
				if(rdr["Cust_ID"].ToString().Trim().Length>len1)
					len1=rdr["Cust_ID"].ToString().Trim().Length;					
				if(rdr["Cust_Name"].ToString().Trim().Length>len2)
					len2=rdr["Cust_Name"].ToString().Trim().Length;					
				if(rdr["Place"].ToString().Trim().Length>len3)
					len3=rdr["Place"].ToString().Trim().Length;
						
				if(rdr["Invoice_No"].ToString().Trim().Length>len4)
					len4=rdr["Invoice_No"].ToString().Trim().Length;					
				if(rdr["Invoice_Date"].ToString().Trim().Length>len5)
					len5=rdr["Invoice_Date"].ToString().Trim().Length;					
				if(rdr["Under_SalesMan"].ToString().Trim().Length>len6)
					len6=rdr["Under_SalesMan"].ToString().Trim().Length;	
				
				if(rdr["Rate"].ToString().Trim().Length>len10)
					len10=rdr["Rate"].ToString().Trim().Length;	
			}
		}

		/// <summary>
		/// This method is used to Sends the text file to print server to print.
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
					CreateLogFiles.ErrorLog("Form:CustomerWiseSalseReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  userid  "+uid);
					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CustomerReport.txt<EOF>");

					// Send the data through the socket.http://localhost/EPetro/Forms/Reports/NozzleReport.aspx
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
					CreateLogFiles.ErrorLog("Form:CustomerWiseSalseReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  EXCEPTION   "+ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerWiseSalseReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  EXCEPTION   "+se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerWiseSalseReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  EXCEPTION   "+es.Message+"  userid  "+uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:CustomerWiseSalseReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This Method multiplies the package quantity with Quantity.
		/// and calculate the total amount of invoice amount and qty in Lit's.
		/// </summary>
		public double os=0;
		protected double Multiply(string str)
		{
			//*******
			string[] str1=str.Split(new char[] {':'},str.Length);
			//*******
			string[] mystr=str1[1].Split(new char[]{'X'},str1[1].Length);
			// check the package type is loose or not.
			if(str.Trim().IndexOf("Loose") == -1)
			{
				double ans=1;
				foreach(string val in mystr)
				{
					if(val.Length>0 && !val.Trim().Equals(""))
						ans*=double.Parse(val,System.Globalization.NumberStyles.Float);
				}
				//******
				os+=ans;
				Cache["os"] = System.Convert.ToString(os);
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
					return 0;
			}
		}
		
		/// <summary>
		/// To calculate the sum of total amount when view in footer part in the datagrid..
		/// </summary>
		public double Invoice_Amt=0;
		double amt=0,amt1=0,amt2=0;
		int count=0,i=0,status=0,Flag=0;
		protected string setAmt(string _Amount,string invoice_no)
		{
			PetrolPumpClass  obj=new PetrolPumpClass();
			SqlDataReader SqlDtr;
			string sql;
			if(Flag==0)
			{
				Cache["Invoice_No"]=invoice_no;
				Flag=1;
			}
			else if(Flag==3)
			{
				Cache["Invoice_No"] = invoice_no;
			}
			if(status==0)
			{
				sql = "select count(*) from vw_CustWiseSales where Invoice_No="+Cache["Invoice_No"].ToString()+"";
				SqlDtr =obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
					count=int.Parse(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
				status=1;
			}
			if(i<count)
			{
				amt += double.Parse(_Amount);
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
				Cache["Invoice_Amt"]=System.Convert.ToString(amt2);
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
				return "---   ";
			else if(Flag==3)
				return GenUtil.strNumericFormat(amt1.ToString());
			return "";
		}

		/// <summary>
		/// This method is used to prepares the excel report file CustomerWiseSalesReport.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:CustomerWiseSalesReport.aspx,Method: btnExcel_Click, CustomerWiseSalesReport Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:CustomerWiseSalesReport.aspx,Method:btnExcel_Click   CustomerWiseSalesReport Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}

		//		//To calculate the sum of total amount when view in footer part in the datagrid..
		//		public double Invoice_Amt=0;
		//		protected string setAmt(string _Amount,string invoice_no)
		//		{
		//			Invoice_Amt += double.Parse(_Amount);
		//			Cache["Invoice_Amt"]=System.Convert.ToString(Invoice_Amt);
		//			return _Amount;
		//		}
	}
}