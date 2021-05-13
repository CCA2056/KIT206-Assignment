using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    class Staff : Researcher
    {
        public int Supervision { get; set; }
        public int PublicationCount3yr()
        {
            return Publication.Count(p => p.Year > DateTime.Today.Year - 3);
        }

        public float ThreeYearAverage()
        {
            return (PublicationCount3yr()) / 3;
        }

        public string Performance()
        {
            float score = 0;

            switch(Level)
            {
                case EmploymentLevel.A:
                    score = (float)(ThreeYearAverage() / 0.5);
                    break;
                case EmploymentLevel.B:
                    score = (float)(ThreeYearAverage() / 1);
                    break;
                case EmploymentLevel.C:
                    score = (float)(ThreeYearAverage() / 2);
                    break;
                case EmploymentLevel.D:
                    score = (float)(ThreeYearAverage() / 3.2);
                    break;
                case EmploymentLevel.E:
                    score = (float)(ThreeYearAverage() / 4);
                    break;
            }
            if (score <= 0.7)
            {
                return "Poor";
            }
            else if(score < 1.1)
            {
                return "Below Expectation";
            }
            else if(score < 2)
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
