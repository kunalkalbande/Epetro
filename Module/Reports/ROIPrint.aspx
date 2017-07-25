<%@ Page language="c#" Codebehind="ROIPrint.aspx.cs" AutoEventWireup="false" Inherits="EPetro.ROIPrint" %>
<%@ Import namespace="System.Data.SqlClient"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ROI_ANALYSIS.aspx</title> <!--
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
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<h5 align="center"><font color="#006400">Retail Outlet Inspection and Analysis Report</font></h5>
			<table id="Table10" cellSpacing="2" cellPadding="0" width="100%" align="center" border="0"
				runat="server">
				<tr>
					<td>
						<table id="Table11" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td colSpan="8" height="20">&nbsp;<STRONG> Note : Annexure I to be filled by sales 
										Officer once a Year.No copy to be kept in the RO. </STRONG>
								</td>
							</tr>
							<tr>
								<td vAlign="top" colSpan="4">&nbsp; <STRONG>Dealer's Name and Address</STRONG>
									<br>
									&nbsp;&nbsp;&nbsp;&nbsp;<%=DLnameaddr%>
								</td>
								<td colSpan="2" vAlign="top">
									<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="2" cellPadding="0"
										width="100%" border="1">
										<TR>
											<TD align="center" colSpan="2"><STRONG>Type Of Station</STRONG></TD>
										</TR>
										<TR>
											<TD>&nbsp; <STRONG>A Site</STRONG></TD>
											<TD>&nbsp;<%=asite%></TD>
										</TR>
										<TR>
											<TD>&nbsp;<STRONG> B Site</STRONG></TD>
											<TD>&nbsp;<%=bsite%></TD>
										</TR>
										<TR>
											<TD>&nbsp;<STRONG> COCO</STRONG></TD>
											<TD>&nbsp;<%=coco%></TD>
										</TR>
									</table>
								</td>
								<td colSpan="2" height="84" vAlign="top">
									<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="2" cellPadding="0"
										width="100%" border="1">
										<tr>
											<td align="center" colSpan="2"><STRONG>Category</STRONG></td>
										</tr>
										<tr>
											<td style="HEIGHT: 21px"><STRONG>&nbsp; SS</STRONG></td>
											<td style="HEIGHT: 21px">&nbsp;<%=catss%></td>
										</tr>
										<tr>
											<td>&nbsp; <STRONG>FS</STRONG></td>
											<td>&nbsp;<%=catfs%></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; <STRONG>Dealership structure</STRONG></td>
								<td colSpan="2" height="19">&nbsp; <STRONG>Partnership</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;<%=partship%>
								</td>
								<td colSpan="2" height="19">&nbsp; <STRONG>Proprietorship&nbsp;<%=proship%></STRONG>
								</td>
								<td colSpan="2" height="19">&nbsp; <STRONG>Others</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;<%=other%>
								</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp;<STRONG> Divisional Office<br>
									</STRONG>&nbsp;&nbsp;<%=DivisionOff%>
								</td>
								<td colSpan="2" height="19">&nbsp; <STRONG>District<br>
									</STRONG>&nbsp;<%=District%>
								</td>
								<td colSpan="2" height="19"><STRONG>&nbsp; Date of previous visit</STRONG></td>
								<td colSpan="2" height="19">&nbsp;<%=Date%>
								</td>
							</tr>
							<tr>
								<td colSpan="2" height="19">
									<P>&nbsp;&nbsp; <STRONG>SALES&nbsp;&nbsp; PERFORMANCE</STRONG></P>
								</td>
								<td colSpan="3" height="19">&nbsp; <STRONG>Month(MM_YY)</STRONG> &nbsp;<%=SalesPerformanceDate%></td>
								<td colSpan="3" height="19">&nbsp; <STRONG>Cumulative upto</STRONG>&nbsp;&nbsp;<%=CummulativeuptoDate%></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp;</td>
								<td align="center" height="19"><STRONG>Target</STRONG></td>
								<td align="center" height="19"><STRONG>C/Year</STRONG></td>
								<td align="center" height="19"><STRONG>L/Year</STRONG></td>
								<td align="center" height="19"><STRONG>Target</STRONG></td>
								<td align="center" height="19"><STRONG>C/Year</STRONG></td>
								<td align="center" height="19"><STRONG>L/Year</STRONG></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; <STRONG>MS</STRONG></td>
								<td height="19">&nbsp;<%=MSTarget1%></td>
								<td height="19">&nbsp;<%=MScyear1%></td>
								<td height="19">&nbsp;<%=MSLyear1%></td>
								<td height="19">&nbsp;<%=MSTarget2 %></td>
								<td height="19">&nbsp;<%=MSCyear2%></td>
								<td height="19">&nbsp;<%=MSLyear2%></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; <STRONG>HSD</STRONG></td>
								<td height="19">&nbsp;<%=HSDTarget1%></td>
								<td height="19">&nbsp;<%=HSDCYear1%></td>
								<td height="19">&nbsp;<%=HSDLYear1%></td>
								<td height="19">&nbsp;<%=HSDTarget2 %></td>
								<td height="19">&nbsp;<%=HSDCYear2%></td>
								<td height="19">&nbsp;<%=HSDLYear2%></td>
							</tr>
							<tr>
								<td style="HEIGHT: 13px" colSpan="2" height="13">&nbsp; <STRONG>Lubes</STRONG></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=LubesTarget1%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=LubesCYear1%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=LubesLYear1%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=LubesTarget2 %></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=LubesCYear2%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=LubesLYear2%></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; <STRONG>Grease</STRONG></td>
								<td height="19">&nbsp;<%=GreaseTarget1%></td>
								<td height="19">&nbsp;<%=GreaseCYear1%></td>
								<td height="19">&nbsp;<%=GreaseLYear1%></td>
								<td height="19">&nbsp;<%=GreaseTarget2 %></td>
								<td height="19">&nbsp;<%=GreaseCYear2%></td>
								<td height="19">&nbsp;<%=GreaseLYear2%></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>LF Ratio</STRONG></td>
								<td height="19">&nbsp;<%=LFratioTarget1%></td>
								<td height="19">&nbsp;<%=LFratioCYear1%></td>
								<td height="19">&nbsp;<%=LFratioLYear1%></td>
								<td height="19">&nbsp;<%=LFratioTarget2 %></td>
								<td height="19">&nbsp;<%=LFratioCYear2%></td>
								<td height="19">&nbsp;<%=LFratioLyear2%></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; <STRONG>2.Trading Area&nbsp;&nbsp;&nbsp; Analysis</STRONG></td>
								<td align="center" colSpan="2" height="19"><STRONG>No. of ROs</STRONG></td>
								<td align="center" colSpan="2" height="19"><STRONG>Trading Area Potential</STRONG></td>
								<td align="center" colSpan="2" height="19"><STRONG>Trading Area Average<br>
										(Kl/Month)</STRONG></td>
							</tr>
							<tr>
								<td colSpan="2" height="18" style="HEIGHT: 18px">&nbsp;</td>
								<td align="center" height="18" style="HEIGHT: 18px"><STRONG>MS</STRONG></td>
								<td align="center" height="18" style="HEIGHT: 18px"><STRONG>HSD</STRONG></td>
								<td align="center" height="18" style="HEIGHT: 18px"><STRONG>MS</STRONG></td>
								<td align="center" height="18" style="HEIGHT: 18px"><STRONG>HSD</STRONG></td>
								<td align="center" height="18" style="HEIGHT: 18px"><STRONG>MS</STRONG></td>
								<td align="center" height="18" style="HEIGHT: 18px"><STRONG>HSD</STRONG></td>
							</tr>
							<tr>
								<td colSpan="2" height="15" style="HEIGHT: 15px">&nbsp; <STRONG>IOC</STRONG></td>
								<td height="15" style="HEIGHT: 15px">&nbsp;<%=IOCMS1%></td>
								<td height="15" style="HEIGHT: 15px">&nbsp;<%=IOCHSD1%></td>
								<td height="15" style="HEIGHT: 15px">&nbsp;<%=IOCMS2%></td>
								<td height="15" style="HEIGHT: 15px">&nbsp;<%=IOCHSD2%></td>
								<td height="15" style="HEIGHT: 15px">&nbsp;<%=IOCMS3%></td>
								<td height="15" style="HEIGHT: 15px">&nbsp;<%=IOCHSD3%></td>
							</tr>
							<tr>
								<td colSpan="2" height="13" style="HEIGHT: 13px">&nbsp; <STRONG>OMC</STRONG></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=OMCMS1%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=OMCHSD1%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=OMCMS2%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=OMCHSD2%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=OMCMS3%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=OMCHSD3%></td>
							</tr>
							<tr>
								<td colSpan="2" height="13" style="HEIGHT: 13px">&nbsp; <STRONG>TOTAL</STRONG></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=TOTALMS1%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=TOTALHSD1%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=TOTALMS2%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=TOTALHSD2%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=TOTALMS3%></td>
								<td height="13" style="HEIGHT: 13px">&nbsp;<%=TOTALHSD3%></td>
							</tr>
							<tr>
								<td colSpan="4" height="16" style="HEIGHT: 16px">&nbsp;</td>
								<td align="center" colSpan="2" height="16" style="HEIGHT: 16px"><STRONG>MS</STRONG></td>
								<td align="center" colSpan="2" height="16" style="HEIGHT: 16px"><STRONG>HSD</STRONG></td>
							</tr>
							<tr>
								<td colSpan="4" height="19"><font size="2">&nbsp;<STRONG> Reasons for lower/higher Than 
											Trading Area Average</STRONG></font></td>
								<td colSpan="2" height="19">&nbsp;<%=ReasonLH_taAvgMS%></td>
								<td colSpan="2" height="19">&nbsp;<%=ReasonLH_taAvgHSD%></td>
							</tr>
							<tr>
								<td align="center" colSpan="6" height="19">&nbsp;<b>3. Any New ROs coming up in the 
										Trading Area</b></td>
								<td height="19">&nbsp;<%=newro%></td>
								<td height="19">&nbsp;</td>
							</tr>
							<tr>
								<td align="center" colSpan="4" height="19"><STRONG>&nbsp;Name Of the Oil Co.</STRONG></td>
								<td align="center" colSpan="4" height="19">&nbsp;<STRONG>Exp. Date Of Commissioning</STRONG></td>
							</tr>
							<tr>
								<td align="center" height="19"><STRONG>a</STRONG></td>
								<td colSpan="4" height="19">&nbsp;<%=a3%></td>
								<td colSpan="3" height="19">&nbsp;<%=a3datepk%></td>
							</tr>
							<tr>
								<td align="center" height="19"><STRONG>b</STRONG></td>
								<td colSpan="4" height="19">&nbsp;<%=b3%></td>
								<td colSpan="3" height="19">&nbsp;<%=b3datepk%></td>
							</tr>
							<tr>
								<td align="center" height="19"><STRONG>c</STRONG></td>
								<td colSpan="4" height="19">&nbsp;<%=c3%></td>
								<td colSpan="3" height="19">&nbsp;<%=c3datepk%></td>
							</tr>
							<tr>
								<td colSpan="8" height="19">&nbsp; <STRONG>4. Daily Sales Record Verification :</STRONG></td>
							</tr>
							<tr>
								<td colSpan="2" height="19">&nbsp; <STRONG>Product</STRONG></td>
								<td align="center" height="19"><STRONG>MS</STRONG></td>
								<td align="center" height="19"><STRONG>HSD</STRONG></td>
								<td align="center" height="19"><STRONG>Lubes</STRONG></td>
								<td align="center" colSpan="3" height="19">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2" height="16" style="HEIGHT: 16px">&nbsp; <STRONG>Avg. Sales per 
										day&nbsp;&nbsp; inliters</STRONG></td>
								<td height="16" style="HEIGHT: 16px">&nbsp;<%=avgsaleMS%></td>
								<td height="16" style="HEIGHT: 16px">&nbsp;<%=avgsaleHSD%></td>
								<td height="16" style="HEIGHT: 16px">&nbsp;<%=avgsaleLUBES%></td>
								<td colSpan="3" height="16" style="HEIGHT: 16px"><b>Reasons</b> <STRONG>:</STRONG> <STRONG>
										Nil Sales/Dry-outs</STRONG></td>
							</tr>
							<tr>
								<td colSpan="2" height="12" style="HEIGHT: 12px">&nbsp; <STRONG>No. Of day Nil Sales</STRONG></td>
								<td height="12" style="HEIGHT: 12px">&nbsp;<%=NilSaleaMS%></td>
								<td height="12" style="HEIGHT: 12px">&nbsp;<%=NilSaleaHSD%></td>
								<td height="12" style="HEIGHT: 12px">&nbsp;<%=NilSaleaLUBES%></td>
								<td colSpan="3" height="32" rowSpan="2" style="HEIGHT: 32px">&nbsp;<%=NilSalesDryout%></td>
							</tr>
							<tr>
								<td colSpan="2" height="14" style="HEIGHT: 14px">&nbsp; <STRONG>Days Of Dry 
										Outs,if&nbsp;&nbsp; any</STRONG>
								</td>
								<td height="14" style="HEIGHT: 14px">&nbsp;<%=DryOutMS%></td>
								<td height="14" style="HEIGHT: 14px">&nbsp;<%=DryOutHSD%></td>
								<td height="14" style="HEIGHT: 14px">&nbsp;<%=DryOutLUBES%></td>
							</tr>
							<tr>
								<td colSpan="4" height="19">&nbsp; <STRONG>TBA Sales(per month)</STRONG></td>
								<td colspan="4"><%=tba4%></td>
							</tr>
						</table>
						<!-- Form 2-->
						<table id="Table4" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td colSpan="8"><b>&nbsp; 5. Stock Verification</b></td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; (A) Totaliser Reading :</b></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp;</td>
								<td align="center" width="11%"><STRONG>No. 1</STRONG></td>
								<td align="center" width="11%"><STRONG>No. 2</STRONG></td>
								<td align="center" width="10%"><STRONG>No. 3</STRONG></td>
								<td align="center" width="11%"><STRONG>No. 4</STRONG></td>
								<td align="center" width="11%"><STRONG>No. 5</STRONG></td>
								<td align="center" width="10%"><STRONG>No. 6</STRONG></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>Product</STRONG></td>
								<td>&nbsp;<%=AProNo1%></td>
								<td>&nbsp;<%=AProNo2%></td>
								<td>&nbsp;<%=AProNo3%></td>
								<td>&nbsp;<%=AProNo4%></td>
								<td>&nbsp;<%=AProNo5%></td>
								<td>&nbsp;<%=AProNo6%></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>Make</STRONG></td>
								<td>&nbsp;<%=AMakeNo1%></td>
								<td>&nbsp;<%=AMakeNo2%></td>
								<td>&nbsp;<%=AMakeNo3%></td>
								<td>&nbsp;<%=AMakeNo4%></td>
								<td>&nbsp;<%=AMakeNo5%></td>
								<td>&nbsp;<%=AMakeNo6%></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>Current Reading</STRONG></td>
								<td>&nbsp;<%=ACuuReadNo1%></td>
								<td>&nbsp;<%=ACuuReadNo2%></td>
								<td>&nbsp;<%=ACuuReadNo3%></td>
								<td>&nbsp;<%=ACuuReadNo4%></td>
								<td>&nbsp;<%=ACuuReadNo5%></td>
								<td>&nbsp;<%=ACuuReadNo6%></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>Previous Reading</STRONG></td>
								<td>&nbsp;<%=APrevReadNo1%></td>
								<td>&nbsp;<%=APrevReadNo2%></td>
								<td>&nbsp;<%=APrevReadNo3%></td>
								<td>&nbsp;<%=APrevReadNo4%></td>
								<td>&nbsp;<%=APrevReadNo5%></td>
								<td>&nbsp;<%=APrevReadNo6%></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>Total Sales as per Meter Reading(i)</STRONG></td>
								<td>&nbsp;<%=APerMETReadNo1%></td>
								<td>&nbsp;<%=APerMETReadNo2%></td>
								<td>&nbsp;<%=APerMETReadNo3%></td>
								<td>&nbsp;<%=APerMETReadNo4%></td>
								<td>&nbsp;<%=APerMETReadNo5%></td>
								<td>&nbsp;<%=APerMETReadNo6%></td>
							</tr>
							<tr>
								<td colSpan="4"><STRONG>&nbsp; (B) Physical stock(Stock in tanks)</STRONG></td>
								<td align="center" rowSpan="2"><STRONG>MS-93</STRONG></td>
								<td align="center" rowSpan="2"><STRONG>MS-87</STRONG></td>
								<td align="center" rowSpan="2"><STRONG>MS-ULP</STRONG></td>
								<td align="center" rowSpan="2"><STRONG>HSD</STRONG></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="4"><STRONG>&nbsp; Stock as on&nbsp;<%=st5bdate%>
										(Date of inspection)</STRONG></td>
								<td>&nbsp;<%=BStockonlastDtMS93%></td>
								<td>&nbsp;<%=BStockonlastDtMS87%></td>
								<td>&nbsp;<%=BStockonlastDtMSulp%></td>
								<td>&nbsp;<%=BStockonlastDtHSD%></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; <STRONG>Receipt since then(KL)</STRONG></td>
								<td>&nbsp;<%=BReceiptKL_MS93%></td>
								<td>&nbsp;<%= BReceiptKL_MS87%></td>
								<td>&nbsp;<%=BReceiptKL_MSULP%></td>
								<td>&nbsp;<%=BReceiptKL_HSD%></td>
							</tr>
							<tr>
								<td style="HEIGHT: 15px" colSpan="4"><STRONG>Total Stock (KL) (A)</STRONG></td>
								<td style="HEIGHT: 15px">&nbsp;<%=BTotalstkMS93%></td>
								<td style="HEIGHT: 15px">&nbsp;<%=BTotalstkMS87%></td>
								<td style="HEIGHT: 15px">&nbsp;<%=BTotalstkMSULP%></td>
								<td style="HEIGHT: 15px">&nbsp;<%=BTotalstkHSD%></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; <STRONG>Less : Actul Stock as per Dip (B)</STRONG></td>
								<td>&nbsp;<%=BTLessstkMS93%></td>
								<td>&nbsp;<%=BTLessstkMS87%></td>
								<td>&nbsp;<%=BTLessstkMSULP%></td>
								<td>&nbsp;<%=BTLessstkHSD%></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; <STRONG>Total Sales as per Dips (ii=A-B)</STRONG></td>
								<td>&nbsp;<%=BTotSalesMS93%></td>
								<td>&nbsp;<%=BTotSalesMS87%></td>
								<td>&nbsp;<%=BTotSalesMSULP%></td>
								<td>&nbsp;<%=BTotSalesHSD%></td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp; <STRONG>Variation (i-ii)</STRONG></td>
								<td>&nbsp;<%=BVariationMS93%></td>
								<td>&nbsp;<%=BVariationMS87%></td>
								<td>&nbsp;<%=BVariationMSULP%></td>
								<td>&nbsp;<%=BVariationHSD%></td>
							</tr>
							<tr>
								<td colSpan="3">&nbsp; <STRONG>Reasons for variation :</STRONG>
								</td>
								<td colSpan="5">&nbsp;<%=BReasonVar%></td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; 6. Lubricants Stock</b></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp;</td>
								<td align="center" colSpan="3"><STRONG>Barrels</STRONG></td>
								<td align="center" colSpan="3"><STRONG>Small Packs</STRONG></td>
							</tr>
							<tr>
								<td colSpan="2" rowSpan="2"><STRONG>&nbsp; Adequate</STRONG></td>
								<td>&nbsp;<%=adqbarrel1_0%></td>
								<td>&nbsp;<%=adqbarrel2_0%></td>
								<td>&nbsp;<%=adqbarrel3_0%></td>
								<td>&nbsp;<%=Smallpck1_0%></td>
								<td>&nbsp;<%=Smallpck2_0%></td>
								<td>&nbsp;<%=Smallpck3_0%></td>
							</tr>
							<tr>
								<td>&nbsp;<%=adqbarrel1_1%></td>
								<td>&nbsp;<%=adqbarrel2_1%></td>
								<td>&nbsp;<%=adqbarrel3_1%></td>
								<td>&nbsp;<%=adSmallpck1_1%></td>
								<td>&nbsp;<%=adSmallpck2_1%></td>
								<td>&nbsp;<%=adSmallpck3_1%></td>
							</tr>
							<tr>
								<td colSpan="2" rowSpan="2"><STRONG>&nbsp; Inadequate</STRONG></td>
								<td>&nbsp;<%=Inadqbarrel1_0%></td>
								<td>&nbsp;<%=Inadqbarrel2_0%></td>
								<td>&nbsp;<%=Inadqbarrel3_0%></td>
								<td>&nbsp;<%=InSmallpck1_0%></td>
								<td>&nbsp;<%=InSmallpck2_0%></td>
								<td>&nbsp;<%=InSmallpck3_0%></td>
							</tr>
							<tr>
								<td>&nbsp;<%=Inadqbarrel1_1%></td>
								<td>&nbsp;<%=Inadqbarrel2_1%></td>
								<td>&nbsp;<%=Inadqbarrel3_1%></td>
								<td>&nbsp;<%=InSmallpck1_1%></td>
								<td>&nbsp;<%=InSmallpck2_1%></td>
								<td>&nbsp;<%=InSmallpck3_1%></td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; Note : Stocks should cover at least 15 days sales. Note grade 
										names under each column</b></td>
							</tr>
							<tr>
								<td width="9%" colSpan="5"><b>&nbsp; 7. Details of Subsidy availed</b></td>
								<td width="10%">&nbsp; <STRONG>Year</STRONG></td>
								<td width="17%" colSpan="2"><STRONG>&nbsp; Amount</STRONG></td>
							</tr>
							<tr>
								<td width="9%" colSpan="5">&nbsp;<%=DetailSub1%>
								</td>
								<td width="10%">&nbsp;<%=DetailSub1_yr%></td>
								<td width="17%" colSpan="2">&nbsp;<%=DetailSub1_amt%></td>
							</tr>
							<tr>
								<td style="HEIGHT: 12px" width="9%" colSpan="5">&nbsp;<%=DetailSub2%>
								</td>
								<td style="HEIGHT: 12px" width="10%">&nbsp;<%=DetailSub2_yr%></td>
								<td style="HEIGHT: 12px" width="17%" colSpan="2">&nbsp;<%=DetailSub2_amt%></td>
							</tr>
							<tr>
								<td style="HEIGHT: 13px" width="9%" colSpan="5">&nbsp;<%=DetailSub3%></td>
								<td style="HEIGHT: 13px" width="10%">&nbsp;<%=DetailSub3_yr%></td>
								<td style="HEIGHT: 13px" width="17%" colSpan="2">&nbsp;<%=DetailSub3_amt%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="5">&nbsp;<%=DetailSub4%></td>
								<td width="10%">&nbsp;<%=DetailSub4_yr%></td>
								<td width="17%" colSpan="2">&nbsp;<%=DetailSub4_amt%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="5">&nbsp;<%=DetailSub5%></td>
								<td width="10%">&nbsp;<%=DetailSub5_yr%></td>
								<td width="17%" colSpan="2">&nbsp;<%=DetailSub5_amt%></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 8. Dealers' Suggestion to improve Image/Sales :<br>
									</b>&nbsp;&nbsp;&nbsp;<%=Dealersugggestion%></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 9. Market information on Competitors' activities 
										:<br>
									</b>&nbsp;&nbsp;<%=MarInfo%></td>
							</tr>
						</table>
						<!-- Form 3-->
						<table id="Table3" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td width="12%" colSpan="8"><b>10. Upkeep and Maintenance of equipments;</b></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6"><b>10.1 Dispensing Pump :</b></td>
								<td width="12%">&nbsp;</td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>a) Pumps adequate for peak hour demand</STRONG></td>
								<td width="12%">&nbsp;<%=c10_1A_Y%>
								</td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;<STRONG> b) No.of pump attendants per shift</STRONG></td>
								<td width="15%" colSpan="2">&nbsp;<%=B10_1%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>c) Painting required</STRONG></td>
								<td width="12%">&nbsp;<%=c10_1C_y%></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;<STRONG> d) Visual leak in despensing units observed</STRONG></td>
								<td width="12%">&nbsp;<%=c10_1d_y%></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;<STRONG> e) Message regarding zeroing of pump meter 
										displayed</STRONG></td>
								<td width="12%">&nbsp;<%=c10_1e_y%></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;<STRONG> f) All units are in working order :</STRONG></td>
								<td width="12%">&nbsp;<%=c10_1f_y%></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3"><STRONG>&nbsp; if no , details</STRONG></td>
								<td width="12%" colSpan="5">&nbsp;<%=f10_1%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6" style="HEIGHT: 14px"><STRONG>&nbsp; g) Any 
										replacements/additions required :</STRONG></td>
								<td width="12%" style="HEIGHT: 14px">&nbsp;<%=c10_1g_y%></td>
								<td width="15%" style="HEIGHT: 14px">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3"><STRONG>&nbsp; if Yes , details</STRONG></td>
								<td width="12%" colSpan="5">&nbsp;<%=g10_1%></td>
							</tr>
							<tr>
								<td width="30%" colSpan="3"><b>&nbsp; 10.2 Emblem&nbsp; Posts</b></td>
								<td width="12%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>a) Visibility of Emblem Sign(check for good 
										or bad)</STRONG></td>
								<td width="12%">&nbsp;<%=c10_2a_good%></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>b) Condition of Emblem Sign(check for good or 
										bad)</STRONG></td>
								<td width="12%">&nbsp;<%=c10_2b_good%></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>c) Painting Required</STRONG></td>
								<td width="12%">&nbsp;<%=c10_2c_y%></td>
								<td width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3"><b>&nbsp; 10.3 Sales Room</b></td>
								<td width="12%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>a) Painting Last Done On (DD-MM-YY)</STRONG></td>
								<td width="15%" colSpan="2">&nbsp;<%=a10_3_Date%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;<STRONG> b) Painting Required :</STRONG></td>
								<td align="center" width="12%">&nbsp;<%=c10_3b_y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>c) Repair Required :</STRONG></td>
								<td align="center" width="12%">&nbsp;<%=c10_3c_y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; <STRONG>d) Display of Lubes</STRONG></td>
								<td align="center" width="12%"><STRONG>Ex</STRONG>&nbsp;<%=c10_3d_Ex%></td>
								<td align="center" width="12%"><STRONG>Vg</STRONG>&nbsp;<%=c10_3d_Vg%></td>
								<td align="center" width="11%"><STRONG>G</STRONG>&nbsp;<%=c10_3d_G%></td>
								<td align="center" width="13%"><STRONG>Av</STRONG>&nbsp;<%=c10_3d_Av%></td>
								<td align="center" width="16%"><STRONG>P</STRONG>&nbsp;<%=c10_3d_P%></td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; <STRONG>e) Cleanliness</STRONG></td>
								<td align="center" width="12%"><STRONG>Ex</STRONG>&nbsp;<%=c10_3e_Ex%></td>
								<td align="center" width="12%"><STRONG>Vg</STRONG>&nbsp;<%=c10_3e_Vg%></td>
								<td align="center" width="11%"><STRONG>G</STRONG>&nbsp;<%=c10_3e_G%></td>
								<td align="center" width="13%"><STRONG>Av</STRONG>&nbsp;<%=c10_3e_Av%></td>
								<td align="center" width="16%"><STRONG>P</STRONG>&nbsp;<%=c10_3e_P%></td>
							</tr>
							<tr>
								<td width="31%" colSpan="3"><b>&nbsp; 10.4 Lighting</b></td>
								<td width="11%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" width="30%" colSpan="3">&nbsp; <STRONG>a) Sales Room</STRONG></td>
								<td style="HEIGHT: 19px" align="center" width="12%"><STRONG>Ex</STRONG>&nbsp;<%=c10_4a_Ex%></td>
								<td style="HEIGHT: 19px" align="center" width="12%"><STRONG>Vg</STRONG>&nbsp;<%=c10_4a_Vg%></td>
								<td style="HEIGHT: 19px" align="center" width="11%"><STRONG>G</STRONG>&nbsp;<%=c10_4a_G%></td>
								<td style="HEIGHT: 19px" align="center" width="13%"><STRONG>Av</STRONG>&nbsp;<%=c10_4a_Av%></td>
								<td style="HEIGHT: 19px" align="center" width="16%"><STRONG>P</STRONG>&nbsp;<%=c10_4a_P%></td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp;<STRONG> b) Yard Lighting</STRONG></td>
								<td align="center" width="12%"><STRONG>Ex</STRONG>&nbsp;<%=c10_4b_Ex%></td>
								<td align="center" width="12%"><STRONG>Vg</STRONG>&nbsp;<%=c10_4b_Vg%></td>
								<td align="center" width="11%"><STRONG>G</STRONG>&nbsp;<%=c10_4b_G%></td>
								<td align="center" width="13%"><STRONG>Av</STRONG>&nbsp;<%=c10_4b_Av%></td>
								<td align="center" width="16%"><STRONG>P</STRONG>&nbsp;<%=c10_4b_P%></td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; <STRONG>c) Pump Island</STRONG></td>
								<td align="center" width="12%"><STRONG>Ex</STRONG>&nbsp;<%=c10_4c_Ex%></td>
								<td align="center" width="12%"><STRONG>Vg</STRONG>&nbsp;<%=c10_4c_Vg%></td>
								<td align="center" width="11%"><STRONG>G</STRONG>&nbsp;<%=c10_4c_G%></td>
								<td align="center" width="13%"><STRONG>Av</STRONG>&nbsp;<%=c10_4c_Av%></td>
								<td align="center" width="16%"><STRONG>P</STRONG>&nbsp;<%=c10_4c_P%></td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; <STRONG>d) Embeling</STRONG></td>
								<td align="center" width="12%"><STRONG>Ex</STRONG>&nbsp;<%=c10_4d_Ex%></td>
								<td align="center" width="12%"><STRONG>Vg</STRONG>&nbsp;<%=c10_4d_Vg%></td>
								<td align="center" width="11%"><STRONG>G</STRONG>&nbsp;<%=c10_4d_G%></td>
								<td align="center" width="13%"><STRONG>Av</STRONG>&nbsp;<%=c10_4d_Av%></td>
								<td align="center" width="16%"><STRONG>P</STRONG>&nbsp;<%=c10_4d_P%></td>
							</tr>
							<tr>
								<td width="30%" colSpan="3"><b>&nbsp; 10.5 Driveway</b></td>
								<td width="12%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; <STRONG>a) Condition of&nbsp; Driveway</STRONG></td>
								<td align="center" width="12%"><STRONG>Ex</STRONG>&nbsp;<%=c10_5a_Ex%></td>
								<td align="center" width="12%"><STRONG>Vg</STRONG>&nbsp;<%=c10_5a_Vg%></td>
								<td align="center" width="11%"><STRONG>G</STRONG>&nbsp;<%=c10_5a_G%></td>
								<td align="center" width="13%"><STRONG>Av</STRONG>&nbsp;<%=c10_5a_Av%></td>
								<td align="center" width="16%"><STRONG>P</STRONG>&nbsp;<%=c10_5a_P%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>b) Asphalted</STRONG></td>
								<td align="center" width="12%">&nbsp;<%=c10_5b_Y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td style="HEIGHT: 15px" width="9%" colSpan="6">&nbsp;<STRONG> c) Repaires Required</STRONG></td>
								<td style="HEIGHT: 15px" align="center" width="12%">&nbsp;<%=c10_5c_Y%></td>
								<td style="HEIGHT: 15px" align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>d) Canopy Available</STRONG></td>
								<td align="center" width="12%">&nbsp;<%=c10_5d_Y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="31%" colSpan="3"><b>&nbsp; 10.6 Pump Island</b></td>
								<td width="11%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="30%" colSpan="3">&nbsp; <STRONG>a) General&nbsp;&nbsp; Appearance</STRONG></td>
								<td align="center" width="12%"><STRONG>Ex&nbsp;</STRONG><%=c10_6a_Ex%></td>
								<td align="center" width="12%"><STRONG>Vg&nbsp;</STRONG><%=c10_6a_Vg%></td>
								<td align="center" width="11%"><STRONG>G&nbsp;</STRONG><%=c10_6a_G%></td>
								<td align="center" width="13%"><STRONG>Av&nbsp;</STRONG><%=c10_6a_Av%></td>
								<td align="center" width="16%"><STRONG>P&nbsp;</STRONG><%=c10_6a_P%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;<STRONG> b) Tiling Done</STRONG>
								</td>
								<td align="center" width="12%">&nbsp;<%=c10_6b_Y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>c) Lube Display at Pump Island</STRONG></td>
								<td align="center" width="12%">&nbsp;<%=c10_6c_Y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="12%" colSpan="8">&nbsp; <STRONG>Action proposed for improving the above</STRONG>
									<br>
									&nbsp;&nbsp;
									<%=c10_6%>
								</td>
							</tr>
							<tr>
								<td width="31%" colSpan="3"><b>&nbsp; 10.7 Tank Farm</b>
								</td>
								<td width="11%" colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>a) Tank Farm area free from oil spillage and 
										kept clean</STRONG></td>
								<td align="center" width="12%">&nbsp;<%=c10_7a_Y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;<STRONG>&nbsp;b) Tank Farm free from dry grass</STRONG>
								</td>
								<td align="center" width="12%">&nbsp;<%=c10_7b_Y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>c) Camlock Couplings available for Unloading</STRONG>
								</td>
								<td align="center" width="12%">&nbsp;<%=c10_7c_Y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>d) Availability of Chain-Link Fencing</STRONG></td>
								<td align="center" width="12%">&nbsp;<%=c10_7d_Y%></td>
								<td align="center" width="15%">&nbsp;</td>
							</tr>
						</table>
						<!-- Form 4-->
						<table id="Table2" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 11.0 Chapter II of MDG available at the RO is 
										understood and being followed</b></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 12.0 Prices : Displayed &amp; Correctly Charged</b></td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp;<STRONG> a) MS 87</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c12a_Y%></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>b) MS 93</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c12b_Y%></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>c) MS-ULP</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c12c_Y%></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>d) HSD</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c12d_Y%></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>e) Lubes</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c12e_Y%></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 13.0 Inspection of Other Facilities</b></td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>a) Free Air Service Available</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13a_Y%></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp;<STRONG> b) Free Radiator Water Available</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13b_Y%></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>c) "Working Hours" Board displayed</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13c_Y%></td>
								<td align="center" width="1%">&nbsp;</td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px" colSpan="6">&nbsp;<STRONG> d) Telephone No of Concerned IOC 
										Officers Are displayed</STRONG></td>
								<td style="HEIGHT: 19px" align="center" width="1%">&nbsp;<%=c13d_Y%></td>
								<td style="HEIGHT: 19px" align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; e) Poster for Checking adulteration of MS displayed</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13e_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>f) Message : Regarding availability of Complaints and 
										Suggestion Book, Costomer Service&nbsp; Cell&nbsp;and Complaints forwarded to 
										DO</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13f_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>g) Presence of Water Checked in Tanks</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13g_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="8" style="HEIGHT: 15px">&nbsp;<STRONG> if Found, action Taken :</STRONG><br>
									<%=g13%>
								</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>h) Water Dip Record maintained by Dealer</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13h_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>i) Density Register Maintained by Dealer</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13i_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; j<STRONG>) Segregated Island for 2/3 Wheelers</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13j_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; k) First Aid Box Available</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13k_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; l) Filter Paper Available</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13l_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; m) 5 Liter measure (Calibrated) available</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13m_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; n) Inspection File Maintained</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13n_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; o) Valid Trade Licence available</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13o_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; p) Explosives Rules displayed </STRONG>
								</td>
								<td align="center" width="1%">&nbsp;<%=c13p_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; q) Layout Drawing of RO duly approved by CCE available </STRONG>
								</td>
								<td align="center" width="1%">&nbsp;<%=c13q_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; r) Explosives licence Renewed</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13r_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; s) No Smoking Board Installed </STRONG>
								</td>
								<td align="center" width="1%">&nbsp;<%=c13s_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; t) Telephone No. of Firebrigade, Police,Ambulance 
										displayed</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13t_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; u) Weights &amp; Measures Certificate valid </STRONG>
								</td>
								<td align="center" width="1%">&nbsp;<%=c13u_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td width="55%" colSpan="6"><STRONG>&nbsp; v) Any Other unauthorised work being carried 
										out at RO,i.e. weiding,etc. or any operations&nbsp;&nbsp; which is not approved 
										by CCE </STRONG>
								</td>
								<td align="center" width="1%">&nbsp;<%=c13v_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="6"><STRONG>&nbsp; w) All the pump attendants in Uniform as per Policy</STRONG></td>
								<td align="center" width="1%">&nbsp;<%=c13w_Y%></td>
								<td align="center" width="12%">&nbsp;</td>
							</tr>
						</table>
						<!--Form 5-->
						<table id="Table1" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td colSpan="22"><STRONG>&nbsp; x) Dealers/Pumps attendents given training in last one 
										year</STRONG></td>
								<td align="center" width="1%" colSpan="2">&nbsp;<%=c13x_Y%></td>
							</tr>
							<tr>
								<td width="5%" colSpan="24"><STRONG>&nbsp; if Yes, Nature of Training</STRONG>&nbsp;<br>
									<%=nature13%>
									&nbsp;&nbsp;
								</td>
							</tr>
							<tr>
								<td style="HEIGHT: 16px" width="5%" colSpan="24"><b>&nbsp; 14.0 Inspection of Pump 
										Delivery</b>
								</td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp;</td>
								<td align="center" width="4%" colSpan="18"><STRONG>Pump Nos</STRONG></td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp;</td>
								<td align="center" colSpan="3"><STRONG>No. 1</STRONG></td>
								<td align="center" colSpan="3"><STRONG>No. 2</STRONG></td>
								<td align="center" colSpan="3"><STRONG>No. 3</STRONG></td>
								<td align="center" colSpan="3"><STRONG>No. 4</STRONG></td>
								<td align="center" colSpan="3"><STRONG>No. 5</STRONG></td>
								<td align="center" colSpan="3"><STRONG>No. 6</STRONG></td>
							</tr>
							<tr>
								<td colSpan="6">&nbsp; <STRONG>a) Weight &amp; Measures Seal Intact</STRONG></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14a1_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14a2_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14a3_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14a4_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14a5_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14a6_Y%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp;<STRONG> b) Totaliser Seal Intact</STRONG></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14b1_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14b2_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14b3_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14b4_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14b5_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c14b6_Y%></td>
							</tr>
							<tr>
								<td width="9%" colSpan="6">&nbsp; <STRONG>c) Delivery</STRONG></td>
								<td align="center" width="1%"><STRONG>C</STRONG>&nbsp;<%=c14c1_C%></td>
								<td align="center" width="1%"><STRONG>S</STRONG>&nbsp;<%=c14c1_S%></td>
								<td align="center" width="1%"><STRONG>E</STRONG>&nbsp;<%=c14c1_E%></td>
								<td align="center" width="1%"><STRONG>C</STRONG>&nbsp;<%=c14c2_C%></td>
								<td align="center" width="1%"><STRONG>S</STRONG>&nbsp;<%=c14c2_S%></td>
								<td align="center" width="1%"><STRONG>E</STRONG>&nbsp;<%=c14c2_E%></td>
								<td align="center" width="1%"><STRONG>C</STRONG>&nbsp;<%=c14c3_C%></td>
								<td align="center" width="1%"><STRONG>S</STRONG>&nbsp;<%=c14c3_S%></td>
								<td align="center" width="1%"><STRONG>E</STRONG>&nbsp;<%=c14c3_E%></td>
								<td align="center" width="1%"><STRONG>C</STRONG>&nbsp;<%=c14c4_C%></td>
								<td align="center" width="1%"><STRONG>S</STRONG>&nbsp;<%=c14c4_S%></td>
								<td align="center" width="1%"><STRONG>E</STRONG>&nbsp;<%=c14c4_E%></td>
								<td align="center" width="1%"><STRONG>C</STRONG>&nbsp;<%=c14c5_C%></td>
								<td align="center" width="1%"><STRONG>S</STRONG>&nbsp;<%=c14c5_S%></td>
								<td align="center" width="1%"><STRONG>E</STRONG>&nbsp;<%=c14c5_E%></td>
								<td align="center" width="1%"><STRONG>C</STRONG>&nbsp;<%=c14c6_C%></td>
								<td align="center" width="1%"><STRONG>S</STRONG>&nbsp;<%=c14c6_S%></td>
								<td align="center" width="1%"><STRONG>E</STRONG>&nbsp;<%=c14c6_E%></td>
							</tr>
							<tr>
								<td align="center" width="4%" colSpan="24"><b>Tick appropriate box &gt; C- Correct, S- 
										Short, E- Excess </b>
								</td>
							</tr>
							<tr>
								<td width="4%" colSpan="24"><b>&nbsp; 15.0 Report on Quality Check of MS/HSD</b></td>
							</tr>
							<tr>
								<td width="7%" colSpan="13">&nbsp;</td>
								<td width="1%" colSpan="3"><STRONG>Tank 1</STRONG></td>
								<td width="1%" colSpan="3"><STRONG>Tank 2</STRONG></td>
								<td width="1%" colSpan="2"><STRONG>Tank 3</STRONG></td>
								<td width="1%" colSpan="3"><STRONG>Tank 4</STRONG></td>
							</tr>
							<tr>
								<td width="7%" colSpan="13"><STRONG>&nbsp; Product</STRONG></td>
								<td width="1%" colSpan="3">&nbsp;<%=pro15t1%></td>
								<td width="1%" colSpan="3">&nbsp;<%=pro15t2%></td>
								<td width="1%" colSpan="2">&nbsp;<%=pro15t3%></td>
								<td width="1%" colSpan="3">&nbsp;<%=pro15t4%></td>
							</tr>
							<tr>
								<td width="7%" colSpan="13"><STRONG>&nbsp; a) Density Check Conducted</STRONG></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c15aT1_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c15aT2_Y%></td>
								<td align="center" width="1%" colSpan="2">&nbsp;<%=c15aT3_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c15aT4_Y%></td>
							</tr>
							<tr>
								<td width="7%" colSpan="13"><STRONG>&nbsp; b) Density at 15 degree(C) as ascertained at 
										the time of Inspection</STRONG></td>
								<td width="1%" colSpan="3">&nbsp;<%=b15T1%></td>
								<td width="1%" colSpan="3">&nbsp;<%=b15T2%></td>
								<td width="1%" colSpan="2">&nbsp;<%=b15T3%></td>
								<td width="1%" colSpan="3">&nbsp;<%=b15T4%></td>
							</tr>
							<tr>
								<td width="7%" colSpan="13"><STRONG>&nbsp; c) Density at 15 degree(C) as per Dealers 
										Record</STRONG></td>
								<td width="1%" colSpan="3">&nbsp;<%=c15T1%></td>
								<td width="1%" colSpan="3">&nbsp;<%=c15T2%></td>
								<td width="1%" colSpan="2">&nbsp;<%=c15T3%></td>
								<td width="1%" colSpan="3">&nbsp;<%=c15T4%></td>
							</tr>
							<tr>
								<td width="7%" colSpan="13"><STRONG>&nbsp; d) Is Variation within Permissible limits ?</STRONG></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c15dT1_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c15dT2_Y%></td>
								<td align="center" width="1%" colSpan="2">&nbsp;<%=c15dT3_Y%></td>
								<td align="center" width="1%" colSpan="3">&nbsp;<%=c15dT4_Y%></td>
							</tr>
							<tr>
								<td style="HEIGHT: 13px" width="7%" colSpan="13"><STRONG>&nbsp; e) Samples Drawn(if 
										Density variation is beyond permissible limits) </STRONG>
								</td>
								<td style="HEIGHT: 13px" align="center" width="1%" colSpan="3">&nbsp;<%=c15eT1_Y%></td>
								<td style="HEIGHT: 13px" align="center" width="1%" colSpan="3">&nbsp;<%=c15eT2_Y%></td>
								<td style="HEIGHT: 13px" align="center" width="1%" colSpan="2">&nbsp;<%=c15eT3_Y%></td>
								<td style="HEIGHT: 13px" align="center" width="1%" colSpan="3">&nbsp;<%=c15eT4_Y%></td>
							</tr>
							<tr>
								<td width="4%" colSpan="24"><STRONG>&nbsp; f) Details of Action Taken :<br>
									</STRONG>
									<%=f15%>
								</td>
							</tr>
							<tr>
								<td width="4%" colSpan="24"><b>&nbsp; 16.0 Report on furfural Check (Applicable in 
										Respect of the ROs Normaly Supplied by Locations undertaking&nbsp;&nbsp; doping 
										of Kerosene)</b></td>
							</tr>
							<tr>
								<td width="4%" colSpan="22"><STRONG>&nbsp; a) Is SKO beinf doped with furfural by the 
										supply point</STRONG></td>
								<td></td>
								<td>&nbsp;<%=c16a_Y%></td>
							</tr>
							<tr>
								<td colSpan="13">&nbsp;</td>
								<td colSpan="3"><STRONG>Tank 1</STRONG></td>
								<td colSpan="3"><STRONG>Tank 2</STRONG></td>
								<td colSpan="2"><STRONG>Tank 3</STRONG></td>
								<td colSpan="3"><STRONG>Tank 4</STRONG></td>
							</tr>
							<tr>
								<td width="7%" colSpan="24"><STRONG>&nbsp; Detail of Action Taken</STRONG></td>
							</tr>
							<tr>
								<td colSpan="13"><STRONG>&nbsp; b) Furfural Check conducted</STRONG>
								</td>
								<td align="center" colSpan="3">&nbsp;<%=c16bT1_Y%></td>
								<td align="center" colSpan="3">&nbsp;<%=c16bT2_Y%></td>
								<td align="center" colSpan="2">&nbsp;<%=c16bT3_Y%></td>
								<td align="center" colSpan="3">&nbsp;<%=c16bT4_Y%></td>
							</tr>
							<tr>
								<td colSpan="13"><STRONG>&nbsp; c) Product Passed Furfural test</STRONG></td>
								<td align="center" colSpan="3">&nbsp;<%=c16cT1_Y%></td>
								<td align="center" colSpan="3">&nbsp;<%=c16cT2_Y%></td>
								<td align="center" colSpan="2">&nbsp;<%=c16cT3_Y%></td>
								<td align="center" colSpan="3">&nbsp;<%=c16cT4_Y%></td>
							</tr>
							<tr>
								<td colSpan="13" style="HEIGHT: 14px"><STRONG>&nbsp; d) Samples Drawn (if product fails 
										test)</STRONG></td>
								<td align="center" colSpan="3" style="HEIGHT: 14px">&nbsp;<%=c16dT1_Y%></td>
								<td align="center" colSpan="3" style="HEIGHT: 14px">&nbsp;<%=c16dT2_Y%></td>
								<td align="center" colSpan="2" style="HEIGHT: 14px">&nbsp;<%=c16dT3_Y%></td>
								<td align="center" colSpan="3" style="HEIGHT: 14px">&nbsp;<%=c16dT4_Y%></td>
							</tr>
							<tr>
								<td colSpan="24" style="HEIGHT: 23px"><STRONG>&nbsp; Details of Action Taken<br>
									</STRONG>&nbsp;<%=Detail16%></td>
							</tr>
							<tr>
								<td colSpan="24"><b>&nbsp; 17.0 Mobile Lab Inspections</b></td>
							</tr>
							<tr>
								<td colSpan="13"><STRONG>&nbsp; a) Date of Last Visit by Mobile Lab : </STRONG>
								</td>
								<td colSpan="5">&nbsp;<%=a17_Date%></td>
								<td colSpan="3">Result</td>
								<td colSpan="3">&nbsp;<%=a17_Result%></td>
							</tr>
							<tr>
								<td width="4%" colSpan="13"><STRONG>&nbsp; b) Date of Last LDs Sample Drawn : </STRONG>
								</td>
								<td width="4%" colSpan="5">&nbsp;<%=b17_Date%></td>
								<td width="1%" colSpan="3">Result</td>
								<td width="1%" colSpan="3">&nbsp;<%=b17_Result%></td>
							</tr>
							<tr>
								<td width="4%" colSpan="13"><STRONG>&nbsp; c) Date of Last Nozzle Sample drawn : </STRONG>
								</td>
								<td width="4%" colSpan="5">&nbsp;<%=c17_Date%></td>
								<td width="1%" colSpan="3">Result</td>
								<td width="1%" colSpan="3">&nbsp;<%=c17_Result%></td>
							</tr>
							<tr>
								<td width="8%" colSpan="20" rowSpan="2">&nbsp; <b>Note :- LDs Sample should be drawn at 
										least once a year. draw LDs sample if date at 17.2 is over One year</b></td>
								<td width="1%">MS</td>
								<td width="1%" colSpan="3">&nbsp;<%=MS17%></td>
							</tr>
							<tr>
								<td width="1%">HSD</td>
								<td width="1%" colSpan="3">&nbsp;<%=HSD17%></td>
							</tr>
						</table>
						<!-- Form 6-->
						<table id="Table7" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td colSpan="8"><b>&nbsp; 18.0 Status Of Payments to Dealer : </b>
								</td>
							</tr>
							<tr>
								<td colSpan="6"><b>&nbsp; 18.1 Dealers Commission Paid Upto : </b>
								</td>
								<td colSpan="2">&nbsp;<%=Comm18_1%></td>
							</tr>
							<tr>
								<td colSpan="6"><b>&nbsp; 18.2 Transport bills : Payed for the period : </b>
								</td>
								<td colSpan="2">&nbsp;<%=Transport18_2%></td>
							</tr>
							<tr>
								<td colSpan="6"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pendig Bills : </b>
								</td>
								<td colSpan="2">&nbsp;<%=Pending18_2%></td>
							</tr>
							<tr>
								<td colSpan="8"><STRONG>&nbsp; Action plans For Clearing the Bills:</STRONG>
									<br>
									&nbsp;
									<%=Action18_2%>
								</td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; <b>18.3 Adjustment against short reciept of Product pending</b></td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Product </b>
								</td>
								<td colSpan="4">&nbsp;</B><%=product18_3%></td>
								<td>&nbsp;<%=Pro18_3%></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Quantity </b>
								</td>
								<td colSpan="4">&nbsp;<%=quality18_3%></B></td>
								<td>&nbsp;<%=Qty18_3%></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Invoice Number</b></td>
								<td colSpan="4">&nbsp;</B><%=Invoice18_3%></td>
								<td>&nbsp;<%=Inv18_3%></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Amount</b></td>
								<td colSpan="4">&nbsp;</B><%=amount18_3%></td>
								<td>&nbsp;<%=Amt18_3%></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="8">&nbsp; <b>18.4 Adjustment of Credit Notes/Excess Billing Pending 
										against short reciept of Product pending</b></td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Product </b>
								</td>
								<td colSpan="4">&nbsp;</B><%=product18_4%></td>
								<td>&nbsp;<%=Pro18_4%></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Quantity </b>
								</td>
								<td colSpan="4">&nbsp;</B><%=quantity18_4%></td>
								<td>&nbsp;<%=Qty18_4%></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp;InvoiceNumber</b></td>
								<td colSpan="4">&nbsp;</B><%=Invoice18_4%></td>
								<td>&nbsp;<%=Inv18_4%></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2"><b>&nbsp; Amount</b></td>
								<td colSpan="4">&nbsp;</B><%=amount18_4%></td>
								<td>&nbsp;<%=Amt18_4%></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="8"><STRONG>&nbsp; Action plans For Clearing the Above:</STRONG>
									<br>
									&nbsp;
									<%=action18_4%>
								</td>
							</tr>
							<tr>
								<td colSpan="8"><b>&nbsp; 18.5 Pump Repairing </b>
								</td>
							</tr>
							<tr>
								<td colSpan="8"><STRONG>&nbsp; a) No. of visits of chargemen for Preventive Maint</STRONG><%=a18_5%></td>
							</tr>
							<TR>
								<td align="center" colSpan="8"><STRONG>Pump Nos</STRONG></td>
							</TR>
							<tr>
								<td colSpan="2">&nbsp;</td>
								<td><STRONG>No.1</STRONG></td>
								<td><STRONG>No.2</STRONG></td>
								<td><STRONG>No.3</STRONG></td>
								<td><STRONG>No.4</STRONG></td>
								<td><STRONG>No.5</STRONG></td>
								<td><STRONG>No.6</STRONG></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp;<STRONG> b) No.of Break Downs since last Inspection</STRONG></td>
								<td>&nbsp;<%=b18_5N1%></td>
								<td>&nbsp;<%=b18_5N2%></td>
								<td>&nbsp;<%=b18_5N3%></td>
								<td>&nbsp;<%=b18_5N4%></td>
								<td>&nbsp;<%=b18_5N5%></td>
								<td>&nbsp;<%=b18_5N6%></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp;<STRONG> c) Nature of Repairs</STRONG></td>
								<td>&nbsp;<%=c18_5N1%></td>
								<td>&nbsp;<%=c18_5N2%></td>
								<td>&nbsp;<%=c18_5N3%></td>
								<td>&nbsp;<%=c18_5N4%></td>
								<td>&nbsp;<%=c18_5N5%></td>
								<td>&nbsp;<%=c18_5N6%></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>d) Date of Breakdown Report</STRONG></td>
								<td>&nbsp;<%=d18_5N1%>
								</td>
								<td>&nbsp;<%=d18_5N2%>
								</td>
								<td>&nbsp;<%=d18_5N3%>
								</td>
								<td>&nbsp;<%=d18_5N4%>
								</td>
								<td>&nbsp;<%=d18_5N5%></td>
								<td>&nbsp;<%=d18_5N6%></td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>e) Date of C/Man Visit to RO </STRONG>
								</td>
								<td>&nbsp;<%=e18_5N1%>
								</td>
								<td>&nbsp;<%=e18_5N2%>
								</td>
								<td>&nbsp;<%=e18_5N3%>
								</td>
								<td>&nbsp;<%=e18_5N4%>
								</td>
								<td>&nbsp;<%=e18_5N5%>
								</td>
								<td>&nbsp;<%=e18_5N6%>
								</td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp; <STRONG>f) Date of completion of Repair</STRONG>
								</td>
								<td>&nbsp;<%=f18_5N1%>
								</td>
								<td>&nbsp;<%=f18_5N2%>
								</td>
								<td>&nbsp;<%=f18_5N3%>
								</td>
								<td>&nbsp;<%=f18_5N4%>
								</td>
								<td>&nbsp;<%=f18_5N5%>
								</td>
								<td>&nbsp;<%=f18_5N6%>
								</td>
							</tr>
							<tr>
								<td colSpan="8"><STRONG>&nbsp; Reasons/Action Plan for Improvement if delay &gt; 1 Day<br>
									</STRONG>&nbsp;<%=reasons18_5%>
								</td>
							</tr>
						</table>
						<!-- form 7-->
						<table id="Table8" cellSpacing="2" cellPadding="0" width="80%" align="center" border="1"
							runat="server">
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 18.6 Indent Execution</b></td>
							</tr>
							<tr>
								<td width="12%" colSpan="7"><STRONG>&nbsp; a) Average time needed for Indent Execution</STRONG></td>
								<td width="12%">&nbsp;<%=a18_6Avg%></td>
							</tr>
							<tr>
								<td style="HEIGHT: 12px" width="12%" colSpan="7"><STRONG>&nbsp; b) No of Dry Outs due 
										to Delayed Execution, if any since last Inspection</STRONG></td>
								<td style="HEIGHT: 12px" width="12%">&nbsp;<%=b18_6Number%></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><STRONG>&nbsp; c) Action Plan for avoiding Dry Outs</STRONG><br>
									&nbsp;<%=c18_6Actionplan%>
								</td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 19.0 Details of Action Taken on point of Previous 
										Inspection Report</b></td>
							</tr>
							<tr>
								<td align="center" width="12%"><STRONG>Sr. No</STRONG></td>
								<td align="center" width="12%" colspan="2"><STRONG>Date</STRONG></td>
								<td align="center" width="12%" colSpan="2"><STRONG>Action Plan</STRONG></td>
								<td width="12%" colSpan="3"><STRONG>Details of action Taken</STRONG></td>
							</tr>
							<tr>
								<td width="12%">&nbsp;<%=sr19_0no1%></td>
								<td colSpan="2">&nbsp;<%=Da19_0te1%></td>
								<td width="12%" colSpan="2">&nbsp;<%=A19_0ction1%></td>
								<td width="12%" colSpan="3">&nbsp;<%=D19_0etail1%></td>
							</tr>
							<tr>
								<td width="12%">&nbsp;<%=sr19_0no2%></td>
								<td colSpan="2">&nbsp;<%=Da19_0te2%></td>
								<td width="12%" colSpan="2">&nbsp;<%=A19_0ction2%></td>
								<td width="12%" colSpan="3">&nbsp;<%=D19_0etail2%></td>
							</tr>
							<tr>
								<td style="HEIGHT: 15px" width="12%">&nbsp;<%=sr19_0no3%></td>
								<td colSpan="2" style="HEIGHT: 15px">&nbsp;<%=Da19_0te3%></td>
								<td style="HEIGHT: 15px" width="12%" colSpan="2">&nbsp;<%=A19_0ction3%></td>
								<td style="HEIGHT: 15px" width="12%" colSpan="3">&nbsp;<%=D19_0etail3%></td>
							</tr>
							<tr>
								<td style="HEIGHT: 13px" width="12%">&nbsp;<%=sr19_0no4%></td>
								<td colSpan="2" style="HEIGHT: 13px">&nbsp;<%=Da19_0te4%></td>
								<td style="HEIGHT: 13px" width="12%" colSpan="2">&nbsp;<%=A19_0ction4%></td>
								<td style="HEIGHT: 13px" width="12%" colSpan="3">&nbsp;<%=D19_0etail4%></td>
							</tr>
							<tr>
								<td width="12%" style="HEIGHT: 14px">&nbsp;<%=sr19_0no5%></td>
								<td colSpan="2" style="HEIGHT: 14px">&nbsp;<%=Da19_0te5%></td>
								<td width="12%" colSpan="2" style="HEIGHT: 14px">&nbsp;<%=A19_0ction5%></td>
								<td width="12%" colSpan="3" style="HEIGHT: 14px">&nbsp;<%=D19_0etail5%></td>
							</tr>
							<tr>
								<td width="12%" colSpan="8"><b>&nbsp; 20.0 Details of Pending Action Points</b></td>
							</tr>
							<tr>
								<td align="center" width="12%"><STRONG>Sr. No</STRONG></td>
								<td align="center" width="12%" colspan="2"><STRONG>Date</STRONG></td>
								<td align="center" width="12%" colSpan="2"><STRONG>Action Plan</STRONG></td>
								<td width="12%" colSpan="3"><STRONG>Details of action Taken</STRONG></td>
							</tr>
							<tr>
								<td width="12%">&nbsp;<%=sr20_0no1%></td>
								<td colSpan="2">&nbsp;<%=Da20_0te1%><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txt20_0Date1);return false;"></A></td>
								<td width="12%" colSpan="2">&nbsp;<%=A20_0ction1%></td>
								<td width="12%" colSpan="3">&nbsp;<%=D20_0etail1%></td>
							</tr>
							<tr>
								<td width="12%">&nbsp;<%=sr20_0no2%></td>
								<td colSpan="2">&nbsp;<%=Da20_0te2%><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txt20_0Date1);return false;"></A></td>
								<td width="12%" colSpan="2">&nbsp;<%=A20_0ction2%></td>
								<td width="12%" colSpan="3">&nbsp;<%=D20_0etail2%></td>
							</tr>
							<tr>
								<td width="12%">&nbsp;<%=sr20_0no3%></td>
								<td colSpan="2">&nbsp;<%=Da20_0te3%><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txt20_0Date1);return false;"></A></td>
								<td width="12%" colSpan="2">&nbsp;<%=A20_0ction3%></td>
								<td width="12%" colSpan="3">&nbsp;<%=D20_0etail3%></td>
							</tr>
							<tr>
								<td width="12%">&nbsp;<%=sr20_0no4%></td>
								<td colSpan="2">&nbsp;<%=Da20_0te4%><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txt20_0Date1);return false;"></A></td>
								<td width="12%" colSpan="2">&nbsp;<%=A20_0ction4%></td>
								<td width="12%" colSpan="3">&nbsp;<%=D20_0etail4%></td>
							</tr>
							<tr>
								<td width="12%">&nbsp;<%=sr20_0no5%></td>
								<td colSpan="2">&nbsp;<%=Da20_0te5%><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.txt20_0Date1);return false;"></A></td>
								<td width="12%" colSpan="2">&nbsp;<%=A20_0ction5%></td>
								<td width="12%" colSpan="3">&nbsp;<%=D20_0etail5%></td>
							</tr>
							<tr>
								<td align="right" width="12%" colSpan="5"><STRONG>Signature of Inspecting IOC of 
										Official</STRONG></td>
								<td width="12%" colSpan="3">&nbsp;<%=SignIOC%></td>
							</tr>
							<tr>
								<td width="12%" colSpan="5">&nbsp;</td>
								<td width="12%" colSpan="3"><STRONG>&nbsp;Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</STRONG><%=IOCName%>
								</td>
							</tr>
							<tr>
								<td width="12%" colSpan="5"><STRONG>&nbsp; Signature Of Dealer </STRONG>
								</td>
								<td width="12%" colSpan="3">&nbsp;<STRONG>Designation</STRONG>&nbsp;&nbsp;<%=IOCdesign%>
								</td>
							</tr>
							<tr>
								<td width="12%" colSpan="5">&nbsp;<%=SOD%></td>
								<td width="12%" colSpan="3">&nbsp;<STRONG>Date&nbsp;</STRONG>&nbsp;
									<%=IOCDate%>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="ipopeng.htm" frameBorder="0" width="174" scrolling="no"
				height="189"></IFRAME>
		</form>
	</BODY>
</HTML>
