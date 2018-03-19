using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.ServiceReference1;
using DataClasses;
using DataAccess;

namespace ConsoleApp2//this is only a temporary testing class that is used for client side activities
{
    class Program
    {
        static void Main(string[] args)
        {

            
           // Service1Client a = new Service1Client();

            /*
            User user = new User();
            //Console.WriteLine(user.Bio);
            user.University = "University of West Florida";
            user.Bio = "I am a Premed major";
            user.UserID = "Barrett";

            if (a.createNewUser(user))
            {
                Console.WriteLine("Created the user");
            }
            else {
                Console.WriteLine("Did not create the user");
            }

            user.Bio = "I like trains";


            if (a.updateUser(user))
            {
                Console.WriteLine("Updated the user");
            }
            

            User b = a.retrieveUser("Barrett");
            Console.WriteLine(b.Bio);

            User c = new User();
            c.UserID = "George";
            if (c.isNull())
            {
                Console.WriteLine("I am a null");
            }
            Console.WriteLine("Bio: {0}    User: {1}    Uni: {2}", c.Bio, c.UserID, c.University);
            
            a.Close();
            
            Listing lis = new Listing();
            lis.Author = "Ted";
            lis.Body = "This is the body of the listing, can theoretically be very very long";
            lis.Heading = "This is the Heading of the Listing. Think A Title";

            if (a.createNewListing(lis))
            {
                Console.WriteLine("Created the Listing");
            }

            List<User> myList  = new List<User>(a.getAllUsers());
            Console.WriteLine(myList.Count);
            foreach (User u in myList)
            {
                Console.WriteLine(u.UserID + ":   " + u.Bio);
            }
            */
<<<<<<< HEAD
            /*
=======
>>>>>>> a897421ad3d7416807ac4ed05d6bfbd57be4e3c6
            UserStorage uStore = new UserStorage();
            User testUser = new User();
            testUser.Bio = "Test User Bio";
            testUser.UserID = "Chandler";
            testUser.University = "USF";

            bool res = uStore.storeNewUser(testUser).Result;
            if (res)
            {
                Console.WriteLine("It worked");
            }
            else {
                Console.WriteLine("No dice");
            }

            User x = uStore.retrieveUser("Chandler").Result;
            Console.WriteLine(x.Bio);

            Console.ReadKey();
            */
        }
    }
}
