<%@ Page language="c#" Codebehind="CustomerVehicleEntry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Parties.CustomerVehicleEntry" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Customer Vehicle Entry</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Shift_Entry" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:TextBox>
			<table height="288" width="778" align="center" border=0>
				<TR>
					<TH align="center">
						<font color="#006400">Customer Vehicle&nbsp;Entry</font>
						<hr>
					</TH>
				</TR>
				<TR>
					<td align="center">
						<TABLE style="WIDTH: 512px" cellpadding="0" cellspacing="0" border=0>
							<TR>
								<TD colSpan="1"><FONT color="black">CVE ID :</FONT></TD>
								<TD colSpan="3"><FONT color="#ff0000">
										<asp:Label id="lblID" runat="server" Width="52px" ForeColor="Blue"></asp:Label>
										<asp:DropDownList id="DropID" runat="server" Visible="False" AutoPostBack="True" CssClass="FontStyle">
											<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
										</asp:DropDownList>
										<asp:Button id="btnEdit" runat="server" Text="..." ToolTip="Click here to edit" CausesValidation="False"></asp:Button></FONT></TD>
							</TR>
							<tr>
								<td colspan="4">&nbsp;</td>
							</tr>
							<TR>
								<TD>Customer Name :</TD>
								<TD colspan="3">
									<asp:dropdownlist id="DropCustomerName" runat="server" Width="234px" CssClass="FontStyle" AutoPostBack="True">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Please Select Customer Name"
										ControlToValidate="DropCustomerName" Operator="NotEqual" ValueToCompare="Select"><font color="red">*</font></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>Vehicle No. 1&nbsp;</TD>
								<TD><asp:textbox id="txtVehicle1" runat="server" BorderStyle="Groove" CssClass="FontStyle" MaxLength="20"></asp:textbox></TD>
								<TD>Vehicle No. 2&nbsp;</TD>
								<TD><asp:textbox id="txtVehicle2" runat="server" BorderStyle="Groove" CssClass="FontStyle" MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Vehicle No. 3</TD>
								<TD><asp:textbox id="txtVehicle3" runat="server" BorderStyle="Groove" MaxLength="20" CssClass="FontStyle"></asp:textbox></TD>
								<TD>Vehicle No. 4</TD>
								<TD><asp:textbox id="txtVehicle4" runat="server" BorderStyle="Groove" CssClass="FontStyle" MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Vehicle No. 5</TD>
								<TD>
									<asp:textbox id="txtVehicle5" runat="server" BorderStyle="Groove" MaxLength="20" CssClass="FontStyle"></asp:textbox></TD>
								<TD>Vehicle No.&nbsp;6&nbsp;</TD>
								<TD><asp:textbox id="txtVehicle6" runat="server" BorderStyle="Groove" CssClass="FontStyle" MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Vehicle No. 7</TD>
								<TD>
									<asp:textbox id="txtVehicle7" runat="server" BorderStyle="Groove" MaxLength="20" CssClass="FontStyle"></asp:textbox></TD>
								<TD>Vehicle No.&nbsp;8&nbsp;</TD>
								<TD><asp:textbox id="txtVehicle8" runat="server" BorderStyle="Groove" CssClass="FontStyle" MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Vehicle No. 9</TD>
								<TD>
									<asp:textbox id="txtVehicle9" runat="server" BorderStyle="Groove" MaxLength="20" CssClass="FontStyle"></asp:textbox></TD>
								<TD>Vehicle No. 10&nbsp;</TD>
								<TD><asp:textbox id="txtVehicle10" runat="server" BorderStyle="Groove" CssClass="FontStyle" MaxLength="20"></asp:textbox></TD>
							</TR>
							<tr>
								<td colspan="4">&nbsp;</td>
							</tr>
							<TR>
								<TD align="center" colSpan="4">
									<asp:button id="btnSave" runat="server" Width="70px" Text="Save" ></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id="btnUpdate" runat="server" Width="70px" Text="Edit"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id="btnDelete" runat="server" Text="Delete" Width="70px" ></asp:Button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" Height="4px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</TR>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
