using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
namespace Csharp_Selenium_WebDriver_Project
{
    class CheckoutPage
    {
        IWebDriver driver;



        //  driver.FindElements(By.CssSelector("h4 a"));
        //driver.FindElement(By.CssSelector(".btn-success")).Click();
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;


        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkOutButton;


        public IList<IWebElement> getCards()
        {

            return checkoutCards;
        }

        public PurchasePage ClickcheckOutbutton()
        {
            checkOutButton.Click();
            return new PurchasePage(driver);
        }


    }
}
