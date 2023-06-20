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
            return View();
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


        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAppointment(AppointmentModel add)
        {
            if (ModelState.IsValid)
            {
               int PatientID= (int)HttpContext.Session.GetInt32("PatientID");
                int DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
                //int UserID = (int)HttpContext.Session.GetInt32("UserID");
                var result = patient.AddAppointments(add);
                return RedirectToAction("GetAllDoc", "Admin");

               

            }
            return View(add);
        }

        [HttpGet]
        public IActionResult GetAllAppointmentbyPatient()
        {
            int PatientID = (int)HttpContext.Session.GetInt32("PatientID");
            List<AppointmentModel> list = new List<AppointmentModel>();
            list = patient.GetAppointmentByPatientID(PatientID).ToList();

            return View(list);
        }

    }
}
