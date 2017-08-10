<%@ Page language="c#" Codebehind="cashbill.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Accounts.cashbill" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Import namespace="RMG"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro : Cash Billing</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<script language="javascript" id="Cash" src="../../Sysitem/Js/Cash.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript">
		function checkProd()
		{
		var packArray = new Array();		
		var index1 = document.all.DropType1.selectedIndex;
		var index2 = document.all.DropProd1.selectedIndex;
		var index3 = document.all.DropPack1.selectedIndex;
		
		var index4 = document.all.DropType2.selectedIndex;
		var index5 = document.all.DropProd2.selectedIndex;
		var index6 = document.all.DropPack2.selectedIndex;
		
		
		
		if(index3==-1 )
		packArray[0]=document.all.DropType1.options[index1].text+document.all.DropProd1.options[index2].text
		else
		packArray[0]=document.all.DropType1.options[index1].text+document.all.DropProd1.options[index2].text+document.all.DropPack1.options[index3].text;
		
		if(index6==-1)
		packArray[1]=document.all.DropType2.options[index4].text+document.all.DropProd2.options[index5].text
		else
		packArray[1]=document.all.DropType2.options[index4].text+document.all.DropProd2.options[index5].text+document.all.DropPack2.options[index6].text;
		
		
		/*if(index9==-1 )
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
		packArray[7]=document.Form1.DropType8.options[index22].text+document.Form1.DropProd8.options[index23].text+document.Form1.DropPack8.options[index24].text;*/
	
		var count = 0;

		for (var i=0;i<2;i++)
		{
		for (var j=0;j<2;j++)
		{

		if(packArray[i]==packArray[j] && packArray[i]!="TypeSelect")
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
		function makeRound(t)
	{

	var str = t.value;
	if(str != "")
	{
	str = eval(str)*100;

	str  = Math.round(str);

	str = eval(str)/100;

	t.value = str;
	//alert(str)
	}
	
	}
		
	  function check(slipNo)
	  {
	  var start = document.all.Txtstart.value;
	  var end  = document.all.TxtEnd.value;
	  var slip = slipNo.value;
	  var slip1 = document.all.SlipNo.value;  
	  var temp = document.all.txtSlipTemp.value;
	  var arr = new Array();
	  arr = temp.split("#");
	  
	    

	  if (eval(slip)<eval(start) || eval(slip)>eval(end))
	  {
	  alert("Invalid Slip No.");
	  slipNo.value="";
	  return false;	  
	  }   
	  
	  for(var i=0; i<arr.length; i++)
	  {
	     if(eval(slip1) != eval(slip))
	     {
	        if(eval(slip) == eval(arr[i]))
	        {
	           alert("Slip No. already Used.");
	          return false;
	        }
	        else
	         continue;
	     }
	  } 
	
	  }
	 
	function calc(txtQty,txtAvstock,txtRate,txtTempQty)
	{	
		var sarr = new Array()
		var temp ="";
		sarr = txtAvstock.value.split(" ")
		if((txtQty.value=="" || txtQty.value=="0") && (txtRate.value!=""))
		{
			alert("Please insert the Quantity")
			return
		}
		if(document.all.btnEdit == null)
		{
			var temp2 = txtTempQty.value;
			if(eval(txtQty.value) > eval(txtTempQty.value))
			{
				temp = eval(txtQty.value) - eval(txtTempQty.value);
				if(eval(temp) > eval(sarr[0]))
				{
					alert("Insufficient Stock")
					txtQty.value=txtTempQty.value;
					txtQty.focus();
					return
				}
			}
		}
		else
		{
			if(eval(txtQty.value)>eval(sarr[0]))
			{
				alert("Insufficient Stock")
				txtQty.value="";
				txtQty.focus()
				return
			}
		}
	 	document.all.txtAmount1.value=document.all.txtQty1.value*document.all.txtRate1.value	
		if(document.all.txtAmount1.value==0)
			document.all.txtAmount1.value=""
		else
			makeRound(document.all.txtAmount1);
		document.all.txtAmount2.value= document.all.txtQty2.value*document.all.txtRate2.value	
 		if(document.all.txtAmount2.value==0)
			document.all.txtAmount2.value=""
		else
			makeRound(document.all.txtAmount2);
		GetGrandTotal()
		// GetNetAmount()
	}	
	function GetGrandTotal()
	{
	 var GTotal=0
	 if(document.all.txtAmount1.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount1.value)
	 if(document.all.txtAmount2.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount2.value)
	 //GTotal = Math.round(GTotal);
	 document.all.txtGrandTotal.value=GTotal ;
	 makeRound(document.all.txtGrandTotal);
	}	
	
	function GetCashDiscount()
	{
	 var CashDisc=document.all.txtCashDisc.value
	 if(CashDisc=="" || isNaN(CashDisc))
		CashDisc=0
	
		if(document.all.DropCashDiscType.value=="Per")
			CashDisc=document.all.txtGrandTotal.value*CashDisc/100 
		document.all.txtVatValue.value = "";	
		document.all.txtVatValue.value = eval(document.all.txtGrandTotal.value) - eval(CashDisc);	
					    
	}
	
	function FindTankName()
	{
	
	    var f = document.forms[0]
		for(var i=0;i<f.length;i++)
		{ 
		/***********
			if(document.Form1.btnEdit == null )
			{
				if(f.txttankdd11.value==f.elements[i].value)
				{
					f.elements[i].checked=true
				}
			}
		************/
	   		if(f.elements[i].checked)
	 		{  
				f.txttankdd.value=f.elements[i].value
				//alert(f.elements[i].id)
				return
			}
		}
	}
	
	function checkDelRec()
	{
		if(document.all.btnEdit == null)
		{
		    if (document.all.dropInvoiceNo.value != "Select")
			{
				if(confirm("Do You Want To Delete The Product"))
				    document.all.tempInfo.value = "Yes";
				else
				    document.all.tempInfo.value = "No";
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
		if (document.all.tempInfo.value == "Yes")
		    document.all.submit();
	}
	
	function CalcQty(amt,qty,stock,rate,tempqty,type,pack)
	{
		if(rate.value!="")
		{
			if(amt.value!="" && amt.value!=0)
			{
				//qty.value = eval(amt.value)/eval(rate.value);
				var rr = eval(amt.value)/eval(rate.value);
				if(type.value=="Fuel" || pack.value=="Loose Oil")
				{
					qty.value=rr;
					makeRound(qty);
				}	
				else
					qty.value=Math.ceil(rr)
				GetGrandTotal()
			}
		}
		else
			alert("Please Select Product");
	}
</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="tmpQty4" style="Z-INDEX: 113; LEFT: 287px; WIDTH: 10px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty4" runat="server"><INPUT id="txttottank" style="Z-INDEX: 127; LEFT: 468px; WIDTH: 10px; POSITION: absolute; TOP: 11px; HEIGHT: 22px"
				type="hidden" size="1" name="txttottank" runat="server"><INPUT id="txttankdd11" style="Z-INDEX: 125; LEFT: 242px; WIDTH: 10px; POSITION: absolute; TOP: 15px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="tmpQty5" style="Z-INDEX: 114; LEFT: 302px; WIDTH: 10px; POSITION: absolute; TOP: 12px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty5" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><INPUT id="TxtVen" style="Z-INDEX: 100; LEFT: -544px; POSITION: absolute; TOP: -16px" type="text"
				name="TxtVen" runat="server"> <INPUT id="TextBox1" style="Z-INDEX: 101; LEFT: -248px; WIDTH: 76px; POSITION: absolute; TOP: -40px; HEIGHT: 22px"
				 type="text" size="7" name="TextBox1" runat="server"> <INPUT id="TxtEnd" style="Z-INDEX: 102; LEFT: -208px; WIDTH: 52px; POSITION: absolute; TOP: -24px; HEIGHT: 22px"
				type="text" size="3" name="TxtEnd" runat="server"><INPUT id="Txtstart" style="Z-INDEX: 103; LEFT: -336px; WIDTH: 83px; POSITION: absolute; TOP: -16px; HEIGHT: 22px"
				type="text" size="8" name="Txtstart" runat="server"> <INPUT id="TxtCrLimit" style="Z-INDEX: 104; LEFT: -448px; WIDTH: 70px; POSITION: absolute; TOP: -16px; HEIGHT: 22px"
				accessKey="TxtEnd" type="text" size="6" name="TxtCrLimit" runat="server">
			<asp:textbox id="TextSelect" style="Z-INDEX: 105; LEFT: 189px; POSITION: absolute; TOP: 18px"
				runat="server" Visible="False" Width="10px" Height="22px"></asp:textbox><asp:textbox id="TextBox2" style="Z-INDEX: 106; LEFT: 228px; POSITION: absolute; TOP: 16px" runat="server"
				Visible="False" Width="10px" Height="22px" BorderStyle="Groove"></asp:textbox><asp:textbox id="TxtCrLimit1" style="Z-INDEX: 107; LEFT: 165px; POSITION: absolute; TOP: 17px"
				runat="server" Visible="False" Width="10px" Height="22px" BorderStyle="Groove" ></asp:textbox><INPUT id="temptext" style="Z-INDEX: 108; LEFT: 152px; WIDTH: 10px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="temptext" runat="server">
			<asp:textbox id="txtTempQty1" style="Z-INDEX: 109; LEFT: 201px; POSITION: absolute; TOP: 16px"
				runat="server" Visible="False" Width="10px" Height="22px"></asp:textbox><asp:textbox id="txtTempQty2" style="Z-INDEX: 110; LEFT: 215px; POSITION: absolute; TOP: 15px"
				runat="server" Visible="False" Width="10px" Height="22px"></asp:textbox><INPUT id="tmpQty1" style="Z-INDEX: 111; LEFT: 255px; WIDTH: 10px; POSITION: absolute; TOP: 17px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty1" runat="server"> <INPUT id="tmpQty2" style="Z-INDEX: 112; LEFT: 270px; WIDTH: 10px; POSITION: absolute; TOP: 14px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty2" runat="server"><INPUT id="txtVatRate" style="Z-INDEX: 116; LEFT: 318px; WIDTH: 10px; POSITION: absolute; TOP: 14px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatRate" runat="server"> <INPUT id="txtVatValue" style="Z-INDEX: 119; LEFT: 352px; WIDTH: 10px; POSITION: absolute; TOP: 13px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatValue" runat="server"> <INPUT id="txtSlipTemp" style="Z-INDEX: 121; LEFT: 382px; WIDTH: 10px; POSITION: absolute; TOP: 12px; HEIGHT: 22px"
				type="hidden" size="1" name="txtSlipTemp" runat="server"><INPUT id="SlipNo" style="Z-INDEX: 122; LEFT: 437px; WIDTH: 5px; POSITION: absolute; TOP: 13px; HEIGHT: 22px"
				type="hidden" size="1" name="SlipNo" runat="server"> <INPUT id="Hidden2" style="Z-INDEX: 117; LEFT: 367px; WIDTH: 5px; POSITION: absolute; TOP: 14px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatValue" runat="server"> <INPUT id="txttankno1" style="Z-INDEX: 120; LEFT: 401px; WIDTH: 6px; POSITION: absolute; TOP: 15px; HEIGHT: 22px"
				type="hidden" size="1" name="txttankno1" runat="server"><INPUT id="txttankno2" style="Z-INDEX: 123; LEFT: 416px; WIDTH: 10px; POSITION: absolute; TOP: 12px; HEIGHT: 22px"
				type="hidden" size="1" name="txttankno2" runat="server"> <INPUT id="lblVehicleNo" style="Z-INDEX: 124; LEFT: 451px; WIDTH: 10px; POSITION: absolute; TOP: 12px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT style="Z-INDEX: 126; LEFT: 178px; WIDTH: 10px; POSITION: absolute; TOP: 17px; HEIGHT: 22px"
				type="hidden" size="1" name="txttankdd"><input id=tempInfo name=tempInfo runat=server type=hidden style="width:0px;">
			<table height="288" width="778" align=center>
				<TBODY>
					<tr>
						<th align="center" colSpan="3">
							<font color="#006400">Cash Billing</font>&nbsp;
							<hr>
							<asp:label id="lblMessage" runat="server" Font-Size="8pt" ForeColor="DarkGreen"></asp:label></th>
					</tr>
					<tr>
					<td>Color of Red for Cash Sales, Blue for Credit Sales & Maroon for TotalLtr</td>
					</tr>
					<tr><td>
						<%
						for(int i=0;i<count;i++)
						{%>
								<label id=lbl<%=count%> style="FONT-WEIGHT: bold; COLOR: #009900"><%=ProdName[i]%></label>&nbsp;:&nbsp;
								<label id=lbl1<%=count%> style="color:red"><%=GenUtil.strNumericFormat(Cash[i])%></label>,
								<label id=lbl2<%=count%> style="color:blue"><%=GenUtil.strNumericFormat(Sales[i])%></label>,
								<label id=lbl3<%=count%> style="color:maroon"><%=GenUtil.strNumericFormat(Quantity11[i])%></label>&nbsp;
									
						<%}%>
								</td></tr>
					<tr>
						<td align="center">
							<TABLE style="WIDTH: 770px" cellSpacing="1" borderColorDark="#ffffcc" borderColorLight="#009966"
								border="1">
								<TBODY>
									<TR>
										<TD align="center" width="350">
											<TABLE cellSpacing="1" cellPadding="0">
												<TR>
													<TD>Invoice No&nbsp;&nbsp;&nbsp; <STRONG>:</STRONG></TD>
													<TD vAlign="top"><asp:dropdownlist CssClass=fontstyle id="dropInvoiceNo" runat="server" Width="100px" onchange="FindTankName();"
															AutoPostBack="True">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><asp:label id="lblInvoiceNo" runat="server" Width="107px" ForeColor="Blue"></asp:label><asp:Label ID=tempInvoice Runat=server ForeColor="red" Visible=false Font-Bold=True></asp:Label><asp:button id="btnEdit" runat="server" Width="25px" ForeColor="White" BorderColor="DarkSeaGreen"
															BackColor="ForestGreen" CausesValidation="False" Text="..." ToolTip="Click For Edit"></asp:button></TD>
												</TR>
												<TR>
													<TD>Invoice Date <STRONG>:</STRONG> &nbsp;</TD>
													<TD><asp:TextBox id="lblInvoiceDate" BorderStyle="Groove" runat="server" Width=65 CssClass=fontstyle ></asp:TextBox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.lblInvoiceDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
															border="0"></A></TD>
												</TR>
											</TABLE>
										</TD>
										<TD align="center" width="400">
											<TABLE cellSpacing="0" cellPadding="0">
												<TBODY>
													<TR>
														<TD width="100">Customer Name</TD>
														<td><asp:textbox  id="txtcustname" MaxLength=25 CssClass=fontstyle Width="168px" BorderStyle="Groove" Runat="server"></asp:textbox></td>
													<tr>
														<TD>Vehicle No</TD>
														<TD><asp:textbox  CssClass=fontstyle id="txtVehicleNo" MaxLength=12 runat="server" Width="168px" BorderStyle="Groove"></asp:textbox></TD>
													</tr>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD align="center" colSpan="2">
											<TABLE cellSpacing="0" cellPadding="0" width="750">
												<TBODY>
													<TR>
														<TD align="center" colSpan="7"><FONT color="#006400"><STRONG><U>Product &nbsp;Details</U></STRONG></FONT></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 16px" align="center"><FONT color="darkgreen">Product&nbsp;Type<font color="red">*</font>&nbsp;<asp:comparevalidator id="Comparevalidator1" runat="server" ValueToCompare="Type" Operator="NotEqual"
																	ErrorMessage="Please Select Category" ControlToValidate="DropType1"><font color="red">*</font></asp:comparevalidator></FONT></TD>
														<TD style="WIDTH: 120px" align="center"><FONT color="darkgreen">Name
																<asp:comparevalidator id="CompareValidator4" runat="server" ValueToCompare="Select" Operator="NotEqual"
																	ErrorMessage="Please Select atleast One Product Name" ControlToValidate="DropProd1">*</asp:comparevalidator></FONT></TD>
														<TD style="WIDTH: 2px" align="center"><FONT color="darkgreen">Package</FONT></TD>
														<TD align="center"><FONT color="darkgreen">Qty<font color="red">*</font>
																<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Please Fill Quantity"
																	ControlToValidate="txtQty1"><font color="red">*</font></asp:requiredfieldvalidator></FONT></TD>
														<TD align="center"><FONT color="darkgreen">Available Stock</FONT></TD>
														<TD align="center"><FONT color="darkgreen">Rate</FONT></TD>
														<TD align="center"><FONT color="darkgreen">Amount</FONT></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 16px"><asp:dropdownlist CssClass=fontstyle id="DropType1" runat="server" Width="91px" Height="17px" onchange="getProdName(this,document.all.DropProd1,document.all.DropPack1,document.all.txtAvStock1,document.all.txtRate1,document.all.txtProdName1,document.all.txtPack1,document.all.txtQty1,document.all.txtAmount1)">
																<asp:ListItem Value="Type">Type</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD style="WIDTH: 275px"><asp:dropdownlist CssClass=fontstyle id="DropProd1" runat="server" Width="275px" Height="17px" onchange="getPack(document.all.DropType1,this,document.all.DropPack1,document.all.txtAvStock1,document.all.txtRate1,document.all.txtProdName1,document.all.txtPack1,document.all.txtQty1,document.all.txtAmount1)">
																<asp:ListItem>select</asp:ListItem>
															</asp:dropdownlist><INPUT id="txtProdName1" style="WIDTH: 275px" type="hidden" name="txtProdName1" runat="server"></TD>
														<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack1" CssClass=fontstyle runat="server" Width="91px" Height="17px" onchange="getStock(document.all.DropType1,document.all.DropProd1,this,document.all.txtAvStock1,document.all.txtRate1,document.all.txtPack1,document.all.txtQty1,document.all.txtAmount1)"></asp:dropdownlist><INPUT id="txtPack1" style="WIDTH: 91px" type="hidden" name="txtPack1" runat="server"></TD>
														<TD align="center"><asp:textbox CssClass=fontstyle onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty1" onblur="calc(this,document.all.txtAvStock1,document.all.txtRate1,document.all.tmpQty1)"
																runat="server" Width="52px" BorderStyle="Groove" onchange="FindTankName()" MaxLength=5></asp:textbox></TD>
														<TD><asp:textbox CssClass=fontstyle id="txtAvStock1" runat="server" Width="110px" BorderStyle="Groove" 
																Enabled="False"></asp:textbox></TD>
														<TD><asp:textbox CssClass=fontstyle id="txtRate1" runat="server" Width="52px" BorderStyle="Groove" ></asp:textbox></TD>
														<TD><asp:textbox CssClass=fontstyle id="txtAmount1" runat="server" Width="79px" BorderStyle="Groove" onblur="CalcQty(this,document.all.txtQty1,document.all.txtAvStock1,document.all.txtRate1,document.all.tmpQty1,document.all.DropType1,document.all.DropPack1)"></asp:textbox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 16px"><asp:dropdownlist CssClass=fontstyle id="DropType2" runat="server" Width="91px" onchange="getProdName(this,document.all.DropProd2,document.all.DropPack2,document.all.txtAvStock2,document.all.txtRate2,document.all.txtProdName2,document.all.txtPack2,document.all.txtQty2,document.all.txtAmount2)" Height="17px">
																<asp:ListItem Value="Type">Type</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD style="WIDTH: 275px"><asp:dropdownlist CssClass=fontstyle id="DropProd2" runat="server" Width="275px" Height="17px" onchange="getPack(document.all.DropType2,this,document.all.DropPack2,document.all.txtAvStock2,document.all.txtRate2,document.all.txtProdName2,document.all.txtPack2,document.all.txtQty2,document.all.txtAmount2)">
																<asp:ListItem Value="Select"></asp:ListItem>
															</asp:dropdownlist><INPUT id="txtProdName2" style="WIDTH: 275px" type="hidden" name="txtProdName2" runat="server"></TD>
														<TD style="WIDTH: 2px"><asp:dropdownlist CssClass=fontstyle id="DropPack2" runat="server" Width="91px" Height="17px" onchange="getStock(document.all.DropType2,document.all.DropProd2,this,document.all.txtAvStock2,document.all.txtRate2,document.all.txtPack2,document.all.txtQty2,document.all.txtAmount2)"></asp:dropdownlist><INPUT id="txtPack2" style="WIDTH: 91px" type="hidden" name="txtPack2" runat="server"></TD>
														<TD><asp:textbox CssClass=fontstyle onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty2" onblur="calc(this,document.all.txtAvStock2,document.all.txtRate2,document.all.tmpQty2)"
																runat="server" Width="52px" BorderStyle="Groove" MaxLength=5></asp:textbox></TD>
														<TD align="center"><asp:textbox CssClass=fontstyle id="txtAvStock2" runat="server" Width="110px" BorderStyle="Groove" 
																Enabled="False"></asp:textbox></TD>
														<TD><asp:textbox CssClass=fontstyle id="txtRate2" runat="server" Width="52px" BorderStyle="Groove" ></asp:textbox></TD>
														<TD><asp:textbox CssClass=fontstyle id="txtAmount2" runat="server" Width="79px" BorderStyle="Groove" onblur="CalcQty(this,document.all.txtQty2,document.all.txtAvStock2,document.all.txtRate2,document.all.tmpQty2,document.all.DropType2,document.all.DropPack2)"></asp:textbox></TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
									<tr>
										<td align="center" colSpan="2">
											<TABLE style="WIDTH: 754px; HEIGHT: 30px" width="754">
												<TR>
													<td style="WIDTH: 80px">&nbsp;Remark</td>
													<TD style="WIDTH: 372px">
														<P><asp:textbox CssClass=fontstyle id="txtRemark" runat="server" Width="370px" BorderStyle="Groove"></asp:textbox></P>
													</TD>
													<TD style="WIDTH: 132px" align="right">Net Amount</TD>
													<TD align="right"><asp:textbox CssClass=fontstyle id="txtGrandTotal" runat="server" Width="124px" BorderStyle="Groove" ></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
								</TBODY>
							</TABLE>
					<TR>
						<td align="right"><asp:button id="btnSave" runat="server" Width="80px" ForeColor="White" BorderColor="DarkSeaGreen"
								BackColor="ForestGreen" Text="Save"></asp:button>&nbsp;<asp:button id="Button1" runat="server" Width="80px" ForeColor="White" BorderColor="DarkSeaGreen"
								BackColor="ForestGreen" Text="Print" CausesValidation="False"></asp:button>&nbsp;<asp:Button id="btnPrePrint" runat="server" Width="80px" ForeColor="White" Text="PrePrint" CausesValidation="False"
								BackColor="ForestGreen" BorderColor="DarkSeaGreen"></asp:Button>&nbsp;<asp:button id="btnDelete" runat="server" Width="80px" ForeColor="White" BorderColor="DarkSeaGreen"
								BackColor="ForestGreen" Text="Delete" onmouseup="checkDelRec()" CausesValidation=False></asp:button>
						</td>
					</TR>
					<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td></tr></TBODY></table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
