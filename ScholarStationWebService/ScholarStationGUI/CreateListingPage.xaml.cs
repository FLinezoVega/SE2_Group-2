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
    /// Interaction logic for CreateListingPage.xaml
    /// </summary>
    public partial class CreateListingPage : Page
    {
        DataManager manager;
        public CreateListingPage(DataManager man)
        {
            InitializeComponent();
            manager = man;
            //this.Loaded +=CreateListingPage_Loaded();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UniversityBox.ItemsSource = manager.getUniversities();
            UniversityBox.SelectedIndex = 0;

            SubjectBox.ItemsSource = manager.getSubjects();
            SubjectBox.SelectedIndex = 0;

            TypeBox.ItemsSource = manager.getTypes();
            TypeBox.SelectedIndex = 0;
        }

        private void CreateListingButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Listing aListing = new Listing();
                aListing.Author = "TESTAUTHOR";
                aListing.Heading = TitleBox.Text;
                aListing.Body = BodyBox.Text;
                aListing.University = UniversityBox.Text;
                aListing.Subject = SubjectBox.Text;
                if (TypeBox.Text.Equals("Tutoring"))
                {
                    aListing.ListingType = (int)ListingType.Tutoring;
                }
                else {
                    aListing.ListingType = (int)ListingType.StudyGroup;
                }
                if (manager.AccessListingStorage().createNewListing(aListing))
                {
                    TitleBox.Text = "GOOOD!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Information", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void textCheck(object sender, RoutedEventArgs e)
        {
            if (TitleBox.Text.Length >= 1 && BodyBox.Text.Length >= 1)
            {
                CreateButton.Visibility = Visibility.Visible;
            }
            else {
                CreateButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
