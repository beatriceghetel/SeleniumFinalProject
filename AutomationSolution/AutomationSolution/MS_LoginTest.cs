using System.Threading;
using AutomationSolution.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


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
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".login")).Click();

            loginPage = new MS_LoginPage(driver);
        }
        [TestMethod]
        public void Login_CorrectEmail_CorrectPassword()
        {
            Thread.Sleep(5000);
            loginPage.LoginApplication("geo.ac1@yahoo.com", "testare1");
            Thread.Sleep(5000);
            var expectedResult = "Georgiana Acornicesei";
            var actualResult = driver.FindElement(By.CssSelector(".account > span:nth-child(1)")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Login_IncorrectEmail_CorrectPassword()
        {
            Thread.Sleep(5000);
            loginPage.LoginApplication("geo.acccc1@yahoo.com", "testare1");
            Thread.Sleep(5000);
            var expectedResult = "Authentication failed.";
            var actualResults = driver.FindElement(By.XPath("//*[@id='center_column']/div[1]/ol/li")).Text;

            Assert.AreEqual(expectedResult, actualResults);
        }

        [TestMethod]
        public void Login_CorrectEmail_IncorrectPassword()
        {
            Thread.Sleep(5000);
            loginPage.LoginApplication("geo.ac1@yahoo.com", "testareee");
            Thread.Sleep(5000);
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
