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
	/// Summary description for LeaveReport.
	/// </summary>
	public class LeaveReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateFrom;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDateTo;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.DataGrid GridReport;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnExcel;
		string uid;

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
				CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Method:page_load"+ "  EXCEPTION "+ex.Message+"  userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="30";
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
		/// This method is used to call the BindTheData() function for view the report and 
		/// also set the column name and order format in session variable.
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
					strOrderBy = "Emp_Name ASC";
					Session["Column"] = "Emp_Name";
					Session["Order"] = "ASC";
					BindTheData();
				}
				CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Method:btnShow_Click"+ " LeaveReport Viewed "+" userid "+ uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Method:btnShow_Click"+  " LeaveReport Viewed "+"  EXCEPTION "+ex.Message+" userid  "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select lr.Emp_ID,e.Emp_Name,lr.Date_From,lr.Date_To,lr.Reason,lr.isSanction from Employee e,Leave_Register lr where e.Emp_ID=lr.Emp_ID and cast(floor(cast(lr.Date_From as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(lr.Date_To as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "Leave_Register");
			DataTable dtCustomers = ds.Tables["Leave_Register"];
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

		public string Approved(string str)
		{
			if(str=="0")
				str="No";
			else
				str="Yes";
			return str;
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
				makingReport();
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
					CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Class:Inventory.cs,Method:btnprint_Clickt    Leave Report  Printed"+"  userid  " +uid);
					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\LeaveReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Leave Report  Printed"+"  EXCEPTION "+ane.Message+"  userid  " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Leave Report  Printed"+"  EXCEPTION "+se.Message+"  userid  " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Leave Report  Printed"+"  EXCEPTION "+es.Message+"  userid  " +uid);
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Leave Report  Printed"+"  EXCEPTION "+ex.Message+"  userid  " +uid);
			}

		}

		/// <summary>
		/// This method is used to write into the report file to print.
		/// </summary>
		public void makingReport()
		{
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\LeaveReport.txt";
			StreamWriter sw = new StreamWriter(path);
			string sql="";
			string info = "";
			//string strDate = "";
			//sql="select lr.Emp_ID r1,e.Emp_Name r2,lr.Date_From r3,lr.Date_To r4,lr.Reason r5,lr.isSanction r6 from Employee e,Leave_Register lr where e.Emp_ID=lr.Emp_ID and cast(floor(cast(lr.Date_From as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(lr.Date_To as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			sql="select lr.Emp_ID,e.Emp_Name,lr.Date_From,lr.Date_To,lr.Reason,lr.isSanction from Employee e,Leave_Register lr where e.Emp_ID=lr.Emp_ID and cast(floor(cast(lr.Date_From as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(lr.Date_To as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			sql=sql+" order by "+Cache["strOrderBy"];
			dbobj.SelectQuery(sql,ref rdr);
			// Condensed
			sw.Write((char)27);
			sw.Write((char)67);
			sw.Write((char)0);
			sw.Write((char)12);

			sw.Write((char)27);
			sw.Write((char)78);
			sw.Write((char)5);
				
			sw.Write((char)27);
			sw.Write((char)15);
			//**********
			string des="--------------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("LEAVE REPORT",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("================",des.Length));
			sw.WriteLine("+-----------+--------------------+----------+----------+--------------------+--------+");
			sw.WriteLine("|Employee ID|    Employee Name   |From Date | To Date  |       Reason       |Approved|");
			sw.WriteLine("+-----------+--------------------+----------+----------+--------------------+--------+");
			//             12345678901 12345678901234567890 1234567890 1234567890 12345678901234567890 12345678
			if(rdr.HasRows)
			{
				info = " {0,-11:S} {1,-20:F} {2,-10:S} {3,-10:S} {4,-20:S}   {5,-6:S}"; 
				while(rdr.Read())
				{
					sw.WriteLine(info,GenUtil.TrimLength(rdr["Emp_ID"].ToString(),10),
						GenUtil.TrimLength(rdr["Emp_Name"].ToString(),20),
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Date_From"].ToString())),
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Date_To"].ToString())),
						GenUtil.TrimLength(rdr["Reason"].ToString(),20),
						Approved(rdr["isSanction"].ToString())
						);
				}
			}
			sw.WriteLine("+-----------+--------------------+----------+----------+--------------------+--------+");
			dbobj.Dispose();
			sw.Close();
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
			string path = home_drive+@"\ePetro_ExcelFile\LeaveReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select lr.Emp_ID,e.Emp_Name,lr.Date_From,lr.Date_To,lr.Reason,lr.isSanction from Employee e,Leave_Register lr where e.Emp_ID=lr.Emp_ID and cast(floor(cast(lr.Date_From as float)) as datetime)>='"+ ToMMddYYYY(txtDateFrom.Text)  +"' and cast(floor(cast(lr.Date_To as float)) as datetime)<='"+ ToMMddYYYY(Textbox1.Text) +"'";
			sql=sql+" order by "+Cache["strOrderBy"];
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+Textbox1.Text);
			sw.WriteLine("Employee ID\tEmployee Name\tFrom Date\tTo Date\tReason\tApproved\t");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(rdr["Emp_ID"].ToString()+"\t"+
						rdr["Emp_Name"].ToString()+"\t"+
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Date_From"].ToString()))+"\t"+
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Date_To"].ToString()))+"\t"+
						rdr["Reason"].ToString()+"\t"+
						Approved(rdr["isSanction"].ToString())
						);
				}
			}
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}

		/// <summary>
		/// This method is used to Prepares the excel report file LeaveReport.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Method: btnExcel_Click, Leave Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:LeaveReport.aspx,Method:btnExcel_Click   Leave Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}