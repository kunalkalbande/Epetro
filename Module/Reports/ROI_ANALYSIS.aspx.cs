/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/

using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using RMG;
using EPetro.Sysitem.Classes ;


namespace EPetro
{
	/// <summary>
	/// Summary description for ROI_Analysis Report.
	/// </summary>
	public class ROI_ANALYSIS : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chkasite;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chkCategoryss;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chkPartnership;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSalesPerformanceDate;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCummulativeuptoDate;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLubesTarget1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLubesTarget2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtGreaseTarget1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtGreaseTarget2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFratioTarget1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCMS1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4avgsaleMS;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AMakeNo5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5ACuuReadNo5;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk12a_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk12b_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk12c_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk12e_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13a_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13b_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13c_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13d_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13e_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13f_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13g_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13h_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13i_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13j_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13k_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13l_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13m_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13n_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13o_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13q_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13r_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13s_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13t_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13u_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13v_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt13_nature;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14a1_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14a2_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14a3_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14a4_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14a5_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14a6_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14b1_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14b2_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14b3_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14b4_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14b5_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk14b6_Y;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c1_C;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c1_S;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c1_E;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c2_C;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c2_S;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c2_E;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c3_C;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c3_S;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c3_E;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c4_C;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c4_S;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c4_E;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c5_C;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c5_S;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c5_E;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c6_C;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c6_S;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk14c6_E;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16a_Y;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chkbsite;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chkcoco;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chkCategoryfs;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chkProprietorship;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chkOthers;
		protected System.Web.UI.WebControls.TextBox txtDivisionOff;
		protected System.Web.UI.HtmlControls.HtmlInputText txtDistrict;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMSTarget1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMScyear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMSLyear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMSTarget2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMSCyear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtMSLyear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHSDTarget1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHSDCYear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHSDLYear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHSDTarget2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHSDCYear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHSDLYear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLubesCYear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLubesLYear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLubesCYear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLubesLYear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtGreaseCYear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtGreaseLYear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtGreaseCYear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtGreaseLYear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFratioCYear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFratioLYear1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFratioTarget2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFratioCYear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLFratioLyear2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCHSD1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCMS2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCHSD2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCMS3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCHSD3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOMCMS1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOMCHSD1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOMCMS2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOMCHSD2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOMCMS3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOMCHSD3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTOTALMS1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTOTALHSD1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTOTALMS2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTOTALHSD2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTOTALMS3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtTOTALHSD3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtReasonLH_taAvgMS;
		protected System.Web.UI.HtmlControls.HtmlInputText txtReasonLH_taAvgHSD;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkNewRoTrAY;
		protected System.Web.UI.HtmlControls.HtmlInputText txt3a;
		protected System.Web.UI.HtmlControls.HtmlInputText txt3b;
		protected System.Web.UI.HtmlControls.HtmlInputText txt3bdatepk;
		protected System.Web.UI.HtmlControls.HtmlInputText txt3c;
		protected System.Web.UI.HtmlControls.HtmlInputText txt3cdatepk;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4avgsaleHSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4avgsaleLUBES;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4NilSaleaMS;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4NilSaleaHSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4NilSaleaLUBES;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4DryOutMS;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4DryOutHSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4DryOutLUBES;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AProNo1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AProNo2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AProNo3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AProNo4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AProNo5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AProNo6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AMakeNo1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AMakeNo2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AMakeNo3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AMakeNo6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5ACuuReadNo1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5ACuuReadNo2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5ACuuReadNo3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5ACuuReadNo4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5ACuuReadNo6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APrevReadNo1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APrevReadNo2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APrevReadNo3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APrevReadNo4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APrevReadNo5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APrevReadNo6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APerMETReadNo1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APerMETReadNo2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APerMETReadNo3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APerMETReadNo4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APerMETReadNo5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5APerMETReadNo6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BStockonlastDtMS93;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BStockonlastDtMS87;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BStockonlastDtMSulp;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BStockonlastDtHSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BReceiptKL_MS93;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BReceiptKL_MS87;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BReceiptKL_MSULP;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BReceiptKL_HSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTotalstkMS93;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTotalstkMS87;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTotalstkMSULP;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTotalstkHSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTLessstkMS93;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTLessstkMS87;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTLessstkMSULP;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTLessstkHSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTotSalesMS93;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTotSalesMS87;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTotSalesMSULP;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BTotSalesHSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BVariationMS93;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BVariationMS87;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BVariationMSULP;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5BVariationHSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adqbarrel1_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adqbarrel2_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adqbarrel3_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Smallpck1_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Smallpck2_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Smallpck3_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adqbarrel1_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adqbarrel2_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adqbarrel3_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adSmallpck1_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adSmallpck2_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6adSmallpck3_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Inadqbarrel1_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Inadqbarrel2_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Inadqbarrel3_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6InSmallpck1_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6InSmallpck2_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6InSmallpck3_0;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Inadqbarrel1_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Inadqbarrel2_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6Inadqbarrel3_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6InSmallpck1_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6InSmallpck2_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt6InSmallpck3_1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub1_yr;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub1_amt;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub2_yr;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub2_amt;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub3_yr;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub3_amt;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub4_yr;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub4_amt;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub5_yr;
		protected System.Web.UI.HtmlControls.HtmlInputText txt7DetailSub5_amt;
		protected System.Web.UI.HtmlControls.HtmlInputText txt8Dealersugggestion;
		protected System.Web.UI.HtmlControls.HtmlInputText txt9MarInfo;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_1C_y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_1d_y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_1e_y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_1f_y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt10_1f;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_1g_y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt10_1g;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_2a_good;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_2b_good;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_2c_y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt10_3_aDate;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_3b_y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_3c_y;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3d_Ex;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3d_Vg;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3d_G;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3d_Av;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3e_Ex;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3e_Vg;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3e_G;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3e_Av;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4a_Ex;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4a_Vg;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4a_G;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4a_Av;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4b_Ex;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4b_Vg;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4b_G;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4b_Av;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4c_Ex;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4c_Vg;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4c_G;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4c_Av;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4d_Ex;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4d_Vg;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4d_G;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4d_Av;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_5a_Ex;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_5a_Vg;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_5a_G;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_5a_Av;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_5b_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_5c_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_5d_Y;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_6a_Ex;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_6a_Vg;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_6a_G;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_6a_Av;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_6b_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_6c_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt10_6c;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_7a_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_7b_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_7c_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_7d_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk12d_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13p_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15aT1_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15aT2_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15aT3_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15aT4_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15bT1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15bT2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15bT3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15bT4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15cT1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15cT2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15cT3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15cT4;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15dT1_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15dT2_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15dT3_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15dT4_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15eT1_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15eT2_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15eT3_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk15eT4_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16bT1_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16bT2_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16bT3_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16bT4_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16cT1_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16cT2_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16cT3_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16cT4_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16dT1_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16dT2_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16dT3_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk16dT4_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt17a_Date;
		protected System.Web.UI.HtmlControls.HtmlInputText txt17a_Result;
		protected System.Web.UI.HtmlControls.HtmlInputText txt17b_Date;
		protected System.Web.UI.HtmlControls.HtmlInputText txt17b_Result;
		protected System.Web.UI.HtmlControls.HtmlInputText txt17c_Date;
		protected System.Web.UI.HtmlControls.HtmlInputText txt17c_Result;
		protected System.Web.UI.HtmlControls.HtmlInputText txt17MS;
		protected System.Web.UI.HtmlControls.HtmlInputText txt17HSD;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_1_Comm;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_2_Transport;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_2_Pending;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_2_Action;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_3_product;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk18_3product_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_3_quality;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk18_3quality_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_3_Invoice;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk18_3invoice_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_3_amount;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk18_3amount_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_4_product;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk18_4product_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_4_quantity;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk18_4quantity_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_4_Invoice;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk18_4invoice_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_4_amount;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk18_4amount_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_4_action;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5a;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5bN1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5bN2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5bN3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5bN4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5bN5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5bN6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5cN1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5cN2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5cN4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5cN5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5dN1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5dN2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5dN3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5dN4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5dN5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5dN6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5eN1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5eN2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5eN3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5eN4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5eN5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5eN6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5fN1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5fN2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5fN3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5fN4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5fN5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5fN6;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5_reasons;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_6aAvg;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_6bNumber;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Date1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Action1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Detail1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0srno2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Date2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Action2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Detail2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0srno3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Date3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Action3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Detail3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0srno4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Date4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Action4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Detail4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0srno5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Date5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Action5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0Detail5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0srno1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Date1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Action1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Detail1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0srno2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Date2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Action2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Detail2;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0srno3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Date3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Action3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Detail3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0srno4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Date4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Action4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Detail4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0srno5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Date5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Action5;
		protected System.Web.UI.HtmlControls.HtmlInputText txt20_0Detail5;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSignIOC;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCName;
		protected System.Web.UI.HtmlControls.HtmlInputText txtSOD;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCdesign;
		protected System.Web.UI.HtmlControls.HtmlInputText txtIOCDate;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.HtmlControls.HtmlImage Img1;
		protected System.Web.UI.HtmlControls.HtmlImage Img2;
		protected System.Web.UI.HtmlControls.HtmlImage Img3;
		protected System.Web.UI.HtmlControls.HtmlImage Img4;
		protected System.Web.UI.HtmlControls.HtmlImage Img5;
		protected System.Web.UI.HtmlControls.HtmlImage Img6;
		protected System.Web.UI.HtmlControls.HtmlImage Img7;
		protected System.Web.UI.HtmlControls.HtmlImage Img8;
		protected System.Web.UI.HtmlControls.HtmlImage Img9;
		protected System.Web.UI.HtmlControls.HtmlImage Img10;
		protected System.Web.UI.HtmlControls.HtmlImage Img11;
		protected System.Web.UI.HtmlControls.HtmlImage Img12;
		protected System.Web.UI.HtmlControls.HtmlImage Img13;
		protected System.Web.UI.HtmlControls.HtmlImage Img14;
		protected System.Web.UI.HtmlControls.HtmlImage Img15;
		protected System.Web.UI.HtmlControls.HtmlImage Img16;
		protected System.Web.UI.HtmlControls.HtmlImage Img17;
		protected System.Web.UI.HtmlControls.HtmlImage Img18;
		protected System.Web.UI.HtmlControls.HtmlImage Img19;
		protected System.Web.UI.HtmlControls.HtmlImage Img20;
		protected System.Web.UI.HtmlControls.HtmlImage Img21;
		protected System.Web.UI.HtmlControls.HtmlImage Img22;
		protected System.Web.UI.HtmlControls.HtmlImage Img23;
		protected System.Web.UI.HtmlControls.HtmlImage Img36;
		protected System.Web.UI.HtmlControls.HtmlImage Img37;
		protected System.Web.UI.HtmlControls.HtmlImage Img38;
		protected System.Web.UI.HtmlControls.HtmlImage Img24;
		protected System.Web.UI.HtmlControls.HtmlImage Img25;
		protected System.Web.UI.HtmlControls.HtmlImage Img26;
		protected System.Web.UI.HtmlControls.HtmlImage Img27;
		protected System.Web.UI.HtmlControls.HtmlImage Img28;
		protected System.Web.UI.HtmlControls.HtmlImage Img29;
		protected System.Web.UI.HtmlControls.HtmlImage Img30;
		protected System.Web.UI.HtmlControls.HtmlImage Img31;
		protected System.Web.UI.HtmlControls.HtmlImage Img32;
		protected System.Web.UI.HtmlControls.HtmlImage Img33;
		protected System.Web.UI.HtmlControls.HtmlImage Img34;
		protected System.Web.UI.HtmlControls.HtmlImage Img35;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtarea4NilSalesDryout;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtarea5BReasonVar;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnSave;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtareaDLnameaddr;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5AMakeNo4;
		protected System.Web.UI.HtmlControls.HtmlInputText txt10_1B;
		protected System.Web.UI.HtmlControls.HtmlInputText txt15f;
		protected System.Web.UI.HtmlControls.HtmlInputText txt16_Detail;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13x_Y;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk13w_Y;
		protected System.Web.UI.HtmlControls.HtmlInputText txt13g;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_6cActionplan;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5cN3;
		protected System.Web.UI.HtmlControls.HtmlInputText txt18_5cN6;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnEdit;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnPrint;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt3adatepk;
		
		//Declaration

		string asite="";
		string bsite="";
		string coco="";
		string catss="";
		string catfs="";
		string partship="";
		string proship="";
		string other=""; 
		string newro="";
		string c10_1g_y="";
		string c10_1A_Y="";
		string c10_3d_Ex="";
		string c10_1f_y="";
		string c10_1C_y="";
		string c10_1d_y="";
		string c10_1e_y="";
		string c10_2a_good="";
		string c10_2b_good="";
		string c10_2c_y="";
		string c10_3b_y="";
		string c10_3c_y="";
		string c10_3d_Vg="";
		string c10_3d_G="";
		string c10_4a_Vg="";				
		string c10_4a_G="";
		string c10_4a_Av="";
		string c10_5a_G="";
		string c10_5a_Av="";
		string c10_5a_P="";
		string c10_5b_Y="";
		string c10_5c_Y="";
		string c10_5d_Y="";
		string c10_6a_Ex="";
		string c10_6a_Vg="";
		string c10_6a_G="";
		string c10_6a_Av="";
		string c10_6a_P="";
		string c10_6b_Y="";
		string c10_6c_Y="";
		string c10_4a_P="";
		string c10_4b_Ex="";
		string c10_4b_Vg="";
		string c10_4b_G="";
		string c10_4b_Av="";
		string c10_4b_P="";
		string c10_4c_Ex="";
		string c10_4c_Vg="";
		string c10_4c_G="";
		string c10_4c_Av="";
		string c10_4c_P="";
		string c10_4d_Ex="";
		string c10_4d_Vg="";
		string c10_4d_G="";
		string c10_4d_P="";
		string c10_4d_Av="";
		string c10_5a_Ex="";
		string c10_5a_Vg="";
		string c10_3d_Av="";
		string c10_3d_P="";
		string c10_3e_Ex="";
		string c10_3e_Vg="";
		string c10_3e_G="";
		string c10_3e_Av="";
		string c10_3e_P="";
		string c10_4a_Ex="";		
		string c10_7a_Y="";
		string c10_7b_Y="";
		string Qty18_3="";					
		string Pro18_3="";
		string Inv18_3="";
		string Amt18_3="";
		string Pro18_4="";
		string Qty18_4="";
		string Inv18_4="";
		string Amt18_4="";
		string c10_7c_Y="";
		string c10_7d_Y="";
		string c12a_Y="";
		string c12b_Y="";
		string c12c_Y="";
		string c12d_Y="";
		string c12e_Y="";
		string c13a_Y="";
		string c13b_Y="";
		string c13c_Y="";
		string c13d_Y="";
		string c13e_Y="";
		string c13f_Y="";
		string c13g_Y="";
		string c13h_Y="";
		string c13i_Y="";
		string c13j_Y="";
		string c13k_Y="";
		string c13l_Y="";
		string c13m_Y="";
		string c13n_Y="";
		string c13o_Y="";
		string c13p_Y="";
		string c13q_Y="";
		string c13r_Y="";
		string c13s_Y="";
		string c13t_Y="";
		string c13u_Y="";
		string c13v_Y="";
		string c13w_Y="";
		string c13x_Y="";
		string c14a1_Y="";
		string c14a2_Y="";
		string c14a3_Y="";
		string c14a4_Y="";
		string c14a5_Y="";
		string c14a6_Y="";
		string c14b1_Y="";
		string c14b2_Y="";
		string c14b3_Y="";
		string c14b4_Y="";
		string c14b5_Y="";
		string c14b6_Y="";
		string c14c1_C="";
		string c14c1_S="";
		string c14c1_E="";
		string c14c2_C="";
		string c14c2_S="";
		string c14c2_E="";
		string c14c3_C="";
		string c14c3_S="";
		string c14c3_E="";
		string c14c4_C="";
		string c14c4_S="";
		string c14c4_E="";
		string c14c5_C="";
		string c14c5_S="";
		string c14c5_E="";
		string c14c6_C="";
		string c14c6_S="";
		string c14c6_E="";
		string c15aT1_Y="";
		string c15aT2_Y="";
		string c15aT3_Y="";
		string c15aT4_Y="";
		string c15dT1_Y="";
		string c15dT2_Y="";
		string c15dT3_Y="";
		string c15dT4_Y="";
		string c15eT1_Y="";
		string c15eT2_Y="";
		string c15eT3_Y="";
		string c15eT4_Y="";
		string c16a_Y="";
		string c16bT1_Y="";
		string c16bT2_Y="";
		string c16bT3_Y="";
		string c16bT4_Y="";
		string c16cT1_Y="";
		string c16cT2_Y="";
		string c16cT3_Y="";
		string c16cT4_Y="";
		string c16dT1_Y="";
		string c16dT2_Y="";
		string c16dT3_Y="";
		protected System.Web.UI.HtmlControls.HtmlInputButton btndelete;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_6a_P;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_5a_P;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4d_P;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4c_P;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4b_P;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_4a_P;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3e_P;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton chk10_3d_P;
		protected System.Web.UI.WebControls.TextBox txtroiid;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk10_1A_Y;
		protected System.Web.UI.HtmlControls.HtmlTable Table6;
		protected System.Web.UI.HtmlControls.HtmlTable Table5;
		protected System.Web.UI.HtmlControls.HtmlTable Table4;
		protected System.Web.UI.HtmlControls.HtmlTable Table3;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlTable Table1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt5bstdate;
		protected System.Web.UI.HtmlControls.HtmlImage Img39;
		protected System.Web.UI.HtmlControls.HtmlImage Img40;
		protected System.Web.UI.HtmlControls.HtmlInputText txt19_0srno1;
		protected System.Web.UI.HtmlControls.HtmlInputText txt4tba;
		protected System.Web.UI.HtmlControls.HtmlInputText txtpro15t1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtpro15t2;
		protected System.Web.UI.HtmlControls.HtmlInputText txtpro15t3;
		protected System.Web.UI.HtmlControls.HtmlInputText txtpro15t4;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnreset;
		protected System.Web.UI.WebControls.Button btnbrw;
		string c16dT4_Y="";
		string uid = "";

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				uid=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:pageload()   EXCEPTION "+ ex.Message+"  userid  "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
			txtDate.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txtSalesPerformanceDate.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txtCummulativeuptoDate.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt3adatepk.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt3bdatepk.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt3cdatepk.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt5bstdate.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt10_3_aDate.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt17a_Date.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt17b_Date.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt17c_Date.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5eN1.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5eN2.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5eN3.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5eN4.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5eN5.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5eN6.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5fN1.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5fN2.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5fN3.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5fN4.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5fN5.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt18_5fN6.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt19_0Date1.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt19_0Date2.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt19_0Date3.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt19_0Date4.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt19_0Date5.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt20_0Date1.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt20_0Date2.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt20_0Date3.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt20_0Date4.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txt20_0Date5.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			txtIOCDate.Value=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
			
