﻿using System;
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
                    SqlCommand newListingCmd = new SqlCommand("Insert into Listing(author, listingID, heading, body) values(@author, @listingID, @heading, @body )", con);
                    newListingCmd.Parameters.AddWithValue("@author", newListing.Author);
                    newListingCmd.Parameters.AddWithValue("@listingID", newListing.ListingID);
                    newListingCmd.Parameters.AddWithValue("@heading", newListing.Heading);
                    newListingCmd.Parameters.AddWithValue("@body", newListing.Body);
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

        public List<Listing> getMatchingListings(string author, int ID, string heading)
        {
            List<Listing> s = new List<Listing>();
            try
            {

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    string query = getListingListSqlString(author, ID, heading);
                    SqlCommand cmd = new SqlCommand(query, con);
                    addListingListSqlParameters(author, ID, heading, cmd);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Listing listing = new Listing();
                            listing.Author = reader.GetString(0);
                            listing.ListingID = reader.GetInt32(1);
                            listing.Heading = reader.GetString(2);
                            listing.Body = reader.GetString(3);
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

        private string getListingListSqlString(string author, int ID, string heading)
        {
            bool hasOne = false;//if there is nothing added to the default select yet, this is false. 
            StringBuilder s = new StringBuilder("Select * From Listing ");
            if (author != null || ID > 0 || heading != null)
            {
                s.Append("Where ");
                if (author != null)
                {
                    s.Append("author = @author ");
                    hasOne = true;
                }
                if (ID > 0)
                {
                    s.Append(hasOne ? "AND listingID = @ID " : "listingID = @ID ");
                    hasOne = true;
                }
                if (heading != null)
                {
                    s.Append(hasOne ? "AND heading = @heading " : "heading = @heading ");
                }
            }
            return s.ToString();
        }

        private void addListingListSqlParameters(string author, int ID, string heading, SqlCommand cmd)
        {
            if (author != null || ID > 0 || heading != null)
            {
                if (author != null)
                {
                    cmd.Parameters.AddWithValue("@author", author);
                }
                if (ID > 0)
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                }
                if (heading != null)
                {
                    cmd.Parameters.AddWithValue("@heading", heading);
                }
            }
        }
    }
}