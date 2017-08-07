<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<%@ Page CodeBehind="DailyOperationEntries.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="EPetro.Module.PetrolPump.Daily_Entries" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Import namespace="RMG"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>


<HTML>
	<HEAD>
	<script language=javascript>
	//Mahesh, Date : 31.01.007
	//This function not call at btnSave button by Mahesh 
	//But in future, This validate function call to btn save button at OnBlur event.
	function Validate()
	{
		var flag=0
		var f=document.f1
		for(var i=0;i<f.length;i++)
		{
			if(f.elements[i].value=="")
			{
				flag=1
				alert("Please Fill All The Fields")
				break;
			}
		}
		if(flag==0)
		{
			f.submit()		
		}
	}
	
	function Check(t)
	{
		//alert(t.name)
		if(t.value != "")
		{
			//if(t.name=="txtCNGDensityTank-1" || t.name=="txtCNGDensityTank-2" || t.name=="txtCNGDensityTank-3" || t.name=="txtCNGDensityTank-4" || t.name=="txtDiesel(HSD)DensityTank-1" || t.name=="txtDiesel(HSD)DensityTank-2" || t.name=="txtDiesel(HSD)DensityTank-3" || t.name=="txtDiesel(HSD)DensityTank-4" || t.name=="txtPetrol(MS)DensityTank-1" || t.name=="txtPetrol(MS)DensityTank-2" || t.name=="txtPetrol(MS)DensityTank-3" || t.name=="txtPetrol(MS)DensityTank-4" || t.name=="txtSuper DieselDensityTank-1" || t.name=="txtSuper DieselDensityTank-2" || t.name=="txtSuper DieselDensityTank-3" || t.name=="txtSuper DieselDensityTank-4" || t.name=="txtSuper PetrolDensityTank-1" || t.name=="txtSuper PetrolDensityTank-2" || t.name=="txtSuper PetrolDensityTank-3" || t.name=="txtSuper PetrolDensityTank-4" || t.name=="txtAuto LPGDensityTank-1" || t.name=="txtAuto LPGDensityTank-2" || t.name=="txtAuto LPGDensityTank-3" || t.name=="txtAuto LPGDensityTank-4")
			if(t.name=="txtCNG1DensityTank-1" || t.name=="txtCNG2DensityTank-1" || t.name=="txtCNG3DensityTank-1" || t.name=="txtCNG4DensityTank-1" || t.name=="txtDiesel(HSD)1DensityTank-1" || t.name=="txtDiesel(HSD)2DensityTank-1" || t.name=="txtDiesel(HSD)3DensityTank-1" || t.name=="txtDiesel(HSD)4DensityTank-1" || t.name=="txtPetrol(MS)1DensityTank-1" || t.name=="txtPetrol(MS)2DensityTank-1" || t.name=="txtPetrol(MS)3DensityTank-1" || t.name=="txtPetrol(MS)4DensityTank-1" || t.name=="txtSuper Diesel1DensityTank-1" || t.name=="txtSuper Diesel2DensityTank-1" || t.name=="txtSuper Diesel3DensityTank-1" || t.name=="txtSuper Diesel4DensityTank-1" || t.name=="txtSuper Petrol1DensityTank-1" || t.name=="txtSuper Petrol2DensityTank-1" || t.name=="txtSuper Petrol3DensityTank-1" || t.name=="txtSuper Petrol4DensityTank-1" || t.name=="txtAuto LPG1DensityTank-1" || t.name=="txtAuto LPG2DensityTank-1" || t.name=="txtAuto LPG3DensityTank-1" || t.name=="txtAuto LPG4DensityTank-1")
			{
				if(t.value <= 679 || t.value >= 771 && t.value <= 789 || t.value >= 861)
				{
					t.value=""
					alert("Invalid Density Value,(680 To 770 And 790 To 860)...")
					return
				}
				else
					document.f1.den.value=t.value
			}
			if(t.name=="txtCNG1TempTank-1" || t.name=="txtCNG2TempTank-1" || t.name=="txtCNG3TempTank-1" || t.name=="txtCNG4TempTank-1" || t.name=="txtDiesel(HSD)1TempTank-1" || t.name=="txtDiesel(HSD)2TempTank-1" || t.name=="txtDiesel(HSD)3TempTank-1" || t.name=="txtDiesel(HSD)4TempTank-1" || t.name=="txtPetrol(MS)1TempTank-1" || t.name=="txtPetrol(MS)2TempTank-1" || t.name=="txtPetrol(MS)3TempTank-1" || t.name=="txtPetrol(MS)4TempTank-1" || t.name=="txtSuper Diesel1TempTank-1" || t.name=="txtSuper Diesel2TempTank-1" || t.name=="txtSuper Diesel3TempTank-1" || t.name=="txtSuper Diesel4TempTank-1" || t.name=="txtSuper Petrol1TempTank-1" || t.name=="txtSuper Petrol2TempTank-1" || t.name=="txtSuper Petrol3TempTank-1" || t.name=="txtSuper Petrol4TempTank-1" || t.name=="txtAuto LPG1TempTank-1" || t.name=="txtAuto LPG2TempTank-1" || t.name=="txtAuto LPG3TempTank-1" || t.name=="txtAuto LPG4TempTank-1")
			{
				if(t.value < -2.50 || t.value > 65)
				{
					t.value=""
					alert("Invalid Temperature Value,(-2.5 To 65)...")
					return
				}
				else
					document.f1.temp.value=t.value
					//document.f1.txtCNGConDensTank-1=ConDen(document.f1.temp.value,document.f1.den.value)
			}
			
		}
		if(t.name=="txtCNG1ConDensTank-1" || t.name=="txtCNG2ConDensTank-1" || t.name=="txtCNG3ConDensTank-1" || t.name=="txtCNG4ConDensTank-1" || t.name=="txtDiesel(HSD)1ConDensTank-1" || t.name=="txtDiesel(HSD)2ConDensTank-1" || t.name=="txtDiesel(HSD)3ConDensTank-1" || t.name=="txtDiesel(HSD)4ConDensTank-1" || t.name=="txtPetrol(MS)1ConDensTank-1" || t.name=="txtPetrol(MS)2ConDensTank-1" || t.name=="txtPetrol(MS)3ConDensTank-1" || t.name=="txtPetrol(MS)4ConDensTank-1" || t.name=="txtSuper Diesel1ConDensTank-1" || t.name=="txtSuper Diesel2ConDensTank-1" || t.name=="txtSuper Diesel3ConDensTank-1" || t.name=="txtSuper Diesel4ConDensTank-1" || t.name=="txtSuper Petrol1ConDensTank-1" || t.name=="txtSuper Petrol2ConDensTank-1" || t.name=="txtSuper Petrol3ConDensTank-1" || t.name=="txtSuper Petrol4ConDensTank-1" || t.name=="txtAuto LPG1ConDensTank-1" || t.name=="txtAuto LPG2ConDensTank-1" || t.name=="txtAuto LPG3ConDensTank-1" || t.name=="txtAuto LPG4ConDensTank-1")
		{
			if(document.f1.temp.value != "" && document.f1.den.value != "")
			{
				t.value=ConDen(document.f1.temp.value,document.f1.den.value)
				document.f1.temp.value=""
				document.f1.den.value=""
				t.enable=false;
			}
		}
		//alert(t.name)
	}
	
