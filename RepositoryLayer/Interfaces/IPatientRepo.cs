using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IPatientRepo
    {
        public PatientModel AddPatientDetails(PatientModel Account);
        public PatientModel GetPatientDetails(int UserID);

        public AppointmentModel AddAppointments(AppointmentModel Account);

        public List<AppointmentModel> GetAppointmentByPatientID(int PatientID);
    }
}
