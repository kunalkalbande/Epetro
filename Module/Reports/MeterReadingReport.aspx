<%@ Page language="c#" Codebehind="MeterReadingReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.MeterReadingReport" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Meter Reading Report</title> <!--
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
			<uc1:Header id="Header1" runat="server"></uc1:Header>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:TextBox><table width="778" height="288" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Meter Reading&nbsp;Report</font><HR>
						<asp:textbox id="txtDateTo" runat="server" Width="110px" ReadOnly="True" BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>
						<asp:Button id="btnView" runat="server" Text="View  " Width="70px" Height="26px" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" ForeColor="White"></asp:Button>&nbsp;&nbsp;&nbsp;
						<asp:Button ID="BtnPrint" Runat="server" Text="Print " Width="70px" Height="26px" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" ForeColor="White"></asp:Button>&nbsp;&nbsp;&nbsp;
						<asp:Button ID="btnExcel" Runat="server" Text="Excel" Width="70px" Height="26px" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" ForeColor="White"></asp:Button></TH>
				</TR>
				<tr>
					<td align="center" style="HEIGHT: 210px">
						<asp:datagrid id="GridMeterReadingReport" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
							BorderColor="DarkSeaGreen" BorderStyle="None" BorderWidth="0px" BackColor="DarkSeaGreen" CellPadding="1"
							PageSize="5" CellSpacing="1" AllowSorting="True" OnSortCommand="SortCommand_Click">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C">
</SelectedItemStyle>

<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9">
</AlternatingItemStyle>

<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2">
</ItemStyle>

<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900">
</HeaderStyle>

<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="machine" SortExpression="machine" HeaderText="Machine Name">
<HeaderStyle Width="75px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="nozzle_name" SortExpression="nozzle_name" HeaderText="Nozzle Name">
<HeaderStyle Width="75px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="prod_name" SortExpression="prod_name" HeaderText="Product Name">
<HeaderStyle Width="75px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Reading" SortExpression="Reading" HeaderText="Reading">
<HeaderStyle Width="75px">
</HeaderStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages">
</PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td align="right"></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
