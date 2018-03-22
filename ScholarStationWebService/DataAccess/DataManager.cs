using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class DataManager
    {
        private ListingStorage lStore;
        private UserStorage uStore;
        private AppointmentStorage aStore;

        public DataManager()
        {
            lStore = new ListingStorage();
            uStore = new UserStorage();
            aStore = new AppointmentStorage();
        }

        public ListingStorage AccessListingStorage()
        {
            return lStore;
        }

        public UserStorage AccessUserStorage()
        {
            return uStore;
        }

        public AppointmentStorage AccessAppointmentStorage()
        {
            return aStore;
        }

    }
}
