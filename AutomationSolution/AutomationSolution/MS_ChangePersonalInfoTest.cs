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
    public class MS_ChangePersonalInfoTest
    {
        private IWebDriver driver;
        private LoginBO loginBO;

        [TestInitialize]
        public void TestInitialize()
        {
            // Access site
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".login")).Click();

            // Login
            var loginPage = new MS_LoginPage(driver);
            loginBO = new LoginBO();
            Thread.Sleep(1000);
            loginPage.LoginApplication(loginBO.email, loginBO.password);
        }


        [TestMethod]
        public void TestPersonalDetailsChanged()
        {
            var userAccountPage = new MS_UserAccountPage(driver);

            userAccountPage.GoToMyPersonalInfo();
            Thread.Sleep(2000);

            var personalDetailsPage = new MS_PersonalDetailsPage(driver);
            var actualResult = personalDetailsPage.UpdatePersonalInfo(loginBO).Trim();

            var expectedResult = "Your personal information has been successfully updated.";

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
