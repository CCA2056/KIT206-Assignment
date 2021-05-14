using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    abstract class ResearcherController
    {
        // filter the researcher list by employment level
        public static List<Researcher> FilterByLevel(List<Researcher> researchers,EmploymentLevel level)
        {
            var filterLevel = from Researcher r in researchers
                            where r.Level == level
                            select r;
            return new List<Researcher>(filterLevel);
        }

        public static List<Researcher> FilterByName(List<Researcher> researchers, String name)
        {
            var filterLevel = from Researcher r in researchers
                              where (r.GivenName.Contains(name)) || (r.FamilyName.Contains(name))
                              select r;
            return new List<Researcher>(filterLevel);
        }
    }
}
