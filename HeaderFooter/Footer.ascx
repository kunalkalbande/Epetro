<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Footer.ascx.cs" Inherits="EPetro.HeaderFooter.Footer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<HTML>
	<HEAD>
		<TITLE>Welcome to epetro - Petro and Gas Station Management System</TITLE>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=iso-8859-1">
		<LINK href="../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY BGCOLOR="#ffffff" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<TABLE WIDTH="1350" BORDER="0" CELLPADDING="0" CELLSPACING="0" align="center">
			<TR>
				<TD background="/EPetro/HeaderFooter/images/Menu_07.gif" WIDTH="1350" HEIGHT="2"></TD>
			</TR>
			<TR>
				<TD background="/EPetro/HeaderFooter/images/Menu_08.gif" WIDTH="1350" HEIGHT="28">
					<table width="1350" cellspacing="0" border="0" cellpadding="0">
						<tr>
							<td width="150">
								<p align="center"><a href="/epetro/Module/Inventory/SalesInvoice.aspx"><font color="#ffffff">Sales 
											Bill</font></a></p>
							</td>
							<td width="145">
								<p align="center"><a href="/epetro/Module/Inventory/PurchaseBill.aspx"><font color="#ffffff">Purchase 
											Bill</font></a></p>
							</td>
							<td width="144">
								<p align="center"><a href="/epetro/Module/Inventory/Credit_Bill.aspx"><font color="#ffffff">Credit 
											Bill</font></a></p>
							</td>
							<td width="151">
								<p align="center"><a href="/epetro/Module/Inventory/Payment_Receipt.aspx"><font color="#ffffff">Receipt</font></a></p>
							</td>
							<td width="158">
								<p align="center"><a href="/epetro/Module/PetrolPump/DailyOperationEntries.aspx"><font color="#ffffff">Daily 
											Operation Entries</font></a></p>
							</td>
						</tr>
					</table>
				</TD>
			</TR>
			<TR>
				<TD colSpan="20"> <IMG img src="<%= Page.ResolveUrl("~/HeaderFooter/images/ePetro_Footer.png")%>" width="1350" height="50">
					</TD>
			</TR>
		</TABLE>
	</BODY>
</HTML>
