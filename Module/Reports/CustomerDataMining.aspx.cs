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
using System.Data.SqlClient;
using System.Net; 
using System.Net.Sockets ;
using System.IO ;
using System.Text;
using DBOperations;    

namespace EPetro.Module.Parties
{
	/// <summary>
	/// Summary description for CustomerDataMining.
	/// </summary>
	public class CustomerDataMining : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.DataGrid CustomerGrid;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		protected System.Web.UI.WebControls.Button btnPrint;
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnview;
		protected System.Web.UI.WebControls.Button btnExcel;
		string uid = "";
	
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and 
		/// also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				uid=(Session["User_Name"].ToString());
				
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="1";
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
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:pageload  EXCEPTION  "+ex.Message+"  "+ uid );
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
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
			this.btnview.Click += new System.EventHandler(this.btnview_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Checks the Order by value and fires the query to display the customer information by given order and display the data grid.
		/// </summary>
		private void DropOrderBy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="Select * from Customer";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "Customer");
			DataTable dtCustomers = ds.Tables["Customer"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				CustomerGrid.DataSource = dv;
				CustomerGrid.DataBind();
			}
			else
			{
				MessageBox.Show("Data not available");
				CustomerGrid.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// Its fires the query according to selected order and writes the result into file CustomerDataMining.txt.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			//			if(DropOrderBy.SelectedIndex == 0)
			//			{
			//				MessageBox.Show("Please Select Display Order");
			//				return;
			//			}
			/*
																				====================
																				Customer Data Mining
																				====================

			+-------------------------+---------------+------------------------------+---------------+---------------+---------------+--------------------------------------------+------------------------------+
			|                         |               |                              |               |               |               |               Contact Number               |                              |
			|    Customer Name        |    Type       |         Address              |    City       |    State      |   Country     |---------------+---------------+------------|          EMail               |
			|                         |               |                              |               |               |               |    Office     |  Residence    |  Mobile    |                              |
			+-------------------------+---------------+------------------------------+---------------+---------------+---------------+---------------+---------------+------------+------------------------------+
			 1234567890123456789012345 123456789012345 123456789012345678901234567890 123456789012345 123456789012345 123456789012345 123456789012345 123456789012345 123456789012 123456789012345678901234567890            
			
			*/			
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\CustomerDataMining.txt";
				StreamWriter sw = new StreamWriter(path);
				string info = "";
				SqlDataReader SqlDtr = null;

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
				//*********************
				string des="-----------------------------------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//***********************
				sw.WriteLine(GenUtil.GetCenterAddr("======================",des.Length)); 
				sw.WriteLine(GenUtil.GetCenterAddr("Customer Data Mining",des.Length)); 
				sw.WriteLine(GenUtil.GetCenterAddr("======================",des.Length)); 
				
				sw.WriteLine("+-----------------+---------+----------------+-----------+---------+-------+------------------------------+-----------------------------+"); 
				sw.WriteLine("|                 |         |                |           |         |       |        Contact Number        |                             |"); 
				sw.WriteLine("|  Customer Name  |  Type   |    Address     |   City    |  State  |Country|--------+---------+-----------|          EMail              |"); 
				sw.WriteLine("|                 |         |                |           |         |       | Office |Residence|  Mobile   |                             |"); 
				sw.WriteLine("+-----------------+---------+----------------+-----------+---------+-------+--------+---------+-----------+-----------------------------+"); 
				//             12345678901234567 123456789 1234567890123456 12345678901 123456789 1234567 12345678 123456789 12345678901 12345678901234567890123456789            
				info = " {0,-17:S} {1,-9:S} {2,-16:S} {3,-11:S} {4,-9:S} {5,-7:S} {6,8:S} {7,9:S} {8,11:S} {9,-29:S}";
				
				//			string order_by = "Cust_Name";
				//				if(DropOrderBy.SelectedItem.Text == "Customer Type")
				//					order_by = "Cust_Type";
				//
				//				if(DropOrderBy.SelectedItem.Text == "Customer City")
				//					order_by = "City";
				//
				//				Session["Order_By"] = order_by;
				
               
				dbobj.SelectQuery("Select * from Customer order by "+Cache["strOrderBy"],ref SqlDtr);
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,GenUtil.TrimLength(SqlDtr["Cust_Name"].ToString().Trim(),17),
							GenUtil.TrimLength(SqlDtr["Cust_Type"].ToString().Trim(),9),
							GenUtil.TrimLength(SqlDtr["Address"].ToString().Trim(),16),
							GenUtil.TrimLength(SqlDtr["City"].ToString().Trim(),11),
							GenUtil.TrimLength(SqlDtr["State"].ToString().Trim(),9),
							GenUtil.TrimLength(SqlDtr["Country"].ToString().Trim(),7),
							SqlDtr["Tel_Off"].ToString().Trim(),
							SqlDtr["Tel_Res"].ToString().Trim(),
							SqlDtr["Mobile"].ToString().Trim(),
							GenUtil.TrimLength(SqlDtr["EMail"].ToString().Trim(),29));  
					}
				}
				else
				{
					MessageBox.Show("Data not available");
					sw.Close();
					return;
				}
				sw.WriteLine("+-----------------+---------+----------------+-----------+---------+-------+------------------------------+-----------------------------+"); 
				sw.Close();
				//Response.Redirect("CustDataMining_PrintPreview.aspx",false); 
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:btnPrint_Click  EXCEPTION  "+ex.Message+"  User: "+ uid );
			}
		}

		/// <summary>
		/// Method to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			//string sql="";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\CustomerDataMining.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader SqlDtr=null;
			sw.WriteLine("Customer Name\tType\tAddress\tCity\tState\tCountry\tOffice\tResidence\tMobile\tE-Mail"); 
			dbobj.SelectQuery("Select * from Customer order by "+Cache["strOrderBy"],ref SqlDtr);
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					sw.WriteLine(SqlDtr["Cust_Name"].ToString().Trim()+"\t"+
						SqlDtr["Cust_Type"].ToString().Trim()+"\t"+
						SqlDtr["Address"].ToString().Trim()+"\t"+
						SqlDtr["City"].ToString().Trim()+"\t"+
						SqlDtr["State"].ToString().Trim()+"\t"+
						SqlDtr["Country"].ToString().Trim()+"\t"+
						SqlDtr["Tel_Off"].ToString().Trim()+"\t"+
						SqlDtr["Tel_Res"].ToString().Trim()+"\t"+
						SqlDtr["Mobile"].ToString().Trim()+"\t"+
						SqlDtr["EMail"].ToString().Trim());  
				}
			}
			dbobj.Dispose();
			sw.Close();
		}
		
		/// <summary>
		/// Its trim the customer address of customer if it is greater than 30 charcters to display in report.
		/// </summary>
		public string trimString(string address)
		{
			if(address.Length > 30)
			{
				address = address.Substring(0,30);
			}
			return address;
		}

		/// <summary>
		/// Its sends the CustomerDataMining.txt to Print Server.
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
					CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\CustomerDataMining.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					//CreateLogFiles.ErrorLog("Form:Vehiclereport.aspx,Method:print"+ "  Daily sales record  Printed   userid  "+uid);
					CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:print. Report Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());

					 
					CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:print  EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to store the column name in asending order and set also a column name and asending 
		/// type on session variable and call the Bindthedata() function to view the report.
		/// </summary>
		private void btnview_Click(object sender, System.EventArgs e)
		{
			//			if(DropOrderBy.SelectedIndex == 0)
			//			{
			//				MessageBox.Show("Please Select Display Order");
			//				return;
			//			}
			//			string order_by = "Cust_Name";
			//			if(DropOrderBy.SelectedItem.Text == "Customer Type")
			//				order_by = "Cust_Type";
			//
			//			if(DropOrderBy.SelectedItem.Text == "Customer City")
			//				order_by = "City";

			try
			{
				//				SqlDataReader SqlDtr = null;
				//		
				//				dbobj.SelectQuery("Select * from Customer order by "+order_by+" asc",ref SqlDtr);
				//				CustomerGrid.DataSource = SqlDtr;
				//				CustomerGrid.DataBind();
				//		
				//				if(CustomerGrid.Items.Count==0)
				//				{
				//					MessageBox.Show("Data not available");
				//					CustomerGrid.Visible=false;
				//				}
				//				else
				//				{
				//					CustomerGrid.Visible=true;
				//				}
				//				SqlDtr.Close ();
				strOrderBy = "Cust_Name ASC";
				Session["Column"] = "Cust_Name";
				Session["Order"] = "ASC";
				BindTheData();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerDataMining.aspx,Method:DropOrderBy_SelectedIndexChanged  EXCEPTION  "+ex.Message+"  User: "+ uid );

			}
		}

		/// <summary>
		/// Prepares the excel report file CustomerDataMining.xls for printing.
		/// call the ConvertToExcel() function to generate the excel report.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(CustomerGrid.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:CustomerDateMining.aspx,Method: btnExcel_Click, CustomerDateMining Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:CustomerDateMining.aspx,Method:btnExcel_Click   CustomerDateMining Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}