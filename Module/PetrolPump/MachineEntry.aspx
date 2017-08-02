<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="MachineEntry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.PetrolPump.MachineEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Machine Entry</title> <!--
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
		
		function  check(t)
		{
		//alert("hello")
		var index = t.selectedIndex;
		var value = t.options[index].value;
		//alert(index)
		if(value == "Other")
		{
		//alert("if")
		document.Form1.txtMachineName.disabled = false;
		return false;
		}
		else
		{
		//alert("else")
		document.Form1.txtMachineName.disabled = true;
		document.Form1.txtMachineName.value = "";
		
		return false;
		}
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header><table width="778" height="288" align="center">
				<TR valign="top">
					<TH align="center" style="HEIGHT: 69px">
						<font color="#006400">Machine&nbsp;Entry</font><hr>
					</TH>
				</TR>
				<tr valign="top">
					<td align="center">
						<TABLE style="WIDTH: 500px; HEIGHT: 144px">
							<TR>
								<TD colSpan="2"><FONT color="#ff0000">Fields Marked as (*) Are Mandatory</FONT></TD>
								<TD style="WIDTH: 93px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Machine ID&nbsp;
									<asp:RequiredFieldValidator ID="rfv1" Runat="server"  ControlToValidate="DropMachineID"
										InitialValue="Select"></asp:RequiredFieldValidator></TD>
								<TD><asp:label id="lblMachineID" runat="server" ForeColor="Purple" Width="80px"></asp:label><asp:DropDownList ID="dropMachineID" Runat="server" Width="150px" AutoPostBack="True">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:DropDownList><asp:button id="btnEdit" runat="server" Width="24px" ForeColor="White" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="..." CausesValidation="False" ToolTip="To Edit The particulars Record"></asp:button></TD>
								<TD style="WIDTH: 93px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Machine Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:label id="lblMachineName" runat="server" ForeColor="Purple" Width="112px"></asp:label></TD>
								<TD style="WIDTH: 93px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Machine Type <font color="red">*</font> </TD>
								<TD colspan="3"><asp:dropdownlist id="DropMachineType" runat="server" Width="300px" onChange="check(this);" CssClass="FontStyle">
										<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
										<asp:ListItem Value="Avery">Avery</asp:ListItem>
										<asp:ListItem Value="Eplob">Aplob</asp:ListItem>
										<asp:ListItem Value="L&amp;T">L&amp;T</asp:ListItem>
										<asp:ListItem Value="Midco">Midco</asp:ListItem>
										<asp:ListItem Value="Tatsuno">Tatsuno</asp:ListItem>
										<asp:ListItem Value="Tokhiam">Tokheim</asp:ListItem>
									</asp:dropdownlist>
									<asp:CompareValidator id="CompareValidator2" runat="server" ErrorMessage="Please Select The Machine Type"
										ControlToValidate="DropMachineType" ValueToCompare="Select" Operator="NotEqual"><font color="red">*</font></asp:CompareValidator></TD>
							</TR>
							<tr>
								<TD style="WIDTH: 100px; HEIGHT: 18px"><FONT color="#0000ff">(if another, Specify)</FONT></TD>
								<TD style="HEIGHT: 18px" colspan="3">
									<asp:TextBox id="txtMachineName" runat="server" Enabled="False" BorderStyle="Groove" Width="300"
										CssClass="FontStyle" MaxLength="49"></asp:TextBox></TD>
							</tr>
							<TR>
								<TD align="right" colSpan="2"><asp:button id="btnSave" runat="server" Width="70px" Text="Save" ForeColor="White" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnDelete" runat="server" Width="65px" ForeColor="White" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Delete"></asp:button></TD>
								<TD style="WIDTH: 93px" align="right"></TD>
								<TD align="right"></TD>
							</TR>
						</TABLE>
						<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
