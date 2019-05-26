using MLPSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MLPSProject.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Customer
        public ActionResult Index(RegisteredUser registeredUser /*,int id*/)
        {
            dbContext.RegisteredUsers.SingleOrDefault(c => c.Id == registeredUser.Id);
            LoanDetail loanDetail = new LoanDetail();
            //loanDetail.RegisteredUserId = id;
            return View(loanDetail);
        }

        [HttpPost]
        public ActionResult Index(LoanDetail loanDetail,RegisteredUser registeredUser)
        {
            dbContext.LoanDetails.Add(loanDetail);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult ApplyLoan()
        {
            return View();
        }

        public ActionResult EMICalculator()
        {
            return View();
        }
    }
}