using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBusiness
    {
        public UserModel LoginAdmin(UserLogin loginAccount);
        public UserModel RegisterCustomer(UserModel registerAccount);
        //public List<UserModel> GetAllDocs();
        //public UserModel GetDocDetail(string EmailID);
    }
}
