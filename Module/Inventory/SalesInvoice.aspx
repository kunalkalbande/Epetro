<%@ Page language="c#" Codebehind="SalesInvoice.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.SalesInvoice" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Sales Invoice</title>
		<meta content="False" name="vs_showGrid"> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<script language="javascript" id="sales" src="../../Sysitem/Js/Sales.js"></script>
		<script language="javascript" id="Fuel" src="../../Sysitem/Js/Fuel.js"></script>
		<meta content="False" name="vs_snapToGrid">
		<script language="javascript">
		function checkProd()
		{
		var packArray = new Array();		
		var index1 = document.all.DropType1.selectedIndex;
		var index2 = document.all.DropProd1.selectedIndex;
		var index3 = document.all.DropPack1.selectedIndex;
		
		var index4 = document.all.DropType2.selectedIndex;
		var index5 = document.all.DropProd2.selectedIndex;
		var index6 = document.all.DropPack2.selectedIndex;
		
		var index7 = document.all.DropType3.selectedIndex;
		var index8 = document.all.DropProd3.selectedIndex;
		var index9 = document.all.DropPack3.selectedIndex;
		
		var index10 = document.all.DropType4.selectedIndex;
		var index11 = document.all.DropProd4.selectedIndex;
		var index12 = document.all.DropPack4.selectedIndex;
		
		var index13 = document.all.DropType5.selectedIndex;
		var index14 = document.all.DropProd5.selectedIndex;
		var index15 = document.all.DropPack5.selectedIndex;
		
		var index16 = document.all.DropType6.selectedIndex;
		var index17 = document.all.DropProd6.selectedIndex;
		var index18 = document.all.DropPack6.selectedIndex;
		
		var index19 = document.all.DropType7.selectedIndex;
		var index20 = document.all.DropProd7.selectedIndex;
		var index21 = document.all.DropPack7.selectedIndex;
		
		var index22 = document.all.DropType8.selectedIndex;
		var index23 = document.all.DropProd8.selectedIndex;
		var index24 = document.all.DropPack8.selectedIndex;
		
		if(index3==-1 )
		packArray[0]=document.all.DropType1.options[index1].text+document.all.DropProd1.options[index2].text
		else
		packArray[0]=document.all.DropType1.options[index1].text+document.all.DropProd1.options[index2].text+document.all.DropPack1.options[index3].text;
		
		if(index6==-1)
		packArray[1]=document.all.DropType2.options[index4].text+document.all.DropProd2.options[index5].text
		else
		packArray[1]=document.all.DropType2.options[index4].text+document.all.DropProd2.options[index5].text+document.all.DropPack2.options[index6].text;
		
		
		if(index9==-1 )
		packArray[2]=document.all.DropType3.options[index7].text+document.all.DropProd3.options[index8].text;
		else
		packArray[2]=document.all.DropType3.options[index7].text+document.all.DropProd3.options[index8].text+document.all.DropPack3.options[index9].text;
	
		
		if(index12==-1)
		packArray[3]=document.all.DropType4.options[index10].text+document.all.DropProd4.options[index11].text
		else
		packArray[3]=document.all.DropType4.options[index10].text+document.all.DropProd4.options[index11].text+document.all.DropPack4.options[index12].text;
		
		
		if(index15==-1)
		packArray[4]=document.all.DropType5.options[index13].text+document.all.DropProd5.options[index14].text;
		else
		packArray[4]=document.all.DropType5.options[index13].text+document.all.DropProd5.options[index14].text+document.all.DropPack5.options[index15].text;

		
		if(index18==-1)
		packArray[5]=document.all.DropType6.options[index16].text+document.all.DropProd6.options[index17].text;
		else
		packArray[5]=document.all.DropType6.options[index16].text+document.all.DropProd6.options[index17].text+document.all.DropPack6.options[index18].text;
		
		
		if(index21==-1)
		packArray[6]=document.all.DropType7.options[index19].text+document.all.DropProd7.options[index20].text;
		else
		packArray[6]=document.all.DropType7.options[index19].text+document.all.DropProd7.options[index20].text+document.all.DropPack7.options[index21].text;
		
		
		if(index24==-1)
		packArray[7]=document.all.DropType8.options[index22].text+document.all.DropProd8.options[index23].text;
		else
		packArray[7]=document.all.DropType8.options[index22].text+document.all.DropProd8.options[index23].text+document.all.DropPack8.options[index24].text;
	
		var count = 0;

		for (var i=0;i<8;i++)
		{
		for (var j=0;j<8;j++)
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
		if(eval(slipNo.value)==0)
		{
			alert("Invalid Slip No.");
			slipNo.value="";
			//slipNo.focus();
			return false;
		}
		var start = document.all.Txtstart.value;
		var end  = document.all.TxtEnd.value;
		var slip = slipNo.value;
		var slip1 = document.all.SlipNo.value;  
		var temp = document.all.txtSlipTemp.value;
		//***
		var k=0;
		var endno = new Array();
		var sno = new Array();
		endno = end.split("#");
		sno = start.split(":");
		for(var j=0; j<sno.length; j++)
		{
			if(eval(slip1) != eval(slip))
			{
				//k=0;
				if(eval(slip) >= eval(sno[j]) && eval(slip) <= eval(endno[j]))
				{
					k=1;
					break;
					//alert("Slip No. already Used.");
					//return false;
				}
			}
			else
				k=1;
		} 
		if(k==0)
	    {
			alert("Invalid Slip No.");
	        slipNo.value="";
	        //slipNo.focus();
	        return false;
	    }
		//***
		var arr = new Array();
		arr = temp.split("#");
	 
		//if (eval(slip)<eval(start) || eval(slip)>eval(end))
		//{
		//alert("Invalid Slip No.");
		//slipNo.value="";
		//return false;	  
		//}   
	  
		for(var i=0; i<arr.length; i++)
		{
			if(eval(slip1) != eval(slip))
			{
				if(eval(slip) == eval(arr[i]))
				{
					alert("Slip No. already Used.");
					slipNo.value="";
					return false;
				}
				else
					continue;
			}
		} 
	}
	 
	function calc(txtQty,txtAvstock,txtRate,txtTempQty,ProdName,PackType)
	{	
		var sarr = new Array()
		var temp ="";
		//******
		var max=document.all.tempminmax.value;
		//alert(max)
		var minmaxarr = new Array()
		var maxarr = new Array()
		var vmm=""
		minmaxarr = max.split("~")
	 	//******
		sarr = txtAvstock.value.split(" ")
		if((txtQty.value=="" || txtQty.value=="0") && (txtRate.value!=""))
		{
			alert("Please insert the Quantity")
			return
		}
		if(document.all.btnEdit == null )
		{
			var temp2 = txtTempQty.value;
			if(eval(txtQty.value) > eval(txtTempQty.value))
			{
				temp = eval(txtQty.value) - eval(txtTempQty.value);
				if(eval(temp) > eval(sarr[0]))
				{
					alert("Insufficient Stock")
					txtQty.value=txtTempQty.value;
					txtQty.focus()
					return
				}
				//*****
				for(var i=0;i<minmaxarr.length;i++)
				{
					vmm=minmaxarr[i]
					maxarr=vmm.split(":")
					//alert(ProdName.value+" "+maxarr[0]+" "+PackType.value+" "+maxarr[1])
					if(ProdName.value==maxarr[0] && PackType.value==maxarr[1]) 
					{
						if(eval(eval(sarr[0])-eval(txtQty.value)+eval(txtTempQty.value)) <= eval(maxarr[4]))
						{
							alert("Quantity of ''"+maxarr[0]+"'' is Below The Minimum Level") 
						}
					}
				}
				//*****/
			}
		}
		else
		{
			if(eval(txtQty.value)>eval(sarr[0]))
			{
				alert("Insufficient Stock")
				txtQty.value=""
				txtQty.focus()
				return
			}
			//*****
			for(var i=0;i<minmaxarr.length;i++)
			{
				vmm=minmaxarr[i]
				maxarr=vmm.split(":")
				//alert(ProdName.value+" "+maxarr[0]+" "+PackType.value+" "+maxarr[1])
				if(ProdName.value==maxarr[0] && PackType.value==maxarr[1]) 
				{
					if(eval(eval(sarr[0])-eval(txtQty.value)) <= eval(maxarr[4]))
					{
						alert("Quantity of ''"+maxarr[0]+"'' is Below The Minimum Level") 
					}
				}
			}
			//*****
		}
		
		document.all.txtAmount1.value=document.all.txtQty1.value*document.all.txtRate1.value	
		if(document.all.txtAmount1.value==0)
			document.all.txtAmount1.value=""
		else
			makeRound(document.all.txtAmount1)
		document.all.txtAmount2.value= document.all.txtQty2.value*document.all.txtRate2.value	
 		if(document.all.txtAmount2.value==0)
			document.all.txtAmount2.value=""
		else
			makeRound(document.all.txtAmount2)
		document.all.txtAmount3.value= document.all.txtQty3.value*document.all.txtRate3.value	
		if(document.all.txtAmount3.value==0)
			document.all.txtAmount3.value=""
		else
			makeRound(document.all.txtAmount3)
		document.all.txtAmount4.value= document.all.txtQty4.value*document.all.txtRate4.value	
		if(document.all.txtAmount4.value==0)
			document.all.txtAmount4.value=""
		else
			makeRound(document.all.txtAmount4)
		document.all.txtAmount5.value= document.all.txtQty5.value*document.all.txtRate5.value	
		if(document.all.txtAmount5.value==0)
			document.all.txtAmount5.value=""
		else
			makeRound(document.all.txtAmount5)
		document.all.txtAmount6.value= document.all.txtQty6.value*document.all.txtRate6.value	
		if(document.all.txtAmount6.value==0)
			document.all.txtAmount6.value=""
		else
			makeRound(document.all.txtAmount6)
		document.all.txtAmount7.value= document.all.txtQty7.value*document.all.txtRate7.value	
		if(document.all.txtAmount7.value==0)
			document.all.txtAmount7.value=""
		else
			makeRound(document.all.txtAmount7)
		document.all.txtAmount8.value= document.all.txtQty8.value*document.all.txtRate8.value	
		if(document.all.txtAmount8.value==0)
			document.all.txtAmount8.value=""
		else
			makeRound(document.all.txtAmount8)
		GetGrandTotal()
		GetNetAmount()
	}	
	
	function GetGrandTotal()
	{
	 var GTotal=0
	 if(document.all.txtAmount1.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount1.value)
	 if(document.all.txtAmount2.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount2.value)
	 if(document.all.txtAmount3.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount3.value)
	 if(document.all.txtAmount4.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount4.value)
	 if(document.all.txtAmount5.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount5.value)
	 if(document.all.txtAmount6.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount6.value)
	 if(document.all.txtAmount7.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount7.value)
	 if(document.all.txtAmount8.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount8.value)
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
	
	function GetVatAmount()
	{
	    GetCashDiscount()
	    
	    if(document.all.No.checked)
	    {
	       document.all.txtVAT.value = "";
	      
	    } 
	    else
	    {
	    var vat_rate = document.all.txtVatRate.value
	   // alert(vat_rate);
	    if(vat_rate == "")
	       vat_rate = 0;
	     var vat = document.all.txtVatValue.value    
	         if(vat == "" || isNaN(vat))
	       vat = 0;
	       //alert("disc: "+vat)
	     var vat_amount = vat * vat_rate/100
	    // alert("vat_amt : "+vat_amount)
	     document.all.txtVAT.value = vat_amount
	     makeRound(document.all.txtVAT)
	    
	     
	     document.all.txtVatValue.value = eval(vat) + eval(vat_amount)
	    // alert("total :"+document.Form1.txtVatValue.value)
	     
	       
	    }
	
	}
	
	function GetNetAmount()
	{
		var vat_value = 0;
		if(document.all.No.checked)
		{
			GetCashDiscount()
			vat_value = document.all.txtVatValue.value;
			document.all.txtVAT.value = "";
	    }
	    else
	    {
			GetVatAmount()
			vat_value = document.all.txtVatValue.value;
	    }
	    
	    if(vat_value=="" || isNaN(vat_value))
			vat_value=0
		var Disc=document.all.txtDisc.value
		if(Disc=="" || isNaN(Disc))
			Disc=0

		var NetAmount
		if(document.all.DropDiscType.value=="Per")
			Disc=vat_value * Disc/100 
		
		//document.all.txtNetAmount.value=eval(vat_value) - eval(Disc);
		//**********Strat Add on Mahesh - Roudeoff net amount - 1.10.007
		var NetAmount=eval(vat_value) - eval(Disc);
		//NetAmount = Math.round(NetAmount)
		document.all.txtNetAmount.value=NetAmount;
		//*********End
		makeRound(document.all.txtNetAmount);
		var index = document.all.DropSalesType.selectedIndex;
		var val =  document.all.DropSalesType.options[index].text;
		if(val == "Credit")
		{
			//alert(document.Form1.txtNetAmount.value);
			if(eval(document.all.TxtCrLimit.value)!=0)
			{
				if(eval(document.all.txtNetAmount.value) > eval(document.all.TxtCrLimit.value))
				{
					alert("Credit Limit is less than Net Amount")
					// document.Form1.txtQ
					return;
				}
				else
				{
					document.all.lblCreditLimit.value = eval(document.all.TxtCrLimit.value) - eval(document.all.txtNetAmount.value)
				}
			}
		}
		else
		{
			document.all.lblCreditLimit.value = document.all.TxtCrLimit.value
		}
		
		if(document.all.txtNetAmount.value==0)
			document.all.txtNetAmount.value==""
	}
	function check11(t)
	{
	t=document.all.TxtEnd.value
	}
	function checkDelRec()
	{
		if(document.all.btnEdit == null)
		{
		    if (document.all.dropInvoiceNo.value != "Select")
			{
				if(confirm("Do You Want To Delete The Product"))
				    document.all.tempDelinfo.value = "Yes";
				else
				    document.all.tempDelinfo.value = "No";
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
		if (document.all.tempDelinfo.value == "Yes")
		    document.all.submit();
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
			<INPUT id="tmpQty4" style="Z-INDEX: 121; LEFT: 390px; WIDTH: 7px; POSITION: absolute; TOP: -3px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty4" runat="server"><INPUT id="txtcustinfo" style="Z-INDEX: 133; LEFT: 504px; WIDTH: 12px; POSITION: absolute; TOP: 5px; HEIGHT: 22px"
				type="hidden" size="1" name="txtcustinfo" runat="server"><INPUT id="tmpQty5" style="Z-INDEX: 122; LEFT: 399px; WIDTH: 7px; POSITION: absolute; TOP: -1px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty5" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><INPUT id="TxtVen" style="Z-INDEX: 100; LEFT: -544px; POSITION: absolute; TOP: -16px" type="text"
				name="TxtVen" runat="server"> <INPUT id="TextBox1" style="Z-INDEX: 101; LEFT: -248px; WIDTH: 76px; POSITION: absolute; TOP: -40px; HEIGHT: 22px"
				 type="text" size="7" name="TextBox1" runat="server"> <INPUT id="TxtEnd" style="Z-INDEX: 102; LEFT: -208px; WIDTH: 52px; POSITION: absolute; TOP: -24px; HEIGHT: 22px"
				type="text" size="3" name="TxtEnd" runat="server"><INPUT id="Txtstart" style="Z-INDEX: 103; LEFT: -336px; WIDTH: 83px; POSITION: absolute; TOP: -16px; HEIGHT: 22px"
				type="text" size="8" name="Txtstart" runat="server"> <INPUT id="TxtCrLimit" style="Z-INDEX: 104; LEFT: -448px; WIDTH: 70px; POSITION: absolute; TOP: -16px; HEIGHT: 22px"
				accessKey="TxtEnd" type="text" size="6" name="TxtCrLimit" runat="server">
			<asp:textbox id="TextSelect" style="Z-INDEX: 105; LEFT: 216px; POSITION: absolute; TOP: 16px"
				runat="server" Width="16px" Visible="False"></asp:textbox><asp:textbox id="TextBox2" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 24px" runat="server"
				Width="8px" Visible="False" BorderStyle="Groove"></asp:textbox><asp:textbox id="TxtCrLimit1" style="Z-INDEX: 107; LEFT: 176px; POSITION: absolute; TOP: 16px"
				runat="server" Width="16px" Visible="False" BorderStyle="Groove" ></asp:textbox><INPUT id="temptext" style="Z-INDEX: 108; LEFT: 152px; WIDTH: 16px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="temptext" runat="server">
			<asp:textbox id="txtTempQty1" style="Z-INDEX: 109; LEFT: 240px; POSITION: absolute; TOP: 16px"
				runat="server" Width="6px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty2" style="Z-INDEX: 110; LEFT: 256px; POSITION: absolute; TOP: 8px"
				runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty3" style="Z-INDEX: 111; LEFT: 272px; POSITION: absolute; TOP: 8px"
				runat="server" Width="4px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty4" style="Z-INDEX: 112; LEFT: 284px; POSITION: absolute; TOP: 8px"
				runat="server" Width="9px" Visible="False"></asp:textbox><asp:textbox id="TextBox7" style="Z-INDEX: 113; LEFT: 336px; POSITION: absolute; TOP: 0px" runat="server"
				Width="2px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty5" style="Z-INDEX: 114; LEFT: 296px; POSITION: absolute; TOP: 8px"
				runat="server" Width="4px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty6" style="Z-INDEX: 115; LEFT: 304px; POSITION: absolute; TOP: 8px"
				runat="server" Width="4px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty7" style="Z-INDEX: 116; LEFT: 312px; POSITION: absolute; TOP: 0px"
				runat="server" Width="4px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty8" style="Z-INDEX: 117; LEFT: 320px; POSITION: absolute; TOP: 0px"
				runat="server" Width="8px" Visible="False"></asp:textbox><INPUT id="tmpQty1" style="Z-INDEX: 118; LEFT: 350px; WIDTH: 10px; POSITION: absolute; TOP: 2px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty1" runat="server"> <INPUT id="tmpQty2" style="Z-INDEX: 119; LEFT: 365px; WIDTH: 7px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty2" runat="server"><INPUT id="tmpQty3" style="Z-INDEX: 120; LEFT: 377px; WIDTH: 7px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty3" runat="server"><INPUT id="tmpQty6" style="Z-INDEX: 123; LEFT: 410px; WIDTH: 6px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty6" runat="server"><INPUT id="tmpQty7" style="Z-INDEX: 124; LEFT: 416px; WIDTH: 5px; POSITION: absolute; TOP: -7px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty7" runat="server"><INPUT id="tmpQty8" style="Z-INDEX: 125; LEFT: 422px; WIDTH: 2px; POSITION: absolute; TOP: -7px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty8" runat="server"> <INPUT id="txtVatRate" style="Z-INDEX: 126; LEFT: 432px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatRate" runat="server"> <INPUT id="txtVatValue" style="Z-INDEX: 127; LEFT: 452px; WIDTH: 5px; POSITION: absolute; TOP: 6px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatValue" runat="server"> <INPUT id="txtSlipTemp" style="Z-INDEX: 128; LEFT: 462px; WIDTH: 6px; POSITION: absolute; TOP: 7px; HEIGHT: 22px"
				type="hidden" size="1" name="txtSlipTemp" runat="server"><INPUT id="SlipNo" style="Z-INDEX: 129; LEFT: 478px; WIDTH: 5px; POSITION: absolute; TOP: 7px; HEIGHT: 22px"
				type="hidden" size="1" name="SlipNo" runat="server"> <INPUT id="lblVehicleNo" style="Z-INDEX: 130; LEFT: 488px; WIDTH: 12px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="lblTinNo" style="Z-INDEX: 131; LEFT: 488px; WIDTH: 12px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="lblTinNo" runat="server"><input id="tempDelinfo" style="WIDTH: 1px" type="hidden" name="tempDelinfo" runat="server"><input id="tempInvoiceDate" style="WIDTH: 1px" type="hidden" name="tempInvoiceDate" runat="server">
			<INPUT id="tempminmax" style="Z-INDEX: 108; LEFT: 152px; WIDTH: 16px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="tempminmax" runat="server">
			<table height="288" width="778" align="center">
				<tr>
					<th align="center" colSpan="3">
						<font color="#006400">Sales&nbsp;Invoice</font>
						<hr>
						<asp:label id="lblMessage" runat="server" ForeColor="DarkGreen" Font-Size="8pt"></asp:label></th></tr>
				<tr>
					<td align="center">
						<TABLE  border="1">
							<TBODY>
								<TR>
									<TD align="center">
										<TABLE cellSpacing="0" cellPadding="0">
											<TR>
												<TD>&nbsp; Invoice No</TD>
												<TD><asp:dropdownlist id="dropInvoiceNo" runat="server" Width="128px" Visible="False" CssClass="FontStyle"
														AutoPostBack="True" Height="22px">
														<asp:ListItem Value="Select">Select</asp:ListItem>
													</asp:dropdownlist><br>
													<asp:label id="lblInvoiceNo" runat="server" Width="107px" BorderStyle="none" ForeColor="Blue"></asp:label><asp:button id="btnEdit" runat="server" Width="25px" ForeColor="White" ToolTip="Click For Edit"
														Text="..." CausesValidation="False" BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button></TD>
											</TR>
											<TR>
												<TD>&nbsp; Invoice Date</TD>
												<TD><asp:textbox id="lblInvoiceDate" runat="server" Width="90" BorderStyle="Groove" 
														CssClass="FontStyle"></asp:textbox>&nbsp;&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.lblInvoiceDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
															border="0"></A></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px">&nbsp; Sales Type</TD>
												<TD style="HEIGHT: 21px"><asp:dropdownlist id="DropSalesType" runat="server" Width="128" CssClass="FontStyle" AutoPostBack="True">
														<asp:ListItem Value="Credit Card Sale">Credit Card Sale</asp:ListItem>
														<asp:ListItem Value="Fleet Card Sale">Fleet Card Sale</asp:ListItem>
														<asp:ListItem Value="General Credit">General Credit</asp:ListItem>
														<asp:ListItem Value="Slip Wise Credit" Selected="True">Slip Wise Credit</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD>&nbsp;
													<asp:label id="lblSlipNo" runat="server" CssClass="dropdownlist">Slip No.<font color="red">*</font></asp:label><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="txtSlipNo" ErrorMessage="Please Enter Slip No."><font color="red">*</font></asp:requiredfieldvalidator></TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtSlipNo" onblur="check(this)"
														runat="server" Width="128px" BorderStyle="Groove" CssClass="FontStyle" Height="22px" MaxLength="9"
														tooltip="check11(document.all.txtSlipNo.value)"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
											</TR>
											<TR>
												<TD>&nbsp; Under Sales Man<font color="red">*</font>&nbsp;&nbsp;
													<asp:comparevalidator id="CompareValidator2" runat="server" ControlToValidate="DropUnderSalesMan" ErrorMessage="Please Select Sales Man"
														Operator="NotEqual" ValueToCompare="Select"><font color="red">*</font></asp:comparevalidator><FONT color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></TD>
												<TD><asp:dropdownlist id="DropUnderSalesMan" runat="server" Width="128" CssClass="FontStyle">
														<asp:ListItem Value="Select">Select</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<asp:panel id="PanChallan" Runat="server">
												<TR>
													<TD>&nbsp;&nbsp;Trans. No</TD>
													<TD>
														<asp:TextBox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtChallanNo" Width="127"
															BorderStyle="Groove" CssClass="FontStyle" MaxLength="9" Runat="server"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD>&nbsp;&nbsp;Trans. Date</TD>
													<TD>
														<asp:TextBox id="txtChallanDate" Width="90" BorderStyle="Groove" CssClass="FontStyle"
															Runat="server"></asp:TextBox>&nbsp;&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtChallanDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
																border="0"></A></TD>
												</TR>
											</asp:panel></TABLE>
									</TD>
									<TD align="center">
										<TABLE style="WIDTH: 314px" cellSpacing="0" cellPadding="0">
											<TR>
												<TD style="HEIGHT: 16px">Customer Name<font color="red">*</font>
													<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropCustName" ErrorMessage="Please Select Customer Name"
														Operator="NotEqual" ValueToCompare="Select"><font color="red">*</font></asp:comparevalidator></TD>
												<TD style="HEIGHT: 16px"><asp:dropdownlist id="DropCustName" runat="server" Width="172px" CssClass="FontStyle" AutoPostBack="True"
														onChange="getcustomerinfo(this,document.all.lblPlace,document.all.lblDueDate,document.all.lblCurrBalance,document.all.lblCreditLimit,document.all.DropVehicleNo);">
														<asp:ListItem Value="Select">Select</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD>Place</TD>
												<TD><INPUT class="FontStyle" id="lblPlace" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														 type="text" size="22" name="lblPlace" runat="server"></TD>
											</TR>
											<TR>
												<TD>Due Date</TD>
												<TD><INPUT class="FontStyle" id="lblDueDate" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														 type="text" size="22" name="lblDueDate" runat="server"></TD>
											</TR>
											<TR>
												<TD>Current 
													Balance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
												<TD><INPUT class="FontStyle" id="lblCurrBalance" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														 type="text" size="22" name="lblCurrBalance" runat="server"></TD>
											</TR>
											<TR>
												<TD>Credit Limit
												</TD>
												<TD><INPUT class="FontStyle" id="lblCreditLimit" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														 type="text" size="22" name="lblCreditLimit" runat="server"></TD>
											</TR>
											<TR>
												<TD>Vehicle No<font color="red">*</font>
													<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtVehicleNo" ErrorMessage="Please Enter Vehicle No."><font color="red">*</font></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="DropVehicleNo" ErrorMessage="Please Select Vehicle No."
														InitialValue="Select"><font color="red">*</font></asp:requiredfieldvalidator></TD>
												<TD><asp:textbox id="txtVehicleNo" runat="server" Width="168px" BorderStyle="Groove" Font-Size="Larger"
														CssClass="FontStyle" MaxLength="20"></asp:textbox><asp:dropdownlist id="DropVehicleNo" runat="server" Width="168px" Visible="False" CssClass="FontStyle"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<TABLE cellSpacing="0" cellPadding="0">
											<TBODY>
												<TR>
													<TD align="center" colSpan="7"><FONT color="#006400"><STRONG><U>Product &nbsp;Details</U></STRONG></FONT></TD>
												</TR>
												<TR>
													<TD align="center"><FONT color="darkgreen">Product Type<font color="red">*</font>
															<asp:comparevalidator id="CompareValidator3" runat="server" ControlToValidate="DropType1" ErrorMessage="Please Select Atleast one Product Type"
																Operator="NotEqual" ValueToCompare="Type"><font color="red">*</font></asp:comparevalidator></FONT></TD>
													<TD style="WIDTH: 120px" align="center"><FONT color="darkgreen">Name
															<asp:comparevalidator id="CompareValidator4" runat="server" ControlToValidate="DropProd1" ErrorMessage="Please Select atleast One Product Name"
																Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator></FONT></TD>
													<TD style="WIDTH: 2px" align="center"><FONT color="darkgreen">Package</FONT></TD>
													<TD align="center"><FONT color="darkgreen">Qty<font color="red">*</font>
															<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtQty1" ErrorMessage="Please Fill Quantity"><font color="red">*</font></asp:requiredfieldvalidator></FONT></TD>
													<TD align="center"><FONT color="darkgreen">Available Stock</FONT></TD>
													<TD align="center"><FONT color="darkgreen">Rate</FONT></TD>
													<TD align="center"><FONT color="darkgreen">Amount</FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType1" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getProdName(this,document.all.DropProd1,document.all.DropPack1,document.all.txtAvStock1,document.all.txtRate1,document.all.txtProdName1,document.all.txtPack1,document.all.txtQty1,document.all.txtAmount1,document.all.DropCustName)">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd1" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.all.DropType1,this,document.all.DropPack1,document.all.txtAvStock1,document.all.txtRate1,document.all.txtProdName1,document.all.txtPack1,document.all.txtQty1,document.all.txtAmount1)">
															<asp:ListItem Value="select">select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName1" style="WIDTH: 140px" type="hidden" name="txtProdName1" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack1" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.all.DropType1,document.all.DropProd1,this,document.all.txtAvStock1,document.all.txtRate1,document.all.txtPack1,document.all.txtQty1,document.all.txtAmount1)"></asp:dropdownlist><INPUT id="txtPack1" style="WIDTH: 91px" type="hidden" name="txtPack1" runat="server"></TD>
													<TD align="center"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty1" onblur="calc(this,document.all.txtAvStock1,document.all.txtRate1,document.all.tmpQty1,document.all.txtProdName1,document.all.txtPack1)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtAvStock1" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate1" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount1" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType2" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.all.DropProd2,document.all.DropPack2,document.all.txtAvStock2,document.all.txtRate2,document.all.txtProdName2,document.all.txtPack2,document.all.txtQty2,document.all.txtAmount2,document.all.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd2" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.all.DropType2,this,document.all.DropPack2,document.all.txtAvStock2,document.all.txtRate2,document.all.txtProdName2,document.all.txtPack2,document.all.txtQty2,document.all.txtAmount2)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName2" style="WIDTH: 140px" type="hidden" name="txtProdName2" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack2" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.all.DropType2,document.all.DropProd2,this,document.all.txtAvStock2,document.all.txtRate2,document.all.txtPack2,document.all.txtQty2,document.all.txtAmount2)"></asp:dropdownlist><INPUT id="txtPack2" style="WIDTH: 91px" type="hidden" name="txtPack2" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty2" onblur="calc(this,document.all.txtAvStock2,document.all.txtRate2,document.all.tmpQty2,document.all.txtProdName2,document.all.txtPack2)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock2" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate2" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount2" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType3" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.all.DropProd3,document.all.DropPack3,document.all.txtAvStock3,document.all.txtRate3,document.all.txtProdName3,document.all.txtPack3,document.all.txtQty3,document.all.txtAmount3,document.all.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd3" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.all.DropType3,this,document.all.DropPack3,document.all.txtAvStock3,document.all.txtRate3,document.all.txtProdName3,document.all.txtPack3,document.all.txtQty3,document.all.txtAmount3)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName3" style="WIDTH: 140px" type="hidden" name="txtProdName3" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack3" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.all.DropType3,document.all.DropProd3,this,document.all.txtAvStock3,document.all.txtRate3,document.all.txtPack3,document.all.txtQty3,document.all.txtAmount3)"></asp:dropdownlist><INPUT id="txtPack3" style="WIDTH: 91px" type="hidden" name="txtPack3" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty3" onblur="calc(this,document.all.txtAvStock3,document.all.txtRate3,document.all.tmpQty3,document.all.txtProdName3,document.all.txtPack3)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock3" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate3" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount3" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType4" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.all.DropProd4,document.all.DropPack4,document.all.txtAvStock4,document.all.txtRate4,document.all.txtProdName4,document.all.txtPack4,document.all.txtQty4,document.all.txtAmount4,document.all.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd4" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.all.DropType4,this,document.all.DropPack4,document.all.txtAvStock4,document.all.txtRate4,document.all.txtProdName4,document.all.txtPack4,document.all.txtQty4,document.all.txtAmount4)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName4" style="WIDTH: 140px" type="hidden" name="txtProdName4" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack4" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.all.DropType4,document.all.DropProd4,this,document.all.txtAvStock4,document.all.txtRate4,document.all.txtPack4,document.all.txtQty4,document.all.txtAmount4)"></asp:dropdownlist><INPUT id="txtPack4" style="WIDTH: 91px" type="hidden" name="txtPack4" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty4" onblur="calc(this,document.all.txtAvStock4,document.all.txtRate4,document.all.tmpQty4,document.all.txtProdName4,document.all.txtPack4)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock4" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate4" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount4" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType5" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.all.DropProd5,document.all.DropPack5,document.all.txtAvStock5,document.all.txtRate5,document.all.txtProdName5,document.all.txtPack5,document.all.txtQty5,document.all.txtAmount5,document.all.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd5" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.all.DropType5,this,document.all.DropPack5,document.all.txtAvStock5,document.all.txtRate5,document.all.txtProdName5,document.all.txtPack5,document.all.txtQty5,document.all.txtAmount5)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName5" style="WIDTH: 140px" type="hidden" name="txtProdName5" runat="server">
													</TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack5" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.all.DropType5,document.all.DropProd5,this,document.all.txtAvStock5,document.all.txtRate5,document.all.txtPack5,document.all.txtQty5,document.all.txtAmount5)"></asp:dropdownlist><INPUT id="txtPack5" style="WIDTH: 91px" type="hidden" name="txtPack5" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty5" onblur="calc(this,document.all.txtAvStock5,document.all.txtRate5,document.all.tmpQty5,document.all.txtProdName5,document.all.txtPack5)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock5" runat="server" Width="110px" BorderStyle="Groove"
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate5" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount5" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType6" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.all.DropProd6,document.all.DropPack6,document.all.txtAvStock6,document.all.txtRate6,document.all.txtProdName6,document.all.txtPack6,document.all.txtQty6,document.all.txtAmount6,document.all.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd6" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.all.DropType6,this,document.all.DropPack6,document.all.txtAvStock6,document.all.txtRate6,document.all.txtProdName6,document.all.txtPack6,document.all.txtQty6,document.all.txtAmount6)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName6" style="WIDTH: 140px" type="hidden" name="txtProdName6" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack6" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.all.DropType6,document.all.DropProd6,this,document.all.txtAvStock6,document.all.txtRate6,document.all.txtPack6,document.all.txtQty6,document.all.txtAmount6)"></asp:dropdownlist><INPUT id="txtPack6" style="WIDTH: 91px" type="hidden" name="txtPack6" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty6" onblur="calc(this,document.all.txtAvStock6,document.all.txtRate6,document.all.tmpQty6,document.all.txtProdName6,document.all.txtPack6)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock6" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate6" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount6" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType7" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.all.DropProd7,document.all.DropPack7,document.all.txtAvStock7,document.all.txtRate7,document.all.txtProdName7,document.all.txtPack7,document.all.txtQty7,document.all.txtAmount7,document.all.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd7" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.all.DropType7,this,document.all.DropPack7,document.all.txtAvStock7,document.all.txtRate7,document.all.txtProdName7,document.all.txtPack7,document.all.txtQty7,document.all.txtAmount7)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName7" style="WIDTH: 140px" type="hidden" name="txtProdName7" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack7" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.all.DropType7,document.all.DropProd7,this,document.all.txtAvStock7,document.all.txtRate7,document.all.txtPack7,document.all.txtQty7,document.all.txtAmount7)"></asp:dropdownlist><INPUT id="txtPack7" style="WIDTH: 91px" type="hidden" name="txtPack7" runat="server"></TD>
													<TD><asp:textbox id="txtQty7" onblur="calc(this,document.all.txtAvStock7,document.all.txtRate7,document.all.tmpQty7,document.all.txtProdName7,document.all.txtPack7)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock7" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate7" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount7" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType8" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getProdName(this,document.all.DropProd8,document.all.DropPack8,document.all.txtAvStock8,document.all.txtRate8,document.all.txtProdName8,document.all.txtPack8,document.all.txtQty8,document.all.txtAmount8,document.all.DropCustName)">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd8" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.all.DropType8,this,document.all.DropPack8,document.all.txtAvStock8,document.all.txtRate8,document.all.txtProdName8,document.all.txtPack8,document.all.txtQty8,document.all.txtAmount8)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName8" style="WIDTH: 140px" type="hidden" name="txtProdName8" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack8" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.all.DropType8,document.all.DropProd8,this,document.all.txtAvStock8,document.all.txtRate8,document.all.txtPack8,document.all.txtQty8,document.all.txtAmount8)"></asp:dropdownlist><INPUT id="txtPack8" style="WIDTH: 91px" type="hidden" name="txtPack8" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty8" onblur="calc(this,document.all.txtAvStock8,document.all.txtRate8,document.all.tmpQty8,document.all.txtProdName8,document.all.txtPack8)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock8" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate8" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount8" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
											</TBODY>
										</TABLE>
										<INPUT id="Hidden1" style="WIDTH: 12px; HEIGHT: 22px" type="hidden" size="1" name="txtcustinfo"
											runat="server"></TD>
								</TR>
							</TBODY>
						</TABLE>
						<TABLE cellSpacing="0" cellPadding="0">
							<TR>
								<TD>Promo Scheme</TD>
								<TD><asp:textbox id="txtPromoScheme" runat="server" Width="246px" BorderStyle="Groove" CssClass="FontStyle"
										MaxLength="49"></asp:textbox></TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD>Grand Total</TD>
								<TD><asp:textbox id="txtGrandTotal" runat="server" Width="124px" BorderStyle="Groove" 
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Remark</TD>
								<TD>
									<P><asp:textbox id="txtRemark" runat="server" Width="246px" BorderStyle="Groove" CssClass="FontStyle"
											MaxLength="49"></asp:textbox></P>
								</TD>
								<TD></TD>
								<TD>Cash Discount</TD>
								<TD><asp:textbox id="txtCashDisc" onblur="GetNetAmount()" runat="server" Width="67px" BorderStyle="Groove"
										CssClass="FontStyle" MaxLength="5"></asp:textbox><asp:dropdownlist id="DropCashDiscType" onblur="GetNetAmount()" runat="server" Width="56px" CssClass="FontStyle">
										<asp:ListItem Value="Rs" Selected="True">Rs.</asp:ListItem>
										<asp:ListItem Value="Per">%</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Message</TD>
								<TD><asp:textbox id="txtMessage" runat="server" Width="246px" BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox></TD>
								<TD></TD>
								<TD>VAT
									<asp:radiobutton id="No" onclick="return GetNetAmount();" runat="server" ToolTip="Not Applied" BackColor="#FFE0C0"
										GroupName="VAT" Checked="True"></asp:radiobutton>&nbsp;<asp:radiobutton id="Yes" onclick="return GetNetAmount();" runat="server" ToolTip="Apply" BackColor="#C0FFC0"
										GroupName="VAT"></asp:radiobutton></TD>
								<TD style="HEIGHT: 27px"><asp:textbox id="txtVAT" runat="server" Width="124px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<P>&nbsp;</P>
								</TD>
								<TD></TD>
								<TD>Discount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtDisc" onblur="GetNetAmount()" runat="server" Width="67px" BorderStyle="Groove"
										CssClass="FontStyle" MaxLength="6"></asp:textbox><asp:dropdownlist id="DropDiscType" onblur="GetNetAmount()" runat="server" Width="56px" CssClass="FontStyle">
										<asp:ListItem Value="Rs" Selected="True">Rs.</asp:ListItem>
										<asp:ListItem Value="Per">%</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD>Net Amount</TD>
								<TD><asp:textbox id="txtNetAmount" runat="server" Width="124px" BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Entry&nbsp;By</TD>
								<TD><asp:label id="lblEntryBy" runat="server"></asp:label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Entry Date &amp; Time</TD>
								<TD><asp:label id="lblEntryTime" runat="server"></asp:label></TD>
								<TD align="right" colSpan="3"><asp:button id="btnSave" runat="server" Width="80px" ForeColor="White" Text="Save" BackColor="ForestGreen"
										BorderColor="DarkSeaGreen"></asp:button>&nbsp;&nbsp;<asp:button id="Button1" runat="server" Width="80px" ForeColor="White" Text=" Print" CausesValidation="False"
										BackColor="ForestGreen" BorderColor="DarkSeaGreen"></asp:button>&nbsp;&nbsp;<asp:button onmouseup="checkDelRec();" id="btnDelete" runat="server" Width="80px" ForeColor="White"
										Text="Delete" CausesValidation="False" BackColor="ForestGreen" BorderColor="DarkSeaGreen"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		<script language="C#">
		</script>
	</body>
</HTML>
