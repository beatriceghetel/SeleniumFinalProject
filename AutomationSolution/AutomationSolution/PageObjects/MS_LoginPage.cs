using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution.PageObjects
{
    public class MS_LoginPage
    {
        private IWebDriver driver;

        public MS_LoginPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(submit));
        }

        private By email = By.Id("email");
        private IWebElement TxtEmail => driver.FindElement(email);

        private By password = By.Id("passwd");
        private IWebElement TxtPassword => driver.FindElement(password);

        private By submit => By.CssSelector("#SubmitLogin > span");
        private IWebElement BtnLogin => driver.FindElement(submit);

        private By incorrectCredentials = By.XPath("//*[@id='center_column']/div[1]/ol/li");
        private IWebElement LblErrorMessage => driver.FindElement(incorrectCredentials);


        public MS_HomePage LoginApplication(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
            return new MS_HomePage(driver);
        }
    }
}
