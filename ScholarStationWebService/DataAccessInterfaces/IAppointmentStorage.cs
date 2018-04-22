using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;

namespace DataAccessInterfaces
{
    public interface IAppointmentStorage
    {
        bool createNewAppointment(Appointment appt);
        List<Appointment> getAllAppointmentsByTutor(string tutorID);
        List<Appointment> getAllEmptyAppointmentsByTutor(string tutorID);
        List<Appointment> getAllFilledAppointmentsByTutor(string tutorID);
        List<Appointment> getAllAppointmentsByClient(string clientID);
        bool updateAppointment(Appointment appt);



    }
}
