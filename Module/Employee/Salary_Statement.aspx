<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Salary_Statement.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Employee.Salary_Statement" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Salary Statement</title> <!--
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
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center" border=0>
				<tr valign=top height=20>
					<TH align="center">
						<font color="#006400">Salary Statement</font>
						<hr>
					</TH>
				</tr>
				<!--TR>
					<td vAlign="top" align="center"><FONT color="#ff0000">Fields Marked as (*) Are 
							Mandatory</FONT></td>
				</TR-->
				<tr valign=top>
					<td align="center">
						<TABLE>
							<TR>
								<TD align="center"><asp:label id="Label1" runat="server"> Salary Month<font color="red">*</font></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropMonth" ValueToCompare="Select"
										Operator="NotEqual" ErrorMessage="Please Select the Salary Month"><font color="red">*</font></asp:comparevalidator><asp:comparevalidator id="CompareValidator2" runat="server" ControlToValidate="DropYear" ValueToCompare="Not Define"
										Operator="NotEqual" ErrorMessage="Please Select Year"><font color="red">*</font></asp:comparevalidator>&nbsp;&nbsp;</TD>
								<TD><asp:dropdownlist id="DropMonth" runat="server" Width="116px" CssClass="FontStyle">
										<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
										<asp:ListItem Value="January">January</asp:ListItem>
										<asp:ListItem Value="February">February</asp:ListItem>
										<asp:ListItem Value="March">March</asp:ListItem>
										<asp:ListItem Value="April">April</asp:ListItem>
										<asp:ListItem Value="May">May</asp:ListItem>
										<asp:ListItem Value="June">June</asp:ListItem>
										<asp:ListItem Value="July">July</asp:ListItem>
										<asp:ListItem Value="August">August</asp:ListItem>
										<asp:ListItem Value="September">September</asp:ListItem>
										<asp:ListItem Value="October">October</asp:ListItem>
										<asp:ListItem Value="November">November</asp:ListItem>
										<asp:ListItem Value="December">December</asp:ListItem>
									</asp:dropdownlist></TD>
								<td><asp:dropdownlist id="DropYear" runat="server" CssClass="FontStyle">
										<asp:ListItem Value="Not Define">Not Define</asp:ListItem>
										<asp:ListItem Value="2000">2000</asp:ListItem>
										<asp:ListItem Value="2001">2001</asp:ListItem>
										<asp:ListItem Value="2002">2002</asp:ListItem>
										<asp:ListItem Value="2003">2003</asp:ListItem>
										<asp:ListItem Value="2004">2004</asp:ListItem>
										<asp:ListItem Value="2005">2005</asp:ListItem>
										<asp:ListItem Value="2006">2006</asp:ListItem>
										<asp:ListItem Value="2007">2007</asp:ListItem>
										<asp:ListItem Value="2008">2008</asp:ListItem>
										<asp:ListItem Value="2009">2009</asp:ListItem>
										<asp:ListItem Value="2010">2010</asp:ListItem>
										<asp:ListItem Value="2011">2011</asp:ListItem>
										<asp:ListItem Value="2012">2012</asp:ListItem>
										<asp:ListItem Value="2013">2013</asp:ListItem>
										<asp:ListItem Value="2014">2014</asp:ListItem>
										<asp:ListItem Value="2015">2015</asp:ListItem>
										<asp:ListItem Value="2016">2016</asp:ListItem>
										<asp:ListItem Value="2017">2017</asp:ListItem>
										<asp:ListItem Value="2018">2018</asp:ListItem>
										<asp:ListItem Value="2019">2019</asp:ListItem>
										<asp:ListItem Value="2020">2020</asp:ListItem>
									</asp:dropdownlist></td>
									<TD>&nbsp;&nbsp;<asp:button id="btnShow" runat="server" Width="70px" Text="View" BorderColor="DarkSeaGreen"
										BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnprint" runat="server" Width="70px" Text="Print" BorderColor="DarkSeaGreen"
										BackColor="ForestGreen" ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:Button id="btnExcel" Width="70px" ForeColor="White" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
										Text="Excel" Runat="server"></asp:Button></TD>
							</TR>
						</TABLE>
						<asp:datagrid id="GridMachineReport" style="TOP: 50px" runat="server" BorderColor="DarkSeaGreen"
							BackColor="DarkSeaGreen" OnSortCommand="SortCommand_Click" ShowFooter="True" AllowSorting="True"
							PageSize="3" CellPadding="1" BorderWidth="0px" AutoGenerateColumns="False" CellSpacing="1"
							BorderStyle="None">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
							<FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="S. No">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<%#GetSNo()%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Emp_ID" SortExpression="Emp_ID" HeaderText="Emp ID" FooterText="Total">
									<HeaderStyle Width="50px"></HeaderStyle>
									<FooterStyle Font-Bold="True"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Emp_Name" SortExpression="Emp_Name" HeaderText="Name">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Salary" SortExpression="Salary" HeaderText="Monthly Salary">
									<HeaderStyle Width="75px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OT_Compensation" SortExpression="OT_Compensation" HeaderText="OT Compansation">
									<HeaderStyle Width="50px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Total Days">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
									<FooterTemplate>
										<%=""%>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Leave">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
									<FooterTemplate>
										<%=Cache["Leave11"]%>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Total Present">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
									<FooterTemplate>
										<%=Cache["Total_Present11"]%>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Overtime&lt;br&gt;Hours">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
									<FooterTemplate>
										<%=GenUtil.strNumericFormat(Cache["OverTime_Hour11"].ToString())%>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Net Salary">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									<FooterTemplate>
										<%=Cache["Net_Salary11"]%>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Advance">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" ForeColor="#8C4510"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid><asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
				<TR>
					<TD vAlign=bottom>&nbsp;&nbsp;&nbsp;<FONT color="#ff0033"><STRONG><U>Note</U> :</STRONG></FONT>
						If the Salary Calculation based on 30 days, then the attendance should be 
						marked for Sundays also.</TD>
				</TR>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
