<%@ Page language="c#" Codebehind="TankReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.TankReport" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Tank Report</title> <!--
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
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header><table width="778" height="288" align=center>
				<TR>
					<TH align="center" style="HEIGHT: 4px">
						<font color="#006400">Tank&nbsp;Report</font><HR>
						<asp:Button id="Button1" runat="server" Text="View  " BackColor="ForestGreen" BorderColor="DarkSeaGreen"
							ForeColor="White" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button ID="Btnreport" Runat="server" Text="Print  " BackColor="ForestGreen" BorderColor="DarkSeaGreen"
							ForeColor="White" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;
<asp:Button id=btnExcel Width="70px" ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen" Text="Excel" Runat="server"></asp:Button>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<asp:DataGrid id="GridTankReport" runat="server" AutoGenerateColumns="False" BorderColor="DarkSeaGreen"
							BorderStyle="None" BorderWidth="0px" BackColor="DarkSeaGreen" CellPadding="1" CellSpacing="1"
							AllowSorting="True" OnSortCommand="SortCommand_Click">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Tank_ID" SortExpression="Tank_ID" HeaderText="Tank ID">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Tank_Name" SortExpression="Tank_Name" HeaderText="Name">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Prod_Name" SortExpression="Prod_Name" HeaderText="Product">
									<HeaderStyle Width="100px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Prod_AbbName" SortExpression="Prod_AbbName" HeaderText="Short Name">
									<HeaderStyle Width="120px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Capacity" SortExpression="Capacity" HeaderText="Capacity">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Water_Stock" SortExpression="Water_Stock" HeaderText="Water Stock">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Reserve_Stock" SortExpression="Reserve_Stock" HeaderText="Reserve Stock">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Opening_Stock" SortExpression="Opening_Stock" HeaderText="Opening Stock">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
				<tr>
					<td align="right"></td>
				</tr>
				<tr>
					<td align="center"></td>
				</tr>
				<tr>
					<td align="right"><A href="javascript:window.print()"></A></td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
