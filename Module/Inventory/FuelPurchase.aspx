<%@ Register TagPrefix="uc1" TagName="Header1" Src="../../HeaderFooter/Header1.ascx" %>
<%@ Page language="c#" Codebehind="FuelPurchase.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.FuelPurchase" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<title>ePetro: Fuel Purchase Invoice</title>
<meta content=False name=vs_showGrid> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<script language=javascript id=sales src="../../Sysitem/Js/Fuel.js"></script>

<script language=javascript>
		

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
	
	function calc1()
	{
		if(document.all.txtQty2.value!="")
	    {
			if(document.all.DropProd2.selectedIndex > 0) 
			{   
			    var unitArr = new Array();
				var temp = document.all.txtUnit5.value;
			    unitArr = temp.split("#");
	    	    
				//var init_cost=(document.Form1.txtQty2.value)*(document.Form1.txtRate2.value);
				var init_cost=(document.all.txtQty2.value)*(document.all.tempRate2.value);
				var reduc=document.all.txtReduction5.value;
				if(unitArr[0] == "KL")
				{
					reduc=eval(reduc)*(document.all.txtQty2.value)
				}
				else
				{
					reduc=init_cost*eval(reduc)/100;  // % or KL
				}
				document.all.txtReduction2.value = reduc
				makeRound(document.all.txtReduction2);
		
				var etax=document.all.txtEntryTax5.value;
				if(unitArr[1] == "%")
				{
					etax=init_cost*eval(etax)/100;  // % or KL
				}
				else
				{
					etax=eval(etax)*(document.all.txtQty2.value)
		
				}	
				document.all.txtEntryTax2.value = etax;
				makeRound(document.all.txtEntryTax2);
				
				var rpocg=document.all.txtRPGCharge5.value;
				if(unitArr[2] == "KL")
				{
					rpocg=(rpocg)*(document.all.txtQty2.value); // % or KL
				}
				else
				{
					rpocg=init_cost*(rpocg)/100;		
				}
				document.all.txtRPGCharge2.value = rpocg;
				makeRound(document.all.txtRPGCharge2);
			
				var rposcg=(document.all.txtRPGSurcharge5.value);
				if(unitArr[3] == "KL")
				{
					rposcg=(rposcg)*(document.all.txtQty2.value); // % or KL
				}
				else
				{
					rposcg=init_cost*(rposcg)/100;		
				}
				document.all.txtRPGSurcharge2.value = rposcg;
				makeRound(document.all.txtRPGSurcharge2);
		
				var ltchg=document.all.txtLTC5.value;
				if(unitArr[4] == "KL")
				{
					ltchg=(ltchg)*(document.all.txtQty2.value); // % or KL
				}
				else
				{
					ltchg=init_cost*(ltchg)/100;		
				}
				document.all.txtLTC2.value = ltchg;
				makeRound(document.all.txtLTC2);
		
				var Olv=document.all.txtOther5.value;
				if(unitArr[6] == "KL")
				{
					Olv=(Olv)*(document.all.txtQty2.value); // % or KL
				}
				else
				{
					Olv=init_cost*eval(Olv)/100;		
				}
				document.all.txtOther2.value = Olv;
				makeRound(document.all.txtOther2);
		
				var tcchg=document.all.txtTransportCharge5.value;
				if(unitArr[5] == "KL")
				{
					tcchg=(document.all.txtQty2.value)*(tcchg);  // To be verified later
				}
				else
				{
					tcchg=init_cost * eval(tcchg)/100;
				}
				document.all.txtTransportCharge2.value = tcchg;
				makeRound(document.all.txtTransportCharge2);
		
				var lst=document.all.txtLST5.value;// % or KL
				if(unitArr[7] == "%")
				{
					lst=(init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg)*(lst)/100;
				}
				else
				{
					lst = lst * (document.all.txtQty2.value);
				}
				document.all.txtLST2.value = lst;
				makeRound(document.all.txtLST2);
		
				var lstschg=document.all.txtLSTSurcharge5.value;
				if(unitArr[8] == "%")
				{
					lstschg=lst*(lstschg)/100; // % or KL
				}
				else
				{
					lstschg = eval(lstschg)*(document.all.txtQty2.value);
				}
				document.all.txtLSTSurcharge2.value = lstschg;
				makeRound(document.all.txtLSTSurcharge2);
		
				var lfrecov=document.all.txtLFR5.value;
				if(unitArr[9] == "KL")
				{
					lfrecov=(document.all.txtQty2.value)*(lfrecov);  // % or KL
				}
				else
				{
					lfrecov= init_cost*eval(lfrecov)/100;
				}
				document.all.txtLFR2.value = lfrecov;
				makeRound(document.all.txtLFR2);
		
				var Do=document.all.txtDO5.value;
				if(unitArr[10] == "KL")
				{
					Do=(document.all.txtQty2.value)*(Do);
				}
				else
				{
					Do = init_cost*eval(Do)/100;
				}
				document.all.txtDO2.value = Do;
				makeRound(document.all.txtDO2);
		
				var tot=init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov+Do+Olv;
		
				document.all.txtAmount2.value=tot;
				makeRound(document.all.txtAmount2);
		
				document.all.TextBox12.value=init_cost;
				document.all.txtRate2.value=init_cost;
				makeRound(document.all.txtRate2)
				document.all.TextBox13.value=reduc;
				document.all.TextBox1.value=etax;
				document.all.TextBox2.value=rpocg;
				document.all.TextBox3.value=rposcg;
				document.all.TextBox4.value=ltchg;
				document.all.TextBox5.value=tcchg;
				document.all.TextBox6.value=Olv;
				document.all.TextBox7.value=lst;
				document.all.TextBox8.value=lstschg;
				document.all.TextBox9.value=lfrecov;
				document.all.TextBox10.value=Do;
				document.all.TextBox11.value=tot;
				GetGrandTotal();
				GetNetAmount();
			}
			else
			{
				document.all.txtReduction2.value = "";
				document.all.txtEntryTax2.value = "";
				document.all.txtRPGCharge2.value = "";
				document.all.txtRPGSurcharge2.value = "";
				document.all.txtLTC2.value = "";
				document.all.txtOther2.value = "";
				document.all.txtTransportCharge2.value = "";
				document.all.txtLST2.value = "";
				document.all.txtLSTSurcharge2.value = "";
				document.all.txtLFR2.value = "";
				document.all.txtDO2.value = "";
				document.all.txtAmount2.value="";
				document.all.TextBox12.value="";
				document.all.txtRate2.value="";
				document.all.TextBox13.value="";
				document.all.TextBox1.value="";
				document.all.TextBox2.value="";
				document.all.TextBox3.value="";
				document.all.TextBox4.value="";
				document.all.TextBox5.value="";
				document.all.TextBox6.value="";
				document.all.TextBox7.value="";
				document.all.TextBox8.value="";
				document.all.TextBox9.value="";
				document.all.TextBox10.value="";
				document.all.TextBox11.value="";
				GetGrandTotal();
				GetNetAmount();
			}
		}
		else
		{
			document.all.txtReduction2.value = "";
			document.all.txtEntryTax2.value = "";
			document.all.txtRPGCharge2.value = "";
			document.all.txtRPGSurcharge2.value = "";
			document.all.txtLTC2.value = "";
			document.all.txtOther2.value = "";
			document.all.txtTransportCharge2.value = "";
			document.all.txtLST2.value = "";
			document.all.txtLSTSurcharge2.value = "";
			document.all.txtLFR2.value = "";
			document.all.txtDO2.value = "";
			document.all.txtAmount2.value="";
			document.all.TextBox12.value="";
			document.all.txtRate2.value="";
			document.all.TextBox13.value="";
			document.all.TextBox1.value="";
			document.all.TextBox2.value="";
			document.all.TextBox3.value="";
			document.all.TextBox4.value="";
			document.all.TextBox5.value="";
			document.all.TextBox6.value="";
			document.all.TextBox7.value="";
			document.all.TextBox8.value="";
			document.all.TextBox9.value="";
			document.all.TextBox10.value="";
			document.all.TextBox11.value="";
			GetGrandTotal();
			GetNetAmount();
		}
	}
	
	function calc2()
	{
		if(document.all.txtQty3.value!="")
	    {
			if(document.all.DropProd3.selectedIndex > 0) 
			{
				var unitArr = new Array();
				var temp = document.all.txtUnit6.value;
			    unitArr = temp.split("#");
	
				//var init_cost=(document.Form1.txtQty3.value)*(document.Form1.txtRate3.value);
				var init_cost=(document.all.txtQty3.value)*(document.all.tempRate3.value);
				var reduc=document.all.txtReduction6.value;
				if(unitArr[0] == "KL")
				{
					reduc=eval(reduc)*(document.all.txtQty3.value)
				}
				else
				{
					reduc=init_cost*eval(reduc)/100;  // % or KL
				}
				document.all.txtReduction3.value = reduc
				makeRound(document.all.txtReduction3);
		
				var etax=document.all.txtEntryTax6.value;
				if(unitArr[1] == "%")
				{
					etax=init_cost*eval(etax)/100;  // % or KL
				}
				else
				{
					etax=eval(etax)*(document.all.txtQty3.value)
				}	
				document.all.txtEntryTax3.value = etax;
				makeRound(document.all.txtEntryTax3);
		
				var rpocg=document.all.txtRPGCharge6.value;
				if(unitArr[2] == "KL")
				{
					rpocg=(rpocg)*(document.all.txtQty3.value); // % or KL
				}
				else
				{
					rpocg=init_cost*(rpocg)/100;		
				}
				document.all.txtRPGCharge3.value = rpocg
				makeRound(document.all.txtRPGCharge3);
	
				var rposcg=(document.all.txtRPGSurcharge6.value);
				if(unitArr[3] == "KL")
				{
					rposcg=(rposcg)*(document.all.txtQty3.value); // % or KL
				}
				else
				{
					rposcg=init_cost*(rposcg)/100;		
				}
				document.all.txtRPGSurcharge3.value = rposcg;
				makeRound(document.all.txtRPGSurcharge3);
		
				var ltchg=document.all.txtLTC6.value;
				if(unitArr[4] == "KL")
				{
					ltchg=(ltchg)*(document.all.txtQty3.value); // % or KL
				}
				else
				{
					ltchg=init_cost*(ltchg)/100;		
				}
				document.all.txtLTC3.value = ltchg;
				makeRound(document.all.txtLTC3);
		
				var Olv=document.all.txtOther6.value;
				if(unitArr[6] == "KL")
				{
					Olv=(Olv)*(document.all.txtQty3.value); // % or KL
				}
				else
				{
					Olv=init_cost*eval(Olv)/100;		
				}
				document.all.txtOther3.value = Olv;
				makeRound( document.all.txtOther3);
		
				var tcchg=document.all.txtTransportCharge6.value;
				if(unitArr[5] == "KL")
				{
					tcchg=(document.all.txtQty3.value)*(tcchg);  // To be verified later
				}
				else
				{
					tcchg=init_cost * eval(tcchg)/100;
				}
				document.all.txtTransportCharge3.value = tcchg;
				makeRound(document.all.txtTransportCharge3);
		
				var lst=document.all.txtLST6.value;// % or KL
				if(unitArr[7] == "%")
				{
					lst=(init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg)*(lst)/100;
				}
				else
				{
					lst = lst * (document.all.txtQty3.value);
				}
				document.all.txtLST3.value = lst;
				makeRound(document.all.txtLST3);
		
				var lstschg=document.all.txtLSTSurcharge6.value;
				if(unitArr[8] == "%")
				{
					lstschg=lst*(lstschg)/100; // % or KL
				}
				else
				{
					lstschg = eval(lstschg)*(document.all.txtQty3.value);
				}
				document.all.txtLSTSurcharge3.value = lstschg;
				makeRound(document.all.txtLSTSurcharge3);
		
				var lfrecov=document.all.txtLFR6.value;
				if(unitArr[9] == "KL")
				{
					lfrecov=(document.all.txtQty3.value)*(lfrecov);  // % or KL
				}
				else
				{
					lfrecov= init_cost*eval(lfrecov)/100;
				}
				document.all.txtLFR3.value = lfrecov;
				makeRound(document.all.txtLFR3);
		
				var Do=document.all.txtDO6.value;
				if(unitArr[10] == "KL")
				{
					Do=(document.all.txtQty3.value)*(Do);
				}
				else
				{
					Do = init_cost*eval(Do)/100;
				}
				document.all.txtDO3.value = Do;
				makeRound(document.all.txtDO3);
		
				var tot=init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov+Do+Olv;
				document.all.txtAmount3.value=tot;
				makeRound(document.all.txtAmount3);
				document.all.TextBox14.value=init_cost;
				document.all.txtRate3.value=init_cost;
				makeRound(document.all.txtRate3)
				document.all.TextBox45.value=reduc;
				document.all.TextBox16.value=etax;
				document.all.TextBox17.value=rpocg;
				document.all.TextBox18.value=rposcg;
				document.all.TextBox19.value=ltchg;
				document.all.TextBox20.value=tcchg;
				document.all.TextBox21.value=Olv;
				document.all.TextBox22.value=lst;
				document.all.TextBox23.value=lstschg;
				document.all.TextBox24.value=lfrecov;
				document.all.TextBox25.value=Do;
				document.all.TextBox26.value=tot;
				GetGrandTotal();
				GetNetAmount();
			}
			else
			{
				document.all.txtReduction3.value = "";
				document.all.txtEntryTax3.value = "";
				document.all.txtRPGCharge3.value = "";
				document.all.txtRPGSurcharge3.value = "";
				document.all.txtLTC3.value = "";
				document.all.txtOther3.value = "";
				document.all.txtTransportCharge3.value = "";
				document.all.txtLST3.value = "";
				document.all.txtLSTSurcharge3.value = "";
				document.all.txtLFR3.value = "";
				document.all.txtDO3.value = "";
				document.all.txtAmount3.value="";
				document.all.TextBox14.value="";
				document.all.txtRate3.value="";
				document.all.TextBox45.value="";
				document.all.TextBox16.value="";
				document.all.TextBox17.value="";
				document.all.TextBox18.value="";
				document.all.TextBox19.value="";
				document.all.TextBox20.value="";
				document.all.TextBox21.value="";
				document.all.TextBox22.value="";
				document.all.TextBox23.value="";
				document.all.TextBox24.value="";
				document.all.TextBox25.value="";
				document.all.TextBox26.value="";
				GetGrandTotal();
				GetNetAmount();
			}
		}
		else
		{
			document.all.txtReduction3.value = "";
			document.all.txtEntryTax3.value = "";
			document.all.txtRPGCharge3.value = "";
			document.all.txtRPGSurcharge3.value = "";
			document.all.txtLTC3.value = "";
			document.all.txtOther3.value = "";
			document.all.txtTransportCharge3.value = "";
			document.all.txtLST3.value = "";
			document.all.txtLSTSurcharge3.value = "";
			document.all.txtLFR3.value = "";
			document.all.txtDO3.value = "";
			document.all.txtAmount3.value="";
			document.all.TextBox14.value="";
			document.all.txtRate3.value="";
			document.all.TextBox45.value="";
			document.all.TextBox16.value="";
			document.all.TextBox17.value="";
			document.all.TextBox18.value="";
			document.all.TextBox19.value="";
			document.all.TextBox20.value="";
			document.all.TextBox21.value="";
			document.all.TextBox22.value="";
			document.all.TextBox23.value="";
			document.all.TextBox24.value="";
			document.all.TextBox25.value="";
			document.all.TextBox26.value="";
			GetGrandTotal();
			GetNetAmount();
		}
	}
	
	
	
	function calc3()
	{
		if(document.all.txtQty4.value!="")
	    {
			if(document.all.DropProd4.selectedIndex > 0) 
			{
				var unitArr = new Array();
				var temp = document.all.txtUnit7.value;
			    unitArr = temp.split("#");
	    	    
				//var init_cost=(document.all.txtQty4.value)*(document.all.txtRate4.value);
				var init_cost=(document.all.txtQty4.value)*(document.all.tempRate4.value);
				var reduc=document.all.txtReduction7.value;
				if(unitArr[0] == "KL")
				{
					reduc=eval(reduc)*(document.all.txtQty4.value)
				}
				else
				{
					reduc=init_cost*eval(reduc)/100;  // % or KL
				}
				document.all.txtReduction4.value = reduc
				makeRound(document.all.txtReduction4);
		
				var etax=document.all.txtEntryTax7.value;
				if(unitArr[1] == "%")
				{
					etax=init_cost*eval(etax)/100;  // % or KL
				}
				else
				{
					etax=eval(etax)*(document.all.txtQty4.value)
				}	
				document.all.txtEntryTax4.value = etax;
				makeRound(document.all.txtEntryTax4);
		
				var rpocg=document.all.txtRPGCharge7.value;
				if(unitArr[2] == "KL")
				{
					rpocg=(rpocg)*(document.all.txtQty4.value); // % or KL
				}
				else
				{
					rpocg=init_cost*(rpocg)/100;		
				}
				document.all.txtRPGCharge4.value = rpocg
				makeRound(document.all.txtRPGCharge4);
	
				var rposcg=(document.all.txtRPGSurcharge7.value);
				if(unitArr[3] == "KL")
				{
					rposcg=(rposcg)*(document.all.txtQty4.value); // % or KL
				}
				else
				{
					rposcg=init_cost*(rposcg)/100;		
				}
				document.all.txtRPGSurcharge4.value = rposcg;
				makeRound(document.all.txtRPGSurcharge4);
		
				var ltchg=document.all.txtLTC7.value;
				if(unitArr[4] == "KL")
				{
					ltchg=(ltchg)*(document.all.txtQty4.value); // % or KL
				}
				else
				{
					ltchg=init_cost*(ltchg)/100;		
				}
				document.all.txtLTC4.value = ltchg;
				makeRound(document.all.txtLTC4);
		
				var Olv=document.all.txtOther7.value;
				if(unitArr[6] == "KL")
				{
					Olv=(Olv)*(document.all.txtQty4.value); // % or KL
				}
				else
				{
					Olv=init_cost*eval(Olv)/100;		
				}
				document.all.txtOther4.value = Olv;
				makeRound(document.all.txtOther4);
		
				var tcchg=document.all.txtTransportCharge7.value;
				if(unitArr[5] == "KL")
				{
					tcchg=(document.all.txtQty4.value)*(tcchg);  // To be verified later
				}
				else
				{
					tcchg=init_cost * eval(tcchg)/100;
				}
				document.all.txtTransportCharge4.value = tcchg;
				makeRound(document.all.txtTransportCharge4);
		
				var lst=document.all.txtLST7.value;// % or KL
				if(unitArr[7] == "%")
				{
					lst=(init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg)*(lst)/100;
				}
				else
				{
					lst = lst * (document.all.txtQty4.value);
				}
				document.all.txtLST4.value = lst;
				makeRound(document.all.txtLST4);
		
				var lstschg=document.all.txtLSTSurcharge7.value;
				if(unitArr[8] == "%")
				{
					lstschg=lst*(lstschg)/100; // % or KL
				}
				else
				{
					lstschg = eval(lstschg)*(document.all.txtQty4.value);
				}
				document.all.txtLSTSurcharge4.value = lstschg;
				makeRound(document.all.txtLSTSurcharge4);
		
				var lfrecov=document.all.txtLFR7.value;
				if(unitArr[9] == "KL")
				{
					lfrecov=(document.all.txtQty4.value)*(lfrecov);  // % or KL
				}
				else
				{
					lfrecov= init_cost*eval(lfrecov)/100;
				}
				document.all.txtLFR4.value = lfrecov;
				makeRound(document.all.txtLFR4);
		
				var Do=document.all.txtDO7.value;
				if(unitArr[10] == "KL")
				{
					Do=(document.all.txtQty4.value)*(Do);
				}
				else
				{
					Do = init_cost*eval(Do)/100;
				}
				document.all.txtDO4.value = Do;
				makeRound(document.all.txtDO4);
		
				var tot=init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov+Do+Olv;
		
				document.all.txtAmount4.value=tot;
				makeRound(document.all.txtAmount4);
				document.all.TextBox27.value=init_cost;
				document.all.txtRate4.value=init_cost;
				makeRound(document.all.txtRate4)
				init_cost=0
				document.all.TextBox28.value=reduc;
				document.all.TextBox29.value=etax;
				document.all.TextBox30.value=rpocg;
				document.all.TextBox31.value=rposcg;
				document.all.TextBox32.value=ltchg;
				document.all.TextBox33.value=tcchg;
				document.all.TextBox34.value=Olv;
				document.all.TextBox35.value=lst;
				document.all.TextBox43.value=lfrecov;
				document.all.TextBox46.value=lstschg;
				document.all.TextBox47.value=Do;
				document.all.TextBox39.value=tot;
				GetGrandTotal();
				GetNetAmount();
			}
			else
			{
				document.all.txtReduction4.value = "";
				document.all.txtEntryTax4.value = "";
				document.all.txtRPGCharge4.value = "";
				document.all.txtRPGSurcharge4.value = "";
				document.all.txtLTC4.value = "";
				document.all.txtOther4.value = "";
				document.all.txtTransportCharge4.value = "";
				document.all.txtLST4.value = "";
				document.all.txtLSTSurcharge4.value = "";
				document.all.txtLFR4.value = "";
				document.all.txtDO4.value = "";
				document.all.txtAmount4.value="";
				document.all.TextBox27.value="";
				document.all.txtRate4.value="";
				document.all.TextBox28.value="";
				document.all.TextBox29.value="";
				document.all.TextBox30.value="";
				document.all.TextBox31.value="";
				document.all.TextBox32.value="";
				document.all.TextBox33.value="";
				document.all.TextBox34.value="";
				document.all.TextBox35.value="";
				document.all.TextBox43.value="";
				document.all.TextBox46.value="";
				document.all.TextBox47.value="";
				document.all.TextBox39.value="";
				GetGrandTotal();
				GetNetAmount();
			}
		}
		else
		{
			document.all.txtReduction4.value = "";
			document.all.txtEntryTax4.value = "";
			document.all.txtRPGCharge4.value = "";
			document.all.txtRPGSurcharge4.value = "";
			document.all.txtLTC4.value = "";
			document.all.txtOther4.value = "";
			document.all.txtTransportCharge4.value = "";
			document.all.txtLST4.value = "";
			document.all.txtLSTSurcharge4.value = "";
			document.all.txtLFR4.value = "";
			document.all.txtDO4.value = "";
			document.all.txtAmount4.value="";
			document.all.TextBox27.value="";
			document.all.txtRate4.value="";
			document.all.TextBox28.value="";
			document.all.TextBox29.value="";
			document.all.TextBox30.value="";
			document.all.TextBox31.value="";
			document.all.TextBox32.value="";
			document.all.TextBox33.value="";
			document.all.TextBox34.value="";
			document.all.TextBox35.value="";
			document.all.TextBox43.value="";
			document.all.TextBox46.value="";
			document.all.TextBox47.value="";
			document.all.TextBox39.value="";
			GetGrandTotal();
			GetNetAmount();
		}
	}
	
	function calc()
	{
	    if(document.all.txtQty1.value!="")
	    {
			if(document.all.DropProd1.selectedIndex > 0) 
			{
				var unitArr = new Array();
				var temp = document.all.txtUnit.value;
			    unitArr = temp.split("#");
				//var init_cost=(document.all.txtQty1.value)*(document.all.txtRate1.value);
				var init_cost=0;
				//alert(document.all.tempRate1.value)
				if(document.all.txtQty1.value!="")
					init_cost=(document.all.txtQty1.value)*(document.all.tempRate1.value);
				else
					init_cost=document.all.tempRate1.value;
				var reduc=document.all.txtReduction.value;
				if(unitArr[0] == "KL")
				{
					reduc=eval(reduc)*(document.all.txtQty1.value)
				}
				else
				{
					reduc=init_cost*eval(reduc)/100;  // % or KL
				}
				document.all.txtReduction1.value = reduc
				makeRound(document.all.txtReduction1);
				var etax=document.all.txtEntryTax.value;
	
				if(unitArr[1] == "%")
				{
					etax=init_cost*eval(etax)/100;  // % or KL
				}
				else
				{
					etax=eval(etax)*(document.all.txtQty1.value)
				}	
	
				document.all.txtEntryTax1.value = etax;
				makeRound(document.all.txtEntryTax1);
		
				var rpocg=document.all.txtRPGCharge.value;
				if(unitArr[2] == "KL")
				{
					rpocg=(rpocg)*(document.all.txtQty1.value); // % or KL
				}
				else
				{
					rpocg=init_cost*(rpocg)/100;		
				}
				document.all.txtRPGCharge1.value = rpocg
				makeRound(document.all.txtRPGCharge1);
			
				var rposcg=(document.all.txtRPGSurcharge.value);
				if(unitArr[3] == "KL")
				{
					rposcg=(rposcg)*(document.all.txtQty1.value); // % or KL
				}
				else
				{
					rposcg=init_cost*(rposcg)/100;		
				}
				document.all.txtRPGSurcharge1.value = rposcg;
				makeRound(document.all.txtRPGSurcharge1);
		
				var ltchg=document.all.txtLTC.value;
				if(unitArr[4] == "KL")
				{
					ltchg=(ltchg)*(document.all.txtQty1.value); // % or KL
				}
				else
				{
					ltchg=init_cost*(ltchg)/100;		
				}
				document.all.txtLTC1.value = ltchg;
				makeRound(document.all.txtLTC1);
		
				var Olv=document.all.txtOther.value;
				if(unitArr[6] == "KL")
				{
					Olv=(Olv)*(document.all.txtQty1.value); // % or KL
				}
				else
				{
					Olv=init_cost*eval(Olv)/100;		
				}
				 document.all.txtOther1.value = Olv;
				 makeRound(document.all.txtOther1);
		
				var tcchg=document.all.txtTransportCharge.value;
				if(unitArr[5] == "KL")
				{
					tcchg=(document.all.txtQty1.value)*(tcchg);  // To be verified later
				}
				else
				{
					tcchg=init_cost * eval(tcchg)/100;
				}
				document.all.txtTransportCharge1.value = tcchg;
				makeRound(document.all.txtTransportCharge1);
		
				var lst=document.all.txtLST.value;// % or KL
				if(unitArr[7] == "%")
				{
					lst=(init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg)*(lst)/100;
				}
				else
				{
					lst = lst * (document.all.txtQty1.value);
				}
				document.all.txtLST1.value = lst;
				makeRound(document.all.txtLST1);
				
				var lstschg=document.all.txtLSTSurcharge.value;
				if(unitArr[8] == "%")
				{
					lstschg=lst*(lstschg)/100; // % or KL
				}
				else
				{
					lstschg = eval(lstschg)*(document.all.txtQty1.value);
				}
				document.all.txtLSTSurcharge1.value = lstschg;
				makeRound(document.all.txtLSTSurcharge1);
		
				var lfrecov=document.all.txtLFR.value;
				if(unitArr[9] == "KL")
				{
					lfrecov=(document.all.txtQty1.value)*(lfrecov);  // % or KL
				}	
				else
				{
					lfrecov= init_cost*eval(lfrecov)/100;
				}
				document.all.txtLFR1.value = lfrecov;
				makeRound(document.all.txtLFR1);
		
				var Do=document.all.txtDO.value;
				if(unitArr[10] == "KL")
				{
					Do=(document.all.txtQty1.value)*(Do);
				}
				else
				{
					Do = init_cost*eval(Do)/100;
				}
				document.all.txtDO1.value = Do;
				makeRound(document.all.txtDO1);
		
				var tot=init_cost-reduc+etax+rpocg+rposcg+ltchg+tcchg+lst+lstschg+lfrecov+Do+Olv;
		
				document.all.txtAmount1.value=tot;
				makeRound(document.all.txtAmount1);
				
				document.all.Duptext1.value=init_cost;
				document.all.txtRate1.value=init_cost;
				makeRound(document.all.txtRate1)
				document.all.Duptext2.value=reduc;
				document.all.TextBox40.value=etax;
				document.all.Duptext4.value=rpocg;
				document.all.Duptext5.value=rposcg;
				document.all.Duptext6.value=ltchg;
				document.all.Duptext7.value=Olv;
				document.all.Duptext8.value=tcchg;
				document.all.Duptext9.value=lst;
				document.all.Duptext10.value=lstschg;
				document.all.Duptext11.value=lfrecov;
				document.all.TextBox38.value=Do;
				document.all.Duptext13.value=tot;
				GetGrandTotal();
				GetNetAmount();
			}
			else
			{
				document.all.txtReduction1.value = "";
				document.all.txtEntryTax1.value = "";
				document.all.txtRPGCharge1.value = "";
				document.all.txtRPGSurcharge1.value = "";
				document.all.txtLTC1.value = "";
				document.all.txtOther1.value = "";
				document.all.txtTransportCharge1.value = "";
				document.all.txtLST1.value = "";
				document.all.txtLSTSurcharge1.value = "";
				document.all.txtLFR1.value = "";
				document.all.txtDO1.value = "";
				document.all.txtAmount1.value="";
				document.all.Duptext1.value="";
				document.all.txtRate1.value="";
				document.all.Duptext2.value="";
				document.all.TextBox40.value="";
				document.all.Duptext4.value="";
				document.all.Duptext5.value="";
				document.all.Duptext6.value="";
				document.all.Duptext7.value="";
				document.all.Duptext8.value="";
				document.all.Duptext9.value="";
				document.all.Duptext10.value="";
				document.all.Duptext11.value="";
				document.all.TextBox38.value="";
				document.all.Duptext13.value="";
				GetGrandTotal();
				GetNetAmount();
			}
		}
		else
		{
			document.all.txtReduction1.value = "";
			document.all.txtEntryTax1.value = "";
			document.all.txtRPGCharge1.value = "";
			document.all.txtRPGSurcharge1.value = "";
			document.all.txtLTC1.value = "";
			document.all.txtOther1.value = "";
			document.all.txtTransportCharge1.value = "";
			document.all.txtLST1.value = "";
			document.all.txtLSTSurcharge1.value = "";
			document.all.txtLFR1.value = "";
			document.all.txtDO1.value = "";
			document.all.txtAmount1.value="";
			document.all.Duptext1.value="";
			document.all.txtRate1.value="";
			document.all.Duptext2.value="";
			document.all.TextBox40.value="";
			document.all.Duptext4.value="";
			document.all.Duptext5.value="";
			document.all.Duptext6.value="";
			document.all.Duptext7.value="";
			document.all.Duptext8.value="";
			document.all.Duptext9.value="";
			document.all.Duptext10.value="";
			document.all.Duptext11.value="";
			document.all.TextBox38.value="";
			document.all.Duptext13.value="";
			GetGrandTotal();
			GetNetAmount();
		}
	}
	function calc_diff(t,u,v)
	{
	t.value=u.value -v.value;
	makeRound(t);
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
	 document.all.txtGrandTotal.value= GTotal
	 makeRound(document.all.txtGrandTotal);
	}	
	
	function GetNetAmount()
	{
	document.all.TotalDisc.value=""	
	 var Disc=document.all.txtDisc.value
	 if(Disc=="")
		Disc=0
	 var NetAmount
		if(document.all.DropDiscType.value=="Per")
			Disc=document.all.txtGrandTotal.value*Disc/100 
		//********
		var t1,t2,t3,t4
		if(document.all.DropDiscType.value=="KL")
		{
			if(document.all.txtQty1.value=="")
				t1 = 0
			else
				t1 = document.all.txtQty1.value
			if(document.all.txtQty2.value=="")
				t2 = 0
			else
				t2 = document.all.txtQty2.value
			if(document.all.txtQty3.value=="")
				t3 = 0
			else
				t3 = document.all.txtQty3.value
			if(document.all.txtQty4.value=="")
				t4 = 0
			else
				t4 = document.all.txtQty4.value
			var Net=eval(t1)+eval(t2)+eval(t3)+eval(t4)
			Disc = Disc * Net
		}
		document.all.TotalDisc.value=Disc
		//********
		//*********Start add Mahesh - Roundoff net amount - 1.10.007
		//document.Form1.txtNetAmount.value=eval(document.Form1.txtGrandTotal.value) - eval(Disc)
		var NetAmount=eval(document.all.txtGrandTotal.value) - eval(Disc)
		NetAmount = Math.round(NetAmount)
		document.all.txtNetAmount.value=NetAmount;
		//****end
		if(document.all.txtNetAmount.value==0)
			document.all.txtNetAmount.value==""
		makeRound(document.all.txtNetAmount);
			//document.Form1.TotalDisc.value=document.Form1.txtNetAmount.value;
	}
	//Check the value of density becouse 771 to 789 data in dbase not available.
	//Mahesh, date : 28/11/06.
	function checkden(t)
	{
		if(t.value != "")
		{
			if(t.value <= 679 || t.value >= 771 && t.value <= 789 || t.value >= 861)
			{
				t.value=""
				alert("Invalid Density Value,(680 To 770 And 790 To 860)...")
			}
		}
	}
	function checkDelRec()
	{
		if(document.all.btnEdit == null)
		{
		    if (document.all.DropInvoiceNo.value != "Select")
			{
				if(confirm("Do You Want To Delete The Product"))
				    document.all.tempInvoiceInfo.value = "Yes";
				else
				    document.all.tempInvoiceInfo.value = "No";
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
		if (document.all.tempInvoiceInfo.value == "Yes")
		    document.forms[0].submit();
	}
	</script>

<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<script language=javascript id=Validations src="../../Sysitem/Js/Validations.js"></script>

<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../Sysitem/Styles.css" type=text/css rel=stylesheet >
  </HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form1 name=Form1 method=post runat="server"><INPUT 
id=FuelText 
style="Z-INDEX: 217; LEFT: -304px; WIDTH: 221px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=31 name=FuelText runat="server"> <asp:textbox id=txtTempQty4 style="Z-INDEX: 225; LEFT: 176px; POSITION: absolute; TOP: 8px" runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id=txtTempQty3 style="Z-INDEX: 224; LEFT: 168px; POSITION: absolute; TOP: 0px" runat="server" Width="8px" Visible="False"></asp:textbox><asp:textbox id=txtTempQty2 style="Z-INDEX: 223; LEFT: 160px; POSITION: absolute; TOP: 8px" runat="server" Width="8px" Visible="False"></asp:textbox><INPUT 
id=Duptext9 
style="Z-INDEX: 103; LEFT: -440px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=Duptext9 runat="server"> <INPUT 
id=Duptext1 
style="Z-INDEX: 113; LEFT: -144px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=Duptext1 runat="server"><INPUT 
id=Duptext2 
style="Z-INDEX: 112; LEFT: -184px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=Duptext2 runat="server"><INPUT 
id=Duptext4 
style="Z-INDEX: 111; LEFT: -256px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=Duptext4 runat="server"><INPUT 
id=Duptext5 
style="Z-INDEX: 110; LEFT: -296px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=Duptext5 runat="server"><INPUT 
id=Duptext6 
style="Z-INDEX: 109; LEFT: -336px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=Duptext6 runat="server"><INPUT 
id=Duptext7 
style="Z-INDEX: 108; LEFT: -368px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=Duptext7 runat="server"><INPUT 
id=Duptext8 
style="Z-INDEX: 107; LEFT: -408px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=Duptext8 runat="server"><INPUT 
id=Duptext10 
style="Z-INDEX: 106; LEFT: -472px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 24px" 
type=text size=1 name=Duptext10 runat="server"><INPUT 
id=Duptext11 
style="Z-INDEX: 105; LEFT: -520px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=Duptext11 runat="server"><INPUT 
style="Z-INDEX: 104; LEFT: -560px; WIDTH: 24px; POSITION: absolute; TOP: 16px; HEIGHT: 22px" 
accessKey=Duptext12 type=text size=1 name=Duptext12 
runat="server"><INPUT 
style="Z-INDEX: 101; LEFT: -224px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 runat="server"><INPUT id=Duptext13 
style="Z-INDEX: 114; LEFT: -608px; WIDTH: 34px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=Duptext13 runat="server"><asp:label id=lblEntryTime style="Z-INDEX: 115; LEFT: -752px; POSITION: absolute; TOP: -24px" runat="server" Width="65px" DESIGNTIMEDRAGDROP="10362">Label</asp:label><INPUT 
id=TextBox1 
style="Z-INDEX: 116; LEFT: -184px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox1 runat="server"><INPUT 
id=TextBox2 
style="Z-INDEX: 117; LEFT: -248px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox2 runat="server"><INPUT 
id=TextBox3 
style="Z-INDEX: 118; LEFT: -232px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox3 runat="server"> <INPUT 
id=TextBox4 
style="Z-INDEX: 119; LEFT: -184px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox4 runat="server"><INPUT 
id=TextBox5 
style="Z-INDEX: 120; LEFT: -240px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox5 runat="server"><INPUT 
id=TextBox6 
style="Z-INDEX: 121; LEFT: -296px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox6 runat="server"><INPUT 
id=TextBox7 
style="Z-INDEX: 122; LEFT: -240px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox7 runat="server"><INPUT 
id=TextBox8 
style="Z-INDEX: 123; LEFT: -208px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox8 runat="server"><INPUT 
id=TextBox9 
style="Z-INDEX: 124; LEFT: -288px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox9 runat="server"><INPUT 
id=TextBox10 
style="Z-INDEX: 125; LEFT: -352px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox10 runat="server"><INPUT 
id=TextBox11 
style="Z-INDEX: 126; LEFT: -328px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox11 runat="server"> <INPUT 
id=TextBox12 
style="Z-INDEX: 127; LEFT: -192px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox12 runat="server"><INPUT 
id=TextBox13 
style="Z-INDEX: 128; LEFT: -264px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox13 runat="server"><INPUT 
id=TextBox14 
style="Z-INDEX: 129; LEFT: -312px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox14 runat="server"><INPUT 
id=TextBox15 
style="Z-INDEX: 130; LEFT: -344px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox15 runat="server"><INPUT 
id=TextBox16 
style="Z-INDEX: 131; LEFT: -432px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox16 runat="server"> <INPUT 
id=TextBox17 
style="Z-INDEX: 132; LEFT: -480px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox17 runat="server"> <INPUT 
id=TextBox18 
style="Z-INDEX: 133; LEFT: -168px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox18 runat="server"><INPUT 
id=TextBox19 
style="Z-INDEX: 134; LEFT: -240px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox19 runat="server"><INPUT 
id=TextBox20 
style="Z-INDEX: 135; LEFT: -232px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=TextBox20 runat="server"><INPUT 
id=TextBox21 
style="Z-INDEX: 136; LEFT: -288px; WIDTH: 26px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox21 runat="server"><INPUT 
id=TextBox22 
style="Z-INDEX: 137; LEFT: -320px; WIDTH: 18px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox22 runat="server"><INPUT 
id=TextBox23 
style="Z-INDEX: 138; LEFT: -168px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox23 runat="server"><INPUT 
id=TextBox24 
style="Z-INDEX: 139; LEFT: -160px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox24 runat="server"> <INPUT 
id=TextBox25 
style="Z-INDEX: 140; LEFT: -168px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox25 runat="server"><INPUT 
id=TextBox26 
style="Z-INDEX: 141; LEFT: -240px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox26 runat="server"><INPUT 
id=TextBox27 
style="Z-INDEX: 142; LEFT: -304px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox27 runat="server"><INPUT 
id=TextBox28 
style="Z-INDEX: 143; LEFT: -216px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox28 runat="server"><INPUT 
id=TextBox29 
style="Z-INDEX: 144; LEFT: -208px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox29 runat="server"><INPUT 
id=TextBox30 
style="Z-INDEX: 145; LEFT: -208px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox30 runat="server"><INPUT 
id=TextBox31 
style="Z-INDEX: 146; LEFT: -304px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox31 runat="server"><INPUT 
id=TextBox32 
style="Z-INDEX: 147; LEFT: -368px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox32 runat="server"><INPUT 
id=TextBox33 
style="Z-INDEX: 148; LEFT: -352px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox33 runat="server"><INPUT 
id=TextBox34 
style="Z-INDEX: 149; LEFT: -448px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox34 runat="server"><INPUT 
id=TextBox43 
style="Z-INDEX: 150; LEFT: -504px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox43 runat="server"><INPUT 
id=TextBox44 
style="Z-INDEX: 151; LEFT: -552px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox44 runat="server"><INPUT 
id=TextBox47 
style="Z-INDEX: 152; LEFT: -616px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox47 runat="server"><INPUT 
id=TextBox46 
style="Z-INDEX: 153; LEFT: -512px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=TextBox46 runat="server"><INPUT 
id=TextBox45 
style="Z-INDEX: 154; LEFT: -496px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=TextBox45 runat="server"><INPUT 
style="Z-INDEX: 155; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1><INPUT id=TextBox42 
style="Z-INDEX: 156; LEFT: -448px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox42 runat="server"><INPUT 
id=TextBox41 
style="Z-INDEX: 157; LEFT: -424px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox41 runat="server"><INPUT 
id=TextBox40 
style="Z-INDEX: 158; LEFT: -416px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox40 runat="server"><INPUT 
id=TextBox39 
style="Z-INDEX: 159; LEFT: -408px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=39 runat="server"><INPUT id=TextBox38 
style="Z-INDEX: 160; LEFT: -408px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox38 runat="server"><INPUT 
id=TextBox37 
style="Z-INDEX: 161; LEFT: -400px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox37 runat="server"><INPUT 
id=TextBox36 
style="Z-INDEX: 162; LEFT: -576px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox36 runat="server"><INPUT 
id=TextBox60 
style="Z-INDEX: 163; LEFT: -672px; WIDTH: 24px; POSITION: absolute; TOP: -24px; HEIGHT: 22px" 
type=text size=1 name=TextBox60><INPUT id=TextBox50 
style="Z-INDEX: 164; LEFT: -656px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
type=text size=1 name=TextBox50><INPUT id=TextBox49 
style="Z-INDEX: 165; LEFT: -616px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=TextBox49><INPUT id=TextBox48 
style="Z-INDEX: 166; LEFT: -544px; WIDTH: 24px; POSITION: absolute; TOP: -32px; HEIGHT: 22px" 
type=text size=1 name=TextBox48><INPUT id=TextBox35 
style="Z-INDEX: 214; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=TextBox35 runat="server"><INPUT 
id=txtUnit 
style="Z-INDEX: 193; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtUnit runat="server"> <INPUT 
id=txtRate 
style="Z-INDEX: 187; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRate runat="server"> <INPUT 
id=txtReduction 
style="Z-INDEX: 169; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtReduction runat="server"> <INPUT 
id=txtEntryTax 
style="Z-INDEX: 195; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtEntryTax runat="server"> <INPUT 
id=txtRPGCharge 
style="Z-INDEX: 171; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRPGCharge runat="server"> <INPUT 
id=txtRPGSurcharge 
style="Z-INDEX: 216; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRPGSurcharge runat="server"> 
<INPUT id=txtLTC 
style="Z-INDEX: 173; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLTC runat="server"> <INPUT 
id=txtTransportCharge 
style="Z-INDEX: 197; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtTransportCharge runat="server"> 
<INPUT id=txtOther 
style="Z-INDEX: 175; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtOther runat="server"> <INPUT 
id=txtLST 
style="Z-INDEX: 209; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLST runat="server"> <INPUT 
id=txtLSTSurcharge 
style="Z-INDEX: 177; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLSTSurcharge runat="server"> 
<INPUT id=txtLFR 
style="Z-INDEX: 199; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLFR runat="server"> <INPUT 
id=txtDO 
style="Z-INDEX: 179; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtDO runat="server"><uc1:header id=Header1 runat="server"></uc1:header><INPUT 
id=TxtVen style="Z-INDEX: 218; LEFT: -528px; POSITION: absolute; TOP: -24px" 
type=text name=TxtVen runat="server"> <INPUT id=txtUnit5 
style="Z-INDEX: 181; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtUnit5 runat="server"> <INPUT 
id=txtReduction5 
style="Z-INDEX: 201; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtReduction5 runat="server"> <INPUT 
id=txtEntryTax5 
style="Z-INDEX: 183; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtEntryTax5 runat="server"> <INPUT 
id=txtRPGCharge5 
style="Z-INDEX: 211; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRPGCharge5 runat="server"> <INPUT 
id=txtRPGSurcharge5 
style="Z-INDEX: 185; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRPGSurcharge5 runat="server"> 
<INPUT id=txtLTC5 
style="Z-INDEX: 203; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLTC5 runat="server"> <asp:textbox id=txtTempQty1 style="Z-INDEX: 221; LEFT: 152px; POSITION: absolute; TOP: 8px" runat="server" Width="8px" Visible="False"></asp:textbox><INPUT 
id=txtTransportCharge5 
style="Z-INDEX: 215; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtTransportCharge5 runat="server"> 
<INPUT id=txtOther5 
style="Z-INDEX: 189; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtOther5 runat="server"> <INPUT 
id=txtLST5 
style="Z-INDEX: 205; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLST5 runat="server"> <INPUT 
id=txtLSTSurcharge5 
style="Z-INDEX: 191; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLSTSurcharge5 runat="server"> 
<INPUT id=txtLFR5 
style="Z-INDEX: 213; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLFR5 runat="server"> <INPUT 
id=txtDO5 
style="Z-INDEX: 167; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtDO5 runat="server"> <INPUT 
id=txtUnit6 
style="Z-INDEX: 207; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtUnit6 runat="server"> <INPUT 
id=txtReduction6 
style="Z-INDEX: 168; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtReduction6 runat="server"> <INPUT 
id=txtEntryTax6 
style="Z-INDEX: 170; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtEntryTax6 runat="server"> <INPUT 
id=txtRPGCharge6 
style="Z-INDEX: 172; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRPGCharge6 runat="server"> <INPUT 
id=txtRPGSurcharge6 
style="Z-INDEX: 174; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRPGSurcharge6 runat="server"> 
<INPUT id=txtLTC6 
style="Z-INDEX: 176; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLTC6 runat="server"> <INPUT 
id=txtTransportCharge6 
style="Z-INDEX: 178; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtTransportCharge6 runat="server"> 
<INPUT id=txtOther6 
style="Z-INDEX: 180; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtOther6 runat="server"> <INPUT 
id=txtLST6 
style="Z-INDEX: 182; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLST6 runat="server"> <INPUT 
id=txtLSTSurcharge6 
style="Z-INDEX: 184; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLSTSurcharge6 runat="server"> 
<INPUT id=txtLFR6 
style="Z-INDEX: 186; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLFR6 runat="server"> <INPUT 
id=txtDO6 
style="Z-INDEX: 188; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtDO6 runat="server"> <INPUT 
id=txtUnit7 
style="Z-INDEX: 190; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtUnit7 runat="server"> <INPUT 
id=txtReduction7 
style="Z-INDEX: 192; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtReduction7 runat="server"> <INPUT 
id=txtEntryTax7 
style="Z-INDEX: 194; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtEntryTax7 runat="server"> <INPUT 
id=txtRPGCharge7 
style="Z-INDEX: 196; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRPGCharge7 runat="server"> <INPUT 
id=txtRPGSurcharge7 
style="Z-INDEX: 198; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtRPGSurcharge7 runat="server"> 
<INPUT id=txtLTC7 
style="Z-INDEX: 200; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLTC7 runat="server"> <INPUT 
id=txtTransportCharge7 
style="Z-INDEX: 202; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtTransportCharge7 runat="server"> 
<INPUT id=txtOther7 
style="Z-INDEX: 204; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtOther7 runat="server"> <INPUT 
id=txtLST7 
style="Z-INDEX: 206; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLST7 runat="server"> <INPUT 
id=txtLSTSurcharge7 
style="Z-INDEX: 208; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLSTSurcharge7 runat="server"> 
<INPUT id=txtLFR7 
style="Z-INDEX: 210; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtLFR7 runat="server"> <INPUT 
id=txtDO7 
style="Z-INDEX: 212; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=txtDO7 runat="server"><INPUT 
id=lblTinNo 
style="Z-INDEX: 212; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=text size=1 name=lblTinNo runat="server"><INPUT 
id=tempRate1 
style="Z-INDEX: 212; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=hidden size=1 name=tempRate1 runat="server"><INPUT 
id=tempRate2 
style="Z-INDEX: 212; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=hidden size=1 name=tempRate2 runat="server"><INPUT 
id=tempRate3 
style="Z-INDEX: 212; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=hidden size=1 name=tempRate3 runat="server"><INPUT 
id=tempRate4 
style="Z-INDEX: 212; LEFT: -488px; WIDTH: 24px; POSITION: absolute; TOP: -8px; HEIGHT: 22px" 
type=hidden size=1 name=tempRate4 runat="server"> <asp:textbox id=textselect style="Z-INDEX: 219; LEFT: -248px; POSITION: absolute; TOP: -24px" runat="server" Width="63px"></asp:textbox><asp:textbox id=TextBox51 style="Z-INDEX: 220; LEFT: 144px; POSITION: absolute; TOP: 16px" runat="server" Width="8px" Visible="False"></asp:textbox><input 
id=tempInvoiceInfo style="WIDTH: 1px" type=hidden name=tempInvoiceInfo runat="server"> 
<table height=288 cellPadding=0 width=778 align=center>
  <TR>
    <TH align=center colSpan=3><asp:label id=lblPlace1 runat="server"></asp:label><font 
      color=#006400>Fuel&nbsp;Purchase Invoice</font>&nbsp; 

      <HR>
    </TH></TR>
  <tr>
    <TD align=center>&nbsp; 
      <TABLE cellSpacing=0 cellPadding=0 width=600 border=1>
        <TBODY>
        <TR><TDALIGNCOLSPAN="2"="CENTER"><asp:label id=lblMessage runat="server" Font-Bold="True" ForeColor="DarkGreen"></asp:label></TD></tr>
        <TR>
          <TD vAlign=middle align=center><U 
            ><FONT color=#990066>
            <TABLE cellSpacing=1 cellPadding=1>
              <TR>
                <TD>Invoice No </TD>
                <TD><asp:label id=lblInvoiceNo runat="server" ForeColor="Blue"></asp:label><asp:dropdownlist id=DropInvoiceNo runat="server" Width="117px" CssClass="FontStyle" AutoPostBack="True">
<asp:ListItem Value="Select">Select</asp:ListItem>
														</asp:dropdownlist></TD>
                <td><asp:button id=btnEdit runat="server" Width="25px"  ToolTip="Click For Edit" Text="..." CausesValidation="False"></asp:button></td></TR>
              <TR>
                <TD>Invoice Date</TD>
                <TD><asp:label id=lblInvoiceDate runat="server"></asp:label></TD></TR>
              <TR>
                <TD>Mode of 
                  Payment&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                <TD><asp:dropdownlist id=DropModeType runat="server" Width="109px" CssClass="FontStyle" Height="20px">
<asp:ListItem Value="Cash" Selected="True">Cash</asp:ListItem>
<asp:ListItem Value="Cheque">Cheque</asp:ListItem>
<asp:ListItem Value="DD on Delivery">DD on Delivery</asp:ListItem>
														</asp:dropdownlist>&nbsp;&nbsp;&nbsp; 
              </TD></TR></TABLE></FONT></U></TD>
          <TD align=center><U><FONT 
            color=#990066>Vendor Information</FONT></U> 
            <TABLE cellSpacing=0 cellPadding=0>
              <TR>
                <TD>Vendor&nbsp;Name&nbsp;&nbsp; <asp:comparevalidator id=CompareValidator1 runat="server" Operator="NotEqual" ControlToValidate="DropVendorID" ValueToCompare="Select" ErrorMessage="Please Select Vendor Name"><font color="red">*</font></asp:comparevalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                </TD>
                <TD><asp:dropdownlist id=DropVendorID runat="server" Width="168px" CssClass="FontStyle" onChange="getCity(this,document.all.lblPlace,document.all.lblTinNo);"><asp:ListItem Value="Select">Select</asp:ListItem></asp:dropdownlist></TD>

              </TR>
              <TR>
                <TD>Place</TD>
                <TD><INPUT class=FontStyle id=lblPlace 
                  style="WIDTH: 166px; BORDER-TOP-STYLE: groove; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; HEIGHT: 21px; BORDER-BOTTOM-STYLE: groove" 
                   type=text size=22 name=lblPlace 
                  runat="server"></TD></TR>
              <TR>
                <TD>Vehicle No <asp:requiredfieldvalidator id=RequiredFieldValidator1 runat="server" ControlToValidate="txtVehicleNo" ErrorMessage="Please Fill Vehicle No."><font color="red">*</font></asp:requiredfieldvalidator></TD>
                <TD><asp:textbox id=txtVehicleNo runat="server" Width="166px" CssClass="FontStyle" Height="21px" BorderStyle="Groove" MaxLength="15"></asp:textbox></TD></TR>
              <TR>
                <TD>Invoice No <asp:requiredfieldvalidator id=RequiredFieldValidator2 runat="server" ControlToValidate="txtVInvoiceNo" ErrorMessage="Please Fill Vendor Invoice No."><font color="red">*</font></asp:requiredfieldvalidator><asp:regularexpressionvalidator id=RegularExpressionValidator1 runat="server" ControlToValidate="txtVInvoiceNo" ErrorMessage="Numeric only" ValidationExpression="\d+">*</asp:regularexpressionvalidator></TD>
                <TD><asp:textbox id=txtVInvoiceNo runat="server" Width="166px" CssClass="FontStyle" Height="21px" BorderStyle="Groove" onkeypress="return GetOnlyNumbers(this, event, false,false);" MaxLength="9"></asp:textbox></TD></TR>
              <TR>
                <TD>Invoice Date <asp:requiredfieldvalidator id=RequiredFieldValidator3 runat="server" ControlToValidate="txtVInvoiceDate" ErrorMessage="Please Fill Vendor Invoice Date"><font color="red">*</font></asp:requiredfieldvalidator></TD>
                <TD><asp:textbox id=txtVInvoiceDate runat="server" Width="110px" CssClass="FontStyle" Height="21px" BorderStyle="Groove" ></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtVInvoiceDate);return false;" href="javascript:void(0)" ><IMG class=PopcalTrigger alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align=absMiddle border=0 ></A></TD></TR></TABLE></TD></TR>
        <TR>
          <TD vAlign=top align=center colSpan=2>
            <TABLE cellSpacing=0 cellPadding=0 width=580>
              <TR>
                <TD align=center></TD>
                <TD align=center><asp:label id=lblComp1 runat="server" Width="100px">Comp. I</asp:label></TD>
                <TD align=center><asp:label id=lblComp2 runat="server" Width="100px">Comp. II</asp:label></TD>
                <TD align=center><asp:label id=lblComp3 runat="server" Width="100px">Comp. III</asp:label></TD>
                <TD align=center><asp:label id=lblComp4 runat="server" Width="100px">Comp. IV</asp:label></TD></TR>
              <TR>
                <TD style="HEIGHT: 21px">Product Name </TD>
                <TD style="HEIGHT: 21px" align=right><asp:dropdownlist id=DropProd1 runat="server" Width="85px" CssClass="FontStyle" onChange="getTaxRate(this,document.all.txtRate1,document.all.txtReduction,document.all.txtEntryTax,document.all.txtRPGCharge,document.all.txtRPGSurcharge,document.all.txtLTC,document.all.txtTransportCharge,document.all.txtOther,document.all.txtLST,document.all.txtLSTSurcharge,document.all.txtLFR,document.all.txtDO,document.all.txtUnit,document.all.tempRate1);" Font-Names="Arial">
<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
                <TD style="HEIGHT: 21px" align=right><asp:dropdownlist id=DropProd2 runat="server" Width="85px" CssClass="FontStyle" onChange="getTaxRate(this,document.all.txtRate2,document.all.txtReduction5,document.all.txtEntryTax5,document.all.txtRPGCharge5,document.all.txtRPGSurcharge5,document.all.txtLTC5,document.all.txtTransportCharge5,document.all.txtOther5,document.all.txtLST5,document.all.txtLSTSurcharge5,document.all.txtLFR5,document.all.txtDO5,document.all.txtUnit5,document.all.tempRate2);" Font-Names="Arial">
<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
                <TD style="HEIGHT: 21px" align=right><asp:dropdownlist id=DropProd3 runat="server" Width="85px" CssClass="FontStyle" onChange="getTaxRate(this,document.all.txtRate3,document.all.txtReduction6,document.all.txtEntryTax6,document.all.txtRPGCharge6,document.all.txtRPGSurcharge6,document.all.txtLTC6,document.all.txtTransportCharge6,document.all.txtOther6,document.all.txtLST6,document.all.txtLSTSurcharge6,document.all.txtLFR6,document.all.txtDO6,document.all.txtUnit6,document.all.tempRate3);" Font-Names="Arial">
<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
                <TD style="HEIGHT: 21px" align=right><asp:dropdownlist id=DropProd4 runat="server" Width="85px" CssClass="FontStyle" onChange="getTaxRate(this,document.all.txtRate4,document.all.txtReduction7,document.all.txtEntryTax7,document.all.txtRPGCharge7,document.all.txtRPGSurcharge7,document.all.txtLTC7,document.all.txtTransportCharge7,document.all.txtOther7,document.all.txtLST7,document.all.txtLSTSurcharge7,document.all.txtLFR7,document.all.txtDO7,document.all.txtUnit7,document.all.tempRate4);" Font-Names="Arial">
<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD></TR>
              <TR>
                <TD><FONT color=#ff3333 
                  ><STRONG>Qty (in 
                  KL)</STRONG></FONT> &nbsp; <asp:requiredfieldvalidator id=RequiredFieldValidator4 runat="server" ControlToValidate="txtQty1" ErrorMessage="Please Fill Qty of the Product" Enabled="False">*</asp:requiredfieldvalidator></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtQty1 onblur=calc() runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtQty2 onblur=calc1() runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtQty3 onblur=calc2() runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtQty4 onblur=calc3() runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD></TR>
              <TR>
                <TD>Rate / (KL)</TD>
                <TD align=right><asp:textbox id=txtRate1 onblur=calc() runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRate2 onblur=calc() runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRate3 onblur=calc() runat="server" Width="85px" CssClass="FontStyle" Height="21" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRate4 onblur=calc() runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Density in Physical</TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtDensityInPhysical1 onblur=checkden(this) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="3"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtDensityInPhysical2 onblur=checkden(this) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="3"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtDensityInPhysical3 onblur=checkden(this) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="3"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtDensityInPhysical4 onblur=checkden(this) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="3"></asp:textbox></TD></TR>
              <TR>
                <TD>Temprature in Physical</TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id=txtTempInPhysical1 runat="server" Width="85px" CssClass="FontStyle" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id=txtTempInPhysical2 runat="server" Width="85px" CssClass="FontStyle" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id=txtTempInPhysical3 runat="server" Width="85px" CssClass="FontStyle" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id=txtTempInPhysical4 runat="server" Width="85px" CssClass="FontStyle" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD></TR>
              <TR>
                <TD>Converted Density(Phy.)</TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtConDensity1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtConDensity2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtConDensity3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtConDensity4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Density in Invoice(Conv.)</TD>
                <TD align=right><asp:textbox id=txtDenConv1 onblur=calc_diff(document.all.txtDensityVariation1,document.all.txtDenConv1,document.all.txtConDensity1) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDenConv2 onblur=calc_diff(document.all.txtDensityVariation2,document.all.txtDenConv2,document.all.txtConDensity2) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDenConv3 onblur=calc_diff(document.all.txtDensityVariation3,document.all.txtDenConv3,document.all.txtConDensity3) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDenConv4 onblur=calc_diff(document.all.txtDensityVariation4,document.all.txtDenConv4,document.all.txtConDensity4) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD id=TD1 style="HEIGHT: 22px">Density 
                  Variation</TD>
                <TD align=right><asp:textbox id=txtDensityVariation1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDensityVariation2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDensityVariation3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDensityVariation4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Density After Decantation</TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtDenAfterDec1 onblur=checkden(this) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="3"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtDenAfterDec2 onblur=checkden(this) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="3"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtDenAfterDec3 onblur=checkden(this) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="3"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id=txtDenAfterDec4 onblur=checkden(this) runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="3"></asp:textbox></TD></TR>
              <TR>
                <TD style="HEIGHT: 21px">Temprature After 
                  Decantation</TD>
                <TD style="HEIGHT: 21px" align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id=txtTempAfterDec1 runat="server" Width="85px" CssClass="FontStyle" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD style="HEIGHT: 21px" align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id=txtTempAfterDec2 runat="server" Width="85px" CssClass="FontStyle" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD style="HEIGHT: 21px" align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id=txtTempAfterDec3 runat="server" Width="85px" CssClass="FontStyle" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD>
                <TD style="HEIGHT: 21px" align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, true,true);" id=txtTempAfterDec4 runat="server" Width="85px" CssClass="FontStyle" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox></TD></TR>
              <TR>
                <TD>Conv. Density After Decantatin</TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtConvDenAfterDec1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtConvDenAfterDec2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtConvDenAfterDec3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id=txtConvDenAfterDec4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Reduction Others</TD>
                <TD align=right><asp:textbox id=txtReduction1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtReduction2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtReduction3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtReduction4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Entry Tax</TD>
                <TD align=right><asp:textbox id=txtEntryTax1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtEntryTax2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtEntryTax3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtEntryTax4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>RPG Charges</TD>
                <TD align=right><asp:textbox id=txtRPGCharge1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRPGCharge2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRPGCharge3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRPGCharge4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>RPG Surcharge</TD>
                <TD align=right><asp:textbox id=txtRPGSurcharge1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRPGSurcharge2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRPGSurcharge3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtRPGSurcharge4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Local Transport Charge</TD>
                <TD align=right><asp:textbox id=txtLTC1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLTC2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLTC3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLTC4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Transportation Charge</TD>
                <TD align=right><asp:textbox id=txtTransportCharge1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtTransportCharge2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtTransportCharge3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtTransportCharge4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Other Levis Value</TD>
                <TD align=right><asp:textbox id=txtOther1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtOther2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtOther3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtOther4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Vat</TD>
                <TD align=right><asp:textbox id=txtLST1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLST2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLST3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLST4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>LST Surcharge</TD>
                <TD align=right><asp:textbox id=txtLSTSurcharge1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLSTSurcharge2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLSTSurcharge3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLSTSurcharge4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>License Fee Recovery</TD>
                <TD align=right><asp:textbox id=txtLFR1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLFR2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLFR3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtLFR4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>DO/ FO/ BC/ Charge</TD>
                <TD align=right><asp:textbox id=txtDO1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDO2 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDO3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtDO4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD>Total Amount</TD>
                <TD align=right><asp:textbox id=txtAmount1 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtAmount2 runat="server" Width="85px" DESIGNTIMEDRAGDROP="526" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtAmount3 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD>
                <TD align=right><asp:textbox id=txtAmount4 runat="server" Width="85px" CssClass="FontStyle" BorderStyle="Groove"  MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD colSpan=5><asp:button id=cmdtot runat="server" Width="32px" Visible="False" Font-Bold="True" ToolTip="View Total Cost of Selected Product" Text="GT" Font-Names="Verdana" Font-Italic="True" Font-Size="XX-Small"></asp:button></TD></TR></TABLE></TD></TR></table>
      <TABLE style="WIDTH: 595px" cellSpacing=0 cellPadding=0 
      >
        <TR>
          <TD>Promo 
            Scheme&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
          <TD style="WIDTH: 251px"><asp:textbox id=txtPromoScheme runat="server" Width="246px" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
          <TD>Grand Total</TD>
          <TD><asp:textbox id=txtGrandTotal runat="server" Width="123px" CssClass="FontStyle" BorderStyle="Groove" ></asp:textbox></TD></TR>
        <TR>
          <TD>Remark</TD>
          <TD style="WIDTH: 251px"><asp:textbox id=txtRemark runat="server" Width="246px" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></TD>
          <TD 
            >Discount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
          <TD><asp:textbox id=txtDisc onblur=GetNetAmount() runat="server" Width="123px" CssClass="FontStyle" Height="22px" BorderStyle="Groove" MaxLength="2"></asp:textbox><asp:dropdownlist id=DropDiscType runat="server" Width="45px" CssClass="FontStyle" onchange="GetNetAmount()">
