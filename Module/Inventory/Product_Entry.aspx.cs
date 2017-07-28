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
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPetro.Sysitem.Classes ;
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Inventory
{
	/// <summary>
	/// Summary description for Product_Entry.
	/// </summary>
	public class Product_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropStorein;
		protected System.Web.UI.WebControls.DropDownList DropUnit;
		protected System.Web.UI.WebControls.DropDownList DropPackage;
		protected System.Web.UI.WebControls.TextBox txtCategory;
		protected System.Web.UI.WebControls.DropDownList DropCategory;
		protected System.Web.UI.WebControls.TextBox txtProdName;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.TextBox txtPack1;
		protected System.Web.UI.WebControls.TextBox txtPack2;
		protected System.Web.UI.WebControls.DropDownList DropPackUnit;
		protected System.Web.UI.WebControls.TextBox txtOp_Stock;
		protected System.Web.UI.WebControls.TextBox txtTotalQty;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Label lblProdID;
		protected System.Web.UI.WebControls.DropDownList dropProdID;
		protected System.Web.UI.WebControls.TextBox txtBox;
		protected System.Web.UI.WebControls.TextBox txtunit;
		protected System.Web.UI.WebControls.Label lblProd;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label lb;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempDelinfo;
		protected System.Web.UI.WebControls.TextBox txtMinLabel;
		protected System.Web.UI.WebControls.TextBox txtReOrderLabel;
		protected System.Web.UI.WebControls.TextBox txtMaxLabel;
		string pass;

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
				pass=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Product_Entry  Method Page_Load "+ " EXCEPTION  "+ex.Message+" userid is   "+pass);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(tempDelinfo.Value=="Yes")
			{
				try
				{
					InventoryClass obj=new InventoryClass();
					SqlDataReader SqlDtr;
					int Count=0;
					string PName=dropProdID.SelectedItem.Text;
					string[] arrName = PName.Split(new char[] {':'},PName.Length);
					string str="select count(*) from Stock_Master where Productid=(select prod_id from products where Prod_Name='"+arrName[0].ToString()+"' and Pack_Type='"+arrName[1].ToString()+"') and (sales<>0 or receipt<>0)";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						Count=int.Parse(SqlDtr.GetValue(0).ToString());
					}
					if(Count == 0)
					{
						SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
						Con.Open();
						SqlCommand cmd = new SqlCommand("delete from Products where Prod_Name='"+arrName[0].ToString()+"' and Pack_Type='"+arrName[1].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						Con.Close();
						cmd.Dispose();
						MessageBox.Show("Product Deleted");
						Clear();
						CreateLogFiles.ErrorLog("Form:Product_Entry.aspx,Method:btnDelete_Click - Record Deleted, user : "+pass);
						GetProdName();
						dropProdID.Visible=false;
						dropProdID.SelectedIndex=0;
						btnEdit.Visible=true;
						lblProdID.Visible=true;
						GetNextProductID();
					}
					else
					{
						MessageBox.Show("Can Not Delete These Product because Some Transaction are available");
						Clear();
						return;
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Product_Entry  Method Page_Load(btnDelete_Click) "+ " EXCEPTION  "+ex.Message+" userid is   "+pass);
				}
			}
			if (!IsPostBack)
			{
				try
				{
                    txtTotalQty.Attributes.Add("readonly", "readonly");
                    checkPrevileges();
					InventoryClass obj=new InventoryClass (); 
					lb.Visible=false;
					txtunit.Enabled = false;
					txtBox.Enabled = false;
					GetNextProductID();
					FCategory();
					PType();
					fUnit();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Product_Entry  Method Page_Load "+ " EXCEPTION  "+ex.Message+" userid is   "+pass);
				}
			}
		}

		/// <summary>
		/// This method is used to fatch the all product name with pack type in edit time.
		/// </summary>
		public void GetProdName()
		{
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr;
			string sql;
			#region Get All Products ID and fill in the ComboBox
			//*bhal**sql="select Prod_name+':'+Pack_Type from Products where Category!='Fuel' order by Prod_name ";
			sql="select Prod_name+':'+Pack_Type from Products where Category!='Fuel' order by Prod_name";
			SqlDtr=obj.GetRecordSet(sql);
			dropProdID.Items.Clear();
			dropProdID.Items.Add("Select");
			while(SqlDtr.Read())
			{
				dropProdID.Items.Add(SqlDtr.GetValue(0).ToString()); 
			}
			SqlDtr.Close();
			#endregion
		}
		/// <summary>
		/// This method is used to check User Previleges.
		/// </summary>
		public void checkPrevileges()
		{
			#region Check Privileges
			int i;
			string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
			string Module="4";
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
			if(Add_Flag=="0" && Edit_Flag == "0" && View_flag == "0")
			{
				Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
			}
			
			if(Add_Flag == "0")
				btnSave.Enabled = false;
			if(Edit_Flag == "0")
			{
				btnEdit.Enabled = false; 
			}

			#endregion
		}

		/// <summary>
		/// This method is used to fatch all product category in combo from the database.
		/// </summary>
		public void FCategory()
		{
			if(!Page.IsPostBack)
			{
				InventoryClass obj=new InventoryClass (); 
				SqlDataReader SqlDtr;
				string sql;
				#region Fetch Categories
				sql="select distinct Category from Products where Category !='Fuel' order by  Category asc";
				SqlDtr = obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					DropCategory.Items.Add(SqlDtr.GetValue(0).ToString ());
				}
				SqlDtr.Close ();
				#endregion
			}
		}

		/// <summary>
		/// This method is used to fatch all product type in combo from the database.
		/// </summary>
		public void PType()
		{
			if(!Page.IsPostBack)
			{
				InventoryClass obj=new InventoryClass (); 
				SqlDataReader SqlDtr;
				string sql;
				#region Fetch Package Types
				sql="select distinct Pack_Type from Products where Category!='Fuel' order by Pack_Type asc";
				SqlDtr = obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					if(!SqlDtr.GetValue(0).ToString().Trim().Equals("Loose Oil")) 
						DropPackage.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
				#endregion
			}
		
		}
		
		/// <summary>
		/// This method is used to fatch all product unit in combo from the database.
		/// </summary>
		public void fUnit()
		{
			if(!Page.IsPostBack)
			{
				InventoryClass obj=new InventoryClass (); 
				SqlDataReader SqlDtr;
				string sql;
				#region Fetch Units
				sql="select distinct Unit from Products";
				SqlDtr = obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					if(DropUnit.Items.IndexOf(DropUnit.Items.FindByValue(SqlDtr.GetValue(0).ToString())) == -1)    
						DropUnit.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close ();
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
			this.dropProdID.SelectedIndexChanged += new System.EventHandler(this.dropProdID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\ProductEntryReport.txt<EOF>");

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
				
					CreateLogFiles.ErrorLog("Form:Product_Entry  Method :Print "+ " EXCEPTION  "+ane.Message+" userid is   "+pass);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
				
					CreateLogFiles.ErrorLog("Form:Product_Entry  Method :Print "+ " EXCEPTION  "+se.Message+" userid is   "+pass);
				
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
				
					CreateLogFiles.ErrorLog("Form:Product_Entry  Method :Print "+ " EXCEPTION  "+es.Message+" userid is   "+pass);
				}

			} 
			catch (Exception es) 
			{
				Console.WriteLine( es.ToString());
				CreateLogFiles.ErrorLog("Form:Product_Entry  Method btnSave_Click "+" userid is   "+pass);
			}
		}

		/// <summary>
		/// Its checks the before save that the account period is inserted in organisaton table or not.
		/// </summary>
		public bool checkAcc_Period()
		{
			SqlDataReader SqlDtr = null;
			int c = 0;
			dbobj.SelectQuery("Select count(Acc_Date_From) from Organisation",ref SqlDtr);
			if(SqlDtr.Read())
			{
				c = System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());  
			}
			SqlDtr.Close();

			if(c > 0)
				return true;
			else
				return false;
		}
		
		/// <summary>
		/// Insert the all values in the database with the help of stored procedures.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!checkAcc_Period())
				{
					MessageBox.Show("Please enter the Accounts Period from Organization Details");
					return;
				}
				InventoryClass obj=new InventoryClass ();
				lb.Visible=false;
				string sql;
				if(dropProdID.Visible==true && dropProdID.SelectedIndex==0)
				{
					MessageBox.Show("Please Select the Product ID");
					return;
				}
				DropUnit.Enabled = true;
				if(DropPackage.SelectedIndex ==1) 
					DropUnit.SelectedIndex = 4; 

				if(txtProdName.Text=="" || (DropCategory.SelectedIndex==0 && txtCategory.Text=="") || (DropPackage.SelectedIndex==0 && txtPack1.Text=="" && txtPack2.Text=="" ) || (DropUnit.SelectedIndex==0 && txtunit.Text=="")|| DropStorein.SelectedIndex==0|| DropPackUnit.SelectedIndex==0)
				{
					MessageBox.Show("Fields Marked as * are Mandatory");
					return;
				}
				SqlDataReader SqlDr;
              
				string sql1; 
				string pname=StringUtil.FirstCharUpper(txtProdName.Text.ToString().Trim()); 
				//	string store = DropStorein.SelectedItem.Value;
				// Check the product name with same package is available or not?
				if(DropPackage.SelectedIndex != 0  )
					sql1="select Prod_ID from Products where Prod_Name='"+pname+"' and Pack_Type='"+DropPackage.SelectedItem.Value.Trim()+"'";// and store_in = '"+store+"'";
				else
					sql1="select Prod_ID from Products where Prod_Name='"+pname+"' and Pack_Type='"+txtPack1.Text.ToString()+"X"+txtPack2.Text.ToString()+"'";// and store_in = '"+store+"'";
				SqlDr=obj.GetRecordSet(sql1);
				if(SqlDr.HasRows)
				{
					while(SqlDr.Read())
					{
						string prodid ="";
						if(lblProdID.Visible == true)
							prodid = lblProdID.Text.ToString();
						else
						{
							string[] arr1=dropProdID.SelectedItem.Text.Split(new char[]{':'},dropProdID.SelectedItem.Text.Length);  
							sql="select Prod_ID from Products where Prod_Name='"+arr1[0]+"' and Pack_Type='"+arr1[1]+"'";
							string ID1="";
							dbobj.SelectQuery(sql,"Prod_ID",ref ID1);
							prodid =ID1;
						}
						
						if(!prodid.Equals(SqlDr["Prod_ID"].ToString()))
						{
							if(DropPackage.SelectedIndex != 0  )
								MessageBox.Show("Product Name "+pname+"  with Packege "+DropPackage.SelectedItem.Value.Trim()+" Already Exist");
							else
								MessageBox.Show("Product Name "+pname+"  with Packege "+txtPack1.Text.ToString()+"X"+txtPack2.Text.ToString()+" Already Exist");
							return;
						}
					}
				}
				SqlDr.Close();
				
				obj.Product_Name  =StringUtil.OnlyFirstCharUpper(txtProdName.Text.ToString());  
				if(DropCategory.SelectedIndex!=0)
				{
					obj.Category=DropCategory.SelectedItem.Value;
				}
				else
				{
					obj.Category=StringUtil.FirstCharUpper( txtCategory.Text.ToString());
				}
				if(DropPackage.SelectedIndex !=0)
					obj.Package_Type=DropPackage.SelectedItem.Value;			
				else
					obj.Package_Type=txtPack1.Text.ToString()+"X"+txtPack2.Text.ToString();			
				obj.Package_Unit =DropPackUnit.SelectedItem.Value.ToString();   

				obj.Total_Qty = txtTotalQty.Text.ToString();
				if(DropPackage.SelectedIndex == 1)
					obj.Opening_Stock = txtBox.Text.ToString(); 
				else  
					obj.Opening_Stock =txtOp_Stock.Text.ToString();
				if(!DropUnit.SelectedItem.Text.Equals("Other"))
				{
					obj.Unit=DropUnit.SelectedItem.Value;
				}
				else
				{
					obj.Unit=StringUtil.FirstCharUpper(txtunit.Text.ToString());
				}
				obj.Store_In=DropStorein.SelectedItem.Value;
				obj.MinLabel=txtMinLabel.Text;
				obj.MaxLabel=txtMaxLabel.Text;
				obj.ReOrderLabel=txtReOrderLabel.Text;
				// Check if the label is visible then save the products, & if Drop down of products id is visible then Update the product details.		
				if(lblProdID.Visible==true)
				{
					obj.Prod_ID = lblProdID.Text.ToString();	
					obj.InsertProducts ();	
					FCategory();
					PType();
					fUnit();
					// the code below adds the category, package and unit into the combo boxes if not present.
					if (txtCategory.Text!="")
					{
						if(DropCategory.Items.IndexOf(DropCategory.Items.FindByValue(StringUtil.FirstCharUpper(txtCategory.Text))) == -1)    
							DropCategory.Items.Add(StringUtil.FirstCharUpper(txtCategory.Text.ToString().Trim() ));
					}
					if((txtPack1.Text!="") && (txtPack2.Text!=""))
					{
						
						if(DropPackage.SelectedIndex != 1)                           
						{
							string temp = txtPack1.Text.Trim() + "X" + txtPack2.Text.Trim() ;
							if(DropPackage.Items.IndexOf(DropPackage.Items.FindByValue(temp.Trim() )) == -1)     
								DropPackage.Items.Add(txtPack1.Text + "X" + txtPack2.Text); 	
						}
					}
					if(txtunit.Text!="")
					{
						if(DropUnit.Items.IndexOf(DropUnit.Items.FindByValue(StringUtil.FirstCharUpper(txtunit.Text))) == -1)    
							DropUnit.Items.Add(StringUtil.FirstCharUpper(txtunit.Text));                     	
					}
					MessageBox.Show("Product Saved");
					CreateLogFiles.ErrorLog("Form:Product_Entry  Method btnSave_Click.:   Product "+txtProdName.Text.ToString()+" Saved.     userid is   "+pass);
				}
				else
				{
					string[] arr=dropProdID.SelectedItem.Text.Split(new char[]{':'},dropProdID.SelectedItem.Text.Length);  
					sql="select Prod_ID from Products where Prod_Name='"+arr[0]+"' and Pack_Type='"+arr[1]+"'";
					string ID="";
					dbobj.SelectQuery(sql,"Prod_ID",ref ID);
					obj.Prod_ID =ID;
					obj.UpdateProducts();	
					if (txtCategory.Text!="")
					{
						if(DropCategory.Items.IndexOf(DropCategory.Items.FindByValue(StringUtil.FirstCharUpper(txtCategory.Text))) == -1)    
							DropCategory.Items.Add(StringUtil.FirstCharUpper(txtCategory.Text.ToString().Trim() ));
					}
					if((txtPack1.Text!="") && (txtPack2.Text!=""))
					{
						if(DropPackage.SelectedIndex != 1)                           
						{
							string temp = txtPack1.Text.Trim() + "X" + txtPack2.Text.Trim() ;
							if(DropPackage.Items.IndexOf(DropPackage.Items.FindByValue(temp.Trim() )) == -1)     
								DropPackage.Items.Add(txtPack1.Text + "X" + txtPack2.Text); 	
						}
					}
					if(txtunit.Text!="")
					{
						if(DropUnit.Items.IndexOf(DropUnit.Items.FindByValue(StringUtil.FirstCharUpper(txtunit.Text))) == -1)    
							DropUnit.Items.Add(StringUtil.FirstCharUpper(txtunit.Text));                     	
					}
					MessageBox.Show("Product Updated");
					CreateLogFiles.ErrorLog("Form:Product_Entry  Method btnSave_Click.:   Product "+dropProdID.SelectedItem.Text.Trim() +" updated.     userid is   "+pass);
				}
				Clear();
				GetNextProductID();
				lblProdID.Visible=true;
				btnEdit.Visible=true;
				dropProdID.Visible=false;
				checkPrevileges();
		  
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Product_Entry  Method btnSave_Click "+"  EXCEPTION  "+  ex.Message+" userid is   "+pass);
			}
		}

		/// <summary>
		/// This method is not used
		/// </summary>
		private string GetString(string str,string spc)
		{
			if(str.Length>spc.Length)
				return str;
			else
				return str+spc.Substring(0,spc.Length-str.Length)+"  ";			
		}
				
		/// <summary>
		/// This method is not used
		/// </summary>
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6,ref int len7,ref int len8,ref int len9)
		{
		
			while(rdr.Read())
			{
				if(rdr["Prod_ID"].ToString().Trim().Length>len1)
					len1=rdr["Prod_ID"].ToString().Trim().Length;					
				if(rdr["Prod_Name"].ToString().Trim().Length>len2)
					len2=rdr["Prod_Name"].ToString().Trim().Length;					
				if(rdr["Category"].ToString().Trim().Length>len3)
					len3=rdr["Category"].ToString().Trim().Length;
				if(rdr["Pack_Type"].ToString().Trim().Length>len4)
					len4=rdr["Pack_Type"].ToString().Trim().Length;	
				if(rdr["Pack_Unit"].ToString().Trim().Length>len5)
					len5=rdr["Pack_Unit"].ToString().Trim().Length;					
				if(rdr["Total_Qty"].ToString().Trim().Length>len6)
					len6=rdr["Total_Qty"].ToString().Trim().Length;	
				if(rdr["Opening_Stock"].ToString().Trim().Length>len7)
					len7=rdr["Opening_Stock"].ToString().Trim().Length;	
				if(rdr["Unit"].ToString().Trim().Length>len8)
					len8=rdr["Unit"].ToString().Trim().Length;	
				if(rdr["Store_In"].ToString().Trim().Length>len9)
					len9=rdr["Store_In"].ToString().Trim().Length;	
			}
		}
		
		/// <summary>
		/// This method is not used
		/// </summary>
		private string GetString(string str,int maxlen,string spc)
		{		
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
		}

		/// <summary>
		/// This method is not used
		/// </summary>
		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
		}

		/// <summary>
		/// This method prepares the report and writes into a Text File to print. info string is used to display print the values in specified formats.
		/// </summary>
		public void reportmaking()
		{
			/*
														 ========================                                                
														   PRODUCT ENTRY REPORT                                                  
														 ========================                                                
			+--------+---------------------+----------------+---------+----+---------+--------+----------+------------+
			|Prod ID |    Product Name     |    Category    |Pack Type|Pack|Quantity |Opening |   Unit   | Store In   |
			|        |                     |                |         |Unit|         | Stock  |          |            |
			+--------+---------------------+----------------+---------+----+---------+--------+----------+------------+
			 1003      Servo pride           Engine oil      100x100   1234  12345678 12345678  Packet     Sales Room

			*/			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\ProductEntryReport.txt";

			StreamWriter sw = new StreamWriter(path);
			string info="";
			System.Data.SqlClient.SqlDataReader rdr=null;
			InventoryClass obj=new InventoryClass (); 
			SqlDataReader SqlDtr;
			string sql="";
			string store="";
			string packType = "";
			         			
			sql="select Prod_ID, Prod_Name, Category, Pack_Type, Pack_Unit, Total_Qty, Opening_Stock, Unit, Store_In from  Products";

			sw.WriteLine("                                             ======================== ");
			sw.WriteLine("                                               PRODUCT ENTRY REPORT ");
			sw.WriteLine("                                             ======================== ");
			sw.WriteLine("+--------+---------------------+----------------+---------+----+---------+--------+----------+------------+");
			sw.WriteLine("|Prod ID |    Product Name     |    Category    |Pack Type|Pack|Quantity |Opening |   Unit   | Store In   |");
			sw.WriteLine("|        |                     |                |         |Unit|         | Stock  |          |            |");
			sw.WriteLine("+--------+---------------------+----------------+---------+----+---------+--------+----------+------------+");
			//             1003      Servo pride           Engine oil      100x100   1234  12345678 12345678 Packet     Sales Room  
			info=" {0,-4:S}      {1,-20:S}  {2,-15:S} {3,-9:S} {4,-4:S}  {5,8:F} {6,8:F} {7,-10:S} {8,-12:S}";
			dbobj.SelectQuery(sql,ref rdr);

			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					store = rdr["Store_In"].ToString();
					if(rdr["Category"].ToString().Trim().Equals("Fuel")) 
					{
						
						SqlDtr = obj.GetRecordSet("select Prod_AbbName from Tank where Tank_ID = '"+store+"'");
						if(SqlDtr.Read())
							store = SqlDtr.GetValue(0).ToString();
						else
							store = "";
						SqlDtr.Close(); 
					}	
					packType = rdr["Pack_Type"].ToString();
					if(packType.Trim().IndexOf("Loose")!= -1)
						packType="";
				
					sw.WriteLine(info,rdr["Prod_ID"].ToString(),
						rdr["Prod_Name"].ToString(),
						rdr["Category"].ToString(),
						packType ,
						rdr["Pack_Unit"].ToString(),
						rdr["Total_Qty"].ToString(),
						rdr["Opening_Stock"].ToString(),
						rdr["Unit"].ToString(),
						store);	
				}
			}
			sw.WriteLine("+--------+---------------------+----------------+---------+----+---------+--------+----------+------------+");
			rdr.Close();
			sw.Close(); 
		}

		/// <summary>
		/// Its clears the form.
		/// </summary>
		public void Clear()
		{
			lblProdID.Text="";
			DropCategory.SelectedIndex=0;
			DropPackage.SelectedIndex=0;
			DropPackUnit.SelectedIndex=0;
			DropStorein.SelectedIndex=0;
			DropUnit.SelectedIndex=0;
			txtProdName.Text="";
			txtCategory.Text=""; 
			txtPack1.Text="";
			txtPack2.Text="";
			txtOp_Stock.Text="";
			txtTotalQty.Text="";
			txtBox.Text=""; 
			txtunit.Text=""; 
			txtPack1.Enabled=true;
			txtPack2.Enabled=true;
			txtCategory.Enabled=true;
			txtMinLabel.Text="";
			txtMaxLabel.Text="";
			txtReOrderLabel.Text="";
		}

		/// <summary>
		/// To return next product id from the database.Initial starts with 1001.
		/// </summary>
		public void GetNextProductID()
		{
			InventoryClass obj=new InventoryClass (); 
			SqlDataReader SqlDtr;
			string sql;

			#region Fetch Next Product ID
			sql="select Max(Prod_ID)+1 from Products";
			SqlDtr = obj.GetRecordSet(sql); 
			while(SqlDtr.Read())
			{
				lblProdID.Text =SqlDtr.GetValue(0).ToString();
				if(lblProdID.Text=="")
				{
					lblProdID.Text ="1001";
				}
			}
			SqlDtr.Close (); 
			#endregion
		}

		/// <summary>
		/// This method is used to get All Products ID and fill in the ComboBox
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				lb.Visible=true;
				lblProdID.Visible=false;
				btnEdit.Visible=false;
				dropProdID.Visible=true;
				btnSave.Enabled = true;  
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string sql;
				dropProdID.Items.Clear();
				dropProdID.Items.Add("Select");

				#region Get All Products ID and fill in the ComboBox
				sql="select Prod_name+':'+Pack_Type from Products where Category!='Fuel' order by Prod_Name";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					dropProdID.Items.Add(SqlDtr.GetValue(0).ToString()); 
				}
				SqlDtr.Close();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Product_Entry  Method: btnEdit_Click.  EXCEPTION  "+  ex.Message+".  User_id is   "+pass);
			}
		}
		
		/// <summary>
		/// To Fatch the all product details according to select the product id in the combo.
		/// </summary>
		private void dropProdID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(dropProdID.SelectedIndex==0)
					return;

				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string sql;
				string[] arr=dropProdID.SelectedItem.Text.Split(new char[]{':'},dropProdID.SelectedItem.Text.Length);  

				#region Fatch the all product details according to product id.
				//			sql="select * from Products where Category!='Fuel' and Prod_ID='"+ dropProdID.SelectedItem.Value +"'";
				sql="select * from Products where Category!='Fuel' and Prod_Name='"+ arr[0] +"' and Pack_Type='"+arr[1]+"'";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					txtProdName.Text=SqlDtr.GetValue(1).ToString();  
					DropCategory.SelectedIndex=DropCategory.Items.IndexOf(DropCategory.Items.FindByValue(SqlDtr.GetValue(2).ToString ()));
					DropPackage.SelectedIndex= DropPackage.Items.IndexOf(DropPackage.Items.FindByValue(SqlDtr.GetValue(3).ToString ()));
					if(DropPackage.SelectedIndex != 1)
					{
						DropUnit.Enabled = true;
						txtOp_Stock.Enabled  = true;
						txtBox.Enabled = false;
						txtBox.Text = "";
						txtOp_Stock.Text ="";
						DropPackUnit.SelectedIndex= DropPackUnit.Items.IndexOf(DropPackUnit.Items.FindByValue(SqlDtr.GetValue(4).ToString ()));
						txtTotalQty.Text=SqlDtr.GetValue(5).ToString();
						txtOp_Stock.Text=SqlDtr.GetValue(6).ToString();
						if(txtTotalQty.Text!="" && txtOp_Stock.Text!="")
						{
							txtBox.Text= System.Convert.ToString(System.Convert.ToDouble(txtTotalQty.Text) *  System.Convert.ToInt32(txtOp_Stock.Text));
						}
						DropUnit.SelectedIndex=DropUnit.Items.IndexOf(DropUnit.Items.FindByValue(SqlDtr.GetValue(7).ToString ()));
						DropStorein.SelectedIndex=DropStorein.Items.IndexOf(DropStorein.Items.FindByValue(SqlDtr.GetValue(8).ToString()));
						txtMinLabel.Text=SqlDtr.GetValue(9).ToString().Trim();
						txtMaxLabel.Text=SqlDtr.GetValue(10).ToString().Trim();
						txtReOrderLabel.Text=SqlDtr.GetValue(11).ToString().Trim();
					}
					else
					{
						txtBox.Text = "";
						txtOp_Stock.Text ="";
						DropPackUnit.SelectedIndex= DropPackUnit.Items.IndexOf(DropPackUnit.Items.FindByValue(SqlDtr.GetValue(4).ToString ()));
						txtTotalQty.Text=SqlDtr.GetValue(5).ToString();
						txtOp_Stock.Enabled = false;
						txtBox.Enabled = true;
						txtBox.Text = SqlDtr.GetValue(6).ToString();
						DropUnit.SelectedIndex=DropUnit.Items.IndexOf(DropUnit.Items.FindByValue(SqlDtr.GetValue(7).ToString ()));
						DropUnit.Enabled = false;
						txtunit.Text ="";
						DropStorein.SelectedIndex=DropStorein.Items.IndexOf(DropStorein.Items.FindByValue(SqlDtr.GetValue(8).ToString()));
						txtMinLabel.Text=SqlDtr.GetValue(9).ToString().Trim();
						txtMaxLabel.Text=SqlDtr.GetValue(10).ToString().Trim();
						txtReOrderLabel.Text=SqlDtr.GetValue(11).ToString().Trim();
					}
				}
				SqlDtr.Close();
				txtCategory.Enabled = false;
				txtPack1.Enabled = false;
				txtPack2.Enabled = false;
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Product_Entry  Method: dropProdID_SelectedIndexChanged.  EXCEPTION  "+  ex.Message+".  User_id is   "+pass);
			}
		}
	}
}