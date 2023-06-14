using BusinessLayer.Interfaces;
using CommonLayer.Models;
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
            List<UserModel> lstEmployee = new List<UserModel>();
            lstEmployee = adminBusness.GetAllDocs().ToList();

            return View(lstEmployee);
        }

        [HttpGet]
        public IActionResult Accept(string EmailID)
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
    }
}
