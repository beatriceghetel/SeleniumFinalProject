using AutomationSolution.PageObjects.BO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution.PageObjects
{
   
    public class MS_RegisterPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_RegisterPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By title = By.XPath("//input[@name='id_gender']");
        private IList<IWebElement> LstTitle => driver.FindElements(title);

        public MS_RegisterAccountPage CreateAddress(RegisterAccountBO registerAccountBO)
        {
            LstTitle[registerAccountBO.Title].Click();
            return new MS_RegisterAccountPage(driver);
        }
    }    
}
