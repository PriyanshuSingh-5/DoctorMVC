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
    public class AdminController : Controller
    {
        private readonly IAdminBussiness adminBusness;
        private readonly IDoctorBusiness doctorBusiness;
        public AdminController(IAdminBussiness adminBusness, IDoctorBusiness doctorBusiness)
        {
            this.adminBusness = adminBusness;
            this.doctorBusiness = doctorBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllDoc()
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 1)
            {
                List<UserModel> lstEmployee = new List<UserModel>();
                lstEmployee = adminBusness.GetAllDocs().ToList();

                return View(lstEmployee);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        public IActionResult Accept(string EmailID)
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 1)
            {
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

        [HttpPost, ActionName("Accept")]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptConfirmed(string EmailID)
        {
            var user = adminBusness.GetAllDocs();
            var result = user.Find(a => a.EmailID == EmailID);
            MSMQ mSMQModel = new MSMQ();
            mSMQModel.SendMessage(EmailID, result.FullName);
            return RedirectToAction("GetAllDoc");
        }


        [HttpGet]
        public IActionResult GetAllAppointmentsAdmin()
        {
            int RoleID = (int)HttpContext.Session.GetInt32("RoleID");
            if (RoleID == 1 || RoleID == 2)
            {

                List<AppointmentModel> list = new List<AppointmentModel>();
                list = adminBusness.GetAllAppointment().ToList();

                return View(list);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }
    }
}
