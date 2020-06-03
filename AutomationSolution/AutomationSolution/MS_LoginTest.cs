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
    public class MS_LoginTest
    {

        private IWebDriver driver;
        private MS_LoginPage loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".login")));
            driver.FindElement(By.CssSelector(".login")).Click();

            loginPage = new MS_LoginPage(driver);
        }


        [TestMethod]
        public void Login_CorrectEmail_CorrectPassword()
        {
            var loginBO = new LoginBO();
            loginPage.LoginApplication(loginBO.email, loginBO.password);
            var expectedResult = loginBO.username;
            var actualResult = driver.FindElement(By.CssSelector(".account > span:nth-child(1)")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void Login_IncorrectEmail_CorrectPassword()
        {
            loginPage.LoginApplication("geo.acccc1@yahoo.com", "testare1");
            var expectedResult = "Authentication failed.";
            var actualResults = driver.FindElement(By.XPath("//*[@id='center_column']/div[1]/ol/li")).Text;

            Assert.AreEqual(expectedResult, actualResults);
        }


        [TestMethod]
        public void Login_CorrectEmail_IncorrectPassword()
        {
            loginPage.LoginApplication("geo.ac1@yahoo.com", "testareee");
            var expectedResult = "Authentication failed.";
            var actualResults = driver.FindElement(By.XPath("//*[@id='center_column']/div[1]/ol/li")).Text;

            Assert.AreEqual(expectedResult, actualResults);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

    }
}
