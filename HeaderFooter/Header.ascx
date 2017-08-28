<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="Header.ascx.cs" Inherits="EPetro.HeaderFooter.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" EnableViewState="True" %>

<html>
<head>
    <title>Welcome to epetro - Petro and Gas Station Management System</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="/EPetro/Sysitem/Styles.css" type="text/css" rel="stylesheet">
</head>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <table width="1350" border="0" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td colspan="2">
                <img src="<%= Page.ResolveUrl("~/HeaderFooter/images/ePetro_Header.png")%>" width="1350" height="60">
            </td>
        </tr>
        <tr>
            <td colspan="2" background="/EPetro/HeaderFooter/images/Menu_04.gif" width="1350" height="31">
                <script src="/EPetro/HeaderFooter/images/stm31.js"></script>
                <script src="/EPetro/HeaderFooter/images/menu.htm"></script>
            </td>
        </tr>
        <tr>
            <td colspan="2" background="/EPetro/HeaderFooter/images/Menu_05.gif" width="1350" height="2"></td>
        </tr>
        <tr>
            <td><font face="Arial, Helvetica, sans-serif" color="#075d01" style="font-weight: bold">
						&nbsp;Date :
						<asp:Label id="lblDate" runat="server"></asp:Label></font>
            </td>
            <td align="right">
                <asp:HyperLink ID="HLinkHome" runat="server" NavigateUrl="../LoginHome/HomePage.aspx" ForeColor="#075d01">
						<STRONG>Home</STRONG></asp:HyperLink>
            </td>
        </tr>
    </table>
</body>
</html>
