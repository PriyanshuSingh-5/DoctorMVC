using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AdminBussiness : IAdminBussiness
    {
        private readonly IAdminRepo adminRepo;
        public AdminBussiness(IAdminRepo adminRepo)
        {
            this.adminRepo = adminRepo;
        }
        public List<UserModel> GetAllDocs()
        {
            return adminRepo.GetAllDocs();
        }
    }
}