			try
			{
				if(!IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="27";
					string[,] Priv=(string[,]) Session["Privileges"];
					for(i=0;i<Priv.GetLength(0);i++)
					{
						if(Priv[i,0]== Module &&  Priv[i,1]==SubModule)
						{						
							View_flag=Priv[i,2];
							Add_Flag=Priv[i,3];
							Edit_Flag=Priv[i,4];
							Del_Flag=Priv[i,5];
							break;
						}
					}	
					if(View_flag=="0" && Add_Flag =="0" && Edit_Flag == "0" && Del_Flag == "0")
					{
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					}
					#endregion
				
					getNextID();
					btnSave.Disabled=false;
					btnEdit.Disabled=true;
					btndelete.Disabled=true;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:pageload()  EXCEPTION "+ ex.Message+"  userid  "+uid);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.btnbrw.Click += new System.EventHandler(this.btnbrw_Click);
			this.btnSave.ServerClick += new System.EventHandler(this.btnSave_ServerClick);
			this.btnEdit.ServerClick += new System.EventHandler(this.btnEdit_ServerClick);
			this.btndelete.ServerClick += new System.EventHandler(this.btndelete_ServerClick);
			this.btnPrint.ServerClick += new System.EventHandler(this.btnPrint_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This method is used to Generate automatically Next ID (as ROIID).
		/// </summary>
		public void getNextID()
		{
			try
			{
				SqlConnection	con  = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
				con.Open();	
				string str1="select max(ROIID)+1 from ROI_ANALYSIS";
				SqlCommand	scom  = new SqlCommand( str1 ,con  );
				SqlDataReader rd= scom.ExecuteReader();
				string r_id="";
				if(rd.Read())
				{
					r_id=rd.GetValue(0).ToString();
				}
				if(r_id.Equals(""))
					r_id="1";
				txtroiid.Text=(r_id);
				con.Close();
				scom.Dispose();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:getNextID()  EXCEPTION "+ ex.Message+"  userid  "+uid);
			}
		}

        /// <summary>
        /// This method is used to insert the record in DataBase.
        /// </summary>
		public void Save()
		{
			SqlConnection	con  = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			con.Open();	
			try
			{
				//  CheckBox is checked then return 1,0 for unchecked.

				if(chkasite.Checked.Equals(true))
				{
					asite="1";
				}
				else
				{
					asite="0";
				}
				if(chkbsite.Checked.Equals(true))
				{
					bsite="1";
				}
				else
				{
					bsite="0";
				}
				if(chkcoco.Checked.Equals(true))
				{
					coco="1";
				}
				else
				{
					coco="0";
				}
				if(chkCategoryss.Checked.Equals(true))
				{
					catss="1";
				}
				else
				{
					catss="0";
				}
				if(chkCategoryfs.Checked.Equals(true))
				{
					catfs="1";
				}
				else
				{
					catfs="0";
				}
				if(chkOthers.Checked.Equals(true))
				{
					other="1";
				}
				else
				{
					other="0";
				}
				if(chkNewRoTrAY.Checked.Equals(true))
				{
					newro="1";
				}
				else
				{
					newro="0";
				}
				if(chkPartnership.Checked.Equals(true))
				{
					partship="1";
				}
				else
				{
					partship="0";
				}
				if(chkProprietorship.Checked.Equals(true))
				{
					proship="1";
				}
				else
				{
					proship="0";
				}
				string d1 =txtDate.Text;
				string d2=txtCummulativeuptoDate.Value;;
				string d3=txt3adatepk.Value;
				string d4=txt3bdatepk.Value;
				string d5=txt3cdatepk.Value;

				// Return Date in MM/DD/YYYY for Display and Print Input is DD/MM/YYYY
			
				if(!d1.Equals(""))
				{
					string[] strTokens = d1.Split(new char[] {'/'},d1.Length);
					d1=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				if(!d2.Equals(""))
				{
					string[] strTokens = d2.Split(new char[] {'/'},d2.Length);
					d2=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				if(!d3.Equals(""))
				{
					string[] strTokens = d3.Split(new char[] {'/'},d3.Length);
					d3=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				if(!d4.Equals(""))
				{
					string[] strTokens = d4.Split(new char[] {'/'},d4.Length);
					d4=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				if(!d5.Equals(""))
				{
					string[] strTokens = d5.Split(new char[] {'/'},d5.Length);
					d5=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				
				//  CheckBox is checked then return 1,0 for unchecked.
				if(chk10_1A_Y.Checked.Equals(true))
				{
					c10_1A_Y="1";
				}
				else
				{
					c10_1A_Y="0";
				}
				if(chk10_1C_y.Checked.Equals(true))
				{
					c10_1C_y="1";
				}
				else
				{
					c10_1C_y="0";
				}
				if(chk10_1d_y.Checked.Equals(true))
				{
					c10_1d_y="1";
				}
				else
				{
					c10_1d_y="0";
				}
			
			
				if(chk10_1e_y.Checked.Equals(true))
				{
					c10_1e_y="1";
				}
				else
				{
					c10_1e_y="0";
				}
			
				if(chk10_1f_y.Checked.Equals(true))
				{
					c10_1f_y="1";
				}
				else
				{
					c10_1f_y="0";
				}
				if(chk10_1g_y.Checked.Equals(true))
				{
					c10_1g_y="1";
				}
				else
				{
					c10_1g_y="0";
				}
			
				if(chk10_2a_good.Checked.Equals(true))
				{
					c10_2a_good="1";
				}
				else
				{
					c10_2a_good="0";
				}
				if(chk10_2b_good.Checked.Equals(true))
				{
					c10_2b_good="1";
				}
				else
				{
					c10_2b_good="0";
				}
			
				if(chk10_2c_y.Checked.Equals(true))
				{
					c10_2c_y="1";
				}
				else
				{
					c10_2c_y="0";
				}
				if(chk10_3b_y.Checked.Equals(true))
				{
					c10_3b_y="1";
				}
				else
				{
					c10_3b_y="0";
				}
				if(chk10_3c_y.Checked.Equals(true))
				{
					c10_3c_y="1";
				}
				else
				{
					c10_3c_y="0";
				}
				if(chk10_3d_Ex.Checked.Equals(true))
				{
					c10_3d_Ex="1";
				}
				else
				{
					c10_3d_Ex="0";
				}
				if(chk10_3d_Vg.Checked.Equals(true))
				{
					c10_3d_Vg="1";
				}
				else
				{
					c10_3d_Vg="0";
				}
				if(chk10_3d_G.Checked.Equals(true))
				{
					c10_3d_G="1";
				}
				else
				{
					c10_3d_G="0";
				}
				if(chk10_3d_Av.Checked.Equals(true))
				{
					c10_3d_Av="1";
				}
				else
				{
					c10_3d_Av="0";
				}
				if(chk10_3d_P.Checked.Equals(true))
				{
					c10_3d_P="1";
				}
				else
				{
					c10_3d_P="0";
				}
				if(chk10_3e_Ex.Checked.Equals(true))
				{
					c10_3e_Ex="1";
				}
				else
				{
					c10_3e_Ex="0";
				}
				if(chk10_3e_Vg.Checked.Equals(true))
				{
					c10_3e_Vg="1";
				}
				else
				{
					c10_3e_Vg="0";
				}
				if(chk10_3e_G.Checked.Equals(true))
				{
					c10_3e_G="1";
				}
				else
				{
					c10_3e_G="0";
				}
				if(chk10_3e_Av.Checked.Equals(true))
				{
					c10_3e_Av="1";
				}
				else
				{
					c10_3e_Av="0";
				}
				if(chk10_3e_P.Checked.Equals(true))
				{
					c10_3e_P="1";
				}
				else
				{
					c10_3e_P="0";
				}
				if(chk10_4a_Ex.Checked.Equals(true))
				{
					c10_4a_Ex="1";
				}
				else
				{
					c10_4a_Ex="0";
				}
				if(chk10_4a_Vg.Checked.Equals(true))
				{
					c10_4a_Vg="1";
				}
				else
				{
					c10_4a_Vg="0";
				}
				if(chk10_4a_G.Checked.Equals(true))
				{
					c10_4a_G="1";
				}
				else
				{
					c10_4a_G="0";
				}
				if(chk10_4a_Av.Checked.Equals(true))
				{
					c10_4a_Av="1";
				}
				else
				{
					c10_4a_Av="0";
				}
				if(chk10_4a_P.Checked.Equals(true))
				{
					c10_4a_P="1";
				}
				else
				{
					c10_4a_P="0";
				}
				if(chk10_4b_Ex.Checked.Equals(true))
				{
					c10_4b_Ex="1";
				}
				else
				{
					c10_4b_Ex="0";
				}
				if(chk10_4b_Vg.Checked.Equals(true))
				{
					c10_4b_Vg="1";
				}
				else
				{
					c10_4b_Vg="0";
				}
				if(chk10_4b_G.Checked.Equals(true))
				{
					c10_4b_G="1";
				}
				else
				{
					c10_4b_G="0";
				}
				if(chk10_4b_Av.Checked.Equals(true))
				{
					c10_4b_Av="1";
				}
				else
				{
					c10_4b_Av="0";
				}
				if(chk10_4b_P.Checked.Equals(true))
				{
					c10_4b_P="1";
				}
				else
				{
					c10_4b_P="0";
				}
				if(chk10_4c_Ex.Checked.Equals(true))
				{
					c10_4c_Ex="1";
				}
				else
				{
					c10_4c_Ex="0";
				}
				if(chk10_4c_Vg.Checked.Equals(true))
				{
					c10_4c_Vg="1";
				}
				else
				{
					c10_4c_Vg="0";
				}
				if(chk10_4c_G.Checked.Equals(true))
				{
					c10_4c_G="1";
				}
				else
				{
					c10_4c_G="0";
				}
				if(chk10_4c_Av.Checked.Equals(true))
				{
					c10_4c_Av="1";
				}
				else
				{
					c10_4c_Av="0";
				}
				if(chk10_4c_P.Checked.Equals(true))
				{
					c10_4c_P="1";
				}
				else
				{
					c10_4c_P="0";
				}
				if(chk10_4d_Ex.Checked.Equals(true))
				{
					c10_4d_Ex="1";
				}
				else
				{
					c10_4d_Ex="0";
				}
				if(chk10_4d_Vg.Checked.Equals(true))
				{
					c10_4d_Vg="1";
				}
				else
				{
					c10_4d_Vg="0";
				}
				if(chk10_4d_G.Checked.Equals(true))
				{
					c10_4d_G="1";
				}
				else
				{
					c10_4d_G="0";
				}
				if(chk10_4d_Av.Checked.Equals(true))
				{
					c10_4d_Av="1";
				}
				else
				{
					c10_4d_Av="0";
				}
				if(chk10_4d_P.Checked.Equals(true))
				{
					c10_4d_P="1";
				}
				else
				{
					c10_4d_P="0";
				}
				if(chk10_5a_Ex.Checked.Equals(true))
				{
					c10_5a_Ex="1";
				}
				else
				{
					c10_5a_Ex="0";
				}
				if(chk10_5a_Vg.Checked.Equals(true))
				{
					c10_5a_Vg="1";
				}
				else
				{
					c10_5a_Vg="0";
				}
				if(chk10_5a_G.Checked.Equals(true))
				{
					c10_5a_G="1";
				}
				else
				{
					c10_5a_G="0";
				}
				if(chk10_5a_Av.Checked.Equals(true))
				{
					c10_5a_Av="1";
				}
				else
				{
					c10_5a_Av="0";
				}
				if(chk10_5a_P.Checked.Equals(true))
				{
					c10_5a_P="1";
				}
				else
				{
					c10_5a_P="0";
				}
				if(chk10_5b_Y.Checked.Equals(true))
				{
					c10_5b_Y="1";
				}
				else
				{
					c10_5b_Y="0";
				}
				if(chk10_5c_Y.Checked.Equals(true))
				{
					c10_5c_Y="1";
				}
				else
				{
					c10_5c_Y="0";
				}
				if(chk10_5d_Y.Checked.Equals(true))
				{
					c10_5d_Y="1";
				}
				else
				{
					c10_5d_Y="0";
				}
				if(chk10_6a_Ex.Checked.Equals(true))
				{
					c10_6a_Ex="1";
				}
				else
				{
					c10_6a_Ex="0";
				}
				if(chk10_6a_Vg.Checked.Equals(true))
				{
					c10_6a_Vg="1";
				}
				else
				{
					c10_6a_Vg="0";
				}
				if(chk10_6a_G.Checked.Equals(true))
				{
					c10_6a_G="1";
				}
				else
				{
					c10_6a_G="0";
				}
				if(chk10_6a_Av.Checked.Equals(true))
				{
					c10_6a_Av="1";
				}
				else
				{
					c10_6a_Av="0";
				}
				if(chk10_6a_P.Checked.Equals(true))
				{
					c10_6a_P="1";
				}
				else
				{
					c10_6a_P="0";
				}
				if(chk10_6b_Y.Checked.Equals(true))
				{
					c10_6b_Y="1";
				}
				else
				{
					c10_6b_Y="0";
				}
				if(chk10_6c_Y.Checked.Equals(true))
				{
					c10_6c_Y="1";
				}
				else
				{
					c10_6c_Y="0";
				}
				if(chk10_7a_Y.Checked.Equals(true))
				{
					c10_7a_Y="1";
				}
				else
				{
					c10_7a_Y="0";
				}
				if(chk10_7b_Y.Checked.Equals(true))
				{
					c10_7b_Y="1";
				}
				else
				{
					c10_7b_Y="0";
				}
				if(chk10_7c_Y.Checked.Equals(true))
				{
					c10_7c_Y="1";
				}
				else
				{
					c10_7c_Y="0";
				}
				if(chk10_7d_Y.Checked.Equals(true))
				{
					c10_7d_Y="1";
				}
				else
				{
					c10_7d_Y="0";
				}
				if(chk12a_Y.Checked.Equals(true))
				{
					c12a_Y="1";
				}
				else
				{
					c12a_Y="0";
				}
				if(chk12b_Y.Checked.Equals(true))
				{
					c12b_Y="1";
				}
				else
				{
					c12b_Y="0";
				}
				if(chk12c_Y.Checked.Equals(true))
				{
					c12c_Y="1";
				}
				else
				{
					c12c_Y="0";
				}
				if(chk12d_Y.Checked.Equals(true))
				{
					c12d_Y="1";
				}
				else
				{
					c12d_Y="0";
				}
				if(chk12e_Y.Checked.Equals(true))
				{
					c12e_Y="1";
				}
				else
				{
					c12e_Y="0";
				}
				if(chk13a_Y.Checked.Equals(true))
				{
					c13a_Y="1";
				}
				else
				{
					c13a_Y="0";
				}
				if(chk13b_Y.Checked.Equals(true))
				{
					c13b_Y="1";
				}
				else
				{
					c13b_Y="0";
				}
				if(chk13c_Y.Checked.Equals(true))
				{
					c13c_Y="1";
				}
				else
				{
					c13c_Y="0";
				}
				if(chk13d_Y.Checked.Equals(true))
				{
					c13d_Y="1";
				}
				else
				{
					c13d_Y="0";
				}
				if(chk13e_Y.Checked.Equals(true))
				{
					c13e_Y="1";
				}
				else
				{
					c13e_Y="0";
				}
				if(chk13f_Y.Checked.Equals(true))
				{
					c13f_Y="1";
				}
				else
				{
					c13f_Y="0";
				}
				if(chk13g_Y.Checked.Equals(true))
				{
					c13g_Y="1";
				}
				else
				{
					c13g_Y="0";
				}
				if(chk13h_Y.Checked.Equals(true))
				{
					c13h_Y="1";
				}
				else
				{
					c13h_Y="0";
				}
				if(chk13i_Y.Checked.Equals(true))
				{
					c13i_Y="1";
				}
				else
				{
					c13i_Y="0";
				}
				if(chk13j_Y.Checked.Equals(true))
				{
					c13j_Y="1";
				}
				else
				{
					c13j_Y="0";
				}
				if(chk13k_Y.Checked.Equals(true))
				{
					c13k_Y="1";
				}
				else
				{
					c13k_Y="0";
				}
				if(chk13l_Y.Checked.Equals(true))
				{
					c13l_Y="1";
				}
				else
				{
					c13l_Y="0";
				}
				if(chk13m_Y.Checked.Equals(true))
				{
					c13m_Y="1";
				}
				else
				{
					c13m_Y="0";
				}
				if(chk13n_Y.Checked.Equals(true))
				{
					c13n_Y="1";
				}
				else
				{
					c13n_Y="0";
				}
				if(chk13o_Y.Checked.Equals(true))
				{
					c13o_Y="1";
				}
				else
				{
					c13o_Y="0";
				}
				if(chk13p_Y.Checked.Equals(true))
				{
					c13p_Y="1";
				}
				else
				{
					c13p_Y="0";
				}
				if(chk13q_Y.Checked.Equals(true))
				{
					c13q_Y="1";
				}
				else
				{
					c13q_Y="0";
				}
				if(chk13r_Y.Checked.Equals(true))
				{
					c13r_Y="1";
				}
				else
				{
					c13r_Y="0";
				}
				if(chk13s_Y.Checked.Equals(true))
				{
					c13s_Y="1";
				}
				else
				{
					c13s_Y="0";
				}
				if(chk13t_Y.Checked.Equals(true))
				{
					c13t_Y="1";
				}
				else
				{
					c13t_Y="0";
				}
				if(chk13u_Y.Checked.Equals(true))
				{
					c13u_Y="1";
				}
				else
				{
					c13u_Y="0";
				}
				if(chk13v_Y.Checked.Equals(true))
				{
					c13v_Y="1";
				}
				else
				{
					c13v_Y="0";
				}
				if(chk13w_Y.Checked.Equals(true))
				{
					c13w_Y="1";
				}
				else
				{
					c13w_Y="0";
				}
				if(chk13x_Y.Checked.Equals(true))
				{
					c13x_Y="1";
				}
				else
				{
					c13x_Y="0";
				}
				if(chk14a1_Y.Checked.Equals(true))
				{
					c14a1_Y="1";
				}
				else
				{
					c14a1_Y="0";
				}
				if(chk14a2_Y.Checked.Equals(true))
				{
					c14a2_Y="1";
				}
				else
				{
					c14a2_Y="0";
				}
				if(chk14a3_Y.Checked.Equals(true))
				{
					c14a3_Y="1";
				}
				else
				{
					c14a3_Y="0";
				}
				if(chk14a4_Y.Checked.Equals(true))
				{
					c14a4_Y="1";
				}
				else
				{
					c14a4_Y="0";
				}
				if(chk14a5_Y.Checked.Equals(true))
				{
					c14a5_Y="1";
				}
				else
				{
					c14a5_Y="0";
				}
				if(chk14a6_Y.Checked.Equals(true))
				{
					c14a6_Y="1";
				}
				else
				{
					c14a6_Y="0";
				}
				if(chk14b1_Y.Checked.Equals(true))
				{
					c14b1_Y="1";
				}
				else
				{
					c14b1_Y="0";
				}
				if(chk14b2_Y.Checked.Equals(true))
				{
					c14b2_Y="1";
				}
				else
				{
					c14b2_Y="0";
				}
				if(chk14b3_Y.Checked.Equals(true))
				{
					c14b3_Y="1";
				}
				else
				{
					c14b3_Y="0";
				}
				if(chk14b4_Y.Checked.Equals(true))
				{
					c14b4_Y="1";
				}
				else
				{
					c14b4_Y="0";
				}
				if(chk14b5_Y.Checked.Equals(true))
				{
					c14b5_Y="1";
				}
				else
				{
					c14b5_Y="0";
				}
				if(chk14b6_Y.Checked.Equals(true))
				{
					c14b6_Y="1";
				}
				else
				{
					c14b6_Y="0";
				}
				if(chk14c1_C.Checked.Equals(true))
				{
					c14c1_C="1";
				}
				else
				{
					c14c1_C="0";
				}
				if(chk14c1_S.Checked.Equals(true))
				{
					c14c1_S="1";
				}
				else
				{
					c14c1_S="0";
				}
				if(chk14c1_E.Checked.Equals(true))
				{
					c14c1_E="1";
				}
				else
				{
					c14c1_E="0";
				}
				if(chk14c2_C.Checked.Equals(true))
				{
					c14c2_C="1";
				}
				else
				{
					c14c2_C="0";
				}
				if(chk14c2_S.Checked.Equals(true))
				{
					c14c2_S="1";
				}
				else
				{
					c14c2_S="0";
				}
				if(chk14c2_E.Checked.Equals(true))
				{
					c14c2_E="1";
				}
				else
				{
					c14c2_E="0";
				}
				if(chk14c3_C.Checked.Equals(true))
				{
					c14c3_C="1";
				}
				else
				{
					c14c3_C="0";
				}
				if(chk14c3_S.Checked.Equals(true))
				{
					c14c3_S="1";
				}
				else
				{
					c14c3_S="0";
				}
				if(chk14c3_E.Checked.Equals(true))
				{
					c14c3_E="1";
				}
				else
				{
					c14c3_E="0";
				}
				if(chk14c4_C.Checked.Equals(true))
				{
					c14c4_C="1";
				}
				else
				{
					c14c4_C="0";
				}
				if(chk14c4_S.Checked.Equals(true))
				{
					c14c4_S="1";
				}
				else
				{
					c14c4_S="0";
				}
				if(chk14c4_E.Checked.Equals(true))
				{
					c14c4_E="1";
				}
				else
				{
					c14c4_E="0";
				}
				if(chk14c5_C.Checked.Equals(true))
				{
					c14c5_C="1";
				}
				else
				{
					c14c5_C="0";
				}
				if(chk14c5_S.Checked.Equals(true))
				{
					c14c5_S="1";
				}
				else
				{
					c14c5_S="0";
				}
				if(chk14c5_E.Checked.Equals(true))
				{
					c14c5_E="1";
				}
				else
				{
					c14c5_E="0";
				}
				if(chk14c6_C.Checked.Equals(true))
				{
					c14c6_C="1";
				}
				else
				{
					c14c6_C="0";
				}
				if(chk14c6_S.Checked.Equals(true))
				{
					c14c6_S="1";
				}
				else
				{
					c14c6_S="0";
				}
				if(chk14c6_E.Checked.Equals(true))
				{
					c14c6_E="1";
				}
				else
				{
					c14c6_E="0";
				}
				if(chk15aT1_Y.Checked.Equals(true))
				{
					c15aT1_Y="1";
				}
				else
				{
					c15aT1_Y="0";
				}
				if(chk15aT2_Y.Checked.Equals(true))
				{
					c15aT2_Y="1";
				}
				else
				{
					c15aT2_Y="0";
				}
				if(chk15aT3_Y.Checked.Equals(true))
				{
					c15aT3_Y="1";
				}
				else
				{
					c15aT3_Y="0";
				}
				if(chk15aT4_Y.Checked.Equals(true))
				{
					c15aT4_Y="1";
				}
				else
				{
					c15aT4_Y="0";
				}
				if(chk15dT1_Y.Checked.Equals(true))
				{
					c15dT1_Y="1";
				}
				else
				{
					c15dT1_Y="0";
				}
				if(chk15dT2_Y.Checked.Equals(true))
				{
					c15dT2_Y="1";
				}
				else
				{
					c15dT2_Y="0";
				}
				if(chk15dT3_Y.Checked.Equals(true))
				{
					c15dT3_Y="1";
				}
				else
				{
					c15dT3_Y="0";
				}
				if(chk15dT4_Y.Checked.Equals(true))
				{
					c15dT4_Y="1";
				}
				else
				{
					c15dT4_Y="0";
				}
				if(chk15eT1_Y.Checked.Equals(true))
				{
					c15eT1_Y="1";
				}
				else
				{
					c15eT1_Y="0";
				}
				if(chk15eT2_Y.Checked.Equals(true))
				{
					c15eT2_Y="1";
				}
				else
				{
					c15eT2_Y="0";
				}
				if(chk15eT3_Y.Checked.Equals(true))
				{
					c15eT3_Y="1";
				}
				else
				{
					c15eT3_Y="0";
				}
				if(chk15eT4_Y.Checked.Equals(true))
				{
					c15eT4_Y="1";
				}
				else
				{
					c15eT4_Y="0";
				}
				if(chk16a_Y.Checked.Equals(true))
				{
					c16a_Y="1";
				}
				else
				{
					c16a_Y="0";
				}
				if(chk16bT1_Y.Checked.Equals(true))
				{
					c16bT1_Y="1";
				}
				else
				{
					c16bT1_Y="0";
				}
				if(chk16bT2_Y.Checked.Equals(true))
				{
					c16bT2_Y="1";
				}
				else
				{
					c16bT2_Y="0";
				}
				if(chk16bT3_Y.Checked.Equals(true))
				{
					c16bT3_Y="1";
				}
				else
				{
					c16bT3_Y="0";
				}
				if(chk16bT4_Y.Checked.Equals(true))
				{
					c16bT4_Y="1";
				}
				else
				{
					c16bT4_Y="0";
				}
				if(chk16cT1_Y.Checked.Equals(true))
				{
					c16cT1_Y="1";
				}
				else
				{
					c16cT1_Y="0";
				}
				if(chk16cT2_Y.Checked.Equals(true))
				{
					c16cT2_Y="1";
				}
				else
				{
					c16cT2_Y="0";
				}
				if(chk16cT3_Y.Checked.Equals(true))
				{
					c16cT3_Y="1";
				}
				else
				{
					c16cT3_Y="0";
				}
				if(chk16cT4_Y.Checked.Equals(true))
				{
					c16cT4_Y="1";
				}
				else
				{
					c16cT4_Y="0";
				}
				if(chk16dT1_Y.Checked.Equals(true))
				{
					c16dT1_Y="1";
				}
				else
				{
					c16dT1_Y="0";
				}
				if(chk16dT2_Y.Checked.Equals(true))
				{
					c16dT2_Y="1";
				}
				else
				{
					c16dT2_Y="0";
				}
				if(chk16dT3_Y.Checked.Equals(true))
				{
					c16dT3_Y="1";
				}
				else
				{
					c16dT3_Y="0";
				}
				if(chk16dT4_Y.Checked.Equals(true))
				{
					c16dT4_Y="1";
				}
				else
				{
					c16dT4_Y="0";
				}
							
							
				// Convert the date format dd/mm/yyyy to mm/dd/yyyy
			
				string a17Date=txt17a_Date.Value;
				if(!a17Date.Equals(""))
				{
					string[] strTokens = a17Date.Split(new char[] {'/'},a17Date.Length);
					a17Date=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string b17Date=txt17b_Date.Value;
				if(!b17Date.Equals(""))
				{
					string[] strTokens = b17Date.Split(new char[] {'/'},b17Date.Length);
					b17Date=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string st5bdate=txt5bstdate.Value;
				if(!st5bdate.Equals(""))
				{
					string[] strTokens = st5bdate.Split(new char[] {'/'},st5bdate.Length);
					st5bdate=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string c17Date=txt17a_Date.Value;
				if(!c17Date.Equals(""))
				{
					string[] strTokens = c17Date.Split(new char[] {'/'},c17Date.Length);
					c17Date=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string a10_3Date = txt10_3_aDate.Value;
				if(!a10_3Date.Equals(""))
				{
					string[] strTokens = a10_3Date.Split(new char[] {'/'},a10_3Date.Length);
					a10_3Date=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				
				string dat18_dn1=txt18_5dN1.Value;
				if(!dat18_dn1.Equals(""))
				{
					string[] strTokens = dat18_dn1.Split(new char[] {'/'},dat18_dn1.Length);
					dat18_dn1=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
			
				string dat18_dn2=txt18_5dN2.Value;
				if(!dat18_dn2.Equals(""))
				{
					string[] strTokens = dat18_dn2.Split(new char[] {'/'},dat18_dn2.Length);
					dat18_dn2=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_dn3=txt18_5dN3.Value;
				if(!dat18_dn3.Equals(""))
				{
					string[] strTokens = dat18_dn3.Split(new char[] {'/'},dat18_dn3.Length);
					dat18_dn3=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				txtSalesPerformanceDate.Value=GenUtil.str2DDMMYYYY(txtSalesPerformanceDate.Value.ToString());
				string dat18_dn4=txt18_5dN4.Value;
				if(!dat18_dn4.Equals(""))
				{
					string[] strTokens = dat18_dn4.Split(new char[] {'/'},dat18_dn4.Length);
					dat18_dn4=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_dn5=txt18_5dN5.Value;
				if(!dat18_dn5.Equals(""))
				{
					string[] strTokens = dat18_dn5.Split(new char[] {'/'},dat18_dn5.Length);
					dat18_dn5=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_dn6=txt18_5dN6.Value;
				if(!dat18_dn6.Equals(""))
				{
					string[] strTokens = dat18_dn6.Split(new char[] {'/'},dat18_dn6.Length);
					dat18_dn6=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_en1=txt18_5eN1.Value;
				if(!dat18_en1.Equals(""))
				{
					string[] strTokens = dat18_en1.Split(new char[] {'/'},dat18_en1.Length);
					dat18_en1=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_en2=txt18_5eN2.Value;
				if(!dat18_en2.Equals(""))
				{
					string[] strTokens = dat18_en2.Split(new char[] {'/'},dat18_en2.Length);
					dat18_en2=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_en3=txt18_5eN3.Value;
				if(!dat18_en3.Equals(""))
				{
					string[] strTokens = dat18_en3.Split(new char[] {'/'},dat18_en3.Length);
					dat18_en3=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_en4=txt18_5eN4.Value;
				if(!dat18_en4.Equals(""))
				{
					string[] strTokens = dat18_en4.Split(new char[] {'/'},dat18_en4.Length);
					dat18_en4=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_en5=txt18_5eN5.Value;
				if(!dat18_en5.Equals(""))
				{
					string[] strTokens = dat18_en5.Split(new char[] {'/'},dat18_en5.Length);
					dat18_en5=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_en6=txt18_5eN6.Value;
				if(!dat18_en6.Equals(""))
				{
					string[] strTokens = dat18_en6.Split(new char[] {'/'},dat18_en6.Length);
					dat18_en6=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_fn1=txt18_5fN1.Value;
				if(!dat18_fn1.Equals(""))
				{
					string[] strTokens = dat18_fn1.Split(new char[] {'/'},dat18_fn1.Length);
					dat18_fn1=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_fn2=txt18_5fN2.Value;
				if(!dat18_fn2.Equals(""))
				{
					string[] strTokens = dat18_fn2.Split(new char[] {'/'},dat18_fn2.Length);
					dat18_fn2=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_fn3=txt18_5fN3.Value;
				if(!dat18_fn3.Equals(""))
				{
					string[] strTokens = dat18_fn3.Split(new char[] {'/'},dat18_fn3.Length);
					dat18_fn3=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_fn4=txt18_5fN4.Value;
				if(!dat18_fn4.Equals(""))
				{
					string[] strTokens = dat18_fn4.Split(new char[] {'/'},dat18_fn4.Length);
					dat18_fn4=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_fn5=txt18_5fN5.Value;
				if(!dat18_fn5.Equals(""))
				{
					string[] strTokens = dat18_fn5.Split(new char[] {'/'},dat18_fn5.Length);
					dat18_fn5=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat18_fn6=txt18_5fN6.Value;
				if(!dat18_fn6.Equals(""))
				{
					string[] strTokens = dat18_fn6.Split(new char[] {'/'},dat18_fn6.Length);
					dat18_fn6=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
			
				string dat19_n1=txt19_0Date1.Value;
				if(!dat19_n1.Equals(""))
				{
					string[] strTokens = dat19_n1.Split(new char[] {'/'},dat19_n1.Length);
					dat19_n1=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
			
			
				string dat19_n2=txt19_0Date2.Value;
				if(!dat19_n2.Equals(""))
				{
					string[] strTokens = dat19_n2.Split(new char[] {'/'},dat19_n2.Length);
					dat19_n2=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
			
				string dat19_n3=txt19_0Date3.Value;
				if(!dat19_n3.Equals(""))
				{
					string[] strTokens = dat19_n3.Split(new char[] {'/'},dat19_n3.Length);
					dat19_n3=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
			
			
				string dat19_n4=txt19_0Date4.Value;
				if(!dat19_n4.Equals(""))
				{
					string[] strTokens = dat19_n4.Split(new char[] {'/'},dat19_n4.Length);
					dat19_n4=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
			
				string dat19_n5=txt19_0Date5.Value;
				if(!dat19_n5.Equals(""))
				{
					string[] strTokens = dat19_n5.Split(new char[] {'/'},dat19_n5.Length);
					dat19_n5=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
			
			
				string dat20_n1=txt20_0Date1.Value;
				if(!dat20_n1.Equals(""))
				{
					string[] strTokens = dat20_n1.Split(new char[] {'/'},dat20_n1.Length);
					dat20_n1=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
			
			
				string dat20_n2=txt20_0Date2.Value;
				if(!dat20_n2.Equals(""))
				{
					string[] strTokens = dat20_n2.Split(new char[] {'/'},dat20_n2.Length);
					dat20_n2=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat20_n3=txt20_0Date3.Value;
				if(!dat20_n3.Equals(""))
				{
					string[] strTokens = dat20_n3.Split(new char[] {'/'},dat20_n3.Length);
					dat20_n3=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat20_n4=txt20_0Date4.Value;
				if(!dat20_n4.Equals(""))
				{
					string[] strTokens = dat20_n4.Split(new char[] {'/'},dat20_n4.Length);
					dat20_n4=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dat20_n5=txt20_0Date5.Value;
				if(!dat20_n5.Equals(""))
				{
					string[] strTokens = dat20_n5.Split(new char[] {'/'},dat20_n5.Length);
					dat20_n5=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				string dateIOC=txtIOCDate.Value;
				if(!dateIOC.Equals(""))
				{
					string[] strTokens = dateIOC.Split(new char[] {'/'},dateIOC.Length);
					dateIOC=strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
				}
				
				//  CheckBox is checked then return 1,0 for unchecked.

				if(chk18_3product_Y.Checked.Equals(true))
				{
					Pro18_3="1";
				}
				else
				{
					Pro18_3="0";
				}
				if(chk18_3quality_Y.Checked.Equals(true))
				{
					Qty18_3="1";
				}
				else
				{
					Qty18_3="0";
				}
				if(chk18_3invoice_Y.Checked.Equals(true))
				{
					Inv18_3="1";
				}
				else
				{
					Inv18_3="0";
				}
				if(chk18_3amount_Y.Checked.Equals(true))
				{
					Amt18_3="1";
				}
				else
				{
					Amt18_3="0";
				}
				if(chk18_4product_Y.Checked.Equals(true))
				{
					Pro18_4="1";
				}
				else
				{
					Pro18_4="0";
				}
				if(chk18_4quantity_Y.Checked.Equals(true))
				{
					Qty18_4="1";
				}
				else
				{
					Qty18_4="0";
				}
				if(chk18_4invoice_Y.Checked.Equals(true))
				{
					Inv18_4="1";
				}
				else
				{
					Inv18_4="0";
				}
				if(chk18_4amount_Y.Checked.Equals(true))
				{
					Amt18_4="1";
				}
				else
				{
					Amt18_4="0";
				}
				
				string a = txtroiid.Text; 
		
				//Define the Insert Query in a String To Pass this Into the SQlcommand.

				string 	str9  = "insert into ROI_ANALYSIS values("+
					a+",'"+
					txtareaDLnameaddr.Value+
					"','"+asite+"','"+bsite+"','"+
					coco+"','"+
					catss+"','"+
					catfs+"','"+
					partship+
					"','"+proship+
					"','"+other+
					"','"+txtDivisionOff.Text+
					"','"+txtDistrict.Value+
					"','"+d1+"','"+
					txtSalesPerformanceDate.Value+
					"','"+d2+
					"','"+txtMSTarget1.Value+
					"','"+txtMScyear1.Value+
					"','"+txtMSLyear1.Value+"','"+
					txtMSTarget2.Value+"','"+
					txtMSCyear2.Value+"','"+
					txtMSLyear2.Value+"','"+
					txtHSDTarget1.Value+"','"+
					txtHSDCYear1.Value+"','"+
					txtHSDLYear1.Value+"','"+
					txtHSDTarget2.Value+"','"+
					txtHSDCYear2.Value+"','"+
					txtHSDLYear2.Value+"','"+
					txtLubesTarget1.Value+"','"+
					txtLubesCYear1.Value+"','"+
					txtLubesLYear1.Value+"','"+
					txtLubesTarget2.Value+"','"+
					txtLubesCYear2.Value+"','"+
					txtLubesLYear2.Value+"','"+
					txtGreaseTarget1.Value+"','"+
					txtGreaseCYear1.Value+"','"+
					txtGreaseLYear1.Value+"','"+
					txtGreaseTarget2.Value+"','"+
					txtGreaseCYear2.Value+
					"','"+txtGreaseLYear2.Value+"','"+
					txtLFratioTarget1.Value+
					"','"+txtLFratioCYear1.Value+
					"','"+txtLFratioLYear1.Value+
					"','"+txtLFratioTarget2.Value+
					"','"+txtLFratioCYear2.Value+
					"','"+txtLFratioLyear2.Value+
					"','"+txtIOCMS1.Value+"','"+
					txtIOCHSD1.Value+
					"','"+txtIOCMS2.Value+
					"','"+txtIOCHSD2.Value+"','"+
					txtIOCMS3.Value+"','"+
					txtIOCHSD3.Value+"','"+
					txtOMCMS1.Value+"','"+txtOMCHSD1.Value+
					"','"+txtOMCMS2.Value+
					"','"+txtOMCHSD2.Value+
					"','"+txtOMCMS3.Value+
					"','"+txtOMCHSD3.Value+"','"+
					txtTOTALMS1.Value+"','"+
					txtTOTALHSD1.Value+"','"+
					txtTOTALMS2.Value+"','"+txtTOTALHSD2.Value+
					"','"+txtTOTALMS3.Value+"','"+
					txtTOTALHSD3.Value+"','"+
					txtReasonLH_taAvgMS.Value+
					"','"+txtReasonLH_taAvgHSD.Value+"','"+
					newro+"','"+
					txt3a.Value+
					"','"+d3+
					"','"+txt3b.Value+"','"+d4+
					"','"+txt3c.Value+"','"+
					d5+"','"+txt4avgsaleMS.Value+
					"','"+txt4avgsaleHSD.Value+
					"','"+txt4avgsaleLUBES.Value+
					"','"+txt4NilSaleaMS.Value+
					"','"+txt4NilSaleaHSD.Value+"','"+
					txt4NilSaleaLUBES.Value+
					"','"+txt4DryOutMS.Value+"','"+
					txt4DryOutHSD.Value+"','"+
					txt4DryOutLUBES.Value+"','"+
					txtarea4NilSalesDryout.Value+"','"+
					//////Form2//////
					txt5AProNo1.Value+
					"','"+txt5AProNo2.Value+"','"+
					txt5AProNo3.Value+"','"+
					txt5AProNo4.Value+"','"+
					txt5AProNo5.Value+"','"+
					txt5AProNo6.Value+"','"+
					txt5AMakeNo1.Value+"','"+
					txt5AMakeNo2.Value+"','"+
					txt5AMakeNo3.Value+"','"+
					txt5AMakeNo4.Value+"','"+
					txt5AMakeNo5.Value+"','"+
					txt5AMakeNo6.Value+"','"+
					txt5ACuuReadNo1.Value+"','"+
					txt5ACuuReadNo2.Value+"','"+
					txt5ACuuReadNo3.Value+"','"+
					txt5ACuuReadNo4.Value+"','"+
					txt5ACuuReadNo5.Value+"','"+
					txt5ACuuReadNo6.Value+"','"+
					txt5APrevReadNo1.Value+"','"+
					txt5APrevReadNo2.Value+"','"+
					txt5APrevReadNo3.Value+"','"+
					txt5APrevReadNo4.Value+"','"+
					txt5APrevReadNo5.Value+"','"+
					txt5APrevReadNo6.Value+"','"+
					txt5APerMETReadNo1.Value+"','"+
					txt5APerMETReadNo2.Value+"','"+
					txt5APerMETReadNo3.Value+"','"+
					txt5APerMETReadNo4.Value+"','"+
					txt5APerMETReadNo5.Value+"','"+
					txt5APerMETReadNo6.Value+"','"+
					txt5BStockonlastDtMS93.Value+"','"+
					txt5BStockonlastDtMS87.Value+"','"+
					txt5BStockonlastDtMSulp.Value+"','"+
					txt5BStockonlastDtHSD.Value+"','"+
					txt5BReceiptKL_MS93.Value+"','"+
					txt5BReceiptKL_MS87.Value+"','"+
					txt5BReceiptKL_MSULP.Value+"','"+
					txt5BReceiptKL_HSD.Value+"','"+
					txt5BTotalstkMS93.Value+"','"+
					txt5BTotalstkMS87.Value+"','"+
					txt5BTotalstkMSULP.Value+"','"+
					txt5BTotalstkHSD.Value+"','"+
					txt5BTLessstkMS93.Value+"','"+
					txt5BTLessstkMS87.Value+"','"+
					txt5BTLessstkMSULP.Value+"','"+
					txt5BTLessstkHSD.Value+"','"+
					txt5BTotSalesMS93.Value+"','"+
					txt5BTotSalesMS87.Value+"','"+
					txt5BTotSalesMSULP.Value+"','"+
					txt5BTotSalesHSD.Value+"','"+
					txt5BVariationMS93.Value+"','"+
					txt5BVariationMS87.Value+"','"+
					txt5BVariationMSULP.Value+"','"+
					txt5BVariationHSD.Value+"','"+
					txtarea5BReasonVar.Value+"','"+
					txt6adqbarrel1_0.Value+"','"+
					txt6adqbarrel2_0.Value+"','"+
					txt6adqbarrel3_0.Value+"','"+
					txt6Smallpck1_0.Value+"','"+
					txt6Smallpck2_0.Value+"','"+
					txt6Smallpck3_0.Value+"','"+
					txt6adqbarrel1_1.Value+"','"+
					txt6adqbarrel2_1.Value+"','"+
					txt6adqbarrel3_1.Value+"','"+
					txt6adSmallpck1_1.Value+"','"+
					txt6adSmallpck2_1.Value+"','"+
					txt6adSmallpck3_1.Value+"','"+
					txt6Inadqbarrel1_0.Value+"','"+
					txt6Inadqbarrel2_0.Value+"','"+
					txt6Inadqbarrel3_0.Value+"','"+
					txt6InSmallpck1_0.Value+"','"+
					txt6InSmallpck2_0.Value+"','"+
					txt6InSmallpck3_0.Value+"','"+
					txt6Inadqbarrel1_1.Value+"','"+
					txt6Inadqbarrel2_1.Value+"','"+
					txt6Inadqbarrel3_1.Value+"','"+
					txt6InSmallpck1_1.Value+"','"+
					txt6InSmallpck2_1.Value+"','"+
					txt6InSmallpck3_1.Value+"','"+
					txt7DetailSub1.Value+"','"+
					txt7DetailSub1_yr.Value+"','"+
					txt7DetailSub1_amt.Value+"','"+
					txt7DetailSub2.Value+"','"+
					txt7DetailSub2_yr.Value+"','"+
					txt7DetailSub2_amt.Value+"','"+
					txt7DetailSub3.Value+"','"+
					txt7DetailSub3_yr.Value+"','"+
					txt7DetailSub3_amt.Value+"','"+
					txt7DetailSub4.Value+"','"+
					txt7DetailSub4_yr.Value+"','"+
					txt7DetailSub4_amt.Value+"','"+
					txt7DetailSub5.Value+"','"+
					txt7DetailSub5_yr.Value+"','"+
					txt7DetailSub5_amt.Value+"','"+
					txt8Dealersugggestion.Value+"','"+
					txt9MarInfo.Value+"','"+
					///////Form-3-4-5/////
					c10_1A_Y+
					"','"+txt10_1B.Value+"','"+
					c10_1C_y+
					"','"+c10_1d_y+"','"+
					c10_1e_y+"','"+c10_1f_y+
					"','"+txt10_1f.Value+"','"+
					c10_1g_y+"','"+txt10_1g.Value+
					"','"+c10_2a_good+"','"+
					c10_2b_good+"','"+c10_2c_y+
					"','"+a10_3Date+"','"+
					c10_3b_y+"','"+c10_3c_y+
					"','"+c10_3d_Ex+"','"+
					c10_3d_Vg+"','"+c10_3d_G+
					"','"+c10_3d_Av+"','"+
					c10_3d_P+"','"+
					c10_3e_Ex+
					"','"+c10_3e_Vg+"','"+
					c10_3e_G+
					"','"+c10_3e_Av+"','"+
					c10_3e_P+"','"+c10_4a_Ex+
					"','"+c10_4a_Vg+"','"+c10_4a_G+
					"','"+c10_4a_Av+"','"+
					c10_4a_P+"','"+c10_4b_Ex+
					"','"+c10_4b_Vg+"','"+c10_4b_G+
					"','"+c10_4b_Av+"','"+
					c10_4b_P+"','"+c10_4c_Ex+
					"','"+c10_4c_Vg+"','"+
					c10_4c_G+
					"','"+c10_4c_Av+"','"+
					c10_4c_P+"','"+c10_4d_Ex+
					"','"+c10_4d_Vg+"','"+
					c10_4d_G+
					"','"+c10_4d_Av+"','"+
					c10_4d_P+"','"+c10_5a_Ex+
					"','"+c10_5a_Vg+"','"+
					c10_5a_G+
					"','"+c10_5a_Av+"','"+
					c10_5a_P+"','"+c10_5b_Y+
					"','"+c10_5c_Y+"','"+
					c10_5d_Y+"','"+c10_6a_Ex+
					"','"+c10_6a_Vg+"','"+
					c10_6a_G+"','"+c10_6a_Av+
					"','"+c10_6a_P+"','"+
					c10_6b_Y+"','"+c10_6c_Y+
					"','"+txt10_6c.Value+"','"+
					c10_7a_Y+"','"+c10_7b_Y+
					"','"+c10_7c_Y+"','"+
					c10_7d_Y+"','"+c12a_Y+
					"','"+c12b_Y+"','"+
					c12c_Y+"','"+c12d_Y+
					"','"+c12e_Y+"','"+
					c13a_Y+"','"+c13b_Y+
					"','"+c13c_Y+"','"+
					c13d_Y+"','"+c13e_Y+
					"','"+c13f_Y+"','"+
					c13g_Y+"','"+txt13g.Value+"','"+c13h_Y+
					"','"+c13i_Y+"','"+
					c13j_Y+"','"+c13k_Y+
					"','"+c13l_Y+"','"+
					c13m_Y+"','"+c13n_Y+
					"','"+c13o_Y+"','"+
					c13p_Y+"','"+c13q_Y+
					"','"+c13r_Y+"','"+
					c13s_Y+"','"+c13t_Y+
					"','"+c13u_Y+"','"+
					c13v_Y+"','"+c13w_Y+
					"','"+c13x_Y+"','"+
					txt13_nature.Value+"','"+c14a1_Y+
					"','"+c14a2_Y+"','"+c14a3_Y+"','"+
					c14a4_Y+"','"+c14a5_Y+"','"+
					c14a6_Y+"','"+c14b1_Y+"','"+
					c14b2_Y+"','"+c14b3_Y+"','"+
					c14b4_Y+"','"+c14b5_Y+"','"+
					c14b6_Y+"','"+
					c14c1_C+"','"+
					c14c1_S+"','"+
					c14c1_E+"','"+
					c14c2_C+"','"+
					c14c2_S+"','"+
					c14c2_E+"','"+
					c14c3_C+"','"+
					c14c3_S+"','"+
					c14c3_E+"','"+
					c14c4_C+"','"+
					c14c4_S+"','"+
					c14c4_E+"','"+
					c14c5_C+"','"+
					c14c5_S+"','"+
					c14c5_E+"','"+
					c14c6_C+"','"+
					c14c6_S+"','"+
					c14c6_E+"','"+
					c15aT1_Y+"','"+
					c15aT2_Y+"','"+
					c15aT3_Y+"','"+
					c15aT4_Y+"','"+
					txt15bT1.Value+"','"+
					txt15bT2.Value+"','"+
					txt15bT3.Value+"','"+
					txt15bT4.Value+"','"+
					txt15cT1.Value+"','"+
					txt15cT2.Value+"','"+
					txt15cT3.Value+"','"+
					txt15cT4.Value+"','"+
					c15dT1_Y+"','"+
					c15dT2_Y+"','"+
					c15dT3_Y+"','"+
					c15dT4_Y+"','"+
					c15eT1_Y+"','"+
					c15eT2_Y+"','"+
					c15eT3_Y+"','"+
					c15eT4_Y+"','"+
					txt15f.Value+"','"+
					c16a_Y+"','"+
					c16bT1_Y+"','"+
					c16bT2_Y+"','"+
					c16bT3_Y+"','"+
					c16bT4_Y+"','"+
					c16cT1_Y+"','"+
					c16cT2_Y+"','"+
					c16cT3_Y+"','"+
					c16cT4_Y+"','"+
					c16dT1_Y+"','"+
					c16dT2_Y+"','"+
					c16dT3_Y+"','"+
					c16dT4_Y+"','"+
					txt16_Detail.Value+"','"+
					a17Date+"','"+
					txt17a_Result.Value+"','"+
					b17Date+"','"+
					txt17b_Result.Value+"','"+
					c17Date+"','"+
					txt17c_Result.Value+"','"+
					txt17MS.Value+"','"+
					txt17HSD.Value+"','"+
					/////Form-6-7-/////
					txt18_1_Comm.Value+"','"+
					txt18_2_Transport.Value+"','"+
					txt18_2_Pending.Value+"','"+
					txt18_2_Action.Value+"','"+
					txt18_3_product.Value+"','"+
					Pro18_3+"','"+
					txt18_3_quality.Value+"','"+
					Qty18_3+"','"+
					txt18_3_Invoice.Value+"','"+
					Inv18_3+"','"+
					txt18_3_amount.Value+"','"+
					Amt18_3+"','"+
					txt18_4_product.Value+"','"+
					Pro18_4+"','"+
					txt18_4_quantity.Value+"','"+
					Qty18_4+"','"+
					txt18_4_Invoice.Value+"','"+
					Inv18_4+"','"+
					txt18_4_amount.Value+"','"+
					Amt18_4+"','"+
					txt18_4_action.Value+"','"+
					txt18_5a.Value+"','"+
					txt18_5bN1.Value+"','"+
					txt18_5bN2.Value+"','"+
					txt18_5bN3.Value+"','"+
					txt18_5bN4.Value+"','"+
					txt18_5bN5.Value+"','"+
					txt18_5bN6.Value+"','"+
					txt18_5cN1.Value+"','"+
					txt18_5cN2.Value+"','"+
					txt18_5cN3.Value+"','"+
					txt18_5cN4.Value+"','"+
					txt18_5cN5.Value+"','"+
					txt18_5cN6.Value+"','"+
					dat18_dn1+"','"+
					dat18_dn2+"','"+
					dat18_dn3+"','"+
					dat18_dn4+"','"+
					dat18_dn5+"','"+
					dat18_dn6+"','"+
					dat18_en1+"','"+
					dat18_en2+"','"+
					dat18_en3+"','"+
					dat18_en4+"','"+
					dat18_en5+"','"+
					dat18_en6+"','"+
					dat18_fn1+"','"+
					dat18_fn2+"','"+
					dat18_fn3+"','"+
					dat18_fn4+"','"+
					dat18_fn5+"','"+
					dat18_fn6+"','"+
					txt18_5_reasons.Value+"','"+
					txt18_6aAvg.Value+"','"+
					txt18_6bNumber.Value+"','"+
					txt18_6cActionplan.Value+"','"+
					txt19_0srno1.Value+"','"+
					dat19_n1+"','"+
					txt19_0Action1.Value+"','"+
					txt19_0Detail1.Value+"','"+
					txt19_0srno2.Value+"','"+
					dat19_n2+"','"+
					txt19_0Action2.Value+"','"+
					txt19_0Detail2.Value+"','"+
					txt19_0srno3.Value+"','"+
					dat19_n3+"','"+
					txt19_0Action3.Value+"','"+
					txt19_0Detail3.Value+"','"+
					txt19_0srno4.Value+"','"+
					dat19_n4+"','"+
					txt19_0Action4.Value+"','"+
					txt19_0Detail4.Value+"','"+
					txt19_0srno5.Value+"','"+
					dat19_n5+"','"+
					txt19_0Action5.Value+"','"+
					txt19_0Detail5.Value+"','"+
					txt20_0srno1.Value+"','"+
					dat20_n1+"','"+
					txt20_0Action1.Value+"','"+
					txt20_0Detail1.Value+"','"+
					txt20_0srno2.Value+"','"+
					dat20_n2+"','"+
					txt20_0Action2.Value+"','"+
					txt20_0Detail2.Value+"','"+
					txt20_0srno3.Value+"','"+
					dat20_n3+"','"+
					txt20_0Action3.Value+"','"+
					txt20_0Detail3.Value+"','"+
					txt20_0srno4.Value+"','"+
					dat20_n4+"','"+
					txt20_0Action4.Value+"','"+
					txt20_0Detail4.Value+"','"+
					txt20_0srno5.Value+"','"+
					dat20_n5+"','"+
					txt20_0Action5.Value+"','"+
					txt20_0Detail5.Value+"','"+
					txtSOD.Value+"','"+
					txtSignIOC.Value+"','"+
					txtIOCName.Value+"','"+
					txtIOCdesign.Value+"','"+
					dateIOC+"','"+st5bdate+"','"+
					txt4tba.Value+"','"+txtpro15t1.Value+
					"','"+txtpro15t2.Value+"','"+
					txtpro15t3.Value+"','"+
					txtpro15t4.Value+"')";
			
				SqlCommand	scom9  = new SqlCommand( str9 ,con  );
				scom9.ExecuteNonQuery();
		
				scom9.Dispose();
				con.Close();
				btnSave.Disabled=true;
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:save()  ROI Report No. "+txtroiid.Text +" Saved.  userid  "+uid);
			}
			catch(Exception Ex)
			{
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:save()  EXCEPTION "+ Ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// this method is used to call the Save() function to save the record in database.
		/// </summary>
		private void btnSave_ServerClick(object sender, System.EventArgs e)
		{
			if(txtareaDLnameaddr.Value.Equals(""))
			{
				MessageBox.Show("Please enter the Name and Address");
			}
			else if(txtDivisionOff.Text.Equals(""))
			{
				MessageBox.Show("Please enter Division");
			}
			else
			{
				Save();					
				MessageBox.Show("Record Saved");
				clear();
				getNextID();
				DropDownList1.SelectedIndex = 0;
				DropDownList1.Enabled = false; 
				btnSave.Disabled=false;
				btnEdit.Disabled=true;
				btndelete.Disabled = true; 
			}
		}

		/// <summary>
		/// This method is used to call the Edit() function to update the particular record select from the dropdownlist in edit time.
		/// </summary>
		private void btnEdit_ServerClick(object sender, System.EventArgs e)
		{
            Edit(); 
			MessageBox.Show("Record Updated");
			clear();
			getNextID();
			DropDownList1.SelectedIndex = 0;
			DropDownList1.Enabled = false; 
			btnSave.Disabled=false;
			btnEdit.Disabled=true;
			btndelete.Disabled = true; 
		}
		
		
		/// <summary>
		/// This method is used to  Editing the record.
		/// </summary>
		public void Edit()
		{
			try
			{
				asite = setRadio1(asite,chkasite);				
				bsite=setRadio1(bsite,chkbsite);
				coco=setRadio1(coco,chkcoco);
				newro=setCheck1(newro,chkNewRoTrAY);
				catss=setRadio1(catss,chkCategoryss);
				catfs=setRadio1(catfs,chkCategoryfs);
				other=setRadio1(other,chkOthers);
				partship=setRadio1(partship,chkPartnership);
				proship=setRadio1(proship,chkProprietorship);
				c10_1A_Y=setCheck1(c10_1A_Y,chk10_1A_Y);
				c10_1C_y=setCheck1(c10_1C_y,chk10_1C_y);	
				c10_1d_y=setCheck1(c10_1d_y,chk10_1d_y);	
				c10_1e_y=setCheck1(c10_1e_y,chk10_1e_y);
				c10_1f_y=setCheck1(c10_1f_y,chk10_1f_y);				
				c10_1g_y=setCheck1(c10_1g_y,chk10_1g_y);
				c10_2a_good=setCheck1(c10_2a_good,chk10_2a_good);
				c10_2b_good=setCheck1(c10_2b_good,chk10_2b_good);
				c10_2c_y=setCheck1(c10_2c_y,chk10_2c_y);
				c10_3b_y=setCheck1(c10_3b_y,chk10_3b_y);
				c10_3c_y=setCheck1(c10_3c_y,chk10_3c_y);
				c10_3d_Ex=setRadio1(c10_3d_Ex,chk10_3d_Ex);
				c10_3d_Vg=setRadio1(c10_3d_Vg,chk10_3d_Vg);
				c10_3d_G=setRadio1(c10_3d_G,chk10_3d_G);
				c10_3d_Av=setRadio1(c10_3d_Av,chk10_3d_Av);
				c10_3d_P=setRadio1(c10_3d_P,chk10_3d_P);
				c10_3e_Ex=setRadio1(c10_3e_Ex,chk10_3e_Ex);
				c10_3e_Vg=setRadio1(c10_3e_Vg,chk10_3e_Vg);
				c10_3e_G=setRadio1(c10_3e_G,chk10_3e_G);
				c10_3e_Av=setRadio1(c10_3e_Av,chk10_3e_Av);
				c10_3e_P=setRadio1(c10_3e_P,chk10_3e_P);
				c10_4a_Ex=setRadio1(c10_4a_Ex,chk10_4a_Ex);
				c10_4a_Vg=setRadio1(c10_4a_Vg,chk10_4a_Vg);
				c10_4a_G=setRadio1(c10_4a_G,chk10_4a_G);
				c10_4a_Av=setRadio1(c10_4a_Av,chk10_4a_Av);
				c10_4a_P=setRadio1(c10_4a_P,chk10_4a_P);
				c10_4b_Ex=setRadio1(c10_4b_Ex,chk10_4b_Ex);
				c10_4b_Vg=setRadio1(c10_4b_Vg,chk10_4b_Vg);
				c10_4b_G=setRadio1(c10_4b_G,chk10_4b_G);
				c10_4b_Av=setRadio1(c10_4b_Av,chk10_4b_Av);
				c10_4b_P=setRadio1(c10_4b_P,chk10_4b_P);
				c10_4c_Ex=setRadio1(c10_4c_Ex,chk10_4c_Ex);
				c10_4c_Vg=setRadio1(c10_4c_Vg,chk10_4c_Vg);
				c10_4c_G=setRadio1(c10_4c_G,chk10_4c_G);
				c10_4c_Av=setRadio1(c10_4c_Av,chk10_4c_Av);
				c10_4c_P=setRadio1(c10_4c_P,chk10_4c_P);
				c10_4d_Ex=setRadio1(c10_4d_Ex,chk10_4d_Ex);
				c10_4d_Vg=setRadio1(c10_4d_Vg,chk10_4d_Vg);
				c10_4d_G=setRadio1(c10_4d_G,chk10_4d_G);
				c10_4d_Av=setRadio1(c10_4d_Av,chk10_4d_Av);
				c10_4d_P=setRadio1(c10_4d_P,chk10_4d_P);
				c10_5a_Ex=setRadio1(c10_5a_Ex,chk10_5a_Ex);
				c10_5a_Vg=setRadio1(c10_5a_Vg,chk10_5a_Vg);
				c10_5a_G=setRadio1(c10_5a_G,chk10_5a_G);
				c10_5a_Av=setRadio1(c10_5a_Av,chk10_5a_Av);
				c10_5a_P=setRadio1(c10_5a_P,chk10_5a_P);
				c10_5b_Y=setCheck1(c10_5b_Y,chk10_5b_Y);
				c10_5c_Y=setCheck1(c10_5c_Y,chk10_5c_Y);
				c10_5d_Y=setCheck1(c10_5d_Y,chk10_5d_Y);
				c10_6a_Ex=setRadio1(c10_6a_Ex,chk10_6a_Ex);
				c10_6a_Vg=setRadio1(c10_6a_Vg,chk10_6a_Vg);
				c10_6a_G=setRadio1(c10_6a_G,chk10_6a_G);
				c10_6a_Av=setRadio1(c10_6a_Av,chk10_6a_Av);
				c10_6a_P=setRadio1(c10_6a_P,chk10_6a_P);
				c10_6b_Y=setCheck1(c10_6b_Y,chk10_6b_Y);
				c10_6c_Y=setCheck1(c10_6c_Y,chk10_6c_Y);
				c10_7a_Y=setCheck1(c10_7a_Y,chk10_7a_Y);
				Pro18_3=setCheck1(Pro18_3,chk18_3product_Y);					
				Qty18_3=setCheck1(Qty18_3,chk18_3quality_Y);					
				Inv18_3=setCheck1(Inv18_3,chk18_3invoice_Y);					
				Amt18_3=setCheck1(Amt18_3,chk18_3amount_Y);					
				Pro18_4=setCheck1(Pro18_4,chk18_4product_Y);					
				Qty18_4=setCheck1(Qty18_4,chk18_4quantity_Y);					
				Inv18_4=setCheck1(Inv18_4,chk18_4invoice_Y);					
				Amt18_4=setCheck1(Amt18_4,chk18_4amount_Y);	
				c10_7b_Y=setCheck1(c10_7b_Y,chk10_7b_Y);
				c10_7c_Y=setCheck1(c10_7c_Y,chk10_7c_Y);
				c10_7d_Y=setCheck1(c10_7d_Y,chk10_7d_Y);
				c12a_Y=setCheck1(c12a_Y,chk12a_Y);
				c12b_Y=setCheck1(c12b_Y,chk12b_Y);
				c12c_Y=setCheck1(c12c_Y,chk12c_Y);
				c12d_Y=setCheck1(c12d_Y,chk12d_Y);
				c13a_Y=setCheck1(c13a_Y,chk13a_Y);
				c13b_Y=setCheck1(c13b_Y,chk13b_Y);
				c13c_Y=setCheck1(c13c_Y,chk13c_Y);
				c13d_Y=setCheck1(c13d_Y,chk13d_Y);
				c13e_Y=setCheck1(c13e_Y,chk13e_Y);
				c13f_Y=setCheck1(c13f_Y,chk13f_Y);
				c13g_Y=setCheck1(c13g_Y,chk13g_Y);
				c13h_Y=setCheck1(c13h_Y,chk13h_Y);
				c13i_Y=setCheck1(c13i_Y,chk13i_Y);
				c13j_Y=setCheck1(c13j_Y,chk13j_Y);
				c13k_Y=setCheck1(c13k_Y,chk13k_Y);
				c13l_Y=setCheck1(c13l_Y,chk13l_Y);
				c13m_Y=setCheck1(c13m_Y,chk13m_Y);
				c13n_Y=setCheck1(c13n_Y,chk13n_Y);
				c13o_Y=setCheck1(c13o_Y,chk13o_Y);
				c13p_Y=setCheck1(c13p_Y,chk13p_Y);
				c13q_Y=setCheck1(c13q_Y,chk13q_Y);
				c13r_Y=setCheck1(c13r_Y,chk13r_Y);
				c13s_Y=setCheck1(c13s_Y,chk13s_Y);
				c13t_Y=setCheck1(c13t_Y,chk13t_Y);
				c13u_Y=setCheck1(c13u_Y,chk13u_Y);
				c13v_Y=setCheck1(c13v_Y,chk13v_Y);
				c13w_Y=setCheck1(c13w_Y,chk13w_Y);
				c13x_Y=setCheck1(c13x_Y,chk13x_Y);
				c14a1_Y=setCheck1(c14a1_Y,chk14a1_Y);					
				c14a2_Y=setCheck1(c14a2_Y,chk14a2_Y);
				c14a3_Y=setCheck1(c14a3_Y,chk14a3_Y);
				c14a4_Y=setCheck1(c14a4_Y,chk14a4_Y);
				c14a5_Y=setCheck1(c14a5_Y,chk14a5_Y);
				c14a6_Y=setCheck1(c14a6_Y,chk14a6_Y);
				c14b1_Y=setCheck1(c14b1_Y,chk14b1_Y);					
				c14b2_Y=setCheck1(c14b2_Y,chk14b2_Y);
				c14b3_Y=setCheck1(c14b3_Y,chk14b3_Y);
				c14b4_Y=setCheck1(c14b4_Y,chk14b4_Y);
				c14b5_Y=setCheck1(c14b5_Y,chk14b5_Y);
				c14c1_C=setRadio1(c14c1_C,chk14c1_C);
				c14c1_S=setRadio1(c14c1_S,chk14c1_S);
				c14c1_E=setRadio1(c14c1_E,chk14c1_E);
				c14c2_C=setRadio1(c14c2_C,chk14c2_C);
				c14c2_S=setRadio1(c14c2_S,chk14c2_S);
				c14c2_E=setRadio1(c14c2_E,chk14c2_E);
				c14c3_C=setRadio1(c14c3_C,chk14c3_C);
				c14c3_S=setRadio1(c14c3_S,chk14c3_S);
				c14c3_E=setRadio1(c14c3_E,chk14c3_E);
				c14c4_C=setRadio1(c14c4_C,chk14c4_C);
				c14c4_S=setRadio1(c14c4_S,chk14c4_S);
				c14c4_E=setRadio1(c14c4_E,chk14c4_E);
				c14c5_C=setRadio1(c14c5_C,chk14c5_C);
				c14c5_S=setRadio1(c14c5_S,chk14c5_S);
				c14c5_E=setRadio1(c14c5_E,chk14c5_E);
				c14c6_C=setRadio1(c14c6_C,chk14c6_C);
				c14c6_S=setRadio1(c14c6_S,chk14c6_S);
				c14c6_E=setRadio1(c14c6_E,chk14c6_E);
				c15aT2_Y=setCheck1(c15aT2_Y,chk15aT2_Y);
				c15aT3_Y=setCheck1(c15aT3_Y,chk15aT3_Y);
				c15aT4_Y=setCheck1(c15aT4_Y,chk15aT4_Y);
				c15dT1_Y=setCheck1(c15dT1_Y,chk15dT1_Y);
				c15dT2_Y=setCheck1(c15dT2_Y,chk15dT2_Y);
				c15dT3_Y=setCheck1(c15dT3_Y,chk15dT3_Y);
				c15dT4_Y=setCheck1(c15dT4_Y,chk15dT4_Y);
				c15eT1_Y=setCheck1(c15eT1_Y,chk15eT1_Y);
				c15eT2_Y=setCheck1(c15eT2_Y,chk15eT2_Y);
				c15eT3_Y=setCheck1(c15eT3_Y,chk15eT3_Y);
				c15eT4_Y=setCheck1(c15eT4_Y,chk15eT4_Y);
				c16a_Y=setCheck1(c16a_Y,chk16a_Y);
				c16bT1_Y=setCheck1(c16bT1_Y,chk16bT1_Y);
				c16bT2_Y=setCheck1(c16bT2_Y,chk16bT2_Y);
				c16bT3_Y=setCheck1(c16bT3_Y,chk16bT3_Y);
				c16bT4_Y=setCheck1(c16bT4_Y,chk16bT4_Y);			
				c16cT1_Y=setCheck1(c16cT1_Y,chk16cT1_Y);
				c16cT2_Y=setCheck1(c16cT2_Y,chk16cT2_Y);
				c16cT3_Y=setCheck1(c16cT3_Y,chk16cT3_Y);
				c16cT4_Y=setCheck1(c16cT4_Y,chk16cT4_Y);			
				c16dT1_Y=setCheck1(c16dT1_Y,chk16dT1_Y);
				c15aT1_Y=setCheck1(c15aT1_Y,chk15aT1_Y);
				c14b6_Y=setCheck1(c14b6_Y,chk14b6_Y);
				c12e_Y=setCheck1(c12e_Y,chk12e_Y);
				c16dT2_Y=setCheck1(c16dT2_Y,chk16dT2_Y);
				c16dT3_Y=setCheck1(c16dT3_Y,chk16dT3_Y);
				c16dT4_Y=setCheck1(c16dT4_Y,chk16dT4_Y);		
	
				// Return Date in MM/DD/YYYY for Display and Print Input is DD/MM/YYYY

				txtSalesPerformanceDate.Value=GenUtil.str2MMDDYYYY(txtSalesPerformanceDate.Value.ToString());
				txtDate.Text=GenUtil.str2MMDDYYYY(txtDate.Text.ToString());
				txtCummulativeuptoDate.Value=GenUtil.str2MMDDYYYY(txtCummulativeuptoDate.Value.ToString());
				txt3adatepk.Value=GenUtil.str2MMDDYYYY(txt3adatepk.Value.ToString());
				txt3bdatepk.Value=GenUtil.str2MMDDYYYY(txt3bdatepk.Value.ToString());
				txt3cdatepk.Value=GenUtil.str2MMDDYYYY(txt3cdatepk.Value.ToString());
				txt17a_Date.Value=GenUtil.str2MMDDYYYY(txt17a_Date.Value.ToString());
				txt17b_Date.Value=GenUtil.str2MMDDYYYY(txt17b_Date.Value.ToString());
				txt17c_Date.Value=GenUtil.str2MMDDYYYY(txt17c_Date.Value.ToString());
				txt10_3_aDate.Value=GenUtil.str2MMDDYYYY(txt10_3_aDate.Value.ToString());
				//txt18_1_Comm.Value=GenUtil.str2MMDDYYYY(txt18_1_Comm.Value.ToString());
				txt18_5dN1.Value=GenUtil.str2MMDDYYYY(txt18_5dN1.Value.ToString());
				txt18_5dN2.Value=GenUtil.str2MMDDYYYY(txt18_5dN2.Value.ToString());
				txt18_5dN3.Value=GenUtil.str2MMDDYYYY(txt18_5dN3.Value.ToString());
				txt18_5dN4.Value=GenUtil.str2MMDDYYYY(txt18_5dN4.Value.ToString());
				txt18_5dN5.Value=GenUtil.str2MMDDYYYY(txt18_5dN5.Value.ToString());
				txt18_5dN6.Value=GenUtil.str2MMDDYYYY(txt18_5dN6.Value.ToString());
				txt18_5eN1.Value=GenUtil.str2MMDDYYYY(txt18_5eN1.Value.ToString());
				txt18_5eN2.Value=GenUtil.str2MMDDYYYY(txt18_5eN2.Value.ToString());
				txt18_5eN3.Value=GenUtil.str2MMDDYYYY(txt18_5eN3.Value.ToString());
				txt18_5eN4.Value=GenUtil.str2MMDDYYYY(txt18_5eN4.Value.ToString());
				txt18_5eN5.Value=GenUtil.str2MMDDYYYY(txt18_5eN5.Value.ToString());
				txt18_5eN6.Value=GenUtil.str2MMDDYYYY(txt18_5eN6.Value.ToString());
				txt18_5fN1.Value=GenUtil.str2MMDDYYYY(txt18_5fN1.Value.ToString());
				txt18_5fN2.Value=GenUtil.str2MMDDYYYY(txt18_5fN2.Value.ToString());
				txt18_5fN3.Value=GenUtil.str2MMDDYYYY(txt18_5fN3.Value.ToString());
				txt18_5fN4.Value=GenUtil.str2MMDDYYYY(txt18_5fN4.Value.ToString());
				txt18_5fN5.Value=GenUtil.str2MMDDYYYY(txt18_5fN5.Value.ToString());
				txt18_5fN6.Value=GenUtil.str2MMDDYYYY(txt18_5fN6.Value.ToString());
				txt19_0Date1.Value=GenUtil.str2MMDDYYYY(txt19_0Date1.Value.ToString());
				txt19_0Date2.Value=GenUtil.str2MMDDYYYY(txt19_0Date2.Value.ToString());
				txt19_0Date3.Value=GenUtil.str2MMDDYYYY(txt19_0Date3.Value.ToString());
				txt19_0Date4.Value=GenUtil.str2MMDDYYYY(txt19_0Date4.Value.ToString());
				txt19_0Date5.Value=GenUtil.str2MMDDYYYY(txt19_0Date5.Value.ToString());	
				txt20_0Date1.Value=GenUtil.str2MMDDYYYY(txt20_0Date1.Value.ToString());	
				txt20_0Date2.Value=GenUtil.str2MMDDYYYY(txt20_0Date2.Value.ToString());	
				txt20_0Date3.Value=GenUtil.str2MMDDYYYY(txt20_0Date3.Value.ToString());	
				txt20_0Date4.Value=GenUtil.str2MMDDYYYY(txt20_0Date4.Value.ToString());	
				txt20_0Date5.Value=GenUtil.str2MMDDYYYY(txt20_0Date5.Value.ToString());	
				txtIOCDate.Value=GenUtil.str2MMDDYYYY(txtIOCDate.Value.ToString());
				txt5bstdate.Value=GenUtil.str2MMDDYYYY(txt5bstdate.Value.ToString());
			

				//Define the connection String to connect the Sqlserver.

				SqlConnection	con  = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
				con.Open();	
				// Define the update query string to update the record.
				string str5="update ROI_ANALYSIS set DLnameaddr='"+txtareaDLnameaddr.Value+
					"',TSAsite='"+asite+
					"',TSBsite='"+bsite+
					"',TScoco='"+coco+
					"',CatSS='"+catss+
					"',CatFS='"+catfs+
					"',partship='"+partship+
					"',Propship='"+proship+
					"',Other='"+other+
					"',Divoffice='"+txtDivisionOff.Text+
					"',Distr='"+txtDistrict.Value+
					"',Pvdt='"+txtDate.Text+
					"',Spdt1='"+txtSalesPerformanceDate.Value+
					"',Spcum1='"+txtCummulativeuptoDate.Value+
					"',Mstar1='"+txtMSTarget1.Value+
					"',Mscyear1='"+txtMScyear1.Value+"',Mslyear1='"+txtMSLyear1.Value+
					"',Mstar2='"+txtMSTarget2.Value+"',Mscyear2='"+txtMSCyear2.Value+
					"',Mslyear2='"+txtMSLyear2.Value+"',Hsdtar1='"+txtHSDTarget1.Value+
					"',Hsdcyear1='"+txtHSDCYear1.Value+"',Hsdlyear1='"+txtHSDLYear1.Value+
					"',Hsdtar2='"+txtHSDTarget2.Value+
					"',Hsdcyear2='"+txtHSDCYear2.Value+
					"',Hsdlyear2='"+txtHSDLYear2.Value+
					"',Lubestar1='"+txtLubesTarget1.Value+
					"',Lubescyear1='"+txtLubesCYear1.Value+
					"',Lubeslyear1='"+txtLubesLYear1.Value+
					"',Lubestar2='"+txtLubesTarget2.Value+
					"',Lubescyear2='"+txtLubesCYear2.Value+
					"',Lubeslyear2='"+txtLubesLYear2.Value+
					"',Greasetar1='"+txtGreaseTarget1.Value+
					"',Greasecyear1='"+txtGreaseCYear1.Value+
					"',Greaselyear1='"+txtGreaseLYear1.Value+
					"',Greasetar2='"+txtGreaseTarget2.Value+
					"',Greasecyear2='"+txtGreaseCYear2.Value+
					"',Greaselyear2='"+txtGreaseLYear2.Value+
					"',Lfratiotar1='"+txtLFratioTarget1.Value+
					"',Lfratiocyear1='"+txtLFratioCYear1.Value+
					"',Lfratiolyear1='"+txtLFratioLYear1.Value+
					"',Lfratiotar2='"+txtLFratioTarget2.Value+
					"',Lfratiocyear2='"+txtLFratioCYear2.Value+
					"',Lfratiolyear2='"+txtLFratioLyear2.Value+
					"',Iocms1='"+txtIOCMS1.Value+"',Iochsd1='"+txtIOCHSD1.Value+
					"',Iocms2='"+txtIOCMS2.Value+"',Iochsd2='"+txtIOCHSD2.Value+
					"',Iocms3='"+txtIOCMS3.Value+"',Iochsd3='"+txtIOCHSD3.Value+
					"',Omcms1='"+txtOMCMS1.Value+"',Omchsd1='"+txtOMCHSD1.Value+
					"',Omcms2='"+txtOMCMS2.Value+"',Omchsd2='"+txtOMCHSD2.Value+
					"',Omcms3='"+txtOMCMS3.Value+"',Omchsd3='"+txtOMCHSD3.Value+
					"',Totalms1='"+txtTOTALMS1.Value+"',Totalhsd1='"+txtTOTALHSD1.Value+
					"',Totalms2='"+txtTOTALMS2.Value+
					"',Totalhsd2='"+txtTOTALHSD2.Value+
					"',Totalms3='"+txtTOTALMS3.Value+
					"',Totalhsd3='"+txtTOTALHSD3.Value+
					"',Reasonl_hms1='"+txtReasonLH_taAvgMS.Value+
					"',Reasonl_hhsd1='"+txtReasonLH_taAvgHSD.Value+
					"',Newros_3='"+newro+"',Name_3a='"+txt3a.Value+
					"',Date_3a='"+txt3adatepk.Value+"',Name_3b='"+txt3b.Value+
					"',Date_3b='"+txt3bdatepk.Value+"',Name_3c='"+txt3c.Value+
					"',Date_3c='"+txt3cdatepk.Value+
					"',Literms_4='"+txt4avgsaleMS.Value+
					"',Literhsd_4='"+txt4avgsaleHSD.Value+
					"',Literlubes_4='"+txt4avgsaleLUBES.Value+
					"',salesms_4='"+txt4NilSaleaMS.Value+
					"',saleshsd_4='"+txt4NilSaleaHSD.Value+
					"',saleslubes_4='"+txt4NilSaleaLUBES.Value+
					"',Anyms_4='"+txt4DryOutMS.Value+
					"',Anyhsd_4='"+txt4DryOutHSD.Value+
					"',Anylubes_4='"+txt4DryOutLUBES.Value+
					"',Reason_4='"+txtarea4NilSalesDryout.Value+
					"',ProNo1_5='"+txt5AProNo1.Value+
					"',ProNo2_5='"+txt5AProNo2.Value+
					"',ProNo3_5='"+txt5AProNo3.Value+
					"',ProNo4_5='"+txt5AProNo4.Value+
					"',ProNo5_5='"+txt5AProNo5.Value+
					"',ProNo6_5='"+txt5AProNo6.Value+
					"',Makeno1_5='"+txt5AMakeNo1.Value+
					"',Makeno2_5='"+txt5AMakeNo2.Value+
					"',Makeno3_5='"+txt5AMakeNo3.Value+
					"',Makeno4_5='"+txt5AMakeNo4.Value+
					"',Makeno5_5='"+txt5AMakeNo5.Value+
					"',Makeno6_5='"+txt5AMakeNo6.Value+
					"',Curreadno1_5='"+txt5ACuuReadNo1.Value+
					"',Curreadno2_5='"+txt5ACuuReadNo2.Value+
					"',Curreadno3_5='"+txt5ACuuReadNo3.Value+
					"',Curreadno4_5='"+txt5ACuuReadNo4.Value+
					"',Curreadno5_5='"+txt5ACuuReadNo5.Value+
					"',Curreadno6_5='"+txt5ACuuReadNo6.Value+
					"',Prereadno1_5='"+txt5APrevReadNo1.Value+
					"',Prereadno2_5='"+txt5APrevReadNo2.Value+
					"',Prereadno3_5='"+txt5APrevReadNo3.Value+
					"',Prereadno4_5='"+txt5APrevReadNo4.Value+
					"',Prereadno5_5='"+txt5APrevReadNo5.Value+
					"',Prereadno6_5='"+txt5APrevReadNo6.Value+
					"',Totmtrreadno1_5='"+txt5APerMETReadNo1.Value+
					"',Totmtrreadno2_5='"+txt5APerMETReadNo2.Value+
					"',Totmtrreadno3_5='"+txt5APerMETReadNo3.Value+
					"',Totmtrreadno4_5='"+txt5APerMETReadNo4.Value+
					"',Totmtrreadno5_5='"+txt5APerMETReadNo5.Value+
					"',Totmtrreadno6_5='"+txt5APerMETReadNo6.Value+
					"',Dtlastinspms93_5b='"+txt5BStockonlastDtMS93.Value+
					"',Dtlastinspms87_5b='"+txt5BStockonlastDtMS87.Value+
					"',Dtlastinspmsulp_5b='"+txt5BStockonlastDtMSulp.Value+
					"',Dtlastinsphsd_5b='"+txt5BStockonlastDtHSD.Value+
					"',Receiptms93_5b='"+txt5BReceiptKL_MS93.Value+
					"',Receiptms87_5b='"+txt5BReceiptKL_MS87.Value+
					"',Receiptmsulp_5b='"+txt5BReceiptKL_MSULP.Value+
					"',Receipthsd_5b='"+txt5BReceiptKL_HSD.Value+
					"',Totstockms93_5b='"+txt5BTotalstkMS93.Value+
					"',Totstockms87_5b='"+txt5BTotalstkMS87.Value+
					"',Totstockmsulp_5b='"+txt5BTotalstkMSULP.Value+
					"',Totstockhsd_5b='"+txt5BTotalstkHSD.Value+
					"',Lessms93_5b='"+txt5BTLessstkMS93.Value+
					"',Lessms87_5b='"+txt5BTLessstkMS87.Value+
					"',Lessmsulp_5b='"+txt5BTLessstkMSULP.Value+
					"',Lesshsd_5b='"+txt5BTLessstkHSD.Value+
					"',Totsalesms93_5b='"+txt5BTotSalesMS93.Value+
					"',Totsalesms87_5b='"+txt5BTotSalesMS87.Value+
					"',Totsalesmsulp_5b='"+txt5BTotSalesMSULP.Value+
					"',Totsaleshsd_5b='"+txt5BTotSalesHSD.Value+
					"',Varms93_5b='"+txt5BVariationMS93.Value+
					"',Varms87_5b='"+txt5BVariationMS87.Value+
					"',Varmsulp_5b='"+txt5BVariationMSULP.Value+
					"',Varhsd_5b='"+txt5BVariationMSULP.Value+
					"',R_Variation_5b='"+txt5BVariationHSD.Value+
					"',Adebar1_6='"+txt6adqbarrel1_0.Value+
					"',Adebar2_6='"+txt6adqbarrel2_0.Value+
					"',Adebar3_6='"+txt6adqbarrel3_0.Value+
					"',Adesp1_6='"+txt6Smallpck1_0.Value+
					"',Adesp2_6='"+txt6Smallpck2_0.Value+
					"',Adesp3_6='"+txt6Smallpck3_0.Value+
					"',Adebar4_6='"+txt6adqbarrel1_1.Value+
					"',Adebar5_6='"+txt6adqbarrel2_1.Value+
					"',Adebar6_6='"+txt6adqbarrel3_1.Value+
					"',Adesp4_6='"+txt6adSmallpck1_1.Value+
					"',Adesp5_6='"+txt6adSmallpck2_1.Value+
					"',Adesp6_6='"+txt6adSmallpck3_1.Value+
					"',Inadebar1_6='"+txt6Inadqbarrel1_0.Value+
					"',Inadebar2_6='"+txt6Inadqbarrel2_0.Value+
					"',Inadebar3_6='"+txt6Inadqbarrel3_0.Value+
					"',Inadesp1_6='"+txt6InSmallpck1_0.Value+
					"',Inadesp2_6='"+txt6InSmallpck2_0.Value+
					"',Inadesp3_6='"+txt6InSmallpck3_0.Value+
					"',Inadebar4_6='"+txt6Inadqbarrel1_1.Value+
					"',Inadebar5_6='"+txt6Inadqbarrel2_1.Value+
					"',Inadebar6_6='"+txt6Inadqbarrel3_1.Value+
					"',Inadesp4_6='"+txt6InSmallpck1_1.Value+
					"',Inadesp5_6='"+txt6InSmallpck2_1.Value+
					"',Inadesp6_6='"+txt6InSmallpck3_1.Value+
					"',Detailsub1_7='"+txt7DetailSub1.Value+
					"',Detailyear1_7='"+txt7DetailSub1_yr.Value+
					"',Detailamt1_7='"+txt7DetailSub1_amt.Value+
					"',Detailsub2_7='"+txt7DetailSub2.Value+
					"',Detailyear2_7='"+txt7DetailSub2_yr.Value+
					"',Detailamt2_7='"+txt7DetailSub2_amt.Value+
					"',Detailsub3_7='"+txt7DetailSub3.Value+
					"',Detailyear3_7='"+txt7DetailSub3_yr.Value+
					"',Detailamt3_7='"+txt7DetailSub3_amt.Value+
					"',Detailsub4_7='"+txt7DetailSub4.Value+
					"',Detailyear4_7='"+txt7DetailSub4_yr.Value+
					"',Detailamt4_7='"+txt7DetailSub4_amt.Value+
					"',Detailsub5_7='"+txt7DetailSub5.Value+
					"',Detailyear5_7='"+txt7DetailSub5_yr.Value+
					"',Detailamt5_7='"+txt7DetailSub5_amt.Value+
					"',Dealersuggestion_8='"+txt8Dealersugggestion.Value+
					"',Marketinfo_9='"+txt9MarInfo.Value+
					"',A10_1='"+c10_1A_Y+
					"',B10_1='"+txt10_1B.Value+
					"',C10_1='"+c10_1C_y+
					"',D10_1='"+c10_1d_y+
					"',E10_1='"+c10_1e_y+
					"',F10_1='"+c10_1f_y+
					"',Fdet10_1='"+txt10_1f.Value+
					"',G10_1='"+c10_1g_y+
					"',Gdet10_1='"+txt10_1g.Value+
					"',A10_2='"+c10_2a_good+
					"',B10_2='"+c10_2b_good+
					"',C10_2='"+c10_2c_y+
					"',Adt10_3='"+txt10_3_aDate.Value+
					"',B10_3='"+c10_3b_y+
					"',C10_3='"+c10_3c_y+
					"',D10_3_ex='"+c10_3d_Ex+
					"',D10_3_vg='"+c10_3d_Vg+
					"',D10_3_g='"+c10_3d_G+
					"',D10_3_av='"+c10_3d_Av+
					"',D10_3_p='"+c10_3d_P+
					"',E10_3_ex='"+c10_3e_Ex+
					"',E10_3_vg='"+c10_3e_Vg+
					"',E10_3_g='"+c10_3e_G+
					"',E10_3_av='"+c10_3e_Av+
					"',E10_3_p='"+c10_3e_P+
					"',A10_4_ex='"+c10_4a_Ex+
					"',A10_4_vg='"+c10_4a_Vg+
					"',A10_4_g='"+c10_4a_G+
					"',A10_4_av='"+c10_4a_Av+
					"',A10_4_p='"+c10_4a_P+
					"',B10_4_ex='"+c10_4b_Ex+
					"',B10_4_vg='"+c10_4b_Vg+
					"',B10_4_g='"+c10_4b_G+
					"',B10_4_av='"+c10_4b_Av+              
					"',B10_4_p='"+c10_4b_P+
					"',C10_4_ex='"+c10_4c_Ex+
					"',C10_4_vg='"+c10_4c_Vg+
					"',C10_4_g='"+c10_4c_G+
					"',C10_4_av='"+c10_4c_Av+
					"',C10_4_p='"+c10_4c_P+
					"',D10_4_ex='"+c10_4d_Ex+
					"',D10_4_vg='"+c10_4d_Vg+
					"',D10_4_g='"+c10_4d_G+
					"',D10_4_av='"+c10_4d_Av+
					"',D10_4_p='"+c10_4d_P+
					"',A10_5_ex='"+c10_5a_Ex+
					"',A10_5_vg='"+c10_5a_Vg+
					"',A10_5_g='"+c10_5a_G+
					"',A10_5_av='"+c10_5a_Av+
					"',A10_5_p='"+c10_5a_P+
					"',B10_5='"+c10_5b_Y+
					"',C10_5='"+c10_5c_Y+
					"',D10_5='"+c10_5d_Y+
					"',A10_6_ex='"+c10_6a_Ex+
					"',A10_6_vg='"+c10_6a_Vg+
					"',A10_6_g='"+c10_6a_G+
					"',A10_6_av='"+c10_6a_Av+
					"',A10_6_p='"+c10_6a_P+
					"',B10_6='"+c10_6b_Y+
					"',C10_6='"+c10_6c_Y+
					"',Action10_6='"+txt10_6c.Value+
					"',A10_7='"+c10_7a_Y+
					"',B10_7='"+c10_7b_Y+
					"',C10_7='"+c10_7c_Y+
					"',D10_7='"+c10_7d_Y+
					"',A12='"+c12a_Y+
					"',B12='"+c12b_Y+
					"',C12='"+c12c_Y+
					"',D12='"+c12d_Y+
					"',E12='"+c12e_Y+
					"',A13='"+c13a_Y+
					"',B13='"+c13b_Y+
					"',C13='"+c13c_Y+
					"',D13='"+c13d_Y+
					"',E13='"+c13e_Y+
					"',F13='"+c13f_Y+
					"',G13='"+c13g_Y+
					"',G13Action='"+txt13g.Value+
					"',H13='"+c13h_Y+
					"',I13='"+c13i_Y+
					"',J13='"+c13j_Y+
					"',K13='"+c13k_Y+
					"',L13='"+c13l_Y+
					"',M13='"+c13m_Y+
					"',N13='"+c13n_Y+
					"',O13='"+c13o_Y+
					"',P13='"+c13p_Y+
					"',Q13='"+c13q_Y+
					"',R13='"+c13r_Y+
					"',S13='"+c13s_Y+
					"',T13='"+c13t_Y+
					"',U13='"+c13u_Y+
					"',V13='"+c13v_Y+
					"',W13='"+c13w_Y+
					"',X13='"+c13x_Y+
					"',Xdet13='"+txt13_nature.Value+
					"',A14N1='"+c14a1_Y+
					"',A14N2='"+c14a2_Y+
					"',A14N3='"+c14a3_Y+
					"',A14N4='"+c14a4_Y+
					"',A14N5='"+c14a5_Y+
					"',A14N6='"+c14a6_Y+
					"',B14N1='"+c14b1_Y+
					"',B14N2='"+c14b2_Y+
					"',B14N3='"+c14b3_Y+
					"',B14N4='"+c14b4_Y+
					"',B14N5='"+c14b5_Y+
					"',B14N6='"+c14b6_Y+
					"',C14N1c='"+c14c1_C+
					"',C14N1s='"+c14c1_S+    
					"',C14N1e='"+c14c1_E+
					"',C14N2c='"+c14c2_C+
					"',C14N2s='"+c14c2_S+
					"',C14N2e='"+c14c2_E+
					"',C14N3c='"+c14c3_C+
					"',C14N3s='"+c14c3_S+
					"',C14N3e='"+c14c3_E+
					"',C14N4c='"+c14c4_C+
					"',C14N4s='"+c14c4_S+
					"',C14N4e='"+c14c4_E+
					"',C14N5c='"+c14c5_C+
					"',C14N5s='"+c14c5_S+
					"',C14N5e='"+c14c5_E+
					"',C14N6c='"+c14c6_C+
					"',C14N6s='"+c14c6_S+
					"',C14N6e='"+c14c6_E+
					"',A15t1='"+c15aT1_Y+
					"',A15t2='"+c15aT2_Y+
					"',A15t3='"+c15aT3_Y+
					"',A15t4='"+c15aT4_Y+
					"',B15t1='"+txt15bT1.Value+
					"',B15t2='"+txt15bT2.Value+
					"',B15t3='"+txt15bT3.Value+
					"',B15t4='"+txt15bT4.Value+
					"',C15t1='"+txt15cT1.Value+
					"',C15t2='"+txt15cT2.Value+
					"',C15t3='"+txt15cT3.Value+
					"',C15t4='"+txt15cT4.Value+
					"',D15t1='"+c15dT1_Y+
					"',D15t2='"+c15dT2_Y+
					"',D15t3='"+c15dT3_Y+
					"',D15t4='"+c15dT4_Y+          
					"',E15t1='"+c15eT1_Y+
					"',E15t2='"+c15eT2_Y+
					"',E15t3='"+c15eT3_Y+
					"',E15t4='"+c15eT4_Y+
					"',Fdet15='"+txt15f.Value+
					"',A16='"+c16a_Y+
					"',B16t1='"+c16bT1_Y+
					"',B16t2='"+c16bT2_Y+
					"',B16t3='"+c16bT3_Y+
					"',B16t4='"+c16bT4_Y+
					"',C16t1='"+c16cT1_Y+
					"',C16t2='"+c16cT2_Y+
					"',C16t3='"+c16cT3_Y+
					"',C16t4='"+c16cT4_Y+
					"',D16t1='"+c16dT1_Y+
					"',D16t2='"+c16dT2_Y+
					"',D16t3='"+c16dT3_Y+
					"',D16t4='"+c16dT4_Y+
					"',Ddet16='"+txt16_Detail.Value+
					"',Adate17='"+txt17a_Date.Value+
					"',Aresult17='"+txt17a_Result.Value+
					"',Bdate17='"+txt17b_Date.Value+
					"',Bresult17='"+txt17b_Result.Value+
					"',Cdate17='"+txt17c_Date.Value+
					"',Cresult17='"+txt17c_Result.Value+
					"',Note17MS='"+txt17MS.Value+
					"',Note17hsd='"+txt17HSD.Value+
					"',Comm18_1='"+txt18_1_Comm.Value+
					"',trans18_2='"+txt18_2_Transport.Value+
					"',pending18_2='"+txt18_2_Pending.Value+
					"',Action18_2='"+txt18_2_Action.Value+
					"',Ptxt18_3='"+txt18_3_product.Value+
					"',P18_3='"+Pro18_3+
					"',Qtytxt18_3='"+txt18_3_quality.Value+
					"',Q18_3='"+Qty18_3+
					"',Invoicetxt18_3='"+txt18_3_Invoice.Value+
					"',I18_3='"+Inv18_3+
					"',Amttxt18_3='"+txt18_3_amount.Value+
					"',A18_3='"+Amt18_3+
					"',Ptxt18_4='"+txt18_4_product.Value+
					"',P18_4='"+Pro18_4+
					"',Qtytxt18_4='"+txt18_4_quantity.Value+		
					"',Q18_4='"+Qty18_4+
					"',Invoicetxt18_4='"+txt18_4_Invoice.Value+
					"',I18_4='"+Inv18_4+
					"',Aamttxt18_4='"+txt18_4_amount.Value+
					"',A18_4='"+Amt18_4+
					"',Action18_4='"+txt18_4_action.Value+
					"',Chargemen_a_18_5='"+txt18_5a.Value+
					"',Insp_bn1_18_5='"+txt18_5bN1.Value+
					"',Insp_bn2_18_5='"+txt18_5bN2.Value+
					"',Insp_bn3_18_5='"+txt18_5bN3.Value+
					"',Insp_bn4_18_5='"+txt18_5bN4.Value+
					"',Insp_bn5_18_5='"+txt18_5bN5.Value+
					"',Insp_bn6_18_5='"+txt18_5bN6.Value+
					"',Repairn1_18_5='"+txt18_5cN1.Value+
					"',Repairn2_18_5='"+txt18_5cN2.Value+
					"',Repairn3_18_5='"+txt18_5cN3.Value+
					"',Repairn4_18_5='"+txt18_5cN4.Value+
					"',Repairn5_18_5='"+txt18_5cN5.Value+
					"',Repairn6_18_5='"+txt18_5cN6.Value+
					"',Ddaten1_18_5='"+txt18_5dN1.Value+
					"',Ddaten2_18_5='"+txt18_5dN2.Value+
					"',Ddaten3_18_5='"+txt18_5dN3.Value+
					"',Ddaten4_18_5='"+txt18_5dN4.Value+
					"',Ddaten5_18_5='"+txt18_5dN5.Value+
					"',Ddaten6_18_5='"+txt18_5dN6.Value+
					"',Edaten1_18_5='"+txt18_5eN1.Value+
					"',Edaten2_18_5='"+txt18_5eN2.Value+
					"',Edaten3_18_5='"+txt18_5eN3.Value+
					"',Edaten4_18_5='"+txt18_5eN4.Value+
					"',Edaten5_18_5='"+txt18_5eN5.Value+
					"',Edaten6_18_5='"+txt18_5eN6.Value+
					"',Fdaten1_18_5='"+txt18_5fN1.Value+
					"',Fdaten2_18_5='"+txt18_5fN2.Value+
					"',Fdaten3_18_5='"+txt18_5fN3.Value+
					"',Fdaten4_18_5='"+txt18_5fN4.Value+
					"',Fdaten5_18_5='"+txt18_5fN5.Value+
					"',Fdaten6_18_5='"+txt18_5fN6.Value+
					"',Reasondelay18_5='"+txt18_5_reasons.Value+
					"',Avg18_6='"+txt18_6aAvg.Value+
					"',Dryout18_6='"+txt18_6bNumber.Value+
					"',Action18_6='"+txt18_6cActionplan.Value+
					"',Sn1_19='"+txt19_0srno1.Value+
					"',Date1_19='"+txt19_0Date1.Value+
					"',Action1_19='"+txt19_0Action1.Value+
					"',Detail1_19='"+txt19_0Detail1.Value+
					"',Sn2_19='"+txt19_0srno2.Value+
					"',Date2_19='"+txt19_0Date2.Value+
					"',Action2_19='"+txt19_0Action2.Value+
					"',Detail2_19='"+txt19_0Detail2.Value+
					"',Sn3_19='"+txt19_0srno3.Value+
					"',Date3_19='"+txt19_0Date3.Value+
					"',Action3_19='"+txt19_0Action3.Value+
					"',Detail3_19='"+txt19_0Detail3.Value+
					"',Sn4_19='"+txt19_0srno4.Value+
					"',Date4_19='"+txt19_0Date4.Value+
					"',Action4_19='"+txt19_0Action4.Value+
					"',Detail4_19='"+txt19_0Detail4.Value+
					"',Sn5_19='"+txt19_0srno5.Value+
					"',Date5_19='"+txt19_0Date5.Value+
					"',Action5_19='"+txt19_0Action5.Value+
					"',Detail5_19='"+txt19_0Detail5.Value+
					"',Sn1_20='"+txt20_0srno1.Value+
					"',Date1_20='"+txt20_0Date1.Value+
					"',Action1_20='"+txt20_0Action1.Value+
					"',Detail1_20='"+txt20_0Detail1.Value+
					"',Sn2_20='"+txt20_0srno2.Value+
					"',Date2_20='"+txt20_0Date2.Value+
					"',Action2_20='"+txt20_0Action2.Value+
					"',Detail2_20='"+txt20_0Detail2.Value+
					"',Sn3_20='"+txt20_0srno3.Value+
					"',Date3_20='"+txt20_0Date3.Value+
					"',Action3_20='"+txt20_0Action3.Value+
					"',Detail3_20='"+txt20_0Detail3.Value+
					"',Sn4_20='"+txt20_0srno4.Value+
					"',Date4_20='"+txt20_0Date4.Value+
					"',Action4_20='"+txt20_0Action4.Value+
					"',Detail4_20='"+txt20_0Detail4.Value+
					"',Sn5_20='"+txt20_0srno5.Value+
					"',Date5_20='"+txt20_0Date5.Value+
					"',Action5_20='"+txt20_0Action5.Value+
					"',Detail5_20='"+txt20_0Detail5.Value+
					"',Dealersign='"+txtSOD.Value+
					"',Iocsign='"+txtSignIOC.Value+
					"',Iocname='"+txtIOCName.Value+
					"',Iocdesign='"+txtIOCdesign.Value+
					"',Iocdate='"+txtIOCDate.Value+
					"',st5bdate='"+txt5bstdate.Value+
					"',tba4='"+txt4tba.Value+
					"',pro15t1='"+txtpro15t1.Value+
					"',pro15t2='"+txtpro15t2.Value+
					"',pro15t3='"+txtpro15t3.Value+
					"',pro15t4='"+txtpro15t4.Value+
					"' where ROIID='"+DropDownList1.SelectedItem.Text+"'";
			
				SqlCommand	scom5  = new SqlCommand( str5 ,con  );
				scom5.ExecuteNonQuery();
				
				scom5.Dispose();
				con.Close();
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:Edit()  The ROI Report No. "+ DropDownList1.SelectedItem.Text +" Updated.  userid  "+uid);
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:Edit()  EXCEPTION "+ ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to Enable the DropDownList.On which record we can edit or Print.
		/// </summary>
		private void btnbrw_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection	con  = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
				con.Open();	
				btnSave.Disabled=true;
				btnEdit.Disabled=false;
				btndelete.Disabled=false;
				DropDownList1.Enabled=true;
				string str6="select ROIID from ROI_ANALYSIS";
				SqlCommand	scom6  = new SqlCommand( str6 ,con  );
				SqlDataReader roiid=scom6.ExecuteReader();
				DropDownList1.Items.Clear();
				DropDownList1.Items.Add("Select");
				while(roiid.Read())
				{
					DropDownList1.Items.Add(roiid.GetValue(0).ToString());
				}
				scom6.Dispose();
				con.Close();
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:btnbrw_Click()  EXCEPTION "+ ex.Message+"  userid  "+uid);
			}
		}
        
		/// <summary>
		/// This method is used to select the particular ROIID from dropdown list to fetch the record 
		/// from the database .
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection	con  = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
				con.Open();	
				string str7="select * from ROI_ANALYSIS where ROIID='"+DropDownList1.SelectedItem.Text+"'";
				SqlCommand	scom7  = new SqlCommand( str7 ,con  );
				SqlDataReader rd7=scom7.ExecuteReader();
			
				if(rd7.Read())
				{
					txtareaDLnameaddr.Value=rd7.GetValue(1).ToString();
					asite=rd7.GetValue(2).ToString();
					bsite=rd7.GetValue(3).ToString();
					coco=rd7.GetValue(4).ToString();
					catss=rd7.GetValue(5).ToString();
					catfs=rd7.GetValue(6).ToString();
					partship=rd7.GetValue(7).ToString();
					proship=rd7.GetValue(8).ToString();
					other=rd7.GetValue(9).ToString();
					txtDivisionOff.Text=rd7.GetValue(10).ToString();
					txtDistrict.Value=rd7.GetValue(11).ToString();
					txtDate.Text=rd7.GetValue(12).ToString();
					txtSalesPerformanceDate.Value=rd7.GetValue(13).ToString();
					txtCummulativeuptoDate.Value=rd7.GetValue(14).ToString();
					txtMSTarget1.Value=rd7.GetValue(15).ToString();
					txtMScyear1.Value=rd7.GetValue(16).ToString();
					txtMSLyear1.Value=rd7.GetValue(17).ToString();
					txtMSTarget2.Value=rd7.GetValue(18).ToString();
					txtMSCyear2.Value=rd7.GetValue(19).ToString();
					txtMSLyear2.Value=rd7.GetValue(20).ToString();
					txtHSDTarget1.Value=rd7.GetValue(21).ToString();
					txtHSDCYear1.Value=rd7.GetValue(22).ToString();
					txtHSDLYear1.Value=rd7.GetValue(23).ToString();
					txtHSDTarget2.Value=rd7.GetValue(24).ToString();
					txtHSDCYear2.Value=rd7.GetValue(25).ToString();
					txtHSDLYear2.Value=rd7.GetValue(26).ToString();
					txtLubesTarget1.Value=rd7.GetValue(27).ToString();
					txtLubesCYear1.Value=rd7.GetValue(28).ToString();
					txtLubesLYear1.Value=rd7.GetValue(29).ToString();
					txtLubesTarget2.Value=rd7.GetValue(30).ToString();
					txtLubesCYear2.Value=rd7.GetValue(31).ToString();
					txtLubesLYear2.Value=rd7.GetValue(32).ToString();
					txtGreaseTarget1.Value=rd7.GetValue(33).ToString();
					txtGreaseCYear1.Value=rd7.GetValue(34).ToString();
					txtGreaseLYear1.Value=rd7.GetValue(35).ToString();
					txtGreaseTarget2.Value=rd7.GetValue(36).ToString();
					txtGreaseCYear2.Value=rd7.GetValue(37).ToString();
					txtGreaseLYear2.Value=rd7.GetValue(38).ToString();
					txtLFratioTarget1.Value=rd7.GetValue(39).ToString();
					txtLFratioCYear1.Value=rd7.GetValue(40).ToString();
					txtLFratioLYear1.Value=rd7.GetValue(41).ToString();
					txtLFratioTarget2.Value=rd7.GetValue(42).ToString();
					txtLFratioCYear2.Value=rd7.GetValue(43).ToString();
					txtLFratioLyear2.Value=rd7.GetValue(44).ToString();
					txtIOCMS1.Value=rd7.GetValue(45).ToString();
					txtIOCHSD1.Value=rd7.GetValue(46).ToString();
					txtIOCMS2.Value=rd7.GetValue(47).ToString();
					txtIOCHSD2.Value=rd7.GetValue(48).ToString();
					txtIOCMS3.Value=rd7.GetValue(49).ToString();
					txtIOCHSD3.Value=rd7.GetValue(50).ToString();
					txtOMCMS1.Value=rd7.GetValue(51).ToString();
					txtOMCHSD1.Value=rd7.GetValue(52).ToString();
					txtOMCMS2.Value=rd7.GetValue(53).ToString();
					txtOMCHSD2.Value=rd7.GetValue(54).ToString();
					txtOMCMS3.Value=rd7.GetValue(55).ToString();
					txtOMCHSD3.Value=rd7.GetValue(56).ToString();
					txtTOTALMS1.Value=rd7.GetValue(57).ToString();
					txtTOTALHSD1.Value=rd7.GetValue(58).ToString();
					txtTOTALMS2.Value=rd7.GetValue(59).ToString();
					txtTOTALHSD2.Value=rd7.GetValue(60).ToString();
					txtTOTALMS3.Value=rd7.GetValue(61).ToString();
					txtTOTALHSD3.Value=rd7.GetValue(62).ToString();
					txtReasonLH_taAvgMS.Value=rd7.GetValue(63).ToString();
					txtReasonLH_taAvgHSD.Value=rd7.GetValue(64).ToString();
					newro=rd7.GetValue(65).ToString();
					txt3a.Value=rd7.GetValue(66).ToString();
					txt3adatepk.Value=rd7.GetValue(67).ToString();
					txt3b.Value=rd7.GetValue(68).ToString();
					txt3bdatepk.Value=rd7.GetValue(69).ToString();
					txt3c.Value=rd7.GetValue(70).ToString();
					txt3cdatepk.Value=rd7.GetValue(71).ToString();
					txt4avgsaleMS.Value=rd7.GetValue(72).ToString();
					txt4avgsaleHSD.Value=rd7.GetValue(73).ToString();
					txt4avgsaleLUBES.Value=rd7.GetValue(74).ToString();
					txt4NilSaleaMS.Value=rd7.GetValue(75).ToString();
					txt4NilSaleaHSD.Value=rd7.GetValue(76).ToString();
					txt4NilSaleaLUBES.Value=rd7.GetValue(77).ToString();
					txt4DryOutMS.Value=rd7.GetValue(78).ToString();
					txt4DryOutHSD.Value=rd7.GetValue(79).ToString();
					txt4DryOutLUBES.Value=rd7.GetValue(80).ToString();
					txtarea4NilSalesDryout.Value=rd7.GetValue(81).ToString();
					txt5AProNo1.Value=rd7.GetValue(82).ToString();
					txt5AProNo2.Value=rd7.GetValue(83).ToString();
					txt5AProNo3.Value=rd7.GetValue(84).ToString();
					txt5AProNo4.Value=rd7.GetValue(85).ToString();
					txt5AProNo5.Value=rd7.GetValue(86).ToString();
					txt5AProNo6.Value=rd7.GetValue(87).ToString();
					txt5AMakeNo1.Value=rd7.GetValue(88).ToString();
					txt5AMakeNo2.Value=rd7.GetValue(89).ToString();
					txt5AMakeNo3.Value=rd7.GetValue(90).ToString();
					txt5AMakeNo4.Value=rd7.GetValue(91).ToString();
					txt5AMakeNo5.Value=rd7.GetValue(92).ToString();
					txt5AMakeNo6.Value=rd7.GetValue(93).ToString();
					txt5ACuuReadNo1.Value=rd7.GetValue(94).ToString();
					txt5ACuuReadNo2.Value=rd7.GetValue(95).ToString();
					txt5ACuuReadNo3.Value=rd7.GetValue(96).ToString();
					txt5ACuuReadNo4.Value=rd7.GetValue(97).ToString();
					txt5ACuuReadNo5.Value=rd7.GetValue(98).ToString();
					txt5ACuuReadNo6.Value=rd7.GetValue(99).ToString();
					txt5APrevReadNo1.Value=rd7.GetValue(100).ToString();
					txt5APrevReadNo2.Value=rd7.GetValue(101).ToString();
					txt5APrevReadNo3.Value=rd7.GetValue(102).ToString();
					txt5APrevReadNo4.Value=rd7.GetValue(103).ToString();
					txt5APrevReadNo5.Value=rd7.GetValue(104).ToString();
					txt5APrevReadNo6.Value=rd7.GetValue(105).ToString();
					txt5APerMETReadNo1.Value=rd7.GetValue(106).ToString();
					txt5APerMETReadNo2.Value=rd7.GetValue(107).ToString();
					txt5APerMETReadNo3.Value=rd7.GetValue(108).ToString();
					txt5APerMETReadNo4.Value=rd7.GetValue(109).ToString();
					txt5APerMETReadNo5.Value=rd7.GetValue(110).ToString();
					txt5APerMETReadNo6.Value=rd7.GetValue(111).ToString();
					txt5BStockonlastDtMS93.Value=rd7.GetValue(112).ToString();
					txt5BStockonlastDtMS87.Value=rd7.GetValue(113).ToString();
					txt5BStockonlastDtMSulp.Value=rd7.GetValue(114).ToString();
					txt5BStockonlastDtHSD.Value=rd7.GetValue(115).ToString();
					txt5BReceiptKL_MS93.Value=rd7.GetValue(116).ToString();
					txt5BReceiptKL_MS87.Value=rd7.GetValue(117).ToString();
					txt5BReceiptKL_MSULP.Value=rd7.GetValue(118).ToString();
					txt5BReceiptKL_HSD.Value=rd7.GetValue(119).ToString();
					txt5BTotalstkMS93.Value=rd7.GetValue(120).ToString();
					txt5BTotalstkMS87.Value=rd7.GetValue(121).ToString();
					txt5BTotalstkMSULP.Value=rd7.GetValue(122).ToString();
					txt5BTotalstkHSD.Value=rd7.GetValue(123).ToString();
					txt5BTLessstkMS93.Value=rd7.GetValue(124).ToString();
					txt5BTLessstkMS87.Value=rd7.GetValue(125).ToString();
					txt5BTLessstkMSULP.Value=rd7.GetValue(126).ToString();
					txt5BTLessstkHSD.Value=rd7.GetValue(127).ToString();
					txt5BTotSalesMS93.Value=rd7.GetValue(128).ToString();
					txt5BTotSalesMS87.Value=rd7.GetValue(129).ToString();
					txt5BTotSalesMSULP.Value=rd7.GetValue(130).ToString();
					txt5BTotSalesHSD.Value=rd7.GetValue(131).ToString();
					txt5BVariationMS93.Value=rd7.GetValue(132).ToString();
					txt5BVariationMS87.Value=rd7.GetValue(133).ToString();
					txt5BVariationMSULP.Value=rd7.GetValue(134).ToString();
					txt5BVariationHSD.Value=rd7.GetValue(135).ToString();
					txtarea5BReasonVar.Value=rd7.GetValue(136).ToString();
					txt6adqbarrel1_0.Value=rd7.GetValue(137).ToString();
					txt6adqbarrel2_0.Value=rd7.GetValue(138).ToString();
					txt6adqbarrel3_0.Value=rd7.GetValue(139).ToString();
					txt6Smallpck1_0.Value=rd7.GetValue(140).ToString();
					txt6Smallpck2_0.Value=rd7.GetValue(141).ToString();
					txt6Smallpck3_0.Value=rd7.GetValue(142).ToString();
					txt6adqbarrel1_1.Value=rd7.GetValue(143).ToString();
					txt6adqbarrel2_1.Value=rd7.GetValue(144).ToString();
					txt6adqbarrel3_1.Value=rd7.GetValue(145).ToString();
					txt6adSmallpck1_1.Value=rd7.GetValue(146).ToString();
					txt6adSmallpck2_1.Value=rd7.GetValue(147).ToString();
					txt6adSmallpck3_1.Value=rd7.GetValue(148).ToString();
					txt6Inadqbarrel1_0.Value=rd7.GetValue(149).ToString();
					txt6Inadqbarrel2_0.Value=rd7.GetValue(150).ToString();
					txt6Inadqbarrel3_0.Value=rd7.GetValue(151).ToString();
					txt6InSmallpck1_0.Value=rd7.GetValue(152).ToString();
					txt6InSmallpck2_0.Value=rd7.GetValue(153).ToString();
					txt6InSmallpck3_0.Value=rd7.GetValue(154).ToString();
					txt6Inadqbarrel1_1.Value=rd7.GetValue(155).ToString();
					txt6Inadqbarrel2_1.Value=rd7.GetValue(156).ToString();
					txt6Inadqbarrel3_1.Value=rd7.GetValue(157).ToString();
					txt6InSmallpck1_1.Value=rd7.GetValue(158).ToString();
					txt6InSmallpck2_1.Value=rd7.GetValue(159).ToString();
					txt6InSmallpck3_1.Value=rd7.GetValue(160).ToString();
					txt7DetailSub1.Value=rd7.GetValue(161).ToString();
					txt7DetailSub1_yr.Value=rd7.GetValue(162).ToString();
					txt7DetailSub1_amt.Value=rd7.GetValue(163).ToString();
					txt7DetailSub2.Value=rd7.GetValue(164).ToString();
					txt7DetailSub2_yr.Value=rd7.GetValue(165).ToString();
					txt7DetailSub2_amt.Value=rd7.GetValue(166).ToString();
					txt7DetailSub3.Value=rd7.GetValue(167).ToString();
					txt7DetailSub3_yr.Value=rd7.GetValue(168).ToString();
					txt7DetailSub3_amt.Value=rd7.GetValue(169).ToString();
					txt7DetailSub4.Value=rd7.GetValue(170).ToString();
					txt7DetailSub4_yr.Value=rd7.GetValue(171).ToString();
					txt7DetailSub4_amt.Value=rd7.GetValue(172).ToString();
					txt7DetailSub5.Value=rd7.GetValue(173).ToString();
					txt7DetailSub5_yr.Value=rd7.GetValue(174).ToString();
					txt7DetailSub5_amt.Value=rd7.GetValue(175).ToString();
					txt8Dealersugggestion.Value=rd7.GetValue(176).ToString();
					txt9MarInfo.Value=rd7.GetValue(177).ToString();
					c10_1A_Y=rd7.GetValue(178).ToString();
					txt10_1B.Value=rd7.GetValue(179).ToString();
					c10_1C_y=rd7.GetValue(180).ToString();
					c10_1d_y=rd7.GetValue(181).ToString();
					c10_1e_y=rd7.GetValue(182).ToString();
					c10_1f_y=rd7.GetValue(183).ToString();
					txt10_1f.Value=rd7.GetValue(184).ToString();
					c10_1g_y=rd7.GetValue(185).ToString();
					txt10_1g.Value=rd7.GetValue(186).ToString();
					c10_2a_good=rd7.GetValue(187).ToString();
					c10_2b_good=rd7.GetValue(188).ToString();
					c10_2c_y=rd7.GetValue(189).ToString();
					txt10_3_aDate.Value=rd7.GetValue(190).ToString();
					c10_3b_y=rd7.GetValue(191).ToString();
					c10_3c_y=rd7.GetValue(192).ToString();
					c10_3d_Ex=rd7.GetValue(193).ToString();
					c10_3d_Vg=rd7.GetValue(194).ToString();
					c10_3d_G=rd7.GetValue(195).ToString();
					c10_3d_Av=rd7.GetValue(196).ToString();
					c10_3d_P=rd7.GetValue(197).ToString();
					c10_3e_Ex=rd7.GetValue(198).ToString();
					c10_3e_Vg=rd7.GetValue(199).ToString();
					c10_3e_G=rd7.GetValue(200).ToString();
					c10_3e_Av=rd7.GetValue(201).ToString();
					c10_3e_P=rd7.GetValue(202).ToString();
					c10_4a_Ex=rd7.GetValue(203).ToString();
					c10_4a_Vg=rd7.GetValue(204).ToString();
					c10_4a_G=rd7.GetValue(205).ToString();
					c10_4a_Av=rd7.GetValue(206).ToString();
					c10_4a_P=rd7.GetValue(207).ToString();
					c10_4b_Ex=rd7.GetValue(208).ToString();
					c10_4b_Vg=rd7.GetValue(209).ToString();
					c10_4b_G=rd7.GetValue(210).ToString();
					c10_4b_Av=rd7.GetValue(211).ToString();
					c10_4b_P=rd7.GetValue(212).ToString();
					c10_4c_Ex=rd7.GetValue(213).ToString();
					c10_4c_Vg=rd7.GetValue(214).ToString();
					c10_4c_G=rd7.GetValue(215).ToString();
					c10_4c_Av=rd7.GetValue(216).ToString();
					c10_4c_P=rd7.GetValue(217).ToString();
					c10_4d_Ex=rd7.GetValue(218).ToString();
					c10_4d_Vg=rd7.GetValue(219).ToString();
					c10_4d_G=rd7.GetValue(220).ToString();
					c10_4d_Av=rd7.GetValue(221).ToString();
					c10_4d_P=rd7.GetValue(222).ToString();
					c10_5a_Ex=rd7.GetValue(223).ToString();
					c10_5a_Vg=rd7.GetValue(224).ToString();
					c10_5a_G=rd7.GetValue(225).ToString();
					c10_5a_Av=rd7.GetValue(226).ToString();
					c10_5a_P=rd7.GetValue(227).ToString();
					c10_5b_Y=rd7.GetValue(228).ToString();
					c10_5c_Y=rd7.GetValue(229).ToString();
					c10_5d_Y=rd7.GetValue(230).ToString();
					c10_6a_Ex=rd7.GetValue(231).ToString();
					c10_6a_Vg=rd7.GetValue(232).ToString();
					c10_6a_G=rd7.GetValue(233).ToString();
					c10_6a_Av=rd7.GetValue(234).ToString();
					c10_6a_P=rd7.GetValue(235).ToString();
					c10_6b_Y=rd7.GetValue(236).ToString();
					c10_6c_Y=rd7.GetValue(237).ToString();
					txt10_6c.Value=rd7.GetValue(238).ToString();
					c10_7a_Y=rd7.GetValue(239).ToString();
					c10_7b_Y=rd7.GetValue(240).ToString();
					c10_7c_Y=rd7.GetValue(241).ToString();
					c10_7d_Y=rd7.GetValue(242).ToString();
					c12a_Y=rd7.GetValue(243).ToString();
					c12b_Y=rd7.GetValue(244).ToString();
					c12c_Y=rd7.GetValue(245).ToString();
					c12d_Y=rd7.GetValue(246).ToString();
					c12e_Y=rd7.GetValue(247).ToString();
					c13a_Y=rd7.GetValue(248).ToString();
					c13b_Y=rd7.GetValue(249).ToString();
					c13c_Y=rd7.GetValue(250).ToString();
					c13d_Y=rd7.GetValue(251).ToString();
					c13e_Y=rd7.GetValue(252).ToString();
					c13f_Y=rd7.GetValue(253).ToString();
					c13g_Y=rd7.GetValue(254).ToString();
					txt13g.Value=rd7.GetValue(255).ToString();
					c13h_Y=rd7.GetValue(256).ToString();
					c13i_Y=rd7.GetValue(257).ToString();
					c13j_Y=rd7.GetValue(258).ToString();
					c13k_Y=rd7.GetValue(259).ToString();
					c13l_Y=rd7.GetValue(260).ToString();
					c13m_Y=rd7.GetValue(261).ToString();
					c13n_Y=rd7.GetValue(262).ToString();
					c13o_Y=rd7.GetValue(263).ToString();
					c13p_Y=rd7.GetValue(264).ToString();
					c13q_Y=rd7.GetValue(265).ToString();
					c13r_Y=rd7.GetValue(266).ToString();
					c13s_Y=rd7.GetValue(267).ToString();
					c13t_Y=rd7.GetValue(268).ToString();
					c13u_Y=rd7.GetValue(269).ToString();
					c13v_Y=rd7.GetValue(270).ToString();
					c13w_Y=rd7.GetValue(271).ToString();
					c13x_Y=rd7.GetValue(272).ToString();
					txt13_nature.Value=rd7.GetValue(273).ToString();
					c14a1_Y=rd7.GetValue(274).ToString();
					c14a2_Y=rd7.GetValue(275).ToString();
					c14a3_Y=rd7.GetValue(276).ToString();
					c14a4_Y=rd7.GetValue(277).ToString();
					c14a5_Y=rd7.GetValue(278).ToString();
					c14a6_Y=rd7.GetValue(279).ToString();
					c14b1_Y=rd7.GetValue(280).ToString();
					c14b2_Y=rd7.GetValue(281).ToString();
					c14b3_Y=rd7.GetValue(282).ToString();
					c14b4_Y=rd7.GetValue(283).ToString();
					c14b5_Y=rd7.GetValue(284).ToString();
					c14b6_Y=rd7.GetValue(285).ToString();
					c14c1_C=rd7.GetValue(286).ToString();
					c14c1_S=rd7.GetValue(287).ToString();
					c14c1_E=rd7.GetValue(288).ToString();
					c14c2_C=rd7.GetValue(289).ToString();
					c14c2_S=rd7.GetValue(290).ToString();
					c14c2_E=rd7.GetValue(291).ToString();
					c14c3_C=rd7.GetValue(292).ToString();
					c14c3_S=rd7.GetValue(293).ToString();
					c14c3_E=rd7.GetValue(294).ToString();
					c14c4_C=rd7.GetValue(295).ToString();
					c14c4_S=rd7.GetValue(296).ToString();
					c14c4_E=rd7.GetValue(297).ToString();
					c14c5_C=rd7.GetValue(298).ToString();
					c14c5_S=rd7.GetValue(299).ToString();
					c14c5_E=rd7.GetValue(300).ToString();
					c14c6_C=rd7.GetValue(301).ToString();
					c14c6_S=rd7.GetValue(302).ToString();
					c14c6_E=rd7.GetValue(303).ToString();
					c15aT1_Y=rd7.GetValue(304).ToString();
					c15aT2_Y=rd7.GetValue(305).ToString();
					c15aT3_Y=rd7.GetValue(306).ToString();
					c15aT4_Y=rd7.GetValue(307).ToString();
					txt15bT1.Value=rd7.GetValue(308).ToString();
					txt15bT2.Value=rd7.GetValue(309).ToString();
					txt15bT3.Value=rd7.GetValue(310).ToString();
					txt15bT4.Value=rd7.GetValue(311).ToString();
					txt15cT1.Value=rd7.GetValue(312).ToString();
					txt15cT2.Value=rd7.GetValue(313).ToString();
					txt15cT3.Value=rd7.GetValue(314).ToString();
					txt15cT4.Value=rd7.GetValue(315).ToString();
					c15dT1_Y=rd7.GetValue(316).ToString();
					c15dT2_Y=rd7.GetValue(317).ToString();
					c15dT3_Y=rd7.GetValue(318).ToString();
					c15dT4_Y=rd7.GetValue(319).ToString();
					c15eT1_Y=rd7.GetValue(320).ToString();
					c15eT2_Y=rd7.GetValue(321).ToString();
					c15eT3_Y=rd7.GetValue(322).ToString();
					c15eT4_Y=rd7.GetValue(323).ToString();
					txt15f.Value=rd7.GetValue(324).ToString();
					c16a_Y=rd7.GetValue(325).ToString();
					c16bT1_Y=rd7.GetValue(326).ToString();
					c16bT2_Y=rd7.GetValue(327).ToString();
					c16bT3_Y=rd7.GetValue(328).ToString();
					c16bT4_Y=rd7.GetValue(329).ToString();
					c16cT1_Y=rd7.GetValue(330).ToString();
					c16cT2_Y=rd7.GetValue(331).ToString();
					c16cT3_Y=rd7.GetValue(332).ToString();
					c16cT4_Y=rd7.GetValue(333).ToString();
					c16dT1_Y=rd7.GetValue(334).ToString();
					c16dT2_Y=rd7.GetValue(335).ToString();
					c16dT3_Y=rd7.GetValue(336).ToString();
					c16dT4_Y=rd7.GetValue(337).ToString();
					txt16_Detail.Value=rd7.GetValue(338).ToString();
					txt17a_Date.Value=rd7.GetValue(339).ToString();
					txt17a_Result.Value=rd7.GetValue(340).ToString();
					txt17b_Date.Value=rd7.GetValue(341).ToString();
					txt17b_Result.Value=rd7.GetValue(342).ToString();
					txt17c_Date.Value=rd7.GetValue(343).ToString();
					txt17c_Result.Value=rd7.GetValue(344).ToString();
					txt17MS.Value=rd7.GetValue(345).ToString();
					txt17HSD.Value=rd7.GetValue(346).ToString();

				
					txt18_1_Comm.Value=rd7.GetValue(347).ToString();
					txt18_2_Transport.Value=rd7.GetValue(348).ToString();
					txt18_2_Pending.Value=rd7.GetValue(349).ToString();
					txt18_2_Action.Value=rd7.GetValue(350).ToString();
					txt18_3_product.Value=rd7.GetValue(351).ToString();
					Pro18_3=rd7.GetValue(352).ToString();
					txt18_3_quality.Value=rd7.GetValue(353).ToString();
					Qty18_3=rd7.GetValue(354).ToString();
					txt18_3_Invoice.Value=rd7.GetValue(355).ToString();
					Inv18_3=rd7.GetValue(356).ToString();
					txt18_3_amount.Value=rd7.GetValue(357).ToString();
					Amt18_3=rd7.GetValue(358).ToString();
					txt18_4_product.Value=rd7.GetValue(359).ToString();
					Pro18_4=rd7.GetValue(360).ToString();
					txt18_4_quantity.Value=rd7.GetValue(361).ToString();
					Qty18_4=rd7.GetValue(362).ToString();
					txt18_4_Invoice.Value=rd7.GetValue(363).ToString();
					Inv18_4=rd7.GetValue(364).ToString();
					txt18_4_amount.Value=rd7.GetValue(365).ToString();
					Amt18_4=rd7.GetValue(366).ToString();
					txt18_4_action.Value=rd7.GetValue(367).ToString();
					txt18_5a.Value=rd7.GetValue(368).ToString();
					txt18_5bN1.Value=rd7.GetValue(369).ToString();
					txt18_5bN2.Value=rd7.GetValue(370).ToString();
					txt18_5bN3.Value=rd7.GetValue(371).ToString();
					txt18_5bN4.Value=rd7.GetValue(372).ToString();
					txt18_5bN5.Value=rd7.GetValue(373).ToString();
					txt18_5bN6.Value=rd7.GetValue(374).ToString();
					txt18_5cN1.Value=rd7.GetValue(375).ToString();
					txt18_5cN2.Value=rd7.GetValue(376).ToString();
					txt18_5cN3.Value=rd7.GetValue(377).ToString();
					txt18_5cN4.Value=rd7.GetValue(378).ToString();
					txt18_5cN5.Value=rd7.GetValue(379).ToString();
					txt18_5cN6.Value=rd7.GetValue(380).ToString();
					txt18_5dN1.Value=rd7.GetValue(381).ToString();
					txt18_5dN2.Value=rd7.GetValue(382).ToString();
					txt18_5dN3.Value=rd7.GetValue(383).ToString();
					txt18_5dN4.Value=rd7.GetValue(384).ToString();
					txt18_5dN5.Value=rd7.GetValue(385).ToString();
					txt18_5dN6.Value=rd7.GetValue(386).ToString();
					txt18_5eN1.Value=rd7.GetValue(387).ToString();
					txt18_5eN2.Value=rd7.GetValue(388).ToString();
					txt18_5eN3.Value=rd7.GetValue(389).ToString();
					txt18_5eN4.Value=rd7.GetValue(390).ToString();
					txt18_5eN5.Value=rd7.GetValue(391).ToString();
					txt18_5eN6.Value=rd7.GetValue(392).ToString();
					txt18_5fN1.Value=rd7.GetValue(393).ToString();
					txt18_5fN2.Value=rd7.GetValue(394).ToString();
					txt18_5fN3.Value=rd7.GetValue(395).ToString();
					txt18_5fN4.Value=rd7.GetValue(396).ToString();
					txt18_5fN5.Value=rd7.GetValue(397).ToString();
					txt18_5fN6.Value=rd7.GetValue(398).ToString();
					txt18_5_reasons.Value=rd7.GetValue(399).ToString();
					txt18_6aAvg.Value=rd7.GetValue(400).ToString();
					txt18_6bNumber.Value=rd7.GetValue(401).ToString();
					txt18_6cActionplan.Value=rd7.GetValue(402).ToString();
					txt19_0srno1.Value=rd7.GetValue(403).ToString();
					txt19_0Date1.Value=rd7.GetValue(404).ToString();
					txt19_0Action1.Value=rd7.GetValue(405).ToString();
					txt19_0Detail1.Value=rd7.GetValue(406).ToString();
					txt19_0srno2.Value=rd7.GetValue(407).ToString();
					txt19_0Date2.Value=rd7.GetValue(408).ToString();
					txt19_0Action2.Value=rd7.GetValue(409).ToString();
					txt19_0Detail2.Value=rd7.GetValue(410).ToString();
					txt19_0srno3.Value=rd7.GetValue(411).ToString();
					txt19_0Date3.Value=rd7.GetValue(412).ToString();
					txt19_0Action3.Value=rd7.GetValue(413).ToString();
					txt19_0Detail3.Value=rd7.GetValue(414).ToString();
					txt19_0srno4.Value=rd7.GetValue(415).ToString();
					txt19_0Date4.Value=rd7.GetValue(416).ToString();
					txt19_0Action4.Value=rd7.GetValue(417).ToString();
					txt19_0Detail4.Value=rd7.GetValue(418).ToString();
					txt19_0srno5.Value=rd7.GetValue(419).ToString();
					txt19_0Date5.Value=rd7.GetValue(420).ToString();
					txt19_0Action5.Value=rd7.GetValue(421).ToString();
					txt19_0Detail5.Value=rd7.GetValue(422).ToString();
					txt20_0srno1.Value=rd7.GetValue(423).ToString();
					txt20_0Date1.Value=rd7.GetValue(424).ToString();
					txt20_0Action1.Value=rd7.GetValue(425).ToString();
					txt20_0Detail1.Value=rd7.GetValue(426).ToString();
					txt20_0srno2.Value=rd7.GetValue(427).ToString();
					txt20_0Date2.Value=rd7.GetValue(428).ToString();
					txt20_0Action2.Value=rd7.GetValue(429).ToString();
					txt20_0Detail2.Value=rd7.GetValue(430).ToString();
					txt20_0srno3.Value=rd7.GetValue(431).ToString();
					txt20_0Date3.Value=rd7.GetValue(432).ToString();
					txt20_0Action3.Value=rd7.GetValue(433).ToString();
					txt20_0Detail3.Value=rd7.GetValue(434).ToString();
					txt20_0srno4.Value=rd7.GetValue(435).ToString();
					txt20_0Date4.Value=rd7.GetValue(436).ToString();
					txt20_0Action4.Value=rd7.GetValue(437).ToString();
					txt20_0Detail4.Value=rd7.GetValue(438).ToString();
					txt20_0srno5.Value=rd7.GetValue(439).ToString();
					txt20_0Date5.Value=rd7.GetValue(440).ToString();
					txt20_0Action5.Value=rd7.GetValue(441).ToString();
					txt20_0Detail5.Value=rd7.GetValue(442).ToString();
					txtSOD.Value=rd7.GetValue(443).ToString();
					txtSignIOC.Value=rd7.GetValue(444).ToString();
					txtIOCName.Value=rd7.GetValue(445).ToString();
					txtIOCdesign.Value=rd7.GetValue(446).ToString();
					txtIOCDate.Value=rd7.GetValue(447).ToString();
					txt5bstdate.Value=rd7.GetValue(448).ToString();
					txt4tba.Value=rd7.GetValue(449).ToString();
					txtpro15t1.Value=rd7.GetValue(450).ToString();
					txtpro15t2.Value=rd7.GetValue(451).ToString();
					txtpro15t3.Value=rd7.GetValue(452).ToString();
					txtpro15t4.Value=rd7.GetValue(453).ToString();
				}
			
				//   1 for return Radiobutton is checked ,0 for unchecked.

				setRadio(asite,chkasite);
				setRadio(bsite,chkbsite);
				setRadio(coco,chkcoco);
				setRadio(c10_3d_Ex,chk10_3d_Ex);
				setRadio(c10_3d_Vg,chk10_3d_Vg);
				setRadio(c10_3d_G,chk10_3d_G);
				setRadio(c10_3d_Av,chk10_3d_Av);
				setRadio(c10_3d_P,chk10_3d_P);
				setRadio(c10_3e_Ex,chk10_3e_Ex);
				setRadio(c10_3e_Vg,chk10_3e_Vg);
				setRadio(c10_3e_G,chk10_3e_G);
				setRadio(c10_3e_Av,chk10_3e_Av);
				setRadio(c10_3e_P,chk10_3e_P);
				setRadio(c10_4a_Ex,chk10_4a_Ex);
				setRadio(c10_4a_Vg,chk10_4a_Vg);
				setRadio(c10_4a_G,chk10_4a_G);
				setRadio(c10_4a_Av,chk10_4a_Av);
				setRadio(c10_4a_P,chk10_4a_P);
				setRadio(c10_4b_Ex,chk10_4b_Ex);
				setRadio(c10_4b_Vg,chk10_4b_Vg);
				setRadio(c10_4b_G,chk10_4b_G);
				setRadio(c10_4b_Av,chk10_4b_Av);
				setRadio(c10_4b_P,chk10_4b_P);
				setRadio(c10_4c_Ex,chk10_4c_Ex);
				setRadio(c10_4c_Vg,chk10_4c_Vg);
				setRadio(c10_4c_G,chk10_4c_G);
				setRadio(c10_4c_Av,chk10_4c_Av);
				setRadio(c10_4c_P,chk10_4c_P);
				setRadio(c10_4d_Ex,chk10_4d_Ex);
				setRadio(c10_4d_Vg,chk10_4d_Vg);
				setRadio(c10_4d_G,chk10_4d_G);
				setRadio(c10_4d_Av,chk10_4d_Av);
				setRadio(c10_4d_P,chk10_4d_P);
				setRadio(c10_5a_Ex,chk10_5a_Ex);
				setRadio(c10_5a_Vg,chk10_5a_Vg);
				setRadio(c10_5a_G,chk10_5a_G);
				setRadio(c10_5a_Av,chk10_5a_Av);
				setRadio(c10_5a_P,chk10_5a_P);
				setRadio(catss,chkCategoryss);
				setRadio(catfs,chkCategoryfs);
				setRadio(other,chkOthers);
				setRadio(partship,chkPartnership);
				setRadio(proship,chkProprietorship);
				setRadio(c10_6a_Ex,chk10_6a_Ex);
				setRadio(c10_6a_Vg,chk10_6a_Vg);
				setRadio(c10_6a_G,chk10_6a_G);
				setRadio(c10_6a_Av,chk10_6a_Av);
				setRadio(c10_6a_P,chk10_6a_P);
				setRadio(c14c1_C,chk14c1_C);
				setRadio(c14c1_S,chk14c1_S);
				setRadio(c14c1_E,chk14c1_E);
				setRadio(c14c2_C,chk14c2_C);
				setRadio(c14c2_S,chk14c2_S);
				setRadio(c14c2_E,chk14c2_E);
				setRadio(c14c3_C,chk14c3_C);
				setRadio(c14c3_S,chk14c3_S);
				setRadio(c14c3_E,chk14c3_E);
				setRadio(c14c4_C,chk14c4_C);
				setRadio(c14c4_S,chk14c4_S);
				setRadio(c14c4_E,chk14c4_E);
				setRadio(c14c5_C,chk14c5_C);
				setRadio(c14c5_S,chk14c5_S);
				setRadio(c14c5_E,chk14c5_E);
				setRadio(c14c6_C,chk14c6_C);
				setRadio(c14c6_S,chk14c6_S);
				setRadio(c14c6_E,chk14c6_E);

				//   1 for return Checkbox is checked ,0 for unchecked.

				setCheck(newro,chkNewRoTrAY);
				setCheck(c10_1A_Y,chk10_1A_Y);
				setCheck(c10_1C_y,chk10_1C_y);	
				setCheck(c10_1d_y,chk10_1d_y);	
				setCheck(c10_1e_y,chk10_1e_y);
				setCheck(c10_1f_y,chk10_1f_y);				
				setCheck(c10_1g_y,chk10_1g_y);
				setCheck(c10_2a_good,chk10_2a_good);
				setCheck(c10_2b_good,chk10_2b_good);
				setCheck(c10_2c_y,chk10_2c_y);
				setCheck(c10_3b_y,chk10_3b_y);
				setCheck(c10_3c_y,chk10_3c_y);
				setCheck(c10_5b_Y,chk10_5b_Y);
				setCheck(c10_5c_Y,chk10_5c_Y);
				setCheck(c10_5d_Y,chk10_5d_Y);
				setCheck(c10_6b_Y,chk10_6b_Y);
				setCheck(c10_6c_Y,chk10_6c_Y);
				setCheck(c10_7a_Y,chk10_7a_Y);
				setCheck(Pro18_3,chk18_3product_Y);					
				setCheck(Qty18_3,chk18_3quality_Y);					
				setCheck(Inv18_3,chk18_3invoice_Y);					
				setCheck(Amt18_3,chk18_3amount_Y);					
				setCheck(Pro18_4,chk18_4product_Y);					
				setCheck(Qty18_4,chk18_4quantity_Y);					
				setCheck(Inv18_4,chk18_4invoice_Y);					
				setCheck(Amt18_4,chk18_4amount_Y);	
				setCheck(c10_7b_Y,chk10_7b_Y);
				setCheck(c10_7c_Y,chk10_7c_Y);
				setCheck(c10_7d_Y,chk10_7d_Y);
				setCheck(c12a_Y,chk12a_Y);
				setCheck(c12b_Y,chk12b_Y);
				setCheck(c12c_Y,chk12c_Y);
				setCheck(c12d_Y,chk12d_Y);
				setCheck(c13a_Y,chk13a_Y);
				setCheck(c13b_Y,chk13b_Y);
				setCheck(c13c_Y,chk13c_Y);
				setCheck(c13d_Y,chk13d_Y);
				setCheck(c13e_Y,chk13e_Y);
				setCheck(c13f_Y,chk13f_Y);
				setCheck(c13g_Y,chk13g_Y);
				setCheck(c13h_Y,chk13h_Y);
				setCheck(c13i_Y,chk13i_Y);
				setCheck(c13j_Y,chk13j_Y);
				setCheck(c13k_Y,chk13k_Y);
				setCheck(c13l_Y,chk13l_Y);
				setCheck(c13m_Y,chk13m_Y);
				setCheck(c13n_Y,chk13n_Y);
				setCheck(c13o_Y,chk13o_Y);
				setCheck(c13p_Y,chk13p_Y);
				setCheck(c13q_Y,chk13q_Y);
				setCheck(c13r_Y,chk13r_Y);
				setCheck(c13t_Y,chk13t_Y);
				setCheck(c13u_Y,chk13u_Y);
				setCheck(c13v_Y,chk13v_Y);
				setCheck(c13w_Y,chk13w_Y);
				setCheck(c13x_Y,chk13x_Y);
				setCheck(c14a1_Y,chk14a1_Y);					
				setCheck(c14a2_Y,chk14a2_Y);
				setCheck(c14a3_Y,chk14a3_Y);
				setCheck(c14a4_Y,chk14a4_Y);
				setCheck(c14a5_Y,chk14a5_Y);
				setCheck(c14a6_Y,chk14a6_Y);
				setCheck(c14b1_Y,chk14b1_Y);					
				setCheck(c14b2_Y,chk14b2_Y);
				setCheck(c14b3_Y,chk14b3_Y);
				setCheck(c14b4_Y,chk14b4_Y);
				setCheck(c14b5_Y,chk14b5_Y);
				setCheck(c15aT2_Y,chk15aT2_Y);
				setCheck(c15aT3_Y,chk15aT3_Y);
				setCheck(c15aT4_Y,chk15aT4_Y);
				setCheck(c15dT1_Y,chk15dT1_Y);
				setCheck(c15dT2_Y,chk15dT2_Y);
				setCheck(c15dT3_Y,chk15dT3_Y);
				setCheck(c15dT4_Y,chk15dT4_Y);
				setCheck(c15eT1_Y,chk15eT1_Y);
				setCheck(c15eT2_Y,chk15eT2_Y);
				setCheck(c15eT3_Y,chk15eT3_Y);
				setCheck(c15eT4_Y,chk15eT4_Y);
				setCheck(c16a_Y,chk16a_Y);
				setCheck(c16bT1_Y,chk16bT1_Y);
				setCheck(c16bT2_Y,chk16bT2_Y);
				setCheck(c16bT3_Y,chk16bT3_Y);
				setCheck(c16bT4_Y,chk16bT4_Y);			
				setCheck(c16cT1_Y,chk16cT1_Y);
				setCheck(c16cT2_Y,chk16cT2_Y);
				setCheck(c16cT3_Y,chk16cT3_Y);
				setCheck(c16cT4_Y,chk16cT4_Y);			
				setCheck(c16dT1_Y,chk16dT1_Y);
				setCheck(c15aT1_Y,chk15aT1_Y);
				setCheck(c14b6_Y,chk14b6_Y);
				setCheck(c13s_Y,chk13s_Y);
				setCheck(c12e_Y,chk12e_Y);
				setCheck(c16dT2_Y,chk16dT2_Y);
				setCheck(c16dT3_Y,chk16dT3_Y);
				setCheck(c16dT4_Y,chk16dT4_Y);			
								
								
								
				// Return Date in DD/MM/YYYY for Display and Print Input is MM/DD/YYYY
			
				txtSalesPerformanceDate.Value=GenUtil.str2DDMMYYYY(txtSalesPerformanceDate.Value.ToString());
				txtDate.Text=GenUtil.str2DDMMYYYY(txtDate.Text.ToString());
				txtCummulativeuptoDate.Value=GenUtil.str2DDMMYYYY(txtCummulativeuptoDate.Value.ToString());
				txt3adatepk.Value=GenUtil.str2DDMMYYYY(txt3adatepk.Value.ToString());
				txt3bdatepk.Value=GenUtil.str2DDMMYYYY(txt3bdatepk.Value.ToString());
				txt3cdatepk.Value=GenUtil.str2DDMMYYYY(txt3cdatepk.Value.ToString());
				txt17a_Date.Value=GenUtil.str2DDMMYYYY(txt17a_Date.Value.ToString());
				txt17b_Date.Value=GenUtil.str2DDMMYYYY(txt17b_Date.Value.ToString());
				txt17c_Date.Value=GenUtil.str2DDMMYYYY(txt17c_Date.Value.ToString());
				txt10_3_aDate.Value=GenUtil.str2DDMMYYYY(txt10_3_aDate.Value.ToString());
				txt18_5dN1.Value=GenUtil.str2DDMMYYYY(txt18_5dN1.Value.ToString());
				txt18_5dN2.Value=GenUtil.str2DDMMYYYY(txt18_5dN2.Value.ToString());
				txt18_5dN3.Value=GenUtil.str2DDMMYYYY(txt18_5dN3.Value.ToString());
				txt18_5dN4.Value=GenUtil.str2DDMMYYYY(txt18_5dN4.Value.ToString());
				txt18_5dN5.Value=GenUtil.str2DDMMYYYY(txt18_5dN5.Value.ToString());
				txt18_5dN6.Value=GenUtil.str2DDMMYYYY(txt18_5dN6.Value.ToString());
				txt18_5eN1.Value=GenUtil.str2DDMMYYYY(txt18_5eN1.Value.ToString());
				txt18_5eN2.Value=GenUtil.str2DDMMYYYY(txt18_5eN2.Value.ToString());
				txt18_5eN3.Value=GenUtil.str2DDMMYYYY(txt18_5eN3.Value.ToString());
				txt18_5eN4.Value=GenUtil.str2DDMMYYYY(txt18_5eN4.Value.ToString());
				txt18_5eN5.Value=GenUtil.str2DDMMYYYY(txt18_5eN5.Value.ToString());
				txt18_5eN6.Value=GenUtil.str2DDMMYYYY(txt18_5eN6.Value.ToString());
				txt18_5fN1.Value=GenUtil.str2DDMMYYYY(txt18_5fN1.Value.ToString());
				txt18_5fN2.Value=GenUtil.str2DDMMYYYY(txt18_5fN2.Value.ToString());
				txt18_5fN3.Value=GenUtil.str2DDMMYYYY(txt18_5fN3.Value.ToString());
				txt18_5fN4.Value=GenUtil.str2DDMMYYYY(txt18_5fN4.Value.ToString());
				txt18_5fN5.Value=GenUtil.str2DDMMYYYY(txt18_5fN5.Value.ToString());
				txt18_5fN6.Value=GenUtil.str2DDMMYYYY(txt18_5fN6.Value.ToString());
				txt19_0Date1.Value=GenUtil.str2DDMMYYYY(txt19_0Date1.Value.ToString());
				txt19_0Date2.Value=GenUtil.str2DDMMYYYY(txt19_0Date2.Value.ToString());
				txt19_0Date3.Value=GenUtil.str2DDMMYYYY(txt19_0Date3.Value.ToString());
				txt19_0Date4.Value=GenUtil.str2DDMMYYYY(txt19_0Date4.Value.ToString());
				txt19_0Date5.Value=GenUtil.str2DDMMYYYY(txt19_0Date5.Value.ToString());	
				txt20_0Date1.Value=GenUtil.str2DDMMYYYY(txt20_0Date1.Value.ToString());	
				txt20_0Date2.Value=GenUtil.str2DDMMYYYY(txt20_0Date2.Value.ToString());	
				txt20_0Date3.Value=GenUtil.str2DDMMYYYY(txt20_0Date3.Value.ToString());	
				txt20_0Date4.Value=GenUtil.str2DDMMYYYY(txt20_0Date4.Value.ToString());	
				txt20_0Date5.Value=GenUtil.str2DDMMYYYY(txt20_0Date5.Value.ToString());	
				txtIOCDate.Value=GenUtil.str2DDMMYYYY(txtIOCDate.Value.ToString());	
				txt5bstdate.Value=GenUtil.str2DDMMYYYY(txt5bstdate.Value.ToString());	

				//Return Date in DD/MM/YYYY for Display Without time

				txtSalesPerformanceDate.Value=GenUtil.trimDate(txtSalesPerformanceDate.Value.ToString());
				txtDate.Text=GenUtil.trimDate(txtDate.Text.ToString());
				txtCummulativeuptoDate.Value=GenUtil.trimDate(txtCummulativeuptoDate.Value.ToString());
				txt3adatepk.Value=GenUtil.trimDate(txt3adatepk.Value.ToString());
				txt3bdatepk.Value=GenUtil.trimDate(txt3bdatepk.Value.ToString());
				txt3cdatepk.Value=GenUtil.trimDate(txt3cdatepk.Value.ToString());
				txt17a_Date.Value=GenUtil.trimDate(txt17a_Date.Value.ToString());
				txt17b_Date.Value=GenUtil.trimDate(txt17b_Date.Value.ToString());
				txt17c_Date.Value=GenUtil.trimDate(txt17c_Date.Value.ToString());
				txt10_3_aDate.Value=GenUtil.trimDate(txt10_3_aDate.Value.ToString());
				txt18_5dN1.Value=GenUtil.trimDate(txt18_5dN1.Value.ToString());
				txt18_5dN2.Value=GenUtil.trimDate(txt18_5dN2.Value.ToString());
				txt18_5dN3.Value=GenUtil.trimDate(txt18_5dN3.Value.ToString());
				txt18_5dN4.Value=GenUtil.trimDate(txt18_5dN4.Value.ToString());
				txt18_5dN5.Value=GenUtil.trimDate(txt18_5dN5.Value.ToString());
				txt18_5dN6.Value=GenUtil.trimDate(txt18_5dN6.Value.ToString());
				txt18_5eN1.Value=GenUtil.trimDate(txt18_5eN1.Value.ToString());
				txt18_5eN2.Value=GenUtil.trimDate(txt18_5eN2.Value.ToString());
				txt18_5eN3.Value=GenUtil.trimDate(txt18_5eN3.Value.ToString());
				txt18_5eN4.Value=GenUtil.trimDate(txt18_5eN4.Value.ToString());
				txt18_5eN5.Value=GenUtil.trimDate(txt18_5eN5.Value.ToString());
				txt18_5eN6.Value=GenUtil.trimDate(txt18_5eN6.Value.ToString());
				txt18_5fN1.Value=GenUtil.trimDate(txt18_5fN1.Value.ToString());
				txt18_5fN2.Value=GenUtil.trimDate(txt18_5fN2.Value.ToString());
				txt18_5fN3.Value=GenUtil.trimDate(txt18_5fN3.Value.ToString());
				txt18_5fN4.Value=GenUtil.trimDate(txt18_5fN4.Value.ToString());
				txt18_5fN5.Value=GenUtil.trimDate(txt18_5fN5.Value.ToString());
				txt18_5fN6.Value=GenUtil.trimDate(txt18_5fN6.Value.ToString());
				txt19_0Date1.Value=GenUtil.trimDate(txt19_0Date1.Value.ToString());
				txt19_0Date2.Value=GenUtil.trimDate(txt19_0Date2.Value.ToString());
				txt19_0Date3.Value=GenUtil.trimDate(txt19_0Date3.Value.ToString());
				txt19_0Date4.Value=GenUtil.trimDate(txt19_0Date4.Value.ToString());
				txt19_0Date5.Value=GenUtil.trimDate(txt19_0Date5.Value.ToString());	
				txt20_0Date1.Value=GenUtil.trimDate(txt20_0Date1.Value.ToString());	
				txt20_0Date2.Value=GenUtil.trimDate(txt20_0Date2.Value.ToString());	
				txt20_0Date3.Value=GenUtil.trimDate(txt20_0Date3.Value.ToString());	
				txt20_0Date4.Value=GenUtil.trimDate(txt20_0Date4.Value.ToString());	
				txt20_0Date5.Value=GenUtil.trimDate(txt20_0Date5.Value.ToString());	
				txtIOCDate.Value=GenUtil.trimDate(txtIOCDate.Value.ToString());	
				txt5bstdate.Value=GenUtil.trimDate(txt5bstdate.Value.ToString());	
			
				//Check Date equalto 1/1/1900 then return & diplay blank string on form

				txtDate.Text=GenUtil.checkDate(txtDate.Text.ToString());
				txtSalesPerformanceDate.Value=GenUtil.checkDate(txtSalesPerformanceDate.Value.ToString());
				txtDate.Text=GenUtil.checkDate(txtDate.Text.ToString());
				txtCummulativeuptoDate.Value=GenUtil.checkDate(txtCummulativeuptoDate.Value.ToString());
				txt3adatepk.Value=GenUtil.checkDate(txt3adatepk.Value.ToString());
				txt3bdatepk.Value=GenUtil.checkDate(txt3bdatepk.Value.ToString());
				txt3cdatepk.Value=GenUtil.checkDate(txt3cdatepk.Value.ToString());
				txt17a_Date.Value=GenUtil.checkDate(txt17a_Date.Value.ToString());
				txt17b_Date.Value=GenUtil.checkDate(txt17b_Date.Value.ToString());
				txt17c_Date.Value=GenUtil.checkDate(txt17c_Date.Value.ToString());
				txt10_3_aDate.Value=GenUtil.checkDate(txt10_3_aDate.Value.ToString());
				txt18_5dN1.Value=GenUtil.checkDate(txt18_5dN1.Value.ToString());
				txt18_5dN2.Value=GenUtil.checkDate(txt18_5dN2.Value.ToString());
				txt18_5dN3.Value=GenUtil.checkDate(txt18_5dN3.Value.ToString());
				txt18_5dN4.Value=GenUtil.checkDate(txt18_5dN4.Value.ToString());
				txt18_5dN5.Value=GenUtil.checkDate(txt18_5dN5.Value.ToString());
				txt18_5dN6.Value=GenUtil.checkDate(txt18_5dN6.Value.ToString());
				txt18_5eN1.Value=GenUtil.checkDate(txt18_5eN1.Value.ToString());
				txt18_5eN2.Value=GenUtil.checkDate(txt18_5eN2.Value.ToString());
				txt18_5eN3.Value=GenUtil.checkDate(txt18_5eN3.Value.ToString());
				txt18_5eN4.Value=GenUtil.checkDate(txt18_5eN4.Value.ToString());
				txt18_5eN5.Value=GenUtil.checkDate(txt18_5eN5.Value.ToString());
				txt18_5eN6.Value=GenUtil.checkDate(txt18_5eN6.Value.ToString());
				txt18_5fN1.Value=GenUtil.checkDate(txt18_5fN1.Value.ToString());
				txt18_5fN2.Value=GenUtil.checkDate(txt18_5fN2.Value.ToString());
				txt18_5fN3.Value=GenUtil.checkDate(txt18_5fN3.Value.ToString());
				txt18_5fN4.Value=GenUtil.checkDate(txt18_5fN4.Value.ToString());
				txt18_5fN5.Value=GenUtil.checkDate(txt18_5fN5.Value.ToString());
				txt18_5fN6.Value=GenUtil.checkDate(txt18_5fN6.Value.ToString());
				txt19_0Date1.Value=GenUtil.checkDate(txt19_0Date1.Value.ToString());
				txt19_0Date2.Value=GenUtil.checkDate(txt19_0Date2.Value.ToString());
				txt19_0Date3.Value=GenUtil.checkDate(txt19_0Date3.Value.ToString());
				txt19_0Date4.Value=GenUtil.checkDate(txt19_0Date4.Value.ToString());
				txt19_0Date5.Value=GenUtil.checkDate(txt19_0Date5.Value.ToString());	
				txt20_0Date1.Value=GenUtil.checkDate(txt20_0Date1.Value.ToString());	
				txt20_0Date2.Value=GenUtil.checkDate(txt20_0Date2.Value.ToString());	
				txt20_0Date3.Value=GenUtil.checkDate(txt20_0Date3.Value.ToString());	
				txt20_0Date4.Value=GenUtil.checkDate(txt20_0Date4.Value.ToString());	
				txt20_0Date5.Value=GenUtil.checkDate(txt20_0Date5.Value.ToString());	
				txtIOCDate.Value=GenUtil.checkDate(txtIOCDate.Value.ToString());	
				txt5bstdate.Value=GenUtil.checkDate(txt5bstdate.Value.ToString());	

				scom7.Dispose();
				con.Close();
				btnSave.Disabled=true;
				btnEdit.Disabled=false;
				btndelete.Disabled=false;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:DropDownList1_SelectedIndexChanged()  EXCEPTION "+ ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used If the value store 1 in the data base then this function will return 
		/// checkbox is checked otherwise 0 for making unchecked the checkbox.
		/// </summary>
		public void setCheck(string str, HtmlInputCheckBox  c)
		{
			if(str.Equals("1"))
			{
				c.Checked = true;
			}
			else
			{
				c.Checked = false;
			}
		}

		/// <summary>
		/// This method is used to return 1 If checkbox is checked otherwise 0 For unchecked the checkbox.
		/// </summary>
		public string setCheck1(string str, HtmlInputCheckBox  c)
		{
			if(c.Checked == true)
			{
				str= "1";
			}
			else
			{
				str= "0";
			}
			return str;
		}

		/// <summary>
		/// This method is used to If the value store 1 in the data base then this function will return 
		/// Radiobutton is checked otherwise 0 for making unchecked the Radiobutton.
		/// </summary>
		public void setRadio(string str, HtmlInputRadioButton c)
		{
			if(str.Equals("1"))
			{
				c.Checked = true;
			}
			else
			{
				c.Checked = false;
			}
		}

		/// <summary>
		/// This function will return 1 If Radiobutton is checked otherwise 0 For unchecked the checkbox.
		/// </summary>
		public string setRadio1(string str, HtmlInputRadioButton c)
		{
			if(c.Checked == true)
			{
				str= "1";
			}
			else
			{
				str= "0";
			}
			return str;
		}
      
//		public string setCheck2(string str, HtmlInputCheckBox  c)
//		{
//			if(c.Checked == true)
//			{
//				str= "v";
//			}
//			else
//			{
//				str= "x";
//			}
//			return str;
//			
//		}


		/// <summary>
		/// This method is used to clear the web form(ROI_ANALYSIS).
		/// </summary>
		public void clear()
		{
			txtareaDLnameaddr.Value="";
			chkasite.Checked=false;
			chkbsite.Checked=false;
			chkcoco.Checked=false;
			chkCategoryss.Checked=false;
			chkCategoryfs.Checked=false;
			chkPartnership.Checked=false;
			chkProprietorship.Checked=false;
			chkOthers.Checked=false;
			txtDivisionOff.Text="";
			txtDistrict.Value="";
			//txtDate.Text="";
			//txtSalesPerformanceDate.Value="";
			//txtCummulativeuptoDate.Value="";
			txtMSTarget1.Value="";
			txtMScyear1.Value="";
			txtMSLyear1.Value="";
			txtMSTarget2.Value="";
			txtMSCyear2.Value="";
			txtMSLyear2.Value="";
			txtHSDTarget1.Value="";
			txtHSDCYear1.Value="";
			txt4tba.Value="";
			txtpro15t1.Value="";
			txtpro15t2.Value="";
			txtpro15t3.Value="";
			txtpro15t4.Value="";
			txtHSDLYear1.Value="";
			txtHSDTarget2.Value="";
			txtHSDCYear2.Value="";
			txtHSDLYear2.Value="";
			txtLubesTarget1.Value="";
			txtLubesCYear1.Value="";
			txtLubesLYear1.Value="";
			txtLubesTarget2.Value="";
			txtLubesCYear2.Value="";
			txtLubesLYear2.Value="";
			txtGreaseTarget1.Value="";
			txtGreaseCYear1.Value="";
			txtGreaseLYear1.Value="";
			txtGreaseTarget2.Value="";
			txtGreaseCYear2.Value="";
			txtGreaseLYear2.Value="";
			txtLFratioTarget1.Value="";
			txtLFratioCYear1.Value="";
			txtLFratioLYear1.Value="";
			txtLFratioTarget2.Value="";
			txtLFratioCYear2.Value="";
			txtLFratioLyear2.Value="";
			txtIOCMS1.Value="";
			txtIOCHSD1.Value="";
			txtIOCMS2.Value="";
			txtIOCHSD2.Value="";
			txtIOCMS3.Value="";
			txtIOCHSD3.Value="";
			txtOMCMS1.Value="";
			txtOMCHSD1.Value="";
			txtOMCMS2.Value="";
			txtOMCHSD2.Value="";
			txtOMCMS3.Value="";
			txtOMCHSD3.Value="";
			txtTOTALMS1.Value="";
			txtTOTALHSD1.Value="";
			txtTOTALMS2.Value="";
			txtTOTALHSD2.Value="";
			txtTOTALMS3.Value="";
			txtTOTALHSD3.Value="";				
			txtReasonLH_taAvgMS.Value="";
			txtReasonLH_taAvgHSD.Value="";
			txt3a.Value="";
			chkNewRoTrAY.Checked=false;
			//txt3adatepk.Value="";
			//txt3bdatepk.Value="";
			//txt3cdatepk.Value="";
			txt3b.Value="";
			txt3c.Value="";
			txt4avgsaleMS.Value="";
			txt4avgsaleHSD.Value="";
			txt4avgsaleLUBES.Value="";
			txt4NilSaleaMS.Value="";
			txt4NilSaleaHSD.Value="";
			txt4NilSaleaLUBES.Value="";
			txt4DryOutMS.Value="";
			txt4DryOutHSD.Value="";
			txt4DryOutLUBES.Value="";
			txtarea4NilSalesDryout.Value="";
			txt5AProNo1.Value="";
			txt5AProNo2.Value="";
			txt5AProNo3.Value="";
			txt5AProNo4.Value="";
			txt5AProNo5.Value="";
			txt5AProNo6.Value="";
			txt5AMakeNo1.Value="";
			txt5AMakeNo2.Value="";
			txt5AMakeNo3.Value="";
			txt5AMakeNo4.Value="";
			txt5AMakeNo5.Value="";
			txt5AMakeNo6.Value="";
			txt5ACuuReadNo1.Value="";
			txt5ACuuReadNo2.Value="";
			txt5ACuuReadNo3.Value="";
			txt5ACuuReadNo4.Value="";
			txt5ACuuReadNo5.Value="";
			txt5ACuuReadNo6.Value="";
			txt5APrevReadNo1.Value="";
			txt5APrevReadNo2.Value="";
			txt5APrevReadNo3.Value="";
			txt5APrevReadNo4.Value="";
			txt5APrevReadNo5.Value="";
			txt5APrevReadNo6.Value="";
			txt5APerMETReadNo1.Value="";
			txt5APerMETReadNo2.Value="";
			txt5APerMETReadNo3.Value="";
			txt5APerMETReadNo4.Value="";
			txt5APerMETReadNo5.Value="";
			txt5APerMETReadNo6.Value="";
			txt5BStockonlastDtMS93.Value="";
			txt5BStockonlastDtMS87.Value="";
			txt5BStockonlastDtMSulp.Value="";
			txt5BStockonlastDtHSD.Value="";
			txt5BReceiptKL_MS93.Value="";
			txt5BReceiptKL_MS87.Value="";
			txt5BReceiptKL_MSULP.Value="";
			txt5BReceiptKL_HSD.Value="";
			txt5BTotalstkMS93.Value="";
			txt5BTotalstkMS87.Value="";
			txt5BTotalstkMSULP.Value="";
			txt5BTotalstkHSD.Value="";
			txt5BTLessstkMS93.Value="";
			txt5BTLessstkMS87.Value="";
			txt5BTLessstkMSULP.Value="";
			txt5BTLessstkHSD.Value="";
			txt5BTotSalesMS93.Value="";
			txt5BTotSalesMS87.Value="";
			txt5BTotSalesMSULP.Value="";
			txt5BTotSalesHSD.Value="";
			txt5BVariationMS93.Value="";
			txt5BVariationMS87.Value="";
			txt5BVariationMSULP.Value="";
			txt5BVariationHSD.Value="";
			txtarea5BReasonVar.Value="";
			txt6adqbarrel1_0.Value="";
			txt6adqbarrel2_0.Value="";
			txt6adqbarrel3_0.Value="";
			txt6Smallpck1_0.Value="";
			txt6Smallpck2_0.Value="";
			txt6Smallpck3_0.Value="";
			txt6adqbarrel1_1.Value="";
			txt6adqbarrel2_1.Value="";
			txt6adqbarrel3_1.Value="";
			txt6adSmallpck1_1.Value="";
			txt6adSmallpck2_1.Value="";
			txt6adSmallpck3_1.Value="";
			txt6Inadqbarrel1_0.Value="";
			txt6Inadqbarrel2_0.Value="";
			txt6Inadqbarrel3_0.Value="";
			txt6InSmallpck1_0.Value="";
			txt6InSmallpck2_0.Value="";
			txt6InSmallpck3_0.Value="";
			txt6Inadqbarrel1_1.Value="";
			txt6Inadqbarrel2_1.Value="";
			txt6Inadqbarrel3_1.Value="";
			txt6InSmallpck1_1.Value="";
			txt6InSmallpck2_1.Value="";
			txt6InSmallpck3_1.Value="";
			txt7DetailSub1.Value="";
			txt7DetailSub1_yr.Value="";
			txt7DetailSub1_amt.Value="";
			txt7DetailSub2.Value="";
			txt7DetailSub2_yr.Value="";
			txt7DetailSub2_amt.Value="";
			txt7DetailSub3.Value="";
			txt7DetailSub3_yr.Value="";
			txt7DetailSub3_amt.Value="";
			txt7DetailSub4.Value="";
			txt7DetailSub4_yr.Value="";
			txt7DetailSub4_amt.Value="";
			txt7DetailSub5.Value="";
			txt7DetailSub5_yr.Value="";
			txt7DetailSub5_amt.Value="";
			txt8Dealersugggestion.Value="";
			txt9MarInfo.Value="";
			txt10_1B.Value="";
			txt10_1f.Value="";
			txt10_1g.Value="";
			//txt10_3_aDate.Value="";
			chk10_1A_Y.Checked=false;
			chk10_1C_y.Checked=false;
			chk10_1d_y.Checked=false;
			chk10_1e_y.Checked=false;
			chk10_1f_y.Checked=false;
			chk10_1g_y.Checked=false;
			chk10_2a_good.Checked=false;
			chk10_2b_good.Checked=false;
			chk10_2c_y.Checked=false;
			chk10_3b_y.Checked=false;
			chk10_3c_y.Checked=false;
			chk10_3d_Ex.Checked=false;
			chk10_3d_Vg.Checked=false;
			chk10_3d_G.Checked=false;
			chk10_3d_Av.Checked=false;
			chk10_3d_P.Checked=false;
			chk10_3e_Ex.Checked=false;
			chk10_3e_Vg.Checked=false;
			chk10_3e_G.Checked=false;
			chk10_3e_Av.Checked=false;
			chk10_3e_P.Checked=false;
			chk10_4a_Ex.Checked=false;
			chk10_4a_Vg.Checked=false;
			chk10_4a_G.Checked=false;
			chk10_4a_Av.Checked=false;
			chk10_4a_P.Checked=false;
			chk10_4b_Ex.Checked=false;
			chk10_4b_Vg.Checked=false;
			chk10_4b_G.Checked=false;
			chk10_4b_Av.Checked=false;
			chk10_4b_P.Checked=false;
			chk10_4c_Ex.Checked=false;
			chk10_4c_Vg.Checked=false;
			chk10_4c_G.Checked=false;
			chk10_4c_Av.Checked=false;
			chk10_4c_P.Checked=false;
			chk10_4d_Ex.Checked=false;
			chk10_4d_Vg.Checked=false;
			chk10_4d_G.Checked=false;
			chk10_4d_Av.Checked=false;
			chk10_4d_P.Checked=false;
			chk10_5a_Ex.Checked=false;
			chk10_5a_Vg.Checked=false;
			chk10_5a_G.Checked=false;
			chk10_5a_Av.Checked=false;
			chk10_5a_P.Checked=false;
			chk10_5b_Y.Checked=false;
			chk10_5c_Y.Checked=false;
			chk10_5d_Y.Checked=false;
			chk10_6a_Ex.Checked=false;
			chk10_6a_Vg.Checked=false;
			chk10_6a_G.Checked=false;
			chk10_6a_Av.Checked=false;
			chk10_6a_P.Checked=false;
			chk10_6b_Y.Checked=false;
			chk10_6c_Y.Checked=false;
			txt10_6c.Value="";
			txt13g.Value="";
			txt13_nature.Value="";
			chk10_7a_Y.Checked=false;
			chk10_7b_Y.Checked=false;
			chk10_7c_Y.Checked=false;
			chk10_7d_Y.Checked=false;
			//txt5bstdate.Value="";
			chk12a_Y.Checked=false;
			chk12b_Y.Checked=false;
			chk12c_Y.Checked=false;
			chk12d_Y.Checked=false;
			chk12e_Y.Checked=false;
			chk13a_Y.Checked=false;
			chk13b_Y.Checked=false;
			chk13c_Y.Checked=false;
			chk13d_Y.Checked=false;
			chk13e_Y.Checked=false;
			chk13f_Y.Checked=false;
			chk13g_Y.Checked=false;
			chk13h_Y.Checked=false;
			chk13i_Y.Checked=false;
			chk13j_Y.Checked=false;
			chk13k_Y.Checked=false;
			chk13l_Y.Checked=false;
			chk13m_Y.Checked=false;
			chk13n_Y.Checked=false;
			chk13o_Y.Checked=false;
			chk13p_Y.Checked=false;
			chk13q_Y.Checked=false;
			chk13r_Y.Checked=false;
			chk13s_Y.Checked=false;
			chk13t_Y.Checked=false;
			chk13u_Y.Checked=false;
			chk13v_Y.Checked=false;
			chk13w_Y.Checked=false;
			chk13x_Y.Checked=false;
			chk14a1_Y.Checked=false;
			chk14a2_Y.Checked=false;
			chk14a3_Y.Checked=false;
			chk14a4_Y.Checked=false;
			chk14a5_Y.Checked=false;
			chk14a6_Y.Checked=false;
			chk14b1_Y.Checked=false;
			chk14b2_Y.Checked=false;
			chk14b3_Y.Checked=false;
			chk14b4_Y.Checked=false;
			chk14b5_Y.Checked=false;
			chk14b6_Y.Checked=false;
			chk14c1_C.Checked=false;
			chk14c1_S.Checked=false;
			chk14c1_E.Checked=false;
			chk14c2_C.Checked=false;
			chk14c2_S.Checked=false;
			chk14c2_E.Checked=false;
			chk14c3_C.Checked=false;
			chk14c3_S.Checked=false;
			chk14c3_E.Checked=false;
			chk14c4_C.Checked=false;
			chk14c4_S.Checked=false;
			chk14c4_E.Checked=false;
			chk14c5_C.Checked=false;
			chk14c5_S.Checked=false;
			chk14c5_E.Checked=false;
			chk14c6_C.Checked=false;
			chk14c6_S.Checked=false;
			chk14c6_E.Checked=false;
			chk15aT1_Y.Checked=false;
			chk15aT2_Y.Checked=false;
			chk15aT3_Y.Checked=false;
			chk15aT4_Y.Checked=false;
			txt15bT1.Value="";
			txt15bT2.Value="";
			txt15bT3.Value="";
			txt15bT4.Value="";
			txt15cT1.Value="";
			txt15cT2.Value="";
			txt15cT3.Value="";
			txt15cT4.Value="";
			chk15dT1_Y.Checked=false;
			chk15dT2_Y.Checked=false;
			chk15dT3_Y.Checked=false;
			chk15dT4_Y.Checked=false;
			chk15eT1_Y.Checked=false;
			chk15eT2_Y.Checked=false;
			chk15eT3_Y.Checked=false;
			chk15eT4_Y.Checked=false;
			txt15f.Value="";
			chk16a_Y.Checked=false;
			chk16bT1_Y.Checked=false;
			chk16bT2_Y.Checked=false;
			chk16bT3_Y.Checked=false;
			chk16bT4_Y.Checked=false;
			chk16cT1_Y.Checked=false;
			chk16cT2_Y.Checked=false;
			chk16cT3_Y.Checked=false;
			chk16cT4_Y.Checked=false;
			chk16dT1_Y.Checked=false;
			chk16dT2_Y.Checked=false;
			chk16dT3_Y.Checked=false;
			chk16dT4_Y.Checked=false;
			txt16_Detail.Value="";
			//txt17a_Date.Value="";
			txt17a_Result.Value="";
			//txt17b_Date.Value="";
			txt17b_Result.Value="";
			//txt17c_Date.Value="";
			txt17c_Result.Value="";
			txt17MS.Value="";
			txt17HSD.Value="";
			txt18_1_Comm.Value="";
			txt18_2_Transport.Value="";
			txt18_2_Pending.Value="";
			txt18_2_Action.Value="";
			txt18_3_product.Value="";
			chk18_3product_Y.Checked=false;
			txt18_3_quality.Value="";
			chk18_3quality_Y.Checked=false;
			txt18_3_Invoice.Value="";
			chk18_3invoice_Y.Checked=false;
			txt18_3_amount.Value="";
			chk18_3amount_Y.Checked=false;
			txt18_4_product.Value="";
			chk18_4product_Y.Checked=false;
			txt18_4_quantity.Value="";
			chk18_4quantity_Y.Checked=false;
			txt18_4_Invoice.Value="";
			chk18_4invoice_Y.Checked=false;
			txt18_4_amount.Value="";
			chk18_4amount_Y.Checked=false;
			txt18_4_action.Value="";
			txt18_5a.Value="";
			txt18_5bN1.Value="";
			txt18_5bN2.Value="";
			txt18_5bN3.Value="";
			txt18_5bN4.Value="";
			txt18_5bN5.Value="";
			txt18_5bN6.Value="";
			txt18_5cN1.Value="";
			txt18_5cN2.Value="";
			txt18_5cN3.Value="";
			txt18_5cN4.Value="";
			txt18_5cN5.Value="";
			txt18_5cN6.Value="";
			txt18_5dN1.Value="";
			txt18_5dN2.Value="";
			txt18_5dN3.Value="";
			txt18_5dN4.Value="";
			txt18_5dN5.Value="";
			txt18_5dN6.Value="";
			//txt18_5eN1.Value="";
			//txt18_5eN2.Value="";
			//txt18_5eN3.Value="";
			//txt18_5eN4.Value="";
			//txt18_5eN5.Value="";
			//txt18_5eN6.Value="";
			//txt18_5fN1.Value="";
			//txt18_5fN2.Value="";
			//txt18_5fN3.Value="";
			//txt18_5fN4.Value="";
			//txt18_5fN5.Value="";
			//txt18_5fN6.Value="";
			txt18_5_reasons.Value="";
			txt18_6aAvg.Value="";
			txt18_6bNumber.Value="";
			txt18_6cActionplan.Value="";
			txt19_0srno1.Value="";
			//txt19_0Date1.Value="";
			txt19_0Action1.Value="";
			txt19_0Detail1.Value="";
			txt19_0srno2.Value="";
			//txt19_0Date2.Value="";
			txt19_0Action2.Value="";
			txt19_0Detail2.Value="";
			txt19_0srno3.Value="";
			//txt19_0Date3.Value="";
			txt19_0Action3.Value="";
			txt19_0Detail3.Value="";
			txt19_0srno4.Value="";
			//txt19_0Date4.Value="";
			txt19_0Action4.Value="";
			txt19_0Detail4.Value="";
			txt19_0srno5.Value="";
			//txt19_0Date5.Value="";
			txt19_0Action5.Value="";
			txt19_0Detail5.Value="";
			txt20_0srno1.Value="";
			//txt20_0Date1.Value="";
			txt20_0Action1.Value="";
			txt20_0Detail1.Value="";
			txt20_0srno2.Value="";
			//txt20_0Date2.Value="";
			txt20_0Action2.Value="";
			txt20_0Detail2.Value="";
			txt20_0srno3.Value="";
			//txt20_0Date3.Value="";
			txt20_0Action3.Value="";
			txt20_0Detail3.Value="";
			txt20_0srno4.Value="";
			//txt20_0Date4.Value="";
			txt20_0Action4.Value="";
			txt20_0Detail4.Value="";
			txt20_0srno5.Value="";
			txt20_0Action5.Value="";
			txt20_0Detail5.Value="";
			txtSOD.Value="";
			txtSignIOC.Value="";
			txtIOCName.Value="";
			txtIOCdesign.Value="";
			//txtIOCDate.Value="";
			//txt20_0Date5.Value="";
		}

		/// <summary>
		/// This method is used to click this button We print webform with save & updation of the record.
		/// </summary>
		private void btnPrint_ServerClick(object sender, System.EventArgs e)
		{
			
			if (DropDownList1.Enabled)
			{
					Edit();
					Session["RoiId"]=DropDownList1.SelectedItem.Text;
					//MessageBox.Show("Successfully Updated & Goto Print");
				
			}
			else
			{   
					Save();
					Session["RoiId"]=txtroiid.Text ;
					//MessageBox.Show("Successfully Saved & Goto Print");
			}
			DropDownList1.Enabled =true;
			Response.Redirect("ROIPrint.aspx");
		}



		/// <summary>
		/// This method is used to Delete the particular record select from the database.
		/// </summary>
		private void btndelete_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection	con  = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Epetro"]);
				con.Open();	
				string strdel="delete ROI_ANALYSIS where ROIID='"+DropDownList1.SelectedItem.Text+"'";
				SqlCommand	comdel  = new SqlCommand( strdel ,con  );
				comdel.ExecuteNonQuery();
				MessageBox.Show("Record  Deleted.");
				comdel.Dispose();
				con.Close();
				clear();
				getNextID();
				DropDownList1.SelectedIndex = 0;
				DropDownList1.Enabled = false; 
				btnSave.Disabled=false;
				btnEdit.Disabled=true;
				btndelete.Disabled = true; 
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:btndelete_ServerClick()  The ROI Report No. "+ DropDownList1.SelectedItem.Text +" Deleted. userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ROI_ANALYSIS.aspx,Method:btndelete_ServerClick()  EXCEPTION "+ ex.Message+"  userid  "+uid);
			}
		}
	}
}
