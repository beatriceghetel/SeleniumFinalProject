using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects.BO
{

    public class NewAddressBO
    {
        public String address { get; set; } = "Main Street no. 12";
        public String city { get; set; } = "Phoenix";
        public String state { get; set; } = "Arizona";
        public String postCode { get; set; } = "70101";
        public String country { get; set; } = "United States";
        public String mobilePhone { get; set; } = "678934561";
        public String aliasAddress { get; set; } = "My Arizona address";
    }
}
