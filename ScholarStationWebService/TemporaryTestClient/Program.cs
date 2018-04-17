using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataClasses;

namespace TemporaryTestClient
{
    class TestClient
    {
        static void Main(string[] args)
        {




            AppointmentStorage a = new AppointmentStorage();
            Appointment g = new Appointment();
            g.TutorID = "12345";
            g.Timeslot = "testTimeSlot";
            Console.WriteLine(a.createNewAppointment(g));
            
            Console.ReadKey();
           
        }
    }
}
