using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
namespace DataAccess
{
    public interface IUserStorage
    {
        bool createNewUser(User newUser);
        User retrieveUser(string userName);
        bool updateUser(User user);
        List<User> getAllUsers();
    }
}
