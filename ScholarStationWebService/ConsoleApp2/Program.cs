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

            string x = a.GetData("This is a test string to test reversal service. This is a test.");
            Console.WriteLine(x);
            

            string y = a.getUsers();
            Console.WriteLine(y);


            //testing to make sure user is properly referenced and whatnot
            //User user = new User();
            //user.Bio = "This is a bio";
            // Console.WriteLine(user.Bio);

            User user = a.getTestUser("Pauly", "adfadfadf");
            Console.WriteLine(user.Bio);


            Console.ReadKey();
            a.Close();
        }
    }
}
