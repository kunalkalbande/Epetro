
	
function getTaxRate(t,rate,reduction,entrytax,rpgcharge,rpgsurcharge,ltc,transportcharge,other,lst,lstsurcharge,lfr,txtdo,txtUnit,tempRate)
{
	//alert("in")
	var mainarr = new Array()
	var typeindex = t.selectedIndex
	var typetext  = t.options[typeindex].text
    // alert(countrytext)

	var hidtext  = document.all.FuelText.value
	mainarr = hidtext.split("#")
	//alert(cscarr)
	var taxarr = new Array()
	var k = 0
	tempRate.value=""
	rate.value=""
	reduction.value=""
	entrytax.value=""
	rpgcharge.value=""
	rpgsurcharge.value=""
	ltc.value=""
	transportcharge.value=""
	other.value=""
	lst.value=""
	lstsurcharge.value=""
	lfr.value=""
	txtdo.value=""
	txtUnit.value = ""
	//alert(typetext)
	if(typetext!="Select")
	{
		for(var i=0;i<(mainarr.length-1);i++)
		{
			taxarr = mainarr[i].split("~")
			//alert(sarr[i])
			for(var j=0;j<taxarr.length;j++ )
			{  
				if(taxarr[j]==typetext)
				{
					// alert("in"+taxarr[2])
					tempRate.value=taxarr[2];
					rate.value=taxarr[2];
					reduction.value=taxarr[3];
					entrytax.value=taxarr[4];
					rpgcharge.value=taxarr[5];
					rpgsurcharge.value=taxarr[6];
					ltc.value=taxarr[7];
					transportcharge.value=taxarr[8];
					other.value=taxarr[9];
					lst.value=taxarr[10];
					lstsurcharge.value=taxarr[11];
					lfr.value=taxarr[12];
					txtdo.value=taxarr[13];
					txtUnit.value = taxarr[14]+"#"+taxarr[15]+"#"+taxarr[16]+"#"+taxarr[17]+"#"+taxarr[18]+"#"+taxarr[19]+"#"+taxarr[20]+"#"+taxarr[21]+"#"+taxarr[22]+"#"+taxarr[23]+"#"+taxarr[24];
					break;
				}	
			}
			//alert(txtUnit.value)
		} 
	}
}
 
function getCity(t,city)
{
  var mainarr = new Array()
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
    //alert(typetext)  
  var hidtext  = document.all.TxtVen.value
  
 
  mainarr = hidtext.split("#")
  var cityarr = new Array()
 
  city.value=""
  
  for(var i=0;i<(mainarr.length - 1);i++)
  {
    cityarr = mainarr[i].split("~")
   // alert(cityarr.length)
    for(var j=0;j<cityarr.length;j++ )
    { 
      if(cityarr[j]==typetext)
      {  
         city.value=cityarr[1]
        // tinno.value=cityarr[2]         
        // break
      }   
    }    
   }
  } 
  
  
  
  	
 function getBalance(t,City,CR_Days,Cust_ID,Balance,CR_Limit,txtstart,txtend,lblCreditLimit,dropvehicle_no)
 { 
  var mainarr = new Array()
  var vehiclearr = new Array(); 
  var typeindex = t.selectedIndex
  var typetext  = t.options[typeindex].text
  // alert(countrytext)
  var hidtext  = document.all.TxtVen.value
  var hidtext1 = document.all.lblVehicleNo.value
 // alert("1 : "+hidtext)
  mainarr = hidtext.split("#")
  vehiclearr = hidtext1.split("#");
  //alert(cscarr)
  var taxarr = new Array()
  var subarr = new Array()
  var k = 0
  City.value=""
  CR_Days.value=""
  CR_Limit.value=""
  lblCreditLimit.value = "";
  Cust_ID.value=""
  Balance.value=""
  txtstart.value=""
  txtend.value=""
  
  
  for(var i=0;i<(mainarr.length-1);i++)
  {
    taxarr = mainarr[i].split("~")
   
    //alert(sarr[i])
    for(var j=0;j<taxarr.length;j++ )
    {  
   // alert("2 : "+taxarr[j]+" #### "+typetext)
      if(taxarr[j]==typetext)
      {
        City.value=taxarr[1];
       // alert("3 : "+taxarr[1])
        CR_Days.value=taxarr[2];
		CR_Limit.value=taxarr[3];
		lblCreditLimit.value = taxarr[3];
		Cust_ID.value=taxarr[4];
		Balance.value=taxarr[5]+" "+taxarr[6];
		txtstart.value=taxarr[7]
		txtend.value=taxarr[8]
		//BalanceType.value=taxarr[6];
		break;
	 }	
	}
   } 
   
  
    
    
 }

