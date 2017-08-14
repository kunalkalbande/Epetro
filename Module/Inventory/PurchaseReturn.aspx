<%@ Page language="c#" Codebehind="PurchaseReturn.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.PurchaseReturn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Purchase Return Credit Note</title> <!--
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
		
function selectAll()
{
	//alert("In");
    var CheckBox = new Array(document.all.Check1, document.all.Check2, document.all.Check3, document.all.Check4, document.all.Check5, document.all.Check6, document.all.Check7, document.all.Check8);
	var ProdName = new Array(document.all.txtProdName1,document.all.txtProdName2,document.all.txtProdName3,document.all.txtProdName4,document.all.txtProdName5,document.all.txtProdName6,document.all.txtProdName7,document.all.txtProdName8);
	var Pack = new Array(document.all.txtPack1,document.all.txtPack2,document.all.txtPack3,document.all.txtPack4,document.all.txtPack5,document.all.txtPack6,document.all.txtPack7,document.all.txtPack8);
	var Qty = new Array(document.all.txtQty1,document.all.txtQty2,document.all.txtQty3,document.all.txtQty4,document.all.txtQty5,document.all.txtQty6,document.all.txtQty7,document.all.txtQty8);
	var Rate = new Array(document.all.txtRate1,document.all.txtRate2,document.all.txtRate3,document.all.txtRate4,document.all.txtRate5,document.all.txtRate6,document.all.txtRate7,document.all.txtRate8);
	var Amount = new Array(document.all.txtAmount1,document.all.txtAmount2,document.all.txtAmount3,document.all.txtAmount4,document.all.txtAmount5,document.all.txtAmount6,document.all.txtAmount7,document.all.txtAmount8);
	// var TempQty = new Array(document.Form1.txtTempQty1,document.Form1.txtTempQty2,document.Form1.txtTempQty3,document.Form1.txtTempQty4,document.Form1.txtTempQty5,document.Form1.txtTempQty6,document.Form1.txtTempQty7,document.Form1.txtTempQty8);
	var TempQty = new Array(document.all.tmpQty1,document.all.tmpQty2,document.all.tmpQty3,document.all.tmpQty4,document.all.tmpQty5,document.all.tmpQty6,document.all.tmpQty7,document.all.tmpQty8);
	
	if(document.all.CheckAll.checked == true)
	{
		//alert("if")
		for(var i = 0; i < CheckBox.length ; i++)
		{
	        if(ProdName[i].value != "")
		    {
				CheckBox[i].checked = true;
				ProdName[i].disabled = false; 
				Pack[i].disabled = false;
				Qty[i].disabled = false;
				Rate[i].disabled = false;
	            Amount[i].disabled = false; 
				calc(Qty[i],Rate[i],TempQty[i])
			}
			else
				continue
		} 
    }
    else
	{
		for(var i = 0; i < CheckBox.length ; i++)
		{
             CheckBox[i].checked = false;
             ProdName[i].disabled = true; 
             Pack[i].disabled = true;
             Qty[i].disabled = true;
             Rate[i].disabled = true;
             Amount[i].disabled = true;  
             Qty[i].value = TempQty[i].value;
		}
		calc1(Qty[i],Rate[i])
    }
	//GetGrandTotal()
	// GetNetAmount()
 }
 
function allUnChecked()
{
	var CheckBox = new Array(document.all.Check1,document.all.Check2,document.all.Check3,document.all.Check4,document.all.Check5,document.all.Check6,document.all.Check7,document.all.Check8);
	var c = 0;
 
	for(var i= 0 ; i < CheckBox.length; i++)
	{
		if(CheckBox[i].checked == false)
		{
			c++
		}
	}
	if(c == 8)
	{
		return true;
	}
	else
		return false;
}		
 
function select1(check, product, pack, qty, rate, amount, tmpQty)
{
    if(check.checked == true)
    {
		product.disabled = false;
		pack.disabled = false;
		qty.disabled = false;
		rate.disabled = false;
		amount.disabled = false; 
		//calc(qty,rate,tmpQty)
    }
    else
    {
		product.disabled = true;
		pack.disabled = true;
		qty.disabled = true;
		rate.disabled = true;
		amount.disabled = true; 
		qty.value = tmpQty.value
		/*Hide By Mahesh on 11.09.007
		if(allUnChecked())
		{
			//calc1(qty,rate)
		}
		else
		{
			//calc(qty,rate,tmpQty)
		}
		*/
    }
	//  GetGrandTotal()
	// GetNetAmount()
 }
	
function calc1(txtQty,txtRate)
{
	//alert("inside")
	var sarr = new Array()
	var temp ="";
	
	document.all.txtAmount1.value=document.all.txtQty1.value*document.all.txtRate1.value	
	if(document.all.txtAmount1.value==0)
		document.all.txtAmount1.value=""
	document.all.txtAmount2.value= document.all.txtQty2.value*document.all.txtRate2.value	
 	if(document.all.txtAmount2.value==0)
		document.all.txtAmount2.value=""
	document.all.txtAmount3.value= document.all.txtQty3.value*document.all.txtRate3.value	
	if(document.all.txtAmount3.value==0)
		document.all.txtAmount3.value=""
	document.all.txtAmount4.value= document.all.txtQty4.value*document.all.txtRate4.value	
	if(document.all.txtAmount4.value==0)
		document.all.txtAmount4.value=""
	document.all.txtAmount5.value= document.all.txtQty5.value*document.all.txtRate5.value	
	if(document.all.txtAmount5.value==0)
		document.all.txtAmount5.value=""
	document.all.txtAmount6.value= document.all.txtQty6.value*document.all.txtRate6.value	
	if(document.all.txtAmount6.value==0)
		document.all.txtAmount6.value=""
	document.all.txtAmount7.value= document.all.txtQty7.value*document.all.txtRate7.value	
	if(document.all.txtAmount7.value==0)
		document.all.txtAmount7.value=""
	document.all.txtAmount8.value= document.all.txtQty8.value*document.all.txtRate8.value	
	if(document.all.txtAmount8.value==0)
		document.all.txtAmount8.value=""
	document.all.txtGrandTotal.value = document.all.tmpGrandTotal.value  
	makeRound(document.all.txtGrandTotal);
	document.all.txtDisc.value = document.all.tmpDisc.value  
	makeRound(document.all.txtDisc);
	document.all.txtNetAmount.value = document.all.tmpNetAmount.value  
	makeRound(document.all.txtNetAmount);
	document.all.txtCashDisc.value = document.all.tmpCashDisc.value  
	makeRound(document.all.txtCashDisc.value);
	document.all.txtVAT.value = document.all.tmpVatAmount.value  
	makeRound(document.all.txtVAT);	
}  

