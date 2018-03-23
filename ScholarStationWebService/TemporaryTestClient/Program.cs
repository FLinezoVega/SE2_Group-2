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


        
            
            ListingStorage ls = new ListingStorage();
            List<Listing> myList = ls.getMatchingListings("", -1,null, -5, "", "UWF");
            foreach (Listing l in myList)
            {
                Console.WriteLine(l.Author + " " + " " + l.Heading + " " + l.Body + " " + l.ListingType + " " + l.Subject + " " + l.University);
            }
            
            Console.ReadKey();
           
        }
    }
}
