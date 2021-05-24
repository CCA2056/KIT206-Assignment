﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Entity;

namespace RAP.Controller
{
    public class PublicationController
    {
        List<Publication> publications;
        Publication publication;
        Researcher researcher;

        private ObservableCollection<Publication> viewablePublication;

        public ObservableCollection<Publication> VisiblePublication { get { return viewablePublication; } set { } }

        public PublicationController()
        {

            LoadPublication();

        }

        public void LoadPublication()
        {

            publications = DBconnect.LoadAllPub();

            viewablePublication = new ObservableCollection<Publication>(publications);
        }

        public void LoadPublication(Researcher selected)
        {

            researcher.Publication = DBconnect.getPublication(selected);

            viewablePublication = new ObservableCollection<Publication>(publications);
        }

        public void getPubDetail(Publication selected)
        {
            publication = selected;
        }

        public ObservableCollection<Publication> GetViewablePubList()
        {
            return VisiblePublication;
        }



        public void YearRange(int fromYear, int toYear)
        {
            var selected = from Publication pub in publications
                           where pub.Year >= fromYear && pub.Year <= toYear
                           select pub;

            viewablePublication.Clear();
            selected.ToList().ForEach(viewablePublication.Add);

        }

    }
}
