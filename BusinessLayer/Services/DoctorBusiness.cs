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
        public DoctorModel GetDoctorDetails(int UserID)
        {
            return repo.GetDoctorDetails(UserID);
        }
        public ScheduleModel AddScheduleAndLocation(ScheduleModel schedule)
        {
            return repo.AddScheduleAndLocation(schedule);
        }
        public List<ScheduleModel> GetAllSchedules(int DoctorID)
        {
            return repo.GetAllSchedules(DoctorID);
        }
    }
}
