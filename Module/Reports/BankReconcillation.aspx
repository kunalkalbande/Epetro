<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<%@ Import namespace="RMG" %>
<%@ Import namespace="System.Data.SqlClient" %>
<%@ Import namespace="EPetro.Sysitem.Classes" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Page language="c#" Codebehind="BankReconcillation.aspx.cs" AutoEventWireup="false" Inherits="EPetro.Module.Reports.BankReconcillation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
  <script language="javascript">
function Check(t,temp)
{
	var index=t.selectedIndex;
	var tempvalue=t.options[index].text;
	temp.value=tempvalue;
	
}
function Check1(t,temp)
{
	var index=t.selectedIndex;
	temp.value=index;
	
}
function EnaDes(t,Day,Mon,Year)
{
	if(t.checked)
	{
		Day.disabled=false;
		Mon.disabled=false;
		Year.disabled=false;
	}
	else
	{
		Day.disabled=true;
		Mon.disabled=true;
		Year.disabled=true;
	}
}
/*
function SetCheck()
{
	var i= "hello";
	alert(i);
}*/
  </script>
		<title>ePetro: BankReconcillation</title> 
		
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../Sysitem/Styles.css" type=text/css rel=stylesheet >
  </HEAD>
<body MS_POSITIONING="GridLayout" onload="SetCheck()">
<form id=Form1 method=post runat="server"><uc1:header id=Header1 runat="server"></uc1:header>
<table height=288 width=778 align=center>
  <tr>
    <TH align=center height=20><font color=#006400>Bank Reconcillation</FONT> 
      <hr>
    </TH></TR>
  <tr height=10>
    <td align=center>Select Bank Name&nbsp;<asp:comparevalidator id="Comparevalidator1" runat="server" ValueToCompare="Select" Operator="NotEqual" ErrorMessage="Please Select Bank Name" ControlToValidate="DropBank"><font color="red">*</font></asp:comparevalidator>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID=DropBank Runat=server><asp:ListItem Value="Select">Select</asp:ListItem></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
