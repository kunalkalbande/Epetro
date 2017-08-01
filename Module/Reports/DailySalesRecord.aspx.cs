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
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using RMG;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EPetro.Module.Reports
{
	/// <summary>
	/// Summary description for DailySalesRecord.
	/// </summary>
	public class DailySalesRecord : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropMonth;
		protected System.Web.UI.WebControls.DropDownList DropProduct;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		string[,] tData;
		public string city="";
		public string dealer="";
		public string div_office="";
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Button PrintBtn;
		protected System.Web.UI.WebControls.DropDownList DropYear;
		public string dealership = "";

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
				string sql1="";
				SqlDataReader  SqlDtr;
				PetrolPumpClass obj1=new PetrolPumpClass();
				// Fetch Dealer name city and store in string , to access from .aspx page.
				sql1="select DealerName,City,Div_Office,DealerShip from Organisation";
				SqlDtr=obj1.GetRecordSet(sql1);
				if(SqlDtr.Read())
				{
					dealer = SqlDtr["DealerName"].ToString();
					city = SqlDtr["City"].ToString();
					div_office = SqlDtr["Div_Office"].ToString();
					div_office = div_office.ToUpper(); 
					dealership = SqlDtr["DealerShip"].ToString();
					dealership = dealership.ToUpper(); 
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:page_load"+ ex.Message+"EXCEPTION   "+uid);
				Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
				return;
			}
				
			if(!IsPostBack)
			{
				try
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="10";
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
					SqlDataReader  SqlDtr;
					DropMonth.SelectedIndex=DateTime.Now.Month;
					Session["selmonth"]=DateTime.Now.Month;
					/**01**/ 
					DropYear.SelectedIndex=DropYear.Items.IndexOf(DropYear.Items.FindByValue((DateTime.Now.Year).ToString()));
					Session["selyear"]=DateTime.Now.Year;
					/**01**/ 
					PetrolPumpClass obj=new PetrolPumpClass();
					string sql;

					#region Fetch Product Name
					sql="select Prod_Name from products where Category='Fuel' order by Prod_Name";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropProduct.Items.Add(SqlDtr["Prod_Name"].ToString());
					}
					SqlDtr.Close();
					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:page_load. EXCEPTION:"+ ex.Message+"   "+uid);
				}
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
			this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to Returns date in MM/DD/YYYY format.
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

		public void Write2File1(StreamWriter sw, string info)
		{
			sw.WriteLine(info);
		}
		
		/// <summary>
		/// This method is used to returns the string array.
		/// </summary>
		public string[,] GetData1()
		{
			try
			{
				string sql="";
				string ID="";
				string[] arr=DropProduct.SelectedItem.Text.Split(new char[]{':'},DropProduct.SelectedItem.Text.Length);  
				if(DropProduct.SelectedIndex>0 )
				{
					sql="select Prod_ID from Products where Prod_Name='"+arr[0]+"'";// and Pack_Type='"+arr[1]+"'";
					dbobj.SelectQuery(sql,"Prod_ID",ref ID);
			
				}
				PetrolPumpClass obj=new PetrolPumpClass();
				SqlDataReader SqlDtr;
				string Prod_ID=ID;
				int month=DropMonth.SelectedIndex;
				/**02**/
				int year = DropYear.SelectedIndex;
				//**int Days_in_Months=DateTime.DaysInMonth(DateTime.Now.Year,month);
				int Days_in_Months=DateTime.DaysInMonth(year,month);
				/**02**/
				tData=new string[Days_in_Months,27]; 
			
				string[] str0 = new string[500000];
				string[] str1 = new string[500000];
				string[] str2 = new string[500000];
				string[] str3 = new string[500000];
				string[] str4 = new string[500000];
				string[] str5 = new string[500000];
				string[] str6 = new string[500000];
				string[] str7 = new string[500000];
				string[] str8 = new string[500000];
				string[] str9 = new string[500000];
				int p=0;
				#region Initialize Array tData
				for(int j=0;j<tData.GetLength(0);j++)
				{
					for(int i=0;i<tData.GetLength(1);i++)
					{
						tData[j,i]="";
					}
				}
				#endregion

				int len = tData.GetLength(0);
				int len1 = tData.GetLength(1);
				float CommTotal=0;
				for(int i=0;i<tData.GetLength(0);i++)
				{
					//string eDate=(i+1)+"/"+month.ToString()+"/"+DateTime.Now.Year.ToString(); 
					string eDate=(i+1)+"/"+month.ToString()+"/"+DropYear.SelectedItem.Text.Trim().ToString(); 
					tData[i,0]=eDate;

					#region Fetch Tank Dip and Water Dip
					sql = "select d.Entry_Date,d.Tank_Dip,d.Water_Dip,d.Testing from daily_Tank_Reading d,Tank t where d.Entry_Date='"+ToMMddYYYY(eDate).ToShortDateString()+"' and d.Tank_ID=t.Tank_ID and t.Prod_Name =(Select Prod_Name from Products where Prod_ID ='"+Prod_ID+"')  order by d.Tank_ID ";
					SqlDtr=obj.GetRecordSet(sql); 
					int temp=0;
					while(SqlDtr.Read())
					{   
						try
						{
							str0[p]=eDate;  
							tData[i,temp+1]=GenUtil.strNumericFormat(SqlDtr["Tank_Dip"].ToString());
							tData[i,temp+2]=SqlDtr["Water_Dip"].ToString();

							str1[p]=GenUtil.strNumericFormat(SqlDtr["Tank_Dip"].ToString());
							str2[p]=SqlDtr["Water_Dip"].ToString();

							if(tData[i,20].Equals(""))
							{
								tData[i,20]=SqlDtr["Testing"].ToString();
								str3[p]=SqlDtr["Testing"].ToString();
							}
							else
								tData[i,20]=(float.Parse(tData[i,20])+float.Parse(SqlDtr["Testing"].ToString())).ToString();
							temp+=2;
						}
						catch(Exception  ex)
						
						{
							CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:GetData"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
						}
					}
					SqlDtr.Close();
					#endregion

					#region Fetch Stock Data
					sql="select Stock_Date,Opening_Stock,Receipt,cast(Opening_Stock as numeric)+cast(Receipt as numeric) as Total,Sales from Stock_Master where ProductID='"+Prod_ID+"' and datepart(mm,Stock_Date)='"+month+"' and datepart(dd,Stock_Date)='"+(i+1)+"' and datepart(yy,Stock_Date)='"+DateTime.Now.Year+"'";
					SqlDtr=obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						try
						{
							tData[i,13]=SqlDtr["Opening_Stock"].ToString();
							tData[i,14]=SqlDtr["Receipt"].ToString();
							tData[i,15]=SqlDtr["Total"].ToString();
							tData[i,21]=SqlDtr["Sales"].ToString();

							str4[p]=SqlDtr["Opening_Stock"].ToString();
							str5[p]=SqlDtr["Receipt"].ToString();
							str6[p]=SqlDtr["Total"].ToString();
							str7[p]=SqlDtr["Sales"].ToString();
						

							if(tData[i,20]=="")
								tData[i,20]="0";
							CommTotal+=(float.Parse(tData[i,20])+float.Parse(tData[i,21]));
							tData[i,22]=CommTotal.ToString();
							//tData[i,22]=(float.Parse(tData[i,20])+float.Parse(tData[i,21])).ToString();
							str8[p]=(float.Parse(tData[i,20])+float.Parse(tData[i,21])).ToString();
							p++;

						}
						catch(Exception ex)
						{
							CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Getdata"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
						}
					}
					SqlDtr.Close();
					#endregion

					#region Fetch Meter Reading
					sql="select d.Entry_Date,d.Nozzle_ID,d.Reading from daily_meter_reading d,Nozzle n,Tank t where d.Entry_Date='"+ToMMddYYYY(eDate).ToShortDateString()+"' and d.Nozzle_ID = n.Nozzle_ID and n.Tank_ID = t.Tank_ID and t.Prod_Name =(Select Prod_Name from Products where Prod_ID = '"+Prod_ID+"')  order by cast(d.Nozzle_ID as numeric)";
					SqlDtr=obj.GetRecordSet(sql); 
					temp=0;
					while(SqlDtr.Read())
					{
						try
						{
							if(temp<4)
								tData[i,temp+16]=SqlDtr["Reading"].ToString();
							str9[p]=SqlDtr["Reading"].ToString();
							temp++;
						
						}
						catch(Exception ex)
						{
							CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Getdata"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
						}
					}

					SqlDtr.Close();
					#endregion

					#region Fetch Total Sales of Engine Oil and Gear Oil
					if(DropProduct.SelectedIndex > 0)
					{
						sql="select Prod_ID,Unit from products where Category = 'Engine Oil' or Category = 'Gear Oil' ";
				
						SqlDtr=obj.GetRecordSet(sql); 
						PetrolPumpClass obj1=new PetrolPumpClass();
						SqlDataReader SqlDtr1 = null; 
						string unit = "";
						string Prod_ID1 = "";
						double loose = 0;
						double packed =0;
						while(SqlDtr.Read())
						{
							try
							{
								unit = SqlDtr["Unit"].ToString();
								Prod_ID1 = SqlDtr["Prod_ID"].ToString();
								if(unit.Trim().IndexOf("Loose") != -1)
								{
									SqlDtr1 = obj1.GetRecordSet("select sales from stock_master where cast(floor(cast(stock_date as float)) as datetime) ='"+ToMMddYYYY(eDate).ToShortDateString()+"' and Productid = '"+Prod_ID1+"'");
									if(SqlDtr1.Read())
									{
										loose = loose + System.Convert.ToDouble(SqlDtr1["sales"].ToString()); 
										if(loose == 0)
											tData[i,24] = "";
										else
											tData[i,24] = loose.ToString();
									}
									SqlDtr1.Close();
							

								}
								else
								{
									SqlDtr1 = obj1.GetRecordSet("select sales from stock_master where cast(floor(cast(stock_date as float)) as datetime) ='"+ToMMddYYYY(eDate).ToShortDateString()+"' and Productid = '"+Prod_ID1+"'");
									if(SqlDtr1.Read())
									{
										packed = packed + System.Convert.ToDouble(SqlDtr1["sales"].ToString()); 
										if(packed == 0)
											tData[i,23] = "";
										else
											tData[i,23] = packed.ToString();
									}
									SqlDtr1.Close();
								}
						
							}
							catch(Exception ex)
							{
								CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Getdata"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
							}
						}


						SqlDtr.Close();
					}
					#endregion

					#region Fetch Total Sales of 2T and 4T
					if(DropProduct.SelectedIndex > 0)
					{
						sql="select Prod_ID,Unit from products where Category = '2T' or Category = '4T' ";
				
						SqlDtr=obj.GetRecordSet(sql); 
						PetrolPumpClass obj1=new PetrolPumpClass();
						SqlDataReader SqlDtr1 = null; 
						string unit = "";
						string Prod_ID1 = "";
						double loose1 = 0;
						double packed1 =0;
						while(SqlDtr.Read())
						{
							try
							{
								unit = SqlDtr["Unit"].ToString();
								Prod_ID1 = SqlDtr["Prod_ID"].ToString();
								if(unit.Trim().IndexOf("Loose") != -1)
								{
									SqlDtr1 = obj1.GetRecordSet("select sales from stock_master where cast(floor(cast(stock_date as float)) as datetime) ='"+ToMMddYYYY(eDate).ToShortDateString()+"' and Productid = '"+Prod_ID1+"'");
									if(SqlDtr1.Read())
									{
										loose1 = loose1 + System.Convert.ToDouble(SqlDtr1["sales"].ToString()); 
										if(loose1 == 0)
											tData[i,26] = "";
										else
											tData[i,26] = loose1.ToString();
									}
									SqlDtr1.Close();
							

								}
								else
								{
									SqlDtr1 = obj1.GetRecordSet("select sales from stock_master where cast(floor(cast(stock_date as float)) as datetime) ='"+ToMMddYYYY(eDate).ToShortDateString()+"' and Productid = '"+Prod_ID1+"'");
									if(SqlDtr1.Read())
									{
										packed1 = packed1 + System.Convert.ToDouble(SqlDtr1["sales"].ToString()); 
										if(packed1 == 0)
											tData[i,25] = "";
										else
											tData[i,25] = packed1.ToString();
									}
									SqlDtr1.Close();
								}
						
							}
							catch(Exception ex)
							{
								CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Getdata"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
							}
						}


						SqlDtr.Close();
					}
					#endregion

				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:GetData1(). EXCEPTION:"+ ex.Message+"   "+uid);
			}
			return tData;
		}
	
		/// <summary>
		/// This method is used to also returns the string array.
		/// </summary>
		public string[,] GetData()
		{
			try
			{
				string sql="";
				string ID="";
				string[] arr=DropProduct.SelectedItem.Text.Split(new char[]{':'},DropProduct.SelectedItem.Text.Length);  
				if(DropProduct.SelectedIndex>0 )
				{
					sql="select Prod_ID from Products where Prod_Name='"+arr[0]+"'";// and Pack_Type='"+arr[1]+"'";
					dbobj.SelectQuery(sql,"Prod_ID",ref ID);
				}
				PetrolPumpClass obj=new PetrolPumpClass();
				SqlDataReader SqlDtr;
				string Prod_ID=ID;
				int month=DropMonth.SelectedIndex;
				/**02**/
				int year = 2017;
				//**int Days_in_Months=DateTime.DaysInMonth(DateTime.Now.Year,month);
				int Days_in_Months=DateTime.DaysInMonth(year,month);
				/**02**/
				tData=new string[Days_in_Months,27]; 
            
				string[] str0 = new string[500000];
				string[] str1 = new string[500000];
				string[] str2 = new string[500000];
				string[] str3 = new string[500000];
				string[] str4 = new string[500000];
				string[] str5 = new string[500000];
				string[] str6 = new string[500000];
				string[] str7 = new string[500000];
				string[] str8 = new string[500000];
				string[] str9 = new string[500000];
				int p=0;
				#region Initialize Array tData
				for(int j=0;j<tData.GetLength(0);j++)
				{
					for(int i=0;i<tData.GetLength(1);i++)
					{
						tData[j,i]="";
					}
				}
				#endregion

				int len = tData.GetLength(0);
				int len1 = tData.GetLength(1);
				float CommTotal=0;
				for(int i=0;i<tData.GetLength(0);i++)
				{
					//**string eDate=(i+1)+"/"+month.ToString()+"/"+DateTime.Now.Year.ToString(); 
					string eDate=(i+1)+"/"+month.ToString()+"/"+DropYear.SelectedValue.ToString(); 
					tData[i,0]=eDate;

					#region Fetch Tank Dip and Water Dip
					sql = "select d.Entry_Date,d.Tank_Dip,d.Water_Dip,d.Testing from daily_Tank_Reading d,Tank t where d.Entry_Date='"+GenUtil.str2MMDDYYYY(eDate)+"' and d.Tank_ID=t.Tank_ID and t.Prod_Name =(Select Prod_Name from Products where Prod_ID ='"+Prod_ID+"')  order by d.Tank_ID ";
					SqlDtr=obj.GetRecordSet(sql); 
					int temp=0;
					while(SqlDtr.Read())
					{   
						try
						{
							str0[p]=eDate;  
							tData[i,temp+1]=GenUtil.strNumericFormat(SqlDtr["Tank_Dip"].ToString());
							tData[i,temp+2]=SqlDtr["Water_Dip"].ToString();

							str1[p]=GenUtil.strNumericFormat(SqlDtr["Tank_Dip"].ToString());
							str2[p]=SqlDtr["Water_Dip"].ToString();

							if(tData[i,20].Equals(""))
							{
								tData[i,20]=SqlDtr["Testing"].ToString();
								str3[p]=SqlDtr["Testing"].ToString();
							}
							else
								tData[i,20]=(float.Parse(tData[i,20])+float.Parse(SqlDtr["Testing"].ToString())).ToString();
							temp+=2;
						}
						catch(Exception  ex)
						
						{
							CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:GetData"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
						}
					}
					SqlDtr.Close();
					#endregion

					#region Fetch Stock Data
					sql="select Stock_Date,Opening_Stock,Receipt,cast(Opening_Stock as numeric)+cast(Receipt as numeric) as Total,Sales from Stock_Master where ProductID='"+Prod_ID+"' and datepart(mm,Stock_Date)='"+month+"' and datepart(dd,Stock_Date)='"+(i+1)+"' and datepart(yy,Stock_Date)='"+DateTime.Now.Year+"'";
					SqlDtr=obj.GetRecordSet(sql);
					
					while(SqlDtr.Read())
					{
						try
						{
							tData[i,13]=SqlDtr["Opening_Stock"].ToString();
							tData[i,14]=SqlDtr["Receipt"].ToString();
							tData[i,15]=SqlDtr["Total"].ToString();
							tData[i,21]=SqlDtr["Sales"].ToString();

							str4[p]=SqlDtr["Opening_Stock"].ToString();
							str5[p]=SqlDtr["Receipt"].ToString();
							str6[p]=SqlDtr["Total"].ToString();
							str7[p]=SqlDtr["Sales"].ToString();
						

							if(tData[i,20]=="")
								tData[i,20]="0";
							CommTotal+=(float.Parse(tData[i,20])+float.Parse(tData[i,21]));
							tData[i,22]=CommTotal.ToString();
							//string ss=tData[i,22].ToString();
							//tData[i,22]=(float.Parse(tData[i,20])+float.Parse(tData[i,21])).ToString();
							str8[p]=(float.Parse(tData[i,20])+float.Parse(tData[i,21])).ToString();
							p++;

						}
						catch(Exception ex)
						{
							CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Getdata"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
						}
					}
					SqlDtr.Close();
					#endregion

					#region Fetch Meter Reading
					sql="select d.Entry_Date,d.Nozzle_ID,d.Reading from daily_meter_reading d,Nozzle n,Tank t where d.Entry_Date='"+ GenUtil.str2MMDDYYYY(eDate)+"' and d.Nozzle_ID = n.Nozzle_ID and n.Tank_ID = t.Tank_ID and t.Prod_Name =(Select Prod_Name from Products where Prod_ID = '"+Prod_ID+"')  order by cast(d.Nozzle_ID as numeric)";
					SqlDtr=obj.GetRecordSet(sql); 
					temp=0;
					while(SqlDtr.Read())
					{
						try
						{
							if(temp<4)
								tData[i,temp+16]=SqlDtr["Reading"].ToString();
							str9[p]=SqlDtr["Reading"].ToString();
							temp++;
						
						}
						catch(Exception ex)
						{
							CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Getdata"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
						}
					}

					SqlDtr.Close();
					#endregion
					#region Fetch Total Sales of Engine Oil and Gear Oil
					if(DropProduct.SelectedIndex > 0)
					{
						sql="select Prod_ID,Unit from products where Category = 'Engine Oil' or Category = 'Gear Oil' ";
				
						SqlDtr=obj.GetRecordSet(sql); 
						PetrolPumpClass obj1=new PetrolPumpClass();
						SqlDataReader SqlDtr1 = null; 
						string unit = "";
						string Prod_ID1 = "";
						double loose = 0;
						double packed =0;
						while(SqlDtr.Read())
						{
							try
							{
								unit = SqlDtr["Unit"].ToString();
								Prod_ID1 = SqlDtr["Prod_ID"].ToString();
								if(unit.Trim().IndexOf("Loose") != -1)
								{
									SqlDtr1 = obj1.GetRecordSet("select sales from stock_master where cast(floor(cast(stock_date as float)) as datetime) ='"+ GenUtil.str2MMDDYYYY(eDate)+"' and Productid = '"+Prod_ID1+"'");
									if(SqlDtr1.Read())
									{
										loose = loose + System.Convert.ToDouble(SqlDtr1["sales"].ToString()); 
										if(loose == 0)
											tData[i,24] = "";
										else
											tData[i,24] = loose.ToString();
									}
									SqlDtr1.Close();
							

								}
								else
								{
									SqlDtr1 = obj1.GetRecordSet("select sales from stock_master where cast(floor(cast(stock_date as float)) as datetime) ='"+ GenUtil.str2MMDDYYYY(eDate)+"' and Productid = '"+Prod_ID1+"'");
									if(SqlDtr1.Read())
									{
										packed = packed + System.Convert.ToDouble(SqlDtr1["sales"].ToString()); 
										if(packed == 0)
											tData[i,23] = "";
										else
											tData[i,23] = packed.ToString();
									}
									SqlDtr1.Close();
								}
						
							}
							catch(Exception ex)
							{
								CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Getdata"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
							}
						}


						SqlDtr.Close();
					}
					#endregion

					#region Fetch Total Sales of 2T and 4T
					if(DropProduct.SelectedIndex > 0)
					{
						sql="select Prod_ID,Unit from products where Category = '2T' or Category = '4T' ";
				
						SqlDtr=obj.GetRecordSet(sql); 
						PetrolPumpClass obj1=new PetrolPumpClass();
						SqlDataReader SqlDtr1 = null; 
						string unit = "";
						string Prod_ID1 = "";
						double loose1 = 0;
						double packed1 =0;
						while(SqlDtr.Read())
						{
							try
							{
								unit = SqlDtr["Unit"].ToString();
								Prod_ID1 = SqlDtr["Prod_ID"].ToString();
								if(unit.Trim().IndexOf("Loose") != -1)
								{
									SqlDtr1 = obj1.GetRecordSet("select sales from stock_master where cast(floor(cast(stock_date as float)) as datetime) ='"+ GenUtil.str2MMDDYYYY(eDate)+"' and Productid = '"+Prod_ID1+"'");
									if(SqlDtr1.Read())
									{
										loose1 = loose1 + System.Convert.ToDouble(SqlDtr1["sales"].ToString()); 
										if(loose1 == 0)
											tData[i,26] = "";
										else
											tData[i,26] = loose1.ToString();
									}
									SqlDtr1.Close();
							

								}
								else
								{
									SqlDtr1 = obj1.GetRecordSet("select sales from stock_master where cast(floor(cast(stock_date as float)) as datetime) ='"+ GenUtil.str2MMDDYYYY(eDate)+"' and Productid = '"+Prod_ID1+"'");
									if(SqlDtr1.Read())
									{
										packed1 = packed1 + System.Convert.ToDouble(SqlDtr1["sales"].ToString()); 
										if(packed1 == 0)
											tData[i,25] = "";
										else
											tData[i,25] = packed1.ToString();
									}
									SqlDtr1.Close();
								}
						
							}
							catch(Exception ex)
							{
								CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Getdata"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
							}
						}


						SqlDtr.Close();
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:GetData(). EXCEPTION:"+ ex.Message+"   "+uid);
			}
			return tData;
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
					CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\DailySalesReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:print"+ "  Daily sales record  Printed   userid  "+uid);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:print"+ "EXCEPTION"  +ane.Message+"  userid  "+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:print"+ "EXCEPTION"  +se.Message+"  userid  "+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:print"+ "EXCEPTION"  +es.Message+"  userid  "+uid);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:print"+ "EXCEPTION"  +ex.Message+"  userid  "+uid);
				//				Err.ErrorLog(Server.MapPath("Logs/ErrorLog"),"Form:Payment_Receipt.aspx,Class:InventoyClass.cs " + ex.Message);
				//				
			}
		}

		/// <summary>
		/// This method is not used
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropMonth.SelectedIndex==0)
				{
					MessageBox.Show("Please select the correct Month");
					DropMonth.SelectedIndex=(int)Session["selmonth"];
					return;
				}
				// Put the selected value of the month into session. 
				Session["selmonth"]=DropMonth.SelectedIndex;
				GetData();
				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Button1_Click"+"  Daily Sales Record Viewed  "+ " userid "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:Button1_Click"+"  Daily Sales Record Viewed  "+"  EXCEPTION   "+ ex.Message+" userid  "+uid);
			}
		}

		//		private void PrintBtn_Click(object sender, System.EventArgs e)//previous report
		//		{
		//			try
		//			{
		//				Session["Data"] = GetData1();
		//				Session["Product"] = DropProduct.SelectedItem.Text;
		//				Session["Month"] = DropMonth.SelectedItem.Text;
		//				//***
		//				Session["Year"] = DropYear.SelectedItem.Text;
		//				//***
		//				Session["Dealer"] = dealer;
		//				Session["Location"] = city; 
		//				Session["DealerShip"] = dealership;
		//				Session["Div_Office"] = div_office; 
		//				Response.Redirect("DailySalesRecord_PrintPreview.aspx",false); 
		//
		////			// Code to create the txt file to print.
		////				string home_drive = Environment.SystemDirectory;
		////				home_drive = home_drive.Substring(0,2); 
		////				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\DailySalesReport.txt";
		////				StreamWriter sw = new StreamWriter(path);
		////				string info = "";
		////
		////				/*
		////																																											   ==================      
		////																																											   DAILY SALES REPORT     
		////																																											   ==================      
		////						Dealer Name :
		////						Location    :
		////						+----------+-------------------+-------------------+-------------------+-------------------+----------+----------+----------+-------------------------------------------+-----------+----------+---------------------+---------------------+
		////						|          |                   |                   |                   |                   |          |          |          |           Opening Meter Reading           |           |          |Total Engine & Gear  |   Total 2T/4T Oil   |
		////						|   Date   |       Tank1       |       Tank2       |       Tank3       |       Tank4       | Opening  | Receipt  |  Total   |                                           |  Testing  |  Cumm.   |    Oil Sales        |                     |
		////						|          +---------+---------+---------+---------+---------+---------+---------+---------+  Stock   |          |  Stock   |----------+--------Pumps--------+----------+           |  Sales   +----------+----------+----------+----------+
		////						|          |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |          |          |          |     1    |     2    |     3    |     4    |           |          |  Packed  |  Loose   |  Packed  |  Loose   |
		////						+----------+---------+---------+---------+---------+---------+---------+---------+---------+----------+----------+----------+----------+----------+----------+----------+-----------+----------+----------+----------+----------+----------+
		////						 29/03/2006 123456.00 123456.00 123456.00 123456.00 123456.00 123456.00 123456.00 123456.00 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 01234567890 1234567890 1234567890 1234567890 1234567890 1234567890  
		////						*/
		////				sw.WriteLine("                                                                                                                                                       ==================");
		////				sw.WriteLine("                                                                                                                                                       DAILY SALES REPORT");
		////				sw.WriteLine("                                                                                                                                                       ==================");
		////				sw.WriteLine("Dealer Name : "+dealer);
		////				sw.WriteLine("Location    : "+city);
		////				sw.WriteLine("Product     : "+DropProduct.SelectedItem.Text.ToString());
		////				sw.WriteLine("Month       : "+DropMonth.SelectedItem.Text.ToString());
		////				/*
		////				sw.WriteLine("+----------+-------------------+-------------------+-------------------+-------------------+----------+----------+----------+-------------------------------------------+-----------+----------+---------------------+---------------------+");
		////				sw.WriteLine("|          |                   |                   |                   |                   |          |          |          |           Opening Meter Reading           |           |          |Total Engine & Gear  |   Total 2T/4T Oil   |");
		////				sw.WriteLine("|   Date   |       Tank1       |       Tank2       |       Tank3       |       Tank4       | Opening  | Receipt  |  Total   |                                           |  Testing  |  Cumm.   |    Oil Sales        |                     |");
		////				sw.WriteLine("|          +---------+---------+---------+---------+---------+---------+---------+---------+  Stock   |          |  Stock   |----------+--------Pumps--------+----------+           |  Sales   +----------+----------+----------+----------+");
		////				sw.WriteLine("|          |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |          |          |          |     1    |     2    |     3    |     4    |           |          |  Packed  |  Loose   |  Packed  |  Loose   |");
		////				sw.WriteLine("+----------+---------+---------+---------+---------+---------+---------+---------+---------+----------+----------+----------+----------+----------+----------+----------+-----------+----------+----------+----------+----------+----------+");
		////				*/
		////				sw.WriteLine("+----------+-------------------+-------------------+-------------------+-------------------+----------+----------+----------+-------------------------------------------+-----------+----------+----------+---------------------+---------------------+");
		////				sw.WriteLine("|          |                   |                   |                   |                   |          |          |          |           Opening Meter Reading           |           |          |          |Total Engine & Gear  |   Total 2T/4T Oil   |");
		////				sw.WriteLine("|   Date   |       Tank1       |       Tank2       |       Tank3       |       Tank4       | Opening  | Receipt  |  Total   |                                           |  Testing  |  Sales   |  Cumm.   |    Oil Sales        |                     |");
		////				sw.WriteLine("|          +---------+---------+---------+---------+---------+---------+---------+---------+  Stock   |          |  Stock   |----------+--------Pumps--------+----------+           |          |  Sales   +----------+----------+----------+----------+");
		////				sw.WriteLine("|          |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |          |          |          |     1    |     2    |     3    |     4    |           |          |          |  Packed  |  Loose   |  Packed  |  Loose   |");
		////				sw.WriteLine("+----------+---------+---------+---------+---------+---------+---------+---------+---------+----------+----------+----------+----------+----------+----------+----------+-----------+----------+----------+----------+----------+----------+----------+");
		////
		////				info = " {0,-10:S} {1,9:F} {2,9:F} {3,9:F} {4,9:F} {5,9:F} {6,9:F} {7,9:F} {8,9:F} {9,10:F} {10,10:F} {11,10:F} {12,10:F} {13,10:F} {14,10:F} {15,10:F} {16,10:F} {17,10:F} {18,10:F} {19,10:F} {20,10:F} {21,10:F} {22,10:F}";
		////
		////				int len2 = tData1.GetLength(0);
		////				
		////				for (int kk=0;kk<tData1.GetLength(0);kk++)
		////				{   
		////					
		////					sw.WriteLine(info,tData1[kk,0],
		////						tData1[kk,1],tData1[kk,2],tData1[kk,3],tData1[kk,4],
		////						tData1[kk,5],tData1[kk,6],tData1[kk,7],tData1[kk,8],
		////						tData1[kk,13],tData1[kk,14],tData1[kk,15],tData1[kk,16],tData1[kk,17],
		////						tData1[kk,18],tData1[kk,19],tData1[kk,20],tData1[kk,21],tData1[kk,22],
		////						tData1[kk,23],tData1[kk,24],tData1[kk,25],tData1[kk,26]
		////						);
		////				}
		////				
		////				sw.WriteLine("+----------+---------+---------+---------+---------+---------+---------+---------+---------+----------+----------+----------+----------+----------+----------+----------+-----------+----------+----------+----------+----------+----------+----------+");
		////
		////				sw.Close();
		////				Print();
		////				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:PrintBtn_Click"+ "  Daily Sales Record Printed  "+ " userid " +uid);
		//
		//			}
		//			catch(Exception ex)
		//			{
		//					CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:PrintBtn_Click"+"  Daily Sales Recored Printed  "+ ex.Message+"  EXCEPTION   "+"  userid  "+uid);
		//
		//			}
		//		}

		/// <summary>
		/// This method is used to Prepares the report file DailySalesRecord.txt for printing.
		/// </summary>
		private void PrintBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				Session["Data"] = GetData1();
				Session["Product"] = DropProduct.SelectedItem.Text;
				Session["Month"] = DropMonth.SelectedItem.Text;
				//***
				Session["Year"] = DropYear.SelectedItem.Text;
				//***
				Session["Dealer"] = dealer;
				Session["Location"] = city; 
				Session["DealerShip"] = dealership;
				Session["Div_Office"] = div_office; 
				Response.Redirect("DailySalesRecord_PrintPreview.aspx",false); 

				//			// Code to create the txt file to print.
				//				string home_drive = Environment.SystemDirectory;
				//				home_drive = home_drive.Substring(0,2); 
				//				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\DailySalesReport.txt";
				//				StreamWriter sw = new StreamWriter(path);
				//				string info = "";
				//
				//				/*
				//																																											   ==================      
				//																																											   DAILY SALES REPORT     
				//																																											   ==================      
				//						Dealer Name :
				//						Location    :
				//						+----------+-------------------+-------------------+-------------------+-------------------+----------+----------+----------+-------------------------------------------+-----------+----------+---------------------+---------------------+
				//						|          |                   |                   |                   |                   |          |          |          |           Opening Meter Reading           |           |          |Total Engine & Gear  |   Total 2T/4T Oil   |
				//						|   Date   |       Tank1       |       Tank2       |       Tank3       |       Tank4       | Opening  | Receipt  |  Total   |                                           |  Testing  |  Cumm.   |    Oil Sales        |                     |
				//						|          +---------+---------+---------+---------+---------+---------+---------+---------+  Stock   |          |  Stock   |----------+--------Pumps--------+----------+           |  Sales   +----------+----------+----------+----------+
				//						|          |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |          |          |          |     1    |     2    |     3    |     4    |           |          |  Packed  |  Loose   |  Packed  |  Loose   |
				//						+----------+---------+---------+---------+---------+---------+---------+---------+---------+----------+----------+----------+----------+----------+----------+----------+-----------+----------+----------+----------+----------+----------+
				//						 29/03/2006 123456.00 123456.00 123456.00 123456.00 123456.00 123456.00 123456.00 123456.00 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 01234567890 1234567890 1234567890 1234567890 1234567890 1234567890  
				//						*/
				//				sw.WriteLine("                                                                                                                                                       ==================");
				//				sw.WriteLine("                                                                                                                                                       DAILY SALES REPORT");
				//				sw.WriteLine("                                                                                                                                                       ==================");
				//				sw.WriteLine("Dealer Name : "+dealer);
				//				sw.WriteLine("Location    : "+city);
				//				sw.WriteLine("Product     : "+DropProduct.SelectedItem.Text.ToString());
				//				sw.WriteLine("Month       : "+DropMonth.SelectedItem.Text.ToString());
				//				/*
				//				sw.WriteLine("+----------+-------------------+-------------------+-------------------+-------------------+----------+----------+----------+-------------------------------------------+-----------+----------+---------------------+---------------------+");
				//				sw.WriteLine("|          |                   |                   |                   |                   |          |          |          |           Opening Meter Reading           |           |          |Total Engine & Gear  |   Total 2T/4T Oil   |");
				//				sw.WriteLine("|   Date   |       Tank1       |       Tank2       |       Tank3       |       Tank4       | Opening  | Receipt  |  Total   |                                           |  Testing  |  Cumm.   |    Oil Sales        |                     |");
				//				sw.WriteLine("|          +---------+---------+---------+---------+---------+---------+---------+---------+  Stock   |          |  Stock   |----------+--------Pumps--------+----------+           |  Sales   +----------+----------+----------+----------+");
				//				sw.WriteLine("|          |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |          |          |          |     1    |     2    |     3    |     4    |           |          |  Packed  |  Loose   |  Packed  |  Loose   |");
				//				sw.WriteLine("+----------+---------+---------+---------+---------+---------+---------+---------+---------+----------+----------+----------+----------+----------+----------+----------+-----------+----------+----------+----------+----------+----------+");
				//				*/
				//				sw.WriteLine("+----------+-------------------+-------------------+-------------------+-------------------+----------+----------+----------+-------------------------------------------+-----------+----------+----------+---------------------+---------------------+");
				//				sw.WriteLine("|          |                   |                   |                   |                   |          |          |          |           Opening Meter Reading           |           |          |          |Total Engine & Gear  |   Total 2T/4T Oil   |");
				//				sw.WriteLine("|   Date   |       Tank1       |       Tank2       |       Tank3       |       Tank4       | Opening  | Receipt  |  Total   |                                           |  Testing  |  Sales   |  Cumm.   |    Oil Sales        |                     |");
				//				sw.WriteLine("|          +---------+---------+---------+---------+---------+---------+---------+---------+  Stock   |          |  Stock   |----------+--------Pumps--------+----------+           |          |  Sales   +----------+----------+----------+----------+");
				//				sw.WriteLine("|          |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |   Dip   |  Water  |          |          |          |     1    |     2    |     3    |     4    |           |          |          |  Packed  |  Loose   |  Packed  |  Loose   |");
				//				sw.WriteLine("+----------+---------+---------+---------+---------+---------+---------+---------+---------+----------+----------+----------+----------+----------+----------+----------+-----------+----------+----------+----------+----------+----------+----------+");
				//
				//				info = " {0,-10:S} {1,9:F} {2,9:F} {3,9:F} {4,9:F} {5,9:F} {6,9:F} {7,9:F} {8,9:F} {9,10:F} {10,10:F} {11,10:F} {12,10:F} {13,10:F} {14,10:F} {15,10:F} {16,10:F} {17,10:F} {18,10:F} {19,10:F} {20,10:F} {21,10:F} {22,10:F}";
				//
				//				int len2 = tData1.GetLength(0);
				//				
				//				for (int kk=0;kk<tData1.GetLength(0);kk++)
				//				{   
				//					
				//					sw.WriteLine(info,tData1[kk,0],
				//						tData1[kk,1],tData1[kk,2],tData1[kk,3],tData1[kk,4],
				//						tData1[kk,5],tData1[kk,6],tData1[kk,7],tData1[kk,8],
				//						tData1[kk,13],tData1[kk,14],tData1[kk,15],tData1[kk,16],tData1[kk,17],
				//						tData1[kk,18],tData1[kk,19],tData1[kk,20],tData1[kk,21],tData1[kk,22],
				//						tData1[kk,23],tData1[kk,24],tData1[kk,25],tData1[kk,26]
				//						);
				//				}
				//				
				//				sw.WriteLine("+----------+---------+---------+---------+---------+---------+---------+---------+---------+----------+----------+----------+----------+----------+----------+----------+-----------+----------+----------+----------+----------+----------+----------+");
				//
				//				sw.Close();
				//				Print();
				//				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:PrintBtn_Click"+ "  Daily Sales Record Printed  "+ " userid " +uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:DailySalesRecord.aspx,Method:PrintBtn_Click"+"  Daily Sales Recored Printed  "+ ex.Message+"  EXCEPTION   "+"  userid  "+uid);
			}
		}
	}
}