using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class PatientBusiness :IPatientBusiness
    {
        private readonly IPatientRepo repo;
        public PatientBusiness(IPatientRepo repo)
        {
            this.repo = repo;
        }
        public PatientModel AddPatientDetails(PatientModel Account)
        {
            return repo.AddPatientDetails(Account);
        }
        public PatientModel GetPatientDetails(int UserID)
        {
            return repo.GetPatientDetails(UserID);
        }
    }
}
