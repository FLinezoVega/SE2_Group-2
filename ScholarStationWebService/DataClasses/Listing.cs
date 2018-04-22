using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

//FIXME be sure to implement null object pattern
namespace DataClasses
{
    [DataContract]
    public class Listing
    {
        private string author;
        private int listingID;
        private string heading;
        private string body;
        private string university;
        private int listingType;
        private string subject;

        public Listing(string author, string heading, string body, string university, string subject)
        {
            this.author = author;
            this.listingID = -1;
            this.heading = heading;
            this.body = body;
            this.university = university;
            this.subject = subject;
        }


        public string Author
        {
            get { return this.author != null ? this.author : "Null"; }
            set { this.author = value; }
        }

        public int ListingID//fix m, update to reflect final decision on database ID incrementing or whatever
        {
            get { return this.listingID; }
            set { this.listingID = value; }
        }
        public string Heading
        {
            get { return this.heading != null ? this.heading : "Null"; }
            set { this.heading = value; }
        }

        public string Body
        {
            get { return this.body != null ? this.body : "Null"; }
            set { this.body = value; }
        }

        public string University
        {
            get { return this.university != null ? this.university : "Null"; }
            set { this.university = value; }
        }

        public int ListingType
        {
            get { return this.listingType; }//< 0 ? this.listingType : -1; }
            set { this.listingType = value; }
        }

        public string Subject
        {
            get { return this.subject != null ? this.subject : "Null"; }
            set { this.subject = value; }
        }

        public Listing()
        {
            listingID = -1;
            listingType = -1;
        }



        public bool isNull()
        {
            return (author == null && listingID < 0 && heading == null && body == null);
        }



    }
}
