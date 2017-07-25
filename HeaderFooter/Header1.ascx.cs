/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
namespace EPetro.HeaderFooter
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for Header1.
	/// </summary>
	public class Header1 : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink Logout;
		protected System.Web.UI.WebControls.Label lblDate;

		private void Page_Load(object sender, System.EventArgs e)
		{
			lblDate.Text=DateTime.Today.Day.ToString()+"."+DateTime.Today.Month.ToString()+"."+DateTime.Today.Year.ToString();
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
