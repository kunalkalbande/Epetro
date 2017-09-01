<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="StockAdjustment.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Inventory.StockAdjustment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Stock Adjustment</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">


function calcPack(t,t1,t2,t3)
{
t.value = "";
var index = t2.selectedIndex;
var typetext = t2.options[index].text;
var temp = document.all.txtTemp1.value;  
var temp1= "";
var temp3 ="";
var arr = new Array();
var arr1 = new Array();
var packArr = new Array();
arr = temp.split("#");
for(var i = 0 ; i< arr.length; i++)
{
   temp1 = arr[i];
   arr1 = temp1.split("~");
   for(var j=0; j< arr1.length; j=j+2)
   {
     if(typetext == arr1[j])
     {
     temp3 = arr1[j+1];
      packArr = temp3.split("X");
      t.value = eval(t1.value)*eval(packArr[0])*eval(packArr[1]);
      t3.value = eval(t1.value)*eval(packArr[0])*eval(packArr[1]);
     }
   } 
}

}


function checkStock(t,t1)
{
var index = t.selectedIndex;
var typetext = t.options[index].text;
var temp = document.all.txtQty.value;  
var temp1= "";
var arr = new Array();
var arr1 = new Array();
arr = temp.split("#");
//alert("inside")

for(var i = 0 ; i< arr.length; i++)
{
   temp1 = arr[i];
   arr1 = temp1.split("~");
    for(var j=0; j< arr1.length; j=j+2)
   {
     if(typetext == arr1[j])
     {
     //alert(arr1[j+1]+" "+t1.value);
            if(eval(arr1[j+1]) < eval(t1.value))
            {
               alert("Insufficient Stock!");
               t1.value = "";
                return false;
             }
            else
            {
              
                calcTotal();
                break;
                   
            }      
                
     }
   }
   
 }  

}
function checkTotal(t,t1) 
{
 calcTotal();
  if(t.value == t1.value)
   {
    calcTotal();
   }
   else
   {
   alert("The IN Liter Quantity must be same as OUT Liter Quantity");
   t.value = "";
   return false;
   }
}

