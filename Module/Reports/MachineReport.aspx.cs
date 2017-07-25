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
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using RMG;


namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for MachineReport.
	/// </summary>
	public class MachineReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.DataGrid GridMachineReport;
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.Button Button1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.Button Button2;
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnExcel;
		string UID;

		/// <summary>
		/// This method is used for setting the Session variable for userId
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				UID=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Class:PetrolPumpClass.cs,Method: page_load " + ex.Message+"  EXCEPTION " +" userid  "+UID);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="3";
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
					//	string msg="UnAthourized Visit to Machine Report Page";
					//	dbobj.LogActivity(msg,Session["User_Name"].ToString());  
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
				}
				#endregion
			}
		}

		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void MakingReport()
		{
			/*
						==================         
						  MACHINE REPORT                   
						==================        
		   +-----------+--------------+--------------+
		   |Machine.ID | Machine.Name | Machine.Type |
		   +-----------+--------------+--------------+
			1001          1-23          1234567890123  

			*/
			System.Data.SqlClient.SqlDataReader rdr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\MachineReport.txt";
			StreamWriter sw = new StreamWriter(path);

			string sql="";
			string info = "";
				
			sql="select Machine_ID,Machine_Name,Machine_Type from Machine order by "+Cache["strOrderBy"].ToString()+"";
			dbobj.SelectQuery(sql,ref rdr);
			/*	sw.Write((char)27); 
				sw.Write((char)38); 
				sw.Write((char)108); 
				sw.Write((char)49); 
				sw.Write((char)79); */
			/*sw.Write((char)27); 
			sw.Write((char)40); 
			sw.Write((char)115); 
			sw.Write((char)50);  
			sw.Write((char)72);*/
			// Condensed

			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu

			sw.Write((char)27);//added by vishnu
			sw.Write((char)15);
			sw.WriteLine("");
			//**********
			string des="-----------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("==================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("MACHINE REPORT",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("==================",des.Length));
			sw.WriteLine("+-----------+--------------+------------------------------+");
			sw.WriteLine("|Machine ID | Machine Name |         Machine Type         |");
			sw.WriteLine("+-----------+--------------+------------------------------+");
			//             12345678901 12345678901234 123456789012345678901234567890  
		        
			if(rdr.HasRows)
			{
				// info : to set the format of the string to display.
				info = " {0,-11:S} {1,-14:S} {2,-30:S}";

				while(rdr.Read())
				{
					
					sw.WriteLine(info,rdr["Machine_ID"].ToString().Trim(),
						GenUtil.TrimLength(rdr["Machine_Name"].ToString(),14),
						GenUtil.TrimLength(rdr["Machine_Type"].ToString(),30));
				}
			}
			sw.WriteLine("+-----------+--------------+------------------------------+");
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
			string path = home_drive+@"\ePetro_ExcelFile\MachineReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select Machine_ID,Machine_Name,Machine_Type from Machine order by "+Cache["strOrderBy"].ToString()+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("Machine ID\tMachine Name\tMachine Type");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(rdr["Machine_ID"].ToString().Trim()+"\t"+
						rdr["Machine_Name"].ToString()+"\t"+
						rdr["Machine_Type"].ToString());
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
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

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
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3)
		{
			while(rdr.Read())
			{
				if(rdr["Machine_ID"].ToString().Trim().Length>len1)
					len1=rdr["Machine_ID"].ToString().Trim().Length;					
				if(rdr["Machine_Name"].ToString().Trim().Length>len2)
					len2=rdr["Machine_Name"].ToString().Trim().Length;					
				if(rdr["Machine_Type"].ToString().Trim().Length>len3)
					len3=rdr["Machine_Type"].ToString().Trim().Length;
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
				strOrderBy = "Machine_ID ASC";
				Session["Column"] = "Machine_ID";
				Session["Order"] = "ASC";
				BindTheData();
				//			PetrolPumpClass  obj=new PetrolPumpClass();
				//			SqlDataReader SqlDtr;
				//			string sql;

				// select the machines and bind the data grid.
				//			sql="select * from Machine";
				//			SqlDtr =obj.GetRecordSet(sql);
				//			GridMachineReport.DataSource=SqlDtr;
				//			GridMachineReport.DataBind();
				//			SqlDtr.Close();
				CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Class:PetrolPumpClass.cs,Method:Button1_Click" +"  Machine Report Viewed  "+" userid  "+UID);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Class:PetrolPumpClass.cs,Method: Button1_Click " +"  Machine Report Viewed  "+ ex.Message+"  EXCEPTION  " +" userid  "+UID);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select * from Machine";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "Machine");
			DataTable dtCustomers = ds.Tables["Machine"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridMachineReport.DataSource = dv;
				GridMachineReport.DataBind();
			}
			else
			{
				MessageBox.Show("Data not available");
				GridMachineReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to sends the text file to print server to print.
		/// </summary>
		private void Button2_Click(object sender, System.EventArgs e)//for printing report by pankaj
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
				CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Class:PetrolPumpClass.cs,Method: Button1_Click " +" userid  "+UID);
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\MachineReport.txt<EOF>");

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
				
					CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Class:PetrolPumpClass.cs ,Method:Button2_Click" + ane.Message+"  EXCEPTION "+" userid  "+UID);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Class:PetrolPumpClass.cs ,Method:Button2_Click" + se.Message+"  EXCEPTION "+" userid  "+UID);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Class:PetrolPumpClass.cs ,Method:Button2_Click" + es.Message+"  EXCEPTION "+" userid  "+UID);
				}

			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Class:PetrolPumpClass.cs ,Method:Button2_Clic" + ex.Message+"  EXCEPTION "+" userid  "+UID);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridMachineReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Method: btnExcel_Click, Machine Report Convert Into Excel Format ,  userid  "+UID);
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
				CreateLogFiles.ErrorLog("Form:MachineReport.aspx,Method:btnExcel_Click   Machine Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+UID);
			}
		}
	}
}