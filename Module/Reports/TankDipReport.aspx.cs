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
	/// Summary description for TankDipReport.
	/// </summary>
	public class TankDipReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.DataGrid GridTankDipReport;
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.Button Button1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		string uid;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.Button btnExcel;
		string strOrderBy="";

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
				CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Class:DBOperation_LETEST.cs,Method:page_load"+ ex.Message+"EXCEPTION"+uid);	
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="6";
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
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6,ref int len7,ref int len8)
		{
			while(rdr.Read())
			{
				if(rdr["Entry_Date"].ToString().Trim().Length>len1)
					len1=rdr["Entry_Date"].ToString().Trim().Length;					
				if(rdr["Prod_AbbName"].ToString().Trim().Length>len2)
					len2=rdr["Prod_AbbName"].ToString().Trim().Length;					
				if(rdr["Density"].ToString().Trim().Length>len3)
					len3=rdr["Density"].ToString().Trim().Length;
				if(rdr["Temprature"].ToString().Trim().Length>len4)
					len4=rdr["Temprature"].ToString().Trim().Length;					
				if(rdr["Converted_Density"].ToString().Trim().Length>len5)
					len5=rdr["Converted_Density"].ToString().Trim().Length;					
				if(rdr["Opening_Stock"].ToString().Trim().Length>len6)
					len6=rdr["Opening_Stock"].ToString().Trim().Length;	
				if(rdr["Tank_Dip"].ToString().Trim().Length>len7)
					len7=rdr["Tank_Dip"].ToString().Trim().Length;	
				if(rdr["Water_Dip"].ToString().Trim().Length>len8)
					len8=rdr["Water_Dip"].ToString().Trim().Length;	
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
		/// This method is used to prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void makingareport()
		{
			/*              ===================
							  TANK DIP REPORT
							===================
			+----------+---------------+-------+----+------------+--------+--------+-------+
			|Entry Date| Prod.AbbName  |Density|Temp|Conv.Density|Op.Stock|Tank.Dip|Wat.Dip|
			+----------+---------------+-------+----+------------+--------+--------+-------+
			 8/7/2006   T-1/HSD-20K        1.23   20         1.24     1000      100     100
			*/
			try
			{
				System.Data.SqlClient.SqlDataReader rdr=null;
				string sql="";
				//string strDate = "";
				String info = "";
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\TankDipReport.txt";
				StreamWriter sw = new StreamWriter(path);

				sql="select dtd.*,t.Prod_AbbName from Daily_Tank_Reading dtd, Tank t where dtd.Tank_ID=t.Tank_ID and dtd.Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by "+Cache["strOrderBy"]+"";
						
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
				string des="-------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("===================================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("TANK DIP REPORT AS ON "+txtDateFrom.Text.Trim().ToString(),des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("===================================",des.Length));
				//sw.WriteLine(" Date : "+txtDateFrom.Text.Trim().ToString());
				sw.WriteLine("+---------------+-------+------+------------+--------+--------+-------+-------+");
				sw.WriteLine("| Prod.AbbName  |Density| Temp |Conv.Density|Op.Stock|Tank.Dip|Wat.Dip|Testing|");
				sw.WriteLine("+---------------+-------+------+------------+--------+--------+-------+-------+");
				//             123456789012345 1234567 123456 123456789012 12345678 12345678 1234567 1234567
			
				if(rdr.HasRows)
				{
					// info : to set display string format.
					info = " {0,-15:S} {1,7:D} {2,6:D} {3,12:D} {4,8:S} {5,8:S} {6,7:S} {7,7:S}";
					while(rdr.Read())
					{
						//						strDate = rdr["Entry_Date"].ToString().Trim();
						//						int pos = strDate.IndexOf(" ");
						//				
						//						if(pos != -1)
						//						{
						//							strDate = strDate.Substring(0,pos);
						//						}
						//						else
						//						{
						//							strDate = "";					
						//						}
						sw.WriteLine(info,//GenUtil.str2DDMMYYYY(strDate),
							GenUtil.TrimLength(rdr["Prod_AbbName"].ToString().Trim(),15),
							GenUtil.strNumericFormat(rdr["Density"].ToString()),
							GenUtil.strNumericFormat(rdr["Temprature"].ToString().Trim()),
							GenUtil.strNumericFormat(rdr["Converted_Density"].ToString().Trim()),
							GenUtil.strNumericFormat(rdr["Opening_Stock"].ToString().Trim()),
							GenUtil.strNumericFormat(rdr["Tank_Dip"].ToString().Trim()),
							GenUtil.strNumericFormat(rdr["Water_Dip"].ToString().Trim()),
							GenUtil.strNumericFormat(rdr["Testing"].ToString().Trim()));
					}
				}
				sw.WriteLine("+---------------+-------+------+------------+--------+--------+-------+-------+");
				dbobj.Dispose();
				//sw.Write((char)18);
				//sw.Write((char)12);
				sw.Close();       
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method:makingareport(),  EXCEPTION   "+ex.Message+" userid  "+uid);
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
			string path = home_drive+@"\ePetro_ExcelFile\TankDipReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select dtd.*,t.Prod_AbbName from Daily_Tank_Reading dtd, Tank t where dtd.Tank_ID=t.Tank_ID and dtd.Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by "+Cache["strOrderBy"]+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("Date\t"+txtDateFrom.Text);
			sw.WriteLine("Prod.AbbName\tDensity\tTemp\tConv.Density\tOp.Stock\tTank.Dip\tWat.Dip\tTesting");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(
						rdr["Prod_AbbName"].ToString().Trim()+"\t"+
						GenUtil.strNumericFormat(rdr["Density"].ToString())+"\t"+
						GenUtil.strNumericFormat(rdr["Temprature"].ToString().Trim())+"\t"+
						GenUtil.strNumericFormat(rdr["Converted_Density"].ToString().Trim())+"\t"+
						GenUtil.strNumericFormat(rdr["Opening_Stock"].ToString().Trim())+"\t"+
						GenUtil.strNumericFormat(rdr["Tank_Dip"].ToString().Trim())+"\t"+
						GenUtil.strNumericFormat(rdr["Water_Dip"].ToString().Trim())+"\t"+
						GenUtil.strNumericFormat(rdr["Testing"].ToString().Trim()));
				}
			}
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This method make the round to the passing string by the passing precision.
		/// </summary>
		public string makeRound(string str,int prec)
		{
			if(!str.Trim().Equals("") || str != null)
			{
				double strValue = System.Convert.ToDouble(str);
				strValue = System.Math.Round(strValue,prec);
				str = System.Convert.ToString(strValue); 
			}
			else
			{
				str ="0.00";
			}
			return str;
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
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// This method is used to Sends the text file to print server to print.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			makingareport();
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\TankDipReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Class:DBOperation_LETEST.cs,Method:btnPrint_Click,Tank Dip Report Printed  userid"+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method:btnPrint_Click,  Tank Dip Report Printed    EXCEPTION "+ ane.Message+"  userid "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method:btnPrint_Click,  Tank Dip Report Printed    EXCEPTION "+ se.Message+"  userid "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method:btnPrint_Click,  Tank Dip Report Printed    EXCEPTION "+ es.Message+"  userid "+uid);
				}
			} 
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method:btnPrint_Click,  Tank Dip Report Printed    EXCEPTION "+ es.Message+"  userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				//			PetrolPumpClass  obj=new PetrolPumpClass();
				//			SqlDataReader SqlDtr;
				//			string sql;
   
				#region Bind DataGrid
				strOrderBy = "Prod_AbbName ASC";
				Session["Column"] = "Prod_AbbName";
				Session["Order"] = "ASC";
				BindTheData();
				//			sql="select dtd.*,t.Prod_AbbName from Daily_Tank_Reading dtd, Tank t where dtd.Tank_ID=t.Tank_ID";
				//			
				//			SqlDtr =obj.GetRecordSet(sql);
				//			GridTankDipReport.DataSource=SqlDtr;
				//			   if(SqlDtr.HasRows)
				//			   {
				//				   GridTankDipReport.DataBind();
				//			   }
				//			   else
				//			   {
				//					GridTankDipReport.Visible=false;
				//				   MessageBox.Show("Data not available");
				//			   }
				//			SqlDtr.Close();
				#endregion
				CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method:Button1_Click, TankDip Report View  userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method:Button1_Click, TankDip Report View   EXCEPTION   "+ex.Message+" userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			//string sqlstr="select dtd.*,t.Prod_AbbName from Daily_Tank_Reading dtd, Tank t where dtd.Tank_ID=t.Tank_ID";
			string sqlstr="select dtd.*,t.Prod_AbbName from Daily_Tank_Reading dtd, Tank t where dtd.Tank_ID=t.Tank_ID and dtd.Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"'";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "Daily_Tank_Reading");
			DataTable dtCustomers = ds.Tables["Daily_Tank_Reading"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"] = strOrderBy;
			if(dv.Count!=0)
			{
				GridTankDipReport.DataSource = dv;
				GridTankDipReport.DataBind();
				GridTankDipReport.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridTankDipReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridTankDipReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method: btnExcel_Click, TankDip Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:TankDipReport.aspx,Method:btnExcel_Click   TankDip Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}