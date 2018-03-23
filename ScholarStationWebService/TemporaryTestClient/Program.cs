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
            List<Listing> myList = ls.getMatchingListings(null, -1,null, -1, null, null);
            foreach (Listing l in myList)
            {
                Console.WriteLine(l.Author + " " + " " + l.Heading + " " + l.ListingType + " " + l.University);
            }
            
            Console.ReadKey();
           
        }
    }
}
