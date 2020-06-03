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
    public class MS_BuyDressTest
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
        public void BuyDress()
        {

            var productGridViewPage = new MS_ProductViewPage(driver);
            var shopItem = new ShopItemBO();

            productGridViewPage.ChooseFirstItem(shopItem);
            productGridViewPage.AddToCart(shopItem);

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
