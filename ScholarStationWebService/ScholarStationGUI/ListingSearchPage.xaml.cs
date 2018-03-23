using System;
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
using DataAccess;
using DataClasses;

namespace ScholarStationGUI
{
    /// <summary>
    /// Interaction logic for ListingSearchPage.xaml
    /// </summary>
    public partial class ListingSearchPage : Page
    {
        List<Listing> myList;


        DataManager manager;

        public ListingSearchPage(DataManager man)
        {
            InitializeComponent();


            manager = man;

            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UniversityBox.ItemsSource = manager.getUniversities();
            UniversityBox.SelectedIndex = 0;
            TypeBox.ItemsSource = manager.getTypes();
            TypeBox.SelectedIndex = 0;
            SubjectBox.ItemsSource = manager.getSubjects();
            SubjectBox.SelectedIndex = 0;

            getListings();
        }

        private void getListings()
        {
            //int listingType = TypeBox.Text.Equals(manager.getTypes()[0]) ? 1 : 2;
            ListingView.ItemsSource = manager.AccessListingStorage().getMatchingListings(null, -1, null, -1, null, UniversityBox.Text);//SubjectBox.Text, UniversityBox.Text);
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            getListings();
        }
    }
}
