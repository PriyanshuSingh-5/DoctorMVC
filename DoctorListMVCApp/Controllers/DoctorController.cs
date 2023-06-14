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

    }
}
