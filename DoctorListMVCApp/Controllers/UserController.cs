using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorListMVCApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBusiness userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                userBusiness.LoginAdmin(login);
                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel register)
        {
            if (ModelState.IsValid)
            {
                userBusiness.RegisterCustomer(register);
                return RedirectToAction("Index", "Home");
            }
            return View(register);
        }
    }
}
