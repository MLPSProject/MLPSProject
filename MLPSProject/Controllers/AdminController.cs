using MLPSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MLPSProject.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public AdminController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.vEmailID == employee.vEmailID && e.vPassword == employee.vPassword);
            Session["User"] = employee.vEmailID;
            if (emp != null)
            {
                if (employee.vDesignation == "Officer")
                {
                    Session["Officer"] = employee.Id;
                    return RedirectToAction("Index", "Officer",new { id = employee.Id});
                }
                else if (employee.vDesignation == "Inspector")
                {
                    return RedirectToAction("Index", "Inspector");
                }
                else if (employee.vDesignation == "Authorizer")
                {
                    return RedirectToAction("Index", "Authorizer");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //FormsAuthentication.SignOut();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Admin");
        }

    }
}