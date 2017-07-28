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
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using RMG;


namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for MeterReadingReport.
	/// </summary>
	public class MeterReadingReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid GridMeterReadingReport;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		string strOrderBy="";
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.Button btnExcel;
		string UID;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
                txtDateTo.Attributes.Add("readonly", "readonly");
                UID =(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,method:page_load,Class:PetrolPumpClass.cs " + ex.Message+"  EXCEPTION "+" userid "+UID);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
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
				if(View_flag=="0")
				{
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
				txtDateTo.Text=DateTime.Now.Day+ "/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year;
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
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5)
		{
			while(rdr.Read())
			{
				if(rdr["entry_date"].ToString().Trim().Length>len1)
					len1=rdr["entry_date"].ToString().Trim().Length;					
				if(rdr["nozzle_name"].ToString().Trim().Length>len2)
					len2=rdr["nozzle_name"].ToString().Trim().Length;					
				if(rdr["machine_name"].ToString().Trim().Length>len3)
					len3=rdr["machine_name"].ToString().Trim().Length;
				if(rdr["prod_name"].ToString().Trim().Length>len4)
					len4=rdr["prod_name"].ToString().Trim().Length;					
				if(rdr["reading"].ToString().Trim().Length>len5)
					len5=rdr["reading"].ToString().Trim().Length;					
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
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
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
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void btnView_Click(object sender, System.EventArgs e)
		{ 
			try
			{
				//				PetrolPumpClass  obj=new PetrolPumpClass();
				//				SqlDataReader SqlDtr;
				//				string sql;
				#region Bind DataGrid
				strOrderBy = "Entry_Date ASC";
				Session["Column"] = "Entry_Date";
				Session["Order"] = "ASC";
				BindTheData();
				//				sql="select entry_date,nozzle_name,machine_name,prod_name,reading from daily_meter_reading d,nozzle n,machine m,tank t where d.nozzle_id = n.nozzle_id and   n.machine_id = m.machine_id and   n.tank_id = t.tank_id and Entry_Date='"+ToMMddYYYY(txtDateTo.Text).ToShortDateString()  +"'";
				//				SqlDtr =obj.GetRecordSet(sql);
				//				GridMeterReadingReport.Visible=true; 
				//				if(SqlDtr.HasRows)
				//				{
				//					GridMeterReadingReport.DataSource=SqlDtr;
				//					GridMeterReadingReport.DataBind();
				//				}
				//				else
				//				{
				//					GridMeterReadingReport.Visible=false; 
				//					RMG.MessageBox.Show("Data not available");
				//
				//				}
				//				SqlDtr.Close();
				#endregion
				CreateLogFiles.ErrorLog("Form:Form:MeterReadingReport.aspx,Method:btnView_click'Class:PetrolPumpClass.cs "+" Meter Reading Report Viewed  "+" userid "+UID);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Form:MeterReadingReport.aspx,Class:PetrolPumpClass.cs ,Method:btnView_Click" +"  Meter Reading Report Viewed  "+ex.Message+"  EXCEPTION  "+"  userid  "+UID);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select entry_date,nozzle_name,machine_name+' : '+machine_type machine,prod_name,reading from daily_meter_reading d,nozzle n,machine m,tank t where d.nozzle_id = n.nozzle_id and   n.machine_id = m.machine_id and   n.tank_id = t.tank_id and Entry_Date='"+ToMMddYYYY(txtDateTo.Text).ToShortDateString()  +"'";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "daily_meter_reading");
			DataTable dtCustomers = ds.Tables["daily_meter_reading"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridMeterReadingReport.DataSource = dv;
				GridMeterReadingReport.DataBind();
				GridMeterReadingReport.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridMeterReadingReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}
		
		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void MakingReport()
		{
			/*
										 ========================                        
										   METER READING REPORT                          
										 ========================                        
			+-----------+-------------+--------------+---------------------+-----------+
			|Entry.Date | Nozzle.Name | Machine.Name | Prod.Name           | Reading   |
			+-----------+-------------+--------------+---------------------+-----------+
			 1/4/2006     123456789012  1-23           12345678901234567890  1234567890 

			*/
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\MeterReadingReport.txt";
			StreamWriter sw = new StreamWriter(path);

			string sql="";
			string info = "";
			//string strDate="";
			sql="select entry_date,nozzle_name,machine_name+' '+machine_type machine,prod_name,reading from daily_meter_reading d,nozzle n,machine m,tank t where d.nozzle_id = n.nozzle_id and   n.machine_id = m.machine_id and   n.tank_id = t.tank_id and Entry_Date='"+ToMMddYYYY(txtDateTo.Text).ToShortDateString()+"' order by "+Cache["strOrderBy"]+"";
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
			string des="---------------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("=====================================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("METER READING REPORT AS ON "+txtDateTo.Text.ToString(),des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=====================================",des.Length));
			sw.WriteLine("+------------------------------+--------------------+---------------------+-----------+");
			sw.WriteLine("|         Machine Name         |    Nozzle Name     |    Product Name     | Reading   |");
			sw.WriteLine("+------------------------------+--------------------+---------------------+-----------+");
			//             123456789012345678901234567890 12345678901234567890 123456789012345678901 12345678901

			if(rdr.HasRows)
			{
				// info : to set the format of the displaying string.
				info = " {0,-30:S} {1,-20:S} {2,-21:S} {3,11:F}";
				while(rdr.Read())
				{
					//					strDate = rdr["entry_date"].ToString().Trim();
					//					int pos = strDate.IndexOf(" ");
					//				
					//					if(pos != -1)
					//					{
					//						strDate = strDate.Substring(0,pos);
					//					}
					//					else
					//					{
					//						strDate = "";					
					//					}

					sw.WriteLine(info,//GenUtil.str2DDMMYYYY(strDate),
						GenUtil.TrimLength(rdr["machine"].ToString().Trim(),30),
						GenUtil.TrimLength(rdr["nozzle_name"].ToString(),20),
						GenUtil.TrimLength(rdr["prod_name"].ToString().Trim(),21),
						GenUtil.strNumericFormat(rdr["reading"].ToString().Trim()));
				}
			}
			sw.WriteLine("+------------------------------+--------------------+---------------------+-----------+");
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
			string path = home_drive+@"\ePetro_ExcelFile\MeterReadingReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select entry_date,nozzle_name,machine_name+' '+machine_type machine,prod_name,reading from daily_meter_reading d,nozzle n,machine m,tank t where d.nozzle_id = n.nozzle_id and   n.machine_id = m.machine_id and   n.tank_id = t.tank_id and Entry_Date='"+ToMMddYYYY(txtDateTo.Text).ToShortDateString()+"' order by "+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("Date\t"+txtDateTo.Text);
			sw.WriteLine("Machine Name\tNozzle Name\tProduct Name\tReading");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(
						rdr["machine"].ToString().Trim()+"\t"+
						rdr["nozzle_name"].ToString()+"\t"+
						rdr["prod_name"].ToString().Trim()+"\t"+
						GenUtil.strNumericFormat(rdr["reading"].ToString().Trim()));
				}
			}
			dbobj.Dispose();
			sw.Close();
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

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\MeterReadingReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,Class:PetrolPumpClass.cs "+"  Meter Reading Report Printed "+" userid "+UID);
				
				}
                
					//}
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,Class:PetrolPumpClass.cs  EXCEPTION  "+ane.Message+" userid "+UID);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,Class:PetrolPumpClass.cs  EXCEPTION  "+se.Message+" userid "+UID);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,Class:PetrolPumpClass.cs  EXCEPTION  "+es.Message+" userid "+UID);
				}

			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,Class:PetrolPumpClass.cs " + " Meter Reading ReportPrinted "+ex.Message+" EXCEPTION  "+" userid "+UID);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridMeterReadingReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,Method: btnExcel_Click, MeterReading Report Convert Into Excel Format ,  userid  "+UID);
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
				CreateLogFiles.ErrorLog("Form:MeterReadingReport.aspx,Method:btnExcel_Click   MeterReading Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+UID);
			}
		}
	}
}