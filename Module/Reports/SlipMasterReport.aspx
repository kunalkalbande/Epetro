<%@ Page language="c#" Codebehind="SlipMasterReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.SlipMasterReport" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Slip Report</title><!--
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
			<uc1:Header id="Header1" runat="server"></uc1:Header>
			<table width="778" height="288" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Slip&nbsp;Report</font><HR>
						<asp:Button id="Button1" runat="server" Text="View  " Width="70px" ></asp:Button>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Btnreport" Runat="server" Text="Print  " Width="70px" ></asp:Button>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnExcel" Runat="server" Text="Excel" Width="70px" ></asp:Button>
					</TH>
				</TR>
				<tr>
					<td align="center" height="188">
						<asp:DataGrid id="GridTankReport" runat="server" AutoGenerateColumns="False" BorderColor="DarkSeaGreen"
							BorderStyle="None" BorderWidth="0px" BackColor="DarkSeaGreen" CellPadding="1" 
							CellSpacing="1" AllowSorting="True" OnSortCommand="SortCommand_Click">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="BookID" SortExpression="BookID" HeaderText="Slip Book ID">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Book_No" SortExpression="Book_No" HeaderText="Book No">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Start_No" SortExpression="Start_No" HeaderText="Start No">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="End_No" SortExpression="End_No" HeaderText="End No">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalSlip" SortExpression="TotalSlip" HeaderText="Total Slip">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Cust_Name" SortExpression="Cust_Name" HeaderText="Cust Name">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
				<tr>
					<td align="right"></td>
				</tr>
				<tr>
					<td align="center" style="HEIGHT: 19px"></td>
				</tr>
				<tr>
					<td align="right"><A href="javascript:window.print()"></A></td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
