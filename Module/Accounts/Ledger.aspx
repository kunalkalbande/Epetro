<%@ Page language="c#" Codebehind="Ledger.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Accounts.Ledgre" EnableEventValidation="false"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Ledger Creation</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<script language="javascript">
		       function getGroup(t)
		       {
		         var typeindex = t.selectedIndex
                 var typetext  = t.options[typeindex].text
                 document.all.TxtSub.value = "";
                
                 var mainarr = new Array();
                 var secarr  = new Array();
                 var n =0;
                 var hidarr = document.all.txtValue.value;
                 mainarr = hidarr.split("#");
                 document.all.DropGroup.length = 1;
                 if(typetext == "Other")
                 {
                // alert("Other")
                     document.all.TxtSub.disabled = false;
                  //for(var i=0;i < mainarr.length;i++)
                 //{
                     hidarr = document.all.txtGrp.value;
                 secarr = hidarr.split("~");
                 // alert(secarr[1])
                 for(var j=0;j<secarr.length-1;j++)
                 {
                     document.all.DropGroup.add(new Option)
                 if(secarr[j]  != "")
                 {
                     document.all.DropGroup.options[n + 1].text = secarr[j];
                 n = n+1;
                 }
                 }
               
                 //}
                  //document.Form1.DropGroup.selectedIndex = 1;
                 document.all.DropGroup.add(new Option)
                 document.all.DropGroup.options[n + 1].text = "Other";
                 
                 }
                 else
                 {
                 //alert("else");
                 
                     document.all.TxtSub.disabled = true;
                 for(var i=0;i < mainarr.length;i++)
                 {
                 secarr = mainarr[i].split("~");
                 if(typetext == secarr[0])
                    {
                     document.all.DropGroup.add(new Option)
                     document.all.DropGroup.options[n + 1].text = secarr[1];
                     n = n + 1;                   
                     if(secarr[2] == "Assets")
                     {
                         document.all.RadioAsset.checked = true;
                     }
                     else if(secarr[2] == "Liabilities")
                     {
                         document.all.RadioLiab.checked = true;
                     }
                     else if(secarr[2] == "Expenses")
                     {
                         document.all.RadioExp.checked = true;
                     }
                     else
                     {
                         document.all.RadioIncome.checked = true;
                     }
                            
                                       
                    } 
                 
                 }
                 document.all.DropGroup.selectedIndex = 1;
                 document.all.DropGroup.add(new Option)
                 document.all.DropGroup.options[n + 1].text = "Other";
                    
                   setNature(t);
                 
                                      
                 
                 }
                 
               }  
               
               function setNature(t)
               {
                
               var typeindex = t.selectedIndex
                var typetext  = t.options[typeindex].text
                var mainarr = new Array();
                 var secarr  = new Array();
                 var hidarr = document.all.txtValue.value;
                 mainarr = hidarr.split("#");               
                 var typeindex = document.all.DropGroup.selectedIndex
                 var typetext1 = document.all.DropGroup.options[typeindex].text
                 document.all.txtTempGrp.value = typetext1;
                 if(typetext1  == "Other")
                 {
                     document.all.TxtGroup.disabled = false;
                     document.all.RadioAsset.checked = true;
                 }
                 else
                 {
                     document.all.TxtGroup.disabled = true;
                     document.all.TxtGroup.value = "";
                 for(var i=0;i < mainarr.length;i++)
                 {
                 secarr = mainarr[i].split("~");
                 if(typetext == secarr[0] && typetext1 == secarr[1] )
                    {
                     if(secarr[2] == "Assets")
                     {
                         document.all.RadioAsset.checked = true;
                     }
                     else if(secarr[2] == "Liabilities")
                     {
                         document.all.RadioLiab.checked = true;
                     }
                     else if(secarr[2] == "Expenses")
                     {
                         document.all.RadioExp.checked = true;
                     }
                     else
                     {
                         document.all.RadioIncome.checked = true;
                     }
                            
                                       
                    } 
                    }
                 
                 }
               }
		       
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><INPUT id="txtValue" style="Z-INDEX: 102; LEFT: 144px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="txtValue" runat="server"> <INPUT id="txtTempGrp" style="Z-INDEX: 103; LEFT: 160px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 24px"
				type="hidden" size="1" name="txtTempGrp" runat="server"> <INPUT id="txtGrp" style="Z-INDEX: 104; LEFT: 176px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 24px"
				type="hidden" size="1" name="txtGrp" runat="server">
			<TABLE height="288" width="778" align="center">
				<tr>
					<th style="HEIGHT: 13px" align="center">
						&nbsp;<font color="#006400">Ledger Creation</font>
						<hr>
					</th>
				</tr>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE style="WIDTH: 611px; HEIGHT: 150px" border="0">
							<TR>
								<TD style="HEIGHT: 5px" colSpan="2"><FONT color="#ff0000">Fields Marked as (*) Are 
										Mandatory</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 10px" align="left">Ledger Name&nbsp; <FONT color="#ff0000">
										*</FONT>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtLedger" ErrorMessage="Please Enter Ledger Name">*</asp:requiredfieldvalidator><FONT color="red"></FONT></TD>
								<TD style="HEIGHT: 10px"><asp:dropdownlist id="dropLedgerName" runat="server" Visible="False" AutoPostBack="True" Width="229px"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:textbox id="TxtLedger" runat="server" Width="229px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="49"></asp:textbox><asp:button id="btnEdit1" runat="server" Text="..." ToolTip="Click Here For Edit" CausesValidation="False"
										BorderColor="ForestGreen" BackColor="ForestGreen" ForeColor="White"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 15px" align="left">SubGroup Name <FONT color="#ff3333">*</FONT></TD>
								<TD style="HEIGHT: 15px"><asp:dropdownlist id="DropSub" runat="server" Width="170px" onChange="return getGroup(this);" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;<FONT color="#0000ff">(if another, Specify)</FONT>
									<asp:textbox id="TxtSub" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 9px" width="98">Group Name <FONT color="#ff0000">*</FONT>
								</TD>
								<TD style="HEIGHT: 9px"><asp:dropdownlist id="DropGroup" runat="server" Width="170px" onchange="return setNature(document.all.DropSub);"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><FONT color="#0000ff">(if another, Specify)</FONT>&nbsp;
									<asp:textbox id="TxtGroup" runat="server" Width="110px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="49"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 34px" align="left">Nature of Group <FONT color="#ff0000">
										&nbsp;&nbsp;&nbsp;</FONT></TD>
								<TD style="HEIGHT: 34px">
									<P align="left"><asp:radiobutton id="RadioAsset" runat="server" Text="Asset" Checked="True" GroupName="Nature"></asp:radiobutton>s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:radiobutton id="RadioLiab" runat="server" Text="Liabilities" GroupName="Nature"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:radiobutton id="RadioExp" runat="server" Text="Expenses" GroupName="Nature"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:radiobutton id="RadioIncome" runat="server" Text="Income" GroupName="Nature"></asp:radiobutton></P>
								</TD>
							</TR>
							<!--	<TR>
								<TD style="HEIGHT: 30px" align="left" colSpan="4">&nbsp;Effective 
									From&nbsp;&nbsp;&nbsp;
									<asp:textbox id="TxtFrom" runat="server" Width="84px"></asp:textbox>&nbsp;&nbsp;&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" id="Img3" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A>&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;&nbsp;Effective TO
									<asp:textbox id="TxtTo" runat="server" Width="60px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txtDate);return false;"><IMG class="PopcalTrigger" id="Img1" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0" runat="server"></A>
								</TD>
							</TR>-->
							<TR>
								<TD style="WIDTH: 98px; HEIGHT: 26px">Opening Balance&nbsp;</TD>
								<TD style="HEIGHT: 26px"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="TxtOpeningBal"
										runat="server" Width="120px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:dropdownlist id="DropBalType" runat="server" Width="40px" CssClass="FontStyle">
										<asp:ListItem Value="Debit">Dr</asp:ListItem>
										<asp:ListItem Value="Credit">Cr</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>
								</TD>
								<TD></TD>
							</TR>
							<tr>
								<td colSpan="2" height="5"></td>
							</tr>
							<TR>
								<TD style="HEIGHT: 8px" align="center" colSpan="2"><asp:button id="btnSave" runat="server" Width="70px" Text="Add" BorderColor="ForestGreen" BackColor="ForestGreen"
										ForeColor="White" ></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnEdit" runat="server" Width="70px" Text="Edit" BorderColor="ForestGreen" BackColor="ForestGreen"
										ForeColor="White"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;<asp:button id="btnDelete" runat="server" Width="71px" Text="Delete" CausesValidation="False"
										BorderColor="ForestGreen" BackColor="ForestGreen" ForeColor="White"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
							Height="209px"></asp:validationsummary></TD>
				</TR>
			</TABLE>
			<!--<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></IFRAME>--><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		</FORM>
	</body>
</HTML>
