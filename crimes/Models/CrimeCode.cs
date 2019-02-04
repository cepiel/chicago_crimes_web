using System; 
//
// One AREA object
//

namespace crimes.Models
{

  public class CrimeCode
	{
	
		// data members with auto-generated getters and setters:      
      public string IUCR { get; set; }
      public string PrimaryDesc { get; set; }
      public string SecondaryDesc { get; set; }
      public int numCrimes { get; set; }
      
		// default constructor:
		public CrimeCode()
		{ }
		
		// constructor:
		public CrimeCode(string iucr, string prim, string sec, int num )     
		{
			IUCR = iucr;
			PrimaryDesc = prim;
			SecondaryDesc = sec;
            numCrimes = num;
            
		}
      

      
 
 
	}//class

}//namespace