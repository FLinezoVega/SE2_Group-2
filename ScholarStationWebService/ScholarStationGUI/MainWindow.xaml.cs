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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDataManager manager;
        public MainWindow()
        {
            InitializeComponent();
            //woot woot dependency injection
            IListingStorage l = new ListingStorage();
            IUserStorage u = new UserStorage();
            IAppointmentStorage a = new AppointmentStorage();
            ILoginManager login = new LoginManager();

            manager = new DataManager(l, u, a, login);
            _mainFrame.Navigate(new OpeningPage(manager));
            //_mainFrame.Navigate(new CreateListingPage(manager));
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
