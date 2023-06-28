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
        private readonly IPatientBusiness patientBusiness;

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
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 3)
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
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        public IActionResult AddDoctorProfile()
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID ==  3)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
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
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 3)
            {
                UserID = (int)HttpContext.Session.GetInt32("UserID");
            if (UserID == null)
            {
                return NotFound();
            }
            DoctorModel user = doctorBusiness.GetDoctorDetails(UserID);

            if (user != null)
            {
                HttpContext.Session.SetInt32("DoctorID", user.DoctorID);
                return View(user);
            }
            return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpGet]
        public IActionResult GetDoctorByDocID(int DoctorID)
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 3 || RoleID == 2)
            {
                DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
            if (DoctorID == null)
            {
                return NotFound();
            }
            DoctorModel user = doctorBusiness.GetDoctorByDocID(DoctorID);

            if (user != null)
            {
               // HttpContext.Session.SetInt32("DoctorID", user.DoctorID);
                return View(user);
            }
            return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpGet]
        public IActionResult AddDocSchedule()
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 3)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }


        [HttpPost]
        public IActionResult AddDocSchedule(ScheduleModel schedule)
        {
            if (ModelState.IsValid)
            {

                int DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
                var result = doctorBusiness.AddScheduleAndLocation(schedule);

                return RedirectToAction("GetAllDoc", "Admin");


            }
            return View(schedule);
        }

        [HttpGet]
        public IActionResult GetAllSchedules()
        {
            int DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
            List<ScheduleModel> list = new List<ScheduleModel>();
            list = doctorBusiness.GetAllSchedules(DoctorID).ToList();

            return View(list);
        }

        [HttpGet]
        public IActionResult GetAllDocProfile()
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 1 || RoleID == 2)
            {

                //int DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
                List<DoctorModel> list = new List<DoctorModel>();
                list = doctorBusiness.GetAllDoctorProfile().ToList();
                foreach (DoctorModel doctors in list)
                {
                    int DoctorID = doctors.DoctorID;
                    HttpContext.Session.SetInt32("DoctorID", DoctorID);
                }
                return View(list);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpGet]
        public IActionResult GetAllAppointment()
        {
            int DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
            List<AppointmentModel> list = new List<AppointmentModel>();
            list = doctorBusiness.GetAppointmentByDocID(DoctorID).ToList();

            return View(list);
        }


        [HttpGet]
        public IActionResult UpdateDoctorByDocID(int DoctorID)
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 3 )
            {
                DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
                if (DoctorID == null)
                {
                    return NotFound();
                }
                DoctorModel user = doctorBusiness.GetDoctorByDocID(DoctorID);

                if (user != null)
                {
                    // HttpContext.Session.SetInt32("DoctorID", user.DoctorID);
                    return View(user);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDoctorByDocID([Bind] DoctorModel model)
        {
           int DoctorID = (int)HttpContext.Session.GetInt32("DoctorID");
            if (DoctorID != model.DoctorID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                doctorBusiness.UpdateDocDetails(model);
                return RedirectToAction("GetDoctorByDocID");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Accept(int PatientID)
        {
            PatientID = (int)HttpContext.Session.GetInt32("PatientID");
            int UserID =(int)HttpContext.Session.GetInt32("UserID");

            if (PatientID == null)
            {
                return NotFound();
            }
            PatientModel user = patientBusiness.GetPatientDetails(UserID);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }

        //[HttpPost, ActionName("Accept")]
        //[ValidateAntiForgeryToken]
        //public IActionResult AcceptConfirmed(string EmailID)
        //{
        //  int  PatientID = (int)HttpContext.Session.GetInt32("PatientID");
        //    var user = doctorBusiness.ConfirmAppointment(PatientID);
        //    //var result = user.Find(a => a.EmailID == EmailID);
        //    MSMQ mSMQModel = new MSMQ();
        //    mSMQModel.SendMessage(EmailID, result.FullName);
        //    return RedirectToAction("GetAllDoc");
        //}
    }
}
