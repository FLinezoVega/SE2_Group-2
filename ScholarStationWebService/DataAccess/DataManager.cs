using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;

namespace DataAccess
{
    public class DataManager
    {

        private User localUser;

        private ListingStorage lStore;
        private UserStorage uStore;
        private AppointmentStorage aStore;
        private LoginManager lManager;

        private List<string> UniversityList;
        private List<string> SubjectList;
        private List<string> TypeList;
        public DataManager()
        {
            lStore = new ListingStorage();
            uStore = new UserStorage();
            aStore = new AppointmentStorage();
            lManager = new LoginManager();

            UniversityList = new List<string>() { "UWF", "FSU", "UCF", "UF", "UM" };
            SubjectList = new List<string>() { "Math", "CompSci", "History", "English", "Biology", "Chemistry" };
            TypeList = new List<string>() { "Tutoring", "Study Group" };
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

        public LoginManager getLoginManager()
        {
            return lManager;
        }

        public List<string> getUniversities()
        {
            return UniversityList;
        }

        public List<string> getSubjects()
        {
            return SubjectList;
        }

        public List<string> getTypes()
        {
            return TypeList;
        }

        public void setLocalUser(User user)
        {
            localUser = user;
        }

        public User getLocalUser()
        {
            if (localUser != null)
            {
                return localUser;
            }
            return new User();
        }

    }
}
