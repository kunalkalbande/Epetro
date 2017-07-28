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
	/// Summary description for PurchaseBook.
	/// </summary>
	public class PurchaseBook : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateTo;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.DataGrid GridReport;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.ValidationSummary vsPurchaseOrder;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnExcel;
		public string totinv_no="";

		/// <summary>
		/// This method is used for setting the Session variable for userId
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaseBook.aspx,Method:pageload"+ ex.Message+"  EXCEPTION  userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
                txtDateFrom.Attributes.Add("readonly", "readonly");
                Textbox1.Attributes.Add("readonly", "readonly");
                #region Check Privileges
                int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="9";
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
		/// This function return to date mm/dd/yyyy format.
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
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		# region Show Report Button...
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
					#region Bind DataGrid
					strOrderBy = "Invoice_No ASC";
					Session["Column"] = "Invoice_No";
					Session["Order"] = "ASC";
					BindTheData();
					//				sql="(select * from vw_PurchaseBook1 where cast(floor(cast(invoice_date as float)) as datetime) >=  '"+ ToMMddYYYY(txtDateFrom.Text) +"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+ ToMMddYYYY(Textbox1.Text)+"') union (select * from vw_PurchaseBook2 where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(invoice_date as float)) as datetime)<= '"+ ToMMddYYYY(Textbox1.Text)+"')";		
					//
					//				SqlDtr =obj.GetRecordSet(sql);
					//				GridReport.DataSource=SqlDtr;
					//				GridReport.DataBind();
					//				totinv_no="1";
					//				if(GridReport.Items.Count==0)
					//				{
					//					MessageBox.Show("Data not available");
					//					GridReport.Visible=false;
					//				}
					//				else
					//				{
					//				   GridReport.Visible=true;
					//				}
					//				SqlDtr.Close();
					#endregion
				}
				CreateLogFiles.ErrorLog("Form:PurchaseBook.aspx,Method:btnShow_Click,Class:DbOperation_LETEST.cs ,   Purchase Book Report Viewed  usrid  "+uid );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaseBook.aspx,Method:btnShow_Click,Class:DbOperation_LETEST.cs , Purchase Book Report Viewed  EXCEPTION  " + ex.Message+" userid "+uid);
			}
		}
		#endregion 

		/// <summary>
		/// This methos is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="(select * from vw_PurchaseBook1 where cast(floor(cast(invoice_date as float)) as datetime) >=  '"+ ToMMddYYYY(txtDateFrom.Text) +"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+ ToMMddYYYY(Textbox1.Text)+"') union (select * from vw_PurchaseBook2 where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(invoice_date as float)) as datetime)<= '"+ ToMMddYYYY(Textbox1.Text)+"')";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "vw_PurchaseBook1");
			DataTable dtCustomers = ds.Tables["vw_PurchaseBook1"];
			Cache["totinv_no"]="1";
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["PurchaseBook"]=strOrderBy;
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
				CreateLogFiles.ErrorLog("Form:PurchaseBook.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to calculate total invoice no.
		/// </summary>
		public void totalinvoiceno()
		{
			PetrolPumpClass  obj=new PetrolPumpClass();
			SqlDataReader SqlDtr;
			string sql;
			//int count1=0;
			sql="(select count(Invoice_No) from vw_PurchaseBook1 where cast(floor(cast(invoice_date as float)) as datetime) >=  '"+ ToMMddYYYY(txtDateFrom.Text) +"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+ ToMMddYYYY(Textbox1.Text)+"') union (select * from vw_PurchaseBook2 where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(invoice_date as float)) as datetime)<= '"+ ToMMddYYYY(Textbox1.Text)+"')";		

			SqlDtr =obj.GetRecordSet(sql);
			/*
			while(
			if(count>0)
			{
				Cache["totin_no"]=count;
			}
			*/
			SqlDtr.Close();
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
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6,ref int len7,ref int len8,ref int len9,ref int len10,ref int len11,ref int len12,ref int len13)
		{
			while(rdr.Read())
			{
				if(rdr["Vendor_ID"].ToString().Trim().Length>len1)
					len1=rdr["Vendor_ID"].ToString().Trim().Length;					
				if(rdr["Vendor_Name"].ToString().Trim().Length>len2)
					len2=rdr["Vendor_Name"].ToString().Trim().Length;					
				if(rdr["Place"].ToString().Trim().Length>len3)
					len3=rdr["Place"].ToString().Trim().Length;
				if(rdr["Vendor_Type"].ToString().Trim().Length>len4)
					len4=rdr["Vendor_Type"].ToString().Trim().Length;					
				if(rdr["Invoice_No"].ToString().Trim().Length>len5)
					len5=rdr["Invoice_No"].ToString().Trim().Length;					
				if(rdr["Invoice_Date"].ToString().Trim().Length>len6)
					len6=rdr["Invoice_Date"].ToString().Trim().Length;	
				if(rdr["Prod_Type"].ToString().Trim().Length>len7)
					len7=rdr["Prod_Type"].ToString().Trim().Length;	
				if(rdr["Prod_Name"].ToString().Trim().Length>len8)
					len8=rdr["Prod_Name"].ToString().Trim().Length;	
				if(rdr["Qty"].ToString().Trim().Length>len9)
					len9=rdr["Qty"].ToString().Trim().Length;	
				if(rdr["Price"].ToString().Trim().Length>len10)
					len10=rdr["Price"].ToString().Trim().Length;	
				if(rdr["Discount"].ToString().Trim().Length>len11)
					len11=rdr["Discount"].ToString().Trim().Length;	
				if(rdr["Promo_Scheme"].ToString().Trim().Length>len12)
					len12=rdr["Promo_Scheme"].ToString().Trim().Length;	
				if(rdr["Cr_Days"].ToString().Trim().Length>len13)
					len13=rdr["Cr_Days"].ToString().Trim().Length;	
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
		/// This method is used to prepare the report file .txt.
		/// </summary>
		public void makingReport()
		{
			/*
														 =================================================
														 PURCHASE BOOK REPORT From 01/07/2006 To 9/7/2006
														 =================================================
+------+-------------------------+---------------+-----------+------+----------+------------+-------------------------+--------+-----------+--------+--------------------+-------+----------+
|Ven.ID|      Vendor Name        |    Place      |Vendor Type|Inv.No|Inv. Date |Product Type|      Product Name       |Quantity|  Price    | Disc.  |   Promo Scheme     |Cr.Days| Due Date |
+------+-------------------------+---------------+-----------+------+----------+------------+-------------------------+--------+-----------+--------+--------------------+-------+----------+
 123456 1234567890123456789012345 123456789012345 12345678901 123456 1234567890 123456789012 1234567890123456789012345 12345678 12345678901 12345678 12345678901234567890 1234567 1234567890
			*/
			try
			{
				System.Data.SqlClient.SqlDataReader rdr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\PurchaseBookReport.txt";
				StreamWriter sw = new StreamWriter(path);
				
				string sql="";
				string info = "";
				string strDate    = "";
				string strDueDate = "";
				string promo = "";
							
				sql="(select * from vw_PurchaseBook1 where cast(floor(cast(invoice_date as float)) as datetime) >=  '"+ ToMMddYYYY(txtDateFrom.Text) +"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+ ToMMddYYYY(Textbox1.Text)+"') union (select * from vw_PurchaseBook2 where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(invoice_date as float)) as datetime)<= '"+ ToMMddYYYY(Textbox1.Text)+"')";		
						
				dbobj.SelectQuery(sql,ref rdr);
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
				//*****************
				string des="-----------------------------------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//******************
				sw.WriteLine(GenUtil.GetCenterAddr("=================================================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("PURCHASE BOOK REPORT From "+txtDateFrom.Text.ToString()+" To "+Textbox1.Text.ToString(),des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("=================================================",des.Length));
				sw.WriteLine("+-------------+---------+-----------+------+----------+---------+--------------+----------+-------+-------+------------+-----+----------+");
				sw.WriteLine("| Vendor Name |  Place  |  Vendor   |Inv.No| Invoice  | Product |   Product    | Quantity | Price | Disc. |  Invoice   | Cr. | Due Date |");
				sw.WriteLine("|             |         |   Type    |      |  Date    |  Type   |    Name      |  in ltr. |       |       |  Amount    |Days |          |");                      
				sw.WriteLine("+-------------+---------+-----------+------+----------+---------+--------------+----------+-------+-------+------------+-----+----------+");
				//             1234567890123 123456789 12345678901 123456 1234567890 123456789 12345678901234 1234567890 1234567 1234567 123456789012 12345 1234567890
				
							
				// info : to set the fields format to display in reports.
				info = "|{0,-13:S}|{1,-9:S}|{2,-11:S}|{3,6:S}|{4,10:S}|{5,-9:S}|{6,-14:S}|{7,10:S}|{8,7:F}|{9,7:F}|{10,12:S}|{11,5:S}|{12,10:D}|";
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{
									
						// Trime the Time part from Date
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
				
						promo = rdr["Promo_Scheme"].ToString().Trim();
				
						if (promo.Length > 20)
						{
							promo = promo.Substring(0,20);
						}
				
						// Calculate Due Date
				
						DateTime dt = System.Convert.ToDateTime(strDate);
						int crDays  = System.Convert.ToInt32(rdr["Cr_Days"].ToString().Trim());
						strDueDate =  dt.AddDays(crDays).ToShortDateString(); // Zero-padding required
				
						sw.WriteLine(info,GenUtil.TrimLength(rdr["Vendor_Name"].ToString().Trim(),13),
							GenUtil.TrimLength(rdr["Place"].ToString(),9),
							GenUtil.TrimLength(rdr["Vendor_Type"].ToString().Trim(),11),
							rdr["Invoice_No"].ToString().Trim(),
							GenUtil.str2DDMMYYYY(strDate),						            
							GenUtil.TrimLength(rdr["Prod_Type"].ToString().Trim(),9),
							GenUtil.TrimLength(rdr["Prod_Name"].ToString().Trim(),14),
							GenUtil.strNumericFormat((Multiply(rdr["Prod_Type"].ToString()+"X"+rdr["Prod_Name"].ToString()+"X"+rdr["Qty"].ToString())).ToString()),
							GenUtil.TrimLength(GenUtil.strNumericFormat(rdr["Price"].ToString().Trim()),7),
							rdr["Discount"].ToString().Trim(),
							Multiply1(rdr["Invoice_No"].ToString()),
							rdr["Cr_Days"].ToString().Trim(),
							GenUtil.str2DDMMYYYY(strDueDate)
							);
				
					}
				}
				sw.WriteLine("+-------------+---------+-----------+------+----------+---------+--------------+----------+-------+-------+------------+-----+----------+");
				sw.WriteLine(info,"  Total","","","","","","",GenUtil.strNumericFormat(Cache["os"].ToString()),"","",GenUtil.strNumericFormat(Cache["amt"].ToString()),"","");
				sw.WriteLine("+-------------+---------+-----------+------+----------+---------+--------------+----------+-------+-------+------------+-----+----------+");
				dbobj.Dispose();
				
				// deselect Condensed
				//sw.Write((char)18);
				//sw.Write((char)12);
				
				sw.Close();

				//Session["From_Date"] = txtDateFrom.Text;
				//Session["To_Date"] = Textbox1.Text;
				//Response.Redirect("PurchaseBook_PrintPreview.aspx",false); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:PurchaseBook.aspx,Method:makingReport();  EXCEPTION: "+ ex.Message+".   userid  "+uid);
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
			string path = home_drive+@"\ePetro_ExcelFile\PurchaseBook.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			string strDate    = "";
			string strDueDate = "";
			string promo = "";
			sql="(select * from vw_PurchaseBook1 where cast(floor(cast(invoice_date as float)) as datetime) >=  '"+ ToMMddYYYY(txtDateFrom.Text) +"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+ ToMMddYYYY(Textbox1.Text)+"') union (select * from vw_PurchaseBook2 where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ ToMMddYYYY(txtDateFrom.Text).ToShortDateString() +"' and cast(floor(cast(invoice_date as float)) as datetime)<= '"+ ToMMddYYYY(Textbox1.Text)+"')";		
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+Textbox1.Text);
			sw.WriteLine("Vendor Name\tPlace\tVendor Type\tInvoice No\tInvoice Date\tProduct Type\tProduct Name\tQuantity In Ltr\tPrice\tDisc.\tInvoice Amount\tCr. Days\tDue Date");
			if(rdr.HasRows)
			{
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
					promo = rdr["Promo_Scheme"].ToString().Trim();
					if (promo.Length > 20)
					{
						promo = promo.Substring(0,20);
					}
					// Calculate Due Date
					DateTime dt = System.Convert.ToDateTime(strDate);
					int crDays  = System.Convert.ToInt32(rdr["Cr_Days"].ToString().Trim());
					strDueDate =  dt.AddDays(crDays).ToShortDateString(); // Zero-padding required
					sw.WriteLine(rdr["Vendor_Name"].ToString().Trim()+"\t"+
						rdr["Place"].ToString()+"\t"+
						rdr["Vendor_Type"].ToString().Trim()+"\t"+
						rdr["Invoice_No"].ToString().Trim()+"\t"+
						GenUtil.str2DDMMYYYY(strDate)+"\t"+
						rdr["Prod_Type"].ToString().Trim()+"\t"+
						rdr["Prod_Name"].ToString().Trim()+"\t"+
						GenUtil.strNumericFormat((Multiply(rdr["Prod_Type"].ToString()+"X"+rdr["Prod_Name"].ToString()+"X"+rdr["Qty"].ToString())).ToString())+"\t"+
						GenUtil.strNumericFormat(rdr["Price"].ToString().Trim())+"\t"+
						rdr["Discount"].ToString().Trim()+"\t"+
						Multiply1(rdr["Invoice_No"].ToString())+"\t"+
						rdr["Cr_Days"].ToString().Trim()+"\t"+
						GenUtil.str2DDMMYYYY(strDueDate)
						);
				}
			}
			sw.WriteLine("Total\t\t\t\t\t\t\t"+GenUtil.strNumericFormat(Cache["os"].ToString())+"\t\t\t"+GenUtil.strNumericFormat(Cache["amt"].ToString()));
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\PurchaseBookReport.txt<EOF>");
			
					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
			
					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					CreateLogFiles.ErrorLog("Form:purchaseBook.aspx,Method:BtnPrint_Click   Purchase Book Report Printed  userid "+uid);
					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
			                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:purchaseBook.aspx,Method:BtnPrint_Click   Purchase Book Report Printed  "+ ane.Message+"  EXCEPTION"+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:purchaseBook.aspx,Method:BtnPrint_Click   Purchase Book Report Printed  "+ se.Message+"  EXCEPTION"+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:purchaseBook.aspx,Method:BtnPrint_Click   Purchase Book Report Printed  "+ es.Message+"  EXCEPTION"+uid);
				}
			} 
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:purchaseBook.aspx,Method:BtnPrint_Click   Purchase Book Report Printed  "+ es.Message+"  EXCEPTION"+uid);
			}
		}
		
		/// <summary>
		/// This Method multiplies the package quantity with Quantity.
		/// </summary>
		public double os=0,os1=0,in_amt=0;
		protected double Multiply(string str)
		{
			//*******
			//string[] str1=new string[3];
			//if(str.IndexOf(":")>0)
			string[] str1=str.Split(new char[] {':'},str.Length);
			//else
			//{	
			//	str1[1]=str;
			//		str1[0]=str;
			//	}
			//*******
			string[] mystr=str1[1].Split(new char[]{'X'},str1[1].Length);
			// check the package type is loose or not.
			if(str1[0].Trim().IndexOf("Fuel") == -1)
			{
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
				double oss=System.Convert.ToDouble( mystr[1].ToString())*1000; //Add on 27.08.07 12.14am
				os+=System.Convert.ToDouble( mystr[1].ToString())*1000;
				Cache["os"]=System.Convert.ToString(os);
				//return System.Convert.ToDouble( mystr[1].ToString()); 	
				return oss;
			}
		}
	
		//This function to calculate the total qty in liters.
		//		double amt=0;
		//		protected double Multiply1(string price,string qty)
		//		{
		//			in_amt=0;
		//			in_amt=double.Parse(qty)*double.Parse(price);
		//			amt+=in_amt;
		//			Cache["amt"]=System.Convert.ToString(amt);
		//			return in_amt;
		//		}
		
		double amt=0,amt1=0,amt2=0;
		int count=0,i=0,status=0,Flag=0;
		protected string Multiply1(string inv_no)
		{
			PetrolPumpClass  obj=new PetrolPumpClass();
			SqlDataReader SqlDtr;
			string sql;
			//in_amt=0;
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
				sql = "(select count(*) from vw_PurchaseBook1 where Invoice_No="+Cache["Invoice_No"].ToString()+") union (select count(*) from vw_PurchaseBook2 where Invoice_No="+Cache["Invoice_No"].ToString()+")";
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
				string sql1 = "select Net_Amount from Purchase_Master where Invoice_No="+Cache["Invoice_No"].ToString();
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
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:PurchaseBook.aspx,Method: btnExcel_Click, PurchaseBook Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:PurchaseBook.aspx,Method:btnExcel_Click   PurchaseBook Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}