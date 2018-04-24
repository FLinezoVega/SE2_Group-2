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
    /// Interaction logic for RateTutorPage.xaml
    /// </summary>


    public partial class RateTutorPage : Page
    {
        IDataManager manager;
        public RateTutorPage(IDataManager manager)
        {
            this.manager = manager;
            InitializeComponent();
        }
    }
}
