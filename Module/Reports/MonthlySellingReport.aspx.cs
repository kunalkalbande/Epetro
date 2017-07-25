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
using RMG;
using System.Data .SqlClient ;
using System.Net; 
using System.Net.Sockets ;
using System.IO ;
using System.Text;
using DBOperations;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for MonthlySellingReport.
	/// </summary>
	public class MonthlySellingReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DropDownList DropMonth;
		protected System.Web.UI.WebControls.DropDownList DropYear;
		public static string[] date;
		public static int Month;
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
			catch(Exception ex)
			{				
				CreateLogFiles.ErrorLog("Form:MonthlySaellingReport.aspx,Method:pageload"+ ex.Message+"  EXCEPTION "+"   "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(DropYear.SelectedIndex!=0 && DropMonth.SelectedIndex!=0)
			{
				//btnExcel.Visible=false;
				Month = DropMonth.SelectedIndex;
				int Day = DateTime.DaysInMonth(int.Parse(DropYear.SelectedItem.Text),Month);
				date = new string[Day];
			}
			if(!Page.IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="31";
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// This method is used to sends the text file to print server to print.
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
					CreateLogFiles.ErrorLog("Form:MonthlySellingReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    Monthly Selling Report  Printed"+"  userid  " +uid);
					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\MonthlySellingReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:MonthlySellingReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    MonthlySelling Report  Printed"+"  EXCEPTION "+ane.Message+"  userid  " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:MonthlySellingReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt   MonthlySelling Report  Printed"+"  EXCEPTION "+se.Message+"  userid  " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:MonthlySellingReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    MonthlySelling Report  Printed"+"  EXCEPTION "+es.Message+"  userid  " +uid);
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:MonthlySellingReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt    MonthlySelling Report  Printed"+"  EXCEPTION "+ex.Message+"  userid  " +uid);
			}
		}

		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void MakingReport()
		{
			if(DropMonth.SelectedIndex!=0 && DropYear.SelectedIndex!=0)
			{						
				SqlDataReader rdr=null,SqlDtr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\MonthlySellingReport.txt";
				StreamWriter sw = new StreamWriter(path);
				
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27); //added by vishnu for condensed
				sw.Write((char)15);//
				sw.WriteLine("");
				
				DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
				InventoryClass obj=new InventoryClass();
				int MS=0,SMS=0,HSD=0,SHSD=0,CNG=0,LPG=0,OTHER=0;
				//string ms="",sms="",hsd="",shsd="",cng="",lpg="",other="";
				dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref rdr);
				string info="+------------------+";
				string info1="+------------------+";
				if(rdr.Read())
				{
					info1+="---------------------+";
					info+="----------+----------+";
					//ms=rdr["Prod_ID"].ToString();
					MS=1;
				}
				dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref rdr);
				if(rdr.Read())
				{
					info1+="---------------------+";
					info+="----------+----------+";
					//sms=rdr["Prod_ID"].ToString();
					SMS=1;
				}
				dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Diesel(HSD)%'",ref rdr);
				if(rdr.Read())
				{
					info1+="---------------------+";
					info+="----------+----------+";
					//hsd=rdr["Prod_ID"].ToString();
					HSD=1;
				}
				dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref rdr);
				if(rdr.Read())
				{
					info1+="---------------------+";
					info+="----------+----------+";
					//shsd=rdr["Prod_ID"].ToString();
					SHSD=1;
				}
				dbobj.SelectQuery("select Prod_ID from Products where Category <> 'Fuel'",ref rdr);
				if(rdr.Read())
				{
					info1+="---------------------+";
					info+="----------+----------+";
					//other=rdr["Prod_ID"].ToString();
					OTHER=1;
				}
				dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'CNG%'",ref rdr);
				if(rdr.Read())
				{
					info1+="---------------------+";
					info+="----------+----------+";
					//cng=rdr["Prod_ID"].ToString();
					CNG=1;
				}
				dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Auto LPG%'",ref rdr);
				if(rdr.Read())
				{
					info1+="---------------------+";
					info+="----------+----------+";
					//lpg=rdr["Prod_ID"].ToString();
					LPG=1;
				}
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],info.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],info.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],info.Length));
				for(int j=0;j<info.Length;j++)
				{
					sw.Write("-");
				}
				sw.WriteLine();
				//string dess="";
				string Name = "MONTHLY SELLING REPORT FOR "+DropMonth.SelectedItem.Text+" "+DropYear.SelectedItem.Text;
				//for(int i=0;i<Name.Length+2;i++)
				//{
				//	dess+="=";
				//}
				//sw.WriteLine(GenUtil.GetCenterAddr("dess",info.Length));
				sw.WriteLine(GenUtil.GetCenterAddr(Name.ToUpper(),info.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("dess",info.Length));
				sw.WriteLine(info1);
				sw.Write("|       Date       |");
				if(MS==1)
					sw.Write("     MS(Petrol)      |");
				if(SMS==1)
					sw.Write("     Super Petrol    |");
				if(HSD==1)
					sw.Write("    HSD(Diesel)      |");
				if(SHSD==1)
					sw.Write("    Super Diesel     |");
				if(OTHER==1)
					sw.Write(" Oil(Lube & Grease)  |");
				if(CNG==1)
					sw.Write("        CNG          |");
				if(LPG==1)
					sw.Write("        LPG          |");
				sw.WriteLine();
				sw.WriteLine(info);
				sw.Write("|                  |");
				if(MS==1)
					sw.Write("Sell      | Lose/Plus|");
				if(SMS==1)
					sw.Write("Sell      | Lose/Plus|");
				if(HSD==1)
					sw.Write("Sell      | Lose/Plus|");
				if(SHSD==1)
					sw.Write("Sell      | Lose/Plus|");
				if(OTHER==1)
					sw.Write("Sell      | Lose/Plus|");
				if(CNG==1)
					sw.Write("Sell      | Lose/Plus|");
				if(LPG==1)
					sw.Write("Sell      | Lose/Plus|");
				sw.WriteLine();
				sw.WriteLine(info);
				string str="";
				double TotalMS=0,TotalHSD=0,TotalOil=0,TotalSMS=0,TotalSHSD=0,TotalCNG=0,TotalLPG=0;
				double CalMS=0,CalHSD=0,CalOil,CalSMS=0,CalSHSD=0,CalCNG=0,CalLPG=0;
				for(int i=1;i<date.Length+1;i++)
				{
					string dt = Month.ToString()+"/"+i.ToString()+"/"+DropYear.SelectedItem.Text;
					str=i.ToString()+"-"+DropMonth.SelectedItem.Text+"-"+DropYear.SelectedItem.Text;
					sw.Write(" "+str);
					for(int j=str.Length;j<=18;j++)
					{
						sw.Write(" ");
					}
					if(MS==1)
					{
						CalMS=0;
						dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref SqlDtr);
						while(SqlDtr.Read())
						{
							dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_date='"+dt+"'",ref rdr);
							if(rdr.Read())
							{
								if(rdr.GetValue(0).ToString()!="")
								{
									CalMS+=double.Parse(rdr.GetValue(0).ToString());
									TotalMS+=double.Parse(rdr.GetValue(0).ToString());
								}
							}
						}
						sw.Write(CalMS.ToString());
						for(int j=CalMS.ToString().Length;j<=21;j++)
						{
							sw.Write(" ");
						}
					}	
					
					if(SMS==1)
					{
						CalSMS=0;
						dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
						while(SqlDtr.Read())
						{
							dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
							if(rdr.Read())
							{
								if(rdr.GetValue(0).ToString()!="")
								{
									CalSMS+=double.Parse(rdr.GetValue(0).ToString());
									TotalSMS+=double.Parse(rdr.GetValue(0).ToString());
								}
							}
						}
						sw.Write(CalSMS.ToString());
						for(int j=CalSMS.ToString().Length;j<=21;j++)
						{
							sw.Write(" ");
						}
					}
					if(HSD==1)
					{
						CalHSD=0;
						dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Diesel(HSD)%'",ref SqlDtr);
						while(SqlDtr.Read())
						{
							dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
							if(rdr.Read())
							{
								if(rdr.GetValue(0).ToString()!="")
								{
									str=rdr.GetValue(0).ToString();
									CalHSD+=double.Parse(rdr.GetValue(0).ToString());
									TotalHSD+=double.Parse(rdr.GetValue(0).ToString());
								}
							}
						}
						sw.Write(CalHSD.ToString());
						for(int j=CalHSD.ToString().Length;j<=21;j++)
						{
							sw.Write(" ");
						}
					}
					if(SHSD==1)
					{
						CalSHSD=0;
						dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
						while(SqlDtr.Read())
						{
							dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
							if(rdr.Read())
							{
								if(rdr.GetValue(0).ToString()!="")
								{
									CalSHSD+=double.Parse(rdr.GetValue(0).ToString());
									TotalSHSD+=double.Parse(rdr.GetValue(0).ToString());
								}
							}
						}
						sw.Write(CalSHSD.ToString());
						for(int j=CalSHSD.ToString().Length;j<=21;j++)
						{
							sw.Write(" ");
						}
					}
					if(OTHER==1)
					{
						CalOil=0;
						dbobj.SelectQuery("select Prod_ID from Products where Category<>'Fuel'",ref SqlDtr);
						while(SqlDtr.Read())
						{
							dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
							if(rdr.Read())
							{
								if(rdr.GetValue(0).ToString()!="")
								{
									CalOil+=double.Parse(rdr.GetValue(0).ToString());
									TotalOil+=double.Parse(rdr.GetValue(0).ToString());
								}
							}
						}
						sw.Write(CalOil.ToString());
						for(int j=CalOil.ToString().Length;j<=21;j++)
						{
							sw.Write(" ");
						}
					}
					if(CNG==1)
					{
						CalCNG=0;
						dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'CNG%'",ref SqlDtr);
						while(SqlDtr.Read())
						{
							dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
							if(rdr.Read())
							{
								if(rdr.GetValue(0).ToString()!="")
								{
									CalCNG+=double.Parse(rdr.GetValue(0).ToString());
									TotalCNG+=double.Parse(rdr.GetValue(0).ToString());
								}
							}
						}
						sw.Write(CalCNG.ToString());
						for(int j=CalCNG.ToString().Length;j<=21;j++)
						{
							sw.Write(" ");
						}
					}
					if(LPG==1)
					{
						CalLPG=0;
						dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Auto LPG%'",ref SqlDtr);
						while(SqlDtr.Read())
						{
							dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
							if(rdr.Read())
							{
								if(rdr.GetValue(0).ToString()!="")
								{
									CalLPG+=double.Parse(rdr.GetValue(0).ToString());
									TotalLPG+=double.Parse(rdr.GetValue(0).ToString());
								}
							}
						}
						sw.Write(CalLPG.ToString());
						for(int j=CalLPG.ToString().Length;j<=21;j++)
						{
							sw.Write(" ");
						}
					}
					sw.WriteLine();
				}
				sw.WriteLine(info);
				sw.Write("       Total        ");
				if(MS==1)
				{
					sw.Write(TotalMS.ToString());
					for(int j=TotalMS.ToString().Length;j<=21;j++)
					{
						sw.Write(" ");
					}
				}
				if(SMS==1)
				{
					sw.Write(TotalSMS.ToString());
					for(int j=TotalSMS.ToString().Length;j<=21;j++)
					{
						sw.Write(" ");
					}
				}
				if(HSD==1)
				{
					sw.Write(TotalHSD.ToString());
					for(int j=TotalHSD.ToString().Length;j<=21;j++)
					{
						sw.Write(" ");
					}
				}
				if(SHSD==1)
				{
					sw.Write(TotalSHSD.ToString());
					for(int j=TotalSHSD.ToString().Length;j<=21;j++)
					{
						sw.Write(" ");
					}
				}
				if(OTHER==1)
				{
					sw.Write(TotalOil.ToString());
					for(int j=TotalOil.ToString().Length;j<=21;j++)
					{
						sw.Write(" ");
					}
				}
				if(CNG==1)
				{
					sw.Write(TotalCNG.ToString());
					for(int j=TotalCNG.ToString().Length;j<=21;j++)
					{
						sw.Write(" ");
					}
				}
				if(LPG==1)
				{
					sw.Write(TotalLPG.ToString());
					for(int j=TotalLPG.ToString().Length;j<=21;j++)
					{
						sw.Write(" ");
					}
				}
				sw.WriteLine();
				sw.WriteLine(info);
				sw.Close();
			}
		}

		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\MonthlySellingReport.xls";
			StreamWriter sw = new StreamWriter(path);
			DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
			InventoryClass obj=new InventoryClass();
			SqlDataReader rdr=null,SqlDtr=null;
			int MS=0,SMS=0,HSD=0,SHSD=0,CNG=0,LPG=0,OTHER=0;
			//string ms="",sms="",hsd="",shsd="",cng="",lpg="",other="";
			//dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref rdr);
			rdr = obj.GetRecordSet("select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'");
			if(rdr.Read())
				MS=1;
			rdr.Close();
			//dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref rdr);
			rdr = obj.GetRecordSet("select Prod_ID from Products where Prod_Name like 'Super Petrol%'");
			if(rdr.Read())
				SMS=1;
			rdr.Close();
			//dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Diesel(HSD)%'",ref rdr);
			rdr = obj.GetRecordSet("select Prod_ID from Products where Prod_Name like 'Diesel(HSD)%'");
			if(rdr.Read())
				HSD=1;
			rdr.Close();
			//dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref rdr);
			rdr = obj.GetRecordSet("select Prod_ID from Products where Prod_Name like 'Super Diesel%'");
			if(rdr.Read())
				SHSD=1;
			rdr.Close();
			//dbobj.SelectQuery("select Prod_ID from Products where Category <> 'Fuel'",ref rdr);
			rdr = obj.GetRecordSet("select Prod_ID from Products where Category <> 'Fuel'");
			if(rdr.Read())
				OTHER=1;
			rdr.Close();
			//dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'CNG%'",ref rdr);
			rdr = obj.GetRecordSet("select Prod_ID from Products where Prod_Name like 'CNG%'");
			if(rdr.Read())
				CNG=1;
			rdr.Close();
			//dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Auto LPG%'",ref rdr);
			rdr = obj.GetRecordSet("select Prod_ID from Products where Prod_Name like 'Auto LPG%'");
			if(rdr.Read())
				LPG=1;
			rdr.Close();
			sw.WriteLine("Month / Year\t"+DropMonth.SelectedItem.Text.ToString()+" "+DropYear.SelectedItem.Text.ToString());
			sw.Write("Date\t");
			if(MS==1)
				sw.Write("MS(Petrol)\t\t");
			if(SMS==1)
				sw.Write("Super Petrol\t\t");
			if(HSD==1)
				sw.Write("HSD(Diesel)\t\t");
			if(SHSD==1)
				sw.Write("Super Diesel\t\t");
			if(OTHER==1)
				sw.Write("Oil(Lube & Grease)\t\t");
			if(CNG==1)
				sw.Write("CNG\t\t");
			if(LPG==1)
				sw.Write("LPG");
			sw.WriteLine();
			sw.Write("\t");
			if(MS==1)
				sw.Write("Sell\tLose/Plus\t");
			if(SMS==1)
				sw.Write("Sell\tLose/Plus\t");
			if(HSD==1)
				sw.Write("Sell\tLose/Plus\t");
			if(SHSD==1)
				sw.Write("Sell\tLose/Plus\t");
			if(OTHER==1)
				sw.Write("Sell\tLose/Plus\t");
			if(CNG==1)
				sw.Write("Sell\tLose/Plus\t");
			if(LPG==1)
				sw.Write("Sell\tLose/Plus\t");
			sw.WriteLine();
			string str="";
			double TotalMS=0,TotalHSD=0,TotalOil=0,TotalSMS=0,TotalSHSD=0,TotalCNG=0,TotalLPG=0;
			double CalMS=0,CalHSD=0,CalOil,CalSMS=0,CalSHSD=0,CalCNG=0,CalLPG=0;
			for(int i=1;i<date.Length+1;i++)
			{
				string dt = Month.ToString()+"/"+i.ToString()+"/"+DropYear.SelectedItem.Text;
				str=i.ToString()+"-"+DropMonth.SelectedItem.Text+"-"+DropYear.SelectedItem.Text;
				sw.Write(str+"\t");
				if(MS==1)
				{
					CalMS=0;
					dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref SqlDtr);
					while(SqlDtr.Read())
					{
						//dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_date='"+dt+"'",ref rdr);
						rdr = obj.GetRecordSet("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'");
						if(rdr.Read())
						{
							if(rdr.GetValue(0).ToString()!="")
							{
								CalMS+=double.Parse(rdr.GetValue(0).ToString());
								TotalMS+=double.Parse(rdr.GetValue(0).ToString());
							}
						}
						rdr.Close();
					}
					sw.Write(CalMS.ToString()+"\t\t");
				}	
					
				if(SMS==1)
				{
					CalSMS=0;
					dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
					while(SqlDtr.Read())
					{
						//dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_date='"+dt+"'",ref rdr);
						rdr = obj.GetRecordSet("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'");
						if(rdr.Read())
						{
							if(rdr.GetValue(0).ToString()!="")
							{
								CalSMS+=double.Parse(rdr.GetValue(0).ToString());
								TotalSMS+=double.Parse(rdr.GetValue(0).ToString());
							}
						}
						rdr.Close();
					}
					sw.Write(CalSMS.ToString()+"\t\t");
				}
				if(HSD==1)
				{
					CalHSD=0;
					dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Diesel(HSD)%'",ref SqlDtr);
					while(SqlDtr.Read())
					{
						//dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_date='"+dt+"'",ref rdr);
						rdr = obj.GetRecordSet("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'");
						if(rdr.Read())
						{
							if(rdr.GetValue(0).ToString()!="")
							{
								str=rdr.GetValue(0).ToString();
								CalHSD+=double.Parse(rdr.GetValue(0).ToString());
								TotalHSD+=double.Parse(rdr.GetValue(0).ToString());
							}
						}
						rdr.Close();
					}
					sw.Write(CalHSD.ToString()+"\t\t");
				}
				if(SHSD==1)
				{
					CalSHSD=0;
					dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
					while(SqlDtr.Read())
					{
						//dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_date='"+dt+"'",ref rdr);
						rdr = obj.GetRecordSet("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'");	
						if(rdr.Read())
						{
							if(rdr.GetValue(0).ToString()!="")
							{
								CalSHSD+=double.Parse(rdr.GetValue(0).ToString());
								TotalSHSD+=double.Parse(rdr.GetValue(0).ToString());
							}
						}
						rdr.Close();
					}
					sw.Write(CalSHSD.ToString()+"\t\t");
				}
				if(OTHER==1)
				{
					CalOil=0;
					dbobj.SelectQuery("select Prod_ID from Products where Category<>'Fuel'",ref SqlDtr);
					while(SqlDtr.Read())
					{
						//dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_date='"+dt+"'",ref rdr);
						rdr = obj.GetRecordSet("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'");
						if(rdr.Read())
						{
							if(rdr.GetValue(0).ToString()!="")
							{
								CalOil+=double.Parse(rdr.GetValue(0).ToString());
								TotalOil+=double.Parse(rdr.GetValue(0).ToString());
							}
						}
						rdr.Close();
					}
					sw.Write(CalOil.ToString()+"\t\t");
				}
				if(CNG==1)
				{
					CalCNG=0;
					dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'CNG%'",ref SqlDtr);
					while(SqlDtr.Read())
					{
						//dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_date='"+dt+"'",ref rdr);
						rdr = obj.GetRecordSet("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'");
						if(rdr.Read())
						{
							if(rdr.GetValue(0).ToString()!="")
							{
								CalCNG+=double.Parse(rdr.GetValue(0).ToString());
								TotalCNG+=double.Parse(rdr.GetValue(0).ToString());
							}
						}
						rdr.Close();
					}
					sw.Write(CalCNG.ToString()+"\t\t");
				}
				if(LPG==1)
				{
					CalLPG=0;
					dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Auto LPG%'",ref SqlDtr);
					while(SqlDtr.Read())
					{
						//dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_date='"+dt+"'",ref rdr);
						rdr = obj.GetRecordSet("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'");
						if(rdr.Read())
						{
							if(rdr.GetValue(0).ToString()!="")
							{
								CalLPG+=double.Parse(rdr.GetValue(0).ToString());
								TotalLPG+=double.Parse(rdr.GetValue(0).ToString());
							}
						}
						rdr.Close();
					}
					sw.Write(CalLPG.ToString()+"\t\t");
				}
				sw.WriteLine();
			}
			sw.Write("Total\t");
			if(MS==1)
				sw.Write(TotalMS.ToString()+"\t\t");
			if(SMS==1)
				sw.Write(TotalSMS.ToString()+"\t\t");
			if(HSD==1)
				sw.Write(TotalHSD.ToString()+"\t\t");
			if(SHSD==1)
				sw.Write(TotalSHSD.ToString()+"\t\t");
			if(OTHER==1)
				sw.Write(TotalOil.ToString()+"\t\t");
			if(CNG==1)
				sw.Write(TotalCNG.ToString()+"\t\t");
			if(LPG==1)
				sw.Write(TotalLPG.ToString()+"\t\t");
			sw.WriteLine();
			dbobj.Dispose();
			rdr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropMonth.SelectedIndex!=0 && DropYear.SelectedIndex!=0)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:MonthlySellingReport.aspx,Method: btnExcel_Click, MonthlySelling Report Convert Into Excel Format ,  userid  "+uid);
				}
				else
				{
					MessageBox.Show("Please Select The Month & Year From DropDownList");
					return;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:MonthlySellingReport.aspx,Method:btnExcel_Click   MonthlySelling Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}