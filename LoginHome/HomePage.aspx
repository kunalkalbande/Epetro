<%@ Page language="c#" Codebehind="HomePage.aspx.cs" AutoEventWireup="false" smartNavigation="False" %>
<%@ Register TagPrefix="uc1" TagName="Header1" Src="../HeaderFooter/Header1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../HeaderFooter/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePetro : Home Page</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="HomePage" method="post" runat="server">
			<uc1:header1 id="Header11" runat="server"></uc1:header1>
			<TABLE height="265" cellSpacing="0" cellPadding="0" width="1350" align="center">
				<TR>
					<TH align="center" colSpan="12">
						<hr>
						<asp:label id="lblMessaeg" runat="server"></asp:label></TH></TR>
				<TR>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#339933">Administration</FONT></STRONG></TD>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#669933">Shift And Employees</FONT></STRONG></TD>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#339933">Parties</FONT></STRONG></TD>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#339933">Purchase / Sales/ 
								Inventory</FONT></STRONG></TD>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#339933">Report/ MIS</FONT></STRONG></TD>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#339933">Report/ MIS</FONT></STRONG></TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;</TD>
					<TD><asp:hyperlink id="Hyperlink441" runat="server" NavigateUrl="../Module/Admin/OrganisationDetails.aspx">Organization Details</asp:hyperlink></TD>
					<TD>&nbsp;&nbsp;</TD>
					<TD><asp:hyperlink id="HyperLink4" runat="server" NavigateUrl="../Module/Employee/Addtadance_Register.aspx"> Attendance Register</asp:hyperlink></TD>
					<TD>&nbsp;&nbsp;</TD>
					<TD><asp:hyperlink id="Hyperlink25" runat="server" NavigateUrl="../Module/Parties/BeatMaster_Entry.aspx">Beat Entry</asp:hyperlink></TD>
					<TD>&nbsp;</TD>
					<TD><asp:hyperlink id="Hyperlink49" runat="server" NavigateUrl="../Module/Accounts/cashbill.aspx">Cash Billing</asp:hyperlink></TD>
					<TD>&nbsp;&nbsp;</TD>
					<TD><asp:hyperlink id="Hyperlink77" runat="server" NavigateUrl="../Module/Reports/AttendenceReport.aspx">Attendence Report</asp:hyperlink></TD>
					<TD>&nbsp;&nbsp;</TD>
					<TD><asp:hyperlink id="Hyperlink33" runat="server" NavigateUrl="../Module/Reports/MachineReport.aspx"> Machine Report </asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink9" runat="server" NavigateUrl="../Module/Admin/Privileges.aspx" DESIGNTIMEDRAGDROP="194">Privileges</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink2" runat="server" NavigateUrl="../Module/Employee/Employee_Entry.aspx"> Employee Entry </asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink24" runat="server" NavigateUrl="../Module/Parties/Customer_Entry.aspx">Customer Entry</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink20" runat="server" NavigateUrl="../Module/Inventory/Price_Updation.aspx">Price Updation</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink62" runat="server" NavigateUrl="../Module/Reports/BalanceSheet.aspx">Balance Sheet</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink31" runat="server" NavigateUrl="../Module/Reports/MeterReadingReport.aspx">Meter Reading </asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink7" runat="server" NavigateUrl="../Module/Admin/Roles.aspx">Roles</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink3" runat="server" NavigateUrl="../Module/Employee/Employee_List.aspx"> Employee List</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink23" runat="server" NavigateUrl="../Module/Parties/Customer_List.aspx"> Customer List</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink22" runat="server" NavigateUrl="../Module/Inventory/Product_Entry.aspx"> Product Entry</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink70" runat="server" NavigateUrl="../Module/Reports/BankReconcillation.aspx">Bank Reconcillation</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink75" runat="server" NavigateUrl="../Module/Reports/MonthlySellingReport.aspx">Monthly Selling Report</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink8" runat="server" NavigateUrl="../Module/Admin/User_Profile.aspx">User Profile</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink12" runat="server" NavigateUrl="../Module/Employee/Leave_Register.aspx">Leave Application</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink67" runat="server" NavigateUrl="../Module/Parties/CustomerVehicleEntry.aspx">Customer Vehicle Entry</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink18" runat="server" NavigateUrl="../Module/Inventory/PurchaseBill.aspx">  Purchase Invoice</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink71" runat="server" NavigateUrl="../Module/Reports/CashBillingReport.aspx">Cash Sales Report</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink32" runat="server" NavigateUrl="../Module/Reports/NozzleReport.aspx">Nozzle Report </asp:hyperlink></TD>
				</TR>
				<TR>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#339933">Petrol Pump</FONT></STRONG></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink72" runat="server" NavigateUrl="../Module/Reports/LeaveReport.aspx">Leave Report</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink47" runat="server" NavigateUrl="../Module/Parties/Slip_Entry.aspx">Slip Entry</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink58" runat="server" NavigateUrl="../Module/Inventory/PurchaseReturn.aspx">Purchase Return</asp:hyperlink></TD>
					<TD><STRONG><FONT color="#339933"></FONT></STRONG></TD>
					<TD><asp:hyperlink id="Hyperlink16" runat="server" NavigateUrl="../Module/Inventory/Credit_Bill.aspx">Credit Bill</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink37" runat="server" NavigateUrl="../Module/Reports/PriceList.aspx">Price List</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD><STRONG><FONT color="#339933"></FONT></STRONG></TD>
					<TD><asp:hyperlink id="Hyperlink26" runat="server" NavigateUrl="../Module/PetrolPump/DailyOperationEntries.aspx">Daily Operation Entry</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink14" runat="server" NavigateUrl="../Module/Employee/Leave_Assignment.aspx">Leave Sanction</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink10" runat="server" NavigateUrl="../Module/Accounts/Taxentry_Master.aspx">Tax Entry</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink17" runat="server" NavigateUrl="../Module/Inventory/SalesInvoice.aspx">Sales Invoice</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink43" runat="server" NavigateUrl="../Module/Reports/Customer_Bill_Ageing.aspx">Customer Bill Ageing</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink41" runat="server" NavigateUrl="../Module/Reports/ProductWiseSales.aspx">Product Wise Sales</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink28" runat="server" NavigateUrl="../Module/PetrolPump/MachineEntry.aspx"> Machine Entry </asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink5" runat="server" NavigateUrl="../Module/Employee/OT_Register.aspx"> OverTime Register</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink19" runat="server" NavigateUrl="../Module/Parties/Supplier_Entry.aspx">Vendor Entry</asp:hyperlink></TD>
					<td></td>
					<td><asp:hyperlink id="Hyperlink55" runat="server" NavigateUrl="../Module/Inventory/SalesReturn.aspx">Sales Return</asp:hyperlink></td>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink66" runat="server" NavigateUrl="../Module/Reports/CustomerDataMining.aspx">Customer Data Mining</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink11" runat="server" NavigateUrl="../Module/Reports/PurchaseBook.aspx">Purchase Book</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink27" runat="server" NavigateUrl="../Module/PetrolPump/NozzleEntry.aspx"> Nozzle Entry </asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink6" runat="server" NavigateUrl="../Module/Employee/Salary_Statement.aspx">Salary Statement</asp:hyperlink></TD>
					<TD></TD>
					<td><asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="../Module/Parties/Supplier_List.aspx"> Vendor List</asp:hyperlink></td>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink59" runat="server" NavigateUrl="../Module/Inventory/StockAdjustment.aspx">Stock Adjustment</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink74" runat="server" NavigateUrl="../Module/Reports/CreditFleetCardSalesReport.aspx">Credit/Fleet Card Report</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink68" runat="server" NavigateUrl="../Module/Reports/ROI_ANALYSIS.aspx" Width="115px">ROI & Analysis Report</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink30" runat="server" NavigateUrl="../Module/PetrolPump/TankEntry.aspx">Tank Entry </asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink15" runat="server" NavigateUrl="../Module/Employee/Shift_Asignment.aspx">Shift Assignment </asp:hyperlink></TD>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#339933">Logistics</FONT></STRONG></TD>
					<TD colSpan="2"><STRONG><FONT style="COLOR: #006400" color="#339933">Account</FONT></STRONG></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink42" runat="server" NavigateUrl="../Module/Reports/CustomerLedgerSummary.aspx">Customer Ledger Summary</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink35" runat="server" NavigateUrl="../Module/Reports/SaleBook.aspx">Sales Book</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink13" runat="server" NavigateUrl="../Module/Employee/Shift_Entry.aspx"> Shift Entry </asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink56" runat="server" NavigateUrl="../Module/Logistics/routeedit.aspx"> Route Master</asp:hyperlink></TD>
					<TD></TD>
					<td><asp:hyperlink id="Hyperlink40" runat="server" NavigateUrl="../Module/Accounts/Ledger.aspx">Ledger Creation</asp:hyperlink></td>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink76" runat="server" NavigateUrl="../Module/Reports/CustomerVehicleEntryReport.aspx">Customer Vehicle Report</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink36" runat="server" NavigateUrl="../Module/Reports/SlipMasterReport.aspx">Slip Master Report</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink50" runat="server" NavigateUrl="../Module/Logistics/Vehicle_logbook.aspx"> Vehicle Daily Log Book </asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink51" runat="server" NavigateUrl="../Module/Accounts/Payment.aspx"> Payment</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink53" runat="server" NavigateUrl="../Module/Reports/CustomerwiseSalesReport.aspx">Customer Wise Sales</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink63" runat="server" NavigateUrl="../Module/Reports/StockLedgerReport.aspx">Stock Ledger Report</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink57" runat="server" NavigateUrl="../Module/Logistics/Vechile_entryform.aspx"> Vehicle Entry</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink21" runat="server" NavigateUrl="../Module/Inventory/Payment_Receipt.aspx"> Receipt</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink48" runat="server" NavigateUrl="../Module/Reports/CustomerWiseReconsi.aspx">Customer Wise Slip </asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink38" runat="server" NavigateUrl="../Module/Reports/StockMovement.aspx">Stock Movement</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 118px"></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink52" runat="server" NavigateUrl="../Module/Accounts/voucher.aspx">Voucher Entry</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink73" runat="server" NavigateUrl="../Module/Reports/DailySalesCumActSheet.aspx">Daily Sales Cum A/C Sheet</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink39" runat="server" NavigateUrl="../Module/Reports/StockReport.aspx">Stock Report</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink78" runat="server" NavigateUrl="../Module/Reports/DayBookReport.aspx">Day Book Report</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink29" runat="server" NavigateUrl="../Module/Reports/TankDipReport.aspx">Tank Dip Stock Reading</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink69" runat="server" NavigateUrl="../Module/Reports/DensityChart.aspx" Width="115px">Density Chart</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink34" runat="server" NavigateUrl="../Module/Reports/TankReport.aspx">Tank Report </asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink45" runat="server" NavigateUrl="../Module/Reports/Density_Register.aspx">Density Register</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink65" runat="server" NavigateUrl="../Module/Reports/TaxReport.aspx">Tax Report</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink44" runat="server" NavigateUrl="../Module/Reports/DailySalesRecord.aspx">Daily Sales Register</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink61" runat="server" NavigateUrl="../Module/Reports/TradingAccount.aspx">Trading Account</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink46" runat="server" NavigateUrl="../Module/Reports/GovtStockRegister.aspx">Govt. Stock Register</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink54" runat="server" NavigateUrl="../Module/Reports/VAT_Report.aspx">VAT Report</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:hyperlink id="HyperLink64" runat="server" NavigateUrl="../Module/Reports/LedgerReport.aspx">Ledger Report</asp:hyperlink></TD>
					<TD></TD>
					<TD><asp:hyperlink id="Hyperlink60" runat="server" NavigateUrl="../Module/Reports/VehicleLogReport.aspx">Vehicle Report</asp:hyperlink></TD>
				</TR>
                <tr>
                    <td height="180"></td>
                </tr>
			</TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
