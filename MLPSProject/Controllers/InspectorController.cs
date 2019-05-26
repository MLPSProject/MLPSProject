using MLPSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MLPSProject.Controllers
{
    public class InspectorController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public InspectorController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Inspector
        public ActionResult Index(LoanDetail loanDetail)
        {
            var l = dbContext.LoanDetails.Include(c => c.PropertyDetail).SingleOrDefault(m => m.Id == loanDetail.Id);
            //var list = dbContext.LoanDetails.SingleOrDefault(c => c.Id==loanDetail.Id);
            return View(l);
        }
    }
}