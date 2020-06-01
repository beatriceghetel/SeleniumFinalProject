# SeleniumFinalProject
#### FEAA-Automation Solution Project (http://automationpractice.com/index.php)

### Automation Tests
#### 1. MS_RegisterTest
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

#### 2. MS_LoginTest
This test was written in order to verify the login process, filling in the fields related to email address and password. First, we checked if the “sign-in” button works, so we can log in into our account using the correct credentials. Then, we identified the alert message that appears when the value added in one of the fields is invalid (inccorect email or inccorect password).
We instantiated our driver to open the Chrome browser and then we accessed the site to be tested. 
We created `MS_LoginPage` and `LoginBO` in order to reuse them in the init process of the next tests.
 
#### 3. MS_AddNewAddressTest
After creating a new account, we created a test in order to add a new address. For that, we created `NewAddressBO` which is similar to the one used in RegisterPage, but the difference is that this one holds informations just about address.

#### 4. MS_ContactFormTest
We created this test in order to complete the Contact Form. We explored two scenarios:
* Contact form without attachment - fill just the minimum required fields 
* Contact form with attachment - we added an attachment
For the fields with implicit values (taken from the current logged in user), we clicked the input in order to confirm the value.

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

#### 5. MS_AddToWishlistTest
The scenario we followed for adding a product to wishlist is to use the search bar in order to find a specific shop item by name(for which we created a bussines object contained the name of the item). Then we ensured the fact that the result are being displayed in grid perspective and then we "wishlisted" the first item from the resulted list. In order to check the expected result, we had to check the text display from the modal box.
```
private By modalBox = By.CssSelector(".fancybox-error");
private IWebElement LblSuccessfullyAdded => driver.FindElement(modalBox);
 ```
