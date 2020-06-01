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
    public class MS_ReorderTest
    {
        private IWebDriver driver;

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
            var loginBO = new LoginBO();
            Thread.Sleep(1000);
            loginPage.LoginApplication(loginBO.email, loginBO.password);
        }

        [TestMethod]
        public void ReorderChangeQuantityByInputTest()
        {
            var userAccountPage = new MS_UserAccountPage(driver);
            userAccountPage.GoToOrderHistoryAndDetails();

            var orderHistoryPage = new MS_OrderHistoryPage(driver);
            orderHistoryPage.ReorderFirstItem();

            var shoppingCart = new MS_ShoppingCartPage(driver);

            var actualResult = shoppingCart.ReorderWithChngedQuantity(3, true, false);  // parameters mean: increase quantity by 2 using the increase Q arrow
            var expectedResult = "Your order on My Store is complete.";

            Assert.AreEqual(expectedResult, actualResult.Trim());
        }

        [TestMethod]
        public void ReorderChangeQuantityByArrowsTest()
        {
            var userAccountPage = new MS_UserAccountPage(driver);
            userAccountPage.GoToOrderHistoryAndDetails();

            var orderHistoryPage = new MS_OrderHistoryPage(driver);
            orderHistoryPage.ReorderFirstItem();

            var shoppingCart = new MS_ShoppingCartPage(driver);            

            var actualResult = shoppingCart.ReorderWithChngedQuantity(3, true, false);  // parameters mean: increase quantity by 2 using the increase Q arrow
            var expectedResult = "Your order on My Store is complete.";

            Assert.AreEqual(expectedResult, actualResult.Trim());
        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
