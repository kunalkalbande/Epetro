<%@ Page language="c#" Codebehind="CustomerLedgerSummary.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Accounts.ViewAccounts" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Customer Ledger Summary</title> <!--
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
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table style="WIDTH: 778px; HEIGHT: 288px" height="288" width="778" align="center">
				<TBODY>
					<TR>
						<TH>
							<font color="#006400">Customer Ledger Summary</font>
							<hr>
						</TH>
					</TR>
					<TR>
						<TD align="center">
							<TABLE width="600">
								<TR>
									<TD vAlign="middle" align="center">Date From
										<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom" ErrorMessage="Date Required">*</asp:requiredfieldvalidator></TD>
									<TD style="WIDTH: 181px"><asp:textbox id="txtDateTo" runat="server" Width="115px"  BorderStyle="Groove"
											CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<TD vAlign="middle" align="center" colSpan="1" rowSpan="1">To</TD>
									<TD><asp:textbox id="txtDateFrom" runat="server" Width="115px"  BorderStyle="Groove"
											CssClass="FontStyle"></asp:textbox><A onClick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center" colSpan="1">
										<P>Customer Category</P>
									</TD>
									<TD style="WIDTH: 181px"><asp:dropdownlist id="drpcustype" runat="server" Width="150px" CssClass="FontStyle">
											<asp:ListItem Value="All">All</asp:ListItem>
											<asp:ListItem Value="Contractor">Contractor</asp:ListItem>
											<asp:ListItem Value="Fleet">Fleet</asp:ListItem>
											<asp:ListItem Value="General">General</asp:ListItem>
											<asp:ListItem Value="Goverment">Goverment</asp:ListItem>
											<asp:ListItem Value="Key Customers">Key Customers</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="WIDTH: 100px" vAlign="middle" align="center">
										<P>Balance Type</P>
									</TD>
									<TD><asp:dropdownlist id="drpOptions" runat="server" Width="150px" CssClass="FontStyle">
											<asp:ListItem Value="All">All</asp:ListItem>
											<asp:ListItem Value="Total Balance">Closing Balance</asp:ListItem>
											<asp:ListItem Value="Opening Balance">Opening Balance</asp:ListItem>
											<asp:ListItem Value="Transaction">Transaction</asp:ListItem>
										</asp:dropdownlist></TD>
								<tr>
									<td colspan="4" align="center">
										<asp:button id="cmdrpt" runat="server" Width="70px" Text="View " BackColor="ForestGreen" BorderColor="DarkSeaGreen"
											ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BtnPrint" Width="70px" Text="Print" Runat="server" BackColor="ForestGreen" BorderColor="DarkSeaGreen"
											ForeColor="White"></asp:button>&nbsp;&nbsp;
										<asp:button id="btnExcel" Width="70px" ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen"
											Text="Excel" Runat="server"></asp:button></td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" height="150">
							<%
	
	
	if(IsPostBack)
	
	 {
			     if(Session["Btype"].ToString()=="Opening Balance") 
			     {
			
 
			      
			       %>
							<asp:datagrid id="grdLeg" runat="server" AutoGenerateColumns="False" Height="8px" CellSpacing="1"
								BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen" BorderStyle="None" BorderWidth="0px" CellPadding="1"
								ShowFooter="True" AllowSorting="True" OnSortCommand="SortCommand_Click">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C">
</SelectedItemStyle>

<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9">
</AlternatingItemStyle>

<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2">
</ItemStyle>

<HeaderStyle HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900">
</HeaderStyle>

<FooterStyle HorizontalAlign="Center" ForeColor="#F7F7F7" VerticalAlign="Middle" BackColor="#009900">
</FooterStyle>

<Columns>
<asp:TemplateColumn SortExpression="Cust_Name" HeaderText="Customer Name">
<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"cust_Name")%>
										
</ItemTemplate>

<FooterTemplate>
											<TABLE borderColor="00990" width="100%" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD vAlign="top" align="center" width="100%"><font color="#f7f7f7"><b>Total</b></font></TD>
												</TR>
											</TABLE>
										
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="City" HeaderText="Place">
<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"City")%>
										
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="Op_Balance" HeaderText="Opening Balance&lt;br&gt;Debit &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Credit">
<HeaderStyle HorizontalAlign="Center">
</HeaderStyle>

