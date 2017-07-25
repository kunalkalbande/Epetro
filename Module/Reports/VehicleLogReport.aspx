<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="VehicleLogReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.VehicleLogReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Vehicle Log Book Report</title><!--
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
		function checkValidity()
		{
		var index = document.Form1.Dropvehicleno.selectedIndex; 
		var ErrMessage = "";
		var flag = 0;
		if(index == 0)
		{
		   ErrMessage = "_Please Select Vehicle No.\n";
		   flag = 1;
		}
		if(document.Form1.txtDateFrom.value == "")
		 {
		 ErrMessage = ErrMessage + "_Please Enter Form Date\n";
		 flag = 1;
		 }
		 if(document.Form1.txtDateTo.value == "")
		 {
		 ErrMessage = ErrMessage + "_Please Enter To Date\n";
		 flag = 1;
		 }
		 if(document.Form1.txtDateFrom.value != "" && document.Form1.txtDateTo.value != "")
		 {
		    if(document.Form1.txtDateTo.value < document.Form1.txtDateFrom.value)
		    {
		        ErrMessage = ErrMessage + "_Date To must be greater than Date From";
		        flag = 1;
		        }		          
		 }
		 
		 if(flag == 1)
		 {
		   alert(ErrMessage);		 
		   return false;
		   }
		   else
		   {
		   return true;
		   }
		
		
		}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox>
			<table height="288" width="778" align="center">
				<TBODY>
					<TR valign=top height=20>
						<TH>
							<FONT face="Verdana" color="#006400">Vehicle Report</FONT> &nbsp;
							<hr>
						</TH>
					</TR>
					<TR>
						<TD vAlign="top" align="center" height=30>
							<TABLE>
								<TR>
									<td vAlign="top">Select Option&nbsp;<asp:comparevalidator id="cv1" Runat="server" ErrorMessage="Please Select The Option" Operator="NotEqual"
											ControlToValidate="DropOption" ValueToCompare="Select">*</asp:comparevalidator>&nbsp;&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="DropOption" Width="170" AutoPostBack="True" Runat="server" CssClass="FontStyle">
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="Fright Report">Fright Report</asp:ListItem>
											<asp:ListItem Value="Vehicle Log Book Report">Vehicle Log Book Report</asp:ListItem>
										</asp:dropdownlist></td>
									<TD>From Date&nbsp; &nbsp;&nbsp;&nbsp;<asp:textbox id="txtDateFrom" runat="server" Width="85px" ReadOnly="True" BorderStyle="Groove"
											CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
									<TD>To Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtDateTo" runat="server" Width="85px" ReadOnly="True" BorderStyle="Groove"
											CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</TR>
								<tr>
									<td><asp:panel id="PenOption" Runat="server">Vehicle No.&nbsp; 
