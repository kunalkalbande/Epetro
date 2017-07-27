<%@ Page language="c#" Codebehind="OT_Register.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Employee.OT_Register" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Overtime Register</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta name="vs_snapToGrid" content="True">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="OT_Register" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:TextBox>
			<table height="288" width="778" align="center">
				<TR valign=top>
					<TH align="center">
						<font color="#006400">OverTime Register</font>
						<hr>
					</TH>
				</TR>
				<tr valign=top>
					<td align="center">
						<TABLE style="WIDTH: 495px" cellpadding="0" cellspacing="0" border=0>
							<TR>
								<TD colSpan="4"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD>Employee ID / Name&nbsp;<FONT color="#ff0000">*</FONT>
									<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropEmpID" Operator="NotEqual"
										ValueToCompare="Select" ErrorMessage="Please Select Employee ID">*</asp:comparevalidator><FONT color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></TD>
								<TD colSpan="3"><asp:dropdownlist id="DropEmpID" runat="server" Width="240px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Date&nbsp;<FONT color="#ff0000">*</FONT>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="Please Select Overtime Date">*</asp:requiredfieldvalidator><FONT color="red"></FONT></TD>
								<TD colSpan="3"><asp:textbox id="txtDate" runat="server" Width="136px" ReadOnly="True" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
							</TR>
							<TR>
								<TD>Time From&nbsp; <FONT color="#ff0000">*</FONT>
									<asp:comparevalidator id="CompareValidator3" runat="server" ControlToValidate="DropHour1" Operator="NotEqual"
										ValueToCompare="HH" ErrorMessage="Please Select Time From">*</asp:comparevalidator><asp:comparevalidator id="CompareValidator4" runat="server" ControlToValidate="DropMinute1" Operator="NotEqual"
										ValueToCompare="MM" ErrorMessage="Please Select Time From">*</asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropHour1" runat="server" Width="44px" Height="24px" CssClass="FontStyle">
										<asp:ListItem Value="HH" Selected="True">HH</asp:ListItem>
										<asp:ListItem Value="00">00</asp:ListItem>
										<asp:ListItem Value="01">01</asp:ListItem>
										<asp:ListItem Value="02">02</asp:ListItem>
										<asp:ListItem Value="03">03</asp:ListItem>
										<asp:ListItem Value="04">04</asp:ListItem>
										<asp:ListItem Value="05">05</asp:ListItem>
										<asp:ListItem Value="06">06</asp:ListItem>
										<asp:ListItem Value="07">07</asp:ListItem>
										<asp:ListItem Value="08">08</asp:ListItem>
										<asp:ListItem Value="09">09</asp:ListItem>
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
									</asp:dropdownlist><asp:dropdownlist id="DropMinute1" runat="server" Width="44px" Height="24px" CssClass="FontStyle">
										<asp:ListItem Value="MM" Selected="True">MM</asp:ListItem>
										<asp:ListItem Value="00">00</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="45">45</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;&nbsp;To&nbsp;
									<asp:CompareValidator id="CompareValidator8" runat="server" ControlToValidate="DropHour2" Operator="NotEqual"
										ValueToCompare="HH" ErrorMessage="Please Select Time To">*</asp:CompareValidator>
									<asp:CompareValidator id="CompareValidator2" runat="server" ControlToValidate="DropMinute2" Operator="NotEqual"
										ValueToCompare="MM" ErrorMessage="Please Select Time To">*</asp:CompareValidator></TD>
								<TD>
									<asp:dropdownlist id="DropHour2" runat="server" Width="45px" Height="23px" CssClass="FontStyle">
										<asp:ListItem Value="HH" Selected="True">HH</asp:ListItem>
										<asp:ListItem Value="00">00</asp:ListItem>
										<asp:ListItem Value="01">01</asp:ListItem>
										<asp:ListItem Value="02">02</asp:ListItem>
										<asp:ListItem Value="03">03</asp:ListItem>
										<asp:ListItem Value="04">04</asp:ListItem>
										<asp:ListItem Value="05">05</asp:ListItem>
										<asp:ListItem Value="06">06</asp:ListItem>
										<asp:ListItem Value="07">07</asp:ListItem>
										<asp:ListItem Value="08">08</asp:ListItem>
										<asp:ListItem Value="09">09</asp:ListItem>
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
									</asp:dropdownlist>
									<asp:dropdownlist id="DropMinute2" runat="server" Width="46px" Height="21px" CssClass="FontStyle">
										<asp:ListItem Value="MM" Selected="True">MM</asp:ListItem>
										<asp:ListItem Value="00">00</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="45">45</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<tr><td>&nbsp;</td></tr>
							<TR>
								<TD align="right" colSpan="4">
									<asp:button id="btnUpdate" runat="server" Width="70px" Text="Save" BackColor="ForestGreen" BorderColor="ForestGreen"
										ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<asp:ValidationSummary id="ValidationSummary1" runat="server" Height="35px" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></td>
				</tr>
			</table>
			<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></IFRAME>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer></form>
	</body>
</HTML>
