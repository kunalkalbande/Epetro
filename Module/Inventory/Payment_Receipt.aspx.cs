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
using DBOperations;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for Payment_Receipt.
	/// </summary>
	public class Payment_Receipt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropCustName;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.TextBox txtTotalBalance;
		protected System.Web.UI.WebControls.TextBox txtRecAmount;
		protected System.Web.UI.WebControls.TextBox txtFinalDues;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.DataGrid GridDuePayment;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox txtAmountinWords;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.WebControls.TextBox txtCr;
		protected System.Web.UI.WebControls.DropDownList DropMode;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		DBOperations.DBUtil dbobj1=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox TextBox4;
		double total=0;
		string uid;
		string[] billDetails;
		int f1 = 0;
		static bool PrintFlag=false;
		public static double RecAmt=0;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.TextBox txtBankName;
		protected System.Web.UI.WebControls.TextBox txtChequeno;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Panel PanBankInfo;
		protected System.Web.UI.HtmlControls.HtmlImage Img1;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Panel PanReceiptNo;
		protected System.Web.UI.WebControls.DropDownList DropReceiptNo;
		protected System.Web.UI.WebControls.TextBox txtNar;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempReceiptInfo;
		protected System.Web.UI.WebControls.DropDownList DropDiscount1;
		protected System.Web.UI.WebControls.TextBox txtDisc1;
		protected System.Web.UI.WebControls.DropDownList DropDiscount2;
		protected System.Web.UI.WebControls.TextBox txtDisc2;
		protected System.Web.UI.WebControls.TextBox txtReceivedDate;
		protected System.Web.UI.HtmlControls.HtmlImage Img2;
		protected System.Web.UI.WebControls.CompareValidator cv1;
		protected System.Web.UI.WebControls.DropDownList DropBankName;
		int f2 = 0;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{   
			try
			{
				//string pass;
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:Page_Load" + ex.Message+" EXCEPTION "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			//			if(tempReceiptInfo.Value=="Yes")
			//			{
			//				DeleteTheRec();
			//			}
			if(!IsPostBack)
			{
				try
				{
                    txtReceivedDate.Attributes.Add("readonly", "readonly");
                    txtDate.Attributes.Add("readonly", "readonly");
                    txtCr.Attributes.Add("readonly", "readonly");
                    txtFinalDues.Attributes.Add("readonly", "readonly");
                    txtTotalBalance.Attributes.Add("readonly", "readonly");
                    Textbox1.Attributes.Add("readonly", "readonly");
                    Textbox3.Attributes.Add("readonly", "readonly");
                    Textbox2.Attributes.Add("readonly", "readonly");
                    Cache["RecAmt"]="0";
					CustName="";
					PanReceiptNo.Visible=false;
					PanBankInfo.Visible=false;
					txtDate.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					txtReceivedDate.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					checkPrevileges();
					checkAccount();
					GetBank();
					InventoryClass  obj=new InventoryClass ();
					SqlDataReader SqlDtr;
					string sql;
					object op = null;
					// The called procedure "getCust_Ledger" merged all customer and ledger names into one temporary table named "Cust_Ledger".
					dbobj.ExecProc(OprType.Insert,"getCust_Ledger",ref op,null);  

					#region Fetch All Customer Name & Account Name and fill in the ComboBox
					sql="select Party_Name from Cust_Ledger order by Party_Name";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						if(!SqlDtr.GetValue(0).ToString().Equals(""))
						{
							DropCustName.Items.Add (SqlDtr.GetValue(0).ToString ());	
						}
					}
					SqlDtr.Close ();		
					#endregion
					#region Fetch All Discount From Ledger Master and fill in the ComboBox
					sql="select Ledger_Name from ledger_master lm,ledger_master_sub_grp lms where lms.sub_grp_id=lm.sub_grp_id and lms.sub_grp_name='Discount'";
					SqlDtr=obj.GetRecordSet(sql);
					DropDiscount1.Items.Clear();
					DropDiscount1.Items.Add("Select");
					DropDiscount2.Items.Clear();
					DropDiscount2.Items.Add("Select");
					while(SqlDtr.Read())
					{
						if(!SqlDtr.GetValue(0).ToString().Equals(""))
						{
							DropDiscount1.Items.Add (SqlDtr.GetValue(0).ToString ());
							DropDiscount2.Items.Add (SqlDtr.GetValue(0).ToString ());
						}
					}
					SqlDtr.Close ();
					if(DropDiscount1.Items.Count>1)
					{
						DropDiscount1.SelectedIndex=1;
						txtDisc1.Enabled=true;
					}
					else
						txtDisc1.Enabled=false;
					if(DropDiscount2.Items.Count>2)
					{
						DropDiscount2.SelectedIndex=2;
						txtDisc2.Enabled=true;
					}
					else
						txtDisc2.Enabled=false;
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:Payment_Receipt. EXCEPTION  "+ex.Message +" userid "+uid);
				}
			}
			if(DropReceiptNo.Visible==true)
			{
				if(DropCustName.SelectedItem.Text==CustName)
					RecAmt=0;
				else
				{
					if(Cache["RecAmt"].ToString()!="")
						RecAmt=double.Parse(Cache["RecAmt"].ToString());
					else
						RecAmt=0;
				}
				//DropCustName.Attributes.Add("Onchange","GetFinalDues();");
			}
		}

		/// <summary>
		/// This method checks the privilegs of the user.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="1";
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
			if(Add_Flag=="0" && View_flag=="0" && Edit_Flag=="0")
			{
				//string msg="UnAthourized Visit to Payment Receipt Page";
				//dbobj.LogActivity(msg,Session["User_Name"].ToString());  
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}

			if(Add_Flag == "0")
				btnSave.Enabled = false;  
			#endregion
		}

		/// <summary>
		/// This method checks the cash and bank accounts are present or not , if not then display the message on screen.
		/// </summary>
		public void checkAccount()
		{
			try
			{
				SqlDataReader SqlDtr = null;
				dbobj.SelectQuery("select Ledger_ID from Ledger_Master lm, Ledger_Master_sub_grp lmsg where lm.sub_grp_id = lmsg.sub_grp_id and  lmsg.sub_grp_name = 'Cash in hand'",ref SqlDtr); 
				if(SqlDtr.HasRows)
				{
					f1 = 1;
				}
				SqlDtr.Close(); 

				dbobj.SelectQuery("select Ledger_ID from Ledger_Master lm, Ledger_Master_sub_grp lmsg where lm.sub_grp_id = lmsg.sub_grp_id and  lmsg.sub_grp_name = 'Bank'",ref SqlDtr); 
				if(SqlDtr.HasRows)
				{
					f2 = 1;
				}
				SqlDtr.Close();

				if(f1 == 0 && f2==0)
					lblMessage.Text = "Cash and Bank Accounts are not created";
				else
				{
					if(f1 == 0)
						lblMessage.Text = "Cash Account not created";
					if(f2 == 0)
						lblMessage.Text = "Bank Account not created";
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:FuelPerchase.aspx,Method:checkAccount(). EXCEPTION  "+ex.Message +" userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to returns MM/DD/YYYY date format.
		/// </summary>
		public DateTime ToMMddYY(string str)
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
			this.DropReceiptNo.SelectedIndexChanged += new System.EventHandler(this.DropReceiptNo_SelectedIndexChanged);
			this.DropCustName.SelectedIndexChanged += new System.EventHandler(this.DropCustName_SelectedIndexChanged);
			this.GridDuePayment.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.GridDuePayment_ItemDataBound);
			this.DropMode.SelectedIndexChanged += new System.EventHandler(this.DropMode_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to view the customer biling information according to select the Customer.
		/// </summary>
		private void DropCustName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				getRecInfo();
				btnPrint.CausesValidation=true;
				PrintFlag=false;
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:DropCustName_SelectedIndexChanged  Payment Recipt Viewed   userid "+uid);			
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:DropCustName_SelectedIndexChanged " + ex.Message+" EXCEPTION "+uid);
			}
		}

		/// <summary>
		/// This method is used to fatch the customer balance info 
		/// </summary>
		public void getRecInfo()
		{
			if(PanReceiptNo.Visible==false)
			{
				txtFinalDues.Text="";
				txtRecAmount.Text="";
				Textbox2.Text =""; 
				Textbox1.Text = "";
			}

			if(DropCustName.SelectedIndex ==0)
				return;
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
				
			CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:DropCustName_SelectedIndexChanged " +uid);

			#region Fetch Place of Customer Regarding Customer Name
			sql="select City from Customer where Cust_Name='"+ DropCustName.SelectedItem.Value +"'";  
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				if(SqlDtr.GetValue(0).ToString().Equals(""))
				{
					txtCity.Text="";
				}
				else
				{
					txtCity.Text =SqlDtr.GetValue(0).ToString();
				}
			}
			SqlDtr.Close ();		
			if(CustName==DropCustName.SelectedItem.Text)
			{
				if(Cache["RecAmt"].ToString()!="")
					RecAmt=double.Parse(Cache["RecAmt"].ToString());
				else
					RecAmt=0;
			}
			else
				RecAmt=0;
			
			#endregion
			
			string _CustName;
			string _City;
			string Cust_ID;
			_CustName=DropCustName.SelectedItem.Value;
			_City=txtCity.Text; 
				
			sql="select Cust_ID  from Customer where Cust_Name='"+ _CustName+"' and City = '"+_City+"'";  
			SqlDtr = obj.GetRecordSet(sql);
			if(SqlDtr.Read())
			{
				Cust_ID =SqlDtr.GetValue(0).ToString();
			}
			else
			{
				Cust_ID = "0";
			}
			SqlDtr.Close ();
			// Disable the Bill Details and Total Due amount fields for the Ledger.
			dbobj.SelectQuery("select Ledger_ID  from Cust_Ledger where Party_Name  = '"+_CustName+"' and Ledger_Id != ''",ref SqlDtr); 
			if(SqlDtr.HasRows)
			{
				Textbox3.Text="";
				txtCr.Text = "";
				GridDuePayment.Visible = false;
				txtTotalBalance.Enabled = false;
				txtTotalBalance.Text =""; 
				Textbox2.Enabled = false;
				Textbox3.Enabled = false; 
				txtCr.Enabled = false;
				txtFinalDues.Enabled = false;
			}
			else
			{
				GridDuePayment.Visible = true;
				txtTotalBalance.Enabled = true;
				Textbox2.Enabled = true;
				Textbox3.Enabled = true; 
				txtCr.Enabled = true;
				txtFinalDues.Enabled = true;
				//object op =null;
				//dbobj.ExecProc(OprType.Insert,"Test",ref op,"@Cust_ID",Cust_ID);

				UpdateLedgDetails(Cust_ID);
				#region Bind DataGrid
				SqlDtr=obj.GetRecordSet("select Bill_No as invoice_no,Bill_date as invoice_date,Amount as balance from LedgDetails where cust_id = '"+Cust_ID+"' and Amount > 0 order by bill_date");
				GridDuePayment.DataSource=SqlDtr;
				GridDuePayment.DataBind();
				SqlDtr.Close();  
				#endregion 

				txtTotalBalance.Text =total.ToString();
			}
			checkPrevileges(); 
		}

		/// <summary>
		/// This method is call at the binding of datagrid.
		/// </summary>
		private void GridDuePayment_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if(e.Item.Cells[2].Text!="Amount" && e.Item.Cells[2].Text!="&nbsp;")
					total=total+System.Convert.ToDouble(e.Item.Cells[2].Text.ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:GridDuePayment_ItemDataBound " + ex.Message+"  EXCEPTION "+uid);
			}
		}

		/// <summary>
		/// This method is used to sends the text file to print server to print.
		/// </summary>
		public void print()
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\Payment_ReceiptReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:Print   Payment Receipt Print   userid  "+uid );
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:Print   Payment Receipt Print  Exception  "+ane.Message+"  userid  "+uid );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:Print   Payment Receipt Print  Exception  "+se.Message+"  userid  "+uid );	
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:Print   Payment Receipt Print  Exception  "+es.Message+"  userid  "+uid );	
				}
			} 
			catch(Exception ex)
			{
				//CreateLogFiles Err = new CreateLogFiles();
				//Err.ErrorLog(Server.MapPath("Logs/ErrorLog"),"Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:btnSaved_Clicked " + ex.Message);
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:print  Payment Receipt Print " + ex.Message+" EXCEPTION  "+uid);
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
				if(rdr["Name"].ToString().Trim().Length>len1)
					len1=rdr["Name"].ToString().Trim().Length;					
				if(rdr["City"].ToString().Trim().Length>len2)
					len2=rdr["City"].ToString().Trim().Length;					
				if(rdr["Rupees"].ToString().Trim().Length>len3)
					len3=rdr["Rupees"].ToString().Trim().Length;					
				if(rdr["TotalAmt"].ToString().Trim().Length>len4)
					len4=rdr["TotalAmt"].ToString().Trim().Length;	
				if(rdr["RecpMode"].ToString().Trim().Length>len5)
					len5=rdr["RecpMode"].ToString().Trim().Length;	
				if(rdr["RecpAmount"].ToString().Trim().Length>len6)
					len6=rdr["RecpAmount"].ToString().Trim().Length;	
				if(rdr["FinalDueMode"].ToString().Trim().Length>len7)
					len7=rdr["FinalDueMode"].ToString().Trim().Length;	
				if(rdr["FinalDuePay"].ToString().Trim().Length>len8)
					len8=rdr["FinalDuePay"].ToString().Trim().Length;	
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
		/// This method is used to return the space according to given length.
		/// </summary>
		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
		}
		// End Report
		// This function prepares the report .txt file. takes argument int
		// 1. Customer Report
		// 2. Report for the Ledger.
		/*
		// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		public void MakingReport(int f)
		{
			/*
											Payment Receipt


Recieved with thanks from ----------------------------------- -----------------
The sum of Rupees ------------------------------------------------ in Full/Part
payment against Bill details given on account of your supply.

+--------------------------------+---------------------------+----------------+
|           Due Payment          |     Recieved Payment      |Final Dues After|
+-------+-----------+------------+-------------+-------------+    Payment     |
|Bill No| Bill Date |   Amount   |    Mode     |   Amount    |                |
+-------+-----------+------------+-------------+-------------+----------------+
|999999 |04-04-2006 |1234567890  |Demand Draft   1234567890  |---- 1234567890 |
+-------+-----------+------------+---------------------------+----------------+
|             Total :1234567890  |               1234567890  |---- 1234567890 |
+--------------------------------+---------------------------+----------------+
*//*
			InventoryClass  obj = new InventoryClass();
			SqlDataReader SqlDtr;
			string info1="";
			string Cust_ID = "";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\Payment_ReceiptReport.txt";
			int flag1=0,flag2=0,flag3=0;
			StreamWriter sw = new StreamWriter(path);
			
			string strCustName = DropCustName.SelectedItem.Value;
			string strCustCity  = txtCity.Text;
			if(f == 1)
			{
				string sql="select Cust_ID  from Customer where Cust_Name='"+ strCustName+"' and City = '"+strCustCity+"'";  
				SqlDtr = obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
					
					Cust_ID =SqlDtr.GetValue(0).ToString();
					
				}
				else
				{
					Cust_ID = "0";
				}
				SqlDtr.Close ();

				int i=0;
				int count = 0;
				SqlDtr=obj.GetRecordSet("select Bill_No as invoice_no,Bill_date as invoice_date,Amount as balance from LedgDetails where cust_id = '"+Cust_ID+"' and Amount > 0");
				while(SqlDtr.Read())
				{
					count++;
					count++;
					count++;
				}
				SqlDtr.Close();
				if(count == 0)
				{
					billDetails = new string[3];
					billDetails[0] = "";
					billDetails[1] = "";
					billDetails[2] = "";
				}
				else
					billDetails = new string[count];
				SqlDtr=obj.GetRecordSet("select Bill_No as invoice_no,Bill_date as invoice_date,Amount as balance from LedgDetails where cust_id = '"+Cust_ID+"' and Amount > 0");
		
				while(SqlDtr.Read())
				{
					billDetails[i]= SqlDtr.GetValue(0).ToString();
					i++;  
					billDetails[i]= SqlDtr.GetValue(1).ToString();
					i++;
					billDetails[i]= SqlDtr.GetValue(2).ToString();
					i++;
				}
				SqlDtr.Close(); 
			}
			else
			{
				string[] name = strCustName.Split(new char[] {':'},strCustName.Length);
				strCustName = name[0].ToString();
				strCustCity = "";
				billDetails = new string[3];
				billDetails[0] = "";
				billDetails[1] = "";
				billDetails[2] = "";
			}

			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu
			// Condensed
			sw.Write((char)27);
			sw.Write((char)15);
			sw.WriteLine("");

			//**********
			string des="------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("=========",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Receipt",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=========",des.Length));
			sw.WriteLine("");
			sw.WriteLine("                                                            Date: "+DateTime.Now.Day.ToString()+"/"+DateTime.Now.Month.ToString()+"/"+DateTime.Now.Year.ToString()   );
			sw.WriteLine("");
			sw.WriteLine("Recieved with thanks from "+strCustName+" "+strCustCity);
			sw.WriteLine("The sum of Rupees "+txtAmountinWords.Text+" in Full/Part");
			sw.WriteLine("payment against Bill details given on account of your supply.");
			sw.WriteLine("");
			sw.WriteLine("+--------------------------------+---------------------------+----------------+");
			sw.WriteLine("|           Due Payment          |     Recieved Payment      |Final Dues After|");
			sw.WriteLine("+-------+-----------+------------+-------------+-------------+    Payment     |");
			sw.WriteLine("|Bill No| Bill Date |   Amount   |    Mode     |   Amount    |                |");
			sw.WriteLine("+-------+-----------+------------+-------------+-------------+----------------+");
			//|O/B    |4/26/2006  |   111100.00|Cash                1500.00|Dr.      8650.00|

			info1 = "|{0,-6:F} |{1,-10:S} | {2,10:F} |{3,-12:S}    {4,10:F} |{5,-3:S}  {6,10:F} |";
			string info4 = "|{0,-6:F} |{1,-10:S} | {2,10:F} |{3,-12:S}    {4,-27:F} |";
			string strDate =billDetails[1];
			int pos = strDate.IndexOf(" ");
				
			if(pos != -1)
			{
				strDate = strDate.Substring(0,pos);
			}
			else
			{
				strDate = "";					
			}
			if(f==1)
				sw.WriteLine(info1,billDetails[0],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[2]),DropMode.SelectedItem.Value,GenUtil.strNumericFormat(txtRecAmount.Text.ToString()),txtCr.Text ,GenUtil.strNumericFormat(txtFinalDues.Text.ToString()) );
			else
				sw.WriteLine(info1,billDetails[0],strDate,billDetails[2],DropMode.SelectedItem.Value,GenUtil.strNumericFormat(txtRecAmount.Text.ToString()),"" ,"" );

			string	info2 = "|{0,-6:F} |{1,-10:S} | {2,10:F} |                           |                |";
			if(billDetails.Length >3 )
			{
				for (int j=3;j<billDetails.Length-2 ;j=j+3)  
				{
					strDate = billDetails[j+1];
					pos = strDate.IndexOf(" ");
				
					if(pos != -1)
					{
						strDate = strDate.Substring(0,pos);
					}
					else
					{
						strDate = "";					
					}
					string test = billDetails[j+2];
					
					if(!DropMode.SelectedItem.Text.Equals("Cash"))
					{
						if(flag1==0)
						{
							sw.WriteLine(info4,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]),"Name of Bank",txtBankName.Text);
							flag1=1;
						}
						else if(flag2==0)
						{
							sw.WriteLine(info1,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]),"Cheque No",txtChequeno.Text,"","");
							flag2=1;
						}
						else if(flag3==0)
						{
							sw.WriteLine(info1,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]),"Cheque Date",txtDate.Text,"","");
							flag3=1;
						}
						else
							sw.WriteLine(info2,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]) );
					}
					else
						sw.WriteLine(info2,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]) );

				}
			}
			if(!DropMode.SelectedItem.Text.Equals("Cash"))
			{
				if(flag1==0)
				{
					sw.WriteLine(info4,"","","","Name of Bank",txtBankName.Text);
					flag1=1;
				}
				if(flag2==0)
				{
					sw.WriteLine(info1,"","","","Cheque No",txtChequeno.Text,"","");
					flag2=1;
				}
				if(flag3==0)
				{
					sw.WriteLine(info1,"","","","Cheque Date",txtDate.Text,"","");
					flag3=1;
				}
			}
			sw.WriteLine("+-------+-----------+------------+---------------------------+----------------+");
			string info3 = "|             Total : {0,10:F} |                {1,10:F} |{2,-3:S}  {3,10:F} |";
			if(f==1)
				sw.WriteLine(info3,GenUtil.strNumericFormat(txtTotalBalance.Text.ToString()),GenUtil.strNumericFormat(Textbox1.Text.ToString() ),Textbox3.Text,GenUtil.strNumericFormat(Textbox2.Text.ToString ()) );
			else
				sw.WriteLine(info3,"",GenUtil.strNumericFormat(Textbox1.Text.ToString() ),"","" );
			sw.WriteLine("+--------------------------------+---------------------------+----------------+");
			string info5 = "|Narration : {0,-65:S}|";
			sw.WriteLine(info5,GenUtil.TrimLength(txtNar.Text,65));
			sw.WriteLine("+----------+------------------------------------------------------------------+");
			sw.Close();
		}
		*/


		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void MakingReport(int f)
		{
			/*
											Payment Receipt


Recieved with thanks from ----------------------------------- -----------------
The sum of Rupees ------------------------------------------------ in Full/Part
payment against Bill details given on account of your supply.

+--------------------------------+---------------------------+----------------+
|           Due Payment          |     Recieved Payment      |Final Dues After|
+-------+-----------+------------+-------------+-------------+    Payment     |
|Bill No| Bill Date |   Amount   |    Mode     |   Amount    |                |
+-------+-----------+------------+-------------+-------------+----------------+
|999999 |04-04-2006 |1234567890  |Demand Draft   1234567890  |---- 1234567890 |
+-------+-----------+------------+---------------------------+----------------+
|             Total :1234567890  |               1234567890  |---- 1234567890 |
+--------------------------------+---------------------------+----------------+
*/
			InventoryClass  obj = new InventoryClass();
			//SqlDataReader SqlDtr;
			string info1="";
			//string Cust_ID = "";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\Payment_ReceiptReport.txt";
			//int flag1=0,flag2=0,flag3=0;
			StreamWriter sw = new StreamWriter(path);
			
			string strCustName = DropCustName.SelectedItem.Value;
			string strCustCity  = txtCity.Text;
			/*
			if(f == 1)
			{
				string sql="select Cust_ID  from Customer where Cust_Name='"+ strCustName+"' and City = '"+strCustCity+"'";  
				SqlDtr = obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
					
					Cust_ID =SqlDtr.GetValue(0).ToString();
					
				}
				else
				{
					Cust_ID = "0";
				}
				SqlDtr.Close ();

				int i=0;
				int count = 0;
				SqlDtr=obj.GetRecordSet("select Bill_No as invoice_no,Bill_date as invoice_date,Amount as balance from LedgDetails where cust_id = '"+Cust_ID+"' and Amount > 0");
				while(SqlDtr.Read())
				{
					count++;
					count++;
					count++;
				}
				SqlDtr.Close();
				if(count == 0)
				{
					billDetails = new string[3];
					billDetails[0] = "";
					billDetails[1] = "";
					billDetails[2] = "";
				}
				else
					billDetails = new string[count];
				SqlDtr=obj.GetRecordSet("select Bill_No as invoice_no,Bill_date as invoice_date,Amount as balance from LedgDetails where cust_id = '"+Cust_ID+"' and Amount > 0");
		
				while(SqlDtr.Read())
				{
					billDetails[i]= SqlDtr.GetValue(0).ToString();
					i++;  
					billDetails[i]= SqlDtr.GetValue(1).ToString();
					i++;
					billDetails[i]= SqlDtr.GetValue(2).ToString();
					i++;
				}
				SqlDtr.Close(); 
			}
			else
			{
				string[] name = strCustName.Split(new char[] {':'},strCustName.Length);
				strCustName = name[0].ToString();
				strCustCity = "";
				billDetails = new string[3];
				billDetails[0] = "";
				billDetails[1] = "";
				billDetails[2] = "";
			}
			*/
			sw.Write((char)27);//added by vishnu
			sw.Write((char)67);//added by vishnu
			sw.Write((char)0);//added by vishnu
			sw.Write((char)12);//added by vishnu
			
			sw.Write((char)27);//added by vishnu
			sw.Write((char)78);//added by vishnu
			sw.Write((char)5);//added by vishnu
			// Condensed
			sw.Write((char)27);
			sw.Write((char)15);
			sw.WriteLine("");

			//**********
			string des="------------------------------------------------------------------------------";
			string Address=GenUtil.GetAddress();
			string[] addr=Address.Split(new char[] {':'},Address.Length);
			sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
			sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
			sw.WriteLine(des);
			//**********
			sw.WriteLine(GenUtil.GetCenterAddr("=========",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("Receipt",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("=========",des.Length));
			sw.WriteLine("");
			sw.WriteLine("                                                            Date: "+DateTime.Now.Day.ToString()+"/"+DateTime.Now.Month.ToString()+"/"+DateTime.Now.Year.ToString()   );
			sw.WriteLine("");
			sw.WriteLine("Recieved with thanks from "+strCustName+" "+strCustCity);
			//sw.WriteLine("The sum of Rupees "+txtAmountinWords.Text+" in Full/Part");
			//sw.WriteLine("The sum of Rupees "+txtAmountinWords.Text+"");
			sw.WriteLine("The sum of Rupees '"+GenUtil.ConvertNoToWord(txtRecAmount.Text)+"'");
			sw.WriteLine("payment against Bill details given on account of your supply.");
			sw.WriteLine("");
			/*
			sw.WriteLine("+--------------------------------+---------------------------+----------------+");
			sw.WriteLine("|           Due Payment          |     Recieved Payment      |Final Dues After|");
			sw.WriteLine("+-------+-----------+------------+-------------+-------------+    Payment     |");
			sw.WriteLine("|Bill No| Bill Date |   Amount   |    Mode     |   Amount    |                |");
			sw.WriteLine("+-------+-----------+------------+-------------+-------------+----------------+");
			//|O/B    |4/26/2006  |   111100.00|Cash                1500.00|Dr.      8650.00|
			*/
			sw.WriteLine("+---------------------------------------------------+");
			sw.WriteLine("|                 Recieved Payment                  |");
			sw.WriteLine("+-------------------------+-------------------------|");
			sw.WriteLine("|          Mode           |         Amount          |");
			sw.WriteLine("+-------------------------+-------------------------+");
			
			//info1 = "|{0,-6:F} |{1,-10:S} | {2,10:F} |{3,-12:S}    {4,10:F} |{5,-3:S}  {6,10:F} |";
			//string info4 = "|{0,-6:F} |{1,-10:S} | {2,10:F} |{3,-12:S}    {4,-27:F} |";
			info1 = "|{0,-25:F}|{1,24:S} |";
			/*
			string strDate =billDetails[1];
			int pos = strDate.IndexOf(" ");
				
			if(pos != -1)
			{
				strDate = strDate.Substring(0,pos);
			}
			else
			{
				strDate = "";					
			}
			*/
			if(f==1)
				//sw.WriteLine(info1,billDetails[0],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[2]),DropMode.SelectedItem.Value,GenUtil.strNumericFormat(txtRecAmount.Text.ToString()),txtCr.Text ,GenUtil.strNumericFormat(txtFinalDues.Text.ToString()) );
				sw.WriteLine(info1,DropMode.SelectedItem.Value,GenUtil.strNumericFormat(txtRecAmount.Text.ToString()));
			else
				sw.WriteLine(info1,DropMode.SelectedItem.Value,GenUtil.strNumericFormat(txtRecAmount.Text.ToString()));

			//string info2 = "|{0,-6:F} |{1,-10:S} | {2,10:F} |                           |                |";
			//if(billDetails.Length >3 )
			//{
			//for (int j=3;j<billDetails.Length-2 ;j=j+3)  
			//{
			/*
					strDate = billDetails[j+1];
					pos = strDate.IndexOf(" ");
				
					if(pos != -1)
					{
						strDate = strDate.Substring(0,pos);
					}
					else
					{
						strDate = "";					
					}
					string test = billDetails[j+2];
					*/
			//if(!DropMode.SelectedItem.Text.Equals("Cash"))
			//{
			//if(flag1==0)
			//{
			//sw.WriteLine(info4,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]),"Name of Bank",txtBankName.Text);
			//sw.WriteLine(info1,"Name of Bank",txtBankName.Text);
			//flag1=1;
			//}
			//else if(flag2==0)
			//{
			//sw.WriteLine(info1,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]),"Cheque No",txtChequeno.Text,"","");
			//sw.WriteLine(info1,"Cheque No",txtChequeno.Text);
			//	flag2=1;
			//}
			//else if(flag3==0)
			//{
			//sw.WriteLine(info1,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]),"Cheque Date",txtDate.Text,"","");
			//	sw.WriteLine(info1,"Cheque Date",txtDate.Text);
			//	flag3=1;
			//}
			//else
			//sw.WriteLine(info2,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]) );

			//}
			//else
			//	sw.WriteLine(info2,billDetails[j],GenUtil.str2DDMMYYYY(strDate),GenUtil.strNumericFormat(billDetails[j+2]) );

			//}
			//}
			if(!DropMode.SelectedItem.Text.Equals("Cash"))
			{
				//if(flag1==0)
				//{
				//sw.WriteLine(info4,"","","","Name of Bank",txtBankName.Text);
				sw.WriteLine(info1,"Name of Bank",txtBankName.Text);
				//	flag1=1;
				//}
				//if(flag2==0)
				//{
				//sw.WriteLine(info1,"","","","Cheque No",txtChequeno.Text,"","");
				sw.WriteLine(info1,"Cheque No",txtChequeno.Text);
				//	flag2=1;
				//}
				//if(flag3==0)
				//{
				sw.WriteLine(info1,"Cheque Date",txtDate.Text);
				//	flag3=1;
				//}
			}
			//sw.WriteLine("+-------+-----------+------------+---------------------------+----------------+");
			//string info3 = "|             Total : {0,10:F} |                {1,10:F} |{2,-3:S}  {3,10:F} |";
			//if(f==1)
			//	sw.WriteLine(info3,GenUtil.strNumericFormat(txtTotalBalance.Text.ToString()),GenUtil.strNumericFormat(Textbox1.Text.ToString() ),Textbox3.Text,GenUtil.strNumericFormat(Textbox2.Text.ToString ()) );
			//else
			//	sw.WriteLine(info3,"",GenUtil.strNumericFormat(Textbox1.Text.ToString() ),"","" );
			sw.WriteLine("+---------------------------------------------------+");
			string info5 = "|Narration : {0,-39:S}|";
			sw.WriteLine(info5,GenUtil.TrimLength(txtNar.Text,38));
			sw.WriteLine("+---------------------------------------------------+");
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine("                                        Signature");
			sw.Close();
		}
		
		/// <summary>
		/// This method is not used.
		/// </summary>
		public void Save2()
		{
			SqlConnection conMyData;
			string  strInsert;
			SqlCommand cmdInsert;
			conMyData = new SqlConnection( @"Server=localhost;user id=sa;password=;Database=EPetro" );
			strInsert = "Insert PaymentReport(Name,City,Rupees,TotalAmt,RecpMode,RecpAmount,FinalDueMode,FinalDuePay)Values(@Name,@City,@Rupees,@TotalAmt,@RecpMode,@RecpAmount,@FinalDueMode,@FinalDuePay)";
			cmdInsert = new SqlCommand( strInsert, conMyData );
			conMyData.Open();
			cmdInsert.Parameters.Add( "@Name", DropCustName.SelectedItem.Value.ToString());
			cmdInsert.Parameters.Add( "@City", txtCity.Text.ToString() );
			cmdInsert.Parameters.Add( "@Rupees", txtAmountinWords.Text.ToString());
			cmdInsert.Parameters.Add( "@TotalAmt", txtTotalBalance.Text.ToString());
			cmdInsert.Parameters.Add( "@RecpMode", DropMode.SelectedItem.Value.ToString());
			cmdInsert.Parameters.Add( "@RecpAmount",txtRecAmount.Text.ToString());
			cmdInsert.Parameters.Add( "@FinalDueMode", txtCr.Text.ToString());
			cmdInsert.Parameters.Add( "@FinalDuePay", txtFinalDues.Text.ToString());
			cmdInsert.ExecuteNonQuery();
			conMyData.Close();
		}

		/// <summary>
		/// This method is used to insert all values in the database with the help of stored procedures.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//			try
			//			{
			//				InventoryClass  obj=new InventoryClass();
			//				SqlDataReader SqlDtr=null;
			//				double rec_amount;
			//				double Amount=0;
			//				double balance;
			//				string Receipt="Save";
			//				string Acc_Type = "";
			//				string _CustName;
			//				string _City;
			//				string Cust_ID;
			//				int f = 0;
			//				_CustName=DropCustName.SelectedItem.Value;
			//				_City=txtCity.Text; 
			//				checkAccount(); 
			//				if(DropMode.SelectedItem.Text.Equals("Cash"))
			//				{
			//					Acc_Type = "Cash in hand";
			//					if(f1 == 0)
			//					{
			//						MessageBox.Show("Cash Account not created");
			//						return;
			//					}
			//				}
			//				else
			//				{
			//					Acc_Type = "Bank";
			//					if(f2 == 0)
			//					{
			//						MessageBox.Show("Bank Account not created");
			//						return;
			//					}
			//				}
			//
			//				if(f1 == 0 && f2==0)
			//				{
			//					MessageBox.Show("Cash and Bank Accounts are not created");
			//					return;
			//				}
			//				//*********************************************
			//				if(PanReceiptNo.Visible==true)
			//				{
			//					Receipt="Update";
			//					/**Mahesh
			//					double TempAmt=double.Parse(Cache["RecAmt"].ToString());
			//					double ActAmt=double.Parse(txtRecAmount.Text);
			//					//if(ActAmt > TempAmt)
			//						Amount=ActAmt-TempAmt;
			//					Mahesh**/
			//					Amount=double.Parse(txtRecAmount.Text);
			//					//*******Maheshend
			//					//else if(Actamt < TempAmt)
			//					//	Amount=TempAmt-ActAmt;
			//					//else if(ActAmt == TempAmt)
			//					//	Amount=0;
			//				}
			//				string	sql="select Cust_ID from Customer where Cust_Name='"+ _CustName+"' and City = '"+_City+"'";  
			//				SqlDtr = obj.GetRecordSet(sql);
			//				if(SqlDtr.Read())
			//					Cust_ID =SqlDtr.GetValue(0).ToString();
			//				else
			//					Cust_ID = "0";
			//				SqlDtr.Close ();
			//				rec_amount=System.Convert.ToDouble(txtRecAmount.Text);
			//				obj.BankName=txtBankName.Text.Trim().ToString();
			//				obj.ChequeNo=txtChequeno.Text.Trim().ToString();
			//				obj.Mode=DropMode.SelectedItem.Text;
			//				obj.ChequeDate=GenUtil.str2MMDDYYYY(txtDate.Text.Trim().ToString());
			//				obj.Receipt=Receipt;
			//				obj.Cust_ID=Cust_ID;
			//				obj.Narration=txtNar.Text;
			//				
			//				//obj.AccType=Acc_Type;
			//				//*********************************************
			//				// Check Amount payment from Ledger Account or from Customer.
			//				dbobj.SelectQuery("select Ledger_ID  from Cust_Ledger where Party_Name  = '"+_CustName+"' and Ledger_Id != ''",ref SqlDtr); 
			//				if(SqlDtr.HasRows)
			//				{
			//					string Ledger_ID = "";
			//					rec_amount = 0;
			//					if(SqlDtr.Read())
			//					{
			//						Ledger_ID = SqlDtr["Ledger_ID"].ToString();
			//					}
			//					rec_amount=System.Convert.ToDouble(txtRecAmount.Text);
			//					object op = null;
			//					f= 2;
			//					MakingReport(f);
			//					SqlDtr=obj.GetRecordSet("select Bill_No,Amount from LedgDetails where cust_id = '"+Cust_ID+"' and Amount > 0");
			//					//print();
			//					//call procedure to insert the record into payment_Receipt and voucher_transaction tables.
			//					if(PanReceiptNo.Visible==true)
			//					{
			//						int x =0;
			//						dbobj.Insert_or_Update("delete from Payment_Receipt where Receipt_No='"+DropReceiptNo.SelectedItem.Text+"'",ref x);
			//						dbobj.Insert_or_Update("delete from AccountsLedgerTable where Particulars='Receipt ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
			//						dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Ledger_ID,"@amount",Amount,"@Acc_Type",Acc_Type,"@BankName",txtBankName.Text,"@ChNo",txtChequeno.Text,"@Chdate",GenUtil.str2MMDDYYYY(txtDate.Text),"@Mode",DropMode.SelectedItem.Text,"@CustID",Cust_ID,"@Narration",txtNar.Text,"@Receipt_No",DropReceiptNo.SelectedItem.Text);
			//						//dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Ledger_ID,"@amount",Amount,"@Acc_Type",Acc_Type,"@BankName",txtBankName.Text,"@ChNo",txtChequeno.Text,"@Chdate",GenUtil.str2MMDDYYYY(txtDate.Text),"@Mode",DropMode.SelectedItem.Text,"@CustID",Cust_ID,"@Narration",txtNar.Text,"@RecDate",RecDate);
			//					}
			//					else
			//						dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Ledger_ID,"@amount",rec_amount,"@Acc_Type",Acc_Type,"@BankName",txtBankName.Text,"@ChNo",txtChequeno.Text,"@Chdate",GenUtil.str2MMDDYYYY(txtDate.Text),"@Mode",DropMode.SelectedItem.Text,"@CustID",Cust_ID,"@Narration",txtNar.Text,"@Receipt_No",0);
			//						//dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Ledger_ID,"@amount",rec_amount,"@Acc_Type",Acc_Type,"@BankName",txtBankName.Text,"@ChNo",txtChequeno.Text,"@Chdate",GenUtil.str2MMDDYYYY(txtDate.Text),"@Mode",DropMode.SelectedItem.Text,"@CustID",Cust_ID,"@Narration",txtNar.Text,"@RecDate",DateTime.Now.ToString());
			//					if(PanReceiptNo.Visible==true)
			//						MessageBox.Show("Payment Receipt Updated");
			//					else
			//						MessageBox.Show("Payment Receipt Saved");
			//					Clear();
			//				}
			//				else
			//				{
			//					f = 1 ;
			//					MakingReport(f);
			//					
			//					//rec_amount=System.Convert.ToDouble(txtRecAmount.Text);
			//					//obj.BankName=txtBankName.Text.Trim().ToString();
			//					//obj.ChequeNo=txtChequeno.Text.Trim().ToString();
			//					//obj.Mode=DropMode.SelectedItem.Text;
			//					//obj.ChequeDate=GenUtil.str2MMDDYYYY(txtDate.Text.Trim().ToString());
			//					//obj.Receipt=Receipt;
			//					//obj.Cust_ID=Cust_ID;
			//					//obj.Narration=txtNar.Text;
			//					SqlDtr=obj.GetRecordSet("select Bill_No,Amount from LedgDetails where cust_id = '"+Cust_ID+"' and Amount > 0");//GetInvoiceBalance(DropCustName.SelectedItem.Value,txtCity.Text);
			//					if(SqlDtr.HasRows)
			//					{
			//						while(SqlDtr.Read())
			//						{
			//							if (SqlDtr.GetValue(1).ToString().Equals(""))
			//							{
			//								balance=00.00;
			//							}
			//							else
			//								balance=System.Convert.ToDouble(SqlDtr.GetValue(1).ToString());
			//							if(PanReceiptNo.Visible==true)
			//							{
			//								if(balance>=Amount)
			//								{
			//									obj.Received_No =DropReceiptNo.SelectedItem.Text;
			//									obj.Invoice_No= SqlDtr.GetValue(0).ToString();
			//									obj.Received_Amount=txtRecAmount.Text.ToString(); 
			//									obj.Actual_Amount = balance.ToString();
			//									obj.InsertPaymentReceived();
			//									int q=0;
			//									dbobj.Insert_or_Update("Update LedgDetails set Amount = "+(balance - Amount)+" where Bill_No = '"+SqlDtr.GetValue(0).ToString()+"' and Cust_ID='"+Cust_ID+"'",ref q);
			//									break;
			//								}
			//								else
			//								{
			//									obj.Received_No=DropReceiptNo.SelectedItem.Text;;
			//									obj.Invoice_No=SqlDtr.GetValue(0).ToString();
			//									obj.Received_Amount=balance.ToString();
			//									obj.Actual_Amount = balance.ToString() ;
			//									obj.InsertPaymentReceived();
			//									rec_amount = Amount-balance; 
			//									int q=0;
			//									dbobj.Insert_or_Update("Update LedgDetails set Amount = "+0+" where Bill_No = '"+SqlDtr.GetValue(0).ToString()+"' and Cust_ID='"+Cust_ID+"'",ref q);
			//					
			//								}
			//							}
			//							else
			//							{
			//								if(balance>=rec_amount)
			//								{
			//									obj.Received_No ="";
			//									obj.Invoice_No= SqlDtr.GetValue(0).ToString();
			//									obj.Received_Amount=rec_amount.ToString(); 
			//									obj.Actual_Amount = balance.ToString();
			//									obj.InsertPaymentReceived();
			//									int q=0;
			//									dbobj.Insert_or_Update("Update LedgDetails set Amount = "+(balance - rec_amount)+" where Bill_No = '"+SqlDtr.GetValue(0).ToString()+"' and Cust_ID='"+Cust_ID+"'",ref q);
			//									break;
			//								}
			//								else
			//								{
			//									obj.Received_No="";
			//									obj.Invoice_No=SqlDtr.GetValue(0).ToString();
			//									obj.Received_Amount=balance.ToString();
			//									obj.Actual_Amount = balance.ToString() ;
			//									obj.InsertPaymentReceived();
			//									rec_amount = rec_amount-balance; 
			//									int q=0;
			//									dbobj.Insert_or_Update("Update LedgDetails set Amount = "+0+" where Bill_No = '"+SqlDtr.GetValue(0).ToString()+"' and Cust_ID='"+Cust_ID+"'",ref q);
			//					
			//								}
			//							}
			//						}
			//					}
			//					else
			//					{
			//						if(PanReceiptNo.Visible==true)
			//						{
			//							obj.Received_No=DropReceiptNo.SelectedItem.Text;
			//							obj.Invoice_No="";
			//							obj.Received_Amount=txtRecAmount.Text;
			//							obj.Actual_Amount = txtRecAmount.Text;
			//							obj.InsertPaymentReceived();
			//						}
			//						else
			//						{
			//							obj.Received_No="";
			//							obj.Invoice_No="";
			//							obj.Received_Amount=txtRecAmount.Text;
			//							obj.Actual_Amount = txtRecAmount.Text;
			//							obj.InsertPaymentReceived();
			//						}
			//					}
			//					SqlDtr.Close();
			//					obj.Customer_Name=DropCustName.SelectedItem.Value;
			//					obj.Place=txtCity.Text.ToString();			
			//					if(PanReceiptNo.Visible==true)
			//						obj.Cr_Plus=Amount.ToString();
			//					else
			//						obj.Cr_Plus=txtRecAmount.Text.ToString();
			//					obj.Dr_Plus="0";
			//					obj.UpdateCustomerBalance();
			//					object op=null;
			//					//Call the procedure to enter the Payment details into customerLedgerTable.
			//					//if(Amount < 0)
			//					//{
			//					//	string str=Amount.ToString();
			//					//	string[] str1=str.Split(new char[] {'-'},str.Length);
			//					//	Amount=double.Parse(str1[1]);
			//					//}
			//					if(PanReceiptNo.Visible==true)
			//						//dbobj.ExecProc(OprType.Insert,"ProCustLedgerEntry",ref op,"@Cust_Name",DropCustName.SelectedItem.Value,"@City",txtCity.Text.ToString(),"@Amount", Amount,"@Rec_Acc_Type",Acc_Type,"@Receipt",Receipt,"@Receipt_No",int.Parse(DropReceiptNo.SelectedItem.Text),"@RecDate",RecDate);
			//						dbobj.ExecProc(OprType.Insert,"ProCustLedgerEntry",ref op,"@Cust_Name",DropCustName.SelectedItem.Value,"@City",txtCity.Text.ToString(),"@Amount", Amount,"@Rec_Acc_Type",Acc_Type,"@Receipt",Receipt,"@Receipt_No",int.Parse(DropReceiptNo.SelectedItem.Text));
			//					else
			//						//dbobj.ExecProc(OprType.Insert,"ProCustLedgerEntry",ref op,"@Cust_Name",DropCustName.SelectedItem.Value,"@City",txtCity.Text.ToString(),"@Amount", float.Parse(txtRecAmount.Text),"@Rec_Acc_Type",Acc_Type,"@Receipt",Receipt,"@Receipt_No","","@RecDate",DateTime.Now.ToString());
			//						dbobj.ExecProc(OprType.Insert,"ProCustLedgerEntry",ref op,"@Cust_Name",DropCustName.SelectedItem.Value,"@City",txtCity.Text.ToString(),"@Amount", float.Parse(txtRecAmount.Text),"@Rec_Acc_Type",Acc_Type,"@Receipt",Receipt,"@Receipt_No","");
			//					//***********************
			//					if(PanReceiptNo.Visible==true)
			//					{
			//						SqlDataReader rdr=null;
			//						SqlCommand cmd;
			//						SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			//						string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name='"+DropCustName.SelectedItem.Text+"') order by entry_date";
			//						//string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where sub_grp_id=118) order by entry_date";
			//						rdr=obj.GetRecordSet(str);
			//						double Bal=0;
			//						string BalType="";
			//						int i=0;
			//						while(rdr.Read())
			//						{
			//							if(i==0)
			//							{
			//								BalType=rdr["Bal_Type"].ToString();
			//								i++;
			//							}
			//							if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
			//							{
			//								if(BalType=="Cr")
			//								{
			//									Bal+=double.Parse(rdr["Credit_Amount"].ToString());
			//									BalType="Cr";
			//								}
			//								else
			//								{
			//									Bal-=double.Parse(rdr["Credit_Amount"].ToString());
			//									if(Bal<0)
			//									{
			//										Bal=double.Parse(Bal.ToString().Substring(1));
			//										BalType="Cr";
			//									}
			//									else
			//										BalType="Dr";
			//								}
			//							}
			//							else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
			//							{
			//								if(BalType=="Dr")
			//									Bal+=double.Parse(rdr["Debit_Amount"].ToString());
			//								else
			//								{
			//									Bal-=double.Parse(rdr["Debit_Amount"].ToString());
			//									if(Bal<0)
			//									{
			//										Bal=double.Parse(Bal.ToString().Substring(1));
			//										BalType="Dr";
			//									}
			//									else
			//										BalType="Cr";
			//								}
			//							}
			//							Con.Open();
			//							cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"' ",Con);
			//							cmd.ExecuteNonQuery();
			//							cmd.Dispose();
			//							Con.Close();
			//							
			//						}
			//						rdr.Close();
			//						//SeqCashAccount();
			//						//****************
			//						string str1="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer where Cust_Name='"+DropCustName.SelectedItem.Text+"') order by entrydate";
			//						rdr=obj.GetRecordSet(str1);
			//						Bal=0;
			//						i=0;
			//						BalType="";
			//						while(rdr.Read())
			//						{
			//							if(i==0)
			//							{
			//								BalType=rdr["BalanceType"].ToString();
			//								i++;
			//							}
			//							if(double.Parse(rdr["CreditAmount"].ToString())!=0)
			//							{
			//								if(BalType=="Cr.")
			//								{
			//									Bal+=double.Parse(rdr["CreditAmount"].ToString());
			//									BalType="Cr.";
			//								}
			//								else
			//								{
			//									Bal-=double.Parse(rdr["CreditAmount"].ToString());
			//									if(Bal<0)
			//									{
			//										Bal=double.Parse(Bal.ToString().Substring(1));
			//										BalType="Cr.";
			//									}
			//									else
			//										BalType="Dr.";
			//								}
			//							}
			//							else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
			//							{
			//								if(BalType=="Dr.")
			//									Bal+=double.Parse(rdr["DebitAmount"].ToString());
			//								else
			//								{
			//									Bal-=double.Parse(rdr["DebitAmount"].ToString());
			//									if(Bal<0)
			//									{
			//										Bal=double.Parse(Bal.ToString().Substring(1));
			//										BalType="Dr.";
			//									}
			//									else
			//										BalType="Cr.";
			//								}
			//							}
			//							Con.Open();
			//							cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
			//							cmd.ExecuteNonQuery();
			//							cmd.Dispose();
			//							Con.Close();
			//						}
			//						rdr.Close();
			//					}
			//					//***********************
			//					//print();
			//					if(PanReceiptNo.Visible==true)
			//						MessageBox.Show("Payment Receipt Updated");
			//					else
			//						MessageBox.Show("Payment Receipt Save");
			//					Clear();
			//					CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:btnSaved_Clicked  Payment receipt saved. User_ID: " +uid);
			//					GridDuePayment.DataSource = null;
			//					GridDuePayment.DataBind(); 
			//				}
			//				checkPrevileges();
			//				PanBankInfo.Visible=false;
			//				PanReceiptNo.Visible=false;
			//				btnSave.Text="Save";
			//			}
			//			catch(Exception ex)
			//			{
			//				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:btnSaved_Clicked "+"   EXCEPTION " +ex.Message +" "+ ex.StackTrace   +uid);
			//			}
			try
			{
				SaveUpdate();
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:btnSaved_Clicked "+"   EXCEPTION " +ex.Message +" "+ ex.StackTrace   +uid);
			}
		}
		static string LedgerID="";
		static string DiscLedgerName1="",DiscLedgerName2="",Invoice_Date="";
		//static double TempDiscAmt1=0,TempDiscAmt2=0;

		/// <summary>
		/// This method is used to save or update the record.
		/// </summary>
		public void SaveUpdate()
		{
			//string[] arrSubReceipt={"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
			InventoryClass  obj=new InventoryClass ();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
			SqlCommand cmd;
			SqlDataReader SqlDtr=null, rdr = null;
			ArrayList UpdateLedgerID = new ArrayList();
			ArrayList UpdateCustomerID = new ArrayList();
			double rec_amount;
			//double Amount=0;
			//double balance;
			string Receipt="Save";
			string Acc_Type = "";
			string _CustName;
			string _City;
			string Cust_ID="";
			int f = 0;
			int z=0;
			_CustName=DropCustName.SelectedItem.Value;
			_City=txtCity.Text; 
			checkAccount(); 
			if(DropMode.SelectedItem.Text.Equals("Cash"))
			{
				Acc_Type = "Cash in hand";
				if(f1 == 0)
				{
					MessageBox.Show("Cash Account not created");
					return;
				}
			}
			else
			{
				Acc_Type = "Bank";
				if(f2 == 0)
				{
					MessageBox.Show("Bank Account not created");
					return;
				}
			}
			if(f1 == 0 && f2==0)
			{
				MessageBox.Show("Cash and Bank Accounts are not created");
				return;
			}
			string	sql="";
			string[] strName=new string[2];
			if(_CustName.IndexOf(":")>0)
			{
				strName=_CustName.Split(new char[] {':'},_CustName.Length);
				Cust_ID=strName[1].ToString();
				UpdateLedgerID.Add(strName[1].ToString());
			}
			else
			{
				strName[0]=_CustName;
			
				sql="select Ledger_ID from Ledger_Master where Ledger_Name='"+strName[0].ToString()+"'";
				SqlDtr = obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
					Cust_ID = SqlDtr.GetValue(0).ToString();
					UpdateLedgerID.Add(SqlDtr.GetValue(0).ToString());
				}
				else
					Cust_ID = "0";
				SqlDtr.Close ();
			}
			if(PanReceiptNo.Visible==true)
			{
				sql="select Cust_ID from Customer where Cust_Name='"+strName[0].ToString()+"'";
				SqlDtr = obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
					UpdateCustomerID.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close ();
			}
			obj.Receipt="Save";
			if(PanBankInfo.Visible==true)
			{
				sql="Select Ledger_ID from Ledger_Master lm,Ledger_Master_sub_grp lmsg where lmsg.sub_grp_id = lm.sub_grp_id and lmsg.sub_grp_name like 'Bank%' and ledger_Name='"+DropBankName.SelectedItem.Text+"'";
				SqlDtr = obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
					obj.BankName = SqlDtr.GetValue(0).ToString();
					Acc_Type = SqlDtr.GetValue(0).ToString();
					UpdateLedgerID.Add(SqlDtr.GetValue(0).ToString());
				}
				else
					obj.BankName = "";
				SqlDtr.Close ();
			}
			else
			{
				//				dbobj.SelectQuery("select Ledger_ID from Ledger_Master lm, Ledger_Master_sub_grp lmsg where lm.sub_grp_id = lmsg.sub_grp_id and  lmsg.sub_grp_name = 'Cash in hand'",ref SqlDtr); 
				//				if(SqlDtr.Read())
				//				{
				//					UpdateLedgerID.Add(SqlDtr.GetValue(0).ToString());
				//				}
				//				SqlDtr.Close(); 
				obj.BankName="";
			}
			//obj.BankName=txtBankName.Text.Trim().ToString();
			obj.ChequeNo=txtChequeno.Text.Trim().ToString();
			obj.Mode=DropMode.SelectedItem.Text;
			obj.ChequeDate=GenUtil.str2MMDDYYYY(txtDate.Text.Trim().ToString());
				
			obj.Cust_ID=Cust_ID;
			obj.Narration=txtNar.Text;
			obj.discount=txtDisc1.Text;
			obj.Discount=txtDisc2.Text;
			obj.CustBankName=txtBankName.Text;
			obj.Invoice_Date=System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
			string DiscID1="0",DiscID2="0";
			if(DropDiscount1.SelectedIndex==0)
				obj.discountid1="";
			else
			{
				SqlDtr = obj.GetRecordSet("Select ledger_id from ledger_master lm,ledger_master_sub_grp lmsg where ledger_name='"+DropDiscount1.SelectedItem.Text+"' and lm.sub_grp_id=lmsg.sub_grp_id and sub_grp_name='discount'");
				if(SqlDtr.Read())
				{
					obj.discountid1=SqlDtr.GetValue(0).ToString();
					DiscID1=SqlDtr.GetValue(0).ToString();
					UpdateLedgerID.Add(SqlDtr.GetValue(0).ToString());
				}
				else
					obj.discountid1="";
				SqlDtr.Close();
			}
			if(DropDiscount2.SelectedIndex==0)
				obj.discountid2="";
			else
			{
				SqlDtr = obj.GetRecordSet("Select ledger_id from ledger_master where ledger_name='"+DropDiscount2.SelectedItem.Text+"'");
				if(SqlDtr.Read())
				{
					obj.discountid2=SqlDtr.GetValue(0).ToString();
					DiscID2=SqlDtr.GetValue(0).ToString();
					UpdateLedgerID.Add(SqlDtr.GetValue(0).ToString());
				}
				else
					obj.discountid2="";
				SqlDtr.Close();
			}
			if(txtDisc1.Text=="")
				obj.discountid1="";
			if(txtDisc2.Text=="")
				obj.discountid2="";
			//********** Add This code by Mahesh On 05.07.008 **********************************
			string DisType1 = "", DisType2 = "";
			if(DropDiscount1.SelectedIndex!=0)
			{
				DisType1 = DropDiscount1.SelectedItem.Text.Substring(0,1);
				DisType1 +="D";
			}
			if(DropDiscount2.SelectedIndex!=0)
			{
				DisType2 = DropDiscount2.SelectedItem.Text.Substring(0,1);
				DisType2 +="D";
			}
			double TotalAmt = 0;
			if(txtRecAmount.Text!="")
				TotalAmt+=double.Parse(txtRecAmount.Text);
			if(txtDisc1.Text!="")
				TotalAmt+=double.Parse(txtDisc1.Text);
			if(txtDisc2.Text!="")
				TotalAmt+=double.Parse(txtDisc2.Text);
			int OldCustID = 0;
			if(PanReceiptNo.Visible==true)
			{
				dbobj.ExecuteScalar("select cust_id from customer where cust_name=(select ledger_name from ledger_master where ledger_id = '"+LedgerID+"')",ref OldCustID);
			}
			//*********************************************************************************
			GetNextReceiptNo();
			//*********************************************
			// Check Amount payment from Ledger Account or from Customer.
			//*****dbobj.SelectQuery("select Ledger_ID from Cust_Ledger where Party_Name  = '"+_CustName+"' and Ledger_Id != ''",ref SqlDtr);// Comment by Mahesh b'coz can not use Cust_Ledger table.
			//*****if(SqlDtr.HasRows)
			if(_CustName.IndexOf(":")>0)
			{
				rec_amount = 0;
				rec_amount=System.Convert.ToDouble(txtRecAmount.Text);
				object op = null;
				f= 2;
				//MakingReport(f);
				MakingReport(f);
				//print();
				//call procedure to insert the record into payment_Receipt and voucher_transaction tables.
				
				if(PanReceiptNo.Visible==true)
				{
					//************* Add This code by Mahesh on 05.07.008 ******************
					int x = 0;
					dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
					dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt_"+DisType1+" ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
					dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt_"+DisType2+" ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
					dbobj1.Insert_or_Update("delete from CustomerLedgerTable where Particular = 'Payment Received("+DropReceiptNo.SelectedItem.Text+")' and CustID='"+OldCustID+"'",ref x);
					dbobj1.Insert_or_Update("delete from Payment_Receipt where Receipt_No='"+DropReceiptNo.SelectedItem.Text+"'",ref x);
					//*********************************************************************
					//dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Ledger_ID,"@amount",Amount,"@Acc_Type",Acc_Type,"@BankName",Acc_Type,"@ChNo",txtChequeno.Text,"@ChDate",txtDate.Text,"@Mode",DropMode.SelectedItem.Text,"@Narration",txtNar.Text,"@CustBankName",txtCustBankName.Text);
					if(DropMode.SelectedItem.Text=="Cash")
						//dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Cust_ID,"@amount",Amount,"@Acc_Type",Acc_Type,"@BankName","","@ChNo","","@ChDate","","@Mode",DropMode.SelectedItem.Text,"@Narration","","@CustBankName","","@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()),"@Cust_ID",Cust_ID,"@Receipt","Update","@Receipt_No",DropReceiptNo.SelectedItem.Text);
						dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Cust_ID,"@amount",TotalAmt,"@Acc_Type",Acc_Type,"@BankName","","@ChNo","","@ChDate","","@Mode",DropMode.SelectedItem.Text,"@Narration","","@CustID",Cust_ID,"@Receipt_No",DropReceiptNo.SelectedItem.Text,"@RecDate",GenUtil.str2MMDDYYYY(txtReceivedDate.Text),"@CustBankName","");
					else
						//dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Cust_ID,"@amount",Amount,"@Acc_Type",Acc_Type,"@BankName",Acc_Type,"@ChNo",txtChequeno.Text,"@ChDate",GenUtil.str2MMDDYYYY(txtDate.Text),"@Mode",DropMode.SelectedItem.Text,"@Narration",txtNar.Text,"@CustBankName",txtCustBankName.Text,"@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()),"@Cust_ID",Cust_ID,"@Receipt","Update","@Receipt_No",DropReceiptNo.SelectedItem.Text);
						dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Cust_ID,"@amount",TotalAmt,"@Acc_Type",Acc_Type,"@BankName",Acc_Type,"@ChNo",txtChequeno.Text,"@ChDate",GenUtil.str2MMDDYYYY(txtDate.Text),"@Mode",DropMode.SelectedItem.Text,"@Narration",txtNar.Text,"@RecDate",GenUtil.str2MMDDYYYY(txtReceivedDate.Text),"@CustID",Cust_ID,"@Receipt_No",DropReceiptNo.SelectedItem.Text,"@CustBankName",txtBankName.Text);
				}
				else
				{
					//dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Ledger_ID,"@amount",rec_amount,"@Acc_Type",Acc_Type,"@BankName","","@ChNo","","@ChDate","","@Mode",DropMode.SelectedItem.Text,"@Narration","","@CustBankName","");
					if(DropMode.SelectedItem.Text=="Cash")
						//dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Cust_ID,"@amount",rec_amount,"@Acc_Type",Acc_Type,"@BankName","","@ChNo","","@ChDate","","@Mode",DropMode.SelectedItem.Text,"@Narration","","@CustBankName","","@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()),"@Cust_ID",Cust_ID,"@Receipt","Save","@Receipt_No",ReceiptNo);
						dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Cust_ID,"@amount",TotalAmt,"@Acc_Type",Acc_Type,"@BankName","","@ChNo","","@ChDate","","@Mode",DropMode.SelectedItem.Text,"@Narration","","@CustID",Cust_ID,"@Receipt_No",ReceiptNo,"@RecDate",GenUtil.str2MMDDYYYY(txtReceivedDate.Text),"@CustBankName","");
					else
						//dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Cust_ID,"@amount",rec_amount,"@Acc_Type",Acc_Type,"@BankName",Acc_Type,"@ChNo",txtChequeno.Text,"@ChDate",GenUtil.str2MMDDYYYY(txtDate.Text),"@Mode",DropMode.SelectedItem.Text,"@Narration",txtNar.Text,"@CustBankName",txtCustBankName.Text,"@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()),"@Cust_ID",Cust_ID,"@Receipt","Save","@Receipt_No",ReceiptNo);
						dbobj.ExecProc(OprType.Insert,"InsertPayment",ref op,"@Ledger_ID",Cust_ID,"@amount",TotalAmt,"@Acc_Type",Acc_Type,"@BankName",Acc_Type,"@ChNo",txtChequeno.Text,"@ChDate",GenUtil.str2MMDDYYYY(txtDate.Text),"@Mode",DropMode.SelectedItem.Text,"@Narration",txtNar.Text,"@CustID",Cust_ID,"@Receipt_No",ReceiptNo,"@RecDate",GenUtil.str2MMDDYYYY(txtReceivedDate.Text),"@CustBankName",txtBankName.Text);
				}
				//MessageBox.Show("Payment Receipt Saved");
				//Clear();
			}
			else
			{
				f = 1 ;
				//MakingReport(f);
				MakingReport(f);
				
				//************** Add new code for save receipt in Payment_Receipt table ******************
				
				//				double TotalAmt = 0;
				//				if(txtRecAmount.Text!="")
				//					TotalAmt+=double.Parse(txtRecAmount.Text);
				//				if(txtDisc1.Text!="")
				//					TotalAmt+=double.Parse(txtDisc1.Text);
				//				if(txtDisc2.Text!="")
				//					TotalAmt+=double.Parse(txtDisc2.Text);
				//int OldCustID=0;
				object op=null;
				object ob=null;
				
				if(PanReceiptNo.Visible==true)
				{
					int x = 0;
					//dbobj.ExecuteScalar("select cust_id from customer where cust_name=(select ledger_name from ledger_master where ledger_id = '"+LedgerID+"')",ref OldCustID);
					if(LedgerID!=Cust_ID)
					{
						UpdateLedgerID.Add(LedgerID);
						UpdateCustomerID.Add(OldCustID);
						dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertLedgerDetails",ref ob,"@Cust_ID",OldCustID);
					}
					//dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt ("+DropReceiptNo.SelectedItem.Text+")' and Ledger_ID = '"+LedgerID+"'",ref x);
					dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
					dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt_"+DisType1+" ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
					dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt_"+DisType2+" ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
					//dbobj1.Insert_or_Update("delete from CustomerLedgerTable where Particular = 'Payment Received("+DropReceiptNo.SelectedItem.Text+")' and CustID='"+OldCustID+"'",ref x);
					dbobj1.Insert_or_Update("delete from CustomerLedgerTable where Particular = 'Payment Received("+DropReceiptNo.SelectedItem.Text+")'",ref x);
					dbobj1.Insert_or_Update("delete from Payment_Receipt where Receipt_No='"+DropReceiptNo.SelectedItem.Text+"'",ref x);
					int Curr_Credit = 0;
					int Credit_Limit = 0;
					dbobj.ExecuteScalar("Select Cr_Limit from customer where Cust_ID = '"+OldCustID+"'",ref Credit_Limit);
					dbobj.ExecuteScalar("Select Curr_Credit from customer where Cust_ID = '"+OldCustID+"'",ref Curr_Credit);
					if(Curr_Credit < Credit_Limit)
					{
						Curr_Credit = Curr_Credit + int.Parse(txtRecAmount.Text);
						if(@Curr_Credit >= @Credit_Limit)
							dbobj1.Insert_or_Update("update customer set Curr_Credit = '"+Credit_Limit+"' where Cust_ID  = '"+LedgerID+"'",ref x);
						else
							dbobj1.Insert_or_Update("update customer set Curr_Credit = '"+Curr_Credit+"' where Cust_ID  = '"+LedgerID+"'",ref x);
					}
					obj.Received_No = DropReceiptNo.SelectedItem.Text;
					//obj.SubReceived_No="A"+DropReceiptNo.SelectedItem.Text;
					//obj.Invoice_No="";
					obj.Received_Amount=TotalAmt.ToString();
					obj.Actual_Amount = System.Convert.ToString(double.Parse(txtRecAmount.Text));
					obj.InsertPaymentReceived();
					
					dbobj.ExecProc(OprType.Insert,"ProCustLedgerEntry",ref op,"@Cust_Name",DropCustName.SelectedItem.Value,"@City",txtCity.Text.ToString(),"@Amount", TotalAmt,"@Rec_Acc_Type",Acc_Type,"@Receipt",Receipt,"@Receipt_No",DropReceiptNo.SelectedItem.Text,"@ActualAmount",txtRecAmount.Text,"@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()));
					if(txtDisc1.Text!="" && txtDisc1.Text!="0")
						dbobj.ExecProc(OprType.Insert,"ProSpacialDiscountEntry",ref op,"@Cust_ID",Cust_ID,"@Receipt","Save","@Receipt_No",DropReceiptNo.SelectedItem.Text,"@Amount",txtDisc1.Text,"@Ledger_ID",DiscID1,"@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()),"@DisType",DisType1);
					if(txtDisc2.Text!="" && txtDisc2.Text!="0")
						dbobj.ExecProc(OprType.Insert,"ProSpacialDiscountEntry",ref op,"@Cust_ID",Cust_ID,"@Receipt","Save","@Receipt_No",DropReceiptNo.SelectedItem.Text,"@Amount",txtDisc2.Text,"@Ledger_ID",DiscID2,"@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()),"@DisType",DisType2);
				}
				else
				{
					obj.Received_No = ReceiptNo.ToString();
					//obj.SubReceived_No="A"+ReceiptNo.ToString();
					//obj.Invoice_No="";
					obj.Received_Amount=TotalAmt.ToString();
					obj.Actual_Amount = System.Convert.ToString(double.Parse(txtRecAmount.Text));
					obj.InsertPaymentReceived();

					dbobj.ExecProc(OprType.Insert,"ProCustLedgerEntry",ref op,"@Cust_Name",DropCustName.SelectedItem.Value,"@City",txtCity.Text.ToString(),"@Amount", TotalAmt,"@Rec_Acc_Type",Acc_Type,"@Receipt",Receipt,"@Receipt_No",ReceiptNo.ToString(),"@ActualAmount",txtRecAmount.Text,"@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()));
					if(txtDisc1.Text!="" && txtDisc1.Text!="0")
						dbobj.ExecProc(OprType.Insert,"ProSpacialDiscountEntry",ref op,"@Cust_ID",Cust_ID,"@Receipt","Save","@Receipt_No",ReceiptNo.ToString(),"@Amount",txtDisc1.Text,"@Ledger_ID",DiscID1,"@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()),"@DisType",DisType1);
					if(txtDisc2.Text!="" && txtDisc2.Text!="0")
						dbobj.ExecProc(OprType.Insert,"ProSpacialDiscountEntry",ref op,"@Cust_ID",Cust_ID,"@Receipt","Save","@Receipt_No",ReceiptNo.ToString(),"@Amount",txtDisc2.Text,"@Ledger_ID",DiscID2,"@RecDate",System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)+" "+DateTime.Now.TimeOfDay.ToString()),"@DisType",DisType2);
				}
				if(PanReceiptNo.Visible==true)
					UpdateLedgDetails(OldCustID.ToString());
				else
				{
					int CustID =0;
					dbobj.ExecuteScalar("select cust_id from customer where cust_name=(select ledger_name from ledger_master where ledger_id = '"+Cust_ID+"')",ref CustID);
					UpdateLedgDetails(CustID.ToString());
				}
				//**************************************** End *******************************************
			}
			if(PanReceiptNo.Visible==true)
			{
				//SqlDataReader rdr=null;
				//SqlCommand cmd;
				//SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
				//string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name='"+DropCustName.SelectedItem.Text+"') order by entry_date";
				double Bal=0;
				object obj1=null;
				string BalType="",tempDate="";
				int i=0;
					
				if(DateTime.Compare(System.Convert.ToDateTime(Invoice_Date),System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtReceivedDate.Text)))>0)
					tempDate=GenUtil.str2MMDDYYYY(txtReceivedDate.Text);
				else
					tempDate=Invoice_Date;
										
				for(int p=0;p<UpdateLedgerID.Count;p++)
				{
					dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref obj1,"@Ledger_ID",UpdateLedgerID[p].ToString(),"@Invoice_Date",tempDate);
					/* Comment This code by Mahesh on 11.11.008,
						 * This process handle by store procedures.
						 * 
						//string str="select * from AccountsLedgerTable where Ledger_ID='"+UpdateLedgerID[p]+"' and cast(floor(cast(cast(entry_date as datetime) as float)) as datetime)>=dateadd(day,-1,"+Invoice_Date+") order by entry_date";
						string str="select * from AccountsLedgerTable where Ledger_ID='"+UpdateLedgerID[p]+"' order by entry_date";
						//string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where sub_grp_id=118) order by entry_date";
						rdr=obj.GetRecordSet(str);
						Bal=0;
						BalType="";
						i=0;
						while(rdr.Read())
						{
							if(i==0)
							{
								BalType=rdr["Bal_Type"].ToString();
								i++;
							}
							if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
							{
								if(BalType=="Cr")
								{
									Bal+=double.Parse(rdr["Credit_Amount"].ToString());
									BalType="Cr";
								}
								else
								{
									Bal-=double.Parse(rdr["Credit_Amount"].ToString());
									if(Bal<0)
									{
										Bal=double.Parse(Bal.ToString().Substring(1));
										BalType="Cr";
									}
									else
										BalType="Dr";
								}
							}
							else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
							{
								if(BalType=="Dr")
									Bal+=double.Parse(rdr["Debit_Amount"].ToString());
								else
								{
									Bal-=double.Parse(rdr["Debit_Amount"].ToString());
									if(Bal<0)
									{
										Bal=double.Parse(Bal.ToString().Substring(1));
										BalType="Dr";
									}
									else
										BalType="Cr";
								}
							}
							Con.Open();
							cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
							cmd.ExecuteNonQuery();
							cmd.Dispose();
							Con.Close();
							
						}
						rdr.Close();
						***************************************/
				}
					
				//SeqCashAccount();
					
				//string str1="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer where Cust_Name='"+DropCustName.SelectedItem.Text+"') order by entrydate";
				for(int p=0;p<UpdateCustomerID.Count;p++)
				{
					dbobj.ExecProc(OprType.Insert,"UpdateCustomerLedgerForCustomer",ref obj1,"@Cust_ID",UpdateCustomerID[p].ToString(),"@Invoice_Date",tempDate);
					/* Comment This Process By Mahesh on 11.11.008,
						* This process hanble by stored procedures
						* 
						//string str1="select * from CustomerLedgerTable where CustID='"+UpdateCustomerID[p]+"' and cast(floor(cast(cast(entrydate as datetime) as float)) as datetime)>='"+Invoice_Date+"' order by entrydate";
						string str1="select * from CustomerLedgerTable where CustID='"+UpdateCustomerID[p]+"' order by entrydate";
						rdr=obj.GetRecordSet(str1);
						Bal=0;
						i=0;
						BalType="";
						while(rdr.Read())
						{
							if(i==0)
							{
								BalType=rdr["BalanceType"].ToString();
								i++;
							}
							if(double.Parse(rdr["CreditAmount"].ToString())!=0)
							{
								if(BalType=="Cr.")
								{
									Bal+=double.Parse(rdr["CreditAmount"].ToString());
									BalType="Cr.";
								}
								else
								{
									Bal-=double.Parse(rdr["CreditAmount"].ToString());
									if(Bal<0)
									{
										Bal=double.Parse(Bal.ToString().Substring(1));
										BalType="Cr.";
									}
									else
										BalType="Dr.";
								}
							}
							else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
							{
								if(BalType=="Dr.")
									Bal+=double.Parse(rdr["DebitAmount"].ToString());
								else
								{
									Bal-=double.Parse(rdr["DebitAmount"].ToString());
									if(Bal<0)
									{
										Bal=double.Parse(Bal.ToString().Substring(1));
										BalType="Dr.";
									}
									else
										BalType="Cr.";
								}
							}
							Con.Open();
							cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
							cmd.ExecuteNonQuery();
							cmd.Dispose();
							Con.Close();
						}
						rdr.Close();
						**************************************************/	
				}
			}
			else
			{
				object op=null;
				dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref op,"@Ledger_ID",Cust_ID,"@Invoice_Date",GenUtil.str2MMDDYYYY(txtReceivedDate.Text));
				dbobj.SelectQuery("Select * from Customer, Ledger_Master where Ledger_Name=Cust_Name and Ledger_ID='"+Cust_ID+"'",ref SqlDtr);
				if(SqlDtr.Read())
				{
					dbobj.ExecProc(OprType.Insert,"UpdateCustomerLedgerForCustomer",ref op,"@Cust_ID",SqlDtr["Cust_ID"].ToString(),"@Invoice_Date",GenUtil.str2MMDDYYYY(txtReceivedDate.Text));
				}
				SqlDtr.Close();
			}
			//*********************add by Mahesh on 16.01.008
			if(DropReceiptNo.Visible==true)
				MessageBox.Show("Payment Receipt Updated");
			else
				MessageBox.Show("Payment Receipt Saved");
			Clear();
			CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:btnSaved_Clicked  Payment receipt saved. User_ID: " +uid);
			GridDuePayment.DataSource = null;
			GridDuePayment.DataBind(); 
			//***********************
			//checkPrevileges();
			PanBankInfo.Visible=false;
			PanReceiptNo.Visible=false;
			btnSave.Text="Save";
			DropMode.Enabled=true;
			//DropBankName.Enabled=true;
			btnPrint.CausesValidation=false;
			PrintFlag=true;
		}

		int ReceiptNo=0;
		/// <summary>
		/// This method is used to get the next id for saveing the data.
		/// </summary>
		public void GetNextReceiptNo()
		{
			SqlDataReader rdr=null;
			dbobj.SelectQuery("select max(Receipt_No)+1 from payment_receipt",ref rdr);
			if(rdr.Read())
			{
				if(rdr.GetValue(0).ToString()!=null && rdr.GetValue(0).ToString()!="")
					ReceiptNo=System.Convert.ToInt32(rdr.GetValue(0).ToString());
				else
					ReceiptNo=1001;
			}
		}
		
		/// <summary>
		/// This method is used to Clears whole form.
		/// </summary>
		public void Clear()
		{
			txtReceivedDate.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			LedgerID="";
			GridDuePayment.Columns.Clear();
			DropCustName.SelectedIndex=0;
			DropMode.SelectedIndex=0;
			txtCity.Text="";
			txtAmountinWords.Text="";
			txtCr.Text="";
			txtFinalDues.Text ="";
			txtRecAmount.Text="";
			txtTotalBalance.Text="";
			Textbox1.Text="";
			Textbox2.Text="";
			Textbox3.Text="";
			txtBankName.Text="";
			PanBankInfo.Visible=false;
			txtChequeno.Text="";
			txtNar.Text="";
			tempReceiptInfo.Value="";
			txtDisc1.Text="";
			txtDisc2.Text="";
			GridDuePayment.Visible=false;
			PanReceiptNo.Visible=false;
			btnSave.Text="Save";
			DropBankName.SelectedIndex=0;
			CustName="";
			Invoice_Date="";
		}

		private void DropMode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropMode.SelectedItem.Text.Equals("Cash"))
				PanBankInfo.Visible=false;
			else
			{
				PanBankInfo.Visible=true;
				if(DropBankName.Items.Count>1)
					DropBankName.SelectedIndex=1;
			}
		}

		/// <summary>
		/// This Method is used to write into the report file to print.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			print();
		}

		/// <summary>
		/// This method is used to fill the Receipt No in dropdownlist.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			Clear();
			GridDuePayment.DataSource = null;
			GridDuePayment.DataBind(); 
			PanReceiptNo.Visible=true;
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr=null;
			string	sql="select Receipt_No  from Payment_Receipt order by Receipt_No";  
			SqlDtr = obj.GetRecordSet(sql);
			DropReceiptNo.Items.Clear();
			DropReceiptNo.Items.Add("Select");
			while(SqlDtr.Read())
			{
				DropReceiptNo.Items.Add(SqlDtr.GetValue(0).ToString());
			}
			SqlDtr.Close ();
			
		}
		
		static string RecDate="",CustName="";
		/// <summary>
		/// This method is used to fatch the particular record according to select the Receipt No from dropdownlist.
		/// </summary>
		private void DropReceiptNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtFinalDues.Text="";
			txtRecAmount.Text="";
			Textbox2.Text =""; 
			Textbox1.Text = "";
			//string Invoice_No="";
			btnSave.Text="Update";
			CustName="";
			string str="";
			//			if(DropCustName.SelectedIndex ==0)
			//				return;
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr,rdr=null;
			string sql,Cust_ID="",LedgerName="",strstr="";
			double totdisc=0;
			sql="select * from payment_receipt where Receipt_No="+DropReceiptNo.SelectedItem.Text;
			SqlDtr = obj.GetRecordSet(sql);
			if(SqlDtr.Read())
			{
				if(SqlDtr["Narration"].ToString()=="Deleted")
				{
					btnSave.Enabled=false;
					btnEdit.Enabled=false;
					btnPrint.Enabled=false;
					btnDelete.Enabled=false;
					DropCustName.Enabled=false;
					txtNar.Text="Deleted";
					txtNar.CssClass="TextColor";
					Textbox1.Text="0";
					GridDuePayment.Visible=false;
					return;
				}
				btnSave.Enabled=true;
				btnEdit.Enabled=true;
				btnPrint.Enabled=true;
				btnDelete.Enabled=true;
				DropCustName.Enabled=true;
				//**Invoice_No=SqlDtr.GetValue(2).ToString();
				DropMode.SelectedIndex=DropMode.Items.IndexOf(DropMode.Items.FindByValue(SqlDtr["mode"].ToString()));
				if(SqlDtr.GetValue(3).ToString()!="")
				{
					dbobj.SelectQuery("select Ledger_Name,Ledger_ID from Ledger_Master where Ledger_ID='"+SqlDtr.GetValue(3).ToString()+"'",ref rdr);
					if(rdr.Read())
					{
						DropBankName.SelectedIndex=DropBankName.Items.IndexOf(DropBankName.Items.FindByValue(rdr["Ledger_Name"].ToString()));
					}
					rdr.Close();
				}
				else
				{
					DropBankName.SelectedIndex=0;
				}
				txtBankName.Text=SqlDtr["CustBankName"].ToString();
				txtChequeno.Text=SqlDtr["ChequeNo"].ToString();
				txtDate.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(SqlDtr["ChequeDate"].ToString()));
				str=SqlDtr["Received_Amount"].ToString();
				txtReceivedDate.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(SqlDtr["Receipt_Date"].ToString()));
				//Cache["RecAmt"]=GenUtil.strNumericFormat(SqlDtr["Received_Amount"].ToString());
				Cust_ID=SqlDtr["Cust_ID"].ToString();
				LedgerID=SqlDtr["Cust_ID"].ToString();
				if(Cust_ID=="0")
				{
					strstr = "select Ledger_Name,Ledger_ID from Ledger_Master where Ledger_ID=(select top 1 Ledger_ID from AccountsLedgerTable where Particulars='Receipt ("+DropReceiptNo.SelectedItem.Text+")' and Credit_Amount<>0)";
					dbobj.SelectQuery(strstr,ref rdr);
					if(rdr.Read())
					{
						LedgerName=rdr.GetValue(0).ToString()+":"+rdr.GetValue(1).ToString();
					}
					rdr.Close();
				}
				txtNar.Text=SqlDtr["Narration"].ToString();
				RecDate=SqlDtr["Receipt_Date"].ToString();
				Invoice_Date=GenUtil.trimDate(SqlDtr["Receipt_Date"].ToString());
				//********
				totdisc=double.Parse(SqlDtr["Received_Amount"].ToString());
				if(SqlDtr["Discount1"].ToString()!="")
					totdisc+=double.Parse(SqlDtr["Discount1"].ToString());
				if(SqlDtr["Discount2"].ToString()!="")
					totdisc+=double.Parse(SqlDtr["Discount2"].ToString());
				dbobj.SelectQuery("select Ledger_Name from Ledger_Master where Ledger_ID='"+SqlDtr["DiscLedgerID1"].ToString()+"'",ref rdr);
				if(rdr.Read())
				{
					DropDiscount1.SelectedIndex=DropDiscount1.Items.IndexOf(DropDiscount1.Items.FindByValue(rdr["Ledger_Name"].ToString()));
					DiscLedgerName1 = rdr["Ledger_Name"].ToString();
				}
				else
				{
					DropDiscount1.SelectedIndex=0;
					DiscLedgerName1 = "";
				}
				rdr.Close();
				dbobj.SelectQuery("select Ledger_Name from Ledger_Master where Ledger_ID='"+SqlDtr["DiscLedgerID2"].ToString()+"'",ref rdr);
				if(rdr.Read())
				{
					DropDiscount2.SelectedIndex=DropDiscount2.Items.IndexOf(DropDiscount2.Items.FindByValue(rdr["Ledger_Name"].ToString()));
					DiscLedgerName2 = rdr["Ledger_Name"].ToString();
				}
				else
				{
					DropDiscount2.SelectedIndex=0;
					DiscLedgerName2 = "";
				}
				rdr.Close();
				if(DropDiscount1.SelectedIndex==0)
					txtDisc1.Enabled=false;
				else
					txtDisc1.Enabled=true;
				if(DropDiscount2.SelectedIndex==0)
					txtDisc2.Enabled=false;
				else
					txtDisc2.Enabled=true;
				//				if(double.Parse(SqlDtr["Discount1"].ToString())>0)
				//					TempDiscAmt1=double.Parse(SqlDtr["Discount1"].ToString());
				//				else
				//					TempDiscAmt1=0;
				//				if(double.Parse(SqlDtr["Discount2"].ToString())>0)
				//					TempDiscAmt2=double.Parse(SqlDtr["Discount2"].ToString());
				//				else
				//					TempDiscAmt2=0;
				txtDisc1.Text=SqlDtr["Discount1"].ToString();
				txtDisc2.Text=SqlDtr["Discount2"].ToString();
				Textbox1.Text=totdisc.ToString();
				//********
			}
			SqlDtr.Close();
			
			if(str.StartsWith("-"))
			{
				string[] str1=str.Split(new char[] {'-'},str.Length);
				txtRecAmount.Text=str1[1];
			}
			else
				txtRecAmount.Text=GenUtil.strNumericFormat(str);
			//RecAmt=double.Parse(txtRecAmount.Text);
			RecAmt=totdisc;
			Cache["RecAmt"]=totdisc.ToString();
			if(DropMode.SelectedItem.Text.Equals("Cash"))
				PanBankInfo.Visible=false;
			else
				PanBankInfo.Visible=true;
			//******Maheshstart
			//sql="select Cust_ID from Sales_Master where Invoice_No='"+Invoice_No+"'";
			//SqlDtr = obj.GetRecordSet(sql);
			//if(SqlDtr.Read())
			//{
			//	CustID=SqlDtr.GetValue(0).ToString();
			//}
			//SqlDtr.Close();
			//*********end
			//sql="select Cust_Name from Customer where Cust_ID='"+Cust_ID+"'";
			/*********************************************
			string CustID="";
			sql="select Ledger_Name,Cust_ID from Ledger_Master lm,customer c where cust_Name=Ledger_Name and Ledger_ID='"+Cust_ID+"'";
			SqlDtr = obj.GetRecordSet(sql);
			if(SqlDtr.Read())
			{
				CustName=SqlDtr.GetValue(0).ToString();
				CustID = SqlDtr.GetValue(1).ToString();
			}
			SqlDtr.Close();

			#region Fetch Place of Customer Regarding Customer Name
			sql="select City from Customer where Cust_Name='"+CustName+"'";
			SqlDtr = obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				if(SqlDtr.GetValue(0).ToString().Equals(""))
				{
					txtCity.Text="";
				}
				else
				{
					txtCity.Text =SqlDtr.GetValue(0).ToString();
				}
			}
			SqlDtr.Close ();		
			************************************/
			string CustID = "";
			int FlagFlag=0;
			sql="select Cust_Name,City,cust_id from Ledger_Master l,Customer c where l.ledger_name=c.cust_name and Ledger_ID='"+Cust_ID+"'";
			SqlDtr = obj.GetRecordSet(sql);
			if(SqlDtr.Read())
			{
				CustName=SqlDtr.GetValue(0).ToString();
				if(SqlDtr.GetValue(1).ToString().Equals(""))
					txtCity.Text="";
				else
					txtCity.Text=SqlDtr.GetValue(1).ToString();
				CustID=SqlDtr.GetValue(2).ToString();
				FlagFlag=1;
			}
			SqlDtr.Close ();
			if(FlagFlag==0)
			{
				sql="select Ledger_Name,city,Ledger_ID from Ledger_Master l,Employee e where l.ledger_name=e.Emp_name and Ledger_ID='"+Cust_ID+"'";
				SqlDtr = obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
					CustName=SqlDtr.GetValue(0).ToString()+":"+SqlDtr.GetValue(2).ToString();
					if(SqlDtr.GetValue(1).ToString().Equals(""))
						txtCity.Text="";
					else
						txtCity.Text=SqlDtr.GetValue(1).ToString();
					FlagFlag=1;
					//					DropDiscount1.Enabled=false;
					//					DropDiscount2.Enabled=false;
					//					txtDisc1.Enabled=false;
					//					txtDisc2.Enabled=false;
				}
				SqlDtr.Close ();
			}
			//********Maheshstart
			//string _CustName;
			//string _City;
			//string Cust_ID;
			DropCustName.SelectedIndex=DropCustName.Items.IndexOf(DropCustName.Items.FindByValue(CustName));
			//_CustName=DropCustName.SelectedItem.Value;
			//_City=txtCity.Text; 
				
			//sql="select Cust_ID  from Customer where Cust_Name='"+ _CustName+"' and City = '"+_City+"'";  
			//SqlDtr = obj.GetRecordSet(sql);
			//if(SqlDtr.Read())
			//{
			//	Cust_ID =SqlDtr.GetValue(0).ToString();
			//}
			//else
			//{
			//	Cust_ID = "0";
			//}
			//SqlDtr.Close ();
			//**********end
			// Disable the Bill Details and Total Due amount fields for the Ledger.
			//dbobj.SelectQuery("select Ledger_ID  from Cust_Ledger where Party_Name  = '"+_CustName+"' and Ledger_Id != ''",ref SqlDtr);
			dbobj.SelectQuery("select Ledger_ID from Cust_Ledger where Party_Name  = '"+CustName+"' and Ledger_Id != ''",ref SqlDtr);
			if(SqlDtr.HasRows)
			{
				Textbox3.Text="";
				txtCr.Text = "";
				GridDuePayment.Visible = false;
				txtTotalBalance.Enabled = false;
				txtTotalBalance.Text ="";
				Textbox2.Enabled = false;
				Textbox3.Enabled = false;
				txtCr.Enabled = false;
				txtFinalDues.Enabled = false;
			}
			else
			{
				GridDuePayment.Visible = true;
				txtTotalBalance.Enabled = true;
				Textbox2.Enabled = true;
				Textbox3.Enabled = true;
				txtCr.Enabled = true;
				txtFinalDues.Enabled = true;
				//object op =null;
				//dbobj.ExecProc(OprType.Insert,"Test",ref op,"@Cust_ID",Cust_ID);
				//dbobj.ExecProc(OprType.Insert,"Test",ref op,"@Cust_ID",Cust_ID);

				#region Bind DataGrid
				//SqlDtr=obj.GetRecordSet("select Bill_No as invoice_no,Bill_date as invoice_date,Amount as balance from LedgDetails where cust_id = '"+Cust_ID+"' and Amount > 0");
				//SqlDtr=obj.GetRecordSet("select Bill_No as invoice_no,Bill_date as invoice_date,Amount as balance from LedgDetails where cust_id = '"+CustID+"' and Amount > 0 order by bill_date");
				SqlDtr=obj.GetRecordSet("select '' as invoice_no,receipt_date as invoice_date,(Received_Amount+discount1+discount2) balance from payment_receipt where receipt_no='"+DropReceiptNo.SelectedItem.Text+"'");
				GridDuePayment.DataSource=SqlDtr;
				GridDuePayment.DataBind();
				SqlDtr.Close();
				#endregion

				txtTotalBalance.Text =total.ToString();
			}
			checkPrevileges();
		}
		
		/// <summary>
		/// This method is not used.
		/// </summary>
		public void SeqCashAccount()
		{
			InventoryClass obj = new InventoryClass();
			SqlDataReader rdr=null;
			SqlCommand cmd;
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			//dbobj.SelectQuery("select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where sub_grp_id=118 and Ledger_Name='Cash') order by entry_date",ref rdr);
			string str = "select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where sub_grp_id=118 and Ledger_Name='Cash') order by entry_date";
			rdr = obj.GetRecordSet(str);
			double Bal=0;
			string BalType="";
			int i=0;
			while(rdr.Read())
			{
				if(i==0)
				{
					BalType=rdr["Bal_Type"].ToString();
					i++;
				}
				if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
				{
					if(BalType=="Cr")
					{
						Bal+=double.Parse(rdr["Credit_Amount"].ToString());
						BalType="Cr";
					}
					else
					{
						Bal-=double.Parse(rdr["Credit_Amount"].ToString());
						if(Bal<0)
						{
							Bal=double.Parse(Bal.ToString().Substring(1));
							BalType="Cr";
						}
						else
							BalType="Dr";
					}
				}
				else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
				{
					if(BalType=="Dr")
						Bal+=double.Parse(rdr["Debit_Amount"].ToString());
					else
					{
						Bal-=double.Parse(rdr["Debit_Amount"].ToString());
						if(Bal<0)
						{
							Bal=double.Parse(Bal.ToString().Substring(1));
							BalType="Dr";
						}
						else
							BalType="Cr";
					}
				}
				Con.Open();
				cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"' ",Con);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				Con.Close();
							
			}
			rdr.Close();
		}

		/// <summary>
		/// This method is used to delete the particular record who select from dropdownlist.
		/// </summary>
		public void DeleteTheRec()
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				SqlCommand cmd;
				SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
				//string st="select Invoice_No from Payment_Receipt where Invoice_No='"+DropReceiptNo.SelectedItem.Text+"'";
				//rdr=obj.GetRecordSet(st);
				//if(rdr.Read())
				//{
				Con.Open();
				cmd = new SqlCommand("delete from Accountsledgertable where Particulars='Receipt ("+DropReceiptNo.SelectedItem.Text+")'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				//}
				//rdr.Close();
						
				string str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name='"+DropCustName.SelectedItem.Text+"') order by entry_date";
				rdr=obj.GetRecordSet(str);
				double Bal=0;
				while(rdr.Read())
				{
					if(rdr["Bal_Type"].ToString().Equals("Dr"))
						Bal+=double.Parse(rdr["Debit_Amount"].ToString())-double.Parse(rdr["Credit_Amount"].ToString());
					else
						Bal+=double.Parse(rdr["Credit_Amount"].ToString())-double.Parse(rdr["Debit_Amount"].ToString());
					if(Bal.ToString().StartsWith("-"))
						Bal=double.Parse(Bal.ToString().Substring(1));
					Con.Open();
					cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					Con.Close();
					cmd.Dispose();
				}
				rdr.Close();
				str="select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where Ledger_Name='Cash') order by entry_date";
				rdr=obj.GetRecordSet(str);
				Bal=0;
				while(rdr.Read())
				{
					if(rdr["Bal_Type"].ToString().Equals("Dr"))
						Bal+=double.Parse(rdr["Debit_Amount"].ToString())-double.Parse(rdr["Credit_Amount"].ToString());
					else
						Bal+=double.Parse(rdr["Credit_Amount"].ToString())-double.Parse(rdr["Debit_Amount"].ToString());
					if(Bal.ToString().StartsWith("-"))
						Bal=double.Parse(Bal.ToString().Substring(1));
					Con.Open();
					cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					Con.Close();
					cmd.Dispose();
				}
				rdr.Close();
				Con.Open();
				cmd = new SqlCommand("delete from Payment_Receipt where Receipt_No='"+DropReceiptNo.SelectedItem.Text+"'",Con);
				cmd.ExecuteNonQuery();
				Con.Close();
				cmd.Dispose();
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Method:btnDelete_Click - Receipt No : " + DropReceiptNo.SelectedItem.Text+" Deleted, user : "+uid);
				Clear();
				//GetNextInvoiceNo();
				//GetProducts();
				//FatchInvoiceNo();
				//FatchInvoiceNo();
				PanReceiptNo.Visible=false;
				PanBankInfo.Visible=false;
				MessageBox.Show("Receipt Transaction Deleted");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Method:btnDelete_Click - Receipt No : " + DropReceiptNo.SelectedItem.Text+" ,Exception : "+ex.Message+" user : "+uid);
			}
		}

		/// <summary>
		/// This method is used to delete the particular record who select from dropdownlist.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
				SqlCommand cmd;
				InventoryClass obj2 = new InventoryClass();
				InventoryClass obj1 = new InventoryClass();
				SqlDataReader rdr=null,rdr1=null;
				string DisType1 = "", DisType2 = "";
				if(DropDiscount1.SelectedIndex!=0)
				{
					DisType1 = DropDiscount1.SelectedItem.Text.Substring(0,1);
					DisType1 +="D";
				}
				if(DropDiscount2.SelectedIndex!=0)
				{
					DisType2 = DropDiscount2.SelectedItem.Text.Substring(0,1);
					DisType2 +="D";
				}
				int x=0;
				object obj = null;
				int OldCustID=0;
				dbobj.Insert_or_Update("delete from AccountsLedgerTable where particulars = 'Receipt ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
				dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt_"+DisType1+" ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
				dbobj1.Insert_or_Update("delete from AccountsLedgerTable where Particulars = 'Receipt_"+DisType2+" ("+DropReceiptNo.SelectedItem.Text+")'",ref x);
				dbobj.Insert_or_Update("delete from CustomerLedgerTable where particular = 'Payment Received("+DropReceiptNo.SelectedItem.Text+")'",ref x);
				dbobj.Insert_or_Update("delete from Payment_Receipt where Receipt_No='"+DropReceiptNo.SelectedItem.Text+"'",ref x);
				dbobj.Insert_or_Update("insert into payment_receipt values("+DropReceiptNo.SelectedItem.Text+",'','','','','','','','Deleted','','','','','')",ref x);
				dbobj.ExecuteScalar("select cust_id from customer where cust_name=(select ledger_name from ledger_master where ledger_id = '"+LedgerID+"')",ref OldCustID);
				dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertLedgerDetails",ref obj,"@Cust_ID",OldCustID);
				dbobj.ExecProc(OprType.Insert,"UpdateAccountsLedgerForCustomer",ref obj,"@Ledger_ID",LedgerID,"@Invoice_Date",GenUtil.str2MMDDYYYY(txtReceivedDate.Text));
				dbobj.ExecProc(OprType.Insert,"UpdateCustomerLedgerForCustomer",ref obj,"@Cust_ID",OldCustID,"@Invoice_Date",GenUtil.str2MMDDYYYY(txtReceivedDate.Text));
				/* Comment This Code By Mahesh on 10.11.008, 
				 * because this process add in ProInsertLedgerDetails stored procedures.
				 * 
				rdr = obj2.GetRecordSet("select CustID,sum(creditamount) CreditAmount from customerledgertable where custid='"+OldCustID+"' group by custid");
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{
						double Amt=double.Parse(rdr["CreditAmount"].ToString());
						rdr1 = obj1.GetRecordSet("select * from LedgDetails where Cust_ID='"+rdr["Custid"].ToString()+"' order by Bill_Date");
						while(rdr1.Read())
						{
							Amt=Amt-double.Parse(rdr1["Amount"].ToString());
							if(Amt>=0)
							{
								Con.Open();
								cmd = new SqlCommand("update LedgDetails set Amount=0 where Cust_ID='"+rdr["CustID"].ToString()+"' and Bill_No='"+rdr1["Bill_No"].ToString()+"'",Con);
								cmd.ExecuteNonQuery();
								cmd.Dispose();
								Con.Close();
								Con.Open();
								cmd = new SqlCommand("update Invoice_Transaction set Net_Amount=0 where Cust_ID='"+rdr["CustID"].ToString()+"' and Invoice_No='"+rdr1["Bill_No"].ToString()+"'",Con);
								cmd.ExecuteNonQuery();
								cmd.Dispose();
								Con.Close();
							}
							else
							{
								Con.Open();
								cmd = new SqlCommand("update LedgDetails set Amount=abs("+Amt+") where Cust_ID='"+rdr["CustID"].ToString()+"' and Bill_No='"+rdr1["Bill_No"].ToString()+"'",Con);
								cmd.ExecuteNonQuery();
								cmd.Dispose();
								Con.Close();
								Con.Open();
								cmd = new SqlCommand("update Invoice_Transaction set Net_Amount=abs("+Amt+") where Cust_ID='"+rdr["CustID"].ToString()+"' and Invoice_No='"+rdr1["Bill_No"].ToString()+"'",Con);
								cmd.ExecuteNonQuery();
								cmd.Dispose();
								Con.Close();
								break;
							}
						}
						rdr1.Close();
					}
				}
				rdr.Close();
				**********************************************************************/
				MessageBox.Show("Receipt Cancellation Successfully");
				Clear();
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:btnDelete_Clicked  Payment receipt Deleted. User_ID: " +uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Payment_Receipt.aspx,Class:InventoryClass.cs,Method:btnDelete_Clicked  Payment receipt.     , Exception : "+ex.Message+"    User_ID: " +uid);
			}
		}

		/// <summary>
		/// This method is used to get bank info.
		/// </summary>
		public void GetBank()
		{
			InventoryClass obj = new InventoryClass();
			SqlDataReader rdr;
			string str="select Ledger_Name from Ledger_Master where sub_grp_id='117' or sub_grp_id='126' or sub_grp_id='127' order by Ledger_Name";
			rdr = obj.GetRecordSet(str);
			DropBankName.Items.Clear();
			DropBankName.Items.Add("Select");
			while(rdr.Read())
			{
				DropBankName.Items.Add(rdr.GetValue(0).ToString());
			}
			rdr.Close();
		}

		/// <summary>
		/// This method is used to update the LedgDetails table with the help of stored procedure  
		/// after save or update the receipt.
		/// </summary>
		public void UpdateLedgDetails(string Cust_ID)
		{
			//***** Update LedgDetails and Invoice_Transaction *************
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
			SqlCommand cmd;
			InventoryClass obj2 = new InventoryClass();
			InventoryClass obj1 = new InventoryClass();
			SqlDataReader rdr=null,rdr1=null;
			object ob=null;
			dbobj.ExecProc(DBOperations.OprType.Insert,"ProInsertLedgerDetails",ref ob,"@Cust_ID",Cust_ID);
			
			/*rdr = obj2.GetRecordSet("select CustID,sum(creditamount) CreditAmount from customerledgertable where custid='"+Cust_ID+"' group by custid");
			if(rdr.Read())
			{
				double Amt=double.Parse(rdr["CreditAmount"].ToString());
				rdr1 = obj1.GetRecordSet("select * from LedgDetails where Cust_ID='"+rdr["Custid"].ToString()+"' and amount>0 order by Bill_Date");
				while(rdr1.Read())
				{
					Amt=Amt-double.Parse(rdr1["Amount"].ToString());
					if(Amt>=0)
					{
						Con.Open();
						cmd = new SqlCommand("update LedgDetails set Amount=0 where Cust_ID='"+rdr["CustID"].ToString()+"' and Bill_No='"+rdr1["Bill_No"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
						Con.Open();
						cmd = new SqlCommand("update Invoice_Transaction set Net_Amount=0 where Cust_ID='"+rdr["CustID"].ToString()+"' and Invoice_No='"+rdr1["Bill_No"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
					}
					else
					{
						Con.Open();
						cmd = new SqlCommand("update LedgDetails set Amount=abs("+Amt+") where Cust_ID='"+rdr["CustID"].ToString()+"' and Bill_No='"+rdr1["Bill_No"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
						Con.Open();
						cmd = new SqlCommand("update Invoice_Transaction set Net_Amount=abs("+Amt+") where Cust_ID='"+rdr["CustID"].ToString()+"' and Invoice_No='"+rdr1["Bill_No"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
						break;
					}
				}
				rdr1.Close();
			}
			rdr.Close();*/
		}
	}
}