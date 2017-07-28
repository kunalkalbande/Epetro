<%@ Page language="c#" Codebehind="LedgerReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.CustomerLedger" %>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Ledger Report</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox>
			<table height="288" width="778" align="center">
				<TBODY>
					<TR vAlign="top" height="10">
						<TH>
							<font color="#006400">Ledger Report</font>
							<hr>
						</TH>
					</TR>
					<TR>
						<TD vAlign="top" height="30">
							<TABLE align="center" border="0">
								<TR>
									<TD vAlign="middle" align="center">Date From</TD>
									<TD vAlign="top">&nbsp;<asp:textbox id="txtDateFrom" runat="server" Width="115px" CssClass="FontStyle" BorderStyle="Groove"
											></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<TD vAlign="middle" align="center" width="25">To</TD>
									<TD vAlign="top"><asp:textbox id="txtDateTo" runat="server" Width="115px" CssClass="FontStyle" BorderStyle="Groove"
											></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<td colSpan="2"><u>Remark:</u> <STRONG>CB</STRONG> (Closing Balance)</td>
								</TR>
								<TR>
									<TD vAlign="middle" align="center" colSpan="5">Report Type&nbsp;&nbsp;&nbsp;
										<asp:dropdownlist id="DropReportType" Width="138" CssClass="FontStyle" Runat="server">
											<asp:ListItem Value="Detail Ledger">Detail Ledger</asp:ListItem>
											<asp:ListItem Value="Summerized Ledger">Summerized Ledger</asp:ListItem>
										</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Party Name&nbsp;&nbsp;&nbsp;
										<asp:dropdownlist id="DropPartyName" runat="server" Width="280px" CssClass="FontStyle">
											<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
								<tr>
									<TD align="center" colSpan="11"><asp:button id="cmdrpt" runat="server" Width="70px" Text="View " BorderColor="DarkSeaGreen"
											BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="BtnPrint" Width="70px" Runat="server" Text="Print" BorderColor="DarkSeaGreen"
											BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnExcel" Width="70px" Runat="server" Text="Excel" BorderColor="DarkSeaGreen"
											BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;</TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center"><asp:datagrid id="Datagrid1" runat="server" BorderStyle="None" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
								CellPadding="1" BorderWidth="0px" AutoGenerateColumns="False" OnItemDataBound="ItemTotal1" CellSpacing="1" DESIGNTIMEDRAGDROP="52"
								AllowSorting="True" OnSortCommand="SortCommand_Click">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
								<Columns>
									<asp:BoundColumn SortExpression="Entry_Date" HeaderText="Transaction No." FooterText="Total:">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle Width="60px"></ItemStyle>
										<FooterStyle Font-Bold="True"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Particulars" SortExpression="Particulars" HeaderText="Transaction Type">
										<HeaderStyle Width="120px"></HeaderStyle>
										<ItemStyle Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Entry_Date" SortExpression="Entry_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle Width="60px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Debit_Amount" SortExpression="Debit_Amount" HeaderText="Debit" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Credit_Amount" SortExpression="Credit_Amount" HeaderText="Credit" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn SortExpression="balance" HeaderText="Closing Balance">
										<HeaderStyle Width="120px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
										<ItemTemplate>
											<%#setBal(GenUtil.strNumericFormat(DataBinder.Eval(Container.DataItem,"balance","{0:N2}").ToString()))%>
											<%#setType(DataBinder.Eval(Container.DataItem,"bal_type").ToString())%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:datagrid id="CustomerGrid" runat="server" BorderStyle="None" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
								CellPadding="1" BorderWidth="0px" AutoGenerateColumns="False" OnItemDataBound="ItemTotal" CellSpacing="1"
								AllowSorting="True" OnSortCommand="SortCommand_Click" ShowFooter="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
								<Columns>
									<asp:BoundColumn SortExpression="Entry_Date" HeaderText="Transaction No." FooterText="Total:">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle Width="60px"></ItemStyle>
										<FooterStyle Font-Bold="True"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Particulars" SortExpression="Particulars" HeaderText="Transaction Type">
										<HeaderStyle Width="120px"></HeaderStyle>
										<ItemStyle Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Entry_Date" SortExpression="Entry_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle Width="60px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Debit_Amount" SortExpression="Debit_Amount" HeaderText="Debit" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Credit_Amount" SortExpression="Credit_Amount" HeaderText="Credit" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn SortExpression="balance" HeaderText="Closing Balance">
										<HeaderStyle Width="120px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
										<ItemTemplate>
											<%#setBal(GenUtil.strNumericFormat(DataBinder.Eval(Container.DataItem,"balance","{0:N2}").ToString()))%>
											<%#setType(DataBinder.Eval(Container.DataItem,"bal_type").ToString())%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:datagrid id="TotalSales" runat="server" BorderStyle="None" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
								CellPadding="1" BorderWidth="0px" AutoGenerateColumns="False" OnItemDataBound="ItemTotal2" CellSpacing="1"
								AllowSorting="True" OnSortCommand="SortCommand_Click" ShowFooter="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
								<Columns>
									<asp:BoundColumn SortExpression="Entry_Date" HeaderText="Transaction No." FooterText="Total:">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle Width="60px"></ItemStyle>
										<FooterStyle Font-Bold="True"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Particulars" SortExpression="Particulars" HeaderText="Transaction Type">
										<HeaderStyle Width="120px"></HeaderStyle>
										<ItemStyle Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Entry_Date" SortExpression="Entry_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle Width="60px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Debit_Amount" SortExpression="Debit_Amount" HeaderText="Debit" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Credit_Amount" SortExpression="Credit_Amount" HeaderText="Credit" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn SortExpression="balance" HeaderText="Closing Balance">
										<HeaderStyle Width="120px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="120px"></ItemStyle>
										<ItemTemplate>
											<%#setBalance1(DataBinder.Eval(Container.DataItem,"Debit_Amount").ToString(),DataBinder.Eval(Container.DataItem,"Credit_Amount").ToString())%>
											<%="Dr"%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:datagrid id="Datagrid2" runat="server" BorderStyle="None" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
								CellPadding="1" BorderWidth="0px" AutoGenerateColumns="False" OnItemDataBound="ItemTotal2" CellSpacing="1"
								AllowSorting="True" OnSortCommand="SortCommand_Click" ShowFooter="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Month" FooterText="Total">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"entry_date").ToString()%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Debit_Amount" HeaderText="Debit_Amount">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
										<ItemTemplate>
											<%#GetDebit(DataBinder.Eval(Container.DataItem,"Debit_Amount","{0:N2}").ToString())%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
										<FooterTemplate>
											<%=GenUtil.strNumericFormat(Cache["dr"].ToString())%>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Credit_Amount" HeaderText="Credit_Amount">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
										<ItemTemplate>
											<%#GetCredit(DataBinder.Eval(Container.DataItem,"Credit_Amount","{0:N2}").ToString())%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
										<FooterTemplate>
											<%=GenUtil.strNumericFormat(Cache["cr"].ToString())%>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="balance" HeaderText="Closing Balance">
										<HeaderStyle Width="130px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Width="130px"></ItemStyle>
										<ItemTemplate>
											<%#setCBal(DataBinder.Eval(Container.DataItem,"Debit_Amount").ToString(),DataBinder.Eval(Container.DataItem,"Credit_Amount").ToString())%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
										<FooterTemplate>
											<%#setMonth()%>
										</FooterTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TBODY>
			</table>
			</TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
