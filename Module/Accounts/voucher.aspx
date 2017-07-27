<%@ Page language="c#" Codebehind="voucher.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.voucher" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Voucher Entry</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
function getAcountName(t,t1)
{
	var index = t.selectedIndex;
	var typetext  = t.options[index].text;
	//alert(typetext)
	var mainarr = new Array();
	var temp = "";
	if(t1!=null)
	{
		if(typetext == "Contra")
		{
			temp = document.Form1.txtTempContra.value;
			fillCombo(t,temp,t1);
		}
		else if(typetext == "Credit Note")
		{
			temp = document.Form1.txTempCredit.value;
			fillCombo(t,temp,t1);
		}
		else if(typetext == "Debit Note")
		{
			temp = document.Form1.txtTempDebit.value;
			fillCombo(t,temp,t1);
		}
		else
		{
			temp = document.Form1.txtTempJournal.value;
			fillCombo(t,temp,t1);
		}
	}
	else
	{
		if(typetext == "Contra")
		{
			temp = document.Form1.txtTempContra.value;
			fillCombo1(temp);
		}
		else if(typetext == "Credit Note")
		{
			temp = document.Form1.txTempCredit.value;
			fillCombo1(temp);
		}
		else if(typetext == "Debit Note")
		{
			temp = document.Form1.txtTempDebit.value;
			fillCombo1(temp);
		}
		else
		{
			temp = document.Form1.txtTempJournal.value;
			fillCombo1(temp);
		}
	} 
}

function fillCombo1(temp)
{
	if(document.Form1.DropVoucherName.value=="Contra")
	{
		alert("Can Not Update The Entry In Contra Voucher Type");
		document.Form1.DropVoucherName.selectedIndex=0;
		return;
	}
	var mainarr = new Array();
	mainarr = temp.split("~");
	alert("Genrate New ID "+document.Form1.DropVoucherName.value+" "+mainarr[0]+" At The Place Of "+document.Form1.DropDownID.value);
	document.Form1.txtID.value = mainarr[0];
}

function fillCombo(t,temp,t1)
{
	document.Form1.dropAccName1.length = 1;
	document.Form1.dropAccName2.length = 1;
	document.Form1.dropAccName3.length = 1;
	document.Form1.dropAccName4.length = 1;
	document.Form1.dropAccName5.length = 1;
	document.Form1.dropAccName6.length = 1;
	document.Form1.dropAccName7.length = 1;
	document.Form1.dropAccName8.length = 1;
	document.Form1.txtAccName1.value = "Select"; 
	document.Form1.txtAccName2.value = "Select";
	document.Form1.txtAccName3.value = "Select";
	document.Form1.txtAccName4.value = "Select";
	document.Form1.txtAccName5.value = "Select";
	document.Form1.txtAccName6.value = "Select";
	document.Form1.txtAccName7.value = "Select";
	document.Form1.txtAccName8.value = "Select";
	var mainarr = new Array();
	mainarr = temp.split("~");
	var n=0;
	//if(t1!=null)
		t1.value = mainarr[0];
	//else
	//	alert("Genrate New ID "+t.value+" "+mainarr[0]+" At The Place Of "+document.Form1.DropDownID.value);
	document.Form1.txtID.value = mainarr[0];
	for(var i=1;i<mainarr.length-1;i++)
	{
		document.Form1.dropAccName1.add(new Option) 
		document.Form1.dropAccName2.add(new Option) 
		document.Form1.dropAccName3.add(new Option) 
		document.Form1.dropAccName4.add(new Option) 
		document.Form1.dropAccName5.add(new Option) 
		document.Form1.dropAccName6.add(new Option) 
		document.Form1.dropAccName7.add(new Option)
		document.Form1.dropAccName8.add(new Option) 
		if(mainarr[i]  != "")
		{
			document.Form1.dropAccName1.options[n+1].text=mainarr[i]; 
			document.Form1.dropAccName2.options[n+1].text=mainarr[i]; 
			document.Form1.dropAccName3.options[n+1].text=mainarr[i]; 
			document.Form1.dropAccName4.options[n+1].text=mainarr[i]; 
			document.Form1.dropAccName5.options[n+1].text=mainarr[i]; 
			document.Form1.dropAccName6.options[n+1].text=mainarr[i]; 
			document.Form1.dropAccName7.options[n+1].text=mainarr[i]; 
			document.Form1.dropAccName8.options[n+1].text=mainarr[i]; 
			n = n + 1;
		}
	}
}


