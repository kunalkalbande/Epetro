<%@ Page language="c#" Codebehind="VAT_Report.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.VAT_Report" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: VAT Report</title> <!--
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table style="HEIGHT: 288px" width="778" align="center">
				<TBODY>
					<TR>
						<TH>
							<font color="#006400">VAT Report</font>
							<hr>
						</TH>
					</TR>
					<TR>
						<TD align="center">
							<TABLE cellpadding="0" cellspacing="0">
								<TR>
									<TD style="WIDTH: 79px" vAlign="middle" align="center"></TD>
									<TD vAlign="top" align="center"></TD>
									<TD style="WIDTH: 60px" vAlign="middle" align="center">Date From</TD>
									<TD style="WIDTH: 162px" vAlign="top"><asp:textbox id="txtDateFrom" runat="server" Width="115px" BorderStyle="Groove"
											CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<TD vAlign="middle" align="center" colSpan="1" rowSpan="1">To</TD>
									<TD vAlign="top"><asp:textbox id="txtDateTo" runat="server" Width="115px" BorderStyle="Groove"
											CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 79px; HEIGHT: 18px" vAlign="middle" align="center"></TD>
									<TD vAlign="top" align="center" style="HEIGHT: 18px"></TD>
									<TD style="WIDTH: 60px; HEIGHT: 18px" vAlign="middle" align="center">Report Type
									</TD>
									<TD style="WIDTH: 162px; HEIGHT: 18px" vAlign="top"><asp:dropdownlist id="DropReportType" runat="server" Width="128px" CssClass="FontStyle">
											<asp:ListItem Value="Both">Both</asp:ListItem>
											<asp:ListItem Value="Purchase Report">Purchase Report</asp:ListItem>
											<asp:ListItem Value="Sales Report">Sales Report</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD vAlign="middle" align="center" style="HEIGHT: 18px">Report Category</TD>
									<TD vAlign="top" style="HEIGHT: 18px"><asp:dropdownlist id="DropReportCategory" runat="server" Width="120px" CssClass="FontStyle">
											<asp:ListItem Value="Both">Both</asp:ListItem>
											<asp:ListItem Value="Non VAT">Non VAT</asp:ListItem>
											<asp:ListItem Value="VAT">VAT</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
								<tr>
									<TD align="center" colSpan="11"><asp:button id="cmdrpt" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
											BorderColor="DarkSeaGreen" Text="View "></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="BtnPrint" Width="70px" ForeColor="White" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
											Text="Print" Runat="server"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnExcel" Width="70px" Text="Excel" BorderColor="DarkSeaGreen" BackColor="ForestGreen"
											ForeColor="White" Runat="server"></asp:button></TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" height="160">
							<asp:label id="lblSalesHeading" runat="server" Visible="False" ForeColor="Green" Font-Bold="True"
								Font-Size="xxsmall">Detailed Vat Report for Complete Party 
											Wise/ Invoice Wise Sales</asp:label><br>
							<br>
							<asp:datagrid id="SalesGrid" runat="server" Visible="False" BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen"
								OnSortCommand="SortCommand_Click" AllowSorting="True" CellSpacing="1" OnItemDataBound="ItemTotal"
								ShowFooter="True" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" CellPadding="1">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="invoice_no" SortExpression="invoice_no" HeaderText="Invoice No." FooterText="Total:">
										<HeaderStyle Width="60px"></HeaderStyle>
										<FooterStyle Font-Bold="True"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="invoice_date" SortExpression="invoice_date" HeaderText="Invoice Date"
										DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Cust_Name" SortExpression="Cust_Name" HeaderText="Customer Name">
										<HeaderStyle Width="150px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="City" SortExpression="City" HeaderText="Place">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Tin_No" SortExpression="Tin_No" HeaderText="Tin No.">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Grand_Total" SortExpression="Grand_Total" HeaderText="Product Value"
										DataFormatString="{0:N2}">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Cash_Disc" SortExpression="Cash_Disc" HeaderText="Cash Discount" DataFormatString="{0:N2}">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VAT_Amount" SortExpression="VAT_Amount" HeaderText="VAT" DataFormatString="{0:N2}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Disc" SortExpression="Disc" HeaderText="Other Discount" DataFormatString="{0:N2}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Net_Amount" SortExpression="Net_Amount" HeaderText="Total Invoice Amount"
										DataFormatString="{0:N2}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><br>
							<asp:label id="lblPurchaseHeading" runat="server" Visible="False" ForeColor="Green" Font-Bold="True"
								Font-Size="Xx-Small">Detailed Vat Report for Complete Party 
											Wise/ Invoice Wise Purchase</asp:label><br>
							<br>
							<asp:datagrid id="PurchaseGrid" runat="server" BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen"
								OnSortCommand="SortCommand1_Click" AllowSorting="True" CellSpacing="1" OnItemDataBound="ItemTotal"
								ShowFooter="True" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" CellPadding="1">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="invoice_no" SortExpression="invoice_no" HeaderText="Invoice No." FooterText="Total:">
										<HeaderStyle Width="60px"></HeaderStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Left"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="invoice_date" SortExpression="invoice_date" HeaderText="Invoice Date"
										DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Supp_Name" SortExpression="Supp_Name" HeaderText="Vendor Name">
										<HeaderStyle Width="150px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="City" SortExpression="City" HeaderText="Place">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Tin_No" SortExpression="Tin_No" HeaderText="Tin No.">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Grand_Total" SortExpression="Grand_Total" HeaderText="Product Value"
										DataFormatString="{0:N2}">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Cash_Disc" SortExpression="Cash_Disc" HeaderText="Cash Discount" DataFormatString="{0:N2}">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VAT_Amount" SortExpression="VAT_Amount" HeaderText="VAT" DataFormatString="{0:N2}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Disc" SortExpression="Disc" HeaderText="Other Discount" DataFormatString="{0:N2}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Net_Amount" SortExpression="Net_Amount" HeaderText="Total Invoice Amount"
										DataFormatString="{0:N2}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
				</TBODY>
			</table>
			</TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
