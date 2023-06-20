using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IDoctorRepo
    {
        public UserModel GetDocDetail(string EmailID);
        public DoctorModel AddDocDetails(DoctorModel Account);
        public DoctorModel GetDoctorDetails(int UserID);
        public DoctorModel GetDoctorByDocID(int DoctorID);
        public ScheduleModel AddScheduleAndLocation(ScheduleModel schedule);
        public List<ScheduleModel> GetAllSchedules(int DoctorID);
        public List<DoctorModel> GetAllDoctorProfile();
        public List<AppointmentModel> GetAppointmentByDocID(int DoctorID);
    }
}
