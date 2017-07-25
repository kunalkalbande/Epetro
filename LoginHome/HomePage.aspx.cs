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
using EPetro.Sysitem.Classes ;

namespace EPetro.LoginHome
{
	/// <summary>
	/// Summary description for HomePage.
	/// </summary>
	public class HomePage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink Hyperlink38;
		protected System.Web.UI.WebControls.HyperLink Hyperlink30;
		protected System.Web.UI.WebControls.HyperLink Hyperlink22;
		protected System.Web.UI.WebControls.HyperLink Hyperlink25;
		protected System.Web.UI.WebControls.HyperLink HyperLink13;
		protected System.Web.UI.WebControls.HyperLink Hyperlink39;
		protected System.Web.UI.WebControls.HyperLink Hyperlink28;
		protected System.Web.UI.WebControls.HyperLink Hyperlink20;
		protected System.Web.UI.WebControls.HyperLink Hyperlink24;
		protected System.Web.UI.WebControls.HyperLink HyperLink15;
		protected System.Web.UI.WebControls.HyperLink Hyperlink35;
		protected System.Web.UI.WebControls.HyperLink Hyperlink27;
		protected System.Web.UI.WebControls.HyperLink Hyperlink18;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		protected System.Web.UI.WebControls.HyperLink Hyperlink11;
		protected System.Web.UI.WebControls.HyperLink Hyperlink34;
		protected System.Web.UI.WebControls.HyperLink Hyperlink26;
		protected System.Web.UI.WebControls.HyperLink Hyperlink17;
		protected System.Web.UI.WebControls.HyperLink HyperLink3;
		protected System.Web.UI.WebControls.HyperLink Hyperlink41;
		protected System.Web.UI.WebControls.HyperLink Hyperlink33;
		protected System.Web.UI.WebControls.HyperLink HyperLink4;
		protected System.Web.UI.WebControls.HyperLink Hyperlink32;
		protected System.Web.UI.WebControls.HyperLink Hyperlink10;
		protected System.Web.UI.WebControls.HyperLink HyperLink5;
		protected System.Web.UI.WebControls.HyperLink Hyperlink31;
		protected System.Web.UI.WebControls.HyperLink Hyperlink7;
		protected System.Web.UI.WebControls.HyperLink HyperLink12;
		protected System.Web.UI.WebControls.HyperLink Hyperlink29;
		protected System.Web.UI.WebControls.HyperLink Hyperlink8;
		protected System.Web.UI.WebControls.HyperLink Hyperlink14;
		protected System.Web.UI.WebControls.HyperLink Hyperlink46;
		protected System.Web.UI.WebControls.HyperLink Hyperlink37;
		protected System.Web.UI.WebControls.HyperLink Hyperlink9;
		protected System.Web.UI.WebControls.HyperLink HyperLink6;
		protected System.Web.UI.WebControls.HyperLink Hyperlink44;
		protected System.Web.UI.WebControls.HyperLink Hyperlink47;
		protected System.Web.UI.WebControls.HyperLink Hyperlink42;
		protected System.Web.UI.WebControls.HyperLink Hyperlink43;
		protected System.Web.UI.WebControls.HyperLink Hyperlink441;
		protected System.Web.UI.WebControls.HyperLink Hyperlink36;
		protected System.Web.UI.WebControls.HyperLink Hyperlink48;
		protected System.Web.UI.WebControls.HyperLink HyperLink49;
		protected System.Web.UI.WebControls.HyperLink Hyperlink45;
		protected System.Web.UI.WebControls.Label lblMessaeg;
		protected System.Web.UI.WebControls.HyperLink Hyperlink60;
		protected System.Web.UI.WebControls.HyperLink Hyperlink52;
		protected System.Web.UI.WebControls.HyperLink HyperLink51;
		protected System.Web.UI.WebControls.HyperLink Hyperlink21;
		protected System.Web.UI.WebControls.HyperLink Hyperlink40;
		protected System.Web.UI.WebControls.HyperLink HyperLink53;
		protected System.Web.UI.WebControls.HyperLink Hyperlink54;
		protected System.Web.UI.WebControls.HyperLink Hyperlink55;
		protected System.Web.UI.WebControls.HyperLink Hyperlink58;
		protected System.Web.UI.WebControls.HyperLink Hyperlink59;
		protected System.Web.UI.WebControls.HyperLink Hyperlink61;
		protected System.Web.UI.WebControls.HyperLink Hyperlink62;
		protected System.Web.UI.WebControls.HyperLink HyperLink63;
		protected System.Web.UI.WebControls.HyperLink HyperLink64;
		protected System.Web.UI.WebControls.HyperLink Hyperlink65;
		protected System.Web.UI.WebControls.HyperLink Hyperlink50;
		protected System.Web.UI.WebControls.HyperLink Hyperlink57;
		protected System.Web.UI.WebControls.HyperLink Hyperlink56;
		protected System.Web.UI.WebControls.HyperLink Hyperlink66;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink23;
		protected System.Web.UI.WebControls.HyperLink Hyperlink19;
		protected System.Web.UI.WebControls.HyperLink Hyperlink67;
		protected System.Web.UI.WebControls.HyperLink HyperLink68;
		protected System.Web.UI.WebControls.HyperLink Hyperlink49;
		protected System.Web.UI.WebControls.HyperLink Hyperlink69;
		protected System.Web.UI.WebControls.HyperLink Hyperlink16;
		protected System.Web.UI.WebControls.HyperLink Hyperlink70;
		protected System.Web.UI.WebControls.HyperLink Hyperlink71;
		protected System.Web.UI.WebControls.HyperLink Hyperlink72;
		protected System.Web.UI.WebControls.HyperLink Hyperlink75;
		protected System.Web.UI.WebControls.HyperLink Hyperlink73;
		protected System.Web.UI.WebControls.HyperLink Hyperlink74;
		protected System.Web.UI.WebControls.HyperLink Hyperlink76;
		protected System.Web.UI.WebControls.HyperLink Hyperlink77;
		protected System.Web.UI.WebControls.HyperLink Hyperlink78;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Subhan: The block of code commented to increase the performance of a project and to decrease the page loading time of home page on windows xp and windows 2000 professional.
			//			if(Cache["view"]!=null)
			//			{
			//				try
			//				{
			//					if((bool)Cache["view"]==false&&Session["User_Name"].ToString().Length<=0)
			//					{
			//						Session.Abandon();
			//						Session.RemoveAll();
			//						Cache.Remove("view");
			//						Response.Redirect(@".\errorpage.aspx",false);
			//					}
			//					else
			//					{
			//						Response.Buffer=false;
			//						Response.CacheControl="no-cache";
			//						Response.Expires=System.DateTime.Now.Minute-1;	
			//						Cache["view"]=false;
			//					}
			//				
			//				CreateLogFiles.ErrorLog("Form:Homepage.aspx,Method:Page_Load  ");
			//				}
			//				catch(System.NullReferenceException)
			//				{
			//					Session.Abandon();
			//					CreateLogFiles.ErrorLog("Form:Homepage.aspx,Method:Page_Load,   EXCEPTION     System.NullReferenceException   ");
			//					Response.Redirect(@".\errorpage.aspx",false);
			//					return;
			//				}
			//				
			//			}
			//			else
			//			{
			//				Response.Buffer=false;
			//				Response.CacheControl="no-cache";
			//				Response.Expires=System.DateTime.Now.Minute-1;
			//				Cache["view"]=false;
			//			}	
			// Subhan
			try
			{
				if(!Page.IsPostBack)
				{
					uid=(Session["User_Name"].ToString ());
					//uid=(Cache["User_Name"].ToString ());
					//**Session["User_Name"]=(Cache["User_Name"].ToString ());
					//**Session["Privileges"]=Cache["Privileges"];
				}
				//string ss=Session["User_Name"].ToString();
				CreateLogFiles.ErrorLog("Form:Homepage.aspx,Method:Page_Load,  userid  "+uid );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Homepage.aspx,Method:Page_Load,   EXCEPTION "+ex.Message+"  userid  "+uid );
				Response.Redirect("ErrorPage.aspx",false);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
	}
}