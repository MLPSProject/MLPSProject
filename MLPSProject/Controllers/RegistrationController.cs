using MLPSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLPSProject.Controllers
{
    public class RegistrationController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public RegistrationController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisteredUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisteredUser(RegisteredUser registeredUser)
        {
            dbContext.RegisteredUsers.Add(registeredUser);
            registeredUser.dtDateOfRegistration = DateTime.Now.ToString("yyyy-mm-dd");
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UnRegisteredUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnRegisteredUser(UnRegisteredUser unRegisteredUser)
        {
            dbContext.UnRegisteredUsers.Add(unRegisteredUser);
            unRegisteredUser.dtDateOfRegistration = DateTime.Now.ToString("yyyy-mm-dd");
            dbContext.SaveChanges();
            return RedirectToAction("UnRegisteredLogin", "Home");
        }
    }
}