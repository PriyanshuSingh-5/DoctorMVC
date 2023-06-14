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

        //public IActionResult loginchecks(UserLogin login)
        //{
        //    var data = userBusiness.GetAllDocs();
        //    var acceptedUser = data.FirstOrDefault(u => u.EmailID == login.EmailID && u.Password == login.Password);
        //    if (acceptedUser != null)
        //    {
        //        if (acceptedUser.IsAccepted.Equals(true))
        //        {
        //            userBusiness.LoginAdmin(login);
        //        }
        //        return View("Login");
        //    }
        //    return View("Login");
        //}

        //[HttpPost]
        //public IActionResult Login(UserLogin login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var data = userBusiness.GetAllDocs();

        //        var acceptedUser = data.FirstOrDefault(u => u.EmailID == login.EmailID && u.Password == login.Password);
        //        if (acceptedUser != null && acceptedUser.IsAccepted.Equals(true))
        //        {
        //            //if (acceptedUser.IsAccepted.Equals(true))
        //            //{
        //                userBusiness.LoginAdmin(login);
        //                //if (result != null)
        //                //{
        //                //    long userID = long.Parse(HttpContext.Session.GetString("UserID"));
        //                //    long RoleID = long.Parse(HttpContext.Session.GetString("RoleID"));
        //                //    if (result.RoleID == 1)
        //                //    {
        //                //        return RedirectToAction("GetAllDoc");
        //                //    }
        //                //}
        //                return RedirectToAction("GetAllDoc");
        //            //}

        //        }
        //        else
        //        {
        //            // ViewBag.msg = "you are not authorized to login yet.";
        //            Notification notification = new Notification
        //            {
        //                Message = "you are not authorized to login yet.",
        //                Type = "success"
        //            };
        //            TempData["Notification"] = notification;
        //        }



        //    }
        //    return View(login);
        //}

        [HttpPost]
        public IActionResult Login(UserLogin login)
        {
            if (ModelState.IsValid)
            {
              
              var result= userBusiness.LoginAdmin(login);
                if(result!=null)
                {
                    HttpContext.Session.SetInt32("UserID", result.UserID);
                     HttpContext.Session.SetInt32("RoleID", result.RoleID);
                    HttpContext.Session.SetString("EmailID", result.EmailID);
                    if(result.RoleID==1 && result.IsAccepted)
                    {
                        return RedirectToAction("GetAllDoc","Admin");
                    }
                    else if (result.RoleID==3 && !result.IsAccepted)
                    {
                        //ViewBag.msg = "you are not authorized to login yet.";
                        Notification notification = new Notification
                        {
                            Message = "you are not authorized to login yet.",
                            Type = "success"
                        };
                        TempData["Notification"] = notification;
                    }
                    else if (result.RoleID == 3 && result.IsAccepted)
                    {
                        //ViewBag.msg = "you are not authorized to login yet.";
                        return RedirectToAction("GetDocDetails", "Doctor");
                    }
                    else if(result.RoleID==2 && !result.IsAccepted)
                    {
                        return RedirectToAction("GetPatientDetails", "Patient");
                    }
                }

               // return RedirectToAction("Login");

            }
          
            
            return View();
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
                var result=userBusiness.RegisterCustomer(register);
                //HttpContext.Session.SetInt32("RoleID", result.RoleID);
                
                Notification notification = new Notification
                {
                    Message = "You are registered successfully, you will receive confirmation mail to login.",
                    Type = "success"
                };
                TempData["Notification"] = notification;
                
            }
            return View(register);
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