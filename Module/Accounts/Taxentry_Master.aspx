<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Taxentry_Master.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Accounts.TaxEntry" smartNavigation="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Tax Entry</title> <!--
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
		<script language="javascript" id="clientEventHandlersJS">
<!--


function chkall_onclick() 
{
	var i;
	if(document.all.item('chkall').checked)
	{   
	    for(var j=0;j<document.forms[0].length;j++)
	    {
         if(document.forms[0].elements[j].type=="text")
         {
           document.forms[0].elements[j].disabled = false
         }	    
	    }
		for(i=1;i<=11;i++)
		{
			var x = document.getElementById('chk'+i);			
			x.checked=true;
		}
	}
	else
	{
	     for(var j=0;j<document.forms[0].length;j++)
	    {
         if(document.forms[0].elements[j].type=="text")
         {
           document.forms[0].elements[j].disabled = true
           document.forms[0].elements[j].value = ""
         }	    
	    }
		for(i=1;i<=11;i++)
		{
			var x = document.getElementById('chk'+i);			
			x.checked=false;
		}
	}
}

/*function window_onload() 
{
	var i;
	for(i=1;i<=12;i++)
	{
		var x = document.getElementById('chk'+i);
		x.checked=true;
	}
}*/

function chk1_onclick(t,t1,t2) 
{
    var i = 1;
    if(t.checked)
    { 
      t1.disabled = false
      
      for(var j=0;j<document.forms[0].length;j++)
	   {
        if(document.forms[0].elements[j].type=="checkbox" && document.forms[0].elements[j].checked==true)
        {
         i++;
         if(i==12)
           document.forms[0].chkall.checked = true; 
        
        }	
       }   
      //document.all.item('chkall').checked=false
	}  
	else
	{
	 t2.defalutChecked
	 t.checked = false
	 t1.disabled = true
	 t1.value=""
	 document.forms[0].chkall.checked = false; 
	}
	
}

/*function chk2_onclick() 
{
document.all.item('chkall').checked=false
}

function chk3_onclick() {
document.all.item('chkall').checked=false
}

function chk4_onclick() {
document.all.item('chkall').checked=false
}

function chk5_onclick() {
document.all.item('chkall').checked=false
}

function chk6_onclick() {
document.all.item('chkall').checked=false
}

function chk7_onclick() {
document.all.item('chkall').checked=false
}

function chk8_onclick() {
document.all.item('chkall').checked=false
}

function chk9_onclick() {
document.all.item('chkall').checked=false
}

function chk10_onclick() {
document.all.item('chkall').checked=false
}

function chk11_onclick() {
document.all.item('chkall').checked=false
}*/

