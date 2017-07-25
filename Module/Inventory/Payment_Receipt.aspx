<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Payment_Receipt.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.Payment_Receipt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Receipt</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<script language="javascript">
function GetFinalDues()
{
	var f=document.Form1
	f.txtFinalDues.value=""
	f.txtCr.value=""
	f.Textbox2.value=""
	f.Textbox3.value=""
	//alert(f.txtTotalBalance.value);
		
	if(f.txtRecAmount.value!="" && f.txtTotalBalance.value !="")
	{
		var Disc = 0;
		if(f.txtDisc1.value != "")
			Disc+=eval(f.txtDisc1.value)
		if(f.txtDisc2.value != "")
			Disc+=eval(f.txtDisc2.value)
		if(eval(f.txtTotalBalance.value)<=eval(f.txtRecAmount.value)+Disc)
		{
			f.txtFinalDues.value=(eval(f.txtRecAmount.value)+Disc)-eval(f.txtTotalBalance.value)
			if(f.txtFinalDues.value.isNaN != true)
			{
				f.txtCr.value="Cr."
			}
			else
			{
			     f.txtFinalDues.value="";
			     f.txtCr.value="";
			}
		}
		else
		{
			f.txtFinalDues.value=eval(f.txtTotalBalance.value)-(eval(f.txtRecAmount.value)+Disc)
			if(f.txtFinalDues.value.isNaN != true)
			{
				f.txtCr.value="Dr."
			}
			else
			{
			     f.txtFinalDues.value="";
			     f.txtCr.value="";
			}
		}
	}
	makeRound(f.txtFinalDues);
	f.Textbox3.value=f.txtCr.value
	if(f.DropReceiptNo==null)
	{
		f.Textbox2.value=f.txtFinalDues.value
		f.Textbox1.value=eval(f.txtRecAmount.value)+Disc
		makeRound(f.Textbox1)
	}
	else
	{
		var str=(eval(f.txtRecAmount.value)+Disc) - <%=RecAmt%>
		var str1=f.txtTotalBalance.value - str
		f.txtFinalDues.value=str1
		makeRound(f.txtFinalDues);
		f.Textbox2.value=f.txtFinalDues.value
		f.Textbox1.value=str
		makeRound(f.Textbox1)
	}
}

function makeRound(t)
{
	var str = t.value;
	//alert(str);
	if(str != "")
	{
		str = eval(str)*100;
		str  = Math.round(str);
		str = eval(str)/100;
		t.value = str;
		//alert(str)
	}
}

function checkDelRec()
{
	if(document.Form1.DropReceiptNo != null)
	{
		if(document.Form1.DropReceiptNo.value!="Select")
		{
			if(confirm("Do You Want To Delete The Product"))
				document.Form1.tempReceiptInfo.value="Yes";
			else
				document.Form1.tempReceiptInfo.value="No";
		}
		else
		{
			alert("Please Select The Invoice No");
			return;
		}
	}
	else
	{
		alert("Please Click The Edit button");
		return;
	}
	if(document.Form1.tempReceiptInfo.value=="Yes")
		document.Form1.submit();
}

function chkSelect(t)
{
	if(t.value=="Select")
	{
		document.Form1.txtDisc1.disabled=true;
		document.Form1.txtDisc1.value="";
		GetFinalDues();
	}
	else
		document.Form1.txtDisc1.disabled=false;
}

