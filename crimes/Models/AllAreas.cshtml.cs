using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AllAreasModel : PageModel  
    {  
        public List<Models.Area> AreaList { get; set; }
				public Exception EX { get; set; }
                public int totalAreas { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Area> Areas = new List<Models.Area>();
					
					// clear exception:
					EX = null;
					
					try                                                  
					{
                        totalAreas=0;
                        
                        string sql = string.Format(@"
	SELECT AreaName, Area
    FROM Areas
    ORDER BY AreaName ASC;
	");
    
                        string sql2 = string.Format(@"
	SELECT Count(*) as numTimes, AreaName
    FROM Crimes
    INNER JOIN Areas ON Crimes.Area = Areas.Area
    GROUP BY AreaName
    ORDER BY AreaName
	");
    
                        string sql3 = string.Format(@"
    SELECT Count(*) AS total
    FROM Crimes;
    ");
                        object result = DataAccessTier.DB.ExecuteScalarQuery(sql3);
                        double totalCrimes = Convert.ToDouble(result);
    
    
						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                        
                        DataSet ds2 = DataAccessTier.DB.ExecuteNonScalarQuery(sql2);
                        
                          
                        foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Area m = new Models.Area();

							m.AreaName = Convert.ToString(row["AreaName"]);
							m.AreaNum = Convert.ToInt32(row["Area"]);
                    
							Areas.Add(m);
                            totalAreas++;
						}
                        
                        foreach (DataRow row in ds2.Tables["TABLE"].Rows)
						{                            
							double numcrimes = Convert.ToDouble(row["numTimes"]);
                            string area = Convert.ToString(row["AreaName"]);
                            
                            //double percentChicago = Convert.ToDouble(row["Area"]);
                            
                            foreach(Models.Area c in Areas) 
                            {
                                if(c.AreaName == area){ 
                                    c.numCrimes = (int)numcrimes;
                                    c.percentChicago = ((numcrimes/totalCrimes) *100);
                                    
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
                        AreaList = Areas;  
                    }
        }  
				
    }//class
}//namespace