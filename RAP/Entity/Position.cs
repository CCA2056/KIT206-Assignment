using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    public enum EmploymentLevel { Student, A, B, C, D, E}
    class Position
    {
        public EmploymentLevel Level { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ToTitle(EmploymentLevel Emplvl)
        {
            if(Emplvl.ToString() == "A")
            {
                return "Postdoc";
            }
            else if(Emplvl.ToString() == "B")
            {
                return "Lecturer";
            }
            else if (Emplvl.ToString() == "C")
            {
                return "Senior Lecturer";
            }
            else if (Emplvl.ToString() == "D")
            {
                return "Associate Professor";
            }
            else
            {
                return "Professor";
            }
        }

        public string Ttile (string Ttile)
        {
            return Ttile.ToString();
        }
    }
}


