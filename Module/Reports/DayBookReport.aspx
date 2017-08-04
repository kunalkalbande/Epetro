<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="DayBookReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.DayBookReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Day Book Report</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center" height="30">
						<font color="#006400">Day Book Report</font>
						<hr>
					</TH>
				</TR>
				<tr height="20">
					<td align="center">Date From&nbsp;&nbsp;&nbsp;<asp:textbox id="txtDateFrom" runat="server"  BorderStyle="Groove" CssClass="FontStyle"
							Width="80px"></asp:textbox>&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date 
						To&nbsp;&nbsp;&nbsp;<asp:textbox id="txtDateTo" runat="server"  BorderStyle="Groove" CssClass="FontStyle"
							Width="80px"></asp:textbox>&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnView" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" Text="View "></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="Btnprint" Width="70px" ForeColor="White" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
							Text="Print  " Runat="server"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnExcel" Width="70px" ForeColor="White" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
							Text="Excel" Runat="server"></asp:button>
					</td>
				</tr>
				<tr height="20">
					<td align="center"><asp:checkbox id="chkReceipt" Text="Receipt" Runat="server" Checked="True"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkPayment" Text="Payment" Runat="server" Checked="True"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkContra" Text="Contra" Runat="server" Checked="True"></asp:checkbox>
						&nbsp;&nbsp;<asp:checkbox id="chkJournel" Text="Journel" Runat="server" Checked="True"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkCN" Text="CN" Runat="server" Checked="True"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkDN" Text="DN" Runat="server" Checked="True"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkCS" Text="CS" Runat="server" Checked="True"></asp:checkbox>
						&nbsp;&nbsp;<asp:checkbox id="chkSWS" Text="SWS" Runat="server" Checked="True"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkFCS" Text="FCS" Runat="server" Checked="True"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkCCS" Text="CCS" Runat="server" Checked="True"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkFuelPer" Text="Fuel Per." Runat="server" Checked="True"></asp:checkbox>
						&nbsp;&nbsp;<asp:checkbox id="chkOtherPer" Text="OtherPer." Runat="server" Checked="True"></asp:checkbox>
					</td>
				</tr>
				<tr>
					<td align="center">
						<TABLE id="Table1" width="80%">
							<TR>
								<TD align="center" colSpan="6"><asp:datagrid id="GrdDayBook" runat="server" BorderStyle="None" Width="100%" BackColor="DarkSeaGreen"
										BorderColor="DarkSeaGreen" ShowFooter="True" OnItemDataBound="ItemTotal" AllowSorting="True" CellSpacing="1" AutoGenerateColumns="False"
										BorderWidth="0px" CellPadding="1" OnSortCommand="SortCommand_Click">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" VerticalAlign="Top" BackColor="#738A9C"></SelectedItemStyle>
										<AlternatingItemStyle ForeColor="#4A3C8C" VerticalAlign="Top" BackColor="#EEFFE9"></AlternatingItemStyle>
										<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
										<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Particulars" SortExpression="Particulars" HeaderText="Transaction Name"
												FooterText="Total">
												<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Transaction No"></asp:TemplateColumn>
											<asp:BoundColumn DataField="Entry_Date" SortExpression="Entry_Date" HeaderText="Transaction Date"
												DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="Ledger_Name" SortExpression="Ledger_Name" HeaderText="Account Name"></asp:BoundColumn>
											<asp:BoundColumn DataField="Debit_Amount" SortExpression="Debit_Amount" HeaderText="Debit Amount"
												DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Credit_Amount" SortExpression="Credit_Amount" HeaderText="Credit Amount"
												DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="right"><A href="javascript:window.print()"></A></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