</script>
		<title>ePetro: Daily Tank & Meter Reading</title>
		<script id=Validations language=javascript  src=../../Sysitem/Js/Validations.js></script>  
		<script language="javascript" id="ConvertDensity" src="../../Sysitem/Js/ConvertDensity.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../Sysitem/Styles.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form  name="f1" id=f1 method="post" Runat=server>
		<uc1:Header id="Header1" runat="server"></uc1:Header>
		<INPUT type=hidden name="den" size=1>
		<input type=hidden name="temp" id=temp onblur="ConDen(this,document.f1.den.value)" size=1>
		<table align=center border=0 width=778><tr><td>
		<table cellpadding=0 cellspacing=1 border=0 align=center>
<!--************************	Tank Related Entries	  *************************************-->
				<TR>
					<Th align=center colspan=5><font color="#006400">Daily Operation Entry</font><hr></Th>
				</TR>
				<asp:Panel ID=panEntry Runat=server Visible=False>
				<TR>
					<Td colspan=5>&nbsp;&nbsp;&nbsp;Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID=DropEntryDate Runat=server OnSelectedIndexChanged="Show" AutoPostBack=True><asp:ListItem Value="Select">Select</asp:ListItem></asp:DropDownList></Td>
				</TR>
				</asp:Panel>
				<%
				PetrolPumpClass obj=new PetrolPumpClass();
				int no_of_products=obj.GetTotalFuelProducts();
				string[] Products=obj.GetFuelProducts();
				int[] no_of_tanks=obj.GetFuelWiseTanks();
				int flag=0;
				string[] Tanks={"Tank-1","Tank-2","Tank-3","Tank-4"};
				//string[] Params={"Density","Temp","ConDens","OpenStk","TankDip","WaterDip","Testing"};
				string[] Params={"Density","Temp","ConDens","TankDip","WaterDip","Testing"};
				//int no_of_rows=Products.Length/3;
				int no_of_rows=Products.Length/5;
				int Prod_No=1;
				int TankCount=0;
				//if(no_of_products%3!=0)
				if(no_of_products%5!=0)
					no_of_rows++;
				%>
				<tr><td><input type=hidden name=Total_Products value=<%=no_of_products%> size=3></td></tr>				
				<%		
				for(int i=1;i<=no_of_rows;i++)
				{
				%>
				<tr>
				<%
				
				//for(int j=1;j<=3;j++)
				for(int j=1;j<=5;j++)
				{
					if(Prod_No>no_of_products)
						continue;
				%>
					<td>
						<table cellspacing=0 cellpadding=0 border=1>
							<tr><td  align=center colspan=5><b>Product : <%=Products[Prod_No-1]%><input name="lblProd<%=Prod_No%>" type="hidden" value="<%=Products[Prod_No-1]%>"></b></td></tr>
							<tr>
							<% 
							
							if(flag==0)
							{
							%>
							<td>&nbsp;</td>
							<% 
							}
							if(flag==2)
							{
							%>
							<td>&nbsp;</td>
							<% 
							}
							int i1=0;
							int flag11=0;
							//**while(i1 < no_of_tanks[Prod_No-1])
							while(i1 < no_of_tanks[Prod_No-1]+1)
							{
							if(flag11==0)
							{
							i1++;
							}
							%>
							
							<td align=center><%=obj.GetTankProduct("Tank-"+i1,Products[Prod_No-1])%></td>
							<!--td>&nbsp;</td><td align =center >&nbsp;&nbsp;Tank-1&nbsp;&nbsp;</td><td align =center >&nbsp;&nbsp;Tank-2&nbsp;&nbsp;</td><td align =center >&nbsp;&nbsp;Tank-3&nbsp;&nbsp;</td><td align =center >&nbsp;&nbsp;Tank-4&nbsp;&nbsp;</td-->
							<%
							i1++;
							flag11=1;
							}%>
							</tr>
							<tr><td><input name=lblProd<%=Prod_No+"Tanks"%> type=hidden value =<%=no_of_tanks[Prod_No-1]%> size=3></td></tr>
							<%	for(int k=0;k<Params.Length;k++)
								{
								
								if(flag==0)
								{
							%>
									<tr><td>&nbsp;<b><%=Params[k]%></b>&nbsp;&nbsp;&nbsp;</td>
									
								<%
								}
								//*************
								if(flag==2)
								{
							%>
									<tr><td>&nbsp;<b><%=Params[k]%></b>&nbsp;&nbsp;&nbsp;</td>
									
								<%
								}
								//***************
								
									for(int m=0;m<4;m++)
									{
								%>
										<%if(EditCount==1)//(Start) add on 26.09.007
										{
											if(no_of_tanks[Prod_No-1]>m)
											{%>
												<td align=center width=133><INPUT type=text size=5 maxlength=5 name="txt<%=Products[Prod_No-1]+Params[k]+Tanks[m]%>" style="border-style:Groove; FONT-SIZE: 8pt;" onkeypress="return GetOnlyNumbers(this, event, false,true);" onblur="Check(this)" value="<%=Tank[TankCount++]%>"></td>
											<%}
										}
										else//(End) add on 26.09.007
										if(no_of_tanks[Prod_No-1]>m)
										{%>
										<td align=center width=133><INPUT type=text size=5 maxlength=5 name="txt<%=Products[Prod_No-1]+Params[k]+Tanks[m]%>" style="border-style:Groove; FONT-SIZE: 8pt;" onkeypress="return GetOnlyNumbers(this, event, false,true);" onblur="Check(this)">
										</td>
										<%}%>
								<%}%>
									</tr>
							<%}	%>
						</table>
					</td>
				<%Prod_No++;
				flag=1;
				} 
				%>
				</tr>
				<%
				//**
				flag=2;
				//**
				}
				%>
				</table>
				</td>
				</tr>
				<tr>
				<td align=center>
				<table align=center cellpadding=0 cellspacing=1 border=0 align=center>
