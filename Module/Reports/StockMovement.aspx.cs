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
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Security.Permissions;

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for StockView.
	/// </summary>
	public class StockView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Button cmdrpt;
		protected System.Web.UI.WebControls.DataGrid grdLeg;
		protected System.Web.UI.WebControls.DropDownList drpstore;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.Button prnButton;
		string strOrderBy="";
		protected System.Web.UI.WebControls.DropDownList Dropcategory;
		protected System.Web.UI.WebControls.Button btnExcel;
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
				CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Class:DBOperation_LETEST.cs,Method:page_load"+ ex.Message+"EXCEPTION"+uid);	
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!Page.IsPostBack )
			{
				try
				{
                    txtDateFrom.Attributes.Add("readonly", "readonly");
                    txtDateTo.Attributes.Add("readonly", "readonly");
                    #region Check Privileges
                    int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="13";
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
					txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					txtDateTo.Text=DateTime.Now.Day+ "/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year;
					System.Data.SqlClient.SqlDataReader rdr=null,rdr1=null;
					// Fetch store_in locations from products tables, if store_in not available then get the tank.
					dbobj.SelectQuery("select distinct store_in from products",ref rdr);
					while(rdr.Read())
					{
						if(Char.IsDigit(rdr["store_in"].ToString(),0))
						{
							dbobj.SelectQuery("select tank_id,tank_name,prod_name from tank where tank_id="+rdr["store_in"].ToString()+" order by tank_id",ref rdr1);
							if(rdr1.Read())
							{
							
								drpstore.Items.Add(rdr1["tank_name"].ToString()+":"+rdr1["prod_name"].ToString());					
							}
						}
						else
							drpstore.Items.Add(rdr["store_in"].ToString());					
					}
					drpstore.Items.Insert(0,"All");
					dbobj.Dispose();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Class:DBOperation_LETEST.cs,Method:page_load().  EXCEPTION: "+ ex.Message+" User_ID: "+uid);	
				}
			}
		}

		/// <summary>
		/// This Method is used to multiplies the package quantity with Quantity.
		/// </summary>
		double count=1,i=1,j=2,k=3,l=4;
		public double os=0,cs=0,sales=0,rect=0;
		protected double Multiply(string str)
		{
			string[] mystr=str.Split(new char[]{'X'},str.Length);
			// check the package type is loose or not.
			if(str.Trim().IndexOf("Loose") == -1)
			{
				double ans=1;
				foreach(string val in mystr)
				{
					if(val.Length>0 && !val.Trim().Equals(""))
						ans*=double.Parse(val,System.Globalization.NumberStyles.Float);
				}
				//***************
				if(count==i)
				{
					os+=ans;
					Cache["os"]=System.Convert.ToString(os);
					i+=4;
				}
				if(count==j)
				{
					rect+=ans;
					Cache["rect"]=System.Convert.ToString(rect);
					j+=4;
				}
				if(count==k)
				{
					sales+=ans;
					Cache["sales"]=System.Convert.ToString(sales);
					k+=4;
				}
				if(count==l)
				{
					cs+=ans;
					Cache["cs"]=System.Convert.ToString(cs);
					l+=4;
				}
				count++;
				//***************
				return ans;
			}
			else
			{
				if(!mystr[0].Trim().Equals(""))
				{
					//***************
					if(count==i)
					{
						os+=System.Convert.ToDouble( mystr[0].ToString());
						Cache["os"]=System.Convert.ToString(os);
						i+=4;
					}
					if(count==j)
					{
						rect+=System.Convert.ToDouble( mystr[0].ToString());
						Cache["rect"]=System.Convert.ToString(rect);
						j+=4;
					}
					if(count==k)
					{
						sales+=System.Convert.ToDouble( mystr[0].ToString());
						Cache["sales"]=System.Convert.ToString(sales);
						k+=4;
					}
					if(count==l)
					{
						cs+=System.Convert.ToDouble( mystr[0].ToString());
						Cache["cs"]=System.Convert.ToString(cs);
						l+=4;
					}
					count++;
					//***************
					return System.Convert.ToDouble( mystr[0].ToString()); 
				}
				else
					return 0;
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
			this.cmdrpt.Click += new System.EventHandler(this.cmdrpt_Click);
			this.prnButton.Click += new System.EventHandler(this.prnButton_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private DateTime getdate(string dat,bool to)
		{
			
			string[] dt=dat.Split(new char[]{'/'},dat.Length);
			if(to)
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
			else
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
		}

		/// <summary>
		/// This method is used to view the report and set the session variable for ascending or descending the record.
		/// </summary>
		private void cmdrpt_Click(object sender, System.EventArgs e)
		{
			try
			{
				//			grdLeg.Visible=true;
				//			int x=0;
				//			object op=null;	
				//	
				//			System.Data.SqlClient.SqlDataReader rdr=null;
				//			string sql="select distinct productid from stock_master";
				//				// Calls the sp_stockmovement for each product and create one stkmv temp. table.
				//			dbobj.SelectQuery(sql,ref rdr);
				//			while(rdr.Read())
				//				dbobj.ExecProc(OprType.Insert,"sp_stockmovement",ref op,"@id",Int32.Parse(rdr["productid"].ToString()),"@fromdate",getdate(txtDateFrom.Text,true).Date.ToShortDateString(),"@todate",getdate(txtDateTo.Text,true).Date.ToShortDateString());
				//			rdr.Close();
				strOrderBy = "Prod_Name ASC";
				Session["Column"] = "Prod_Name";
				Session["Order"] = "ASC";
				BindTheData();
				//			if(drpstore.SelectedIndex>0)
				//			{
				//				if(drpstore.SelectedItem.Text.IndexOf(":")>0)
				//				{
				//					string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
				//					string tid="";
				//					dbobj.SelectQuery("select tank_id  from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
				//					sql="select * from stkmv where Location='"+tid+"'";
				//				
				//				}
				//				else
				//				{
				//					sql="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"'";
				//				
				//				}
				//				dbobj.SelectQuery(sql,ref rdr);
				//			}
				//			else
				//				dbobj.SelectQuery("select * from stkmv",ref rdr);
				//			if(rdr.HasRows)
				//			{
				//				grdLeg.DataSource=rdr;
				//				grdLeg.DataBind();
				//			}
				//			else
				//			{
				//				RMG.MessageBox.Show("Data not available");
				//				grdLeg.Visible=false;
				//			}
			
				// truncate table after use.
				//dbobj.Insert_or_Update("truncate table stkmv", ref x);
				CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Class:DBOperation_LETEST.cs,Method:cmdrpt_Click  Stock Movement Report  Viewed  useried "+uid);	
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Class:DBOperation_LETEST.cs,Method:cmdrpt_Click,  Stock Movement Report  Viewed  EXCEPTION "+ ex.Message+"  userid  "+uid);		
			}	
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="";
			grdLeg.Visible=true;
			int x=0;
			object op=null;	
	
			System.Data.SqlClient.SqlDataReader rdr=null;
			string sql="select distinct productid from stock_master";
			// Calls the sp_stockmovement for each product and create one stkmv temp. table.
			dbobj.SelectQuery(sql,ref rdr);
			while(rdr.Read())
				dbobj.ExecProc(OprType.Insert,"sp_stockmovement",ref op,"@id",Int32.Parse(rdr["productid"].ToString()),"@fromdate",GenUtil.str2MMDDYYYY(txtDateFrom.Text),"@todate", GenUtil.str2MMDDYYYY(txtDateTo.Text));
			rdr.Close();
			if(drpstore.SelectedIndex>0)
			{
				if(drpstore.SelectedItem.Text.IndexOf(":")>0)
				{
					string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
					string tid="";
					dbobj.SelectQuery("select tank_id  from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
					if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
						sqlstr="select * from stkmv where Location='"+tid+"' and category='Fuel'";
					else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
						sqlstr="select * from stkmv where Location='"+tid+"' and category!='Fuel'";
					else
						sqlstr="select * from stkmv where Location='"+tid+"'";
				}
				else
				{
					if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
						sqlstr="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"' and category='Fuel'";
					else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
						sqlstr="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"' and category!='Fuel'";
					else
						sqlstr="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"'";
				
				}
				//dbobj.SelectQuery(sql,ref rdr);
			}
			else
			{
				if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
					sqlstr="select * from stkmv where category='Fuel'";
				else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
					sqlstr="select * from stkmv where category!='Fuel'";
				else
					sqlstr="select * from stkmv";
			}
			//dbobj.SelectQuery("select * from stkmv",ref rdr);
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "stkmv");
			DataTable dtCustomers = ds.Tables["stkmv"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				grdLeg.DataSource = dv;
				grdLeg.DataBind();
				grdLeg.Visible=true;
			}
			else
			{
				MessageBox.Show("Data not available");
				grdLeg.Visible=false;
			}
			// truncate table after use.
			dbobj.Insert_or_Update("truncate table stkmv", ref x);
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
				CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to check if the products type is fuel or package is Loose Oil then return space.
		/// </summary>
		double count1=1,i1=1,j1=2,k1=3,l1=4;
		public double osp=0,csp=0,salesp=0,rectp=0;
		protected string Check(string cs, string type,string pack)
		{
			if(type.ToUpper().Equals("FUEL") || pack.IndexOf("Loose")!= -1)
			{
				Cache["osp"]="";
				Cache["rectp"]="";
				Cache["salesp"]="";
				Cache["csp"]="";
				return "&nbsp;";
			}
			else
				//***************
				if(count1==i1)
			{
				osp+=System.Convert.ToDouble(cs);
				Cache["osp"]=System.Convert.ToString(osp);
				i1+=4;
			}
			if(count1==j1)
			{
				rectp+=System.Convert.ToDouble(cs);
				Cache["rectp"]=System.Convert.ToString(rectp);
				j1+=4;
			}
			if(count1==k1)
			{
				salesp+=System.Convert.ToDouble(cs);
				Cache["salesp"]=System.Convert.ToString(salesp);
				k1+=4;
			}
			if(count1==l1)
			{
				csp+=System.Convert.ToDouble(cs);
				Cache["csp"]=System.Convert.ToString(csp);
				l1+=4;
			}
			count1++;
			//***************
			return cs;
		}

		/// <summary>
		/// This methed is used to if the tank the returns the tank abbrevation name, for that tank.
		/// </summary>
		protected string IsTank(string str)
		{
			string op="";
			if(Char.IsDigit(str,0))
				dbobj.SelectQuery("select top 1 prod_abbname from tank where tank_id='"+str+"'","prod_abbname",ref op);
			if(op.Length>0)
				return op;
			else
				return str;
		}

		/// <summary>
		/// This method is used to Sends the text file to print server to print.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\StockMovementReport.txt<EOF>");

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
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+ane.Message+" userid "+ uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+se.Message+" userid "+ uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+es.Message+" userid "+ uid);
				}
				//CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+es.Message+" userid "+ uid);
			} 
			catch (Exception es) 
			{
				CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:print EXCEPTION  "+es.Message+" userid "+ uid);
			}
		}

		/// <summary>
		/// This method prepares the report and writes into a Text File to print. 
		/// info string is used to display print the values in specified formats.
		/// </summary>
		private void prnButton_Click(object sender, System.EventArgs e)
		{
			/*
																				 =====================
																				 Stock Movement Report
																				 =====================
			From : 
			To   :
			Location :

			+------------------------------+---------------+---------------+---------------+---------------+---------------+
			|                              |               | Opening Stock |   Receipt     |    Sales      | Closing Stock |
			|    Product Name              |   Location    |------+--------|------+--------|------+--------|------+--------|
			|                              |               | Pkg. | Lt./Kg | Pkg. | Lt./Kg | Pkg. | Lt./Kg | Pkg. | Lt./Kg |
			+------------------------------+---------------+---------------+---------------+---------------+---------------+
			 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxx123456 12345678 xxxx  1234567890   1234567890	  1234567890   1234567890   1234567890   1234567890   1234567890   1234567890  
  
			*/
			try
			{
				string info = " {0,-30:S} {1,-15:S} {2,6:F} {3,8:F} {4,6:F} {5,8:F} {6,6:F} {7,8:F} {8,6:F} {9,8:F}";
				string info1 =" {0,-30:S} {1,-15:S} {2,6:F} {3,8:F} {4,6:F} {5,8:F} {6,6:F} {7,8:F} {8,6:F} {9,8:F}";
				string sql         = "";
		

				string strPackOp = "";
				string strPackRc = "";
				string strPackSl = "";
				string strPackCl = "";
				string[] strSplit;
				string pack = "";

				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\StockMovementReport.txt";
				StreamWriter sw = new StreamWriter(path);
				System.Data.SqlClient.SqlDataReader rdr=null;
				sql="select distinct productid from stock_master";
				dbobj.SelectQuery(sql,ref rdr);
				object op=null;
				while(rdr.Read())
					dbobj.ExecProc(OprType.Insert,"sp_stockmovement",ref op,"@id",Int32.Parse(rdr["productid"].ToString()),"@fromdate",GenUtil.str2MMDDYYYY(txtDateFrom.Text),"@todate",GenUtil.str2MMDDYYYY(txtDateTo.Text));
				rdr.Close();
				if(drpstore.SelectedIndex>0)
				{
					if(drpstore.SelectedItem.Text.IndexOf(":")>0)
					{
						string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
						string tid="";
						dbobj.SelectQuery("select tank_id  from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
						if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
							sql="select * from stkmv where Location='"+tid+"' and category='Fuel'";
						else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
							sql="select * from stkmv where Location='"+tid+"' and category!='Fuel'";
						else
							sql="select * from stkmv where Location='"+tid+"'";
					}
					else
					{
						if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
							sql="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"' and category='Fuel'";
						else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
							sql="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"' and category!='Fuel'";
						else
							sql="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"'";
					}
					sql=sql+" order by "+Cache["strOrderBy"]+"";
					dbobj.SelectQuery(sql,ref rdr);
				}
				else
				{
					if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
						sql="select * from stkmv where category='Fuel' order by "+Cache["strOrderBy"];
					else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
						sql="select * from stkmv where category!='Fuel' order by "+Cache["strOrderBy"];
					else
						sql="select * from stkmv order by "+Cache["strOrderBy"];
					dbobj.SelectQuery(sql,ref rdr);
				}
					

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
				string des="----------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("=====================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Stock Movement Report",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("=====================",des.Length));
				sw.WriteLine("From : "+txtDateFrom.Text);
				sw.WriteLine("To   : "+txtDateTo.Text);
				sw.WriteLine("Location : "+drpstore.SelectedItem.Value);
				sw.WriteLine("Category : "+Dropcategory.SelectedItem.Text);
				sw.WriteLine("");
				
				sw.WriteLine("+------------------------------+---------------+---------------+---------------+---------------+---------------+");
				sw.WriteLine("|                              |               | Opening Stock |   Receipt     |    Sales      | Closing Stock |");
				sw.WriteLine("|    Product Name              |   Location    |------+--------|------+--------|------+--------|------+--------|");
				sw.WriteLine("|                              |               | Pkg. | Lt./Kg | Pkg. | Lt./Kg | Pkg. | Lt./Kg | Pkg. | Lt./Kg |"); 
				sw.WriteLine("+------------------------------+---------------+------+--------+------+--------+------+--------+------+--------+");
			 
				if(rdr.HasRows)

				{
					while(rdr.Read())
					{
						strPackOp = "";
						strPackRc = "";
						strPackSl = "";
						strPackCl = "";
						pack = "";
						string pabbName="";
						// check if the product is type of fuel then do not display the package , and displays the tank abbrevation name.
						if(rdr["category"].ToString().ToUpper().Equals("FUEL") )
						{
							dbobj.SelectQuery("select prod_AbbName from tank where tank_id="+rdr["location"].ToString().Trim(),"prod_AbbName",ref pabbName);
							sw.WriteLine(info1,GenUtil.TrimLength(rdr["prod_name"].ToString().Trim(),30),pabbName,"",rdr["op"].ToString().Trim(),"",rdr["rcpt"].ToString().Trim(),"",rdr["sales"].ToString().Trim(),"",rdr["cs"].ToString().Trim());
                      	
						}
						
							// if package is Loose Oil then do not package .
						else if(rdr["pack_type"].ToString().IndexOf("Loose") != -1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(rdr["prod_name"].ToString().Trim(),30),GenUtil.TrimLength(rdr["location"].ToString().Trim(),15),"",rdr["op"].ToString().Trim(),"",rdr["rcpt"].ToString().Trim(),"",rdr["sales"].ToString().Trim(),"",rdr["cs"].ToString().Trim());
						}
						else
						{                      	
							pack = rdr["pack_type"].ToString().Trim();
							if (pack.IndexOf("X")<0 || pack.Equals("") )
							{
								strPackOp = rdr["op"].ToString().Trim();
								strPackRc = rdr["rcpt"].ToString().Trim();
								strPackSl= rdr["Sales"].ToString().Trim();
								strPackCl = rdr["cs"].ToString().Trim();

							}
							else
							{
								strSplit = pack.Split(new char []{'X'},pack.Length);
								double d1 = 1;
								double d2 = 1;
								if(!strSplit[0].Trim().Equals (""))
									d1 = System.Convert.ToDouble(strSplit[0]);
								if(!strSplit[1].Trim().Equals (""))
									d2 = System.Convert.ToDouble(strSplit[1]);


								strPackOp = rdr["op"].ToString().Trim();
								if(!strPackOp.Equals("")) 
								{
								
									strPackOp = ""+System.Convert.ToDouble(strPackOp)*d1*d2 ;
								}
								strPackRc = rdr["rcpt"].ToString().Trim();
								if(!strPackRc.Equals(""))
								{
									strPackRc = ""+System.Convert.ToDouble(strPackRc)*d1*d2 ;
								}
								strPackSl = rdr["Sales"].ToString().Trim();
								if(!strPackSl.Equals(""))
								{
									strPackSl = ""+System.Convert.ToDouble(strPackSl)*d1*d2 ;
								}
								strPackCl = rdr["cs"].ToString().Trim();
								if(!strPackCl.Equals(""))
								{
									strPackCl = ""+System.Convert.ToDouble(strPackCl)*d1*d2 ;            
								}
							}
                  
							sw.WriteLine(info,GenUtil.TrimLength(rdr["prod_name"].ToString().Trim(),30),GenUtil.TrimLength(rdr["location"].ToString().Trim(),15),rdr["op"].ToString().Trim(),strPackOp,rdr["rcpt"].ToString().Trim(),strPackRc,rdr["sales"].ToString().Trim(),strPackSl,rdr["cs"].ToString().Trim(),strPackCl);
						}
					
					}
				}
				
				sw.WriteLine("+------------------------------+---------------+------+--------+------+--------+------+--------+------+--------+");
				sw.WriteLine(info,"    Total","",Cache["osp"].ToString(),Cache["os"].ToString(),Cache["rectp"].ToString(),Cache["rect"].ToString(),Cache["salesp"].ToString(),Cache["sales"].ToString(),Cache["csp"].ToString(),Cache["cs"].ToString());
				sw.WriteLine("+------------------------------+---------------+------+--------+------+--------+------+--------+------+--------+");

				// deselect Condensed
				//	sw.Write((char)18);
				//	sw.Write((char)12);
				sw.Close();
				dbobj.Dispose();
				rdr.Close();
				print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:prnButton_Click(). EXCEPTION  "+ex.Message+" userid "+ uid);
			}
		}

		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string sql="";
			string strPackOp = "";
			string strPackRc = "";
			string strPackSl = "";
			string strPackCl = "";
			string[] strSplit;
			string pack = "";
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\StockMovementReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader rdr=null;
			sql="select distinct productid from stock_master";
			dbobj.SelectQuery(sql,ref rdr);
			object op=null;
			while(rdr.Read())
				dbobj.ExecProc(OprType.Insert,"sp_stockmovement",ref op,"@id",Int32.Parse(rdr["productid"].ToString()),"@fromdate", GenUtil.str2MMDDYYYY(txtDateFrom.Text),"@todate", GenUtil.str2MMDDYYYY(txtDateTo.Text));
			rdr.Close();
			if(drpstore.SelectedIndex>0)
			{
				if(drpstore.SelectedItem.Text.IndexOf(":")>0)
				{
					string[] stor=drpstore.SelectedItem.Text.Split(new char []{':'},drpstore.SelectedItem.Text.Length);
					string tid="";
					dbobj.SelectQuery("select tank_id  from tank where tank_name='"+stor[0]+"' and prod_name like '"+stor[1]+"'","tank_id",ref tid);
					if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
						sql="select * from stkmv where Location='"+tid+"' and category='Fuel'";
					else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
						sql="select * from stkmv where Location='"+tid+"' and category!='Fuel'";
					else
						sql="select * from stkmv where Location='"+tid+"'";
				}
				else
				{
					if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
						sql="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"' and category='Fuel'";
					else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
						sql="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"' and category!='Fuel'";
					else
						sql="select * from stkmv where Location='"+drpstore.SelectedItem.Value +"'";
				}
				sql=sql+" order by "+Cache["strOrderBy"]+"";
				dbobj.SelectQuery(sql,ref rdr);
			}
			else
			{
				if(Dropcategory.SelectedItem.Text.Equals("Fuel"))
					sql="select * from stkmv where category='Fuel' order by "+Cache["strOrderBy"];
				else if(Dropcategory.SelectedItem.Text.Equals("Non Fuel"))
					sql="select * from stkmv where category!='Fuel' order by "+Cache["strOrderBy"];
				else
					sql="select * from stkmv order by "+Cache["strOrderBy"];
				dbobj.SelectQuery(sql,ref rdr);
			}
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+txtDateTo.Text);
			sw.WriteLine("Stock Location\t"+drpstore.SelectedItem.Text);
			sw.WriteLine("Stock Category\t"+Dropcategory.SelectedItem.Text);
			sw.WriteLine("Product Name\tLocation\tOpening Stock(Pkg)\tOpening Stock(Ltr/kg)\tReceipt(Pkg)\tReceipt(Ltr/kg)\tSales(Pkg)\tSales(Ltr/kg)\tClosing Stock(Pkg)\tClosing Stock(Ltr/kg)");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					strPackOp = "";
					strPackRc = "";
					strPackSl = "";
					strPackCl = "";
					pack = "";
					string pabbName="";
					// check if the product is type of fuel then do not display the package , and displays the tank abbrevation name.
					if(rdr["category"].ToString().ToUpper().Equals("FUEL") )
					{
						dbobj.SelectQuery("select prod_AbbName from tank where tank_id="+rdr["location"].ToString().Trim(),"prod_AbbName",ref pabbName);
						sw.WriteLine(rdr["prod_name"].ToString().Trim()+"\t"+pabbName+"\t\t"+rdr["op"].ToString().Trim()+"\t\t"+rdr["rcpt"].ToString().Trim()+"\t\t"+rdr["sales"].ToString().Trim()+"\t\t"+rdr["cs"].ToString().Trim());
					}
						// if package is Loose Oil then do not package .
					else if(rdr["pack_type"].ToString().IndexOf("Loose") != -1)
					{
						sw.WriteLine(rdr["prod_name"].ToString().Trim()+"\t"+rdr["location"].ToString().Trim()+"\t\t"+rdr["op"].ToString().Trim()+"\t\t"+rdr["rcpt"].ToString().Trim()+"\t\t"+rdr["sales"].ToString().Trim()+"\t\t"+rdr["cs"].ToString().Trim());
					}
					else
					{                      	
						pack = rdr["pack_type"].ToString().Trim();
						if (pack.IndexOf("X")<0 || pack.Equals("") )
						{
							strPackOp = rdr["op"].ToString().Trim();
							strPackRc = rdr["rcpt"].ToString().Trim();
							strPackSl= rdr["Sales"].ToString().Trim();
							strPackCl = rdr["cs"].ToString().Trim();
						}
						else
						{
							strSplit = pack.Split(new char []{'X'},pack.Length);
							double d1 = 1;
							double d2 = 1;
							if(!strSplit[0].Trim().Equals (""))
								d1 = System.Convert.ToDouble(strSplit[0]);
							if(!strSplit[1].Trim().Equals (""))
								d2 = System.Convert.ToDouble(strSplit[1]);
							strPackOp = rdr["op"].ToString().Trim();
							if(!strPackOp.Equals("")) 
							{
								strPackOp = ""+System.Convert.ToDouble(strPackOp)*d1*d2 ;
							}
							strPackRc = rdr["rcpt"].ToString().Trim();
							if(!strPackRc.Equals(""))
							{
								strPackRc = ""+System.Convert.ToDouble(strPackRc)*d1*d2 ;
							}
							strPackSl = rdr["Sales"].ToString().Trim();
							if(!strPackSl.Equals(""))
							{
								strPackSl = ""+System.Convert.ToDouble(strPackSl)*d1*d2 ;
							}
							strPackCl = rdr["cs"].ToString().Trim();
							if(!strPackCl.Equals(""))
							{
								strPackCl = ""+System.Convert.ToDouble(strPackCl)*d1*d2 ;            
							}
						}
						sw.WriteLine(rdr["prod_name"].ToString().Trim()+"\t"+rdr["location"].ToString().Trim()+"\t"+rdr["op"].ToString().Trim()+"\t"+strPackOp+"\t"+rdr["rcpt"].ToString().Trim()+"\t"+strPackRc+"\t"+rdr["sales"].ToString().Trim()+"\t"+strPackSl+"\t"+rdr["cs"].ToString().Trim()+"\t"+strPackCl);
					}
				}
			}
			sw.WriteLine("Total\t\t"+Cache["osp"]+"\t"+Cache["os"]+"\t"+Cache["rectp"]+"\t"+Cache["rect"]+"\t"+Cache["salesp"]+"\t"+Cache["sales"]+"\t"+Cache["csp"]+"\t"+Cache["cs"]);
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
				if(grdLeg.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method: btnExcel_Click, StockMovement Report Convert Into Excel Format ,  userid  "+uid);
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
				CreateLogFiles.ErrorLog("Form:StockMovement.aspx,Method:btnExcel_Click   StockMovement Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}
	}
}