using AutomationSolution.PageObjects.BO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects
{
    class MS_ContactPage
    {


        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_ContactPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By contactLink = By.Id("contact-link");
        private IWebElement BtnContactUs => driver.FindElement(contactLink);

        private By subjectHeading = By.Id("id_contact");
        private IWebElement TxtSubjectHeading => driver.FindElement(subjectHeading);
        
        private By email = By.Id("email");
        private IWebElement TxtEmail => driver.FindElement(email);

        private By attachmentSelect = By.CssSelector("#uniform-fileUpload > span.filename");
        private IWebElement TxtChooseFile => driver.FindElement(attachmentSelect);

        private By message = By.Id("message");
        private IWebElement TxtMessage => driver.FindElement(message);

        private By submit = By.Id("submitMessage");
        private IWebElement BtnSubmit => driver.FindElement(submit);

        private By successMessage = By.CssSelector("#center_column > p");
        private IWebElement LblSuccessMessage => driver.FindElement(successMessage);

        public String fillContactMessageWithAttachment(ContactFormBO formBO)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(contactLink));
            BtnContactUs.Click();

            //wait.Until(ExpectedConditions.ElementIsVisible(subjectHeading));   // PROCESS HANGS
            Thread.Sleep(2000);
            TxtSubjectHeading.SendKeys(formBO.subjectHeading);
            TxtEmail.Click();   // ALREADY FILLED WITH LOGGED IN EMAIL
            TxtChooseFile.Click();
            TxtChooseFile.SendKeys(formBO.fileAddress);
            TxtChooseFile.SendKeys(Keys.Enter);
            TxtMessage.SendKeys(formBO.message);

            BtnSubmit.Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(successMessage));
            Thread.Sleep(1000);
            return LblSuccessMessage.Text;
        }

        public String fillContactMessageWithoutAttachment(ContactFormBO formBO)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(contactLink));
            BtnContactUs.Click();

            // wait.Until(ExpectedConditions.ElementIsVisible(subjectHeading));   // PROCESS HANGS
            Thread.Sleep(1000);
            TxtSubjectHeading.SendKeys(formBO.subjectHeading);
            TxtEmail.Click();   // ALREADY FILLED WITH LOGGED IN EMAIL
            TxtMessage.SendKeys(formBO.message);

            BtnSubmit.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(successMessage)); 
            return LblSuccessMessage.Text;
        }
    }
}
