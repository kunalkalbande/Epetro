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
using System.Globalization;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using RMG;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for GovtStockRegister.
	/// </summary>
	public class GovtStockRegister : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropMonth;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.DropDownList DropProduct;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		public string city= "";
		public string dealer = "";
		public string div_office="";
		public string dealership = "";
		protected System.Web.UI.WebControls.Button Button1;
		string[,] tData;
	
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				SqlDataReader SqlDtr;
				PetrolPumpClass obj=new PetrolPumpClass();
		
				string sql="";
				uid=(Session["User_Name"].ToString());
				// Fetch Dealer name city and store in string , to access from .aspx page.
				sql="select DealerName,City,Div_Office,DealerShip from Organisation";
				SqlDtr=obj.GetRecordSet(sql); 
				if(SqlDtr.Read())
				{
					dealer = SqlDtr["DealerName"].ToString();
					city = SqlDtr["City"].ToString();
					div_office = SqlDtr["Div_Office"].ToString();
					div_office = div_office.ToUpper(); 
					dealership = SqlDtr["DealerShip"].ToString();
					dealership = dealership.ToUpper(); 
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:page_load" + ex.Message+"  EXCEPTION "+"  userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
				
			if(!IsPostBack)
			{
				try
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="16";
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
				
					DropMonth.SelectedIndex=DateTime.Now.Month;
					Session["selmonth"]=DateTime.Now.Month;
					PetrolPumpClass obj=new PetrolPumpClass();
					SqlDataReader  SqlDtr;
					string sql;

					#region Fetch Product Name
					sql="select Prod_Name from products where Category='Fuel' order by Prod_Name";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropProduct.Items.Add(SqlDtr["Prod_Name"].ToString());
					}
					SqlDtr.Close();
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:page_load  EXCEPTION " + ex.Message+"  userid  "+uid);
				}
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
			this.DropMonth.SelectedIndexChanged += new System.EventHandler(this.DropMonth_SelectedIndexChanged);
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to returns the date in MM/DD/YYYY format
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
		/// This method is used to Fetch all the information and returns the array.
		/// </summary>
		public string[,] GetData()
		{   
			try
			{
				string sql="";
				string ID="";
				SqlDataReader SqlDtr;
				PetrolPumpClass obj=new PetrolPumpClass();
				string[] arr=DropProduct.SelectedItem.Text.Split(new char[]{':'},DropProduct.SelectedItem.Text.Length);  
				if(DropProduct.SelectedIndex>0 )
				{
					sql="select Prod_ID from Products where Prod_Name='"+arr[0]+"'";
					dbobj.SelectQuery(sql,"Prod_ID",ref ID);
				}
				string Prod_ID=ID;
				int month=(int) Session["selmonth"];			
				int Days_in_Months=DateTime.DaysInMonth(DateTime.Now.Year,month);
				tData=new string[Days_in_Months,20]; 
				string[] str0 = new string[500000];
				string[] str1 = new string[500000];
				string[] str2 = new string[500000];
				string[] str3 = new string[500000];
				string[] str4 = new string[500000];
				string[] str5 = new string[500000];
				string[] str6 = new string[500000];
				string[] str7 = new string[500000];
				int l=0;
				int p=0;
				#region Initialize Array Data
				for(int i=0;i<tData.GetLength(0);i++)
				{
					for(int j=0;j<tData.GetLength(1);j++)
					{
						tData[i,j]="";
					}
				}
				#endregion
			
				for(int i=0;i<tData.GetLength(0);i++)
				{   
					string eDate=(i+1)+"/"+month.ToString()+"/"+DateTime.Now.Year.ToString(); 
					tData[i,0]=eDate;
					#region Fetch Stock Data
				
					sql="select Opening_Stock, Receipt, cast(Opening_Stock as numeric)+cast(Receipt as numeric) as Total, Sales, Closing_Stock  from stock_master where ProductID='"+Prod_ID+"' and day(Stock_Date)='"+(i+1)+"' and month(Stock_Date)='"+month+"' and year(Stock_Date)=year(getdate())";
					//if(i == 5)
					//Response.Write(sql); 
			
					SqlDtr=obj.GetRecordSet(sql); 
					tData[i,5] ="0";
					while(SqlDtr.Read())
					{
						str0[l]=eDate;  
						l++;
						tData[i,1]=SqlDtr["Opening_Stock"].ToString();
						tData[i,2]=SqlDtr["Receipt"].ToString();
						tData[i,3]=SqlDtr["Total"].ToString();
						tData[i,4]=SqlDtr["Sales"].ToString();
						tData[i,5]=SqlDtr["Closing_Stock"].ToString();
				
						str1[p]=SqlDtr["Opening_Stock"].ToString();
						str2[p]=SqlDtr["Receipt"].ToString();
						str3[p]=SqlDtr["Total"].ToString();
						str4[p]=SqlDtr["Sales"].ToString();
						str5[p]=SqlDtr["Closing_Stock"].ToString();
						p++;

					}
					SqlDtr.Close();
					#endregion
				
					#region Fetch Meter Reading
			    
					sql = "select Entry_date,d.Nozzle_id,Reading from daily_meter_reading as d,Nozzle as n,tank as t where Entry_date='"+ GenUtil.str2MMDDYYYY(eDate)+"' and d.nozzle_id =n.nozzle_id and n.tank_id = t.tank_id and  t.prod_name = '"+arr[0]+"'";
					SqlDtr=obj.GetRecordSet(sql); 
					int j=0;
					while(SqlDtr.Read())
					{
						if(j<5)
							tData[i,j+6]=SqlDtr["Reading"].ToString();
						str6[j]=SqlDtr["Reading"].ToString();
						j++;
					}
					SqlDtr.Close();
					#endregion

					#region Fetch Tank Dip Reading
				
			
					sql = "select Tank_Dip,d.Remark from Daily_Tank_Reading as d,Tank as t where Entry_Date='"+ GenUtil.str2MMDDYYYY(eDate)+"' and d.tank_id = t.tank_id and t.Prod_Name ='"+arr[0]+"'";
					SqlDtr=obj.GetRecordSet(sql); 
					j=0;
					tData[i,16]= "0";
					while(SqlDtr.Read())
					{
						if(j<5)
						{
							tData[i,j+11]=GenUtil.strNumericFormat(SqlDtr["Tank_Dip"].ToString());
							//tData[i,16]=(Int32.Parse(tData[i,16])+Int32.Parse(tData[i,j+11])).ToString();
							tData[i,16]=(double.Parse(tData[i,16])+double.Parse(tData[i,j+11])).ToString();
                      	
						}
						j++;
					
						//tData[i,17] = (Int32.Parse(tData[i,5])- Int32.Parse(tData[i,16])).ToString();					
						tData[i,17] = (double.Parse(tData[i,5])- double.Parse(tData[i,16])).ToString();					
						tData[i,18] = SqlDtr["Remark"].ToString();
					
					}			
				
					if(tData[i,17].Equals("0"))
						tData[i,17]="";
					if(tData[i,5].Equals("0"))
						tData[i,5]="";
					if(tData[i,16].Equals("0"))
						tData[i,16]="";

			    
					#endregion
				
					SqlDtr.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:GetData().  EXCEPTION " + ex.Message+"  userid  "+uid);
			}
			return tData;
		}

		/// <summary>
		/// This method is used to Fetch all the information and returns the array.
		/// </summary>
		public string[,] GetData1()
		{ 
			try
			{
				string sql="";
				string ID="";
			
				SqlDataReader SqlDtr;
				PetrolPumpClass obj=new PetrolPumpClass();
				string[] arr=DropProduct.SelectedItem.Text.Split(new char[]{':'},DropProduct.SelectedItem.Text.Length);  
				if(DropProduct.SelectedIndex>0 )
				{
					sql="select Prod_ID from Products where Prod_Name='"+arr[0]+"'";
					dbobj.SelectQuery(sql,"Prod_ID",ref ID);
				}
				string Prod_ID=ID;
				int month=DropMonth.SelectedIndex;
				int Days_in_Months=DateTime.DaysInMonth(DateTime.Now.Year,month);
				tData=new string[Days_in_Months,20]; 

				string[] str0 = new string[500000];
				string[] str1 = new string[500000];
				string[] str2 = new string[500000];
				string[] str3 = new string[500000];
				string[] str4 = new string[500000];
				string[] str5 = new string[500000];
				string[] str6 = new string[500000];
				string[] str7 = new string[500000];
				int l=0;
				int p=0;
				#region Initialize Array Data
				for(int i=0;i<tData.GetLength(0);i++)
				{
					for(int j=0;j<tData.GetLength(1);j++)
					{
						tData[i,j]="";
					}
				}
				#endregion
			
				for(int i=0;i<tData.GetLength(0);i++)
				{   
					string eDate=(i+1)+"/"+month.ToString()+"/"+DateTime.Now.Year.ToString(); 
					tData[i,0]=eDate;
					#region Fetch Stock Data
				
					sql="select Opening_Stock, Receipt, cast(Opening_Stock as numeric)+cast(Receipt as numeric) as Total, Sales, Closing_Stock  from stock_master where ProductID='"+Prod_ID+"' and day(Stock_Date)='"+(i+1)+"' and month(Stock_Date)='"+month+"' and year(Stock_Date)=year(getdate())";
			
					SqlDtr=obj.GetRecordSet(sql); 
					tData[i,5] ="0";
					while(SqlDtr.Read())
					{
						str0[l]=eDate;  
						l++;
						tData[i,1]=SqlDtr["Opening_Stock"].ToString();
						tData[i,2]=SqlDtr["Receipt"].ToString();
						tData[i,3]=SqlDtr["Total"].ToString();
						tData[i,4]=SqlDtr["Sales"].ToString();
						tData[i,5]=SqlDtr["Closing_Stock"].ToString();
			
						str1[p]=SqlDtr["Opening_Stock"].ToString();
						str2[p]=SqlDtr["Receipt"].ToString();
						str3[p]=SqlDtr["Total"].ToString();
						str4[p]=SqlDtr["Sales"].ToString();
						str5[p]=SqlDtr["Closing_Stock"].ToString();
						p++;

					}
					SqlDtr.Close();
					#endregion
				
					#region Fetch Meter Reading
					sql = "select Entry_date,d.Nozzle_id,Reading from daily_meter_reading as d,Nozzle as n,tank as t where Entry_date='"+ToMMddYYYY(eDate).ToShortDateString()+"' and d.nozzle_id =n.nozzle_id and n.tank_id = t.tank_id and  t.prod_name = '"+arr[0]+"'";
					SqlDtr=obj.GetRecordSet(sql); 
					int j=0;
					while(SqlDtr.Read())
					{
						if(j<5)
							tData[i,j+6]=SqlDtr["Reading"].ToString();
						str6[j]=SqlDtr["Reading"].ToString();
						j++;
					}
					SqlDtr.Close();
					#endregion

					#region Fetch Tank Dip Reading
				
			
					sql = "select Tank_Dip,d.Remark from Daily_Tank_Reading as d,Tank as t where Entry_Date='"+ToMMddYYYY(eDate).ToShortDateString()+"' and d.tank_id = t.tank_id and t.Prod_Name ='"+arr[0]+"'";
					SqlDtr=obj.GetRecordSet(sql); 
					j=0;
					tData[i,16]= "0";
					while(SqlDtr.Read())
					{
						if(j<5)
						{
							tData[i,j+11]=SqlDtr["Tank_Dip"].ToString();
							tData[i,16]=(Int32.Parse(tData[i,16])+Int32.Parse(tData[i,j+11])).ToString();
						
					
                      	
						}
						j++;
					
						tData[i,17] = (Int32.Parse(tData[i,5])- Int32.Parse(tData[i,16])).ToString();					
						tData[i,18] = SqlDtr["Remark"].ToString();
					
					}			
				
					if(tData[i,17].Equals("0"))
						tData[i,17]="";
					if(tData[i,5].Equals("0"))
						tData[i,5]="";
					if(tData[i,16].Equals("0"))
						tData[i,16]="";

			    
					#endregion
				
					SqlDtr.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:GetData1().  EXCEPTION " + ex.Message+"  userid  "+uid);
			}
			return tData;
		}

		/// <summary>
		/// This method is used to set the month index no in session variable.
		/// </summary>
		private void DropMonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropMonth.SelectedIndex==0)
			{
				MessageBox.Show("Please select the correct Month");
				DropMonth.SelectedIndex=(int)Session["selmonth"];
				return;
			}
			//put the selected month in session.
			Session["selmonth"]=DropMonth.SelectedIndex;
		}

		/// <summary>
		/// This method is used to call the GetData() function for prepare the report.
		/// </summary>
		private void btnView_Click(object sender, System.EventArgs e)
		{                       
			try
			{
                if (DropProduct.SelectedIndex == 0)
                {
                    MessageBox.Show("- Please Select Product Name");
                    return;
                }
                if (DropMonth.SelectedIndex==0)
				{
					MessageBox.Show("Please select the correct Month");
					DropMonth.SelectedIndex=(int)Session["selmonth"];
					return;
				}
				// Put the selected month in session.
				Session["selmonth"]=DropMonth.SelectedIndex;
				GetData();
				CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:btnView_Click" +"  GOVT. STOCK REGISTER VIEWED "+" userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:btnView_Click" + "  GOVT. STOCK REGISTER VIEWED "+ex.Message+" EXCEPTION "+" userid  "+uid);
			}
		}

		public void Write2File1(StreamWriter sw, string info)
		{
			sw.WriteLine(info);
		}


		//----------------------for report-----------------------------

		/// <summary>
		/// This method is used to sends the text file to print server to print.	
		/// </summary>
		public void Print()
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\GovtReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:print "+"  GOVT. STOCK REGISTER PRINTED "+" userid  " +uid);
					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:print "+"  GOVT. STOCK REGISTER PRINTED "+"  EXCEPTION  "+ane.Message+" userid  " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:print "+"  GOVT. STOCK REGISTER PRINED "+"  EXCEPTION  "+se.Message+" userid  " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:print "+"  GOVT. STOCK REGISTER PRINTED "+"  EXCEPTION  "+es.Message+" userid  " +uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:print "+"  GOVT. STOCK REGISTER PRINTED "+"  EXCEPTION  "+ex.Message+" userid  " +uid);
			}
		}
	
		/// <summary>
		/// This method is used for printing. 
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)//for Print
		{
			try
			{
                if (DropProduct.SelectedIndex == 0)
                {
                    MessageBox.Show("- Please Select Product Name");
                    return;
                }
                if (DropMonth.SelectedIndex==0)
				{
					MessageBox.Show("Please select the correct Month");
					DropMonth.SelectedIndex=(int)Session["selmonth"];
					return;
				}
				Session["selmonth"]=DropMonth.SelectedIndex;
				//string[,] tData1= GetData();
				Session["Data"] = GetData();
				Session["Product"] = DropProduct.SelectedItem.Text;
				Session["Month"] = DropMonth.SelectedItem.Text;
				Session["Dealer"] = dealer;
				Session["Location"] = city; 
				Session["DealerShip"] = dealership;
				Session["Div_Office"] = div_office; 
				Response.Redirect("GovtStockRegister_PrintPreview.aspx",false); 
   
				//				string home_drive = Environment.SystemDirectory;
				//				home_drive = home_drive.Substring(0,2); 
				//				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\GovtReport.txt";
				//				StreamWriter sw = new StreamWriter(path);
				//				string info = "";
				//				/*
				//																			 =======================                                                                          
				//																			   GOVT STOCK REGISTER                                                                         
				//																			 ======================= 
				//					Dealer Name : 
				//					Location    : 														                                                                         
				//					+----------+----------+----------+----------+----------+----------+------------------------------------------------------+----------------------------------+----------+--------------------+
				//					|          | Opening  |          |          |          | Closing  |                    Meter Reading                     |            Dip Stock             |Difference|      Remarks       |
				//					|  Date    |  Stock   | Receipt  |  Total   |  Sales   |  Stock   |----------+----------+----------+----------+----------+------+------+------+------+------+ between  |                    |
				//					|          |          |          |          |          |          |     1    |    2     |     3    |    4     |    5     |  T-1 | T-2  |  T-3 |  T-4 |  T-5 |  6 & 8   |                    |                                                                                           
				//					+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+------+------+------+------+------+----------+--------------------+
				//					|    1     |     2    |    3     |    4          5     |     6    |                           7                          |                 8                |    9     |         10         |
				//					+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+------+------+------+------+------+----------+--------------------+
				//					 10/12/2006 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 123.50 123.50 123.50 123.50 123.50 1234567890 xxxxxxxxxxxxxxxxxxxx
				//
				//					*/	
				//				// info : to set the format of the string to display in the report.
				//				info = " {0,-10:S} {1,10:F} {2,10:F} {3,10:F} {4,10:F} {5,10:F} {6,10:F} {7,10:F} {8,10:F} {9,10:F} {10,10:F} {11,6:F} {12,6:F} {13,6:F} {14,6:F} {15,6:F} {16,6:F} {17,10:F} {18,-20:S}";
				//				sw.WriteLine("                                                         =======================");
				//				sw.WriteLine("                                                           GOVT STOCK REGISTER");
				//				sw.WriteLine("                                                         =======================");
				//				sw.WriteLine("Dealer Name : "+dealer);
				//				sw.WriteLine("Location    : "+city);
				//				sw.WriteLine("Product     : "+DropProduct.SelectedItem.Text.ToString());
				//				sw.WriteLine("Month       : "+DropMonth.SelectedItem.Text.ToString());
				//				sw.WriteLine("+----------+----------+----------+----------+----------+----------+------------------------------------------------------+-----------------------------------------+----------+--------------------+");
				//				sw.WriteLine("|          | Opening  |          |          |          | Closing  |                    Meter Reading                     |            Dip Stock                    |Difference|      Remarks       |");
				//				sw.WriteLine("|  Date    |  Stock   | Receipt  |  Total   |  Sales   |  Stock   |----------+----------+----------+----------+----------+------+------+------+------+------+------+ between  |                    |");
				//				sw.WriteLine("|          |          |          |          |          |          |     1    |    2     |     3    |    4     |    5     |  T-1 | T-2  |  T-3 |  T-4 |  T-5 |Total |  6 & 8   |                    |");
				//				sw.WriteLine("+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+------+------+------+------+------+------+----------+--------------------+");
				//				sw.WriteLine("|    1     |     2    |    3     |    4          5     |     6    |                           7                          |                    8                    |    9     |         10         |");
				//				sw.WriteLine("+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+------+------+------+------+------+------+----------+--------------------+");
				//			
				//			
				//				int len2 = tData1.GetLength(0);
				//				for (int kk=0;kk<tData1.GetLength(0);kk++)
				//				{   
				//					sw.WriteLine(info,tData1[kk,0],tData1[kk,1],tData1[kk,2],tData1[kk,3],tData1[kk,4],
				//						tData1[kk,5],tData1[kk,6],tData1[kk,7],tData1[kk,8],tData1[kk,9],
				//						tData1[kk,10],tData1[kk,11],tData1[kk,12],tData1[kk,13],tData1[kk,14],
				//						tData1[kk,15],tData1[kk,16],tData1[kk,17],tData1[kk,18]
				//						);
				//				}
				//
				//				sw.WriteLine("+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+------+------+------+------+------+------+----------+--------------------+");
				//
				//				sw.Close();	
				//				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:GovermentStockregistor.aspx,Class:PetrolPumpClass.cs ,Method:Button1_Click.  EXCEPTION  "+ex.Message+" userid  " +uid);
			}
		}
	}
}