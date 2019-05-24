using MLPSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLPSProject.ViewModel
{
    public class LoanRegisterUnRegisterViewModel
    {
        public RegisteredUser RegisteredUser { get; set; }
        public UnRegisteredUser UnRegisteredUser { get; set; }
        public LoanDetail LoanDetail { get; set; }

    }
}