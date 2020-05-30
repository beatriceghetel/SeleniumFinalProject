using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using OpenQA.Selenium;

namespace AutomationSolution.PageObjects
{
    public class MS_HomePage
    {
        private IWebDriver driver;

        public MS_HomePage(IWebDriver browser)
        {
            driver = browser;
        }

    }
}
