using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    public class ResearcherController
    {
        List<Researcher> researchers;
        Researcher researcher;
        public List<Position> positions;
        Position position;

        int PubCount3yr { get; set; }
        float average3yr { get; set; }
        string performance;
        public string Performance { get { return performance; } set { Performance = performance; } }
        public float Average3year { get { return average3yr; } set { Average3year = average3yr; } }

        private ObservableCollection<Researcher> viewableResearcher;

        public ObservableCollection<Researcher> VisibleWorkers { get { return viewableResearcher; } set { } }

        private ObservableCollection<Position> viewablePosition;

        public ObservableCollection<Position> VisiblePositions { get { return viewablePosition; } set { } }

        public ResearcherController()
        {

            LoadResearchers();
            loadSupervisor();
            LoadPositions();
            loadSupervision();
            loadPublication();
        }


        public void LoadResearchers()
        {
            researchers = DBconnect.LoadAll();

            viewableResearcher = new ObservableCollection<Researcher>(researchers);
        }



        public void getDetail(Researcher selected)
        {
            researcher = selected;
        }


        public ObservableCollection<Researcher> GetViewableList()
        {
            return VisibleWorkers;
        }



        public void FilterByLevel(EmploymentLevel level)
        {

            var selected = from Researcher res in researchers
                           where res.Level == level || level == EmploymentLevel.All
                           select res;

            viewableResearcher.Clear();
            selected.ToList().ForEach(viewableResearcher.Add);

        }

        public void FilterByName(string name) {

            var filtered = from Researcher res in researchers
                           where (res.GivenName.Contains(name)) || (res.FamilyName.Contains(name))
                           select res;
            viewableResearcher.Clear();
            filtered.ToList().ForEach(viewableResearcher.Add);
        }


        public void LoadPositions()
        {
            var selected = from Researcher s in researchers
                           where s.Level != EmploymentLevel.Student
                           select s;
            foreach(Staff s in selected)
            {
                s.Position = DBconnect.getPosition(s);
            }
           
        }

        public void getPositionDetail(Position selected)
        {
            position = selected;
            var temp = from Position pos in researcher.Position
                       where pos.Level == selected.Level
                       select pos;

            viewablePosition.Clear();
            temp.ToList().ForEach(viewablePosition.Add);
        }


        public ObservableCollection<Position> GetViewablePos()
        {
            return VisiblePositions;
        }

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

        public void loadPublication()
        {
            foreach (Researcher s in researchers)
            {
                s.Publication = DBconnect.getPublication(s);
            }
        }



        /*        public int PublicationCount(Staff r)
                {
                    return r.Publication.Count;
                }

                public int Count3year(Staff r)
                {
                    return r.Publication.Count(p => p.Year > DateTime.Today.Year - 3);
                }

                public float ThreeYearAverage(Staff r)
                {
                    return (Count3year(r)) / 3;
                }


                public string PerformCal(Staff r)
                {
                    float score = 0;

                    switch (r.Level)
                    {
                        case EmploymentLevel.A:
                            score = (float)(ThreeYearAverage(r) / 0.5);
                            break;
                        case EmploymentLevel.B:
                            score = (float)(ThreeYearAverage(r) / 1);
                            break;
                        case EmploymentLevel.C:
                            score = (float)(ThreeYearAverage(r) / 2);
                            break;
                        case EmploymentLevel.D:
                            score = (float)(ThreeYearAverage(r) / 3.2);
                            break;
                        case EmploymentLevel.E:
                            score = (float)(ThreeYearAverage(r) / 4);
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
                }*/



    }
}
