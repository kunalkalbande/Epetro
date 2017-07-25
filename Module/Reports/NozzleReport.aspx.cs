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
	/// Summary description for NozzleReport.
	/// </summary>
	public class NozzleReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.DataGrid GridNozzleReport;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.Button Button1;
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
				CreateLogFiles.ErrorLog("Form:Nozzelreport.aspx,Class:PetrolPumpClass.cs ,Method:Pageload"+ex.Message+"   EXCEPTION  "+"  userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="4";
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

		// This function prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		//		public void MakingReport()
		//		{
		//			/*
		//									 ==================               
		//										NOZZEL REPORT                               
		//									 ==================                  
		//			+----------+-------------+--------------+-----------+---------------------+
		//			|Nozzle.id | Nozzle.Name | Machine Name | Tank.Name |     Prod.Name       |
		//			+----------+-------------+--------------+-----------+---------------------+
		//			 1001       1234567890123  1-23          12345678901 123456789012345678901
		//			*/
		//			System.Data.SqlClient.SqlDataReader rdr=null;
		//			string home_drive = Environment.SystemDirectory;
		//			home_drive = home_drive.Substring(0,2); 
		//			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\NozzleReport.txt";
		//			StreamWriter sw = new StreamWriter(path);
		//			string sql="";
		//			string info = "";
		//
		//			//sql="select nozzle_id,nozzle_name,machine_name,tank_name,prod_name from nozzle n, machine m,tank t where n.machine_id = m.machine_id and   n.tank_id = t.tank_id order by "+Cache["strOrderBy"].ToString()+"";
		//			sql="select case when nozzlesortname='' then nozzle_name else nozzle_name+':'+ nozzlesortname end nozzle,machine_name+':'+machine_type machine,prod_name,prod_abbname from nozzle n, machine m,tank t where n.machine_id = m.machine_id and   n.tank_id = t.tank_id order by "+Cache["strOrderBy"].ToString();
		//			dbobj.SelectQuery(sql,ref rdr);
		//			// Condensed
		//			sw.Write((char)15);
		//			sw.WriteLine("");
		//			//**********
		//			string des="----------------------------------------------------------------------------------------------------------";
		//			string Address=GenUtil.GetAddress();
		//			string[] addr=Address.Split(new char[] {':'},Address.Length);
		//			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
		//			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
		//			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
		//			sw.WriteLine(des);
		//			//**********
		//			sw.WriteLine(GenUtil.GetCenterAddr("==================",des.Length));
		//			sw.WriteLine(GenUtil.GetCenterAddr("NOZZEL REPORT",des.Length));
		//			sw.WriteLine(GenUtil.GetCenterAddr("==================",des.Length));
		//			sw.WriteLine("+------------------------------+------------------------------+---------------------+--------------------+");
		//			sw.WriteLine("|          Nozzle Name         |         Machine Name         |    Product Name     |     Tank Name      |");
		//			sw.WriteLine("+------------------------------+------------------------------+---------------------+--------------------+");
		//			//             123456789012345678901234567890 123456789012345678901234567890 123456789012345678901 12345678901234567890
		//			if(rdr.HasRows)
		//			{
		//				// info : to set the format of the displaying fields.
		//				//info = " {0,-4:S}       {1,-13:S}   {2,-3:S}          {3,-11:S} {4,-21:S}";
		//				info = " {0,-30:S} {1,-30:S} {2,-21:S} {3,-20:S}";
		//				while(rdr.Read())
		//				{
		//					sw.WriteLine(info,GenUtil.TrimLength(rdr["nozzle"].ToString().Trim(),30),
		//						//rdr["machine_name"].ToString()+':'+rdr["machine_type"].ToString(),
		//						GenUtil.TrimLength(rdr["machine"].ToString(),30),
		//						GenUtil.TrimLength(rdr["prod_name"].ToString().Trim(),21),
		//						GenUtil.TrimLength(rdr["prod_abbname"].ToString().Trim(),20));
		//				}
		//			}
		//
		//			sw.WriteLine("+------------------------------+------------------------------+---------------------+--------------------+");
		//			dbobj.Dispose();
		//			sw.Close();		
		//		}

		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void MakingReport()
		{
			/*
											 ==================               
												NOZZEL REPORT                               
											 ==================                  
					+----------+-------------+--------------+-----------+---------------------+
					|Nozzle.id | Nozzle.Name | Machine Name | Tank.Name |     Prod.Name       |
					+----------+-------------+--------------+-----------+---------------------+
					 1001       1234567890123  1-23          12345678901 123456789012345678901
					*/
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\NozzleReport.txt";
			StreamWriter sw = new StreamWriter(path);
			string sql="";
			string info = "";
		
			//sql="select nozzle_id,nozzle_name,machine_name,tank_name,prod_name from nozzle n, machine m,tank t where n.machine_id = m.machine_id and   n.tank_id = t.tank_id order by "+Cache["strOrderBy"].ToString()+"";
			sql="select case when nozzlesortname='' then nozzle_name else nozzle_name+':'+ nozzlesortname end nozzle,machine_name+':'+machine_type machine,prod_name,prod_abbname from nozzle n, machine m,tank t where n.machine_id = m.machine_id and   n.tank_id = t.tank_id order by "+Cache["strOrderBy"].ToString();
			dbobj.SelectQuery(sql,ref rdr);
			// Condensed
			//sw.Write((char)27); //added by vishnu
			//sw.Write((char)15);//commented by vishnu

			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu

			/*sw.Write((char)27);//Reverse paper
					sw.Write((char)106);
					sw.Write((char)255);

					sw.Write((char)27);
					sw.Write((char)106);
					sw.Write((char)255);*/

					
			//sw.Write((char)27);  //added by vishnu
			//sw.Write((char)67);  //added by vishnu
			//sw.Write((char)23); //added by vishnu

			sw.Write((char)27); //added by vishnu
			sw.Write((char)15);//

			sw.WriteLine("");
			//**********
			string des="----------------------------------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("==================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("NOZZEL REPORT",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("==================",des.Length));
			sw.WriteLine("+------------------------------+------------------------------+---------------------+--------------------+");
			sw.WriteLine("|          Nozzle Name         |         Machine Name         |    Product Name     |     Tank Name      |");
			sw.WriteLine("+------------------------------+------------------------------+---------------------+--------------------+");
			//             123456789012345678901234567890 123456789012345678901234567890 123456789012345678901 12345678901234567890
			if(rdr.HasRows)
			{
				// info : to set the format of the displaying fields.
				//info = " {0,-4:S}       {1,-13:S}   {2,-3:S}          {3,-11:S} {4,-21:S}";
				info = " {0,-30:S} {1,-30:S} {2,-21:S} {3,-20:S}";
				while(rdr.Read())
				{
					sw.WriteLine(info,GenUtil.TrimLength(rdr["nozzle"].ToString().Trim(),30),
						//rdr["machine_name"].ToString()+':'+rdr["machine_type"].ToString(),
						GenUtil.TrimLength(rdr["machine"].ToString(),30),
						GenUtil.TrimLength(rdr["prod_name"].ToString().Trim(),21),
						GenUtil.TrimLength(rdr["prod_abbname"].ToString().Trim(),20));
								
					//sw.WriteLine(i);

				}
			}
		
			sw.WriteLine("+------------------------------+------------------------------+---------------------+--------------------+");
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
			string path = home_drive+@"\ePetro_ExcelFile\NozzleReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select case when nozzlesortname='' then nozzle_name else nozzle_name+':'+ nozzlesortname end nozzle,machine_name+':'+machine_type machine,prod_name,prod_abbname from nozzle n, machine m,tank t where n.machine_id = m.machine_id and   n.tank_id = t.tank_id order by "+Cache["strOrderBy"].ToString();
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("Nozzle Name\tMachine Name\tProduct Name\tTank Name");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(rdr["nozzle"].ToString().Trim()+"\t"+
						rdr["machine"].ToString()+"\t"+
						rdr["prod_name"].ToString().Trim()+"\t"+
						rdr["prod_abbname"].ToString().Trim());
				}
			}
			dbobj.Dispose();
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\NozzleReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:Nozzelreport.aspx,Class:PetrolPumpClass.cs ,Method:btnprint_Click    Nozzle Report  Printed   "+"  userid "+uid);
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:Nozzelreport.aspx,Class:PetrolPumpClass.cs ,Method:btnprint_Click    Nozzle Report  Printed   "+ane.Message+" EXCEPTION "+"  userid "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:Nozzelreport.aspx,Class:PetrolPumpClass.cs ,Method:btnprint_Click    Nozzle Report  Printed   "+se.Message+" EXCEPTION "+"  userid "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:Nozzelreport.aspx,Class:PetrolPumpClass.cs ,Method:btnprint_Click    Nozzle Report  Printed   "+es.Message+" EXCEPTION "+"  userid "+uid);
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:Nozzelreport.aspx,Class:PetrolPumpClass.cs ,Method:btnprint_Click    Nozzle Report  Printed   "+ex.Message+" EXCEPTION "+"  userid "+uid);
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
				if(rdr["nozzle_id"].ToString().Trim().Length>len1)
					len1=rdr["nozzle_id"].ToString().Trim().Length;
				if(rdr["nozzle_name"].ToString().Trim().Length>len2)
					len2=rdr["nozzle_name"].ToString().Trim().Length;					
				if(rdr["machine_name"].ToString().Trim().Length>len3)
					len3=rdr["machine_name"].ToString().Trim().Length;					
				if(rdr["tank_name"].ToString().Trim().Length>len4)
					len4=rdr["tank_name"].ToString().Trim().Length;
									
				if(rdr["prod_name"].ToString().Trim().Length>len5)
					len5=rdr["prod_name"].ToString().Trim().Length;					
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
				strOrderBy = "Nozzle_ID ASC";
				Session["Column"] = "Nozzle_ID";
				Session["Order"] = "ASC";
				BindTheData();
				//			sql="select nozzle_id,nozzle_name,machine_name,tank_name,prod_name from nozzle n, machine m,tank t where n.machine_id = m.machine_id and   n.tank_id = t.tank_id";
				//			SqlDtr =obj.GetRecordSet(sql);
				//			GridNozzleReport.DataSource=SqlDtr;
				//			GridNozzleReport.DataBind();
				//			SqlDtr.Close();
				#endregion
				CreateLogFiles.ErrorLog("Form:Nozzelreport.aspx,Class:PetrolPumpClass.cs ,Method:Button1_Click   Nozzle Report  Viewed  userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Nozzelreport.aspx,Class:PetrolPumpClass.cs ,Method:Button1_Click  Nozzle Report  Viewed    "+ex.Message+" EXCEPTION "+" userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			//string sqlstr="select nozzle_id,nozzle_name+' : '+ nozzlesortname nozzle,machine_name+' : '+machine_type machine,tank_name,prod_name,prod_abbname from nozzle n, machine m,tank t where n.machine_id = m.machine_id and   n.tank_id = t.tank_id";
			string sqlstr="select nozzle_id,case when nozzlesortname='' then nozzle_name else nozzle_name+' : '+ nozzlesortname end nozzle,machine_name+' : '+machine_type machine,tank_name,prod_name,prod_abbname from nozzle n, machine m,tank t where n.machine_id = m.machine_id and   n.tank_id = t.tank_id";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "nozzle");
			DataTable dtCustomers = ds.Tables["nozzle"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridNozzleReport.DataSource = dv;
				GridNozzleReport.DataBind();
				GridNozzleReport.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridNozzleReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:NozzleReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridNozzleReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:NozzleReport.aspx,Method: btnExcel_Click, Nozzle Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:NozzleReport.aspx,Method:btnExcel_Click   Nozzle Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}