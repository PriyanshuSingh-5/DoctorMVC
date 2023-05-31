using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBusiness
    {
        public bool LoginAdmin(UserLogin loginAccount);
        public UserModel RegisterCustomer(UserModel registerAccount);
        public List<UserModel> GetAllBook();
    }
}
