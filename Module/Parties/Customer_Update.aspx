<%@ Page language="c#" Codebehind="Customer_Update.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Parties.Customer_Update_aspx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Customer Update</title> <!--
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
		<script language="javascript" id="Validation" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox><asp:TextBox id="txtbeatname" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 16px"
				name="txtbeatname" runat="server" Width="1" Height="1"></asp:TextBox><asp:textbox id="TempCustName" Width="1" Height="1" Runat="server"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Update Customer</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE cellpadding="0" cellspacing="0">
							<!--TR>
								<TD colSpan="4"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR-->
							<TR>
								<TD>Customer ID</TD>
								<TD colSpan="2"><asp:label id="LblCustomerID" Width="97px" ForeColor="Blue" Runat="server"></asp:label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Name</TD>
								<TD colSpan="2">
									<asp:TextBox id="lblName" runat="server" Width="180px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Type&nbsp; <FONT color="#ff0000">*</FONT>
									<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropCustType" ErrorMessage="Please Select Customer Type"
										ValueToCompare="Select" Operator="NotEqual">*</asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropCustType" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Contractor">Contractor</asp:ListItem>
										<asp:ListItem Value="Fleet">Fleet</asp:ListItem>
										<asp:ListItem Value="General">General</asp:ListItem>
										<asp:ListItem Value="Goverment">Goverment</asp:ListItem>
										<asp:ListItem Value="Key Customers">Key Customers</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>Tin No.<asp:regularexpressionvalidator id="Regularexpressionvalidator7" runat="server" ControlToValidate="txtTinNo" ErrorMessage="Invalid Tin No"
										ValidationExpression="\d{11}">*</asp:regularexpressionvalidator></TD>
								<TD>
									<asp:textbox id="txtTinNo" runat="server" Width="130px" BorderStyle="Groove" Height="24" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>City&nbsp; <FONT color="#ff0000">*</FONT>
									<asp:comparevalidator id="CompareValidator2" runat="server" ControlToValidate="DropCity" ErrorMessage="Please Select City"
										ValueToCompare="Select" Operator="NotEqual">*</asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropCity" runat="server" Width="130px" onChange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>Phone No(Res.)
									<asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ControlToValidate="txtPhoneRes"
										ErrorMessage="Contact No. Between 6-12 Digits" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="txtPhoneRes" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>State</TD>
								<TD><asp:dropdownlist id="DropState" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>Phone No(Off.)
									<asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" ControlToValidate="txtPhoneOff"
										ErrorMessage="Contact No. Between 6-12 Digits" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="txtPhoneOff" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Country</TD>
								<TD><asp:dropdownlist id="DropCountry" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>Mobile No
									<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile No. Between 10-12 Digits"
										ValidationExpression="\d{10,12}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="txtMobile" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Address</TD>
								<TD colSpan="3"><asp:textbox id="txtAddress" runat="server" Width="180px" MaxLength="99" BorderStyle="Groove"
										TextMode="MultiLine" Font-Names="Arial" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>E - Mail&nbsp;
									<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtEMail" ErrorMessage="Please Fill Valid E-mail"
										ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:regularexpressionvalidator>&nbsp;</TD>
								<TD colSpan="3"><asp:textbox id="txtEMail" runat="server" Width="180px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Credit Limit&nbsp;
									<asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" ControlToValidate="txtCRLimit" ErrorMessage="Credit Limit Should be Correct"
										ValidationExpression="(\d+\.\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="txtCRLimit" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										CssClass="FontStyle" MaxLength="10"></asp:textbox></TD>
								<TD>Credit Days</TD>
								<TD><asp:dropdownlist id="DropCrDay" Width="72px" Runat="server" CssClass="FontStyle">
										<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Op. Balance&nbsp;
									<asp:regularexpressionvalidator id="RegularExpressionValidator5" runat="server" ControlToValidate="txtOpBalance"
										ErrorMessage="Opening Balance Should be Correct" ValidationExpression="(\d+\.\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="txtOpBalance" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										CssClass="FontStyle" MaxLength="10"></asp:textbox></TD>
								<TD><asp:dropdownlist id="DropBal" Runat="server" CssClass="FontStyle">
										<asp:ListItem Value="Cr.">Cr.</asp:ListItem>
										<asp:ListItem Value="Dr.">Dr.</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD align="right"><asp:button id="btnUpdate" runat="server" Width="80px" Text="Update" ></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
