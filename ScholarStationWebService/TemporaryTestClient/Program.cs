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

            LoginManager l = new LoginManager();
            Console.WriteLine(l.createNewAccount("bleh", "blehbleh"));
            
            Console.ReadKey();
           
        }
    }
}
