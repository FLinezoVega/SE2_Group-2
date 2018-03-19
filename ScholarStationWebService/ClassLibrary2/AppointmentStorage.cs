using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataClasses;

namespace DataAccess
{
    public class AppointmentStorage
    {
        string ConnectionString;

        public AppointmentStorage()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "se2group2.database.windows.net";
            builder.UserID = "ScholarStationAdmin";
            builder.Password = "scholarGroup2";
            builder.InitialCatalog = "SoftwareEngineeringGroup2";
            ConnectionString = builder.ConnectionString;
        }

        public bool createNewAppointment(Appointment appt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Appointment(tutorID, clientID, timeslot) values(@tutorID, @clientID, @timeslot)", con);
                    cmd.Parameters.AddWithValue("@tutorID", appt.TutorID);
                    cmd.Parameters.AddWithValue("@clientID", appt.ClientID);
                    cmd.Parameters.AddWithValue("@timeslot", appt.Timeslot);
                    cmd.ExecuteNonQuery();
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
