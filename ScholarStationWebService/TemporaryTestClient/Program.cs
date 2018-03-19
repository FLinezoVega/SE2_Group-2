using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataClasses;

namespace TemporaryTestClient
{
    class TestClient
    {
        static void Main(string[] args)
        {
            /*
            TestClient tc = new TestClient();
            UserStorage us = new UserStorage();
            User user = new User();
            user.Bio = "Test client after the sql has been put directly into the code";
            user.University = "UCF";
            user.UserID = "David";
            Console.WriteLine(us.createNewUser(user));
            */

            /*
            ListingStorage ls = new ListingStorage();
            Listing x = new Listing();
            x.Author = "Robby";
            x.ListingID = 77;
            x.Heading = "Stanhope";
            x.Body = "Sunnyvaleasdasd";

            Console.WriteLine(ls.createNewListing(x));

            //Listing y = ls.retrieveListing();
            //Console.WriteLine(y.Body);
            */
            /*
            ListingStorage ls = new ListingStorage();
            List<Listing> theList = ls.getMatchingListings("Sally", -1, null);
            foreach(Listing l in theList)
            {
                Console.WriteLine(l.Author + " " + l.ListingID + " " + l.Heading +" " + l.Body);
            }
            */
            
            Appointment a = new Appointment();
            a.ClientID = "Jerry";
            a.TutorID = "Layne";
            a.Timeslot = "The 90s";
            AppointmentStorage store = new AppointmentStorage();
            Console.WriteLine(store.createNewAppointment(a));
            
            Console.ReadKey();
        }
    }
}
