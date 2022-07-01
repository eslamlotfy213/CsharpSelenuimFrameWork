using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
namespace Csharp_Selenium_WebDriver_Project
{
    class PurchasePage
    {
        IWebDriver driver;


        //driver.FindElement(By.Id("country")).SendKeys("ind");
        //driver.FindElement(By.LinkText("India")).Click();
        //driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
        //driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
        //driver.FindElement(By.CssSelector(".alert-success")).Text;


        public PurchasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;



        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement IndiaCountry;


        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2")]
        private IWebElement checkbox2;


        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement Purchasebutton;


        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement successMessage;


        public void WriteCountry(string countryText)
        {
            country.SendKeys(countryText);
        }


        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }

        public void ClickIndiaCountry()
        {
            IndiaCountry.Click();
        }


        public void ClickPurchasebutton()
        {
            Purchasebutton.Click();
        }


        public void Clickagreecheckbox2()
        {
            checkbox2.Click();
        }



        public string getsuccessMessage()
        {
            return successMessage.Text;
        }



    }
}
