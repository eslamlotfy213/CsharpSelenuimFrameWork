using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace Csharp_Selenium_WebDriver_Project
{
    public class WelcomePage
    {
        private IWebDriver driver;

        public WelcomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }



        [FindsBy(How = How.XPath, Using = "//button[@class='chakra-button css-1e9sdxw']")]
        private IWebElement SignUp_buttont;


        [FindsBy(How = How.XPath, Using = "//button[@class='chakra-button css-6wr7f7']")]
        private IWebElement Signin_button;






        public SigininPage user_Can_Signin()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='chakra-button css-6wr7f7']")));

            Signin_button.Click();
            return new SigininPage(driver);

        }


        // methods web element
        public IWebElement getSignin_buttont()
        {
            return Signin_button;
        }








    }
}