<!--************************	Nozzel Related Entries	  *************************************-->
				
				<TR>
					<Th align=center colspan=2><font color=006400>Meter Reading<hr></font></Th>
				</TR>
				<%
				int no_of_machines=obj.GetTotalMachines();	
				int[] no_of_nozzels=obj.GetNozzles();	
				//string[] Nozzels={"Nozzle-1","Nozzle-2","Nozzle-3","Nozzle-4"};
				string[] Nozzels={"Nozzle-1","Nozzle-2","Nozzle-3","Nozzle-4","Nozzle-5","Nozzle-6"};
				//int rows=no_of_machines/3;
				int rows=no_of_machines/2;
				int Machine_No=1;
				//***********
				int[] MachineNo=obj.getMachineNo();
				//***********
				int flag1=0;
				TankCount=0;
				//if(no_of_machines%3!=0)
				if(no_of_machines%2!=0)
					rows++;
				%>
				<tr><td><input type=hidden name=Total_Machines value=<%=no_of_machines%> size=3></td></tr>
				<%
				for(int i=1;i<=rows;i++)
				{
				flag1=0;
				%>
				<tr>
				<%
				//for(int j=1;j<=3;j++)
				for(int j=1;j<=2;j++)
				{   
					if(Machine_No>no_of_machines)
						continue;
						
				%>
					<td>
						<table cellpadding=0 cellspacing =0 border=1>
							<tr><td  align=center colspan=7><b>Machine : M-<%=MachineNo[Machine_No-1]%> (<%=obj.GetMachineName("M-"+MachineNo[Machine_No-1])%>)<input name=lblMachine<%=Machine_No%> type="hidden" value=M-<%=MachineNo[Machine_No-1]%>></b></td></tr>
							<% if(flag1==0){%>
							<tr><td>&nbsp;&nbsp;</td>
							
							<!--for(int k=0;k<4;k++)--><%}int i2=0;
							while(i2 < no_of_nozzels[Machine_No-1])	
							{
							%>
							<td align =center >&nbsp;<%=Nozzels[i2]%>&nbsp;<br>(<%=obj.GetNozzleProduct("M-"+MachineNo[Machine_No-1],Nozzels[i2])%>)</td>
							
							<%
							i2++;	
							}
							%>	
							</tr>
							<input name=lblMachine<%=Machine_No%>Nozzles type=hidden value =<%=no_of_nozzels[Machine_No-1]%>>
								<% if(flag1==0){%>
								<tr><td align =	center>&nbsp;&nbsp;<b>Mtr.Read</b>&nbsp;&nbsp;</td>
								<%}
                                    for(int m=0;m<6;m++)
                                    {
                                        if(EditCount==1)//(Start) add on 26.09.007
                                        {
                                            if(no_of_nozzels[Machine_No-1]>m && TankCount <= 5){%>
											<td align=center><input type=text size=5 class="FontStyle" maxlength=10 name=txtM-<%=MachineNo[Machine_No-1]+Nozzels[m]%> style="border-style:Groove;" onkeypress="return GetOnlyNumbers(this, event, false,true);" value="<%=Nozzle[TankCount++]%>"></td>
											<%}
										}
										else
										if(no_of_nozzels[Machine_No-1]>m){%>
										<td align=center><input type=text size=5 class="FontStyle" maxlength=10 name=txtM-<%=MachineNo[Machine_No-1]+Nozzels[m]%> style="border-style:Groove;" onkeypress="return GetOnlyNumbers(this, event, false,true);"></td>
										<%}%>
								<%	}
								%>
								</tr>
						</table>
					</td>
				<%Machine_No++;
				flag1=1;
				} 
				%>
				</tr>
				<% 
				}
				%>
				</table>
				</td>
				</tr>
