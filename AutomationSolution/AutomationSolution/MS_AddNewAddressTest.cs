using System;
using System.Threading;
using AutomationSolution.PageObjects;
using AutomationSolution.PageObjects.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationSolution
{
    [TestClass]
    public class MS_AddNewAddressTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void TestInitialize()
        {
            // Access site
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".login")));
            driver.FindElement(By.CssSelector(".login")).Click();

            // Login
            var loginPage = new MS_LoginPage(driver);
            var loginBO = new LoginBO();
            loginPage.LoginApplication(loginBO.email, loginBO.password);
        }

        [TestMethod]
        public void TestAddNewAddress()
        {
            var userAccountPage = new MS_UserAccountPage(driver);            

            userAccountPage.GoToAddressess();
                        
            var registerNewAddressPage = new MS_NewAddressPage(driver);
            var newAddress = new NewAddressBO();
            registerNewAddressPage.CreateAddress(newAddress);

            var actualResult = registerNewAddressPage.checkAddressSuccessfullyAdded().Trim();
            var expectedResult = newAddress.aliasAddress.ToUpper();

            Assert.AreEqual(expectedResult, actualResult);
        }
        

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
