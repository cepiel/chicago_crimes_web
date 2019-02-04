using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class GetAreaModel : PageModel  
    {  
				public List<Models.Crime> CrimeList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
                
                public string arName { get; set; }
                public int arNum { get; set; }
  
        public void OnGet(string input)  
        {  
				  List<Models.Crime> Crimes = new List<Models.Crime>();
					
					// make input available to web page:
					Input = input;
					
					// clear exception:
					EX = null;
					
					try
					{
						//
						// Do we have an input argument?  If so, we do a lookup:
						//
						if (input == null)
						{
							//
							// there's no page argument, perhaps user surfed to the page directly?  
							// In this case, nothing to do.
							//
						}
						else  
						{
							// 
							// Lookup movie(s) based on input, which could be id or a partial name:
							// 
							int id;
							string sql;
                            string sql2; string sql3;
                            
                            //output top 10 crimes in this area of the city!
                            //DISPLAY same info as you did in part 1
                            //
                            //page should ALSO display the area name and number so its clear 
                            //
                            //if user enters an area that doesn't exist, say so!
  
  
                                                                          //inner join as before or LEFT join as was found here?
							if (System.Int32.TryParse(input, out id))     //input was the area ID number
							{
								// lookup movie by movie id:
								sql = string.Format(@"
	SELECT TOP 10 Crimes.IUCR, PrimaryDesc, SecondaryDesc, Count(*) AS numTimes, Areas.AreaName, Crimes.Area
	FROM Crimes
	LEFT JOIN Codes ON Crimes.IUCR = Codes.IUCR
    INNER JOIN Areas ON Crimes.Area = Areas.Area
	WHERE Crimes.Area = {0}
	GROUP BY Crimes.IUCR, PrimaryDesc, SecondaryDesc, Crimes.Area, Areas.AreaName
	ORDER BY numTimes DESC;
	", id);
    
                                 //now for the total number of crimes
                            sql2 = string.Format(@"
    SELECT Count(*) AS total
    FROM Crimes
    WHERE Area = {0};
    ", id);

                                sql3 = string.Format(@"
    SELECT IUCR, Count(Arrested) as Arrested
    From Crimes
    Where Arrested=1 AND Area = {0}
    Group by IUCR;
    ", id);

							}
							else
							{
								// lookup movie(s) by partial name match:
								input = input.Replace("'", "''");

								sql = string.Format(@"
	SELECT TOP 10 Crimes.IUCR, PrimaryDesc, SecondaryDesc, Count(*) AS numTimes, Areas.AreaName, Crimes.Area
	FROM Crimes
	LEFT JOIN Codes ON Crimes.IUCR = Codes.IUCR
    INNER JOIN Areas ON Crimes.Area = Areas.Area
	WHERE Areas.AreaName LIKE '%{0}%'
	GROUP BY Crimes.IUCR, PrimaryDesc, SecondaryDesc, Crimes.Area, Areas.AreaName
	ORDER BY numTimes DESC;
	", input);
    
                                 //now for the total number of crimes
                            sql2 = string.Format(@"
    SELECT Count(*) AS total
    FROM Crimes
    INNER JOIN Areas ON Crimes.Area = Areas.Area
    WHERE Areas.AreaName = '%{0}%';
    ", input);
    
                            //now for the arrested rate
                            sql3 = string.Format(@"
    SELECT IUCR, Count(Arrested) as Arrested
    From Crimes
    INNER JOIN Areas  ON Crimes.Area = Areas.Area
    Where Arrested=1 AND Areas.AreaName LIKE '%{0}%'
    Group by IUCR;
    ", input);
    
    
							}

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

                        object result = DataAccessTier.DB.ExecuteScalarQuery(sql2);
                        double totalCrimes = Convert.ToDouble(result);
                        
                        DataSet ds2 = DataAccessTier.DB.ExecuteNonScalarQuery(sql3);
                        


                        foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crime m = new Models.Crime();

							m.IUCR = Convert.ToString(row["IUCR"]);
							m.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);
							m.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]);
							m.numTimes = Convert.ToInt32(row["numTimes"]);
                            m.percentChicago = m.numTimes/totalCrimes;
                           
                            arName = Convert.ToString(row["AreaName"]);
                            arNum = Convert.ToInt32(row["Area"]);
                            
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
                        } //end for each
                        
					} 
                    }//end try stmt
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