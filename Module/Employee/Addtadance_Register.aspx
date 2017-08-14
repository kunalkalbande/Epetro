<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
<%@ Page CodeBehind="Addtadance_Register.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="EPetro.Module.Employee.Addtadance_Register" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="EPetro.Sysitem.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/Footer.ascx" %>
<%@ Import namespace="RMG"%>
<HTML>
	<HEAD>
	<script language=JavaScript>
	
	function selectAll()
	{
	    var f = document.forms[0]
		if(f.chkSelectAll.checked)
			for(var i=0;i<f.length;i++)
				f.elements[i].checked=true
		else
			for(var i=0;i<f1.length;i++)
				f.elements[i].checked=false
	}
	</script>
		<title>ePetro: Attandance Register</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Sysitem/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form name="f1" id="f1" method="post" runat=server>
		<uc1:Header id="Header1" runat="server"></uc1:Header>
			<table width=778 height=288 align=center>
				<TR>
					<Th height=20><font color=006400>Attendance Register</font><hr></Th>
				</TR>
				<tr>
					<td align=center>
						<table border=1 bgcolor=#EEFFE9 bordercolor=DarkSeaGreen cellspacing=0 cellpadding=0>
							<asp:Panel Runat=server ID=panEmp>
							<tr>
							<td colspan=4>Attendance Date &nbsp;&nbsp;<asp:DropDownList Runat=server ID="DropEmp" AutoPostBack=True><asp:ListItem Value="Select">Select</asp:ListItem></asp:DropDownList><font color="red">*</font>
							<asp:CompareValidator ID=cv1 Runat=server ControlToValidate="DropEmp" ErrorMessage="Please Select The Date" ValueToCompare="Select" Operator=NotEqual><font color="red">*</font></asp:CompareValidator>
							</td>
							</tr>
							</asp:Panel>
							<tr height=20>
								<td width=60 align="center" bgcolor="009900"><font color=#ffffff>Emp ID</font></td>
								<td width=200 align="center" bgcolor="009900"><font color=#ffffff>Name</font></td>
								<td width=150 align="center" bgcolor="009900"><font color=#ffffff>Designation</font></td>
								<td width=50 align="center" bgcolor="009900"><font color=#ffffff>Status</font></td>
							</tr>
							<%
							EmployeeClass obj=new EmployeeClass();
								SqlDataReader SqlDtr;
								string sql;
								int Row_No=0;
								int i=0;
								 string str1;
								 str1=obj.date();
							if(panEmp.Visible==false)
							{
							//try{
								 sql=" select employee.emp_id,employee.Emp_Name,employee.Designation from employee where emp_id!=all(select distinct Attandance_Register.emp_id from Attandance_Register where att_Date ='"+GenUtil.str2MMDDYYYY(str1)+"')and emp_ID!=all(    select  emp_id from leave_Register where  getdate() between Date_from and DATEADD(day, 1, date_to) and  issanction=1)"; 
								 SqlDtr=obj.GetRecordSet(sql);
													
								 while(SqlDtr.Read())
								 {
							%>
							<tr>
								<td>&nbsp;<font color=#4A3C8C><%=SqlDtr.GetValue(0).ToString()%></font><input type=hidden name=lblEmpID<%=Row_No%> value="<%=SqlDtr.GetValue(0).ToString()%>"></td>
								<td>&nbsp;<font color=#4A3C8C><%=SqlDtr.GetValue(1).ToString()%></font><input type=hidden name=lblEmpName<%=Row_No%> value="<%=SqlDtr.GetValue(1).ToString()%>"></td>
								<td>&nbsp;<font color=#4A3C8C><%=SqlDtr.GetValue(2).ToString()%></font><input type=hidden name=lblDesig<%=Row_No%> value="<%=SqlDtr.GetValue(2).ToString()%>"></td>
								<td align=center><input type=checkbox name=chk<%=Row_No%>></td>
							</tr>
							<%	Row_No++;
								}
								SqlDtr.Close();
							//}
							//catch(Exception ex)
							//{
							//CreateLogFiles.ErrorLog("Form:Attendance_Register.aspx.cs,Method:page_load() EXCEPTION: "+ ex.Message+" userid :"+ Session["User_Name"].ToString());
							//}
							%>
							
							<input type=hidden name=lblTotal_Row value=<%=Row_No%>>
							<%}
							else if(DropEmp.SelectedIndex!=0)
							{
							//string str="Select a.Emp_ID,e.Emp_Name,e.Designation,a.Status from Attandance_Register a,Employee e where Att_date='"+DropEmp.SelectedItem.Text+"' and a.Emp_ID=e.Emp_ID";
							string str="Select a.Emp_ID,e.Emp_Name,e.Designation,a.Status from Attandance_Register a,Employee e where Att_date='"+GenUtil.str2MMDDYYYY(DropEmp.SelectedItem.Text)+"' and a.Emp_ID=e.Emp_ID";
							SqlDtr = obj.GetRecordSet(str);
							
							while(SqlDtr.Read())
							{
							%>
							<tr>
							<td>&nbsp;<font color=#4A3C8C><%=SqlDtr["Emp_ID"].ToString()%></font><input type=hidden name=tempEmpID<%=i%> value=<%=SqlDtr["Emp_ID"].ToString()%>></td>
							<td>&nbsp;<font color=#4A3C8C><%=SqlDtr["Emp_Name"].ToString()%></font></td>
							<td>&nbsp;<font color=#4A3C8C><%=SqlDtr["Designation"].ToString()%></font></td>
							<%if(double.Parse(SqlDtr["Status"].ToString())==1){%>
							<td align=center><input type=checkbox name=chk<%=i%> checked></td>
							<%}else{%>
							<td align=center><input type=checkbox name=chk<%=i%>></td>
							<%}%>
							</tr>
							<%i++;}}%>
							<tr><td colspan=3 align=right bgcolor="009900"><font color=#ffffff>Select All</font>&nbsp;&nbsp;&nbsp;</td><td align=center bgcolor=009900><input type=checkbox name=chkSelectAll onClick="selectAll();"></td></tr>
							<tr><td><input type=hidden name=CountEdit value=<%=i%>></td></tr>
						</table>
					</td>
				</tr>
				<TR>
					<td align=center><asp:Button ID=Btnsave Text=Submit Runat=server OnClick="attan" BackColor=forestgreen BorderColor=darkseagreen ForeColor=white Width=70></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnEdit" Text=Edit Runat=server OnClick="View" BackColor=forestgreen BorderColor=darkseagreen ForeColor=white Width=70></asp:Button></td>
				</TR>
				<tr><td><asp:ValidationSummary ID=vs1 Runat=server ShowMessageBox=True ShowSummary=False></asp:ValidationSummary></td></tr>
			</table><uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>


