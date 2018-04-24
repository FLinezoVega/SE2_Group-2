using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;

namespace DataAccessInterfaces
{
    public interface IUserStorage
    {
        bool createNewUser(User newUser);
        User retrieveUser(string userName);
        bool updateUser(User user);
        bool toggleUserVerification(string userName);
        List<User> getAllUsers();
        List<User> getMatchingUsers(string keyWord, string university);
        List<User> getMatchingTutors(string userName);
    }
}
