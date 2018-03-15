using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace DataClasses
{
    [DataContract]
    public class Listing
    {
        private string author;
        private int listingID;
        private string heading;
        private string body;

        [DataMember]
        public string Author
        {
            get { return this.author != null ? this.author : "Null"; }
            set { this.author = value; }
        }

        [DataMember]
        public int ListingID
        {
            get { return this.listingID < 0 ? this.listingID : -1; }
            set { this.listingID = value; }
        }
        [DataMember]
        public string Heading
        {
            get { return this.heading != null ? this.heading : "Null"; }
            set { this.heading = value; }
        }

        [DataMember]
        public string Body
        {
            get { return this.body != null ? this.body : "Null"; }
            set { this.body = value; }
        }


        public Listing()
        {
            listingID = -1;
        }



        public bool isNull()
        {
            return (author == null && listingID < 0 && heading == null && body == null);
        }



    }
}
