using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    public enum PublicationType {Conference, Journal, Other };
    class Publication
    {
        public string DOI { get; set; }
        public string titile { get; set; }
        public string authors { get; set; }
        public int year { get; set; }
        public DateTime available { get; set; }
        public PublicationType type { get; set; } 
        public string cite_as { get; set; }

        public int Age(Publication pub)
        {
            int today = DateTime.Today.Year;
            int duration = today - pub.year;
            return duration;
        }

        

        
    }
}
