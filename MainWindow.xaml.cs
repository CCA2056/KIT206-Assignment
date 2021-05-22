﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RAP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string RESEARCHER_LIST_KEY = "researcherList";
        private const string RESEARCHER_DETAIL_KEY = "researcherDetail";
        private const string POSITION_KEY = "positionList";
        private ResearcherController researcherController;

        public MainWindow()
        {
            InitializeComponent();
            researcherController = (ResearcherController)(Application.Current.FindResource(RESEARCHER_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Researcher selected = e.AddedItems[0] as Researcher;
                researcherController.getDetail(selected);
                researcherDetailPanel.DataContext = e.AddedItems[0];
                //MessageBox.Show(selected.Publication[0].ToString());
            }

        }

        private void filterName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                researcherController.FilterByName(filterName.Text);
            }
        }

        private void SelectLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                researcherController.FilterByLevel((EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), e.AddedItems[0].ToString()));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}