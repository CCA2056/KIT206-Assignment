using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Entity;

namespace RAP.Controller
{
    //this class is for controller of researchers
    public class ResearcherController
    {
        List<Researcher> researchers;
        Researcher researcher;
        public List<Position> positions;
        Position position;

        int PubCount3yr { get; set; }
        float average3yr { get; set; }

        public float Average3year { get { return average3yr; } set { Average3year = average3yr; } }

        private ObservableCollection<Researcher> viewableResearcher;

        public ObservableCollection<Researcher> VisibleWorkers { get { return viewableResearcher; } set { } }


        public ResearcherController()
        {

            LoadResearchers();
            loadSupervisor();
            LoadPositions();
            loadSupervision();
            loadPublication();
            PerformCal();
        }

        // talk to the DBconnector and load the researchers from database
        public void LoadResearchers()
        {
            researchers = DBconnect.LoadAll();

            viewableResearcher = new ObservableCollection<Researcher>(researchers);
        }

        
        // it is called getDetail but what it really does is assign researcher...
        public void getDetail(Researcher selected)
        {
            researcher = selected;
        
        }


        public ObservableCollection<Researcher> GetViewableList()
        {
            return VisibleWorkers;
        }


        // filter by Level function
        public void FilterByLevel(EmploymentLevel level)
        {

            var selected = from Researcher res in researchers
                           where res.Level == level || level == EmploymentLevel.All
                           select res;

            viewableResearcher.Clear();
            selected.ToList().ForEach(viewableResearcher.Add);

        }
        // search by key word (name) function, allows partial match, but Case Sensitive
        public void FilterByName(string name)
        {

            var filtered = from Researcher res in researchers
                           where (res.GivenName.Contains(name)) || (res.FamilyName.Contains(name))
                           select res;
            viewableResearcher.Clear();
            filtered.ToList().ForEach(viewableResearcher.Add);
        }

        // assign the position lists to each researcher
        public void LoadPositions()
        {
            var selected = from Researcher s in researchers
                           where s.Level != EmploymentLevel.Student
                           select s;
            foreach (Staff s in selected)
            {
                s.Position = DBconnect.getPosition(s);
            }

        }

        // assign the supervisor's name to each student
        public void loadSupervisor()
        {
            var selected = from Researcher s in researchers
                           where s.Level == EmploymentLevel.Student
                           select s;
            foreach (Student s in selected)
            {
                s.Supervisor = DBconnect.getSupervisor(s);
            }
        }
        // assign the supervisions to each staff
        public void loadSupervision()
        {
            var selected = from Researcher s in researchers
                           where s.Level != EmploymentLevel.Student
                           select s;
            foreach (Staff s in selected)
            {
                s.Supervision = DBconnect.getSupervision(s);
            }

        }
        // assign each researcher their publication list
        public void loadPublication()
        {
            foreach (Researcher s in researchers)
            {
                s.Publication = DBconnect.getPublication(s);
            }
        }

        // return the publication number of a staff
        public int PublicationCount(Staff r)
        {
            return r.Publication.Count;
        }
        // count the 3 year average publication number of a researcher
        public float ThreeYearAverage(Staff r)
        {
            return (r.Publication.Count(p => p.Year > DateTime.Today.Year - 3))/ 3;
        }

        // calculate performance and assign it to each staff
        public void PerformCal()
        {
            float score = 0;
            var selected = from Researcher r in researchers
                           where r.Level != EmploymentLevel.Student
                           select r;
            foreach(Staff s in selected)
            {
                switch (s.Level)
                {
                    case EmploymentLevel.A:
                        score = (float)(ThreeYearAverage(s) / 0.5);
                        
                        break;
                    case EmploymentLevel.B:
                        score = (float)(ThreeYearAverage(s) / 1);
                        break;
                    case EmploymentLevel.C:
                        score = (float)(ThreeYearAverage(s) / 2);
                        break;
                    case EmploymentLevel.D:
                        score = (float)(ThreeYearAverage(s) / 3.2);
                        break;
                    case EmploymentLevel.E:
                        score = (float)(ThreeYearAverage(s) / 4);
                        break;
                }
                if (score <= 0.7)
                {
                    s.Performance = "Poor";
                }
                else if (score < 1.1)
                {
                    s.Performance = "Below Expectation";
                }
                else if (score < 2)
                {
                    s.Performance = "Meeting Minimum";
                }
                else
                {
                    s.Performance = "Star Performer";
                }
            }
               
        }
    }
}
