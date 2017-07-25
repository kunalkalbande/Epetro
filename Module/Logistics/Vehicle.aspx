<%@ Page language="c#" Codebehind="Vehicle.aspx.cs" AutoEventWireup="false" Inherits="Epetro.Form.Logistics.Vehicle" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Vehicle Category</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Vehicle" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="232" width="778" align="center">
				<TR>
					<TH align="center">
						<FONT color="#006400">Vehicle Category</FONT>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE style="WIDTH: 329px; HEIGHT: 93px">
							<TBODY>
								<TR>
									<TD style="WIDTH: 107px; HEIGHT: 24px">Vehicle Category
									</TD>
									<TD style="HEIGHT: 24px"><asp:dropdownlist id="Dropvech" runat="server" AutoPostBack="True" Width="104px" CssClass="FontStyle"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 107px; HEIGHT: 14px">Add New</TD>
									<TD style="HEIGHT: 14px"><asp:textbox id="txtveccategory" runat="server" Width="102px" CssClass="FontStyle"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnaddnew" runat="server" Width="58px" Text="Add  " BackColor="ForestGreen"
											BorderColor="ForestGreen" ForeColor="White"></asp:button><asp:button id="btnEdit" runat="server" Width="58px" Text="Edit" BackColor="ForestGreen" BorderColor="ForestGreen"
											ForeColor="White"></asp:button><asp:button id="btneditsave" runat="server" Text="Edit  " Width="58px" BackColor="ForestGreen"
											BorderColor="ForestGreen" ForeColor="White"></asp:button><asp:button id="btnDel" runat="server" Width="58px" Text="Delete" BackColor="ForestGreen" BorderColor="ForestGreen"
											ForeColor="White"></asp:button></TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
