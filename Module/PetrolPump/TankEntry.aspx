<%@ Page language="c#" Codebehind="TankEntry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.PetrolPump.TankEntry" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Tank Entry</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<script language="javascript">
	function FuelStock()
	{
		var f=document.all
		var openingstock=f.txtOpeningStock.value
		var waterstock=f.txtWaterStock.value
		var reservestock=f.ReserveStock.value
		
		if(openingstock.value=="")
			openingstock.value=0
		if(waterstock.value=="")
			waterstock.value=0
		if(reservestock.value=="")
			reservestock.value=0
			
		f.txtFuelStock.value=eval(openingstock.value)-eval(waterstock.value)-eval(reservestock.value)
	}
		</script>
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
			<uc1:header id="Header1" runat="server"></uc1:header><INPUT id="TxtVen" style="Z-INDEX: 218; LEFT: -528px; POSITION: absolute; TOP: -24px" type="text"
				name="TxtVen" runat="server">
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Tank&nbsp;Entry</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE cellSpacing="0" cellPadding="0">
							<TR>
								<TD colSpan="3"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD>Tank ID</TD>
								<TD><asp:label id="lblTankID" runat="server" Width="112px" ForeColor="Purple"></asp:label><asp:dropdownlist id="DropTankID" runat="server" Width="180px" AutoPostBack="True" Visible="False"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:CompareValidator id="CompareValidator2" runat="server" Width="2px" Operator="NotEqual" ErrorMessage="Please Select The Tank ID"
										ValueToCompare="Select" ControlToValidate="DropTankID"><font color="red"></font></asp:CompareValidator></TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>Tank 
									Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD>
									<asp:TextBox id="lblTankName" runat="server" Width="147px" BorderStyle="Groove" 
										CssClass="FontStyle"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Product Name 
									<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropProdName" ValueToCompare="Select"
										ErrorMessage="Please Select Product Name" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropProdName" runat="server" Width="150px" onChange="getTankNo(this,document.all.lblTankName);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
										<asp:ListItem Value="Auto LPG">Auto LPG</asp:ListItem>
										<asp:ListItem Value="CNG">CNG</asp:ListItem>
										<asp:ListItem Value="Diesel(HSD)">Diesel(HSD)</asp:ListItem>
										<asp:ListItem Value="Petrol(MS)">Petrol(MS)</asp:ListItem>
										<asp:ListItem Value="Super Diesel">Super Diesel</asp:ListItem>
										<asp:ListItem Value="Super Petrol">Super Petrol</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Short Name <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtProdAbbr" ErrorMessage="Please Enter Short Name"><font color="red">*</font></asp:requiredfieldvalidator></FONT></TD>
								<TD><asp:textbox id="txtProdAbbr" runat="server" Width="150px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="49"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Capacity&nbsp; 
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtCapacity" ErrorMessage="Please Fill Capacity"><font color="red">*</font></asp:requiredfieldvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtCapacity" runat="server"
										Width="150px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD>&nbsp; (Liters)&nbsp;</TD>
							</TR>
							<TR>
								<TD>Water Stock</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtWaterStock"
										runat="server" Width="150px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD align="center">(Liters)</TD>
							</TR>
							<TR>
								<TD>Reserve Stock</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtReserveStock"
										runat="server" Width="150px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD align="center">(Liters)</TD>
							</TR>
							<TR>
								<TD>Opening Stock</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOpeningStock"
										runat="server" Width="150px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD align="center">(Liters)</TD>
							</TR>
							<TR>
								<TD align="right" colSpan="3"><asp:button id="btnSave" runat="server" Width="65px" Text="Add"></asp:button>
                                    <asp:button id="Button1" runat="server" Width="65px"  Text="Edit"></asp:button>
                                    <asp:button id="btnEdit" runat="server" Width="65px" Text="Edit" CausesValidation="False"></asp:button>
                                    <asp:button id="btnDelete" runat="server" Width="65px"  Text="Delete"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
