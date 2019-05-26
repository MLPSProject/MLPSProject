using MLPSProject.Models;
using MLPSProject.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLPSProject.Controllers
{
    public class LoanController : Controller
    {
        static string upload1 = "";
        static string upload2 = "";
        static string upload3 = "";

        private ApplicationDbContext dbContext = null;
        public LoanController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Self(int id)
        {
            LoanDetail loanDetail = new LoanDetail();
            loanDetail.PropertyDetailId = id;
            var regid = Session["regId"];
            loanDetail.RegisteredUserId = Convert.ToInt32(regid);
            return View(loanDetail);
        }

        [HttpPost]
        public ActionResult Self(LoanDetail loanDetail, PropertyDetail propertyDetail)
        {
            dbContext.LoanDetails.Add(loanDetail);
            var regid = Session["regId"];
            
            //dbContext.PropertyDetails.Add(propertyDetail);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Loan");
        }

        public ActionResult Others()
        {
            //LoanPropertyViewModel viewModel = new LoanPropertyViewModel();
            //LoanDetail loanDetail = new LoanDetail();
            //PropertyDetail propertyDetail = new PropertyDetail();
            //viewModel.LoanDetail = loanDetail;
            //viewModel.PropertyDetail = propertyDetail;
            return View();
        }

        [HttpPost]
        public ActionResult Others(PropertyDetail propertyDetail, RegisteredUser registeredUser)
        {
            var userName = dbContext.RegisteredUsers.SingleOrDefault(c => c.vEmailID == registeredUser.vEmailID && c.vPassword == registeredUser.vPassword);

            dbContext.PropertyDetails.Add(propertyDetail);
            dbContext.SaveChanges();
            return RedirectToAction("Self", "Loan", new { id = propertyDetail.Id });

            //LoanPropertyViewModel viewModel = new LoanPropertyViewModel();
            //LoanDetail detail = new LoanDetail();
            //PropertyDetail propertyDetail1 = new PropertyDetail();
            //viewModel.LoanDetail = detail;
            //viewModel.PropertyDetail = propertyDetail;
            //return View(viewModel);
        }

        public void UploadIDProof(PropertyDetail propertyDetail, HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string File = string.Format("{0}.{1}", Guid.NewGuid(), Path.GetFileName(ImageFile.FileName));
            string extension = Path.GetExtension(ImageFile.FileName);
            string targetPath = @"E:\MLPSProject\MLPSProject\documents";
            fileName = Path.Combine(targetPath, fileName);
            LoanController.upload1 = fileName;
            ImageFile.SaveAs(fileName);

        }

        public void UploadIDProof1(HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string File = string.Format("{0}.{1}", Guid.NewGuid(), Path.GetFileName(ImageFile.FileName));
            string extension = Path.GetExtension(ImageFile.FileName);
            string targetPath = @"E:\MLPSProject\MLPSProject\documents";
            fileName = Path.Combine(targetPath, fileName);
            LoanController.upload2 = fileName;
            ImageFile.SaveAs(fileName);

        }
        public void UploadIDProof3(HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string File = string.Format("{0}.{1}", Guid.NewGuid(), Path.GetFileName(ImageFile.FileName));
            string extension = Path.GetExtension(ImageFile.FileName);
            string targetPath = @"E:\MLPSProject\MLPSProject\documents";
            fileName = Path.Combine(targetPath, fileName);
            LoanController.upload3 = fileName;
            ImageFile.SaveAs(fileName);

        }


    }
}