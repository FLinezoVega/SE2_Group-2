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
        private string email;

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

        [DataMember(Name = "UType")]
        public UserType UType
        {
            get; set;
        }

        [DataMember(Name = "Verified")]
        public bool Verified
        {
            get; set;
        }

        [DataMember(Name = "Score")]
        public string Score
        {
            get; set;
        }

        [DataMember(Name = "Verification")]
        public string Verfication
        {
            get
            {
                if (Verified)
                {
                    return "Verfied with " + University;
                }
                else
                {
                    return "";
                }
            }
        }

        [DataMember(Name = "University")]
        public string University
        {
            get { return this.university != null ? this.university : "Null"; }
            set { this.university = value; }
        }

        [DataMember(Name = "Email")]
        public string Email
        {
            get { return this.email!= null ? this.email : "Null"; }
            set { this.email = value; }
        }

        public bool isNull()//Test this extensively
        {
            return (UserID.Equals("Null") && Bio.Equals("Null") &&  University.Equals("Null"));
        }
    }
}
