# SeleniumFinalProject
#### FEAA-Automation Solution Project (http://automationpractice.com/index.php)

### Automation Tests
#### 1. MS_RegisterTest
Register test refers to the process of creating a new account using an email address (automatically and randomly generated)



#### 2. MS_LoginTest
The first test was written in order to verify the login process, filling in the fields related to email address and password. First, we checked if the “sign-in” button works, so we can log in into our account using the correct credentials. Then, we identified the alert message that appears when the value added in one of the fields is invalid. 
We instantiated our driver to open the Chrome browser:
  ```
  driver = new ChromeDriver(); //open chrome browser
  driver.Manage().Window.Maximize(); //maximize the window
  driver.Navigate().GoToUrl("http://automationpractice.com/"); //access url
  ```
