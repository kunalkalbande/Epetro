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
using EPetro.Sysitem.Classes ;
using DBOperations;
using RMG;
using System.IO;

namespace EPetro.Module.Admin
{
	/// <summary>
	/// Summary description for OrganisationDetails.
	/// </summary>
	public class OrganisationDetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.TextBox txtPhoneOff;
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label LblCompanyID;
		protected System.Web.UI.WebControls.TextBox txtDealerName;
		protected System.Web.UI.WebControls.DropDownList DropDealerShip;
		protected System.Web.UI.WebControls.TextBox TxtDealership;
		protected System.Web.UI.WebControls.TextBox TxtAddress;
		protected System.Web.UI.WebControls.TextBox TxtAddress1;
		protected System.Web.UI.WebControls.TextBox TxtFaxNo;
		protected System.Web.UI.WebControls.TextBox TxtWebsite;
		protected System.Web.UI.HtmlControls.HtmlInputFile txtFileContents;
		protected System.Web.UI.WebControls.TextBox TxtWMlic;
		protected System.Web.UI.WebControls.TextBox TxtTinno;
		protected System.Web.UI.WebControls.TextBox txtExplosive;
		protected System.Web.UI.WebControls.TextBox txtfood;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList Drop;
		protected System.Web.UI.WebControls.TextBox txtdumy;
		protected System.Web.UI.WebControls.TextBox txtdummy;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TxtAddress2;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["epetro"],true);
		protected System.Web.UI.WebControls.TextBox txtDivOffice;
		protected System.Web.UI.WebControls.TextBox txtMsg;
		protected System.Web.UI.WebControls.TextBox txtFileTitle;
		protected System.Web.UI.WebControls.TextBox txtVatRate;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtbeatname;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator4;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox txtFleetCard;
		protected System.Web.UI.WebControls.TextBox txtCreditCard;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempFleetCard;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempCreditCard;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		string uid;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for particular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				TxtDealership.Visible=false;
				//Response.Write(txtFileContents.TemplateSourceDirectory);
				//txtFileContents. 
				//txtFileContents
				try
				{
					//	string pass;
					uid=(Session["User_Name"].ToString());
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:page_load"+ ex.Message+"  EXCEPTION" +"  "  +uid);
					Response.Redirect("../../Sysitem/ErrorPage.aspx",false);
					return;
				}	
				if(!IsPostBack)
				{
					try
					{
						#region Check Privileges
						// Checks the user id adminnistrator or not ?
						if(Session["User_ID"].ToString ()!="1001")
							Response.Redirect("../../Sysitem/AccessDeny.aspx",false);
						#endregion
						getbeat();
						//LblCompanyID.Text ="1001";
						showdealer();
						city();
						nextid();
						txtDateFrom.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;    
						txtDateTo.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;   
						//	txtDateFrom.Text = "01/04/2006" ;
						//	txtDateTo.Text = "31/03/2007"; 
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:page_load"+ ex.Message+"  EXCEPTION" +"  "  +uid);
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:page_load"+ ex.Message+"  EXCEPTION " +"  "  +uid);
			}
		}

		/// <summary>
		/// If the Dealer name is not present in combo box then add the dealer in combo box.	
		/// </summary>
		public void showdealer()
		{
			InventoryClass obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql;
			
			sql="select DealerShip from Organisation";
			SqlDtr=obj.GetRecordSet(sql);
			while(SqlDtr.Read())
			{
				if(DropDealerShip.Items.IndexOf(DropDealerShip.Items.FindByValue(SqlDtr.GetValue(0).ToString())) == -1)    
					DropDealerShip.Items.Add(SqlDtr.GetValue(0).ToString());
				
			}
			SqlDtr.Close ();
		}
	
		/// <summary>
		/// This is used to generate next CompanyID auto.
		/// </summary>
		public void GetNextCustomerID()
		{
			PartiesClass obj=new PartiesClass();
			SqlDataReader SqlDtr;

			#region Fetch Next Customer ID
			SqlDtr =obj.GetNextCustomerID1();
			while(SqlDtr.Read())
			{
				LblCompanyID.Text =SqlDtr.GetSqlValue(0).ToString ();
				if (LblCompanyID.Text=="Null")
					LblCompanyID.Text ="1001";
			}	
			SqlDtr.Close();
			#endregion
		}

		/// <summary>
		/// This method is used to Fetch the Organisation ID from Organisation table.
		/// </summary>
		public void nextid()
		{
			PartiesClass obj=new PartiesClass();  
			SqlDataReader SqlDtr;
			

			#region Fetch the Next Company Number
		
			SqlDtr=obj.GetNextCustomerID1();
			while(SqlDtr.Read())
			{
				LblCompanyID.Text =SqlDtr.GetValue(0).ToString ();				
				if(LblCompanyID.Text=="")
					LblCompanyID.Text="1001";
			}
			SqlDtr.Close ();		
			#endregion
		}

		/// <summary>
		/// This is method is used to fetch city,state,country.
		/// </summary>
		public void city()
		{
			try
			{
				EmployeeClass obj=new EmployeeClass();
				SqlDataReader SqlDtr;
				string sql;
				
				#region Fetch Extra Cities from Database and add to the ComboBox
				sql="select distinct City from Beat_Master order by City asc";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					DropCity.Items.Add(SqlDtr.GetValue(0).ToString()); 
				}
				SqlDtr.Close();
				#endregion

				#region Fetch Extra Cities from Database and add to the ComboBox
				sql="select distinct state from Beat_Master order by state asc";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					DropState.Items.Add(SqlDtr.GetValue(0).ToString()); 
				}
				SqlDtr.Close();
				#endregion

				#region Fetch Extra Cities from Database and add to the ComboBox
				sql="select distinct country from Beat_Master order by country asc";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					DropCountry.Items.Add(SqlDtr.GetValue(0).ToString()); 
				}
				SqlDtr.Close();
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:btnupdate_click"+ ex.Message+"  EXCEPTION" +"  "  +uid);
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
			this.Drop.SelectedIndexChanged += new System.EventHandler(this.Drop_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.DropDealerShip.SelectedIndexChanged += new System.EventHandler(this.DropDealerShip_SelectedIndexChanged);
			this.DropCity.SelectedIndexChanged += new System.EventHandler(this.DropCity_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to check the account peried date is valid or not.
		/// </summary>
		public bool checkValidity()
		{
			string ErrorMessage = "";
			bool flag = true;
			//Response.Write("2:"+txtDateFrom.Text+";;"+txtDateTo.Text); 
	
			if(txtDateFrom.Text.Trim().Equals(""))
			{
				ErrorMessage = ErrorMessage + " - Please Select Accounts Period From Date\n";
				flag = false;
			}
			if(txtDateTo.Text.Trim().Equals(""))
			{
				ErrorMessage = ErrorMessage + " - Please Select Accounts Period To Date\n";
				flag = false;
			}
			if(flag == false)
			{
				MessageBox.Show(ErrorMessage);
				return false;
			}
			if(System.DateTime.Compare(ToMMddYYYY(txtDateFrom.Text.Trim()),ToMMddYYYY(txtDateTo.Text.Trim())) > 0)
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
		/// Name : Mahesh, Date : 30/11/06
		/// Select the state and country according to the selected city.
		/// </summary>
		public void getbeat()
		{
			try
			{
				InventoryClass  obj=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;
				string str="";
				sql="select City,State,Country from Beat_Master";
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
					str=str+SqlDtr.GetValue(0).ToString()+":";
					str=str+SqlDtr.GetValue(1).ToString()+":";
					str=str+SqlDtr.GetValue(2).ToString()+"#";
				} 
				txtbeatname.Text=str;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:getBeat()" + "EXCEPTION  "+ex.Message+uid);
			}
		}

		/// <summary>
		/// This method is used to Return Date in MM/DD/YYYY for Display and Print Input is DD/MM/YYYY
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
		/// This method is used to Insert or update the organisation details with the help of saveimage() and saveimage1() function.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:btnupdate_click"+ "  "  +uid);
				if(DropDealerShip.SelectedIndex == 0)
				{
					MessageBox.Show("Please select the Dealership");
					return;
				}
				//	Response.Write("1:"+Hidden1.Value  +";hh;"+Hidden2.Value+"<br>");   
				///	Response.Write("1:"+txtDateFrom.Text+";;"+txtDateTo.Text);   
				if(!checkValidity())
				{
					return;
				}
				if(LblCompanyID.Visible==true)
				{
					if(LblCompanyID.Text=="")
					{
						MessageBox.Show("Organisation Details Already Stored ");
						return;
					}
					saveimage();
					nextid();
				}
				else if(Drop.Visible==true)
				{
					Label1.Visible=true;
					saveimage1();
					Label1.Visible=true;
					Drop.Visible = false; 
					Button1.Visible = true;
					LblCompanyID.Visible=true;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:btnupdate_click"+ ex.Message+"  EXCEPTION" +"  "  +uid);
				TextBox1.Text="j";
			}
		}
		
		/// <summary>
		/// This Method is used to clears the form.
		/// </summary>
		public void clear()
		{
			txtDealerName.Text="";
			TxtDealership.Text="";
			TxtAddress .Text="";
			TxtAddress1.Text="";
			TxtAddress2.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry .SelectedIndex=0;
			txtPhoneOff.Text="";
			TxtFaxNo.Text="";
			txtEMail.Text="";
			TxtWebsite.Text="";
			TxtTinno.Text="";
			txtExplosive.Text="";
			txtfood.Text="";
			TxtWMlic .Text="";
			txtDivOffice.Text = "";
			DropDealerShip.SelectedIndex = 0; 
			Drop.Items.Clear();
			Drop.Items.Add("Select");  
			Drop.SelectedIndex=0; 
			txtMsg.Text = "";
			txtVatRate.Text = "";
			txtDateFrom.Text = "";
			txtDateTo.Text = "";
			txtFleetCard.Text="";
			txtCreditCard.Text="";
			tempFleetCard.Value="";
			tempCreditCard.Value="";
			txtDateFrom.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;    
			txtDateTo.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;   
		}

		/// <summary>
		/// This method is used to Insert the Organisation details into organisation table and also insert the other table with the help of stored procedure.
		/// </summary>
		public void saveimage()
		{
			try
			{
				//This Code Is hide  20 feb 2006  , This code is used for image upload in data base.
				SqlConnection conMyData;
				string  strInsert;
				SqlCommand cmdInsert;
				if ( txtFileContents.PostedFile != null )
				{
					int fileLen = txtFileContents.PostedFile.FileName.Length;
					int Lastindex = txtFileContents.PostedFile.FileName.LastIndexOf("\\");
					string filename =  txtFileContents.PostedFile.FileName.Substring(Lastindex + 1);
					conMyData=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
					conMyData.Open ();
					strInsert = "Insert Organisation (CompanyID,DealerName,DealerShip,Address,City,State,Country ,PhoneNo ,FaxNo ,Email,Website,TinNo,ExplosiveNo ,FoodLicNO,WM,Logo,Div_Office,Message,VAT_Rate,Acc_Date_from,Acc_Date_to,CreditCard,FleetCard) " +      "Values (@CompanyID,@DealerName,@DealerShip,@Address,@City,@State,@Country ,@PhoneNo,@FaxNo ,@Email,@Website,@TinNo,@ExplosiveNo,@FoodLicNO,@WM,@Logo,@Div_Office,@Message,@VAT_Rate,@Acc_date_from,@Acc_date_To,@CreditCard,@FleetCard)";
					cmdInsert = new SqlCommand( strInsert, conMyData );
					cmdInsert.Parameters.Add( "@CompanyID", LblCompanyID.Text );
					cmdInsert.Parameters.Add( "@DealerName", txtDealerName.Text );
					if(!DropDealerShip.SelectedItem.Text.ToString().Equals("Other"))
					{
						cmdInsert.Parameters.Add("@DealerShip", DropDealerShip.SelectedItem.Value.ToString());
					}
					else
					{
						cmdInsert.Parameters.Add("@DealerShip", TxtDealership.Text );
						if(DropDealerShip.Items.IndexOf(DropDealerShip.Items.FindByValue(TxtDealership.Text)) == -1)      
							DropDealerShip.Items.Add( TxtDealership.Text);
					}
				
					cmdInsert.Parameters.Add( "@Address", TxtAddress .Text.ToString()+" "+TxtAddress1.Text.ToString()+" "+TxtAddress2.Text.ToString() );
					cmdInsert.Parameters.Add( "@City", DropCity.SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@State", DropState.SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@Country", DropCountry .SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@PhoneNo", txtPhoneOff.Text.ToString() );
					cmdInsert.Parameters.Add( "@FaxNo", TxtFaxNo.Text.ToString() );
					cmdInsert.Parameters.Add( "@Email", txtEMail.Text.ToString() );
					cmdInsert.Parameters.Add( "@Website", TxtWebsite .Text.ToString() );
					cmdInsert.Parameters.Add( "@TinNo", TxtTinno.Text.ToString() );
					cmdInsert.Parameters.Add( "@ExplosiveNo", txtExplosive.Text.ToString() );
					cmdInsert.Parameters.Add( "@FoodLicNO", txtfood.Text.ToString() );
					cmdInsert.Parameters.Add( "@WM", TxtWMlic .Text.ToString() );
					cmdInsert.Parameters.Add( "@Logo",txtFileContents.PostedFile.FileName.ToString());
					cmdInsert.Parameters.Add( "@Div_Office",txtDivOffice.Text.ToString() );
					cmdInsert.Parameters.Add( "@Message",txtMsg.Text.ToString() );
					cmdInsert.Parameters.Add("@VAT_Rate",txtVatRate.Text.Trim().ToString());    
					cmdInsert.Parameters.Add("@Acc_date_from",GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim()));    
					cmdInsert.Parameters.Add("@Acc_date_to",GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()));
					cmdInsert.Parameters.Add("@FleetCard",txtFleetCard.Text+" FleetCardA/C");
					cmdInsert.Parameters.Add("@CreditCard",txtCreditCard.Text+" CreditCardA/C");
					Session["Message"] = txtMsg.Text.ToString();
					Session["VAT_Rate"] = txtVatRate.Text.Trim(); 
					cmdInsert.ExecuteNonQuery();
					//***********
					object op = null;
					dbobj.ExecProc(OprType.Insert,"ProInsertLedger",ref op,"@Ledger_Name","Cash","@SubGrp_Name","Cash in hand","@Group_Name","Current Assets","@Grp_Nature","Assets","@Op_Bal","0","@Bal_Type","Dr");
					if(txtFleetCard.Text!="")
						dbobj.ExecProc(OprType.Insert,"ProInsertLedger",ref op,"@Ledger_Name",txtFleetCard.Text+" FleetCardA/C","@SubGrp_Name","Cash in hand","@Group_Name","Current Assets","@Grp_Nature","Assets","@Op_Bal","0","@Bal_Type","Dr");
					if(txtCreditCard.Text!="")
						dbobj.ExecProc(OprType.Insert,"ProInsertLedger",ref op,"@Ledger_Name",txtCreditCard.Text+" CreditCardA/C","@SubGrp_Name","Cash in hand","@Group_Name","Current Assets","@Grp_Nature","Assets","@Op_Bal","0","@Bal_Type","Dr");
					//*****
					clear();
					MessageBox.Show("Organisation Details Saved");	
					cmdInsert.Dispose();
					conMyData.Close();
					CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:EmployeeClass.cs ,Method:saveImage(). Organisation Details Saved. User_ID: "+uid);
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:EmployeeClass.cs ,Method:image"+"  EXCEPTION "+ ex.Message+uid);
			}
		}

		/// <summary>
		/// This method is used to retrieve the company id in the combobox from the database.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{  
			CreateLogFiles Err = new CreateLogFiles();
			try
			{
				Label1.Visible=true;
				txtFileTitle.Enabled=false;
				txtFileContents.EnableViewState =false;
				Button1.Visible=false;
				Drop.Visible=true;
				LblCompanyID.Visible=false;
				txtFileContents .Visible =false;
			
				InventoryClass obj=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;
			
				//sql="select max(CompanyID) from Organisation";
				sql="select CompanyID from Organisation";
				SqlDtr=obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					Drop.Items.Add(SqlDtr.GetValue(0).ToString());
				
				}
				SqlDtr.Close ();	
 
				//CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:savebutton    User ID: "+uid);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:saveButton   EXCEPTION: "+ ex.Message+"  User_ID: "+uid);
			}
		}

		/// <summary>
		/// This method is used to update the Organisation details and also update the other table with the help of stored procedure.
		/// </summary>
		public void saveimage1()
		{
			try
			{
				SqlConnection conMyData;
				string  strInsert;
				SqlCommand cmdInsert;
				//
				// Add Uploaded file to database
				conMyData=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["epetro"]);
				conMyData.Open();
				strInsert = "update Organisation set CompanyID=@CompanyID,DealerName=@DealerName,DealerShip=@DealerShip,Address=@Address,City=@City,State=@State,Country=@Country  ,PhoneNo=@PhoneNo ,FaxNo=@FaxNo ,Email=@Email,Website=@Website,TinNo=@TinNo,ExplosiveNo=@ExplosiveNo ,FoodLicNO=@FoodLicNO,WM=@WM ,Logo=@Logo,Div_Office=@Div_Office,Message=@Message,VAT_Rate = @VAT_Rate,Acc_Date_From = @Acc_date_From,Acc_Date_To = @Acc_date_to, FleetCard = @FleetCard, CreditCard = @CreditCard where CompanyID=@CompanyID";
				cmdInsert = new SqlCommand( strInsert, conMyData );
				cmdInsert.Parameters.Add( "@document", txtFileContents.Value.ToString());
				//
				cmdInsert.Parameters.Add( "@CompanyID", Drop.SelectedItem.Value.ToString());
				cmdInsert.Parameters.Add( "@DealerName", txtDealerName.Text );
				if(!DropDealerShip.SelectedItem.Text.ToString().Equals("Other")  )
				{
					cmdInsert.Parameters.Add("@DealerShip", DropDealerShip.SelectedItem.Value.ToString());
				}
				else
				{
					cmdInsert.Parameters.Add("@DealerShip", TxtDealership.Text.Trim()  );
					if(DropDealerShip.Items.IndexOf(DropDealerShip.Items.FindByValue(TxtDealership.Text)) == -1)      
						DropDealerShip.Items.Add( TxtDealership.Text);
				}
				cmdInsert.Parameters.Add( "@Address", TxtAddress .Text.ToString()+" "+TxtAddress1.Text.ToString()+" "+TxtAddress2.Text.ToString() );
				cmdInsert.Parameters.Add( "@City", DropCity.SelectedItem.Value.ToString() );
				cmdInsert.Parameters.Add( "@State", DropState.SelectedItem.Value.ToString() );
				cmdInsert.Parameters.Add( "@Country", DropCountry .SelectedItem.Value.ToString() );
				cmdInsert.Parameters.Add( "@PhoneNo", txtPhoneOff.Text.ToString() );
				cmdInsert.Parameters.Add( "@FaxNo", TxtFaxNo.Text.ToString() );
				cmdInsert.Parameters.Add( "@Email", txtEMail.Text.ToString() );
				cmdInsert.Parameters.Add( "@Website", TxtWebsite .Text.ToString() );
				cmdInsert.Parameters.Add( "@TinNo", TxtTinno.Text.ToString() );
				cmdInsert.Parameters.Add( "@ExplosiveNo", txtExplosive.Text.ToString() );
				cmdInsert.Parameters.Add( "@FoodLicNO", txtfood.Text.ToString() );
				cmdInsert.Parameters.Add( "@WM", TxtWMlic .Text.ToString() );
				cmdInsert.Parameters.Add( "@Logo", txtFileContents.PostedFile.FileName.ToString() );
				cmdInsert.Parameters.Add( "@Div_Office", txtDivOffice.Text.ToString() );
				cmdInsert.Parameters.Add( "@Message", txtMsg.Text.ToString() );
				cmdInsert.Parameters.Add("@VAT_Rate", txtVatRate.Text.Trim().ToString());    
				cmdInsert.Parameters.Add("@Acc_date_from",GenUtil.str2MMDDYYYY(txtDateFrom.Text.Trim()));    
				cmdInsert.Parameters.Add("@Acc_date_to",GenUtil.str2MMDDYYYY(txtDateTo.Text.Trim()));
				cmdInsert.Parameters.Add("@FleetCard",txtFleetCard.Text+" FleetCardA/C");
				cmdInsert.Parameters.Add("@CreditCard",txtCreditCard.Text+" CreditCardA/C");
				Session["Message"] = txtMsg.Text.ToString();
				Session["VAT_Rate"] = txtVatRate.Text.Trim(); 
				cmdInsert.ExecuteNonQuery();
				//*************
				SqlDataReader rdr=null;
				object op = null;
				//dbobj.SelectQuery("update Ledger_Master set Eff_From='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"', Eff_to='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master where Ledger_Name='Cash')",ref rdr);
				dbobj.SelectQuery("update Ledger_Master set Eff_From='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"', Eff_to='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Ledger_Name='Cash' and Sub_Grp_Name='cash in hand')",ref rdr);
				dbobj.SelectQuery("update AccountsLedgerTable set Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Ledger_Name='Cash' and Sub_Grp_Name='cash in hand') and Particulars='Opening Balance'",ref rdr);
				if(tempFleetCard.Value!="" && txtFleetCard.Text!="")
				{
					//dbobj.SelectQuery("update Ledger_Master set Ledger_Name='"+txtFleetCard.Text+" FleetCardA/C"+"',Eff_From='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"', Eff_to='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master where Ledger_Name='"+tempFleetCard.Value+"')",ref rdr);
					dbobj.SelectQuery("update Ledger_Master set Ledger_Name='"+txtFleetCard.Text+" FleetCardA/C"+"',Eff_From='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"', Eff_to='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Ledger_Name='"+tempFleetCard.Value+"' and Sub_Grp_Name='cash in hand')",ref rdr);
					//dbobj.SelectQuery("update AccountsLedgerTable set Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master where Ledger_Name='"+tempFleetCard.Value+"') and Particulars='Opening Balance'",ref rdr);
					dbobj.SelectQuery("update AccountsLedgerTable set Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Ledger_Name='"+tempFleetCard.Value+"' and Sub_Grp_Name='cash in hand') and Particulars='Opening Balance'",ref rdr);
				}
				else if(txtFleetCard.Text!="")
				{
					dbobj.ExecProc(OprType.Insert,"ProInsertLedger",ref op,"@Ledger_Name",txtFleetCard.Text+" FleetCardA/C","@SubGrp_Name","Cash in hand","@Group_Name","Current Assets","@Grp_Nature","Assets","@Op_Bal","0","@Bal_Type","Dr");
				}
				else if(tempFleetCard.Value!="")
				{
					//dbobj.SelectQuery("delete from Ledger_Master where Ledger_Name='"+tempFleetCard.Value+"'",ref rdr);
					dbobj.SelectQuery("delete from Ledger_Master lm,Ledger_Master_Sub_Grp lms where Ledger_Name='"+tempFleetCard.Value+"' and lm.Sub_Grp_ID=lms.Sub_Grp_ID and Sub_grp_Name='cash in hand'",ref rdr);
				}
				if(tempCreditCard.Value!="" && txtCreditCard.Text!="")
				{
					//dbobj.SelectQuery("update Ledger_Master set Ledger_Name='"+txtCreditCard.Text+" CreditCardA/C"+"',Eff_From='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"', Eff_to='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master where Ledger_Name='"+tempCreditCard.Value+"')",ref rdr);
					dbobj.SelectQuery("update Ledger_Master set Ledger_Name='"+txtCreditCard.Text+" CreditCardA/C"+"',Eff_From='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"', Eff_to='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Ledger_Name='"+tempCreditCard.Value+"' and Sub_Grp_Name='cash in hand')",ref rdr);
					//dbobj.SelectQuery("update AccountsLedgerTable set Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master where Ledger_Name='"+tempCreditCard.Value+"') and Particulars='Opening Balance'",ref rdr);
					dbobj.SelectQuery("update AccountsLedgerTable set Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Ledger_Name='"+tempCreditCard.Value+"' and Sub_Grp_Name='cash in hand') and Particulars='Opening Balance'",ref rdr);
				}
				else if(txtCreditCard.Text!="")
				{
					dbobj.ExecProc(OprType.Insert,"ProInsertLedger",ref op,"@Ledger_Name",txtCreditCard.Text+" CreditCardA/C","@SubGrp_Name","Cash in hand","@Group_Name","Current Assets","@Grp_Nature","Assets","@Op_Bal","0","@Bal_Type","Dr");
				}
				else if(tempCreditCard.Value!="")
				{
					//dbobj.SelectQuery("delete from Ledger_Master where Ledger_Name='"+tempCreditCard.Value+"'",ref rdr);
					dbobj.SelectQuery("delete from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Sub_Grp_Name='cash in hand' and Ledger_Name='"+tempCreditCard.Value+"'",ref rdr);
				}
				//*************
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:saveImage() Organisation Details Updated.  userid "+uid);
				clear();
				MessageBox.Show("Organisation Details Updated ");	
				showdealer();
				conMyData.Close();
			}
			catch(Exception ex)
			{
				//MessageBox.Show("Please Select Company ID");	
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:saveImage(). EXCEPTION: "+ex.Message+".   userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to set the image path in session variable.
		/// </summary>
		public void SaveimageinFolder()
		{
			string strpath =System.Configuration .ConfigurationSettings .AppSettings["FileUploadPath"];  
			string strExt=System.IO.Path .GetFileName (txtFileContents.PostedFile.FileName);
			string  filePath=strpath+"/"+strExt;
			txtFileContents.PostedFile.SaveAs(filePath);
			Session["rajImage"]=filePath; 
		}

		/// <summary>
		/// This method is used to Displays the Organisation details information on edit time.
		/// </summary>
		private void Drop_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtdumy .Text=Drop.SelectedItem.Value.ToString();
				if(txtdumy.Text=="Select")
				{
					MessageBox.Show("Please Select Company ID ");
				}
				else
				{
					InventoryClass  obj=new InventoryClass ();
					SqlDataReader SqlDtr;
					string sql;
					sql="select * from Organisation where CompanyID='"+ Drop.SelectedItem.Value +"'" ;
					SqlDtr=obj.GetRecordSet(sql); 
					while(SqlDtr.Read())
					{
						txtDealerName.Text=SqlDtr.GetValue(1).ToString();  
						DropDealerShip.SelectedIndex=(DropDealerShip.Items.IndexOf((DropDealerShip.Items.FindByValue (SqlDtr.GetValue(2).ToString()))));
						TxtAddress.Text=SqlDtr.GetValue(3).ToString();
						DropCity .SelectedIndex=(DropCity.Items.IndexOf((DropCity.Items.FindByValue(SqlDtr.GetValue(4).ToString()))));
						DropState .SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(SqlDtr.GetValue(5).ToString()))));
						DropCountry .SelectedIndex=(DropCountry .Items.IndexOf((DropCountry .Items.FindByValue(SqlDtr.GetValue(6).ToString()))));
						txtPhoneOff.Text=SqlDtr.GetValue(7).ToString();
						TxtFaxNo.Text=SqlDtr.GetValue(8).ToString(); 
						txtEMail .Text =SqlDtr.GetValue(9).ToString(); 
						TxtWebsite.Text= SqlDtr.GetValue(10).ToString(); 
						TxtTinno .Text=SqlDtr.GetValue(11).ToString();  
						txtExplosive .Text=SqlDtr.GetValue(12).ToString();  
						txtfood.Text= SqlDtr.GetValue(13).ToString();  
						TxtWMlic.Text= SqlDtr.GetValue(14).ToString();  
						txtDivOffice.Text =  SqlDtr.GetValue(16).ToString();
						txtFileContents.Name = SqlDtr.GetValue(15).ToString(); 
						txtMsg.Text = SqlDtr.GetValue(17).ToString();
						txtVatRate.Text = GenUtil.strNumericFormat(SqlDtr.GetValue(18).ToString().Trim ());  
						txtDateFrom.Text = checkDate(GenUtil.str2DDMMYYYY(trimDate(SqlDtr.GetValue(19).ToString().Trim ()))); 
						txtDateTo.Text = checkDate(GenUtil.str2DDMMYYYY(trimDate(SqlDtr.GetValue(20).ToString().Trim ()))); 
						string FC=SqlDtr["FleetCard"].ToString();
						string[] FCard=FC.Split(new char[] {' '},FC.Length);
						txtFleetCard.Text=FCard[0].ToString();
						string CC=SqlDtr["CreditCard"].ToString();
						string[] CCard=CC.Split(new char[] {' '},CC.Length);
						txtCreditCard.Text=CCard[0].ToString();
						tempFleetCard.Value=SqlDtr["FleetCard"].ToString();
						tempCreditCard.Value=SqlDtr["CreditCard"].ToString();
					}
					SqlDtr.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:Drop_SelectedIndexChanged(). EXCEPTION: "+ex.Message+".   userid "+uid);
			}
		}

		/// <summary>
		/// This method is used to Return blank if retrieve date format is "1/1/1900" otherwise return str. 
		/// </summary>
		public string checkDate(string str)
		{
			if(!str.Trim().Equals(""))
			{
				if(str.Trim().Equals("1/1/1900"))
					str = "";
			}
			return str;
		}

		/// <summary>
		/// This method is used to seprate time from date and returns only date in mm/dd/yyyy
		/// </summary>
		public string trimDate(string strDate)
		{
			
			int pos = strDate.IndexOf(" ");

			if(pos != -1)
			{
				strDate = strDate.Substring(0,pos);
			}
			else
			{
				strDate = "";					
			}
			return strDate;
		}


		/// <summary>
		/// If the dealer name is other then visible the Text Box to enter the dealer name. 
		/// </summary>
		private void DropDealerShip_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtdummy.Text=DropDealerShip.SelectedItem.Value.ToString();
 
			if(txtdummy.Text=="Other")
			{
				TxtDealership.Visible=true;
			
			}
			else
			{
				TxtDealership.Visible=false;
			}
		}

		/// <summary>
		/// Select the state and country according to the selected city.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			try
			{
				InventoryClass  obj=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;
				sql="select State,Country from Beat_Master where City='"+ DropCity.SelectedItem.Value +"'" ;
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
				
					DropState.SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(SqlDtr.GetValue(0).ToString()))));
					DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry.Items.FindByValue(SqlDtr.GetValue(1).ToString()))));
				
				}  
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Class:InventoryClass.cs ,Method:Drop_SelectedIndexChanged(). EXCEPTION: "+ex.Message+".   userid "+uid);
			}*/
		}
	}
}