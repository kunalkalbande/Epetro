<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="DailySalesRecord_PrintPreview.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.DialySalesRecord_PrintPreview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Daily Sales Report</title> 
		<!--
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
			<table cellSpacing="0" width="778" border="1" align=center>
				<tr>
					<td align="center" width="116%" colSpan="27"><font style="BACKGROUND-COLOR: #ffffff" color="#000000"><b style="COLOR: #006400"><%=Session["DealerShip"].ToString() %>
								<br>
								<%=Session["Div_Office"].ToString()%>
								DIVISIONAL OFFICE<br>
								DAILY SALES&nbsp;RECORD</b> </font>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center"><STRONG>Product</STRONG></td>
					<td colspan="4"><%=Session["Product"].ToString()%></td>
					<td colspan="2" align="center"><STRONG>Month</STRONG></td>
					<td colspan="3"><%=Session["Month"].ToString()%></td>
					<td colspan="2"><%=Session["Year"].ToString()%></td>
					<td colspan="14"><b>Dealer Name:</b> &nbsp;<%=Session["Dealer"].ToString()%></td>
				</tr>
				<tr>
					<td colspan="12" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
					<td colspan="15"><b>Location:</b>&nbsp;<%=Session["Location"].ToString() %></td>
				</tr>
				<tr>
					<td align="center" width="4%" rowSpan="3"><STRONG>Date</STRONG></td>
					<td align="center" width="8%" colSpan="2" rowSpan="2"><STRONG>Tank 1</STRONG></td>
					<td align="center" width="8%" colSpan="2" rowSpan="2"><STRONG>Tank 2</STRONG></td>
					<td align="center" width="8%" colSpan="2" rowSpan="2"><STRONG>Tank 3</STRONG></td>
					<td align="center" width="8%" colSpan="2" rowSpan="2"><STRONG>Tank 4</STRONG></td>
					<td align="center" width="8%" colSpan="2" rowSpan="2"><STRONG>Tank 5</STRONG></td>
					<td align="center" width="8%" colSpan="2" rowSpan="2"><STRONG>Tank 6</STRONG></td>
					<td align="center" width="4%" rowSpan="3"><STRONG>Opening Stock</STRONG></td>
					<td align="center" width="4%" rowSpan="3"><STRONG>Receipt</STRONG></td>
					<td align="center" width="4%" rowSpan="3"><STRONG>Total Stock</STRONG></td>
					<td align="center" width="16%" colSpan="4"><STRONG>Opening Meter Reading</STRONG></td>
					<td align="center" width="4%" rowSpan="3"><STRONG>Testing</STRONG></td>
					<td align="center" width="4%" rowSpan="3"><STRONG>Sales</STRONG></td>
					<td align="center" width="4%" rowSpan="3"><STRONG>Cumm. Sales</STRONG></td>
					<td align="center" width="8%" colSpan="2" rowSpan="2"><STRONG>Total Engine and Gear Oil 
							Sales</STRONG></td>
					<td align="center" width="16%" colSpan="2" rowSpan="2"><STRONG>Total 2T/4T Oil</STRONG></td>
				</tr>
				<tr>
					<td align="center" width="16%" colSpan="4"><STRONG>Pumps</STRONG></td>
				</tr>
				<tr>
					<td align="center" width="4%"><STRONG>Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Water Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Water Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Water Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Water Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Water Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>Water Dip</STRONG></td>
					<td align="center" width="4%"><STRONG>1</STRONG></td>
					<td align="center" width="4%"><STRONG>2</STRONG></td>
					<td align="center" width="4%"><STRONG>3</STRONG></td>
					<td align="center" width="4%"><STRONG>4</STRONG></td>
					<td align="center" width="4%"><STRONG>Packed</STRONG></td>
					<td align="center" width="4%"><STRONG>Loose</STRONG></td>
					<td align="center" width="4%"><STRONG>Packed</STRONG></td>
					<td align="center" width="4%"><STRONG>Loose</STRONG></td>
				</tr>
				<% 
				string[,] tData=(string[,])Session["Data"];
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
			</table>
		</form>
	</body>
</HTML>
