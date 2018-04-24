using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
using DataAccessInterfaces;

namespace DataAccessInterfaces
{
    public interface IFeedbackStorage 
    {
        bool submitFeedback(int score, string rate, string target);
    }
}
