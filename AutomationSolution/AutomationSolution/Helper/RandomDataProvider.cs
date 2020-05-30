using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Helper
{
    public class RandomDataProvider
    {
        private static String EMAIL_ROOT = "test_email_";
        private static String EMAIL_SUFFIX = "@mail.com";

        public static String getRandomEmail()
        {
            Random r = new Random();
            return (EMAIL_ROOT + r.Next(10000, 99999999) + EMAIL_SUFFIX);
        }
    }
}
