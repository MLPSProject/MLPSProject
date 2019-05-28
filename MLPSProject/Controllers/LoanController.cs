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

        public ActionResult Self(int id,int regisId)
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
        public ActionResult Others(PropertyDetail propertyDetail,  RegisteredUser registeredUser,HttpPostedFileBase IdProofDoc, HttpPostedFileBase AddressProofDoc, HttpPostedFileBase PropertyAgreementDoc)
        {
            var userName = dbContext.RegisteredUsers.SingleOrDefault(c => c.vEmailID == registeredUser.vEmailID && c.vPassword == registeredUser.vPassword);
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(IdProofDoc.InputStream))
            {
                bytes = br.ReadBytes(IdProofDoc.ContentLength);
            }
            byte[] bytes2;
            using (BinaryReader br2 = new BinaryReader(AddressProofDoc.InputStream))
            {
                bytes2 = br2.ReadBytes(AddressProofDoc.ContentLength);
            }
            byte[] bytes3;
            using (BinaryReader br3 = new BinaryReader(PropertyAgreementDoc.InputStream))
            {
                bytes3 = br3.ReadBytes(PropertyAgreementDoc.ContentLength);
            }
            int pId = propertyDetail.Id;
            dbContext.PropertyDetails.Add(new PropertyDetail
            {
                IdProof = bytes,
                AddressProof = bytes2,
                PropertyAgreement = bytes3,
                vPropertyHolderName = propertyDetail.vPropertyHolderName,
                vPropertyType = propertyDetail.vPropertyType,
                PropertyAddress = propertyDetail.PropertyAddress
            });
            //dbContext.PropertyDetails.Add(propertyDetail);
            
            dbContext.SaveChanges();
            var larId = dbContext.PropertyDetails.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            var regID = Session["regId"];
            return RedirectToAction("Self", "Loan", new { id = larId.Id, regisId = regID });

            
        }

        


    }
}