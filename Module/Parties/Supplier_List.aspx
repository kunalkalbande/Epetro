<%@ Page language="c#" Codebehind="Supplier_List.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Parties.Supplier_List" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Vendor List</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script id="Validations" language="javascript" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="View_Customer" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header><table width="778" height="288" align="center">
				<TR valign=top height=20>
					<TH align="center">
						<font color="#006400">Vendor List</font><hr>
					</TH>
				</TR>
				<tr valign=top>
					<td align="center">
						<TABLE>
							<TR>
								<TD>
									Vendor&nbsp;ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtSuppID" runat="server" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									Name</TD>
								<TD><asp:textbox id="txtName" runat="server" onkeypress="return GetOnlyChars(this, event);" BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									Place</TD>
								<TD><asp:textbox id="txtPlace" runat="server" onkeypress="return GetOnlyChars(this, event);" BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD align="center"><asp:linkbutton id="btnSearch" runat="server">Search</asp:linkbutton></TD>
							</TR>
						</TABLE>
						<asp:datagrid id="GridSearch" AllowPaging="True" AutoGenerateColumns="False" Width="380px" Runat="server"
							HeaderStyle-BackColor="#ff99ff" BorderColor="DarkSeaGreen" BorderStyle="None" BorderWidth="0px"
							BackColor="DarkSeaGreen" CellPadding="1" Font-Size="Smaller" Font-Names="Arial" PageSize="5"
							CellSpacing="1" AllowSorting="True" OnSortCommand="SortCommand_Click">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Supp_ID" ReadOnly="True" HeaderText="Vendor ID" SortExpression="Supp_ID">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Supp_Name" ReadOnly="True" HeaderText="Name" SortExpression="Supp_Name">
									<HeaderStyle Width="250px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="City" ReadOnly="True" HeaderText="Place" SortExpression="City">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="Supp_ID" DataNavigateUrlFormatString="Supplier_Update.aspx?ID={0}" 
 HeaderText="Edit">
									<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle NextPageText="Next" PrevPageText="Prev" HorizontalAlign="Center" ForeColor="#F7F7F7"
								BackColor="#009900" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</FORM>
	</body>
</HTML>
