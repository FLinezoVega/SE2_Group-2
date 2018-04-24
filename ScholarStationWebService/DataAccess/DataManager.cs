using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
using DataAccessInterfaces;


namespace DataAccess
{
    public class DataManager: IDataManager
    {

        private User localUser;

        private IListingStorage lStore;
        private IUserStorage uStore;
        private IAppointmentStorage aStore;
        private ILoginManager lManager;
        private IFeedbackStorage fStore;

        private List<string> UniversityList;
        private List<string> SubjectList;
        private List<string> TypeList;

        public DataManager(IListingStorage l, IUserStorage u, IAppointmentStorage a, ILoginManager login, IFeedbackStorage f)
        {
            lStore = l;// new ListingStorage();
            uStore = u;// new UserStorage();
            aStore = a;// new AppointmentStorage();
            lManager = login;// new LoginManager();
            fStore = f;

            UniversityList = new List<string>() { "UWF", "FSU", "UCF", "UF", "UM" };
            SubjectList = new List<string>() { "Math", "CompSci", "History", "English", "Biology", "Chemistry" };
            TypeList = new List<string>() { "Tutoring", "Study Group" };
        }

        public IListingStorage AccessListingStorage()
        {
            return lStore;
        }

        public IUserStorage AccessUserStorage()
        {
            return uStore;
        }

        public IAppointmentStorage AccessAppointmentStorage()
        {
            return aStore;
        }

        public ILoginManager getLoginManager()
        {
            return lManager;
        }

        public IFeedbackStorage getFeedbackStorage()
        {
            return fStore;
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