<asp:ListItem Value="Per">%</asp:ListItem>
<asp:ListItem Value="Rs" Selected="True">Rs.</asp:ListItem>
<asp:ListItem Value="KL">KL</asp:ListItem>
									</asp:dropdownlist><asp:textbox id=TotalDisc runat="server" Width="123px" Height="22px" BorderStyle="Groove" ></asp:textbox></TD></TR>
        <TR>
          <TD>Message</TD>
          <TD style="WIDTH: 251px"><asp:textbox id=txtMessage runat="server" Width="246px" CssClass="FontStyle" BorderStyle="Groove" ></asp:textbox></TD>
          <TD>Net 
            Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
          <TD><asp:textbox id=txtNetAmount runat="server" Width="124px" CssClass="FontStyle" BorderStyle="Groove" ></asp:textbox></TD></TR>
        <TR>
          <TD>Entry&nbsp;By</TD>
          <TD style="WIDTH: 251px"><asp:label id=lblEntryBy runat="server"></asp:label></TD>
          <TD align=right colSpan=2></TD></TR>
        <TR>
          <TD>Entry Date &amp; Time</TD>
          <TD style="WIDTH: 251px">
            <P><asp:label id=lblETime runat="server">lblEntryTime</asp:label></P></TD>
          <TD align=right colSpan=2><asp:button id=btnSave runat="server" Width="70px"  Text="Save"></asp:button>&nbsp;<asp:button id=btnPrint runat="server" Width="70px"  Text="Print" CausesValidation="False"></asp:button>&nbsp;<asp:button onmouseup=checkDelRec() id=btnDelete runat="server" Width="70px"  Text="Delete"></asp:button></TD></TR></TABLE></TD><asp:validationsummary id=ValidationSummary1 runat="server" Height="12px" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TR><INPUT 
  id=Duptext3 
  style="Z-INDEX: 102; LEFT: -224px; WIDTH: 24px; POSITION: absolute; TOP: -16px; HEIGHT: 22px" 
  type=text size=1 name=Duptext3> </TBODY></TABLE><IFRAME 
id=gToday:contrast:agenda.js 
style="Z-INDEX: 100; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px" 
name=gToday:contrast:agenda.js src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder=0 
width=174 scrolling=no height=189></IFRAME><uc1:footer id=Footer1 runat="server"></uc1:footer></form>
	</body>
</HTML>
