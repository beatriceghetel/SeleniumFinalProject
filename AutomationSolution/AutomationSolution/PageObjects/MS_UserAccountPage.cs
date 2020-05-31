using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects
{
    public class MS_UserAccountPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_UserAccountPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By orderHistoryAndDetails = By.CssSelector(".icon-list-ol");
        private IWebElement BtnOrdersHistory => driver.FindElement(orderHistoryAndDetails);

        private By myAddressess = By.CssSelector(".icon-building");
        private IWebElement BtnAddressess => driver.FindElement(myAddressess);

        private By myWishlist = By.CssSelector(".icon-heart");
        private IWebElement BtnWishlist => driver.FindElement(myWishlist);

        public MS_UserAccountPage GoToWishlist()
        {
            BtnWishlist.Click();
            return new MS_UserAccountPage(driver);
        }

        public MS_UserAccountPage GoToAddressess()
        {
            BtnAddressess.Click();
            return new MS_UserAccountPage(driver);
        }
    }
}
