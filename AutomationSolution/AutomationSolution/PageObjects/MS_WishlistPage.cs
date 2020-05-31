using AutomationSolution.PageObjects.BO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects
{
    class MS_WishlistPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_WishlistPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By myWishlist = By.CssSelector("#wishlist_20009 > td:nth-child(1) > a:nth-child(1)");
        private IWebElement BtnWishlist => driver.FindElement(myWishlist);

        private By removeFromWishlist = By.CssSelector(".icon-remove-sign");
        private IWebElement BtnRemoveFromWishlist => driver.FindElement(removeFromWishlist);

        private By removedSuccessfullyAlert = By.CssSelector(".alert");
        private IWebElement LblRemovedFromWishlist => driver.FindElement(removedSuccessfullyAlert);


        public String removeItemFromWishlist(ShopItemBO shopItem)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(myWishlist));
            BtnWishlist.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(removeFromWishlist));
            BtnRemoveFromWishlist.Click();
            Thread.Sleep(500);
            BtnWishlist.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(removedSuccessfullyAlert));            
            return LblRemovedFromWishlist.Text;
        }

    }
}
