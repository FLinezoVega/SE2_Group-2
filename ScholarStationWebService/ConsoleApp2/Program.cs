using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.ServiceReference1;

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
            Console.ReadKey();

            a.Close();
        }
    }
}
