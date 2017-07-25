<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Customer_Bill_Ageing.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.Customer_Bill_Ageing" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Customer Bill Ageing</title> <!--
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
function check(t1,t)
{
var temp = t.Value;
if(temp.Trim() =="")
{
alert("Please Enter the Interest Rate")
return false;
}
return true;

}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox2" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="4px"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center" height="20">
						<font color="#006400">Customer Bill&nbsp;Ageing Report</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE>
							<TR>
								<TD colSpan="4">&nbsp;&nbsp;&nbsp;Date From&nbsp;
									<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ErrorMessage="Please Select From Date From the Calender"
										ControlToValidate="txtDateFrom">*</asp:requiredfieldvalidator>&nbsp;&nbsp;
									<asp:textbox id="txtDateFrom" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;&nbsp;Date To&nbsp;
									<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ErrorMessage="Please Select To Date From the Calender"
										ControlToValidate="Textbox1">*</asp:requiredfieldvalidator>&nbsp;&nbsp;
									<asp:textbox id="Textbox1" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.Textbox1);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;&nbsp; Customer Name&nbsp;&nbsp;<asp:dropdownlist id="DropCustName" Width="200" CssClass="FontStyle" Runat="server"></asp:dropdownlist>
								</TD>
							</TR>
							<tr>
								<TD align="center">Interest Rate</TD>
								<TD><asp:textbox id="InterestText" runat="server" Width="40px" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox><asp:checkbox id="c" runat="server" Width="35px" Height="12px"></asp:checkbox><asp:button id="Update1" runat="server" Width="70px" Text="Update" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
										ForeColor="White"></asp:button></TD>
								<td align="center" colSpan="2"><asp:button id="btnShow" runat="server" Width="60px" Text="View" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
										ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BtnPrint" Width="60px" Runat="server" Text="Print" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
										ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnExcel" Width="60px" Runat="server" Text="Excel" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
										ForeColor="White"></asp:button></td>
							</tr>
							<TR>
								<TD align="center" colSpan="6" height="170"><asp:datagrid id="GridReport" runat="server" Width="100%" BorderStyle="None" BackColor="DarkSeaGreen"
										BorderColor="DarkSeaGreen" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="1" CellSpacing="1" ShowFooter="True" AllowSorting="True"
										OnSortCommand="SortCommand_Click">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
										<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
										<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
										<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Cust_Name" SortExpression="Cust_Name" HeaderText="Customer Name" FooterText="Total">
												<HeaderStyle Width="150px"></HeaderStyle>
												<FooterStyle HorizontalAlign="Center"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Slip_No" SortExpression="Slip_No" HeaderText="Slip No"></asp:BoundColumn>
											<asp:BoundColumn DataField="Vehicle_No" SortExpression="Vehicle_No" HeaderText="Vehicle No"></asp:BoundColumn>
											<asp:BoundColumn DataField="City" SortExpression="City" HeaderText="Place">
												<HeaderStyle Width="70px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" HeaderText="Invoice No."></asp:BoundColumn>
											<asp:BoundColumn DataField="Invoice_Date" SortExpression="Invoice_Date" HeaderText="Invoice Date"
												DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											<asp:TemplateColumn SortExpression="Net_Amount" HeaderText="Bill Amount">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<%#SumAmount(DataBinder.Eval(Container.DataItem,"Net_Amount").ToString())%>
												</ItemTemplate>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
												<FooterTemplate>
													<%=GenUtil.strNumericFormat(Cache["Amount"].ToString())%>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Cr_Days" SortExpression="Cr_Days" HeaderText="Credit Days">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="due_date" SortExpression="due_date" HeaderText="Due Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="tcr" SortExpression="tcr" HeaderText="Due Days">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="tdd" SortExpression="tdd" HeaderText="Overdue Days">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Amt. with Interest">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<%#CalcInterest(DataBinder.Eval(Container.DataItem, "Net_Amount").ToString(),DataBinder.Eval(Container.DataItem, "tdd").ToString()) %>
												</ItemTemplate>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												<FooterTemplate>
													<%=Cache["Amt1"]%>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="vsCustWiseSales" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
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
