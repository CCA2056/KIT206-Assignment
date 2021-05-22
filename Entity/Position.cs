using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    public enum EmploymentLevel { All, Student, A, B, C, D, E}
    public class Position
    {
        public int id { get; set; }
        public EmploymentLevel Level { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }

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

        public override string ToString()
        {
            if(DateTime.Compare(EndDate, Convert.ToDateTime("01/01/1900")) == 0)
            {
                return "Position Level: " + Level + ", StartDate: " + StartDate.ToString("d") + ", EndDate: Current";
            }
            else
            {
                return "Position Level: " + Level + ", StartDate: " + StartDate.ToString("d") + ", EndDate: " + EndDate.ToString("d");
            }
           
        }

        public string Ttile (string Ttile)
        {
            return Ttile.ToString();
        }
    }
}


