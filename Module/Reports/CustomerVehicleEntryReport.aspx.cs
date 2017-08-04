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
	/// This report view the all vehicle no information in particular customer.
	/// </summary>
	public class CustomerVehicleEntryReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Btnprint;
		protected System.Web.UI.WebControls.DropDownList DropCustName;
		protected System.Web.UI.WebControls.Button btnExcel;
		public static string[] arr1 = new string[12];
		public static string[] arr2 = new string[12];
		public static string[] arr3 = new string[12];
		public static string[] arr4 = new string[12];
		public static string[] arr5 = new string[12];
		public static string[] arr6 = new string[12];
		public static string[] arr7 = new string[12];
		public static string[] arr8 = new string[12];
		public static string[] arr9 = new string[12];
		public static string[] arr10 = new string[12];
		string uid;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		static int Flag=0;
	
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
				CreateLogFiles.ErrorLog("Form:PriceList.aspx,Class:PetrolPumpClass.cs,Method:pageload"+ ex.Message+ "  EXCEPTION" +uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack)
			{
				//string [] arr={arr1,arr2,arr3,arr4,arr5,arr6,arr7,arr8,arr9,arr10};
				InventoryClass obj = new InventoryClass();
				SqlDataReader rdr;
				string str="select cust_name from customer where cust_id in (select distinct cust_id from customer_vehicles)";
				rdr=obj.GetRecordSet(str);
				DropCustName.Items.Clear();
				DropCustName.Items.Add("Select");
				while(rdr.Read())
				{
					DropCustName.Items.Add(rdr.GetValue(0).ToString());
				}
				rdr.Close();
				// To checks the user privileges from session.
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="35";
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
					return;
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
			this.Btnprint.Click += new System.EventHandler(this.Btnprint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to show the all vehicle corresponding to select particualr customer from dropdownlist.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
            StringBuilder errorMessage = new StringBuilder();
            if (DropCustName.SelectedIndex == 0)
            {
                errorMessage.Append("Please Select Customer Name");
                errorMessage.Append("\n");
            }
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage.ToString());
                return;
            }
			InventoryClass obj = new InventoryClass();
			SqlDataReader rdr;
			for(int k=0;k<arr1.Length;k++)
			{
				arr1[k]=" ";
				arr2[k]=" ";
				arr3[k]=" ";
				arr4[k]=" ";
				arr5[k]=" ";
				arr6[k]=" ";
				arr7[k]=" ";
				arr8[k]=" ";
				arr9[k]=" ";
				arr10[k]=" ";
			}
			string str="select * from customer_vehicles where cust_id =(select cust_id from customer where cust_name='"+DropCustName.SelectedItem.Text+"')";
			rdr=obj.GetRecordSet(str);
			int i=0,j=1;
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					Flag=1;
					if(j==1)
					{
						arr1[i++]=rdr["CVE_ID"].ToString();
						arr1[i++]=rdr["Vehicle_No1"].ToString();
						arr1[i++]=rdr["Vehicle_No2"].ToString();
						arr1[i++]=rdr["Vehicle_No3"].ToString();
						arr1[i++]=rdr["Vehicle_No4"].ToString();
						arr1[i++]=rdr["Vehicle_No5"].ToString();
						arr1[i++]=rdr["Vehicle_No6"].ToString();
						arr1[i++]=rdr["Vehicle_No7"].ToString();
						arr1[i++]=rdr["Vehicle_No8"].ToString();
						arr1[i++]=rdr["Vehicle_No9"].ToString();
						arr1[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==2)
					{
						arr2[i++]=rdr["CVE_ID"].ToString();
						arr2[i++]=rdr["Vehicle_No1"].ToString();
						arr2[i++]=rdr["Vehicle_No2"].ToString();
						arr2[i++]=rdr["Vehicle_No3"].ToString();
						arr2[i++]=rdr["Vehicle_No4"].ToString();
						arr2[i++]=rdr["Vehicle_No5"].ToString();
						arr2[i++]=rdr["Vehicle_No6"].ToString();
						arr2[i++]=rdr["Vehicle_No7"].ToString();
						arr2[i++]=rdr["Vehicle_No8"].ToString();
						arr2[i++]=rdr["Vehicle_No9"].ToString();
						arr2[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==3)
					{
						arr3[i++]=rdr["CVE_ID"].ToString();
						arr3[i++]=rdr["Vehicle_No1"].ToString();
						arr3[i++]=rdr["Vehicle_No2"].ToString();
						arr3[i++]=rdr["Vehicle_No3"].ToString();
						arr3[i++]=rdr["Vehicle_No4"].ToString();
						arr3[i++]=rdr["Vehicle_No5"].ToString();
						arr3[i++]=rdr["Vehicle_No6"].ToString();
						arr3[i++]=rdr["Vehicle_No7"].ToString();
						arr3[i++]=rdr["Vehicle_No8"].ToString();
						arr3[i++]=rdr["Vehicle_No9"].ToString();
						arr3[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==4)
					{
						arr4[i++]=rdr["CVE_ID"].ToString();
						arr4[i++]=rdr["Vehicle_No1"].ToString();
						arr4[i++]=rdr["Vehicle_No2"].ToString();
						arr4[i++]=rdr["Vehicle_No3"].ToString();
						arr4[i++]=rdr["Vehicle_No4"].ToString();
						arr4[i++]=rdr["Vehicle_No5"].ToString();
						arr4[i++]=rdr["Vehicle_No6"].ToString();
						arr4[i++]=rdr["Vehicle_No7"].ToString();
						arr4[i++]=rdr["Vehicle_No8"].ToString();
						arr4[i++]=rdr["Vehicle_No9"].ToString();
						arr4[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==5)
					{
						arr5[i++]=rdr["CVE_ID"].ToString();
						arr5[i++]=rdr["Vehicle_No1"].ToString();
						arr5[i++]=rdr["Vehicle_No2"].ToString();
						arr5[i++]=rdr["Vehicle_No3"].ToString();
						arr5[i++]=rdr["Vehicle_No4"].ToString();
						arr5[i++]=rdr["Vehicle_No5"].ToString();
						arr5[i++]=rdr["Vehicle_No6"].ToString();
						arr5[i++]=rdr["Vehicle_No7"].ToString();
						arr5[i++]=rdr["Vehicle_No8"].ToString();
						arr5[i++]=rdr["Vehicle_No9"].ToString();
						arr5[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==6)
					{
						arr6[i++]=rdr["CVE_ID"].ToString();
						arr6[i++]=rdr["Vehicle_No1"].ToString();
						arr6[i++]=rdr["Vehicle_No2"].ToString();
						arr6[i++]=rdr["Vehicle_No3"].ToString();
						arr6[i++]=rdr["Vehicle_No4"].ToString();
						arr6[i++]=rdr["Vehicle_No5"].ToString();
						arr6[i++]=rdr["Vehicle_No6"].ToString();
						arr6[i++]=rdr["Vehicle_No7"].ToString();
						arr6[i++]=rdr["Vehicle_No8"].ToString();
						arr6[i++]=rdr["Vehicle_No9"].ToString();
						arr6[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==7)
					{
						arr7[i++]=rdr["CVE_ID"].ToString();
						arr7[i++]=rdr["Vehicle_No1"].ToString();
						arr7[i++]=rdr["Vehicle_No2"].ToString();
						arr7[i++]=rdr["Vehicle_No3"].ToString();
						arr7[i++]=rdr["Vehicle_No4"].ToString();
						arr7[i++]=rdr["Vehicle_No5"].ToString();
						arr7[i++]=rdr["Vehicle_No6"].ToString();
						arr7[i++]=rdr["Vehicle_No7"].ToString();
						arr7[i++]=rdr["Vehicle_No8"].ToString();
						arr7[i++]=rdr["Vehicle_No9"].ToString();
						arr7[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==8)
					{
						arr8[i++]=rdr["CVE_ID"].ToString();
						arr8[i++]=rdr["Vehicle_No1"].ToString();
						arr8[i++]=rdr["Vehicle_No2"].ToString();
						arr8[i++]=rdr["Vehicle_No3"].ToString();
						arr8[i++]=rdr["Vehicle_No4"].ToString();
						arr8[i++]=rdr["Vehicle_No5"].ToString();
						arr8[i++]=rdr["Vehicle_No6"].ToString();
						arr8[i++]=rdr["Vehicle_No7"].ToString();
						arr8[i++]=rdr["Vehicle_No8"].ToString();
						arr8[i++]=rdr["Vehicle_No9"].ToString();
						arr8[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==9)
					{
						arr9[i++]=rdr["CVE_ID"].ToString();
						arr9[i++]=rdr["Vehicle_No1"].ToString();
						arr9[i++]=rdr["Vehicle_No2"].ToString();
						arr9[i++]=rdr["Vehicle_No3"].ToString();
						arr9[i++]=rdr["Vehicle_No4"].ToString();
						arr9[i++]=rdr["Vehicle_No5"].ToString();
						arr9[i++]=rdr["Vehicle_No6"].ToString();
						arr9[i++]=rdr["Vehicle_No7"].ToString();
						arr9[i++]=rdr["Vehicle_No8"].ToString();
						arr9[i++]=rdr["Vehicle_No9"].ToString();
						arr9[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
					else if(j==10)
					{
						arr10[i++]=rdr["CVE_ID"].ToString();
						arr10[i++]=rdr["Vehicle_No1"].ToString();
						arr10[i++]=rdr["Vehicle_No2"].ToString();
						arr10[i++]=rdr["Vehicle_No3"].ToString();
						arr10[i++]=rdr["Vehicle_No4"].ToString();
						arr10[i++]=rdr["Vehicle_No5"].ToString();
						arr10[i++]=rdr["Vehicle_No6"].ToString();
						arr10[i++]=rdr["Vehicle_No7"].ToString();
						arr10[i++]=rdr["Vehicle_No8"].ToString();
						arr10[i++]=rdr["Vehicle_No9"].ToString();
						arr10[i++]=rdr["Vehicle_No10"].ToString();
						j++;
						i=0;
					}
				}
			}
			else
				Flag=0;
		}

		/// <summary>
		/// This method is used to sends the text file to print server to print.
		/// </summary>
		private void Btnprint_Click(object sender, System.EventArgs e)
		{
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
				bool ff = makingReport();
				if(ff==false)
				{
					MessageBox.Show("Please Click The View Button First");
					return;
				}
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
					CreateLogFiles.ErrorLog("Form:CustomerVehicleEntryReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt  CustomerVehicleEntry Report  Printed"+"  userid  " +uid);
					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CustomerVehicleEntryReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:CustomerVehicleEntryReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt  CustomerVehicleEntry Report  Printed"+"  EXCEPTION "+ane.Message+"  userid  " +uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerVehicleEntryReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt  CustomerVehicleEntry Report  Printed"+"  EXCEPTION "+se.Message+"  userid  " +uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerVehicleEntryReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt  CustomerVehicleEntry Report  Printed"+"  EXCEPTION "+es.Message+"  userid  " +uid);
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:CustomerVehicleEntryReport.aspx,Class:PetrolPumpClass.cs,Method:btnprint_Clickt CustomerVehicleEntry Report  Printed"+"  EXCEPTION "+ex.Message+"  userid  " +uid);
			}
		}
		
		/// <summary>
		/// This Method is used to prepare the report file .txt to print.
		/// </summary>
		public bool makingReport()
		{
			int count=0;
			if(Flag==1)
			{
				//System.Data.SqlClient.SqlDataReader rdr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CustomerVehicleEntryReport.txt";
				StreamWriter sw = new StreamWriter(path);
				count=1;

				//***added by vishnu ***//
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27); //added by vishnu for condensed
				sw.Write((char)15);//
				//**********
				sw.WriteLine();
				string des="-----------------------------------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Customer Vehicles Entry Report",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------",des.Length));
				string info1 = " {0,-5:S}   {1,-12:S} {2,-12:S} {3,-12:S} {4,-12:S} {5,-12:S} {6,-12:S} {7,-12:S} {8,-12:S} {9,-12:S} {10,-12:S}";
				string info = "  {0,-5:S}{1,-12:S} {2,-12:S} {3,-12:S} {4,-12:S} {5,-12:S} {6,-12:S} {7,-12:S} {8,-12:S} {9,-12:S} {10,-12:S}";
				int i=0;
				sw.WriteLine("Customer Name : "+DropCustName.SelectedItem.Text);
				sw.WriteLine("+-----+------------+------------+------------+------------+------------+------------+------------+------------+------------+------------+");
				sw.WriteLine(info1,"CVEID",arr1[i].ToString(),arr2[i].ToString(),arr3[i].ToString(),arr4[i].ToString(),arr5[i].ToString(),arr6[i].ToString(),arr7[i].ToString(),arr8[i].ToString(),arr9[i].ToString(),arr10[i].ToString());
				sw.WriteLine("+-----+------------+------------+------------+------------+------------+------------+------------+------------+------------+------------+");
				//             1001567 12345678901234567890123 12345678901 12345678.00 12345678.00 DD/MM/YYYY
				i++;
				while(i<=10)
				{
					sw.WriteLine(info," "+i.ToString(),arr1[i].ToString(),arr2[i].ToString(),arr3[i].ToString(),arr4[i].ToString(),arr5[i].ToString(),arr6[i].ToString(),arr7[i].ToString(),arr8[i].ToString(),arr9[i].ToString(),arr10[i].ToString());
					i++;
				}
				sw.WriteLine("+-----+------------+------------+------------+------------+------------+------------+------------+------------+------------+------------+");

				//deselect condensed
				sw.Write((char)27);
				sw.Write((char)18);//ad
				sw.Close();
			}
			if(count==0)
				return false;
			else
				return true;
		}

		/// <summary>
		/// This Method is used to prepare the report file .xls to print.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			if(Flag==0)
			{
				MessageBox.Show("Please Click The View Button First");
				return;
			}
			else
			{
				try
				{
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
					Directory.CreateDirectory(strExcelPath);
					string path = home_drive+@"\ePetro_ExcelFile\CustometVehicleEntryReport.xls";
					StreamWriter sw = new StreamWriter(path);
					int i=0;
					sw.WriteLine("Customer Name\t"+DropCustName.SelectedItem.Text);
					sw.WriteLine("CVEID"+"\t"+arr1[i].ToString()+"\t"+arr2[i].ToString()+"\t"+arr3[i].ToString()+"\t"+arr4[i].ToString()+"\t"+arr5[i].ToString()+"\t"+arr6[i].ToString()+"\t"+arr7[i].ToString()+"\t"+arr8[i].ToString()+"\t"+arr9[i].ToString()+"\t"+arr10[i].ToString());
					i++;
					while(i<=10)
					{
						sw.WriteLine(i.ToString()+"\t"+arr1[i].ToString()+"\t"+arr2[i].ToString()+"\t"+arr3[i].ToString()+"\t"+arr4[i].ToString()+"\t"+arr5[i].ToString()+"\t"+arr6[i].ToString()+"\t"+arr7[i].ToString()+"\t"+arr8[i].ToString()+"\t"+arr9[i].ToString()+"\t"+arr10[i].ToString());
						i++;
					}
					sw.Close();
					MessageBox.Show("Successfully Convert File into Excel Format");
				}
				catch(Exception ex)
				{
					MessageBox.Show("First Close The Open Excel File");
					CreateLogFiles.ErrorLog("Form:CustomerVehicleEntryReport.aspx,Method:btnExcel_Click   PriceList Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
				}
			}
		}
	}
}