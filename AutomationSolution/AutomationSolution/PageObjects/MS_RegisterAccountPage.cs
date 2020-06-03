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

    public class MS_RegisterAccountPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_RegisterAccountPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By succesfullyRegistered = By.CssSelector("[data-test=notice]");
        private IWebElement LblSuccessfullyRegister => driver.FindElement(succesfullyRegistered);

        // Customer details
        private By title = By.XPath("//input[@name='id_gender']");
        private IList<IWebElement> LstTitle => driver.FindElements(title);

        private By customerFirstName = By.Id("customer_firstname");
        private IWebElement TxtCustomerFirstName => driver.FindElement(customerFirstName);

        private By customerLastName = By.Id("customer_lastname");
        private IWebElement TxtCustomerLastName => driver.FindElement(customerLastName);

        private By email = By.Id("email");
        private IWebElement TxtEmail => driver.FindElement(email);

        private By password = By.Id("passwd");
        private IWebElement TxtPassword => driver.FindElement(password);

        private By days = By.Id("days");    // PART OF BIRTH DATE
        private IWebElement DdlDays => driver.FindElement(days);

        private By months = By.Id("months");    // PART OF BIRTH DATE
        private IWebElement DdlMonths => driver.FindElement(months);

        private By years = By.Id("years");    // PART OF BIRTH DATE
        private IWebElement DdlYears => driver.FindElement(years);


        // Address details
        private By firstName = By.Id("firstname");
        private IWebElement TxtFirstName => driver.FindElement(firstName);

        private By lastName = By.Id("lastname");
        private IWebElement TxtLastName => driver.FindElement(lastName);

        private By address = By.Id("address1");
        private IWebElement TxtAddress => driver.FindElement(address);

        private By city = By.Id("city");
        private IWebElement TxtCity => driver.FindElement(city);

        private By state = By.Id("id_state");
        private IWebElement DdlState => driver.FindElement(state);

        private By postCode = By.Id("postcode");
        private IWebElement TxtPostCode => driver.FindElement(postCode);

        private By country = By.Id("id_country");
        private IWebElement DdlCountry => driver.FindElement(country);

        private By mobilePhone = By.Id("phone_mobile");
        private IWebElement TxtMobilePhone => driver.FindElement(mobilePhone);

        private By aliasAddress = By.Id("alias");
        private IWebElement TxtAliasAddress => driver.FindElement(aliasAddress);

        private By registerAccount = By.CssSelector("#submitAccount > span:nth-child(1)");
        private IWebElement BtnRegisterAccount => driver.FindElement(registerAccount);


        public MS_RegisterAccountPage CreateAccount(RegisterAccountBO registerAccountBO)
        {
            // Customer details
            wait.Until(ExpectedConditions.ElementIsVisible(customerFirstName));
            LstTitle[registerAccountBO.Title].Click();
            TxtCustomerFirstName.SendKeys(registerAccountBO.customerFirstName);
            TxtCustomerLastName.SendKeys(registerAccountBO.customerLastName);
            // TxtEmail.SendKeys(registerAccountBO.email);   // AUTOFILLED FROM REGISTER
            TxtEmail.Click();   // just click is needed for enabling the implicit value
            TxtPassword.SendKeys(registerAccountBO.password);
            DdlDays.SendKeys(registerAccountBO.days);    // PART OF BIRTH DATE
            DdlMonths.SendKeys(registerAccountBO.months);    // PART OF BIRTH DATE
            DdlYears.SendKeys(registerAccountBO.years);    // PART OF BIRTH DATE

            // Address details
            TxtFirstName.SendKeys(registerAccountBO.firstName);
            TxtLastName.SendKeys(registerAccountBO.lastName);
            TxtAddress.SendKeys(registerAccountBO.address);
            TxtCity.SendKeys(registerAccountBO.city);
            DdlState.SendKeys(registerAccountBO.state);
            TxtPostCode.SendKeys(registerAccountBO.postCode);
            DdlCountry.SendKeys(registerAccountBO.country);
            TxtMobilePhone.SendKeys(registerAccountBO.mobilePhone);
            TxtAliasAddress.Clear();    // has "My Address" string by default already inserted
            TxtAliasAddress.SendKeys(registerAccountBO.aliasAddress);

            BtnRegisterAccount.Click();
            return new MS_RegisterAccountPage(driver);
        }
    }
}
