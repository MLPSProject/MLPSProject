using MLPSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            if (Session["User"] != null)
            {
                var list = dbContext.LoanDetails.Include(c => c.PropertyDetail).ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
            
        }

        public ActionResult Pending()
        {
            var list = dbContext.LoanDetails.Include(c => c.PropertyDetail).ToList();
            return View(list);
        }

        public ActionResult Process()
        {
            return View();
        }

       
    }
}