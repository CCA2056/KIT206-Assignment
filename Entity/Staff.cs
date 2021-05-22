using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    public class Staff : Researcher
    {
        public List<Student> Supervision { get; set; }
 

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
                return (Count3year) / 3;
            }
            
        }


        public string PerformCal
        {
            get
            {

                float score = 0;

                switch (Level)
                {
                    case EmploymentLevel.A:
                        score = (float)(ThreeYearAverage / 0.5);
                        break;
                    case EmploymentLevel.B:
                        score = (float)(ThreeYearAverage / 1);
                        break;
                    case EmploymentLevel.C:
                        score = (float)(ThreeYearAverage / 2);
                        break;
                    case EmploymentLevel.D:
                        score = (float)(ThreeYearAverage / 3.2);
                        break;
                    case EmploymentLevel.E:
                        score = (float)(ThreeYearAverage / 4);
                        break;
                }
                if (score <= 0.7)
                {
                    return "Poor";
                }
                else if (score < 1.1)
                {
                    return "Below Expectation";
                }
                else if (score < 2)
                {
                    return "Meeting Minimum";
                }
                else
                {
                    return "Star Performer";
                }

            }

        }

    }
}
