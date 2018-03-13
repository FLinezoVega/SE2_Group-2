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
        public string GetData(string value)
        {
            string output = "aaa";

            for (int i = value.Length - 1; i >= 0; i--)
            {
                output += value[i];
            }

            return output;
        }


        public string getUsers()
        {

            StringBuilder output = new StringBuilder();
            try
            {
                //return "got here";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "se2group2.database.windows.net";
                builder.UserID = "ScholarStationAdmin";
                builder.Password = "scholarGroup2";
                builder.InitialCatalog = "SoftwareEngineeringGroup2";

                string query = "SELECT * FROM TestUser";

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


        public User getTestUser(string name, string bio)
        {
            User temp = new User();
            temp.Bio = bio;
            temp.UserID = name;

            return temp;
        }
        
    }
}
