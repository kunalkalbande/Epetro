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
using System.IO;
using System.Text; 
using EPetro.Sysitem.Classes;  
using RMG;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace EPetro.Module.Admin
{
	/// <summary>
	/// Summary description for Backup_Restore.
	/// </summary>
	public class BackupRestore : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnBackup;
		protected System.Web.UI.WebControls.Button btnRestore;
		string uid= "";
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempPath;
		static int Flag=0;
	
		/// <summary>
		/// This method is used for setting the Session variable for userId
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{ 
				uid=(Session["User_Name"].ToString ());
				btnRestore.Attributes.Add("OnClick","Progressbar();");
				btnBackup.Attributes.Add("OnClick","Progressbar();");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:Page_load   EXCEPTION:  "+ex.Message+" userid  "+uid  );
				Response.Redirect("ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				Flag=0;
				btnRestore.Enabled=false;
				#region Check Privileges if user id admin then grant the access
				if(Session["User_ID"].ToString ()!="1001")
					Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
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
			this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
			this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to create a backup file from database and stored in EPetro backup folder when creating a system home drive.
		/// </summary>
		private void btnBackup_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
				//lblMessage.Visible = true;
				//** 
				//System.Threading.Thread.Sleep(5 * 1000); 
				//	lblMessage.Visible = false;
				//****************************
				//				string msg = "";
				//				msg = contactServer("[BK]");
				//				if(msg.Trim().Equals("Backup Completed"))
				//					MessageBox.Show("Backup Completed."); 
				//****************************
				string main_drive = Environment.SystemDirectory;
				string drive = main_drive.Substring(0,2);
				string strGrandFather  = drive+"\\EPetroBackup\\GrandFather\\";
				string strFather       = drive+"\\EPetroBackup\\Father\\";
				string strSon          = drive+"\\EPetroBackup\\Son\\";
				string strDataBase = "EPetro.bak";
				bool blnGrandFather=false, blnFather=false, blnSon=false;
				int Count=0;
				Directory.CreateDirectory(strGrandFather);
				Directory.CreateDirectory(strFather);
				Directory.CreateDirectory(strSon);
				if (File.Exists(strGrandFather + strDataBase)) 
					blnGrandFather = true;
				if (File.Exists(strFather + strDataBase)) 
					blnFather = true;
				if (File.Exists(strSon + strDataBase)) 
					blnSon = true;

				// Start Backing...

				if (blnGrandFather == true && blnFather == true && blnSon == true)
				{
					// Father ---> GrandFather
					File.Copy(strFather + strDataBase, strGrandFather + strDataBase, true);
					//File.Copy(strFather + strDBLog, strGrandFather + strDBLog, true);

					// Son ---> Father
					File.Copy(strSon + strDataBase, strFather + strDataBase, true);
					//File.Copy(strSon + strDBLog, strFather + strDBLog, true);

					// MS-SQL ---> Son
					//File.Copy(strDataBasePath + strDataBase, strSon + strDataBase, true);
					//File.Copy(strDataBasePath + strDBLog, strSon + strDBLog, true);
				}
				else
				{
					con.Open();
					//SqlCommand cmd = new SqlCommand("BACKUP DATABASE [EPetro] TO  DISK = N'C:\\EPetroBackup\\Son\\EPetro.bak' WITH NOFORMAT, NOINIT,  NAME = N'EPetro-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10",con);
					SqlCommand cmd = new SqlCommand("BACKUP DATABASE [EPetro] TO  DISK = N'C:\\EPetroBackup\\Son\\EPetro.bak' WITH NOFORMAT, INIT,  NAME = N'EPetro-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					System.Threading.Thread.Sleep(1000 * 5);
					Count=1;
					//MS-SQL ---> GrandFather
					//File.Copy(strDataBasePath + strDataBase, strGrandFather + strDataBase, true);
					File.Copy(strSon + strDataBase, strGrandFather + strDataBase, true);
					//File.Copy(strDataBasePath + strDBLog, strGrandFather + strDBLog, true);
	       
					//MS-SQL ---> Father
					//File.Copy(strDataBasePath + strDataBase, strFather + strDataBase, true);
					File.Copy(strSon + strDataBase, strFather + strDataBase, true);
					//File.Copy(strDataBasePath + strDBLog, strFather + strDBLog, true);
	       
					//MS-SQL ---> Son
					//File.Copy(strDataBasePath + strDataBase, strSon + strDataBase, true);
					//File.Copy(strSon + strDataBase, strSon + strDataBase, true);
					//File.Copy(strDataBasePath + strDBLog, strSon + strDBLog, true);
				}
				//************************
				if(Count==0)
				{
					con.Open();
					//SqlCommand cmd = new SqlCommand("BACKUP DATABASE [EPetro] TO  DISK = N'C:\\EPetroBackup\\Son\\EPetro.bak' WITH NOFORMAT, NOINIT,  NAME = N'EPetro-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10",con);
					SqlCommand cmd = new SqlCommand("BACKUP DATABASE [EPetro] TO  DISK = N'C:\\EPetroBackup\\Son\\EPetro.bak' WITH NOFORMAT, INIT,  NAME = N'EPetro-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					System.Threading.Thread.Sleep(1000 * 5);
				}
				MessageBox.Show("Backup Complete");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:btnBackup_Click   EXCEPTION:  "+ex.Message+" userid  "+uid  );  
			}
		}

		/// <summary>
		/// This method is used to Sends the text file to print server to print.
		/// </summary>
		public string contactServer(string key)
		{
			// Data buffer for incoming data.
			byte[] bytes = new byte[1024];
			string strID = "";
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
				Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );

				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender.Connect(remoteEP);
					// Encode the data string into a byte array.
					byte[] msg = Encoding.ASCII.GetBytes(key + "<EOF>");

					// Send the data through the socket.
					int bytesSent = sender.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender.Receive(bytes);
					//Console.WriteLine("\nEpetroPrintServices Server Echo = {0}", Encoding.ASCII.GetString(bytes,0,bytesRec));
					strID = Encoding.ASCII.GetString(bytes,0,bytesRec);
					// Release the socket.
					sender.Shutdown(SocketShutdown.Both);
					sender.Close();
					return strID;
				}
				catch (ArgumentNullException ane) 
				{
					string str = ane.Message; // To avoid Warnings
					CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:contactServer()   EXCEPTION:  "+ane.Message+" userid  "+uid  );    
				}
				catch (SocketException se)
				{
					string str = se.Message; // To avoid Warnings
					CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:contactServer()   EXCEPTION:  "+se.Message+" userid  "+uid  );    
					//Response.Redirect(".\\Service.aspx",false);
				} 
				catch (Exception e)
				{
					string str = e.Message; // To avoid Warnings
					CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:contactServer()   EXCEPTION:  "+e.Message+" userid  "+uid  );      
					//Response.Redirect(".\\Service.aspx",false);
				}
			} 
			catch (Exception e)
			{
				string str = e.Message; // To avoid Warnings
				CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:contactServer()   EXCEPTION:  "+e.Message+" userid  "+uid  );    
			}
			return "";
		}

		/// <summary>
		/// This method is used to restored the data in database from EPetro backup folder. 
		/// </summary>
		private void btnRestore_Click(object sender, System.EventArgs e)
		{
			try
			{
				//				System.Threading.Thread.Sleep(5 * 1000); 
				//				string msg = "";
				//				msg = contactServer("[RS]");
				//				if(msg.Trim().Equals("Restored"))  
				//					MessageBox.Show("Data Restored."); 
				if(tempPath.Value!="")
				{
					string FilePath=tempPath.Value;
					FilePath+=".bak";
					SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Master"]);
					con.Open();
					SqlCommand cmd = new SqlCommand("Alter DATABASE EPetro SET SINGLE_USER WITH ROLLBACK IMMEDIATE",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					con.Open();
					cmd = new SqlCommand("RESTORE DATABASE [EPetro] FROM  DISK = '"+FilePath+"' WITH  FILE = 1,REPLACE",con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					con.Open();
					cmd = new SqlCommand("Alter DATABASE EPetro SET MULTI_USER",con);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(1000 * 30);
					MessageBox.Show("Restore Complete");
					cmd.Dispose();
					con.Close();
					Flag=1;
				}
				else
				{
					MessageBox.Show("Please Select The '.bak' File");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:BackupRestore.aspx,Method:btnRestore_Click   EXCEPTION:  "+ex.Message+" userid  "+uid  );  
			}
		}
	}
}