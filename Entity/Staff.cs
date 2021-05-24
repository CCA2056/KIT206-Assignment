using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    class Staff : Researcher
    {
        public int PublicationCount3yr()
        {
            return Publication.Count(p => p.Year > DateTime.Today.Year - 3);
        }

        public float ThreeYearAverage()
        {
            return (PublicationCount3yr()) * 3;
        }

        public float Performance()
        {
            return 0; //PublicationCount3yr() ;
        }
    }
}
