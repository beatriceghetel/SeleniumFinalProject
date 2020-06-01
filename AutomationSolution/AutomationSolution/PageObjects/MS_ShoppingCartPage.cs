using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects
{
    class MS_ShoppingCartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MS_ShoppingCartPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By isAvailable = By.CssSelector(".label");
        private IWebElement LblIsAvailable => driver.FindElement(isAvailable);

        private By itemQuantity = By.CssSelector(".cart_quantity_input");
        private IWebElement TxtItemQuantity => driver.FindElement(itemQuantity);

        private By quantitySubstract = By.CssSelector(".icon-minus");
        private IWebElement BtnQuantitySubstract => driver.FindElement(quantitySubstract);

        private By quantityIncrease = By.CssSelector(".icon-plus");
        private IWebElement BtnQuantityIncrease => driver.FindElement(quantityIncrease);

        private By removeItem = By.CssSelector(".icon-trash");
        private IWebElement BtnRemoveItem => driver.FindElement(removeItem);

        private By proceedToCheckout = By.CssSelector(".standard-checkout > span:nth-child(1)");
        private IWebElement BtnProceedToCheckout => driver.FindElement(proceedToCheckout);

        // INTERMEDIATE PAGES ELEMENTS UNTIL DELIVERY PAGE
        // Since we intended to have just ome "next next" approach we did not create another 4-5 PageObjects for simplicity
        private By proceedToCheckoutAfterAddressSelection = By.CssSelector("button.button:nth-child(4) > span:nth-child(1)");
        private IWebElement BtnProceedToCheckoutAfterAddressSelection => driver.FindElement(proceedToCheckoutAfterAddressSelection);

        private By agreeWithTerms = By.Id("cgv");
        private IWebElement BtnAgreeWithTerms => driver.FindElement(agreeWithTerms);

        private By choosePaymentByBankWire = By.CssSelector(".bankwire");  // we used just this method again, for simplicity
        private IWebElement BtnChoosePaymentByBankWire => driver.FindElement(choosePaymentByBankWire);

        private By confirmOrder = By.CssSelector("button.button-medium > span:nth-child(1)");
        private IWebElement BtnConfirmOrder => driver.FindElement(confirmOrder);

        private By orderSuccessfullyPlaced = By.CssSelector(".cheque-indent > strong");
        private IWebElement LblOrderSuccessfullyPlaced => driver.FindElement(orderSuccessfullyPlaced);

        public string ProceedToCheckoutWithoutChanges()
        {
            if (LblIsAvailable.Text.Equals("In stock"))
            {
                BtnProceedToCheckout.Click();
                return goThroughStepsUntilOrderCompletion();
            }
            else
            {
                throw new Exception("Test cannot continue: cannot reorder item since it's out of stock!");
            }
        }

        public string ReorderWithChngedQuantity(int quantityChange, Boolean increase, Boolean useInputDirectly)
        {
            if (LblIsAvailable.Text.Equals("In stock"))
            {
                if (increase)
                {
                    if (useInputDirectly)
                    {
                        int currentQuanity = Int32.Parse(TxtItemQuantity.GetAttribute("value"));
                        TxtItemQuantity.Clear();
                        TxtItemQuantity.SendKeys((currentQuanity + quantityChange).ToString());
                    } else
                    {
                        for (int i = 0; i < quantityChange; i++)
                        {
                            BtnQuantityIncrease.Click();
                        }
                    }
                } 
                else
                {
                    if (useInputDirectly)
                    {
                        var currentQuanity = Int32.Parse(TxtItemQuantity.GetAttribute("value"));
                        TxtItemQuantity.Clear();
                        TxtItemQuantity.SendKeys((currentQuanity - quantityChange).ToString());
                    }
                    else
                    {
                        for (int i = 0; i < quantityChange; i++)
                        {
                            BtnQuantitySubstract.Click();
                        }
                    }
                }
                
                return goThroughStepsUntilOrderCompletion();
            } 
            else
            {
                throw new Exception("Test cannot continue: cannot reorder item since it's out of stock!");
            }            
        }


        // We put here the "next next" logic to avoid repetition in the methods
        private string goThroughStepsUntilOrderCompletion()
        {
            BtnProceedToCheckout.Click();

            // we will use the same address as for the original order
            wait.Until(ExpectedConditions.ElementIsVisible(proceedToCheckoutAfterAddressSelection));
            BtnProceedToCheckoutAfterAddressSelection.Click();

            // agree with terms
            // wait.Until(ExpectedConditions.ElementIsVisible(agreeWithTerms));   // process hangs with wait
            Thread.Sleep(1000);
            BtnAgreeWithTerms.Click();
            BtnProceedToCheckoutAfterAddressSelection.Click();

            // choose payment option
            wait.Until(ExpectedConditions.ElementIsVisible(choosePaymentByBankWire));
            BtnChoosePaymentByBankWire.Click();

            // confirm order
            wait.Until(ExpectedConditions.ElementIsVisible(confirmOrder));
            BtnConfirmOrder.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(orderSuccessfullyPlaced));
            return LblOrderSuccessfullyPlaced.Text;
        }
    }
}
