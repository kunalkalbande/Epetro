<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Header.ascx.cs" Inherits="EPetro.HeaderFooter.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" enableViewState="True" %>

<HTML>
  <HEAD>
		<TITLE>Welcome to epetro - Petro and Gas Station Management System</TITLE>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=iso-8859-1">
		<LINK href="/EPetro/Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<BODY BGCOLOR="#ffffff" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<TABLE WIDTH="1350" BORDER="0" CELLPADDING="0" CELLSPACING="0" align="center">
			<TR>
                <TD colSpan="2"> <IMG src="../HeaderFooter/images/ePetro_Header.png" width="1350" height="60">
					</TD>								
			</TR>
			<TR>
				<TD colspan="2" background="/EPetro/HeaderFooter/images/Menu_04.gif" WIDTH="1350" HEIGHT="31">
					<SCRIPT src="/EPetro/HeaderFooter/images/stm31.js"></SCRIPT>
					<SCRIPT src="/EPetro/HeaderFooter/images/menu.htm"></SCRIPT>
				</TD>
			</TR>
			<TR>
				<TD colspan="2" background="/EPetro/HeaderFooter/images/Menu_05.gif" WIDTH="1350" HEIGHT="2"></TD>
			</TR>
			<tr>
				<td><font face="Arial, Helvetica, sans-serif" color="#075d01" style="FONT-WEIGHT: bold">
						&nbsp;Date :
						<asp:Label id="lblDate" runat="server"></asp:Label></font>
				</td>
				<td align="right">
					<asp:hyperlink id="HLinkHome" runat="server" NavigateUrl="../LoginHome/HomePage.aspx" ForeColor="#075d01">
						<STRONG>Home</STRONG></asp:hyperlink>
				</td>
			</tr>
		</TABLE>
	</BODY>
</HTML>