/*function fillCombo(t,temp,t1)
{
//alert("fill")
document.Form1.dropAccName1.length = 1;
document.Form1.dropAccName2.length = 1;
document.Form1.dropAccName3.length = 1;
document.Form1.dropAccName4.length = 1;
document.Form1.dropAccName5.length = 1;
document.Form1.dropAccName6.length = 1;
document.Form1.dropAccName7.length = 1;
document.Form1.dropAccName8.length = 1;
document.Form1.txtAccName1.value = "Select"; 
document.Form1.txtAccName2.value = "Select";
document.Form1.txtAccName3.value = "Select";
document.Form1.txtAccName4.value = "Select";
document.Form1.txtAccName5.value = "Select";
document.Form1.txtAccName6.value = "Select";
document.Form1.txtAccName7.value = "Select";
document.Form1.txtAccName8.value = "Select";
var mainarr = new Array();
mainarr = temp.split("~");
var n=0;
//document.Form1.txtVouchID.disabled = false; 
//alert(t1.value);
//t1.value = "hello";
if(t1!=null)
	t1.value = mainarr[0];
else
	alert("Genrate New ID "+t.value+" "+mainarr[0]+" At The Place Of "+document.Form1.DropDownID.value);
document.Form1.txtID.value = mainarr[0];
//alert(document.Form1.txtVouchID.value);
//document.Form1.txtVouchID.disabled = true;
for(var i=1;i<mainarr.length-1;i++)
{
	document.Form1.dropAccName1.add(new Option) 
	document.Form1.dropAccName2.add(new Option) 
	document.Form1.dropAccName3.add(new Option) 
	document.Form1.dropAccName4.add(new Option) 
	document.Form1.dropAccName5.add(new Option) 
	document.Form1.dropAccName6.add(new Option) 
	document.Form1.dropAccName7.add(new Option) 
	document.Form1.dropAccName8.add(new Option) 
	if(mainarr[i]  != "")
	{
	document.Form1.dropAccName1.options[n+1].text=mainarr[i];                  
	document.Form1.dropAccName2.options[n+1].text=mainarr[i]; 
	document.Form1.dropAccName3.options[n+1].text=mainarr[i]; 
	document.Form1.dropAccName4.options[n+1].text=mainarr[i]; 
	document.Form1.dropAccName5.options[n+1].text=mainarr[i]; 
	document.Form1.dropAccName6.options[n+1].text=mainarr[i]; 
	document.Form1.dropAccName7.options[n+1].text=mainarr[i]; 
	document.Form1.dropAccName8.options[n+1].text=mainarr[i]; 
	n = n + 1;
	}

}

}
*/

function changeType(t)
{
//alert(t.name);
var index = t.selectedIndex;
var temp = t.name;
var arr = new Array();
var drop = new Array(document.Form1.dropType_1,document.Form1.dropType_2,document.Form1.dropType_3,document.Form1.dropType_4,document.Form1.dropType_5,document.Form1.dropType_6,document.Form1.dropType_7,document.Form1.dropType_8);
arr = temp.split("_");

if(eval(arr[1]) <= 4)
{
//alert(arr[1]);
if(index == 0)
{
drop[(eval(arr[1])+4)-1].selectedIndex = 0;
//alert(drop[(eval(arr[1])+4)-1].name);
}
else
{
drop[(eval(arr[1])+4)-1].selectedIndex = 1;
//alert(drop[(eval(arr[1])+4)-1].name);
}
}
else
{
//alert(arr[1]);
if(index == 0)
{
drop[(eval(arr[1])-4)-1].selectedIndex = 0;
}
else
{
drop[(eval(arr[1])-4)-1].selectedIndex = 1;
}
}

 calcTotal(); 

}

