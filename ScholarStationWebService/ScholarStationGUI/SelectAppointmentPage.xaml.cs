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
    /// Interaction logic for SelectAppointmentPage.xaml
    /// </summary>
    public partial class SelectAppointmentPage : Page
    {
        DataManager manager;
        User Tutor;
        public SelectAppointmentPage(DataManager man, User Tutor)
        {
            InitializeComponent();
            manager = man;
            this.Tutor = Tutor;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            getAppointments();
            TutorBox.Text = Tutor.UserID;
        }



        private void getAppointments()
        {
            try
            {
                List<Appointment> apptList = manager.AccessAppointmentStorage().getAllEmptyAppointmentsByTutor(Tutor.UserID);
                List<string> timeList = new List<string>();
                foreach (Appointment a in apptList)
                {
                    timeList.Add(a.Timeslot);
                }
                AppointmentBox.ItemsSource = timeList;
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not load appointments", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {

           if (this.NavigationService.CanGoBack)
           {
               this.NavigationService.GoBack();
           }
        }

        private void ChooseButtonClick(object sender, RoutedEventArgs e)
        {
           // string user = manager.getLocalUser().UserID;
          //  string mail = manager.getLocalUser().Email;

          //  manager.AccessAppointmentStorage().
        }


    }
}
