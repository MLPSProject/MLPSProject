﻿using MLPSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MLPSProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult RegisteredLogin()
        {
            var UserPersist = TempData["User"];
            //if (TempData["IsError"] != null)
            //{
                ViewBag.IsError = "Invalid login attempt";
            //}
            return View();
        }

        [HttpPost]
        public ActionResult RegisteredLogin(RegisteredUser registeredUser)
        {
            var userName = dbContext.RegisteredUsers.SingleOrDefault(c => c.vEmailID == registeredUser.vEmailID && c.vPassword == registeredUser.vPassword);
            Session["User"] = registeredUser.vEmailID;
            Session["regId"] = userName.Id;
            if (userName != null)
            {
                return RedirectToAction("Index", "Customer",new { id = userName.Id});
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                ViewBag.IsError = "Invalid login attempt";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult UnRegisteredLogin()
        {
            return View();
        }


        public ActionResult UnRegisteredUserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnRegisteredUserLogin(UnRegisteredUser unRegisteredUser)
        {
            var customer = dbContext.UnRegisteredUsers.SingleOrDefault(c => c.vEmailID == unRegisteredUser.vEmailID && c.vMobile == unRegisteredUser.vMobile);
            if (customer != null)
            {
                return RedirectToAction("Index", "Loan");
            }
            else
            {
                return RedirectToAction("UnRegisteredLogin");
            }
            
        }


        [HttpGet]
        public ActionResult Enquiry()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UnRegisterApply()
        {
            return View();
        }


        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}