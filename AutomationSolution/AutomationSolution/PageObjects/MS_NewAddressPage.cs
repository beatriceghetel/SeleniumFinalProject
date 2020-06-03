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

    public class MS_NewAddressPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_NewAddressPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By createNewAddress = By.CssSelector("a.button-medium:nth-child(1)");
        private IWebElement BtnCreateNewAddress => driver.FindElement(createNewAddress);

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

        private By registerNewAddress = By.Id("submitAddress");
        private IWebElement BtnRegisterNewAddress => driver.FindElement(registerNewAddress);

        // Label of new added address
        private By newAddressTitle = By.CssSelector(".last_item > li > .page-subheading");
        private IWebElement LblNewAddedAddress => driver.FindElement(newAddressTitle);


        public MS_RegisterAccountPage CreateAddress(NewAddressBO newAddressBO)
        {
            // Open new address form
            wait.Until(ExpectedConditions.ElementIsVisible(createNewAddress));
            BtnCreateNewAddress.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(firstName));

            // Address details
            TxtFirstName.SendKeys(Keys.Enter);   // has "First Name" string by default already inserted
            TxtLastName.SendKeys(Keys.Enter);    // has "Last Name" string by default already inserted
            TxtAddress.SendKeys(newAddressBO.address);
            TxtCity.SendKeys(newAddressBO.city);
            DdlState.SendKeys(newAddressBO.state);
            TxtPostCode.SendKeys(newAddressBO.postCode);
            DdlCountry.SendKeys(newAddressBO.country);
            TxtMobilePhone.SendKeys(newAddressBO.mobilePhone);
            TxtAliasAddress.Clear();    // has "My Address" string by default already inserted
            TxtAliasAddress.SendKeys(newAddressBO.aliasAddress);

            BtnRegisterNewAddress.Click();
            return new MS_RegisterAccountPage(driver);
        }

        public String checkAddressSuccessfullyAdded()
        {
            driver.Navigate().Refresh();
            wait.Until(ExpectedConditions.ElementIsVisible(newAddressTitle));
            return LblNewAddedAddress.Text;
        }
    }
}
