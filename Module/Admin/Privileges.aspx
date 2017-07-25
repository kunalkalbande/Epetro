<%@ Page language="c#" Codebehind="Privileges.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Admin.Privileges" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Privileges</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<script language="javascript">
	function ClearAll()
	{
		var f=document.Form1
		for(var i=0;i<f.length;i++)
			f.elements[i].checked=false
	}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center">
				<TBODY>
					<TR valign=top>
						<TH align="center">
							<font color="#006400">Privileges</font><hr>
						</TH>
					</TR>
					<tr>
						<td align="center">
							<TABLE border="1">
								<TR>
									<TD align="center">User ID <FONT color="red">*</FONT> &nbsp;&nbsp;
										<asp:dropdownlist id="DropUserID" runat="server" Width="150px" AutoPostBack="True" CssClass="FontStyle">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist><asp:textbox id="txtUserName" runat="server" Enabled="False" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD colSpan="6"><asp:checkbox id="chkAccount" runat="server" AutoPostBack="True" ForeColor="Green" Text="Account Module"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="6"><asp:panel id="PanelAcc" runat="server" Width="490" Visible="False">
                  <TABLE id=Table1 cellSpacing=0 cellPadding=0 width=500 
                  border=0>
                    <TR>
                      <TD></TD>
                      <TD></TD>
                      <TD 
                      align=center><STRONG><STRONG>View</STRONG></STRONG></TD>
                      <TD 
                        align=center><STRONG><STRONG>&nbsp;Add</STRONG></STRONG></TD>
                      <TD align=center><STRONG>Edit</STRONG></TD>
                      <TD align=center><STRONG>&nbsp;Del</STRONG></TD></TR>
                    <TR>
                      <TD align=center width=35>1.</TD>
                      <TD>Ledger 
                        Creation&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                      <TD align=center>
<asp:checkbox id=chkView1 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd1 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit1 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel1 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>2.</TD>
                      <TD>Receipt</TD>
                      <TD align=center>
<asp:checkbox id=chkView2 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd2 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit2 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel2 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>3.</TD>
                      <TD>Payment</TD>
                      <TD align=center>
<asp:checkbox id=chkView3 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd3 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit3 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel3 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>4.</TD>
                      <TD>Voucher Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView4 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd4 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit4 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel4 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>5.</TD>
                      <TD>Bank Reconcillation</TD>
                      <TD align=center>
<asp:checkbox id=chkView61 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd61 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit61 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel61 runat="server"></asp:checkbox></TD></TR></TABLE>
													</asp:panel></TD>
											</TR>
											<TR>
												<TD colSpan="6"><asp:checkbox id="chkEmployee" runat="server" AutoPostBack="True" ForeColor="Green" Text="Employee Module"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="6"><asp:panel id="PanelEmp" runat="server" Width="490" Visible="False" Height="177px">
                  <TABLE style="WIDTH: 500px" cellSpacing=0 cellPadding=0>
                    <TR>
                      <TD></TD>
                      <TD><STRONG></STRONG></TD>
                      <TD align=center colSpan=1 
                        rowSpan=1><STRONG>View</STRONG></TD>
                      <TD align=center><STRONG>Add</STRONG></TD>
                      <TD align=center><STRONG>Edit</STRONG></TD>
                      <TD align=center><STRONG>Del</STRONG></TD></TR>
                    <TR>
                      <TD align=center width=35>1.</TD>
                      <TD>Shift Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView5 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd5 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit5 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel5 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>2.</TD>
                      <TD>Employee Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView6 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd6 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit6 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel6 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>3.</TD>
                      <TD>Attandance 
                        Register&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                      </TD>
                      <TD align=center>
<asp:checkbox id=chkView7 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd7 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit7 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel7 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>4.</TD>
                      <TD>Overtime Register</TD>
                      <TD align=center>
<asp:checkbox id=chkView8 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd8 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit8 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel8 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>5.</TD>
                      <TD>Shift Assignment</TD>
                      <TD align=center>
<asp:checkbox id=chkView9 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd9 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit9 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel9 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>6.</TD>
                      <TD>Leave Application</TD>
                      <TD align=center>
<asp:checkbox id=chkView10 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd10 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit10 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel10 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>7.</TD>
                      <TD>Leave Sanction</TD>
                      <TD align=center>
<asp:checkbox id=chkView11 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd11 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit11 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel11 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>8.</TD>
                      <TD>Salary Statement</TD>
                      <TD align=center>
