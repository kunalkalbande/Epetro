/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/		
 function getProdName(t,pname,packtype,srate,txtProdName,txtPack,txtQty,txtAmount)
 { 
  var ProdName 
  var mainarr = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
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
  txtQty.value=""
  txtAmount.value=""
  txtProdName.value=""
  txtPack.value=""

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
     }	 
 }

function getPack(prodtype,t,packtype,srate,prodname,txtPack,txtQty,txtAmount)
 { 
	packtype.length=1
	packtype.value="";
	packtype.value="Select"
	 srate.value=""
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
     }
//     getStock(prodtype,t,packtype,avstock,srate)
 }
 
 function getStock(prodtype,pname,t,srate,packname,txtQty,txtAmount)
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
  var packtext  = t.options[packindex].text
  packname.value=packtext
  // alert(countrytext)
  var hidarr  = document.all.temptext.value
  mainarr = hidarr.split(",")
  //alert(cscarr)
  var prodarr = new Array()
  var ratearr = new Array()
  var unitarr = new Array()
  var status="n"
  var k = 0
  var r =0;
   srate.value=""
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
      if(prodarr[1]==prodtext&& prodarr[2]==packtext)
      {
	if(status!="y")
	{// alert(prodarr[3]+" "+prodarr[4]+" "+prodarr[5])
	   ratearr[k] = prodarr[3];
	   unitarr[k]=  prodarr[4];
       k++;
	}
      } 
    }
  }
   for(n=0;n<ratearr.length;n++)
     {  
        srate.value=ratearr[n]
     } 
	 
 }
