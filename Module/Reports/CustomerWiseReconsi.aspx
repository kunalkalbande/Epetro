<%@ Page language="c#" Codebehind="CustomerWiseReconsi.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.CustomerWiseReconsi" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Customerwise Reconcilation Report</title> <!--
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
				Visible="False" Width="8px"></asp:textbox><uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center" height="20">
						<font color="#006400">Customer Wise Slip Reconciliation</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td valign="top" align="center">
						Date From&nbsp;&nbsp;
						<asp:textbox id="txtDateFrom" runat="server" Width="110px" ReadOnly="True" BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>
						<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="Please Select From Date From the Calender">*</asp:requiredfieldvalidator>
						Date To&nbsp;&nbsp;
						<asp:textbox id="Textbox1" runat="server" Width="110px" ReadOnly="True" BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.Textbox1);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>
						<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ControlToValidate="Textbox1" ErrorMessage="Please Select To Date From the Calender">*</asp:requiredfieldvalidator></td>
				<tr>
					<td valign="top" align="center"><asp:button id="btnShow" runat="server" Width="70px" Text="View   " BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BtnPrint" Width="70px" Text="Print  " Runat="server" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnExcel" Width="70px" ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen"
							Text="Excel" Runat="server"></asp:button></td>
				</tr>
				<tr>
					<td align="center">
						<TABLE id="Table1">
							<TR>
								<TD align="center" colSpan="5" style="HEIGHT: 160px"><asp:datagrid id="GridReport" runat="server" Width="356px" AutoGenerateColumns="False" BorderColor="DarkSeaGreen"
										BorderStyle="None" BorderWidth="0px" BackColor="DarkSeaGreen" CellPadding="1" CellSpacing="1" AllowSorting="True" OnSortCommand="SortCommand_Click" ShowFooter="True">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C">
</SelectedItemStyle>

<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9">
</AlternatingItemStyle>

<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2">
</ItemStyle>

<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900">
</HeaderStyle>

<FooterStyle ForeColor="#F7F7F7" BackColor="#009900">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="cust_name" SortExpression="Cust_Name" HeaderText="Customer Name" FooterText="Total">
<FooterStyle Font-Bold="True" HorizontalAlign="Center">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="slip_no" SortExpression="Slip_No" HeaderText="Slip No"></asp:BoundColumn>
<asp:BoundColumn DataField="invoice_no" SortExpression="Invoice_No" HeaderText="Invoice No "></asp:BoundColumn>
<asp:BoundColumn DataField="vehicle_no" SortExpression="Vehicle_No" HeaderText="Vechicle No"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="Amount">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<ItemTemplate>
<%#GetTotal(DataBinder.Eval(Container.DataItem,"Net_Amount","{0:N2}").ToString())%>
</ItemTemplate>

<FooterStyle Font-Bold="True" HorizontalAlign="Right">
</FooterStyle>

<FooterTemplate>
<%=Cache["amt"].ToString()%>
</FooterTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle Visible="False" NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages">
</PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
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
