<%@ Page language="c#" Codebehind="PurchaseInvoice.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.PurchaseInvoice" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Other Purchase Invoice</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<script language="javascript" id="purchase" src="../../Sysitem/Js/Purchase.js.js"></script>
		<script language="javascript">
		function checkProd()
		{
		var packArray = new Array();		
		var index1 = document.Form1.DropType1.selectedIndex;
		var index2 = document.Form1.DropProd1.selectedIndex;
		var index3 = document.Form1.DropPack1.selectedIndex;
		
		var index4 = document.Form1.DropType2.selectedIndex;
		var index5 = document.Form1.DropProd2.selectedIndex;
		var index6 = document.Form1.DropPack2.selectedIndex;
		
		var index7 = document.Form1.DropType3.selectedIndex;
		var index8 = document.Form1.DropProd3.selectedIndex;
		var index9 = document.Form1.DropPack3.selectedIndex;
		
		var index10 = document.Form1.DropType4.selectedIndex;
		var index11 = document.Form1.DropProd4.selectedIndex;
		var index12 = document.Form1.DropPack4.selectedIndex;
		
		var index13 = document.Form1.DropType5.selectedIndex;
		var index14= document.Form1.DropProd5.selectedIndex;
		var index15 = document.Form1.DropPack5.selectedIndex;
		
		var index16= document.Form1.DropType6.selectedIndex;
		var index17= document.Form1.DropProd6.selectedIndex;
		var index18= document.Form1.DropPack6.selectedIndex;
		
		var index19 = document.Form1.DropType7.selectedIndex;
		var index20 = document.Form1.DropProd7.selectedIndex;
		var index21 = document.Form1.DropPack7.selectedIndex;
		
		var index22 = document.Form1.DropType8.selectedIndex;
		var index23 = document.Form1.DropProd8.selectedIndex;
		var index24 = document.Form1.DropPack8.selectedIndex;
		
		if(index3==-1 )
		packArray[0]=document.Form1.DropType1.options[index1].text+document.Form1.DropProd1.options[index2].text
		else
		packArray[0]=document.Form1.DropType1.options[index1].text+document.Form1.DropProd1.options[index2].text+document.Form1.DropPack1.options[index3].text;
		
		if(index6==-1)
		packArray[1]=document.Form1.DropType2.options[index4].text+document.Form1.DropProd2.options[index5].text
		else
		packArray[1]=document.Form1.DropType2.options[index4].text+document.Form1.DropProd2.options[index5].text+document.Form1.DropPack2.options[index6].text;
		
		
		if(index9==-1 )
		packArray[2]=document.Form1.DropType3.options[index7].text+document.Form1.DropProd3.options[index8].text;
		else
		packArray[2]=document.Form1.DropType3.options[index7].text+document.Form1.DropProd3.options[index8].text+document.Form1.DropPack3.options[index9].text;
		
		
		if(index12==-1)
		packArray[3]=document.Form1.DropType4.options[index10].text+document.Form1.DropProd4.options[index11].text
		else
		packArray[3]=document.Form1.DropType4.options[index10].text+document.Form1.DropProd4.options[index11].text+document.Form1.DropPack4.options[index12].text;

		
		if(index15==-1)
		packArray[4]=document.Form1.DropType5.options[index13].text+document.Form1.DropProd5.options[index14].text;
		else
		packArray[4]=document.Form1.DropType5.options[index13].text+document.Form1.DropProd5.options[index14].text+document.Form1.DropPack5.options[index15].text;
	
		
		if(index18==-1)
		packArray[5]=document.Form1.DropType6.options[index16].text+document.Form1.DropProd6.options[index17].text;
		else
		packArray[5]=document.Form1.DropType6.options[index16].text+document.Form1.DropProd6.options[index17].text+document.Form1.DropPack6.options[index18].text;

		
		if(index21==-1)
		packArray[6]=document.Form1.DropType7.options[index19].text+document.Form1.DropProd7.options[index20].text;
		else
		packArray[6]=document.Form1.DropType7.options[index19].text+document.Form1.DropProd7.options[index20].text+document.Form1.DropPack7.options[index21].text;
	
		
		if(index24==-1)
		packArray[7]=document.Form1.DropType8.options[index22].text+document.Form1.DropProd8.options[index23].text;
		else
		packArray[7]=document.Form1.DropType8.options[index22].text+document.Form1.DropProd8.options[index23].text+document.Form1.DropPack8.options[index24].text;
		
		var count = 0;

		for (var i=0;i<8;i++)
		{
		for (var j=0;j<8;j++)
		{

		if(packArray[i]==packArray[j] && packArray[i]!="TypeSelectSelect")
		{
		count=count+1;
		if(count>1)
		{
		alert("Product Already Selected!");
	
		return false;
		}
	
		}

		else
		continue;
		}
		count = 0;

		}
		return true;
				
					
		
		}
	function calc()
	{	
	 document.Form1.txtAmount1.value=document.Form1.txtQty1.value*document.Form1.txtRate1.value	
	 if(document.Form1.txtAmount1.value==0)
		document.Form1.txtAmount1.value=""
	 document.Form1.txtAmount2.value= document.Form1.txtQty2.value*document.Form1.txtRate2.value	
 	 if(document.Form1.txtAmount2.value==0)
		document.Form1.txtAmount2.value=""
	 document.Form1.txtAmount3.value= document.Form1.txtQty3.value*document.Form1.txtRate3.value	
	 if(document.Form1.txtAmount3.value==0)
		document.Form1.txtAmount3.value=""
	 document.Form1.txtAmount4.value= document.Form1.txtQty4.value*document.Form1.txtRate4.value	
	 if(document.Form1.txtAmount4.value==0)
		document.Form1.txtAmount4.value=""
	 document.Form1.txtAmount5.value= document.Form1.txtQty5.value*document.Form1.txtRate5.value	
	 if(document.Form1.txtAmount5.value==0)
		document.Form1.txtAmount5.value=""
	 document.Form1.txtAmount6.value= document.Form1.txtQty6.value*document.Form1.txtRate6.value	
	 if(document.Form1.txtAmount6.value==0)
		document.Form1.txtAmount6.value=""
	 document.Form1.txtAmount7.value= document.Form1.txtQty7.value*document.Form1.txtRate7.value	
	 if(document.Form1.txtAmount7.value==0)
		document.Form1.txtAmount7.value=""
	 document.Form1.txtAmount8.value= document.Form1.txtQty8.value*document.Form1.txtRate8.value	
	 if(document.Form1.txtAmount8.value==0)
		document.Form1.txtAmount8.value=""
	 GetGrandTotal()
	 GetNetAmount()
	}	
	function GetGrandTotal()
	{
	 var GTotal=0
	 if(document.Form1.txtAmount1.value!="")
	 	GTotal=GTotal+eval(document.Form1.txtAmount1.value)
	 if(document.Form1.txtAmount2.value!="")
	 	GTotal=GTotal+eval(document.Form1.txtAmount2.value)
	 if(document.Form1.txtAmount3.value!="")
	 	GTotal=GTotal+eval(document.Form1.txtAmount3.value)
	 if(document.Form1.txtAmount4.value!="")
	 	GTotal=GTotal+eval(document.Form1.txtAmount4.value)
	 if(document.Form1.txtAmount5.value!="")
	 	GTotal=GTotal+eval(document.Form1.txtAmount5.value)
	 if(document.Form1.txtAmount6.value!="")
	 	GTotal=GTotal+eval(document.Form1.txtAmount6.value)
	 if(document.Form1.txtAmount7.value!="")
	 	GTotal=GTotal+eval(document.Form1.txtAmount7.value)
	 if(document.Form1.txtAmount8.value!="")
	 	GTotal=GTotal+eval(document.Form1.txtAmount8.value)
	document.Form1.txtGrandTotal.value=GTotal ;
	 makeRound(document.Form1.txtGrandTotal);
	}	
	function makeRound(t)
	{

	var str = t.value;
	if(str != "")
	{
	str = eval(str)*100;

	str  = Math.round(str);

	str = eval(str)/100;

	t.value = str;
	}
	
	}
	function GetCashDiscount()
	{
	 var CashDisc=document.Form1.txtCashDisc.value
	 if(CashDisc=="" || isNaN(CashDisc))
		CashDisc=0
	
		if(document.Form1.DropCashDiscType.value=="Per")
			CashDisc=document.Form1.txtGrandTotal.value*CashDisc/100 
		document.Form1.txtVatValue.value = "";	
		document.Form1.txtVatValue.value = eval(document.Form1.txtGrandTotal.value) - eval(CashDisc);	
					    
	}
	
	function GetVatAmount()
	{
	    GetCashDiscount()
	    
	    if(document.Form1.No.checked)
	    {
	       document.Form1.txtVAT.value = "";
	      
	    } 
	    else
	    {
	    var vat_rate = document.Form1.txtVatRate.value
	  // alert(vat_rate);
	    if(vat_rate == "")
	       vat_rate = 0;
	     var vat = document.Form1.txtVatValue.value    
	       if(vat == "" || vat == null || isNaN(vat))
	       {
	      // alert("if");
	       vat = 0;
	       }
	      // alert("disc: "+vat)
	     var vat_amount = vat * vat_rate/100
	   // alert("vat_amt : "+vat_amount)
	    
	     document.Form1.txtVAT.value = vat_amount
	     makeRound(document.Form1.txtVAT)
	    
	     
	     document.Form1.txtVatValue.value = eval(vat) + eval(vat_amount)
	    // alert("total :"+document.Form1.txtVatValue.value)
	     
	       
	    }
	
	}
	
	function GetNetAmount()
	{
	
	var vat_value = 0;
	if(document.Form1.No.checked)
	    {
	    GetCashDiscount()
	    vat_value = document.Form1.txtVatValue.value;
	    document.Form1.txtVAT.value = "";
	    }
	    else
	    {
	    GetVatAmount()
	    vat_value = document.Form1.txtVatValue.value;
	    }
	    
	   if(vat_value=="" || isNaN(vat_value))
		vat_value=0
	 var Disc=document.Form1.txtDisc.value
	 if(Disc=="" || isNaN(Disc))
		Disc=0

	 var NetAmount
		if(document.Form1.DropDiscType.value=="Per")
			Disc=vat_value * Disc/100 
		//*********Start Add Mahesh - Roundoff net amount - 1.10.007
		//document.Form1.txtNetAmount.value=eval(vat_value) - eval(Disc);
		var NetAmount = eval(vat_value) - eval(Disc);
		NetAmount = Math.round(NetAmount)
		document.Form1.txtNetAmount.value = NetAmount
		//********end
		makeRound(document.Form1.txtNetAmount);
		
		if(document.Form1.txtNetAmount.value==0  )
			document.Form1.txtNetAmount.value==""
	}/*
	function GetNetAmount()
	{
	 var Disc=document.Form1.txtDisc.value
	 if(Disc=="")
		Disc=0

	 var NetAmount
		if(document.Form1.DropDiscType.value=="Per")
			Disc=document.Form1.txtGrandTotal.value*Disc/100 

		document.Form1.txtNetAmount.value=eval(document.Form1.txtGrandTotal.value) - eval(Disc)
		makeRound(document.Form1.txtNetAmount);
		if(document.Form1.txtNetAmount.value==0)
			document.Form1.txtNetAmount.value==""
	}	*/
		function checkDelRec()
		{
			if(document.Form1.BtnEdit == null)
			{
				if(document.Form1.DropInvoiceNo.value!="Select")
				{
					if(confirm("Do You Want To Delete The Product"))
						document.Form1.tempInvoiceInfo.value="Yes";
					else
						document.Form1.tempInvoiceInfo.value="No";
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
			if(document.Form1.tempInvoiceInfo.value=="Yes")
				document.Form1.submit();
		}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script language="javascript" id="sales" src="../../Sysitem/Js/Fuel.js"></script>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .auto-style1 {
                font-family: Arial;
                font-size: 8pt;
            }
        </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" name="Form1" method="post" runat="server">
			<asp:textbox id="txtTempQty2" style="Z-INDEX: 106; LEFT: 184px; POSITION: absolute; TOP: 8px"
				runat="server" Width="8px" Visible="False"></asp:textbox><INPUT id="txtVatRate" style="Z-INDEX: 129; LEFT: 248px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatRate" runat="server"><INPUT id="txtVatValue" style="Z-INDEX: 128; LEFT: 272px; WIDTH: 5px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatValue" runat="server"><asp:textbox id="txtTempQty7" style="Z-INDEX: 111; LEFT: 224px; POSITION: absolute; TOP: 8px"
				runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty6" style="Z-INDEX: 110; LEFT: 216px; POSITION: absolute; TOP: 8px"
				runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty4" style="Z-INDEX: 108; LEFT: 200px; POSITION: absolute; TOP: 8px"
				runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty3" style="Z-INDEX: 107; LEFT: 192px; POSITION: absolute; TOP: 0px"
				runat="server" Width="8px" Visible="False"></asp:textbox><uc1:header id="Header1" runat="server"></uc1:header><INPUT id="TxtVen" style="Z-INDEX: 102; LEFT: -544px; POSITION: absolute; TOP: -24px" type="text"
				name="TxtVen" runat="server">
			<asp:textbox id="Txtselect" style="Z-INDEX: 103; LEFT: 144px; POSITION: absolute; TOP: 16px"
				runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id="TextBox1" style="Z-INDEX: 104; LEFT: 160px; POSITION: absolute; TOP: 16px" runat="server"
				Width="8px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty1" style="Z-INDEX: 105; LEFT: 176px; POSITION: absolute; TOP: 8px"
				runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty5" style="Z-INDEX: 109; LEFT: 208px; POSITION: absolute; TOP: 8px"
				runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty8" style="Z-INDEX: 112; LEFT: 232px; POSITION: absolute; TOP: 16px"
				runat="server" Width="8px" Visible="False"></asp:textbox><input id="tempInvoiceInfo" style="WIDTH: 1px" type="hidden" name="tempInvoiceInfo" runat="server">
			<input id="tempInvoiceNo" style="WIDTH: 1px" type="hidden" name="tempInvoiceNo" runat="server">
			<table height="278" width="778" align="center">
				<TR>
					<TH align="center" colSpan="3">
						<font color="#006400">Other Purchase Invoice</font>
						<HR>
						<asp:label id="lblMessage" runat="server" Font-Size="8pt" ForeColor="DarkGreen"></asp:label></TH></TR>
				<tr>
					<td align="center">
						<TABLE border="1">
							<TR>
								<TD align="center">
									<TABLE>
										<TR>
											<TD>Invoice No</TD>
											<TD><asp:label id="lblInvoiceNo" runat="server" Width="63px" ForeColor="Blue" Height="16px"></asp:label><asp:dropdownlist id="DropInvoiceNo" runat="server" Width="114px" AutoPostBack="True" CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><asp:button id="BtnEdit" runat="server" Text="..." ForeColor="White" BackColor="ForestGreen"
													BorderColor="ForestGreen" CausesValidation="False"></asp:button></TD>
										</TR>
										<TR>
											<TD>Invoice Date</TD>
											<TD><asp:TextBox id="lblInvoiceDate" runat="server" Width="100px" ReadOnly="True" BorderStyle="Groove"
													CssClass="FontStyle"></asp:TextBox>
												<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.lblInvoiceDate);return false;">
													<IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
														border="0"></A>
											</TD>
										</TR>
										<TR>
											<TD>Mode of Payment <FONT color="red">&nbsp;</FONT>&nbsp;&nbsp;</TD>
											<TD><asp:dropdownlist id="DropModeType" runat="server" Width="118px" Height="20px" CssClass="FontStyle">
													<asp:ListItem Value="Cash" Selected="True">Cash</asp:ListItem>
													<asp:ListItem Value="Cheque">Cheque</asp:ListItem>
													<asp:ListItem Value="DD on Delivery">DD on Delivery</asp:ListItem>
												</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											</TD>
										</TR>
									</TABLE>
									<INPUT id="temptext" type="hidden" name="temptext" runat="server">
								</TD>
								<TD align="center"><FONT color="#990066">Vendor Information</FONT></FONT></U>
									<TABLE cellpadding="0" cellspacing="0">
										<TR>
											<TD>&nbsp; Vendor&nbsp;Name&nbsp;&nbsp;
												<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Please Select the Vendor Name"
													ControlToValidate="DropVendorID" ValueToCompare="Select" Operator="NotEqual">*</asp:CompareValidator>&nbsp; 
												&nbsp;
											</TD>
											<TD colSpan="2"><asp:dropdownlist id="DropVendorID" runat="server" Width="172px" AutoPostBack="False" onChange="getCity(this,document.Form1.lblPlace);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											</TD>
										</TR>
										<TR>
											<TD>&nbsp; Place</TD>
											<TD colSpan="2"><INPUT id="lblPlace" style="WIDTH: 170px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
													readOnly type="text" size="23" name="lblPlace" runat="server" class="FontStyle"></TD>
										</TR>
										<TR>
											<TD>&nbsp; Vehicle No&nbsp;
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter The Vehicle No"
													ControlToValidate="txtVehicleNo">*</asp:RequiredFieldValidator>
											</TD>
											<TD colSpan="2"><asp:textbox id="txtVehicleNo" runat="server" Width="170px" Height="20px" BorderStyle="Groove"
													CssClass="FontStyle" MaxLength="12"></asp:textbox></TD>
										</TR>
										<TR>
											<TD>&nbsp; Invoice No&nbsp;&nbsp;
												<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter The Vendor Invoice No"
													ControlToValidate="txtVInnvoiceNo">*</asp:RequiredFieldValidator></TD>
											<TD colSpan="2"><asp:textbox id="txtVInnvoiceNo" runat="server" Width="170px" Height="20px" BorderStyle="Groove"
													CssClass="FontStyle" MaxLength="9" onkeypress="return GetOnlyNumbers(this, event, false,false);"></asp:textbox></TD>
										</TR>
										<TR>
											<TD>&nbsp; Invoice Date&nbsp;
											</TD>
											<TD colSpan="2"><asp:textbox id="txtVInvoiceDate" runat="server" Width="173px" Height="20px" BorderStyle="Groove"
													ReadOnly="True" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtVInvoiceDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
														border="0"></A></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD align="center" colSpan="6"><FONT color="#990066"><STRONG><U>Products Details</U></STRONG></FONT></TD>
										</TR>
										<TR>
											<TD align="center"><FONT color="#990066">Product Type <FONT color="#ff0000">
														<asp:CompareValidator id="CompareValidator2" runat="server" ErrorMessage="Please Select the Product Type"
															ControlToValidate="DropType1" ValueToCompare="Type" Operator="NotEqual">*</asp:CompareValidator></FONT>
												</FONT>
											</TD>
											<TD align="center"><FONT color="#990066">Name&nbsp;
													<asp:CompareValidator id="CompareValidator3" runat="server" ErrorMessage="Please Select the Product Name"
														ControlToValidate="DropProd1" ValueToCompare="Select" Operator="NotEqual">*</asp:CompareValidator>
												</FONT>
											</TD>
											<TD align="center"><FONT color="#990066">Package</FONT></TD>
											<TD align="center"><FONT color="#990066">Qty <FONT color="#ff0000">
														<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter The Qty"
															ControlToValidate="txtQty1">*</asp:RequiredFieldValidator></FONT></FONT>
											</TD>
											<TD align="center"><FONT color="#990066">Rate</FONT></TD>
											<TD align="center"><FONT color="#990066">Amount</FONT></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropType1" runat="server" Width="100px" Height="17px" onchange="getProdName(this,document.Form1.DropProd1,document.Form1.DropPack1,document.Form1.txtRate1,document.Form1.txtProdName1,document.Form1.txtPack1,document.Form1.txtQty1,document.Form1.txtAmount1);"
													CssClass="FontStyle">
													<asp:ListItem Value="Type">Type</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="DropProd1" runat="server" Width="140px" Height="17px" onchange="getPack(document.Form1.DropType1,this,document.Form1.DropPack1,document.Form1.txtRate1,document.Form1.txtProdName1,document.Form1.txtPack1,document.Form1.txtQty1,document.Form1.txtAmount1);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtProdName1" style="WIDTH: 140px" type="hidden" name="txtProdName1" runat="server"></TD>
											<td><asp:dropdownlist id="DropPack1" runat="server" Width="100px" Height="17px" onchange="getStock(document.Form1.DropType1,document.Form1.DropProd1,this,document.Form1.txtRate1,document.Form1.txtPack1,document.Form1.txtQty1,document.Form1.txtAmount1);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtPack1" style="WIDTH: 100px" type="hidden" name="txtPack1" runat="server"></td>
											<TD><asp:textbox id="txtQty1" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtRate1" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtAmount1" runat="server" Width="80px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropType2" runat="server" Width="100px" onchange="getProdName(this,document.Form1.DropProd2,document.Form1.DropPack2,document.Form1.txtRate2,document.Form1.txtProdName2,document.Form1.txtPack2,document.Form1.txtQty2,document.Form1.txtAmount2);"
													CssClass="FontStyle" Height="17px">
													<asp:ListItem Value="Type">Type</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD>
												<P><asp:dropdownlist id="DropProd2" runat="server" Width="140px" Height="17px" onchange="getPack(document.Form1.DropType2,this,document.Form1.DropPack2,document.Form1.txtRate2,document.Form1.txtProdName2,document.Form1.txtPack2,document.Form1.txtQty2,document.Form1.txtAmount2);"
														CssClass="FontStyle">
														<asp:ListItem Value="Select">Select</asp:ListItem>
													</asp:dropdownlist><INPUT id="txtProdName2" style="WIDTH: 140px" type="hidden" name="txtProdName2" runat="server"></P>
											</TD>
											<td>
												<P><asp:dropdownlist id="DropPack2" runat="server" Width="100px" Height="17px" onchange="getStock(document.Form1.DropType2,document.Form1.DropProd2,this,document.Form1.txtRate2,document.Form1.txtPack2,document.Form1.txtQty2,document.Form1.txtAmount2);"
														CssClass="FontStyle">
														<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
													</asp:dropdownlist><INPUT id="txtPack2" style="WIDTH: 100px" type="hidden" name="txtPack2" runat="server"></P>
											</td>
											<TD><asp:textbox id="txtQty2" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtRate2" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtAmount2" runat="server" Width="80px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropType3" runat="server" Width="100px" onchange="getProdName(this,document.Form1.DropProd3,document.Form1.DropPack3,document.Form1.txtRate3,document.Form1.txtProdName3,document.Form1.txtPack3,document.Form1.txtQty3,document.Form1.txtAmount3);"
													CssClass="FontStyle" Height="17px">
													<asp:ListItem Value="Type">Type</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="DropProd3" runat="server" Width="140px" Height="17px" onchange="getPack(document.Form1.DropType3,this,document.Form1.DropPack3,document.Form1.txtRate3,document.Form1.txtProdName3,document.Form1.txtPack3,document.Form1.txtQty3,document.Form1.txtAmount3);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtProdName3" style="WIDTH: 140px" type="hidden" name="txtProdName3" runat="server"></TD>
											<td><asp:dropdownlist id="DropPack3" runat="server" Width="100px" Height="17px" onchange="getStock(document.Form1.DropType3,document.Form1.DropProd3,this,document.Form1.txtRate3,document.Form1.txtPack3,document.Form1.txtQty3,document.Form1.txtAmount3);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtPack3" style="WIDTH: 91px" type="hidden" name="txtPack3" runat="server"></td>
											<TD><asp:textbox id="txtQty3" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtRate3" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtAmount3" runat="server" Width="80px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropType4" runat="server" Width="100px" onchange="getProdName(this,document.Form1.DropProd4,document.Form1.DropPack4,document.Form1.txtRate4,document.Form1.txtProdName4,document.Form1.txtPack4,document.Form1.txtQty4,document.Form1.txtAmount4);"
													CssClass="FontStyle" Height="17px">
													<asp:ListItem Value="Type">Type</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="DropProd4" runat="server" Width="140px" Height="17px" onchange="getPack(document.Form1.DropType4,this,document.Form1.DropPack4,document.Form1.txtRate4,document.Form1.txtProdName4,document.Form1.txtPack4,document.Form1.txtQty4,document.Form1.txtAmount4);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtProdName4" style="WIDTH: 140px" type="hidden" name="txtProdName4" runat="server"></TD>
											<td><asp:dropdownlist id="DropPack4" runat="server" Width="100px" Height="17px" onchange="getStock(document.Form1.DropType4,document.Form1.DropProd4,this,document.Form1.txtRate4,document.Form1.txtPack4,document.Form1.txtQty4,document.Form1.txtAmount4);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtPack4" style="WIDTH: 91px" type="hidden" name="txtPack4" runat="server"></td>
											<TD><asp:textbox id="txtQty4" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtRate4" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtAmount4" runat="server" Width="80px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropType5" runat="server" Width="100px" onchange="getProdName(this,document.Form1.DropProd5,document.Form1.DropPack5,document.Form1.txtRate5,document.Form1.txtProdName5,document.Form1.txtPack5,document.Form1.txtQty5,document.Form1.txtAmount5);"
													CssClass="FontStyle" Height="17px">
													<asp:ListItem Value="Type">Type</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="DropProd5" runat="server" Width="140px" Height="17px" onchange="getPack(document.Form1.DropType5,this,document.Form1.DropPack5,document.Form1.txtRate5,document.Form1.txtProdName5,document.Form1.txtPack5,document.Form1.txtQty5,document.Form1.txtAmount5);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtProdName5" style="WIDTH: 140px" type="hidden" name="txtProdName5" runat="server"></TD>
											<td><asp:dropdownlist id="DropPack5" runat="server" Width="100px" Height="17px" onchange="getStock(document.Form1.DropType5,document.Form1.DropProd5,this,document.Form1.txtRate5,document.Form1.txtPack5,document.Form1.txtQty5,document.Form1.txtAmount5);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtPack5" style="WIDTH: 91px" type="hidden" name="txtPack5" runat="server"></td>
											<TD><asp:textbox id="txtQty5" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtRate5" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtAmount5" runat="server" Width="80px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropType6" runat="server" Width="100px" onchange="getProdName(this,document.Form1.DropProd6,document.Form1.DropPack6,document.Form1.txtRate6,document.Form1.txtProdName6,document.Form1.txtPack6,document.Form1.txtQty6,document.Form1.txtAmount6);"
													CssClass="FontStyle" Height="17px">
													<asp:ListItem Value="Type">Type</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="DropProd6" runat="server" Width="140px" Height="17px" onchange="getPack(document.Form1.DropType6,this,document.Form1.DropPack6,document.Form1.txtRate6,document.Form1.txtProdName6,document.Form1.txtPack6,document.Form1.txtQty6,document.Form1.txtAmount6);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtProdName6" style="WIDTH: 140px" type="hidden" name="txtProdName6" runat="server"></TD>
											<td><asp:dropdownlist id="DropPack6" runat="server" Width="100px" Height="17px" onchange="getStock(document.Form1.DropType6,document.Form1.DropProd6,this,document.Form1.txtRate6,document.Form1.txtPack6,document.Form1.txtQty6,document.Form1.txtAmount6);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtPack6" style="WIDTH: 91px" type="hidden" name="txtPack6" runat="server"></td>
											<TD><asp:textbox id="txtQty6" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtRate6" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtAmount6" runat="server" Width="80px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropType7" runat="server" Width="100px" onchange="getProdName(this,document.Form1.DropProd7,document.Form1.DropPack7,document.Form1.txtRate7,document.Form1.txtProdName7,document.Form1.txtPack7,document.Form1.txtQty7,document.Form1.txtAmount7);"
													CssClass="FontStyle" Height="17px">
													<asp:ListItem Value="Type">Type</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="DropProd7" runat="server" Width="140px" Height="17px" onchange="getPack(document.Form1.DropType7,this,document.Form1.DropPack7,document.Form1.txtRate7,document.Form1.txtProdName7,document.Form1.txtPack7,document.Form1.txtQty7,document.Form1.txtAmount7);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtProdName7" style="WIDTH: 140px" type="hidden" name="txtProdName7" runat="server"></TD>
											<TD><asp:dropdownlist id="DropPack7" runat="server" Width="100px" Height="17px" onchange="getStock(document.Form1.DropType7,document.Form1.DropProd7,this,document.Form1.txtRate7,document.Form1.txtPack7,document.Form1.txtQty7,document.Form1.txtAmount7);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtPack7" style="WIDTH: 91px" type="hidden" name="txtPack7" runat="server"></TD>
											<TD><asp:textbox id="txtQty7" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtRate7" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtAmount7" runat="server" Width="80px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropType8" runat="server" Width="100px" Height="17px" onchange="getProdName(this,document.Form1.DropProd8,document.Form1.DropPack8,document.Form1.txtRate8,document.Form1.txtProdName8,document.Form1.txtPack8,document.Form1.txtQty8,document.Form1.txtAmount8);"
													CssClass="FontStyle">
													<asp:ListItem Value="Type">Type</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="DropProd8" runat="server" Width="140px" Height="17px" onchange="getPack(document.Form1.DropType8,this,document.Form1.DropPack8,document.Form1.txtRate8,document.Form1.txtProdName8,document.Form1.txtPack8,document.Form1.txtQty8,document.Form1.txtAmount8);"
													CssClass="auto-style1">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtProdName8" style="WIDTH: 140px" type="hidden" name="txtProdName8" runat="server"></TD>
											<td><asp:dropdownlist id="DropPack8" runat="server" Width="100px" Height="17px" onchange="getStock(document.Form1.DropType8,document.Form1.DropProd8,this,document.Form1.txtRate8,document.Form1.txtPack8,document.Form1.txtQty8,document.Form1.txtAmount8);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist><INPUT id="txtPack8" style="WIDTH: 91px" type="hidden" name="txtPack8" runat="server"></td>
											<TD><asp:textbox id="txtQty8" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtRate8" onblur="calc()" runat="server" Width="52px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtAmount8" runat="server" Width="80px" BorderStyle="Groove" ReadOnly="True"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<TABLE style="WIDTH: 550px" cellpadding="0" cellspacing="0">
							<TR>
								<TD>Promo Scheme</TD>
								<TD><asp:textbox id="txtPromoScheme" runat="server" Width="230px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
								<TD>Grand Total</TD>
								<TD><asp:textbox id="txtGrandTotal" runat="server" Width="123px" BorderStyle="Groove" ReadOnly="True"
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Remark</TD>
								<TD>
									<asp:textbox id="txtRemark" runat="server" Width="230px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
								<TD>Cash Discount</TD>
								<TD><asp:textbox id="txtCashDisc" onblur="GetNetAmount()" runat="server" Width="67px" Height="22px"
										BorderStyle="Groove" CssClass="FontStyle" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										MaxLength="5"></asp:textbox><asp:dropdownlist id="DropCashDiscType" onblur="GetNetAmount()" runat="server" Width="56px" CssClass="FontStyle">
										<asp:ListItem Value="Rs" Selected="True">Rs.</asp:ListItem>
										<asp:ListItem Value="Per">%</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Message</TD>
								<TD>
									<asp:textbox id="txtMessage" runat="server" Width="230px" BorderStyle="Groove" ReadOnly="True"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD>Discount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtDisc" onblur="GetNetAmount()" runat="server" Width="67px" Height="22px" BorderStyle="Groove"
										CssClass="FontStyle" onkeypress="return GetOnlyNumbers(this, event, true,true);" MaxLength="6"></asp:textbox><asp:dropdownlist id="DropDiscType" onblur="GetNetAmount()" runat="server" Width="56px" CssClass="FontStyle">
										<asp:ListItem Value="Rs" Selected="True">Rs.</asp:ListItem>
										<asp:ListItem Value="Per">%</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD></TD>
								<TD>VAT
									<asp:radiobutton id="No" onclick="return GetNetAmount();" runat="server" GroupName="VAT"
										ToolTip="Not Applied"></asp:radiobutton>
									<asp:radiobutton id="Yes" onclick="return GetNetAmount();" runat="server" GroupName="VAT"
										ToolTip="Apply" Checked="True"></asp:radiobutton>
								</TD>
								<TD>
									<asp:textbox id="txtVAT" runat="server" Width="124px" BorderStyle="Groove" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD>Net Amount</TD>
								<TD><asp:textbox id="txtNetAmount" runat="server" Width="124px" BorderStyle="Groove" ReadOnly="True"
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Entry&nbsp;By</TD>
								<TD><asp:label id="lblEntryBy" runat="server"></asp:label></TD>
								<TD align="right" colSpan="2"></TD>
							</TR>
							<TR>
								<TD>Entry Date &amp; Time&nbsp;&nbsp;&nbsp;
								</TD>
								<TD><asp:label id="lblEntryTime" runat="server"></asp:label></TD>
								<TD align="right" colSpan="2"><asp:button id="btnSave" runat="server" Width="70px" Text="Save" ForeColor="White" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;<asp:Button id="btnPrint" runat="server" Width="70px" ForeColor="White" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Print" CausesValidation="False"></asp:Button>&nbsp;&nbsp;<asp:button id="btnDelete" runat="server" Width="70px" Text="Delete" ForeColor="White" BackColor="ForestGreen"
										BorderColor="ForestGreen" onmouseup="checkDelRec()"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
