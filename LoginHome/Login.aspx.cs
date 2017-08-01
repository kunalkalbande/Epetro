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
using System.Text.RegularExpressions;
using System.Text;
using System.Data;
using System.Security.Cryptography;

using System.IO;
using System.Diagnostics;
using DBOperations;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using RMG;
using MySecurity;

using System.Runtime.InteropServices;
using System.Management;

using System.Net;
using System.Net.Sockets;
//using Security;

namespace EPetro.LoginHome
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.DropDownList DropUser;
		protected System.Web.UI.WebControls.ImageButton btnSign;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox TxtUserName;
		protected System.Web.UI.WebControls.TextBox TxtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["Epetro"],true);
		protected System.Web.UI.HtmlControls.HtmlImage Cal_Img;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.HtmlControls.HtmlImage Cal_Img1;
		protected System.Web.UI.WebControls.Label lblMessage;

		/// <summary>
		/// This method is used to check the activation with the help of MySecurity.dll 
		/// after that filling the required dropdown with database values 
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			string check = "";
			Cal_Img1.Visible = false; 

			// check string gets the value from the check() method present in MySecurity.dll;
			//** if syssts = 0 for Trial Peried and syssts = 1 for Activated and syssts=2 for Expired. in the systbl table.
			//** if syssts =2 then error occured "PROBLEM ENCOUNTERED AT THE SERVER SIDE PLEASE CONTACT bbnisys Technologies Pvt. Ltd."
			//** Solution :- insert the values (syssts=0, syssta =FromDate, sysend = ToDate and sysabbr = D) in the table systbl. 
			
			//check=Security.Security.check();
			check = MySecurity.MySecurity.check();  
					 
			// If the return value is false then the activation period expired and redirect to the error.aspx
			if(check.Equals("false" ))
			{
				Response.Redirect("..\\Sysitem\\error.aspx",false);
				return;
			}
			// If the return value is Service then the Print_WindowsService is stopped and redirect to the Service.aspx
			if(check.Equals("Service"))
			{
				Response.Redirect("..\\Sysitem\\Service.aspx",false);
				return;
			}

			// If the return value is starts with P then dispaly the activation period. 
			if(!check.Equals(""))
			{
				if(!check.Equals("true") && check.StartsWith("P") )
				{
					lblMessage.Text = check.Substring(1)+" left for Activation";
					//Cal_Img.Disabled = true;
					Cal_Img.Visible = false;
					Cal_Img1.Visible = true; 
					Cal_Img1.Disabled = true; 
					//Cal_Img. 
 
					//					Cal_Img.Visible = true;
					//					Cal_Img1.Visible = false; 
					//					Cal_Img1.Disabled = false; 
				}
			}
			Session.Clear();
			if(!IsPostBack)
			{
                txtDateFrom.Attributes.Add("readonly", "readonly");
                // Subhan: The 4 lines commented to increase the performance of a project on a windows xp and 2000 professional OS.  
                //Response.Buffer=false;
                //Response.CacheControl="no-cache";
                //Response.Expires=System.DateTime.Now.Minute-1;
                //Cache["view"]=true;
                //Subhan
                PetrolPumpClass obj=new PetrolPumpClass();
				SqlDataReader SqlDtr;
				string sql;
				// Fetch the roles and fills the User Type combo.
				sql="select Role_Name from Roles";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
					DropUser.Items.Add(SqlDtr.GetValue(0).ToString()); 				
				SqlDtr.Close();
				txtDateFrom.Text = DateTime.Now.Day.ToString()+"/"+DateTime.Now.Month.ToString()+"/"+DateTime.Now.Year.ToString();   
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
			this.btnSign.Click += new System.Web.UI.ImageClickEventHandler(this.btnSign_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// This method is not used.
		/// </summary>
		private bool IsExpired()
		{
			int x=0;
			bool Status=false;
			dbobj.ExecuteScalar("select count(*) from SysTable",ref x);
			if(x<=0)
			{
				dbobj.Insert_or_Update("insert into SysTable(SysDate1,SysDate2,allow) values(getdate(),dateadd(dd,30,getdate()),'f')",ref x);
			}
			else
			{
				dbobj.Insert_or_Update("if((select SysDate2 from SysTable)<(select getdate())) update SysTable set allow='n'",ref x);
			}
			System.Data.SqlClient.SqlDataReader rdr=null;
			dbobj.SelectQuery("select allow from SysTable",ref rdr);
			if(rdr.Read())
			{
				if(rdr["allow"].Equals("n"))
					Status=true;
			}
			return Status;
		}
	
		/// <summary>
		/// This method is used to check the user name and passwors according to select the 
		/// administrator value from the dropdownlist.
		/// </summary>
		private void btnSign_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			CreateLogFiles.ErrorLog("Form:Login.aspx,Method: btnSign_Click, Login Type "+ DropUser.SelectedItem.Text    +" and  Login User   "+ TxtUserName.Text );
			PetrolPumpClass obj=new PetrolPumpClass();
			
			try
			{
				SqlDataReader SqlDtr; 
				string sql;
				string User_ID="";
				string[,] Privileges=new string[73,6];

				#region Check for Valid User
				string pwd="";
				string epassword="";
				sql="select Password from User_Master where LoginName='"+ TxtUserName.Text  +"'"; 
				SqlDtr =obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{ 
					pwd =MySecurity.MySecurity.Decrypt(SqlDtr.GetValue(0).ToString(),"!@#$%^");
				
					if(TxtPassword.Text==pwd)
					{
						epassword = SqlDtr.GetValue(0).ToString();
						SqlDtr.Close();
					}
					else
					{
						RMG.MessageBox.Show("Invalid User Login Name or Password");			
						return;
					}
				}
				else
				{
					//RMG.MessageBox.Show("Invalid User Login Name or Password");			
					return;
				}
				SqlDtr.Close();

				//				// Calls the method contactServer by passing the selected date to set the system date as a selected date.
				MySecurity.MySecurity.contactServer("[CD]"+convertDate(txtDateFrom.Text));   
				#region get the message from Organisation table and put into session to display in all the invoices
				dbobj.SelectQuery("Select Message from organisation where CompanyID = 1001",ref SqlDtr);
				if(SqlDtr.Read())
				{
					Session["Message"] = SqlDtr.GetValue(0).ToString();
				}
				else
				{
					Session["Message"] = "";
				}
				SqlDtr.Close();
				#endregion

				#region get the VAT_Rate from Organisation table and put into session to access in Sales and Purchase Invoice.
				dbobj.SelectQuery("Select VAT_Rate from organisation where CompanyID = 1001",ref SqlDtr);
				if(SqlDtr.Read())
				{
					Session["VAT_Rate"] = SqlDtr.GetValue(0).ToString();  
				}
				else
				{
					Session["VAT_Rate"] = "";
				}
				SqlDtr.Close();
				#endregion
		
				#region select the user id ,password compare and stored in a session variable.	
				sql="select UserID, LoginName,password from User_Master um, Roles r where um.role_ID=r.role_ID and um.LoginName='"+ TxtUserName.Text  +"' and password='"+epassword+"' and r.Role_ID=(select Role_ID from Roles where Role_Name='"+ DropUser.SelectedItem.Value  +"')";
				SqlDtr=obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
					User_ID=SqlDtr.GetValue(0).ToString();
					Session["User_ID"] = User_ID;
					Session["User_Name"]=SqlDtr.GetValue(1).ToString();
					
					//Name : Modified this part by Mahesh
					//Becouse the problem of session expire 
					//Cache are used in the place of session.
					//**Cache["User_Name"]=SqlDtr.GetValue(1).ToString();
					Session["PASSWORD"]=SqlDtr.GetValue(2).ToString();
					//SqlDtr.Close();
				}
				else
				{
					RMG.MessageBox.Show("Invalid User Login Name or Password");			
					return;
				}
				SqlDtr.Close();
				#endregion
				#endregion
				if(User_ID!="")
				{
					#region Get The User Permission
					sql="select * from Privileges where User_ID='"+ User_ID +"'";
					SqlDtr=obj.GetRecordSet(sql);
					for(int i=0;SqlDtr.Read();i++)
					{
						for(int j=0;j<6;j++)	
						{
							Privileges[i,j]=SqlDtr.GetValue(j+1).ToString(); 
						}
					}
					SqlDtr.Close();
					Session["Privileges"]=Privileges;
					//string ss=Session["Privileges"].ToString();
					
					//Session["User_Name"]=SqlDtr.GetValue(1).ToString();
					//Name : Modified this part by Mahesh
					//Becouse the problem of session expire 
					//Cache are used in the place of session.
					//**Cache["Privileges"]=Privileges;
					#endregion 
					Response.Redirect("../LoginHome/HomePage.aspx",false);
				}
				else
				{
					RMG.MessageBox.Show("Invalid User Login Name or Password");			
					return;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Login.aspx,Method: btnSign_Click, Login Type "+ DropUser.SelectedItem.Text    +"  EXCEPTION   "+ex.ToString()+"  and  Login User   "+ TxtUserName.Text );
			}
		}

		/// <summary>
		/// This method is used to returns the date in mm/dd/yyyy from dd/mm/yyyy string.
		/// </summary>
		public string convertDate(string strDate)
		{
			string[] strArr = strDate.Split(new char[] {'/'} , strDate.Length);
			return strArr[1]+"-"+strArr[0]+"-"+strArr[2];
		}
	}
}