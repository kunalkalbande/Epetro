<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="DensityRegister_PrintPreview.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.DensityRegister_PrintPreview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Density Register Report Print Preview</title> 
		<!--
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
			<table border="1" width="778" height="278" cellSpacing="0" align=center>
				<tr>
					<td width="100%" align="center" colspan="23"><FONT style="BACKGROUND-COLOR: #ffffff"><FONT color="#000000"><b style="COLOR: #006400"><%=Session["DealerShip"].ToString() %>
									<BR>
									<%=Session["Div_Office"].ToString() %>
									DIVISIONAL OFFICE</b></FONT></FONT><br>
						<FONT style="BACKGROUND-COLOR: #ffffff"><FONT color="#000000"><b style="COLOR: #006400">DENSITY 
									REGISTER</b></FONT></FONT></td>
				</tr>
				<tr>
					<td colspan="2" align="center"><STRONG>Product</STRONG></td>
					<td colspan="3"><%=Session["Product"].ToString()%></td>
					<td colspan="3" align="center"><STRONG>Month </STRONG>
					</td>
					<td colspan="6" style="WIDTH: 142px"><%=Session["Month"].ToString()%></td>
					<td colspan="9"><b>Dealer Name:</b>&nbsp;<%=Session["Dealer"].ToString()%></td>
				</tr>
				<tr>
					<td colspan="2" align="center"><STRONG>Tank ID</STRONG></td>
					<td colspan="12" align="left"><%=Session["Tank"].ToString()%></td>
					</TD><td colspan="10"><b>Location:</b>&nbsp;<%=Session["Location"].ToString()%></td>
				</tr>
				<tr>
					<td width="4%" align="center" rowspan="3"><STRONG>Date</STRONG></td>
					<td width="12%" colspan="3" align="center"><STRONG>Morning Density</STRONG>
					</td>
					<td width="8%" colspan="2" align="center"><STRONG>Receipts</STRONG></td>
					<td width="107" colspan="4" align="center" style="WIDTH: 107px"><STRONG>Observed 
							Density</STRONG></td>
					<td width="16%" colspan="4" align="center"><STRONG>Observed Temp.</STRONG></td>
					<td width="19%" colspan="4" align="center"><STRONG>Density Converted to 15<sup>o</sup>C</STRONG></td>
					<td width="5%" rowspan="3" align="center"><STRONG>As Per Challan at 15<sup>o</sup>C</STRONG></td>
					<td width="5%" rowspan="3" align="center"><STRONG>Diff. B/w 9 &amp; 10</STRONG></td>
					<td width="15%" colspan="3" align="center"><STRONG>After Decantation</STRONG></td>
				</tr>
				<tr>
					<td width="12%" colspan="3" align="center"><STRONG>Observed</STRONG></td>
					<td width="4%" rowspan="2" align="center"><STRONG>Invoice No.</STRONG></td>
					<td width="4%" rowspan="2" align="center"><STRONG>Qty.</STRONG></td>
					<td width="107" colspan="4" align="center" style="WIDTH: 107px"><STRONG>Compartment</STRONG></td>
					<td width="16%" colspan="4" align="center"><STRONG>Compartment</STRONG></td>
					<td width="19%" colspan="4" align="center"><STRONG>Compartment</STRONG></td>
					<td width="5%" align="center" rowspan="2"><STRONG>Density</STRONG></td>
					<td width="5%" align="center" rowspan="2"><STRONG>Temp</STRONG></td>
					<td width="5%" align="center" rowspan="2"><STRONG>Density Converted to 15<sup>o</sup>C</STRONG></td>
				</tr>
				<tr>
					<td width="4%" align="center"><STRONG>Density</STRONG></td>
					<td width="4%" align="center"><STRONG>Temp.</STRONG></td>
					<td width="4%" align="center"><STRONG>Density Converted to 15<sup>o</sup>C</STRONG></td>
					<td width="4%" align="center"><STRONG>I</STRONG></td>
					<td width="4%" align="center"><STRONG>II</STRONG></td>
					<td width="4%" align="center"><STRONG>III</STRONG></td>
					<td width="26" align="center" style="WIDTH: 26px"><STRONG>IV</STRONG></td>
					<td width="4%" align="center"><STRONG>I</STRONG></td>
					<td width="4%" align="center"><STRONG>II</STRONG></td>
					<td width="34" align="center" style="WIDTH: 34px"><STRONG>III</STRONG></td>
					<td width="4%" align="center"><STRONG>IV</STRONG></td>
					<td width="4%" align="center"><STRONG>I</STRONG></td>
					<td width="4%" align="center"><STRONG>II</STRONG></td>
					<td width="4%" align="center"><STRONG>III</STRONG></td>
					<td width="4%" align="center"><STRONG>IV</STRONG></td>
				</tr>
				<tr>
					<td width="4%" align="center"><STRONG>1</STRONG></td>
					<td width="4%" align="center"><STRONG>2</STRONG></td>
					<td width="4%" align="center"><STRONG>3</STRONG></td>
					<td width="4%" align="center"><STRONG>4</STRONG></td>
					<td width="4%" align="center"><STRONG>5</STRONG></td>
					<td width="4%" align="center"><STRONG>6</STRONG></td>
					<td width="107" colspan="4" align="center" style="WIDTH: 107px"><STRONG>7</STRONG></td>
					<td width="16%" colspan="4" align="center"><STRONG>8</STRONG></td>
					<td width="19%" colspan="4" align="center"><STRONG>9</STRONG></td>
					<td width="5%" align="center"><STRONG>10</STRONG></td>
					<td width="5%" align="center"><STRONG>11</STRONG></td>
					<td width="5%" align="center"><STRONG>12</STRONG></td>
					<td width="5%" align="center"><STRONG>13</STRONG></td>
					<td width="5%" align="center"><STRONG>14</STRONG></td>
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
					<td width="26" style="WIDTH: 26px">&nbsp;<%=tData[i,9].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,10].ToString()%></td>
					<td width="4%">&nbsp;<%=tData[i,11].ToString()%></td>
					<td width="34" style="WIDTH: 34px">&nbsp;<%=tData[i,12].ToString()%></td>
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
		</form>
	</body>
</HTML>
