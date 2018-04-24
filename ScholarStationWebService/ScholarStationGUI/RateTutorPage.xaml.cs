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
using DataAccessInterfaces;
using DataClasses;


namespace ScholarStationGUI
{
    /// <summary>
    /// Interaction logic for RateTutorPage.xaml
    /// </summary>


    public partial class RateTutorPage : Page
    {
        IDataManager manager;
        string selectedUserName;
        int[] rate = { 1, 2, 3, 4, 5 };
        public RateTutorPage(IDataManager manager)
        {
            this.manager = manager;
            InitializeComponent();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User u = e.AddedItems[0] as User;
            Rating.ItemsSource = rate;
            Rating.IsEnabled = true;
            selectedUserName = u.UserID;
            RateButton.IsEnabled = true;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //change this to get users with same university as caller
            UserView.ItemsSource = manager.AccessUserStorage().getMatchingTutors(manager.getLocalUser().UserID);
        }

        private void RateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                manager.getFeedbackStorage().submitFeedback(Int32.Parse(Rating.Text), manager.getLocalUser().UserID, selectedUserName);
                UserView.ItemsSource = manager.AccessUserStorage().getMatchingTutors(manager.getLocalUser().UserID);
            }
            catch (Exception ex)
            {

            }
        }
        /*
        private void searchUsers()
        {
            try
            {
                UserView.ItemsSource = manager.AccessUserStorage().getMatchingUsers(SearchBox.Text, manager.getLocalUser().University);
            }
            catch (Exception e)
            {

            }
        }
        */
        /*
        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            searchUsers();
        }
        
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text.Length >= 1)
            {
                SearchButton.IsEnabled = true;
            }
            else
            {
                SearchButton.IsEnabled = false;
            }
        }
        */
    }

}
