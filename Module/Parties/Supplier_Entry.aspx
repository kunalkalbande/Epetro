<%@ Page language="c#" Codebehind="Supplier_Entry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Parties.Supplier_Entry" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<HTML>
  <HEAD>
		<title>ePetro: Vendor Entry</title> <!--
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
		<script language="javascript" id="Beat" src="../../Sysitem/Js/Beat.js"></script>
		<script id="Validations" language="javascript" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header><asp:TextBox id="txtbeatname" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 16px"
				name="txtbeatname" runat="server" Width="1" Height="1"></asp:TextBox>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:TextBox><table width="778" height="278" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Vendor&nbsp;Entry</font><hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE cellpadding="0" cellspacing="0">
							<!--TR>
								<TD colSpan="4"><FONT color="#ff0000">Fields Marked as (*) Are 
										Mandatory</FONT></TD>
							</TR-->
							<TR>
								<TD>Vendor ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:label id="lblSupplierID" Width="108px" ForeColor="Blue" Runat="server"></asp:label></TD>
								<TD></TD>
								<TD style="WIDTH: 127px"></TD>
							</TR>
							<TR>
								<TD>
								</TD>
								<TD>
									First Name</TD>
								<TD>
									<P>Middle&nbsp;Name</P>
								</TD>
								<TD style="WIDTH: 127px">
									Last Name</TD>
							</TR>
							<TR>
								<TD>
									Name&nbsp; 
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName" ErrorMessage="Please Fill Supplier Name"><font color="red">*</font></asp:RequiredFieldValidator></TD>
								<TD><asp:textbox id="txtFName" runat="server" Width="130px" onkeypress="return GetOnlyChars(this, event);"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="30"></asp:textbox></TD>
								<TD><asp:textbox id="txtMName" runat="server" Width="127px" onkeypress="return GetOnlyChars(this, event);"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="10"></asp:textbox></TD>
								<TD style="WIDTH: 127px"><asp:textbox id="txtLName" runat="server" Width="130px" onkeypress="return GetOnlyChars(this, event);"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									Type&nbsp;&nbsp; 
									<asp:CompareValidator id="CompareValidator1" runat="server" ControlToValidate="DropType" ErrorMessage="Please Select Customer Type"
										ValueToCompare="Select" Operator="NotEqual"><font color="red">*</font></asp:CompareValidator></TD>
								<TD><asp:dropdownlist id="DropType" runat="server" Width="132px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Fuel">Fuel</asp:ListItem>
										<asp:ListItem Value="Lubricants">Lubricants</asp:ListItem>
										<asp:ListItem Value="Misc.">Misc.</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tin 
									No. <asp:RequiredFieldValidator id="Requiredfieldvalidator3" runat="server" ControlToValidate="txtTinNo" ErrorMessage="Please Fill TinNo"><font color="red">*</font></asp:RequiredFieldValidator>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" ErrorMessage="Invalid Tin No" ControlToValidate="txtTinNo"
										ValidationExpression="\d{11}"><font color="red">*</font></asp:regularexpressionvalidator></TD>
								<TD style="WIDTH: 127px">
									<asp:textbox id="txtTinNo" runat="server" Width="130px" BorderStyle="Groove" MaxLength="11" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									City&nbsp;&nbsp; 
									<asp:CompareValidator id="CompareValidator2" runat="server" ControlToValidate="DropCity" ErrorMessage="Please Select City"
										ValueToCompare="Select" Operator="NotEqual"><font color="red">*</font></asp:CompareValidator></TD>
								<TD><asp:dropdownlist id="DropCity" runat="server" Width="130px" onChange="getBeatInfo(this,document.all.DropState,document.all.DropCountry);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone 
									No(Off.)
									<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
										ControlToValidate="txtPhoneOff" ValidationExpression="\d{6,10}">*</asp:RegularExpressionValidator></TD>
								<TD style="WIDTH: 127px">
									<asp:textbox id="txtPhoneOff" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									State&nbsp;</TD>
								<TD><asp:dropdownlist id="DropState" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone 
									No(Res.)
									<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="Contact No. Between 6-10 Digits"
										ControlToValidate="txtPhoneRes" ValidationExpression="\d{6,10}">*</asp:RegularExpressionValidator></TD>
								<TD style="WIDTH: 127px">
									<asp:textbox id="txtPhoneRes" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
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
									<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile No. Between 10-12 Digits"
										ControlToValidate="txtMobile" ValidationExpression="\d{10,12}">*</asp:RegularExpressionValidator></TD>
								<TD style="WIDTH: 127px">
									<asp:textbox id="txtMobile" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									Address</TD>
								<TD colSpan="3" style="WIDTH: 398px"><asp:textbox id="txtAddress" runat="server" Height="21px" Width="398px" TextMode="MultiLine"
										BorderStyle="Groove" Font-Names="Arial" CssClass="FontStyle" MaxLength="99"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									E - Mail&nbsp;
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtEMail" ErrorMessage="Please Fill Valid E-mail"
										ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></TD>
								<TD colSpan="2"><asp:textbox id="txtEMail" runat="server" Width="268px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
								<td style="WIDTH: 127px"></td>
							</TR>
							<TR>
								<TD>Op. Balance&nbsp;
									<asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ErrorMessage="Opening Balance Should be Correct"
										ControlToValidate="txtOpBalance" ValidationExpression="(\d+\.\d+)|(\d+)">*</asp:RegularExpressionValidator></TD>
								<TD><asp:textbox id="txtOpBalance" runat="server" Width="130px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										CssClass="FontStyle" MaxLength="10"></asp:textbox></TD>
								<TD>
									<asp:DropDownList id="DropBal" Runat="server" CssClass="FontStyle">
										<asp:ListItem Value="Cr.">Cr.</asp:ListItem>
										<asp:ListItem Value="Dr.">Dr.</asp:ListItem>
									</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Credit Days</TD>
								<TD style="WIDTH: 127px">
									<asp:dropdownlist id="DropCrDay" Runat="server" Width="72px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="21">21</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="45">45</asp:ListItem>
										<asp:ListItem Value="60">60</asp:ListItem>
										<asp:ListItem Value="75">75</asp:ListItem>
										<asp:ListItem Value="90">90</asp:ListItem>
										<asp:ListItem Value="120">120</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="right" style="WIDTH: 474px">
									<asp:button id="btnUpdate" runat="server" Width="95px" Text="Save Profile" ForeColor="White"
										BackColor="ForestGreen" BorderColor="ForestGreen" ></asp:button>
								</TD>
							</TR>
						</TABLE>
						<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
