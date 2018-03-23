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

namespace ScholarStationGUI
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        DataManager manager;
        public LoginPage(DataManager man)
        {
            InitializeComponent();
            manager = man;
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (manager.getLoginManager().checkExisting(UserNameBox.Text, PasswordTextBox.Password))
                {
                    manager.setLocalUser(manager.AccessUserStorage().retrieveUser(UserNameBox.Text));
                    this.NavigationService.Navigate(new ListingSearchPage(manager));
                }
                else
                {
                    MessageBox.Show("Invalid Login Credentials", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try Again", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
