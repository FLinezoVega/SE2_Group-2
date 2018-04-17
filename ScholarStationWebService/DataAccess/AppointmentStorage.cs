using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataClasses;

namespace DataAccess
{
    public class AppointmentStorage : IAppointmentStorage
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
                    if (appt.ClientID != null)
                    {
                        cmd.Parameters.AddWithValue("@clientID", appt.ClientID);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@clientID", DBNull.Value);
                    }
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


        public List<Appointment> getAllAppointmentsByTutor(string tutorID)
        {
            List<Appointment> appList = new List<Appointment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Appointment WHERE tutorID = @tutorID", connection);
                    cmd.Parameters.AddWithValue("@tutorID", tutorID);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    //Console.WriteLine("here1");
                    while (reader.HasRows)
                    {
                        
                        Appointment a = new Appointment();
                        reader.Read();
                        a.TutorID = reader.GetString(0);
                        a.ClientID = (reader.GetValue(1).ToString());
                        a.Timeslot = reader.GetString(2);
                        appList.Add(a);
                    }
                    return appList;
                }
            }
            catch (Exception e)
            {
                appList.Add(new Appointment());
                //Console.WriteLine("weeeeee");
                return appList;
            }
        }


        public List<Appointment> getAllEmptyAppointmentsByTutor(string tutorID)
        {
            List<Appointment> appList = new List<Appointment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Appointment WHERE tutorID = @tutorID AND clientID IS NULL", connection);
                    cmd.Parameters.AddWithValue("@tutorID", tutorID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.HasRows)
                    {

                        Appointment a = new Appointment();
                        reader.Read();
                        a.TutorID = reader.GetString(0);
                        a.ClientID = (reader.GetValue(1).ToString());
                        a.Timeslot = reader.GetString(2);
                        appList.Add(a);
                    }
                    return appList;
                }
            }
            catch (Exception e)
            {
                appList.Add(new Appointment());
                return appList;
            }
        }

        public List<Appointment> getAllFilledAppointmentsByTutor(string tutorID)
        {
            List<Appointment> appList = new List<Appointment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Appointment WHERE tutorID = @tutorID AND clientID IS NOT NULL", connection);
                    cmd.Parameters.AddWithValue("@tutorID", tutorID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.HasRows)
                    {

                        Appointment a = new Appointment();
                        reader.Read();
                        a.TutorID = reader.GetString(0);
                        a.ClientID = (reader.GetValue(1).ToString());
                        a.Timeslot = reader.GetString(2);
                        appList.Add(a);
                    }
                    return appList;
                }
            }
            catch (Exception e)
            {
                appList.Add(new Appointment());
                return appList;
            }
        }


        public List<Appointment> getAllAppointmentsByClient(string clientID)
        {
            List<Appointment> appList = new List<Appointment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Appointment WHERE clientID = @clientID", connection);
                    cmd.Parameters.AddWithValue("@clientID", clientID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.HasRows)
                    {

                        Appointment a = new Appointment();
                        reader.Read();
                        a.TutorID = reader.GetString(0);
                        a.ClientID = (reader.GetValue(1).ToString());
                        a.Timeslot = reader.GetString(2);
                        appList.Add(a);
                    }
                    return appList;
                }
            }
            catch (Exception e)
            {
                appList.Add(new Appointment());
                return appList;
            }
        }
    }
}

