<%@ Page language="c#" Codebehind="BeatMaster_Entry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Parties.BeatMaster_Entry" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: BeatMaster Entry</title> <!--
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
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<script language="javascript">
		function  check1()
		{
		alert("hello");
		return false;
		}
		</script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR>
					<TH style="HEIGHT: 54px" align="center">
						<font color="#006400">Beat&nbsp;Entry</font>
						<hr>
					</TD></TR>
				<tr>
					<td align="center">
						<TABLE style="WIDTH: 252px" cellpadding="0" cellspacing="0">
							<TR>
								<TD colSpan="2"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 33px">Beat No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD style="HEIGHT: 33px"><asp:label id="lblBeatNo" runat="server" Width="152px" ForeColor="Blue"></asp:label><br>
									<asp:dropdownlist id="DropBeatNo" runat="server" Width="160px" Visible="False" AutoPostBack="True"
										CssClass="FontStyle"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>City&nbsp; 
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill City" ControlToValidate="txtCity"><font color="red">*</font></asp:requiredfieldvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtCity" runat="server" Width="160px"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>State</TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtState" runat="server" Width="160px"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Country&nbsp;</TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtCountry" runat="server" Width="160px"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2">
									<HR width="100%" color="#000099" SIZE="1">
									<asp:button id="btnSave" runat="server" Width="60px" Text="Add" CausesValidation="true"></asp:button>&nbsp;
                                    <asp:button id="btnEdit" runat="server" Width="60px" Text="Edit" CausesValidation="False"></asp:button>
                                    <asp:button id="Edit1" runat="server" Width="61px" Text="Edit" ></asp:button>&nbsp;
                                    <asp:button id="btnDelete" runat="server" Width="60px" Text="Delete" CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
