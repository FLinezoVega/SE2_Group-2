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

            Console.WriteLine((int)UserType.User);
            UserStorage us = new UserStorage();
            User u = us.retrieveUser("testUser17");
            Console.WriteLine(u.Verified);
            u.Verified = true;
            Console.WriteLine(us.updateUser(u));
            List<User> muhList = us.getMatchingUsers("testUser");
            foreach (User a in muhList)
            {
                Console.WriteLine("uName: " + a.UserID + "  email: " + a.Email +  "  Verified: " + a.Verified.ToString());
            }
            Console.ReadKey();
        }
    }
}
