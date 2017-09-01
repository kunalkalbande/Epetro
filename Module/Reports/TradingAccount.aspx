<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="TradingAccount.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.TradingAccount" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Trading Account</title><!--
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
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center" height="20">
						<font color="#006400">Trading Account</font>&nbsp;
						<hr>
					</TH>
				</TR>
				<tr>
					<td vAlign="top" align="center">Date From&nbsp;
						<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="Please Select From Date From the Calender">*</asp:requiredfieldvalidator>&nbsp;
						<asp:textbox id="txtDateFrom" runat="server" Width="110px" CssClass="FontStyle"
							BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A> Date To&nbsp;
						<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ControlToValidate="txtDateTo" ErrorMessage="Please Select To Date From the Calender">*</asp:requiredfieldvalidator>&nbsp;
						<asp:textbox id="txtDateTo" runat="server" Width="110px" CssClass="FontStyle"
							BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A></td>
				<TR>
					<TD vAlign="top" align="center" colSpan="5">
                        <asp:button id="btnShow" runat="server" Width="70px" Text="View"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="BtnPrint" Width="70px" Text="Print " Runat="server"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnExcel" Width="70px" Text="Excel" Runat="server"></asp:button></TD>
				</TR>
				<tr height="50">
				</tr>
				<TR>
					<TD style="HEIGHT: 170px" vAlign="top" align="center">
						<TABLE id="Table1" border="1" runat="server">
							<tr>
								<th colSpan="5">
									<b><font color="#006400">Debit Side</font></b>&nbsp;
								</th>
								<th colSpan="5">
									<b><font color="#006400">Credit Side</font></b>
								</th>
							</tr>
							<TR>
								<TD style="HEIGHT: 110px" align="center" colSpan="5"><table border="0">
										<tr>
											<!--<th align="center" colspan="2">
												<b>LIABILITIES</b>
											</th>
											<th align="center" colspan="3">
												<b></b>
											</th>--></tr>
										<tr>
											<td align="left" width="100"><asp:label id="lblOpeningStock" runat="server" Font-Size="8pt" Font-Bold="True">Opening Stock</asp:label></td>
											<td align="right" width="80"><asp:label id="lblOpeningStockValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblPurchase" runat="server" Font-Size="8pt" Font-Bold="True"> Purchase</asp:label></td>
											<td align="right" width="80"><asp:label id="lblPurchaseValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblDirectExpenses" runat="server" Font-Size="8pt" Font-Bold="True">Direct Expenses</asp:label></td>
											<td align="right" width="80"><asp:label id="lblDirectExpensesValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
											<td align="right" width="80"></td>
										</tr>
										<tr>
											<td style="HEIGHT: 15px"><asp:label id="lblGrossProfit" runat="server" Font-Size="8pt" Font-Bold="True">Gross Profit</asp:label></td>
											<td style="HEIGHT: 15px" align="right" width="80"><asp:label id="lblGrossProfitValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<!--<tr>
											<td vAlign=bottom></td>
											<td width="80" align="right"></td>
										</tr>-->
										<tr>
											<td vAlign="middle">
												<hr style="FONT-WEIGHT: normal; COLOR: buttontext; BORDER-TOP-STYLE: double; BORDER-RIGHT-STYLE: double; BORDER-LEFT-STYLE: double; HEIGHT: 1px; BORDER-BOTTOM-STYLE: double">
												<asp:label id="lblDebitTotal" runat="server" Font-Size="8pt" Font-Bold="True">TOTAL</asp:label>
												<hr style="COLOR: black; HEIGHT: 1px">
											</td>
											<td vAlign="middle" align="right" width="80">
												<hr style="COLOR: #ffffff">
												<asp:label id="lblDebitTotalValue" runat="server" Width="80px" Font-Bold="True"></asp:label>
												<hr style="COLOR: #ffffff">
											</td>
										</tr>
										<tr>
										</tr>
										<tr>
										</tr>
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
											<td><asp:label id="lblSales" runat="server" Font-Size="8pt" Font-Bold="True">Sales</asp:label></td>
											<td align="right" width="80"><asp:label id="lblSalesValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td><asp:label id="lblClosingStock" runat="server" Font-Size="8pt" Font-Bold="True">Closing Stock</asp:label></td>
											<td align="right" width="80"><asp:label id="lblClossingStockValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td><asp:label id="lblDirectIncome" runat="server" Font-Size="8pt" Font-Bold="True">Direct Income</asp:label></td>
											<td align="right" width="80"><asp:label id="lblDirectIncomeValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td style="HEIGHT: 9px"></td>
											<td style="HEIGHT: 9px"></td>
											<td style="HEIGHT: 9px">&nbsp;</td>
											<td style="HEIGHT: 9px" align="right" width="80"></td>
										</tr>
										<tr>
											<td style="HEIGHT: 10px"></td>
											<td style="HEIGHT: 10px"></td>
											<td style="HEIGHT: 10px">
												<asp:label id="lblGrossLoss" runat="server" Visible="False" Font-Bold="True" Font-Size="8pt">Gross Loss</asp:label>&nbsp;</td>
											<td style="HEIGHT: 10px" align="right" width="80">
												<asp:label id="lblGrossLossAmount" runat="server" Visible="False" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td vAlign="middle" width="100">
												<hr style="FONT-WEIGHT: normal; COLOR: buttontext; BORDER-TOP-STYLE: double; BORDER-RIGHT-STYLE: double; BORDER-LEFT-STYLE: double; HEIGHT: 1px; BORDER-BOTTOM-STYLE: double">
												<asp:label id="lblCreditTotal" runat="server" Font-Size="8pt" Font-Bold="True">TOTAL</asp:label>
												<hr style="COLOR: black; HEIGHT: 1px">
											</td>
											<td align="right" width="80">
												<HR style="COLOR: #ffffff">
												<asp:label id="lblCreditTotalValue" runat="server" Width="80px" Font-Bold="True"></asp:label>
												<HR style="COLOR: #ffffff">
											</td>
										</tr>
										<tr>
										</tr>
										<tr>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<th align="center" colSpan="10">
									<font color="#006400">Profit&nbsp;&amp; Loss Account</font></th></TR>
							<tr>
								<TD style="HEIGHT: 90px" vAlign="top" align="center" colSpan="5">
									<table border="0">
										<tr>
											<td>
												<asp:label id="lblGrossLoss1" runat="server" Visible="False" Font-Bold="True" Font-Size="8pt">Gross Loss</asp:label>&nbsp;</td>
											<td align="right" width="80">
												<asp:label id="lblGrossLoss1Amount" runat="server" Visible="False" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td>
												<asp:label id="lblIndirectExp" runat="server" Font-Bold="True" Font-Size="8pt">Indirect Expenses</asp:label></td>
											<td align="right" width="80">
												<asp:label id="lblIndirectExpensesValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td><asp:label id="lblNetProfit" runat="server" Font-Size="8pt" Font-Bold="True">Net Profit</asp:label>&nbsp;</td>
											<td align="right" width="80">
												<asp:label id="lblNetProfitValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
											<td align="right" width="80"></td>
										</tr>
										<tr>
											<td style="HEIGHT: 15px">
												<HR style="FONT-WEIGHT: normal; COLOR: buttontext; BORDER-TOP-STYLE: double; BORDER-RIGHT-STYLE: double; BORDER-LEFT-STYLE: double; HEIGHT: 1px; BORDER-BOTTOM-STYLE: double">
												<asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="8pt">TOTAL</asp:label>
												<HR style="COLOR: black; HEIGHT: 1px">
											</td>
											<td style="HEIGHT: 15px" align="right" width="80">
												<asp:label id="lblTotal1Value" runat="server" Width="80px" Font-Bold="True"></asp:label></td>
										</tr>
										<!--<tr>
											<td vAlign=bottom></td>
											<td width="80" align="right"></td>
										</tr>-->
										<tr>
											<td vAlign="middle"></td>
											<td align="right" width="80"></td>
										</tr>
										<tr>
										</tr>
										<tr>
										</tr>
									</table>
								</TD>
								<TD style="HEIGHT: 90px" vAlign="top" align="center" colSpan="5">
									<table border="0">
										<tr>
											<td></td>
											<td></td>
											<td width="100"><asp:label id="lblGrossProfit1" runat="server" Font-Size="8pt" Font-Bold="True">Gross Profit</asp:label>&nbsp;</td>
											<td align="right" width="80">
												<asp:label id="lblGrossProfit1Value" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td>
												<asp:label id="lblIndirectIncome" runat="server" Font-Bold="True" Font-Size="8pt">Indirect Income</asp:label></td>
											<td align="right" width="80">
												<asp:label id="lblIndirectIncomeValue" runat="server" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td>
												<asp:label id="lblNetLoss" runat="server" Visible="False" Font-Bold="True" Font-Size="8pt">Net Loss</asp:label>&nbsp;</td>
											<td align="right" width="80">
												<asp:label id="lblNetLossAmount" runat="server" Visible="False" Width="80px"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td>&nbsp;</td>
											<td align="right" width="80"></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td style="HEIGHT: 15px" vAlign="top">
												<HR style="FONT-WEIGHT: normal; COLOR: buttontext; BORDER-TOP-STYLE: double; BORDER-RIGHT-STYLE: double; BORDER-LEFT-STYLE: double; HEIGHT: 1px; BORDER-BOTTOM-STYLE: double">
												<asp:label id="Label2" runat="server" Font-Bold="True" Font-Size="8pt">TOTAL</asp:label>
												<HR style="COLOR: black; HEIGHT: 1px">
											</td>
											<td style="HEIGHT: 15px" align="right" width="80">
												<asp:label id="lblTotal2Value" runat="server" Width="80px" Font-Bold="True"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td vAlign="middle"></td>
											<td align="right" width="80"></td>
										</tr>
										<tr>
										</tr>
										<tr>
										</tr>
									</table>
								</TD>
							</tr>
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
