using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IDoctorRepo
    {
        public UserModel GetDocDetail(string EmailID);
    }
}
