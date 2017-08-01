<%@ import namespace="EPetro.Sysitem.Classes"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="DailySalesRecord.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.DailySalesRecord" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Daily Sales Report</title> <!--
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
			<asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 101; LEFT: 264px; POSITION: absolute; TOP: 840px"
				runat="server" ShowMessageBox="True" ShowSummary="False" Width="120px"></asp:validationsummary><uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 136px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox>
			<table cellSpacing="0" width="778" border="1" align="center">
				<tr>
					<TD style=" HEIGHT: 46px" align="left" colSpan="8" vAlign="top"><STRONG><FONT color="#ff0033"><U>Note</U></FONT><FONT color="#ff0033">:</FONT></STRONG>
						To take a printout press the Print button, to redirect<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; the output to a 
						new page. Use the Page Setup
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; option in the File 
						menu to set the appropriate
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; margins, then use 
						the Print option in the File menu<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; to send the output 
						to&nbsp;printer.</TD>
					<td align="left" width="116%" colSpan="27" style="HEIGHT: 46px"><font style="BACKGROUND-COLOR: #ffffff" color="#000000"><b style="COLOR: #006400">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<% =dealership %>
								&nbsp;
								<br>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<% =div_office%>
								DIVISIONAL OFFICE<br>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
								DAILY SALES&nbsp;RECORD</b> </font>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						Product
						<asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="Please Select Product Name"
							Operator="NotEqual" ValueToCompare="Select" ControlToValidate="DropProduct">*</asp:comparevalidator></td>
					<td colspan="4"><asp:dropdownlist id="DropProduct" runat="server" Width="150px" CssClass="FontStyle">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist></td>
					<td colspan="2" align="center">Month
						<asp:comparevalidator id="CompareValidator2" runat="server" ErrorMessage="Please Select Product Name"
							Operator="NotEqual" ValueToCompare="Select" ControlToValidate="DropMonth">*</asp:comparevalidator></td>
					<td colspan="4"><asp:dropdownlist id="DropMonth" runat="server" CssClass="FontStyle">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="January">January</asp:ListItem>
							<asp:ListItem Value="February">February</asp:ListItem>
							<asp:ListItem Value="March">March</asp:ListItem>
							<asp:ListItem Value="April">April</asp:ListItem>
							<asp:ListItem Value="May">May</asp:ListItem>
							<asp:ListItem Value="June">June</asp:ListItem>
							<asp:ListItem Value="July">July</asp:ListItem>
							<asp:ListItem Value="August">August</asp:ListItem>
							<asp:ListItem Value="September">September</asp:ListItem>
							<asp:ListItem Value="October">October</asp:ListItem>
							<asp:ListItem Value="November">November</asp:ListItem>
							<asp:ListItem Value="December">December</asp:ListItem>
						</asp:dropdownlist></td>
					<td colspan="2"><asp:dropdownlist id="DropYear" runat="server" AutoPostBack="True" CssClass="FontStyle">
							<asp:ListItem Value="2000" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="2000">2000</asp:ListItem>
							<asp:ListItem Value="2001">2001</asp:ListItem>
							<asp:ListItem Value="2002">2002</asp:ListItem>
							<asp:ListItem Value="2003">2003</asp:ListItem>
							<asp:ListItem Value="2004">2004</asp:ListItem>
							<asp:ListItem Value="2005">2005</asp:ListItem>
							<asp:ListItem Value="2006">2006</asp:ListItem>
							<asp:ListItem Value="2007">2007</asp:ListItem>
							<asp:ListItem Value="2008">2008</asp:ListItem>
							<asp:ListItem Value="2009">2009</asp:ListItem>
							<asp:ListItem Value="2010">2010</asp:ListItem>
							<asp:ListItem Value="2011">2011</asp:ListItem>
							<asp:ListItem Value="2012">2012</asp:ListItem>
						</asp:dropdownlist></td>
					<td colspan="13"><b>Dealer Name:</b> &nbsp;<% =dealer %></td>
				</tr>
				<tr>
					<td colspan="12" align="center"><asp:button id="btnView" runat="server" Width="70px" Text="View " BackColor="ForestGreen" BorderColor="DarkSeaGreen"
							ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="PrintBtn" runat="server" Width="70px" Text="Print" ToolTip="Refer to the note at the bottom of this page"
							BackColor="ForestGreen" BorderColor="DarkSeaGreen" ForeColor="White"></asp:button></td>
					<td colspan="15"><b>Location:</b>&nbsp;<%  =city %></td>
				</tr>
				<tr>
					<td align="center" width="39" rowSpan="3" style="WIDTH: 39px">Date</td>
					<td align="center" width="8%" colSpan="2" rowSpan="2">Tank 1</td>
					<td align="center" width="8%" colSpan="2" rowSpan="2">Tank 2</td>
					<td align="center" width="8%" colSpan="2" rowSpan="2">Tank 3</td>
					<td align="center" width="8%" colSpan="2" rowSpan="2">Tank 4</td>
					<td align="center" width="8%" colSpan="2" rowSpan="2">Tank 5</td>
					<td align="center" width="8%" colSpan="2" rowSpan="2">Tank 6</td>
					<td align="center" width="4%" rowSpan="3">Opening Stock</td>
					<td align="center" width="4%" rowSpan="3">Receipt</td>
					<td align="center" width="4%" rowSpan="3">Total Stock</td>
					<td align="center" width="16%" colSpan="4">Opening Meter Reading</td>
					<td align="center" width="4%" rowSpan="3">Testing</td>
					<td align="center" width="4%" rowSpan="3">Sales</td>
					<td align="center" width="4%" rowSpan="3">Cumm. Sales</td>
					<td align="center" width="8%" colSpan="2" rowSpan="2">Total Engine and Gear Oil 
						Sales</td>
					<td align="center" width="16%" colSpan="2" rowSpan="2">Total 2T/4T Oil</td>
				</tr>
				<tr>
					<td align="center" width="16%" colSpan="4">Pumps</td>
				</tr>
				<tr>
					<td align="center" width="4%">Dip</td>
					<td align="center" width="4%">Water Dip</td>
					<td align="center" width="4%">Dip</td>
					<td align="center" width="4%">Water Dip</td>
					<td align="center" width="4%">Dip</td>
					<td align="center" width="4%">Water Dip</td>
					<td align="center" width="4%">Dip</td>
					<td align="center" width="4%">Water Dip</td>
					<td align="center" width="4%">Dip</td>
					<td align="center" width="4%">Water Dip</td>
					<td align="center" width="4%">Dip</td>
					<td align="center" width="4%">Water Dip</td>
					<td align="center" width="4%">1</td>
					<td align="center" width="4%">2</td>
					<td align="center" width="4%">3</td>
					<td align="center" width="4%">4</td>
					<td align="center" width="4%">Packed</td>
					<td align="center" width="4%">Loose</td>
					<td align="center" width="4%">Packed</td>
					<td align="center" width="4%">Loose</td>
				</tr>
				<% 
				string[,] tData=GetData();
				for(int i=0;i<tData.GetLength(0);i++)
				{
				%>
				<tr>
					<td width="39" style="WIDTH: 39px">&nbsp;<%=tData[i,0].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,1].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,2].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,3].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,4].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,5].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,6].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,7].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,8].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,9].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,10].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,11].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,12].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,13].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,14].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,15].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,16].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,17].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,18].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,19].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,20].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,21].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,22].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,23].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,24].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,25].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,26].ToString()%></td>
				</tr>
				<%}
				%>
				<tr>
					<td align="right" width="4%" colSpan="27"></td>
				</tr>
				<TR>
					<TD align="left" width="4%" colSpan="27"><FONT color="black"> </FONT>
					</TD>
				</TR>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
