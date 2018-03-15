using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataClasses
{
    [DataContract(Name  = "User")]
    public class User : IUser
    {
        private string userID;
        private string bio;
        private string university;

        [DataMember(Name = "UserID")]
        public string UserID
        {
            get { return this.userID != null ? this.userID : "Null"; }
            set { this.userID = value; }
        }

        [DataMember(Name = "Bio")]
        public string Bio
        {
            get { return this.bio != null ? this.bio : "Null"; }
            set { this.bio = value; }
        }

        [DataMember(Name = "University")]
        public string University
        {
            get { return this.university != null ? this.university : "Null"; }
            set { this.university = value; }
        }


        public bool isNull()//Test this extensively
        {
            return (UserID.Equals("Null") && Bio.Equals("Null") &&  University.Equals("Null"));
        }
    }
}
