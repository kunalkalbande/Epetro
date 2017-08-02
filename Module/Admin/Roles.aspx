<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Roles.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Admin.Roles" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Roles</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" id="Validations" src="Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR valign="top">
					<TH align="center">
						<font color="#006400">Roles</font><hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE>
							<TR>
								<TD>Role&nbsp;ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD>
									<asp:dropdownlist id="dropRoleID" runat="server" Width="130px" AutoPostBack="True" Visible="False"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:label id="lblRoleID" ForeColor="Blue" Width="100px" Runat="server"></asp:label>
									<asp:button id="btnEdit" runat="server" Width="25px" Text="..." ToolTip="Click For Edit" CausesValidation="False"
										ForeColor="White" BackColor="ForestGreen" BorderColor="DarkSeaGreen"></asp:button></TD>
							</TR>
							<TR>
								<TD>Role Name<font color="red">*</font>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill the Role Name"
										ControlToValidate="txtRoleName"><font color="red">*</font></asp:RequiredFieldValidator></TD>
								<TD><asp:textbox id="txtRoleName" runat="server" Width="300px" BorderStyle="Groove" onkeypress="return GetOnlyChars(this, event);"
										MaxLength="49" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;</TD>
								<TD colSpan="2"><asp:textbox id="txtDesc" runat="server" Width="300px" BorderStyle="Groove" TextMode="MultiLine"
										CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="4">
									<asp:button id="btnUpdate" runat="server" Width="70px" Text="Save" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
										ForeColor="White"></asp:button>
									<asp:button id="btnDelete" runat="server" Width="70px" Text="Delete" CausesValidation="False"
										BackColor="ForestGreen" BorderColor="DarkSeaGreen" ForeColor="White"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
