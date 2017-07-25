<%@ Page language="c#" Codebehind="PurchaseBill.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.PurchaseBill" %>
<%@ outputcache duration="1000" varybyparam="*" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<HTML>
	<HEAD>
		<title>ePetro: Purchase Bill</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header><table width="778" height="288" align="center">
				<TR>
					<Th valign="top">
						<font color="#006400">Purchase Bill</font><hr>
					</Th>
				</TR>
				<tr>
					<td align="center">
						<P>
							<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="FuelPurchase.aspx">Fuel Purchase</asp:HyperLink></P>
						<P>
							<asp:HyperLink id="HyperLink2" runat="server" NavigateUrl="PurchaseInvoice.aspx">Other Purchase</asp:HyperLink></P>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
