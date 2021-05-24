using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public class Staff : Researcher
    {
        public List<Student> Supervision { get; set; }

        public string Performance { get; set; }
        public int PublicationCount
        {
            get
            {
                return Publication.Count;
            }
            
        }

        public int Count3year
        {
            get
            {
                return Publication.Count(p => p.Year > DateTime.Today.Year - 3);
            }
        }

        public float ThreeYearAverage
        {
            get
            {
                return Count3year/3;
            }
            
        }
    }
}
