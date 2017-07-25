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
var temp = document.Form1.txtTemp1.value;  
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
var temp = document.Form1.txtQty.value;  
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


  
  if(document.Form1.txtOutQtyPack1.value != "")
  {

  OutPackTotal = OutPackTotal+ eval(document.Form1.txtOutQtyPack1.value);
  calcPack(document.Form1.txtOutQtyLtr1,document.Form1.txtOutQtyPack1,document.Form1.DropOutProd1,document.Form1.tmpOutQtyLtr1);
  }
  
  if(document.Form1.txtOutQtyLtr1.value != "")
  {
    OutLtrTotal = OutLtrTotal+ eval(document.Form1.txtOutQtyLtr1.value);
  }
  
   if(document.Form1.txtOutQtyPack2.value != "")
  {
  
  OutPackTotal = OutPackTotal+ eval(document.Form1.txtOutQtyPack2.value);
  calcPack(document.Form1.txtOutQtyLtr2,document.Form1.txtOutQtyPack2,document.Form1.DropOutProd2,document.Form1.tmpOutQtyLtr2);
  }
  
  if(document.Form1.txtOutQtyLtr2.value != "")
  {
  OutLtrTotal = OutLtrTotal+ eval(document.Form1.txtOutQtyLtr2.value);
  }
   if(document.Form1.txtOutQtyPack3.value != "")
  {
  
   OutPackTotal = OutPackTotal+ eval(document.Form1.txtOutQtyPack3.value);
  calcPack(document.Form1.txtOutQtyLtr3,document.Form1.txtOutQtyPack3,document.Form1.DropOutProd3,document.Form1.tmpOutQtyLtr3);
  }
  
  if(document.Form1.txtOutQtyLtr3.value != "")
  {
  OutLtrTotal = OutLtrTotal+ eval(document.Form1.txtOutQtyLtr3.value);
  }
   if(document.Form1.txtOutQtyPack4.value != "")
  {
  
  OutPackTotal = OutPackTotal+ eval(document.Form1.txtOutQtyPack4.value);
  calcPack(document.Form1.txtOutQtyLtr4,document.Form1.txtOutQtyPack4,document.Form1.DropOutProd4,document.Form1.tmpOutQtyLtr4);
  }
  
  if(document.Form1.txtOutQtyLtr4.value != "")
  {
    OutLtrTotal = OutLtrTotal+ eval(document.Form1.txtOutQtyLtr4.value);
  }
  
  if(document.Form1.txtInQtyPack1.value != "")
  {
  
  InPackTotal = InPackTotal+ eval(document.Form1.txtInQtyPack1.value);
  calcPack(document.Form1.txtInQtyLtr1,document.Form1.txtInQtyPack1,document.Form1.DropInProd1,document.Form1.tmpInQtyLtr1 );
  }
  
  if(document.Form1.txtInQtyLtr1.value != "")
  {
    InLtrTotal = InLtrTotal+ eval(document.Form1.txtInQtyLtr1.value);
  }
  
  if(document.Form1.txtInQtyPack2.value != "")
  {
  
  InPackTotal = InPackTotal+ eval(document.Form1.txtInQtyPack2.value);
  calcPack(document.Form1.txtInQtyLtr2,document.Form1.txtInQtyPack2,document.Form1.DropInProd2,document.Form1.tmpInQtyLtr2);
  }
  
  if(document.Form1.txtInQtyLtr2.value != "")
  {
    InLtrTotal = InLtrTotal+ eval(document.Form1.txtInQtyLtr2.value);
  }
  
  if(document.Form1.txtInQtyPack3.value != "")
  {
  
  InPackTotal = InPackTotal+ eval(document.Form1.txtInQtyPack3.value);
  calcPack(document.Form1.txtInQtyLtr3,document.Form1.txtInQtyPack3,document.Form1.DropInProd3,document.Form1.tmpInQtyLtr3);
  }
  
  if(document.Form1.txtInQtyLtr3.value != "")
  {
    InLtrTotal = InLtrTotal+ eval(document.Form1.txtInQtyLtr3.value);
  }
  if(document.Form1.txtInQtyPack4.value != "")
  {
  
  InPackTotal = InPackTotal+ eval(document.Form1.txtInQtyPack4.value);
  calcPack(document.Form1.txtInQtyLtr4,document.Form1.txtInQtyPack4,document.Form1.DropInProd4,document.Form1.tmpInQtyLtr4);
  }
  
  if(document.Form1.txtInQtyLtr4.value != "")
  {
    InLtrTotal = InLtrTotal+ eval(document.Form1.txtInQtyLtr4.value);
  }
 document.Form1.txtTotalOutQtyLtr.value ="";
  document.Form1.txtTotalOutQtyPack.value = "";
   document.Form1.txtTotalInQtyLtr.value ="";
  document.Form1.txtTotalInQtyPack.value = "";
    document.Form1.txtTotalOutQtyLtr.value = OutLtrTotal;
   makeRound( document.Form1.txtTotalOutQtyLtr);
    document.Form1.txtTotalOutQtyPack.value = OutPackTotal;
   makeRound( document.Form1.txtTotalOutQtyPack);
      document.Form1.txtTotalInQtyLtr.value = InLtrTotal;
   makeRound( document.Form1.txtTotalInQtyLtr);
    document.Form1.txtTotalInQtyPack.value = InPackTotal;
   makeRound( document.Form1.txtTotalInQtyPack);
  
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
	     document.Form1.txtAccName1.value = typetext;
	  if(t.name == "dropAccName2")
	     document.Form1.txtAccName2.value = typetext;
	  if(t.name == "dropAccName3")
	     document.Form1.txtAccName3.value = typetext;
	  if(t.name == "dropAccName4")
		document.Form1.txtAccName4.value = typetext;
	  if(t.name == "dropAccName5")
		document.Form1.txtAccName5.value = typetext;
	  if(t.name == "dropAccName6")
		document.Form1.txtAccName6.value = typetext;
	  if(t.name == "dropAccName7")
		document.Form1.txtAccName7.value = typetext;
	  if(t.name == "dropAccName8")
		document.Form1.txtAccName8.value = typetext;     
	       
	   
	}
	
	function setStore(t,t1,t2,t3)
	{
	//alert("in");
	   t2.value = "";
	   t3.value = "";
	   t1.value = "";
	   var index = t.selectedIndex;
	  
	   var typetext = t.options[index].text;
	   var temp = document.Form1.txtTemp.value; 
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
											<td align="left"><asp:dropdownlist id="DropOutProd1" runat="server" Width="224px" onChange="return setStore(this,document.Form1.txtOutStoreIn1,document.Form1.txtOutQtyPack1,document.Form1.txtOutQtyLtr1);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></td>
											<td><asp:textbox id="txtOutStoreIn1" runat="server" Width="70px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></td>
											<td><asp:textbox id="txtOutQtyPack1" runat="server" Width="40px" onblur="return checkStock(document.Form1.DropOutProd1,this);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></td>
											<td><asp:textbox id="txtOutQtyLtr1" runat="server" Width="40px" onblur="return checkStock(document.Form1.DropOutProd1,this);"
													CssClass="FontStyle"></asp:textbox></td>
										</tr>
										<TR>
											<TD><asp:dropdownlist id="DropOutProd2" runat="server" Width="224px" onChange="return setStore(this,document.Form1.txtOutStoreIn2,document.Form1.txtOutQtyPack2,document.Form1.txtOutQtyLtr2);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtOutStoreIn2" runat="server" Width="70px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyPack2" runat="server" Width="40px" onblur="return checkStock(document.Form1.DropOutProd2,this);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyLtr2" runat="server" Width="40px" onblur="return checkStock(document.Form1.DropOutProd2,this);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropOutProd3" runat="server" Width="224px" onChange="return setStore(this,document.Form1.txtOutStoreIn3,document.Form1.txtOutQtyPack3,document.Form1.txtOutQtyLtr3);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtOutStoreIn3" runat="server" Width="70px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyPack3" runat="server" Width="40px" onblur="return checkStock(document.Form1.DropOutProd3,this);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyLtr3" runat="server" Width="40px" onblur="return checkStock(document.Form1.DropOutProd3,this);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropOutProd4" runat="server" Width="224px" onChange="return setStore(this,document.Form1.txtOutStoreIn4,document.Form1.txtOutQtyPack4,document.Form1.txtOutQtyLtr4);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtOutStoreIn4" runat="server" Width="70px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyPack4" runat="server" Width="40px" onblur="return checkStock(document.Form1.DropOutProd4,this);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtOutQtyLtr4" runat="server" Width="40px" onblur="return checkStock(document.Form1.DropOutProd4,this);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><STRONG style="COLOR: #006400">Total Out:</STRONG></TD>
											<TD>&nbsp;</TD>
											<TD><asp:textbox id="txtTotalOutQtyPack" runat="server" Width="40px" ReadOnly="True" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtTotalOutQtyLtr" runat="server" Width="40px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
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
											<td><asp:dropdownlist id="DropInProd1" runat="server" Width="224px" onChange="return setStore(this,document.Form1.txtInStoreIn1,document.Form1.txtInQtyPack1,document.Form1.txtInQtyLtr1);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></td>
											<td><asp:textbox id="txtInStoreIn1" runat="server" Width="70px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></td>
											<td><asp:textbox id="txtInQtyPack1" runat="server" Width="40px" onblur="return checkTotal(document.Form1.txtInQtyLtr1,document.Form1.txtOutQtyLtr1);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></td>
											<td><asp:textbox id="txtInQtyLtr1" runat="server" Width="40px" onblur="return checkTotal(document.Form1.txtInQtyLtr1,document.Form1.txtOutQtyLtr1);"
													CssClass="FontStyle"></asp:textbox></td>
										</tr>
										<TR>
											<TD><asp:dropdownlist id="DropInProd2" runat="server" Width="224px" onChange="return setStore(this,document.Form1.txtInStoreIn2,document.Form1.txtInQtyPack2,document.Form1.txtInQtyLtr2);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtInStoreIn2" runat="server" Width="70px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtInQtyPack2" runat="server" Width="40px" onblur="return checkTotal(document.Form1.txtInQtyLtr2,document.Form1.txtOutQtyLtr2);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtInQtyLtr2" runat="server" Width="40px" onblur="return checkTotal(document.Form1.txtInQtyLtr2,document.Form1.txtOutQtyLtr2);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:dropdownlist id="DropInProd3" runat="server" Width="224px" onChange="return setStore(this,document.Form1.txtInStoreIn3,document.Form1.txtInQtyPack3,document.Form1.txtInQtyLtr3);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD><asp:textbox id="txtInStoreIn3" runat="server" Width="70px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
											<TD><asp:textbox id="txtInQtyPack3" runat="server" Width="40px" onblur="return checkTotal(document.Form1.txtInQtyLtr3,document.Form1.txtOutQtyLtr3);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtInQtyLtr3" runat="server" Width="40px" onblur="return checkTotal(document.Form1.txtInQtyLtr3,document.Form1.txtOutQtyLtr3);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 21px"><asp:dropdownlist id="DropInProd4" runat="server" Width="224px" onChange="return setStore(this,document.Form1.txtInStoreIn4,document.Form1.txtInQtyPack4,document.Form1.txtInQtyLtr4);"
													CssClass="FontStyle">
													<asp:ListItem Value="Select">Select</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtInStoreIn4" runat="server" Width="70px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtInQtyPack4" runat="server" Width="40px" onblur="return checkTotal(document.Form1.txtInQtyLtr4,document.Form1.txtOutQtyLtr4);"
													CssClass="FontStyle" MaxLength="5"></asp:textbox></TD>
											<TD style="HEIGHT: 21px"><asp:textbox id="txtInQtyLtr4" runat="server" Width="40px" onblur="return checkTotal(document.Form1.txtInQtyLtr4,document.Form1.txtOutQtyLtr4);"
													CssClass="FontStyle"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><STRONG style="COLOR: #006400">Total IN:</STRONG></TD>
											<TD>&nbsp;</TD>
											<TD><asp:textbox id="txtTotalInQtyPack" runat="server" Width="40px" ReadOnly="True" CssClass="FontStyle"
													MaxLength="5"></asp:textbox></TD>
											<TD><asp:textbox id="txtTotalInQtyLtr" runat="server" Width="40px" ReadOnly="True" CssClass="FontStyle"></asp:textbox></TD>
										</TR>
									</table>
								</td>
							</tr>
							<TR>
								<TD align="center" colSpan="2">&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><asp:button id="btnPrint" runat="server" Width="70px" Text="Save" ForeColor="White" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id="Button1" runat="server" ForeColor="White" Width="70px" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Print" CausesValidation="False"></asp:Button></TD>
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
