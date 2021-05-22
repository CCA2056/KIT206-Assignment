using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    public class Researcher
    {
        public List<Position> Position { get; set; }
        public List<Publication> Publication { get; set; }
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Unit { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }       
        public string Photo { get; set; }
        public string Degree { get; set; }
        public EmploymentLevel Level { get; set; }
        public DateTime EarliestStart { get; set; }
        public DateTime CurrentJobStartDate { get; set; }




        public string CurrentJob
        {
            get
            {
                if (Level.ToString() == "A")
                {
                    return "Postdoc";
                }
                else if (Level.ToString() == "B")
                {
                    return "Lecturer";
                }
                else if (Level.ToString() == "C")
                {
                    return "Senior Lecturer";
                }
                else if (Level.ToString() == "D")
                {
                    return "Associate Professor";
                }
                else
                {
                    return "Professor";
                }
            }
            

        }


        public Position GetEarliestJob(List<Position> pos)
        {
            Position EariliestJob;
            EariliestJob = pos.First();
            foreach (Position Job in pos)
            {
                if (EariliestJob.StartDate > Job.StartDate)
                {
                    EariliestJob = Job;
                }
            }
            return EariliestJob;

        }


        public float Tenure
        {
            get
            {
                TimeSpan ts = ((DateTime.Now).Subtract(EarliestStart));
                double day = ts.TotalDays;
                return (float)day;
            }

        }

       

        public override string ToString()
        {
            return GivenName + " " + FamilyName + " " + Title;
        }
    }
}