<ItemTemplate>
											<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD align="left" width="60"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((CheckDebit(DataBinder.Eval(Container.DataItem,"cust_id").ToString())).ToString())%></font></TD>
													<TD align="right" width="60"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((CheckCredit(DataBinder.Eval(Container.DataItem,"cust_id").ToString())).ToString())%></font></TD>
												</TR>
											</TABLE>
										
</ItemTemplate>

<FooterTemplate>
											<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD align="left" width="60"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["os1"].ToString())%></b></font></TD>
													<TD align="right" width="60"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["os2"].ToString())%></b></font></TD>
												</TR>
											</TABLE>
										
</FooterTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages">
</PagerStyle>
							</asp:datagrid>
							<%}
						
						  else if(Session["Btype"].ToString()=="Total Balance") 
						  
						 
			     {
			     
			     
			     
			     
			     
			     
			     %>
							<asp:datagrid id="Datagrid1" runat="server" AutoGenerateColumns="False" Height="8px" CellSpacing="1"
								BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen" BorderStyle="None" BorderWidth="0px" CellPadding="1"
								ShowFooter="True" AllowSorting="True" OnSortCommand="SortCommand_Click" OnItemDataBound="ItemTotalclosing">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C">
</SelectedItemStyle>

<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9">
</AlternatingItemStyle>

<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2">
</ItemStyle>

<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900">
</HeaderStyle>

<FooterStyle HorizontalAlign="Center" ForeColor="#F7F7F7" VerticalAlign="Middle" BackColor="#009900">
</FooterStyle>

<Columns>
<asp:TemplateColumn SortExpression="Cust_Name" HeaderText="Customer Name">
<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"cust_Name")%>
										
</ItemTemplate>

<FooterTemplate>
											<TABLE borderColor="00990" width="100%" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD vAlign="top" align="center" width="100%"><font color="#f7f7f7"><b>Total</b></font></TD>
												</TR>
											</TABLE>
										
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="City" HeaderText="Place">
<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"City")%>
										
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="Balance" HeaderText="Closing Balance">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<ItemTemplate>
											<%#CheckClosing(DataBinder.Eval(Container.DataItem,"balance").ToString(),DataBinder.Eval(Container.DataItem,"balancetype").ToString())%>
										
</ItemTemplate>

<FooterStyle Font-Bold="True" HorizontalAlign="Right">
</FooterStyle>
</asp:TemplateColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages">
</PagerStyle>
							</asp:datagrid>
							<%}
						
					     else if(Session["Btype"].ToString()=="Transaction") 
			     
			     
			     
			     {
			     
			     
			     
			     
			     %>
							<asp:datagrid id="Datagrid2" runat="server" AutoGenerateColumns="False" Height="8px" CellSpacing="1"
								BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen" BorderStyle="None" BorderWidth="0px" CellPadding="1"
								ShowFooter="True" AllowSorting="True" OnSortCommand="SortCommand_Click">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C">
</SelectedItemStyle>

<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9">
</AlternatingItemStyle>

<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2">
</ItemStyle>

<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900">
</HeaderStyle>

<FooterStyle HorizontalAlign="Center" ForeColor="#F7F7F7" VerticalAlign="Middle" BackColor="#009900">
</FooterStyle>

<Columns>
<asp:TemplateColumn SortExpression="Cust_Name" HeaderText="Customer Name">
<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"cust_Name")%>
										
</ItemTemplate>

<FooterTemplate>
											<TABLE borderColor="00990" width="100%" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD vAlign="top" align="center" width="100%"><font color="#f7f7f7"><b>Total</b></font></TD>
												</TR>
											</TABLE>
										
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="City" HeaderText="Place">
<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"City")%>
										
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="DebitAmount" HeaderText="Transaction&lt;br&gt;Debit &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Credit">
<HeaderStyle HorizontalAlign="Center">
</HeaderStyle>

<ItemTemplate>
											<table align="center" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td align="left" width="60"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((Limit2(DataBinder.Eval(Container.DataItem,"debitamount").ToString())).ToString())%></font></td>
													<td align="right" width="60"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((Limit2(DataBinder.Eval(Container.DataItem,"CreditAmount").ToString())).ToString())%></font></td>
												</tr>
											</table>
										
