<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Page language="c#" Codebehind="ProductWiseSales.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.ProductWiseSales" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Product Wise Sales Reportl</title> <!--
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
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox>
			<table height="288" width="778" align="center">
				<TBODY>
					<TR height="10">
						<TH>
							<font color="#006400">Product Wise Sales
								<hr>
							</font>
						</TH>
					</TR>
					<TR>
						<TD align="center" colSpan="1" rowSpan="1" height="10">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1">
								<TR>
									<TD align="center">Date From
										<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="Date Required">*</asp:requiredfieldvalidator></TD>
									<TD><asp:textbox id="txtDateFrom" runat="server" Width="110px"  BorderStyle="Groove"
											CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"></A></TD>
									<TD align="center" colSpan="1" rowSpan="1">To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD><asp:textbox id="txtDateTo" runat="server" Width="129px"  BorderStyle="Groove"
											CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"></A><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"></A></TD>
								</TR>
							</TABLE>
							<asp:button id="cmdrpt" runat="server" Width="71px" Text="View  " BorderColor="ForestGreen"
								BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BtnPrint" Width="71px" Text="Print  " BorderColor="ForestGreen" BackColor="ForestGreen"
								ForeColor="White" Runat="server"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="btnExcel" Width="71px" Text="Excel" BorderColor="ForestGreen" BackColor="ForestGreen"
								ForeColor="White" Runat="server"></asp:button></TD>
					</TR>
					<tr>
						<td align="center"><asp:datagrid id="grdLeg1" runat="server" BorderColor="DarkSeaGreen" BackColor="DarkSeaGreen"
								OnSortCommand="SortCommand_Click" AllowSorting="True" CellSpacing="1" Height="8px" AutoGenerateColumns="False"
								BorderStyle="None" BorderWidth="0px" CellPadding="1" ShowFooter="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" VerticalAlign="Middle"
									BackColor="#009900"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Product Name" FooterText="Total" SortExpression="Prod_Name">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"prod_Name")%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True"></FooterStyle>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Sales<br>Pkg &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lt./Kg"
										SortExpression="Sales">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
												<TR>
													<TD align="left" width="75"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((Check(DataBinder.Eval(Container.DataItem,"Sales").ToString(),DataBinder.Eval(Container.DataItem,"pack_type").ToString())).ToString())%></font></TD>
													<TD align="right" width="75"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((Multiply(DataBinder.Eval(Container.DataItem,"pack_type").ToString()+"X" +DataBinder.Eval(Container.DataItem,"Sales").ToString())).ToString())%></font></TD>
												</TR>
											</TABLE>
										</ItemTemplate>
										<FooterStyle Font-Bold="True"></FooterStyle>
										<FooterTemplate>
											<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
												<TR>
													<TD align="left" width="75"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["salesp"].ToString())%></b></font></TD>
													<TD align="right" width="75"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["sales1"].ToString())%></b></font></TD>
												</TR>
											</TABLE>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Amount" SortExpression="amount">
										<HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#GenUtil.strNumericFormat((totalamount(DataBinder.Eval(Container.DataItem,"amount").ToString())).ToString())%>
										</ItemTemplate>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="#F7F7F7"></FooterStyle>
										<FooterTemplate>
											<%=GenUtil.strNumericFormat(Cache["amount"].ToString())%>
										</FooterTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
					</tr>
					<tr>
						<td align="right"><A href="javascript:window.print()"></A></td>
					</tr>
				</TBODY>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
