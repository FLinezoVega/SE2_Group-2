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
using DataAccessInterfaces;

namespace ScholarStationGUI
{
    /// <summary>
    /// Interaction logic for SelectAppointmentPage.xaml
    /// </summary>
    public partial class SelectAppointmentPage : Page
    {
        IDataManager manager;
        User Tutor;
        List<Appointment> apptList;

        public SelectAppointmentPage(IDataManager man, User Tutor)
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
                apptList = manager.AccessAppointmentStorage().getAllEmptyAppointmentsByTutor(Tutor.UserID);
                AppointmentView.ItemsSource = apptList;      
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not load appointments", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            /*
           if (this.NavigationService.CanGoBack)
           {
               this.NavigationService.GoBack();
           }*/
            this.NavigationService.Navigate(new ListingSearchPage(manager));
        }


        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SelectedAppointment = e.AddedItems[0] as Appointment;
            //var clicker = (FrameworkElement)sender;
            //selectedAppointment = (Appointment)clicker.DataContext as Appointment;
            //System.Diagnostics.Debug.WriteLine(SelectedAppointment.TutorID);

            ChooseButton.IsEnabled = true;
        }

        private void ChooseButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                apptList[AppointmentView.SelectedIndex].ClientID = manager.getLocalUser().UserID;
                apptList[AppointmentView.SelectedIndex].ClientMail = manager.getLocalUser().Email;
                manager.AccessAppointmentStorage().updateAppointment(apptList[AppointmentView.SelectedIndex]);
                this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not choose appointment", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
