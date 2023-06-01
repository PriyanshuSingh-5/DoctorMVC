using BusinessLayer.Interfaces;
using CommonLayer.Models;
using DoctorListMVCApp.Models;
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
                return RedirectToAction("GetAllDoc");
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
                Notification notification = new Notification
                {
                    Message = "You are registered successfully, you will receive confirmation mail to login.",
                    Type = "success"
                };
                TempData["Notification"] = notification;
                
            }
            return View(register);
        }
        [HttpGet]
        public IActionResult GetAllDoc()
        {
            List<UserModel> lstEmployee = new List<UserModel>();
            lstEmployee = userBusiness.GetAllDocs().ToList();

            return View(lstEmployee);
        }

        [HttpGet]
        public IActionResult Accept(string EmailID)
        {
            if (EmailID == null)
            {
                return NotFound();
            }
            UserModel user = userBusiness.GetDocDetail(EmailID);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Accept")]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptConfirmed(string EmailID)
        {
            var user = userBusiness.GetAllDocs();
            var result = user.Find(a => a.EmailID == EmailID);
            MSMQ mSMQModel = new MSMQ();
            mSMQModel.SendMessage(EmailID,result.FullName);
            return RedirectToAction("GetAllDoc");
        }
    }
}
//if (recordCreated)
//{
//    Notification notification = new Notification
//    {
//        Message = "Record created successfully.",
//        Type = "success"
//    };

//    TempData["Notification"] = notification;