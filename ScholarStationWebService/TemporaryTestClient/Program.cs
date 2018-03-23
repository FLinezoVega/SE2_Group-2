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
            /*
            TestClient tc = new TestClient();
            UserStorage us = new UserStorage();
            User user = new User();
            user.Bio = "Test client after the sql has been put directly into the code";
            user.University = "UCF";
            user.UserID = "Memera";
            user.Email = "robertCali@asdasd.com";
            Console.WriteLine(us.createNewUser(user));
            User x = us.retrieveUser("Memera");
            Console.WriteLine(x.Email + " " + x.UserID);
            */
            LoginManager lm = new DataAccess.LoginManager();
            Console.WriteLine(lm.checkExisting("bkp5", "password123"));
            Console.ReadKey();
        }
    }
}
