# SeleniumFinalProject
#### FEAA-Automation Solution Project (http://automationpractice.com/index.php)

**Developers:**
* Acornicesei Georgiana
* Cristea Alexandru
* Ghetel Beatrice

**************************************************************

### Automation Tests

*This document briefly explains the user stories that were tested, and the "special cases" (or particular events that needed additional logic to be implemented) that we have encountered during the test development.*

**************************************************************

#### 1. User registration: `MS_RegisterTest`

Register test refers to the process of creating a new account using an email address (automatically randomly generated). Whitin the `RandomDataProvider` class, the logic for the random generated email can be found.
```
public class RandomDataProvider
    {
        private static String EMAIL_ROOT = "test_email_";
        private static String EMAIL_SUFFIX = "@mail.com";

        public static String getRandomEmail()
        {
            Random r = new Random();
            return (EMAIL_ROOT + r.Next(10000, 99999999) + EMAIL_SUFFIX);
        }
    }
 ```
 We created a bussines object for the register test, which holds both the Customer Details and Address details needed for the form completion.

**************************************************************

#### 2. User Login: `MS_LoginTest`

This test was written in order to verify the login process, filling in the fields related to email address and password. First, we checked if the “sign-in” button works, so we can log in into our account using the correct credentials. Then, we identified the alert message that appears when the value added in one of the fields is invalid (inccorect email or inccorect password).
We instantiated our driver to open the Chrome browser and then we accessed the site to be tested. 
We created `MS_LoginPage` and `LoginBO` in order to reuse them in the init process of the next tests.

**************************************************************

#### 3. Add new address to existing account: `MS_AddNewAddressTest`

After creating a new account, we created a test in order to add a new address. For that, we created `NewAddressBO` which is similar to the one used in RegisterPage, but the difference is that this one holds informations just about address.

Here (and not only) we had to pay extra attention to the situations where the form had preset values for the input fields. For example, if the user did not set a name for the newly added address, a default `"My Address+random_suffix"` was present, and in order to insert only our value we had to clear the input before, otherwise the preset value would just be concatenated with our custom value from the `NewAddressBO` (sample code below).

```
    TxtAliasAddress.Clear();    // has "My Address" string by default already inserted
    TxtAliasAddress.SendKeys(newAddressBO.aliasAddress);
```

**************************************************************

#### 4. "Contact Us" form fill: `MS_ContactFormTest`

We created this test in order to complete the Contact Form. We explored two scenarios of submitting the contact form:

* **without attachment** - fill just the minimum required fields 
* **with attachment** - we added an attachment (**.png file** - *which is actually an error we have truly encountered while working on the practice website*)

For the fields with implicit values (taken from the current logged in user), we just clicked the input in order to confirm the value.

Below you can find the method which creates the form with attachment:
```
    public String fillContactMessageWithAttachment(ContactFormBO formBO)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(contactLink));
            BtnContactUs.Click();

            //wait.Until(ExpectedConditions.ElementIsVisible(subjectHeading));   // PROCESS HANGS
            Thread.Sleep(1000);
            TxtSubjectHeading.SendKeys(formBO.subjectHeading);
            TxtEmail.Click();   // ALREADY FILLED WITH LOGGED IN EMAIL
            TxtChooseFile.SendKeys(formBO.fileAddress);
            TxtMessage.SendKeys(formBO.message);

            BtnSubmit.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(successMessage));
            return LblSuccessMessage.Text;
        }
   ```

**************************************************************

#### 5. Add item to Wishlist: `MS_AddToWishlistTest`

The scenario we followed for adding a product to wishlist is to use the search bar in order to find a specific shop item by name(for which we created a bussines object contained the name of the item). Then we ensured the fact that the result are being displayed in grid perspective and then we "wishlisted" the first item from the resulted list. In order to check the expected result, we had to check the text display from the modal box.
```
private By modalBox = By.CssSelector(".fancybox-error");
private IWebElement LblSuccessfullyAdded => driver.FindElement(modalBox);
 ```

**************************************************************

#### 6. Remove item from Wishlist: `MS_RemoveFromWishlistTest`

In order to remove an item from the wishlist, we navigated to the user's account page  (we implemented the `MS_UserAccountPage` Page Object in order to ensure a single point reference for all the actions that can be done from my account, including accessing the Wishlist), and then to the actual wishlist page `MS_WishlistPage`. Here we added selector in order to remove from wishlist the first added item. To validate the completion of the operation performed, we have waited for the display of the success alert.

```
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
```

**************************************************************

#### 7. Buying a product: `MS_BuyDressTest`

For the acquisition tests we have used a `ShopItemBO` searching for the product by name, we have chosen the first item from the list (ensuring the fact that the products view is in Grid format, like in the Wishlist scenario). Before addin the item to the cart we also changed its color to black value. Then we clicked the proceed to checkout, and we used the `ProceedToCheckoutWithoutChanges()` which simply uses the "next next" approach with default options for payment and transportation in order to reach the actual Checkout.

In order to reuse the steps to reach checkout we have encapsulated them into the `goThroughStepsUntilOrderCompletion()` (this will be used also for the Reorder logic).


**************************************************************

#### 8. Use Order History to reorder product: `MS_ReorderTest`

In this scenario we have used the `MS_UserAccountPage` in order to access the list of previous orders. From this point we have clicked the first order in the list in order to expand the `MS_OrderHistoryPage` and then click the button to navigate to the order history. We will select the first order from the list, expanded the order detailed view and clicked the Reorder button.

From this point we will reuse the `MS_ShoppingCartPage` from the buy product scenario, changing the quantity of the product in 2 ways:

* modifying the **input** directly
* using the increase / decrease quantity **arrows**

We also checked if the product is in stock, to see whether we can actually reorder it.

```
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
```



**************************************************************

#### 9. Edit account information: `MS_ChangePersonalInfoTest`

This use-case reiterates through already explained mechanisms, it just navigates to the logged in user account page, then goes to the personal details page (`MS_PersonalDetailsPage`), changes the birth day with a random generated number between 1 - 28 and ticks the optional values (Special Offers and Newsletter). For the other fields we preserve the original values by pressing enter over them. for the old password field we have reused the `LoginBO` taking the password field value.


**************************************************************

