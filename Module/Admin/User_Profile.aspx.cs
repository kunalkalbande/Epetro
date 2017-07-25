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
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Security.Cryptography;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using DBOperations;
using RMG;

namespace EPetro.Module.Admin
{
	/// <summary>
	/// Summary description for User_Profile.
	/// </summary>
	public class User_Profile : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFName;
		protected System.Web.UI.WebControls.TextBox txtMName;
		protected System.Web.UI.WebControls.TextBox txtLName;
		protected System.Web.UI.WebControls.DropDownList DropRole;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.TextBox txtLoginName;
		protected System.Web.UI.WebControls.Label lblUserID;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.DropDownList dropUserID;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;

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
				uid=(Session["User_Name"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:Page_load  EXCEPTION: "+ ex.Message+"    "+uid);
				Response.Redirect("ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				try
				{
					#region Check Privileges, if the user is admin then grant the access
					if(Session["User_ID"].ToString ()!="1001")
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					#endregion

					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string sql;

					#region Fetch Roles from Database and Add in the ComboBox
					sql="select Role_Name from Roles order by Role_Name";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropRole.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
					#endregion

					GetNextUserID();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:Page_load EXCEPTION: "+ ex.Message+"    "+uid);
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
			this.dropUserID.SelectedIndexChanged += new System.EventHandler(this.dropUserID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to Clear the form.
		/// </summary>
		public void Clear()
		{
			lblUserID.Text="";
			txtLoginName.Text="";
			txtPassword.Text="";
			txtFName.Text="";
			txtMName.Text="";
			txtLName.Text="";
			DropRole.SelectedIndex=0;
		}
		
		/// <summary>
		/// This methos is used to Retrieve next user id from the database.
		/// </summary>
		public void GetNextUserID()
		{
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr;
			string sql;
			try
			{
				#region Fetch Next User ID
			
				sql="select max(UserID)+1 from User_Master";
				SqlDtr =obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					lblUserID.Text=SqlDtr.GetSqlValue(0).ToString ();
					if (lblUserID.Text=="Null")
						lblUserID.Text ="1001";
				}		
				SqlDtr.Close();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:GetNextUserID  EXCEPTION: "+ ex.Message+"    "+uid);
			}
		}

		/// <summary>
		/// This methos is used to insert or update the records with the help of stored procedures.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{

			EmployeeClass obj=new EmployeeClass();
			int x=0;
			try
			{
				#region check the username is exist or not?
				dbobj.ExecuteScalar("select count(*) from user_master where loginname='"+txtLoginName.Text.Trim()+"'",ref x);
				if(x>0)
				{
					if(dropUserID.Visible)
					{
						SqlDataReader SqlDtr = null;
						string UserId = "";
						dbobj.SelectQuery("Select UserID from user_master where loginname='"+txtLoginName.Text.Trim()+"'" ,ref SqlDtr);
						if(SqlDtr.Read())
						{
							UserId = SqlDtr.GetValue(0).ToString().Trim();   
						}
						SqlDtr.Close();
						if(!dropUserID.SelectedItem.Text.Trim().Equals(UserId))
						{
							RMG.MessageBox.Show("User " +txtLoginName.Text +" already exists");
							return;
						}
					}
					else
					{
						RMG.MessageBox.Show("User " +txtLoginName.Text +" already exists");
						return;
					}
				}
				#endregion
		
				obj.Login_Name=txtLoginName.Text.ToString();

				obj.Password = Encrypt(txtPassword.Text.ToString(),"!@#$%^");
													
				obj.User_Name=txtFName.Text.ToString()+" "+txtMName.Text.ToString()+" "+txtLName.Text.ToString();
				obj.Role_Name=DropRole.SelectedItem.Value; 
				if(dropUserID.Visible)
				{
					obj.User_ID = dropUserID.SelectedItem.Value;
					obj.UpdateUserMaster();
					CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:brnUpdate_Click.  User  ID"+ obj.User_ID +" Updated.  User: "+uid);
					MessageBox.Show("User Profile Updated");
				}
				else
				{
					obj.User_ID = lblUserID.Text.ToString();
					obj.InsertUserMaster();	
					CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:brnUpdate_Click. New User With ID "+ obj.User_ID +" Created.  User: "+uid);
					MessageBox.Show("User Profile Created");
				}
				
				Clear();
				GetNextUserID();
				lblUserID.Visible=true;
				btnEdit.Visible=true;
				dropUserID.Visible=false;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:Page_load  EXCEPTION: "+ ex.Message+"    "+uid);
			}
		}

		/// <summary>
		/// This methos is used to encrypt the user password before saving to the database.
		/// </summary>
		public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV) 
		{ 
			// Create a MemoryStream to accept the encrypted bytes 
			MemoryStream ms = new MemoryStream(); 

			// Create a symmetric algorithm. 
			// We are going to use Rijndael because it is strong and
			// available on all platforms. 
			// You can use other algorithms, to do so substitute the
			// next line with something like 
			//      TripleDES alg = TripleDES.Create(); 

			Rijndael alg = Rijndael.Create(); 

			// Now set the key and the IV. 
			// We need the IV (Initialization Vector) because
			// the algorithm is operating in its default 
			// mode called CBC (Cipher Block Chaining).
			// The IV is XORed with the first block (8 byte) 
			// of the data before it is encrypted, and then each
			// encrypted block is XORed with the 
			// following block of plaintext.
			// This is done to make encryption more secure. 

			// There is also a mode called ECB which does not need an IV,
			// but it is much less secure. 
			alg.Key = Key; 
			alg.IV = IV; 

			// Create a CryptoStream through which we are going to be
			// pumping our data. 
			// CryptoStreamMode.Write means that we are going to be
			// writing data to the stream and the output will be written
			// in the MemoryStream we have provided. 
			CryptoStream cs = new CryptoStream(ms, 
				alg.CreateEncryptor(), CryptoStreamMode.Write); 

			// Write the data and make it do the encryption 
			cs.Write(clearData, 0, clearData.Length); 

			// Close the crypto stream (or do FlushFinalBlock). 
			// This will tell it that we have done our encryption and
			// there is no more data coming in, 
			// and it is now a good time to apply the padding and
			// finalize the encryption process. 
			cs.Close(); 

			// Now get the encrypted data from the MemoryStream.
			// Some people make a mistake of using GetBuffer() here,
			// which is not the right way. 
			byte[] encryptedData = ms.ToArray();

			return encryptedData; 
		} 

		/// <summary>
		/// Encrypt a string into a string using a password 
		//  Uses Encrypt(byte[], byte[], byte[]) 
		/// </summary>
		public static string Encrypt(string clearText, string Password) 
		{ 
			// First we need to turn the input string into a byte array. 
			byte[] clearBytes = 
				System.Text.Encoding.Unicode.GetBytes(clearText); 

			// Then, we need to turn the password into Key and IV 
			// We are using salt to make it harder to guess our key
			// using a dictionary attack - 
			// trying to guess a password by enumerating all possible words. 
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
							   0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76}); 

			// Now get the key/IV and do the encryption using the
			// function that accepts byte arrays. 
			// Using PasswordDeriveBytes object we are first getting
			// 32 bytes for the Key 
			// (the default Rijndael key length is 256bit = 32bytes)
			// and then 16 bytes for the IV. 
			// IV should always be the block size, which is by default
			// 16 bytes (128 bit) for Rijndael. 
			// If you are using DES/TripleDES/RC2 the block size is
			// 8 bytes and so should be the IV size. 
			// You can also read KeySize/BlockSize properties off
			// the algorithm to find out the sizes. 
			byte[] encryptedData = Encrypt(clearBytes, 
				pdb.GetBytes(32), pdb.GetBytes(16)); 

			// Now we need to turn the resulting byte array into a string. 
			// A common mistake would be to use an Encoding class for that.
			//It does not work because not all byte values can be
			// represented by characters. 
			// We are going to be using Base64 encoding that is designed
			//exactly for what we are trying to do. 
			return Convert.ToBase64String(encryptedData); 
		}

