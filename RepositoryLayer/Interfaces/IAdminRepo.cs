using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAdminRepo
    {
        public List<UserModel> GetAllDocs();
        public List<AppointmentModel> GetAllAppointment();
    }
}
