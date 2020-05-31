using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        
        //#wlp_5_19 > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > a:nth-child(1) > i:nth-child(1)
        //s_title   -- caut rochia dupa titltu
    }
}
