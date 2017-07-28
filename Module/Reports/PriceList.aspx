<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="PriceList.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.PriceList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Price List Report</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header>
			<table width="778" height="288" align="center">
				<TR>
					<TH align="center" height="30">
						<font color="#006400">Price List Report</font><hr>
					</TH>
				</TR>
				<tr height="20">
					<td align="center">Date From&nbsp;<asp:textbox id="txtDateFrom" runat="server" Width="80px" CssClass="FontStyle" BorderStyle="Groove"
							ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A> &nbsp;&nbsp;Date To&nbsp;&nbsp;<asp:textbox id="txtDateTo" runat="server" Width="80px" CssClass="FontStyle" BorderStyle="Groove"
							ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A> &nbsp;&nbsp; Product Name&nbsp;&nbsp;<asp:dropdownlist id="DropProdName" Width="200" CssClass="FontStyle" Runat="server"></asp:dropdownlist>
					</td>
				</tr>
				<tr height="20">
					<td align="center">
						<asp:Button id="Button1" runat="server" Text="View " Width="70px" BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button ID="Btnprint" Runat="server" Text="Print  " Width="70px" BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnExcel" Runat="server" Text="Excel" Width="70px" BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:Button>
					</td>
				</tr>
				<tr>
					<td align="center">
						<TABLE id="Table1" width="80%">
							<TR>
								<TD align="center" colSpan="6">
									<asp:DataGrid id="GridReport" runat="server" CellPadding="1" BackColor="DarkSeaGreen" BorderWidth="0px"
										BorderStyle="None" BorderColor="DarkSeaGreen" AutoGenerateColumns="False" Width="100%" Height="100%"
										CellSpacing="1" AllowSorting="True" OnSortCommand="SortCommand_Click">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
										<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
										<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
										<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Prod_ID" SortExpression="Prod_ID" HeaderText="Product ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="Prod_Name" SortExpression="Prod_Name" HeaderText="Product/Item Name"></asp:BoundColumn>
											<asp:BoundColumn DataField="Pack_Type" SortExpression="Pack_Type" HeaderText="Type Of Pack"></asp:BoundColumn>
											<asp:BoundColumn DataField="Pur_Rate" SortExpression="Pur_Rate" HeaderText="Purchase Rate" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Sal_Rate" SortExpression="Sal_Rate" HeaderText="Selling Rate" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Eff_Date" SortExpression="Eff_Date" HeaderText="Last Update Date" DataFormatString="{0:dd/MM/yyyy}">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="right"><A href="javascript:window.print()"></A></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
