<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Page language="c#" Codebehind="SalesBook_PrintPreview.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.SalesBook_PrintPreview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Sales Book Report Print Preview</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="278" width="778" align=center>
				<TR>
					<TH style="HEIGHT: 4px" align="center">
						<font color="#006400"><U>Sales Book Report From
								<%=Session["From_Date"].ToString()%>
								To
								<%=Session["To_Date"].ToString()%>
							</U></font>
					</TH>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<TABLE id="Table1" cellSpacing="0" border="1" bordercolor="darkseagreen" cellpadding="0">
							<TR>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Customer<br>
											ID</font> </STRONG>
								</TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Customer Name</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Place</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Customer<br>
											Category</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Invoice<br>
											No.</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Invoice<br>
											Date</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Under Salesman</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Package<br>
											Type</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Product Name</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Quantity<br>
											in<br>
											No's/Lit's</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Price</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Discount<br>
											(if any)</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Promo Scheme</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Credit<br>
											Days</font></STRONG></TD>
								<TD align="center" bgcolor="#009900"><STRONG><font color="#f7f7f7">Due Date</font></STRONG></TD>
							</TR>
							<%
								DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
								 SqlDataReader SqlDtr = null;
								 if(Cache["SalesBook"]=="")
									Cache["SalesBook"]="Cust_Name";
								// string order_by = Session["Order_By"].ToString();
								 dbobj.SelectQuery("select * from vw_SaleBook where cast(floor(cast(invoice_date as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(Session["From_Date"].ToString())+"' and cast(floor(cast(invoice_date as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(Session["To_Date"].ToString())+"' order by "+Cache["SalesBook"]+"",ref SqlDtr);
								 while(SqlDtr.Read())
								 {								    
								%>
							<TR>
								<TD><font color="#4a3c8c"><%=SqlDtr["Cust_ID"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Cust_Name"].ToString().Equals("")?"&nbsp":SqlDtr["Cust_Name"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["City"].ToString().Equals("")?"&nbsp":SqlDtr["City"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Cust_Type"].ToString().Equals("")?"&nbsp":SqlDtr["Cust_Type"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Invoice_no"].ToString().Equals("")?"&nbsp":SqlDtr["Invoice_No"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["Invoice_date"].ToString().Equals("")?"&nbsp":SqlDtr["Invoice_date"].ToString()))%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Under_Salesman"].ToString().Equals("")?"&nbsp":SqlDtr["Under_Salesman"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Pack_type"].ToString().Equals("")?"&nbsp":SqlDtr["Pack_Type"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Prod_name"].ToString().Equals("")?"&nbsp":SqlDtr["Prod_Name"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Qty"].ToString().Equals("")?"&nbsp":SqlDtr["Qty"].ToString()%></font></TD>
								<TD align="right"><font color="#4a3c8c"><%=GenUtil.strNumericFormat(SqlDtr["Rate"].ToString().Equals("")?"&nbsp":SqlDtr["Rate"].ToString())%></font></TD>
								<TD align="center"><font color="#4a3c8c"><%=SqlDtr["Discount"].ToString().Equals("")?"&nbsp":SqlDtr["Discount"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Promo_Scheme"].ToString().Equals("")?"&nbsp":SqlDtr["Promo_Scheme"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=SqlDtr["Cr_Days"].ToString().Equals("")?"&nbsp":SqlDtr["Cr_Days"].ToString()%></font></TD>
								<TD><font color="#4a3c8c"><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["Due_Date"].ToString().Equals("")?"&nbsp":SqlDtr["Due_Date"].ToString()))%></font></TD>
							</TR>
							<%
							    }
							    SqlDtr.Close();
							
							%>
						</TABLE>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
		</form>
	</body>
</HTML>
