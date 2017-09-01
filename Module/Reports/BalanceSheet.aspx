<%@ Page language="c#" Codebehind="BalanceSheet.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.BalanceSheet" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Balance Sheet</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:textbox id="TextBox2" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox><uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center" border=1>
				<TR>
					<TH align="center" height="20" colspan=5>
						<font color="#006400">Balance Sheet</font>
						<hr>
					</TH>
				</TR>
				<tr height=20>
					<td align="center">Date From</td>
					<td><asp:textbox id="txtDateFrom" runat="server" Width="110px"  CssClass="FontStyle"
							BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A></td>
					<td align=center>Date To</td>
					<td><asp:textbox id="txtDateTo" runat="server" Width="110px"  CssClass="FontStyle"
							BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A></td>
					<TD vAlign="top" align="center"><asp:button id="btnShow" runat="server" Width="70px" Text="View" ></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="BtnPrint" Width="70px" Text="Print " Runat="server" ></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnExcel" Width="70px" Text="Excel" Runat="server"></asp:button></TD>
				</tr>
				<tr height="50">
				</tr>
				<TR>
					<TD vAlign="top" align="center" colspan=5>
						<TABLE id="Table1" border="1" runat="server">
							<tr>
								<th align="center" colSpan="5">
									<b><font color="#006400">LIABILITIES</font></b>
								</th>
								<th align="center">
									<b><font color="#006400">ASSETS</font></b>
								</th>
							</tr>
							<TR>
								<TD style="HEIGHT: 110px" vAlign="top" align="center" colSpan="5">
									<table border="0">
										<tr>
											<!--<th align="center" colspan="2">
												<b>LIABILITIES</b>
											</th>
											<th align="center" colspan="3">
												<b></b>
											</th>--></tr>
										<tr>
											<td><asp:label id="lblCapital" runat="server" Font-Size="8pt" Font-Bold="True">Capital</asp:label></td>
											<td align="right" width="80"><asp:label id="lblCapitalValue" runat="server" Width="80px" ForeColor="Black"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblRes_Surplus" runat="server" Font-Size="8pt" Font-Bold="True">Reserve & Surplus</asp:label></td>
											<td align="right" width="80"><asp:label id="lblRes_Sur_Value" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblSecuredLoans" runat="server" Font-Size="8pt" Font-Bold="True">Secured Loans</asp:label></td>
											<td align="right" width="80"><asp:label id="lblSecuredLoansValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblUnsecuredLoans" runat="server" Font-Size="8pt" Font-Bold="True">Unsecured Loans</asp:label></td>
											<td align="right" width="80"><asp:label id="lblunsecuredValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td style="HEIGHT: 15px"><asp:label id="lblCurrentLiabilities" runat="server" Font-Size="8pt" Font-Bold="True">Current Liabilities</asp:label></td>
											<td style="HEIGHT: 15px" align="right" width="80"><asp:label id="lblCurrentValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblProvisions" runat="server" Font-Size="8pt" Font-Bold="True">Provisions</asp:label></td>
											<td align="right" width="80"><asp:label id="lblProvisionsValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<TR>
											<TD><asp:label id="lblDiffCreditBal" runat="server" Font-Size="8pt" Font-Bold="True">Diff. In Opening Balance</asp:label>&nbsp;</TD>
											<TD align="right" width="80"><asp:label id="lblDiffBal1" runat="server" Width="75px" ForeColor="DarkGreen"></asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
											<TD align="right" width="80">&nbsp;</TD>
										</TR>
										<TR>
											<TD>
												<HR style="COLOR: black; HEIGHT: 1px">
												<asp:label id="Label1" runat="server" Font-Size="8pt" Font-Bold="True">TOTAL</asp:label>
												<HR style="FONT-WEIGHT: normal; COLOR: buttontext; BORDER-TOP-STYLE: double; BORDER-RIGHT-STYLE: double; BORDER-LEFT-STYLE: double; HEIGHT: 1px; BORDER-BOTTOM-STYLE: double">
											</TD>
											<TD align="right" width="80"><asp:label id="lblTotal1Value" runat="server" Width="80px" Font-Bold="True"></asp:label></TD>
										</TR>
									</table>
								</TD>
								<TD style="HEIGHT: 120px" align="center" colSpan="5"><table border="0">
										<tr>
											<!--<th align=center colspan = 2 >
								<b>ASSETS</b>						
								</th>--></tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblFixedAssets" runat="server" Font-Size="8pt" Font-Bold="True">Fixed Assets</asp:label></td>
											<td align="right" width="80"><asp:label id="lblFixedAssetsValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblInvestments" runat="server" Font-Size="8pt" Font-Bold="True">Investments</asp:label></td>
											<td align="right" width="80"><asp:label id="lblInvestmentValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblCurrentAssets" runat="server" Font-Size="8pt" Font-Bold="True">Current Assets</asp:label></td>
											<td align="right" width="80"><asp:label id="lblCurrentAssetsValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblLoansAdvances" runat="server" Font-Size="8pt" Font-Bold="True">Loans & Advances</asp:label></td>
											<td align="right" width="80"><asp:label id="lblLoansAdvancesValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td style="HEIGHT: 15px"><asp:label id="lblProfitLossAC" runat="server" Font-Size="8pt" Font-Bold="True">Profit & Loss A/C</asp:label></td>
											<td style="HEIGHT: 15px" align="right" width="80"><asp:label id="lblProfitLossValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td><asp:label id="lblMiscExp" runat="server" Font-Size="8pt" Font-Bold="True">Misc. Expenditure</asp:label></td>
											<td align="right" width="80"><asp:label id="lblMiscExpValue" runat="server" Width="75px"></asp:label></td>
										</tr>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD><asp:label id="lblDiffBalDebit" runat="server" Font-Size="8pt" Font-Bold="True">Diff. In Opening Balance</asp:label>&nbsp;</TD>
											<TD align="right" width="80"><asp:label id="lblDiffBal2" runat="server" Width="75px" ForeColor="DarkGreen"></asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
											<TD align="right" width="80">&nbsp;</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD>
												<HR style="FONT-WEIGHT: normal; COLOR: buttontext; BORDER-TOP-STYLE: double; BORDER-RIGHT-STYLE: double; BORDER-LEFT-STYLE: double; HEIGHT: 1px; BORDER-BOTTOM-STYLE: double">
												<asp:label id="Label2" runat="server" Font-Size="8pt" Font-Bold="True">TOTAL</asp:label>
												<HR style="COLOR: black; HEIGHT: 1px">
											</TD>
											<TD align="right" width="80"><asp:label id="lblTotal2Value" runat="server" Width="80px" Font-Bold="True"></asp:label></TD>
										</TR>
									</table>
								</TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" Width="138px" Height="22px" ShowSummary="False"
							ShowMessageBox="True"></asp:validationsummary></TD>
				</TR>
				<tr>
					<td align="right"></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
