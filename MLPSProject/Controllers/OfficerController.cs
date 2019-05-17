using MLPSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLPSProject.Controllers
{
    public class OfficerController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public OfficerController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Officer
        public ActionResult Index()
        {
            Employee employee = new Employee();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //var userId = User.Identity.GetUserId();
            }
                return View();
        }

        public ActionResult Pending()
        {
            return View();
        }

        public ActionResult Process()
        {
            return View();
        }

       
    }
}