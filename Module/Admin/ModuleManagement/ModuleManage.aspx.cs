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
using DBOperations;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPetro.Sysitem.Classes;
using RMG;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Admin.ModuleManagement
{
	/// <summary>
	/// Summary description for ModuleManage.
	/// </summary>
	public class ModuleManage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnUpdate;
		string uid;
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);

		/// <summary>
		/// Put user code to initialize the page here
		/// This method is used for setting the Session variable for userId
		/// and also check accessing priviledges for particular user
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{				
				CreateLogFiles.ErrorLog("Form:ModuleManage.aspx,Method:pageload"+ ex.Message+"  EXCEPTION "+"   "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to update the all Ledger balance of AccountsLedgerTable and CustomerLedgerTable in sequencialy.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			InventoryClass obj = new InventoryClass();
			InventoryClass obj1 = new InventoryClass();
			SqlCommand cmd;
			int Flag=0;
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			SqlDataReader rdr1=null,rdr=null;
			string str="select Prod_ID from Products";
			rdr=obj.GetRecordSet(str);
			while(rdr.Read())
			{
				string str1="select * from Stock_Master where Productid='"+rdr["Prod_ID"].ToString()+"' order by Stock_date";
				rdr1=obj1.GetRecordSet(str1);
				double OS=0,CS=0,k=0;
				while(rdr1.Read())
				{
					Flag=1;
					if(k==0)
					{
						OS=double.Parse(rdr1["opening_stock"].ToString());
						k++;
					}
					else
						OS=CS;
					CS=OS+double.Parse(rdr1["receipt"].ToString())-double.Parse(rdr1["sales"].ToString());
					Con.Open();
					cmd = new SqlCommand("update Stock_Master set opening_stock='"+OS.ToString()+"', Closing_Stock='"+CS.ToString()+"' where ProductID='"+rdr1["Productid"].ToString()+"' and Stock_Date='"+rdr1["stock_date"].ToString()+"'",Con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					Con.Close();
				}
				rdr1.Close();
			}
			rdr.Close();
			//**************
			//SqlDataReader rdr=null;
			//SqlCommand cmd;
			//SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["EPetro"]);
			//dbobj.SelectQuery("select * from AccountsLedgerTable where Ledger_ID=(select Ledger_ID from Ledger_Master where sub_grp_id=118 and Ledger_Name='Cash') order by entry_date",ref rdr);
			dbobj.SelectQuery("select Ledger_ID from Ledger_Master",ref rdr1);
			while(rdr1.Read())
			{
				dbobj.SelectQuery("select * from AccountsLedgerTable where Ledger_ID='"+rdr1["Ledger_ID"].ToString()+"' order by entry_date",ref rdr);
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
			rdr.Close();
			//****************
			if(Flag==1)
				MessageBox.Show("Stock Variation Updated Successfully");
		}
	}
}