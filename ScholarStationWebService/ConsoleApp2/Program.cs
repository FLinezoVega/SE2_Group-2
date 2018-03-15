using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.ServiceReference1;
using DataClasses;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Service1Client a = new Service1Client();
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
            Console.WriteLine("{0}, {1}", lis.isNull(), lis.Author);


            Console.ReadKey();
        }
    }
}
