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
    /// Interaction logic for FacultyUserSearch.xaml
    /// </summary>
    public partial class FacultyUserSearch : Page
    {
        IDataManager manager;
       // List<User> myList;
        string selectedUserName;

        public FacultyUserSearch(IDataManager manager)
        {
            this.manager = manager;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //change this to get users with same university as caller
            searchUsers();
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            searchUsers();
        }

        private void VerifyClick(object sender, RoutedEventArgs e)
        {
            manager.AccessUserStorage().toggleUserVerification(selectedUserName);

            
            searchUsers();
            UserView.SelectedValue = 0;
        }

        private void searchUsers()
        {
            try
            {
                UserView.ItemsSource =  manager.AccessUserStorage().getMatchingUsers(SearchBox.Text, manager.getLocalUser().University);
            }
            catch (Exception e)
            {

            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User u = e.AddedItems[0] as User;
            selectedUserName = u.UserID;
            VerifyButton.IsEnabled = true;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text.Length >= 1)
            {
                SearchButton.IsEnabled = true;
            }
            else {
                SearchButton.IsEnabled = false;
            }
        }
    }
}
