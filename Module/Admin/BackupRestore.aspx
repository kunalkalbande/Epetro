<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="BackupRestore.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Admin.BackupRestore" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Back & Restore</title> <!--
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
		<script language="javascript">
function Check(t)
	{
		var str=t.value
		if(t.value!="" && str.indexOf(".")>0)
		{
			str=str.substring(0,str.lastIndexOf("."));
			//if(t.value.indexOf(".LDF")>0)
			//alert(t.value)
			if(t.value.toLowerCase().indexOf("epetro.bak")>0)
			{
				document.Form1.btnRestore.disabled=false;
				document.Form1.tempPath.value=str;
			}
			else
			{
				alert("Please Select Appropriate 'EPetro.bak' File");
				document.Form1.btnRestore.disabled=true;
				return;
			}
		}
		else
		{
			//alert("Please Select The 'LDF' File");
			alert("Please Select The 'bak' File");
			document.Form1.btnRestore.disabled=false;
			return;
		}
	}
	function Progressbar()
	{
		document.all.lblPro.style.visibility="visible"
		document.all.lblPro.style.font.bold=true
	}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server" DESIGNTIMEDRAGDROP="11"></uc1:header><input id="tempPath" type="hidden" name="tempPath" runat="server">
			<table height="288" cellSpacing="0" cellPadding="0" width="778" align="center" border=0>
				<TBODY>
					<tr valign=top><th align="center"><font color="#006400">Backup & Restore</font><hr></th></tr>
					<tr>
						<td align="center" valign=bottom><input style="BORDER-RIGHT: palegoldenrod thin; TABLE-LAYOUT: auto; BORDER-TOP: palegoldenrod thin; DISPLAY: block; FONT-WEIGHT: bold; VISIBILITY: hidden; BORDER-LEFT: palegoldenrod thin; WIDTH: 200px; CURSOR: wait; COLOR: firebrick; DIRECTION: ltr; TEXT-INDENT: 25px; BORDER-BOTTOM: palegoldenrod thin; BORDER-COLLAPSE: collapse; HEIGHT: 30px; BACKGROUND-COLOR: palegoldenrod"
								type="button" value="Processing Please Wait..." name="lblPro"></td>
					</tr>
					<tr>
						<td vAlign="middle" align="center" height="100"><INPUT id="ff1" style="BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
								type="file" onchange="Check(this);" size="70" name="ff1">&nbsp;&nbsp;<asp:button id="btnRestore" runat="server" Width="70px"  Text="Restore"></asp:button>&nbsp;&nbsp;
                            <asp:button id="btnBackup" runat="server" Width="70px" Text="Backup"></asp:button></td>
					</tr>
					<tr>
						<td vAlign="bottom">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="5"><FONT color="black" size="2"><STRONG><U>Remark&nbsp;:</U></STRONG>&nbsp; 
									The backup process stores the copy of your data&nbsp;in the home drive in a 
									folder <STRONG>ePetroBackup</STRONG>. For example if your  
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									 home drive is C: then your backup is copied in <b>C:\ePetroBackup</b> folder.&nbsp;</FONT>
							</FONT></FONT></td>
					</tr>
				</TBODY>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
