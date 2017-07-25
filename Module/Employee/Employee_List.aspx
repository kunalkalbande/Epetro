<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Employee_List.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Employee.Employee_List" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Employee List</title> <!--
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
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="View_Customer" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR>
					<TH style="HEIGHT: 3px" align="center">
						<font color="#006400">Employee List</font>
						<HR>
					</TH>
				</TR>
				<tr>
					<td align="center">
						<TABLE style="WIDTH: 318px; HEIGHT: 64px">
							<TR>
								<TD>Employee&nbsp;ID&nbsp;&nbsp;</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtEmpID" runat="server"
										BorderStyle="Groove" CssClass="FontStyle"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Name</TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtName" runat="server" BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Designation</TD>
								<TD><asp:textbox onkeypress="return GetOnlyChars(this, event);" id="txtDesig" runat="server" BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD align="center"><asp:linkbutton id="btnSearch" runat="server" Width="80px">Search</asp:linkbutton></TD>
							</TR>
						</TABLE>
						<asp:datagrid id="GridSearch" BorderStyle="None" Width="355px" OnSortCommand="SortCommand_Click"
							AllowSorting="True" CellSpacing="1" PageSize="5" AllowPaging="True" Runat="server" HeaderStyle-BackColor="#ff99ff"
							AutoGenerateColumns="False" BorderColor="DarkSeaGreen" BorderWidth="0px" BackColor="DarkSeaGreen"
							CellPadding="1" Font-Size="Smaller" Font-Names="Arial">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Emp_ID" SortExpression="Emp_ID" ReadOnly="True" HeaderText="Employee ID">
									<HeaderStyle Width="80pt"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Emp_Name" SortExpression="Emp_Name" ReadOnly="True" HeaderText="Name">
									<HeaderStyle Width="200px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Designation" SortExpression="Designation" ReadOnly="True" HeaderText="Designation">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="Emp_ID" DataNavigateUrlFormatString="Employee_Update.aspx?ID={0}" 
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
			<uc1:footer id="Footer1" runat="server"></uc1:footer></FORM>
	</body>
</HTML>
