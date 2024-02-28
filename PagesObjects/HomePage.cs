using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Csharp_Selenium_WebDriver_Project
{
    class HomePage
    {
  
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }




        [FindsBy(How = How.XPath, Using = "(//div[@class='css-lzb7d6'])[2]")]
        private IWebElement challenge_button;


        [FindsBy(How = How.XPath, Using = "//button[@class='chakra-button css-1ljsqjm']")]
        private IWebElement Create_an_account;


        [FindsBy(How = How.XPath, Using = "//p[@class='chakra-text css-1yh54r5']")]
        private IWebElement user_name;



        [FindsBy(How = How.XPath, Using = "//input[@class='chakra-input WebSearch_input__K3Sfh css-1o4kqu6']")]
        private IWebElement search_text;


        [FindsBy(How = How.XPath, Using = "//button[@class='chakra-button css-1ddia27']")]
        private IWebElement search_icon;


        [FindsBy(How = How.XPath, Using = "//a[@class='chakra-link css-j03ezk']/p")]
        private IWebElement cancel_icon;


        /*
                public void waitForPageDisplay()
                {
                    WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
                    wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='chakra-button css-1ljsqjm']")));


                }

        */
        public WelcomePage user_Can_Create_an_account()
        {


          /*  IAlert simpleAlert = driver.SwitchTo().Alert();
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);
            simpleAlert.Accept();*/

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='chakra-button css-1ljsqjm']")));
            Create_an_account.Click();
            return new WelcomePage(driver);

        }


        // methods web element
        public IWebElement getCreate_an_accounte()
        {
            return Create_an_account;
        }


        public IWebElement getuser_name()
        {
            return user_name;
        }



        public String Verify_user_name()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//p[@class='chakra-text css-1yh54r5']")));

            return driver.FindElement(By.XPath("//p[@class='chakra-text css-1yh54r5']")).Text ;

        }


        public challengesPage user_can_click_on_links(String selectlink)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.css-lzb7d6")));


            IList<IWebElement> links = driver.FindElements(By.CssSelector("div.css-lzb7d6"));
            foreach (IWebElement link in links)
            {
                if (link.Text.Equals(selectlink))
                {
                    link.Click();
                    break;
                }
            }
            return new challengesPage(driver);

        }



        public SearchPage user_Can_Search_for_Text(String text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='chakra-input WebSearch_input__K3Sfh css-1o4kqu6']")));


            search_text.Clear();
            search_text.SendKeys(text);
            search_icon.Click();

            return new SearchPage(driver);

        }




        public HomePage Navigation_links(String selectlink)
        {

            IList<IWebElement> links = driver.FindElements(By.CssSelector("div.css-lzb7d6"));
            foreach (IWebElement link in links)
            {
                if (link.Text.Equals(selectlink))
                {
                    link.Click();
                }
            }

            return new HomePage(driver);

        }








    }
}