function calc(txtQty,txtRate,txtTempQty)
{	
	var sarr = new Array()
	var temp ="";
	// alert(txtQty.value + "  "+txtTempQty.value);
	if(eval(txtQty.value) > eval(txtTempQty.value))
	{
		alert("Return quantity should not be greater than "+txtTempQty.value)
		//txtQty.value = "";
		txtQty.value = txtTempQty.value;
		return false;
	}
	//**************
	var tarr = new Array();
	var taxarr = new Array();
	var flag1=0;
	var tax = document.all.tempTaxEntry.value;
	tarr = tax.split("~");
	for(var i=0;i<tarr.length;i++)
	{
		taxarr=tarr[i].split(":");
		if(document.all.txtProdName1.value==taxarr[1])
		{
			calcTax(txtQty,txtTempQty)
			flag1=1;
		}
	}
	if(flag1==0)
	{
	//***************/
		document.all.txtAmount1.value=document.all.txtQty1.value*document.all.txtRate1.value	
		if(document.all.txtAmount1.value==0)
			document.all.txtAmount1.value=""
		document.all.txtAmount2.value= document.all.txtQty2.value*document.all.txtRate2.value	
 		if(document.all.txtAmount2.value==0)
			document.all.txtAmount2.value=""
		document.all.txtAmount3.value= document.all.txtQty3.value*document.all.txtRate3.value	
		if(document.all.txtAmount3.value==0)
			document.all.txtAmount3.value=""
		document.all.txtAmount4.value= document.all.txtQty4.value*document.all.txtRate4.value	
		if(document.all.txtAmount4.value==0)
			document.all.txtAmount4.value=""
		document.all.txtAmount5.value= document.all.txtQty5.value*document.all.txtRate5.value	
		if(document.all.txtAmount5.value==0)
			document.all.txtAmount5.value=""
		document.all.txtAmount6.value= document.all.txtQty6.value*document.all.txtRate6.value	
		if(document.all.txtAmount6.value==0)
			document.all.txtAmount6.value=""
		document.all.txtAmount7.value= document.all.txtQty7.value*document.all.txtRate7.value	
		if(document.all.txtAmount7.value==0)
			document.all.txtAmount7.value=""
		document.all.txtAmount8.value= document.all.txtQty8.value*document.all.txtRate8.value	
		if(document.all.txtAmount8.value==0)
			document.all.txtAmount8.value=""
		GetGrandTotal()
		GetNetAmount()
	}	
}

function GetGrandTotal()
{
	var GTotal=0
	if(document.all.txtAmount1.value!="" && document.all.Check1.checked == true)
	 	GTotal=GTotal+eval(document.all.txtAmount1.value)
	if(document.all.txtAmount2.value!="" && document.all.Check2.checked == true)
	 	GTotal=GTotal+eval(document.all.txtAmount2.value)
	if(document.all.txtAmount3.value!="" && document.all.Check3.checked == true)
	 	GTotal=GTotal+eval(document.all.txtAmount3.value)
	if(document.all.txtAmount4.value!="" && document.all.Check4.checked == true)
	 	GTotal=GTotal+eval(document.all.txtAmount4.value)
	if(document.all.txtAmount5.value!="" && document.all.Check5.checked == true)
	 	GTotal=GTotal+eval(document.all.txtAmount5.value)
	if(document.all.txtAmount6.value!="" && document.all.Check6.checked == true)
	 	GTotal=GTotal+eval(document.all.txtAmount6.value)
	if(document.all.txtAmount7.value!="" && document.all.Check7.checked == true)
	 	GTotal=GTotal+eval(document.all.txtAmount7.value)
	if(document.all.txtAmount8.value!="" && document.all.Check8.checked == true)
	 	GTotal=GTotal+eval(document.all.txtAmount8.value)
	document.all.txtGrandTotal.value=GTotal ;
	makeRound(document.all.txtGrandTotal);
}	
	
function GetCashDiscount()
{
	var CashDisc=document.all.txtCashDisc.value
	if(CashDisc=="" || isNaN(CashDisc))
		CashDisc=0
	if(document.all.txtCashDiscType.value=="%")
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
	if(document.all.txtDiscType.value=="%")
		Disc=vat_value * Disc/100 
	document.all.txtNetAmount.value=eval(vat_value) - eval(Disc);
	makeRound(document.all.txtNetAmount);
	if(document.all.txtNetAmount.value==0)
		document.all.txtNetAmount.value=""
}

