<%@ import namespace="EPetro.Sysitem.Classes" %>
<%@ Page language="c#" Codebehind="CashBillingReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.CashBillingReport" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Cash Billing Report</title> <!--
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
				<TBODY>
					<TR>
						<TH align="center" height="20">
							<font color="#006400">Cash&nbsp;Sales Report</font>
							<hr>
						</TH>
					</TR>
					<tr>
						<td align="center">Date From&nbsp;&nbsp;
							<asp:textbox id="txtDateFrom" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
								ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
									border="0"></A>
							<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ErrorMessage="Please Select From Date From the Calender"
								ControlToValidate="txtDateFrom">*</asp:requiredfieldvalidator>Date 
							To&nbsp;&nbsp;
							<asp:textbox id="Textbox1" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
								ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.Textbox1);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
									border="0"></A>
							<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ErrorMessage="Please Select To Date From the Calender"
								ControlToValidate="Textbox1">*</asp:requiredfieldvalidator><asp:checkbox id="chkDel" Text="Delete Record" Runat="server"></asp:checkbox>&nbsp;&nbsp;<asp:button id="btnShow" runat="server" Width="70px" Text="View" ForeColor="White" BorderColor="DarkSeaGreen"
								BackColor="ForestGreen"></asp:button>&nbsp;&nbsp;<asp:button id="BtnPrint" Width="70px" Text="Print  " Runat="server" ForeColor="White" BorderColor="DarkSeaGreen"
								BackColor="ForestGreen"></asp:button>&nbsp;&nbsp;<asp:button id="btnExcel" Width="70px" Text="Excel" Runat="server" ForeColor="White" BorderColor="DarkSeaGreen"
								BackColor="ForestGreen"></asp:button>
						</td>
					<!--tr>
					<td valign="top" align="center">&nbsp;</td>
				</tr-->
					<tr>
						<td align="center">
							<TABLE>
								<TR>
									<TD style="HEIGHT: 160px" align="center" colSpan="5"><asp:datagrid id="GridReport" runat="server" BorderStyle="None" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
											ShowFooter="True" OnSortCommand="SortCommand_Click" AllowSorting="True" CellSpacing="1" CellPadding="1" BorderWidth="0px" AutoGenerateColumns="False">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
											<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
											<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
											<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" HeaderText="Invoice No" FooterText="Total">
													<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="custname" SortExpression="custname" HeaderText="Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="Invoice_Date" SortExpression="Invoice_Date" HeaderText="Invoice Date"
													DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
												<asp:BoundColumn DataField="vehicleno" SortExpression="vehicleno" HeaderText="Vechicle No"></asp:BoundColumn>
												<asp:BoundColumn DataField="Prod_Name" SortExpression="Prod_Name" HeaderText="Product Name">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="qty" SortExpression="qty" HeaderText="Quantity">
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="rate" SortExpression="rate" HeaderText="Price">
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn SortExpression="netamt" HeaderText="Invoice Amount">
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
													<ItemTemplate>
														<%#Multiply1(DataBinder.Eval(Container.DataItem,"Invoice_No").ToString())%>
													</ItemTemplate>
													<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
													<FooterTemplate>
														<%=GenUtil.strNumericFormat(Cache["amt"].ToString())%>
													</FooterTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Visible="False" NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center"
												ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
							<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
					</tr>
					<tr>
						<td align="right"></td>
					</tr>
				</TBODY>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