<script language=C# runat=server >

    private void Page_Load(object sender, System.EventArgs e)
    {
        /*
        string uid="";
        DBOperations.DBUtil dbobj=new DBOperations.DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
        try
        {
             uid=(Session["User_Name"].ToString());
        }
        catch(Exception ex)
        {
            CreateLogFiles.ErrorLog("Form:Addtandance_Registor,Method:Page_load  userid "+ uid);
            Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
            return;
        }
        if(!IsPostBack)
        {
            #region Check Privileges
            int i;
            string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
            string Module="2";
            string SubModule="3";
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
                string msg="UnAthourized Visit to Attandance Register Page";

                Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
            }
            #endregion
        }
        */
    }

    // this method used to save the attendance of the present employee.
    public void attan(Object sender, EventArgs e)
    {
        try
        {
            if (DropEmp.Visible == true  && DropEmp.SelectedIndex == 0)
            {
                MessageBox.Show("- Please select the Date");
                return;
            }
            EmployeeClass obj=new EmployeeClass();
            int Total_Rows=0;
            SqlDataReader SqlDtr;
            string sql;
            /*
            sql="select Count(*) from Attandance_Register where Att_Date='"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Day.ToString()+"/"+DateTime.Today.Year.ToString() +"'";
            SqlDtr=obj.GetRecordSet(sql); 
            while(SqlDtr.Read())
            {
                int flag=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString()); 
                if(flag>0)
                {
                    return;					
                }
            }
            SqlDtr.Close();
            */

            string empid ="";
            string empid1 ="";
            if(panEmp.Visible==false)
            {
                Total_Rows=System.Convert.ToInt32(Request.Params.Get("lblTotal_Row"));
                for(int i=0;i<Total_Rows;i++)
                {
                    if(Request.Params.Get("Chk"+i)!=null)
                    {
                        string str="";
                        obj.Att_Date=DateTime.Now.ToShortDateString();
                        obj.Emp_ID=Request.Params.Get("lblEmpID"+i);
                        obj.Status="1";
                        EmployeeClass obj1=new EmployeeClass();
                        SqlDataReader SqlDtr11;
                        string sql1;
                        string dtTime = GenUtil.str2DDMMYYYY(DateTime.Now.ToShortDateString());
                        sql1="select Status from Attandance_Register where Att_Date=Convert(datetime,'" + dtTime+"',103) and  Emp_ID="+Request.Params.Get("lblEmpID"+i)+"";
                        SqlDtr11=obj1.GetRecordSet(sql1);
                        while(SqlDtr11.Read())
                        {
                            str=SqlDtr11.GetValue(0).ToString();
                        }
                        if(str.Equals("0") || str.Equals(""))
                        {
                            obj.InsertEmployeeAttandance();
                            CreateLogFiles.ErrorLog("Form:Attendance_Register.aspx.cs,Method:attan(). Attendance of employee ID "+Request.Params.Get("lblEmpID"+i)+" Saved. userid :"+ Session["User_Name"].ToString());
                            empid= empid+" "+Request.Params.Get("lblEmpID"+i)+"   ";
                        }
                        else
                        {
                            empid1= empid1+" "+Request.Params.Get("lblEmpID"+i)+"   ";
                        }
                    }
                }
                if(!empid.Equals(""))
                {
                    MessageBox.Show("Attendance Saved");
                }
                if(!empid1.Equals(""))
                    MessageBox.Show("Attandance Already Exits For Employee ID "+empid1);
            }
            else
            {
                Total_Rows=System.Convert.ToInt32(Request.Params.Get("CountEdit"));
                for(int i=0;i<Total_Rows;i++)
                {
                    string str="";
                    if(Request.Params.Get("Chk"+i)!=null)
                    {
                        //obj.Att_Date=DropEmp.SelectedItem.Text;  
                        obj.Att_Date=GenUtil.str2MMDDYYYY(DropEmp.SelectedItem.Text);
                        obj.Emp_ID=Request.Params.Get("tempEmpID"+i);
                        obj.Status="1";
                        obj.UpdateEmployeeAttandance();
                        CreateLogFiles.ErrorLog("Form:Attendance_Register.aspx.cs,Method:attan(). Attendance of employee ID "+Request.Params.Get("tempEmpID"+i)+" Updated. userid :"+ Session["User_Name"].ToString());
                    }
                    else
                    {
                        //obj.Att_Date=DropEmp.SelectedItem.Text;  
                        obj.Att_Date=GenUtil.str2MMDDYYYY(DropEmp.SelectedItem.Text);
                        obj.Emp_ID=Request.Params.Get("tempEmpID"+i);
                        obj.Status="0";
                        obj.UpdateEmployeeAttandance();
                        CreateLogFiles.ErrorLog("Form:Attendance_Register.aspx.cs,Method:attan(). Attendance of employee ID "+Request.Params.Get("tempEmpID"+i)+" Updated. userid :"+ Session["User_Name"].ToString());
                    }
                }
                MessageBox.Show("Attendance Update");
                panEmp.Visible=false;
            }
        }
        catch(Exception ex)
        {
            CreateLogFiles.ErrorLog("Form:Attendance_Register.aspx.cs,Method:attan(). EXCEPTION: "+ ex.Message+" userid :"+ Session["User_Name"].ToString());
        }
    }

    public void View(Object sender, EventArgs e)
    {
        try
        {
            if (DropEmp.Visible == true && DropEmp.SelectedIndex == 0)
            {
                MessageBox.Show("- Please select the Date");
                return;
            }
            panEmp.Visible=true;
            EmployeeClass obj=new EmployeeClass();
            SqlDataReader SqlDtr;
            string sql;
            sql="select distinct Att_Date from Attandance_Register";
            SqlDtr=obj.GetRecordSet(sql);
            DropEmp.Items.Clear();
            DropEmp.Items.Add("Select");
            while(SqlDtr.Read())
            {
                //DropEmp.Items.Add(SqlDtr["Att_Date"].ToString());
                DropEmp.Items.Add(GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["Att_Date"].ToString())));
            }
            SqlDtr.Close();
        }
        catch(Exception ex)
        {
            CreateLogFiles.ErrorLog("Form:Attendance_Register.aspx.cs,Method:attan(). EXCEPTION: "+ ex.Message+" userid :"+ Session["User_Name"].ToString());
        }
    }

    public DateTime ToMMddYYYY(string str)
    {
        int dd,mm,yy;
        string [] strarr = new string[3];
        strarr=str.Split(new char[]{'/'},str.Length);
        dd=Int32.Parse(strarr[0]);
        mm=Int32.Parse(strarr[1]);
        yy=Int32.Parse(strarr[2]);
        DateTime dt=new DateTime(yy,mm,dd);
        return(dt);
    }
</script>
