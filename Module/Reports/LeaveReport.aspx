<%@ Page language="c#" Codebehind="LeaveReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.LeaveReport" %>
<%@ import namespace="EPetro.Sysitem.Classes" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Leave Report</title> 
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
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:textbox id="TextBox2" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox><uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center" height="20">
						<font color="#006400">Leave Report</font>
						<hr>
					</TH>
				</TR>
				<tr>
					<td valign="top" align="center">
						Date From&nbsp;&nbsp;
						<asp:textbox id="txtDateFrom" runat="server" Width="110px"  BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>
						<asp:requiredfieldvalidator id="rfvDateFrom" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="Please Select From Date From the Calender">*</asp:requiredfieldvalidator>
						Date To&nbsp;&nbsp;
						<asp:textbox id="Textbox1" runat="server" Width="110px"  BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.all.Textbox1);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0"></A>
						<asp:requiredfieldvalidator id="rfvDateTo" runat="server" ControlToValidate="Textbox1" ErrorMessage="Please Select To Date From the Calender">*</asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnShow" runat="server" Width="70px" Text="View   " BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BtnPrint" Width="70px" Text="Print  " Runat="server" BackColor="ForestGreen"
							BorderColor="DarkSeaGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnExcel" Width="70px" ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen"
							Text="Excel" Runat="server"></asp:button></td>	
				<tr>
					<td align="center">
						<TABLE>
							<TR>
								<TD align="center" colSpan="5" style="HEIGHT: 160px"><asp:datagrid id="GridReport" runat="server" AutoGenerateColumns="False" BorderColor="DarkSeaGreen"
										BorderStyle="None" BorderWidth="0px" BackColor="DarkSeaGreen" CellPadding="1" CellSpacing="1" AllowSorting="True" OnSortCommand="SortCommand_Click">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
										<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
										<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="25px" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
										<FooterStyle ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Emp_ID" SortExpression="Emp_ID" HeaderText="Employee ID">
												<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Emp_Name" SortExpression="Emp_Name" HeaderText="Employee Name"></asp:BoundColumn>
											<asp:BoundColumn DataField="Date_From" SortExpression="Date_From" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="Date_To" SortExpression="Date_To" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="Reason" SortExpression="Reason" HeaderText="Reason">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn SortExpression="isSanction" HeaderText="Approved">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<%#Approved(DataBinder.Eval(Container.DataItem,"isSanction").ToString())%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Visible="False" NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center"
											ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
				<tr>
					<td align="right"></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