<asp:checkbox id=chkView12 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd12 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit12 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel12 runat="server"></asp:checkbox></TD></TR></TABLE>
													</asp:panel></TD>
											</TR>
											<TR>
												<TD colSpan="6"><asp:checkbox id="chkParties" runat="server" AutoPostBack="True" ForeColor="Green" Text="Parties Module"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="6"><asp:panel id="PanelParties" runat="server" Width="490" Visible="False" DESIGNTIMEDRAGDROP="1043">
                  <TABLE id=Table2 style="WIDTH: 500px" cellSpacing=0 
                  cellPadding=0>
                    <TR>
                      <TD></TD>
                      <TD><STRONG></STRONG></TD>
                      <TD align=center><STRONG>View</STRONG></TD>
                      <TD align=center><STRONG>Add</STRONG></TD>
                      <TD align=center><STRONG>Edit</STRONG></TD>
                      <TD align=center><STRONG>Del</STRONG></TD></TR>
                    <TR>
                      <TD align=center width=35>1.</TD>
                      <TD>Beat Master</TD>
                      <TD align=center>
<asp:checkbox id=chkView13 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd13 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit13 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel13 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>2.</TD>
                      <TD>Customer Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView14 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd14 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit14 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel14 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>3.</TD>
                      <TD>Vendor 
                        Entry&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                      <TD align=center>
<asp:checkbox id=chkView15 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd15 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit15 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel15 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>4.</TD>
                      <TD>Slip Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView16 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd16 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit16 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel16 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>5.</TD>
                      <TD>Customer Vehicle 
                        Entry&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
</TD>
                      <TD align=center>
<asp:checkbox id=chkView17 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd17 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit17 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel17 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>6.</TD>
                      <TD>Tax Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView18 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd18 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit18 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel18 runat="server"></asp:checkbox></TD></TR></TABLE>
													</asp:panel></TD>
											</TR>
											<TR>
												<TD colSpan="6"><asp:checkbox id="chkInventory" runat="server" AutoPostBack="True" ForeColor="Green" Text="Purchase / Sales/ Inventory Module"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="6"><asp:panel id="PanelInventory" runat="server" Width="490" Visible="False" DESIGNTIMEDRAGDROP="1043">
                  <TABLE id=Table3 style="WIDTH: 500px" cellSpacing=0 
                  cellPadding=0>
                    <TR>
                      <TD></TD>
                      <TD><STRONG></STRONG></TD>
                      <TD align=center><STRONG>View</STRONG></TD>
                      <TD align=center><STRONG>Add</STRONG></TD>
                      <TD align=center><STRONG>Edit</STRONG></TD>
                      <TD align=center><STRONG>Del</STRONG></TD></TR>
                    <TR>
                      <TD align=center width=35>1.</TD>
                      <TD>Product Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView19 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd19 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit19 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel19 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>2.</TD>
                      <TD>Price Updation</TD>
                      <TD align=center>
<asp:checkbox id=chkView20 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd20 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit20 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel20 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>3.</TD>
                      <TD>Purchase 
                        Invoice&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                      </TD>
                      <TD align=center>
<asp:checkbox id=chkView21 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd21 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit21 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel21 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>4.</TD>
                      <TD>Sales Invoice</TD>
                      <TD align=center>
<asp:checkbox id=chkView22 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd22 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit22 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel22 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>5.</TD>
                      <TD>Credit Bills</TD>
                      <TD align=center>
<asp:checkbox id=chkView23 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd23 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit23 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel23 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>6.</TD>
                      <TD>Sales Return</TD>
                      <TD align=center>
<asp:checkbox id=chkView24 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd24 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit24 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel24 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>7.</TD>
                      <TD>Purchase Return</TD>
                      <TD align=center>
<asp:checkbox id=chkView25 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd25 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit25 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel25 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>8.</TD>
                      <TD>Stock Adjustment </TD>
                      <TD align=center>
<asp:checkbox id=chkView26 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd26 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit26 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel26 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>9.</TD>
                      <TD>Cash Billing </TD>
                      <TD align=center>
<asp:checkbox id=chkView64 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd64 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit64 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel64 runat="server"></asp:checkbox></TD></TR></TABLE>
													</asp:panel></TD>
											</TR>
											<TR>
												<TD colSpan="6"><asp:checkbox id="chkPetrolPump" runat="server" AutoPostBack="True" ForeColor="Green" Text="Petrol pump Module"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="6"><asp:panel id="PanelPetrolpump" runat="server" Width="490" Visible="False">
                  <P>
                  <TABLE id=Table4 style="WIDTH: 500px" cellSpacing=0 
                  cellPadding=0>
                    <TR>
                      <TD></TD>
                      <TD><STRONG></STRONG></TD>
                      <TD align=center><STRONG>View</STRONG></TD>
                      <TD align=center><STRONG>Add</STRONG></TD>
                      <TD align=center><STRONG>Edit</STRONG></TD>
                      <TD align=center><STRONG>Del</STRONG></TD></TR>
                    <TR>
                      <TD align=center width=35>1. </TD>
                      <TD>Tank Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView27 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd27 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit27 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel27 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>2.</TD>
                      <TD>Machine Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView28 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd28 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit28 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel28 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>3.</TD>
                      <TD>Nozzle 
                        Entry&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                      <TD align=center>
