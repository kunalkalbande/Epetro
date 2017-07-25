<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<%@ Page language="c#" Codebehind="ErrorPage.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Sysitem.ErrorPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Error Page</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="778" height="278" align=center>
				<tr>
					<td>
						<P align="center"><FONT color="red" size="5"> 
								Your&nbsp;&nbsp;Session&nbsp;Has&nbsp;Expired </FONT>
						</P>
						<P align="center">
							<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="../LoginHome/Login.aspx" Font-Size="Medium">Please Login</asp:HyperLink></P>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
