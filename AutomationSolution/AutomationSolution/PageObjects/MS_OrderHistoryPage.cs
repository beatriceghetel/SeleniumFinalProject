using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects
{
    class MS_OrderHistoryPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_OrderHistoryPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        // We will try to focus on the first order from out list
        private By firstOrderInList = By.CssSelector("#order-list > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(1) > a");
        private IWebElement TxtFirstOrderInList => driver.FindElement(firstOrderInList);

        private By reorderFromOrderDetailView = By.CssSelector("a.button:nth-child(3)");
        private IWebElement BtnReorderFromOrderDetailView => driver.FindElement(reorderFromOrderDetailView);

        public MS_OrderHistoryPage ReorderFirstItem()
        {
            TxtFirstOrderInList.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(reorderFromOrderDetailView));
            BtnReorderFromOrderDetailView.Click();
            return new MS_OrderHistoryPage(driver);
        }
    }
}
