<%@ Page language="c#" Codebehind="Vehicle_logbook.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Logistics.Vehicle_logbook" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ePetro: Vehicle Daily Log Book</TITLE> 
		<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<script language="javascript">
		function getVehicleInfo(t)
		{
		var index = t.selectedIndex;
		var typetext = t.options[index].text;
		//alert(typetext);
		var temp = document.Vehicle_logbook.txtHidden.value;
		var mainArr = new Array();
		mainArr = temp.split("#");
		
		var t1="";
		for(var i=0; i<mainArr.length;i++)
		 {
	      t1 = mainArr[i];
	     // alert(t1);
	      var secArr = new Array();
		   secArr = t1.split("~");
		 //  alert(secArr[0])
		   for(var j = 0;j<secArr.length;j=j+4)
		   {
		 //  alert("j=="+j)
		    //   alert(secArr[j])
		       if( typetext == secArr[j])
		       {
		  
		          document.Vehicle_logbook.txtVehiclename.value = secArr[j+1]
		          document.Vehicle_logbook.txtdrivername.value = secArr[j+2]
		          document.Vehicle_logbook.txtmeterreadpre.value = secArr[j+3]
		          break
		       }
		   
		   } 
		   
		
		 }  
		}
		</script>
	</HEAD>
	<body>
		<form id="Vehicle_logbook" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header><INPUT id="txtHidden" style="WIDTH: 8px; HEIGHT: 16px" type="hidden" size="1" name="txtHidden"
				runat="server">
			<table height="288" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Vehicle Daily Log Book</font>
						<hr>
						</FONT></TH></TR>
				<tr>
					<td align="center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="1">
							<TR>
								<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;VDLB ID</TD>
								<TD><asp:label id="lblVDLBID" runat="server" ForeColor="Blue" Width="56px"></asp:label><asp:dropdownlist id="DropVDLBID" runat="server" Width="80px" CssClass="FontStyle" Visible="False"
										AutoPostBack="True">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:button id="btnEdit1" runat="server" ForeColor="White" Width="24px" Text="..." ToolTip="Click here for Edit"
										CausesValidation="False" BackColor="ForestGreen" BorderColor="ForestGreen"></asp:button></TD>
								<TD>&nbsp;Vehicle No.
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Vehicle No."
										ControlToValidate="DropVehicleNo" InitialValue="Select">*</asp:requiredfieldvalidator><FONT color="#ff0000">*
									</FONT>&nbsp;&nbsp;
									<asp:dropdownlist id="DropVehicleNo" runat="server" Width="162px" CssClass="FontStyle" onchange="return getVehicleInfo(this);">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;Vehicle&nbsp;Name&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtVehiclename" runat="server" Width="132px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;DOE (Date of Entry)
								</TD>
								<TD><asp:textbox id="txtDOE" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Vechile_entryform.txtDOE);return false;">&nbsp;</A></TD>
								<TD>&nbsp;Driver's Name&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtdrivername" runat="server" Width="161px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
								<td>&nbsp;Bilty 
									No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtBiltyNo" Width="132px"
										CssClass="FontStyle" BorderStyle="Groove" MaxLength="14" Runat="server"></asp:textbox></td>
							</TR>
							<tr>
								<td>&nbsp;Consignee Name</td>
								<td><asp:dropdownlist id="DropConsigneeName" Width="159px" CssClass="FontStyle" Runat="server">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></td>
								<td>&nbsp;Fright&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtFright" Width="162px"
										CssClass="FontStyle" BorderStyle="Groove" MaxLength="10" Runat="server"></asp:textbox></td>
								<td>&nbsp;Bilty 
									Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtBiltyDate" Width="80px" CssClass="FontStyle" BorderStyle="Groove" ReadOnly="True"
										Runat="server"></asp:textbox>&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtBiltyDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></td>
							</tr>
							<TR>
								<TD colSpan="2">&nbsp;Meter Reading&nbsp;&nbsp; (Previous Day)&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtmeterreadpre" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										ReadOnly="True"></asp:textbox></TD>
								<td>&nbsp;Meter Reading (Current Day)<FONT color="#ff0033">*</FONT><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Current Meter Reading"
										ControlToValidate="txtmeterreadcurr">*</asp:requiredfieldvalidator>&nbsp;<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtmeterreadcurr"
										runat="server" Width="91px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></td>
								<td>&nbsp;Acknowledgement&nbsp;&nbsp;
									<asp:radiobutton id="Radioyes" runat="server" Text="Yes" GroupName="Acknow"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:radiobutton id="RadioNo" runat="server" Text="No" GroupName="Acknow"></asp:radiobutton></td>
							</TR>
							<TR>
								<TD>&nbsp;Vehicle Route</TD>
								<TD><asp:dropdownlist id="Dropvehicleroute" runat="server" Width="159px" CssClass="FontStyle"></asp:dropdownlist></TD>
								<TD colSpan="2">&nbsp;Fuel Used <FONT color="#ff0000">*</FONT> &nbsp;&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="Dropfuelused" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtfuelused" runat="server"
										Width="36px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Engine Oil</TD>
								<TD><asp:dropdownlist id="Dropengineoil" runat="server" Width="120px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtengineqty" runat="server"
										Width="36px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD>&nbsp;Gear 
									Oil&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:dropdownlist id="Dropgearoil" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtGearqty" runat="server"
										Width="36px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD>&nbsp;Grease&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:dropdownlist id="Dropgrease" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtGreaseqty" runat="server"
										Width="36px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Brake Oil</TD>
								<TD><asp:dropdownlist id="Dropbrakeoil" runat="server" Width="120px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtBrakeqty" runat="server"
										Width="36px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD>&nbsp;Coolent&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:dropdownlist id="Dropcoolent" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtCoolentqty"
										runat="server" Width="36px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD>&nbsp;Trans. Oil&nbsp;&nbsp;
									<asp:dropdownlist id="Droptranoil" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtTranqty" runat="server"
										Width="36px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Other Exp.in Rupees</TD>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									Toll&nbsp;&nbsp;&nbsp;<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtTollqty" runat="server"
										Width="56px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD>&nbsp;Police&nbsp;
									<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtPoliceqty" runat="server"
										Width="56px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;&nbsp; &nbsp;Food&nbsp;&nbsp;&nbsp;
									<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtfoodqty" runat="server"
										Width="57px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
								<TD>&nbsp;Misc.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
									<asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtMiscqty" runat="server"
										Width="56px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="5"><asp:button id="btnSave" runat="server" ForeColor="White" Width="70px" Text="Save" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnEdit" runat="server" ForeColor="White" Width="70px" Text="Edit" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnDelete" runat="server" ForeColor="White" Width="70px" Text="Delete" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="Button1" runat="server" ForeColor="White" Width="70px" Text="Print" BackColor="ForestGreen"
										BorderColor="ForestGreen"></asp:button></TD>
							</TR>
							<tr>
								<td colSpan="5"><asp:validationsummary id="vsVehicle_log" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
							</tr>
						</TABLE>
					</td>
					<td></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<!--<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../shareables/style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>--><uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
