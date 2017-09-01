<%@ Page language="c#" Codebehind="CreditFleetCardSalesReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.CreditFleetCardSalesReport" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Credit/Fleet Card Report</title> <!--
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
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox2" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR>
					<TH>
						<font color="#006400">Credit/Fleet Card Sales Report</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<TABLE id="Table1">
							<TR>
								<TD style="HEIGHT: 63px">
									<table width="500" align="center">
										<TR>
											<TD>Date From</TD>
											<TD><asp:textbox id="txtDateFrom" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
													></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
														border="0"></A>
												<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ErrorMessage="Please Select From Date From the Calender"
													ControlToValidate="txtDateFrom">*</asp:requiredfieldvalidator></TD>
											<TD align="center">Date To</TD>
											<TD align="center"><asp:textbox id="Textbox1" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
													></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.Textbox1);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
														border="0"></A>
												<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ErrorMessage="Please Select To Date From the Calender"
													ControlToValidate="Textbox1">*</asp:requiredfieldvalidator></TD>
										</TR>
										<tr>
											<td>Sales Type</td>
											<td><asp:dropdownlist id="DropSalesType" runat="server" Width="144" CssClass="FontStyle">
													<asp:ListItem Value="Combine Sales">Combine Sales</asp:ListItem>
													<asp:ListItem Value="Credit Card Sale">Credit Card Sale</asp:ListItem>
													<asp:ListItem Value="Fleet Card Sale">Fleet Card Sale</asp:ListItem>
												</asp:dropdownlist></td>
											<TD colSpan="2"><asp:button id="btnShow" runat="server" Width="70px" Text="View" ></asp:button>&nbsp;&nbsp;
                                                <asp:button id="BtnPrint" Width="70px" Text="Print "  Runat="server"></asp:button>&nbsp;&nbsp;
                                                <asp:button id="btnExcel" Width="70px" Text="Excel"  Runat="server"></asp:button></TD>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE>
										<TR>
											<TD align="center" colSpan="5" height="100"><asp:datagrid id="GridSalesReport" runat="server" BorderStyle="None" BorderColor="DarkSeaGreen"
													BackColor="DarkSeaGreen" CellPadding="1" BorderWidth="0px" AutoGenerateColumns="False" CellSpacing="1" AllowSorting="True" OnSortCommand="SortCommand_Click"
													ShowFooter="True">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" VerticalAlign="Top" BackColor="#738A9C"></SelectedItemStyle>
													<AlternatingItemStyle ForeColor="#4A3C8C" VerticalAlign="Top" BackColor="#EEFFE9"></AlternatingItemStyle>
													<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
													<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
													<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Cust_Name" SortExpression="Cust_Name" HeaderText="Customer Name" FooterText="Total">
															<HeaderStyle Width="250px"></HeaderStyle>
															<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="City" SortExpression="City" HeaderText="Place">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Cust_Type" SortExpression="Cust_Type" HeaderText="Customer Category">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" HeaderText="Invoice No.">
															<HeaderStyle Width="50px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Invoice_Date" SortExpression="Invoice_Date" HeaderText="Invoice Date"
															DataFormatString="{0:dd/MM/yyyy}">
															<HeaderStyle Width="60px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Under_SalesMan" SortExpression="Under_SalesMan" HeaderText="Under Salesman">
															<HeaderStyle Width="250px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Pack_Type" SortExpression="Pack_Type" HeaderText="Package Type">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Prod_Name" SortExpression="Prod_Name" HeaderText="Product Name">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Quantity In Lit's">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<%#GenUtil.strNumericFormat((Multiply(DataBinder.Eval(Container.DataItem,"Pack_Type").ToString()+"X"+DataBinder.Eval(Container.DataItem,"Qty").ToString())).ToString())%>
															</ItemTemplate>
															<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
															<FooterTemplate>
																<%=GenUtil.strNumericFormat(Cache["os"].ToString())%>
															</FooterTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Rate" SortExpression="Rate" HeaderText="Price" DataFormatString="{0:N2}">
															<HeaderStyle Width="60px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Discount" SortExpression="Discount" HeaderText="Discount(if any)">
															<HeaderStyle Width="50px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Invoice Amount" SortExpression="Net_Amount">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<%#Multiply1(DataBinder.Eval(Container.DataItem,"Invoice_No").ToString())%>
															</ItemTemplate>
															<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
															<FooterTemplate>
																<%=GenUtil.strNumericFormat(Cache["amt"].ToString())%>
															</FooterTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="CR_Days" SortExpression="CR_Days" HeaderText="Credit Days">
															<HeaderStyle Width="50px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn SortExpression="Due_date" HeaderText="Due Date">
															<ItemTemplate>
																<%#BlankDate(DataBinder.Eval(Container.DataItem,"Due_date","{0:dd/MM/yyyy}").ToString())%>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
									<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
							</TR>
							<tr>
								<td align="left"></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