<asp:comparevalidator id=Comparevalidator1 ValueToCompare="Select" ControlToValidate="Dropvehicleno" Operator="NotEqual" ErrorMessage="Please Select The Vehicle No" Runat="server">*</asp:comparevalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:dropdownlist id=Dropvehicleno runat="server" Width="170px" CssClass="FontStyle">
												<asp:ListItem Value="Select">Select</asp:ListItem>
											</asp:dropdownlist></asp:panel></td>
									<td align="right" colSpan="2"><asp:button id="btnView" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
											BorderColor="DarkSeaGreen" Text="View"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnPrint" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
											BorderColor="DarkSeaGreen" Text="Print"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnExcel" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
											BorderColor="DarkSeaGreen" Text="Excel"></asp:button></td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" valign=top>
							<asp:datagrid id="grdLog" runat="server" BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen" OnSortCommand="SortCommand_Click"
								CellPadding="1" BorderStyle="None" AllowSorting="True" BorderWidth="0px" Font-Size="10pt"
								Font-Names="Verdana" CellSpacing="1" Height="4px" AutoGenerateColumns="False" HorizontalAlign="Center">
								<SelectedItemStyle Font-Size="2pt" Font-Bold="True" Height="4px" ForeColor="White" CssClass="DataGridItem"
									BackColor="#738A9C"></SelectedItemStyle>
								<EditItemStyle Height="4px"></EditItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle Font-Size="10pt" ForeColor="#4A3C8C" CssClass="DataGridItem" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Size="2px" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									Height="4px" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Fuel Inward" SortExpression="Fuel_Used_Qty">
										<HeaderStyle ForeColor="White"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Fuel_Used_Qty")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Vehicle Route" SortExpression="Vehicle_Route">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#getRoute(DataBinder.Eval(Container.DataItem,"Vehicle_Route").ToString())%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Engine Oil Used" SortExpression="Engine_Oil_Qty">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Engine_Oil_Qty")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Gear Oil Used" SortExpression="Gear_Oil_Qty">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Gear_Oil_Qty")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Grease Used" SortExpression="Grease_Qty">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Grease_Qty")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Brake Oil Used" SortExpression="Brake_Oil_Qty">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Brake_Oil_Qty")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Coolent Used" SortExpression="Coolent_Qty">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Coolent_Qty")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Trans. Oil Used" SortExpression="Trans_Oil_Qty">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Trans_Oil_Qty")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Expenses (In Rs.)">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<HeaderTemplate>
											<TABLE width="100%" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD align="center" colSpan="4" width="100%"><font color="White">Expenses (In Rs.)</font>
													</TD>
												</TR>
												<TR>
													<TD align="left" width="60"><font color="White">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Toll</font></TD>
													<TD align="left" width="60"><font color="White">&nbsp;&nbsp;&nbsp;&nbsp;Police</font></TD>
													<TD align="left" width="60"><font color="White">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Food</font></TD>
													<TD align="left" width="60"><font color="White">&nbsp;&nbsp;&nbsp;&nbsp;Misc.</font></TD>
												</TR>
											</TABLE>
										</HeaderTemplate>
										<ItemTemplate>
											<TABLE border="0" align="center" cellpadding="0" cellspacing="0">
												<TR>
													<TD align="Right" width="60"><font color="#4a3c8c"><%#DataBinder.Eval(Container.DataItem,"Toll").ToString()%></font></TD>
													<TD align="Right" width="60"><font color="#4a3c8c"><%#DataBinder.Eval(Container.DataItem,"Police").ToString()%></font></TD>
													<TD align="Right" width="60"><font color="#4a3c8c"><%#DataBinder.Eval(Container.DataItem,"Food").ToString()%></font></TD>
													<TD align="Right" width="60"><font color="#4a3c8c"><%#DataBinder.Eval(Container.DataItem,"Misc").ToString()%></font></TD>
												</TR>
											</TABLE>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Opening Meter Reading" SortExpression="Meter_Reading_Pre">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Meter_Reading_Pre")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Closing Meter Reading" SortExpression="Meter_Reading_Cur">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"Meter_Reading_Cur")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="KM. Move" SortExpression="KM">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#DataBinder.Eval(Container.DataItem,"KM")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Mileage" SortExpression="Mileage">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
										<ItemTemplate>
											<%#GenUtil.strNumericFormat(DataBinder.Eval(Container.DataItem,"Mileage").ToString())%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:datagrid id="grdFright" runat="server" BackColor="DarkSeaGreen" BorderColor="DarkSeaGreen"
								OnSortCommand="SortCommand_Click" CellPadding="1" BorderStyle="None" AllowSorting="True" BorderWidth="0px"
								Font-Size="10pt" Font-Names="Verdana" CellSpacing="1" Height="4px" AutoGenerateColumns="False" HorizontalAlign="Center">
								<SelectedItemStyle Font-Size="2pt" Font-Bold="True" Height="4px" ForeColor="White" CssClass="DataGridItem"
									BackColor="#738A9C"></SelectedItemStyle>
								<EditItemStyle Height="4px"></EditItemStyle>
								<AlternatingItemStyle ForeColor="#4A3C8C" BackColor="#EEFFE9"></AlternatingItemStyle>
								<ItemStyle Font-Size="10pt" ForeColor="#4A3C8C" CssClass="DataGridItem" BackColor="#EEFFD2"></ItemStyle>
								<HeaderStyle Font-Size="2px" Font-Names="Verdana" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									Height="4px" ForeColor="#F7F7F7" BackColor="#009900"></HeaderStyle>
								<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Fuel_Used_Qty" SortExpression="Fuel_Used_Qty" HeaderText="Fuel Inward"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="Vehicle_Route" HeaderText="Vehicle Route">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#getRoute(DataBinder.Eval(Container.DataItem,"Vehicle_Route").ToString())%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="BiltyNo" SortExpression="BiltyNo" HeaderText="Bilty No"></asp:BoundColumn>
									<asp:BoundColumn DataField="BiltyDate" SortExpression="BiltyDate" HeaderText="Bilty Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
									<asp:BoundColumn DataField="Fright" SortExpression="Fright" HeaderText="Fright"></asp:BoundColumn>
									<asp:BoundColumn DataField="Consignee" SortExpression="Consignee" HeaderText="Consignee Name"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="Acknowledgement" HeaderText="Acknowledgement">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<%#getAcknow(DataBinder.Eval(Container.DataItem,"Acknowledgement").ToString())%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Meter_Reading_Pre" SortExpression="Meter_Reading_Pre" HeaderText="Opening Meter Reading"></asp:BoundColumn>
									<asp:BoundColumn DataField="Meter_Reading_Cur" SortExpression="Meter_Reading_Cur" HeaderText="Closing Meter Reading"></asp:BoundColumn>
									<asp:BoundColumn DataField="KM" SortExpression="KM" HeaderText="KM. Move"></asp:BoundColumn>
									<asp:BoundColumn DataField="Mileage" SortExpression="Mileage" HeaderText="Mileage" DataFormatString="{0:N2}"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD align="right"><asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary><A href="javascript:window.print()"></A></TD>
					</TR>
				</TBODY>
			</table></TD></TR></TBODY></TABLE><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form></FORM>
	</body>
</HTML>