		//		private byte[] Encrypt(string pswd)
		//		{
		//			RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
		//			byte[]key=System.Text.ASCIIEncoding.ASCII.GetBytes("shashank");
		//			byte[]IV=System.Text.ASCIIEncoding.ASCII.GetBytes("shashank");
		//			byte[]data=System.Text.ASCIIEncoding.ASCII.GetBytes(pswd);
		//			MemoryStream msEncrypt = new MemoryStream();
		//			//CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
		//			CryptoStream csEncrypt = new CryptoStream(msEncrypt, rc2CSP.CreateEncryptor(key,IV), CryptoStreamMode.Write);			
		//			csEncrypt.Write(data,0,data.Length);
		//			csEncrypt.FlushFinalBlock();
		//			return msEncrypt.ToArray();
		//			//txtres.Text=System.Text.ASCIIEncoding.ASCII.GetString(msEncrypt.ToArray());
		//		}

		/// <summary>
		/// This method is used to Retrieve all user id in combobox from database.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			lblUserID.Visible=false;
			btnEdit.Visible=false;
			dropUserID.Visible=true;

			#region	Fetch All User ID

			try
			{
				dropUserID.Items.Clear();
				dropUserID.Items.Add("Select");
				DBOperations.DBUtil obj=new DBOperations.DBUtil();
				SqlDataReader SqlDtr=null;
				obj.SelectQuery("select UserID from User_Master",ref SqlDtr);
				while(SqlDtr.Read())
				{
					dropUserID.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:btnEdit_Click EXCEPTION: "+ ex.Message+"  " +uid);
			}
			#endregion
		}

