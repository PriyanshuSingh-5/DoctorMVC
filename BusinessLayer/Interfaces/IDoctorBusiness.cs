﻿using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IDoctorBusiness
    {
        public UserModel GetDocDetail(string EmailID);
        public DoctorModel AddDocDetails(DoctorModel Account);
        public DoctorModel GetDoctorDetails(int UserID);
    }
}