<asp:checkbox id=chkView29 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd29 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit29 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel29 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>4.</TD>
                      <TD>Daily Entries</TD>
                      <TD align=center>
<asp:checkbox id=chkView30 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd30 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit30 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel30 runat="server"></asp:checkbox></TD></TR></TABLE></P>
													</asp:panel></TD>
											</TR>
											<TR>
												<TD colSpan="6"><asp:checkbox id="chkAdmin" runat="server" AutoPostBack="True" ForeColor="Green" Text="Admin Module"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="6"><asp:panel id="PanelAdmin" runat="server" Width="490" Visible="False">
                  <P>
                  <TABLE id=Table5 style="WIDTH: 500px" cellSpacing=0 
                  cellPadding=0>
                    <TR>
                      <TD></TD>
                      <TD><STRONG></STRONG></TD>
                      <TD align=center><STRONG>View</STRONG></TD>
                      <TD align=center><STRONG>Add</STRONG></TD>
                      <TD align=center><STRONG>Edit</STRONG></TD>
                      <TD align=center><STRONG>Del</STRONG></TD></TR>
                    <TR>
                      <TD align=center width=35>1.</TD>
                      <TD>Customer Data&nbsp;Mining</TD>
                      <TD align=center>
<asp:checkbox id=chkView31 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd31 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit31 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel31 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>2.</TD>
                      <TD>Tank Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView32 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd32 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit32 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel32 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>3.</TD>
                      <TD>Machine Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView33 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd33 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit33 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel33 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>4.</TD>
                      <TD>Nozzle Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView34 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd34 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit34 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel34 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>5.</TD>
                      <TD>Daily Meter Reading 
Report&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                      <TD align=center>
<asp:checkbox id=chkView35 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd35 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit35 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel35 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>6.</TD>
                      <TD>Daily Tank Dip Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView36 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd36 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit36 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel36 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>7.</TD>
                      <TD>Price List</TD>
                      <TD align=center>
<asp:checkbox id=chkView37 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd37 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit37 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel37 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>8.</TD>
                      <TD>Sales Book</TD>
                      <TD align=center>
<asp:checkbox id=chkView38 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd38 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit38 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel38 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>9.</TD>
                      <TD>Purchase Book</TD>
                      <TD align=center>
<asp:checkbox id=chkView39 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd39 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit39 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel39 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>10.</TD>
                      <TD>Daily Sales Record</TD>
                      <TD align=center>
<asp:checkbox id=chkView40 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd40 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit40 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel40 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>11.</TD>
                      <TD>Product Wise Sales</TD>
                      <TD align=center>
<asp:checkbox id=chkView41 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd41 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit41 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel41 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>12.</TD>
                      <TD>Stock Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView42 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd42 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit42 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel42 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>13.</TD>
                      <TD>Stock Movement</TD>
                      <TD align=center>
<asp:checkbox id=chkView43 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd43 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit43 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel43 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>14.</TD>
                      <TD>Density Register</TD>
                      <TD align=center>
<asp:checkbox id=chkView44 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd44 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit44 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel44 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>15.</TD>
                      <TD>Daily Sales Register</TD>
                      <TD align=center>
<asp:checkbox id=chkView45 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd45 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit45 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel45 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>16.</TD>
                      <TD>Govt. Stock register</TD>
                      <TD align=center>
<asp:checkbox id=chkView46 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd46 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit46 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel46 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>17.</TD>
                      <TD>Customer Ledger Summary</TD>
                      <TD align=center>
<asp:checkbox id=chkView47 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd47 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit47 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel47 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>18.</TD>
                      <TD>Customer Bill Ageing</TD>
                      <TD align=center>
<asp:checkbox id=chkView48 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd48 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit48 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel48 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>19.</TD>
                      <TD>Customer Wise Sales</TD>
                      <TD align=center>
<asp:checkbox id=chkView49 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd49 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit49 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel49 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>20.</TD>
                      <TD>Vehicle Log Book Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView50 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd50 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit50 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel50 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>21.</TD>
                      <TD>Stock Ledger Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView51 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd51 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit51 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel51 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>22.</TD>
                      <TD>VAT Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView52 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd52 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit52 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel52 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>23.</TD>
                      <TD>Trading Account</TD>
                      <TD align=center>
