<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Shift_Asignment.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Employee.Shift_Asignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Shift Assignment</title> <!--
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
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Shift Assignment</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE cellpadding="5" cellspacing="5">
							<TR>
								<TD align="center" colSpan="3">Shift&nbsp;Name &nbsp; <FONT color="red">*&nbsp;&nbsp; </FONT>
									<asp:dropdownlist id="DropShiftID" runat="server" Width="150px" Height="20px" AutoPostBack="True" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvShiftName" runat="server" ValueToCompare="Select" Operator="NotEqual" ControlToValidate="DropShiftID"
										ErrorMessage="Please select the shift name">*</asp:comparevalidator><asp:textbox id="txtShiftTime" runat="server" Height="21px" Width="126px" BorderStyle="Groove" Enabled="False"
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD></TD>
								<TD align="center"></TD>
							</TR>
							<TR>
								<TD align="center"><FONT color="#000066" style="COLOR: #006400">Employees Available</FONT></TD>
								<TD><FONT color="#cc0033"></FONT></TD>
								<TD align="center"><FONT color="#000066" style="COLOR: #006400">Employees Assigned <FONT color="red">
											*</FONT></FONT></TD>
							</TR>
							<TR>
								<TD align="center"><asp:listbox id="ListEmpAvailable" runat="server" Width="180px" Height="160px" CssClass="FontStyle"></asp:listbox></TD>
								<TD align="center">
									<P><asp:button id="btnIn" runat="server" Width="50px" ToolTip="Move selected items from available employee list to employee assigned list"
											Font-Bold="True" Text=">" CausesValidation="False" BackColor="ForestGreen" BorderColor="ForestGreen"
											ForeColor="White"></asp:button></P>
									<P dir="ltr" align="justify"><asp:button id="btnout" runat="server" Width="50px" ToolTip="Move selected items from employee assigned list to available employee list "
											Font-Bold="True" Text="<" CausesValidation="False" BackColor="ForestGreen" BorderColor="ForestGreen" ForeColor="White"></asp:button></P>
									<P><asp:button id="btn1" runat="server" Width="50px" Height="25px" ToolTip="Move all items from available employee list to employee assigned list"
											Font-Bold="True" Text=">>" CausesValidation="False" BackColor="ForestGreen" BorderColor="ForestGreen"
											ForeColor="White"></asp:button></P>
								</TD>
								<TD align="center"><asp:listbox id="ListEmpAssigned" runat="server" Width="180px" Height="160px" CssClass="FontStyle"></asp:listbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3" style="HEIGHT: 10px">
									<asp:button id="btnSubmit" runat="server" Width="80px" Text="Submit" BackColor="ForestGreen"
										BorderColor="ForestGreen" ForeColor="White"></asp:button></TD>
							</TR>
							<TR>
								<TD colSpan="3"><asp:validationsummary id="vsShiftAssignment" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
