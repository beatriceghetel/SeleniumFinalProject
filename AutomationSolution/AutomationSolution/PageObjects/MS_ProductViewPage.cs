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
    class MS_ProductViewPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_ProductViewPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By searchBox = By.Id("search_query_top");
        private IWebElement ISearchBox => driver.FindElement(searchBox);

        private By gridView = By.CssSelector(".icon-th-large");
        private IWebElement BtnGridView => driver.FindElement(gridView);

        private By firstResult = By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]/div/div[2]/h5/a");
        private IWebElement LblFirstResult => driver.FindElement(firstResult);

        private By wishList = By.Id("wishlist_button");
        private IWebElement BtnWishList => driver.FindElement(wishList);

        //.fancybox-error
        private By modalBox = By.CssSelector(".fancybox-error");
        private IWebElement LblSuccessfullyAdded => driver.FindElement(modalBox);

        public MS_ProductViewPage ChooseFirstItem(ShopItem shopItem)
        {
            // Search for the desired item
            ISearchBox.Click();
            ISearchBox.SendKeys(shopItem.itemName);
            ISearchBox.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            // Make sure we have the Grid view perspective
            BtnGridView.Click();
            Thread.Sleep(2000);

            // Select first result
            LblFirstResult.Click();
            return new MS_ProductViewPage(driver);
        }


        public String WishlistItem(ShopItem shopItem)
        {
            BtnWishList.Click();
            Thread.Sleep(2000);
            return LblSuccessfullyAdded.Text;
        }

    }
}