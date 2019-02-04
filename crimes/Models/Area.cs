using System; 
//
// One AREA object
//

namespace crimes.Models
{

  public class Area
	{
	
		// data members with auto-generated getters and setters:      
      public string AreaName { get; set; }
      public int AreaNum { get; set; }
      public int numCrimes { get; set; }
      public double percentChicago { get; set; }
      
		// default constructor:
		public Area()
		{ }
		
		// constructor:
		public Area(string aname, int anum, int times, double percent )     
		{
			AreaName = aname;
			AreaNum = anum;
			numCrimes = times;
            percentChicago = percent;
            
		}
      
      public Area(string aname, int anum )     
		{
			AreaName = aname;
			AreaNum = anum;
            
		}
      
 
 
	}//class

}//namespace