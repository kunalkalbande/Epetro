<%@ Page language="c#" Codebehind="Employee_Entry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Employee.Employee_Entry" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Employee Entry</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="Beat" src="../../Sysitem/Js/Beat.js"></script>
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	/*	function checkDriver(t)
		{
		var index = t.selectedIndex;
		var value = t.options[index].text;
		alert(value);
		if(value == "Driver")
		{
		alert("if")
		document.Form1. txtLicenseNo.style.visibility = "hidden";
		document.Form1. txtLicenseValidity.style.visibility = "hidden";
		document.Form1. Label1.style.visibility = "hidden";
		
		}
		
		}*/
		
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="txtbeatname" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 16px"
				runat="server" name="txtbeatname" Width="1" Height="1"></asp:textbox>
			<table height="288" cellSpacing="0" cellPadding="0" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Employee Entry</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE style="WIDTH: 539px" cellSpacing="0" cellPadding="0" border="0">
							<!--TR>
								<TD colSpan="4"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR-->
							<TR>
								<TD style="WIDTH: 164px">Employee ID</TD>
								<TD style="WIDTH: 142px"><asp:label id="LblEmployeeID" Width="120px" ForeColor="Blue" Runat="server"></asp:label></TD>
								<TD style="WIDTH: 145px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px"></TD>
								<TD style="WIDTH: 142px">First Name</TD>
								<TD style="WIDTH: 145px">Middle Name</TD>
								<TD>Last Name</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px">Name&nbsp; 
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName" ErrorMessage="Please Fill Employee Name"><font color="red">*</font></asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 142px"><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtFName" runat="server" Width="130px"
										BorderStyle="Groove" MaxLength="30" CssClass="FontStyle"></asp:textbox></TD>
								<TD style="WIDTH: 145px"><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtMName" runat="server" Width="130px"
										BorderStyle="Groove" MaxLength="10" CssClass="FontStyle"></asp:textbox></TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtLName" runat="server" Width="130px"
										BorderStyle="Groove" MaxLength="10" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px">Address</TD>
								<TD style="WIDTH: 281px" colSpan="2"><asp:textbox id="txtAddress" runat="server" Width="271px" Height="20" BorderStyle="Groove" TextMode="MultiLine"
										Font-Names="Arial" CssClass="FontStyle" MaxLength="99"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px">City&nbsp; 
									<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropCity" ErrorMessage="Please Select City"
										ValueToCompare="Select" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropCity" runat="server" Width="130px" onChange="getBeatInfo(this,document.all.DropState,document.all.DropCountry);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									Contact No
									<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactNo"
										ErrorMessage="Contact No. Between 6-12 Digits" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event);" id="txtContactNo" runat="server"
										Width="130px" BorderStyle="Groove" MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px">State</TD>
								<TD><asp:dropdownlist id="DropState" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									Mobile No
									<asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile No. Between 10-12 Digits"
										ValidationExpression="\d{10,12}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event);" id="txtMobile" runat="server" Width="130px"
										BorderStyle="Groove" MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							<tr>
								<td style="WIDTH: 164px">Country</td>
								<TD><asp:dropdownlist id="DropCountry" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD></TD>
								<TD></TD>
							</tr>
							<TR>
								<TD style="WIDTH: 164px">E - Mail&nbsp;&nbsp;
									<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtEMail" ErrorMessage="Please Type Valid E-Mail"
										ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:regularexpressionvalidator></TD>
								<TD style="WIDTH: 281px" colSpan="2"><asp:textbox id="txtEMail" runat="server" Width="271px" BorderStyle="Groove" MaxLength="50" CssClass="FontStyle"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px">Designation
									<asp:comparevalidator id="CompareValidator5" runat="server" ControlToValidate="DropDesig" ErrorMessage="Please Select Designation"
										ValueToCompare="Select" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator></TD>
								<TD style="WIDTH: 281px" colSpan="2"><asp:dropdownlist id="DropDesig" runat="server" Width="165px" AutoPostBack="True" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
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
									</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Op. Balance</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtopbal" runat="server"
										Width="90px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="10"></asp:textbox><asp:dropdownlist id="DropType" runat="server" Width="39px" CssClass="FontStyle">
										<asp:ListItem Value="Dr">Dr</asp:ListItem>
										<asp:ListItem Value="Cr">Cr</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD vAlign="middle"><asp:label id="lblDrLicense" runat="server" Width="95px" Height="25px" Font-Size="8pt">Driving License No.</asp:label></TD>
								<TD><asp:textbox id="txtLicenseNo" runat="server" Width="130px" BorderStyle="Groove" MaxLength="12"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD align="center"><asp:label id="lblLicenseVali" runat="server" Font-Size="8pt">Validity In</asp:label></TD>
								<TD><asp:textbox id="txtLicenseValidity" runat="server" Width="130px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 164px"><asp:label id="lblLICPolicy" runat="server" Width="99px" Height="25px" Font-Size="8pt">Driver LIC Policy No.</asp:label></TD>
								<TD><asp:textbox id="txtLICNo" runat="server" Width="130px" BorderStyle="Groove" MaxLength="12" CssClass="FontStyle"></asp:textbox></TD>
								<TD align="center"><FONT color="#ff0000"><asp:label id="lblLICValid" runat="server" ForeColor="Black" Font-Size="8pt">Validity In</asp:label></FONT></TD>
								<TD><asp:textbox id="txtLICvalidity" runat="server" Width="130px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblVehicleNo" runat="server" Font-Size="8pt">Vehicle No</asp:label></TD>
								<TD><asp:dropdownlist id="DropVehicleNo" runat="server" Width="133px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
							<TR>
								<td></td>
								<TD colSpan="2"><asp:textbox id="txtOther" Width="270px" Runat="server" BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Salary&nbsp; 
									<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtSalary" ErrorMessage="Please Fill Salary of Employee"><font color="red">*</font></asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 142px"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtSalary" runat="server"
										Width="130px" BorderStyle="Groove" MaxLength="10" CssClass="FontStyle"></asp:textbox></TD>
								<TD style="WIDTH: 145px">OT Compensation<FONT color="#ff0000"> &nbsp;&nbsp;Rs./ Hour </FONT>
								</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOT_Comp" runat="server"
										Width="130px" BorderStyle="Groove" MaxLength="8" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="4"><asp:button id="btnUpdate" runat="server" Width="95px" ForeColor="White" Text="Save Profile"
										BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" Height="4px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
