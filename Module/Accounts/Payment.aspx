<%@ Page language="c#" Codebehind="Payment.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Accounts.Payment" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Payment</title><!--
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
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox><input id="tempPaymentID" style="Z-INDEX: 103; LEFT: 160px; VISIBILITY: hidden; WIDTH: 5px; POSITION: absolute; TOP: 8px; HEIGHT: 20px"
				type="hidden" runat="server" NAME="tempPaymentID">
			<TABLE height="288" width="778" align="center">
				<tr vAlign="top" height="20">
					<th align="center">
						<font color="#006400">Payment</font>
						<hr>
					</th>
				</tr>
				<TR vAlign="top">
					<TD align="center">
						<TABLE>
							<TR>
								<TD colSpan="2"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD>Ledger Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" InitialValue="Select" ControlToValidate="DropLedgerName"
										ErrorMessage="Please Select Ledger Name">*</asp:requiredfieldvalidator><FONT color="red"></FONT></TD>
								<TD><asp:dropdownlist id="DropLedgerName1" runat="server" Visible="False" Width="200px" AutoPostBack="True"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:dropdownlist id="DropLedgerName" runat="server" Width="200px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:button id="btnEdit1" runat="server" Width="22px" CausesValidation="False" Text="..." ToolTip="Click here for edit"
										BackColor="ForestGreen" BorderColor="ForestGreen" ForeColor="White"></asp:button></TD>
							</TR>
							<TR>
								<TD>By&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" InitialValue="Select" ControlToValidate="DropBy"
										ErrorMessage="Please Select By Account Name">*</asp:requiredfieldvalidator></TD>
								<TD><asp:dropdownlist id="DropBy" runat="server" Width="154px" AutoPostBack="True" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<asp:panel id="PanBankInfo" runat="server">
								<TR>
									<TD>Bank Name</TD>
									<TD>
										<asp:textbox id="txtBankname" runat="server" CssClass="FontStyle" MaxLength="49" BorderStyle="Groove"></asp:textbox>&nbsp;Cheque 
										No.
										<asp:textbox id="txtCheque" runat="server" Width="87px" CssClass="FontStyle" MaxLength="15" BorderStyle="Groove"></asp:textbox>&nbsp;&nbsp; 
										Date
										<asp:textbox id="txtDate" runat="server" Width="112px" CssClass="FontStyle" BorderStyle="Groove"
											ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" id="Img1" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0" runat="server"></A></TD>
								</TR>
							</asp:panel><asp:panel id="PanAmount" runat="server">
								<TR>
									<TD>Amount
										<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Amount "
											ControlToValidate="TxtAmount">*</asp:requiredfieldvalidator></TD>
									<TD>
										<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount" runat="server"
											Width="154px" CssClass="FontStyle" MaxLength="12" BorderStyle="Groove"></asp:textbox></TD>
								</TR>
							</asp:panel>
							<TR>
								<TD>Narrrations&nbsp;&nbsp;&nbsp; <FONT color="#ff0000">&nbsp;&nbsp;</FONT></TD>
								<TD><TEXTAREA class="FontStyle" id="txtNarrartion" style="VERTICAL-ALIGN: baseline; WIDTH: 154px; DIRECTION: ltr; TEXT-ALIGN: left"
										accessKey="txtNarArea" name="TEXTAREA1" wrap="hard" cols="17" runat="server"></TEXTAREA></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4"><asp:button id="btnSave" runat="server" Width="70px" Text="Save" BackColor="ForestGreen" BorderColor="ForestGreen"
										ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnEdit" runat="server" Width="70px" Text="Edit" BackColor="ForestGreen" BorderColor="ForestGreen"
										ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnDelete" runat="server" Width="70px" Text="Delete" BackColor="ForestGreen"
										BorderColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnPrint" runat="server" Width="70px" CausesValidation="False" Text="Print"
										BackColor="ForestGreen" BorderColor="ForestGreen" ForeColor="White"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
				</TR>
			</TABLE>
			<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></IFRAME>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