<asp:button id="btnShow" runat="server" CausesValidation=True ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen" Width="80" Text="View" OnClick="btnShow_Click"></asp:button>&nbsp;&nbsp;
<asp:button id=btnView runat="server" CausesValidation=True ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen" Width="80" Text="Reconciled" OnClick="Recon"></asp:button>&nbsp;&nbsp;
<asp:button id=btnPrint runat="server" CausesValidation=True ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen" Width="70" Text="Print"></asp:button>&nbsp;&nbsp;
<asp:button id=btnExcel runat="server" CausesValidation=True ForeColor="White" BorderColor="DarkSeaGreen" BackColor="ForestGreen" Width="70" Text="Excel"></asp:button></TD></TR>
  <tr>
    <td align=center>
    <%
    if(DropBank.SelectedIndex!=0)
    {
		InventoryClass obj = new InventoryClass();
		SqlDataReader rdr;
		//string str="(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where (alt.particulars like 'payment%' or alt.particulars like 'receipt%') and alt.ledger_id=lm.ledger_id and alt.particulars not in(select vouchartype from reconcillation) and (lm.sub_grp_id='117' or lm.sub_grp_id='126' or lm.sub_grp_id='127'))union(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where alt.particulars like 'contra%' and Credit_amount>0 and alt.ledger_id=lm.ledger_id and alt.particulars not in(select vouchartype from reconcillation) and (lm.sub_grp_id='117' or lm.sub_grp_id='126' or lm.sub_grp_id='127'))";
		string str="(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where lm.Ledger_Name='"+DropBank.SelectedItem.Text+"' and (alt.particulars like 'payment%' or alt.particulars like 'receipt%') and alt.ledger_id=lm.ledger_id and alt.particulars not in(select vouchartype from reconcillation))union(select lm.Ledger_Name Cust_Name,alt.Particulars Type,alt.Debit_Amount Debit,alt.Credit_Amount Credit,alt.Entry_Date Entry from accountsledgertable alt,ledger_master lm where lm.Ledger_Name='"+DropBank.SelectedItem.Text+"' and alt.particulars like 'contra%' and Credit_amount>0 and alt.ledger_id=lm.ledger_id and alt.particulars not in(select vouchartype from reconcillation))";
		rdr = obj.GetRecordSet(str);
		int i=0;
		double Dr=0,Cr=0;
		if(rdr.HasRows)
		{
    %>
      <table border=1 cellspacing=0 bordercolor=darkseagreen id=Table1>
        <tr bgcolor=forestgreen height=22>
          <td align=center><font color=white><b>Bank Name</b></font></Td>
          <td align=center><font color=white><b>Vouchar Type</b></font></Td>
          <td align=center><font color=white><b>Debit Amount</b></font></Td>
          <td align=center><font color=white><b>Credit Amount</b></font></td>
          <td align=center><font color=white><b>Posted On</b></font></td>
          <td align=center><font color=white><b>Reconciled On</b></font></td>
          <td align=center><font color=white><b>Select</b></font></td>
        </TR>
      <%while(rdr.Read())
      {%>
		<tr>
		<td><%=rdr.GetValue(0).ToString()%><input type=hidden name=tempBankName<%=i%> value="<%=rdr.GetValue(0).ToString()%>"></td>
		<td><%=rdr.GetValue(1).ToString()%><input type=hidden name=tempVoucharType<%=i%> value="<%=rdr.GetValue(1).ToString()%>"></td>
		<td align=right><%=GenUtil.strNumericFormat(rdr.GetValue(2).ToString())%><input type=hidden name=tempDebit<%=i%> value="<%=rdr.GetValue(2).ToString()%>"></td>
		<td align=right><%=GenUtil.strNumericFormat(rdr.GetValue(3).ToString())%><input type=hidden name=tempCredit<%=i%> value="<%=rdr.GetValue(3).ToString()%>"></td>
		<td align=center><%=GenUtil.trimDate(rdr.GetValue(4).ToString())%><input type=hidden name=tempPosted<%=i%> value="<%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr.GetValue(4).ToString()))%>"></td>
		<%
		Dr+=double.Parse(rdr.GetValue(2).ToString());
		Cr+=double.Parse(rdr.GetValue(3).ToString());
		%>
		<td><input type=hidden name=tempDay<%=i%>><select name=DropDay<%=i%> onchange="Check(this,document.Form1.tempDay<%=i%>)">
		<option value="Select">Select</option>
		<%for(int j=1;j<=31;j++){%>
		<option value="<%=j%>"><%=j%></option>
		<%}%>
		</select><input type=hidden name=tempMonth<%=i%>>
		<select name=DropMonth<%=i%> onchange="Check1(this,document.Form1.tempMonth<%=i%>)">
		<option value="Select">Select</option>
		<option value="Jan">Jan</option>
		<option value="Feb">Feb</option>
		<option value="Mar">Mar</option>
		<option value="April">April</option>
		<option value="May">May</option>
		<option value="Jun">Jun</option>
		<option value="July">July</option>
		<option value="August">August</option>
		<option value="Sept">Sept</option>
		<option value="Oct">Oct</option>
		<option value="Nov">Nov</option>
		<option value="Dec">Dec</option>
		</select><input type=hidden name=tempYear<%=i%>>
		<select name=DropYear<%=i%> onchange="Check(this,document.Form1.tempYear<%=i%>)">
		<option value="Select">Select</option>
		<option value="2005">2005</option>
		<option value="2006">2006</option>
		<option value="2007">2007</option>
		<option value="2008">2008</option>
		<option value="2009">2009</option>
		<option value="2010">2010</option>
		<option value="2011">2011</option>
		<option value="2012">2012</option>
		<option value="2013">2013</option>
		<option value="2014">2014</option>
		<option value="2015">2015</option>
		</select>
		</td>
		<td align=center><input type=checkbox name=chk<%=i%> checked onclick="EnaDes(this,document.Form1.DropDay<%=i%>,document.Form1.DropMonth<%=i%>,document.Form1.DropYear<%=i%>)"></td>
		</tr>
      <%
      i++;
      }%>
      <tr bgcolor=forestgreen height=20>
      <td align=center><font color=white><b>Total</b></font></td>
      <td>&nbsp;</td>
      <td align=right><font color=white><b><%=GenUtil.strNumericFormat(Dr.ToString())%></b></font></td>
      <td align=right><font color=white><b><%=GenUtil.strNumericFormat(Cr.ToString())%></b></font></td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      </tr>
      <tr>
      <td><input type=hidden name=Count value="<%=i%>"></td>
      </tr>
      </TABLE>
    <%}
    else
    {
		MessageBox.Show("Data Not Available");
    }
    }%>
    </TD>
  </TR>
  <tr><td><asp:ValidationSummary Runat=server ID=ValidationSummary1 ShowSummary=false ShowMessageBox=true></asp:ValidationSummary></td></tr>
