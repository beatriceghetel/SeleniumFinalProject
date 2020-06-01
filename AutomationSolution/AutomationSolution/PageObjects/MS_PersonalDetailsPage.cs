using AutomationSolution.PageObjects.BO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects
{
    public class MS_PersonalDetailsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_PersonalDetailsPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        // Client details
        private By customerFirstName = By.Id("firstname");
        private IWebElement TxtCustomerFirstName => driver.FindElement(customerFirstName);

        private By customerLastName = By.Id("lastname");
        private IWebElement TxtCustomerLastName => driver.FindElement(customerLastName);

        private By email = By.Id("email");
        private IWebElement TxtEmail => driver.FindElement(email);

        private By days = By.Id("days");    // PART OF BIRTH DATE
        private IWebElement DdlDays => driver.FindElement(days);

        private By oldPassword = By.Id("old_passwd");
        private IWebElement TxtOldPassword => driver.FindElement(oldPassword);

        // Optional ticks
        private By newsletter = By.Id("newsletter");
        private IWebElement BtnNewsletter => driver.FindElement(newsletter);

        private By offers = By.Id("optin");
        private IWebElement BtnOffers => driver.FindElement(offers);

        // Save related
        private By save = By.CssSelector("button.btn:nth-child(1)");
        private IWebElement BtnSave => driver.FindElement(save);

        private By confirmationAlert = By.CssSelector(".alert");
        private IWebElement LblConfirmationAlert => driver.FindElement(confirmationAlert);

        public string UpdatePersonalInfo(LoginBO loginBO)
        {
            TxtCustomerFirstName.Click();
            TxtCustomerLastName.Click();
            TxtEmail.Click();
            updateDayOfBirth();
            TxtOldPassword.SendKeys(loginBO.password);
            tickOptionals();

            BtnSave.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(confirmationAlert));
            return LblConfirmationAlert.Text;
        }


        public void updateDayOfBirth()
        {
            Random r = new Random();
            DdlDays.SendKeys(r.Next(1, 28).ToString());
        }

        public void tickOptionals()
        {
            BtnNewsletter.Click();
            BtnOffers.Click();
        }

    }
}
