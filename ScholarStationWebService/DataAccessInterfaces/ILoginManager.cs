using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface ILoginManager
    {
        bool checkExisting(string userName);

        bool checkExisting(string userName, string password);

        bool createNewAccount(string userName, string password);
    }
}
