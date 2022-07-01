using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Csharp_Selenium_WebDriver_Project
{
    class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        // Page object Model [factory Pattern]
        // Locators 






        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;



        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;


        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signInbutton;



        public ProductPage validLogin(String user, String pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkbox.Click();
            signInbutton.Click();
            return new ProductPage(driver);

        }




        // methods web element
        public IWebElement getUserName()
        {
            return username;
        }

        public IWebElement getPassword()
        {
            return password;
        }





    }
}
