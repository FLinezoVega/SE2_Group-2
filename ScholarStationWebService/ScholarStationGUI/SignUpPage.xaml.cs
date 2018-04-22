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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        IDataManager manager;
        public SignUpPage(IDataManager manager)
        {
            this.manager = manager;
            InitializeComponent();
        }


        private bool checkPassWords()
        {
            return (PasswordTextBox.Password.Equals(PasswordConfirm.Password));
        }

        private void TextCheck(object sender, RoutedEventArgs e)
        {
            checkDuplicateUserName();
            if (UserNameBox.Text.Length >= 1 && Email.Text.Length >= 1 && University.Text.Length >= 1 && PasswordTextBox.Password.Length >= 1 && checkPassWords() && !checkDuplicateUserName())
            {
                    createButton.IsEnabled = true;
            }
            else
            {
                createButton.IsEnabled = false;
            }
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                manager.getLoginManager().createNewAccount(UserNameBox.Text, PasswordTextBox.Password);
                User u = new User(UserNameBox.Text, "", University.Text, Email.Text);
                manager.AccessUserStorage().createNewUser(u);
                this.NavigationService.Navigate(new HomePage(manager));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create user account", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


        private bool checkDuplicateUserName()
        {
            if (manager.getLoginManager().checkExisting(UserNameBox.Text))
            {
                DuplicateUser.Visibility = Visibility.Visible;
                return true;
            }
            DuplicateUser.Visibility = Visibility.Hidden;
            return false;


        }

        private void PasswordChange(object sender, RoutedEventArgs e)
        {
            if (checkPassWords())
            {
                mismatchMessage.Visibility = Visibility.Hidden;
            }
            else
            {
                mismatchMessage.Visibility = Visibility.Visible;
            }
        }

       
    }
}
