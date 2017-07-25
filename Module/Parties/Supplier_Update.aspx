<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Supplier_Update.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Parties.Supplier_Update_aspx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Vendor Update</title> <!--
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
		<script language="javascript" id="Beat" src="../../Sysitem/Js/Beat.js"></script>
		<script id="Validations" language="javascript" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header><asp:TextBox id="txtbeatname" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 16px"
				name="txtbeatname" runat="server" Width="1" Height="1"></asp:TextBox><asp:textbox id="TempCustName" Width="1" Height="1" Runat="server"></asp:textbox>
			<table height="278" width="778" align="center">
				<asp:TextBox id="TextBox1" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
					Width="8px" Visible="False"></asp:TextBox></table>
			<table width="778" height="288" align="center">
				<TR>
					<TD></TD>
					<TH align="center">
						<font color="#006400">Update Vendor<hr>
						</font>
					</TH>
					<TD></TD>
				</TR>
				<tr>
					<td></td>
					<td align="center">
						<TABLE cellpadding="0" cellspacing="0">
							<!--TR>
								<TD colSpan="4"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR-->
							<TR>
								<TD>Vendor ID</TD>
								<TD colSpan="2"><asp:label id="lblSupplierID" Width="166px" ForeColor="Blue" Runat="server"></asp:label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									Name</TD>
								<TD colSpan="2">
									<asp:TextBox id="lblName" runat="server" Width="250px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									Type&nbsp;<FONT color="#ff0000">*</FONT>
									<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Please Select Customer Type"
										ControlToValidate="DropSuppType" Operator="NotEqual" ValueToCompare="Select">*</asp:CompareValidator></TD>
								<TD><asp:dropdownlist id="DropSuppType" runat="server" Width="132px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Fuel">Fuel</asp:ListItem>
										<asp:ListItem Value="Lubricants">Lubricants</asp:ListItem>
										<asp:ListItem Value="Misc.">Misc.</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tin 
									No.<asp:RegularExpressionValidator id="Regularexpressionvalidator6" runat="server" ControlToValidate="txtTinNo" ErrorMessage="Invalid Tin No"
										ValidationExpression="\d{11}">*</asp:RegularExpressionValidator></TD>
								<TD>
									<asp:textbox id="txtTinNo" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									City <FONT color="#ff0000">*</FONT> &nbsp;
									<asp:CompareValidator id="CompareValidator2" runat="server" ErrorMessage="Please Select City" ControlToValidate="DropCity"
										Operator="NotEqual" ValueToCompare="Select">*</asp:CompareValidator></TD>
								<TD><asp:dropdownlist id="DropCity" runat="server" Width="130px" onChange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select ">Select </asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone 
									No(Res.)
									<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ControlToValidate="txtPhoneRes"
										ErrorMessage="Contact No. Between 6-10 Digits" ValidationExpression="\d{6,10}">*</asp:RegularExpressionValidator></TD>
								<TD>
									<asp:textbox id="txtPhoneRes" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									State</TD>
								<TD><asp:dropdownlist id="DropState" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone 
									No(Off.)
									<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ControlToValidate="txtPhoneOff"
										ErrorMessage="Contact No. Between 6-10 Digits" ValidationExpression="\d{6,10}">*</asp:RegularExpressionValidator></TD>
								<TD>
									<asp:textbox id="txtPhoneOff" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									Country</TD>
								<TD><asp:dropdownlist id="DropCountry" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mobile 
									No
									<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile No. Between 6-10 Digits"
										ValidationExpression="\d{10,12}">*</asp:RegularExpressionValidator></TD>
								<TD>
									<asp:textbox id="txtMobile" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									Address</TD>
								<TD colSpan="3"><asp:textbox id="txtAddress" runat="server" Height="22px" Width="405px" TextMode="MultiLine"
										BorderStyle="Groove" Font-Name="Arial" CssClass="FontStyle" MaxLength="99"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									E - Mail&nbsp;
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Please Fill Valid E-mail"
										ControlToValidate="txtEMail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></TD>
								<TD colSpan="2"><asp:textbox id="txtEMail" runat="server" Width="268px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
								<td></td>
							</TR>
							<TR>
								<TD style="HEIGHT: 19px">Op. Balance&nbsp;
									<asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ControlToValidate="txtOpBalance"
										ErrorMessage="Opening Balance Should be Correct" ValidationExpression="(\d+\.\d+)|(\d+)">*</asp:RegularExpressionValidator></TD>
								<TD style="HEIGHT: 19px"><asp:textbox id="txtOpBalance" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										CssClass="FontStyle" MaxLength="10"></asp:textbox></TD>
								<TD style="HEIGHT: 19px">
									<asp:DropDownList id="DropBal" Runat="server" CssClass="FontStyle">
										<asp:ListItem Value="Cr.">Cr.</asp:ListItem>
										<asp:ListItem Value="Dr.">Dr.</asp:ListItem>
									</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Credit Days</TD>
								<TD style="HEIGHT: 19px">
									<asp:dropdownlist id="DropCrDay" Runat="server" Width="72px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="4">
									<asp:button id="btnUpdate" runat="server" Width="80px" Text="Update" ForeColor="White" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button>
								</TD>
							</TR>
						</TABLE>
						<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
					</td>
					<td></td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
