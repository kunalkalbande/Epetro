<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="User_Profile.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Admin.User_Profile" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: User Profile</title> <!--
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
		<!--<script language="javascript" id="Validations" src="Validations.js"></script>-->
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .auto-style1 {
                height: 7px;
            }
        </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center" border="0">
				<TR valign="top">
					<TH align="center">
						<font color="#006400">User Profile</font><hr>
					</TH>
				</TR>
				<tr valign="top">
					<td align="center">
						<TABLE cellpadding="0" cellspacing="0">
							<TR>
								<TD>User&nbsp;ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD colSpan="3">
									<asp:dropdownlist id="dropUserID" runat="server" Width="130px" AutoPostBack="True" Visible="False"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>
									<asp:label id="lblUserID" Runat="server" ForeColor="Blue" Width="100px"></asp:label>
									<asp:button id="btnEdit" runat="server" Width="25px" Text="..." ToolTip="Click For Edit" CausesValidation="False"
										ForeColor="White" BackColor="ForestGreen" BorderColor="DarkSeaGreen"></asp:button></TD>
							</TR>
							<TR>
								<TD class="auto-style1"></TD>
								<TD colSpan="3" class="auto-style1">
									</TD>
							</TR>
							<TR>
								<TD>Login Name&nbsp;
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" display="Dynamic" runat="server" ErrorMessage="Please Fill the Login Name"
										ControlToValidate="txtLoginName"><font color="red">*</font></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD>
									<asp:textbox id="txtLoginName" runat="server" Width="130px" BorderStyle="Groove" MaxLength="49"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Password                                 
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" display="Dynamic" runat="server" ErrorMessage="Please Fill the Password"
										ControlToValidate="txtPassword"><font color="red">*</font></asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword"
										ErrorMessage="Password length Minimum 5 Maximum 30 characters allowed" ValidationExpression="\w{5,30}"><font color="red">*</font></asp:RegularExpressionValidator></TD>
								<TD>
									<asp:textbox id="txtPassword" runat="server" TextMode="Password" Width="130px" BorderStyle="Groove"
										MaxLength="30" CssClass="FontStyle"></asp:textbox></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4"></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD align="center">First Name</TD>
								<TD>Middle Name</TD>
								<TD align="center">Last Name</TD>
							</TR>
							<TR>
								<TD>Name
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="Please Fill the User Name"
										ControlToValidate="txtFName"><font color="red">*</font></asp:RequiredFieldValidator></TD>
								<TD><asp:textbox id="txtFName" runat="server" Width="130px" BorderStyle="Groove" MaxLength="30" CssClass="FontStyle"></asp:textbox></TD>
								<TD><asp:textbox id="txtMName" runat="server" Width="59px" BorderStyle="Groove" MaxLength="10" CssClass="FontStyle"></asp:textbox></TD>
								<TD><asp:textbox id="txtLName" runat="server" Width="130px" BorderStyle="Groove" MaxLength="10" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Role&nbsp;
									<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Please Select the Role Name"
										ControlToValidate="DropRole" Operator="NotEqual" ValueToCompare="Select"><font color="red">*</font></asp:CompareValidator></TD>
								<TD colspan="2"><asp:dropdownlist id="DropRole" runat="server" Width="192px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="4">
									&nbsp;</TD>
							</TR>
							<TR>
								<TD align="right" colSpan="4">
									<asp:button id="btnUpdate" runat="server" Width="90px" Text="Save Profile" ForeColor="White"
										BackColor="ForestGreen" BorderColor="DarkSeaGreen"></asp:button>
									<asp:button id="btnDelete" runat="server" Width="70px" Text="Delete" CausesValidation="False"
										ForeColor="White" BackColor="ForestGreen" BorderColor="DarkSeaGreen"></asp:button></TD>
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
