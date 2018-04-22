using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;

namespace DataAccessInterfaces
{
    public interface IDataManager
    {
        IListingStorage AccessListingStorage();

        IUserStorage AccessUserStorage();

        IAppointmentStorage AccessAppointmentStorage();

        ILoginManager getLoginManager();

        List<string> getUniversities();

        List<string> getSubjects();

        List<string> getTypes();

        void setLocalUser(User user);

        User getLocalUser();
    }
}
