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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using EPetro.Sysitem.Classes ;
using DBOperations;
using RMG;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for SlipMasterReport.
	/// </summary>
	public class SlipMasterReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid GridTankReport;
		protected System.Web.UI.WebControls.Button Btnreport;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnExcel;
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
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception es)
			{
				CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:page_load    EXCEPTION  "+es.Message+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="13";
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Btnreport.Click += new System.EventHandler(this.Btnreport_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to Sends the text file to print server to print.
		/// </summary>
		public void print()
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\SlipReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:print  Slip Master Report Print  userid  "+uid);
					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:print,      Slip Master Report Printed   EXCEPTION  "+ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:print ,      Slip Master Report Printed   EXCEPTION  "+se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:print,  Slip Master Report Printed   EXCEPTION  "+es.Message+"  userid  "+uid);
				}
			} 
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:print,   Slip Master Report Printed   EXCEPTION  "+es.Message+"  userid  "+uid);
			}
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
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6)
		{
			while(rdr.Read())
			{
				if(rdr["BookID"].ToString().Trim().Length>len1)
					len1=rdr["BookID"].ToString().Trim().Length;					
				if(rdr["Book_No"].ToString().Trim().Length>len2)
					len2=rdr["Book_No"].ToString().Trim().Length;					
				if(rdr["Start_No"].ToString().Trim().Length>len3)
					len3=rdr["Start_No"].ToString().Trim().Length;					
				if(rdr["End_No"].ToString().Trim().Length>len4)
					len4=rdr["End_No"].ToString().Trim().Length;	
				if(rdr["TotalSlip"].ToString().Trim().Length>len5)
					len5=rdr["TotalSlip"].ToString().Trim().Length;	
				if(rdr["Cust_Name"].ToString().Trim().Length>len6)
					len6=rdr["Cust_Name"].ToString().Trim().Length;	
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
		/// This Method is used to prepare the report file.	
		/// </summary>
		public void MakingReport()
		{
			/*
			+--------+------+---------------+-------+-------------------------------+
			|  Slip  | Book |     Slip No   |Number |                               |
			| Book ID|  No  +-------+-------+  of   |        Customer Name          |
			|        |      | From  |  To   |Slips  |                               |
			+--------+------+-------+-------+-------+-------------------------------+
			 1001     1000   111111  111111  111111  x
			*/
			
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\SlipReport.txt";
			StreamWriter sw = new StreamWriter(path);

			string sql="";
			string info = "";
			          			
			sql="select Slip_Book_ID as BookID,Book_No,Start_No,End_No,(End_No - (Start_No-1)) as TotalSlip,Cust_Name from slip s,customer c where s.Cust_ID = c.Cust_ID order by "+Cache["strOrderBy"]+"";
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
			string des="-------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("=================",des.Length)); 
			sw.WriteLine(GenUtil.GetCenterAddr("SLIP REPORT",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=================",des.Length));
			/*			
						sw.WriteLine("+-----------+---------+---------------+-------------+-------------------------------+");
						sw.WriteLine("|           |         |     Slip No   |             |                               |");
						sw.WriteLine("| Slip Book | Book No |-------+-------| No. of Slips|        Customer Name          |");
						sw.WriteLine("|     ID    |         | From  |  To   |             |                               |");
						sw.WriteLine("+-----------+---------+-------+-------+-------------+-------------------------------+");
						//			               1038        1111      123456  123456   1112          123456789012345678901234567890
			*/
			sw.WriteLine("+--------+------+---------------+-------+-------------------------------+");
			sw.WriteLine("|  Slip  | Book |     Slip No   |Number |                               |");
			sw.WriteLine("| Book ID|  No  +-------+-------+  of   |        Customer Name          |");
			sw.WriteLine("|        |      | From  |  To   |Slips  |                               |");
			sw.WriteLine("+--------+------+-------+-------+-------+-------------------------------+");
			if(rdr.HasRows)
			{
				// info : to set the string format.
				info = "  {0,-4:S}     {1,-4:S}  {2,-6:S}   {3,6:S} {4,6:S}   {5,-30:S}";
				while(rdr.Read())
				{
					
					sw.WriteLine(info,rdr["BookID"].ToString().Trim(),
						rdr["Book_No"].ToString().Trim(),
						rdr["Start_No"].ToString(),
						rdr["End_No"].ToString(),
						rdr["TotalSlip"].ToString(),
						GenUtil.TrimLength(rdr["Cust_Name"].ToString(),30));
				}
			}
			sw.WriteLine("+--------+------+-------+-------+-------+-------------------------------+");
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
			string path = home_drive+@"\ePetro_ExcelFile\SlipMasterReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select Slip_Book_ID as BookID,Book_No,Start_No,End_No,(End_No - (Start_No-1)) as TotalSlip,Cust_Name from slip s,customer c where s.Cust_ID = c.Cust_ID order by "+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("Slip Book ID\tBook No\tSlip No(From)\tSlip No(To)\tNumber Of Slips\tCustomer Name");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(rdr["BookID"].ToString().Trim()+"\t"+
						rdr["Book_No"].ToString().Trim()+"\t"+
						rdr["Start_No"].ToString()+"\t"+
						rdr["End_No"].ToString()+"\t"+
						rdr["TotalSlip"].ToString()+"\t"+
						rdr["Cust_Name"].ToString());
				}
			}
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}

		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			PetrolPumpClass  obj=new PetrolPumpClass();
			try
			{
				// Fetch the details from database and bind the data grid.
				strOrderBy = "Cust_Name ASC";
				Session["Column"] = "Cust_Name";
				Session["Order"] = "ASC";
				BindTheData();
				//				SqlDataReader SqlDtr;
				//				string sql;
				//				sql="select Slip_Book_ID as BookID,Book_No,Start_No,End_No,(End_No - (Start_No-1)) as TotalSlip,Cust_Name from slip s,customer c where s.Cust_ID = c.Cust_ID";
				//				SqlDtr =obj.GetRecordSet(sql);
				//				GridTankReport.DataSource=SqlDtr;
				//				if(SqlDtr.HasRows)
				//				{
				//					GridTankReport.DataBind();
				//					GridTankReport.Visible=true;
				//				}
				//				else
				//				{
				//					MessageBox.Show("Data Not Available");
				//					GridTankReport.Visible=false;
				//				}
				//				SqlDtr.Close();
				CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:Button1_Click, Slip Master Report Viewed   userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:Button1_Click, Slip Master  Report Viewed   Exception "+ex.Message  +"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select Slip_Book_ID as BookID,Book_No,Start_No,End_No,(End_No - (Start_No-1)) as TotalSlip,Cust_Name from slip s,customer c where s.Cust_ID = c.Cust_ID";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "slip");
			DataTable dtCustomers = ds.Tables["slip"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridTankReport.DataSource = dv;
				GridTankReport.DataBind();
				GridTankReport.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridTankReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to call MakingReport() function to prapare the .txt file for print.
		/// </summary>
		private void Btnreport_Click(object sender, System.EventArgs e)
		{
			try
			{
				MakingReport();	
				print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:Btnreport_Click().  EXCEPTION "+ ex.Message+" userid "+  uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridTankReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method: btnExcel_Click, SlipMaster Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:SlipMasterReport.aspx,Method:btnExcel_Click   SlipMaster Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}