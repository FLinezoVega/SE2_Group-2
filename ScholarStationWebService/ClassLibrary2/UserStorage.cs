using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;


namespace DataAccess
{
    public class UserStorage
    {

        public async Task<bool> storeNewUser(User user)
        {
            try
            {
                Service1Client client = new Service1Client();
                return await client.createNewUserAsync(user);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async Task<User> retrieveUser(string userName)
        {
            try
            {
                Service1Client client = new Service1Client();
                User user = await client.retrieveUserAsync(userName);
                return user;
            }
            catch (Exception e)
            {
                return new User();
            }
        }
    }
}
