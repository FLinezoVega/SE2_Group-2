﻿using System;
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
    /// Interaction logic for ManageAppointmentsPage.xaml
    /// </summary>
    public partial class ManageAppointmentsPage : Page
    {
        DataManager manager;

        public ManageAppointmentsPage(DataManager man)
        {
            InitializeComponent();
            manager = man;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            textCheck();
            getClientAppointments();
            getTutorAppointments();
        }

        private void TextSelectionChanged(object sender, RoutedEventArgs e)
        {
            textCheck();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void CreateButtonClick(object sender, RoutedEventArgs E)
        {
            try
            {
                Appointment newAppt = new Appointment();
                newAppt.TutorID = manager.getLocalUser().UserID;
                newAppt.Timeslot = text.Text;
                manager.AccessAppointmentStorage().createNewAppointment(newAppt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not create appointment", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            getTutorAppointments();
        }

        private void textCheck()
        {
            if (text.Text.Length >= 1)
            {
                CreateButton.Visibility = Visibility.Visible;
            }
            else
            {
                CreateButton.Visibility = Visibility.Hidden;
            }
        }

        private void getClientAppointments()
        {
            try
            {

                ClientView.ItemsSource = manager.AccessAppointmentStorage().getAllAppointmentsByClient(manager.getLocalUser().UserID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("could not load appointments");
                MessageBox.Show("Could not load appointments", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
       }

        private void getTutorAppointments()
        {
            try
            {

                TutorView.ItemsSource = manager.AccessAppointmentStorage().getAllAppointmentsByTutor(manager.getLocalUser().UserID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("could not load appointments");
                MessageBox.Show("Could not load appointments", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}