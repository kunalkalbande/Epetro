<%@ Page language="c#" Codebehind="MonthlySellingReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.MonthlySellingReport" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Import namespace="RMG"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro: Monthly Selling Report</title> 
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
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	    <style type="text/css">
            .auto-style1 {
                width: 717px;
            }
        </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="278" width="778" align="center">
				<tr vAlign="top" height="10">
					<th colSpan="5">
						<font color="#006400">Monthly Selling Report</font>
						<hr>
					</th>
				</tr>
				<tr>
					<td valign="top">
						<table width="600" align="center">
							<tr align="center">
								<td align="center">Month</td>
								<td align="center"><asp:dropdownlist id="DropMonth" Runat="server" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="January">January</asp:ListItem>
										<asp:ListItem Value="Fabruary">February</asp:ListItem>
										<asp:ListItem Value="March">March</asp:ListItem>
										<asp:ListItem Value="April">April</asp:ListItem>
										<asp:ListItem Value="May">May</asp:ListItem>
										<asp:ListItem Value="June">June</asp:ListItem>
										<asp:ListItem Value="July">July</asp:ListItem>
										<asp:ListItem Value="August">August</asp:ListItem>
										<asp:ListItem Value="September">September</asp:ListItem>
										<asp:ListItem Value="October">October</asp:ListItem>
										<asp:ListItem Value="November">November</asp:ListItem>
										<asp:ListItem Value="December">December</asp:ListItem>
									</asp:dropdownlist></td>
								<td align="center">Year</td>
								<td align="center"><asp:dropdownlist id="DropYear" Runat="server" CssClass="FontStyle">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="2005">2005</asp:ListItem>
										<asp:ListItem Value="2006">2006</asp:ListItem>
										<asp:ListItem Value="2007">2007</asp:ListItem>
										<asp:ListItem Value="2008">2008</asp:ListItem>
										<asp:ListItem Value="2009">2009</asp:ListItem>
										<asp:ListItem Value="2010">2010</asp:ListItem>
										<asp:ListItem Value="2011">2011</asp:ListItem>
										<asp:ListItem Value="2012">2012</asp:ListItem>
										<asp:ListItem Value="2013">2013</asp:ListItem>
										<asp:ListItem Value="2014">2014</asp:ListItem>
										<asp:ListItem Value="2015">2015</asp:ListItem>
									</asp:dropdownlist></td>
								<td align="center"><asp:button id="btnView" Runat="server" Width="70" ForeColor="White" BorderColor="DarkSeaGreen"
										BackColor="ForestGreen" Text="View"></asp:button>&nbsp;&nbsp;
									<asp:button id="btnPrint" Runat="server" Width="70" ForeColor="White" BorderColor="DarkSeaGreen"
										BackColor="ForestGreen" Text="Print"></asp:button>&nbsp;&nbsp;
									<asp:button id="btnExcel" Runat="server" Width="70" ForeColor="White" BorderColor="DarkSeaGreen"
										BackColor="ForestGreen" Text="Excel"></asp:button></td>
							</tr>
							<%if(DropMonth.SelectedIndex!=0 && DropYear.SelectedIndex!=0){%>
							<tr>
								<td colSpan="5">
									<table borderColor="green" cellSpacing="0" cellPadding="0" align="center" border="1" class="auto-style1">
										<%
										DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
										InventoryClass obj=new InventoryClass();
										SqlDataReader SqlDtr=null,rdr=null;
										int MS=0,SMS=0,HSD=0,SHSD=0,CNG=0,LPG=0,OTHER=0;
										//string ms="",sms="",hsd="",shsd="",cng="",lpg="",other="";
										//string sql="select Prod_ID,Prod_Name from Products";
										//SqlDtr=obj.GetRecordSet(sql);
										%>
										<tr>
											<td align="center" rowspan="2" valign="middle"><B>Date</B></td>
											<%dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref rdr);
											if(rdr.Read()){
											//ms=rdr["Prod_ID"].ToString();%>
											<td align="center"><B>MS(Petrol)</B></td>
											<%MS=1;}
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref rdr);
											if(rdr.Read()){
											//sms=rdr["Prod_ID"].ToString();%>
											<td align="center"><B>Super Petrol</B></td>
											<%SMS=1;}
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Diesel(HSD)%'",ref rdr);
											if(rdr.Read()){
											//hsd=rdr["Prod_ID"].ToString();%>
											<td align="center"><B>HSD(Diesel)</B></td>
											<%HSD=1;}dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref rdr);
											if(rdr.Read()){
											%>
											<td align="center"><B>Super Diesel</B></td>
											<%SHSD=1;}dbobj.SelectQuery("select Prod_ID from Products where Category <> 'Fuel'",ref rdr);
											if(rdr.Read()){
											//other=rdr["Prod_ID"].ToString();%>
											<td align="center"><B>OIL(Lube &amp; Grease)</B></td>
											<%OTHER=1;}
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'CNG%'",ref rdr);
											if(rdr.Read()){
											//cng=rdr["Prod_ID"].ToString();%>
											<td align="center"><B>CNG</B></td>
											<%CNG=1;}
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Auto LPG%'",ref rdr);
											if(rdr.Read()){
											//lpg=rdr["Prod_ID"].ToString();%>
											<td align="center"><B>Auto LPG</B></td>
											<%LPG=1;}%>
										</tr>
										<tr>
											<%if(MS==1){%>
											<td><table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td><B>SELL</B></td>
														<td align="right"><B>LOSS/PLUS</B></td>
													</tr>
												</table>
											</td>
											<%}if(SMS==1){%>
											<td><table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td><B>SELL</B></td>
														<td align="right"><B>LOSS/PLUS</B></td>
													</tr>
												</table>
											</td>
											<%}if(HSD==1){%>
											<td><table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td><B>SELL</B></td>
														<td align="right"><B>LOSS/PLUS</B></td>
													</tr>
												</table>
											</td>
											<%}if(SHSD==1){%>
											<td><table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td><B>SELL</B></td>
														<td align="right"><B>LOSS/PLUS</B></td>
													</tr>
												</table>
											</td>
											<%}if(OTHER==1){%>
											<td><table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td><B>SELL</B></td>
														<td align="right"><B>LOSS/PLUS</B></td>
													</tr>
												</table>
											</td>
											<%}if(CNG==1){%>
											<td><table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td><B>SELL</B></td>
														<td align="right"><B>LOSS/PLUS</B></td>
													</tr>
												</table>
											</td>
											<%}if(LPG==1){%>
											<td><table width="100%" cellpadding="0" cellspacing="0">
													<tr>
														<td><B>SELL</B></td>
														<td align="right"><B>LOSS/PLUS</B></td>
													</tr>
												</table>
											</td>
											<%}%>
										</tr>
										<%
										double TotalMS=0,TotalHSD=0,TotalOil=0,TotalSMS=0,TotalSHSD=0,TotalCNG=0,TotalLPG=0;
										double CalMS=0,CalHSD=0,CalOil,CalSMS=0,CalSHSD=0,CalCNG=0,CalLPG=0;
										for(int i=1;i<date.Length+1;i++)
										{
										string dt = Month.ToString()+"/"+i.ToString()+"/"+DropYear.SelectedItem.Text;
										%>
										<tr>
											<td align="center" width="105"><%=i%>
												-<%=DropMonth.SelectedItem.Text%>
												-<%=DropYear.SelectedItem.Text%></td>
											<%if(MS==1){CalMS=0;
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Petrol(MS)%'",ref SqlDtr);
											while(SqlDtr.Read()){
											dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
											if(rdr.Read()){
											if(rdr.GetValue(0).ToString()!=""){
											CalMS+=double.Parse(rdr.GetValue(0).ToString());
											TotalMS+=double.Parse(rdr.GetValue(0).ToString());}}}
											%>
											<td>&nbsp;&nbsp;<%=CalMS%></td>
											<%}if(SMS==1){CalSMS=0;
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Petrol%'",ref SqlDtr);
											while(SqlDtr.Read()){
											dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
											if(rdr.Read()){
											if(rdr.GetValue(0).ToString()!=""){
											CalSMS+=double.Parse(rdr.GetValue(0).ToString());
											TotalSMS+=double.Parse(rdr.GetValue(0).ToString());}}}
											%>
											<td>&nbsp;&nbsp;<%=CalSMS%></td>
											<%}if(HSD==1){CalHSD=0;
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Diesel(HSD)%'",ref SqlDtr);
											while(SqlDtr.Read()){
											dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
											if(rdr.Read()){
											if(rdr.GetValue(0).ToString()!=""){
											CalHSD+=double.Parse(rdr.GetValue(0).ToString());
											TotalHSD+=double.Parse(rdr.GetValue(0).ToString());}}}
											%>
											<td>&nbsp;&nbsp;<%=CalHSD%></td>
											<%}if(SHSD==1){CalSHSD=0;
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Super Diesel%'",ref SqlDtr);
											while(SqlDtr.Read()){
											dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
											if(rdr.Read()){
											if(rdr.GetValue(0).ToString()!=""){
											CalSHSD+=double.Parse(rdr.GetValue(0).ToString());
											TotalSHSD+=double.Parse(rdr.GetValue(0).ToString());}}}
											%>
											<td>&nbsp;&nbsp;<%=CalSHSD%></td>
											<%}if(OTHER==1){CalOil=0;
											dbobj.SelectQuery("select Prod_ID from Products where Category<>'Fuel'",ref SqlDtr);
											while(SqlDtr.Read()){
											dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
											if(rdr.Read()){
											if(rdr.GetValue(0).ToString()!=""){
											CalOil+=double.Parse(rdr.GetValue(0).ToString());
											TotalOil+=double.Parse(rdr.GetValue(0).ToString());}}}
											%>
											<td>&nbsp;&nbsp;<%=CalOil%><!--%TotalOil+=double.Parse(rdr.GetValue(0).ToString());%--></td>
											<!--%}else%>
											<td>&nbsp;&nbsp;0</td-->
											<%}if(CNG==1){CalCNG=0;
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'CNG%'",ref SqlDtr);
											while(SqlDtr.Read()){
											dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
											if(rdr.Read()){
											if(rdr.GetValue(0).ToString()!=""){
											CalCNG+=double.Parse(rdr.GetValue(0).ToString());
											TotalCNG+=double.Parse(rdr.GetValue(0).ToString());}}}
											%>
											<td>&nbsp;&nbsp;<%=CalCNG%></td>
											<%}if(LPG==1){CalLPG=0;
											dbobj.SelectQuery("select Prod_ID from Products where Prod_Name like 'Auto LPG%'",ref SqlDtr);
											while(SqlDtr.Read()){
											dbobj.SelectQuery("select sum(sd.qty) from sales_Details sd,Sales_Master sm where sd.invoice_no=sm.invoice_no and sd.Prod_id='"+SqlDtr["Prod_ID"].ToString()+"' and cast(floor(cast(cast(sm.invoice_date as datetime) as float)) as datetime)='"+dt+"'",ref rdr);
											if(rdr.Read()){
											if(rdr.GetValue(0).ToString()!=""){
											CalLPG+=double.Parse(rdr.GetValue(0).ToString());
											TotalLPG+=double.Parse(rdr.GetValue(0).ToString());}}}
											%>
											<td>&nbsp;&nbsp;<%=CalLPG%></td>
											<%}%>
										</tr>
										<%}%>
										<tr>
											<td align="center"><B>Total</B></td>
											<%if(MS==1){%>
											<td>&nbsp;&nbsp;<b><%=TotalMS%></b></td>
											<%}if(SMS==1){%>
											<td>&nbsp;&nbsp;<b><%=TotalSMS%></b></td>
											<%}if(HSD==1){%>
											<td>&nbsp;&nbsp;<b><%=TotalHSD%></b></td>
											<%}if(SHSD==1){%>
											<td>&nbsp;&nbsp;<b><%=TotalSHSD%></b></td>
											<%}if(OTHER==1){%>
											<td>&nbsp;&nbsp;<b><%=TotalOil%></b></td>
											<%}if(CNG==1){%>
											<td>&nbsp;&nbsp;<b><%=TotalCNG%></b></td>
											<%}if(LPG==1){%>
											<td>&nbsp;&nbsp;<b><%=TotalLPG%></b></td>
											<%}%>
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
