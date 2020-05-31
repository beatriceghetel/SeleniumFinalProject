using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects.BO
{

    public class RegisterAccountBO
    {
        // Customer details
        public int Title { get; set; } = 0;
        public String customerFirstName { get; set; } = "Ionescu";
        public String customerLastName { get; set; } = "Vasile";
        // public String email { get; set; } = "vasile.ionescu@mail.com";   // AUTOFILLED FROM REGISTER
        public String password { get; set; } = "VasileIonescu";
        public String days { get; set; } = "27";    // PART OF BIRTH DATE
        public String months { get; set; } = "April";    // PART OF BIRTH DATE
        public String years { get; set; } = "1995";     // PART OF BIRTH DATE


        // Address details
        public String firstName { get; set; } = "Ionescu";
        public String lastName { get; set; } = "Vasile";
        public String address { get; set; } = "Main Street no. 14";
        public String city { get; set; } = "Denver";
        public String state { get; set; } = "Colorado";
        public String postCode { get; set; } = "70123";
        public String country { get; set; } = "United States";
        public String mobilePhone { get; set; } = "1231231234";
        public String aliasAddress { get; set; } = "My Colorado Address";
    }
}
