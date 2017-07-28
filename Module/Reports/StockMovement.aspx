<%@ Page language="c#" Codebehind="StockMovement.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.StockView" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Stock Movement Reportl</title> <!--
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
				Visible="False" Width="8px"></asp:textbox>
			<table height="288" width="778" align="center">
				<TR>
					<TH style="HEIGHT: 4px">
						<font color="#006400">Stock Movement Report</font>
						<hr>
					</TH>
				</TR>
				<TR>
					<TD align="center" colSpan="1" height="80" rowSpan="1" style="HEIGHT: 80px">
						<TABLE>
							<TR>
								<TD>Date From&nbsp;&nbsp;
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="Date Required">*</asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtDateFrom" runat="server" Width="110px"  BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD align="center">To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtDateTo" runat="server" Width="110px" BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
							</TR>
							<tr>
								<TD vAlign="middle">Stock Location&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</TD>
								<td><asp:dropdownlist id="drpstore" runat="server" Width="148px" CssClass="FontStyle"></asp:dropdownlist></td>
								<TD vAlign="middle">Stock Category&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</TD>
								<td><asp:dropdownlist id="Dropcategory" runat="server" Width="111px" CssClass="FontStyle">
										<asp:ListItem Value="Both">Both</asp:ListItem>
										<asp:ListItem Value="Fuel">Fuel</asp:ListItem>
										<asp:ListItem Value="Non Fuel">Non Fuel</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</TABLE>
						<asp:button id="cmdrpt" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" Text="View"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="prnButton" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" Text=" Print "></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnExcel" runat="server" Width="70px" Text="Excel" BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:button></TD>
				</TR>
				<tr>
					<td align="center"><asp:datagrid id="grdLeg" runat="server" BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen" OnSortCommand="SortCommand_Click"
							AllowSorting="True" ShowFooter="True" CellPadding="1" BorderWidth="0px" BorderStyle="None" CellSpacing="1"
							AutoGenerateColumns="False">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#009900"></HeaderStyle>
							<FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" VerticalAlign="Middle"
								BackColor="#009900"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Product Name" FooterText="Total" SortExpression="prod_name">
									<HeaderStyle Width="150px"></HeaderStyle>
									<ItemTemplate>
										<%#DataBinder.Eval(Container.DataItem,"prod_name")%>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE width="100%" align="center" cellpadding="0" cellspacing="0">
											<TR>
												<TD align="center" width="100%"><font color="#ffffff"><b>Totol</b></font></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Location" SortExpression="location">
									<HeaderStyle Width="100px"></HeaderStyle>
									<ItemTemplate>
										<%#IsTank(DataBinder.Eval(Container.DataItem,"location").ToString())%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Opening Stock<br>Pkg &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lt./Kg"
									SortExpression="op">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
											<TR>
												<TD width="40" align="left"><font color="4a3c8c"><%#Check(DataBinder.Eval(Container.DataItem,"op").ToString(),DataBinder.Eval(Container.DataItem,"Category").ToString(),DataBinder.Eval(Container.DataItem,"pack_type").ToString())%></font></TD>
												<TD width="60" align="right"><font color="4a3c8c"><%#(Multiply(DataBinder.Eval(Container.DataItem,"op").ToString()+"X" +DataBinder.Eval(Container.DataItem,"pack_type")))%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
											<TR>
												<TD width="40" align="left"><font color="f7f7f7"><b><%=Cache["osp"].ToString()%></b></font></TD>
												<TD width="60" align="right"><font color="f7f7f7"><b><%=Cache["os"].ToString()%></b></font></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Receipt Stock<br>Pkg &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lt./Kg"
									SortExpression="rcpt">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
											<TR>
												<TD width="40" align="left"><font color="4a3c8c"><%#Check(DataBinder.Eval(Container.DataItem,"rcpt").ToString(),DataBinder.Eval(Container.DataItem,"Category").ToString(),DataBinder.Eval(Container.DataItem,"pack_type").ToString())%></font></TD>
												<TD width="60" align="right"><font color="4a3c8c"><%#Multiply(DataBinder.Eval(Container.DataItem,"rcpt").ToString()+"X"+DataBinder.Eval(Container.DataItem,"pack_type"))%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
											<TR>
												<TD width="40" align="left"><font color="f7f7f7"><b><%=Cache["rectp"]%></b></font></TD>
												<TD width="60" align="right"><font color="f7f7f7"><b><%=Cache["rect"]%></b></font></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sales Stock<br>Pkg &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lt./Kg"
									SortExpression="sales">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
											<TR>
												<TD width="40" align="left"><font color="4a3c8c"><%#Check(DataBinder.Eval(Container.DataItem,"sales").ToString(),DataBinder.Eval(Container.DataItem,"Category").ToString(),DataBinder.Eval(Container.DataItem,"pack_type").ToString())%></font></TD>
												<TD width="60" align="right"><font color="4a3c8c"><%#Multiply(DataBinder.Eval(Container.DataItem,"sales").ToString()+"X"+DataBinder.Eval(Container.DataItem,"pack_type"))%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
											<TR>
												<TD width="40" align="left"><font color="f7f7f7"><b><%=Cache["salesp"]%></b></font></TD>
												<TD width="60" align="right"><font color="f7f7f7"><b><%=Cache["sales"]%></b></font></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Closing Stock<br>Pkg &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lt./Kg"
									SortExpression="cs">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
											<TR>
												<TD width="40" align="left"><font color="4a3c8c"><%#Check(DataBinder.Eval(Container.DataItem,"cs").ToString(),DataBinder.Eval(Container.DataItem,"Category").ToString(),DataBinder.Eval(Container.DataItem,"pack_type").ToString())%></font></TD>
												<TD width="60" align="right"><font color="4a3c8c"><%#Multiply(DataBinder.Eval(Container.DataItem,"cs").ToString()+"X"+DataBinder.Eval(Container.DataItem,"pack_type"))%></font></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE align="center" border="0" cellspacing="0" cellpadding="0">
											<TR>
												<TD width="40" align="left"><font color="f7f7f7"><b><%=Cache["csp"]%></b></font></TD>
												<TD width="60" align="right"><font color="f7f7f7"><b><%=Cache["cs"]%></b></font></TD>
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
