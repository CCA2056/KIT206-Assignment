using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public enum PublicationType {Conference, Journal, Other };
    public class Publication
    {
        public string DOI { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public int Year { get; set; }
        public DateTime Available { get; set; }
        public PublicationType Type { get; set; } 
        public string Cite_as { get; set; }
        public int Age { get { return getAge(); } set { Age = Age; } }

        public int getAge()
        {
            int today = DateTime.Today.Year;
            int duration = today - Year;
            return duration;
        }

        public override string ToString()
        {
            return "<" + Title + "> by: " + Authors;
        }
    }
}
