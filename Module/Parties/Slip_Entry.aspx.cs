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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using EPetro.Sysitem.Classes ;
using DBOperations;
using RMG;

namespace EPetro.Module.Master
{
	/// <summary>
	/// Summary description for Slip_Entry.
	/// </summary>
	public class Slip_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HLinkHome;
		protected System.Web.UI.WebControls.Label lblSlipBookID;
		protected System.Web.UI.WebControls.TextBox txtBookNo;
		protected System.Web.UI.WebControls.TextBox txtStartNo;
		protected System.Web.UI.WebControls.DropDownList DropCustID;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox txtEndNo;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.TextBox txtTotalSlips;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.DropDownList dropslipID;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Update;
		protected System.Web.UI.WebControls.Label Label1;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		static string slipEnd="";
		static string bookNo="";

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			dropslipID.Visible=false; 
			Update.Visible=false;
			txtEndNo.Attributes.Add("onblur","calc();");
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Slip_Entry.aspx,Method:page_load"+ ex.Message+ "EXCEPTION "+uid);
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
					string Module="3";
					string SubModule="4";
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
					//if(Add_Flag == "0")
					#endregion

					PartiesClass  obj=new PartiesClass();
					SqlDataReader SqlDTRed;
					string sql;
					GetNextSlipBookID();
					Button1.Visible=true;
					#region Get all Customer ID
					sql="select Cust_Name+':'+City from Customer order by Cust_Name";
					SqlDTRed=obj.GetRecordSet(sql) ;
					while(SqlDTRed.Read())
					{
						DropCustID.Items .Add (SqlDTRed.GetValue (0).ToString ());				
					}
					SqlDTRed.Close();
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Slip_Entry.aspx,Method:page_load().  EXCEPTION: "+ ex.Message+ " User_ID "+uid);
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
			this.dropslipID.SelectedIndexChanged += new System.EventHandler(this.dropslipID_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Update.Click += new System.EventHandler(this.Update_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{  
			MasterClass  obj=new MasterClass();
			SqlDataReader rdr=null;
			try
			{
				if(Int32.Parse(txtStartNo.Text.ToString())>Int32.Parse(txtEndNo.Text.ToString()))
				{
					MessageBox.Show("Slip No. To Should be greater than Slip No. From");
					txtStartNo.Text=slipEnd.ToString();
					return;
				}
				int slip_Start=0,slip_End=0;
				if(txtStartNo.Text.ToString()!="")
					slip_Start=Int32.Parse(txtStartNo.Text.ToString());
				if(slipEnd.ToString()!="")
					slip_End=Int32.Parse(slipEnd.ToString());
				dbobj.SelectQuery("select * from slip where start_No>='"+ txtStartNo.Text  +"' and End_No<='"+ txtEndNo.Text +"' or Start_No between '"+ txtStartNo.Text +"' and '"+ txtEndNo.Text +"' or End_No between '"+ txtStartNo.Text +"' and '"+ txtEndNo.Text+"'",ref rdr);
				if(rdr.Read())
				{
					//if(slip_Start<slip_End)
					//{
					//MessageBox.Show("Slip No. Upto "+slip_End+" already Used");
					MessageBox.Show("Start Slip No. "+txtStartNo.Text+" and End Slip No. "+txtEndNo.Text+" already Used");
					Clear();
					txtStartNo.Text=slip_End.ToString();
					return ;
					//}
				}
				string sql1="select Slip_Book_Id  from slip where Book_No='"+txtBookNo.Text.ToString ()+"'";
				string sb_id="";
				dbobj.SelectQuery(sql1,"Slip_Book_ID",ref sb_id);
				if(!sb_id.Equals(""))
				{
					MessageBox.Show("Slip Book No. "+ txtBookNo.Text.ToString ()+" is already used");
					Clear();
					txtStartNo.Text=slipEnd.ToString();
					return;
				}
				string[] arr=DropCustID.SelectedItem.Text.Split(new char[]{':'},DropCustID.SelectedItem.Text.Length);  
				string sql="";
				sql="select Cust_ID from Customer where Cust_Name='"+arr[0]+"' and City='"+arr[1]+"'";
				string ID="";
				dbobj.SelectQuery(sql,"Cust_ID",ref ID);				
				obj.Slip_Book_ID = lblSlipBookID.Text.ToString();
				obj.Book_No=txtBookNo.Text.ToString ();
				obj.Start_No=txtStartNo.Text.ToString();
				obj.End_No=txtEndNo .Text .ToString();
				obj.Cust_ID=ID;
				obj.InsertSlip_Book();
				Save();
				RMG.MessageBox.Show("Slip details Saved");
				Clear();
				CreateLogFiles.ErrorLog("Form:Slip_Entry.aspx,Method:btnUpdate_Click"+ " Custmer id "+obj.Cust_ID  +"  Sleep book id  "+ obj.Slip_Book_ID +"  book no  "+ obj.Book_No +"  start no  "+  obj.Start_No+" end no "+ obj.End_No +" IS SAVED "+"   user id "+uid);
				GetNextSlipBookID();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Slip_Entry.aspx,Method:btnUpdate_Click"+ " Custmer id "+obj.Cust_ID  +"  Sleep book id  "+ obj.Slip_Book_ID +"  book no  "+ obj.Book_No +"  start no  "+  obj.Start_No+" end no "+ obj.End_No + " IS SAVED   "+" EXEPTION  "+ex.Message+"  userid  "+uid);
			}
		}

		// For Report
		private string GetString(string str,string spc)
		{
			if(str.Length>spc.Length)
				return str;
			else
				return str+spc.Substring(0,spc.Length-str.Length)+"  ";			
		}
		
		//private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2)
		private void getMaxLen(System.Data.SqlClient.SqlDataReader rdr,ref int len1,ref int len2,ref int len3,ref int len4,ref int len5,ref int len6)
		{
			while(rdr.Read())
			{
				if(rdr["BookID"].ToString().Trim().Length>len1)
					len1=rdr["BookID"].ToString().Trim().Length;					
				if(rdr["Book_No"].ToString().Trim().Length>len2)
					len2=rdr["Book_No"].ToString().Trim().Length;					
				if(rdr["Start_No"].ToString().Trim().Length>len3)
					len3=rdr["Start_No"].ToString().Trim().Length;					
				if(rdr["End_No"].ToString().Trim().Length>len4)
					len4=rdr["End_No"].ToString().Trim().Length;	
				if(rdr["TotalSlip"].ToString().Trim().Length>len5)
					len5=rdr["TotalSlip"].ToString().Trim().Length;	
				if(rdr["Cust_Name"].ToString().Trim().Length>len6)
					len6=rdr["Cust_Name"].ToString().Trim().Length;	
			}

		}

		private string GetString(string str,int maxlen,string spc)
		{		
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
		}

		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
		}
		// End Report
		
		/// <summary>
		/// This method is used to save the slip details.
		/// </summary>
		public void Save()
		{
			string[] arr=DropCustID.SelectedItem.Text.Split(new char[]{':'},DropCustID.SelectedItem.Text.Length);  
			string sql="";
			sql="select Cust_ID from Customer where Cust_Name='"+arr[0]+"' and City='"+arr[1]+"'";
			string ID="";
			dbobj.SelectQuery(sql,"Cust_ID",ref ID);	

			MasterClass  obj=new MasterClass();
			SqlConnection conMyData;
			string  strInsert;
			SqlCommand cmdInsert;
			conMyData = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"] );
			strInsert = "Insert SlipReport(BookID,Book_No,Start_No,End_No,TotalSlip,Cust_Name)Values(@BookID,@Book_No,@Start_No,@End_No,@TotalSlip,@Cust_Name)";
			cmdInsert = new SqlCommand( strInsert, conMyData );
			conMyData.Open();
			cmdInsert.Parameters.Add( "@BookID", lblSlipBookID.Text.ToString());
			cmdInsert.Parameters.Add( "@Book_No", txtBookNo.Text.ToString() );
			cmdInsert.Parameters.Add( "@Start_No", txtStartNo.Text.ToString());
			cmdInsert.Parameters.Add( "@End_No", txtEndNo.Text.ToString());
			cmdInsert.Parameters.Add( "@TotalSlip", txtTotalSlips.Text.ToString());
			cmdInsert.Parameters.Add( "@Cust_Name",DropCustID.SelectedItem.Value.ToString());
			cmdInsert.ExecuteNonQuery();
			conMyData.Close();
		}

		/// <summary>
		/// This method is used to clear the form.
		/// </summary>
		public void Clear()
		{
			txtBookNo.Text="";
			txtStartNo.Text="";
			txtEndNo.Text="";
			txtTotalSlips.Text="";
			DropCustID.SelectedIndex=0;
			Button1.Visible=true;
		}
		
		/// <summary>
		/// This method is used to return the next slipbookid from the database.
		/// </summary>
		public void GetNextSlipBookID()
		{
			PartiesClass  obj=new PartiesClass();
			SqlDataReader SqlDTRed;
			string sql;

			#region Get Next Slip Book ID and Slip No.
			sql="select max(Slip_Book_ID)+1,max(End_No)+1 from Slip";
			SqlDTRed=obj.GetRecordSet(sql) ;
			while(SqlDTRed.Read())
			{
				lblSlipBookID.Text =SqlDTRed.GetSqlValue(0).ToString ();
				slipEnd=SqlDTRed.GetSqlValue(1).ToString();
				if (lblSlipBookID.Text =="Null")
					lblSlipBookID.Text ="1001";
				if(slipEnd=="Null" || slipEnd.Equals(""))
				{
					txtStartNo.Text="1";
					slipEnd="1";
				}
			}	
			SqlDTRed.Close();
			txtStartNo.Text=slipEnd.ToString();
			#endregion
		}
		
		/// <summary>
		/// This method is used to retrieve the all slip id in the combobox from the database.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			Clear();
			Button1.Visible=false;
			Label1.Visible=true;
			txtTotalSlips.Visible=true; 
			btnUpdate .Visible=false;
			Update.Visible=true;
			dropslipID.Items.Clear();
			dropslipID.Items.Add("Select") ;
			if(Page.IsPostBack)
			{
				dropslipID.Visible=true;
				dropslipID.SelectedIndex=0;
				lblSlipBookID.Visible=false; 
			}
			if(Page.IsPostBack)
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string sql;
				sql="select Slip_Book_ID from Slip ";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					dropslipID.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close ();	
			}
		}
		
		/// <summary>
		/// This method is used to Display slip details according to selected ID.
		/// </summary>
		private void dropslipID_SelectedIndexChanged(object sender, System.EventArgs e)
		{   
			dropslipID.Visible=true; 
			Update.Visible=true;
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
			if(dropslipID.SelectedValue.Equals("Select"))
			{
				Clear();
			}
			try
			{
				sql="select s.Book_No,s.Start_No,s.End_No,c.Cust_Name+':'+c.City from Slip s,Customer c where s.Slip_Book_ID='"+ dropslipID.SelectedItem.Value +"' and s.Cust_ID=c.Cust_ID";
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					txtBookNo.Text=SqlDtr.GetValue(0).ToString();  
					bookNo=SqlDtr.GetValue(0).ToString(); 
					txtStartNo.Text=SqlDtr.GetValue(1).ToString();
					txtEndNo.Text=SqlDtr.GetValue(2).ToString();
					txtTotalSlips.Text=System.Convert.ToString((System.Convert.ToInt32(txtEndNo.Text.ToString())-(System.Convert.ToInt32(txtStartNo.Text.ToString())-1)));
					DropCustID.SelectedIndex=(DropCustID .Items.IndexOf((DropCustID .Items.FindByValue(SqlDtr.GetValue(3).ToString()))));
				}
				SqlDtr.Close();
				CreateLogFiles.ErrorLog("Form:Slip_Entry.aspx,Method:print, Slip Entry  updated for sleepbook id"+ txtBookNo.Text    +"   userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Slip_Entry.aspx,Method:print, Slip Entry  updated for sleepbook id"+ txtBookNo.Text  +"     EXCEPTION:"+ex.Message+"   userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to update the slip entry
		/// </summary>
		private void Update_Click(object sender, System.EventArgs e)
		{   
			if(dropslipID.SelectedIndex == 0)
			{
				MessageBox.Show("Please Select The Slip No");
				return;
			}
			if(Int32.Parse(txtStartNo.Text.ToString())>Int32.Parse(txtEndNo.Text.ToString()))
			{
				MessageBox.Show("Slip No. To Should be greater than Slip No. From");
				dropslipID.Visible=true;
				Update.Visible=true;
				return;
			}
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader rdr=null;
			//int slip_Start=0,slip_End=0;
			//if(txtStartNo.Text.ToString()!="")
			//	slip_Start=Int32.Parse(txtStartNo.Text.ToString());
			//if(slipEnd.ToString()!="")
			//	slip_End=Int32.Parse(slipEnd.ToString());
			dbobj.SelectQuery("select * from slip where Slip_Book_ID<>'"+dropslipID.SelectedItem.Text+"' and (start_No>='"+ txtStartNo.Text  +"' and End_No<='"+ txtEndNo.Text +"' or Start_No between '"+ txtStartNo.Text +"' and '"+ txtEndNo.Text +"' or End_No between '"+ txtStartNo.Text +"' and '"+ txtEndNo.Text+"')",ref rdr);
			if(rdr.Read())
			{
				MessageBox.Show("Start Slip No. "+txtStartNo.Text+" and End Slip No. "+txtEndNo.Text+" already Used");
				//Clear();
				//txtStartNo.Text=slip_End.ToString();
				return ;
			}
			string sql1="select Slip_Book_Id  from slip where Book_No='"+txtBookNo.Text.ToString ()+"' and Book_No!='"+bookNo+"'";
			string sb_id="";
			dbobj.SelectQuery(sql1,"Slip_Book_ID",ref sb_id);
			if(!sb_id.Equals(""))
			{
				MessageBox.Show("Slip Book Name  "+ txtBookNo.Text.ToString ()+" is already used");
				dropslipID.Visible=true;
				return;
			}
			SqlDataReader SqlDtr;
			string	slipStart="";
			//string	slipEnd="";
			int slip_id=Int32.Parse(dropslipID.SelectedItem.Value.ToString()); 
			int a =slip_id-1;
			int b=slip_id+1;
			string sql4="";
			sql4="select end_no=(select   end_no from slip where slip_book_id="+a+"),  start_no=(select start_no from slip where slip_book_id="+b+") from slip";
			SqlDtr=obj.GetRecordSet(sql4); 
			while(SqlDtr.Read())
			{
				slipStart=SqlDtr.GetValue(1).ToString();  
				slipEnd=SqlDtr.GetValue(0).ToString();
			}
			SqlDtr.Close();
			if(slipStart.Equals("") || slipStart==null)
			{
				slipStart="0";
			}
			if(slipEnd.Equals("") || slipEnd==null)
			{
				slipEnd="0";
			}
			/*
			if(Int32.Parse(txtStartNo.Text.ToString())<= Int32.Parse(slipEnd.ToString()))
			{
				slipEnd=System.Convert.ToString(Int32.Parse(slipEnd)+1);
				MessageBox.Show("Slip No. should not be less than "+slipEnd);
				dropslipID.Visible=true;
				Update.Visible=true;
				return;
			}
			if(Int32.Parse(txtEndNo.Text.ToString()) >= Int32.Parse(slipStart.ToString()) && Int32.Parse(slipStart.ToString())!=0 )
			{
				MessageBox.Show("Slip No. should not greater than "+slipStart.ToString());
				dropslipID.Visible=true;
				Update.Visible=true;
				return ;
			}
			*/
			string[] arr=DropCustID.SelectedItem.Text.Split(new char[]{':'},DropCustID.SelectedItem.Text.Length);  
			string sql="";
			sql="select Cust_ID from Customer where Cust_Name='"+arr[0]+"' and City='"+arr[1]+"'";
			string ID="";
			dbobj.SelectQuery(sql,"Cust_ID",ref ID);	
			SqlConnection conMyData;
			string  strInsert;
			SqlCommand cmdInsert;
			//
			// Add Uploaded file to database
			conMyData = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"] );
			strInsert = "update Slip set Book_No=@Book_No,Start_No=@Start_No,End_No=@End_No,Cust_ID=@Cust_ID where Slip_Book_ID='"+ dropslipID.SelectedItem.Value+"'";
			cmdInsert = new SqlCommand( strInsert, conMyData );
			conMyData .Open();
			cmdInsert.Parameters.Add( "@Book_No",txtBookNo.Text.ToString());
			cmdInsert.Parameters.Add( "@Start_No",txtStartNo.Text.ToString());
			cmdInsert.Parameters.Add( "@End_No", txtEndNo.Text.ToString());
			cmdInsert.Parameters.Add( "@Cust_ID", ID);
			cmdInsert.ExecuteNonQuery();
			Clear();
			GetNextSlipBookID();
			RMG.MessageBox.Show("Slip Updated ");
			conMyData.Close();
			Label1.Visible=true;
			txtTotalSlips.Visible=true; 
			lblSlipBookID.Visible=true;
			dropslipID.Visible=false;
			btnUpdate.Visible=true;
			Update.Visible=false;
			dropslipID.Items.Clear();
			Button1.Visible=true;
		}
	}
}