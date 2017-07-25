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
	/// Summary description for TaxReport.
	/// </summary>
	public class TaxReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid GridTaxReport;
		protected System.Web.UI.WebControls.Button BtnPrint;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.Button btnView;
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnExcel;
		string uid;
	
		/// <summary>
		/// This method is used for setting the Session variable for userId
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TaxReport.aspx,Class:PetrolPumpClass.cs ,Method:Pageload   EXCEPTION: "+ex.Message+".  userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
				string SubModule="26";
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
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void btnView_Click(object sender, System.EventArgs e)
		{
			try
			{
				strOrderBy = "Prod_Name ASC";
				Session["Column"] = "Prod_Name";
				Session["Order"] = "ASC";
				BindTheData();
				//            SqlDataReader SqlDtr = null;
				//			  dbobj.SelectQuery("select p.prod_name, cast(Reduction as varchar)+' '+Unit_rdc as Reduction,cast(entry_tax as varchar)+' '+unit_etax as Entry_Tax, cast(rpg_charge as varchar)+' '+Unit_rpgchg as rpg_charge,cast(rpg_surcharge as varchar)+' '+Unit_rpgschg as rpg_surcharge,cast(LT_charge as varchar)+' '+Unit_ltchg as LT_Charge,cast(tran_charge as varchar)+' '+Unit_tchg as trans_charge,cast(Other_Lvy as varchar)+' '+Unit_olvy as Other_Lvy,cast(LST as varchar)+' '+Unit_LST as LST, cast(LST_Surcharge as varchar)+' '+Unit_lstschg as LST_Surcharge,cast(LF_Recov as varchar)+' '+Unit_lfrecov as LF_Recov, cast(dofobc_Charge as varchar)+' '+Unit_dochg as dofobc_Charge  from tax_entry t, Products p where p.Prod_ID =  t.ProductID ",ref SqlDtr); 
				//			  GridTaxReport.DataSource=SqlDtr;
				//			  GridTaxReport.DataBind();
				//			  if(GridTaxReport.Items.Count == 0 )
				//			  {
				//				  GridTaxReport.Visible = false;
				//				  MessageBox.Show("Data not available");
				//				  return;
				//
				//			  }
				//			  else
				//			  {
				//				  GridTaxReport.Visible = true;                  
				//			  } 
				//			  SqlDtr.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TaxReport.aspx,Method:btnView_Click()   EXCEPTION: "+ex.Message+".  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="select p.prod_name, cast(Reduction as varchar)+' '+Unit_rdc as Reduction,cast(entry_tax as varchar)+' '+unit_etax as Entry_Tax, cast(rpg_charge as varchar)+' '+Unit_rpgchg as rpg_charge,cast(rpg_surcharge as varchar)+' '+Unit_rpgschg as rpg_surcharge,cast(LT_charge as varchar)+' '+Unit_ltchg as LT_Charge,cast(tran_charge as varchar)+' '+Unit_tchg as trans_charge,cast(Other_Lvy as varchar)+' '+Unit_olvy as Other_Lvy,cast(LST as varchar)+' '+Unit_LST as LST, cast(LST_Surcharge as varchar)+' '+Unit_lstschg as LST_Surcharge,cast(LF_Recov as varchar)+' '+Unit_lfrecov as LF_Recov, cast(dofobc_Charge as varchar)+' '+Unit_dochg as dofobc_Charge  from tax_entry t, Products p where p.Prod_ID =  t.ProductID";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "tax_entry");
			DataTable dtCustomers = ds.Tables["tax_entry"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				GridTaxReport.DataSource = dv;
				GridTaxReport.DataBind();
				GridTaxReport.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				GridTaxReport.Visible=false;
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
				CreateLogFiles.ErrorLog("Form:TaxReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to prepares the report and writes into a Text File to print. 
		/// info string is used to display print the values in specified formats.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				/*
												  ==========
												  Tax Report
												  ==========

+------------+---------+-------+-------+---------+---------+---------+--------+-------+---------+--------+--------+
|  Product   |Reduction| Entry |  RPG  |   RPG   |  Local  |Transport| Other  | Local |   LST   |License |DO/FO/BC|
|   Name     |         |  Tax  |Charges|Surcharge|Transport| Charge  | Levies | Sales |Surcharge| Free   |Charges |
|            |         |       |       |         | Charge  |         | Value  |  Tax  |         |Recovery|        |
+------------+---------+-------+-------+---------+---------+---------+--------+-------+---------+--------+--------+
 123456789012 123456789 1234567 1234567 123456789 123456789 123456789 12345678 1234567 123456789 12345678 12345678				 
				 */
				SqlDataReader SqlDtr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\TaxReport.txt";
				StreamWriter sw = new StreamWriter(path);


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
				string des="-------------------------------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("============",des.Length)); 
				sw.WriteLine(GenUtil.GetCenterAddr("Tax Report",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("============",des.Length));
				sw.WriteLine("");
				
				sw.WriteLine("+------------+---------+-------+---------+-----------+-----------+-----------+----------+---------+-----------+----------+----------+");
				sw.WriteLine("|  Product   |Reduction| Entry |   RPG   |    RPG    |   Local   | Transport |  Other   |         |    LST    | License  | DO/FO/BC |");
				sw.WriteLine("|   Name     |         |  Tax  | Charges | Surcharge | Transport |  Charge   |  Levies  |   Vat   | Surcharge |  Free    | Charges  |");
				sw.WriteLine("|            |         |       |         |           |  Charge   |           |  Value   |         |           | Recovery |          |");
				sw.WriteLine("+------------+---------+-------+---------+-----------+-----------+-----------+----------+---------+-----------+----------+----------+");
				//             123456789012 123456789 1234567 1234567 123456789 123456789 123456789 12345678 1234567 123456789 12345678 12345678				        
				string info = " {0,-12:S} {1,9:S} {2,7:S} {3,9:S} {4,11:S} {5,11:S} {6,11:S} {7,10:S} {8,9:S} {9,11:S} {10,10:S} {11,10:S}"; 
				dbobj.SelectQuery("select p.prod_name, cast(Reduction as varchar)+' '+Unit_rdc as Reduction,cast(entry_tax as varchar)+' '+unit_etax as Entry_Tax, cast(rpg_charge as varchar)+' '+Unit_rpgchg as rpg_charge,cast(rpg_surcharge as varchar)+' '+Unit_rpgschg as rpg_surcharge,cast(LT_charge as varchar)+' '+Unit_ltchg as LT_Charge,cast(tran_charge as varchar)+' '+Unit_tchg as trans_charge,cast(Other_Lvy as varchar)+' '+Unit_olvy as Other_Lvy,cast(LST as varchar)+' '+Unit_LST as LST, cast(LST_Surcharge as varchar)+' '+Unit_lstschg as LST_Surcharge,cast(LF_Recov as varchar)+' '+Unit_lfrecov as LF_Recov, cast(dofobc_Charge as varchar)+' '+Unit_dochg as dofobc_Charge  from tax_entry t, Products p where p.Prod_ID =  t.ProductID order by "+Cache["strOrderBy"]+"",ref SqlDtr); 
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,  GenUtil.TrimLength(SqlDtr.GetValue(0).ToString(),12),
							SqlDtr.GetValue(1).ToString(), 
							SqlDtr.GetValue(2).ToString(), 
							SqlDtr.GetValue(3).ToString(), 
							SqlDtr.GetValue(4).ToString(), 
							SqlDtr.GetValue(5).ToString(), 
							SqlDtr.GetValue(6).ToString(), 
							SqlDtr.GetValue(7).ToString(), 
							SqlDtr.GetValue(8).ToString(), 
							SqlDtr.GetValue(9).ToString(), 
							SqlDtr.GetValue(10).ToString(), 
							SqlDtr.GetValue(11).ToString());
					}
				}
				else
				{
					MessageBox.Show("Data not available"); 
					sw.Close();
					return;
				}
				SqlDtr.Close();
				sw.WriteLine("+------------+---------+-------+---------+-----------+-----------+-----------+----------+---------+-----------+----------+----------+");
				// deselect Condensed
				//sw.Write((char)18);
				//sw.Write((char)12);
				sw.Close(); 
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:TaxReport.aspx,Method:BtnPrint_Click()   EXCEPTION: "+ex.Message+".  userid  "+uid);
			}
		}
		
		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			//string sql="";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\TaxReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader SqlDtr=null;
			sw.WriteLine("Product Name\tReduction\tEntry Tax\tRPG Charges\tRPG Surcharges\tLocal Transport Charge\tTransport Charge\tOther Levies Value\tVat\tLST Surcharge\tLicense Free Recovery\tDO/FO/BC Charge");
			dbobj.SelectQuery("select p.prod_name, cast(Reduction as varchar)+' '+Unit_rdc as Reduction,cast(entry_tax as varchar)+' '+unit_etax as Entry_Tax, cast(rpg_charge as varchar)+' '+Unit_rpgchg as rpg_charge,cast(rpg_surcharge as varchar)+' '+Unit_rpgschg as rpg_surcharge,cast(LT_charge as varchar)+' '+Unit_ltchg as LT_Charge,cast(tran_charge as varchar)+' '+Unit_tchg as trans_charge,cast(Other_Lvy as varchar)+' '+Unit_olvy as Other_Lvy,cast(LST as varchar)+' '+Unit_LST as LST, cast(LST_Surcharge as varchar)+' '+Unit_lstschg as LST_Surcharge,cast(LF_Recov as varchar)+' '+Unit_lfrecov as LF_Recov, cast(dofobc_Charge as varchar)+' '+Unit_dochg as dofobc_Charge  from tax_entry t, Products p where p.Prod_ID =  t.ProductID order by "+Cache["strOrderBy"]+"",ref SqlDtr); 
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					sw.WriteLine(SqlDtr.GetValue(0).ToString()+"\t"+
						SqlDtr.GetValue(1).ToString()+"\t"+
						SqlDtr.GetValue(2).ToString()+"\t"+
						SqlDtr.GetValue(3).ToString()+"\t"+
						SqlDtr.GetValue(4).ToString()+"\t"+
						SqlDtr.GetValue(5).ToString()+"\t"+
						SqlDtr.GetValue(6).ToString()+"\t"+
						SqlDtr.GetValue(7).ToString()+"\t"+
						SqlDtr.GetValue(8).ToString()+"\t"+
						SqlDtr.GetValue(9).ToString()+"\t"+
						SqlDtr.GetValue(10).ToString()+"\t"+
						SqlDtr.GetValue(11).ToString());
				}
			}
			dbobj.Dispose();
			SqlDtr.Close();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to Sends the text file to print server to print.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\TaxReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:TaxReport.aspx Method:Print()    Tax Report  Printed   "+"  userid "+uid);
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:TaxReport.aspx Method:Print()    EXCEPTION: "+ane.Message+"  userid "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:TaxReport.aspx Method:Print()     EXCEPTION: "+se.Message+" userid "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:TaxReport.aspx Method:Print()   EXCEPTION: "+es.Message+"   userid "+uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:TaxReport.aspx Method:Print()   EXCEPTION : "+ex.Message+"  userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(GridTaxReport.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:TaxReport.aspx,Method: btnExcel_Click, Tax Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:TaxReport.aspx,Method:btnExcel_Click   Tax Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}