<!--************************************	End		*************************************-->
			<!--tr><td align =center colspan=3><hr   size=2></td></tr-->
			<tr>
			<%if(EditCount==1){%>
				<td valign=middle>&nbsp;&nbsp;&nbsp;Remark&nbsp;&nbsp;&nbsp;<input name="txtRemark" type=text size=90 maxlength=100 style="border-style:Groove; FONT-SIZE: 8pt;" value=<%=Remarks%>>
			<%}else%>
				<td valign=middle>&nbsp;&nbsp;&nbsp;Remark&nbsp;&nbsp;&nbsp;<input name="txtRemark" type=text size=90 maxlength=100 style="border-style:Groove; FONT-SIZE: 8pt;">
			&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID=Btnsave Text=Submit Runat=server OnClick="save" BackColor=forestgreen BorderColor=darkseagreen ForeColor=white Width=70></asp:Button>
			<asp:Button ID="btnEdit" Text=Edit Runat=server OnClick="Update" BackColor=forestgreen BorderColor=darkseagreen ForeColor=white Width=70></asp:Button>
			<asp:Button ID="btnDelete" Text=Delete Runat=server OnClick="Del" BackColor=forestgreen BorderColor=darkseagreen ForeColor=white Width=70></asp:Button>
			</td></tr>
			</table></td></tr></table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
