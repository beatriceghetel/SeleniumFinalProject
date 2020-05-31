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
    public class MS_AddToWishlistTest
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
            Thread.Sleep(5000);
            loginPage.LoginApplication(loginBO.email, loginBO.password);
        }

        [TestMethod]
        public void AddToWishlistTest()
        {
            var productGridViewPage = new MS_ProductViewPage(driver);
            var shopItem = new ShopItemBO();

            productGridViewPage.ChooseFirstItem(shopItem);
            Thread.Sleep(2000);

            var actualResult = productGridViewPage.WishlistItem(shopItem);
            var expectedResult = "Added to your wishlist.";

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
