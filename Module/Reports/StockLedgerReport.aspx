<%@ Page language="c#" Codebehind="StockLedgerReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.StockLedgerReport" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Stock Ledger Report</title> <!--
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
		<script language="javascript" id="clientEventHandlersJS">


function window_onload() 
{
}

		</script>
	</HEAD>
	<body language="javascript" onLoad="return window_onload()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 152px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR>
					<TH style="HEIGHT: 4px">
						<font color="#006400">Stock Ledger Report</font>
						<hr>
					</TH>
				</TR>
				<TR>
					<TD style="HEIGHT: 61px" align="center">
						<TABLE>
							<TR>
								<TD>From Date</TD>
								<TD><asp:textbox id="txtDateFrom" runat="server" Width="110px"  BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD>To Date</TD>
								<TD><asp:textbox id="txtDateTo" runat="server" Width="110px" BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
							</TR>
							<tr>
								<TD>Product Name</TD>
								<td><asp:dropdownlist id="drpProductName" runat="server" Width="300px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></td>
								<TD>Transaction Type</TD>
								<td><asp:dropdownlist id="drpTransType" runat="server" Width="111px" CssClass="FontStyle">
										<asp:ListItem Value="All">All</asp:ListItem>
										<asp:ListItem Value="Cash">Cash</asp:ListItem>
										<asp:ListItem Value="Purchase">Purchase</asp:ListItem>
										<asp:ListItem Value="Sales">Sales</asp:ListItem>
										<asp:ListItem Value="Others">Others</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</TABLE>
						<br>
						<asp:button id="cmdrpt" runat="server" Text="View " Width="70px" ></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnPrint" Text="Print  " Runat="server" Width="70px" ></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnExcel" Width="70px" Text="Excel" Runat="server"></asp:button></TD>
				</TR>
				<tr>
					<td align="center">
						<asp:datagrid id="Stock_Ledger" runat="server" Width="711px" AutoGenerateColumns="False" BorderColor="DarkSeaGreen"
							BorderStyle="None" BorderWidth="0px" BackColor="DarkSeaGreen" CellPadding="1" CellSpacing="1"
							AllowSorting="True" OnSortCommand="SortCommand_Click">
							<SelectedItemStyle ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" Height="30px" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Trans_Type" SortExpression="Trans_Type" HeaderText="Transaction Type">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Trans_ID" SortExpression="Trans_ID" HeaderText="Transaction ID">
									<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<FooterStyle HorizontalAlign="Center"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Trans_Date" SortExpression="Trans_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
									<HeaderStyle Width="50px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="In_Qty_Nos" HeaderText="IN<br>Qty in Nos. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Qty in Ltr">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
											<TR>
												<TD align="right" width="60"><font color="#4a3c8c"><%#checkValue(DataBinder.Eval(Container.DataItem,"In_Qty_Nos","{0:N2}").ToString())%></font></TD>
												<TD align="right" width="60"><font color="#4a3c8c"><%#checkValue(DataBinder.Eval(Container.DataItem,"In_Qty_Ltr","{0:N2}").ToString())%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Out_Qty_Nos" HeaderText="OUT<br>Qty in Nos. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Qty in Ltr">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
											<TR>
												<TD align="right" width="60"><font color="#4a3c8c"><%#checkValue(DataBinder.Eval(Container.DataItem,"Out_Qty_Nos","{0:N2}").ToString())%></font></TD>
												<TD align="right" width="60"><font color="#4a3c8c"><%#checkValue(DataBinder.Eval(Container.DataItem,"Out_Qty_Ltr","{0:N2}").ToString())%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Closing_Bal_Nos" HeaderText="CLOSING BALANCE<br>Qty in Nos. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Qty in Ltr">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
											<TR>
												<TD align="right" width="60"><font color="#4a3c8c"><%#checkValue(DataBinder.Eval(Container.DataItem,"Closing_Bal_Nos","{0:N2}").ToString())%></font></TD>
												<TD align="right" width="60"><font color="#4a3c8c"><%#checkValue(DataBinder.Eval(Container.DataItem,"Closing_Bal_Ltr","{0:N2}").ToString())%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
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