//var ChkFlag = new Array(false,false,false,false)
//var QtyFlag = new Array(false,false,false,false)
function calcTax(txtQty,txtTempQty)
{
	var q=txtQty.name.substring(6)
	var Check = new Array(document.all.Check1,document.all.Check2,document.all.Check3,document.all.Check4);
	var ProdName = new Array(document.all.txtProdName1,document.all.txtProdName2,document.all.txtProdName3,document.all.txtProdName4);
	var Qty = new Array(document.all.txtQty1,document.all.txtQty2,document.all.txtQty3,document.all.txtQty4);
	var Rate = new Array(document.all.txtRate1,document.all.txtRate2,document.all.txtRate3,document.all.txtRate4);
	var Amount = new Array(document.all.txtAmount1,document.all.txtAmount2,document.all.txtAmount3,document.all.txtAmount4);
	var k=q-1;
	//for(var k=q-1;k<Check.length;k++)
	//{
		//alert(Check[k].checked+" and Flag "+ChkFlag[k])
		//if(Check[k].checked==true)// && (ChkFlag[k]==false || QtyFlag==false))
		//{
			//alert(Qty[k].value)
			if(Qty[k].value!="")
			{
				var tarr = new Array();
				var taxarr = new Array();
				var tax = document.all.tempTaxEntry.value;
				tarr = tax.split("~");
				var j=0;
				for(var i=0;i<tarr[j].length;i++)
				{
					taxarr=tarr[i].split(":");
					//alert(ProdName[k].value+" "+taxarr[1])
					if(ProdName[k].value==taxarr[1])
					{
						//alert("Enter");
						var init_cost=0;
						if(Qty[k].value!="")
							init_cost=(Qty[k].value)*(Rate[k].value);
						var reduc=0;
						if(taxarr[13] == "KL")
							reduc=eval(taxarr[2])*(Qty[k].value)
						else
							reduc=init_cost*eval(reduc)/100;  // % or KL
						var etax=taxarr[3];
						if(taxarr[14] == "%")
							etax=init_cost*eval(etax)/100;  // % or KL
						else
							etax=eval(etax)*(Qty[k].value)
						var rpocg=taxarr[4];
						if(taxarr[15] == "KL")
							rpocg=(rpocg)*(Qty[k].value); // % or KL
						else
							rpocg=init_cost*(rpocg)/100;		
						var rposcg=taxarr[5];
						if(taxarr[16] == "KL")
							rposcg=(rposcg)*(Qty[k].value); // % or KL
						else
							rposcg=init_cost*(rposcg)/100;		
						var ltchg=taxarr[6];
						if(taxarr[17] == "KL")
							ltchg=(ltchg)*(Qty[k].value); // % or KL
						else
							ltchg=init_cost*(ltchg)/100;		
						var Olv=taxarr[7];
						if(taxarr[18] == "KL")
							Olv=(Olv)*(Qty[k].value); // % or KL
						else
							Olv=init_cost*eval(Olv)/100;		
						var tcchg=taxarr[8];
						if(taxarr[19] == "KL")
							tcchg=(Qty[k].value)*(tcchg);  // To be verified later
						else
							tcchg=init_cost * eval(tcchg)/100;
						var lst=taxarr[9];// % or KL
						if(taxarr[20] == "%")
							lst=(init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg)*(lst)/100;
						else
							lst = lst * (Qty[k].value);
						var lstschg=taxarr[10];
						if(taxarr[21] == "%")
							lstschg=lst*(lstschg)/100; // % or KL
						else
							lstschg = eval(lstschg)*(Qty[k].value);
						var lfrecov=taxarr[11];
						if(taxarr[22] == "KL")
							lfrecov=(Qty[k].value)*(lfrecov);  // % or KL
						else
							lfrecov= init_cost*eval(lfrecov)/100;
						var Do=taxarr[12];
						if(taxarr[23] == "KL")
							Do=(Qty[k].value)*(Do);
						else
							Do = init_cost*eval(Do)/100;
						var tot=init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov+Do+Olv;
						//******
						Amount[k].value=tot
						makeRound(Amount[k])
						//******
						j++;
						GetGrandTotal();
						GetNetAmount();
						//if(ChkFlag[k]==false)
						//	ChkFlag[k]=true;
						break;
					}
				//}
			}
			//else
			//{
				//txtQty.value=eval(txtTempQty.value);
			//}
		}
	//}
}
/*
	if(document.Form1.Check2.checked==true)
	{
		if(document.Form1.txtQty2.value!="")
		{
			alert("Mahesh");
			var tarr = new Array();
			var taxarr = new Array();
			var tax = document.Form1.tempTaxEntry.value;
			tarr = tax.split("~");
			var j=0;
			for(var i=0;i<tarr[j].length;i++)
			{
				taxarr=tarr[i].split(":");
				if(document.Form1.txtProdName2.value==taxarr[1])
				{
					var init_cost=0;
					if(document.Form1.txtQty2.value!="")
						init_cost=(document.Form1.txtQty2.value)*(document.Form1.txtRate2.value);
					//else
					//	init_cost=document.Form1.tempRate1.value;
					var reduc=0;
					if(taxarr[13] == "KL")
						reduc=eval(taxarr[2])*(document.Form1.txtQty2.value)
					else
						reduc=init_cost*eval(reduc)/100;  // % or KL
					alert("reduc"+reduc)
					alert("init_cost"+init_cost)
					var etax=taxarr[3];
					if(taxarr[14] == "%")
						etax=init_cost*eval(etax)/100;  // % or KL
					else
						etax=eval(etax)*(document.Form1.txtQty2.value)
					alert("etax"+etax)
					var rpocg=taxarr[4];
					if(taxarr[15] == "KL")
						rpocg=(rpocg)*(document.Form1.txtQty2.value); // % or KL
					else
						rpocg=init_cost*(rpocg)/100;		
					alert("rpocg"+rpocg)
					var rposcg=taxarr[5];
					if(taxarr[16] == "KL")
						rposcg=(rposcg)*(document.Form1.txtQty2.value); // % or KL
					else
						rposcg=init_cost*(rposcg)/100;		
					alert("rposcg"+rposcg)
					var ltchg=taxarr[6];
					if(taxarr[17] == "KL")
						ltchg=(ltchg)*(document.Form1.txtQty2.value); // % or KL
					else
						ltchg=init_cost*(ltchg)/100;		
					alert("ltchg"+ltchg);
					var Olv=taxarr[7];
					if(taxarr[18] == "KL")
						Olv=(Olv)*(document.Form1.txtQty2.value); // % or KL
					else
						Olv=init_cost*eval(Olv)/100;		
					alert("Olv"+Olv);
					var tcchg=taxarr[8];
					if(taxarr[19] == "KL")
						tcchg=(document.Form1.txtQty2.value)*(tcchg);  // To be verified later
					else
						tcchg=init_cost * eval(tcchg)/100;
					alert("tcchg"+tcchg);
					alert("tcchg"+taxarr[20]);
					var lst=taxarr[9];// % or KL
					if(taxarr[20] == "%")
						lst=(init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg)*(lst)/100;
					else
						lst = lst * (document.Form1.txtQty2.value);
					alert("lst"+lst);
					var lstschg=taxarr[10];
					if(taxarr[21] == "%")
						lstschg=lst*(lstschg)/100; // % or KL
					else
						lstschg = eval(lstschg)*(document.Form1.txtQty2.value);
					alert("lstschg"+lstschg);
					var lfrecov=taxarr[11];
					if(taxarr[22] == "KL")
						lfrecov=(document.Form1.txtQty2.value)*(lfrecov);  // % or KL
					else
						lfrecov= init_cost*eval(lfrecov)/100;
					alert("lfrecov"+lfrecov);
					var Do=taxarr[12];
					if(taxarr[23] == "KL")
						Do=(document.Form1.txtQty2.value)*(Do);
					else
						Do = init_cost*eval(Do)/100;
					alert("Do"+Do);
					var tot=init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov+Do+Olv;
					alert(tot);
					//******
					document.Form1.txtAmount2.value=eval(tot)
					makeRound(document.Form1.txtAmount2)
					//******
					j++;
					GetGrandTotal();
					GetNetAmount();
					break;
				}
			}
		}
	}
	if(document.Form1.Check3.checked==true)
	{
		if(document.Form1.txtQty3.value!="")
		{
			var tarr = new Array();
			var taxarr = new Array();
			var tax = document.Form1.tempTaxEntry.value;
			tarr = tax.split("~");
			var j=0;
			for(var i=0;i<tarr[j].length;i++)
			{
				taxarr=tarr[i].split(":");
				if(document.Form1.txtProdName3.value==taxarr[1])
				{
					var init_cost=0;
					if(document.Form1.txtQty3.value!="")
						init_cost=(document.Form1.txtQty3.value)*(document.Form1.txtRate3.value);
					//else
					//	init_cost=document.Form1.tempRate1.value;
					var reduc=0;
					if(taxarr[13] == "KL")
						reduc=eval(taxarr[2])*(document.Form1.txtQty3.value)
					else
						reduc=init_cost*eval(reduc)/100;  // % or KL
					alert("reduc"+reduc)
					alert("init_cost"+init_cost)
					var etax=taxarr[3];
					if(taxarr[14] == "%")
						etax=init_cost*eval(etax)/100;  // % or KL
					else
						etax=eval(etax)*(document.Form1.txtQty3.value)
					alert("etax"+etax)
					var rpocg=taxarr[4];
					if(taxarr[15] == "KL")
						rpocg=(rpocg)*(document.Form1.txtQty3.value); // % or KL
					else
						rpocg=init_cost*(rpocg)/100;		
					alert("rpocg"+rpocg)
					var rposcg=taxarr[5];
					if(taxarr[16] == "KL")
						rposcg=(rposcg)*(document.Form1.txtQty3.value); // % or KL
					else
						rposcg=init_cost*(rposcg)/100;		
					alert("rposcg"+rposcg)
					var ltchg=taxarr[6];
					if(taxarr[17] == "KL")
						ltchg=(ltchg)*(document.Form1.txtQty3.value); // % or KL
					else
						ltchg=init_cost*(ltchg)/100;		
					alert("ltchg"+ltchg);
					var Olv=taxarr[7];
					if(taxarr[18] == "KL")
						Olv=(Olv)*(document.Form1.txtQty3.value); // % or KL
					else
						Olv=init_cost*eval(Olv)/100;		
					alert("Olv"+Olv);
					var tcchg=taxarr[8];
					if(taxarr[19] == "KL")
						tcchg=(document.Form1.txtQty3.value)*(tcchg);  // To be verified later
					else
						tcchg=init_cost * eval(tcchg)/100;
					alert("tcchg"+tcchg);
					alert("tcchg"+taxarr[20]);
					var lst=taxarr[9];// % or KL
					if(taxarr[20] == "%")
						lst=(init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg)*(lst)/100;
					else
						lst = lst * (document.Form1.txtQty3.value);
					alert("lst"+lst);
					var lstschg=taxarr[10];
					if(taxarr[21] == "%")
						lstschg=lst*(lstschg)/100; // % or KL
					else
						lstschg = eval(lstschg)*(document.Form1.txtQty3.value);
					alert("lstschg"+lstschg);
					var lfrecov=taxarr[11];
					if(taxarr[22] == "KL")
						lfrecov=(document.Form1.txtQty3.value)*(lfrecov);  // % or KL
					else
						lfrecov= init_cost*eval(lfrecov)/100;
					alert("lfrecov"+lfrecov);
					var Do=taxarr[12];
					if(taxarr[23] == "KL")
						Do=(document.Form1.txtQty3.value)*(Do);
					else
						Do = init_cost*eval(Do)/100;
					alert("Do"+Do);
					var tot=init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov+Do+Olv;
					alert(tot);
					//******
					document.Form1.txtAmount3.value=eval(tot)
					makeRound(document.Form1.txtAmount3)
					//******
					j++;
					GetGrandTotal();
					GetNetAmount();
					break;
				}
			}
		}
	}
	if(document.Form1.Check4.checked==true)
	{
		if(document.Form1.txtQty4.value!="")
		{
			var tarr = new Array();
			var taxarr = new Array();
			var tax = document.Form1.tempTaxEntry.value;
			tarr = tax.split("~");
			var j=0;
			for(var i=0;i<tarr[j].length;i++)
			{
				taxarr=tarr[i].split(":");
				if(document.Form1.txtProdName4.value==taxarr[1])
				{
					var init_cost=0;
					if(document.Form1.txtQty4.value!="")
						init_cost=(document.Form1.txtQty4.value)*(document.Form1.txtRate4.value);
					//else
					//	init_cost=document.Form1.tempRate1.value;
					var reduc=0;
					if(taxarr[13] == "KL")
						reduc=eval(taxarr[2])*(document.Form1.txtQty4.value)
					else
						reduc=init_cost*eval(reduc)/100;  // % or KL
					alert("reduc"+reduc)
					alert("init_cost"+init_cost)
					var etax=taxarr[3];
					if(taxarr[14] == "%")
						etax=init_cost*eval(etax)/100;  // % or KL
					else
						etax=eval(etax)*(document.Form1.txtQty4.value)
					alert("etax"+etax)
					var rpocg=taxarr[4];
					if(taxarr[15] == "KL")
						rpocg=(rpocg)*(document.Form1.txtQty4.value); // % or KL
					else
						rpocg=init_cost*(rpocg)/100;		
					alert("rpocg"+rpocg)
					var rposcg=taxarr[5];
					if(taxarr[16] == "KL")
						rposcg=(rposcg)*(document.Form1.txtQty4.value); // % or KL
					else
						rposcg=init_cost*(rposcg)/100;		
					alert("rposcg"+rposcg)
					var ltchg=taxarr[6];
					if(taxarr[17] == "KL")
						ltchg=(ltchg)*(document.Form1.txtQty4.value); // % or KL
					else
						ltchg=init_cost*(ltchg)/100;		
					alert("ltchg"+ltchg);
					var Olv=taxarr[7];
					if(taxarr[18] == "KL")
						Olv=(Olv)*(document.Form1.txtQty4.value); // % or KL
					else
						Olv=init_cost*eval(Olv)/100;		
					alert("Olv"+Olv);
					var tcchg=taxarr[8];
					if(taxarr[19] == "KL")
						tcchg=(document.Form1.txtQty4.value)*(tcchg);  // To be verified later
					else
						tcchg=init_cost * eval(tcchg)/100;
					alert("tcchg"+tcchg);
					alert("tcchg"+taxarr[20]);
					var lst=taxarr[9];// % or KL
					if(taxarr[20] == "%")
						lst=(init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg)*(lst)/100;
					else
						lst = lst * (document.Form1.txtQty4.value);
					alert("lst"+lst);
					var lstschg=taxarr[10];
					if(taxarr[21] == "%")
						lstschg=lst*(lstschg)/100; // % or KL
					else
						lstschg = eval(lstschg)*(document.Form1.txtQty4.value);
					alert("lstschg"+lstschg);
					var lfrecov=taxarr[11];
					if(taxarr[22] == "KL")
						lfrecov=(document.Form1.txtQty4.value)*(lfrecov);  // % or KL
					else
						lfrecov= init_cost*eval(lfrecov)/100;
					alert("lfrecov"+lfrecov);
					var Do=taxarr[12];
					if(taxarr[23] == "KL")
						Do=(document.Form1.txtQty4.value)*(Do);
					else
						Do = init_cost*eval(Do)/100;
					alert("Do"+Do);
					var tot=init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov+Do+Olv;
					alert(tot);
					//******
					document.Form1.txtAmount4.value=eval(tot)
					makeRound(document.Form1.txtAmount4)
					//******
					j++;
					GetGrandTotal();
					GetNetAmount();
					break;
				}
			}
		}
	}
}
*/
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="tmpQty4" style="Z-INDEX: 122; LEFT: 390px; WIDTH: 7px; POSITION: absolute; TOP: -3px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty4" runat="server"><INPUT id="tmpGrandTotal" style="Z-INDEX: 134; LEFT: 468px; WIDTH: 9px; POSITION: absolute; TOP: 5px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden2" runat="server"><INPUT id="tmpCashDisc" style="Z-INDEX: 130; LEFT: 483px; WIDTH: 6px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden3" runat="server"><INPUT id="tmpVatAmount" style="Z-INDEX: 131; LEFT: 496px; WIDTH: 7px; POSITION: absolute; TOP: 10px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden4" runat="server"><INPUT id="tmpDisc" style="Z-INDEX: 132; LEFT: 508px; WIDTH: 8px; POSITION: absolute; TOP: 10px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden5" runat="server"><INPUT id="tmpNetAmount" style="Z-INDEX: 133; LEFT: 526px; WIDTH: 10px; POSITION: absolute; TOP: 9px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="tmpQty5" style="Z-INDEX: 123; LEFT: 399px; WIDTH: 7px; POSITION: absolute; TOP: -1px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty5" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><INPUT id="TxtVen" style="Z-INDEX: 101; LEFT: -544px; POSITION: absolute; TOP: -16px" type="text"
				name="TxtVen" runat="server"> <INPUT id="TextBox1" style="Z-INDEX: 102; LEFT: -248px; WIDTH: 76px; POSITION: absolute; TOP: -40px; HEIGHT: 22px"
				 type="text" size="7" name="TextBox1" runat="server"> <INPUT id="TxtEnd" style="Z-INDEX: 103; LEFT: -208px; WIDTH: 52px; POSITION: absolute; TOP: -24px; HEIGHT: 22px"
				type="text" size="3" name="TxtEnd" runat="server"><INPUT id="Txtstart" style="Z-INDEX: 104; LEFT: -336px; WIDTH: 83px; POSITION: absolute; TOP: -16px; HEIGHT: 22px"
				type="text" size="8" name="Txtstart" runat="server"> <INPUT id="TxtCrLimit" style="Z-INDEX: 105; LEFT: -448px; WIDTH: 70px; POSITION: absolute; TOP: -16px; HEIGHT: 22px"
				accessKey="TxtEnd" type="text" size="6" name="TxtCrLimit" runat="server">
			<asp:textbox id="TextSelect" style="Z-INDEX: 106; LEFT: 216px; POSITION: absolute; TOP: 16px"
				runat="server" Width="16px" Visible="False"></asp:textbox><asp:textbox id="TextBox2" style="Z-INDEX: 107; LEFT: 192px; POSITION: absolute; TOP: 24px" runat="server"
				Width="8px" Visible="False" BorderStyle="Groove"></asp:textbox><asp:textbox id="TxtCrLimit1" style="Z-INDEX: 108; LEFT: 176px; POSITION: absolute; TOP: 16px"
				runat="server" Width="16px" Visible="False" BorderStyle="Groove" ></asp:textbox><INPUT id="temptext" style="Z-INDEX: 109; LEFT: 152px; WIDTH: 16px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="temptext" runat="server">
			<asp:textbox id="txtTempQty1" style="Z-INDEX: 110; LEFT: 240px; POSITION: absolute; TOP: 16px"
				runat="server" Width="6px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty2" style="Z-INDEX: 111; LEFT: 256px; POSITION: absolute; TOP: 8px"
				runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty3" style="Z-INDEX: 112; LEFT: 272px; POSITION: absolute; TOP: 8px"
				runat="server" Width="4px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty4" style="Z-INDEX: 113; LEFT: 284px; POSITION: absolute; TOP: 8px"
				runat="server" Width="9px" Visible="False"></asp:textbox><asp:textbox id="TextBox7" style="Z-INDEX: 114; LEFT: 336px; POSITION: absolute; TOP: 0px" runat="server"
				Width="2px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty5" style="Z-INDEX: 115; LEFT: 296px; POSITION: absolute; TOP: 8px"
				runat="server" Width="4px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty6" style="Z-INDEX: 116; LEFT: 304px; POSITION: absolute; TOP: 8px"
				runat="server" Width="4px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty7" style="Z-INDEX: 117; LEFT: 312px; POSITION: absolute; TOP: 0px"
				runat="server" Width="4px" Visible="False"></asp:textbox><asp:textbox id="txtTempQty8" style="Z-INDEX: 118; LEFT: 320px; POSITION: absolute; TOP: 0px"
				runat="server" Width="8px" Visible="False"></asp:textbox><INPUT id="tmpQty1" style="Z-INDEX: 119; LEFT: 350px; WIDTH: 10px; POSITION: absolute; TOP: 2px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty1" runat="server"> <INPUT id="tmpQty2" style="Z-INDEX: 120; LEFT: 365px; WIDTH: 7px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty2" runat="server"><INPUT id="tmpQty3" style="Z-INDEX: 121; LEFT: 377px; WIDTH: 7px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty3" runat="server"><INPUT id="tmpQty6" style="Z-INDEX: 124; LEFT: 410px; WIDTH: 6px; POSITION: absolute; TOP: 0px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty6" runat="server"><INPUT id="tmpQty7" style="Z-INDEX: 125; LEFT: 416px; WIDTH: 5px; POSITION: absolute; TOP: -7px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty7" runat="server"><INPUT id="tmpQty8" style="Z-INDEX: 126; LEFT: 422px; WIDTH: 2px; POSITION: absolute; TOP: -7px; HEIGHT: 22px"
				type="hidden" size="1" name="tmpQty8" runat="server"> <INPUT id="txtVatRate" style="Z-INDEX: 127; LEFT: 432px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatRate" runat="server"> <INPUT id="txtVatValue" style="Z-INDEX: 128; LEFT: 452px; WIDTH: 5px; POSITION: absolute; TOP: 6px; HEIGHT: 22px"
				type="hidden" size="1" name="txtVatValue" runat="server"><INPUT id="tempTaxEntry" style="Z-INDEX: 128; LEFT: 452px; WIDTH: 5px; POSITION: absolute; TOP: 6px; HEIGHT: 22px"
				type="hidden" size="1" name="tempTaxEntry" runat="server">
			<table height="278" width="778" align="center">
				<tr>
					<th align="center" colSpan="3">
						<font color="#006400">Purchase&nbsp;Return Credit Note</font>
						<hr>
						<asp:label id="lblMessage" runat="server" ForeColor="DarkGreen" Font-Size="8pt"></asp:label></th></tr>
				<tr>
					<td align="center">
						<TABLE width="550" border="1">
							<TBODY>
								<TR>
									<TD vAlign="middle" align="center">
										<TABLE cellSpacing="0" cellPadding="0">
											<TR>
												<TD vAlign="middle">&nbsp; Invoice No</TD>
												<TD vAlign="middle"><asp:dropdownlist id="dropInvoiceNo" runat="server" Width="135px" CssClass="FontStyle" AutoPostBack="True">
														<asp:ListItem Value="Select">Select</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD>&nbsp; Invoice Date</TD>
												<TD><asp:label id="lblInvoiceDate" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD>&nbsp; Vendor InvoiceNo.&nbsp; &nbsp;</TD>
												<TD><INPUT class="FontStyle" id="lblVendInvoiceNo" style="WIDTH: 135px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														disabled  type="text" size="22" name="lblVendInvoiceNo" runat="server"></TD>
											</TR>
											<TR>
												<TD>&nbsp; Vendor Invoice Date&nbsp;&nbsp;</TD>
												<TD><INPUT class="FontStyle" id="lblVendInvoiceDate" style="WIDTH: 135px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														disabled  type="text" size="22" name="lblVendInvoiceDate" runat="server"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD vAlign="middle" align="center">
										<TABLE style="WIDTH: 267px" cellSpacing="0" cellPadding="0">
											<TR>
												<TD style="WIDTH: 145px">Vendor Name</TD>
												<TD><INPUT class="FontStyle" id="lblVendName" style="WIDTH: 158px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														disabled  type="text" size="22" name="lblCustName" runat="server"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 145px">Place</TD>
												<TD><INPUT class="FontStyle" id="lblPlace" style="WIDTH: 158px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														disabled  type="text" size="22" name="lblPlace" runat="server"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 145px">Vehicle No</TD>
												<TD><INPUT class="FontStyle" id="lblVehicleNo" style="WIDTH: 158px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 22px; BORDER-BOTTOM-STYLE: groove"
														disabled  type="text" size="22" name="lblVehicleNo" runat="server"></TD>
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
													<TD align="center"><FONT color="#006400">Name</FONT></TD>
													<TD align="center"><FONT color="#006400">&nbsp;&nbsp;&nbsp;&nbsp;Package</FONT></TD>
													<TD align="center"><FONT color="#006400">Qty
															<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtQty1" ErrorMessage="Please Fill Quentity"><font color="red">*</font></asp:requiredfieldvalidator></FONT></TD>
													<TD align="center"><FONT color="#006400">Rate</FONT></TD>
													<TD align="center"><FONT color="#006400">Amount</FONT></TD>
													<TD align="center"><FONT color="#006400">Select</FONT></TD>
												</TR>
												<TR>
													<TD><INPUT class="FontStyle" id="txtProdName1" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtProdName1" runat="server"></TD>
													<TD><INPUT class="FontStyle" id="txtPack1" style="WIDTH: 100px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtPack1" runat="server"></TD>
													<TD align="center"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty1" onblur="calc(this,document.all.txtRate1,document.all.tmpQty1)"
															runat="server" size="22" Width="52px" BorderStyle="Groove" CssClass="FontStyle" Enabled="False" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate1" runat="server" size="22" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"
															Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount1" runat="server" size="22" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD align="center"><INPUT id="Check1" onclick="select1(document.all.Check1,document.all.txtProdName1,document.all.txtPack1,document.all.txtQty1,document.all.txtRate1,document.all.txtAmount1,document.all.tmpQty1)"
															type="checkbox" name="Checkbox1" runat="server"></TD>
												</TR>
												<TR>
													<TD><INPUT class="FontStyle" id="txtProdName2" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtProdName2" runat="server"></TD>
													<TD><INPUT class="FontStyle" id="txtPack2" style="WIDTH: 100px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtPack2" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty2" onblur="calc(this,document.all.txtRate2,document.all.tmpQty2)"
															runat="server" size="22" Width="52px" BorderStyle="Groove" CssClass="FontStyle" Enabled="False" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate2" runat="server" size="22" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"
															Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount2" runat="server" size="22" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD align="center"><INPUT id="Check2" onclick="select1(document.all.Check2,document.all.txtProdName2,document.all.txtPack2,document.all.txtQty2,document.all.txtRate2,document.all.txtAmount2,document.all.tmpQty2)"
															type="checkbox" name="Checkbox1" runat="server"></TD>
												</TR>
												<TR>
													<TD><INPUT class="FontStyle" id="txtProdName3" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtProdName3" runat="server"></TD>
													<TD><INPUT class="FontStyle" id="txtPack3" style="WIDTH: 100px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtPack3" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty3" onblur="calc(this,document.all.txtRate3,document.all.tmpQty3)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" Enabled="False" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate3" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"
															Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount3" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD align="center"><INPUT id="Check3" onclick="select1(document.all.Check3,document.all.txtProdName3,document.all.txtPack3,document.all.txtQty3,document.all.txtRate3,document.all.txtAmount3,document.all.tmpQty3)"
															type="checkbox" name="Checkbox1" runat="server"></TD>
												</TR>
												<TR>
													<TD><INPUT class="FontStyle" id="txtProdName4" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtProdName4" runat="server"></TD>
													<TD><INPUT class="FontStyle" id="txtPack4" style="WIDTH: 100px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtPack4" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty4" onblur="calc(this,document.all.txtRate4,document.all.tmpQty4)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" Enabled="False" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate4" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"
															Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount4" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD align="center"><INPUT id="Check4" onclick="select1(document.all.Check4,document.all.txtProdName4,document.all.txtPack4,document.all.txtQty4,document.all.txtRate4,document.all.txtAmount4,document.all.tmpQty4)"
															type="checkbox" name="Checkbox1" runat="server"></TD>
												</TR>
												<TR>
													<TD><INPUT class="FontStyle" id="txtProdName5" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtProdName5" runat="server">
													</TD>
													<TD><INPUT class="FontStyle" id="txtPack5" style="WIDTH: 100px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtPack5" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty5" onblur="calc(this,document.all.txtRate5,document.all.tmpQty5)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" Enabled="False" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate5" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"
															Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount5" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD align="center"><INPUT id="Check5" onclick="select1(document.all.Check5,document.all.txtProdName5,document.all.txtPack5,document.all.txtQty5,document.all.txtRate5,document.all.txtAmount5,document.all.tmpQty5)"
															type="checkbox" name="Checkbox1" runat="server"></TD>
												</TR>
												<TR>
													<TD><INPUT class="FontStyle" id="txtProdName6" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtProdName6" runat="server"></TD>
													<TD><INPUT class="FontStyle" id="txtPack6" style="WIDTH: 100px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtPack6" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty6" onblur="calc(this,document.all.txtRate6,document.all.tmpQty6)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" Enabled="False" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate6" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"
															Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount6" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD align="center"><INPUT id="Check6" onclick="select1(document.all.Check6,document.all.txtProdName6,document.all.txtPack6,document.all.txtQty6,document.all.txtRate6,document.all.txtAmount6,document.all.tmpQty6)"
															type="checkbox" name="Checkbox1" runat="server"></TD>
												</TR>
												<TR>
													<TD><INPUT class="FontStyle" id="txtProdName7" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtProdName7" runat="server"></TD>
													<TD><INPUT class="FontStyle" id="txtPack7" style="WIDTH: 100px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtPack7" runat="server"></TD>
													<TD><asp:textbox id="txtQty7" onblur="calc(this,document.all.txtRate7,document.all.tmpQty7)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" Enabled="False" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate7" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"
															Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount7" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD align="center"><INPUT id="Check7" onclick="select1(document.all.Check7,document.all.txtProdName7,document.all.txtPack7,document.all.txtQty7,document.all.txtRate7,document.all.txtAmount7,document.all.tmpQty7)"
															type="checkbox" name="Checkbox1" runat="server"></TD>
												</TR>
												<TR>
													<TD><INPUT class="FontStyle" id="txtProdName8" style="WIDTH: 168px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtProdName8" runat="server"></TD>
													<TD><INPUT class="FontStyle" id="txtPack8" style="WIDTH: 100px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove;  BORDER-BOTTOM-STYLE: groove"
															disabled  type="text" size="22" name="txtPack8" runat="server"></TD>
													<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtQty8" onblur="calc(this,document.all.txtRate8,document.all.tmpQty8)"
															runat="server" Width="52px" BorderStyle="Groove" CssClass="FontStyle" Enabled="False" MaxLength="5"></asp:textbox></TD>
													<TD><asp:textbox id="txtRate8" runat="server" Width="52px" BorderStyle="Groove"  CssClass="FontStyle"
															Enabled="False"></asp:textbox></TD>
													<TD><asp:textbox id="txtAmount8" runat="server" Width="79px" BorderStyle="Groove" 
															CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
													<TD align="center"><INPUT id="Check8" onclick="select1(document.all.Check8,document.all.txtProdName8,document.all.txtPack8,document.all.txtQty8,document.all.txtRate8,document.all.txtAmount8,document.all.tmpQty8)"
															type="checkbox" name="Checkbox1" runat="server"></TD>
												</TR>
												<TR>
													<TD></TD>
													<TD></TD>
													<TD></TD>
													<TD></TD>
													<TD>Select All</TD>
													<TD align="center"><INPUT id="CheckAll" onclick="return selectAll();" type="checkbox" name="Checkbox9" runat="server"></TD>
												</TR>
											</TBODY>
										</TABLE>
									</TD>
								</TR>
							</TBODY>
						</TABLE>
						<TABLE style="WIDTH: 529px" cellSpacing="0" cellPadding="0">
							<TR>
								<TD style="WIDTH: 150px">Promo Scheme</TD>
								<TD style="WIDTH: 184px"><asp:textbox id="txtPromoScheme" runat="server" Width="150px" BorderStyle="Groove" 
										CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
								<TD style="WIDTH: 24px"></TD>
								<TD style="WIDTH: 80px">Grand Total</TD>
								<TD><asp:textbox id="txtGrandTotal" runat="server" Width="124px" BorderStyle="Groove" 
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px">Remark</TD>
								<TD style="WIDTH: 184px">
									<P><asp:textbox id="txtRemark" runat="server" Width="150px" BorderStyle="Groove" 
											CssClass="FontStyle" Enabled="False"></asp:textbox></P>
								</TD>
								<TD style="WIDTH: 24px"></TD>
								<TD style="WIDTH: 80px">Cash Discount</TD>
								<TD><asp:textbox id="txtCashDisc" onblur="GetNetAmount()" runat="server" Width="67px" BorderStyle="Groove"
										 CssClass="FontStyle" Height="22px"></asp:textbox><asp:textbox id="txtCashDiscType" onblur="GetNetAmount()" runat="server" Width="56px" BorderStyle="Groove"
										 CssClass="FontStyle" Enabled="False" Height="22px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px">Message</TD>
								<TD style="WIDTH: 184px"><asp:textbox id="txtMessage" runat="server" Width="150px" BorderStyle="Groove" 
										CssClass="FontStyle" Enabled="False"></asp:textbox></TD>
								<TD style="WIDTH: 24px"></TD>
								<TD style="WIDTH: 80px">VAT
									<asp:radiobutton id="No" onclick="return GetNetAmount();" runat="server" Enabled="False" BackColor="#FFE0C0"
										GroupName="VAT" ToolTip="Not Applied"></asp:radiobutton>&nbsp;<asp:radiobutton id="Yes" onclick="return GetNetAmount();" runat="server" Enabled="False" BackColor="#C0FFC0"
										GroupName="VAT" ToolTip="Applied" Checked="True"></asp:radiobutton></TD>
								<TD><asp:textbox id="txtVAT" runat="server" Width="124px" BorderStyle="Groove"  CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px"></TD>
								<TD style="WIDTH: 184px">
									<P>&nbsp;</P>
								</TD>
								<TD style="WIDTH: 24px"></TD>
								<TD style="WIDTH: 80px">Discount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtDisc" onblur="GetNetAmount()" runat="server" Width="67px" BorderStyle="Groove"
										 CssClass="FontStyle" Height="22px"></asp:textbox><asp:textbox id="txtDiscType" onblur="GetNetAmount()" runat="server" Width="56px" BorderStyle="Groove"
										 CssClass="FontStyle" Enabled="False" Height="22px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px"></TD>
								<TD style="WIDTH: 184px"></TD>
								<TD style="WIDTH: 24px"></TD>
								<TD style="WIDTH: 80px">Net Amount</TD>
								<TD><asp:textbox id="txtNetAmount" runat="server" Width="124px" BorderStyle="Groove" 
										CssClass="FontStyle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px">Entry&nbsp;By</TD>
								<TD style="WIDTH: 184px"><asp:label id="lblEntryBy" runat="server"></asp:label></TD>
								<TD style="WIDTH: 24px"></TD>
								<TD style="WIDTH: 80px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 150px">Entry Date &amp; Time</TD>
								<TD style="WIDTH: 184px"><asp:label id="lblEntryTime" runat="server"></asp:label></TD>
								<TD style="WIDTH: 24px"></TD>
								<TD align="right" colSpan="2"><asp:button id="btnSave" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
										Text="Save" BorderColor="ForestGreen"></asp:button>&nbsp;<asp:button id="btnPrint" runat="server" Width="70px" ForeColor="White" BackColor="ForestGreen"
										CausesValidation="False" Text="Print" BorderColor="ForestGreen"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		<script language="C#">


		</script>
	</body>
</HTML>