<script language=C# runat=server >
private void Page_Load(object sender, System.EventArgs e)
{
	/*	
	string uid;
	try
	{
	   	uid=(Session["User_Name"].ToString());
	}
	catch(Exception ex)
	{
		CreateLogFiles.ErrorLog("Form:Daily_Entry ,Method:Page_load, EXCEPTION  "+ex.Message);
		Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
		return;
	}
	if(!IsPostBack)
	{
		DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		#region Check Privileges
		int i;
		string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
		string Module="5";
		string SubModule="4";
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
		if(Add_Flag=="0")
		{
			string msg="UnAthourized Visit to Daily Entries Page";
			Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
		}
		#endregion
	}
	*/
}
		
		
public void save(Object sender, EventArgs e)
{ 
	try
	{
	    if(panEntry.Visible==true)
	    {
			if(DropEntryDate.SelectedIndex==0)
			{
				MessageBox.Show("Please Select The Date First");
				return;
			}
		}
		//****************************
		
		if(panEntry.Visible==false)
		{
			InventoryClass obj1 = new InventoryClass();
			SqlDataReader rdr;
			rdr = obj1.GetRecordSet("select * from daily_tank_reading where entry_date='"+DateTime.Now.Date.ToShortDateString()+"'");
			if(rdr.HasRows)
			{
				MessageBox.Show("Data Already Exists");
				return;
			}
			rdr.Close();
			rdr = obj1.GetRecordSet("select * from daily_meter_reading where entry_date='"+DateTime.Now.Date.ToShortDateString()+"'");
			if(rdr.HasRows)
			{
				MessageBox.Show("Data Already Exists");
				return;
			}
			rdr.Close();
		}
		
		//****************************
		int Total_Products=System.Convert.ToInt32(Request.Params.Get("Total_Products"));
		int Total_Machines=System.Convert.ToInt32(Request.Params.Get("Total_Machines"));
		//MessageBox.Show("product : "+Total_Products.ToString()+", Machine : "+Total_Machines.ToString());
		string Remark = System.Convert.ToString(Request.Params.Get("txtRemark"));
		string[] Products={"lblprod1","lblprod2","lblprod3","lblprod4","lblprod4","lblprod5","lblprod6","lblprod7","lblprod8"};
		string[] Machines={"lblMachine1","lblMachine2","lblMachine3","lblMachine4","lblMachine5","lblMachine6","lblMachine7","lblMachine8"};
		string[] ProdTanks={"lblprod1Tanks","lblprod2Tanks","lblprod3Tanks","lblprod4Tanks","lblprod5Tanks","lblprod6Tanks","lblprod7Tanks","lblprod8Tanks"};
		string[] MachineNozzles={"lblMachine1Nozzles","lblMachine2Nozzles","lblMachine3Nozzles","lblMachine4Nozzles","lblMachine5Nozzles","lblMachine6Nozzles","lblMachine7Nozzles","lblMachine8Nozzles"};
		string[] Tanks={"Tank-1","Tank-2","Tank-3","Tank-4"};
		//string[] Nozzles={"Nozzle-1","Nozzle-2","Nozzle-3","Nozzle-4"};
		string[] Nozzles={"Nozzle-1","Nozzle-2","Nozzle-3","Nozzle-4","Nozzle-5","Nozzle-6"};
		string prod_name = "";
		string tank_name = "";
		string machine_name = "";
		string nozzle = "";
				
		// Checked if all the required fields are filled or not, if not then display the message.
		int f = 0,f1=0,f2=0,f3=0,f4=0,f5=0,f6=0,f7=0,ff1=0,ff2=0;
		for(int i=0;i<Total_Products;i++)
		{
			for(int j=0;j<System.Convert.ToInt32(Request.Params.Get(ProdTanks[i]));j++)
			{
				prod_name=Request.Params.Get(Products[i]);
				tank_name=Tanks[j];
				if(Request.Params.Get("txt"+prod_name+"Density"+tank_name).Trim().Equals(""))
					f++;
				//f= 1;
				if(Request.Params.Get("txt"+prod_name+"Temp"+tank_name).Trim().Equals(""))
					f1++;
				//f= 1;
				if(Request.Params.Get("txt"+prod_name+"ConDens"+tank_name).Trim().Equals(""))
					f2++;
				//f= 1;
				//**if(Request.Params.Get("txt"+prod_name+"OpenStk"+tank_name).Trim().Equals(""))
					//**f3++;
				//f= 1;
				if(Request.Params.Get("txt"+prod_name+"TankDip"+tank_name).Trim().Equals(""))
					f4++;
				//f= 1;
				if(Request.Params.Get("txt"+prod_name+"WaterDip"+tank_name).Trim().Equals(""))
					f5++;
				if(Request.Params.Get("txt"+prod_name+"Testing"+tank_name).Trim().Equals(""))
					f6++;
				ff1++;
			}
			//MessageBox.Show("For loop"+i+" : "+ff1.ToString()+", f : "+f.ToString());
		}	
		for(int i=0;i<Total_Machines;i++)
		{
			for(int j=0;j<System.Convert.ToInt32(Request.Params.Get(MachineNozzles[i]));j++)
			{
			    machine_name=Request.Params.Get(Machines[i]);
				nozzle=Nozzles[j];
				if(Request.Params.Get("txt"+machine_name+nozzle).Trim().Equals(""))
					f7++;
				//f= 1;
				ff2++;
			}
		}
		//****Hide by Mahesh, date : 31.01.007
		///****Remove the validation********
		//MessageBox.Show(ff1.ToString()+", "+ff2.ToString());
		if(ff1==f && ff1==f1 && ff1==f2 && ff1==f3 && ff1==f4 && ff1==f5 && ff1==f6 && ff2==f7)
		{
			MessageBox.Show("Please fill some fields");
			return;				
		}
		//***********/
		
		for(int i=0;i<Total_Products;i++)
		{
			for(int j=0;j<System.Convert.ToInt32(Request.Params.Get(ProdTanks[i]));j++)
			{
				PetrolPumpClass obj=new PetrolPumpClass();
						
				if(Request.Params.Get(Products[i]).Equals(""))
					obj.ProdName="";
				else
					obj.ProdName=Request.Params.Get(Products[i]);
				if(Tanks[j].Equals(""))
					obj.TankName="";
				else
					obj.TankName=Tanks[j];
				obj.Density=Request.Params.Get("txt"+obj.ProdName+"Density"+obj.TankName);
				if(obj.Density.Equals(""))
					obj.Density="0";
				obj.Temprature=Request.Params.Get("txt"+obj.ProdName+"Temp"+obj.TankName);
				if(obj.Temprature.Equals(""))
					obj.Temprature="0";
				obj.ConvertedDensity=Request.Params.Get("txt"+obj.ProdName+"ConDens"+obj.TankName);
				if(obj.ConvertedDensity.Equals(""))
					obj.ConvertedDensity="0";
				//**obj.OpeningStock=Request.Params.Get("txt"+obj.ProdName+"OpenStk"+obj.TankName);
				//**if(obj.OpeningStock.Equals(""))
				//obj.OpeningStock="0";
				obj.TankDip=Request.Params.Get("txt"+obj.ProdName+"TankDip"+obj.TankName);
				if(obj.TankDip.Equals(""))
					obj.TankDip="0";
				obj.WaterDip=Request.Params.Get("txt"+obj.ProdName+"WaterDip"+obj.TankName);
				if(obj.WaterDip.Equals(""))
					obj.WaterDip="0";
				obj.Testing=Request.Params.Get("txt"+obj.ProdName+"Testing"+obj.TankName);
				if(obj.Testing.Equals(""))
					obj.Testing="0";
				obj.Remark = Remark;
				if(panEntry.Visible==false)
				{
					obj.OpeningStock="0";
					obj.EntryDate=DateTime.Now.Date.ToShortDateString();
					obj.InsertDailyTankReading();
				}
				else
				{
					obj.OpeningStock="1";
					obj.EntryDate=GenUtil.str2DDMMYYYY(DropEntryDate.SelectedItem.Text);
					obj.InsertDailyTankReading(); 
				}
						
			}
		}
		for(int i=0;i<Total_Machines;i++)
		{
			for(int j=0;j<System.Convert.ToInt32(Request.Params.Get(MachineNozzles[i]));j++)
			{
				PetrolPumpClass obj=new PetrolPumpClass();
						
				obj.MachineName=Request.Params.Get(Machines[i]);
				obj.NozzelName=Nozzles[j];
				obj.Reading=Request.Params.Get("txt"+obj.MachineName+obj.NozzelName);
				if(obj.Reading.Equals(""))
					obj.Reading="0";
				if(panEntry.Visible==false)
				{
					obj.OpeningStock="0";
					obj.EntryDate=DateTime.Now.Date.ToShortDateString();
					obj.InsertDailyMeterReading(); 
				}
				else
				{
					obj.OpeningStock="1";
					obj.EntryDate=GenUtil.str2DDMMYYYY(DropEntryDate.SelectedItem.Text);
					obj.InsertDailyMeterReading();
				}
			}
		}
		if(panEntry.Visible==false)
		{	
			CreateLogFiles.ErrorLog("Form:Daily_Entry ,Method:save Dialy Entry Saved.");
			MessageBox.Show("Daily Entries Saved");
		}
		else
		{	
			CreateLogFiles.ErrorLog("Form:Daily_Entry ,Method:save Dialy Entry Update");
			MessageBox.Show("Daily Entries Updated");
			panEntry.Visible=false;
			Btnsave.Text="Submit";
		}
	}
	catch(FormatException fe)
	{
		MessageBox.Show("Please fill all the fields");
		return;
	}
	catch(Exception ex)
	{
		CreateLogFiles.ErrorLog("Form:Daily_Entry ,Method:save , EXCEPTION  "+ex.ToString());
	}
}
		
