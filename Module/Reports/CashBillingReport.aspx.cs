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
using DBOperations; 


namespace EPetro.Module.Reports
{
	/// <summary>
	/// This Report is used to show the all cash sales report according to given period.
	/// </summary>
	public class CashBillingReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateTo;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button BtnPrint;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string strOrderBy="";
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.CheckBox chkDel;
		protected System.Web.UI.WebControls.DataGrid GridReport;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
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
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Class:PetrolPumpClass,Method:page_load"+ "  EXCEPTION "+ex.Message+"  userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				GridReport.Visible=false;
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="29";
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
		/// This method is used to show the cash sales report with the help of BindTheData() function.
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
					strOrderBy = "Invoice_Date ASC";
					Session["Column"] = "Invoice_Date";
					Session["Order"] = "ASC";
					BindTheData();
				}
				CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Class:PetrolPumpClass,Method:btnShow_Click"+ " CashBillingReport Viewed "+" userid "+ uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Class:PetrolPumpClass,Method:btnShow_Click"+  " CashBillingReport Viewed "+"  EXCEPTION "+ex.Message+" userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="";
			if(chkDel.Checked)
				sqlstr="select distinct Invoice_No,custname,Invoice_Date,vehicleno,vehicleno Prod_Name,vehicleno qty,vehicleno rate,vehicleno netamt from cashbilling where custname='Deleted' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text)+"'";
			else
				sqlstr="(select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate,c.netamt from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select distinct Invoice_No,custname,Invoice_Date,vehicleno,vehicleno Product_Name,vehicleno qty,vehicleno rate,vehicleno netamt from cashbilling where custname='Deleted' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text)+"')";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "cashbilling");
			DataTable dtCustomers = ds.Tables["cashbilling"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count==0)
			{
				MessageBox.Show("Data not available");
				GridReport.Visible=false;
			}
			else
			{
				GridReport.DataSource=dv;
				GridReport.DataBind();
				GridReport.Visible=true;
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
				CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to Returns date in MM/DD/YYYY format.
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
		
		double amt=0,amt1=0,amt2=0;
		int count=0,i=0,status=0,Flag=0,in_amt=0;
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
				sql = "select count(*) from sales_details where Invoice_No="+Cache["Invoice_No"].ToString();
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
				string sql1 = "select netamt from cashbilling where Invoice_No="+Cache["Invoice_No"].ToString();
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
		/// This method is used to prepares the report file CashBillingReport.txt for printing.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CashBillingReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CashBillingReport Viewed "+" userid  "+uid);
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CashBillingReport Viewed  "+ "  EXCEPTION "+ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CashBillingReport  Viewed  "+ "  EXCEPTION "+se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " CashBillingReport  Viewed  "+ "  EXCEPTION "+es.Message+"  userid  "+uid);
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Class:PetrolPumpClass,Method:BtnPrint_Click"+ " Cash Billing Report Viewed  "+ "  EXCEPTION "+ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This Method is used to make the report file.
		/// </summary>
		public void MakingReport() // Prafull
		{
			System.Data.SqlClient.SqlDataReader rdr=null;
			string sql  = "";
			string info = "";
			//	double Total = 0;
			
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CashBillingReport.txt";
			StreamWriter sw = new StreamWriter(path);

			//sql="select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' order by "+Cache["strOrderBy"].ToString();
			string Inv_No=Cache["strOrderBy"].ToString();
			string[]Invoi_No=Inv_No.Split(new char[] {' '},Inv_No.Length);
			if(chkDel.Checked)
			{
				sql="select distinct Invoice_No,custname,Invoice_Date,vehicleno,vehicleno Prod_Name,vehicleno qty,vehicleno rate,vehicleno netamt from cashbilling where custname='Deleted' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text)+"' order by "+Cache["strOrderBy"].ToString()+"";
			}
			else
			{
				if(Invoi_No[0].Equals("Invoice_No"))
					//sql="select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' order by "+"c."+Cache["strOrderBy"].ToString()+"";
					sql="(select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select distinct Invoice_No,custname,Invoice_Date,vehicleno,vehicleno Product_Name,vehicleno qty,vehicleno rate from cashbilling where custname='Deleted' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text)+"')";
				else
					//sql="select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' order by "+Cache["strOrderBy"].ToString()+"";
					sql="(select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select distinct Invoice_No,custname,Invoice_Date,vehicleno,vehicleno Product_Name,vehicleno qty,vehicleno rate from cashbilling where custname='Deleted' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text)+"')";
			}
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
			string des="-------------------------------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("======================================================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("CASH BILLING REPORT From "+txtDateFrom.Text.ToString()+" To "+Textbox1.Text.ToString(),des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("======================================================",des.Length));
			sw.WriteLine("+-------+--------------------+----------+----------+--------------------+-----+---------+-------------+");
			sw.WriteLine("|Invoice|   Customer Name    |   Date   |Vehicle No|    Product Name    | Qty |  Price  |   Amount    |");
			sw.WriteLine("+-------+--------------------+----------+----------+--------------------+-----+---------+-------------+");
			//             1234567 12345678901234567890 1234567890 1234567890 12345678901234567890 12345 123456789 1234567890123 

			if(rdr.HasRows)
			{
				Cache["amt"]="";
				while(rdr.Read())  // 
				{
					//Total = Total +System.Convert.ToDouble(rdr["net_amount"].ToString().Trim());
					// info: to display the string into the specified formats
					info = " {0,-7:S} {1,-20:D} {2,10:D} {3,-10:S} {4,-20:F} {5,5:F} {6,9:F} {7,13:F}";
					sw.WriteLine(info,rdr["Invoice_No"].ToString(),
						GenUtil.TrimLength(rdr["custname"].ToString().Trim(),20),
						GenUtil.trimDate(GenUtil.str2DDMMYYYY(rdr["Invoice_Date"].ToString().Trim())),
						GenUtil.TrimLength(rdr["vehicleno"].ToString(),10),
						GenUtil.TrimLength(rdr["Prod_Name"].ToString().Trim(),20),
						rdr["qty"].ToString(),
						GenUtil.strNumericFormat(rdr["rate"].ToString()),
						Multiply1(rdr["Invoice_No"].ToString())
						);
				}

				sw.WriteLine("+-------+--------------------+----------+----------+--------------------+-----+---------+-------------+");
				sw.WriteLine(info," Total","","","","","","",GenUtil.strNumericFormat(Cache["amt"].ToString()));
				sw.WriteLine("+-------+--------------------+----------+----------+--------------------+-----+---------+-------------+");
			}
			dbobj.Dispose();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to Method to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string sql="";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\CashBillingReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			string Inv_No=Cache["strOrderBy"].ToString();
			string[]Invoi_No=Inv_No.Split(new char[] {' '},Inv_No.Length);
			if(chkDel.Checked)
			{
				sql="select distinct Invoice_No,custname,Invoice_Date,vehicleno,vehicleno Prod_Name,vehicleno qty,vehicleno rate,vehicleno netamt from cashbilling where custname='Deleted' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text)+"' order by "+Cache["strOrderBy"].ToString()+"";
			}
			else
			{
				if(Invoi_No[0].Equals("Invoice_No"))
					//sql="select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' order by "+"c."+Cache["strOrderBy"].ToString()+"";
					sql="(select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select distinct Invoice_No,custname,Invoice_Date,vehicleno,vehicleno Product_Name,vehicleno qty,vehicleno rate from cashbilling where custname='Deleted' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text)+"')";
				else
					//sql="select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"' order by "+Cache["strOrderBy"].ToString()+"";
					sql="(select c.Invoice_No,c.custname,c.Invoice_Date,c.vehicleno,p.prod_name+' : '+p.pack_type Prod_Name,sd.qty,sd.rate from cashbilling c,sales_details sd,products p where sd.Invoice_No=c.Invoice_No and sd.Prod_id=p.Prod_id and cast(floor(cast(c.Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(c.Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"') union (select distinct Invoice_No,custname,Invoice_Date,vehicleno,vehicleno Product_Name,vehicleno qty,vehicleno rate from cashbilling where custname='Deleted' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text)+"')";
			}
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+Textbox1.Text);
			sw.WriteLine("Invoice No\tCustomer Name\tDate\tVehicle No\tProduct Name\tQty\tPrice\tAmount");
			if(rdr.HasRows)
			{
				Cache["amt"]="";
				while(rdr.Read())
				{
					sw.WriteLine(rdr["Invoice_No"].ToString()+"\t"+
						rdr["custname"].ToString().Trim()+"\t"+
						GenUtil.trimDate(GenUtil.str2DDMMYYYY(rdr["Invoice_Date"].ToString().Trim()))+"\t"+
						rdr["vehicleno"].ToString()+"\t"+
						rdr["Prod_Name"].ToString().Trim()+"\t"+
						rdr["qty"].ToString()+"\t"+
						GenUtil.strNumericFormat(rdr["rate"].ToString())+"\t"+
						Multiply1(rdr["Invoice_No"].ToString())
						);
				}
			}
			sw.WriteLine("Total\t\t\t\t\t\t\t"+GenUtil.strNumericFormat(Cache["amt"].ToString()));
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to prepares the excel report file CashBillingReport.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Method: btnExcel_Click, CashBilling Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:CashBillingReport.aspx,Method:btnExcel_Click   CashBilling Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}