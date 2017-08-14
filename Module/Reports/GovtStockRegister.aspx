<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ import namespace="EPetro.Sysitem.Classes"%>
<%@ Page language="c#" Codebehind="GovtStockRegister.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.GovtStockRegister" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Govt. Stock Register Report</title> <!--
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
			<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 136px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:TextBox>
			<table cellSpacing="0" width="100%" border="1" align="center">
				<TR>
					<TD align="left" width="5%" colSpan="4" vAlign="top"><STRONG><FONT color="#ff0033"><U>Note</U></FONT><FONT color="#ff0033">:</FONT></STRONG>
						To take a printout press the Print<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; button, to 
						redirect&nbsp; the output to a
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; new page. Use the 
						Page Setup &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; option 
						in the File menu to set the<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; appropriate&nbsp; 
						margins, then use<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;the Print 
						option in the File menu<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; to send the output 
						to&nbsp;printer.</TD>
					<TD align="center" width="5%" colSpan="19"><FONT style="BACKGROUND-COLOR: #ffffff"><FONT color="#000000"><B style="COLOR: #006400"><% =dealership %><BR>
									<% =div_office %>
									DIVISIONAL OFFICE<BR>
									GOVT. STOCK REGISTER</B> </FONT></FONT>
					</TD>
				</TR>
				<tr>
					<td colspan="2" align="center">Product&nbsp;&nbsp;
						<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Please Select Product Name"
							Operator="NotEqual" ValueToCompare="Select" ControlToValidate="DropProduct"><font color="red">*</font></asp:CompareValidator></td>
					<td colspan="3"><asp:DropDownList id="DropProduct" runat="server" Width="150px" CssClass="FontStyle">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:DropDownList></td>
					<td colspan="2" align="center">Month&nbsp;&nbsp;
						<asp:CompareValidator id="CompareValidator2" runat="server" ErrorMessage="Please Select Month Name" Operator="NotEqual"
							ValueToCompare="Select" ControlToValidate="DropMonth">*</asp:CompareValidator></td>
					<td colspan="3"><asp:dropdownlist id="DropMonth" runat="server" CssClass="FontStyle">
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
					<td colspan="9"><b>Dealer Name:</b> &nbsp;<% =dealer %></td>
				</tr>
				<tr>
					<td colspan="10" align="center"><asp:Button id="btnView" runat="server" Text="View " Width="70px" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
							ForeColor="White"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="Button1" runat="server" Width="70px" Text="Print" ToolTip="Refer to the note at the bottom of this page"
							BackColor="ForestGreen" BorderColor="DarkSeaGreen" ForeColor="White"></asp:Button></td>
					<td colspan="9"><b>Location:</b>&nbsp;<%  =city %></td>
				</tr>
				<tr>
					<td align="center" width="5%" rowSpan="2">Date</td>
					<td align="center" width="5%" rowSpan="2">Opening Stock</td>
					<td align="center" width="5%" rowSpan="2">Receipt</td>
					<td align="center" width="5%" rowSpan="2">Total</td>
					<td align="center" width="5%" rowSpan="2">Sales</td>
					<td align="center" width="5%" rowSpan="2">Closing Stock</td>
					<td align="center" width="25%" colSpan="5">Meter Reading</td>
					<td align="center" width="30%" colSpan="6">Dip Stock</td>
					<td align="center" width="5%" rowSpan="2">Diff. B/w 6 &amp; 8</td>
					<td align="center" width="5%" rowSpan="2">Remark</td>
				</tr>
				<tr>
					<td align="center" width="5%">1</td>
					<td align="center" width="5%">2</td>
					<td align="center" width="5%">3</td>
					<td align="center" width="5%">4</td>
					<td align="center" width="5%">5</td>
					<td align="center" width="5%">T-1</td>
					<td align="center" width="5%">T-2</td>
					<td align="center" width="5%">T-3</td>
					<td align="center" width="5%">T-4</td>
					<td align="center" width="5%">T-5</td>
					<td align="center" width="5%">Total</td>
				</tr>
				<tr>
					<td align="center" width="5%"><b>1</b></td>
					<td align="center" width="5%"><b>2</b></td>
					<td align="center" width="5%"><b>3</b></td>
					<td align="center" width="5%"><b>4</b></td>
					<td align="center" width="5%"><b>5</b></td>
					<td align="center" width="5%"><b>6</b></td>
					<td align="center" width="25%" colSpan="5"><b>7</b></td>
					<td align="center" width="30%" colSpan="6"><b>8</b></td>
					<td align="center" width="5%"><b>9</b></td>
					<td align="center" width="5%"><b>10</b></td>
				</tr>
				<% 
				string[,] tData=GetData();
				for(int i=0;i<tData.GetLength(0);i++)
				{
				%>
				<tr>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,0].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=GenUtil.strNumericFormat(tData[i,1].ToString())%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,2].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,3].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,4].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=GenUtil.strNumericFormat(tData[i,5].ToString())%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,6].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,7].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,8].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,9].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,10].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,11].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,12].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,13].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,14].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,15].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,16].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,17].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,18].ToString()%></td>
				</tr>
				<% 
				}
				%>
				<tr>
					<td width="4%" colspan="19" align="right"><a href='javascript:window.print()'></a></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
			<asp:ValidationSummary id="ValidationSummary1" style="Z-INDEX: 101; LEFT: 312px; POSITION: absolute; TOP: 440px"
				runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></form>
	</body>
</HTML>
