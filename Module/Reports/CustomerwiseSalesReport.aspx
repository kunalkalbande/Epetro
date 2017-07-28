<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="CustomerwiseSalesReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.CustomerwiseSalesReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Customerwise Sales Report</title> <!--
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
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox2" style="Z-INDEX: 102; LEFT: 136px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center" height="20">
						<font color="#006400">Customer Wise Sales Report</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<TABLE id="Table1">
							<TR>
								<TD style="HEIGHT: 31px" align="left">Date From</TD>
								<TD style="HEIGHT: 31px" align="left"><asp:textbox id="txtDateFrom" runat="server" Width="110px"  BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"
										href="javascript:void(0)"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ErrorMessage="Please Select From Date From the Calender"
										ControlToValidate="txtDateFrom">*</asp:requiredfieldvalidator></TD>
								<TD style="HEIGHT: 31px" align="left">Date To</TD>
								<TD style="HEIGHT: 31px" align="left"><asp:textbox id="Textbox1" runat="server" Width="110px"  BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.Textbox1);return false;"
										href="javascript:void(0)"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ErrorMessage="Please Select To Date From the Calender"
										ControlToValidate="Textbox1">*</asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 10px" align="left">Product Group</TD>
								<TD style="HEIGHT: 10px" align="left"><asp:dropdownlist id="DropCategory" runat="server" Width="110px" CssClass="FontStyle">
										<asp:ListItem Value="All">All</asp:ListItem>
										<asp:ListItem Value="Battery water">Battery water</asp:ListItem>
										<asp:ListItem Value="Brake oil">Brake oil</asp:ListItem>
										<asp:ListItem Value="Coolant">Coolant</asp:ListItem>
										<asp:ListItem Value="Grease">Grease</asp:ListItem>
										<asp:ListItem Value="Lubricant">Lubricant</asp:ListItem>
										<asp:ListItem Value="Misc">Misc</asp:ListItem>
										<asp:ListItem Value="Tyre">Tyre</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvProductGroup" runat="server" ErrorMessage="Please Select Product Group" ControlToValidate="DropType"
										ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
								<TD style="HEIGHT: 10px" align="left">Customer Category</TD>
								<TD style="HEIGHT: 10px" align="left"><asp:dropdownlist id="DropType" runat="server" Width="110px" CssClass="FontStyle">
										<asp:ListItem Value="All">All</asp:ListItem>
										<asp:ListItem Value="Contractor">Contractor</asp:ListItem>
										<asp:ListItem Value="Fleet">Fleet</asp:ListItem>
										<asp:ListItem Value="General">General</asp:ListItem>
										<asp:ListItem Value="Goverment">Goverment</asp:ListItem>
										<asp:ListItem Value="Key Customers">Key Customers</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="cvCustCat" runat="server" ErrorMessage="Please Select Customer Category" ControlToValidate="DropCategory"
										ValueToCompare="---Select---" Operator="NotEqual">*</asp:comparevalidator></TD>
							</TR>
							<tr>
								<td align="center" colSpan="4"><asp:button id="btnShow" runat="server" Width="70px" Text="View" BorderColor="DarkSeaGreen"
										BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="BtnPrint" runat="server" Width="70px" Text="Print " BorderColor="DarkSeaGreen"
										BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnExcel" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
										BorderColor="DarkSeaGreen" Text="Excel"></asp:button></td>
							</tr>
							<TR>
								<TD align="center" colSpan="6"><asp:datagrid id="GridReport" runat="server" Width="100%" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
										ShowFooter="True" CellPadding="1" BorderWidth="0px" BorderStyle="None" AutoGenerateColumns="False" Height="100%" CellSpacing="1"
										AllowSorting="True" OnSortCommand="SortCommand_Click">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
										<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
										<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
										<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Cust_Name" SortExpression="Cust_Name" HeaderText="Customer Name" FooterText="Total">
												<FooterStyle HorizontalAlign="Center"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="slip_no" SortExpression="slip_no" HeaderText="Slip No"></asp:BoundColumn>
											<asp:BoundColumn DataField="Place" SortExpression="Place" HeaderText="Place"></asp:BoundColumn>
											<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" HeaderText="Invoice No."></asp:BoundColumn>
											<asp:BoundColumn DataField="Invoice_Date" SortExpression="Invoice_Date" HeaderText="Invoice Date"
												DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="Under_SalesMan" SortExpression="Under_SalesMan" HeaderText="Salesman"></asp:BoundColumn>
											<asp:BoundColumn DataField="Prod_Name" SortExpression="Prod_Name" HeaderText="Product Name"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Quantity">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<%#GenUtil.strNumericFormat((Multiply(DataBinder.Eval(Container.DataItem,"Prod_Name").ToString()+"X"+DataBinder.Eval(Container.DataItem,"Qty"))).ToString())%>
												</ItemTemplate>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
												<FooterTemplate>
													<%=GenUtil.strNumericFormat(Cache["os"].ToString())%>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Invoice Amount">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<%#setAmt(DataBinder.Eval(Container.DataItem,"rate","{0:N2}").ToString(),DataBinder.Eval(Container.DataItem,"Invoice_No").ToString())%>
												</ItemTemplate>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
												<FooterTemplate>
													<%=GenUtil.strNumericFormat(Cache["Invoice_Amt"].ToString())%>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="vsCustWiseSales" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
