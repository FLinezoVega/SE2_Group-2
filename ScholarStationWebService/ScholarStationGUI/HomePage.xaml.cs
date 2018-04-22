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
using DataAccessInterfaces;

namespace ScholarStationGUI
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        IDataManager manager;
        public HomePage(IDataManager manager)
        {
            this.manager = manager;
            InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Frame f1 = new Frame();
            f1.Navigate(new ListingSearchPage(manager));
            tabItem1.Content = f1;

            Frame f2 = new Frame();
            f2.Navigate(new ManageAppointmentsPage(manager));
            tabItem2.Content = f2;

            Frame f3 = new Frame();
            f3.Navigate(new CreateListingPage(manager));
            tabItem3.Content = f3;
        }
    }
}
