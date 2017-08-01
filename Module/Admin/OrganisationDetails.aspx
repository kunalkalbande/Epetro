<%@ Page language="c#" Codebehind="OrganisationDetails.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Admin.OrganisationDetails" %>
<%@ Register TagPrefix="uc1" TagName="Header1" Src="../../HeaderFooter/Header1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Organisation Details</title> <!--
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
		<form id="Form1" encType="multipart/form-data" runat="server">
			<asp:textbox id="txtdumy" style="Z-INDEX: 101; LEFT: 168px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" BorderStyle="Groove" Visible="False"></asp:textbox><asp:textbox id="txtdummy" style="Z-INDEX: 102; LEFT: 152px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox><uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 103; LEFT: 184px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox><asp:TextBox id="txtbeatname" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 16px"
				name="txtbeatname" runat="server" Width="1" Height="1"></asp:TextBox><input type="hidden" runat="server" id="tempFleetCard" name="tempFleetCard" style="WIDTH:1px">
			<input type="hidden" runat="server" id="tempCreditCard" name="tempCreditCard" style="WIDTH:1px">
			<table height="278" width="778" cellpadding="0" cellspacing="0" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Organization Details</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE cellpadding="0" cellspacing="0">
							<TR>
								<TD colSpan="4"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD>&nbsp;<asp:label id="Label1" runat="server" Width="64px">Company ID</asp:label></TD>
								<TD colspan="3"><asp:label id="LblCompanyID" Width="72px" Runat="server" ForeColor="Blue"></asp:label><asp:dropdownlist id="Drop" runat="server" Width="104px" Visible="False" AutoPostBack="True" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:button id="Button1" runat="server" Text="..." CausesValidation="False" ForeColor="White"
										BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button></TD>
							</TR>
							<TR>
								<TD>&nbsp;Name Of Dealer&nbsp;
									<asp:RequiredFieldValidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="Please Fill the Dealer Name"
										ControlToValidate="txtDealerName"><font color="red">*</font></asp:RequiredFieldValidator></TD>
								<TD colSpan="3"><asp:textbox id="txtDealerName" runat="server" Width="362px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD valign="top">&nbsp;Dealership&nbsp;
									<asp:comparevalidator id="Comparevalidator1" runat="server" ControlToValidate="DropDealerShip" ErrorMessage="Please Select DealerShip Name"
										ValueToCompare="Select" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator></TD>
								<TD colSpan="3"><asp:dropdownlist id="DropDealerShip" runat="server" Width="362px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="BHARAT PETROLEUM CORP LTD.">BHARAT PETROLEUM CORP LTD.</asp:ListItem>
										<asp:ListItem Value="ESSAR OIL COMPANY.">ESSAR OIL COMPANY.</asp:ListItem>
										<asp:ListItem Value="HINDUSTAN PETROLEUM CORP LTD.">HINDUSTAN PETROLEUM CORP LTD.</asp:ListItem>
										<asp:ListItem Value="IBP COMPANY LTD.">IBP COMPANY LTD.</asp:ListItem>
										<asp:ListItem Value="INDIAN OIL CORPORATION LTD.">INDIAN OIL CORPORATION LTD.</asp:ListItem>
									</asp:dropdownlist><br>
									<asp:textbox id="TxtDealership" runat="server" Width="362px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Address&nbsp;
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill the Address"
										ControlToValidate="TxtAddress"><font color="red">*</font></asp:RequiredFieldValidator></TD>
								<TD colSpan="3"><asp:textbox CausesValidation="true" id="TxtAddress" runat="server" Width="362px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD colSpan="3"><asp:textbox id="TxtAddress1" runat="server" Width="362px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD colSpan="3"><asp:textbox id="TxtAddress2" runat="server" Width="362px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;City&nbsp;
									<asp:comparevalidator id="CompareValidator2" runat="server" ControlToValidate="DropCity" ErrorMessage="Please Select City"
										ValueToCompare="Select" Operator="NotEqual"><font color="red">*</font></asp:comparevalidator></TD>
								<TD><asp:dropdownlist id="DropCity" runat="server" Width="130px" onChange="getBeatInfo(this,document.all.DropState,document.Form1.DropCountry);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;Phone No
									<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Contact No. Between 6-12 Digits"
										ControlToValidate="txtPhoneOff" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="txtPhoneOff" runat="server" Width="101" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;State</TD>
								<TD><asp:dropdownlist id="DropState" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;Fax No<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="Contact No. Between 6-12 Digits"
										ControlToValidate="TxtFaxNo" ValidationExpression="\d{6,12}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="TxtFaxNo" runat="server" Width="101px" BorderStyle="Groove" MaxLength="11" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Country</TD>
								<TD><asp:dropdownlist id="DropCountry" runat="server" Width="130px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>&nbsp;E - Mail<asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ErrorMessage="Please Fill Valid E-mail"
										ControlToValidate="txtEMail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:regularexpressionvalidator></TD>
								<TD colSpan="3"><asp:textbox id="txtEMail" runat="server" Width="362px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Web Site</TD>
								<TD colSpan="3"><asp:textbox id="TxtWebsite" runat="server" Width="362" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="29"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Divisional Office</TD>
								<TD><asp:textbox id="txtDivOffice" runat="server" Width="134px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
								<td>&nbsp;W &amp; M Lic No&nbsp;&nbsp;</td>
								<td><asp:textbox id="TxtWMlic" runat="server" Width="101" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="24"></asp:textbox></td>
							</TR>
							<TR>
								<TD>&nbsp;Explosive Lic No</TD>
								<TD><asp:textbox id="txtExplosive" runat="server" Width="134px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="24"></asp:textbox></TD>
								<TD>&nbsp;Tin No <asp:RequiredFieldValidator id="Requiredfieldvalidator3" runat="server" ControlToValidate="TxtTinno" ErrorMessage="Please Fill the TinNo"><font color="red">*</font></asp:RequiredFieldValidator>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" ErrorMessage="Invalid Tin No" ControlToValidate="TxtTinno"
										ValidationExpression="\d{11}">*</asp:regularexpressionvalidator></TD>
								<TD><asp:textbox id="TxtTinno" runat="server" Width="101px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										MaxLength="11" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<tr>
								<td>&nbsp;Fleet Card Reload A/C Name&nbsp;&nbsp;
                                    <asp:RequiredFieldValidator id="Requiredfieldvalidator4" runat="server" ControlToValidate="txtFleetCard" ErrorMessage="Please Enter Fleet Card Name"><font color="red">*</font></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;</td>
								<td><asp:TextBox Runat="server" ID="txtFleetCard" onkeypress="return GetSpace(this, event);" Width="134"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="40"></asp:TextBox></td>
								<td>&nbsp;Credit Card Banker Name&nbsp;&nbsp;<asp:RequiredFieldValidator id="Requiredfieldvalidator5" runat="server" ControlToValidate="txtCreditCard" ErrorMessage="Please Enter Credit Card Name"><font color="red">*</font></asp:RequiredFieldValidator></td>
								<td><asp:TextBox Runat="server" ID="txtCreditCard" onkeypress="return GetSpace(this, event);" Width="101"
										BorderStyle="Groove" CssClass="FontStyle" MaxLength="40"></asp:TextBox></td>
							</tr>
							<TR>
								<TD>&nbsp;Food Lic No</TD>
								<TD><asp:textbox id="txtfood" runat="server" Width="134px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="24"></asp:textbox></TD>
								<TD>&nbsp;VAT Rate</TD>
								<TD vAlign="middle"><asp:textbox id="txtVatRate" runat="server" BorderStyle="Groove" Width="48px" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										MaxLength="5" CssClass="FontStyle"></asp:textbox>&nbsp;<STRONG>%</STRONG></TD>
							</TR>
							<!--TR>
								<TD>W &amp; M Lic No</TD>
								<TD></TD>
								<!--<TD>File Title
								</TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtFileTitle" Width="158px" BorderStyle="Groove"
										Runat="Server"></asp:textbox></TD>
								></TR-->
							<TR>
								<TD>&nbsp;Company Logo</TD>
								<TD colSpan="3"><input id="txtFileContents" style="WIDTH: 363px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="file" size="41" name="txtFileContents" Runat="Server" dataSrc="d:\test\" class="FontStyle"></TD>
							</TR>
							<TR>
								<TD>&nbsp;Message</TD>
								<TD colSpan="3"><asp:textbox id="txtMsg" runat="server" Width="180px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="99"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Accounts Period From &nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtDateFrom" runat="server" Width="88px"  BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD align="center">To</TD>
								<TD><asp:textbox id="txtDateTo" runat="server" Width="88px"  BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="4">&nbsp;
									<asp:button  OnClick="btnUpdate_Click1" id="btnUpdate" runat="server" Width="95px" Text="Save Profile" ForeColor="White"
										BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
