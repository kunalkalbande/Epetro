<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Page language="c#" Codebehind="PurchaseBook.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.PurchaseBook" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Purchase Book Report</title> <!--
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
		<script language="javascript">
		function aa()
		{
		alert("hello");
		}
		</script>
		<style type="text/css">.style1 { FONT-SIZE: 8pt; COLOR: #000000; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.style2 { FONT-SIZE: 8px; COLOR: #000000; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.style3 { FONT-FAMILY: Arial, Helvetica, sans-serif }
	.style6 { FONT-SIZE: 8pt; COLOR: #000000; FONT-FAMILY: Arial }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox2" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table style="HEIGHT: 288px" width="778" align="center">
				<TR>
					<TH height="20">
						<font color="#006400">Purchase Book Report</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td vAlign="top" align="center">Date From&nbsp;&nbsp;
						<asp:textbox id="txtDateFrom" runat="server" Width="110px" ReadOnly="True" BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>
						<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ErrorMessage="Please Select From Date From the Calender"
							ControlToValidate="txtDateFrom">
							<span class="style2">*</span></asp:requiredfieldvalidator>Date 
						To&nbsp;&nbsp;
						<asp:textbox id="Textbox1" runat="server" Width="110px" ReadOnly="True" BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.Textbox1);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>
						<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ErrorMessage="Please Select To Date From the Calender"
							ControlToValidate="Textbox1">
							<span class="style3">*</span></asp:requiredfieldvalidator></td>
				<tr>
					<td vAlign="top" align="center"><asp:button id="btnShow" runat="server" Width="70px" ForeColor="White" BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" Text="View"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BtnPrint" Width="70px" ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen"
							Text="Print  " Runat="server"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnExcel" Width="70px" ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen"
							Text="Excel" Runat="server"></asp:button></td>
				</tr>
				<tr>
					<td align="center" height="150"><asp:datagrid id="GridReport" runat="server" Width="100%" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
							ShowFooter="True" OnSortCommand="SortCommand_Click" AllowSorting="True" CellSpacing="1" CellPadding="1" BorderWidth="0px"
							BorderStyle="None" AutoGenerateColumns="False">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Vendor_Name" SortExpression="Vendor_Name" HeaderText="Vendor Name" FooterText="Total">
									<HeaderStyle Width="140px"></HeaderStyle>
									<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Place" SortExpression="Place" HeaderText="Place"></asp:BoundColumn>
								<asp:BoundColumn DataField="Vendor_Type" SortExpression="Vendor_Type" HeaderText="Vendor Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" HeaderText="Invoice No."></asp:BoundColumn>
								<asp:BoundColumn DataField="Invoice_Date" SortExpression="Invoice_Date" HeaderText="Invoice Date"
									DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Prod_Type" SortExpression="Prod_Type" HeaderText="Product Type">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Prod_Name" SortExpression="Prod_Name" HeaderText="Product Name">
									<HeaderStyle Width="100px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Quantity In Lit's">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<%#GenUtil.strNumericFormat((Multiply(DataBinder.Eval(Container.DataItem,"Prod_Type").ToString()+"X"+DataBinder.Eval(Container.DataItem,"Prod_Name").ToString()+"X"+DataBinder.Eval(Container.DataItem,"Qty").ToString())).ToString())%>
									</ItemTemplate>
									<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									<FooterTemplate>
										<%=GenUtil.strNumericFormat(Cache["os"].ToString())%>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Price" SortExpression="Price" HeaderText="Price" DataFormatString="{0:N2}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Discount" SortExpression="Discount" HeaderText="Discount(if any)"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Invoice Amount">
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<%#Multiply1(DataBinder.Eval(Container.DataItem,"Invoice_No").ToString())%>
									</ItemTemplate>
									<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									<FooterTemplate>
										<%=GenUtil.strNumericFormat(Cache["amt"].ToString())%>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Cr_Days" SortExpression="Cr_Days" HeaderText="Credit Days">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="duedate" SortExpression="duedate" HeaderText="Due Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<!--tr>
					<td align="left"><FONT color="#ff0033"><STRONG><U>Note</U>:</STRONG>&nbsp;</FONT><FONT color="black">
							To take a printout press the above Print button, to redirect the output to a 
							new page. Use the Page Setup option in the File menu to set the appropriate
							<br>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; margins, 
							then use the Print option in the file menu to send the output to the printer. </FONT>
					</td>
				</tr-->
			</table>
			<asp:validationsummary id="vsPurchaseOrder" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR><tr>
				<td align="right"><A href="javascript:window.print()"></A></td>
			</tr>
			</TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
