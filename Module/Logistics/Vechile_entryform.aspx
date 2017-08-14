<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Vechile_entryform.aspx.cs" AutoEventWireup="false" Inherits="Epetro.Form.Logistics.Vechile_entryform" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ePetro: Vehicle Entry</TITLE> <!--
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
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Vechile_entryform" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table cellSpacing="0" cellPadding="0" width="778" align="center">
				<TR>
					<TH align="center">
						<font color="#006400">Vehicle Entry</font>
						<hr>
						</FONT></TH></TR>
				<tr>
					<td align="center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="1">
							<TR>
								<TD colSpan="4"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 24px" colSpan="1">&nbsp;Vehicle ID</TD>
								<TD style="HEIGHT: 24px" align="left" colSpan="3"><asp:label id="lblVehicleID" runat="server" ForeColor="Blue" Height="20px" Width="100px"></asp:label><asp:dropdownlist id="DropVehicleID" runat="server" Width="100px" AutoPostBack="True" Visible="False"
										CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><asp:button id="btnEdit1" runat="server" ForeColor="White" Width="24px" BorderColor="ForestGreen"
										BackColor="ForestGreen" CausesValidation="False" ToolTip="Click here for edit" Text="..."></asp:button></TD>
							</TR>
							<TR>
								<TD>&nbsp;Vehicle's Type</TD>
								<TD><asp:dropdownlist id="DropVechileType2" runat="server" Width="100px" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Bus">Bus</asp:ListItem>
										<asp:ListItem Value="Car">Car</asp:ListItem>
										<asp:ListItem Value="Jeep">Jeep</asp:ListItem>
										<asp:ListItem Value="Motor Cycle">Motor Cycle</asp:ListItem>
										<asp:ListItem Value="Scooter">Scooter</asp:ListItem>
										<asp:ListItem Value="Tanker">Tanker</asp:ListItem>
										<asp:ListItem Value="Truck">Truck</asp:ListItem>
										<asp:ListItem Value="Other">Other</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD>&nbsp;Vehicle No <asp:requiredfieldvalidator id="RefLnm" ControlToValidate="txtVehicleno" ErrorMessage="You Must Enter Vechicle No"
										Display="Dynamic" Runat="server"><font color="red">*</font></asp:requiredfieldvalidator></TD>
								<TD><asp:textbox id="txtVehicleno" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Vehicle Name</TD>
								<TD><asp:textbox id="txtVehiclenm" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="49"></asp:textbox></TD>
								<TD>&nbsp;RTO Registration Validity&nbsp;</TD>
								<TD><asp:textbox id="txtrtoregvalidity" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="12"></asp:textbox><asp:comparevalidator id="Comparevalidator1" ControlToValidate="txtrtoregvalidity" ErrorMessage="Rto registration validity must be numeric."
										Display="Dynamic" Runat="server" Enabled="False" Operator="DataTypeCheck">*</asp:comparevalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Model Name</TD>
								<TD><asp:textbox id="txtmodelnm" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="49"></asp:textbox></TD>
								<TD>&nbsp;RTO Registration No.<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtrtono" ErrorMessage="You Must Enter R.T.O Registration No"><font color="red">*</font></asp:requiredfieldvalidator></TD>
								<TD><asp:textbox id="txtrtono" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Vehicle Manufact. Date</TD>
								<TD><asp:textbox id="txtVehicleyear" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="12"></asp:textbox></TD>
								<TD>&nbsp;Insurance No.</TD>
								<TD><asp:textbox id="txtinsuranceno" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="20"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Meter Reading (K.M.)</TD>
								<TD><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtVehiclemreading"
										runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="15"></asp:textbox><asp:comparevalidator id="Comparevalidator4" ControlToValidate="txtVehiclemreading" ErrorMessage="Meter reading must be numeric."
										Display="Dynamic" Runat="server" Operator="DataTypeCheck" Type="Integer">*</asp:comparevalidator></TD>
								<TD>&nbsp;Insurance Validity</TD>
								<TD><asp:textbox id="txtvalidityinsurance" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 9px">&nbsp;Vehicle Route</TD>
								<TD style="HEIGHT: 9px"><asp:dropdownlist id="DropDownList1" runat="server" Width="200px" CssClass="FontStyle"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 9px">&nbsp;Insurance Company Name</TD>
								<TD style="HEIGHT: 9px"><asp:textbox id="txtInsCompName" runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"
										MaxLength="49"></asp:textbox><asp:comparevalidator id="Comparevalidator6" ControlToValidate="txtInsCompName" ErrorMessage="Driver salary must be numeric."
										Display="Dynamic" Runat="server" Operator="DataTypeCheck">*</asp:comparevalidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Fuel Used ( Petrol/Diesel )</TD>
								<TD><asp:dropdownlist id="DropFuelused" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtfuelinword"
										runat="server" Width="70px" CssClass="FontStyle"></asp:textbox></TD>
								<TD>&nbsp;Starting Fuel Qty.
								</TD>
								<TD><asp:textbox id="txtfuelintank" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD colSpan="3"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="5"><b><B><SPAN style="FONT-SIZE: 8pt; FONT-FAMILY: Arial; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Fuel 
												/ Lubricants Uses</SPAN></B></b></TD>
							</TR>
							<TR>
								<TD colSpan="1" rowSpan="1">&nbsp;Engine Oil</TD>
								<TD><asp:dropdownlist id="DropEngineOil" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtEngineQty" runat="server"
										Width="70px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
								<TD>&nbsp;Date
									<asp:textbox id="txtEngineOilDate" runat="server" Width="80px"  CssClass="FontStyle"
										BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtEngineOilDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD vAlign="top">&nbsp;K.M&nbsp;<asp:textbox id="txtEngineKM" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
										Width="100px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;Gear Oil</TD>
								<TD><asp:dropdownlist id="Dropgear" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtgearinword"
										runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
								<TD>&nbsp;Date
									<asp:textbox id="txtgeardt" runat="server" Width="80px"  CssClass="FontStyle"
										BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtgeardt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD vAlign="top">&nbsp;K.M&nbsp;<asp:textbox id="txtgearkm" runat="server" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										Width="100px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;Brake Oil</TD>
								<TD><asp:dropdownlist id="Dropbreak" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtbearkinword"
										runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
								<TD>&nbsp;Date
									<asp:textbox id="txtbreakdt" runat="server" Width="80px"  CssClass="FontStyle"
										BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtbreakdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD>&nbsp;K.M&nbsp;<asp:textbox id="txtbreakkm" runat="server" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										Width="100px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;Coolent</TD>
								<TD><asp:dropdownlist id="Dropcoolent" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtcoolentinword"
										runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
								<TD vAlign="top">&nbsp;Date
									<asp:textbox id="txtcoolentdt" runat="server" Width="80px"  CssClass="FontStyle"
										BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtcoolentdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD vAlign="top">&nbsp;K.M&nbsp;<asp:textbox id="txtcoolentkm" onkeypress="return GetOnlyNumbers(this, event, false,true);" runat="server"
										Width="100px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Grease</TD>
								<TD><asp:dropdownlist id="Dropgrease" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtgreaseinword"
										runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
								<TD>&nbsp;Date
									<asp:textbox id="txtgreasedt" runat="server" Width="80px"  CssClass="FontStyle"
										BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtgreasedt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD>&nbsp;K.M&nbsp;<asp:textbox id="txtgreasekm" runat="server" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										Width="100px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Transmission Oil</TD>
								<TD><asp:dropdownlist id="Droptransmission" runat="server" Width="130px" CssClass="FontStyle"></asp:dropdownlist><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txttransinword"
										runat="server" Width="70px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
								<TD>&nbsp;Date
									<asp:textbox id="txttransmissiondt" runat="server" Width="80px"  CssClass="FontStyle"
										BorderStyle="Groove"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txttransmissiondt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
								<TD>&nbsp;K.M&nbsp;<asp:textbox id="txttransmissionkm" runat="server" onkeypress="return GetOnlyNumbers(this, event, false,true);"
										Width="100px" CssClass="FontStyle" BorderStyle="Groove" MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>&nbsp;Vehicle Average</TD>
								<TD colSpan="3"><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" MaxLength="8" id="txtvechileavarge"
										runat="server" Width="100px" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox><asp:comparevalidator id="Comparevalidator19" ControlToValidate="txtvechileavarge" ErrorMessage="Vechile average must be numeric"
										Display="Dynamic" Runat="server" Enabled="False" Operator="DataTypeCheck">*</asp:comparevalidator></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="5"><asp:button id="btnSave" runat="server" ForeColor="White" Width="70px" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnEdit" runat="server" ForeColor="White" Width="70px" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Edit"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnDelete" runat="server" ForeColor="White" Width="70px" BorderColor="ForestGreen"
										BackColor="ForestGreen" Text="Delete"></asp:button></TD>
							</TR>
							<tr>
								<td colSpan="5"><asp:validationsummary id="vsVehicle" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
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
