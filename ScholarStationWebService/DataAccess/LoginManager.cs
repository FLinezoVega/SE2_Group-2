using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessInterfaces
{
    public class LoginManager : ILoginManager
    {
        private string ConnectionString;

        public LoginManager()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "se2group2.database.windows.net";
            builder.UserID = "ScholarStationAdmin";
            builder.Password = "scholarGroup2";
            builder.InitialCatalog = "SoftwareEngineeringGroup2";
            ConnectionString = builder.ConnectionString;
        }


        public bool checkExisting(string userName)// int hashedPassword)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from Login WHERE userName = @userName", con);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public bool checkExisting(string userName,string password)// int hashedPassword)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from Login WHERE userName = @userName AND password = @password", con);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count =(int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }
                return true;//add test to check if ExecuteNonQuery is 1 or whatever the value is
            }
            catch (SqlException e)
            {//FIX this, maybe
                return false;
            }
        }

        public bool createNewAccount(string userName, string password)//not tested at all, be sure to test this to make sure it works
        {

            if (checkExisting(userName, password))
            {
                return false;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand newUserCmd = new SqlCommand("Insert into Login(userName, PassHash,  password) values(@userName, @passHash, @password)", con);
                    newUserCmd.Parameters.AddWithValue("@userName", userName);
                    newUserCmd.Parameters.AddWithValue("@passHash", 12345);
                    newUserCmd.Parameters.AddWithValue("@password", password);
                    newUserCmd.ExecuteNonQuery();
                }
                return true;//add test to check if ExecuteNonQuery is 1 or whatever the value is
            }
            catch (SqlException e)
            {//FIX this, maybe
                return false;
            }
        }

    }
}