		/// <summary>
		/// This methos is used to retrieve the all values from the database according to selected value in the dropdownlist.
		/// </summary>
		private void dropUserID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				Clear();
				DBOperations.DBUtil obj=new DBOperations.DBUtil();
				SqlDataReader SqlDtr=null;

				obj.SelectQuery("select loginname, password, username,role_name from user_master um, roles r where um.role_id=r.role_id and UserId='"+ dropUserID.SelectedItem.Value +"'",ref SqlDtr);
				while(SqlDtr.Read())
				{
					txtLoginName.Text=SqlDtr.GetValue(0).ToString();
					txtPassword.Text=SqlDtr.GetValue(1).ToString();
					txtFName.Text=SqlDtr.GetValue(2).ToString();
					DropRole.SelectedIndex=DropRole.Items.IndexOf(DropRole.Items.FindByValue(SqlDtr.GetValue(3).ToString()));
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Please Select User ID");
				CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:dropUserID_SelectedIndexChanged  EXCEPTION: "+ ex.Message+"    "+uid);
			}
		}

		/// <summary>
		/// This method is used to delete the record according to selected value from the dropdownlist.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(dropUserID.SelectedIndex==0)
			{
				RMG.MessageBox.Show("Please select the User ID");
				return;
			}
			int output=0;
			try
			{
				DBOperations.DBUtil obj=new DBOperations.DBUtil();
				obj.Insert_or_Update("delete from User_Master where UserID='"+ dropUserID.SelectedItem.Value +"'",ref output);
				obj.Insert_or_Update("delete from privileges where User_ID='"+ dropUserID.SelectedItem.Value +"'",ref output);
				dropUserID.Items.Remove(dropUserID.SelectedItem.Value);
				MessageBox.Show("User Deleted");
				dropUserID.Visible=false;
				lblUserID.Visible=true;
				Clear();
				GetNextUserID();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:User_Profile.aspx,Method:btnDelete_Click  EXCEPTION: "+ ex.Message+"    "+uid);
			}
		}
	}
}