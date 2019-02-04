using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesTop10Model : PageModel  
    {  
        public List<Models.Crime> CrimeList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Crime> Crimes = new List<Models.Crime>();
					
					// clear exception:
					EX = null;
					
					try                                                  
					{

                        string sql = string.Format(@"
	SELECT TOP 10 Crimes.IUCR, PrimaryDesc, SecondaryDesc, Count(*) AS numTimes 
	FROM Crimes
	INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
	GROUP BY Crimes.IUCR, PrimaryDesc, SecondaryDesc
	ORDER BY numTimes DESC;
	");
    
						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                        
                        //now for the total number of crimes
                        string sql2 = string.Format(@"
SELECT Count(*) AS total
FROM Crimes;
");
                        object result = DataAccessTier.DB.ExecuteScalarQuery(sql2);
                        double totalCrimes = Convert.ToDouble(result);
                        
                        //now for the arrested
                        string sql3 = string.Format(@"
SELECT IUCR, Count(Arrested) as Arrested
From Crimes
Where Arrested=1
Group by IUCR
");
                        DataSet ds2 = DataAccessTier.DB.ExecuteNonScalarQuery(sql3);
                        
                        
                        foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crime m = new Models.Crime();

							m.IUCR = Convert.ToString(row["IUCR"]);
							m.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);
							m.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]);
							m.numTimes = Convert.ToInt32(row["numTimes"]);
                            m.percentChicago = m.numTimes/totalCrimes;
                                                        
							Crimes.Add(m);
						}
                        
                        foreach (DataRow row in ds2.Tables["TABLE"].Rows) //this ds has all the crimes IUCRs and arrest numbers
						{
                            string iucr = Convert.ToString(row["IUCR"]);
                            double arrested = Convert.ToDouble(row["Arrested"]);
                            
                            foreach(Models.Crime c in Crimes) //search if this iucr is in our top 10 crimes list
                            {
                                if(c.IUCR == iucr){ //if the iucr is found in our top 10, assign its arrested number
                                    c.arrestRate = ((arrested/c.numTimes) *100);
                                    
                                }
                            }
                        }
                        
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
                    CrimeList = Crimes;  
                    }
        }  
				
    }//class
}//namespace