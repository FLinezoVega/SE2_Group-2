using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using DataClasses;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private string ConnectionString;

        public Service1()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "se2group2.database.windows.net";
            builder.UserID = "ScholarStationAdmin";
            builder.Password = "scholarGroup2";
            builder.InitialCatalog = "SoftwareEngineeringGroup2";

            ConnectionString = builder.ConnectionString;
        }


        public string getUsers()
        {

            StringBuilder output = new StringBuilder();//delet this
            try
            {
                //return "got here";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "se2group2.database.windows.net";
                builder.UserID = "ScholarStationAdmin";
                builder.Password = "scholarGroup2";
                builder.InitialCatalog = "SoftwareEngineeringGroup2";

                string query = "SELECT * FROM TestUser WHERE ";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        output.Append(reader[0]);
                        output.Append(reader[1]);
                    }

                }
            }
            catch (Exception e)
            {
                return "Failed to retrieve data";
            }
            return output.ToString();
        }


        public User retrieveUser(string userName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT userName, bio, university FROM Customer WHERE userName = @userName", con);//add more fields when increasing the number of colums
                    cmd.Parameters.AddWithValue("@userName", userName);//user.UserID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        User newUser = new User();
                        reader.Read();
                        newUser.UserID = reader.GetString(0);
                        newUser.Bio = reader.GetString(1);
                        newUser.University = reader.GetString(2);
                        return newUser;
                    }
                }
            }
            catch (Exception e)//FIXME
            {

            }
            return new User();
        }

        public bool createNewUser(User newUser)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand newUserCmd = new SqlCommand("Insert into Customer(userName, bio, university) values(@userName, @bio, @university)", con);
                    newUserCmd.Parameters.AddWithValue("@userName", newUser.UserID);
                    newUserCmd.Parameters.AddWithValue("@bio", newUser.Bio);
                    newUserCmd.Parameters.AddWithValue("@university", newUser.University);
                    newUserCmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException e){
                return false;
            }
        }
        
        public bool updateUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand newUserCmd = new SqlCommand("Update Customer SET bio = @bio, university = @university WHERE userName = @userName", con);
                    newUserCmd.Parameters.AddWithValue("@userName", user.UserID);
                    newUserCmd.Parameters.AddWithValue("@bio", user.Bio);
                    newUserCmd.Parameters.AddWithValue("@university", user.University);
                    newUserCmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        } 
    }
}
