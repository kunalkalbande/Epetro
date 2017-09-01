<%@ Import namespace="RMG"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Page language="c#" Codebehind="DailySalesCumActSheet.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.DailySalesReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Daily Sales Report</title> 
		<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="278" width="778" align="center">
				<tr vAlign="top" height="10">
					<th>
						<font face="Verdana" color="#006400">Daily Sales Cum A/C Sheet Report</font>
						<hr>
					</th>
				</tr>
				<tr>
					<td vAlign="top">
						<table width="700" align="center">
							<tr>
								<td align="right" width="10%">From Date</td>
								<td align="center" width="20%"><asp:textbox id="txtDateFrom" runat="server" Width="80px"  BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox>&nbsp;&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></td>
								<td align="center" width="10%">To Date</td>
								<td width="20%"><asp:textbox id="txtDateTo" runat="server" Width="80px"  BorderStyle="Groove"
										CssClass="FontStyle"></asp:textbox>&nbsp;&nbsp;<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.all.txtDateTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/DTPicker/calendar_icon.gif" align="absMiddle"
											border="0"></A></td>
								<td align="center" colSpan="2" width="40%"><asp:button id="btnView" Width="55" Text="View" Runat="server" ></asp:button>&nbsp;&nbsp;
                                    <asp:button id="btnSave" Width="55" Text="Save" Runat="server" ></asp:button>&nbsp;&nbsp;
                                    <asp:button id="btnPrint" Width="55" Text="Print" Runat="server" ></asp:button>&nbsp;&nbsp;
                                    <asp:button id="btnExcel" Width="55" Text="Excel" Runat="server" ></asp:button></td>
							</tr>
							<%if(Flag==1)
							{%>
							<tr>
								<td colSpan="6">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td colSpan="2">&nbsp;</td>
											<td>CHEQUE NUMBER</td>
											<td>AMOUNT(RS.)</td>
											<td colSpan="2">BANK NAME</td>
										</tr>
										<!--tr>
											<td colSpan="2"><STRONG>FUEL SUPPLIER CHEQUE(UNDER CLEARING) :</STRONG>&nbsp;</td>
											<td></td>
											<td></td>
											<td colSpan="2"></td>
										</tr-->
										<tr>
											<td colSpan="2"><STRONG>FUEL SUPPLIER CHEQUE(UNDER CLEARING) :</STRONG>&nbsp;</td>
											<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtChkNo1" Width="80"
													Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
											<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmt1" Width="80"
													Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
											<td colSpan="2"><asp:textbox id="txtBank1" Width="150" Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
										</tr>
										<tr>
											<td colSpan="2">&nbsp;</td>
											<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtChkNo2" Width="80"
													Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
											<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmt2" Width="80"
													Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
											<td colSpan="2"><asp:textbox id="txtBank2" Width="150" Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
										</tr>
										<tr>
											<td colSpan="2">&nbsp;</td>
											<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,false);" id="txtChkNo3" Width="80"
													Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
											<td><asp:textbox onkeypress="return GetOnlyNumbers(this, event, false,true);" id="txtAmt3" Width="80"
													Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
											<td colSpan="2"><asp:textbox id="txtBank3" Width="150" Runat="server" CssClass="FontStyle" BorderStyle="Groove"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>CASH ON HAND (Evening / Day Close)&nbsp; :</STRONG>&nbsp;&nbsp;&nbsp;
									<%
								DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
								InventoryClass obj=new InventoryClass();
								SqlDataReader SqlDtr=null,rdr=null,rdr1=null,rdr2=null,rdr3=null;
								string sql="Select Ledger_ID from Ledger_Master where Sub_grp_id=118";
								SqlDtr=obj.GetRecordSet(sql);
								if(SqlDtr.Read())
								{
									dbobj.SelectQuery("Select top 1 Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = '"+SqlDtr["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by Entry_Date desc",ref rdr);
									if(rdr.Read())
									{
							%>
									<font color="#990000">
										<%=GenUtil.strNumericFormat(rdr["Balance"].ToString())%>
										&nbsp;<%=rdr["Bal_Type"].ToString()%></font></td>
								<%}else%>
								<td colSpan="4"></td>
								<%}SqlDtr.Close();%>
							</tr>
							<tr>
								<td colSpan="6">
									<table borderColor="#336633" cellSpacing="0" cellPadding="2" rules="groups" width="100%">
										<tr>
											<td width="200"><B>STOCK MOVEMENT</B></td>
											<td width="100"><B>MS</B></td>
											<td width="100"><B>HSD</B></td>
											<td width="100"><B>Super Petrol</B></td>
											<td width="100"><B>Super Diesel</B></td>
											<td width="100"><B>OIL(IN S-R)</B></td>
											<td width="100"><B>OIL (IN GODW.)</B></td>
										</tr>
										<tr>
											<td>OPENING STOCK :</td>
											<%
											double OPMS=0,OPHSD=0,OPSMS=0,OPSHSD=0,OPSROil=0,OPGDOil=0;
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name LIKE 'Petrol(ms)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Opening_Stock"].ToString()!="")
												OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
												}else{
												dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
												if(rdr.Read()){
												if(rdr["Opening_Stock"].ToString()!="")
												OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
												}}}
										%>
											<td><%=GenUtil.strNumericFormat(OPMS.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Opening_Stock"].ToString()!="")
												OPHSD+=double.Parse(rdr["Opening_Stock"].ToString());
												}else{
												dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
												if(rdr.Read()){
												if(rdr["Opening_Stock"].ToString()!="")
												OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
												}}}
										%>
											<td><%=GenUtil.strNumericFormat(OPHSD.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Opening_Stock"].ToString()!="")
												OPSMS+=double.Parse(rdr["Opening_Stock"].ToString());
												}else{
												dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
												if(rdr.Read()){
												if(rdr["Opening_Stock"].ToString()!="")
												OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
												}}}
										%>
											<td><%=GenUtil.strNumericFormat(OPSMS.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 * from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Opening_Stock"].ToString()!="")
												//if(rdr["receipt"].ToString().Equals("0") && rdr["sales"].ToString().Equals("0"))
												OPSHSD+=double.Parse(rdr["Closing_Stock"].ToString());
												}else{
												dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
												if(rdr.Read()){
												if(rdr["Opening_Stock"].ToString()!="")
												OPMS+=double.Parse(rdr["Opening_Stock"].ToString());
												}}}
												
										%>
											<td><%=GenUtil.strNumericFormat(OPSHSD.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read())
												{
													if(rdr["Opening_Stock"].ToString()!="")
													{
														if(SqlDtr["store_in"].ToString()=="Sales Room")
														{
															OPSROil+=double.Parse(rdr["Opening_Stock"].ToString());
														}
														else if(SqlDtr["store_in"].ToString()=="Godown")
														{
															OPGDOil+=double.Parse(rdr["Opening_Stock"].ToString());
														}
													}
												}
												else
												{
													dbobj.SelectQuery("Select top 1 Opening_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by stock_date",ref rdr);
													if(rdr.Read())
													{
														if(rdr["Opening_Stock"].ToString()!="")
														{
															if(SqlDtr["store_in"].ToString()=="Sales Room")
															{
																OPSROil+=double.Parse(rdr["Opening_Stock"].ToString());
															}
															else if(SqlDtr["store_in"].ToString()=="Godown")
															{
																OPGDOil+=double.Parse(rdr["Opening_Stock"].ToString());
															}
														}
													}
												}
											}
										%>
											<td><%=GenUtil.strNumericFormat(OPSROil.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(OPGDOil.ToString())%></td>
										</tr>
										<tr>
											<td>SELL :</td>
											<%
											double SalMS=0,SalHSD=0,SalSMS=0,SalSHSD=0,SalSROther=0,SalGDOther=0;
											double PurMS=0,PurHSD=0,PurSMS=0,PurSHSD=0,PurSROther=0,PurGDOther=0;
											double CLMS=0,CLHSD=0,CLSMS=0,CLSHSD=0,CLSROil=0,CLGDOil=0;
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["sales"].ToString()!=""){
												SalMS+=double.Parse(rdr["sales"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(SalMS.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["sales"].ToString()!=""){
												SalHSD+=double.Parse(rdr["sales"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(SalHSD.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["sales"].ToString()!=""){
												SalSMS+=double.Parse(rdr["sales"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(SalSMS.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["sales"].ToString()!=""){
												SalSHSD+=double.Parse(rdr["sales"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(SalSHSD.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(sales) sales from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["sales"].ToString()!=""){
												if(SqlDtr["store_in"].ToString()=="Sales Room"){
												SalSROther+=double.Parse(rdr["sales"].ToString());}
												else if(SqlDtr["store_in"].ToString()=="Godown"){
												SalGDOther+=double.Parse(rdr["sales"].ToString());}}}}
										%>
											<td><%=GenUtil.strNumericFormat(SalSROther.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(SalGDOther.ToString())%></td>
										</tr>
										<tr>
											<td>PURCHASE :</td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(ms)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["receipt"].ToString()!=""){
												PurMS+=double.Parse(rdr["receipt"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(PurMS.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["receipt"].ToString()!=""){
												PurHSD+=double.Parse(rdr["receipt"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(PurHSD.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["receipt"].ToString()!=""){
												PurSMS+=double.Parse(rdr["receipt"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(PurSMS.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["receipt"].ToString()!=""){
												PurSHSD+=double.Parse(rdr["receipt"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(PurSHSD.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select sum(receipt) receipt from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr["receipt"].ToString()!=""){
												if(SqlDtr["store_in"].ToString()=="Sales Room"){
												PurSROther+=double.Parse(rdr["receipt"].ToString());}
												else if(SqlDtr["store_in"].ToString()=="Godown"){
												PurGDOther+=double.Parse(rdr["receipt"].ToString());}}}}
										%>
											<td><%=GenUtil.strNumericFormat(PurSROther.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(PurGDOther.ToString())%></td>
										</tr>
										<tr>
											<td>CLOSING STOCK :</td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Petrol(ms)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Closing_Stock"].ToString()!=""){
												CLMS+=double.Parse(rdr["Closing_Stock"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(CLMS.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Diesel(hsd)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Closing_Stock"].ToString()!=""){
												CLHSD+=double.Parse(rdr["Closing_Stock"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(CLHSD.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Closing_Stock"].ToString()!=""){
												CLSMS+=double.Parse(rdr["Closing_Stock"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(CLSMS.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Closing_Stock"].ToString()!=""){
												CLSHSD+=double.Parse(rdr["Closing_Stock"].ToString());}}}
										%>
											<td><%=GenUtil.strNumericFormat(CLSHSD.ToString())%></td>
											<%
											dbobj.SelectQuery("Select Prod_ID,store_in from Products where Category<>'Fuel'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("Select top 1 Closing_Stock from Stock_Master where ProductID = '"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(stock_date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' order by stock_date desc",ref rdr);
												if(rdr.Read()){
												if(rdr["Closing_Stock"].ToString()!=""){
												if(SqlDtr["store_in"].ToString()=="Sales Room"){
												CLSROil+=double.Parse(rdr["Closing_Stock"].ToString());}
												else if(SqlDtr["store_in"].ToString()=="Godown"){
												CLGDOil+=double.Parse(rdr["Closing_Stock"].ToString());}}}}
										%>
											<td><%=GenUtil.strNumericFormat(CLSROil.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(CLGDOil.ToString())%></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="6"><B>&nbsp;&nbsp;CASH FLOW MANAGEMENT</B></td>
							</tr>
							<tr>
								<td colSpan="6">
									<table borderColor="#336633" cellSpacing="0" cellPadding="2" rules="groups" width="100%"
										border="1">
										<tr>
											<TD colSpan="3"><font color=#990033><B>INCOME (CASH RECEIVED)</B></font></TD>
											<td colSpan="3"><font color=#990033><b>EXPENSES</b></font></td>
										</tr>
										<tr>
											<td><b>PARTICULARS</b></td>
											<td><b>SELL</b></td>
											<td><b>RS.</b></td>
											<td colSpan="2"><b>PARTICULARS</b></td>
											<td><b>RS.</b></td>
										</tr>
										<tr>
											<td>MS</td>
											<%
											double CalMS=0,CalHSD=0,CalSMS=0,CalSHSD=0,CalOil=0,CalOther=0;
											double AmtMS=0,AmtHSD=0,AmtSMS=0,AmtSHSD=0,AmtOil=0,AmtOther=0;
											double TotalSell=0,TotalRS=0,TotalPRS=0;
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Petrol(ms)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr.GetValue(0).ToString()!=""){
												CalMS+=double.Parse(rdr.GetValue(0).ToString());
												AmtMS+=double.Parse(rdr.GetValue(1).ToString());
												TotalSell+=double.Parse(rdr.GetValue(0).ToString());
												TotalRS+=double.Parse(rdr.GetValue(1).ToString());}}}
											%>
											<td><%=GenUtil.strNumericFormat(CalMS.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(AmtMS.ToString())%></td>
											<td vAlign="top" colSpan="3" rowSpan="6">
												<table cellSpacing="0" cellPadding="1" width="100%" border="0">
													<%
											string BalType=" Cr";
											//dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp lm,mgroup mg where Sub_grp_Name like 'Indirect%' or Sub_grp_Name like 'Direct%'",ref rdr1);
											//dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where (grp_id=21 or grp_id=22 or grp_id=23 or grp_id=24 or grp_id=25 or grp_id=26)",ref rdr1);
											dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where (grp_id=24 or grp_id=25 or grp_id=26) or (Sub_grp_ID=117 or Sub_grp_ID=126 or Sub_grp_ID=127)",ref rdr1);
											while(rdr1.Read())
											{
											dbobj.SelectQuery("Select Ledger_ID,Ledger_Name from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr2);
												while(rdr2.Read())
												{
													dbobj.SelectQuery("Select sum(Credit_Amount-Debit_Amount) Amount from AccountsLedgerTable where Ledger_ID='"+rdr2["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr3);
													if(rdr3.Read())
													{
													if(rdr3["Amount"].ToString()!="")
													{
													if(double.Parse(rdr3["Amount"].ToString())>0)
															BalType=" Cr";
														else
															BalType=" Dr";
											%>
													<tr>
														<td width="55%"><%=rdr2["Ledger_Name"].ToString()%></td>
														<td width="45%"><%=GenUtil.strNumericFormat(Math.Abs(double.Parse(rdr3["Amount"].ToString())).ToString())%><%=BalType%><%if(rdr3["Amount"].ToString()!="")TotalPRS+=Math.Abs(double.Parse(rdr3["Amount"].ToString()));%></td>
													</tr>
													<%}
													else
													{
													//dbobj.SelectQuery("Select abs(sum(Debit_Amount-Credit_Amount)) Amount from AccountsLedgerTable where Ledger_ID='"+rdr2["Ledger_ID"].ToString()+"'",ref rdr3);
													//if(rdr3.Read())
													//{
													%>
													<tr>
														<td width="60%"><%=rdr2["Ledger_Name"].ToString()%></td>
														<!--td width="40%"><%=rdr3["Amount"].ToString()%><%if(rdr3["Amount"].ToString()!="")TotalPRS+=double.Parse(rdr3["Amount"].ToString());%></td-->
														<td width="40%">0<%=BalType%><%TotalPRS+=0;%></td>
													</tr>
													<%
													//}
													}
													}}}
											dbobj.SelectQuery("Select sum(Debit_Amount) Amount from AccountsLedgerTable where Particulars like 'Contra%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr2);
											if(rdr2.Read())
											{
											if(rdr2["Amount"].ToString()!=""){
											%>
													<tr>
														<td width="60%">Contra</td>
														<td width="40%"><%=GenUtil.strNumericFormat(rdr2["Amount"].ToString())%><%if(rdr2["Amount"].ToString()!="")TotalPRS+=double.Parse(rdr2["Amount"].ToString());%></td>
													</tr>
													<%}}%>
													<%
											/*
											dbobj.SelectQuery("select * from ledger_master_sub_grp where sub_grp_name like 'bank%'and (grp_id=17 or grp_id=13)",ref rdr1); 
											while(rdr1.Read())
											{
												dbobj.SelectQuery("Select * from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr3);
												if(rdr3.Read())
												{
													dbobj.SelectQuery("Select sum(Debit_Amount) Debit_Amount from AccountsLedgerTable where Ledger_ID = '"+rdr3["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr2);
													if(rdr2.Read())
													{
											%>
													<tr>
														<td width="60%"><%=rdr3["Ledger_Name"].ToString()%></td>
														<td width="40%"><%=GenUtil.strNumericFormat(rdr2["Debit_Amount"].ToString())%><%if(rdr2["Debit_Amount"].ToString()!="")TotalPRS+=double.Parse(rdr2["Debit_Amount"].ToString());%></td>
													</tr>
													<%
											}}}*/
											%>
												</table>
											</td>
										</tr>
										<tr>
											<td>HSD</td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Diesel(hsd)%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr.GetValue(0).ToString()!=""){
												CalHSD+=double.Parse(rdr.GetValue(0).ToString());
												TotalSell+=double.Parse(rdr.GetValue(0).ToString());
												TotalRS+=double.Parse(rdr.GetValue(1).ToString());
												AmtHSD+=double.Parse(rdr.GetValue(1).ToString());}}}
											%>
											<td><%=GenUtil.strNumericFormat(CalHSD.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(AmtHSD.ToString())%></td>
										</tr>
										<tr>
											<td>Super Petrol</td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Super Petrol%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr.GetValue(0).ToString()!=""){
												CalSMS+=double.Parse(rdr.GetValue(0).ToString());
												TotalSell+=double.Parse(rdr.GetValue(0).ToString());
												TotalRS+=double.Parse(rdr.GetValue(1).ToString());
												AmtSMS+=double.Parse(rdr.GetValue(1).ToString());}}}
											%>
											<td><%=GenUtil.strNumericFormat(CalSMS.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(AmtSMS.ToString())%></td>
										</tr>
										<tr>
											<td>Super Diesel</td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Prod_name like 'Super Diesel%'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr.GetValue(0).ToString()!=""){
												CalSHSD+=double.Parse(rdr.GetValue(0).ToString());
												TotalSell+=double.Parse(rdr.GetValue(0).ToString());
												TotalRS+=double.Parse(rdr.GetValue(1).ToString());
												AmtSHSD+=double.Parse(rdr.GetValue(1).ToString());}}}
											%>
											<td><%=GenUtil.strNumericFormat(CalSHSD.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(AmtSHSD.ToString())%></td>
										</tr>
										<tr>
											<td>OIL</td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Category <> 'Fuel' and store_in<>'Other'",ref SqlDtr);
											while(SqlDtr.Read())
											{
												dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr.GetValue(0).ToString()!=""){
												CalOil+=double.Parse(rdr.GetValue(0).ToString());
												TotalSell+=double.Parse(rdr.GetValue(0).ToString());
												TotalRS+=double.Parse(rdr.GetValue(1).ToString());
												AmtOil+=double.Parse(rdr.GetValue(1).ToString());}}}
											%>
											<td><%=GenUtil.strNumericFormat(CalOil.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(AmtOil.ToString())%></td>
										</tr>
										<tr>
											<td>OTHERS</td>
											<%
											dbobj.SelectQuery("Select Prod_ID from Products where Category <> 'Fuel' and store_in='Other'",ref SqlDtr);
											if(SqlDtr.Read())
											{
												dbobj.SelectQuery("select sum(ps.Qty),sum(ps.NetAmount) from productsales ps,sales_master sm where Prod_ID='"+SqlDtr["Prod_ID"].ToString()+"' and sm.invoice_no=ps.invoice_no and cast(floor(cast(sm.Invoice_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(sm.Invoice_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr);
												if(rdr.Read()){
												if(rdr.GetValue(0).ToString()!=""){
												CalOther+=double.Parse(rdr.GetValue(0).ToString());
												TotalSell+=double.Parse(rdr.GetValue(0).ToString());
												TotalRS+=double.Parse(rdr.GetValue(1).ToString());
												AmtOther+=double.Parse(rdr.GetValue(1).ToString());}}}
											%>
											<td><%=GenUtil.strNumericFormat(CalOther.ToString())%></td>
											<td><%=GenUtil.strNumericFormat(AmtOther.ToString())%></td>
										</tr>
										<%
										dbobj.SelectQuery("Select Sub_grp_ID from Ledger_Master_Sub_Grp where (grp_id=21 or grp_id=22 or grp_id=23)",ref rdr1);
										//string BalType=" Cr";
											while(rdr1.Read())
											{
											dbobj.SelectQuery("Select Ledger_ID,Ledger_Name from Ledger_Master where Sub_grp_ID='"+rdr1["Sub_grp_ID"].ToString()+"'",ref rdr2);
												while(rdr2.Read())
												{
													dbobj.SelectQuery("Select sum(Credit_Amount-Debit_Amount) Amount from AccountsLedgerTable where Ledger_ID='"+rdr2["Ledger_ID"].ToString()+"' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'",ref rdr3);
													if(rdr3.Read())
													{
													if(rdr3["Amount"].ToString()!="")
													{
														if(double.Parse(rdr3["Amount"].ToString())>0)
															BalType=" Cr";
														else
															BalType=" Dr";
											%>
										<tr>
											<td colspan="2"><%=rdr2["Ledger_Name"].ToString()%></td>
											<td><%=GenUtil.strNumericFormat(Math.Abs(double.Parse(rdr3["Amount"].ToString())).ToString())%><%=BalType%><%if(rdr3["Amount"].ToString()!="")TotalRS+=Math.Abs(double.Parse(rdr3["Amount"].ToString()));%></td>
										</tr>
										<%}
													else
													{
													//dbobj.SelectQuery("Select abs(sum(Debit_Amount-Credit_Amount)) Amount from AccountsLedgerTable where Ledger_ID='"+rdr2["Ledger_ID"].ToString()+"'",ref rdr3);
													//if(rdr3.Read())
													//{
													%>
										<tr>
											<td colspan="2"><%=rdr2["Ledger_Name"].ToString()%></td>
											<td>0<%=BalType%><%TotalRS+=0;%></td>
										</tr>
										<%
													//}
													}
													}}}%>
										<tr>
											<td colSpan="6">
												<hr color="#000000" SIZE="1">
											</td>
										</tr>
										<tr>
											<td vAlign="middle"><b>TOTAL</b></td>
											<td vAlign="middle"><b><%=GenUtil.strNumericFormat(TotalSell.ToString())%></b></td>
											<td vAlign="middle"><b><%=GenUtil.strNumericFormat(TotalRS.ToString())	%></b></td>
											<td colSpan="2"></td>
											<td vAlign="middle"><b><%--<%if(TotalPRS!=0)%><%=GenUtil.strNumericFormat(TotalPRS.ToString())%>--%></b></td>
										</tr>
									</table>
								</td>
							</tr>
							<%}%>
						</table>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
