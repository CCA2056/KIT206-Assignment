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
        public string Titile { get; set; }
        public string Authors { get; set; }
        public int Year { get; set; }
        public DateTime Available { get; set; }
        public PublicationType Type { get; set; } 
        public string Cite_as { get; set; }

        public int Age(Publication pub)
        {
            int today = DateTime.Today.Year;
            int duration = today - pub.Year;
            return duration;
        }

        

        
    }
}