public void Update(Object sender, EventArgs e)
{
	InventoryClass obj = new InventoryClass();
	SqlDataReader rdr;
	string str="select distinct Entry_Date from Daily_Tank_Reading";
	rdr = obj.GetRecordSet(str);
	DropEntryDate.Items.Clear();
	DropEntryDate.Items.Add("Select");
	while(rdr.Read())
	{
		DropEntryDate.Items.Add(GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr.GetValue(0).ToString())));
	}
	rdr.Close();
	panEntry.Visible=true;
	Btnsave.Text="Update";
}

public void Show(object sender, System.EventArgs e)
{
	if(DropEntryDate.SelectedIndex!=0)
	{
		EditCount=1;
		FatchData();
	}
	else
	{
		MessageBox.Show("Please Select The Date First");
		return;
	}
}
		
public void Del(object sender, System.EventArgs e)
{
	try
	{
		if(panEntry.Visible==true)
		{
			if(DropEntryDate.SelectedIndex!=0)
			{
				PetrolPumpClass obj=new PetrolPumpClass();
				obj.DeleteRecord("delete from Daily_Tank_Reading where Entry_Date = '"+GenUtil.str2MMDDYYYY(DropEntryDate.SelectedItem.Text)+"'");
				obj.DeleteRecord("delete from Daily_Meter_Reading where Entry_Date = '"+GenUtil.str2MMDDYYYY(DropEntryDate.SelectedItem.Text)+"'");
				MessageBox.Show("Daily Operation Entries Deleted");
				panEntry.Visible=false;
				Btnsave.Text="Submit";
			}
			else
			{
				MessageBox.Show("Please Select The Date");
			}
		}
		else
		{
			MessageBox.Show("Please Click The Edit Button First");
		}
	}
	catch(Exception ex)
	{
		CreateLogFiles.ErrorLog("Form:DailyOperationEntry ,Method:Del() , EXCEPTION  "+ex.ToString());
	}
}
</script>
