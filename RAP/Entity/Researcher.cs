using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    class Researcher
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
        public EmploymentLevel Level { get; set; }

        public Position GetCurrentJob(List<Position> pos)
        {
            Position CurrentJob = pos.First();
            foreach (Position Job in pos)
            {
                if (CurrentJob.StartDate < Job.StartDate)
                {
                    CurrentJob = Job;
                }
            }
            return CurrentJob;

        }

        public string CurrentJobTitle(List<Position> pos)
        {
            return GetCurrentJob(pos).Title;
        }

        public DateTime CurrentJobStartDate(List<Position> pos)
        {
            return GetCurrentJob(pos).StartDate;
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

        public DateTime EarliestStart(List<Position> pos)
        {
            return GetEarliestJob(pos).StartDate;
        }

        //Need to convert TimeSpan to float
        public float Tenure(List<Position> pos)
        {
            TimeSpan ts = ((DateTime.Now).Subtract(EarliestStart(pos)));
            double day = ts.TotalDays;
            return (float)day;
        }

        public int PublicationCount(List<Publication> pub)
        {
            return pub.Count;
        }
        public override string ToString()
        {
            return GivenName + " " + FamilyName + " " + Title;
        }
    }
}
