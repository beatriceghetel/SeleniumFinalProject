﻿using AutomationSolution.PageObjects.RegisterAccountPage.InputData;
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

        private By title = By.XPath("//input[@name='id_gender']");
        private IList<IWebElement> LstTitle => driver.FindElements(title);

        public string SuccessfullyCreatedText => LblSuccessfullyRegister.Text;

        public MS_RegisterAccountPage CreateAccount(RegisterAccountBO registerAccount)
        {
           /* wait.Until(ExpectedConditions.ElementIsVisible(firstName));
            TxtFirstName.SendKeys(addAddressBo.FirstName);
            TxtLastName.SendKeys(addAddressBo.LastName);
            TxtAddress1.SendKeys(addAddressBo.Address1);
            TxtCity.SendKeys(addAddressBo.City);
            var selectState = new SelectElement(DdlState);
            selectState.SelectByText(addAddressBo.State);
            TxtZipCode.SendKeys(addAddressBo.ZipCode);*/
            LstTitle[registerAccount.Title].Click();
            /*var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", ClColor, addAddressBo.Color);
            BtnCreateAddress.Click();*/
            return new MS_RegisterAccountPage(driver);
        }
    }
}