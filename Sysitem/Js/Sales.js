/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/		

 function getProdName(t,pname,packtype,avstock,srate,txtProdName,txtPack,txtQty,txtAmount,CustName)
 {
  var i;
  for (i = pname.options.length - 1 ; i >= 0 ; i--)
  {
      if (pname.value != "Select")
         pname.remove(i);
  }
  var ProdName 
  var mainarr = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
  if(CustName.value=="Select")
  {
	alert("Please Select The Customer Name")
	t.selectedIndex=0
	return;
  }
  // alert(countrytext)
  var hidarr  = document.all.temptext.value
  mainarr = hidarr.split(",")
  //alert(cscarr)
  var prodarr = new Array()
  var prodnamearr = new Array()
  var status="n"
  var k = 0
  var r =0;
  pname.length    = 1
  packtype.length = 1
  pname.value     ="Select"
  packtype.value  ="Select"
  
  srate.value=""
  avstock.value=""
  txtQty.value=""
  txtAmount.value=""
  txtProdName.value=""
  txtPack.value=""
  if(typetext=="Type")
  {
	GetGrandTotal();
	GetNetAmount();
  }
  for(var i=0;i<(mainarr.length-1);i++)
  {
    prodarr = mainarr[i].split(":")
    //alert(sarr[i])
    if(ProdName==prodarr[1])
    {
 		status="y"; 
    }
    else
    {	
		ProdName=prodarr[1]
		status="n"
    }
    for(var j=0;j<prodarr.length;j++ )
    {  
      if(prodarr[j]==typetext)
      {
		if(status!="y")
		{ 
			prodnamearr[k]=prodarr[1];
			k++;
		}
      } 
    }
  }
    for(n=0;n<prodnamearr.length;n++)
     {  
        pname.add(new Option)  
        pname.options[n+1].text=prodnamearr[n]
        pname.options[n+1].value=prodnamearr[n]
        
     }	 
 }

function getPack(prodtype,t,packtype,avstock,srate,prodname,txtPack,txtQty,txtAmount)
 { 

var index1 = prodtype.selectedIndex
var ptype = prodtype.options[index1].text
	
 if(ptype=="Fuel")
  {
   packtype.disabled = true;
   getStock(prodtype,t,packtype,avstock,srate,prodname,txtQty,txtAmount);
  }
  else
  packtype.disabled = false; 
  
	packtype.length=1	
	packtype.value="";
	packtype.selectedIndex = 0;
	
	// srate.value=""
     //avstock.value=""
      txtQty.value=""
  txtAmount.value=""
  txtPack.value="" 
	prodname.value=""
	var index = t.selectedIndex
	var Prod = t.options[index].text
	
    prodname.value=Prod
	var mainarr = new Array()
	var parr = new Array()
	var k=0
	var packarray = new Array()
	var hiddenarr  = document.all.temptext.value
	mainarr = hiddenarr.split(",")
	for(var i=0;i<(mainarr.length-1);i++)
	{
    parr = mainarr[i].split(":")
    for(var j=0;j<parr.length;j++ )
    {  
      if(parr[j]==Prod)
      {
        packarray[k]=parr[j+1]
        k++;
      } 
    }
  }
     for(n=0;n<packarray.length;n++)
     {
        packtype.add(new Option)  
        packtype.options[n+1].text=packarray[n]
        packtype.options[n+1].value=packarray[n]
     }
   //  getStock(prodtype,t,packtype,avstock,srate)
 }
 
 function getStock(prodtype,pname,t,avstock,srate,packname,txtQty,txtAmount)
 {
 if (!checkProd())
 {
 prodtype.selectedIndex = 0;
 pname.selectedIndex=0;
 t.length=1;
 t.selectedIndex=0;
 return false;
 
 }
  var ProdName
  var PackType 
  var mainarr = new Array()
  var prodindex = pname.selectedIndex
  var prodtext  = pname.options[prodindex].text
  
  var packindex = t.selectedIndex
//  alert(packindex)
  var packtext;
  if(packindex==-1)
  packtext="";
  else
  var packtext  = t.options[packindex].text
  packname.value=packtext
  // alert(countrytext)
  var hidarr  = document.all.temptext.value
  mainarr = hidarr.split(",")
  //alert(cscarr)
  var prodarr = new Array()
  var ratearr = new Array()
  var stockarr = new Array()
  var unitarr = new Array()
  var status="n"
  var k = 0
  var r =0;
   srate.value=""
  avstock.value=""
   txtQty.value=""
  txtAmount.value=""

  for(var i=0;i<(mainarr.length-1);i++)
  {
    prodarr = mainarr[i].split(":")
    //alert(sarr[i])
    if(ProdName==prodarr[1]&&PackType==prodarr[2])
    {
 		status="y"; 
    }
    else
    {	
	ProdName=prodarr[1]
	PackType=prodarr[2]
	status="n"
    }
    for(var j=0;j<prodarr.length;j++ )
    { 
    //alert(packtext)
    //alert(prodarr[2])  
     //alert(prodtext)
    //alert(prodarr[1]) 
      if(prodarr[1]==prodtext&& prodarr[2]==packtext)
      {
	if(status!="y")
	{// alert(prodarr[3]+" "+prodarr[4]+" "+prodarr[5])
	//alert("in sta ")
	   ratearr[k] = prodarr[3];
	   stockarr[k]= prodarr[4];
	   unitarr[k]=  prodarr[5];
       k++;
	}
      } 
    }
  }
   for(n=0;n<ratearr.length;n++)
     {  
     //alert("for")
        srate.value=ratearr[n]
        avstock.value=stockarr[n]+" "+unitarr[n]
     } 
	 
 }
 
 function getcustomerinfo(t,place,DueDate,CurrBal,CreditLimit,drpvehicleno)
 {
  var mainarr = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
  
   var hidtext  = document.all.txtcustinfo.value
 // alert(document.Form1.txtcustinfo.value)
  mainarr = hidtext.split("#")
 
  var cityarr = new Array()
  place.value=""
  DueDate.value=""
  CurrBal.value=""
  CreditLimit.value=""
  /*if(drpvehicleno!=undefined)
  {
	drpvehicleno.length=1
	drpvehicleno.value="Select"
  }*/
  
  for(var i=0;i<(mainarr.length - 1);i++)
  {
		cityarr = mainarr[i].split(":")
		//alert(typetext)
		for(var j=0;j<cityarr.length;j++ )
		{  
			//alert(cityarr[j])
			if(cityarr[j]==typetext)
			{   
				//alert("Enter info")
				var l=0,m=0,n=0
				place.value=cityarr[++l]  
				DueDate.value=cityarr[++l]  
				CreditLimit.value= cityarr[++l]
				CurrBal.value=cityarr[++l]+" "+cityarr[++l]  
				m=++l
				if(cityarr[m]=="")
				{
				}
				/*else if(drpvehicleno!=undefined)
				{
					while(cityarr[m]!="")
					{
						drpvehicleno.add(new Option)  
						drpvehicleno.options[n+1].text=cityarr[m]
						drpvehicleno.options[n+1].value=cityarr[m]
						++m
						++n
					}
				}*/
				 break
			}   
        }
   }
  
 }
