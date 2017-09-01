<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="ROI_ANALYSIS.aspx.cs" AutoEventWireup="false" Inherits="EPetro.ROI_ANALYSIS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Retail Outlet Inspection and Analysis Report</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

-->
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table id="Table6" cellSpacing="2" cellPadding="0" width="100%" align="center" border="0"
				runat="server">
				<tr>
					<th>
						<font color="#006400">Retail Outlet Inspection and Analysis Report</font><hr>
					</th>
				</tr>
				<tr>
					<td>
						<table id="Table5" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td colSpan="3" height="20">&nbsp; ROI ID&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtroiid" runat="server" BorderStyle="Groove" Width="64px"  CssClass="FontStyle"></asp:textbox></td>
								<td colSpan="5" height="20"><asp:dropdownlist id="DropDownList1" runat="server" Width="112px" AutoPostBack="True" Enabled="False"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:button id="btnbrw" runat="server" Width="25px"  Text="..."></asp:button></td>
							</tr>
							<tr>
								<td colSpan="8" height="20">&nbsp; Note : Annexure I to be filled by sales Officer 
									once a Year.No copy to be kept in the RO.
								</td>
							</tr>
							<tr>
								<td vAlign="top" colSpan="4">&nbsp; Dealer's Name and Address<br>
									&nbsp;&nbsp;&nbsp; <TEXTAREA id="txtareaDLnameaddr" style="WIDTH: 176px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 38px; BORDER-BOTTOM-STYLE: groove"
										rows="3" cols="30" runat="server" class="FontStyle"></TEXTAREA>
								</td>
								<td colSpan="2">
									<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="2" cellPadding="0"
										width="100%" border="1">
										<TR>
											<TD align="center" colSpan="2">Type Of Station</TD>
										</TR>
										<TR>
											<TD>&nbsp; A Site</TD>
											<TD><input id="chkasite" type="radio" name="Station" runat="server"></TD>
										</TR>
										<TR>
											<TD>&nbsp; B Site</TD>
											<TD><input id="chkbsite" type="radio" name="Station" runat="server"></TD>
										</TR>
										<TR>
											<TD>&nbsp; COCO</TD>
											<TD><input id="chkcoco" type="radio" name="Station" runat="server"></TD>
										</TR>
									</table>
								</td>
								<td colSpan="2" height="84">
									<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="2" cellPadding="0"
										width="100%" border="1">
										<tr>
											<td align="center" colSpan="2">Category</td>
										</tr>
										<tr>
											<td style="HEIGHT: 19px">&nbsp; SS</td>
											<td style="HEIGHT: 19px"><input id="chkCategoryss" type="radio" name="Category" runat="server"></td>
										</tr>
										<tr>
											<td>&nbsp; FS</td>
											<td><input id="chkCategoryfs" type="radio" name="Category" runat="server"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; Dealership structure</td>
								<td align="center" height="19">Partnership</td>
								<td><input id="chkPartnership" type="radio" name="Dealership" runat="server"></td>
								<td style="WIDTH: 147px" align="center" height="19">Proprietorship</td>
								<td><input id="chkProprietorship" type="radio" name="Dealership" runat="server"></td>
								<td align="center" height="19">Others</td>
								<td><input id="chkOthers" type="radio" name="Dealership" runat="server"></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; Divisional Office<br>
									&nbsp;&nbsp;
									<asp:textbox id="txtDivisionOff" runat="server" BorderStyle="Groove" MaxLength="50" WIDTH="80px"
										CssClass="FontStyle"></asp:textbox></td>
								<td colSpan="2" height="19">&nbsp; District<br>
									&nbsp; <input id="txtDistrict" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="50" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2" height="19">&nbsp; Date of previous visit</td>
								<td colSpan="2" height="19">&nbsp;
									<asp:textbox id="txtDate" runat="server" BorderStyle="Groove" Width="80px"  CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDate);return false;"><IMG class="PopcalTrigger" id="Img1" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">
									<P>&nbsp;&nbsp; SALES&nbsp;&nbsp; PERFORMANCE</P>
								</td>
								<td align="center" colSpan="3" height="19">&nbsp; Month(MM_YY) <input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtSalesPerformanceDate"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"  type="text"
										size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtSalesPerformanceDate);return false;"><IMG class="PopcalTrigger" id="Img40" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td align="center" colSpan="3" height="19">&nbsp; Cumulative upto &nbsp;<input id="txtCummulativeuptoDate" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtCummulativeuptoDate);return false;"><IMG class="PopcalTrigger" id="Img2" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp;</td>
								<td align="center" height="19">Target</td>
								<td align="center" height="19">C/Year</td>
								<td align="center" height="19">L/Year</td>
								<td align="center" height="19">Target</td>
								<td align="center" height="19">C/Year</td>
								<td align="center" height="19">L/Year</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; MS</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtMSTarget1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="14" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtMScyear1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="14" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtMSLyear1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtMSTarget2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtMSCyear2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtMSLyear2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; HSD</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtHSDTarget1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtHSDCYear1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtHSDLYear1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtHSDTarget2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtHSDCYear2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtHSDLYear2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" colSpan="2" height="26">&nbsp; Lubes</td>
								<td style="HEIGHT: 19px"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLubesTarget1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLubesCYear1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLubesLYear1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLubesTarget2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLubesCYear2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLubesLYear2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; Grease</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtGreaseTarget1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtGreaseCYear1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtGreaseLYear1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtGreaseTarget2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtGreaseCYear2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtGreaseLYear2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; LF Ratio</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLFratioTarget1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLFratioCYear1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLFratioLYear1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLFratioTarget2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLFratioCYear2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtLFratioLyear2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; 2.Trading Area&nbsp;&nbsp;&nbsp; Analysis</td>
								<td align="center" colSpan="2" height="19">No. of ROs</td>
								<td align="center" colSpan="2" height="19">Trading Area Potential</td>
								<td align="center" colSpan="2" height="19">Trading Area Average<br>
									(Kl/Month)</td>
							</tr>
							<tr>
								<td colSpan="2" height="19"></td>
								<td align="center" height="19">MS</td>
								<td align="center" height="19">HSD</td>
								<td align="center" height="19">MS</td>
								<td align="center" height="19">HSD</td>
								<td align="center" height="19">MS</td>
								<td align="center" height="19">HSD</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; IOC</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtIOCMS1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtIOCHSD1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtIOCMS2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtIOCHSD2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtIOCMS3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtIOCHSD3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; OMC</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOMCMS1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOMCHSD1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOMCMS2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOMCHSD2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOMCMS3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOMCHSD3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; TOTAL</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtTOTALMS1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input language="javascript" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										id="txtTOTALHSD1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtTOTALMS2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtTOTALHSD2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtTOTALMS3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtTOTALHSD3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="4" height="19">&nbsp;</td>
								<td align="center" colSpan="2" height="19">MS</td>
								<td align="center" colSpan="2" height="19">HSD</td>
							</tr>
							<tr>
								<td colSpan="4" height="19"><font size="2">&nbsp; Reasons for lower/higher Than Trading 
										Area Average</font></td>
								<td colSpan="2" height="19"><input id="txtReasonLH_taAvgMS" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2" height="19"><input id="txtReasonLH_taAvgHSD" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td align="center" colSpan="6" height="19">&nbsp;<b>3. Any New ROs coming up in the 
										Trading Area</b></td>
								<td height="19"><input id="chkNewRoTrAY" type="checkbox" value="ON" runat="server"></td>
								<td height="19"></td>
							</tr>
							<tr>
								<td align="center" colSpan="4" height="19">&nbsp;Name Of the Oil Co.</td>
								<td align="center" colSpan="4" height="19">&nbsp;Exp. Date Of Commissioning</td>
							</tr>
							<tr>
								<td align="center" height="19">a</td>
								<td colSpan="4" height="19"><input language="javascript" id="txt3a" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3" height="19"><input id="txt3adatepk" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt3adatepk);return false;"><IMG class="PopcalTrigger" id="Img3" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
							</tr>
							<tr>
								<td align="center" height="19">b</td>
								<td colSpan="4" height="19"><input id="txt3b" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3" height="19"><input id="txt3bdatepk" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt3bdatepk);return false;"><IMG class="PopcalTrigger" id="Img4" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
							</tr>
							<tr>
								<td align="center" height="19">c</td>
								<td colSpan="4" height="19"><input id="txt3c" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3" height="19"><input id="txt3cdatepk" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt3cdatepk);return false;"><IMG class="PopcalTrigger" id="Img5" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
							</tr>
							<tr>
								<td colSpan="8" height="19">&nbsp; 4. Daily Sales Record Verification :</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; Product</td>
								<td align="center" height="19">MS</td>
								<td align="center" height="19">HSD</td>
								<td align="center" height="19">Lubes</td>
								<td align="center" colSpan="3" height="19">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; Avg. Sales per day&nbsp;&nbsp; inliters</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4avgsaleMS"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4avgsaleHSD"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4avgsaleLUBES"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3" height="19"><b>Reasons</b> : Nil Sales/Dry-outs</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; No. Of day Nil Sales</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4NilSaleaMS"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4NilSaleaHSD"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4NilSaleaLUBES"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3" height="19" rowSpan="2"><TEXTAREA id="txtarea4NilSalesDryout" style="WIDTH: 176px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 38px; BORDER-BOTTOM-STYLE: groove"
										name="Textarea1" rows="2"  cols="30" runat="server" class="FontStyle"></TEXTAREA></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; Days Of Dry Outs,if&nbsp;&nbsp; any
								</td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4DryOutMS" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4DryOutHSD"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td height="19"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt4DryOutLUBES"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="4" height="19">&nbsp; TBA Sales(per month)</td>
								<td colSpan="4"><input id="txt4tba" style="WIDTH: 192px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
										type="text" size="26" runat="server" class="FontStyle"></td>
							</tr>
						</table>
						<!-- Form 2-->
						<table id="Table4" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td colSpan="8"><b>&nbsp; 5. Stock Verification</b></td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; (A) Totaliser Reading :</b></td>
							</tr>
							<tr>
								<td colSpan="2"></td>
								<td align="center" width="11%">No. 1</td>
								<td align="center" width="11%">No. 2</td>
								<td align="center" width="10%">No. 3</td>
								<td align="center" width="11%">No. 4</td>
								<td align="center" width="11%">No. 5</td>
								<td align="center" width="10%">No. 6</td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; Product</td>
								<td><input id="txt5AProNo1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AProNo2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AProNo3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AProNo4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AProNo5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AProNo6" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; Make</td>
								<td><input id="txt5AMakeNo1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AMakeNo2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AMakeNo3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AMakeNo4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" name="txt5AMakeNo4" runat="server" class="FontStyle"></td>
								<td><input id="txt5AMakeNo5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5AMakeNo6" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; Current Reading</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5ACuuReadNo1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5ACuuReadNo2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5ACuuReadNo3"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5ACuuReadNo4"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5ACuuReadNo5"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5ACuuReadNo6"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; Previous Reading</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APrevReadNo1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APrevReadNo2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APrevReadNo3"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APrevReadNo4"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APrevReadNo5"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APrevReadNo6"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; Total Sales as per Meter Reading(i)</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APerMETReadNo1"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APerMETReadNo2"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APerMETReadNo3"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APerMETReadNo4"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APerMETReadNo5"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5APerMETReadNo6"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="4"><b>&nbsp; (B) Physical stock</b>(Stock in tanks)</td>
								<td align="center" rowSpan="2">MS-93</td>
								<td align="center" rowSpan="2">MS-87</td>
								<td align="center" rowSpan="2">MS-ULP</td>
								<td align="center" rowSpan="2">HSD</td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; Stock as on <input id="txt5bstdate" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" name="Text1" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt5bstdate);return false;"><IMG class="PopcalTrigger" id="Img39" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A><br>
									(Date of inspection)</td>
								<td><input id="txt5BStockonlastDtMS93" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5BStockonlastDtMS87" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5BStockonlastDtMSulp" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt5BStockonlastDtHSD" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; Receipt since then(KL)</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BReceiptKL_MS93"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BReceiptKL_MS87"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BReceiptKL_MSULP"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BReceiptKL_HSD"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; Total Stock (KL) (A)</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTotalstkMS93"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTotalstkMS87"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTotalstkMSULP"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTotalstkHSD"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; Less : Actul Stock as per Dip (B)</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTLessstkMS93"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTLessstkMS87"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTLessstkMSULP"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTLessstkHSD"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; Total Sales as per Dips (ii=A-B)</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTotSalesMS93"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTotSalesMS87"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTotSalesMSULP"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BTotSalesHSD"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; Variation (i-ii)</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BVariationMS93"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BVariationMS87"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BVariationMSULP"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt5BVariationHSD"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="3">&nbsp; Reasons for variation :
								</td>
								<td colSpan="5"><TEXTAREA id="txtarea5BReasonVar" style="WIDTH: 200px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 38px; BORDER-BOTTOM-STYLE: groove"
										rows="2" cols="30" runat="server" class="FontStyle"></TEXTAREA></td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; 6. Lubricants Stock</b></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp;</td>
								<td align="center" colSpan="3">Barrels</td>
								<td align="center" colSpan="3">Small Packs</td>
							</tr>
							<tr>
								<td colSpan="2" rowSpan="2">&nbsp; Adequate</td>
								<td><input id="txt6adqbarrel1_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6adqbarrel2_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6adqbarrel3_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6Smallpck1_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6Smallpck2_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6Smallpck3_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input id="txt6adqbarrel1_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6adqbarrel2_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle">&nbsp;</td>
								<td><input id="txt6adqbarrel3_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle">&nbsp;</td>
								<td><input id="txt6adSmallpck1_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle">&nbsp;</td>
								<td><input id="txt6adSmallpck2_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle">&nbsp;</td>
								<td><input id="txt6adSmallpck3_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2" rowSpan="2">&nbsp; Inadequate</td>
								<td><input id="txt6Inadqbarrel1_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6Inadqbarrel2_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6Inadqbarrel3_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6InSmallpck1_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6InSmallpck2_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6InSmallpck3_0" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input id="txt6Inadqbarrel1_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6Inadqbarrel2_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6Inadqbarrel3_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6InSmallpck1_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6InSmallpck2_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td><input id="txt6InSmallpck3_1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; Note : Stocks should cover at least 15 days sales. Note grade 
										names under each column</b></td>
							</tr>
							<tr>
								<td width="9%" colSpan="5"><b>&nbsp; 7. Details of Subsidy availed</b></td>
								<td width="10%">&nbsp; Year</td>
								<td width="17%" colSpan="2">&nbsp; Amount</td>
							</tr>
							<tr>
								<td width="9%" colSpan="5">&nbsp;&nbsp; <input id="txt7DetailSub1" style="WIDTH: 200px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td width="10%"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub1_yr"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td width="17%" colSpan="2"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub1_amt"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" width="9%" colSpan="5">&nbsp;&nbsp; <input id="txt7DetailSub2" style="WIDTH: 200px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px" width="10%"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub2_yr"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px" width="17%" colSpan="2"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub2_amt"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" width="9%" colSpan="5">&nbsp;&nbsp; <input id="txt7DetailSub3" style="WIDTH: 200px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px" width="10%"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub3_yr"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td style="HEIGHT: 19px" width="17%" colSpan="2"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub3_amt"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="9%" colSpan="5">&nbsp;&nbsp; <input id="txt7DetailSub4" style="WIDTH: 200px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td width="10%"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub4_yr"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td width="17%" colSpan="2"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub4_amt"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="9%" colSpan="5">&nbsp;&nbsp; <input id="txt7DetailSub5" style="WIDTH: 200px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td width="10%"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub5_yr"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td width="17%" colSpan="2"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt7DetailSub5_amt"
										style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 8. Dealers' Suggestion to improve Image/Sales :<br>
									</b>&nbsp;&nbsp;&nbsp;<input id="txt8Dealersugggestion" style="WIDTH: 550px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 9. Market information on Competitors' activities 
										:<br>
									</b>&nbsp;&nbsp;<input id="txt9MarInfo" style="WIDTH: 550px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
						</table>
						<!-- Form 3-->
						<table id="Table3" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td width="12%" colSpan="8"><b>10. Upkeep and Maintenance of equipments;</b></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6"><b>10.1 Dispensing Pump :</b></td>
								<td width="12%">&nbsp;</td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; a) Pumps adequate for peak hour demand</td>
								<td width="12%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="chk10_1A_Y" type="checkbox" value="ON" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; b) No.of pump attendants per shift</td>
								<td width="15%" colSpan="2"><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt10_1B" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server"></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; c) Painting required</td>
								<td width="12%"><input id="chk10_1C_y" style="WIDTH: 80px" type="checkbox" size="20" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; d) Visual leak in despensing units observed</td>
								<td width="12%"><input id="chk10_1d_y" style="WIDTH: 80px" type="checkbox" size="20" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; e) Message regarding zeroing of pump meter 
									displayed</td>
								<td width="12%"><input id="chk10_1e_y" style="WIDTH: 80px" type="checkbox" size="20" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; f) All units are in working order :</td>
								<td width="12%"><input id="chk10_1f_y" style="WIDTH: 80px" type="checkbox" size="20" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; if no , details</td>
								<td width="12%" colSpan="5"><input id="txt10_1f" style="WIDTH: 400px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; g) Any replacements/additions required :</td>
								<td width="12%"><input id="chk10_1g_y" style="WIDTH: 80px" type="checkbox" size="20" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; if Yes , details</td>
								<td width="12%" colSpan="5"><input id="txt10_1g" style="WIDTH: 400px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="30%" colSpan="3"><b>&nbsp; 10.2 Emblem&nbsp; Posts</b></td>
								<td width="12%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; a) Visibility of Emblem Sign(check for good or 
									bad)</td>
								<td width="12%"><input id="chk10_2a_good" style="WIDTH: 80px" type="checkbox" value="ON" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; b) Condition of Emblem Sign(check for good or 
									bad)</td>
								<td width="12%"><input id="chk10_2b_good" style="WIDTH: 80px" type="checkbox" value="ON" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; c) Painting Required</td>
								<td width="12%"><input id="chk10_2c_y" style="WIDTH: 80px" type="checkbox" value="ON" runat="server"></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3"><b>&nbsp; 10.3 Sales Room</b></td>
								<td width="12%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6" style="HEIGHT: 32px">&nbsp; a) Painting Last Done On 
									(DD-MM-YY)</td>
								<td width="15%" colSpan="2" style="HEIGHT: 32px"><input id="txt10_3_aDate" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt10_3_aDate);return false;"><IMG class="PopcalTrigger" id="Img6" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; b) Painting Required :</td>
								<td align="center" width="12%"><input id="chk10_3b_y" type="checkbox" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; c) Repair Required :</td>
								<td align="center" width="12%"><input id="chk10_3c_y" type="checkbox" size="20" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; d) Display of Lubes</td>
								<td align="center" width="12%">Ex<input id="chk10_3d_Ex" type="radio" name="10_3d" runat="server">&nbsp;</td>
								<td align="center" width="12%">Vg<input id="chk10_3d_Vg" type="radio" name="10_3d" runat="server">&nbsp;</td>
								<td align="center" width="11%">G<input id="chk10_3d_G" type="radio" name="10_3d" runat="server">&nbsp;</td>
								<td align="center" width="13%">Av<input id="chk10_3d_Av" type="radio" name="10_3d" runat="server">&nbsp;</td>
								<td align="center" width="16%">P<input id="chk10_3d_P" type="radio" name="10_3d" runat="server">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; e) Cleanliness</td>
								<td align="center" width="12%">Ex<input id="chk10_3e_Ex" type="radio" name="10_3e" runat="server">&nbsp;</td>
								<td align="center" width="12%">Vg<input id="chk10_3e_Vg" type="radio" name="10_3e" runat="server">&nbsp;</td>
								<td align="center" width="11%">G<input id="chk10_3e_G" type="radio" name="10_3e" runat="server">&nbsp;</td>
								<td align="center" width="13%">Av<input id="chk10_3e_Av" type="radio" name="10_3e" runat="server">&nbsp;</td>
								<td align="center" width="16%">P<input id="chk10_3e_P" type="radio" name="10_3e" runat="server">&nbsp;</td>
							</tr>
							<tr>
								<td width="31%" colSpan="3"><b>&nbsp; 10.4 Lighting</b></td>
								<td width="11%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; a) Sales Room</td>
								<td align="center" width="12%">Ex<input id="chk10_4a_Ex" type="radio" name="10_4a" runat="server">&nbsp;</td>
								<td align="center" width="12%">Vg<input id="chk10_4a_Vg" type="radio" name="10_4a" runat="server">&nbsp;</td>
								<td align="center" width="11%">G<input id="chk10_4a_G" type="radio" name="10_4a" runat="server">&nbsp;</td>
								<td align="center" width="13%">Av<input id="chk10_4a_Av" type="radio" name="10_4a" runat="server">&nbsp;</td>
								<td align="center" width="16%">P<input id="chk10_4a_P" type="radio" name="10_4a" runat="server">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; b) Yard Lighting</td>
								<td align="center" width="12%">Ex<input id="chk10_4b_Ex" type="radio" name="10_4b" runat="server">&nbsp;</td>
								<td align="center" width="12%">Vg<input id="chk10_4b_Vg" type="radio" name="10_4b" runat="server">&nbsp;</td>
								<td align="center" width="11%">G<input id="chk10_4b_G" type="radio" name="10_4b" runat="server">&nbsp;</td>
								<td align="center" width="13%">Av<input id="chk10_4b_Av" type="radio" name="10_4b" runat="server">&nbsp;</td>
								<td align="center" width="16%">P<input id="chk10_4b_P" type="radio" name="10_4b" runat="server">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; c) Pump Island</td>
								<td align="center" width="12%">Ex<input id="chk10_4c_Ex" type="radio" name="10_4c" runat="server">&nbsp;</td>
								<td align="center" width="12%">Vg<input id="chk10_4c_Vg" type="radio" name="10_4c" runat="server">&nbsp;</td>
								<td align="center" width="11%">G<input id="chk10_4c_G" type="radio" name="10_4c" runat="server">&nbsp;</td>
								<td align="center" width="13%">Av<input id="chk10_4c_Av" type="radio" name="10_4c" runat="server">&nbsp;</td>
								<td align="center" width="16%">P<input id="chk10_4c_P" type="radio" name="10_4c" runat="server">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; d) Embeling</td>
								<td align="center" width="12%">Ex<input id="chk10_4d_Ex" type="radio" name="10_4d" runat="server">&nbsp;</td>
								<td align="center" width="12%">Vg<input id="chk10_4d_Vg" type="radio" name="10_4d" runat="server">&nbsp;</td>
								<td align="center" width="11%">G<input id="chk10_4d_G" type="radio" name="10_4d" runat="server">&nbsp;</td>
								<td align="center" width="13%">Av<input id="chk10_4d_Av" type="radio" name="10_4d" runat="server">&nbsp;</td>
								<td align="center" width="16%">P<input id="chk10_4d_P" type="radio" name="10_4d" runat="server">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3"><b>&nbsp; 10.5 Driveway</b></td>
								<td width="12%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; a) Condition of&nbsp; Driveway</td>
								<td align="center" width="12%">Ex<input id="chk10_5a_Ex" type="radio" name="10_5a" runat="server">&nbsp;</td>
								<td align="center" width="12%">Vg<input id="chk10_5a_Vg" type="radio" name="10_5a" runat="server">&nbsp;</td>
								<td align="center" width="11%">G<input id="chk10_5a_G" type="radio" name="10_5a" runat="server">&nbsp;</td>
								<td align="center" width="13%">Av<input id="chk10_5a_Av" type="radio" name="10_5a" runat="server">&nbsp;</td>
								<td align="center" width="16%">P<input id="chk10_5a_P" type="radio" name="10_5a" runat="server">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; b) Asphalted</td>
								<td align="center" width="12%"><input id="chk10_5b_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" width="9%" colSpan="6">&nbsp; c) Repaires Required</td>
								<td style="HEIGHT: 19px" align="center" width="12%"><input id="chk10_5c_Y" type="checkbox" value="ON" runat="server"></td>
								<td style="HEIGHT: 19px" align="center" width="15%"></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; d) Canopy Available</td>
								<td align="center" width="12%"><input id="chk10_5d_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="31%" colSpan="3"><b>&nbsp; 10.6 Pump Island</b></td>
								<td width="11%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; a) General&nbsp;&nbsp; Appearance</td>
								<td align="center" width="12%">Ex<input id="chk10_6a_Ex" type="radio" name="10_6a" runat="server">&nbsp;</td>
								<td align="center" width="12%">Vg<input id="chk10_6a_Vg" type="radio" name="10_6a" runat="server">&nbsp;</td>
								<td align="center" width="11%">G<input id="chk10_6a_G" type="radio" name="10_6a" runat="server">&nbsp;</td>
								<td align="center" width="13%">Av<input id="chk10_6a_Av" type="radio" name="10_6a" runat="server">&nbsp;</td>
								<td align="center" width="16%">P<input id="chk10_6a_P" type="radio" name="10_6a" runat="server">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; b) Tiling Done
								</td>
								<td align="center" width="12%"><input id="chk10_6b_Y" type="checkbox" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; c) Lube Display at Pump Island</td>
								<td align="center" width="12%"><input id="chk10_6c_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="12%" colSpan="8">&nbsp; Action proposed for improving the above<br>
									&nbsp;&nbsp; <input id="txt10_6c" style="WIDTH: 500px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="31%" colSpan="3"><b>&nbsp; 10.7 Tank Farm</b>
								</td>
								<td width="11%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; a) Tank Farm area free from oil spillage and kept 
									clean</td>
								<td align="center" width="12%"><input id="chk10_7a_Y" type="checkbox" size="20" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;&nbsp;b) Tank Farm free from dry grass
								</td>
								<td align="center" width="12%"><input id="chk10_7b_Y" type="checkbox" size="20" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; c) Camlock Couplings available for Unloading
								</td>
								<td align="center" width="12%"><input id="chk10_7c_Y" type="checkbox" size="20" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; d) Availability of Chain-Link Fencing</td>
								<td align="center" width="12%"><input id="chk10_7d_Y" type="checkbox" size="20" runat="server"></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
						</table>
						<!-- Form 4-->
						<table id="Table2" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 11.0 Chapter II of MDG available at the RO is 
										understood and being followed</b>&nbsp;</td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 12.0 Prices : Displayed &amp; Correctly Charged</b></td>
							</tr>
							<tr>
								<td style="HEIGHT: 25px" colSpan="6">&nbsp; a) MS 87</td>
								<td style="HEIGHT: 25px" align="center" width="1%"><input id="chk12a_Y" type="checkbox" value="ON" runat="server"></td>
								<td style="HEIGHT: 25px" align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; b) MS 93</td>
								<td align="center" width="1%"><input id="chk12b_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; c) MS-ULP</td>
								<td align="center" width="1%"><input id="chk12c_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; d) HSD</td>
								<td align="center" width="1%"><input id="chk12d_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; e) Lubes</td>
								<td align="center" width="1%"><input id="chk12e_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 13.0 Inspection of Other Facilities</b></td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; a) Free Air Service Available</td>
								<td align="center" width="1%"><input id="chk13a_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; b) Free Radiator Water Available</td>
								<td align="center" width="1%"><input id="chk13b_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; c) "Working Hours" Board displayed</td>
								<td align="center" width="1%"><input id="chk13c_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; d) Telephone No of Concerned IOC Officers Are displayed</td>
								<td align="center" width="1%"><input id="chk13d_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; e) Poster for Checking adulteration of MS displayed</td>
								<td align="center" width="1%"><input id="chk13e_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; f) Message : Regarding availability of Complaints and 
									Suggestion Book, Costomer Service&nbsp; Cell&nbsp;and Complaints forwarded to 
									DO</td>
								<td align="center" width="1%"><input id="chk13f_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; g) Presence of Water Checked in Tanks</td>
								<td align="center" width="1%"><input id="chk13g_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; if Found, action Taken : <input id="txt13g" style="WIDTH: 300px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; h) Water Dip Record maintained by Dealer</td>
								<td align="center" width="1%"><input id="chk13h_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; i) Density Register Maintained by Dealer</td>
								<td align="center" width="1%"><input id="chk13i_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; j) Segregated Island for 2/3 Wheelers</td>
								<td align="center" width="1%"><input id="chk13j_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; k) First Aid Box Available</td>
								<td align="center" width="1%"><input id="chk13k_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; l) Filter Paper Available</td>
								<td align="center" width="1%"><input id="chk13l_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; m) 5 Liter measure (Calibrated) available</td>
								<td align="center" width="1%"><input id="chk13m_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; n) Inspection File Maintained</td>
								<td align="center" width="1%"><input id="chk13n_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; o) Valid Trade Licence available</td>
								<td align="center" width="1%"><input id="chk13o_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; p) Explosives Rules displayed
								</td>
								<td align="center" width="1%"><input id="chk13p_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; q) Layout Drawing of RO duly approved by CCE available
								</td>
								<td align="center" width="1%"><input id="chk13q_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; r) Explosives licence Renewed</td>
								<td align="center" width="1%"><input id="chk13r_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; s) No Smoking Board Installed
								</td>
								<td align="center" width="1%"><input id="chk13s_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; t) Telephone No. of Firebrigade, Police,Ambulance displayed</td>
								<td align="center" width="1%"><input id="chk13t_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; u) Weights &amp; Measures Certificate valid
								</td>
								<td align="center" width="1%"><input id="chk13u_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td width="55%" colSpan="6">&nbsp; v) Any Other unauthorised work being carried out 
									at RO,i.e. weiding,etc. or any operations&nbsp;&nbsp; which is not approved by 
									CCE
								</td>
								<td align="center" width="1%"><input id="chk13v_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; w) All the pump attendants in Uniform as per Policy</td>
								<td align="center" width="1%"><input id="chk13w_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
						</table>
						<!--Form 5-->
						<table id="Table1" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td colSpan="22">&nbsp; x) Dealers/Pumps attendents given training in last one year</td>
								<td align="center" width="1%" colSpan="2"><input id="chk13x_Y" type="checkbox" value="ON" name="Checkbox1" runat="server"></td>
							</tr>
							<tr>
								<td width="5%" colSpan="24">&nbsp; if Yes, Nature of Training<br>
									&nbsp;&nbsp; <input id="txt13_nature" style="WIDTH: 500px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td style="HEIGHT: 16px" width="5%" colSpan="24"><b>&nbsp; 14.0 Inspection of Pump 
										Delivery</b>
								</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp;</td>
								<td align="center" width="4%" colSpan="18">Pump Nos</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp;</td>
								<td align="center" colSpan="3">No. 1</td>
								<td align="center" colSpan="3">No. 2</td>
								<td align="center" colSpan="3">No. 3</td>
								<td align="center" colSpan="3">No. 4</td>
								<td align="center" colSpan="3">No. 5</td>
								<td align="center" colSpan="3">No. 6</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; a) Weight &amp; Measures Seal Intact</td>
								<td align="center" width="1%" colSpan="3"><input id="chk14a1_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14a2_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14a3_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14a4_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14a5_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14a6_Y" type="checkbox" value="ON" runat="server"></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; b) Totaliser Seal Intact</td>
								<td align="center" width="1%" colSpan="3"><input id="chk14b1_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14b2_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14b3_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14b4_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14b5_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="3"><input id="chk14b6_Y" type="checkbox" value="ON" runat="server"></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; c) Delivery</td>
								<td align="center" width="1%">C<input id="chk14c1_C" type="radio" name="deleivery1" runat="server"></td>
								<td align="center" width="1%">S<input id="chk14c1_S" type="radio" name="deleivery1" runat="server"></td>
								<td align="center" width="1%">E<input id="chk14c1_E" type="radio" name="deleivery1" runat="server"></td>
								<td align="center" width="1%">C<input id="chk14c2_C" type="radio" name="deleivery2" runat="server"></td>
								<td align="center" width="1%">S<input id="chk14c2_S" type="radio" name="deleivery2" runat="server"></td>
								<td align="center" width="1%">E<input id="chk14c2_E" type="radio" name="deleivery2" runat="server"></td>
								<td align="center" width="1%">C<input id="chk14c3_C" type="radio" name="deleivery3" runat="server"></td>
								<td align="center" width="1%">S<input id="chk14c3_S" type="radio" name="deleivery3" runat="server"></td>
								<td align="center" width="1%">E<input id="chk14c3_E" type="radio" name="deleivery3" runat="server"></td>
								<td align="center" width="1%">C<input id="chk14c4_C" type="radio" name="deleivery4" runat="server"></td>
								<td align="center" width="1%">S<input id="chk14c4_S" type="radio" name="deleivery4" runat="server"></td>
								<td align="center" width="1%">E<input id="chk14c4_E" type="radio" name="deleivery4" runat="server"></td>
								<td align="center" width="1%">C<input id="chk14c5_C" type="radio" name="deleivery5" runat="server"></td>
								<td align="center" width="1%">S<input id="chk14c5_S" type="radio" name="deleivery5" runat="server"></td>
								<td align="center" width="1%">E<input id="chk14c5_E" type="radio" name="deleivery5" runat="server"></td>
								<td align="center" width="1%">C<input id="chk14c6_C" type="radio" name="deleivery6" runat="server"></td>
								<td align="center" width="1%">S<input id="chk14c6_S" type="radio" name="deleivery6" runat="server"></td>
								<td align="center" width="1%">E<input id="chk14c6_E" type="radio" name="deleivery6" runat="server"></td>
							</tr>
							<tr>
								<td align="center" width="4%" colSpan="24"><b>Tick appropriate box &gt; C- Correct, S- 
										Short, E- Excess </b>
								</td>
							</tr>
							<tr>
								<td width="4%" colSpan="24"><b>&nbsp; 15.0 Report on Quality Check of MS/HSD</b></td>
							</tr>
							<tr>
								<td width="7%" colSpan="16">&nbsp;</td>
								<td width="1%" colSpan="2">Tank 1</td>
								<td width="1%" colSpan="2">Tank 2</td>
								<td width="1%" colSpan="2">Tank 3</td>
								<td width="1%" colSpan="2">Tank 4</td>
							</tr>
							<tr>
								<td width="7%" colSpan="16">&nbsp; Product</td>
								<td width="1%" colSpan="2"><input id="txtpro15t1" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txtpro15t2" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txtpro15t3" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txtpro15t4" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="7%" colSpan="16">&nbsp; a) Density Check Conducted</td>
								<td align="center" width="1%" colSpan="2"><input id="chk15aT1_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="2"><input id="chk15aT2_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="2"><input id="chk15aT3_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="2"><input id="chk15aT4_Y" type="checkbox" value="ON" runat="server"></td>
							</tr>
							<tr>
								<td width="7%" colSpan="16">&nbsp; b) Density at 15 degree(C) as ascertained at the 
									time of Inspection</td>
								<td width="1%" colSpan="2"><input id="txt15bT1" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txt15bT2" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txt15bT3" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txt15bT4" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="7%" colSpan="16">&nbsp; c) Density at 15 degree(C) as per Dealers Record</td>
								<td width="1%" colSpan="2"><input id="txt15cT1" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txt15cT2" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txt15cT3" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="1%" colSpan="2"><input id="txt15cT4" style="WIDTH: 50px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="7%" colSpan="16">&nbsp; d) Is Variation within Permissible limits ?</td>
								<td align="center" width="1%" colSpan="2"><input id="chk15dT1_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="2"><input id="chk15dT2_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="2"><input id="chk15dT3_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" width="1%" colSpan="2"><input id="chk15dT4_Y" type="checkbox" value="ON" runat="server"></td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" width="7%" colSpan="16">&nbsp; e) Samples Drawn(if Density 
									variation is beyond permissible limits)
								</td>
								<td style="HEIGHT: 19px" align="center" width="1%" colSpan="2"><input id="chk15eT1_Y" type="checkbox" value="ON" runat="server"></td>
								<td style="HEIGHT: 19px" align="center" width="1%" colSpan="2"><input id="chk15eT2_Y" type="checkbox" value="ON" runat="server"></td>
								<td style="HEIGHT: 19px" align="center" width="1%" colSpan="2"><input id="chk15eT3_Y" type="checkbox" value="ON" runat="server"></td>
								<td style="HEIGHT: 19px" align="center" width="1%" colSpan="2"><input id="chk15eT4_Y" type="checkbox" value="ON" runat="server"></td>
							</tr>
							<tr>
								<td width="4%" colSpan="24">&nbsp; f) Details of Action Taken<br>
									&nbsp;&nbsp; <input id="txt15f" style="WIDTH: 500px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" name="txt15f" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="4%" colSpan="24"><b>&nbsp; 16.0 Report on furfural Check (Applicable in 
										Respect of the ROs Normaly Supplied by Locations undertaking&nbsp;&nbsp; doping 
										of Kerosene)</b></td>
							</tr>
							<tr>
								<td width="4%" colSpan="22">&nbsp; a) Is SKO beinf doped with furfural by the 
									supply point</td>
								<td><input id="chk16a_Y" type="checkbox" value="ON" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="16">&nbsp;</td>
								<td colSpan="2">Tank 1</td>
								<td colSpan="2">Tank 2</td>
								<td colSpan="2">Tank 3</td>
								<td colSpan="2">Tank 4</td>
							</tr>
							<tr>
								<td width="7%" colSpan="24">&nbsp; Detail of Action Taken</td>
							</tr>
							<tr>
								<td colSpan="16">&nbsp; b) Furfural Check conducted
								</td>
								<td align="center" colSpan="2"><input id="chk16bT1_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16bT2_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16bT3_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16bT4_Y" type="checkbox" value="ON" runat="server"></td>
							</tr>
							<tr>
								<td colSpan="16">&nbsp; c) Product Passed Furfural test</td>
								<td align="center" colSpan="2"><input id="chk16cT1_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16cT2_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16cT3_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16cT4_Y" type="checkbox" value="ON" runat="server"></td>
							</tr>
							<tr>
								<td colSpan="16">&nbsp; d) Samples Drawn (if product fails test)</td>
								<td align="center" colSpan="2"><input id="chk16dT1_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16dT2_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16dT3_Y" type="checkbox" value="ON" runat="server"></td>
								<td align="center" colSpan="2"><input id="chk16dT4_Y" type="checkbox" value="ON" runat="server"></td>
							</tr>
							<tr>
								<td colSpan="24">&nbsp; Details of Action Taken<br>
									&nbsp;&nbsp; <input id="txt16_Detail" style="WIDTH: 500px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="24"><b>&nbsp; 17.0 Mobile Lab Inspections</b></td>
							</tr>
							<tr>
								<td colSpan="13">&nbsp; a) Date of Last Visit by Mobile Lab :
								</td>
								<td colSpan="5"><input id="txt17a_Date" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt17a_Date);return false;">
										<IMG class="PopcalTrigger" id="Img36" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="3">Result</td>
								<td colSpan="3"><input id="txt17a_Result" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="4%" colSpan="13">&nbsp; b) Date of Last LDs Sample Drawn :
								</td>
								<td width="4%" colSpan="5"><input id="txt17b_Date" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt17b_Date);return false;">
										<IMG class="PopcalTrigger" id="Img37" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td width="1%" colSpan="3">Result</td>
								<td width="1%" colSpan="3"><input id="txt17b_Result" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="4%" colSpan="13">&nbsp; c) Date of Last Nozzle Sample drawn :
								</td>
								<td width="4%" colSpan="5"><input id="txt17c_Date" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt17c_Date);return false;">
										<IMG class="PopcalTrigger" id="Img38" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td width="1%" colSpan="3">Result</td>
								<td width="1%" colSpan="3"><input id="txt17c_Result" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="8%" colSpan="20" rowSpan="2">&nbsp; <b>Note :- LDs Sample should be drawn at 
										least once a year. draw LDs sample if date at 17.2 is over One year</b></td>
								<td width="1%">MS</td>
								<td width="1%" colSpan="3"><input id="txt17MS" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="1%">HSD</td>
								<td width="1%" colSpan="3"><input id="txt17HSD" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
						</table>
						<!-- Form 6-->
						<table cellSpacing="2" cellPadding="0" width="80%" align="center" border="1" runat="server">
							<tr>
								<td colSpan="8"><b>&nbsp; 18.0 Status Of Payments to Dealer : </b>
								</td>
							</tr>
							<tr>
								<td colSpan="6"><b>&nbsp; 18.1 Dealers Commission Paid Upto : </b>
								</td>
								<td colSpan="2"><input id="txt18_1_Comm" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="6"><b>&nbsp; 18.2 Transport bills : Payed for the period : </b>
								</td>
								<td colSpan="2"><input id="txt18_2_Transport" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="6"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pendig Bills : </b>
								</td>
								<td colSpan="2"><input id="txt18_2_Pending" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; Action plans For Clearing the Bills:<br>
									<input id="txt18_2_Action" style="WIDTH: 500px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove; size: "
										type="text" maxLength="100" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; <b>18.3 Adjustment against short reciept of Product pending</b></td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Product </b>
								</td>
								<td colSpan="4"><input id="txt18_3_product" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"> </B></td>
								<td><input id="chk18_3product_Y" type="checkbox" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Quantity </b>
								</td>
								<td colSpan="4"><input id="txt18_3_quality" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"> </B></td>
								<td><input id="chk18_3quality_Y" type="checkbox" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Invoice Number</b></td>
								<td colSpan="4"><input id="txt18_3_Invoice" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"> </B></td>
								<td><input id="chk18_3invoice_Y" type="checkbox" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Amount</b></td>
								<td colSpan="4"><input id="txt18_3_amount" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"> </B></td>
								<td><input id="chk18_3amount_Y" type="checkbox" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; <b>18.4 Adjustment of Credit Notes/Excess Billing Pending 
										against short reciept of Product pending</b></td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Product </b>
								</td>
								<td colSpan="4"><input id="txt18_4_product" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"> </B></td>
								<td><input id="chk18_4product_Y" type="checkbox" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Quantity </b>
								</td>
								<td colSpan="4"><input id="txt18_4_quantity" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"> </B></td>
								<td><input id="chk18_4quantity_Y" type="checkbox" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp;InvoiceNumber</b></td>
								<td colSpan="4"><input id="txt18_4_Invoice" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"> </B></td>
								<td><input id="chk18_4invoice_Y" type="checkbox" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Amount</b></td>
								<td colSpan="4"><input id="txt18_4_amount" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"> </B></td>
								<td><input id="chk18_4amount_Y" type="checkbox" runat="server"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; Action plans For Clearing the Above:<br>
									<input id="txt18_4_action" style="WIDTH: 500px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; 18.5 Pump Repairing </b>
								</td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; a) No. of visits of chargemen for Preventive Maint.<input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt18_5a" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<TR>
								<td align="center" colSpan="8">Pump Nos</td>
							</TR>
							<tr>
								<td colSpan="2">&nbsp;</td>
								<td>No.1</td>
								<td>No.2</td>
								<td>No.3</td>
								<td>No.4</td>
								<td>No.5</td>
								<td>No.6</td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; b) No.of Break Downs since last Inspection</td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt18_5bN1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt18_5bN2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt18_5bN3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt18_5bN4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt18_5bN5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txt18_5bN6" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; c) Nature of Repairs</td>
								<td><input id="txt18_5cN1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input id="txt18_5cN2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input id="txt18_5cN3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input id="txt18_5cN4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input id="txt18_5cN5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td><input id="txt18_5cN6" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; d) Date of Breakdown Report</td>
								<td><input id="txt18_5dN1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5dN1);return false;"><IMG class="PopcalTrigger" id="Img7" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5dN2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5dN2);return false;"><IMG class="PopcalTrigger" id="Img8" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5dN3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5dN3);return false;"><IMG class="PopcalTrigger" id="Img9" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5dN4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5dN4);return false;"><IMG class="PopcalTrigger" id="Img10" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5dN5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5dN5);return false;"><IMG class="PopcalTrigger" id="Img11" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5dN6" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5dN6);return false;"><IMG class="PopcalTrigger" id="Img12" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; e) Date of C/Man Visit to RO
								</td>
								<td><input id="txt18_5eN1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5eN1);return false;"><IMG class="PopcalTrigger" id="Img24" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5eN2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5eN2);return false;"><IMG class="PopcalTrigger" id="Img25" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5eN3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5eN3);return false;"><IMG class="PopcalTrigger" id="Img26" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5eN4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5eN4);return false;"><IMG class="PopcalTrigger" id="Img27" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5eN5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5eN5);return false;"><IMG class="PopcalTrigger" id="Img28" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5eN6" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5eN6);return false;"><IMG class="PopcalTrigger" id="Img29" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; f) Date of completion of Repair
								</td>
								<td><input id="txt18_5fN1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5fN1);return false;"><IMG class="PopcalTrigger" id="Img30" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5fN2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5fN2);return false;"><IMG class="PopcalTrigger" id="Img31" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5fN3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5fN3);return false;"><IMG class="PopcalTrigger" id="Img32" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5fN4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5fN4);return false;"><IMG class="PopcalTrigger" id="Img33" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5fN5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5fN5);return false;"><IMG class="PopcalTrigger" id="Img34" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
								<td><input id="txt18_5fN6" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt18_5fN6);return false;"><IMG class="PopcalTrigger" id="Img35" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"><br>
										</A></td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; Reasons/Action Plan for Improvement if delay &gt; 1 Day<br>
									&nbsp;&nbsp; <input id="txt18_5_reasons" style="WIDTH: 500px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
						</table>
						<!-- form 7-->
						<table cellSpacing="2" cellPadding="0" width="80%" align="center" border="1" runat="server">
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 18.6 Indent Execution</b></td>
							</tr>
							<tr>
								<td width="12%" colSpan="7">&nbsp; a) Average time needed for Indent Execution</td>
								<td width="12%" colSpan="1"><input id="txt18_6aAvg" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" width="12%" colSpan="7">&nbsp; b) No of Dry Outs due to 
									Delayed Execution, if any since last Inspection</td>
								<td style="HEIGHT: 19px" width="12%" colSpan="1"><input id="txt18_6bNumber" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8">&nbsp; c) Action Plan for avoiding Dry Outs<br>
									&nbsp;&nbsp; <input id="txt18_6cActionplan" style="WIDTH: 500px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" maxLength="100" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 19.0 Details of Action Taken on point of Previous 
										Inspection Report</b></td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" align="center">Sr. No</td>
								<td style="HEIGHT: 19px" align="center" colSpan="2">Date</td>
								<td style="HEIGHT: 19px" align="center" colSpan="2">Action Plan</td>
								<td style="HEIGHT: 19px" colSpan="3">Details of action Taken</td>
							</tr>
							<tr>
								<td colSpan="2"><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt19_0srno1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td colSpan="1"><input id="txt19_0Date1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt19_0Date1);return false;"><IMG class="PopcalTrigger" id="Img13" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt19_0Action1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt19_0Detail1" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt19_0srno2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt19_0Date2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt19_0Date2);return false;"><IMG class="PopcalTrigger" id="Img14" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt19_0Action2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt19_0Detail2" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt19_0srno3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt19_0Date3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt19_0Date3);return false;"><IMG class="PopcalTrigger" id="Img15" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt19_0Action3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt19_0Detail3" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt19_0srno4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt19_0Date4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt19_0Date4);return false;"><IMG class="PopcalTrigger" id="Img16" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt19_0Action4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt19_0Detail4" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt19_0srno5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt19_0Date5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt19_0Date5);return false;"><IMG class="PopcalTrigger" id="Img17" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt19_0Action5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt19_0Detail5" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; 20.0 Details of Pending Action Points</b></td>
							</tr>
							<tr>
								<td align="center">Sr. No</td>
								<td align="center" colSpan="2">Date</td>
								<td align="center" colSpan="2">Action Plan</td>
								<td colSpan="3">Details of action Taken</td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt20_0srno1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt20_0Date1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt20_0Date1);return false;"><IMG class="PopcalTrigger" id="Img18" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt20_0Action1" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt20_0Detail1" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt20_0srno2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt20_0Date2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt20_0Date2);return false;"><IMG class="PopcalTrigger" id="Img19" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt20_0Action2" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt20_0Detail2" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt20_0srno3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt20_0Date3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt20_0Date3);return false;"><IMG class="PopcalTrigger" id="Img20" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt20_0Action3" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt20_0Detail3" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt20_0srno4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt20_0Date4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt20_0Date4);return false;"><IMG class="PopcalTrigger" id="Img21" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt20_0Action4" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt20_0Detail4" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td><input onkeypress="return GetOnlyNumbers(this, event, false,true)" id="txt20_0srno5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="2"><input id="txt20_0Date5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txt20_0Date5);return false;"><IMG class="PopcalTrigger" id="Img22" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
								<td colSpan="2"><input id="txt20_0Action5" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
								<td colSpan="3"><input id="txt20_0Detail5" style="WIDTH: 150px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td align="right" width="12%" colSpan="5">Signature of Inspecting IOC of Official</td>
								<td width="12%" colSpan="3"><input id="txtSignIOC" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="12%" colSpan="5">&nbsp;</td>
								<td width="12%" colSpan="3">&nbsp;Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<input id="txtIOCName" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="12%" colSpan="5">&nbsp; Signature Of Dealer <input id="txtSOD" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" runat="server" class="FontStyle"></td>
								<td width="12%" colSpan="3">&nbsp;Designation <input id="txtIOCdesign" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										type="text" size="20" runat="server" class="FontStyle"></td>
							</tr>
							<tr>
								<td width="12%" colSpan="5">&nbsp;</td>
								<td width="12%" colSpan="3">&nbsp;Date&nbsp;&nbsp; <input id="txtIOCDate" style="WIDTH: 80px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
										 type="text" size="20" runat="server" class="FontStyle"><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtIOCDate);return false;"><IMG class="PopcalTrigger" id="Img23" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A></td>
							</tr>
							<TR align="center">
								<TD width="12%" colSpan="8"><input id="btnSave" tabIndex="11" type="submit" value="Save" runat="server"> 
                                    <input id="btnEdit" tabIndex="1" type="submit" value="Edit" runat="server"> 
                                    <input id="btndelete" tabIndex="1" type="submit" value="Delete" runat="server">
                                     <input id="btnPrint" type="submit" value="Print" runat="server" >
								</TD>
							</TR>
							<TR>
								<TD width="12%" colSpan="8" align="left"><FONT color="#ff0033"><STRONG><U>Note</U>:</STRONG>&nbsp;</FONT><FONT color="black">
										To take a printout press the above Print button, to redirect the output to a 
										new page. Use the Page Setup option in the
										<br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; File menu to 
										set the appropriate&nbsp;margins, then use the Print option in the file menu to 
										send the output to the printer. </FONT>
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></IFRAME>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</BODY>
</HTML>
