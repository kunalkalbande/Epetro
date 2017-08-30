<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="EPetro.LoginHome.Login" %>
<HTML>
	<HEAD>
		<TITLE>ePetro: Login</TITLE> 
		<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Sysitem/Styles.css" type="text/css" rel="stylesheet">
			<script language="javascript">
		function Check()
		{
			if(document.all.DropUser.value=="Select")
			{
			    document.all.TxtUserName.disabled = true
			    document.all.TxtPassword.disabled = true
			}
		}
		
		function Enable()
		{
			if(document.all.DropUser.value=="Select")
			{
				document.all.TxtUserName.disabled=true
				document.all.TxtPassword.disabled = true
			}
			else
			{
			    document.all.TxtUserName.disabled = false
			    document.all.TxtPassword.disabled = false
			}		
		}
			</script>
	    <style type="text/css">
            .auto-style2 {
                margin-right: 0px;
                margin-left: 0px;
            }
            .auto-style4 {
                width: 10px;
            }
            .auto-style6 {
                width: 647px;
            }
            .auto-style7 {
                width: 1277px;
                margin-right: 0px;
            }
            .auto-style8 {
                width: 12px;
            }
            .auto-style9 {
                width: 11px;
            }
            .auto-style10 {
                width: 449px;
            }
            .auto-style11 {
                width: 254px;
            }
            .auto-style12 {
                width: 316px;
            }
            .auto-style13 {
                width: 22px;
            }
            .auto-style14 {
                width: 1239px;
            }
            .auto-style16 {
                width: 636px;
            }
        </style>
	</HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" onload="Check();" MARGINHEIGHT="0"
		MARGINWIDTH="0">
		<form id="Form1" runat="server">
			<TABLE border="0" align="center" cellPadding="0" cellSpacing="0" height="445" class="auto-style7">
              
				<TR>
					<TD colSpan="20" height="49"><IMG src="../HeaderFooter/images/ePetro_Header.png" height="60" class="auto-style14"></TD>
				</TR>
				<TR>
					<TD width="1150" height="12" colSpan="17" background="../HeaderFooter/images/Login-Page_03.gif"></TD>
					<TD width="1" height="12" class="auto-style4"></TD>
				</TR>
				<TR>
					<TD colSpan="2" rowSpan="2"></TD>
					<TD></TD>
					<TD height="12" colSpan="14" rowSpan="2" align="center">
						<asp:Label id="lblMessage" runat="server" ForeColor="#004000" Font-Size="X-Small" Font-Bold="True"></asp:Label></TD>
					<TD></TD>
					<TD colSpan="2" rowSpan="2"></TD>
					<TD width="1" height="2" class="auto-style4"></TD>
				</TR>
				<TR>
					<TD height="16" class="auto-style8" ></TD>
					<TD width="11" height="16" class="auto-style9" ></TD>
					<TD width="1" height="16" class="auto-style4"></TD>
				</TR>
				<TR>
					<TD ></TD>
					<TD width="767" height="9" colSpan="16" align="center" vAlign="middle" background="../HeaderFooter/images/Login-Page_12.gif"></TD>
					<TD></TD>
					<TD width="1" height="9" class="auto-style4"></TD>
				</TR>
				<TR>
					<TD colSpan="1" rowSpan="16"></TD>
					<TD height="279" rowSpan="16" background="../HeaderFooter/images/Login-Page_15.gif" class="auto-style8"></TD>
					<TD colSpan="3" rowSpan="2"></TD>
					<TD background="../HeaderFooter/images/Login-Page_10.gif"></TD>
					<TD align="center" colSpan="10" rowSpan="2"></TD>
					<TD width="11" height="279" rowSpan="16" background="../HeaderFooter/images/Login-Page_19.gif" class="auto-style9"></TD>
					<TD  ></TD>
					<TD width="1" height="14" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD width="10" height="269" rowSpan="14" background="../HeaderFooter/images/Login-Page_21.gif" class="auto-style9"></TD>
					<TD width="1" height="2" class="auto-style9"></TD>
				</TR>
             
				<TR>
					<TD rowSpan="12"></TD>
					<TD rowSpan="12" class="auto-style10">
						<OBJECT codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=5,0,0,0"
							height="260" width="500" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" VIEWASTEXT>
							<PARAM NAME="_cx" VALUE="8916">
							<PARAM NAME="_cy" VALUE="6879">
							<PARAM NAME="FlashVars" VALUE="8916">
							<PARAM NAME="Movie" VALUE="../HeaderFooter/images/intro.swf">
							<PARAM NAME="Src" VALUE="../HeaderFooter/images/intro.swf">
							<PARAM NAME="WMode" VALUE="Window">
							<PARAM NAME="Play" VALUE="-1">
							<PARAM NAME="Loop" VALUE="-1">
							<PARAM NAME="Quality" VALUE="High">
							<PARAM NAME="SAlign" VALUE="">
							<PARAM NAME="Menu" VALUE="-1">
							<PARAM NAME="Base" VALUE="">
							<PARAM NAME="AllowScriptAccess" VALUE="always">
							<PARAM NAME="Scale" VALUE="ShowAll">
							<PARAM NAME="DeviceFont" VALUE="0">
							<PARAM NAME="EmbedMovie" VALUE="0">
							<PARAM NAME="BGColor" VALUE="">
							<PARAM NAME="SWRemote" VALUE="">
							<embed src="../HeaderFooter/images/intro.swf" width="500" height="260" quality="high" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
								type="application/x-shockwave-flash"> </embed>
						</OBJECT>
					</TD>
					<TD rowSpan="12" class="auto-style8"></TD>
					<TD rowSpan="12"></TD>
					<TD width="9" height="241" rowSpan="11" background="../HeaderFooter/images/Login-Page_15.gif" class="auto-style8"></TD>
					<TD colSpan="5"> <IMG src="../HeaderFooter/images/ePetro_LoginUser.png"  height="40" class="auto-style16"></TD>
					<TD colSpan="0" rowSpan="12"><IMG src="../HeaderFooter/images/Login-Page_15.gif" height="330" width="5" class="auto-style2" /></TD>
					<TD rowSpan="12" class="auto-style9"></TD>
					<TD width="1" height="4" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD width="175" height="45" colSpan="1" align="center" class="auto-style11" ><b><h7>User 
        Type :</h7></b>
					</TD>
					<TD height="45" colSpan="1" class="auto-style12" >
						<asp:dropdownlist id=DropUser Runat="server" Width="140px" DataSource="<%# Page %>" onChange="Enable();" CssClass="fontstyle">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="4" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD width="70" height="44" colSpan="1" align="center" class="auto-style11" ><b><h7>User 
        Login :</h7></b>
					</TD>
					<TD height="44" colSpan="1" class="auto-style12"  >
						<asp:textbox id="TxtUserName" runat="server" Width="140px" BorderStyle="Groove" CssClass="FontStyle"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUserName"   ErrorMessage="Please Enter Login Name"><font color="red">*</font></asp:requiredfieldvalidator>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="4" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD width="70" height="46" colSpan="1" align="center" class="auto-style11" ><b><h7>Password 
        :</h7></b>
					</TD>
					<TD height="46" colSpan="1" class="auto-style12" >
						<asp:textbox id="TxtPassword" runat="server" Width="140px" TextMode="Password" BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPassword"  ErrorMessage="Please Enter Password "><font color="red">*</font></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="3" class="auto-style9"></TD>
				</TR>
				<TR>
					<!--<TD width="317" background="../HeaderFooter/images/Login-Page_44.gif" colSpan="6" height="32">ssss
						<table width="314">
							<tr>
								<td align="center" width="138"></td>
								<td align="center" width="164"></td>
							</tr>
						</table>
					</TD>-->
					<TD width="70" height="32" colSpan="1" align="center" class="auto-style11" ><b><h7>Set 
        Date :</h7></b>
					</TD>
					<TD height="32" colSpan="1" class="auto-style12" >
						<asp:textbox id="txtDateFrom" runat="server" Width="115px"  BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox>
						<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"
							id="a1"><IMG class="PopcalTrigger" alt="" src="../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
								border="0" id="Cal_Img" runat="server"></A><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDateFrom);return false;"></A><IMG class="PopcalTrigger" alt="" src="../HeaderFooter/DTPicker/calendar_icon1.gif" align="absMiddle"
							border="0" id="Cal_Img1" runat="server">
					</TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="4" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD height="45" colSpan="6" >
						<table height="28" width="315">
							<tr>
								<td width="116" height="28">&nbsp;</td>
								<td align="center" width="64" height="28">&nbsp;</td>
								<td width="119" height="28"><asp:imagebutton id="btnSign" runat="server" AlternateText="Sign in" ImageUrl="..\HeaderFooter\images\button.jpg"
										Height="28px"></asp:imagebutton></td>
							</tr>
						</table>
					</TD>
					<TD width="1" height="45" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="8" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD  colSpan="7"><IMG src="../HeaderFooter/images/Login-Page_53.gif" height="9" class="auto-style6" width="640px"></TD>
					<TD width="1" height="8" class="auto-style9"></TD>
				</TR>
				<TR >
					<TD colSpan="3" rowSpan="2"></TD>
					<TD colSpan="10" rowSpan="2" style="color:red;" ><asp:validationsummary id="ValidationSummary1"  runat="server"></asp:validationsummary></TD>
					<TD width="1" height="16" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD colSpan="6"> <IMG src="../HeaderFooter/images/Login-Page_10.gif" ></TD>
					<TD width="1" height="2" class="auto-style9"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="767" height="10" colSpan="16" align="center" vAlign="middle" background="../HeaderFooter/images/Login-Page_53.gif"></TD>
					<TD></TD>
					<TD width="1" height="9" class="auto-style4"></TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
					<TD colSpan="16" height="90"></TD>
					<TD colSpan="2"></TD>
					<TD width="1" height="3" class="auto-style4"></TD>
				</TR>
				<TR>
					<TD colSpan="20"> <IMG src="../HeaderFooter/images/ePetro_Footer.png" height="50" class="auto-style14">
					</TD>
				</TR>
				<TR>
					<TD width="6" height="2" class="auto-style8"></TD>
					<TD vAlign="middle" align="center" height="2" class="auto-style8"></TD>
					<TD height="2" class="auto-style8"></TD>
					<TD height="2" class="auto-style10"></TD>
					<TD height="2" class="auto-style8"></TD>
					<TD width="11" height="2" class="auto-style9"></TD>
					<TD width="10" height="2" class="auto-style9"></TD>
					<TD width="12" height="2" class="auto-style8"></TD>
					<TD width="9" height="2" class="auto-style11"></TD>
					<TD height="2" class="auto-style12"></TD>
					<TD width="1" height="2" class="auto-style13"></TD>
					<TD width="4" height="2" class="auto-style13"></TD>
					<TD width="1" height="2" class="auto-style13"></TD>
					<TD height="2"></TD>
					<TD height="2" class="auto-style9"></TD>
					<TD width="11" height="2" class="auto-style9"></TD>
					<TD width="9" height="2" class="auto-style9"></TD>
					<TD width="11" height="2" class="auto-style9"></TD>
					<TD width="9" height="2" class="auto-style9"></TD>
					<TD width="5" height="2" class="auto-style9"></TD>
					<TD width="6" height="2" class="auto-style4"></TD>
				</TR>
			</TABLE>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
		</form>
	</BODY>
</HTML>
