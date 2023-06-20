using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAdminBussiness
    {
        public List<UserModel> GetAllDocs();
        public List<AppointmentModel> GetAllAppointment();
    }
}
