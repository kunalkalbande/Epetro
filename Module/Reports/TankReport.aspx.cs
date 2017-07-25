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
	/// Summary description for TankReport.
	/// </summary>
	public class TankReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.DataGrid GridTankReport;
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.Button Btnreport;
		protected System.Web.UI.WebControls.Button Button1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		string uid;
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
			catch(Exception es)
			{
				CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:Btnreport_Click"+ es.Message+"EXCEPTION" +uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="2";
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

		//For report
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
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6,ref int len7)
		{
			while(rdr.Read())
			{
				if(rdr["Tank_ID"].ToString().Trim().Length>len1)
					len1=rdr["Tank_ID"].ToString().Trim().Length;					
				if(rdr["Tank_Name"].ToString().Trim().Length>len2)
					len2=rdr["Tank_Name"].ToString().Trim().Length;					
				if(rdr["Prod_Name"].ToString().Trim().Length>len3)
					len3=rdr["Prod_Name"].ToString().Trim().Length;	
				if(rdr["Capacity"].ToString().Trim().Length>len4)
					len4=rdr["Capacity"].ToString().Trim().Length;					
				if(rdr["Water_Stock"].ToString().Trim().Length>len5)
					len5=rdr["Water_Stock"].ToString().Trim().Length;					
				if(rdr["Reserve_Stock"].ToString().Trim().Length>len6)
					len6=rdr["Reserve_Stock"].ToString().Trim().Length;	
				if(rdr["Opening_Stock"].ToString().Trim().Length>len7)
					len7=rdr["Opening_Stock"].ToString().Trim().Length;	
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
		//End report

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
		/// This Method is used to prepares the report file .txt
		/// </summary>
		public void reportmaking()
		{
			/*
							   ================                                   
								 TANK REPORT                                      
							   ================                                   
+-------+-----------+--------------------+--------+--------+--------+---------+
|Tank ID| Tank.Name | Product Name       |Capacity| Water  |Reserve |Op.Stock |
|       |           |                    |        | Stock  | Stock  |         |
+-------+-----------+--------------------+--------+--------+--------+---------+
 1001    12345678901 12345678901234567890 12345678 12345678 12345678 123456789       
			*/
			try
			{
				System.Data.SqlClient.SqlDataReader rdr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\TankReport.txt";
				StreamWriter sw = new StreamWriter(path);
				string sql="";
				string info = "";
				sql="select Tank_ID,Tank_Name,Prod_Name,Prod_AbbName,Capacity,Water_Stock,Reserve_Stock,Opening_Stock from Tank order by "+Cache["strOrderBy"].ToString()+"";
				dbobj.SelectQuery(sql,ref rdr);

				//				sw.Write((char)27); 
				//				sw.Write('X');
				//				sw.Write('l');
				//				sw.Write((char)10);
				//sw.Write((char)0);
				/*****************************************************************************************
							  //Landscape
								sw.Write((char)27); 
								sw.Write((char)38);
								sw.Write((char)108);
								sw.Write((char)49);
								sw.Write((char)79);

								//Character Set - CP 437 International
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)49);
								sw.Write((char)48);
								sw.Write((char)85);

				
								//Character Position - (Normal) Clears Superscript and Subscript
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)115);
								sw.Write((char)48);
								sw.Write((char)85);

								//Spacing - Fixed Horizontal
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)115);
								sw.Write((char)48);
								sw.Write((char)80);

								//Pitch- 12 cpi pitch
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)115);
								sw.Write((char)49);
								sw.Write((char)50);
								sw.Write((char)72);

								//Character Heigth -  12 point character
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)115);
								sw.Write((char)49);
								sw.Write((char)50);
								sw.Write((char)86);

				
								//Print Style - Upright print style
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)115);
								sw.Write((char)48);
								sw.Write((char)83);
		
								//Stroke Weight -- Medium Stroke Intensity
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)115);
								sw.Write((char)48);
								sw.Write((char)66);

							  //True Font
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)115);
								sw.Write((char)53);
								sw.Write((char)84);

				
								//Print Quality -- Letter
								sw.Write((char)27);
								sw.Write((char)40);
								sw.Write((char)115);
								sw.Write((char)50);
								sw.Write((char)81);
								sw.WriteLine(""); 
				*******************************************************************************************/
				
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
				string des="--------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("===============",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("TANK REPORT",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("===============",des.Length));
				sw.WriteLine("+-------+-----------+--------------------+------------------------------+--------+--------+--------+---------+");
				sw.WriteLine("|Tank ID| Tank.Name | Product Name       |           Sort Name          |Capacity| Water  |Reserve |Op.Stock |");
				sw.WriteLine("|       |           |                    |                              | Stock  | Stock  |        |         |"); 
				sw.WriteLine("+-------+-----------+--------------------+------------------------------+--------+--------+--------+---------+");
				//             1001    12345678901 12345678901234567890 12345678 12345678 12345678 123456789 
				if(rdr.HasRows)
				{
					// info : to set the format of displaying values.
					info = " {0,-4:S}    {1,-11:S} {2,-20:S} {3,-30:S} {4,8:F} {5,8:F} {6,8:F} {7,9:F}";
					while(rdr.Read())
					{
					

						sw.WriteLine(info,rdr["Tank_ID"].ToString().Trim(),
							GenUtil.TrimLength(rdr["Tank_Name"].ToString().Trim(),11),
							GenUtil.TrimLength(rdr["Prod_Name"].ToString(),20),
							GenUtil.TrimLength(rdr["Prod_AbbName"].ToString(),30),
							rdr["Capacity"].ToString().Trim(),
							rdr["Water_Stock"].ToString().Trim(),
							rdr["Reserve_Stock"].ToString().Trim(),
							rdr["Opening_Stock"].ToString().Trim());

					}
				}
				sw.WriteLine("+-------+-----------+--------------------+------------------------------+--------+--------+--------+---------+");
				dbobj.Dispose();
				sw.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:reportmaking(). EXCEPTION "+ ex.Message+" User_ID: " +uid);
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
			string path = home_drive+@"\ePetro_ExcelFile\TankReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select Tank_ID,Tank_Name,Prod_Name,Prod_AbbName,Capacity,Water_Stock,Reserve_Stock,Opening_Stock from Tank order by "+Cache["strOrderBy"].ToString()+"";
			dbobj.SelectQuery(sql,ref rdr);
			sw.WriteLine("Tank ID\tTank.Name\tProduct Name\tSort Name\tCapacity\tWater Stock\tReserve Stock\tOp.Stock");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(rdr["Tank_ID"].ToString().Trim()+"\t"+
						rdr["Tank_Name"].ToString().Trim()+"\t"+
						rdr["Prod_Name"].ToString()+"\t"+
						rdr["Prod_AbbName"].ToString()+"\t"+
						rdr["Capacity"].ToString().Trim()+"\t"+
						rdr["Water_Stock"].ToString().Trim()+"\t"+
						rdr["Reserve_Stock"].ToString().Trim()+"\t"+
						rdr["Opening_Stock"].ToString().Trim());
				}
			}
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to Sends the text file to print server to print.
		/// </summary>
		private void Btnreport_Click(object sender, System.EventArgs e)
		{
			reportmaking();
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\TankReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:Btnreport_Click  Tank Report Printed  userid "+uid);
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:Btnreport_Click  Tank Report Printed   EXCEPTION  "+ ane.Message+" userid " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:Btnreport_Click  Tank Report Printed   EXCEPTION  "+ se.Message+" userid " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:Btnreport_Click  Tank Report Printed   EXCEPTION  "+ es.Message+" userid " +uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:Btnreport_Click  Tank Report Printed   EXCEPTION  "+ ex.Message+" userid " +uid);
			}
		}

		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				strOrderBy = "Tank_ID ASC";
				Session["Column"] = "Tank_ID";
				Session["Order"] = "ASC";
				BindTheData();
				//				PetrolPumpClass  obj=new PetrolPumpClass();
				//				SqlDataReader SqlDtr;
				//				string sql;
				//				sql="select * from Tank";
				//				SqlDtr =obj.GetRecordSet(sql);
				//				GridTankReport.DataSource=SqlDtr;
				//				GridTankReport.DataBind();
				//				SqlDtr.Close();
			
				CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:Button1_Click,  Tank Report Viewed   userid  "+uid);
			}
		
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TankReport.aspx,lass:PetrolPumpClass.cs,Method:Button1_Click, Tank Report Viwed   EXCEPTION "+ ex.Message+"   userid   "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select * from Tank";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "Tank");
			DataTable dtCustomers = ds.Tables["Tank"];
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
				CreateLogFiles.ErrorLog("Form:TankReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
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
					CreateLogFiles.ErrorLog("Form:TankReport.aspx,Method: btnExcel_Click, Tank Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:TankReport.aspx,Method:btnExcel_Click   Tank Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}		
	}
}