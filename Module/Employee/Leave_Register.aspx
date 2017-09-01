<%@ Page language="c#" Codebehind="Leave_Register.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Employee.Leave_Register" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Leave Register</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../Sysitem/Styles.css" type=text/css rel=stylesheet >
</HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Leave_Register method=post runat="server"><uc1:header id=Header1 runat="server"></uc1:header><asp:textbox id=TextBox1 style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server" Visible="False" Width="8px"></asp:textbox>
<table height=288 width=778 align=center>
  <TR vAlign=top>
    <TH align=center><font color=#006400>Leave Application</FONT> 
      <hr>
    </TH>
  </TR>
  <tr vAlign=top>
    <td align=center>
      <TABLE style="WIDTH: 325px" cellSpacing=0 cellPadding=0>
        <TR>
          <TD colSpan=2><FONT color=#ff0000>Fields Marked as (*) Are Mandatory</FONT></TD></TR>
        <TR>
          <TD>Employee ID&nbsp;<asp:comparevalidator id=CompareValidator1 runat="server" ValueToCompare="Select" Operator="NotEqual" ControlToValidate="DropEmpName" ErrorMessage="Please Select Employee ID"><font color="red">*</font></asp:comparevalidator></TD>
          <TD><asp:dropdownlist id=DropEmpName runat="server" Width="215px" CssClass="FontStyle"><asp:ListItem Value="Select">Select</asp:ListItem></asp:dropdownlist></TD>
        </TR>

        <TR>
          <TD>Date&nbsp;From&nbsp;&nbsp;&nbsp;<font color="white">*</font><asp:requiredfieldvalidator id=RequiredFieldValidator2 runat="server" ControlToValidate="txtDateFrom" ErrorMessage="Please Select Date From"><font color="red">*</font></asp:requiredfieldvalidator></TD>
          <TD><asp:textbox id=txtDateFrom runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove" ></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;" ><IMG class=PopcalTrigger alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align=absMiddle border=0 ></A></TD>
        </TR>

        <TR>
          <TD>Date To&nbsp;&nbsp;&nbsp;<font color="white">*</font><asp:requiredfieldvalidator id=RequiredFieldValidator3 runat="server" ControlToValidate="txtDateTO" ErrorMessage="Please Select Date To"><font color="red">*</font></asp:requiredfieldvalidator></TD>
          <TD><asp:textbox id=txtDateTO runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove" ></asp:textbox><A  onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTO);return false;" ><IMG class=PopcalTrigger alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align=absMiddle border=0 ></A></TD>
        </TR>

        <TR>
          <TD>Reason&nbsp;&nbsp; <asp:requiredfieldvalidator id=RequiredFieldValidator1 runat="server" ControlToValidate="txtReason" ErrorMessage="Please Specify the Reason of Leave"><font color="red">*</font></asp:requiredfieldvalidator></TD>
          <td><asp:textbox id=txtReason runat="server" Width="215px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="49" TextMode="MultiLine" Height="42px"></asp:textbox></TD></TR>
          <TR>
              <TD>
                  <asp:TextBox ID="nothing" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="none"></asp:TextBox>
              </TD>
          </TR>
        <TR>
          <TD align=center colSpan=2><asp:button id=btnApply runat="server" Width="70px"  Text="Apply"></asp:button></TD>
        </TR>

      </TABLE>
        <asp:validationsummary id=ValidationSummary1 runat="server" Height="16px" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD></TR></TABLE><iframe 
id=gToday:contrast:agenda.js 
style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px" 
name=gToday:contrast:agenda.js src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder=0 
width=174 scrolling=no height=189></iframe><uc1:footer id=Footer1 runat="server"></uc1:footer></FORM>
	</body>
</HTML>
