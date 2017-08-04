<%@ Page language="c#" Codebehind="NozzleEntry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.PetrolPump.NozzleEntry" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Nozzle Entry</title> <!--
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
		<script language="javascript" id="Beat" src="../../Sysitem/Js/Beat.js"></script>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><INPUT id="TxtVen" style="Z-INDEX: 218; LEFT: -528px; POSITION: absolute; TOP: -24px" type="text"
				name="TxtVen" runat="server">
			<table height="288" width="778" align="center">
				<TR valign="top">
					<TH align="center">
						<font color="#006400">Nozzle&nbsp;Entry</font>
						<hr>
					</TH>
				</TR>
				<tr valign="top">
					<td align="center">
						<TABLE style="WIDTH: 306px">
							<TR>
								<TD colSpan="2"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD align="left" style="HEIGHT: 28px">Nozzle&nbsp;ID<font color="red">*</font></TD>
								<TD style="HEIGHT: 28px"><asp:label id="lblNozzleID" runat="server" ForeColor="Purple" Width="112px"></asp:label><br>
									<asp:dropdownlist id="DropNozzleID" runat="server" Width="164px" Visible="False" AutoPostBack="True"
										CssClass="FontStyle">
										<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:CompareValidator id="CompareValidator3" runat="server" ControlToValidate="DropNozzleID" ValueToCompare="Select"
										ErrorMessage="Please Select The Nozzle ID" Operator="NotEqual"><font color="red">*</font></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>Nozzle&nbsp;Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="lblNozzleName" runat="server" ForeColor="Purple" BorderStyle="None" Width="164px"
										 CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 14px">Machine Name<font color="red">*</font> 
									<asp:comparevalidator id="CompareValidator1" runat="server" Operator="NotEqual" ErrorMessage="Please Select Machine Name"
										ValueToCompare="Select" ControlToValidate="DropMachineID"><font color="red">*</font></asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropMachineID" runat="server" Width="200px" onChange="getNozzleNo(this,document.all.lblNozzleName);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Nozzle SortName</TD>
								<TD><asp:textbox id="txtsortname" runat="server" ForeColor="Black" Width="200px" CssClass="FontStyle"
										BorderStyle="Groove" MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Tank&nbsp;Name<font color="red">*</font> 
									<asp:comparevalidator id="CompareValidator2" runat="server" Operator="NotEqual" ErrorMessage="Please Select Tank Name"
										ValueToCompare="Select" ControlToValidate="DropTankID"><font color="red">*</font></asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropTankID" runat="server" Width="200px" CssClass="FontStyle">
										<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnSave" runat="server" ForeColor="White" Width="65px" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Add"></asp:button><asp:button id="btnEdit" runat="server" ForeColor="White" Width="65px" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Edit" CausesValidation="False"></asp:button><asp:button id="btnDelete" runat="server" ForeColor="White" Width="65px" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Delete" CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
