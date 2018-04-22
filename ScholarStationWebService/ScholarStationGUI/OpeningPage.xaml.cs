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

namespace ScholarStationGUI
{
    /// <summary>
    /// Interaction logic for OpeningPage.xaml
    /// </summary>
    public partial class OpeningPage : Page
    {
        IDataManager manager;
        public OpeningPage(IDataManager man)
        {
            InitializeComponent();
            manager = man;
        }

        private void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage(manager));
        }

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignUpPage(manager));//new HomePage(manager));
            //this.NavigationService.Navigate(new LoginPage(manager));
        }
    }
}
