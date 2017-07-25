


function getBeatInfo(t,state,country)
{
	
  var mainarr = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
  //alert(typetext)
  var hidtext  = document.Form1.txtbeatname.value
 // alert(hidtext)
  mainarr = hidtext.split("#")
  var cityarr = new Array()
  country.value=""
  state.value=""
  var k=0
  var statearr = new Array()
  var countryarr = new Array()
  for(var i=0;i<(mainarr.length - 1);i++)
  {
    cityarr = mainarr[i].split(":")
    
    for(var j=0;j<cityarr.length;j++ )
    { 
    
      if(cityarr[j]==typetext)
      {  
         state.value=cityarr[1]
         country.value=cityarr[2]         
         break
      }   
    }    
   }
  } 
  
  function getTankNo(t,tankno)
{
  var mainarr = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
  //alert(typetext)
  var hidtext  = document.Form1.TxtVen.value
  //alert(document.Form1.TxtVen.value)
 
  mainarr = hidtext.split("#")
  var cityarr = new Array()
 
  tankno.value=""
  for(var i=0;i<(mainarr.length - 1);i++)
  {
    cityarr = mainarr[i].split("~")
   // alert(cityarr.length)
    for(var j=0;j<cityarr.length;j++ )
    { 
    
      if(cityarr[j]==typetext)
      {  
         tankno.value="Tank-"+cityarr[1]         
         break
      }   
    }    
   }
  } 
  
  function getNozzleNo(t,nozzleno)
{
  var mainarr = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
  //alert(typetext)
  var hidtext  = document.Form1.TxtVen.value
  
 //alert(document.Form1.TxtVen.value)
 
  mainarr = hidtext.split("#")
  var cityarr = new Array()
 
  nozzleno.value=""
  for(var i=0;i<(mainarr.length - 1);i++)
  {
    cityarr = mainarr[i].split("~")
   // alert(cityarr.length)
    for(var j=0;j<cityarr.length;j++ )
    { 
	//alert(cityarr[j]+":::"+typetext)
      if(cityarr[j]==typetext)
      {  
         nozzleno.value="Nozzle-"+cityarr[1]         
         break
      }   
    }    
   }
  } 
