using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorListMVCApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorBusiness doctorBusiness;

        public DoctorController(IDoctorBusiness doctorBusiness)
        {
            this.doctorBusiness = doctorBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDocDetails(string EmailID)
        {
             EmailID = (string)HttpContext.Session.GetString("EmailID");
            if (EmailID == null)
            {
                return NotFound();
            }
            UserModel user = doctorBusiness.GetDocDetail(EmailID);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult AddDoctorProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDoctorProfile(DoctorModel register)
        {
            if (ModelState.IsValid)
            {
                int UserID = (int)HttpContext.Session.GetInt32("UserID");
                int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
                var result = doctorBusiness.AddDocDetails(register);
                //HttpContext.Session.SetInt32("RoleID", result.RoleID);
                return RedirectToAction("GetAllDoc", "Admin");

                //Notification notification = new Notification
                //{
                //    Message = "You are registered successfully, you will receive confirmation mail to login.",
                //    Type = "success"
                //};
                //TempData["Notification"] = notification;

            }
            return View(register);
        }

        [HttpGet]
        public IActionResult GetDoctorDetails(int UserID)
        {
            UserID = (int)HttpContext.Session.GetInt32("UserID");
            if (UserID == null)
            {
                return NotFound();
            }
            DoctorModel user = doctorBusiness.GetDoctorDetails(UserID);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}
