using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
<<<<<<< HEAD
using System.Data.SqlClient;
=======
>>>>>>> a897421ad3d7416807ac4ed05d6bfbd57be4e3c6


namespace DataAccess
{
    public class UserStorage
    {
<<<<<<< HEAD
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
                    SqlCommand newUserCmd = new SqlCommand("Insert into Customer(userName, bio, university) values(@userName, @bio, @university)", con);
                    newUserCmd.Parameters.AddWithValue("@userName", newUser.UserID);
                    newUserCmd.Parameters.AddWithValue("@bio", newUser.Bio);
                    newUserCmd.Parameters.AddWithValue("@university", newUser.University);
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
=======

        public async Task<bool> storeNewUser(User user)
        {
            try
            {
                Service1Client client = new Service1Client();
                return await client.createNewUserAsync(user);
            }
            catch (Exception e)
>>>>>>> a897421ad3d7416807ac4ed05d6bfbd57be4e3c6
            {
                return false;
            }
        }


<<<<<<< HEAD
        public List<User> getAllUsers()//maybe add check for empty list inside try block
        {
            List<User> userList = new List<User>();
            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Customer", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User temp = new User();
                        temp.UserID = reader.GetString(0);
                        temp.Bio = reader.GetString(1);
                        temp.University = reader.GetString(2);
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
    }

=======
        public async Task<User> retrieveUser(string userName)
        {
            try
            {
                Service1Client client = new Service1Client();
                User user = await client.retrieveUserAsync(userName);
                return user;
            }
            catch (Exception e)
            {
                return new User();
            }
        }
    }
>>>>>>> a897421ad3d7416807ac4ed05d6bfbd57be4e3c6
}
