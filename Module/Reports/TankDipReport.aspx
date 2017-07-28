<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="TankDipReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.TankDipReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Tank Dip Report</title> <!--
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
					<TH style="HEIGHT: 4px" align="center">
						<font color="#006400">Daily Tank Dip Stock Reading&nbsp;Report</font>
						<HR>
						<asp:textbox id="txtDateFrom" runat="server" ReadOnly="True" Width="110px" BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>
						<asp:button id="Button1" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" Text=" View "></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BtnPrint" Width="70px" ForeColor="White" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
							Text=" Print " Runat="server"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnExcel" Width="70px" Text="Excel" BorderColor="DarkSeaGreen" BackColor="ForestGreen"
							ForeColor="White" Runat="server"></asp:button></TH></TR>
				<tr>
					<td align="center"><asp:datagrid id="GridTankDipReport" runat="server" BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen"
							OnSortCommand="SortCommand_Click" AllowSorting="True" CellSpacing="1" HorizontalAlign="Center" AutoGenerateColumns="False"
							BorderStyle="None" BorderWidth="0px" CellPadding="1">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Prod_AbbName" SortExpression="Prod_AbbName" HeaderText="Tank Name">
									<HeaderStyle Width="75px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Density" SortExpression="Density" HeaderText="Density" DataFormatString="{0:N4}">
									<HeaderStyle Width="75px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Temprature" SortExpression="Temprature" HeaderText="Temprature" DataFormatString="{0:N2}">
									<HeaderStyle Width="75px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Converted_Density" SortExpression="Converted_Density" HeaderText="Converted Density"
									DataFormatString="{0:N2}">
									<HeaderStyle Width="75px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Opening_Stock" SortExpression="Opening_Stock" HeaderText="Opening Stock"
									DataFormatString="{0:N2}">
									<HeaderStyle Width="75px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Tank_Dip" SortExpression="Tank_Dip" HeaderText="Tank Dip" DataFormatString="{0:N2}">
									<HeaderStyle Width="75px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Water_Dip" SortExpression="Water_Dip" HeaderText="Water Dip" DataFormatString="{0:N2}">
									<HeaderStyle Width="75px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Testing" SortExpression="Testing" HeaderText="Testing" DataFormatString="{0:N2}"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td align="right"></td>
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
