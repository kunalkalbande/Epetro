<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="CustomerDataMining.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Parties.CustomerDataMining" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Customer Data Mining</title> <!--
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
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox>
			<table style="WIDTH: 778px" height="288" align="center">
				<TBODY>
					<TR>
						<TH style="COLOR: #003366">
							<font color="#006400">Customer Data Mining</font>&nbsp;&nbsp;
							<hr>
						</TH>
					</TR>
					<TR>
						<TD align="center">
							<TABLE>
								<TR>
									<TD><asp:button id="btnview" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
											BorderColor="ForestGreen" Text="View"></asp:button></TD>
									<TD><asp:button id="btnPrint" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
											BorderColor="ForestGreen" Text="Print"></asp:button></TD>
									<TD><asp:button id="btnExcel" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
											BorderColor="ForestGreen" Text="Excel"></asp:button></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD align="center" height="160"><asp:datagrid id="CustomerGrid" runat="server" BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen"
								OnSortCommand="SortCommand_Click" AllowSorting="True" CellPadding="1" BorderStyle="None" BorderWidth="0px" Font-Size="10pt"
								Font-Names="Verdana" CellSpacing="1" AutoGenerateColumns="False" HorizontalAlign="Center">
								<SelectedItemStyle Font-Size="2pt" Font-Bold="True" ForeColor="White" CssClass="DataGridItem" BackColor="#738A9C"></SelectedItemStyle>
								<EditItemStyle></EditItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle Font-Size="10pt" ForeColor="#4A3C8C" CssClass="DataGridItem" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Size="2px" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Customer Name" SortExpression="Cust_Name">
										<HeaderStyle ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Cust_name")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Type" SortExpression="Cust_Type">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Cust_Type")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Address" SortExpression="Address">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Address")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="City" SortExpression="City">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"City")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="State" SortExpression="State">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"State")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Country" SortExpression="Country">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Country")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Contact Number">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<HeaderTemplate>
											<TABLE width="100%" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD align="center" colSpan="3" width="100%"><font color="White">Contact Number</font>
													</TD>
												</TR>
												<TR>
													<TD align="left" width="60"><font color="White">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Office</font></TD>
													<TD align="left" width="60"><font color="White">&nbsp;&nbsp;&nbsp;&nbsp;Residence</font></TD>
													<TD align="left" width="60"><font color="White">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mobile</font></TD>
												</TR>
											</TABLE>
										</HeaderTemplate>
										<ItemTemplate>
											<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD align="left" width="60"><font color="#000066"><%#DataBinder.Eval(Container.DataItem,"Tel_Off").ToString()%></font></TD>
													<TD align="left" width="60"><font color="#000066"><%#DataBinder.Eval(Container.DataItem,"Tel_Res").ToString()%></font></TD>
													<TD align="Right" width="60"><font color="#000066"><%#DataBinder.Eval(Container.DataItem,"Mobile").ToString()%></font></TD>
												</TR>
											</TABLE>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="EMail" SortExpression="Email">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Email")%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<td align="left"><FONT color="#ff0033"><STRONG><U>Note</U>:</STRONG>&nbsp;</FONT><FONT color="black">
								To take a printout press the above Print button, to redirect the output to a 
								new page. Use the Page Setup option in the File menu to set the appropriate
								<br>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; margins, 
								then use the Print option in the file menu to send the output to the printer. </FONT>
						</td>
					</TR>
				</TBODY>
			</table>
			</TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
