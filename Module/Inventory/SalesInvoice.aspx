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
		var start = document.Form1.Txtstart.value;
		var end  = document.Form1.TxtEnd.value;
		var slip = slipNo.value;
		var slip1 = document.Form1.SlipNo.value;  
		var temp = document.Form1.txtSlipTemp.value;
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
		var max=document.Form1.tempminmax.value;
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
		if(document.Form1.btnEdit == null )
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
		
		document.Form1.txtAmount1.value=document.Form1.txtQty1.value*document.Form1.txtRate1.value	
		if(document.Form1.txtAmount1.value==0)
			document.Form1.txtAmount1.value=""
		else
			makeRound(document.Form1.txtAmount1)
		document.Form1.txtAmount2.value= document.Form1.txtQty2.value*document.Form1.txtRate2.value	
 		if(document.Form1.txtAmount2.value==0)
			document.Form1.txtAmount2.value=""
		else
			makeRound(document.Form1.txtAmount2)
		document.Form1.txtAmount3.value= document.Form1.txtQty3.value*document.Form1.txtRate3.value	
		if(document.Form1.txtAmount3.value==0)
			document.Form1.txtAmount3.value=""
		else
			makeRound(document.Form1.txtAmount3)
		document.Form1.txtAmount4.value= document.Form1.txtQty4.value*document.Form1.txtRate4.value	
		if(document.Form1.txtAmount4.value==0)
			document.Form1.txtAmount4.value=""
		else
			makeRound(document.Form1.txtAmount4)
		document.Form1.txtAmount5.value= document.Form1.txtQty5.value*document.Form1.txtRate5.value	
		if(document.Form1.txtAmount5.value==0)
			document.Form1.txtAmount5.value=""
		else
			makeRound(document.Form1.txtAmount5)
		document.Form1.txtAmount6.value= document.Form1.txtQty6.value*document.Form1.txtRate6.value	
		if(document.Form1.txtAmount6.value==0)
			document.Form1.txtAmount6.value=""
		else
			makeRound(document.Form1.txtAmount6)
		document.Form1.txtAmount7.value= document.Form1.txtQty7.value*document.Form1.txtRate7.value	
		if(document.Form1.txtAmount7.value==0)
			document.Form1.txtAmount7.value=""
		else
			makeRound(document.Form1.txtAmount7)
		document.Form1.txtAmount8.value= document.Form1.txtQty8.value*document.Form1.txtRate8.value	
		if(document.Form1.txtAmount8.value==0)
			document.Form1.txtAmount8.value=""
		else
			makeRound(document.Form1.txtAmount8)
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
	         if(vat == "" || isNaN(vat))
	       vat = 0;
	       //alert("disc: "+vat)
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
		
		//document.Form1.txtNetAmount.value=eval(vat_value) - eval(Disc);
		//**********Strat Add on Mahesh - Roudeoff net amount - 1.10.007
		var NetAmount=eval(vat_value) - eval(Disc);
		//NetAmount = Math.round(NetAmount)
		document.Form1.txtNetAmount.value=NetAmount;
		//*********End
		makeRound(document.Form1.txtNetAmount);
		var index = document.Form1.DropSalesType.selectedIndex;
		var val =  document.Form1.DropSalesType.options[index].text;
		if(val == "Credit")
		{
			//alert(document.Form1.txtNetAmount.value);
			if(eval(document.Form1.TxtCrLimit.value)!=0)
			{
				if(eval(document.Form1.txtNetAmount.value) > eval(document.Form1.TxtCrLimit.value))
				{
					alert("Credit Limit is less than Net Amount")
					// document.Form1.txtQ
					return;
				}
				else
				{
					document.Form1.lblCreditLimit.value = eval(document.Form1.TxtCrLimit.value) - eval(document.Form1.txtNetAmount.value)
				}
			}
		}
		else
		{
			document.Form1.lblCreditLimit.value = document.Form1.TxtCrLimit.value
		}
		
		if(document.Form1.txtNetAmount.value==0)
			document.Form1.txtNetAmount.value==""
	}
	function check11(t)
	{
	t=document.Form1.TxtEnd.value
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
												<TD style="HEIGHT: 21px"><asp:dropdownlist id="DropSalesType" runat="server" Width="128" CssClass="FontStyle" AutoPostBack="True"
														Height="22">
														<asp:ListItem Value="Credit Card Sale">Credit Card Sale</asp:ListItem>
														<asp:ListItem Value="Fleet Card Sale">Fleet Card Sale</asp:ListItem>
														<asp:ListItem Value="General Credit">General Credit</asp:ListItem>
														<asp:ListItem Value="Slip Wise Credit" Selected="True">Slip Wise Credit</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD>&nbsp;
													<asp:label id="lblSlipNo" runat="server" CssClass="dropdownlist">Slip No.</asp:label><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="txtSlipNo" ErrorMessage="Please Enter Slip No.">*</asp:requiredfieldvalidator></TD>
												<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtSlipNo" onblur="check(this)"
														runat="server" Width="80px" BorderStyle="Groove" CssClass="FontStyle" Height="20px" MaxLength="9"
														tooltip="check11(document.Form1.txtSlipNo.value)"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
											</TR>
											<TR>
												<TD>&nbsp; Under Sales Man&nbsp;&nbsp;
													<asp:comparevalidator id="CompareValidator2" runat="server" ControlToValidate="DropUnderSalesMan" ErrorMessage="Please Select Sales Man"
														Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator><FONT color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></TD>
												<TD><asp:dropdownlist id="DropUnderSalesMan" runat="server" Width="128" CssClass="FontStyle" Height="22">
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
												<TD style="HEIGHT: 16px">Customer Name
													<asp:comparevalidator id="CompareValidator1" runat="server" ControlToValidate="DropCustName" ErrorMessage="Please Select Customer Name"
														Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator></TD>
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
												<TD>Vehicle No
													<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtVehicleNo" ErrorMessage="Please Enter Vehicle No.">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="DropVehicleNo" ErrorMessage="Please Select Vehicle No."
														InitialValue="Select">*</asp:requiredfieldvalidator></TD>
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
													<TD align="center"><FONT color="darkgreen">Product Type
															<asp:comparevalidator id="CompareValidator3" runat="server" ControlToValidate="DropType1" ErrorMessage="Please Select Atleast one Product Type"
																Operator="NotEqual" ValueToCompare="Type">*</asp:comparevalidator></FONT></TD>
													<TD style="WIDTH: 120px" align="center"><FONT color="darkgreen">Name
															<asp:comparevalidator id="CompareValidator4" runat="server" ControlToValidate="DropProd1" ErrorMessage="Please Select atleast One Product Name"
																Operator="NotEqual" ValueToCompare="Select">*</asp:comparevalidator></FONT></TD>
													<TD style="WIDTH: 2px" align="center"><FONT color="darkgreen">Package</FONT></TD>
													<TD align="center"><FONT color="darkgreen">Qty
															<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtQty1" ErrorMessage="Please Fill Quantity">*</asp:requiredfieldvalidator></FONT></TD>
													<TD align="center"><FONT color="darkgreen">Available Stock</FONT></TD>
													<TD align="center"><FONT color="darkgreen">Rate</FONT></TD>
													<TD align="center"><FONT color="darkgreen">Amount</FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType1" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getProdName(this,document.Form1.DropProd1,document.Form1.DropPack1,document.Form1.txtAvStock1,document.Form1.txtRate1,document.Form1.txtProdName1,document.Form1.txtPack1,document.Form1.txtQty1,document.Form1.txtAmount1,document.Form1.DropCustName)">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd1" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.Form1.DropType1,this,document.Form1.DropPack1,document.Form1.txtAvStock1,document.Form1.txtRate1,document.Form1.txtProdName1,document.Form1.txtPack1,document.Form1.txtQty1,document.Form1.txtAmount1)">
															<asp:ListItem Value="select">select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName1" style="WIDTH: 140px" type="hidden" name="txtProdName1" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack1" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.Form1.DropType1,document.Form1.DropProd1,this,document.Form1.txtAvStock1,document.Form1.txtRate1,document.Form1.txtPack1,document.Form1.txtQty1,document.Form1.txtAmount1)"></asp:dropdownlist><INPUT id="txtPack1" style="WIDTH: 91px" type="hidden" name="txtPack1" runat="server"></TD>
													<TD align="center"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty1" onblur="calc(this,document.Form1.txtAvStock1,document.Form1.txtRate1,document.Form1.tmpQty1,document.Form1.txtProdName1,document.Form1.txtPack1)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtAvStock1" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate1" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount1" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType2" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.Form1.DropProd2,document.Form1.DropPack2,document.Form1.txtAvStock2,document.Form1.txtRate2,document.Form1.txtProdName2,document.Form1.txtPack2,document.Form1.txtQty2,document.Form1.txtAmount2,document.Form1.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd2" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.Form1.DropType2,this,document.Form1.DropPack2,document.Form1.txtAvStock2,document.Form1.txtRate2,document.Form1.txtProdName2,document.Form1.txtPack2,document.Form1.txtQty2,document.Form1.txtAmount2)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName2" style="WIDTH: 140px" type="hidden" name="txtProdName2" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack2" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.Form1.DropType2,document.Form1.DropProd2,this,document.Form1.txtAvStock2,document.Form1.txtRate2,document.Form1.txtPack2,document.Form1.txtQty2,document.Form1.txtAmount2)"></asp:dropdownlist><INPUT id="txtPack2" style="WIDTH: 91px" type="hidden" name="txtPack2" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty2" onblur="calc(this,document.Form1.txtAvStock2,document.Form1.txtRate2,document.Form1.tmpQty2,document.Form1.txtProdName2,document.Form1.txtPack2)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock2" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate2" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount2" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType3" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.Form1.DropProd3,document.Form1.DropPack3,document.Form1.txtAvStock3,document.Form1.txtRate3,document.Form1.txtProdName3,document.Form1.txtPack3,document.Form1.txtQty3,document.Form1.txtAmount3,document.Form1.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd3" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.Form1.DropType3,this,document.Form1.DropPack3,document.Form1.txtAvStock3,document.Form1.txtRate3,document.Form1.txtProdName3,document.Form1.txtPack3,document.Form1.txtQty3,document.Form1.txtAmount3)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName3" style="WIDTH: 140px" type="hidden" name="txtProdName3" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack3" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.Form1.DropType3,document.Form1.DropProd3,this,document.Form1.txtAvStock3,document.Form1.txtRate3,document.Form1.txtPack3,document.Form1.txtQty3,document.Form1.txtAmount3)"></asp:dropdownlist><INPUT id="txtPack3" style="WIDTH: 91px" type="hidden" name="txtPack3" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty3" onblur="calc(this,document.Form1.txtAvStock3,document.Form1.txtRate3,document.Form1.tmpQty3,document.Form1.txtProdName3,document.Form1.txtPack3)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock3" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate3" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount3" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType4" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.Form1.DropProd4,document.Form1.DropPack4,document.Form1.txtAvStock4,document.Form1.txtRate4,document.Form1.txtProdName4,document.Form1.txtPack4,document.Form1.txtQty4,document.Form1.txtAmount4,document.Form1.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd4" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.Form1.DropType4,this,document.Form1.DropPack4,document.Form1.txtAvStock4,document.Form1.txtRate4,document.Form1.txtProdName4,document.Form1.txtPack4,document.Form1.txtQty4,document.Form1.txtAmount4)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName4" style="WIDTH: 140px" type="hidden" name="txtProdName4" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack4" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.Form1.DropType4,document.Form1.DropProd4,this,document.Form1.txtAvStock4,document.Form1.txtRate4,document.Form1.txtPack4,document.Form1.txtQty4,document.Form1.txtAmount4)"></asp:dropdownlist><INPUT id="txtPack4" style="WIDTH: 91px" type="hidden" name="txtPack4" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty4" onblur="calc(this,document.Form1.txtAvStock4,document.Form1.txtRate4,document.Form1.tmpQty4,document.Form1.txtProdName4,document.Form1.txtPack4)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock4" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate4" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount4" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType5" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.Form1.DropProd5,document.Form1.DropPack5,document.Form1.txtAvStock5,document.Form1.txtRate5,document.Form1.txtProdName5,document.Form1.txtPack5,document.Form1.txtQty5,document.Form1.txtAmount5,document.Form1.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd5" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.Form1.DropType5,this,document.Form1.DropPack5,document.Form1.txtAvStock5,document.Form1.txtRate5,document.Form1.txtProdName5,document.Form1.txtPack5,document.Form1.txtQty5,document.Form1.txtAmount5)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName5" style="WIDTH: 140px" type="hidden" name="txtProdName5" runat="server">
													</TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack5" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.Form1.DropType5,document.Form1.DropProd5,this,document.Form1.txtAvStock5,document.Form1.txtRate5,document.Form1.txtPack5,document.Form1.txtQty5,document.Form1.txtAmount5)"></asp:dropdownlist><INPUT id="txtPack5" style="WIDTH: 91px" type="hidden" name="txtPack5" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty5" onblur="calc(this,document.Form1.txtAvStock5,document.Form1.txtRate5,document.Form1.tmpQty5,document.Form1.txtProdName5,document.Form1.txtPack5)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock5" runat="server" Width="110px" BorderStyle="Groove"
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate5" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount5" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType6" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.Form1.DropProd6,document.Form1.DropPack6,document.Form1.txtAvStock6,document.Form1.txtRate6,document.Form1.txtProdName6,document.Form1.txtPack6,document.Form1.txtQty6,document.Form1.txtAmount6,document.Form1.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd6" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.Form1.DropType6,this,document.Form1.DropPack6,document.Form1.txtAvStock6,document.Form1.txtRate6,document.Form1.txtProdName6,document.Form1.txtPack6,document.Form1.txtQty6,document.Form1.txtAmount6)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName6" style="WIDTH: 140px" type="hidden" name="txtProdName6" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack6" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.Form1.DropType6,document.Form1.DropProd6,this,document.Form1.txtAvStock6,document.Form1.txtRate6,document.Form1.txtPack6,document.Form1.txtQty6,document.Form1.txtAmount6)"></asp:dropdownlist><INPUT id="txtPack6" style="WIDTH: 91px" type="hidden" name="txtPack6" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty6" onblur="calc(this,document.Form1.txtAvStock6,document.Form1.txtRate6,document.Form1.tmpQty6,document.Form1.txtProdName6,document.Form1.txtPack6)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock6" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate6" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount6" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType7" runat="server" Width="91px" CssClass="FontStyle" onchange="getProdName(this,document.Form1.DropProd7,document.Form1.DropPack7,document.Form1.txtAvStock7,document.Form1.txtRate7,document.Form1.txtProdName7,document.Form1.txtPack7,document.Form1.txtQty7,document.Form1.txtAmount7,document.Form1.DropCustName)" Height="17px">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd7" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.Form1.DropType7,this,document.Form1.DropPack7,document.Form1.txtAvStock7,document.Form1.txtRate7,document.Form1.txtProdName7,document.Form1.txtPack7,document.Form1.txtQty7,document.Form1.txtAmount7)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName7" style="WIDTH: 140px" type="hidden" name="txtProdName7" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack7" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.Form1.DropType7,document.Form1.DropProd7,this,document.Form1.txtAvStock7,document.Form1.txtRate7,document.Form1.txtPack7,document.Form1.txtQty7,document.Form1.txtAmount7)"></asp:dropdownlist><INPUT id="txtPack7" style="WIDTH: 91px" type="hidden" name="txtPack7" runat="server"></TD>
													<TD><asp:textbox id="txtQty7" onblur="calc(this,document.Form1.txtAvStock7,document.Form1.txtRate7,document.Form1.tmpQty7,document.Form1.txtProdName7,document.Form1.txtPack7)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
													<TD align="center"><asp:textbox id="txtAvStock7" runat="server" Width="110px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate7" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount7" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 16px"><asp:dropdownlist id="DropType8" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getProdName(this,document.Form1.DropProd8,document.Form1.DropPack8,document.Form1.txtAvStock8,document.Form1.txtRate8,document.Form1.txtProdName8,document.Form1.txtPack8,document.Form1.txtQty8,document.Form1.txtAmount8,document.Form1.DropCustName)">
															<asp:ListItem Value="Type">Type</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="WIDTH: 120px"><asp:dropdownlist id="DropProd8" runat="server" Width="140px" CssClass="FontStyle" Height="17px" onchange="getPack(document.Form1.DropType8,this,document.Form1.DropPack8,document.Form1.txtAvStock8,document.Form1.txtRate8,document.Form1.txtProdName8,document.Form1.txtPack8,document.Form1.txtQty8,document.Form1.txtAmount8)">
															<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist><INPUT id="txtProdName8" style="WIDTH: 140px" type="hidden" name="txtProdName8" runat="server"></TD>
													<TD style="WIDTH: 2px"><asp:dropdownlist id="DropPack8" runat="server" Width="91px" CssClass="FontStyle" Height="17px" onchange="getStock(document.Form1.DropType8,document.Form1.DropProd8,this,document.Form1.txtAvStock8,document.Form1.txtRate8,document.Form1.txtPack8,document.Form1.txtQty8,document.Form1.txtAmount8)"></asp:dropdownlist><INPUT id="txtPack8" style="WIDTH: 91px" type="hidden" name="txtPack8" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty8" onblur="calc(this,document.Form1.txtAvStock8,document.Form1.txtRate8,document.Form1.tmpQty8,document.Form1.txtProdName8,document.Form1.txtPack8)"
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
