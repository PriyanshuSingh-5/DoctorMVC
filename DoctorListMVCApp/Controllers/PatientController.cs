using BusinessLayer.Interfaces;
using CommonLayer.Models;
using DoctorListMVCApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace DoctorListMVCApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientBusiness patient;
        public PatientController(IPatientBusiness patient)
        {
            this.patient = patient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPatientProfile()
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID  == 2)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpPost]
        public IActionResult AddPatientProfile(PatientModel register)
        {
            if (ModelState.IsValid)
            {
                int UserID = (int)HttpContext.Session.GetInt32("UserID");
                var result = patient.AddPatientDetails(register);
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
        public IActionResult GetPatientDetails(int UserID) 
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 2)
            {
                UserID = (int)HttpContext.Session.GetInt32("UserID");
            if (UserID == null)
            {
                return NotFound();
            }
            PatientModel user = patient.GetPatientDetails(UserID);

            if (user != null)
            {
                HttpContext.Session.SetInt32("PatientID", user.PatientID);
                    
                return View(user);
            }
             //HttpContext.Session.SetInt32("PatientID", user.PatientID);
                return NotFound();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }


        }


        [HttpGet]
        public IActionResult AddAppointment()
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            string EmailID = HttpContext.Session.GetString("EmailID");
            if (RoleID == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult AddAppointment(AppointmentModel add)
        {
            if (ModelState.IsValid)
            {
               int PatientID= (int)HttpContext.Session.GetInt32("PatientID");
                int DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
                //string EmailID = HttpContext.Session.GetString("EmailID");
                //string FullName = HttpContext.Session.GetString();
               
                //int UserID = (int)HttpContext.Session.GetInt32("UserID");
                var result = patient.AddAppointments(add);
                return RedirectToAction("GetAllDoc", "Admin");

               

            }
            return View(add);
        }

        [HttpGet]
        public IActionResult GetAllAppointmentbyPatient()
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 2)
            {
                int PatientID = (int)HttpContext.Session.GetInt32("PatientID");
            List<AppointmentModel> list = new List<AppointmentModel>();
            list = patient.GetAppointmentByPatientID(PatientID).ToList();

            return View(list);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

    }
}
