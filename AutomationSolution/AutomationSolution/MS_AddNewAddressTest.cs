using System.Threading;
using AutomationSolution.PageObjects;
using AutomationSolution.PageObjects.BO;
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
        private MS_EditAddressPage editAddressPage;

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
        public void TestAddNewAddress()
        {
            var userAccountPage = new MS_UserAccountPage(driver);            

            userAccountPage.GoToAddressess();
            Thread.Sleep(2000);
                        
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
