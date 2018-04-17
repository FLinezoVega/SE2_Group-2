using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;

namespace DataAccess
{
    public interface IListingStorage
    {
        bool createNewListing(Listing newListing);
        Listing retrieveListing(int ID);
        List<Listing> getMatchingListings(string author, int ID, string heading, int ListingType, string Subject, string University);
    }
}
