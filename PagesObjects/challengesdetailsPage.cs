using AngleSharp.Dom;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Csharp_Selenium_WebDriver_Project
{
    class challengesdetailsPage
    {
  
        IWebDriver driver;
        public challengesdetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//div[@id='chakra-modal--body-:r1:']")]
        private IWebElement model_body;


        [FindsBy(How = How.XPath, Using = "//div[@class='css-1ggsmk3']")]
        private IWebElement reminde_me_later;

        [FindsBy(How = How.XPath, Using = "//p[@class='chakra-text css-1kr7s2v']")]
        private IWebElement model_text;

        
        By model_bodyloc = By.XPath("//div[@id='chakra-modal--body-:r1:']");


        public void ConfirmdJoinDisplay(string  poptext)
        {

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(model_bodyloc));


            //            IAlert simpleAlert = driver.SwitchTo().Alert();

            //           String alertText = simpleAlert.Text;
            //          TestContext.Progress.WriteLine("Alert text is " + alertText);

            if (poptext.Trim().Contains(model_text.Text))
            {
                Assert.That(model_text.Text, Is.EqualTo(poptext));
                reminde_me_later.Click();
            }

        }




        public void waitForPageDisplay()
        {
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//p[@class='chakra-text css-1wd8yy2'])[1]")));

            ScrollToPageDisplay(By.XPath("(//p[@class='chakra-text css-1wd8yy2'])[1]"));


        }

        public void ScrollToPageDisplay(By element)
        {

            IWebElement scroll = driver.FindElement(element);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", scroll);


        }




      





    }
}
