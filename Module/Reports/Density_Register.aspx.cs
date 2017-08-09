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
	/// Summary description for Density_Register.
	/// </summary>
	public class Density_Register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropMonth;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.DropDownList DropProduct;
		protected System.Web.UI.WebControls.DropDownList DropTank;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		string uid;
		public string city ="";
		public string dealer = "";
		public string div_office="";
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
				SqlDataReader SqlDtr;
				PetrolPumpClass obj=new PetrolPumpClass();
				string sql="";
				uid=(Session["User_Name"].ToString());
				// Fetch Dealer name city and store in string , to access from .aspx page.
				sql="select DealerName,City,Div_Office,DealerShip from Organisation";
				SqlDtr=obj.GetRecordSet(sql); 
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
				CreateLogFiles.ErrorLog("Form:Density_Registor,Method:page_load"+ex.Message+"  EXCEPTION "+"  userid  "+uid);
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
					string SubModule="14";
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
						//	string msg="UnAthourized Visit to Density register Report Page";
						//	dbobj.LogActivity(msg,Session["User_Name"].ToString());  
						Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
					}
					#endregion

					DropMonth.SelectedIndex=DateTime.Now.Month;
					Session["selmonth"]=DateTime.Now.Month;
					PetrolPumpClass obj=new PetrolPumpClass();
					SqlDataReader  SqlDtr;
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

					//					#region Fetch Tank ID
					//					if(!DropProduct.SelectedItem.Text.Equals("Select"))
					//					{
					//						sql="select Prod_AbbName from Tank where Prod_Name='"+DropProduct.SelectedItem.Text+"' order by Prod_AbbName";
					//						SqlDtr=obj.GetRecordSet(sql);
					//						while(SqlDtr.Read())
					//						{
					//							DropTank.Items.Add(SqlDtr["Prod_AbbName"].ToString());
					//						}
					//						SqlDtr.Close();
					//					}
					//					#endregion
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Density_Registor,Method:page_load  EXCEPTION "+ex.Message+"  userid  "+uid);
				}
			}			
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		private string GetString(string str,int maxlen,string spc)
		{		
			return str+spc.Substring(0,maxlen>str.Length?maxlen-str.Length:str.Length-maxlen);
		}
		
		/// <summary>
		/// This method is not used.
		/// </summary>
		private string MakeString(int len)
		{
			string spc="";
			for(int x=0;x<len;x++)
				spc+=" ";
			return spc;
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
			this.DropProduct.SelectedIndexChanged += new System.EventHandler(this.DropProduct_SelectedIndexChanged);
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This method is used to returns the date in MM/DD/YYYY format.
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
		/// This function fetch all information and returns the string array and prepares the report file. 
		/// </summary>
		public string[,] GetData1()
		{   
			string sql="";
			string ProdID="";
			string TankID=""; 
			string info ="";
			if(DropProduct.SelectedIndex>0 )
			{
				sql="select Prod_ID from Products where Prod_Name='"+DropProduct.SelectedItem.Value+"'";
				dbobj.SelectQuery(sql,"Prod_ID",ref ProdID);
			}
			if(DropTank.SelectedIndex>0 )
			{
				sql="select Tank_ID from Tank where Prod_AbbName='"+DropTank.SelectedItem.Value+"'";
				dbobj.SelectQuery(sql,"Tank_ID",ref TankID);
			}
			PetrolPumpClass obj=new PetrolPumpClass();
			SqlDataReader SqlDtr;
			string Prod_ID=ProdID,Tank_ID=TankID;
			int month=(int) Session["selmonth"];
			int Days_in_Months=DateTime.DaysInMonth(DateTime.Now.Year,month);
			string[,] tData=new string[Days_in_Months,23]; 

			#region Initialize Array Data

			
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
			string[] str10 = new string[500000];
			string[] str11 = new string[500000];
			string[] str12 = new string[500000];
			string[] str13 = new string[500000];
			string[] str14 = new string[500000];
			string[] str15 = new string[500000];
			string[] str16 = new string[500000];
			string[] str17 = new string[500000];
			string[] str18 = new string[500000];
			string[] str19 = new string[500000];
			string[] str20 = new string[500000];
			string[] str21 = new string[500000];
			string[] str22 = new string[500000];
			string[] str23 = new string[500000];
			
			int l=0;
			int p=0;
			for(int i=0;i<tData.GetLength(0);i++)
			{
				for(int j=0;j<tData.GetLength(1);j++)
				{
					tData[i,j]="";
				}
			}
			#endregion
			
			for(int i=0;i<tData.GetLength(0);i++)
			{
				string eDate=(i+1)+"/"+month.ToString()+"/"+DateTime.Now.Year.ToString(); 
				tData[i,0]=eDate;

				#region Fetch Density, Tempreture and Converted Density
				sql="select Entry_Date,Density,Temprature,Converted_Density from daily_tank_reading where Tank_ID='"+ Tank_ID +"' and cast(floor(cast(Entry_Date as float)) as datetime)='"+GenUtil.str2MMDDYYYY(eDate)+"'";
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					str0[l]=eDate;  
					l++;
					tData[i,1]=SqlDtr["Density"].ToString();
					tData[i,2]=SqlDtr["Temprature"].ToString();
					tData[i,3]=SqlDtr["Converted_Density"].ToString();
					tData[i,1]=(System.Math.Round(System.Convert.ToDecimal(tData[i,1]),4)).ToString();
					tData[i,3]=(System.Math.Round(System.Convert.ToDecimal(tData[i,3]),4)).ToString();
					str1[p]=SqlDtr["Density"].ToString();
					str2[p]=SqlDtr["Temprature"].ToString();
					str3[p]=SqlDtr["Converted_Density"].ToString();
					
					p++;

				}
				SqlDtr.Close();
				#endregion
				
				int  pp=0;
				string strQty="";
				double dQty=0;
				#region Fetch Data from Purchase
				sql="select pm.*,fps.* from Purchase_Master pm, Fuel_Purchase_Details fps where pm.Invoice_No=fps.Invoice_No and Prod_ID='"+Prod_ID+"' and cast(floor(cast(Invoice_Date as float)) as datetime)>='"+ GenUtil.str2MMDDYYYY(eDate) +"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(eDate)+"' order by pm.Invoice_No";
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					tData[i,4]=SqlDtr["Vndr_Invoice_No"].ToString(); // Invoice_No (original)
					strQty = SqlDtr["Qty"].ToString();
					if(!strQty.Trim().Equals(""))
					{
						dQty=dQty+System.Convert.ToDouble(strQty); 
					}

					str4[pp]=SqlDtr["Invoice_No"].ToString();
					str5[pp]=SqlDtr["Qty"].ToString();
                      
					
					if(SqlDtr["Compartment"].ToString()=="Comp. I")
					{
						tData[i,6]=SqlDtr["Density_in_Physical"].ToString();
						tData[i,10]=SqlDtr["Temp_in_Physical"].ToString();
						tData[i,14]=SqlDtr["Conv_Density_Phy"].ToString();

						// Prafull : Density in Invoice
						tData[i,18]=SqlDtr["Density_in_Invoice_Conv"].ToString();
						tData[i,19]=SqlDtr["Density_Variation"].ToString();

						tData[i,20]=SqlDtr["Den_After_Dec"].ToString();
						tData[i,21]=SqlDtr["Temp_After_Dec"].ToString();
						tData[i,22]=SqlDtr["Conv_Den_After_Dec"].ToString();

						str6[pp]=SqlDtr["Density_in_Physical"].ToString();
						str10[pp]=SqlDtr["Temp_in_Physical"].ToString();
						str14[pp]=SqlDtr["Conv_Density_Phy"].ToString();
						str20[pp]=SqlDtr["Den_After_Dec"].ToString();
						str21[pp]=SqlDtr["Temp_After_Dec"].ToString();
						str22[pp]=SqlDtr["Conv_Den_After_Dec"].ToString();

					}
					else if(SqlDtr["Compartment"].ToString()=="Comp. II")
					{
						tData[i,7]=SqlDtr["Density_in_Physical"].ToString();
						tData[i,11]=SqlDtr["Temp_in_Physical"].ToString();
						tData[i,15]=SqlDtr["Conv_Density_Phy"].ToString();
						tData[i,20]=SqlDtr["Den_After_Dec"].ToString();
						tData[i,21]=SqlDtr["Temp_After_Dec"].ToString();
						tData[i,22]=SqlDtr["Conv_Den_After_Dec"].ToString();

						str7[pp]=SqlDtr["Density_in_Physical"].ToString();
						str11[pp]=SqlDtr["Temp_in_Physical"].ToString();
						str15[pp]=SqlDtr["Conv_Density_Phy"].ToString();
						str20[pp]=SqlDtr["Den_After_Dec"].ToString();
						str21[pp]=SqlDtr["Temp_After_Dec"].ToString();
						str22[pp]=SqlDtr["Conv_Den_After_Dec"].ToString();


					}
					else if(SqlDtr["Compartment"].ToString()=="Comp. III")
					{
						tData[i,8]=SqlDtr["Density_in_Physical"].ToString();
						tData[i,12]=SqlDtr["Temp_in_Physical"].ToString();
						tData[i,16]=SqlDtr["Conv_Density_Phy"].ToString();
						tData[i,20]=SqlDtr["Den_After_Dec"].ToString();
						tData[i,21]=SqlDtr["Temp_After_Dec"].ToString();
						tData[i,22]=SqlDtr["Conv_Den_After_Dec"].ToString();

						str8[pp]=SqlDtr["Density_in_Physical"].ToString();
						str12[pp]=SqlDtr["Temp_in_Physical"].ToString();
						str16[pp]=SqlDtr["Conv_Density_Phy"].ToString();
						str20[pp]=SqlDtr["Den_After_Dec"].ToString();
						str21[pp]=SqlDtr["Temp_After_Dec"].ToString();
						str22[pp]=SqlDtr["Conv_Den_After_Dec"].ToString();


					}
					else if(SqlDtr["Compartment"].ToString()=="Comp. IV")
					{
						tData[i,9]=SqlDtr["Density_in_Physical"].ToString();
						tData[i,13]=SqlDtr["Temp_in_Physical"].ToString();
						tData[i,17]=SqlDtr["Conv_Density_Phy"].ToString();
						tData[i,20]=SqlDtr["Den_After_Dec"].ToString();
						tData[i,21]=SqlDtr["Temp_After_Dec"].ToString();
						tData[i,22]=SqlDtr["Conv_Den_After_Dec"].ToString();

						str9[pp]=SqlDtr["Density_in_Physical"].ToString();
						str13[pp]=SqlDtr["Temp_in_Physical"].ToString();
						str17[pp]=SqlDtr["Conv_Density_Phy"].ToString();
						str20[pp]=SqlDtr["Den_After_Dec"].ToString();
						str21[pp]=SqlDtr["Temp_After_Dec"].ToString();
						str22[pp]=SqlDtr["Conv_Den_After_Dec"].ToString();


					}
				

				} 
				if(dQty != 0)
					tData[i,5]=dQty.ToString() ;
				else
					tData[i,5]="";

				if (str1.Length < 17)
				{
					str1[pp] = str1[pp] + MakeString(17 - str1[pp].Length);
               

				}

				if (str2.Length < 13)
				{
					str2[pp] = str2[pp] + MakeString(13 - str2[pp].Length);
               

				}
				if (str3.Length < 13)
				{
					str3[pp] = str3[pp] + MakeString(13 - str3[pp].Length);
               

				}

				if (str4.Length < 13)
				{
					str4[pp] = str4[pp] + MakeString(13 - str4[pp].Length);
               

				}
				if (str5.Length < 13)
				{
					str5[pp] = str5[pp] + MakeString(13 - str5[pp].Length);
               

				}
				if (str6.Length < 13)
				{
					str6[pp] = str6[pp] + MakeString(13 - str6[pp].Length);
               

				}
				
				SqlDtr.Close();
				#endregion
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 				
				string path = home_drive+@"\Inetpub\wwwroot\EPetro\Sysitem\EpetroPrintServices\ReportView\DensityReport.txt";
		
				StreamWriter sw = new StreamWriter(path);
				/*
																								 ===========================                                                                                                                                                 
																								   DENSITY REGISTER REPORT                                                                                                                                                  
																								 ===========================                                                                                                                                                 
					+----------+------------------------+----------------+------------------------------------+-----------------------+-----------------------------------+--------+--------+------------------------+
					|          |    Morning Density     |    Receipts    |        Observed Density            | Observed Temperature  |        Density Converted          |As  per | Diff.  |         After          |           
					|          |------------------------|                |------------------------------------|-----------------------|-----------------------------------|Challan |between |      Decantation       |                
					|  Date    |       Observed         |                |            Compartment             |     Compartment       |            Compartment            |at 15蚓 |9 and 10|                        |                     
					|          |---------+----+---------|------+---------+--------+---------+--------+--------+-----+-----+-----+-----+--------+--------+--------+--------+        |        |--------+-----+---------+
					|          | Density |Temp|Den @ 15院Inv.No|Quantity |    I   |   II    |   III  |  IV    | I   | II  | III | IV  |   I    |   II   |  III   |   IV   |        |        |Density |Temp.|Den @ 15院         
					+----------+---------+----+---------+------+---------+--------+---------+--------+--------+-----+-----+-----+-----+--------+--------+--------+--------+--------+--------+--------+-----+---------+
					|    1     |    2    | 3  |    4    |  5   |   6     |                  7                 |           8           |                 9                 |   10   |   11   |   12   | 13  |   14    |
					+----------+---------+----+---------+------+---------+--------+---------+--------+--------+-----+-----+-----+-----+--------+--------+--------+--------+--------+--------+--------+-----+---------+
					 28/03/2006 0.123456  022  0.123456  1234   123456.78 0.123456 0.1234560 0.123456 0.123456 10.50 10.50 10.50 10.50 0.123456 0.123456 0.123456 0.123456 0.123456 0.123456 0.123456 10.50 0.123456

					*/ 			
				// info : to display the fields in to the specified format, or to set the format.
				info = " {0,-10:S} {1,8:F} {2,4:F}  {3,8:F} {4,6:D} {5,9:F} {6,8:F} {7,9:F} {8,8:F} {9,8:F} {10,5:F} {11,5:F} {12,5:F} {13,5:F} {14,8:F} {15,8:F} {16,8:F} {17,8:F} {18,8:F}{19,9:F} {20,8:F} {21,5:F}  {22,8:F}";
				sw.WriteLine("                                                                             =========================== ");
				sw.WriteLine("                                                                               DENSITY REGISTER REPORT");
				sw.WriteLine("                                                                             =========================== ");
				/*
					Dealer Name:  M/S. SIDHA STHAN PETROLEAM
					Location   :  Morena
					Product    :  Petrol
					Tank       :  T-1/MSD-20k
					Month      :  April 
					 */	
				sw.WriteLine("Dealer Name: "+dealer); 
				sw.WriteLine("Location   : "+city);
				sw.WriteLine("Product    : "+DropProduct.SelectedItem.Text.ToString());
				sw.WriteLine("Tank       : "+DropTank.SelectedItem.Text.ToString());
				sw.WriteLine("Month      : "+DropMonth.SelectedItem.Text.ToString());
				sw.WriteLine("+---------+------------------------+----------------+------------------------------------+-----------------------+-----------------------------------+--------+--------+------------------------+");
				sw.WriteLine("|         |    Morning Density     |    Receipts    |        Observed Density            | Observed Temperature  |        Density Converted          |As  per | Diff.  |         After          |");
				sw.WriteLine("|         |------------------------|                |------------------------------------|-----------------------|-----------------------------------|Challan |between |      Decantation       |");
				sw.WriteLine("|  Date   |       Observed         |                |            Compartment             |     Compartment       |            Compartment            |at 15蚓 |9 and 10|                        |");
				sw.WriteLine("|         |---------+----+---------|------+---------+--------+---------+--------+--------+-----+-----+-----+-----+--------+--------+--------+--------+        |        |--------+-----+---------+");
				sw.WriteLine("|         | Density |Temp|Den @ 15院Inv.No|Quantity |    I   |   II    |   III  |  IV    | I   | II  | III | IV  |   I    |   II   |  III   |   IV   |        |        |Density |Temp.|Den @ 15院");
				sw.WriteLine("+---------+---------+----+---------+------+---------+--------+---------+--------+--------+-----+-----+-----+-----+--------+--------+--------+--------+--------+--------+--------+-----+---------+");
				sw.WriteLine("|    1    |    2    | 3  |    4    |  5   |   6     |                  7                 |           8           |                 9                 |   10   |   11   |   12   | 13  |   14    |");
				sw.WriteLine("+---------+---------+----+---------+------+---------+--------+---------+--------+--------+-----+-----+-----+-----+--------+--------+--------+--------+--------+--------+--------+-----+---------+");
				
				for(int kk=0;kk<tData.GetLength(0);kk++)  //<p
				{
					sw.WriteLine(info,tData[kk,0],tData[kk,1],tData[kk,2],tData[kk,3],tData[kk,4],
						tData[kk,5],tData[kk,6],tData[kk,7],tData[kk,8],tData[kk,9],
						tData[kk,10],tData[kk,11],tData[kk,12],tData[kk,13],tData[kk,14],
						tData[kk,15],tData[kk,16],tData[kk,17],tData[kk,18],tData[kk,19],
						tData[kk,20],tData[kk,21],tData[kk,22]
						);

				}

				sw.WriteLine("+---------+---------+----+---------+------+---------+--------+---------+--------+--------+-----+-----+-----+-----+--------+--------+--------+--------+--------+--------+--------+-----+---------+");
				sw.Close();
			}
			return tData;
		}

		/// <summary>
		/// This method returns Fetch all the information from database & returns a string array.
		/// </summary>
		/// <returns></returns>
		public string[,] GetData()
		{   
			string sql="";
			string ProdID="";
			string TankID=""; 
			if(DropProduct.SelectedIndex>0 )
			{
				sql="select Prod_ID from Products where Prod_Name='"+DropProduct.SelectedItem.Value+"'";
				dbobj.SelectQuery(sql,"Prod_ID",ref ProdID);
			}
			if(DropTank.SelectedIndex>0 )
			{
				sql="select Tank_ID from Tank where Prod_AbbName='"+DropTank.SelectedItem.Value+"'";
				dbobj.SelectQuery(sql,"Tank_ID",ref TankID);
			}
			PetrolPumpClass obj=new PetrolPumpClass();
			SqlDataReader SqlDtr;
			string Prod_ID=ProdID,Tank_ID=TankID;
			int month=(int) Session["selmonth"];
			int Days_in_Months=DateTime.DaysInMonth(DateTime.Now.Year,month);
			string[,] tData=new string[Days_in_Months,23]; 

			#region Initialize Array Data

			
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
			string[] str10 = new string[500000];
			string[] str11 = new string[500000];
			string[] str12 = new string[500000];
			string[] str13 = new string[500000];
			string[] str14 = new string[500000];
			string[] str15 = new string[500000];
			string[] str16 = new string[500000];
			string[] str17 = new string[500000];
			string[] str18 = new string[500000];
			string[] str19 = new string[500000];
			string[] str20 = new string[500000];
			string[] str21 = new string[500000];
			string[] str22 = new string[500000];
			string[] str23 = new string[500000];
			
			int l=0;
			int p=0;
			for(int i=0;i<tData.GetLength(0);i++)
			{
				for(int j=0;j<tData.GetLength(1);j++)
				{
					tData[i,j]="";
				}
			}
			#endregion
			
			for(int i=0;i<tData.GetLength(0);i++)
			{
				string eDate=(i+1)+"/"+month.ToString()+"/"+DateTime.Now.Year.ToString(); 
				tData[i,0]=eDate;

				#region Fetch Density, Tempreture and Converted Density
				sql="select Entry_Date,Density,Temprature,Converted_Density from daily_tank_reading where Tank_ID='"+ Tank_ID +"' and cast(floor(cast(Entry_Date as float)) as datetime)='"+GenUtil.str2MMDDYYYY(eDate)+"'";
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					str0[l]=eDate;  
					l++;
					tData[i,1]=SqlDtr["Density"].ToString();
					tData[i,2]=SqlDtr["Temprature"].ToString();
					tData[i,3]=SqlDtr["Converted_Density"].ToString();
					tData[i,1]=(System.Math.Round(System.Convert.ToDecimal(tData[i,1]),4)).ToString();
					tData[i,3]=(System.Math.Round(System.Convert.ToDecimal(tData[i,3]),4)).ToString();
					str1[p]=SqlDtr["Density"].ToString();
					str2[p]=SqlDtr["Temprature"].ToString();
					str3[p]=SqlDtr["Converted_Density"].ToString();
					
					p++;

				}
				SqlDtr.Close();
				#endregion
				
				int  pp=0;
				string strQty="";
				double dQty=0;
					
				#region Fetch Data from Purchase

				sql="select pm.*,fps.* from Purchase_Master pm, Fuel_Purchase_Details fps where pm.Invoice_No=fps.Invoice_No and Prod_ID='"+Prod_ID+"' and cast(floor(cast(Invoice_Date as float)) as datetime)>= '"+ GenUtil.str2MMDDYYYY(eDate)+"' and cast(floor(cast(Invoice_Date as float)) as datetime)<='"+ GenUtil.str2MMDDYYYY(eDate)+"' order by pm.Invoice_No";
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					tData[i,4]=SqlDtr["Vndr_Invoice_No"].ToString(); // Invoice_No (original)
					strQty = SqlDtr["Qty"].ToString();
					if(!strQty.Trim().Equals(""))
					{
						dQty=dQty+System.Convert.ToDouble(strQty); 
					}

					str4[pp]=SqlDtr["Invoice_No"].ToString();
					str5[pp]=SqlDtr["Qty"].ToString();
                      
					
					if(SqlDtr["Compartment"].ToString()=="Comp. I")
					{
						tData[i,6]=SqlDtr["Density_in_Physical"].ToString();
						tData[i,10]=SqlDtr["Temp_in_Physical"].ToString();
						tData[i,14]=SqlDtr["Conv_Density_Phy"].ToString();

						// Prafull : Density in Invoive
						tData[i,18]=SqlDtr["Density_in_Invoice_Conv"].ToString();
						tData[i,19]=SqlDtr["Density_Variation"].ToString();

						tData[i,20]=SqlDtr["Den_After_Dec"].ToString();
						tData[i,21]=SqlDtr["Temp_After_Dec"].ToString();
						tData[i,22]=SqlDtr["Conv_Den_After_Dec"].ToString();

						str6[pp]=SqlDtr["Density_in_Physical"].ToString();
						str10[pp]=SqlDtr["Temp_in_Physical"].ToString();
						str14[pp]=SqlDtr["Conv_Density_Phy"].ToString();
						str20[pp]=SqlDtr["Den_After_Dec"].ToString();
						str21[pp]=SqlDtr["Temp_After_Dec"].ToString();
						str22[pp]=SqlDtr["Conv_Den_After_Dec"].ToString();

					}
					else if(SqlDtr["Compartment"].ToString()=="Comp. II")
					{
						tData[i,7]=SqlDtr["Density_in_Physical"].ToString();
						tData[i,11]=SqlDtr["Temp_in_Physical"].ToString();
						tData[i,15]=SqlDtr["Conv_Density_Phy"].ToString();
						tData[i,20]=SqlDtr["Den_After_Dec"].ToString();
						tData[i,21]=SqlDtr["Temp_After_Dec"].ToString();
						tData[i,22]=SqlDtr["Conv_Den_After_Dec"].ToString();

						str7[pp]=SqlDtr["Density_in_Physical"].ToString();
						str11[pp]=SqlDtr["Temp_in_Physical"].ToString();
						str15[pp]=SqlDtr["Conv_Density_Phy"].ToString();
						str20[pp]=SqlDtr["Den_After_Dec"].ToString();
						str21[pp]=SqlDtr["Temp_After_Dec"].ToString();
						str22[pp]=SqlDtr["Conv_Den_After_Dec"].ToString();


					}
					else if(SqlDtr["Compartment"].ToString()=="Comp. III")
					{
						tData[i,8]=SqlDtr["Density_in_Physical"].ToString();
						tData[i,12]=SqlDtr["Temp_in_Physical"].ToString();
						tData[i,16]=SqlDtr["Conv_Density_Phy"].ToString();
						tData[i,20]=SqlDtr["Den_After_Dec"].ToString();
						tData[i,21]=SqlDtr["Temp_After_Dec"].ToString();
						tData[i,22]=SqlDtr["Conv_Den_After_Dec"].ToString();

						str8[pp]=SqlDtr["Density_in_Physical"].ToString();
						str12[pp]=SqlDtr["Temp_in_Physical"].ToString();
						str16[pp]=SqlDtr["Conv_Density_Phy"].ToString();
						str20[pp]=SqlDtr["Den_After_Dec"].ToString();
						str21[pp]=SqlDtr["Temp_After_Dec"].ToString();
						str22[pp]=SqlDtr["Conv_Den_After_Dec"].ToString();


					}
					else if(SqlDtr["Compartment"].ToString()=="Comp. IV")
					{
						tData[i,9]=SqlDtr["Density_in_Physical"].ToString();
						tData[i,13]=SqlDtr["Temp_in_Physical"].ToString();
						tData[i,17]=SqlDtr["Conv_Density_Phy"].ToString();
						tData[i,20]=SqlDtr["Den_After_Dec"].ToString();
						tData[i,21]=SqlDtr["Temp_After_Dec"].ToString();
						tData[i,22]=SqlDtr["Conv_Den_After_Dec"].ToString();

						str9[pp]=SqlDtr["Density_in_Physical"].ToString();
						str13[pp]=SqlDtr["Temp_in_Physical"].ToString();
						str17[pp]=SqlDtr["Conv_Density_Phy"].ToString();
						str20[pp]=SqlDtr["Den_After_Dec"].ToString();
						str21[pp]=SqlDtr["Temp_After_Dec"].ToString();
						str22[pp]=SqlDtr["Conv_Den_After_Dec"].ToString();


					}
				
				} 
				if(dQty != 0)
					tData[i,5]= dQty.ToString() ;
				else
					tData[i,5]= "";



				if (str1.Length < 17)
				{
					str1[pp] = str1[pp] + MakeString(17 - str1[pp].Length);
               

				}

				if (str2.Length < 13)
				{
					str2[pp] = str2[pp] + MakeString(13 - str2[pp].Length);
               

				}
				if (str3.Length < 13)
				{
					str3[pp] = str3[pp] + MakeString(13 - str3[pp].Length);
               

				}

				if (str4.Length < 13)
				{
					str4[pp] = str4[pp] + MakeString(13 - str4[pp].Length);
               

				}
				if (str5.Length < 13)
				{
					str5[pp] = str5[pp] + MakeString(13 - str5[pp].Length);
               

				}
				if (str6.Length < 13)
				{
					str6[pp] = str6[pp] + MakeString(13 - str6[pp].Length);
               

				}
				
				SqlDtr.Close();
				#endregion
				
			}
			return tData;
		}

		public void Write2File1(StreamWriter sw, string info)
		{
			sw.WriteLine(info);
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

					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\EPetro\\Sysitem\\EpetroPrintServices\\ReportView\\DensityReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:Density_Registor,Method:print  EXCEPTION "+ane.Message+" User:"+uid);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:Density_Registor,Method:print  EXCEPTION "+se.Message+" User:"+uid);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:Density_Registor,Method:print  EXCEPTION "+es.Message+" User:"+uid);
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:Density_Registor,Method:print"+ex.Message+"  EXCEPTION"+uid);
			}
		}

		/// <summary>
		/// This method is used to print the report in html format.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
                StringBuilder errorMessage = new StringBuilder();
                if (DropProduct.SelectedIndex == 0)
                {
                    errorMessage.Append("- Please Select Product Name");
                    errorMessage.Append("\n");
                }
                if (DropTank.SelectedIndex == 0)
                {
                    errorMessage.Append("- Please Select Tank ID");
                    errorMessage.Append("\n");
                }
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());
                    return;
                }

                if (DropMonth.SelectedIndex==0)
				{
					MessageBox.Show("Please select the correct Month");
					DropMonth.SelectedIndex=(int)Session["selmonth"];
					return;
				}
				Session["selmonth"]=DropMonth.SelectedIndex;
				Session["Data"] = GetData1();
				Session["Product"] = DropProduct.SelectedItem.Text;
				Session["Month"] = DropMonth.SelectedItem.Text;
				Session["Tank"] = DropTank.SelectedItem.Text;
				Session["Dealer"] = dealer;
				Session["Location"] = city; 
				Session["DealerShip"] = dealership;
				Session["Div_Office"] = div_office; 
				Response.Redirect("DensityRegister_PrintPreview.aspx",false); 
				//Print();
			
				CreateLogFiles.ErrorLog("Form:Density_Registor,Method:Button1_Click"+" Density Registor Record Viewed  "+" userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Density_Registor,Method:Button1_Click"+" Density Registor Record Viewed  "+"  userid"+ex.Message+"  EXCEPTION  "+" userid  "+uid);
			}
		}

		/// <summary>
		/// This method is used to call the GetData() function for view the report.
		/// </summary>
		private void btnView_Click(object sender, System.EventArgs e)
		{
            StringBuilder errorMessage = new StringBuilder();
            if (DropProduct.SelectedIndex == 0)
            {
                errorMessage.Append("- Please Select Product Name");
                errorMessage.Append("\n");
            }
            if (DropTank.SelectedIndex == 0)
            {
                errorMessage.Append("- Please Select Tank ID");
                errorMessage.Append("\n");
            }
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage.ToString());
                return;
            }
			try
			{
				if(DropMonth.SelectedIndex==0)
				{
					MessageBox.Show("Please select the correct Month");
					DropMonth.SelectedIndex=(int)Session["selmonth"];
					return;
				}
				//put the selected month in session.
				Session["selmonth"]=DropMonth.SelectedIndex;
				GetData();
				CreateLogFiles.ErrorLog("Form:Density_Registor,Method:btnView_Click"+" Density Registor Record Viewed  "+" userid  "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Density_Registor,Method:btnView_Click"+" Density Registor Record Viewed  "+ex.Message+"  EXCEPTION"+uid);
			}
		}

		/// <summary>
		/// This method is used to fatch the tank name according to select the product name from dropdownlist.
		/// </summary>
		private void DropProduct_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PetrolPumpClass obj=new PetrolPumpClass();
			SqlDataReader SqlDtr;
			string sql="";

			#region Fetch Tank ID
			DropTank.Items.Clear();
			DropTank.Items.Add("Select");
			if(!DropProduct.SelectedItem.Text.Equals("Select"))
			{
				sql="select Prod_AbbName from Tank where Prod_Name='"+DropProduct.SelectedItem.Text+"' order by Prod_AbbName";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					DropTank.Items.Add(SqlDtr["Prod_AbbName"].ToString());
				}
				SqlDtr.Close();
			}
			#endregion
		}
	}
}