﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Publication pub1 = new Publication();
            List<Publication> pub = Generate();
            pub1.Age(pub.First());
            Console.WriteLine(pub1.Age(pub.First()));
            Console.ReadLine();

        }


        public static List<Publication> Generate()
        {
            return new List<Publication>() {
             new Publication { DOI= "AAAAA", Title = "WWWWW", Authors = "SSSSSS", Year = 2010, Available = new DateTime (2019,01,02), Type = PublicationType.Conference, Cite_as = "FFFFFFF"  },
             new Publication { DOI= "BBBBB", Title = "XXXXX", Authors = "GGGGG", Year = 2011, Available = new DateTime (2019,02,02), Type = PublicationType.Journal, Cite_as = "JJJJJJJJJ"  },};
        }

        static void DisplayPosition(List<Position> pos)
        {
            foreach (Position p in pos)
            {
                Console.WriteLine(p);
                Console.ReadLine();
            }
        }



        /*public static List<Position> Generate()
        {
            return new List<Position>() {
                new Position { Level = EmploymentLevel.A, StartDate = new DateTime(2019,01,01), EndDate = new DateTime (2019,01,02), Title = "PostDr" },
                new Position { Level = EmploymentLevel.B, StartDate = new DateTime(2019,02,01), EndDate = new DateTime (2019,02,02), Title = "Dr" },
                new Position { Level = EmploymentLevel.A, StartDate = new DateTime(2019,03,01), EndDate = new DateTime (2019,03,02), Title = "Dr2" },

            };
        }

        static void DisplayPosition(List<Position> pos)
        {
            foreach (Position p in pos)
            {
                Console.WriteLine(p);
                Console.ReadLine();
            }
        }*/



    }
}
