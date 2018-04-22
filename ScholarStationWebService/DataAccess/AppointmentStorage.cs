using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataClasses;
using DataAccessInterfaces;

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
                    SqlCommand cmd = new SqlCommand("Insert into Appointment(tutorID, timeslot) values(@tutorID, @timeslot)", con);

                    cmd.Parameters.AddWithValue("@tutorID", appt.TutorID);

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

        public bool updateAppointment(Appointment appt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Appointment set clientID =@clientID, clientMail = @clientMail where ID = @ID", con);
                    cmd.Parameters.AddWithValue("@tutorID", appt.TutorID);
                    if (!String.IsNullOrEmpty(appt.ClientID))
                    {
                        cmd.Parameters.AddWithValue("@clientID", appt.ClientID);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@clientID", DBNull.Value);
                    }

                    if (!String.IsNullOrEmpty(appt.ClientMail))
                    {
                        cmd.Parameters.AddWithValue("@clientMail", appt.ClientMail);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@clientMail", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@ID", appt.ID);

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
                    SqlCommand cmd = new SqlCommand("Select * From Appointment WHERE tutorID = @tutorID order by timeslot", connection);
                    cmd.Parameters.AddWithValue("@tutorID", tutorID);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    //Console.WriteLine("here1");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Appointment a = new Appointment();

                            //a.TutorID = reader.GetString(0);
                            a.TutorID = reader.GetValue(0) == DBNull.Value ? "..." : reader.GetValue(0).ToString();
                            // a.ClientID = (reader.GetValue(1).ToString());
                            a.ClientID = reader.GetValue(1) == DBNull.Value ? "..." : reader.GetValue(1).ToString();
                            // a.Timeslot = reader.GetString(2);
                            a.Timeslot = reader.GetValue(2) == DBNull.Value ? "..." : reader.GetValue(2).ToString();
                            a.ID = (int)reader.GetValue(3);
                           /// a.ClientMail = reader.GetString(4);
                            a.ClientMail = reader.GetValue(4) == DBNull.Value ? "..." : reader.GetValue(4).ToString();
                            appList.Add(a);
                        }
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
                    SqlCommand cmd = new SqlCommand("Select * From Appointment WHERE tutorID = @tutorID AND clientID IS NULL order by timeslot", connection);
                    cmd.Parameters.AddWithValue("@tutorID", tutorID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Appointment a = new Appointment();

                            //a.TutorID = reader.GetString(0);
                            a.TutorID = reader.GetValue(0) == DBNull.Value ? "..." : reader.GetValue(0).ToString();
                            // a.ClientID = (reader.GetValue(1).ToString());
                            a.ClientID = reader.GetValue(1) == DBNull.Value ? "..." : reader.GetValue(1).ToString();
                            // a.Timeslot = reader.GetString(2);
                            a.Timeslot = reader.GetValue(2) == DBNull.Value ? "..." : reader.GetValue(2).ToString();
                            a.ID = (int)reader.GetValue(3);
                            /// a.ClientMail = reader.GetString(4);
                            a.ClientMail = reader.GetValue(4) == DBNull.Value ? "..." : reader.GetValue(4).ToString();
                            appList.Add(a);
                        }
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
                    SqlCommand cmd = new SqlCommand("Select * From Appointment WHERE tutorID = @tutorID AND clientID IS NOT NULL order by timeslot", connection);
                    cmd.Parameters.AddWithValue("@tutorID", tutorID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Appointment a = new Appointment();

                            //a.TutorID = reader.GetString(0);
                            a.TutorID = reader.GetValue(0) == DBNull.Value ? "..." : reader.GetValue(0).ToString();
                            // a.ClientID = (reader.GetValue(1).ToString());
                            a.ClientID = reader.GetValue(1) == DBNull.Value ? "..." : reader.GetValue(1).ToString();
                            // a.Timeslot = reader.GetString(2);
                            a.Timeslot = reader.GetValue(2) == DBNull.Value ? "..." : reader.GetValue(2).ToString();
                            a.ID = (int)reader.GetValue(3);
                            /// a.ClientMail = reader.GetString(4);
                            a.ClientMail = reader.GetValue(4) == DBNull.Value ? "..." : reader.GetValue(4).ToString();
                            appList.Add(a);
                        }
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
                    SqlCommand cmd = new SqlCommand("Select * From Appointment WHERE clientID = @clientID order by timeslot", connection);
                    cmd.Parameters.AddWithValue("@clientID", clientID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Appointment a = new Appointment();

                            //a.TutorID = reader.GetString(0);
                            a.TutorID = reader.GetValue(0) == DBNull.Value ? "..." : reader.GetValue(0).ToString();
                            // a.ClientID = (reader.GetValue(1).ToString());
                            a.ClientID = reader.GetValue(1) == DBNull.Value ? "..." : reader.GetValue(1).ToString();
                            // a.Timeslot = reader.GetString(2);
                            a.Timeslot = reader.GetValue(2) == DBNull.Value ? "..." : reader.GetValue(2).ToString();
                            a.ID = (int)reader.GetValue(3);
                            /// a.ClientMail = reader.GetString(4);
                            a.ClientMail = reader.GetValue(4) == DBNull.Value ? "..." : reader.GetValue(4).ToString();
                            appList.Add(a);
                        }
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

