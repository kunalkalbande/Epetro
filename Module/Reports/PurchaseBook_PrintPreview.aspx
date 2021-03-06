<%@ Page language="c#" Codebehind="PurchaseBook_PrintPreview.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.PurchaseBook_PrintPreview" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Import namespace="DBOperations"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Purchase Book Report Print Preview</title> <!--
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
						<font color="006400"><U>Purchase&nbsp;Book Report From
								<%=Session["From_Date"].ToString()%>
								To
								<%=Session["To_Date"].ToString()%>
							</U></font>
					</TH>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<TABLE id="Table1" cellSpacing="0" border="1">
							<TR>
								<!--TD align="center"><STRONG>Vendor<br>
										ID </STRONG>
								</TD-->
								<TD align="center"><STRONG>Vendor&nbsp;Name</STRONG></TD>
								<TD align="center"><STRONG>Place</STRONG></TD>
								<TD align="center"><STRONG>Vendor<br>
										Type</STRONG></TD>
								<TD align="center"><STRONG>Invoice<br>
										No.</STRONG></TD>
								<TD align="center"><STRONG>Invoice<br>
										Date</STRONG></TD>
								<TD align="center"><STRONG>Product<br>
										Type</STRONG></TD>
								<TD align="center"><STRONG>Product Name</STRONG></TD>
								<TD align="center"><STRONG>Quantity<br>
										in Lit's</STRONG></TD>
								<TD align="center"><STRONG>Price</STRONG></TD>
								<TD align="center"><STRONG>Discount<br>
										(if any)</STRONG></TD>
								<TD align="center"><STRONG>Invoice<br>Amount</STRONG></TD>
								<TD align="center"><STRONG>Credit<br>
										Days</STRONG></TD>
								<TD align="center"><STRONG>Due Date</STRONG></TD>
							</TR>
							<%
								DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
								 SqlDataReader SqlDtr = null;
								 if(Cache["PurchaseBook"]=="")
								 Cache["PurchaseBook"]="Vendor_ID";
								// string order_by = Session["Order_By"].ToString();
								 dbobj.SelectQuery("(select * from vw_PurchaseBook1 where cast(floor(cast(invoice_date as float)) as datetime) >=  '"+ GenUtil.str2MMDDYYYY(Session["From_Date"].ToString()) +"' and cast(floor(cast(invoice_date as float)) as datetime) <= '"+ GenUtil.str2MMDDYYYY(Session["To_Date"].ToString())+"') union (select * from vw_PurchaseBook2 where cast(floor(cast(invoice_date as float)) as datetime) >= '"+ GenUtil.str2MMDDYYYY(Session["From_Date"].ToString()) +"' and cast(floor(cast(invoice_date as float)) as datetime)<= '"+ GenUtil.str2MMDDYYYY(Session["To_Date"].ToString())+"') order by "+Cache["PurchaseBook"]+"",ref SqlDtr);
								while(SqlDtr.Read())
								 {								    
								%>
							<TR>
								<!--TD><%=SqlDtr["vendor_ID"].ToString()%></TD-->
								<TD><%=SqlDtr["Vendor_Name"].ToString().Equals("")?"&nbsp":SqlDtr["Vendor_Name"].ToString()%></TD>
								<TD><%=SqlDtr["Place"].ToString().Equals("")?"&nbsp":SqlDtr["Place"].ToString()%></TD>
								<TD><%=SqlDtr["Vendor_Type"].ToString().Equals("")?"&nbsp":SqlDtr["Vendor_Type"].ToString()%></TD>
								<TD><%=SqlDtr["Invoice_no"].ToString().Equals("")?"&nbsp":SqlDtr["Invoice_No"].ToString()%></TD>
								<TD><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["Invoice_date"].ToString().Equals("")?"&nbsp":SqlDtr["Invoice_date"].ToString()))%></TD>
								<TD><%=SqlDtr["Prod_type"].ToString().Equals("")?"&nbsp":SqlDtr["Prod_Type"].ToString()%></TD>
								<TD><%=SqlDtr["Prod_name"].ToString().Equals("")?"&nbsp":SqlDtr["Prod_Name"].ToString()%></TD>
								<!--TD><%=SqlDtr["Qty"].ToString().Equals("")?"&nbsp":SqlDtr["Qty"].ToString()%></TD-->
								<td align=right><%=GenUtil.strNumericFormat((Multiply(SqlDtr["Prod_Type"].ToString()+"X"+SqlDtr["Prod_Name"].ToString()+"X"+SqlDtr["Qty"].ToString())).ToString())%></td>
								<TD align="right"><%=GenUtil.strNumericFormat(SqlDtr["Price"].ToString().Equals("")?"&nbsp":SqlDtr["Price"].ToString())%></TD>
								<TD align="center"><%=SqlDtr["Discount"].ToString().Equals("")?"&nbsp":SqlDtr["Discount"].ToString()%></TD>
								<!--TD align="center"><%=Cache["totinv_no"]%></TD-->
								<td align=right><%=GenUtil.strNumericFormat((Multiply1(SqlDtr["Price"].ToString(),SqlDtr["Qty"].ToString())).ToString())%></td>
								<TD align=right><%=SqlDtr["Cr_Days"].ToString().Equals("")?"&nbsp":SqlDtr["Cr_Days"].ToString()%></TD>
								<TD><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["DueDate"].ToString().Equals("")?"&nbsp":SqlDtr["DueDate"].ToString()))%></TD>
							</TR>
							<%
							    }
							    SqlDtr.Close();
							
							%>
							<tr>
							<td align=center><strong>Total</strong></td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td align=right><strong><%=GenUtil.strNumericFormat(Cache["os"].ToString())%></strong></td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td align=right><strong><%=GenUtil.strNumericFormat(Cache["amt"].ToString())%></strong></td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							</tr>
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