</ItemTemplate>

<FooterTemplate>
											<table align="center" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td align="left" width="60"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["tr1"].ToString())%></b></font></td>
													<td align="right" width="60"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["tr2"].ToString())%></b></font></td>
												</tr>
											</table>
										
</FooterTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages">
</PagerStyle>
							</asp:datagrid>
							<%}
						 else if(Session["Btype"].ToString()=="All")
			     
			     
			     
			     
			     {
			    ;
			     
			     
			     
			     %>
							<asp:datagrid id="Datagrid3" runat="server" AutoGenerateColumns="False" CellSpacing="1" PageSize="5"
								BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen" BorderStyle="None" BorderWidth="0px" CellPadding="1"
								ShowFooter="True" OnSortCommand="SortCommand_Click" AllowSorting="True" OnItemDataBound="ItemTotal1">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C">
</SelectedItemStyle>

<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9">
</AlternatingItemStyle>

<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2">
</ItemStyle>

<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7" BackColor="#009900">
</HeaderStyle>

<FooterStyle HorizontalAlign="Center" ForeColor="#F7F7F7" VerticalAlign="Middle" BackColor="#009900">
</FooterStyle>

<Columns>
<asp:TemplateColumn SortExpression="Cust_Name" HeaderText="Customer Name">
<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"cust_Name")%>
										
</ItemTemplate>

<FooterTemplate>
											<TABLE borderColor="00990" width="100%" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD vAlign="top" align="center" width="100%"><font color="#f7f7f7"><b>Total</b></font></TD>
												</TR>
											</TABLE>
										
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="City" HeaderText="Place">
<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"City")%>
										
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="Op_Balance" HeaderText="Opening Balance&lt;br&gt;Debit &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Credit">
<HeaderStyle HorizontalAlign="Center">
</HeaderStyle>

<ItemTemplate>
											<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD align="left" width="60"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((CheckDebit(DataBinder.Eval(Container.DataItem,"cust_id").ToString())).ToString())%></font></TD>
													<TD align="right" width="60"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((CheckCredit(DataBinder.Eval(Container.DataItem,"cust_id").ToString())).ToString())%></font></TD>
												</TR>
											</TABLE>
										
</ItemTemplate>

<FooterTemplate>
											<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD align="left" width="60"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["os1"].ToString())%></b></font></TD>
													<TD align="right" width="60"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["os2"].ToString())%></b></font></TD>
												</TR>
											</TABLE>
										
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="DebitAmount" HeaderText="Transaction&lt;br&gt;Debit &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Credit">
<HeaderStyle HorizontalAlign="Center">
</HeaderStyle>

<ItemTemplate>
											<table align="center" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td align="left" width="60"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((Limit(DataBinder.Eval(Container.DataItem,"debitamount").ToString())).ToString())%></font></td>
													<td align="right" width="60"><font color="#4a3c8c"><%#GenUtil.strNumericFormat((Limit(DataBinder.Eval(Container.DataItem,"CreditAmount").ToString())).ToString())%></font></td>
												</tr>
											</table>
										
</ItemTemplate>

<FooterTemplate>
											<table align="center" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td align="left" width="60"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["os"].ToString())%></b></font></td>
													<td align="right" width="60"><font color="#f7f7f7"><b><%=GenUtil.strNumericFormat(Cache["tr"].ToString())%></b></font></td>
												</tr>
											</table>
										
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn SortExpression="Balance" HeaderText="Closing Balance">
<ItemStyle HorizontalAlign="Right">
</ItemStyle>

<ItemTemplate>
											<font color="#4a3c8c">
												<%#GenUtil.strNumericFormat((Limit(DataBinder.Eval(Container.DataItem,"balance").ToString())).ToString())%>
											</font><font color="#4a3c8c">
												<%#DataBinder.Eval(Container.DataItem,"balancetype")%>
											</font>
										
</ItemTemplate>

<FooterStyle Font-Bold="True" HorizontalAlign="Right">
</FooterStyle>
</asp:TemplateColumn>
</Columns>

<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages">
</PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD align="right"><A href="javascript:window.print()"></A></TD>
					</TR>
				</TBODY>
			</table>
			<%}
		
					
			
			}%>
			</TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