//-->
		</script>
	</HEAD>
	<body language="javascript" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server" name="Form1">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 101; LEFT: 152px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:TextBox>
			<TABLE height="200" width="778" align="center">
				<tr>
					<th align="center">
						<font color="#006400">Tax Entry</font>
						<hr>
						<TABLE id="Table1" align="center" style="WIDTH: 361px; HEIGHT: 336px">
							<TR>
								<TD align="center" colSpan="2">
									<TABLE cellpadding="0" cellspacing="0">
										<TR>
											<TD>Product Name&nbsp; <FONT color="#ff0000">*</FONT>
												<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Please Select Product Name"
													ValueToCompare="Select" ControlToValidate="drp_pname" Operator="NotEqual"><font color="red">*</font></asp:CompareValidator></TD>
											<TD><asp:dropdownlist id="drp_pname" runat="server" AutoPostBack="True" Width="120px" CssClass="FontStyle"></asp:dropdownlist></TD>
											<TD align="center">Unit</TD>
											<TD align="center">Required
												<br>
												Fields
											</TD>
										</TR>
										<TR>
											<TD>Reduction&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txtrdc" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txtrdc" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_rdc" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL" Selected="True">KL</asp:ListItem>
													<asp:ListItem Value="%">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk1" onClick="return chk1_onclick(this,document.forms[0].txtrdc,document.forms[0].unit_rdc)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>Entry Tax&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txtetax" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txtetax" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_etax" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL">KL</asp:ListItem>
													<asp:ListItem Value="%" Selected="True">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD id="chket" align="center"><INPUT language="javascript" id="chk2" onClick="return chk1_onclick(this,document.forms[0].txtetax,document.forms[0].unit_etax)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>RPG Charges&nbsp;&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" Width="8px" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txtrpg_chg" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txtrpg_chg" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle"
													BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_rpgchg" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL" Selected="True">KL</asp:ListItem>
													<asp:ListItem Value="%">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk3" onClick="return chk1_onclick(this,document.forms[0].txtrpg_chg,document.forms[0].unit_rpgchg)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>RPG Surcharge&nbsp;&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txt_rpgschg" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txt_rpgschg" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle"
													BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_rpgschg" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL" Selected="True">KL</asp:ListItem>
													<asp:ListItem Value="%">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk4" onClick="return chk1_onclick(this,document.forms[0].txt_rpgschg,document.forms[0].unit_rpgschg)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>Local Transport Charge&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator5" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txt_ltchg" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txt_ltchg" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_ltchg" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL" Selected="True">KL</asp:ListItem>
													<asp:ListItem Value="%">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk5" onClick="return chk1_onclick(this,document.forms[0].txt_ltchg,document.forms[0].unit_ltchg)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>Transportation Charge&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txt_tchg" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txt_tchg" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_tchg" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL" Selected="True">KL</asp:ListItem>
													<asp:ListItem Value="%">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk6" onClick="return chk1_onclick(this,document.forms[0].txt_tchg,document.forms[0].unit_tchg)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>Other Levies Value&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator7" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txt_olvy" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txt_olvy" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_olv" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL" Selected="True">KL</asp:ListItem>
													<asp:ListItem Value="%">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk7" onClick="return chk1_onclick(this,document.forms[0].txt_olvy,document.forms[0].unit_olv)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>
												Vat&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator8" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txt_lst" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txt_lst" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_lst" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL">KL</asp:ListItem>
													<asp:ListItem Value="%" Selected="True">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk8" onClick="return chk1_onclick(this,document.forms[0].txt_lst,document.forms[0].unit_lst)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>LST Surcharge&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator9" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txt_lstschg" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txt_lstschg" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle"
													BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_lstschg" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL">KL</asp:ListItem>
													<asp:ListItem Value="%" Selected="True">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk9" onClick="return chk1_onclick(this,document.forms[0].txt_lstschg,document.forms[0].unit_lstschg)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 1px">License Fee Recovery&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator10" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txt_lfrecov" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD style="HEIGHT: 1px"><asp:textbox id="txt_lfrecov" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle"
													BorderStyle="Groove"></asp:textbox></TD>
											<TD style="HEIGHT: 1px"><asp:dropdownlist id="unit_lfrecov" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL" Selected="True">KL</asp:ListItem>
													<asp:ListItem Value="%">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center" style="HEIGHT: 1px"><INPUT language="javascript" id="chk10" onClick="return chk1_onclick(this,document.forms[0].txt_lfrecov,document.forms[0].unit_lfrecov)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD>DO/FO/BC Charges&nbsp;
												<asp:regularexpressionvalidator id="RegularExpressionValidator11" runat="server" ErrorMessage="Numeric Entry Required"
													ControlToValidate="txt_dochg" ValidationExpression="(\d+\.{1}\d+)|(\d+)">*</asp:regularexpressionvalidator></TD>
											<TD><asp:textbox id="txt_dochg" runat="server" Width="120px" MaxLength="5" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="unit_dochg" runat="server" CssClass="FontStyle">
													<asp:ListItem Value="KL" Selected="True">KL</asp:ListItem>
													<asp:ListItem Value="%">%</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><INPUT language="javascript" id="chk11" onClick="return chk1_onclick(this,document.forms[0].txt_dochg,document.forms[0].unit_dochg)"
													type="checkbox" CHECKED runat="server"></TD>
										</TR>
										<TR>
											<TD align="right" colSpan="3">select&nbsp;All</TD>
											<TD>
												<P align="center"><INPUT language="javascript" id="chkall" onClick="return chkall_onclick()" type="checkbox"
														CHECKED runat="server"></P>
											</TD>
										</TR>
									</TABLE>
									<asp:button id="btnAdd" accessKey="a" runat="server" Width="70px" Text="Add" BackColor="ForestGreen"
										BorderColor="ForestGreen" ForeColor="White"></asp:button><asp:button id="btnEdit" accessKey="e" runat="server" Width="70px" Text="Edit" BackColor="ForestGreen"
										BorderColor="ForestGreen" ForeColor="White"></asp:button><asp:button id="btnDelete" accessKey="e" runat="server" Width="70px" Text="Delete" BackColor="ForestGreen"
										BorderColor="ForestGreen" ForeColor="White"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" Height="16px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></th></tr>
			</TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		</FORM>
	</body>
</HTML>
