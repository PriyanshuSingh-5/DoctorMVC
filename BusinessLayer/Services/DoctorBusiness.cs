﻿using BusinessLayer.Interfaces;
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
    }
}