using AutomationSolution.Helper;
using AutomationSolution.PageObjects;
using AutomationSolution.PageObjects.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution
{
    [TestClass]
    public class MS_RegisterTest
    {
        private IWebDriver driver;
        private MS_LoginPage loginPage;
        private MS_RegisterAccountPage registerPage;
        private WebDriverWait wait;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".login")));
            driver.FindElement(By.CssSelector(".login")).Click();

            loginPage = new MS_LoginPage(driver);
            registerPage = new MS_RegisterAccountPage(driver);
        }

        [TestMethod]
        public void Register_CorrectEmail()
        {
            loginPage.RegisterApplication(RandomDataProvider.getRandomEmail());

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("id_gender1")));
            driver.FindElement(By.Id("id_gender1"));

            var registerAccountBO = new RegisterAccountBO();
            var addressDetailsPage = registerPage.CreateAccount(registerAccountBO);
            
            var expectedResult = (registerAccountBO.firstName + " " + registerAccountBO.lastName);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".account > span:nth-child(1)")));
            var actualResult = driver.FindElement(By.CssSelector(".account > span:nth-child(1)")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

    
}
