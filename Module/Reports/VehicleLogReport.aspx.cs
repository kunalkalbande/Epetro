/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data .SqlClient ;
using EPetro.Sysitem.Classes ;
using System.Net; 
using System.Net.Sockets ;
using System.IO ;
using System.Text;
using DBOperations;
using RMG;

namespace EPetro
{
	/// <summary>
	/// Summary description for VehicleLogReport.
	/// </summary>
	public class VehicleLogReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.DataGrid grdLog;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["EPetro"],true);
		protected System.Web.UI.WebControls.DropDownList Dropvehicleno;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		string uid="";
		string strOrderBy="";
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DropDownList DropOption;
		protected System.Web.UI.WebControls.Panel PenOption;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.CompareValidator cv1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.DataGrid grdFright;
		public bool f= true;
	
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
				if(! IsPostBack)
				{
                    txtDateFrom.Attributes.Add("readonly", "readonly");
                    txtDateTo.Attributes.Add("readonly", "readonly");
                    PenOption.Visible=false;
					getVehicleNo();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="20";
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
					if(View_flag=="0")
					{
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					}
					#endregion 
					txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					txtDateTo.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:vehicle Dialy Log Report.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"  "+ uid );
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
		}
		
		/// <summary>
		/// Fetch the vehicle no and id from vehicleentry table and fills the combo
		/// </summary>
		public void getVehicleNo()
		{
			SqlDataReader SqlDtr = null;
			dbobj.SelectQuery("Select vehicle_no+' VID '+cast(vehicledetail_id as varchar) from vehicleentry order by vehicle_no",ref SqlDtr);
			Dropvehicleno.Items.Clear();
			Dropvehicleno.Items.Add("Select");  
			while(SqlDtr.Read())
			{
				Dropvehicleno.Items.Add(SqlDtr.GetValue(0).ToString());
				
			}
			SqlDtr.Close(); 
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
			this.DropOption.SelectedIndexChanged += new System.EventHandler(this.DropOption_SelectedIndexChanged);
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
		
		/// <summary>
		/// This method is used to Returns the date in MM/DD/YYYY format.
		/// </summary>
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

		/// <summary>
		/// This method is used to returns the route name for passing route Id.
		/// </summary>
		public string getRoute(string str)
		{
			SqlDataReader SqlDtr = null;
			dbobj.SelectQuery("Select Route_name from Route where Route_Id = "+str.Trim(),ref SqlDtr);
			if(SqlDtr.Read())
			{
				str = SqlDtr.GetValue(0).ToString();  
			}
			else
			{
				str = "";
			} 
			return str;
		}

		/// <summary>
		/// This method is used to returns the Acknowledgement 1 for Yes and 0 for No.
		/// </summary>
		public string getAcknow(string str)
		{
			if(str=="0")
				return "No";
			else if(str=="1")
				return "Yes";
			else
				return "";
		}

		/// <summary>
		/// Checks the validity of the form .. all the fields are properly filled or not.
		/// </summary>
		public bool checkValidity()
		{
			string ErrorMessage = "";
			bool flag = true;
			if(Dropvehicleno.SelectedIndex  == 0)
			{
				ErrorMessage = ErrorMessage + " - Please Select Vehicle No.\n";
				flag = false;
			}
			if(txtDateFrom.Text.Trim().Equals(""))
			{
				ErrorMessage = ErrorMessage + " - Please Select From Date\n";
				flag = false;
			}
			if(txtDateTo.Text.Trim().Equals(""))
			{
				ErrorMessage = ErrorMessage + " - Please Select To Date\n";
				flag = false;
			}
			
			if(flag == false)
			{
				MessageBox.Show(ErrorMessage);
				return false;
			}
			

			if(System.DateTime.Compare(ToMMddYYYY(txtDateFrom.Text.Trim()), ToMMddYYYY(txtDateTo.Text.Trim())) > 0)
			{
				MessageBox.Show("Date From Should be less than Date To");
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// This method is used to view the report with the help of BindTheData() function and set the 
		/// column name and order format in session variable.
		/// </summary>
		private void btnView_Click(object sender, System.EventArgs e)
		{
			try
			{
                StringBuilder errorMessage = new StringBuilder();
                if (DropOption.SelectedIndex == 0)
                {
                    errorMessage.Append("Please Select Option");
                }
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());
                    return;
                }
				/*Hide By Mahesh 24.08.007 4:47PM
				if(!checkValidity()) 
				{
					return;
				}
				*/
				strOrderBy = "Fuel_Used_Qty ASC";
				Session["Column"] = "Fuel_Used_Qty";
				Session["Order"] = "ASC";
				BindTheData();
				//				SqlDataReader SqlDtr = null;
				//				dbobj.SelectQuery("Select *,(Meter_reading_Cur - Meter_Reading_Pre) as KM,((Meter_reading_Cur - Meter_Reading_Pre)/Fuel_Used_Qty) as Mileage from VDLB where vehicle_no = right('"+Dropvehicleno.SelectedItem.Text.Trim()+"',4) and cast(floor(cast(DOE as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and  cast(floor(cast(DOE as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim())+"'",ref SqlDtr);
				//				grdLog.DataSource = SqlDtr;
				//				grdLog.DataBind();
				//				if(grdLog.Items.Count==0)
				//				{
				//					MessageBox.Show("Data not available");
				//					grdLog.Visible=false;
				//				}
				//				else
				//				{
				//					grdLog.Visible=true;
				//				}
				//				SqlDtr.Close ();
				CreateLogFiles.ErrorLog("Form:vehicleLogReport.aspx,Method:btnView_Click ,  User "+ uid ); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:vehicleLogReport.aspx,Method:btnView_Click "+ " EXCEPTION  "+ex.Message+"  "+ uid ); 
			}			 
		}

		/// <summary>
		/// This method is used to bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["Epetro"]);
			string sqlstr="";
			if(DropOption.SelectedIndex==1)
				sqlstr="Select *,(Meter_reading_Cur - Meter_Reading_Pre) as KM,((Meter_reading_Cur - Meter_Reading_Pre)/Fuel_Used_Qty) as Mileage from VDLB where cast(floor(cast(DOE as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and  cast(floor(cast(DOE as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim())+"'";
			else
				sqlstr="Select *,(Meter_reading_Cur - Meter_Reading_Pre) as KM,((Meter_reading_Cur - Meter_Reading_Pre)/Fuel_Used_Qty) as Mileage from VDLB where vehicle_no = right('"+Dropvehicleno.SelectedItem.Text.Trim()+"',4) and cast(floor(cast(DOE as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and  cast(floor(cast(DOE as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim())+"'";
			DataSet ds= new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(sqlstr, SqlCon);
			da.Fill(ds, "VDLB");
			DataTable dtCustomers = ds.Tables["VDLB"];
			DataView dv=new DataView(dtCustomers);
			dv.Sort = strOrderBy;
			Cache["strOrderBy"]=strOrderBy;
			if(dv.Count!=0)
			{
				if(DropOption.SelectedIndex==1)
				{
					grdFright.DataSource = dv;
					grdFright.DataBind();
					grdFright.Visible=true;
					grdLog.Visible=false;
				}
				else
				{
					grdLog.DataSource = dv;
					grdLog.DataBind();
					grdLog.Visible=true;
					grdFright.Visible=false;
				}
			}
			else
			{
				MessageBox.Show("Data not available");
				grdLog.Visible=false;
				grdFright.Visible=false;
			}
			SqlCon.Dispose();
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnSortCommand"
		/// </summary>
		public void SortCommand_Click(object sender,DataGridSortCommandEventArgs e)
		{
			try
			{
				//Check to see if same column clicked again
				if(e.SortExpression.ToString().Equals(Session["Column"]))
				{
					if(Session["Order"].Equals("ASC"))
					{
						strOrderBy=e.SortExpression.ToString() +" DESC";
						Session["Order"]="DESC";
					}
					else
					{
						strOrderBy=e.SortExpression.ToString() +" ASC";
						Session["Order"]="ASC";
					}
				}
					//Different column selected, so default to ascending order
				else
				{
					strOrderBy = e.SortExpression.ToString() +" ASC";
					Session["Order"] = "ASC";
				}
				Session["Column"] = e.SortExpression.ToString();
				BindTheData();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method is used to prepare the report after that call the print() function for printing.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			// if f is true then call the print else return;
			makingReport();
			if(f)
				Print();
			else
				return;
		}

		/// <summary>
		/// This method is used to prepare the .txt report file.
		/// </summary>
		public void makingReport()
		{

			/*
													=====================================================
													Vehicle Log Book Report From mm/dd/yyyy To mm/dd/yyyy
													=====================================================
			Vehicle No. : MH 09 78787

			+------+-----------+------+-----+------+-----+-------+------+-----------------------------+--------+--------+------+-------+
			| Fuel |  Vehicle  |Engine|Gear |Grease|Brake|Coolent|Trans.|      Expenses (In Rs.)      |Opening |Closing |  KM. |       |
			|Inward|   Route   |Oil   |Oil  | Used |Oil  | Used  |Oil   |------+--------+------+------| Meter  | Meter  | Move |Mileage|
			|      |           |Used  |Used |      |Used |       |Used  | Toll | Police | Food | Misc.|Reading |Reading |      |       |
			+------+-----------+------+-----+------+-----+-------+------+------+--------+------+------+--------+--------+------+-------+
			 123456 ########### 123456 12345 123456 12345 1234567 123456 123456 12345678 123456 123456 12345678 12345678 123456 1234.00
			*/
			try
			{
				//if(!checkValidity()) 
				//{
				//	f = false; 
				//	return;
				//}
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\VehicleLogBookReport.txt";
				StreamWriter sw = new StreamWriter(path);
				SqlDataReader SqlDtr = null;
				SqlDataReader SqlDtr1 = null;
				sw.Write((char)27);
				sw.Write('O');
				sw.Write('P');
				sw.Write((char)15);
				// Condensed
				sw.Write((char)15);
				sw.WriteLine("");
				//**********
				string des="";
				if(DropOption.SelectedIndex==1)
					des="---------------------------------------------------------------------------------------------------------------------------";
				else
					des="----------------------------------------------------------------------------------------------------------------------------------------";
				string Address=GenUtil.GetAddress();
				string[] addr=Address.Split(new char[] {':'},Address.Length);
				sw.WriteLine(GenUtil.GetCenterAddr(addr[0],des.Length).ToUpper());
				sw.WriteLine(GenUtil.GetCenterAddr(addr[1]+addr[2],des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Tin No : "+addr[3],des.Length));
				sw.WriteLine(des);
				//**********
				sw.WriteLine(GenUtil.GetCenterAddr("============================================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Vehicle Report From "+txtDateFrom.Text.Trim()+" To "+txtDateTo.Text.Trim(),des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("============================================",des.Length));
				if(DropOption.SelectedIndex==1)
					sw.WriteLine("Select Option : "+DropOption.SelectedItem.Text);
				else
				{
					sw.WriteLine("Select Option : "+DropOption.SelectedItem.Text);
					sw.WriteLine("Vehicle No.   : "+Dropvehicleno.SelectedItem.Text.Substring(0,Dropvehicleno.SelectedItem.Text.IndexOf("VID")).Trim());
				}
				sw.WriteLine("");
				if(DropOption.SelectedIndex==1)
				{
					sw.WriteLine("+------+-----------------------+--------------+----------+--------+---------------+------+--------+--------+------+-------+");
					sw.WriteLine("|      |                       |              |          |        |               |Acknow|Opening |Closing |      |       |");
					sw.WriteLine("| Fuel |    Vehicle Route      |   Bilty No   |Bilty Date| Fright |   Consignee   |ledge-| Meter  | Meter  |  KM. |Mileage|");
					sw.WriteLine("|Inward|                       |              |          |        |     Name      |Ment  |Reading |Reading | Move |       |");
					sw.WriteLine("+------+-----------------------+--------------+----------+--------+---------------+------+--------+--------+------+-------+");
					//             123456 12345678901234567890123 12345678901234 1234567890 12345678 123456789012345 123456 12345678 12345678 123456 1234567
				}
				else
				{
					sw.WriteLine("+------+-----------------------+------+-----+------+-----+-------+------+-----------------------------+--------+--------+------+-------+");
					sw.WriteLine("|      |                       |Engine|Gear |Grease|Brake|Coolent|Trans.|      Expenses (In Rs.)      |Opening |Closing |      |       |");
					sw.WriteLine("| Fuel |    Vehicle Route      |Oil   |Oil  | Used |Oil  | Used  |Oil   |------+--------+------+------| Meter  | Meter  |  KM. |Mileage|");
					sw.WriteLine("|Inward|                       |Used  |Used |      |Used |       |Used  | Toll | Police | Food | Misc.|Reading |Reading | Move |       |");
					sw.WriteLine("+------+-----------------------+------+-----+------+-----+-------+------+------+--------+------+------+--------+--------+------+-------+");
				}
				//             123456 ########### 123456 12345 123456 12345 1234567 123456 123456 12345678 123456 123456 12345678 12345678 123456 1234.00
				//  0        1           2    3     4       5     6       7      8     9        10     11     12         13     14     15

				//info : to set string format.
				string info =" {0,6:f} {1,-23:S} {2,6:f} {3,5:f} {4,6:f} {5,5:f} {6,7:f} {7,6:f} {8,6:f} {9,8:f} {10,6:f} {11,6:f} {12,8:f} {13,8:f} {14,6:f} {15,7:f}";
				string info1 =" {0,6:f} {1,-23:S} {2,-14:f} {3,-10:f} {4,8:f} {5,-15:f} {6,6:f} {7,8:f} {8,8:f} {9,6:f} {10,7:f}";
				string route = "";
				if(DropOption.SelectedIndex==1)
					dbobj.SelectQuery("Select *,(Meter_reading_Cur - Meter_Reading_Pre) as KM,((Meter_reading_Cur - Meter_Reading_Pre)/Fuel_Used_Qty) as Mileage from VDLB where cast(floor(cast(DOE as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and  cast(floor(cast(DOE as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim())+"' order by "+Cache["strOrderBy"]+"",ref SqlDtr);
				else
					dbobj.SelectQuery("Select *,(Meter_reading_Cur - Meter_Reading_Pre) as KM,((Meter_reading_Cur - Meter_Reading_Pre)/Fuel_Used_Qty) as Mileage from VDLB where vehicle_no = right('"+Dropvehicleno.SelectedItem.Text.Trim()+"',4) and cast(floor(cast(DOE as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and  cast(floor(cast(DOE as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim())+"' order by "+Cache["strOrderBy"]+"",ref SqlDtr);
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						route = "";
						dbobj.SelectQuery("Select route_name from route where route_id ="+SqlDtr["Vehicle_Route"].ToString().Trim(),ref SqlDtr1);
						if(SqlDtr1.Read())
						{
							route = SqlDtr1.GetValue(0).ToString();  
						}
						SqlDtr1.Close();
						if(DropOption.SelectedIndex==1)
							sw.WriteLine(info1,SqlDtr["Fuel_Used_Qty"].ToString().Trim(),
								GenUtil.TrimLength(route,23),
								SqlDtr["BiltyNo"].ToString().Trim(),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["BiltyDate"].ToString().Trim())),
								SqlDtr["Fright"].ToString().Trim(),
								GenUtil.TrimLength(SqlDtr["Consignee"].ToString().Trim(),15),
								getAcknow(SqlDtr["Acknowledgement"].ToString().Trim()),
								SqlDtr["Meter_Reading_Pre"].ToString().Trim(),
								SqlDtr["Meter_Reading_Cur"].ToString().Trim(),
								SqlDtr["KM"].ToString().Trim(),
								GenUtil.strNumericFormat(SqlDtr["Mileage"].ToString().Trim()));
						else
							sw.WriteLine(info,SqlDtr["Fuel_Used_Qty"].ToString().Trim(),
								GenUtil.TrimLength(route,23),
								SqlDtr["Engine_Oil_Qty"].ToString().Trim(),
								SqlDtr["Gear_Oil_Qty"].ToString().Trim(),
								SqlDtr["Grease_Qty"].ToString().Trim(),
								SqlDtr["Brake_Oil_Qty"].ToString().Trim(),
								SqlDtr["Coolent_Qty"].ToString().Trim(),
								SqlDtr["Trans_Oil_Qty"].ToString().Trim(),
								SqlDtr["Toll"].ToString().Trim(),
								SqlDtr["Police"].ToString().Trim(),
								SqlDtr["Food"].ToString().Trim(),
								SqlDtr["Misc"].ToString().Trim(),
								SqlDtr["Meter_Reading_Pre"].ToString().Trim(),
								SqlDtr["Meter_Reading_Cur"].ToString().Trim(),
								SqlDtr["KM"].ToString().Trim(),
								GenUtil.strNumericFormat(SqlDtr["Mileage"].ToString().Trim()));
					}
				}
				else
				{
					MessageBox.Show("Data not available");
					SqlDtr.Close();
					sw.Close();
					f = false; 
					return;
				}
				SqlDtr.Close();
				if(DropOption.SelectedIndex==1)
					sw.WriteLine("+------+-----------------------+--------------+----------+--------+---------------+------+--------+--------+------+-------+");
				else
					sw.WriteLine("+------+-----------------------+------+-----+------+-----+-------+------+------+--------+------+------+--------+--------+------+-------+");
				// deselect Condensed
				//sw.Write((char)18);
				//sw.Write((char)12);
				sw.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:vehicleLogReport.aspx,Method:makingReport() "+ " EXCEPTION  "+ex.Message+"  "+ uid ); 
			}
		}

		/// <summary>
		/// This method is used to write into the excel report file to print.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\ePetro_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\ePetro_ExcelFile\VehicleLogReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader SqlDtr=null,SqlDtr1=null;
			sw.WriteLine("From Date\t"+txtDateFrom.Text);
			sw.WriteLine("To Date\t"+txtDateTo.Text);
			if(DropOption.SelectedIndex==1)
				sw.WriteLine("Select Option\t"+DropOption.SelectedItem.Text);
			else
			{
				sw.WriteLine("Select Option\t"+DropOption.SelectedItem.Text);
				sw.WriteLine("Vehicle No\t"+Dropvehicleno.SelectedItem.Text);
			}
			if(DropOption.SelectedIndex==1)
				sw.WriteLine("Fuel\tVehicle Route\tBilty No\tBilty Date\tFright\tConsignee Name\tAcknowledgement\tOpening Meter Reading\tClosing Meter Reading\tKM. Move\tMileage");
			else
				sw.WriteLine("Fuel\tVehicle Route\tEngine Oil Used\tgear Oil Used\tGrease Used\tBrake Oil Used\tCoolent Used\tTrans. Oil Used\tToll Tax\tPolice\tFood\tMisc.\tOpening Meter Reading\tClosing Meter Reading\tKM. Move\tMileage");
			string route = "";
			if(DropOption.SelectedIndex==1)
				dbobj.SelectQuery("Select *,(Meter_reading_Cur - Meter_Reading_Pre) as KM,((Meter_reading_Cur - Meter_Reading_Pre)/Fuel_Used_Qty) as Mileage from VDLB where cast(floor(cast(DOE as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and  cast(floor(cast(DOE as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim())+"' order by "+Cache["strOrderBy"]+"",ref SqlDtr);
			else
				dbobj.SelectQuery("Select *,(Meter_reading_Cur - Meter_Reading_Pre) as KM,((Meter_reading_Cur - Meter_Reading_Pre)/Fuel_Used_Qty) as Mileage from VDLB where vehicle_no = right('"+Dropvehicleno.SelectedItem.Text.Trim()+"',4) and cast(floor(cast(DOE as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim())+"' and  cast(floor(cast(DOE as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim())+"' order by "+Cache["strOrderBy"]+"",ref SqlDtr);
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					route = "";
					dbobj.SelectQuery("Select route_name from route where route_id ="+SqlDtr["Vehicle_Route"].ToString().Trim(),ref SqlDtr1);
					if(SqlDtr1.Read())
					{
						route = SqlDtr1.GetValue(0).ToString();  
					}
					SqlDtr1.Close();
					if(DropOption.SelectedIndex==1)
					{
						sw.WriteLine(SqlDtr["Fuel_Used_Qty"].ToString().Trim()+"\t"+
							route+"\t"+
							SqlDtr["BiltyNo"].ToString().Trim()+"\t"+
							GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["BiltyDate"].ToString().Trim()))+"\t"+
							SqlDtr["Fright"].ToString().Trim()+"\t"+
							SqlDtr["Consignee"].ToString().Trim()+"\t"+
							getAcknow(SqlDtr["Acknowledgement"].ToString().Trim())+"\t"+
							SqlDtr["Meter_Reading_Pre"].ToString().Trim()+"\t"+
							SqlDtr["Meter_Reading_Cur"].ToString().Trim()+"\t"+
							SqlDtr["KM"].ToString().Trim()+"\t"+
							GenUtil.strNumericFormat(SqlDtr["Mileage"].ToString().Trim()));
					}
					else
					{
						sw.WriteLine(SqlDtr["Fuel_Used_Qty"].ToString().Trim()+"\t"+
							route+"\t"+
							SqlDtr["Engine_Oil_Qty"].ToString().Trim()+"\t"+
							SqlDtr["Gear_Oil_Qty"].ToString().Trim()+"\t"+
							SqlDtr["Grease_Qty"].ToString().Trim()+"\t"+
							SqlDtr["Brake_Oil_Qty"].ToString().Trim()+"\t"+
							SqlDtr["Coolent_Qty"].ToString().Trim()+"\t"+
							SqlDtr["Trans_Oil_Qty"].ToString().Trim()+"\t"+
							SqlDtr["Toll"].ToString().Trim()+"\t"+
							SqlDtr["Police"].ToString().Trim()+"\t"+
							SqlDtr["Food"].ToString().Trim()+"\t"+
							SqlDtr["Misc"].ToString().Trim()+"\t"+
							SqlDtr["Meter_Reading_Pre"].ToString().Trim()+"\t"+
							SqlDtr["Meter_Reading_Cur"].ToString().Trim()+"\t"+
							SqlDtr["KM"].ToString().Trim()+"\t"+
							GenUtil.strNumericFormat(SqlDtr["Mileage"].ToString().Trim()));
					}
				}
			}
			SqlDtr.Close();
			SqlDtr1.Close();
			dbobj.Dispose();
			sw.Close();
		}
		
		/// <summary>
		/// This method is used to sends the text file to print server to print.
		/// </summary>
		public void Print()
		{
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{
				// Establish the remote endpoint for the socket.
				// The name of the
				// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,60000);

				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );

				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\VehicleLogBookReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					//CreateLogFiles.ErrorLog("Form:Vehiclereport.aspx,Method:print"+ "  Daily sales record  Printed   userid  "+uid);
					CreateLogFiles.ErrorLog("Form:Vehicle_report.aspx,Method:print"+ " Report Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());

					 
					CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:print"+ " EXCEPTION "  +ex.Message+"  userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to prepares the excel report file ClaimSheet.xls for printing.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(grdLog.Visible==true || grdFright.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method: btnExcel_Click, VehicleLog Report Convert Into Excel Format ,  userid  "+uid);
				}
				else
				{
					MessageBox.Show("Please Click the View Button First");
					return;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:btnExcel_Click   VehicleLog Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to hide or visible the penel.
		/// </summary>
		private void DropOption_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropOption.SelectedIndex!=0)
			{
				if(DropOption.SelectedIndex==1)
					PenOption.Visible=false;
				else
					PenOption.Visible=true;
			}
			else
				PenOption.Visible=false;
		}
	}
}