function calcTotal()
{
var LDrTotal = 0;
var LCrTotal = 0;
var RDrTotal = 0;
var RCrTotal = 0;

if(document.Form1.txtAmount1.value != "")
  {
  document.Form1.txtAmount5.value = document.Form1.txtAmount1.value;
     var index = document.Form1.dropType_1.selectedIndex;
     var typetext = document.Form1.dropType_1.options[index].text;
     if(typetext == "Dr")
        LDrTotal = LDrTotal+ eval(document.Form1.txtAmount1.value);
     else
        LCrTotal = LCrTotal+ eval(document.Form1.txtAmount1.value);
        
  }
  if(document.Form1.txtAmount2.value != "")
  {
  document.Form1.txtAmount6.value = document.Form1.txtAmount2.value;
     var index2 = document.Form1.dropType_2.selectedIndex;
     var typetext2 = document.Form1.dropType_2.options[index2].text;
     if(typetext2 == "Dr")
        LDrTotal = LDrTotal+ eval(document.Form1.txtAmount2.value);
     else
        LCrTotal = LCrTotal+ eval(document.Form1.txtAmount2.value);
        
  }
  if(document.Form1.txtAmount3.value != "")
  {
  document.Form1.txtAmount7.value = document.Form1.txtAmount3.value;
     var index3 = document.Form1.dropType_3.selectedIndex;
     var typetext3 = document.Form1.dropType_3.options[index3].text;
     if(typetext3 == "Dr")
        LDrTotal = LDrTotal+ eval(document.Form1.txtAmount3.value);
     else
        LCrTotal = LCrTotal+ eval(document.Form1.txtAmount3.value);
        
  }
  if(document.Form1.txtAmount4.value != "")
  {
  document.Form1.txtAmount8.value = document.Form1.txtAmount4.value;
     var index4 = document.Form1.dropType_4.selectedIndex;
     var typetext4 = document.Form1.dropType_4.options[index4].text;
     if(typetext4 == "Dr")
        LDrTotal = LDrTotal+ eval(document.Form1.txtAmount4.value);
     else
        LCrTotal = LCrTotal+ eval(document.Form1.txtAmount4.value);
        
  }
  if(document.Form1.txtAmount5.value != "")
  {
  document.Form1.txtAmount1.value = document.Form1.txtAmount5.value;
     var index5 = document.Form1.dropType_5.selectedIndex;
     var typetext5 = document.Form1.dropType_5.options[index5].text;
     if(typetext5 == "Dr")
        RDrTotal = RDrTotal+ eval(document.Form1.txtAmount5.value);
     else
        RCrTotal = RCrTotal+ eval(document.Form1.txtAmount5.value);
        
  }
  if(document.Form1.txtAmount6.value != "")
  {
  document.Form1.txtAmount2.value = document.Form1.txtAmount6.value;
     var index6 = document.Form1.dropType_6.selectedIndex;
     var typetext6 = document.Form1.dropType_6.options[index6].text;
     if(typetext6 == "Dr")
        RDrTotal = RDrTotal+ eval(document.Form1.txtAmount6.value);
     else
        RCrTotal = RCrTotal+ eval(document.Form1.txtAmount6.value);
        
  }
  if(document.Form1.txtAmount7.value != "")
  {
  document.Form1.txtAmount3.value = document.Form1.txtAmount7.value;
     var index7 = document.Form1.dropType_7.selectedIndex;
     var typetext7 = document.Form1.dropType_7.options[index7].text;
     if(typetext7 == "Dr")
        RDrTotal = RDrTotal+ eval(document.Form1.txtAmount7.value);
     else
        RCrTotal = RCrTotal+ eval(document.Form1.txtAmount7.value);
        
  }
  if(document.Form1.txtAmount8.value != "")
  {
  document.Form1.txtAmount4.value = document.Form1.txtAmount8.value;
     var index8 = document.Form1.dropType_8.selectedIndex;
     var typetext8 = document.Form1.dropType_8.options[index8].text;
     if(typetext8 == "Dr")
        RDrTotal = RDrTotal+ eval(document.Form1.txtAmount8.value);
     else
        RCrTotal = RCrTotal+ eval(document.Form1.txtAmount8.value);
        
  }
  
  document.Form1.txtLCr.value = LCrTotal;
   makeRound( document.Form1.txtLCr);
  document.Form1.txtLDr.value = LDrTotal;
   makeRound( document.Form1.txtLDr);
  document.Form1.txtRCr.value = RCrTotal;
   makeRound( document.Form1.txtRCr);
  document.Form1.txtRDr.value = RDrTotal;
   makeRound( document.Form1.txtRDr);
  
}
	function makeRound(t)
	{
//	alert(t.value)
	var str = t.value;
	if(str != "")
	{
	str = eval(str)*100;
//	alert(str)
	str  = Math.round(str);
//	alert(str)
	str = eval(str)/100;
//	alert(str)
	t.value = str;
	}
	
	}
	function setValue(t)
	{
	  var index = t.selectedIndex;
	  var typetext = t.options[index].text;
	  //alert(t.name);
	  if(t.name == "dropAccName1")
	     document.Form1.txtAccName1.value = typetext;
	  if(t.name == "dropAccName2")
	     document.Form1.txtAccName2.value = typetext;
	  if(t.name == "dropAccName3")
	     document.Form1.txtAccName3.value = typetext;
	  if(t.name == "dropAccName4")
		document.Form1.txtAccName4.value = typetext;
	  if(t.name == "dropAccName5")
		document.Form1.txtAccName5.value = typetext;
	  if(t.name == "dropAccName6")
		document.Form1.txtAccName6.value = typetext;
	  if(t.name == "dropAccName7")
		document.Form1.txtAccName7.value = typetext;
	  if(t.name == "dropAccName8")
		document.Form1.txtAccName8.value = typetext;     
	       
	   
	}
	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="8px"></asp:textbox><INPUT id="txtTempContra" style="Z-INDEX: 103; LEFT: 160px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 24px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txTempCredit" style="Z-INDEX: 104; LEFT: 176px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txtTempDebit" style="Z-INDEX: 105; LEFT: 192px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 24px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="txtTempJournal" style="Z-INDEX: 106; LEFT: 208px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server">
			<TABLE style="WIDTH: 778px; HEIGHT: 288px" align="center">
				<tr>
					<th align="center">
						<font color="#006400">Voucher Entry</font>
						<hr>
					</th>
				</tr>
				<TR>
					<TD vAlign="middle" align="center">
						<TABLE cellSpacing="0" cellPadding="0" border="0">
							<TBODY>
								<TR>
									<TD colSpan="7"><FONT color="#ff0000">Fields Marked as (*) Are 
											Mandatory&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:label id="lblVid" runat="server" Width="66px"></asp:label></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" align="left">Voucher Type<FONT color="#ff0000">*</FONT><asp:comparevalidator id="Comparevalidator5" runat="server" ErrorMessage="Please Select Voucher type"
											ControlToValidate="DropVoucherName" Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator><FONT color="red"></FONT></TD>
									<TD><asp:dropdownlist id="DropVoucherName" runat="server" Width="130px" onChange="return getAcountName(this,document.Form1.txtVouchID);"
											CssClass="FontStyle">
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="Contra">Contra</asp:ListItem>
											<asp:ListItem Value="Credit Note">Credit Note</asp:ListItem>
											<asp:ListItem Value="Debit Note">Debit Note</asp:ListItem>
											<asp:ListItem Value="Journal">Journal</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD>&nbsp;&nbsp;&nbsp;Voucher ID <FONT color="#ff0000">*</FONT>
										<asp:comparevalidator id="Comparevalidator6" runat="server" ErrorMessage="Please Select Voucher ID " ControlToValidate="DropDownID"
											Operator="NotEqual" ValueToCompare="Select" ForeColor="White">*</asp:comparevalidator>&nbsp;&nbsp;</TD>
									<TD vAlign="top" align="left">
										<P align="left" valign="top"><asp:dropdownlist id="DropDownID" runat="server" Width="69px" CssClass="FontStyle" AutoPostBack="True">
												<asp:ListItem Value="Select">Select</asp:ListItem>
											</asp:dropdownlist><INPUT id="txtVouchID" style="WIDTH: 69px; HEIGHT: 22px" disabled type="text" size="6"
												name="txtVouchID" runat="server"><asp:button id="btnEdit1" runat="server" ForeColor="White" ToolTip="click here for Edit" CausesValidation="False"
												Text="..." BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button><INPUT id="txtID" style="WIDTH: 9px; HEIGHT: 22px" type="hidden" size="1" name="txtID"
												runat="server"></P>
									</TD>
									<TD align="center">&nbsp; Voucher Date <FONT color="#ff0000">*</FONT>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Please Enter Voucher Date"
											ControlToValidate="txtDate" ForeColor="White">*</asp:requiredfieldvalidator></TD>
									<TD colSpan="2"><asp:textbox id="txtDate" runat="server" Width="84px" CssClass="FontStyle" ReadOnly="True" BorderStyle="Groove"></asp:textbox>&nbsp;&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
												border="0"></A></TD>
								</TR>
					</TD>
				<tr>
					<td></td>
					<td align="center"><FONT color="#006400">Account Name</FONT></td>
					<td align="center"><FONT color="#006400">Amount</FONT></td>
					<td></td>
					<td align="center"><FONT color="#006400">Account Name</FONT></td>
					<td align="center"><FONT color="#006400">Amount</FONT></td>
					<td></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td><asp:dropdownlist id="dropAccName1" runat="server" Width="185px" CssClass="FontStyle" OnChange="return setValue(this);">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtAccName1" style="WIDTH: 124px; HEIGHT: 22px" type="hidden" size="15" name="Hidden1"
							runat="server"></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount1" onblur="return calcTotal();"
							runat="server" Width="84px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="9"></asp:textbox></td>
					<td><asp:dropdownlist id="dropType_1" runat="server" Width="50px" onChange="return changeType(this);"
							CssClass="FontStyle">
							<asp:ListItem Value="Dr">Dr</asp:ListItem>
							<asp:ListItem Value="Cr">Cr</asp:ListItem>
						</asp:dropdownlist></td>
					<td><asp:dropdownlist id="dropAccName5" runat="server" Width="185px" CssClass="FontStyle" OnChange="return setValue(this);">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtAccName5" style="WIDTH: 124px; HEIGHT: 22px" type="hidden" size="15" name="Hidden1"
							runat="server"></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount5" onblur="return calcTotal();"
							runat="server" Width="84px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="9"></asp:textbox></td>
					<td><asp:dropdownlist id="dropType_5" runat="server" Width="50px" onChange="return changeType(this);"
							CssClass="FontStyle">
							<asp:ListItem Value="Cr">Cr</asp:ListItem>
							<asp:ListItem Value="Dr">Dr</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td><asp:dropdownlist id="dropAccName2" runat="server" Width="185px" CssClass="FontStyle" OnChange="return setValue(this);">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtAccName2" style="WIDTH: 124px; HEIGHT: 22px" type="hidden" size="15" name="Hidden1"
							runat="server"></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount2" onblur="return calcTotal();"
							runat="server" Width="84px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="9"></asp:textbox></td>
					<td><asp:dropdownlist id="dropType_2" runat="server" Width="50px" onChange="return changeType(this);"
							CssClass="FontStyle">
							<asp:ListItem Value="Dr">Dr</asp:ListItem>
							<asp:ListItem Value="Cr">Cr</asp:ListItem>
						</asp:dropdownlist></td>
					<td><asp:dropdownlist id="dropAccName6" runat="server" Width="185px" CssClass="FontStyle" OnChange="return setValue(this);">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtAccName6" style="WIDTH: 124px; HEIGHT: 22px" type="hidden" size="15" name="Hidden1"
							runat="server"></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount6" onblur="return calcTotal();"
							runat="server" Width="84px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="9"></asp:textbox></td>
					<td><asp:dropdownlist id="dropType_6" runat="server" Width="50px" onChange="return changeType(this);"
							CssClass="FontStyle">
							<asp:ListItem Value="Cr">Cr</asp:ListItem>
							<asp:ListItem Value="Dr">Dr</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td><asp:dropdownlist id="dropAccName3" runat="server" Width="185px" CssClass="FontStyle" OnChange="return setValue(this);">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtAccName3" style="WIDTH: 124px; HEIGHT: 22px" type="hidden" size="15" runat="server"></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount3" onblur="return calcTotal();"
							runat="server" Width="84px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="9"></asp:textbox></td>
					<td><asp:dropdownlist id="dropType_3" runat="server" Width="50px" onChange="return changeType(this);"
							CssClass="FontStyle">
							<asp:ListItem Value="Dr">Dr</asp:ListItem>
							<asp:ListItem Value="Cr">Cr</asp:ListItem>
						</asp:dropdownlist></td>
					<td><asp:dropdownlist id="dropAccName7" runat="server" Width="185px" CssClass="FontStyle" OnChange="return setValue(this);">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtAccName7" style="WIDTH: 124px; HEIGHT: 22px" type="hidden" size="15" name="Hidden1"
							runat="server"></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount7" onblur="return calcTotal();"
							runat="server" Width="84px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="9"></asp:textbox></td>
					<td><asp:dropdownlist id="dropType_7" runat="server" Width="50px" onChange="return changeType(this);"
							CssClass="FontStyle">
							<asp:ListItem Value="Cr">Cr</asp:ListItem>
							<asp:ListItem Value="Dr">Dr</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td><asp:dropdownlist id="dropAccName4" runat="server" Width="185px" CssClass="FontStyle" OnChange="return setValue(this);">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtAccName4" style="WIDTH: 124px; HEIGHT: 22px" type="hidden" size="15" name="Hidden1"
							runat="server"></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount4" onblur="return calcTotal();"
							runat="server" Width="84px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="9"></asp:textbox></td>
					<td><asp:dropdownlist id="dropType_4" runat="server" Width="50px" onChange="return changeType(this);"
							CssClass="FontStyle">
							<asp:ListItem Value="Dr">Dr</asp:ListItem>
							<asp:ListItem Value="Cr">Cr</asp:ListItem>
						</asp:dropdownlist></td>
					<td><asp:dropdownlist id="dropAccName8" runat="server" Width="185px" CssClass="FontStyle" OnChange="return setValue(this);">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtAccName8" style="WIDTH: 124px; HEIGHT: 22px" type="hidden" size="15" name="Hidden1"
							runat="server"></td>
					<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmount8" onblur="return calcTotal();"
							runat="server" Width="84px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="9"></asp:textbox></td>
					<td><asp:dropdownlist id="dropType_8" runat="server" Width="50px" onChange="return changeType(this);"
							CssClass="FontStyle">
							<asp:ListItem Value="Cr">Cr</asp:ListItem>
							<asp:ListItem Value="Dr">Dr</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td><b>Total CR&nbsp;: </b>
					</td>
					<td></td>
					<td><asp:textbox id="txtLCr" runat="server" Width="84px" CssClass="FontStyle" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
					<td></td>
					<td></td>
					<td><asp:textbox id="txtRCr" runat="server" Width="84px" CssClass="FontStyle" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td><b>Total DR : </b>
					</td>
					<td></td>
					<td><asp:textbox id="txtLDr" runat="server" Width="84px" CssClass="FontStyle" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
					<td></td>
					<td></td>
					<td><asp:textbox id="txtRDr" runat="server" Width="84px" CssClass="FontStyle" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<TD vAlign="top" colSpan="7"><FONT color="#ff0000"><b><FONT color="black">Narration:&nbsp; </FONT>
							</b>&nbsp; <TEXTAREA class="FontStyle" id="txtNarration" style="WIDTH: 344px; HEIGHT: 23px" rows="1"
								cols="40" runat="server">							</TEXTAREA> </FONT>
					</TD>
				</tr>
				<tr>
					<TD align="center" colSpan="7"><asp:button id="btnAdd" runat="server" Width="70px" ForeColor="White" Text="Save" BackColor="ForestGreen"
							BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnEdit" runat="server" Width="70px" ForeColor="White" Text="Edit" BackColor="ForestGreen"
							BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnDelete" runat="server" Width="70px" ForeColor="White" Text="Delete" BackColor="ForestGreen"
							BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="Button1" runat="server" Width="70px" ForeColor="White" CausesValidation="False"
							Text="Print" BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button></TD>
				</tr>
			</TABLE>
			<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD></TR></TBODY></TABLE><IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189"></IFRAME>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		</FORM>
	</body>
</HTML>
