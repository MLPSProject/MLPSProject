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

        public ActionResult Process(LoanDetail loanDetail)
        {
            var l = dbContext.LoanDetails.Include(c => c.PropertyDetail).SingleOrDefault(m => m.Id == loanDetail.Id);
            //var list = dbContext.LoanDetails.SingleOrDefault(c => c.Id==loanDetail.Id);
            return View(l);
        }

        public ActionResult StatusApproval(int loanId,int regId, string msg)
        {
            //int a = Convert.ToInt32(Request["loanId"]);
            LoanDetail loanDetail = new LoanDetail();
            loanDetail.RegisteredUserId = regId;
            loanDetail.Id = loanId;
            var loanDetails = dbContext.LoanDetails.FirstOrDefault(x => x.Id == loanId);
            if (msg == "Accepted")
            {
                loanDetails.vStatus = "Verification";
                loanDetail.vStatus = msg;
                dbContext.LoanDetails.Add(loanDetail);
                dbContext.SaveChanges();
                return RedirectToAction("Process", "Officer");
            }
            else
            {
                loanDetails.vStatus = "Rejected";
                loanDetail.vStatus = msg;
                dbContext.LoanDetails.Add(loanDetail);
                dbContext.SaveChanges();
                ViewBag.ErrorMessage = "Loan Application is Rejected";
                return RedirectToAction("Process", "Officer");
            }
        }


    }
}