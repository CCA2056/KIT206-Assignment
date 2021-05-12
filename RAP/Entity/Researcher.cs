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
        public string Level { get; set; }

        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public Position GetCurrentJob()
        {
            Position CurrentJob;
            CurrentJob = Position.First();
            foreach (Position Job in Position)
            {
                if (CurrentJob.StartDate < Job.StartDate)
                {
                    CurrentJob = Job;
                }
            }
            return CurrentJob;

        }

        /*public string CurrentJobTitle()
        {
            return GetCurrentJob().Ttile;
        }*/

        public DateTime CurrentJobStartDate()
        {
            return GetCurrentJob().StartDate;
        }

        public Position GetEarliestJob()
        {
            Position EariliestJob;
            EariliestJob = Position.First();
            foreach (Position Job in Position)
            {
                if (EariliestJob.StartDate < Job.StartDate)
                {
                    EariliestJob = Job;
                }
            }
            return EariliestJob;

        }

        public DateTime EarliestStart()
        {
            return GetEarliestJob().StartDate;
        }

        public float Tenure()
        {
            float day = ((DateTime.Today.Day) - (EarliestStart()).Day);
            return day;
        }

        public int PublicationCount()
        {
            return Publication.Count;
        }

    }
}
