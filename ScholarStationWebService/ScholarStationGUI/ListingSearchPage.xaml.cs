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
    /// Interaction logic for ListingSearchPage.xaml
    /// </summary>
    public partial class ListingSearchPage : Page
    {
        List<Listing> myList;

        public ListingSearchPage()
        {
            InitializeComponent();
            UniversityBox.ItemsSource = new List<string>() { "UWF", "FSU", "UF", "UCF" };
            UniversityBox.SelectedIndex = 0;
            createTestUsers();
            ListingView.ItemsSource = myList;
        }


        private void createTestUsers()
        {
            ListingStorage x = new ListingStorage();
            myList = x.getMatchingListings("Robby", -22, null);
            /*
            myList = new List<Listing>();
            for (int i = 0; i < 35; i++)
            {
                Listing temp = new Listing();
                temp.Author = i.ToString();
                temp.Heading = i.ToString() + i + i;
                temp.Body = "Hullo";
                myList.Add(temp);
            }
            */
        }
    }
}
