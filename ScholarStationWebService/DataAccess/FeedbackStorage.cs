using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
namespace DataAccess
{
    public class FeedbackStorage: IFeedbackStorage
    {
        private string ConnectionString;

        public FeedbackStorage()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "se2group2.database.windows.net";
            builder.UserID = "ScholarStationAdmin";
            builder.Password = "scholarGroup2";
            builder.InitialCatalog = "SoftwareEngineeringGroup2";
            ConnectionString = builder.ConnectionString;
        }

        public bool submitFeedback(int score, string rate, string target)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update feedback set rating = @rating where target = @target AND rater = @rater if @@ROWCOUNT = 0 INSERT INTO feedback(target, rater, rating) values('testUser18', 'testUser1', 4)", con);
                    cmd.Parameters.AddWithValue("@target", target);
                    cmd.Parameters.AddWithValue("@rater", rate);
                    cmd.Parameters.AddWithValue("@rating", score);

                    cmd.ExecuteNonQuery();
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
