using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class DoctorBusiness: IDoctorBusiness
    {
        private readonly IDoctorRepo repo;
        public DoctorBusiness(IDoctorRepo repo)
        {
            this.repo = repo;
        }
        public UserModel GetDocDetail(string EmailID)
        {
            return this.repo.GetDocDetail(EmailID);
        }
        public DoctorModel AddDocDetails(DoctorModel Account)
        {
            return repo.AddDocDetails(Account);
        }

        public DoctorModel UpdateDocDetails(DoctorModel Account)
        {
            return repo.UpdateDocDetails(Account);
        }
        public DoctorModel GetDoctorDetails(int UserID)
        {
            return repo.GetDoctorDetails(UserID);
        }

        public DoctorModel GetDoctorByDocID(int DoctorID)
        {
            return repo.GetDoctorByDocID(DoctorID);
        }
        public ScheduleModel AddScheduleAndLocation(ScheduleModel schedule)
        {
            return repo.AddScheduleAndLocation(schedule);
        }
        public List<ScheduleModel> GetAllSchedules(int DoctorID)
        {
            return repo.GetAllSchedules(DoctorID);
        }

        public List<DoctorModel> GetAllDoctorProfile()
        {
            return repo.GetAllDoctorProfile();
        }
        public List<AppointmentModel> GetAppointmentByDocID(int DoctorID)
        {
            return repo.GetAppointmentByDocID(DoctorID);
        }
        public AppointmentModel ConfirmAppointment(int PatientID)
        {
            return repo.ConfirmAppointment(PatientID);
        }
    }
}
