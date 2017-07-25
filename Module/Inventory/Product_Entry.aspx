<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="Product_Entry.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.Product_Entry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Product Entry</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<script language="javascript">
		function  check(t)
		{
		var index = t.selectedIndex;
		//var value = t.options[index].value;
		//alert(index)
		if(index == 0)
		{
		//alert("if")
		document.f1.txtCategory.disabled = false;
		return false;
		}
		else
		{
		//alert("else")
		document.f1.txtCategory.disabled = true;
		document.f1.txtCategory.value = "";
		return false;
		}
		
		}
		
		function  check1(t)
		{
		var index = t.selectedIndex;
		var value = t.options[index].value;
		//alert(index)
		if(value == "Other")
		{
		//alert("if")
		document.f1.txtunit.disabled = false;
		return false;
		}
		else
		{
		//alert("else")
		document.f1.txtunit.disabled = true;
		document.f1.txtunit.value = "";
		
		return false;
		}
		
		}
		function  check2(t)
		{
		var index = t.selectedIndex;
	//	var value = t.options[index].value;
	//	alert(index)
		if(index == 0)
		{
	//	alert("if")
		document.f1.txtPack1.disabled = false;
		document.f1.txtPack2.disabled = false;
		document.f1.DropUnit.selectedIndex = 0;
		document.f1.DropUnit.disabled = false;
		document.f1.txtOp_Stock.disabled = false;
		document.f1.txtBox.disabled = true;
		document.f1.DropUnit.disabled = false;
		document.f1.txtOp_Stock.value = "";
		document.f1.txtBox.value = "";
		document.f1.txtTotalQty.value ="";
		document.f1.DropPackUnit.selectedIndex =0;
		
		
		return false;
		}
		else if(index == 1)
		{
		document.f1.txtPack1.disabled = true;
		document.f1.txtPack2.disabled = true;
		document.f1.txtPack1.value = "";
		document.f1.txtPack2.value = "";
		document.f1.txtOp_Stock.disabled = true;
		document.f1.txtBox.value = "";
		document.f1.txtBox.disabled = false;
		document.f1.txtOp_Stock.value = "";
		document.f1.txtTotalQty.value = "0";
		document.f1.txtunit.value = "";
		document.f1.txtunit.disabled = true;
		document.f1.DropUnit.selectedIndex = 4;
		document.f1.DropUnit.disabled = true;
		document.f1.DropUnit.disabled = true;	
		document.f1.DropPackUnit.selectedIndex = 2;
		
		}
		else
		{
	//	alert("else")
		document.f1.txtPack1.disabled = true;
		document.f1.txtPack2.disabled = true;
		document.f1.txtPack1.value = "";
		document.f1.txtPack2.value = "";
		document.f1.DropUnit.selectedIndex = 0;
		document.f1.DropUnit.disabled = false;
		document.f1.txtOp_Stock.disabled = false;
		document.f1.txtBox.disabled = true;
		document.f1.DropUnit.disabled = false;
		document.f1.txtOp_Stock.value = "";
		document.f1.txtBox.value = "";
		document.f1.txtTotalQty.value ="";
		document.f1.DropPackUnit.selectedIndex =0;
		CalcTotalQty1(t);
		return false;
		}
		
		}
		
	function CalcTotalQty()
	{
		var f=document.f1;
		f.txtTotalQty.value=f.txtPack1.value*f.txtPack2.value;
	}
	function CalcTotalQty1(t)
	{
		var index = t.selectedIndex;
		var value = t.options[index].value;
		if(value != "")
		{
		var Qty = new Array();
		Qty = value.split("X");
		var q1=0;
		var q2=0;
		if(Qty[0]!="")
		q1=Qty[0];
		if(Qty[1] != "")
		q2=Qty[1];		  	
		document.f1.txtTotalQty.value= q1*q2;
		}
	}
	function CalcQty()
	{
		var f=document.f1;
		f.txtBox.value=f.txtTotalQty.value*f.txtOp_Stock.value;
	}
	function checkDelRec()
	{
		if(document.f1.btnEdit == null)
		{
			if(document.f1.dropProdID.value!="Select")
			{
				if(confirm("Do You Want To Delete The Product"))
					document.f1.tempDelinfo.value="Yes";
				else
					document.f1.tempDelinfo.value="No";
			}
			else
			{
				alert("Please Select The Product Name");
				return;
			}
		}
		else
		{
			alert("Please Click The Edit button");
			return;
		}
		if(document.f1.tempDelinfo.value=="Yes")
			document.f1.submit();
	}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="f1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><asp:textbox id="TextBox1" style="Z-INDEX: 101; LEFT: 152px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox><input type="hidden" name="tempDelinfo" id="tempDelinfo" runat="server" style="WIDTH:1px">
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Product Entry</font>
						<HR>
					</TH>
				</TR>
				<TR>
					<TD align="center">
						<TABLE cellpadding="0" cellspacing="0">
							<TR>
								<TD>Product</TD>
								<TD colSpan="3"><asp:label id="lblProdID" runat="server" ForeColor="Blue" Width="120px"></asp:label>
									<asp:dropdownlist id="dropProdID" runat="server" Width="283px" Visible="False" AutoPostBack="True"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:label id="lb" runat="server" ForeColor="Red">Except Fuel products</asp:label>
									<asp:button id="btnEdit" runat="server" Width="25px" Text="..." ToolTip="Click For Edit" Height="20px"
										ForeColor="White" BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button></TD>
							</TR>
							<TR>
								<TD>Product Name <FONT color="red">*</FONT></TD>
								<TD colspan="3"><asp:textbox id="txtProdName" runat="server" Width="382px" BorderStyle="Groove" CssClass="FontStyle"></asp:textbox>
									<asp:label id="lblProd" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Category&nbsp;Type <FONT color="red">*</FONT></TD>
								<TD><asp:dropdownlist id="DropCategory" Width="160px" AutoPostBack="false" Runat="server" OnChange="check(this);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD><FONT color="#0000ff">(if another, Specify)</FONT></TD>
								<TD><asp:textbox id="txtCategory" runat="server" Width="118px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Package Type <FONT color="red">*</FONT></TD>
								<TD><asp:dropdownlist id="DropPackage" runat="server" Width="160px" onChange="check2(this);" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Loose Oil">Loose Oil</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD><FONT color="#0000ff">(if another, Specify)</FONT></TD>
								<TD><asp:textbox id="txtPack1" onblur="CalcTotalQty()" runat="server" Width="48px" BorderStyle="Groove"
										CssClass="FontStyle" onkeypress="return GetOnlyNumbers(this, event, false,true);" MaxLength="5"></asp:textbox>&nbsp; 
									X&nbsp;&nbsp;
									<asp:textbox id="txtPack2" onblur="CalcTotalQty()" runat="server" Width="48px" BorderStyle="Groove"
										CssClass="FontStyle" onkeypress="return GetOnlyNumbers(this, event, false,true);" MaxLength="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Opening Stock
								</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtOp_Stock" onblur="CalcQty()"
										runat="server" Width="78px" BorderStyle="Groove" CssClass="FontStyle"></asp:textbox><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtBox" runat="server"
										Width="78px" BorderStyle="Groove" CssClass="FontStyle"></asp:textbox></TD>
								<TD>Package&nbsp;Qty&nbsp; <FONT color="red">*</FONT></TD>
								<TD><asp:textbox id="txtTotalQty" runat="server" Width="58px" BorderStyle="Groove" ReadOnly="True"
										CssClass="FontStyle"></asp:textbox><asp:dropdownlist id="DropPackUnit" runat="server" Width="60px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Kg.">Kg.</asp:ListItem>
										<asp:ListItem Value="Ltr.">Ltr.</asp:ListItem>
										<asp:ListItem Value="Ml.">Ml.</asp:ListItem>
										<asp:ListItem Value="Nos.">Nos.</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Unit <FONT color="red">*</FONT></TD>
								<TD><asp:dropdownlist id="DropUnit" runat="server" Width="160px" onChange="check1(this);" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Barrel">Barrel</asp:ListItem>
										<asp:ListItem Value="Bucket">Bucket</asp:ListItem>
										<asp:ListItem Value="Carton">Carton</asp:ListItem>
										<asp:ListItem Value="Loose Oil">Loose Oil</asp:ListItem>
										<asp:ListItem Value="Pouch">Pouch</asp:ListItem>
										<asp:ListItem Value="Tin">Tin</asp:ListItem>
										<asp:ListItem Value="Other">Other</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 18px"><FONT color="#0000ff"><asp:label id="Label1" runat="server" Width="88px">(if another, Specify)</asp:label></FONT></TD>
								<TD style="HEIGHT: 18px"><asp:textbox id="txtunit" onblur="CalcTotalQty()" runat="server" Width="58px" BorderStyle="Groove"
										CssClass="FontStyle" MaxLength="40"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Store in <FONT color="red">*</FONT></TD>
								<TD><asp:dropdownlist id="DropStorein" runat="server" Width="160px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Godown">Godown</asp:ListItem>
										<asp:ListItem Value="Sales Room">Sales Room</asp:ListItem>
										<asp:ListItem Value="Other">Other</asp:ListItem>
									</asp:dropdownlist></TD>
								<td>&nbsp; Minimum Lavel</td>
								<td><asp:textbox id="txtMinLabel" Width="58px" CssClass="FontStyle" Runat="server" BorderStyle="Groove"
										MaxLength="10"></asp:textbox></td>
							</TR>
							<tr>
								<td>ReOrder Lavel</td>
								<td><asp:textbox id="txtReOrderLabel" Width="80" CssClass="FontStyle" Runat="server" BorderStyle="Groove"
										MaxLength="10"></asp:textbox></td>
								<td>&nbsp; Max Lavel</td>
								<td><asp:TextBox ID="txtMaxLabel" Runat="server" Width="58px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="10"></asp:TextBox></td>
							</tr>
							<TR>
								<TD height="20" colSpan="4" align="right">
									<asp:button id="btnSave" runat="server" Width="80px" Text="Save" ForeColor="White" BorderColor="ForestGreen"
										BackColor="ForestGreen"></asp:button>&nbsp;&nbsp;<asp:button id="btnDelete" runat="server" Width="80px" Text="Delete" ForeColor="White" BorderColor="ForestGreen"
										BackColor="ForestGreen" Onmouseup="checkDelRec()"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
