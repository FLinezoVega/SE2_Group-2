using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
using DataAccessInterfaces;
using System.Data.SqlClient;



namespace DataAccess
{
    public class UserStorage : IUserStorage
    {

        private string ConnectionString;

        public UserStorage()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "se2group2.database.windows.net";
            builder.UserID = "ScholarStationAdmin";
            builder.Password = "scholarGroup2";
            builder.InitialCatalog = "SoftwareEngineeringGroup2";
            ConnectionString = builder.ConnectionString;
        }

        public bool createNewUser(User newUser)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand newUserCmd = new SqlCommand("Insert into Customer(userName, bio, university, email, verified, type) values(@userName, @bio, @university, @email, 0, 0)", con);
                    newUserCmd.Parameters.AddWithValue("@userName", newUser.UserID);
                    newUserCmd.Parameters.AddWithValue("@bio", newUser.Bio);
                    newUserCmd.Parameters.AddWithValue("@university", newUser.University);
                    newUserCmd.Parameters.AddWithValue("@email", newUser.Email);
                    newUserCmd.ExecuteNonQuery();
                }
                return true;//add test to check if ExecuteNonQuery is 1 or whatever the value is
            }
            catch (SqlException e)
            {//FIX this, maybe
                return false;
            }
        }

        public User retrieveUser(string userName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT userName, bio, university, email, verified, type FROM Customer WHERE userName = @userName", con);//add more fields when increasing the number of colums
                    cmd.Parameters.AddWithValue("@userName", userName);//user.UserID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        User newUser = new User();
                        reader.Read();
                        newUser.UserID = reader.GetString(0);
                        newUser.Bio = reader.GetString(1);
                        newUser.University = reader.GetString(2);
                        newUser.Email = reader.GetString(3);
                        newUser.Verified = (bool)reader.GetValue(4);
                        newUser.UType = (UserType)reader.GetValue(5);
                        return newUser;
                    }
                }
            }
            catch (Exception e)//FIXME
            {

            }
            return new User();
        }

        public bool updateUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand newUserCmd = new SqlCommand("Update Customer SET bio = @bio, university = @university, verified = @verified WHERE userName = @userName", con);
                    newUserCmd.Parameters.AddWithValue("@userName", user.UserID);
                    newUserCmd.Parameters.AddWithValue("@bio", user.Bio);
                    newUserCmd.Parameters.AddWithValue("@university", user.University);
                    newUserCmd.Parameters.AddWithValue("@verified", user.Verified);
                    newUserCmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public List<User> getAllUsers()//maybe add check for empty list inside try block
        {
            List<User> userList = new List<User>();
            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select userName, bio, university, email, verified, type From Customer", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User temp = new User();
                        temp.UserID = reader.GetString(0);
                        temp.Bio = reader.GetString(1);
                        temp.University = reader.GetString(2);
                        temp.Email = reader.GetString(3);
                        temp.Verified = (bool)reader.GetValue(4);
                        
                        userList.Add(temp);
                    }

                    return userList;
                }
            }
            catch (Exception e)
            {
                userList.Add(new User());
                return userList;
            }
        }

        public List<User> getMatchingUsers(string keyword, string university)
        {
            List<User> userList = new List<User>();
            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT userName, bio, university, email, verified, type FROM Customer WHERE userName Like @search AND university = @university Order by userName", connection);
                    cmd.Parameters.AddWithValue("@search", "%" + keyword + "%");
                    cmd.Parameters.AddWithValue("@university", university);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User temp = new User();
                        temp.UserID = reader.GetString(0);
                        temp.Bio = reader.GetString(1);
                        temp.University = reader.GetString(2);
                        temp.Email = reader.GetString(3);
                        temp.Verified = (bool)reader.GetValue(4);
                        temp.UType = (UserType)reader.GetInt32(5);
                        userList.Add(temp);
                    }

                    return userList;
                }
            }
            catch (Exception e)
            {
                userList.Add(new User());
                return userList;
            }
        }


        public bool toggleUserVerification(string userName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand newUserCmd = new SqlCommand("Update customer set verified = CASE WHEN verified = 1 THEN 0 ELSE 1 END where userName = @userName", con);
                    newUserCmd.Parameters.AddWithValue("@userName", userName);
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
