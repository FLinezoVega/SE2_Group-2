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
        private int id;
        private string clientMail;


        //this is to be called when making an appointment as a tutor
        public Appointment(string tutorID, string timeSlot)
        {
            this.tutorID = tutorID;
            this.timeslot = timeSlot;
        }

        public string TutorID
        {
            get { return this.tutorID; }
            set { this.tutorID = value; }
        }
        public string ClientMail
        {
            get { return this.clientMail; }
            set { this.clientMail = value; }
        }
        public string ClientID
        {
            get { return this.clientID; }
            set { this.clientID = value; }
        }

        public string Timeslot
        {
            get { return this.timeslot; }
            set { this.timeslot = value; }
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}
