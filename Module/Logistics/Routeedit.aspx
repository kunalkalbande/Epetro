<%@ Page language="c#" Codebehind="Routeedit.aspx.cs" AutoEventWireup="false" Inherits="Epetro.Form.Logistics.Routeedit" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Route Insertion</title> <!--
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
		<form id="Routeedit" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center" valign="top">
						<FONT color="#006400">Route&nbsp;Master</FONT>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE style="WIDTH: 331px" cellpadding="0" cellspacing="0">
							<TBODY>
								<TR>
									<TD id="r1" style="HEIGHT: 21px">Route Id</TD>
									<TD style="HEIGHT: 21px"><asp:Label id="lblRouteid" runat="server"></asp:Label><asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True" Width="170px" Visible="False"
											CssClass="FontStyle"></asp:dropdownlist>
										<FONT face="Arial" size="2"></FONT>
									</TD>
								</TR>
								<TR>
									<TD id="r2">Route Name <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtrname" ErrorMessage="Please Select Route Name"><font color="red">*</font></asp:requiredfieldvalidator></TD>
									<TD><asp:textbox id="txtrname" runat="server" Width="170px" CssClass="FontStyle" MaxLength="49"></asp:textbox><FONT face="Arial" size="2"></FONT></TD>
								</TR>
								<TR>
									<TD id="r3">Route KM</TD>
									<TD><asp:textbox id="txtrkm" runat="server" Width="170px" CssClass="FontStyle" MaxLength="15"></asp:textbox><FONT face="Arial" size="2"></FONT></TD>
								</TR>
								<tr>
									<td colspan="2">&nbsp;</td>
								</tr>
								<TR>
									<TD align="center" colSpan="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="Button1" runat="server" Width="65px" Text="Add "></asp:button>&nbsp;&nbsp;
                                        <asp:button id="btnsave" runat="server" Width="65px" Text="Edit"></asp:button>
                                        <asp:button id="btnEdit" runat="server" Width="65px" Text="Edit"></asp:button>&nbsp;&nbsp;
                                        <asp:button id="btnDel" runat="server" Text="Delete" Width="65px"></asp:button></TD>
								</TR>
								<tr>
									<td vAlign="middle" align="center" colSpan="2"></td>
								</tr>
							</TBODY>
						</TABLE>
						<P><asp:validationsummary id="vsRoute" runat="server" Width="158px" ShowMessageBox="True" ShowSummary="False"
								Height="32px"></asp:validationsummary></P>
						<P>&nbsp;</P>
					<td></td>
				</tr>
				<tr>
					<td colSpan="1"></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
