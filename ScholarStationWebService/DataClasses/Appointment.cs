using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses
{
    public class Appointment
    {
        private string tutorID;
        private string clientID;
        private string timeslot;

        public string TutorID
        {
            get;
            set;
        }

        public string ClientID
        {
            get;
            set;
        }

        public string Timeslot
        {
            get;
            set;
        }
    }
}