function chkSelect1(t)
{
	if(t.value=="Select")
	{
		document.Form1.txtDisc2.disabled=true;
		document.Form1.txtDisc2.value="";
		GetFinalDues();
	}
	else
		document.Form1.txtDisc2.disabled=false;
}
		</script>
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox4" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox><input id="tempReceiptInfo" style="WIDTH: 1px" type="hidden" name="tempReceiptInfo" runat="server">
			<table height="288" width="778" align="center">
				<TR>
					<TH colSpan="3">
						&nbsp;<font color="#006400">Receipt</font>
						<HR>
						<asp:label id="lblMessage" runat="server" Width="300px" ForeColor="DarkGreen" Font-Bold="True"
							Font-Size="8pt"></asp:label></TH></TR>
				<asp:panel id="PanReceiptNo" Runat="server">
					<TR>
						<TD></TD>
						<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Receipt 
							No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:DropDownList id="DropReceiptNo" runat="server" Width="150" CssClass="FontStyle" AutoPostBack="True">
								<asp:ListItem Value="Select">Select</asp:ListItem>
							</asp:DropDownList>&nbsp;
							<asp:comparevalidator id="Comparevalidator2" runat="server" ValueToCompare="Select" Operator="NotEqual"
								ControlToValidate="DropReceiptNo" ErrorMessage="Please Select Receipt No">*</asp:comparevalidator></TD>
						<TD></TD>
					</TR>
				</asp:panel>
				<TR>
					<TD width="15%"></TD>
					<TD width="70%">Received with thanks from&nbsp;&nbsp;<STRONG>&nbsp; <FONT color="#ff0000">*</FONT>
							<asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="Please Select Party Name" ControlToValidate="DropCustName"
								Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator></STRONG>&nbsp;&nbsp;
						<asp:dropdownlist id="DropCustName" runat="server" Width="250px" AutoPostBack="True" CssClass="FontStyle">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><asp:textbox id="txtCity" runat="server" Width="104px" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
					<TD width="15%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>The sum of Rupees
						<asp:textbox id="txtAmountinWords" runat="server" Width="224px" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox>&nbsp;in&nbsp;Full 
						/ Part&nbsp;&nbsp; payment against Bill details given on account of your 
						supply.</TD>
					<TD></TD>
				</TR>
				<tr>
					<td></td>
					<td colSpan="2">Received 
						Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtReceivedDate" Width="80" Runat="server" CssClass="fontstyle" BorderStyle="Groove"
							ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtReceivedDate);return false;"><IMG class="PopcalTrigger" id="Img2" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0" runat="server"></A></td>
				</tr>
				<tr>
					<td></td>
					<td align="center">
						<TABLE border="1">
							<TR>
								<TD align="center">Due Payment</TD>
								<TD align="center">Received Payment</TD>
								<TD align="center">Final Dues After Payment</TD>
							</TR>
							<TR>
								<TD vAlign="top"><asp:datagrid id="GridDuePayment" runat="server" Width="100%" AutoGenerateColumns="False" HorizontalAlign="Center"
										CellSpacing="1">
										<HeaderStyle Font-Size="Large" Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="invoice_no" HeaderText="Bill No">
												<HeaderStyle Width="60px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="invoice_date" HeaderText="Bill Date" DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="balance" HeaderText="Amount" DataFormatString="{0:N2}">
												<HeaderStyle Width="75px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
								<TD align="center">
									<TABLE cellSpacing="0" cellPadding="0">
										<TR>
											<TD>Mode</TD>
											<TD>Amount&nbsp; <FONT color="#ff0000">*</FONT>
												<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Received Amount"
													ControlToValidate="txtRecAmount">*</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 16px"><asp:dropdownlist id="DropMode" runat="server" AutoPostBack="True" CssClass="FontStyle">
													<asp:ListItem Value="Cash">Cash</asp:ListItem>
													<asp:ListItem Value="Cheque">Cheque</asp:ListItem>
													<asp:ListItem Value="DD">DD</asp:ListItem>
													<asp:ListItem Value="Pay Order">Pay Order</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD style="HEIGHT: 16px"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtRecAmount" onblur="GetFinalDues()"
													runat="server" Width="96px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
										</TR>
										<tr>
											<td style="HEIGHT: 10px"><asp:dropdownlist id="DropDiscount1" Width="100%" Runat="server" CssClass="fontstyle" onchange="chkSelect(this);">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></td>
											<td style="HEIGHT: 10px"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtDisc1" onblur="GetFinalDues()"
													Width="100%" Runat="server" CssClass="fontstyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:dropdownlist id="DropDiscount2" Width="100%" Runat="server" CssClass="fontstyle" onchange="chkSelect1(this);">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></td>
											<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtDisc2" onblur="GetFinalDues()"
													Width="100%" Runat="server" CssClass="fontstyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></td>
										</tr>
										<asp:panel id="PanBankInfo" runat="server">
											<TR>
												<TD>&nbsp;Bank A/C&nbsp;
													<asp:CompareValidator id="cv1" Runat="server" ValueToCompare="Select" Operator="NotEqual" ControlToValidate="DropBankName"
														ErrorMessage="Please Select The Bank">*</asp:CompareValidator></TD>
												<TD>
													<asp:DropDownList id="DropBankName" Width="100%" Runat="server" CssClass="fontstyle">
														<asp:ListItem Value="Select">Select</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD>Cust. Bank Name</TD>
												<TD>
													<asp:textbox id="txtBankName" runat="server" Width="96px" CssClass="FontStyle" BorderStyle="Groove"
														MaxLength="49"></asp:textbox></TD>
											</TR>
											<TR>
												<TD>Cheque No</TD>
												<TD>
													<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtChequeno" runat="server"
														Width="96px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="15"></asp:textbox></TD>
											</TR>
											<TR>
												<TD>Date</TD>
												<TD height="10">
													<asp:textbox id="txtDate" runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove"
														ReadOnly="True"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" id="Img1" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
															border="0" runat="server"></A></TD>
											</TR>
										</asp:panel></TABLE>
								</TD>
								<TD align="center">
									<TABLE cellSpacing="0" cellPadding="0">
										<TR>
											<TD height="17">&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right"><asp:textbox id="txtCr" runat="server" Width="31px" CssClass="FontStyle" BorderStyle="Groove"
													ReadOnly="True"></asp:textbox><asp:textbox id="txtFinalDues" runat="server" Width="96px" CssClass="FontStyle" BorderStyle="Groove"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>Total&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtTotalBalance" runat="server" Width="96px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
								<TD align="right"><asp:textbox id="Textbox1" runat="server" Width="96px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox>&nbsp;</TD>
								<TD align="right"><asp:textbox id="Textbox3" runat="server" Width="31px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox><asp:textbox id="Textbox2" runat="server" Width="96px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox>&nbsp;</TD>
							</TR>
							<tr>
								<td align="center">Narration</td>
								<td colSpan="2"><asp:textbox id="txtNar" Width="320" Runat="server" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="149"></asp:textbox></td>
							</tr>
						</TABLE>
					</td>
					<td></td>
				</tr>
				<TR>
					<TD></TD>
					<TD align="right"><asp:button id="btnSave" runat="server" Width="70px" ForeColor="White" Text="Save" BackColor="ForestGreen"
							BorderColor="ForestGreen"></asp:button>&nbsp;<asp:button id="btnEdit" runat="server" Width="70px" ForeColor="White" Text="Edit" BackColor="ForestGreen"
							BorderColor="ForestGreen" CausesValidation="False"></asp:button>&nbsp;<asp:button id="btnPrint" runat="server" Width="70px" ForeColor="White" Text="Print" BackColor="ForestGreen"
							BorderColor="ForestGreen" CausesValidation="False"></asp:button>&nbsp;<asp:button id="btnDelete" runat="server" Width="70px" ForeColor="White" Text="Delete" BackColor="ForestGreen"
							BorderColor="ForestGreen" CausesValidation="False"></asp:button></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right"><asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD>
					<TD></TD>
				</TR>
			</table>
			<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></IFRAME>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
