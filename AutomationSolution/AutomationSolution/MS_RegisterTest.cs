using AutomationSolution.Helper;
using AutomationSolution.PageObjects;
using AutomationSolution.PageObjects.RegisterAccountPage.InputData;
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
    public class MS_RegisterTest
    {
        private IWebDriver driver;
        private MS_LoginPage loginPage;
        private MS_RegisterAccountPage registerPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector(".login")).Click();
            loginPage = new MS_LoginPage(driver);
            registerPage = new MS_RegisterAccountPage(driver);
        }

        [TestMethod]
        public void Register_CorrectEmail()
        {

            Thread.Sleep(5000);
                      
            
            loginPage.RegisterApplication(RandomDataProvider.getRandomEmail());

            Thread.Sleep(5000);
            driver.FindElement(By.Id("id_gender1"));

            var registerAccountBO = new RegisterAccountBO
            {
                Title = 1
            };
            var addressDetailsPage = registerPage.CreateAccount(registerAccountBO);
            Thread.Sleep(10000);
            Assert.AreEqual("Address was successfully created.", addressDetailsPage.SuccessfullyCreatedText);

            Assert.AreEqual("FILL ME", "FILL ME");
        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

    
}
