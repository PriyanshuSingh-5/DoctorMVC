using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepo repo;
        public UserBusiness(IUserRepo repo)
        {
            this.repo = repo;
        }

        public UserModel LoginAdmin(UserLogin loginAccount)
        {
            return repo.LoginAdmin(loginAccount);
        }
        public UserModel RegisterCustomer(UserModel registerAccount)
        {
            return repo.RegisterCustomer(registerAccount);
        }
        
    }
}
