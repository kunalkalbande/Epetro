<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Density_Register.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.Density_Register" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Density Register Report</title><!--
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
			<asp:ValidationSummary id="ValidationSummary1" style="Z-INDEX: 101; LEFT: 232px; POSITION: absolute; TOP: 408px"
				runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
			<uc1:Header id="Header1" runat="server"></uc1:Header>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:TextBox>
			<table border="1" width="778" height="278" cellSpacing="0" align="center">
				<tr>
					<TD vAlign="top" align="left" width="100%" colSpan="7"><STRONG><FONT color="#ff0033"><U>Note</U></FONT><FONT color="#ff0033">:</FONT></STRONG>
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
					<td width="100%" align="left" colspan="16"><FONT style="BACKGROUND-COLOR: #ffffff"><FONT color="#000000"><b style="COLOR: #006400">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<% =dealership %>
									&nbsp;
									<BR>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<% =div_office  %>
									DIVISIONAL OFFICE</b></FONT></FONT><br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<FONT style="BACKGROUND-COLOR: #ffffff"><FONT color="#000000"><b style="COLOR: #006400">DENSITY 
									REGISTER</b></FONT></FONT></td>
				</tr>
				<tr>
					<td colspan="2" align="center">Product
						<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Please Select Product Name"
							Operator="NotEqual" ValueToCompare="Select" ControlToValidate="DropProduct">*</asp:CompareValidator></td>
					<td colspan="3"><asp:DropDownList id="DropProduct" runat="server" Width="150px" AutoPostBack="True" CssClass="FontStyle">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:DropDownList></td>
					<td colspan="3" align="center">Month
						<asp:CompareValidator id="CompareValidator3" runat="server" ErrorMessage="Please Select Month Name" Operator="NotEqual"
							ValueToCompare="Select" ControlToValidate="DropMonth">*</asp:CompareValidator></td>
					<td colspan="5"><asp:DropDownList id="DropMonth" runat="server" CssClass="FontStyle">
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
						</asp:DropDownList></td>
					<td colspan="10"><b>Dealer Name:</b>&nbsp;<%=dealer%></td>
				</tr>
				<tr>
					<td colspan="2" align="center">Tank ID
						<asp:CompareValidator id="CompareValidator2" runat="server" ErrorMessage="Please Select Tank Name" Operator="NotEqual"
							ValueToCompare="Select" ControlToValidate="DropTank">*</asp:CompareValidator></td>
					<td colspan="3" align="center"><asp:DropDownList id="DropTank" runat="server" Width="150px" CssClass="FontStyle">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:DropDownList></td>
					<td colspan="8" align="center"><asp:Button id="btnView" runat="server" Text="View " Width="70px" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
							ForeColor="White"></asp:Button>
						<asp:Button id="Button1" runat="server" Width="70px" Text="Print" ToolTip="Refer to the note at the bottom of this page"
							BackColor="ForestGreen" BorderColor="DarkSeaGreen" ForeColor="White"></asp:Button></td>
					</TD><td colspan="10"><b>Location:</b>&nbsp;<%=city%></td>
				</tr>
				<tr>
					<td width="4%" align="center" rowspan="3">Date</td>
					<td width="12%" colspan="3" align="center">Morning Density
					</td>
					<td width="8%" colspan="2" align="center">Receipts</td>
					<td width="107" colspan="4" align="center" style="WIDTH: 107px">Observed Density</td>
					<td width="16%" colspan="4" align="center">Observed Temp.</td>
					<td width="19%" colspan="4" align="center">Density Converted to 15<sup>o</sup>C</td>
					<td width="5%" rowspan="3" align="center">As Per Challan at 15<sup>o</sup>C</td>
					<td width="5%" rowspan="3" align="center">Diff. B/w 9 &amp; 10</td>
					<td width="15%" colspan="3" align="center">After Decantation</td>
				</tr>
				<tr>
					<td width="12%" colspan="3" align="center">Observed</td>
					<td width="4%" rowspan="2" align="center">Invoice No.</td>
					<td width="4%" rowspan="2" align="center">Qty.</td>
					<td width="107" colspan="4" align="center" style="WIDTH: 107px">Compartment</td>
					<td width="16%" colspan="4" align="center">Compartment</td>
					<td width="19%" colspan="4" align="center">Compartment</td>
					<td width="5%" align="center" rowspan="2">Density</td>
					<td width="5%" align="center" rowspan="2">Temp</td>
					<td width="5%" align="center" rowspan="2">Density Converted to 15<sup>o</sup>C</td>
				</tr>
				<tr>
					<td width="4%" align="center">Density</td>
					<td width="4%" align="center">Temp.</td>
					<td width="4%" align="center">Density Converted to 15<sup>o</sup>C</td>
					<td width="4%" align="center">I</td>
					<td width="4%" align="center">II</td>
					<td width="4%" align="center">III</td>
					<td width="4%" align="center">IV</td>
					<td width="4%" align="center">I</td>
					<td width="4%" align="center">II</td>
					<td width="4%" align="center">III</td>
					<td width="4%" align="center">IV</td>
					<td width="4%" align="center">I</td>
					<td width="4%" align="center">II</td>
					<td width="4%" align="center">III</td>
					<td width="4%" align="center">IV</td>
				</tr>
				<tr>
					<td width="4%" align="center">1</td>
					<td width="4%" align="center">2</td>
					<td width="4%" align="center">3</td>
					<td width="4%" align="center">4</td>
					<td width="4%" align="center">5</td>
					<td width="4%" align="center">6</td>
					<td width="107" colspan="4" align="center" style="WIDTH: 107px">7</td>
					<td width="16%" colspan="4" align="center">8</td>
					<td width="19%" colspan="4" align="center">9</td>
					<td width="5%" align="center">10</td>
					<td width="5%" align="center">11</td>
					<td width="5%" align="center">12</td>
					<td width="5%" align="center">13</td>
					<td width="5%" align="center">14</td>
				</tr>
				<% 
				string[,] tData=GetData();
				for(int i=0;i<tData.GetLength(0);i++)
				{
				%>
				<tr>
					<td width="4%">&nbsp;<%=tData[i,0].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,1].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,2].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,3].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,4].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,5].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,6].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,7].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,8].ToString()%></td>
					<td width="26">&nbsp;<%=tData[i,9].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,10].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,11].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,12].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,13].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,14].ToString()%></td>
					<td width="5%">&nbsp;<%=tData[i,15].ToString()%></td>
					<td width="5%">&nbsp;<%=tData[i,16].ToString()%></td>
					<td width="5%">&nbsp;<%=tData[i,17].ToString()%></td>
					<td width="5%">&nbsp;<%=tData[i,18].ToString()%></td>
					<td width="5%">&nbsp;<%=tData[i,19].ToString()%></td>
					<td width="5%">&nbsp;<%=tData[i,20].ToString()%></td>
					<td width="5%">&nbsp;<%=tData[i,21].ToString()%></td>
					<td width="5%">&nbsp;<%=tData[i,22].ToString()%></td>
				</tr>
				<%}
				%>
				<tr>
					<td colspan="23" align="right"></td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
