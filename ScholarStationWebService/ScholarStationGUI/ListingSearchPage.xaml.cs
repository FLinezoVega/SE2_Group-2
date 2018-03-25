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
        string selectedUserName;

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
            try
            {
                ListingView.ItemsSource = manager.AccessListingStorage().getMatchingListings(null, -1, null, -1, "", UniversityBox.Text);//SubjectBox.Text, UniversityBox.Text);   
                //ListingView.SelectedIndex = 0;
                //System.Diagnostics.Debug.WriteLine("xxxx" + SubjectBox.Text + "xxxx");
            }
            catch (Exception e)
            {
              //  MessageBox.Show("Could not load listings", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            getListings();
        }


        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Listing l = e.AddedItems[0] as Listing;
            selectedUserName = l.Author;
            ViewAppointmentButton.IsEnabled = true;
        }

        private void NavigateToCreateClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateListingPage(manager));
        }

        private void NavigateToCreateAppointmentClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Clicked Manage appointment");
            this.NavigationService.Navigate(new ManageAppointmentsPage(manager));
        }

        private void ViewAppointmentsClick(object sender, RoutedEventArgs e)
        {
            try {

                User tutor = manager.AccessUserStorage().retrieveUser(selectedUserName);
                this.NavigationService.Navigate(new SelectAppointmentPage(manager, tutor));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not load Tutor Data", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
