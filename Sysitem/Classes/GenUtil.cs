/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/

using System;
using System.Data.SqlClient;
using EPetro.Sysitem.Classes;
using RMG;

namespace EPetro.Sysitem.Classes
{
	/// <summary>
	/// Summary description for GenUtil.
	/// </summary>
	public class GenUtil
	{
		public GenUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// This Method is used to force 2 Digits of precission for numeric values
		/// </summary>
		public static string strNumericFormat(string str)
		{
			int pos = -1;
			pos = str.IndexOf(".");

			if(pos != -1)
			{
				string s = str.Substring(pos);
				if(s.Length > 2)
				{
					if(s.Length != 3)
						str = System.Convert.ToString(System.Math.Round(System.Convert.ToDouble(str),2));   
                      
					if(str.IndexOf(".") == -1)
						str = str+".00";

					if(str.Substring(pos).Length  == 2)
						str = str+"0";
				}
				else
				{
					str = str + "0";
				}
			}
			else
			{
				if(!str.Trim().Equals(""))  
					str = str+".00";
			}
			return str;	
		}

		/// <summary>
		/// This method is used to check the date when retrieve from the database
		/// if date is "1/1/1900" then pass the blank values 
		/// </summary>
		public static string checkDate(string str)
		{
			if(!str.Trim().Equals(""))
			{
				if(str.Trim().Equals("1/1/1900"))
					str = "";
			}
			return str;
		}

		/// <summary>
		/// This method is used to Return Date in DD/MM/YYYY for Display and Print Input is MM/DD/YYYY
		/// </summary>
		public static string str2DDMMYYYY(string  str)
		{
			if(!str.Trim().Equals(""))  
			{
				string[] strTokens = str.Split(new char[] {'/'},str.Length);
				return strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
			}
			else
				return "";
		}

		/// <summary>
		/// This method is used to Return Date in MM/DD/YYYY for Display and Print Input is DD/MM/YYYY
		/// </summary>
		public static string str2MMDDYYYY(string  str)
		{
			if(!str.Trim().Equals(""))  
			{
				string[] strTokens = str.Split(new char[] {'/'},str.Length);
				return strTokens[1] + "/" + strTokens[0] + "/" + strTokens[2];
			}
			else
				return "";
		}
		
		/// <summary>
		/// This method is used to return the date without time.
		/// </summary>
		public static string trimDate(string  str)
		{
			if(str.Trim().IndexOf(" ")> -1)  
			{
				str = str.Substring(0,str.Trim().IndexOf(" "));   
			}
			return str;
		}

		/// <summary>
		/// This method is used to trim the spaces according to length.
		/// </summary>
		public static string TrimLength(string str,int len)
		{
			if(str.Length > len)
			{
				str = str.Substring(0,len); 
			}
			return str;
		}

		/// <summary>
		/// This method is used to retrieve the address from the organization table.
		/// </summary>
		public static string GetAddress()
		{
			InventoryClass  obj=new InventoryClass ();
			SqlDataReader SqlDtr;
			string sql,str="";
			sql="select DealerName,DealerShip,Address,TinNo,PhoneNo,Message from organisation";
			SqlDtr=obj.GetRecordSet(sql);
			if(SqlDtr.Read())
			{
				str=SqlDtr.GetValue(0).ToString()+':'+SqlDtr.GetValue(1).ToString()+':'+SqlDtr.GetValue(2).ToString()+':'+SqlDtr.GetValue(3).ToString()+':'+SqlDtr.GetValue(4).ToString()+':'+SqlDtr.GetValue(5).ToString();
			}
			else
				str="";
			SqlDtr.Close();
			return(str);
		}
		
		/// <summary>
		/// This method is used to find the center of given address according to given length.
		/// </summary>
		public static string GetCenterAddr(string Addr,int Len)
		{
			int address=Addr.Length;
			int ss=0;
			string sp="";
			if(Len > Addr.Length)
				ss=(Len-address)/2;
			else
				ss=0;
			for(int i=0;i<ss;i++)
			{
				sp=sp+" ";
			}
			return sp+Addr;
		}

