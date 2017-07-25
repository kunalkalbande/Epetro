<%@ Page language="c#" Codebehind="GovtStockRegister_PrintPreview.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.GovtStockRegister_PrintPreview" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Govt. Stock Register Report Print Preview</title> <!--
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
			<table cellSpacing="0" width="100%" border="1" align=center>
				<TR>
					<TD align="center" width="5%" colSpan="19"><FONT style="BACKGROUND-COLOR: #ffffff"><FONT color="#000000"><B style="COLOR: #006400"><%=Session["DealerShip"].ToString() %><BR>
									<%=Session["Div_Office"].ToString()%>
									DIVISIONAL OFFICE<BR>
									GOVT. STOCK REGISTER</B> </FONT></FONT>
					</TD>
				</TR>
				<tr>
					<td colspan="2" align="center"><STRONG>Product&nbsp;</STRONG>&nbsp;</td>
					<td colspan="3"><%=Session["Product"].ToString()%></td>
					<td colspan="2" align="center"><STRONG>Month</STRONG>&nbsp;&nbsp;</td>
					<td colspan="3"><%=Session["Month"].ToString()%></td>
					<td colspan="9"><b>Dealer Name:</b> &nbsp;<%=Session["Dealer"].ToString()%></td>
				</tr>
				<tr>
					<td colspan="10" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
					<td colspan="9"><b>Location:</b>&nbsp;<%=Session["Location"].ToString()%></td>
				</tr>
				<tr>
					<td align="center" width="5%" rowSpan="2"><STRONG>Date</STRONG></td>
					<td align="center" width="5%" rowSpan="2"><STRONG>Opening Stock</STRONG></td>
					<td align="center" width="5%" rowSpan="2"><STRONG>Receipt</STRONG></td>
					<td align="center" width="5%" rowSpan="2"><STRONG>Total</STRONG></td>
					<td align="center" width="5%" rowSpan="2"><STRONG>Sales</STRONG></td>
					<td align="center" width="5%" rowSpan="2"><STRONG>Closing Stock</STRONG></td>
					<td align="center" width="25%" colSpan="5"><STRONG>Meter Reading</STRONG></td>
					<td align="center" width="30%" colSpan="6"><STRONG>Dip Stock</STRONG></td>
					<td align="center" width="5%" rowSpan="2"><STRONG>Diff. B/w 6 &amp; 8</STRONG></td>
					<td align="center" width="5%" rowSpan="2"><STRONG>Remark</STRONG></td>
				</tr>
				<tr>
					<td align="center" width="5%"><STRONG>1</STRONG></td>
					<td align="center" width="5%"><STRONG>2</STRONG></td>
					<td align="center" width="5%"><STRONG>3</STRONG></td>
					<td align="center" width="5%"><STRONG>4</STRONG></td>
					<td align="center" width="5%"><STRONG>5</STRONG></td>
					<td align="center" width="5%"><STRONG>T-1</STRONG></td>
					<td align="center" width="5%"><STRONG>T-2</STRONG></td>
					<td align="center" width="5%"><STRONG>T-3</STRONG></td>
					<td align="center" width="5%"><STRONG>T-4</STRONG></td>
					<td align="center" width="5%"><STRONG>T-5</STRONG></td>
					<td align="center" width="5%"><STRONG>Total</STRONG></td>
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
				string[,] tData=(string[,])Session["Data"];
				for(int i=0;i<tData.GetLength(0);i++)
				{
				%>
				<tr>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,0].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,1].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,2].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,3].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,4].ToString()%></td>
					<td width="5%" style="HEIGHT: 18px">&nbsp;<%=tData[i,5].ToString()%></td>
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
		</form>
	</body>
</HTML>
