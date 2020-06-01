using AutomationSolution.Helper;
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
    public class MS_BuyDressTest
    {
        private IWebDriver driver;

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
        public void BuyDress()
        {

            var productGridViewPage = new MS_ProductViewPage(driver);
            var shopItem = new ShopItemBO();

            productGridViewPage.ChooseFirstItem(shopItem);
            Thread.Sleep(1000);

            productGridViewPage.AddToCart(shopItem);
            Thread.Sleep(1000);

            var shoppingCart = new MS_ShoppingCartPage(driver);            

            var actualResult = shoppingCart.ProceedToCheckoutWithoutChanges();
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
