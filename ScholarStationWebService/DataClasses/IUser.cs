using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataClasses
{
    
    public interface IUser
    {
        [DataMember]
        string UserID
        {
            get; set;
        }
        [DataMember]
        string Bio
        {
            get;  set;
        }
        [DataMember]
        string University
        {
            get;  set;
        }

    }
}
