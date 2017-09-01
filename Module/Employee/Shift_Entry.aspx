<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Shift_Entry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Master.Shift_Entry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Shift Entry</title> <!--
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
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Shift Entry</font>
						<hr>
					</TH>
				</TR>
				<TR>
					<td align="center">
						<TABLE>
							<TR>
								<TD colSpan="2"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 34px">Shift 
									ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD style="HEIGHT: 34px"><asp:label id="lblShiftID" runat="server" Height="1px" Width="48px" ForeColor="Blue"></asp:label><br>
									<asp:dropdownlist id="DropShiftID" runat="server" Width="156px" AutoPostBack="True" Visible="False"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Shift Name&nbsp; 
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtShiftName" ErrorMessage="Please Fill Shift Name"><font color="red">*</font></asp:requiredfieldvalidator></TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtShiftName" runat="server"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Time&nbsp;From&nbsp; 
									<asp:comparevalidator id="CompareValidator3" runat="server" ControlToValidate="DropHour1" ErrorMessage="Please Select From Hours"
										ValueToCompare="HH" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator><asp:comparevalidator id="CompareValidator4" runat="server" ControlToValidate="DropMinute1" ErrorMessage="Please Select From Minute"
										ValueToCompare="MM" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropHour1" runat="server" Height="19px" Width="70px" CssClass="FontStyle">
										<asp:ListItem Value="HH" Selected="True">HH</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="13">13</asp:ListItem>
										<asp:ListItem Value="14">14</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="16">16</asp:ListItem>
										<asp:ListItem Value="17">17</asp:ListItem>
										<asp:ListItem Value="18">18</asp:ListItem>
										<asp:ListItem Value="19">19</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="21">21</asp:ListItem>
										<asp:ListItem Value="22">22</asp:ListItem>
										<asp:ListItem Value="23">23</asp:ListItem>
									</asp:dropdownlist><asp:dropdownlist id="DropMinute1" runat="server" Height="22" Width="67px" CssClass="FontStyle">
										<asp:ListItem Value="MM" Selected="True">MM</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="45">45</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px">Time&nbsp;To&nbsp; 
									<asp:comparevalidator id="CompareValidator2" runat="server" ControlToValidate="DropHour2" ErrorMessage="Please Select To Hour"
										ValueToCompare="HH" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator><asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropMinute2" ErrorMessage="Please Select To Minute"
										ValueToCompare="MM" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator></TD>
								<TD style="HEIGHT: 20px"><asp:dropdownlist id="DropHour2" runat="server" Height="23px" Width="70px" CssClass="FontStyle">
										<asp:ListItem Value="HH" Selected="True">HH</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="13">13</asp:ListItem>
										<asp:ListItem Value="14">14</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="16">16</asp:ListItem>
										<asp:ListItem Value="17">17</asp:ListItem>
										<asp:ListItem Value="18">18</asp:ListItem>
										<asp:ListItem Value="19">19</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="21">21</asp:ListItem>
										<asp:ListItem Value="22">22</asp:ListItem>
										<asp:ListItem Value="23">23</asp:ListItem>
									</asp:dropdownlist><asp:dropdownlist id="DropMinute2" runat="server" Height="21px" Width="67px" CssClass="FontStyle">
										<asp:ListItem Value="MM" Selected="True">MM</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="45">45</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Remark</TD>
								<TD><asp:textbox id="TxtRemark" runat="server" BorderStyle="Groove" MaxLength="49" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="2">
									<HR width="100%" color="#000099" SIZE="1">
									<asp:button id="btnUpdate" runat="server" Width="60px" Text="Add" ></asp:button>
									<asp:button id="btnEdit" runat="server" Width="60px" Text="Edit" CausesValidation="False"></asp:button>
									<asp:Button id="Edit1" runat="server" Width="57px" Text="Edit" ></asp:Button>
									<asp:button id="btnDelete" runat="server" Width="60px" Text="Delete" CausesValidation="False"></asp:button></TD>
							</TR>
							<TR>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" Height="4px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</TR>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
