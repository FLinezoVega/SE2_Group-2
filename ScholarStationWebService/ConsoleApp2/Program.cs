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
            Console.WriteLine(user.Bio);
            user.University = "University of West Florida";
            user.Bio = "I am a poliSci major";
            user.UserID = "Brad";

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
           // else
           // {
           //     Console.WriteLine("Did not update the user");
           // }

            Console.ReadKey();
            a.Close();
        }
    }
}