<asp:checkbox id=chkView53 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd53 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit53 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel53 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>24.</TD>
                      <TD>Balance Sheet</TD>
                      <TD align=center>
<asp:checkbox id=chkView54 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd54 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit54 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel54 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>25.</TD>
                      <TD>Ledger Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView55 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd55 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit55 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel55 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>26.</TD>
                      <TD>Tax Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView56 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd56 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit56 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel56 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>27.</TD>
                      <TD>ROI &amp; Analysis Report</TD>
                      <TD align=center>
<asp:checkbox id=chkView57 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd57 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit57 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel57 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>28.</TD>
                      <TD>Density Chart</TD>
                      <TD align=center>
<asp:checkbox id=chkView62 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd62 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit62 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel62 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>29.</TD>
                      <TD>Cash Billing Report </TD>
                      <TD align=center>
<asp:checkbox id=chkView63 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd63 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit63 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel63 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>30.</TD>
                      <TD>Leave Report </TD>
                      <TD align=center>
<asp:checkbox id=chkView65 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd65 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit65 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel65 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>31.</TD>
                      <TD>Monthly Selling Report </TD>
                      <TD align=center>
<asp:checkbox id=chkView66 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd66 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit66 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel66 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>32.</TD>
                      <TD>Daily Sales Cum A/C Sheet </TD>
                      <TD align=center>
<asp:checkbox id=chkView67 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd67 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit67 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel67 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>33.</TD>
                      <TD>Attendence Report </TD>
                      <TD align=center>
<asp:checkbox id=chkView68 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd68 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit68 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel68 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>34.</TD>
                      <TD>Credit/Fleet Card Report </TD>
                      <TD align=center>
<asp:checkbox id=chkView69 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd69 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit69 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel69 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>35.</TD>
                      <TD>Customer Vehicle Report </TD>
                      <TD align=center>
<asp:checkbox id=chkView70 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd70 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit70 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel70 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>36.</TD>
                      <TD>Day Book Report </TD>
                      <TD align=center>
<asp:checkbox id=chkView71 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd71 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit71 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel71 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>37.</TD>
                      <TD>Bank Reconcillation </TD>
                      <TD align=center>
<asp:checkbox id=chkView72 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd72 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit72 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel72 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>38.</TD>
                      <TD>Customer Wise Slip </TD>
                      <TD align=center>
<asp:checkbox id=chkView73 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd73 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit73 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel73 runat="server"></asp:checkbox></TD></TR></TABLE></P>
													</asp:panel></TD>
											</TR>
											<TR>
												<TD colSpan="6"><asp:checkbox id="checkLogistics" runat="server" AutoPostBack="True" ForeColor="Green" Text="Logistics Module"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="6"><asp:panel id="panelLogistics" runat="server" Width="490" Visible="False">
                  <P>
                  <TABLE id=Table9 style="WIDTH: 500px" cellSpacing=0 
                  cellPadding=0>
                    <TR>
                      <TD></TD>
                      <TD><STRONG></STRONG></TD>
                      <TD align=center><STRONG>View</STRONG></TD>
                      <TD align=center><STRONG>Add</STRONG></TD>
                      <TD align=center><STRONG>Edit</STRONG></TD>
                      <TD align=center><STRONG>Del</STRONG></TD></TR>
                    <TR>
                      <TD align=center width=35>1.</TD>
                      <TD>Route Master</TD>
                      <TD align=center>
<asp:checkbox id=chkView58 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd58 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit58 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel58 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>2.</TD>
                      <TD>Vehicle Entry</TD>
                      <TD align=center>
<asp:checkbox id=chkView59 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd59 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit59 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel59 runat="server"></asp:checkbox></TD></TR>
                    <TR>
                      <TD align=center width=35>3.</TD>
                      <TD>Vehicle Daily Log 
                        Book&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                      </TD>
                      <TD align=center>
<asp:checkbox id=chkView60 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkAdd60 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkEdit60 runat="server"></asp:checkbox></TD>
                      <TD align=center>
<asp:checkbox id=chkDel60 runat="server"></asp:checkbox></TD></TR></TABLE></P>
													</asp:panel></TD>
											</TR>
											<tr>
												<td>&nbsp;</td>
											</tr>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center"><asp:button id="btnAllocate" runat="server" ForeColor="White" Text="Allocate Privileges" BorderColor="DarkSeaGreen"
											BackColor="ForestGreen"></asp:button><asp:button id="btnSave" runat="server" Width="80px" ForeColor="White" Text="Save" BorderColor="DarkSeaGreen"
											BackColor="ForestGreen"></asp:button></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</TBODY>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
