<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="TaxReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.TaxReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Tax Report</title><!--
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
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Tax Report</font>
						<HR>
						<asp:button id="btnView" runat="server" Width="70px" Text="View " BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BtnPrint" Width="70px" Text="Print  " Runat="server" BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnExcel" Width="70px" Text="Excel" Runat="server" BorderColor="DarkSeaGreen"
							BackColor="ForestGreen" ForeColor="White"></asp:button>
					</TH>
				</TR>
				<tr>
					<td style="HEIGHT: 199px" align="center"><asp:datagrid id="GridTaxReport" runat="server" Visible="False" AutoGenerateColumns="False" HorizontalAlign="Center"
							BorderColor="DarkSeaGreen" BorderStyle="None" BorderWidth="0px" BackColor="DarkSeaGreen" CellPadding="1" CellSpacing="1" AllowSorting="True"
							OnSortCommand="SortCommand_Click">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Size="Large" Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7"
								BackColor="#009900"></HeaderStyle>
							<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Prod_Name" SortExpression="Prod_Name" HeaderText="Product Name">
									<ItemStyle HorizontalAlign="Left" Width="80px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Reduction" SortExpression="Reduction" HeaderText="Reduction">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="entry_tax" SortExpression="entry_tax" HeaderText="Entry Tax">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="rpg_charge" SortExpression="rpg_charge" HeaderText="RPG Charges">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="rpg_Surcharge" SortExpression="rpg_Surcharge" HeaderText="RPG Surcharge">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LT_Charge" SortExpression="LT_Charge" HeaderText="Local Transport Charge">
									<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Trans_Charge" SortExpression="Trans_Charge" HeaderText="Transportation Charge">
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Other_Lvy" SortExpression="Other_Lvy" HeaderText="Other Levies Value">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LST" SortExpression="LST" HeaderText="Vat">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LST_Surcharge" SortExpression="LST_Surcharge" HeaderText="LST Surcharge">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LF_Recov" SortExpression="LF_Recov" HeaderText="License Fee Recovery">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dofobc_Charge" SortExpression="dofobc_Charge" HeaderText="DO/ FO/ BC Charges">
									<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				<tr>
					<td align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
				</tr>
				</tr>
				<tr>
					<td align="right"><A href="javascript:window.print()"></A></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
