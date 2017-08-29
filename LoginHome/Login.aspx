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
	</HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" onload="Check();" MARGINHEIGHT="0"
		MARGINWIDTH="0">
		<form id="Form1" runat="server">
			<TABLE width="1350" border="0" align="center" cellPadding="0" cellSpacing="0" height="445">
              
				<TR>
					<TD colSpan="20" height="49"><IMG src="../HeaderFooter/images/ePetro_Header.png" width="1350" height="60"></TD>
				</TR>
				<TR>
					<TD width="1350" height="12" colSpan="20" background="../HeaderFooter/images/Login-Page_03.gif"></TD>
					<TD width="1" height="12"></TD>
				</TR>
				<TR>
					<TD colSpan="2" rowSpan="2"></TD>
					<TD></TD>
					<TD height="12" colSpan="14" rowSpan="2" align="center">
						<asp:Label id="lblMessage" runat="server" ForeColor="#004000" Font-Size="X-Small" Font-Bold="True"></asp:Label></TD>
					<TD></TD>
					<TD colSpan="2" rowSpan="2"></TD>
					<TD width="1" height="2"></TD>
				</TR>
				<TR>
					<TD width="11" height="16" background="../HeaderFooter/images/Login-Page_09.gif"></TD>
					<TD width="11" height="16" background="../HeaderFooter/images/Login-Page_10.gif"></TD>
					<TD width="1" height="16"></TD>
				</TR>
				<TR>
					<TD ></TD>
					<TD width="767" height="9" colSpan="18" align="center" vAlign="middle" background="../HeaderFooter/images/Login-Page_12.gif"></TD>
					<TD></TD>
					<TD width="1" height="9"></TD>
				</TR>
				<TR>
					<TD colSpan="2" rowSpan="16"></TD>
					<TD width="11" height="279" rowSpan="16" background="../HeaderFooter/images/Login-Page_15.gif"></TD>
					<TD colSpan="3" rowSpan="2"></TD>
					<TD background="../HeaderFooter/images/Login-Page_10.gif"></TD>
					<TD align="center" colSpan="10" rowSpan="2"></TD>
					<TD width="11" height="279" rowSpan="16" background="../HeaderFooter/images/Login-Page_19.gif"></TD>
					<TD colSpan="2" rowSpan="16"></TD>
					<TD width="1" height="14"></TD>
				</TR>
				<TR>
					<TD width="10" height="269" rowSpan="14" background="../HeaderFooter/images/Login-Page_21.gif"></TD>
					<TD width="1" height="2"></TD>
				</TR>
             
				<TR>
					<TD rowSpan="12"></TD>
					<TD rowSpan="12">
						<OBJECT codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=5,0,0,0"
							height="260" width="337" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" VIEWASTEXT>
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
							<embed src="../HeaderFooter/images/intro.swf" width="337" height="260" quality="high" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
								type="application/x-shockwave-flash"> </embed>
						</OBJECT>
					</TD>
					<TD rowSpan="12"></TD>
					<TD rowSpan="12"></TD>
					<TD width="9" height="241" rowSpan="11" background="../HeaderFooter/images/Login-Page_15.gif"></TD>
					<TD colSpan="6"> <IMG width="900" src="../HeaderFooter/images/ePetro_LoginUser.png"  height="40"></TD>
					<TD width="9" height="250" rowSpan="12" background="../HeaderFooter/images/Login-Page_15.gif"></TD>
					<TD rowSpan="12"></TD>
					<TD width="1" height="4"></TD>
				</TR>
				<TR>
					<TD width="98" height="45" colSpan="2" align="center" ><b><h7>User 
        Type :</h7></b>
					</TD>
					<TD height="45" colSpan="3" >&nbsp;&nbsp;&nbsp;
						<asp:dropdownlist id=DropUser Runat="server" Width="140px" DataSource="<%# Page %>" onChange="Enable();" CssClass="fontstyle">
							<asp:ListItem Value="Select">Select</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="4"></TD>
				</TR>
				<TR>
					<TD width="98" height="44" colSpan="2" align="center" ><b><h7>User 
        Login:</h7></b>
					</TD>
					<TD height="44" colSpan="3"  >&nbsp;&nbsp;&nbsp;
						<asp:textbox id="TxtUserName" runat="server" Width="140px" BorderStyle="Groove" CssClass="FontStyle"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUserName"   ErrorMessage="Please Enter Login Name"><font color="red">*</font></asp:requiredfieldvalidator>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="4"></TD>
				</TR>
				<TR>
					<TD width="98" height="46" colSpan="2" align="center" ><b><h7>Password 
        :</h7></b>
					</TD>
					<TD height="46" colSpan="3" >&nbsp;&nbsp;&nbsp;
						<asp:textbox id="TxtPassword" runat="server" Width="140px" TextMode="Password" BorderStyle="Groove"
							CssClass="FontStyle"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPassword"  ErrorMessage="Please Enter Password "><font color="red">*</font></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="3"></TD>
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
					<TD width="98" height="32" colSpan="2" align="center" ><b><h7>Set 
        Date :</h7></b>
					</TD>
					<TD height="32" colSpan="3" >&nbsp;&nbsp;&nbsp;
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
					<TD width="1" height="4"></TD>
				</TR>
				<TR>
					<TD width="317" height="45" colSpan="6" >
						<table height="28" width="315">
							<tr>
								<td width="116" height="28">&nbsp;</td>
								<td align="center" width="64" height="28">&nbsp;</td>
								<td width="119" height="28"><asp:imagebutton id="btnSign" runat="server" AlternateText="Sign in" ImageUrl="..\HeaderFooter\images\button.jpg"
										Height="28px"></asp:imagebutton></td>
							</tr>
						</table>
					</TD>
					<TD width="1" height="45"></TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
					<TD width="1" height="8"></TD>
				</TR>
				<TR>
					<TD width="328" height="9" colSpan="7"  background="../HeaderFooter/images/Login-Page_53.gif"></TD>
					<TD width="1" height="8"></TD>
				</TR>
				<TR >
					<TD colSpan="3" rowSpan="2"></TD>
					<TD colSpan="10" rowSpan="2" style="color:red;" ><asp:validationsummary id="ValidationSummary1"  runat="server"></asp:validationsummary></TD>
					<TD width="1" height="16"></TD>
				</TR>
				<TR>
					<TD background="../HeaderFooter/images/Login-Page_10.gif"></TD>
					<TD width="1" height="2"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="767" height="10" colSpan="18" align="center" vAlign="middle" background="../HeaderFooter/images/Login-Page_53.gif"></TD>
					<TD></TD>
					<TD width="1" height="9"></TD>
				</TR>
				<TR>
					<TD colSpan="2" rowSpan="2"></TD>
					<TD width="11" height="13" background="../HeaderFooter/images/Login-Page_56.gif"></TD>
					<TD height="13" colSpan="14"></TD>
					<TD width="11" height="20" background="../HeaderFooter/images/Login-Page_58.gif"></TD>
					<TD colSpan="2" rowSpan="2"></TD>
					<TD width="1" height="13"></TD>
				</TR>
				<TR>
					<TD colSpan="16" height="180"></TD>
					<TD width="1" height="3"></TD>
				</TR>
				<TR>
					<TD colSpan="20"> <IMG src="../HeaderFooter/images/ePetro_Footer.png" width="1350" height="50">
					</TD>
				</TR>
				<TR>
					<TD width="6" height="2"></TD>
					<TD vAlign="middle" align="center" width="11" height="2"></TD>
					<TD width="11" height="2"></TD>
					<TD width="9" height="2"></TD>
					<TD width="337" height="2"></TD>
					<TD width="11" height="2"></TD>
					<TD width="10" height="2"></TD>
					<TD width="12" height="2"></TD>
					<TD width="9" height="2"></TD>
					<TD width="97" height="2"></TD>
					<TD width="1" height="2"></TD>
					<TD width="4" height="2"></TD>
					<TD width="1" height="2"></TD>
					<TD width="79" height="2"></TD>
					<TD width="135" height="2"></TD>
					<TD width="11" height="2"></TD>
					<TD width="9" height="2"></TD>
					<TD width="11" height="2"></TD>
					<TD width="9" height="2"></TD>
					<TD width="5" height="2"></TD>
					<TD width="6" height="2"></TD>
				</TR>
			</TABLE>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
		</form>
	</BODY>
</HTML>
