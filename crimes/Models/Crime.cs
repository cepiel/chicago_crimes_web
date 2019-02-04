using System; 
//
// One crime object
//

namespace crimes.Models
{

  public class Crime
	{
	
		// data members with auto-generated getters and setters:      
      public string IUCR { get; set; }
      public string PrimaryDesc { get; set; }
      public string SecondaryDesc { get; set; }
      public int numTimes { get; set; }
      public double percentChicago { get; set; }
      public double arrestRate { get; set; }
      
		// default constructor:
		public Crime()
		{ }
		
		// constructor:
		public Crime(string iucr, string primaryD, string secondaryD, int times, double percent, double arrestR )     
		{
			IUCR = iucr;
			PrimaryDesc = primaryD;
			SecondaryDesc = secondaryD;
			numTimes = times;
            percentChicago = percent;
            arrestRate = arrestR;
            
		}
      
      public Crime(string iucr, string primaryD, string secondaryD, int times )     
		{
			IUCR = iucr;
			PrimaryDesc = primaryD;
			SecondaryDesc = secondaryD;
			numTimes = times;
            
		}
 
	}//class

}//namespace