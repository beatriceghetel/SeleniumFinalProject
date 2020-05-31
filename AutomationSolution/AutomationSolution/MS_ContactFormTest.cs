using AutomationSolution.PageObjects;
using AutomationSolution.PageObjects.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationSolution
{
    [TestClass]
    public class MS_ContactFormTest
    {
        private IWebDriver driver;
        private MS_LoginPage loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            // Access site
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".login")).Click();

            // Login
            var loginPage = new MS_LoginPage(driver);
            var loginBO = new LoginBO();
            Thread.Sleep(2000);
            loginPage.LoginApplication(loginBO.email, loginBO.password);
        }

        [TestMethod]
        public void FillContactFormWithoutAttachment()
        {
            var contactPage = new MS_ContactPage(driver);
            var contactFormBO = new ContactFormBO();
            //Thread.Sleep(1000);

            var expectedResult = "Your message has been successfully sent to our team.";
            var actualResult = contactPage.fillContactMessageWithoutAttachment(contactFormBO);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FillContactFormWithAttachment()
        {
            var contactPage = new MS_ContactPage(driver);
            var contactFormBO = new ContactFormBO();

            contactPage.fillContactMessageWithAttachment(contactFormBO);
            Thread.Sleep(5000);

            //Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
