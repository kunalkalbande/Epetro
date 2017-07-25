<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="ModuleManage.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Admin.ModuleManagement.ModuleManage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Module Management</title> 
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
		<LINK href="../../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="278" width="778" align="center">
				<tr height="10">
					<th align="center">
						<font color="#006400">Module Management</font><hr>
					</th>
				</tr>
				<tr>
					<td align="center">
						<asp:Button id="btnUpdate" runat="server" Text="Update Stock Management" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" ForeColor="White"></asp:Button>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
