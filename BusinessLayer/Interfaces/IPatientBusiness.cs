using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IPatientBusiness
    {
        public PatientModel AddPatientDetails(PatientModel Account);
        public PatientModel GetPatientDetails(int UserID);
    }
}
