using System.Threading;
using AutomationSolution.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutomationSolution
{
    [TestClass]
    public class MS_AddNewAddressTest
    {
        private IWebDriver driver;
        private MS_LoginPage loginPage;
        private MS_AccountPage accountPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            Thread.Sleep(5000);
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

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
