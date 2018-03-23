using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataClasses;

namespace DataAccess
{
    public class ListingStorage
    {
        private string ConnectionString;

        public ListingStorage()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "se2group2.database.windows.net";
            builder.UserID = "ScholarStationAdmin";
            builder.Password = "scholarGroup2";
            builder.InitialCatalog = "SoftwareEngineeringGroup2";
            ConnectionString = builder.ConnectionString;
        }

        public bool createNewListing(Listing newListing)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand newListingCmd = new SqlCommand("Insert into Listing(author, listingID, heading, body, ListingType, Subject, University) values(@author, @listingID, @heading, @body, @ListingType, @Subject, @University )", con);
                    newListingCmd.Parameters.AddWithValue("@author", newListing.Author);
                    newListingCmd.Parameters.AddWithValue("@listingID", newListing.ListingID);// < 0 ? newListing.ListingID: DBNull.Value);
                    newListingCmd.Parameters.AddWithValue("@heading", newListing.Heading);// != null ? newListing.Heading: DBNull.Value);
                    newListingCmd.Parameters.AddWithValue("@body", newListing.Body);
                    newListingCmd.Parameters.AddWithValue("@ListingType", newListing.ListingType);
                    newListingCmd.Parameters.AddWithValue("@Subject", newListing.Subject);
                    newListingCmd.Parameters.AddWithValue("@University", newListing.University);
                    newListingCmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Listing retrieveListing(int ID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT author, listingID, heading, body FROM Listing WHERE listingID = @listingID", con);
                    cmd.Parameters.AddWithValue("@listingID", ID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Listing listing = new Listing();
                        reader.Read();
                        listing.Author = reader.GetString(0);
                        listing.ListingID = reader.GetInt32(1);
                        listing.Heading = reader.GetString(2);
                        listing.Body = reader.GetString(3);

                        return listing;
                    }
                }
            }
            catch (Exception e)//FIXME
            {

            }
            return new Listing();
        }//currently broken based on Listing returning -1 for every listing. This is due to eventual plans of have an auto id assignment for database

        public List<Listing> getMatchingListings(string author, int ID, string heading, int ListingType, string Subject, string University)
        {
            List<Listing> s = new List<Listing>();
            try
            {

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    string query = getListingListSqlString(author, ID, heading, ListingType, Subject, University);
                    SqlCommand cmd = new SqlCommand(query, con);
                    addListingListSqlParameters(author, ID, heading, ListingType, Subject, University, cmd);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {


                            Listing listing = new Listing();
                            if (reader.GetValue(0) != DBNull.Value)
                            {
                                listing.Author = reader.GetString(0);
                            }
                            if (reader.GetValue(1) != DBNull.Value)
                            {
                                listing.ListingID = reader.GetInt32(1);
                            }
                            if (reader.GetValue(2) != DBNull.Value)
                            { 
                            listing.Heading = reader.GetString(2);
                            }
                            if (reader.GetValue(3) != DBNull.Value)
                            {
                                listing.Body = reader.GetString(3);
                            }
                            if (reader.GetValue(4) != DBNull.Value)
                            {
                                listing.ListingType = (int)reader.GetValue(4);
                            }
                            if (reader.GetValue(5) != DBNull.Value)
                            {
                                listing.Subject = reader.GetString(5);
                            }
                            if (reader.GetValue(6) != DBNull.Value)
                            {
                                listing.University = reader.GetString(6);
                            }  
                            
                            s.Add(listing);
                            
                        }
                    }
                }
            }
            catch (Exception e)//FIXME, null object pattern
            {
                s.Add(new Listing());
            }
            return s;
        }

        private string getListingListSqlString(string author, int ID, string heading, int ListingType, string Subject, string University)
        {
            bool hasOne = false;//if there is nothing added to the default select yet, this is false. 
            StringBuilder s = new StringBuilder("Select author, listingID, heading, body, ListingType, Subject, University From Listing ");
            if (!string.IsNullOrEmpty(author) || ID > 0 || !string.IsNullOrEmpty(heading) || ListingType > 0 || !string.IsNullOrEmpty(Subject) || !string.IsNullOrEmpty(University))
            {
                s.Append("Where ");
                if (!string.IsNullOrEmpty(author))
                {
                    s.Append("author = @author ");
                    hasOne = true;
                }
                if (ID > 0)
                {
                    s.Append(hasOne ? "AND listingID = @ID " : "listingID = @ID ");
                    hasOne = true;
                }
                if (!string.IsNullOrEmpty(heading))
                {
                    s.Append(hasOne ? "AND heading = @heading " : "heading = @heading ");
                }
                if (ListingType > 0)
                {
                   s.Append(hasOne ? "AND ListingType = @ListingType " : "ListingType = @ListingType ");
                }
                if (!string.IsNullOrEmpty(Subject))
                {
                    s.Append(hasOne ? "AND Subject = @Subject " : "Subject = @Subject ");
                }
                if (!string.IsNullOrEmpty(University))
                {
                    s.Append(hasOne ? "AND University = @University " : "University = @University ");
                }

                
            }
            Console.WriteLine(s.ToString());
            return s.ToString();
        }

        private void addListingListSqlParameters(string author, int ID, string heading, int ListingType, string Subject, string University, SqlCommand cmd)
        {
            if (!string.IsNullOrEmpty(author) || ID > 0 || !string.IsNullOrEmpty(heading) || ListingType > 0 || !string.IsNullOrEmpty(Subject) || !string.IsNullOrEmpty(University))
            {
                if (!string.IsNullOrEmpty(author))
                {
                    cmd.Parameters.AddWithValue("@author", author);
                }
                if (ID > 0)
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                }
                if (!string.IsNullOrEmpty(heading))
                {
                    cmd.Parameters.AddWithValue("@heading", heading);
                }
                if (ListingType > 0)
                {
                    cmd.Parameters.AddWithValue("@ListingType", ListingType);
                }
                if (!string.IsNullOrEmpty(Subject))
                {
                    cmd.Parameters.AddWithValue("@Subject", Subject);
                }
                if (!string.IsNullOrEmpty(University))
                {
                    cmd.Parameters.AddWithValue("@University", University);
                }
            }
        }
    }
}