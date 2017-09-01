<%@ Page language="c#" Codebehind="AttendenceReport.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.AttendenceReport" %>
<%@ Import namespace="RMG"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePetro: Attendence Report</title> 
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
		<script language="javascript" id="Validations" src="../../Sysitem/Js/Validations.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="278" width="778" align="center">
				<tr vAlign="top" height="20">
					<th colSpan="5">
						<font color="#006400">Attendence Report</font>
						<hr>
					</th>
				</tr>
				<tr>
					<td vAlign="top">
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
								<td align="center"><asp:button id="btnView" Runat="server" Width="70"  Text="View"></asp:button>&nbsp;&nbsp;
									<asp:button id="btnPrint" Runat="server" Width="70"  Text="Print"></asp:button>&nbsp;&nbsp;
									<asp:button id="btnExcel" Runat="server" Width="70"  Text="Excel"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<%if(DropMonth.SelectedIndex!=0 && DropYear.SelectedIndex!=0 && Flag==1){%>
				<tr>
					<td vAlign="top" colSpan="5">
						<table borderColor="darkseagreen" cellSpacing="0" cellPadding="0" width="100%" align="center"
							border="1">
							<tr bgColor="#009900">
								<td align="center"><font color="#ffffff"><b>Employee Name / Day</b></font></td>
								<%
								for(int i=1;i<=Day;i++)
								{
								%>
								<td align="center"><font color="#ffffff"><b><%=i.ToString()%></b></font></td>
								<%}%>
								<td align="center"><font color="#ffffff"><b>Total P</b></font></td>
								<td align="center"><font color="#ffffff"><b>Total A</b></font></td>
							</tr>
							<%
			DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
			string[] arr1 = new string[Day];
			string[] arr2 = new string[Day];
			string FromDate=DropMonth.SelectedIndex+"/1/"+DropYear.SelectedItem.Text;
			string ToDate=DropMonth.SelectedIndex+"/"+Day.ToString()+"/"+DropYear.SelectedItem.Text;
			
			InventoryClass obj = new InventoryClass();
			SqlDataReader rdr,rdr1=null;
			for(int i=0,j=1;i<Day;i++,j++)
			{
				arr1[i]=DropMonth.SelectedIndex+"/"+j+"/"+DropYear.SelectedItem.Text;
				//arr2[i]="A";
			}
			string emp="";
			
			dbobj.SelectQuery("select emp_id,emp_name from employee",ref rdr1);
			while(rdr1.Read())
			{
				for(int i=0,j=1;i<Day;i++,j++)
				{
					//arr1[i]=DropMonth.SelectedIndex+"/"+j+"/"+DropYear.SelectedItem.Text;
					arr2[i]="A";
				}
				int countP=0,countA=0;
				emp=rdr1.GetValue(1).ToString();
				rdr = obj.GetRecordSet("select * from attandance_register where att_date>='"+FromDate+"' and att_date<='"+ToDate+"' and emp_id='"+rdr1.GetValue(0).ToString()+"' and status=1 order by att_date");
				while(rdr.Read())
				{
					for(int i=0;i<arr1.Length;i++)
					{
						//if(rdr.GetValue(0).ToString().Equals(arr1[i].ToString()))
						if(GenUtil.trimDate(rdr.GetValue(0).ToString()).Equals(arr1[i].ToString()))
						{
							arr2[i]="P";
							countP++;
							break;
						}
					}
				}
				rdr.Close();
				countA=Day-countP;
			%>
							<tr>
								<td>&nbsp;<%=emp%></td>
								<%
			for(int i=0;i<arr1.Length;i++)
			{
			%>
								<td align="center" width="15"><%=arr2[i].ToString()%></td>
								<%}	%>
								<td align="center"><%=countP.ToString()%></td>
								<td align="center"><%=countA.ToString()%></td>
							</tr>
							<%}%>
						</table>
					</td>
				</tr>
				<%}%>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/DTPicker/ipopeng.htm" frameBorder="0" width="174"
				scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
