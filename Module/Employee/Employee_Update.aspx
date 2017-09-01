<%@ Page language="c#" Codebehind="Employee_Update.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Employee.Employee_Update" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Employee Update</title> <!--
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
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="txtbeatname" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 16px"
				runat="server" Height="1" Width="1" name="txtbeatname"></asp:textbox><asp:textbox id="TempCustName" Width="1" Height="1" Runat="server"></asp:textbox>
			<table height="288" cellSpacing="0" cellPadding="0" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Update Employee</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE style="WIDTH: 587px" cellSpacing="0" cellPadding="0">
							<!--TR>
								<TD colSpan="4"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR-->
							<TR>
								<TD style="WIDTH: 132px">Employee ID&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD colSpan="2"><asp:label id="LblEmployeeID" Width="132px" Runat="server" ForeColor="Blue"></asp:label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px">Name</TD>
								<TD colSpan="2">
									<asp:TextBox id="lblName" runat="server" Width="250px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px">Address</TD>
								<TD colSpan="3"><asp:textbox id="txtAddress" runat="server" Height="23px" Width="439px" Font-Names="Arial" TextMode="MultiLine"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="99"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px">E - Mail&nbsp;
									<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
										ControlToValidate="txtEMail" ErrorMessage="Please Type Valid E-Mail">*</asp:regularexpressionvalidator></TD>
								<TD colSpan="2"><asp:textbox id="txtEMail" runat="server" Width="273px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px">City&nbsp; <FONT color="#ff0000">*</FONT>
									<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropCity" ErrorMessage="Please Select City"
										ValueToCompare="Select" Operator="NotEqual">*</asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropCity" runat="server" Width="130px" onChange="getBeatInfo(this,document.Form1.DropState,document.Form1.DropCountry);"
										CssClass="FontStyle"></asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Contact No
									<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ValidationExpression="\d{6,12}"
										ControlToValidate="txtContactNo" ErrorMessage="Contact No. Between 6-12 Digits">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event);" id="txtContactNo" runat="server"
										Width="131px" BorderStyle="Groove" MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px">State&nbsp;</TD>
								<TD><asp:dropdownlist id="DropState" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mobile 
									No
									<asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ValidationExpression="\d{10,12}"
										ControlToValidate="txtMobile" ErrorMessage="mobile no between 10-12 digits">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event);" id="txtMobile" runat="server" Width="132px"
										BorderStyle="Groove" MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px">Country&nbsp;</TD>
								<TD><asp:dropdownlist id="DropCountry" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px">Designation&nbsp; <FONT color="#ff0000">*</FONT>
									<asp:comparevalidator id="CompareValidator5" runat="server" ControlToValidate="DropDesig" ErrorMessage="Please Select Designation"
										ValueToCompare="Select" Operator="NotEqual">*</asp:comparevalidator><FONT color="red"></FONT></TD>
								<TD><asp:dropdownlist id="DropDesig" runat="server" Width="180px" AutoPostBack="True" CssClass="FontStyle">
										<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
										<asp:ListItem Value="Accountant">Accountant</asp:ListItem>
										<asp:ListItem Value="Cash Collection Boy">Cash Collection Boy</asp:ListItem>
										<asp:ListItem Value="Cleaner">Cleaner</asp:ListItem>
										<asp:ListItem Value="Driver">Driver</asp:ListItem>
										<asp:ListItem Value="Filling Boy">Filling Boy</asp:ListItem>
										<asp:ListItem Value="Helper">Helper</asp:ListItem>
										<asp:ListItem Value="Manager">Manager</asp:ListItem>
										<asp:ListItem Value="Marshal">Marshal</asp:ListItem>
										<asp:ListItem Value="Peon">Peon</asp:ListItem>
										<asp:ListItem Value="Sales Man">Sales Man</asp:ListItem>
										<asp:ListItem Value="Security Guard">Security Guard</asp:ListItem>
										<asp:ListItem Value="Service Center Employee">Service Center Employee</asp:ListItem>
										<asp:ListItem Value="Other">Other</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp; OT Compensation
									<asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" ControlToValidate="txtOT_Comp" ErrorMessage="Please Fill OT Compensation">*</asp:requiredfieldvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOT_Comp" runat="server"
										Width="130px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="8"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px"><asp:label id="lblDrLicense" runat="server" Height="12px" Width="93px" Font-Size="8pt">Driving License No.</asp:label></TD>
								<TD><asp:textbox id="txtLicenseNo" runat="server" Width="130px" BorderStyle="Groove" MaxLength="12"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD align="center"><asp:label id="lblLicenseVali" runat="server" Font-Size="8pt">Validity In</asp:label></TD>
								<TD><asp:textbox id="txtLicenseValidity" runat="server" Width="130px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px"><asp:label id="lblLICPolicy" runat="server" Height="6px" Width="98px" Font-Size="8pt">Driver LIC Policy No.</asp:label></TD>
								<TD><asp:textbox id="txtLICNo" runat="server" Width="130px" BorderStyle="Groove" MaxLength="12" CssClass="FontStyle"></asp:textbox></TD>
								<TD align="center"><FONT color="#ff0000"><asp:label id="lblLICValid" runat="server" ForeColor="Black" Font-Size="8pt">Validity In</asp:label></FONT></TD>
								<TD><asp:textbox id="txtLICvalidity" runat="server" Width="130px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px; HEIGHT: 13px"><asp:label id="lblVehicleNo" runat="server" Font-Size="8pt">Vehicle No</asp:label></TD>
								<TD style="HEIGHT: 13px"><asp:dropdownlist id="DropVehicleNo" runat="server" Width="133px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 13px"></TD>
								<TD style="HEIGHT: 13px"></TD>
							</TR>
							<TR>
								<td></td>
								<TD colspan="2"><asp:TextBox Runat="server" ID="txtOther" Width="270px" BorderStyle="Groove" CssClass="FontStyle"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 132px">Salary &nbsp; <FONT color="#ff0000">*</FONT>
									<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtSalary" ErrorMessage="Please Fill Salary of Employee">*</asp:requiredfieldvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtSalary" runat="server"
										Width="131px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="10"></asp:textbox></TD>
								<TD align="center">Op. Balance</TD>
								<TD><asp:textbox id="txtopbal" runat="server" Width="90px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										CssClass="FontStyle"></asp:textbox><asp:dropdownlist id="DropType" runat="server" Width="39px" CssClass="FontStyle">
										<asp:ListItem Value="Dr">Dr</asp:ListItem>
										<asp:ListItem Value="Cr">Cr</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="4"><asp:button id="btnUpdate" runat="server" Width="110px"  Text="Update Profile"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" Height="4px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