		/// <summary>
		/// This method is used to convert the passing value(number) in words
		/// </summary>
		public static string ConvertNoToWord(string number)
		{
			string[] num=new string[2];
			int count=0,div=0;
			if(number.IndexOf(".")>0)
			{
				num=number.Split(new char[] {'.'},number.Length);
				div=System.Convert.ToInt32(num[0]);
			}
			else
				div=System.Convert.ToInt32(number);
				
			int[] arr1=new int[12];
			int[] arr2=new int[12];
	
			String[] digit1={"ZERO","ONE","TWO","THREE","FOUR","FIVE","SIX","SEVEN","EIGHT","NINE","TEN","ELEVAN","TWELVE","THRTEEN","FOURTEEN","FIFTEEN","SIXTEEN","SEVENTEEN","EIGHTEEN","NINETEEN","TWENTY","THIRTY","FOURTY","FIFTY","SIXTY","SEVENTY","EIGHTY","NINTY"};
			String[] digit2 ={"","hundred","thousand","lakh","crore"};   
			String[] array=new String[20];
			//count digit
			while(div>0)
			{
				arr1[count]=div%10;
				div=div/10;
				count++;
			}
		
			if(count>=10)
			{
				MessageBox.Show("please Enter Nine Digit Number");
				//array[0]="ZERO";
				//return (array);
			}
		
			if(count==0)
			{
				//System.out.println("ZERO");
				array[0]="ZERO";
			}
			//set place
			div=System.Convert.ToInt32(num[0]);
			for(int i=count-1;i>=0;--i)
			{
				if(i==1||i==4||i==6||i==8)
				{
					arr2[i]=arr1[i]*10;
				}
				else
				{
					arr2[i]=arr1[i];
				}
			}
	  
	  
			for(int i=count-1,j=0;i>=0;++j,--i)
			{
				if(i==8&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						//System.out.print(digit1[dig/10+18]+" ");
						array[j]=digit1[dig/10+18];
						//System.out.print(digit2[4]+" ");
						array[j+1]=digit2[4];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						//System.out.print(digit1[dig/10+18]+" ");
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						//System.out.print(digit1[dig]+" ");
						array[j]=digit1[dig];
						//System.out.print(digit2[4]+" ");
						array[j+1]=digit2[4];
						--i;
						++j;
					}
			  		 
				}
				else if(i==7)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						//  System.out.print(digit1[dig]+" ");
						array[j]=digit1[dig];
						//System.out.print(digit2[4]+" ");
						array[j+1]=digit2[4];
						++j;
					}
				}
				else if(i==6&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						//	  System.out.print(digit1[dig/10+18]+" ");
						array[j]=digit1[dig/10+18];
						//	  System.out.print(digit2[3]+" ");
						array[j+1]=digit2[3];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						//	 System.out.print(digit1[dig/10+18]+" ");
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						//	  System.out.print(digit1[dig]+" ");
						array[j]=digit1[dig];
						//	  System.out.print(digit2[3]+" ");
						array[j+1]=digit2[3];
						--i;
						++j;
					}
			  		 
				}
				else if(i==5)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						//System.out.print(digit1[dig]+" ");
						array[j]=digit1[dig];
						//System.out.print(digit2[3]+" ");
						array[j+1]=digit2[3];
						++j;
					}
				}
				else if(i==4&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						//  System.out.print(digit1[dig/10+18]+" ");
						array[j]=digit1[dig/10+18];
						//System.out.print(digit2[2]+" ");
						array[j+1]=digit2[2];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						//System.out.print(digit1[dig/10+18]+" ");
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						// System.out.print(digit1[dig]+" ");
						array[j]=digit1[dig];
						//System.out.print(digit2[2]+" ");
						array[j+1]=digit2[2];
						--i;
						++j;
					}
			  
				}

				else if(i==3)
				{
					if(arr2[i]!=0)
					{			
						int dig=arr2[i]; 
						//System.out.print(digit1[dig]+" ");
						array[j]=digit1[dig];
						//			   System.out.print(digit2[2]+" ");
						array[j+1]=digit2[2];
						++j;
					}
			
				}
				else if(i==2)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						//				  System.out.print(digit1[dig]+" ");
						array[j]=digit1[dig];
						//			      System.out.print(digit2[1]+" ");
						array[j+1]=digit2[1];
						++j;
					}
			 			  
				}
				else if(i==1)
				{
					int dig=arr2[i];
					if(dig>=20&&arr2[i]!=0&&arr2[i-1]==0)
					{
						dig=arr2[i];
						//				System.out.print(digit1[dig/10+18]+" ");
						array[j]=digit1[dig/10+18];
						--i;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						//			    System.out.print(digit1[dig/10+18]+" ");
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						//				  System.out.println(digit1[dig]);
						array[j]=digit1[dig];
						--i;
					}
			  
				}
				else if(i==0)
				{
					int dig=arr2[i];
					if(arr2[i]!=0)
					{
						//			   System.out.print(digit1[dig]+" ");
						array[j]=digit1[dig];
					}
				}
			}    
			string no="";
			for(int i=0;i<array.Length;i++)
			{
				if(array[i]!=null)

					no=no+StringUtil.FirstCharUpper(array[i])+" ";
			}
			//return (array);
			return (no+"Only");
			/*
			int m=0,n=0;
			string[] p=new string[1];
			if(no.IndexOf(".")>0)
			{
				p=no.Split(new char[] {'.'},no.Length);
				n=System.Convert.ToInt32(p[0]);
			}
			else
			{
				n=System.Convert.ToInt32(no);
			}
			string str="",str1="Rupees";
			while(n>0)
			{
				m=n%10;
				n=n/10;
				switch(m)
				{
					case 0:
						str="Zero";
						break;
					case 1:
						str="One";
						break;
					case 2:
						str="Two";
						break;
					case 3:
						str="Three";
						break;
					case 4:
						str="Four";
						break;
					case 5:
						str="Five";
						break;
					case 6:
						str="Six";
						break;
					case 7:
						str="Seven";
						break;
					case 8:
						str="Eight";
						break;
					case 9:
						str="Nine";
						break;
				}
				str1=str+" "+str1;
			}
			return (str1);
			*/
		}
	}
}