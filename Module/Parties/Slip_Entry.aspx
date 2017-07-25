<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Slip_Entry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Master.Slip_Entry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Slip Entry</title> <!--
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
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="clientEventHandlersJS">
<!--
function calc()
{
	document.Form1.txtTotalSlips.value=eval(document.Form1.txtEndNo.value)-(eval(document.Form1.txtStartNo.value)-1)
}
function window_onblur() {

}

//-->
		</script>
</HEAD>
	<body language="javascript" onBlur="return window_onblur()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR valign="top" height="20">
					<TH align="center">
						<font color="#006400">Slip Entry</font>
						<hr>
					</TH>
				</TR>
				<tr valign="top">
					<td align="center">
						<TABLE style="WIDTH: 351px" cellspacing="0" cellpadding="0">
							<TR>
								<TD align="center" colSpan="4"><asp:label id="lblMessage" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>Slip Book&nbsp;ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD style="WIDTH: 171px"><asp:label id="lblSlipBookID" runat="server" Width="56px" ForeColor="Blue" Height="1px"></asp:label><asp:dropdownlist id="dropslipID" runat="server" Width="105px" AutoPostBack="True" CssClass="FontStyle">
<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:button id="Button1" runat="server" Width="20px" Text="..." ForeColor="White" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button></TD>
								<TD colSpan="2"></TD>
							</TR>
							<TR>
								<TD>Book No</TD>
								<TD style="WIDTH: 171px"><asp:textbox id="txtBookNo" runat="server" Width="105px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
								<TD colSpan="2"></TD>
							</TR>
							<TR>
								<TD>Slip&nbsp;No&nbsp; From
								</TD>
								<TD style="WIDTH: 171px"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtStartNo" runat="server"
										Width="104px" BorderStyle="Groove" CssClass="FontStyle"></asp:textbox></TD>
								<td>To</td>
								<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtEndNo" runat="server"
										Width="50px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="8"></asp:textbox></td>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label1" runat="server">No. of Slips</asp:label></TD>
								<TD style="WIDTH: 171px"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtTotalSlips"
										runat="server" Width="104px" BorderStyle="Groove" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
								<TD colSpan="2"></TD>
							</TR>
							<TR>
								<TD>Customer&nbsp;Name</TD>
								<TD colSpan="3"><asp:dropdownlist id="DropCustID" runat="server" Width="250px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<TR>
								<TD align="right" colSpan="4">
									<asp:button id="Update" runat="server" Text="Update" CausesValidation="False" Width="70px" ForeColor="White"
										BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button><asp:button id="btnUpdate" runat="server" Width="70px" Text="Save " ForeColor="White" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
