using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Csharp_Selenium_WebDriver_Project
{
    class ProductPage
    {
        IWebDriver driver;

        By Cardtitle = By.CssSelector(".card-title a");
        By addToCard = By.CssSelector(".card-footer button");

        //            driver.FindElement(By.PartialLinkText("Checkout")).Click();

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement CheckOutButton;


        public void waitForPageDisplay()
        {
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));


        }


        public IList<IWebElement> getCards()
        {
            return cards;
        }


        public By getCardTitle()
        {
            return Cardtitle;
        }


        public CheckoutPage checkout()
        {
            CheckOutButton.Click();
            return new CheckoutPage(driver);
        }



        public By AddToCardButton()
        {

            return addToCard;
        }

    }
}
