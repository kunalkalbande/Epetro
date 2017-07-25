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
using System.Data.SqlClient;
using System.Drawing;
using DBOperations;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPetro.Sysitem.Classes;
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for DailySalesReport.
	/// </summary>
	public class DailySalesReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtChkNo1;
		protected System.Web.UI.WebControls.TextBox txtAmt1;
		protected System.Web.UI.WebControls.TextBox txtBank1;
		protected System.Web.UI.WebControls.TextBox txtChkNo2;
		protected System.Web.UI.WebControls.TextBox txtAmt2;
		protected System.Web.UI.WebControls.TextBox txtBank2;
		protected System.Web.UI.WebControls.TextBox txtChkNo3;
		protected System.Web.UI.WebControls.TextBox txtAmt3;
		protected System.Web.UI.WebControls.TextBox txtBank3;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempoilrs;
		public static int Flag=0;
		protected System.Web.UI.WebControls.Button btnExcel;
		string uid;
	
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required textboxes values 
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
				CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Method:pageload"+ ex.Message+"  EXCEPTION "+"   "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			//btnPrint.Visible=false;
			if(!Page.IsPostBack)
			{
				txtDateFrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
				txtDateTo.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
				Flag=0;
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="32";
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
				if(Add_Flag=="0")
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
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to view the report according to set Flag variable
		/// if Flag=1 then show the report otherwise not.
		/// </summary>
		private void btnView_Click(object sender, System.EventArgs e)
		{
			Flag=1;
		}

		/// <summary>
		/// This method is used to clear the forms.
		/// </summary>
		public void clear()
		{
			txtDateFrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtDateTo.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			TextBox[] Cheque = {txtChkNo1,txtChkNo2,txtChkNo3};
			TextBox[] Amount = {txtAmt1,txtAmt2,txtAmt3};
			TextBox[] Bank = {txtBank1,txtBank2,txtBank3};
			for(int i=0;i<Cheque.Length;i++)
			{
				Cheque[i].Text="";
				Amount[i].Text="";
				Bank[i].Text="";
			}
		}

		/// <summary>
		/// This method is used to insert the Fuel Supplier Cheque information in the database.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
				InventoryClass obj=new InventoryClass();
				SqlCommand cmd;
				int Flag=0,Count=0;
				TextBox[] Cheque = {txtChkNo1,txtChkNo2,txtChkNo3};
				TextBox[] Amount = {txtAmt1,txtAmt2,txtAmt3};
				TextBox[] Bank = {txtBank1,txtBank2,txtBank3};
				for(int i=0;i<Cheque.Length;i++)
				{
					if(Cheque[i].Text!="")
					{
						if(Amount[i].Text!="")
						{
							if(Bank[i].Text!="")
							{
								Count++;
								
							}
							else
							{
								MessageBox.Show("Please Enter The Bank Name");
								return;
							}
						}
						else
						{
							MessageBox.Show("Please Enter The Amount");
							return;
						}
					}
					else
					{
						if(i==0)
						{
							MessageBox.Show("Please Enter The Cheque No");
							return;
						}
					}
				}
				for(int j=0;j<Count;j++)
				{
					con.Open();
					cmd=new SqlCommand("insert into BPCLCheque values('"+Cheque[j].Text+"','"+Amount[j].Text+"','"+Bank[j].Text+"')",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					Flag=1;
				}
				if(Flag==1)
				{
					MessageBox.Show("Record Saved");
					clear();
				}
				CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Method:btnSave : Record Saved , User : "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Method:btnSave "+ ex.Message+"  EXCEPTION "+"   "+uid);
				return;
			}
		}

		/// <summary>
		/// This method is used to prepares the report file DailySalesCumAcSheetReport.txt for printing.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
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
					CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Class:Inventory.cs,Method:btnprint_Clickt   DailySalesCumActSheet Report  Printed"+"  userid  " +uid);
					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\DailySalesCumAcSheetReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt   DailySalesCumActSheet Report  Printed"+"  EXCEPTION "+ane.Message+"  userid  " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    DailySalesCumActSheet Report  Printed"+"  EXCEPTION "+se.Message+"  userid  " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt   DailySalesCumActSheet Report  Printed"+"  EXCEPTION "+es.Message+"  userid  " +uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt   DailySalesCumActSheet Report  Printed"+"  EXCEPTION "+ex.Message+"  userid  " +uid);
			}
		}
		
		/// <summary>
		/// This method is used to write into the report file to print.
		/// </summary>
		public void MakingReport()
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\DailySalesCumAcSheetReport.txt";
			StreamWriter sw = new StreamWriter(path);
			DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr=null,rdr=null;
			string info = " {0,-40:S} {1,-25:S} {2,-25:S} {3,-25:S}";
			string info1 = " {0,-40:S} {1,-20:S}";
			string info2 = "|{0,-27:S} {1,-17:S} {2,-17:S} {3,-17:S} {4,-17:S} {5,-17:S} {6,-17:S}|";
			string info3 = " {0,-27:S} {1,-20:S} {2,-20:S} ";
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
			sw.WriteLine();
			//**********
			string des="+---------------------------------------------------------------------------------------------------------------------------------------+";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("=============================================================",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("DAILY SALES CUM A/C SHEET REPORT FOR "+txtDateFrom.Text+" TO "+txtDateTo.Text,des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=============================================================",des.Length));
			sw.WriteLine(info,"","Check Nomber","Amount(Rs.)","Bank Name");
			sw.WriteLine(info,"BPCL CHECK(UNDER CLEARING) : ","","","");
			sw.WriteLine(info,"",txtChkNo1.Text,txtAmt1.Text,txtBank1.Text);
			sw.WriteLine(info,"",txtChkNo2.Text,txtAmt2.Text,txtBank2.Text);
			sw.WriteLine(info,"",txtChkNo3.Text,txtAmt3.Text,txtBank3.Text);
			dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Sub_grp_id=118",ref SqlDtr);
			sw.WriteLine(des);
			if(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = '"+SqlDtr["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by Entry_Date desc",ref rdr);
				if(rdr.Read())
					sw.WriteLine(info1,"CASH ON HAND (Evening / Day Close) : ",rdr.GetValue(0).ToString()+" "+rdr.GetValue(1).ToString());
				else
					sw.WriteLine(info1,"CASH ON HAND (Evening / Day Close) : ","0");
			}
			
			sw.WriteLine(des);
			sw.WriteLine(info2,"STOCK MOVEMENT","MS","HSD","Super Petrol","Super Diesel","OIL(IN S-R)","OIL(IN GODW.)");
			double OPMS=0,OPHSD=0,OPSMS=0,OPSHSD=0,OPSROil=0,OPGDOil=0;
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name LIKE 'Petrol(ms)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
						OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
							OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
						OPHSD+=double.Parse(rdr["Opening_Stock"].ToString());
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
							OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
						OPSMS+=double.Parse(rdr["Opening_Stock"].ToString());
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
							OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 * from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
						//if(rdr["receipt"].ToString().Equals("0") && rdr["sales"].ToString().Equals("0"))
						OPSHSD+=double.Parse(rdr["Closing_Stock"].ToString());
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
							OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
					{
						if(SqlDtr["store_in"].ToString()=="Sales Room")
						{
							OPSROil+=double.Parse(rdr["Opening_Stock"].ToString());
						}
						else if(SqlDtr["store_in"].ToString()=="Godown")
						{
							OPGDOil+=double.Parse(rdr["Opening_Stock"].ToString());
						}
					}
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
						{
							if(SqlDtr["store_in"].ToString()=="Sales Room")
							{
								OPSROil+=double.Parse(rdr["Opening_Stock"].ToString());
							}
							else if(SqlDtr["store_in"].ToString()=="Godown")
							{
								OPGDOil+=double.Parse(rdr["Opening_Stock"].ToString());
							}
						}
					}
				}
			}
			sw.WriteLine(info2,"Opening Stock",OPMS.ToString(),OPHSD.ToString(),OPSMS.ToString(),OPSHSD.ToString(),OPSROil.ToString(),OPGDOil.ToString());
			double SalMS=0,SalHSD=0,SalSMS=0,SalSHSD=0,SalSROther=0,SalGDOther=0;
			double PurMS=0,PurHSD=0,PurSMS=0,PurSHSD=0,PurSROther=0,PurGDOther=0;
			double CLMS=0,CLHSD=0,CLSMS=0,CLSHSD=0,CLSROil=0,CLGDOil=0;
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						SalMS+=double.Parse(rdr["sales"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						SalHSD+=double.Parse(rdr["sales"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						SalSMS+=double.Parse(rdr["sales"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						SalSHSD+=double.Parse(rdr["sales"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						if(SqlDtr["store_in"].ToString()=="Sales Room")
						{
							SalSROther+=double.Parse(rdr["sales"].ToString());}
						else if(SqlDtr["store_in"].ToString()=="Godown")
						{
							SalGDOther+=double.Parse(rdr["sales"].ToString());
						}
					}
				}
			}
			sw.WriteLine(info2,"Sales",SalMS.ToString(),SalHSD.ToString(),SalSMS.ToString(),SalSHSD.ToString(),SalSROther.ToString(),SalGDOther.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(ms)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						PurMS+=double.Parse(rdr["receipt"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						PurHSD+=double.Parse(rdr["receipt"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						PurSMS+=double.Parse(rdr["receipt"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						PurSHSD+=double.Parse(rdr["receipt"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						if(SqlDtr["store_in"].ToString()=="Sales Room")
						{
							PurSROther+=double.Parse(rdr["receipt"].ToString());}
						else if(SqlDtr["store_in"].ToString()=="Godown")
						{
							PurGDOther+=double.Parse(rdr["receipt"].ToString());
						}
					}
				}
			}
			sw.WriteLine(info2,"Purchase",PurMS.ToString(),PurHSD.ToString(),PurSMS.ToString(),PurSHSD.ToString(),PurSROther.ToString(),PurGDOther.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(ms)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						CLMS+=double.Parse(rdr["Closing_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						CLHSD+=double.Parse(rdr["Closing_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						CLSMS+=double.Parse(rdr["Closing_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						CLSHSD+=double.Parse(rdr["Closing_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						if(SqlDtr["store_in"].ToString()=="Sales Room")
						{
							CLSROil+=double.Parse(rdr["Closing_Stock"].ToString());}
						else if(SqlDtr["store_in"].ToString()=="Godown")
						{
							CLGDOil+=double.Parse(rdr["Closing_Stock"].ToString());
						}
					}
				}
			}
			sw.WriteLine(info2,"Closing Stock",CLMS.ToString(),CLHSD.ToString(),CLSMS.ToString(),CLSHSD.ToString(),CLSROil.ToString(),CLGDOil.ToString());
			sw.WriteLine(des);
			sw.WriteLine("  CASH FLOW MANAGEMENT");
			sw.WriteLine("+---------------------------------------------------------------+");
			sw.WriteLine(info3,"INCOME (CASH RECEIVED)","","");
			sw.WriteLine(info3,"PARTICULARS","SALES","RS.");
			double CalMS=0,CalHSD=0,CalSMS=0,CalSHSD=0,CalOil=0,CalOther=0;
			double AmtMS=0,AmtHSD=0,AmtSMS=0,AmtSHSD=0,AmtOil=0,AmtOther=0;
			double TotalSell=0,TotalRS=0,TotalPRS=0;
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Petrol(ms)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalMS+=double.Parse(rdr.GetValue(0).ToString());
						AmtMS+=double.Parse(rdr.GetValue(1).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine(info3,"MS",CalMS.ToString(),AmtMS.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalHSD+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtHSD+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine(info3,"HSD",CalHSD.ToString(),AmtHSD.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalSMS+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtSMS+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine(info3,"Super Petrol",CalSMS.ToString(),AmtSMS.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalSHSD+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtSHSD+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine(info3,"Super Diesel",CalSHSD.ToString(),AmtSHSD.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Category <> 'Fuel' and store_in<>'Other'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalOil+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtOil+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine(info3,"Oil",CalOil.ToString(),AmtOil.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Category <> 'Fuel' and store_in='Other'",ref SqlDtr);
			if(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalOther+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtOther+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine(info3,"Other",CalOther.ToString(),AmtOther.ToString());
			SqlDataReader rdr1=null,rdr2=null,rdr3=null;
			string BalType=" Cr";
			dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where (grp_id=21 or grp_id=22 or grp_id=23)",ref rdr1);
			while(rdr1.Read())
			{
				dbobj.SelectQuery("Select Ledger_ID,Ledger_Name from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr2);
				while(rdr2.Read())
				{
					
					dbobj.SelectQuery("Select sum(Credit_Amount-Debit_Amount) Amount from AccountsLedgerTable where Ledger_ID='"+rdr2["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr3);
					if(rdr3.Read())
					{
						if(rdr3["Amount"].ToString()!="")
						{
							if(double.Parse(rdr3["Amount"].ToString())>0)
								BalType=" Cr";
							else
								BalType=" Dr";
							TotalRS+=Math.Abs(double.Parse(rdr3["Amount"].ToString()));		
							sw.WriteLine(info3,rdr2["Ledger_Name"].ToString(),"",System.Convert.ToString(Math.Abs(double.Parse(rdr3["Amount"].ToString())))+BalType);
						}
					}
				}
			}
			sw.WriteLine("+---------------------------------------------------------------+");
			sw.WriteLine(info3,"        Total",TotalSell.ToString(),TotalRS.ToString());
			sw.WriteLine("+---------------------------------------------------------------+");
			sw.WriteLine(info3,"EXPENSES","","");
			sw.WriteLine(info3,"PARTICULARS","","RS.");
			
			//dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where Sub_grp_Name like 'Indirect%' or Sub_grp_Name like 'Direct%'",ref rdr1);
			dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where (grp_id=24 or grp_id=25 or grp_id=26) or (Sub_grp_ID=117 or Sub_grp_ID=126 or Sub_grp_ID=127)",ref rdr1);
			while(rdr1.Read())
			{
				dbobj.SelectQuery("Select Ledger_ID,Ledger_Name from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr2);
				while(rdr2.Read())
				{
					dbobj.SelectQuery("Select sum(Credit_Amount-Debit_Amount) Amount from AccountsLedgerTable where Ledger_ID='"+rdr2["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr3);
					if(rdr3.Read())
					{
						if(rdr3["Amount"].ToString()!="")
						{
							if(double.Parse(rdr3["Amount"].ToString())>0)
								BalType=" Cr";
							else
								BalType=" Dr";
							TotalPRS+=Math.Abs(double.Parse(rdr3["Amount"].ToString()));		
							sw.WriteLine(info3,rdr2["Ledger_Name"].ToString(),"",System.Convert.ToString(Math.Abs(double.Parse(rdr3["Amount"].ToString())))+BalType);
						}
						else
						{
							sw.WriteLine(info3,rdr2["Ledger_Name"].ToString(),"","0");
						}

					}
				}
			}
			dbobj.SelectQuery("Select sum(Debit_Amount) Amount from AccountsLedgerTable where Particulars like 'Contra%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr2);
			if(rdr2.Read())
			{
				if(rdr2["Amount"].ToString()!="")
				{
					TotalPRS+=double.Parse(rdr2["Amount"].ToString());
					sw.WriteLine(info3,"Contra","",rdr2["Amount"].ToString());
				}
			}
			dbobj.SelectQuery("select * from ledger_master_sub_grp where sub_grp_name like 'bank%'and (grp_id=17 or grp_id=13)",ref rdr1); 
			while(rdr1.Read())
			{
				dbobj.SelectQuery("Select * from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr3);
				if(rdr3.Read())
				{
					dbobj.SelectQuery("Select sum(Debit_Amount) Debit_Amount from AccountsLedgerTable where Ledger_ID = '"+rdr3["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr2);
					if(rdr2.Read())
					{
						TotalPRS+=double.Parse(rdr2["Debit_Amount"].ToString());
						sw.WriteLine(info3,rdr3["Ledger_Name"].ToString(),"",rdr2["Debit_Amount"].ToString());
					}
				}
			}
			sw.WriteLine("+---------------------------------------------------------------+");
			sw.WriteLine(info3,"        Total","",TotalPRS.ToString());
			sw.WriteLine("+---------------------------------------------------------------+");
			sw.Close();
		}
		
		/// <summary>
		/// This Method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\DailySalesCumActSheetReport.xls";
			StreamWriter sw = new StreamWriter(path);
			DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr=null,rdr=null;
			sw.WriteLine("Form Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+txtDateTo.Text);
			sw.WriteLine("\tCheck Nomber\tAmount(Rs.)\tBank Name");
			sw.WriteLine("BPCL CHECK(UNDER CLEARING) : ");
			sw.WriteLine("\t"+txtChkNo1.Text+"\t"+txtAmt1.Text+"\t"+txtBank1.Text);
			sw.WriteLine("\t"+txtChkNo2.Text+"\t"+txtAmt2.Text+"\t"+txtBank2.Text);
			sw.WriteLine("\t"+txtChkNo3.Text+"\t"+txtAmt3.Text+"\t"+txtBank3.Text);
			dbobj.SelectQuery("Select Ledger_ID from Ledger_Master where Sub_grp_id=118",ref SqlDtr);
			sw.WriteLine();
			if(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = '"+SqlDtr["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by Entry_Date desc",ref rdr);
				if(rdr.Read())
					sw.WriteLine("CASH ON HAND (Evening / Day Close) : \t"+rdr.GetValue(0).ToString()+" "+rdr.GetValue(1).ToString());
				else
					sw.WriteLine("CASH ON HAND (Evening / Day Close) : \t"+"0");
			}
			
			sw.WriteLine();
			sw.WriteLine("STOCK MOVEMENT\tMS\tHSD\tSuper Petrol\tSuper Diesel\tOIL(IN S-R)\tOIL(IN GODW.)");
			double OPMS=0,OPHSD=0,OPSMS=0,OPSHSD=0,OPSROil=0,OPGDOil=0;
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name LIKE 'Petrol(ms)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
						OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
							OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
						OPHSD+=double.Parse(rdr["Opening_Stock"].ToString());
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
							OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
						OPSMS+=double.Parse(rdr["Opening_Stock"].ToString());
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
							OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 * from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
						//if(rdr["receipt"].ToString().Equals("0") && rdr["sales"].ToString().Equals("0"))
						OPSHSD+=double.Parse(rdr["Closing_Stock"].ToString());
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
							OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Opening_Stock"].ToString()!="")
					{
						if(SqlDtr["store_in"].ToString()=="Sales Room")
						{
							OPSROil+=double.Parse(rdr["Opening_Stock"].ToString());
						}
						else if(SqlDtr["store_in"].ToString()=="Godown")
						{
							OPGDOil+=double.Parse(rdr["Opening_Stock"].ToString());
						}
					}
				}
				else
				{
					dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
					if(rdr.Read())
					{
						if(rdr["Opening_Stock"].ToString()!="")
						{
							if(SqlDtr["store_in"].ToString()=="Sales Room")
							{
								OPSROil+=double.Parse(rdr["Opening_Stock"].ToString());
							}
							else if(SqlDtr["store_in"].ToString()=="Godown")
							{
								OPGDOil+=double.Parse(rdr["Opening_Stock"].ToString());
							}
						}
					}
				}
			}
			sw.WriteLine("Opening Stock\t"+OPMS.ToString()+"\t"+OPHSD.ToString()+"\t"+OPSMS.ToString()+"\t"+OPSHSD.ToString()+"\t"+OPSROil.ToString()+"\t"+OPGDOil.ToString());
			double SalMS=0,SalHSD=0,SalSMS=0,SalSHSD=0,SalSROther=0,SalGDOther=0;
			double PurMS=0,PurHSD=0,PurSMS=0,PurSHSD=0,PurSROther=0,PurGDOther=0;
			double CLMS=0,CLHSD=0,CLSMS=0,CLSHSD=0,CLSROil=0,CLGDOil=0;
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						SalMS+=double.Parse(rdr["sales"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						SalHSD+=double.Parse(rdr["sales"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						SalSMS+=double.Parse(rdr["sales"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						SalSHSD+=double.Parse(rdr["sales"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["sales"].ToString()!="")
					{
						if(SqlDtr["store_in"].ToString()=="Sales Room")
						{
							SalSROther+=double.Parse(rdr["sales"].ToString());}
						else if(SqlDtr["store_in"].ToString()=="Godown")
						{
							SalGDOther+=double.Parse(rdr["sales"].ToString());
						}
					}
				}
			}
			sw.WriteLine("Sales\t"+SalMS.ToString()+"\t"+SalHSD.ToString()+"\t"+SalSMS.ToString()+"\t"+SalSHSD.ToString()+"\t"+SalSROther.ToString()+"\t"+SalGDOther.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(ms)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						PurMS+=double.Parse(rdr["receipt"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						PurHSD+=double.Parse(rdr["receipt"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						PurSMS+=double.Parse(rdr["receipt"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						PurSHSD+=double.Parse(rdr["receipt"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr["receipt"].ToString()!="")
					{
						if(SqlDtr["store_in"].ToString()=="Sales Room")
						{
							PurSROther+=double.Parse(rdr["receipt"].ToString());}
						else if(SqlDtr["store_in"].ToString()=="Godown")
						{
							PurGDOther+=double.Parse(rdr["receipt"].ToString());
						}
					}
				}
			}
			sw.WriteLine("Purchase\t"+PurMS.ToString()+"\t"+PurHSD.ToString()+"\t"+PurSMS.ToString()+"\t"+PurSHSD.ToString()+"\t"+PurSROther.ToString()+"\t"+PurGDOther.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(ms)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						CLMS+=double.Parse(rdr["Closing_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						CLHSD+=double.Parse(rdr["Closing_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						CLSMS+=double.Parse(rdr["Closing_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						CLSHSD+=double.Parse(rdr["Closing_Stock"].ToString());
					}
				}
			}
			dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
				if(rdr.Read())
				{
					if(rdr["Closing_Stock"].ToString()!="")
					{
						if(SqlDtr["store_in"].ToString()=="Sales Room")
						{
							CLSROil+=double.Parse(rdr["Closing_Stock"].ToString());}
						else if(SqlDtr["store_in"].ToString()=="Godown")
						{
							CLGDOil+=double.Parse(rdr["Closing_Stock"].ToString());
						}
					}
				}
			}
			sw.WriteLine("Closing Stock\t"+CLMS.ToString()+"\t"+CLHSD.ToString()+"\t"+CLSMS.ToString()+"\t"+CLSHSD.ToString()+"\t"+CLSROil.ToString()+"\t"+CLGDOil.ToString());
			sw.WriteLine();
			sw.WriteLine("  CASH FLOW MANAGEMENT");
			sw.WriteLine();
			sw.WriteLine("INCOME (CASH RECEIVED)");
			sw.WriteLine("PARTICULARS\tSALES\tRS.");
			double CalMS=0,CalHSD=0,CalSMS=0,CalSHSD=0,CalOil=0,CalOther=0;
			double AmtMS=0,AmtHSD=0,AmtSMS=0,AmtSHSD=0,AmtOil=0,AmtOther=0;
			double TotalSell=0,TotalRS=0,TotalPRS=0;
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Petrol(ms)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalMS+=double.Parse(rdr.GetValue(0).ToString());
						AmtMS+=double.Parse(rdr.GetValue(1).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine("MS\t"+CalMS.ToString()+"\t"+AmtMS.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Diesel(hsd)%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalHSD+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtHSD+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine("HSD\t"+CalHSD.ToString()+"\t"+AmtHSD.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Super Petrol%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalSMS+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtSMS+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine("Super Petrol\t"+CalSMS.ToString()+"\t"+AmtSMS.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Super Diesel%'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalSHSD+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtSHSD+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine("Super Diesel\t"+CalSHSD.ToString()+"\t"+AmtSHSD.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Category <> 'Fuel' and store_in<>'Other'",ref SqlDtr);
			while(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalOil+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtOil+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine("Oil\t"+CalOil.ToString()+"\t"+AmtOil.ToString());
			dbobj.SelectQuery("Select Prod_ID from Products where Category <> 'Fuel' and store_in='Other'",ref SqlDtr);
			if(SqlDtr.Read())
			{
				dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
				if(rdr.Read())
				{
					if(rdr.GetValue(0).ToString()!="")
					{
						CalOther+=double.Parse(rdr.GetValue(0).ToString());
						TotalSell+=double.Parse(rdr.GetValue(0).ToString());
						TotalRS+=double.Parse(rdr.GetValue(1).ToString());
						AmtOther+=double.Parse(rdr.GetValue(1).ToString());
					}
				}
			}
			sw.WriteLine("Other\t"+CalOther.ToString()+"\t"+AmtOther.ToString());
			SqlDataReader rdr1=null,rdr2=null,rdr3=null;
			string BalType=" Cr";
			dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where (grp_id=21 or grp_id=22 or grp_id=23)",ref rdr1);
			while(rdr1.Read())
			{
				dbobj.SelectQuery("Select Ledger_ID,Ledger_Name from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr2);
				while(rdr2.Read())
				{
					dbobj.SelectQuery("Select sum(Credit_Amount-Debit_Amount) Amount from AccountsLedgerTable where Ledger_ID='"+rdr2["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr3);
					if(rdr3.Read())
					{
						if(rdr3["Amount"].ToString()!="")
						{
							if(double.Parse(rdr3["Amount"].ToString())>0)
								BalType=" Cr";
							else
								BalType=" Dr";
							TotalRS+=Math.Abs(double.Parse(rdr3["Amount"].ToString()));
							sw.WriteLine(System.Convert.ToString(rdr2["Ledger_Name"].ToString())+"\t\t"+System.Convert.ToString(Math.Abs(double.Parse(rdr3["Amount"].ToString())))+BalType);
						}
						else
						{
							sw.WriteLine(rdr2["Ledger_Name"].ToString()+"\t\t"+"0");
						}

					}
				}
			}
			sw.WriteLine("Total\t"+TotalSell.ToString()+"\t"+TotalRS.ToString());
			sw.WriteLine();
			sw.WriteLine("EXPENSES");
			sw.WriteLine("PARTICULARS\t\tRS.");
			
			//dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where Sub_grp_Name like 'Indirect%' or Sub_grp_Name like 'Direct%'",ref rdr1);
			dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where (grp_id=24 or grp_id=25 or grp_id=26) or (Sub_grp_ID=117 or Sub_grp_ID=126 or Sub_grp_ID=127)",ref rdr1);
			while(rdr1.Read())
			{
				dbobj.SelectQuery("Select Ledger_ID,Ledger_Name from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr2);
				while(rdr2.Read())
				{
					dbobj.SelectQuery("Select sum(Credit_Amount-Debit_Amount) Amount from AccountsLedgerTable where Ledger_ID='"+rdr2["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr3);
					if(rdr3.Read())
					{
						if(rdr3["Amount"].ToString()!="")
						{
							if(double.Parse(rdr3["Amount"].ToString())>0)
								BalType=" Cr";
							else
								BalType=" Dr";
							TotalPRS+=Math.Abs(double.Parse(rdr3["Amount"].ToString()));		
							sw.WriteLine(rdr2["Ledger_Name"].ToString()+"\t\t"+System.Convert.ToString(Math.Abs(double.Parse(rdr3["Amount"].ToString())))+BalType);
						}
						else
						{
							sw.WriteLine(rdr2["Ledger_Name"].ToString()+"\t\t"+"0");
						}
					}
				}
			}
			dbobj.SelectQuery("Select sum(Debit_Amount) Amount from AccountsLedgerTable where Particulars like 'Contra%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr2);
			if(rdr2.Read())
			{
				if(rdr2["Amount"].ToString()!="")
				{
					TotalPRS+=double.Parse(rdr2["Amount"].ToString());
					sw.WriteLine("Contra\t\t"+rdr2["Amount"].ToString());
				}
			}
			dbobj.SelectQuery("select * from ledger_master_sub_grp where sub_grp_name like 'bank%'and (grp_id=17 or grp_id=13)",ref rdr1); 
			while(rdr1.Read())
			{
				dbobj.SelectQuery("Select * from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr3);
				if(rdr3.Read())
				{
					dbobj.SelectQuery("Select sum(Debit_Amount) Debit_Amount from AccountsLedgerTable where Ledger_ID = '"+rdr3["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"'",ref rdr2);
					if(rdr2.Read())
					{
						TotalPRS+=double.Parse(rdr2["Debit_Amount"].ToString());
						sw.WriteLine(rdr3["Ledger_Name"].ToString()+"\t\t"+rdr2["Debit_Amount"].ToString());
					}
				}
			}
			sw.WriteLine("Total\t\t"+TotalPRS.ToString());
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to prepares the excel report file DailySalesCumActSheetReport.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertToExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Method: btnExcel_Click, DailySalesCumActSheet Report Convert Into Excel Format ,  userid  "+uid);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:DailySalesCumActSheet.aspx,Method:btnExcel_Click   DailySalesCumActSheet Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}