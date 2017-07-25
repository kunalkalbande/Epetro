<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="RMG"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="CustomerVehicleEntryReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.CustomerVehicleEntryReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Price List Report</title> <!--
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
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center" height="30">
						<font color="#006400">Customer Vehicle Entry Report</font>
						<hr>
					</TH>
				</TR>
				<tr height="20">
					<td align="center">Customer Name&nbsp;<asp:comparevalidator id="Comparevalidator1" runat="server" ValueToCompare="Select" Operator="NotEqual"	ErrorMessage="Please Select Customer Name" ControlToValidate="DropCustName">*</asp:comparevalidator>&nbsp;&nbsp;
						<asp:dropdownlist id="DropCustName" Runat="server" Width="200" CssClass="FontStyle"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;
						<asp:button id="Button1" runat="server" Width="70px" Text="View " BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="Btnprint" Runat="server" Width="70px" Text="Print  " BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnExcel" Runat="server" Width="70px" Text="Excel" BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:button>
					</td>
				</tr>
				<%
			if(DropCustName.SelectedIndex!=0)
			{
				int i=0;
				%>
				<tr>
					<td align="center">
						<TABLE id="Table1" borderColor="green" cellSpacing="0" width="100%" border="1">
							<tr bgColor="#009900">
								<td align="center" width="6%"><font color="#f7f7f7"><b>CVE ID</b></font></td>
								<td align="center" width="10%"><font color="#f7f7f7"><b><%=arr1[i].ToString()%></b></font></td>
								<td align="center" width="10%"><font color="#f7f7f7"><b><%=arr2[i].ToString()%></b></font></td>
								<td align="center" width="10%"><font color="#f7f7f7"><b><%=arr3[i].ToString()%></b></font></td>
								<td align="center" width="10%"><font color="#f7f7f7"><b><%=arr4[i].ToString()%></b></font></td>
								<td align="center" width="9%"><font color="#f7f7f7"><b><%=arr5[i].ToString()%></b></font></td>
								<td align="center" width="9%"><font color="#f7f7f7"><b><%=arr6[i].ToString()%></b></font></td>
								<td align="center" width="9%"><font color="#f7f7f7"><b><%=arr7[i].ToString()%></b></font></td>
								<td align="center" width="9%"><font color="#f7f7f7"><b><%=arr8[i].ToString()%></b></font></td>
								<td align="center" width="9%"><font color="#f7f7f7"><b><%=arr9[i].ToString()%></b></font></td>
								<td align="center" width="9%"><font color="#f7f7f7"><b><%=arr10[i].ToString()%></b></font></td>
								<%i++;%>
							</tr>
							<%
							
							while(i<=10)
							{
							%>
							<TR>
								<td align="center"><%=i.ToString()%></td>
								<td>&nbsp;<%=arr1[i].ToString()%></td>
								<td>&nbsp;<%=arr2[i].ToString()%></td>
								<td>&nbsp;<%=arr3[i].ToString()%></td>
								<td>&nbsp;<%=arr4[i].ToString()%></td>
								<td>&nbsp;<%=arr5[i].ToString()%></td>
								<td>&nbsp;<%=arr6[i].ToString()%></td>
								<td>&nbsp;<%=arr7[i].ToString()%></td>
								<td>&nbsp;<%=arr8[i].ToString()%></td>
								<td>&nbsp;<%=arr9[i].ToString()%></td>
								<td>&nbsp;<%=arr10[i].ToString()%></td>
								<%i++;%>
							</TR>
							<%}%>
						</TABLE>
						<%//}%>
					</td>
				</tr>
				<%}%>
				<tr>
					<td align="right"><A href="javascript:window.print()"></A>
					<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
