/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/		
 
 
 function getProdName(t,pname,packtype,avstock,srate,txtProdName,txtPack,txtQty,txtAmount)
 { 
 
  var ProdName
  var mainarr = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
  
  // alert(countrytext)
  var hidarr  = document.all.temptext.value
  //alert(document.Form1.temptext.value)
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
	GetGrandTotal1();
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
      //alert(typetext+","+prodarr[j])
      if(prodarr[j]==typetext)
      {
		if(status!="y")
		{ 
			if(typetext=="Fuel")
				prodnamearr[k]=prodarr[1]+":"+prodarr[6];
			else
				prodnamearr[k]=prodarr[1]
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
     // alert(parr[j])
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
 pname.selectedIndex = 0;
 t.length=1;
 t.selectedIndex=0;
 return false;
 
 }
  var ProdName
  var PackType 
  var mainarr = new Array()
  var prodindex = pname.selectedIndex
  //var prodtext  = pname.options[prodindex].text
  //*******
  var prodtext11  = pname.options[prodindex].text
  var str=new Array()
  str=prodtext11.split(":")
  var prodtext = str[0]
  //************
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

function GetGrandTotal1()
	{
	 var GTotal=0;
	 if(document.all.txtAmount1.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount1.value);
	 if(document.all.txtAmount2.value!="")
	 	GTotal=GTotal+eval(document.all.txtAmount2.value);
	 document.all.txtGrandTotal.value=GTotal;
	 makeRound(document.all.txtGrandTotal);
	}	 
 
 
 /*****************This code hide by Mahesh, Date : 24.02.0007***********
 function getProdName(t,pname,packtype,avstock,srate,txtProdName,txtPack,txtQty,txtAmount)
 { 
   var ProdName 
  var mainarr = new Array()
   var mainarr1 = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
  
  // alert(countrytext)
  var hidarr  = document.Form1.temptext.value
  mainarr = hidarr.split(",")
  var hidarr1  = document.Form1.txttottank.value
  mainarr1 = hidarr1.split(",")
  //alert(cscarr)
  var prodarr = new Array()
  var prodarr1 = new Array()
  var prodnamearr = new Array()
  var prodnamearr1 = new Array()
  var status="n"
  var status="n1"
  var k = 0
  var k1 = 0
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
  
  for(var i=0;i<(mainarr.length-1);i++)
  {
    prodarr = mainarr[i].split(":")
    if(ProdName==prodarr[1])
    {
 		status="y"; 
    }
    else
    {	
		ProdName=prodarr[1]
		status="n"
    }
    //**********************
    for(var j=0;j<mainarr1.length;j++ )
    {  
      if(prodarr[j]==typetext)
      {
		if(status!="y")
		{ 
			if(prodarr[j]=="Fuel")//**
			{
			//	prodnamearr[k]=prodarr[1];
			//	k++;
			//}
			//else //if(mainarr1[j]==mainarr1[j])
			//{
			//alert("apnna"+mainarr1[k1])
				if(mainarr1[k1+1]!=undefined)
				{
					prodnamearr[k]=mainarr1[k1+1];
					k++;
				}
				k1++;
			}
			
		}
      } 
    }

    //**********************
    for(var j=0;j<prodarr.length;j++ )
    {  
      if(prodarr[j]==typetext)
      {
		if(status!="y")
		{ 
			if(prodarr[j]!="Fuel")//**
			{
				prodnamearr[k]=prodarr[1];
				k++;
			}
			else //if(mainarr1[j]==mainarr1[j])
			{
			//alert(mainarr1[k1])
				if(mainarr1[k1+1]!=undefined)
				{
					prodnamearr[k]=mainarr1[k1+1];
					k++;
				}
				k1++;
			}
			
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
     //***************
     //for(var i1=0;i1<(mainarr1.length);i1++)
	//{
	
    //prodarr1 = mainarr1[i1].split(":")
    //alert(sarr[i])
    //if(ProdName==prodarr1[1])
   // {
 	//	status="y"; 
   // }
    //else
   // {	alert(prodarr1[0])
	//	ProdName=prodarr1[0]
	//	status="n1"
    //}
    //for(var j1=0;j1<mainarr1.length;j1++ )
   // {  //alert(prodarr1[j1])
     // if(mainarr1[j1]==typetext)
     // {
		//if(status!="y")
		//{ 
			//prodnamearr1[k]=mainarr1[1];
			//k++;
		//}
    //  } 
   // }
  //}
    //for(n=0;n<prodnamearr1.length;n++)
    // {  
     //   pname.add(new Option)  
    //    pname.options[n+1].text=prodnamearr1[n]
   //     pname.options[n+1].value=prodnamearr1[n]
        
  //   }
     //***************
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
	var hiddenarr  = document.Form1.temptext.value
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
//************* 
//function getStock(prodtype,pname,t,avstock,srate,packname,txtQty,txtAmount)
 //{
 //if (!checkProd())
// {
 //prodtype.selectedIndex = 0;
 //pname.selectedIndex=0;
 //t.length=1;
 //t.selectedIndex=0;
 //return false;
 
// }
  //var ProdName
  //var PackType 
  //var mainarr = new Array()
  //var mainarr1 = new Array()
  //var prodindex = pname.selectedIndex
  //var prodtext  = pname.options[prodindex].text
  
  //var packindex = t.selectedIndex
//  alert(packindex)
  //var packtext;
  //if(packindex==-1)
  //packtext="";
  //else
  //var packtext  = t.options[packindex].text
  //packname.value=packtext
  // alert(countrytext)
  //var hidarr  = document.Form1.temptext.value
  //var hidarr1  = document.Form1.txttottank.value
  //mainarr = hidarr.split(",")
  //mainarr1 = hidarr1.split(",")
  //alert(cscarr)
  //var prodarr = new Array()
  //var prodarr1 = new Array()
  //var ratearr = new Array()
  //var stockarr = new Array()
  //var unitarr = new Array()
  //var status="n"
  //var k = 0
  //var r =0;
  // srate.value=""
  //avstock.value=""
  // txtQty.value=""
  //txtAmount.value=""

 // for(var i=0;i<(mainarr.length-1);i++)
  //{
   // prodarr = mainarr[i].split(":")
    //if(mainarr1[i+1]!=undefined)
    //prodarr1 = mainarr1[i+1].split(":")
    //alert(sarr[i])
    //alert(PackType)
    //if(ProdName==prodarr[1]&&PackType==prodarr[2])
    //if(ProdName==prodarr1[0]&&PackType==prodarr1[1])
    //{
 //		status="y"; 
  //  }
   // else
    //{	
	//ProdName=prodarr[1]
	//PackType=prodarr[2]
	//ProdName=prodarr1[0]
	//PackType=prodarr1[1]
	//status="n"
   // }
    //for(var j=0;j<prodarr.length;j++ )
    //for(var j=0;j<prodarr1.length;j++ )
    //{ 
    //alert(mainarr1[j])
    //alert(prodarr[2])  
     //alert(prodtext)
    //alert(prodarr[1]) 
      //if(prodarr[1]==prodtext&& prodarr[2]==packtext)
     // if(mainarr1[j]==prodtext)
      //{
      //alert("enter")
	//if(status!="y")
//	{ alert(prodarr[3]+" "+prodarr[4]+" "+prodarr[5])
	//alert("in sta ")
//	   ratearr[k] = prodarr[3];
	   //stockarr[k]= prodarr[4];
	   //unitarr[k]=  prodarr[5];
       //k++;
	//}
     // } 
   // }
  //}
  // for(n=0;n<ratearr.length;n++)
   //  {  
     //alert("for")
    //    srate.value=ratearr[n]
     //   avstock.value=stockarr[n]+" "+unitarr[n]
     //} 
	 
 //}
 //****************
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
  var mainarr1 = new Array()
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
  var hidarr  = document.Form1.temptext.value
  mainarr = hidarr.split(",")
  var hidarr1  = document.Form1.txttottank.value
  mainarr1 = hidarr1.split(",")
  //alert(cscarr)
  var prodarr = new Array()
  var prodarr1 = new Array()
  var prodarr2 = new Array()
  var ratearr = new Array()
  var stockarr = new Array()
  var unitarr = new Array()
  var status="n"
  var k = 0
  var k1 = 0
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
		prodarr2 = prodtext.split(":")
		for(var j=0;j<prodarr.length;j++ )
		{ 
		//this additional part get the available stock and rate according
		//to selected product name
    //************************************************
		if(mainarr1[i+1]!=undefined)
		{
			prodarr1 = mainarr1[i+1].split(":")
		}
		//alert("dd"+prodarr2[0]+"dd")
		if(prodarr2[0] == prodarr[1] && prodarr[2]== "")
		{
			if(mainarr1[k1+1]==prodtext)
			{
				if(status!="y")
				{ //alert(prodarr[3]+" "+prodarr[4]+" "+prodarr[5])
					//alert("in		sta ")
			        ratearr[k] = prodarr[3];
					stockarr[k]= prodarr[4];
					unitarr[k]=  prodarr[5];
				    k++;
				   // alert(prodarr[3]+" "+prodarr[4]+" "+prodarr[5])
				}
				k1++;
			}
			else
				k1++;
			}
	//*********************************************************
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
 **********************************************************************/
 
 
 