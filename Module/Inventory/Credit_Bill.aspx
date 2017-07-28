<%@ Page language="c#" Codebehind="Credit_Bill.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.Credit_Bill" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ import namespace=EPetro.Sysitem.Classes %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Credit Bill</title> <!--
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
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 528px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Enabled="False" BorderStyle="None" ></asp:textbox><asp:textbox id="TextBox2" style="Z-INDEX: 103; LEFT: 152px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="False" Width="8px"></asp:textbox>
			<table height="288" width="764" align="center">
				<TBODY>
					<TR vAlign="top">
						<TD align="center" colSpan="3">
							<table border="0">
								<tr vAlign="top">
									<td vAlign="top"><asp:image id="imgSample" runat="server" Width="48px" Height="51px"></asp:image></td>
									<td vAlign="top" align="center"><asp:label id="txtname1" runat="server" Width="472px" Height="8px" Font-Size="X-Small" Font-Bold="True"
											ForeColor="DarkGreen"></asp:label><br>
										<asp:label id="txtdet1" runat="server" Width="472px" Font-Size="8pt" Font-Bold="True" ForeColor="DarkGreen"></asp:label><br>
										<asp:label id="txtadd1" runat="server" Width="472px" Font-Size="8pt" Font-Bold="True" ForeColor="DarkGreen"></asp:label><br>
										<asp:label id="txtci11" Width="224px" Font-Size="8pt" Font-Bold="True" ForeColor="DarkGreen"
											Runat="server"></asp:label><br>
										<!--<P>-->
										<!--	<table style="WIDTH: 487px; HEIGHT: 90px" border=0>
              <TBODY>
											<tr>
												<td style="HEIGHT: 8px"><asp:label id="txtname" runat="server" Width="472px" Font-Size="X-Small" Font-Bold="True" Height="8px"></asp:label></td>
											</tr>
											<TR>
												<td style="HEIGHT: 10pt"><asp:label id="txtdet" runat="server" Width="472px" Font-Size="10pt"></asp:label></td>
											</TR>
											<tr>
												<td style="HEIGHT: 9pt"><asp:label id="txtadd" runat="server" Width="472px" Font-Size="9pt"></asp:label></td>
											</tr>
											<tr>
												<td style="HEIGHT: 7pt"><asp:label id="txtci1" Width="224px" Font-Size="7pt" Runat="server"></asp:label></td>
											</tr>
											<!--<tr>
												<td height=10></td>
											</tr>
										</table>-->
										<!--</P>--></td></FONT></FONT></tr>
							</table>
							<!-- <P></P>-->
							<hr align="center">
						</TD>
					</TR>
					<TR vAlign="top" height="10">
						<TD align="right"></TD>
						<TD align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							Bill No:&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblBillNo" runat="server" ForeColor="Blue"></asp:label><asp:dropdownlist id="DropBillNo" Width="238px" Runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnEdit" Width="20" ForeColor="White" Runat="server" ToolTip="Edit The Record"
								BackColor="ForestGreen" BorderColor="DarkSeaGreen" CausesValidation="False" Text="..."></asp:button>
						</TD>
						<TD></TD>
					</TR>
					<TR vAlign="top" height="15">
						<TD></TD>
						<TD align="center">&nbsp;&nbsp;From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtDateFrom" runat="server" BorderStyle="Groove"  Width="80px"
								CssClass="FontStyle"></asp:textbox>&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
									border="0"></A>&nbsp;&nbsp;To&nbsp;&nbsp;
							<asp:textbox id="txtDateTO" runat="server" BorderStyle="Groove"  Width="80px"
								CssClass="FontStyle"></asp:textbox>&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateTO);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
									border="0"></A>&nbsp;&nbsp;Sales Type&nbsp;&nbsp;<asp:dropdownlist id="DropSalesType" runat="server" Width="130px" CssClass="FontStyle">
								<asp:ListItem Value="All">All</asp:ListItem>
								<asp:ListItem Value="Credit Card Sale">Credit Card Sale</asp:ListItem>
								<asp:ListItem Value="Fleet Card Sale">Fleet Card Sale</asp:ListItem>
								<asp:ListItem Value="General Credit">General Credit</asp:ListItem>
								<asp:ListItem Value="Slip Wise Credit">Slip Wise Credit</asp:ListItem>
							</asp:dropdownlist>&nbsp;&nbsp;Vehicle No.&nbsp;&nbsp;<asp:dropdownlist id="DropVehicleNo" runat="server" Width="130px" CssClass="FontStyle">
								<asp:ListItem Value="All">All</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD></TD>
					</TR>
					<TR vAlign="top" height="15">
						<TD align="center"></TD>
						<TD align="center">M/s <FONT color="#ff0000">*</FONT>&nbsp;<FONT color="red">&nbsp;&nbsp;&nbsp;</FONT>&nbsp;&nbsp;<asp:dropdownlist id="DropCustID" runat="server" Width="220px" AutoPostBack="True" CssClass="FontStyle">
								<asp:ListItem Value="Select">Select</asp:ListItem>
							</asp:dropdownlist>&nbsp;
							<asp:comparevalidator id="CompareValidator7" runat="server" ErrorMessage="Please Select Firm Name" ValueToCompare="Select"
								ControlToValidate="DropCustID" Operator="NotEqual">*</asp:comparevalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnView" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
								BorderColor="DarkSeaGreen" Text="View"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="printBtn" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
								BorderColor="DarkSeaGreen" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnPrint" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
								BorderColor="DarkSeaGreen" Text="Print"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnExcel" Width="70px" ForeColor="White" Runat="server" BackColor="ForestGreen"
								BorderColor="DarkSeaGreen" Text="Excel"></asp:button>
						</TD>
						<TD></TD>
					</TR>
					<tr vAlign="top" height="80">
						<td></td>
						<td align="center"><asp:datagrid id="GridCreditBill" runat="server" BorderStyle="None" Width="700px" BackColor="DarkSeaGreen"
								BorderColor="DarkSeaGreen" ShowFooter="True" CellPadding="1" BorderWidth="0px" AutoGenerateColumns="False"
								CellSpacing="1" AllowSorting="True" OnSortCommand="SortCommand_Click" OnItemDataBound="ItemTotal">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Size="Large" Font-Bold="True" HorizontalAlign="Center" ForeColor="#F7F7F7"
									BackColor="#009900"></HeaderStyle>
								<FooterStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#009900"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="invoice_date" SortExpression="invoice_date" HeaderText="Date" FooterText="Total" DataFormatString="{0:dd-MM-yyyy}">
										<HeaderStyle Font-Bold="True" Width="60px"></HeaderStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Center"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="slip_no" SortExpression="slip_no" HeaderText="Slip No / trans. No">
										<HeaderStyle Font-Bold="True" Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" HeaderText="Invoice No">
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="70px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="prod_Name" SortExpression="prod_Name" HeaderText="Particulars">
										<HeaderStyle Font-Bold="True" Width="200px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="qty" SortExpression="Qty" HeaderText="Qty">
										<HeaderStyle Font-Bold="True" Width="40px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Rate" SortExpression="Rate" HeaderText="Rate" DataFormatString="{0:N2}">
										<HeaderStyle Font-Bold="True" Width="50px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Amount" SortExpression="Amount" HeaderText="Amount" DataFormatString="{0:N2}">
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="60px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Bold="True" HorizontalAlign="Right"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="vehicle_no" SortExpression="vehicle_no" HeaderText="Vehicle No.">
										<HeaderStyle Font-Bold="True" Width="100px"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
						<td></td>
					</tr>
					<TR>
						<TD></TD>
						<TD align="left"><asp:validationsummary id="ValidationSummary1" runat="server" Height="7px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary>
							<p><FONT color="#ff0033"><STRONG><U>Note</U> :</STRONG></FONT> Only Vehicle numbers 
								entered through Customer Vehicle Entry are populated in the above dropdown.<br>
								&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vehicle number 
								entered manually through Sales Invoice are not populated.</p>
						</TD>
						<TD></TD>
					</TR>
				</TBODY>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form></TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
