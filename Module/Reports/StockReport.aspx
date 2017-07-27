<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Import namespace="EPetro.Sysitem.Classes" %>
<%@ Page language="c#" Codebehind="StockReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.StockReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Stock Report</title> <!--
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
<!--

function window_onload() 
{
}

//-->
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 152px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR>
					<TH style="HEIGHT: 4px">
						<font color="#006400">Stock Report</font>
						<hr>
					</TH>
				</TR>
				<TR>
					<TD style="HEIGHT: 61px" align="center">
						<TABLE>
							<TR>
								<TD>Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtDateTo" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD>Stock Location&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
									<asp:dropdownlist id="drpstore" runat="server" CssClass="FontStyle"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
						Valuation &nbsp;&nbsp;&nbsp;<asp:RadioButton Runat="server" ID="RadioYes" GroupName="Yes" Text="Yes"></asp:RadioButton>
						<asp:RadioButton Runat="server" ID="RadioNo" GroupName="Yes" Text="No"></asp:RadioButton>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdrpt" runat="server" Width="70px" Text="View " BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnPrint" Width="70px" Text="Print  " BorderColor="DarkSeaGreen" BackColor="ForestGreen"
							ForeColor="White" Runat="server"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnExcel" Width="70px" Text="Excel" BorderColor="DarkSeaGreen" BackColor="ForestGreen"
							ForeColor="White" Runat="server"></asp:button></TD>
				</TR>
				<tr>
					<td align="center"><asp:datagrid id="grdLeg" runat="server" BorderStyle="None" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
							CellSpacing="1" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="1" ShowFooter="True" AllowSorting="True"
							OnSortCommand="SortCommand_Click">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" VerticalAlign="Middle"
								BackColor="#009900"></FooterStyle>
							<Columns>
								<asp:TemplateColumn SortExpression="product" HeaderText="Product Name" FooterText="Total">
									<ItemTemplate>
										<%#DataBinder.Eval(Container.DataItem,"Product")%>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Store_In" HeaderText="Location">
									<ItemTemplate>
										<%#IsTank(DataBinder.Eval(Container.DataItem,"Store_in").ToString())%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Closing_Stock" HeaderText="Closing Stock<br>Pkg &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lt./Kg">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE align="center" cellspacing="0" width="100%" border="0" cellpadding="0" cellspacing="0">
											<TR>
												<TD align="left"><font color="4a3c8c"><%#Check(DataBinder.Eval(Container.DataItem,"closing_stock").ToString(),DataBinder.Eval(Container.DataItem,"Category").ToString(),DataBinder.Eval(Container.DataItem,"pack_type").ToString())%></font></TD>
												<TD align="right"><font color="4a3c8c"><%#Multiply(DataBinder.Eval(Container.DataItem,"closing_stock").ToString()+"X" +DataBinder.Eval(Container.DataItem,"pack_type").ToString())%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE align="center" cellspacing="0" width="100%" border="0" cellpadding="0" cellspacing="0">
											<TR>
												<TD align="left"><font color="f7f7f7"><b><%=Cache["csp"]%></b></font></TD>
												<TD align="right"><font color="f7f7f7"><b><%=Cache["cs"]%></b></font></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Amount" HeaderText="Amount">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
									<ItemTemplate>
										<%#GetAmount(Check(DataBinder.Eval(Container.DataItem,"closing_stock").ToString(),DataBinder.Eval(Container.DataItem,"Category").ToString(),DataBinder.Eval(Container.DataItem,"pack_type").ToString()),Multiply1(DataBinder.Eval(Container.DataItem,"closing_stock").ToString()+"X" +DataBinder.Eval(Container.DataItem,"pack_type").ToString()),DataBinder.Eval(Container.DataItem,"sal_rate").ToString())%>
									</ItemTemplate>
									<FooterTemplate>
										<%=GenUtil.strNumericFormat(Cache["Amount"].ToString())%>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><asp:datagrid id="Datagrid1" runat="server" BorderStyle="None" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
							CellSpacing="1" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="1" ShowFooter="True" AllowSorting="True"
							OnSortCommand="SortCommand_Click">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" VerticalAlign="Middle"
								BackColor="#009900"></FooterStyle>
							<Columns>
								<asp:TemplateColumn SortExpression="product" HeaderText="Product Name" FooterText="Total">
									<ItemTemplate>
										<%#DataBinder.Eval(Container.DataItem,"Product")%>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Store_In" HeaderText="Location">
									<ItemTemplate>
										<%#IsTank(DataBinder.Eval(Container.DataItem,"Store_in").ToString())%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Closing_Stock" HeaderText="Closing Stock&lt;br&gt;Pkg &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Lt./Kg">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE align="center" cellspacing="0" width="100%" border="0" cellpadding="0" cellspacing="0">
											<TR>
												<TD align="left"><font color="4a3c8c"><%#Check(DataBinder.Eval(Container.DataItem,"closing_stock").ToString(),DataBinder.Eval(Container.DataItem,"Category").ToString(),DataBinder.Eval(Container.DataItem,"pack_type").ToString())%></font></TD>
												<TD align="right"><font color="4a3c8c"><%#Multiply(DataBinder.Eval(Container.DataItem,"closing_stock").ToString()+"X" +DataBinder.Eval(Container.DataItem,"pack_type").ToString())%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE align="center" cellspacing="0" width="100%" border="0" cellpadding="0" cellspacing="0">
											<TR>
												<TD align="left"><font color="f7f7f7"><b><%=Cache["csp"]%></b></font></TD>
												<TD align="right"><font color="f7f7f7"><b><%=Cache["cs"]%></b></font></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
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