</TABLE>
<uc1:footer id=Footer1 runat="server"></uc1:footer>
</FORM>
	</body>
</HTML>
<script runat=server language=C#>
public void Recon(Object sender, EventArgs e)
{
	SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["epetro"]);
	SqlCommand Cmd;
	int Count=System.Convert.ToInt32(Request.Params.Get("Count"));
	int Flag=0;
	for(int i=0;i<Count;i++)
	{
		if(Request.Params.Get("chk"+i)!=null)
		{
			if(Request.Params.Get("tempDay"+i)!="" && Request.Params.Get("tempMonth"+i)!="" && Request.Params.Get("tempYear"+i)!="")
			{
				SqlCon.Open();
				Cmd=new SqlCommand("insert into Reconcillation values('"+Request.Params.Get("tempBankName"+i)+"','"+Request.Params.Get("tempVoucharType"+i)+"','"+Request.Params.Get("tempDebit"+i)+"','"+Request.Params.Get("tempCredit"+i)+"','"+GenUtil.str2MMDDYYYY(Request.Params.Get("tempPosted"+i))+"','"+GenUtil.str2MMDDYYYY(Request.Params.Get("tempDay"+i)+"/"+Request.Params.Get("tempMonth"+i)+"/"+Request.Params.Get("tempYear"+i))+"','Yes')",SqlCon);
				//Cmd=new SqlCommand("insert into Reconcillation values('"+Request.Params.Get("tempBankName"+i)+"','"+Request.Params.Get("tempVoucharType"+i)+"','"+Request.Params.Get("tempDebit"+i)+"','"+Request.Params.Get("tempCredit"+i)+"','"+GenUtil.str2MMDDYYYY(Request.Params.Get("tempPosted"+i))+"','','Yes')",SqlCon);
				Cmd.ExecuteNonQuery();
				Cmd.Dispose();
				SqlCon.Close();
				Flag=1;
			}
		}
		/*
		else
		{
			SqlCon.Open();
			if(Request.Params.Get("tempDay"+i)!="" && Request.Params.Get("tempMonth"+i)!="" && Request.Params.Get("tempYear"+i)!="")
				Cmd=new SqlCommand("insert into Reconcillation values('"+Request.Params.Get("tempBankName"+i)+"','"+Request.Params.Get("tempVoucharType"+i)+"','"+Request.Params.Get("tempDebit"+i)+"','"+Request.Params.Get("tempCredit"+i)+"','"+GenUtil.str2MMDDYYYY(Request.Params.Get("tempPosted"+i))+"','"+GenUtil.str2MMDDYYYY(Request.Params.Get("tempDay"+i)+"/"+Request.Params.Get("tempMonth"+i)+"/"+Request.Params.Get("tempYear"+i))+"','No')",SqlCon);
			else
				Cmd=new SqlCommand("insert into Reconcillation values('"+Request.Params.Get("tempBankName"+i)+"','"+Request.Params.Get("tempVoucharType"+i)+"','"+Request.Params.Get("tempDebit"+i)+"','"+Request.Params.Get("tempCredit"+i)+"','"+GenUtil.str2MMDDYYYY(Request.Params.Get("tempPosted"+i))+"','','No')",SqlCon);
			Cmd.ExecuteNonQuery();
			Cmd.Dispose();
			SqlCon.Close();
		}
		*/
	}
	if(Flag==0)
		MessageBox.Show("Please Select Atleest One Record");
	else
		MessageBox.Show("Data Save Successfully");
}
</script>
