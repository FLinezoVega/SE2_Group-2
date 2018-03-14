using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataClasses
{
    [DataContract]
    public class User
    {
        private string userID;
        private string bio;
        private string university;

        [DataMember]
        public string UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        [DataMember]
        public string Bio
        {
            get { return this.bio; }
            set { this.bio = value; }
        }

        [DataMember]
        public string University
        {
            get { return this.university; }
            set { this.university = value; }
        }
    }
}