function calcTotal()
{
var OutLtrTotal = 0;
var OutPackTotal = 0;
var InLtrTotal = 0;
var InPackTotal = 0;


  
  if(document.all.txtOutQtyPack1.value != "")
  {

  OutPackTotal = OutPackTotal+ eval(document.all.txtOutQtyPack1.value);
  calcPack(document.all.txtOutQtyLtr1,document.all.txtOutQtyPack1,document.all.DropOutProd1,document.all.tmpOutQtyLtr1);
  }
  
  if(document.all.txtOutQtyLtr1.value != "")
  {
    OutLtrTotal = OutLtrTotal+ eval(document.all.txtOutQtyLtr1.value);
  }
  
   if(document.all.txtOutQtyPack2.value != "")
  {
  
  OutPackTotal = OutPackTotal+ eval(document.all.txtOutQtyPack2.value);
  calcPack(document.all.txtOutQtyLtr2,document.all.txtOutQtyPack2,document.all.DropOutProd2,document.all.tmpOutQtyLtr2);
  }
  
  if(document.all.txtOutQtyLtr2.value != "")
  {
  OutLtrTotal = OutLtrTotal+ eval(document.all.txtOutQtyLtr2.value);
  }
   if(document.all.txtOutQtyPack3.value != "")
  {
  
   OutPackTotal = OutPackTotal+ eval(document.all.txtOutQtyPack3.value);
  calcPack(document.all.txtOutQtyLtr3,document.all.txtOutQtyPack3,document.all.DropOutProd3,document.all.tmpOutQtyLtr3);
  }
  
  if(document.all.txtOutQtyLtr3.value != "")
  {
  OutLtrTotal = OutLtrTotal+ eval(document.all.txtOutQtyLtr3.value);
  }
   if(document.all.txtOutQtyPack4.value != "")
  {
  
  OutPackTotal = OutPackTotal+ eval(document.all.txtOutQtyPack4.value);
  calcPack(document.all.txtOutQtyLtr4,document.all.txtOutQtyPack4,document.all.DropOutProd4,document.all.tmpOutQtyLtr4);
  }
  
  if(document.all.txtOutQtyLtr4.value != "")
  {
    OutLtrTotal = OutLtrTotal+ eval(document.all.txtOutQtyLtr4.value);
  }
  
  if(document.all.txtInQtyPack1.value != "")
  {
  
  InPackTotal = InPackTotal+ eval(document.all.txtInQtyPack1.value);
  calcPack(document.all.txtInQtyLtr1,document.all.txtInQtyPack1,document.all.DropInProd1,document.all.tmpInQtyLtr1 );
  }
  
  if(document.all.txtInQtyLtr1.value != "")
  {
    InLtrTotal = InLtrTotal+ eval(document.all.txtInQtyLtr1.value);
  }
  
  if(document.all.txtInQtyPack2.value != "")
  {
  
  InPackTotal = InPackTotal+ eval(document.all.txtInQtyPack2.value);
  calcPack(document.all.txtInQtyLtr2,document.all.txtInQtyPack2,document.all.DropInProd2,document.all.tmpInQtyLtr2);
  }
  
  if(document.all.txtInQtyLtr2.value != "")
  {
    InLtrTotal = InLtrTotal+ eval(document.all.txtInQtyLtr2.value);
  }
  
  if(document.all.txtInQtyPack3.value != "")
  {
  
  InPackTotal = InPackTotal+ eval(document.all.txtInQtyPack3.value);
  calcPack(document.all.txtInQtyLtr3,document.all.txtInQtyPack3,document.all.DropInProd3,document.all.tmpInQtyLtr3);
  }
  
  if(document.all.txtInQtyLtr3.value != "")
  {
    InLtrTotal = InLtrTotal+ eval(document.all.txtInQtyLtr3.value);
  }
  if(document.all.txtInQtyPack4.value != "")
  {
  
  InPackTotal = InPackTotal+ eval(document.all.txtInQtyPack4.value);
  calcPack(document.all.txtInQtyLtr4,document.all.txtInQtyPack4,document.all.DropInProd4,document.all.tmpInQtyLtr4);
  }
  
  if(document.all.txtInQtyLtr4.value != "")
  {
    InLtrTotal = InLtrTotal+ eval(document.all.txtInQtyLtr4.value);
  }
 document.all.txtTotalOutQtyLtr.value ="";
  document.all.txtTotalOutQtyPack.value = "";
   document.all.txtTotalInQtyLtr.value ="";
  document.all.txtTotalInQtyPack.value = "";
    document.all.txtTotalOutQtyLtr.value = OutLtrTotal;
   makeRound( document.all.txtTotalOutQtyLtr);
    document.all.txtTotalOutQtyPack.value = OutPackTotal;
   makeRound( document.all.txtTotalOutQtyPack);
      document.all.txtTotalInQtyLtr.value = InLtrTotal;
   makeRound( document.all.txtTotalInQtyLtr);
    document.all.txtTotalInQtyPack.value = InPackTotal;
   makeRound( document.all.txtTotalInQtyPack);
  
}
	function makeRound(t)
	{
//	alert(t.value)
	var str = t.value;
	if(str != "")
	{
	str = eval(str)*100;
//	alert(str)
	str  = Math.round(str);
//	alert(str)
	str = eval(str)/100;
//	alert(str)
	t.value = str;
	}
	
	}
	function setValue(t)
	{
	  var index = t.selectedIndex;
	  var typetext = t.options[index].text;
	  //alert(t.name);
	  if(t.name == "dropAccName1")
	     document.all.txtAccName1.value = typetext;
	  if(t.name == "dropAccName2")
	     document.all.txtAccName2.value = typetext;
	  if(t.name == "dropAccName3")
	     document.all.txtAccName3.value = typetext;
	  if(t.name == "dropAccName4")
		document.all.txtAccName4.value = typetext;
	  if(t.name == "dropAccName5")
		document.all.txtAccName5.value = typetext;
	  if(t.name == "dropAccName6")
		document.all.txtAccName6.value = typetext;
	  if(t.name == "dropAccName7")
		document.all.txtAccName7.value = typetext;
	  if(t.name == "dropAccName8")
		document.all.txtAccName8.value = typetext;     
	       
	   
	}
	
	function setStore(t,t1,t2,t3)
	{
	//alert("in");
	   t2.value = "";
	   t3.value = "";
	   t1.value = "";
	   var index = t.selectedIndex;
	  
	   var typetext = t.options[index].text;
	   var temp = document.all.txtTemp.value; 
	   var temp1="";
	   var arr =new Array();
	   var secArr = new Array();
	   var str = new String();
	   arr = temp.split("#");
	  // alert(arr);
	   for(var i= 0 ; i<arr.length; i++)
	   {
	     temp1 = arr[i];
	     secArr = temp1.split("~");
	    // alert(secArr);
	     for(var j=0; j< secArr.length; j= j+4)
	     { 
	    // alert(typetext+"#"+secArr[j]);
	     if(typetext == secArr[j])
	       {
	        t1.value = secArr[j+2]
	        str = secArr[j+3]
	        if(secArr[j+1] == "Fuel" || str.indexOf("Loose",0) > -1  )
	          {
	              t2.disabled = true;
	              t3.disabled = false;
	              
	          }
	          else
	          {
	              t2.disabled = false;
	              t3.disabled = true;
	          }
	        }
	     }
	   }
	   
	 
	   calcTotal();
	     
	   
	}
	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><INPUT id="txtTemp" style="Z-INDEX: 102; LEFT: 160px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"> <INPUT id="txtTemp1" style="Z-INDEX: 103; LEFT: 176px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="txtTemp1" runat="server"> <INPUT id="txtQty" style="Z-INDEX: 104; LEFT: 192px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"> <INPUT id="tmpOutQtyLtr1" style="Z-INDEX: 105; LEFT: 208px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="tmpOutQtyLtr2" style="Z-INDEX: 106; LEFT: 224px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden2" runat="server"><INPUT id="tmpOutQtyLtr3" style="Z-INDEX: 107; LEFT: 240px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden3" runat="server"><INPUT id="tmpOutQtyLtr4" style="Z-INDEX: 108; LEFT: 256px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden4" runat="server"><INPUT id="tmpInQtyLtr1" style="Z-INDEX: 109; LEFT: 272px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden5" runat="server"><INPUT id="tmpInQtyLtr2" style="Z-INDEX: 110; LEFT: 288px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden6" runat="server"><INPUT id="tmpInQtyLtr3" style="Z-INDEX: 111; LEFT: 304px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden7" runat="server"><INPUT id="tmpInQtyLtr4" style="Z-INDEX: 112; LEFT: 320px; WIDTH: 8px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="Hidden8" runat="server">
			<TABLE height="288" width="778" align="center">
				<tr>
					<th align="center">
						<font color="#006400">Stock Adjustment Voucher</font>
						<hr SIZE="2">
					</th>
				</tr>
				<TR>
					<td vAlign="top" align="center">
						<table border="1" cellpadding="0" cellspacing="0">
							<TR>
								<TD align="left" colSpan="2"><STRONG>SAV ID:</STRONG>
									<asp:Label id="lblSAV_ID" runat="server" ForeColor="Blue">1001</asp:Label></TD>
							</TR>
							<tr>
								<th align="center">
									<font color="#006400">OUT</font>
								</th>
								<th align="center">
									<font color="#006400">IN</font>
								</th>
							</tr>
							<tr>
								<td>
									<table border="1" cellpadding="0" cellspacing="0">
										<tr>
											<td bgColor="#009900" align="center">
												<FONT color="#ffffff">Product Name &amp; Package</FONT>
											</td>
											<td bgColor="#009900" align="center">
												<FONT color="#ffffff">Store In</FONT>
											</td>
											<td bgColor="#009900" align="center">
												<FONT color="#ffffff">Qty. in<br>
													Pack</FONT>
											</td>
											<td bgColor="#009900" align="center">
												<FONT color="#ffffff">Qty. in<br>
													Ltr.</FONT>
											</td>
										</tr>
										<tr>
											<td align="left"><asp:dropdownlist id="DropOutProd1" runat="server" Width="224px" onChange="return setStore(this,document.all.txtOutStoreIn1,document.all.txtOutQtyPack1,document.all.txtOutQtyLtr1);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></td>
											<td><asp:textbox id="txtOutStoreIn1" runat="server" Width="70px"  CssClass="FontStyle"></asp:textbox></td>
											<td><asp:textbox id="txtOutQtyPack1" runat="server" Width="40px" onblur="return checkStock(document.all.DropOutProd1,this);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></td>
											<td><asp:textbox id="txtOutQtyLtr1" runat="server" Width="40px" onblur="return checkStock(document.all.DropOutProd1,this);"
													CssClass="FontStyle"></asp:textbox></td>
										</tr>
										<TR>
											<TD><asp:dropdownlist id="DropOutProd2" runat="server" Width="224px" onChange="return setStore(this,document.all.txtOutStoreIn2,document.all.txtOutQtyPack2,document.all.txtOutQtyLtr2);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtOutStoreIn2" runat="server" Width="70px"  CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyPack2" runat="server" Width="40px" onblur="return checkStock(document.all.DropOutProd2,this);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyLtr2" runat="server" Width="40px" onblur="return checkStock(document.all.DropOutProd2,this);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropOutProd3" runat="server" Width="224px" onChange="return setStore(this,document.all.txtOutStoreIn3,document.all.txtOutQtyPack3,document.all.txtOutQtyLtr3);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtOutStoreIn3" runat="server" Width="70px"  CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyPack3" runat="server" Width="40px" onblur="return checkStock(document.all.DropOutProd3,this);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyLtr3" runat="server" Width="40px" onblur="return checkStock(document.all.DropOutProd3,this);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropOutProd4" runat="server" Width="224px" onChange="return setStore(this,document.all.txtOutStoreIn4,document.all.txtOutQtyPack4,document.all.txtOutQtyLtr4);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtOutStoreIn4" runat="server" Width="70px"  CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyPack4" runat="server" Width="40px" onblur="return checkStock(document.all.DropOutProd4,this);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyLtr4" runat="server" Width="40px" onblur="return checkStock(document.all.DropOutProd4,this);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><STRONG style="COLOR: #006400">Total Out:</STRONG></TD>
											<TD>&nbsp;</TD>
											<TD><asp:textbox id="txtTotalOutQtyPack" runat="server" Width="40px"  CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtTotalOutQtyLtr" runat="server" Width="40px"  CssClass="FontStyle"></asp:textbox></TD>
										</TR>
									</table>
								</td>
								<td>
									<table border="1" cellpadding="0" cellspacing="0">
										<tr>
											<td bgColor="#009900" align="center">
												<FONT color="#ffffff">Product Name &amp; Package</FONT>
											</td>
											<td bgColor="#009900" align="center">
												<FONT color="#ffffff">Store In</FONT>
											</td>
											<td bgColor="#009900" align="center">
												<FONT color="#ffffff">Qty. in<br>
													Pack</FONT>
											</td>
											<td bgColor="#009900" align="center">
												<FONT color="#ffffff">Qty. in<br>
													Ltr.</FONT>
											</td>
										</tr>
										<tr>
											<td><asp:dropdownlist id="DropInProd1" runat="server" Width="224px" onChange="return setStore(this,document.all.txtInStoreIn1,document.all.txtInQtyPack1,document.all.txtInQtyLtr1);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></td>
											<td><asp:textbox id="txtInStoreIn1" runat="server" Width="70px"  CssClass="FontStyle"></asp:textbox></td>
											<td><asp:textbox id="txtInQtyPack1" runat="server" Width="40px" onblur="return checkTotal(document.all.txtInQtyLtr1,document.all.txtOutQtyLtr1);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></td>
											<td><asp:textbox id="txtInQtyLtr1" runat="server" Width="40px" onblur="return checkTotal(document.all.txtInQtyLtr1,document.all.txtOutQtyLtr1);"
													CssClass="FontStyle"></asp:textbox></td>
										</tr>
										<TR>
											<TD><asp:dropdownlist id="DropInProd2" runat="server" Width="224px" onChange="return setStore(this,document.all.txtInStoreIn2,document.all.txtInQtyPack2,document.all.txtInQtyLtr2);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtInStoreIn2" runat="server" Width="70px"  CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtInQtyPack2" runat="server" Width="40px" onblur="return checkTotal(document.all.txtInQtyLtr2,document.all.txtOutQtyLtr2);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtInQtyLtr2" runat="server" Width="40px" onblur="return checkTotal(document.all.txtInQtyLtr2,document.all.txtOutQtyLtr2);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropInProd3" runat="server" Width="224px" onChange="return setStore(this,document.all.txtInStoreIn3,document.all.txtInQtyPack3,document.all.txtInQtyLtr3);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtInStoreIn3" runat="server" Width="70px"  CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtInQtyPack3" runat="server" Width="40px" onblur="return checkTotal(document.all.txtInQtyLtr3,document.all.txtOutQtyLtr3);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtInQtyLtr3" runat="server" Width="40px" onblur="return checkTotal(document.all.txtInQtyLtr3,document.all.txtOutQtyLtr3);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 21px"><asp:dropdownlist id="DropInProd4" runat="server" Width="224px" onChange="return setStore(this,document.all.txtInStoreIn4,document.all.txtInQtyPack4,document.all.txtInQtyLtr4);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtInStoreIn4" runat="server" Width="70px"  CssClass="FontStyle"></asp:textbox></TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtInQtyPack4" runat="server" Width="40px" onblur="return checkTotal(document.all.txtInQtyLtr4,document.all.txtOutQtyLtr4);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtInQtyLtr4" runat="server" Width="40px" onblur="return checkTotal(document.all.txtInQtyLtr4,document.all.txtOutQtyLtr4);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><STRONG style="COLOR: #006400">Total IN:</STRONG></TD>
											<TD>&nbsp;</TD>
											<TD><asp:textbox id="txtTotalInQtyPack" runat="server" Width="40px"  CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtTotalInQtyLtr" runat="server" Width="40px"  CssClass="FontStyle"></asp:textbox></TD>
										</TR>
									</table>
								</td>
							</tr>
							<TR>
								<TD align="center" colSpan="2">&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><asp:button id="btnPrint" runat="server" Width="70px" Text="Save" ></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id="Button1" runat="server"  Width="70px"  Text="Print" CausesValidation="False"></asp:Button></TD>
							</TR>
						</table>
					</td>
				</TR>
			</TABLE>
			<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></IFRAME>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		</FORM>
	</body>
</HTML>
