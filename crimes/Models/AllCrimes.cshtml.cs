using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AllCrimesModel : PageModel  
    {  
        public List<Models.CrimeCode> CrimeCodeList { get; set; }
				public Exception EX { get; set; }
                public int totalCrimes { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.CrimeCode> Crimes = new List<Models.CrimeCode>();
					
					// clear exception:
					EX = null;
					
					try                                                  
					{
                        totalCrimes=0;
                        
                        string sql = string.Format(@"
	SELECT Crimes.IUCR, PrimaryDesc, SecondaryDesc, Count(*) AS numTimes 
	FROM Crimes
	INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
	GROUP BY Crimes.IUCR, PrimaryDesc, SecondaryDesc
	ORDER BY PrimaryDesc, SecondaryDesc ASC;
	");
    
						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                        
                          
                        foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.CrimeCode m = new Models.CrimeCode();

							m.IUCR = Convert.ToString(row["IUCR"]);
							m.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);
							m.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]);
							m.numCrimes = Convert.ToInt32(row["numTimes"]);
                                                        
							Crimes.Add(m);
                            totalCrimes++;
						}
   
                        
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
                    CrimeCodeList = Crimes;  
                    }
        }  
				
    }//class
}//namespace