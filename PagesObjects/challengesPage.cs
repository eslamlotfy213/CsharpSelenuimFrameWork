using AngleSharp.Dom;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Csharp_Selenium_WebDriver_Project
{
    class challengesPage
    {
  
        IWebDriver driver;
        public challengesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[@class='chakra-button css-n70wdt']")]
        private IList<IWebElement> Learn_More;



        [FindsBy(How = How.XPath, Using = "//button[@class='chakra-button css-ke83f5']")]
        private IWebElement Join_More;



        [FindsBy(How = How.XPath, Using = "//p[@class='chakra-text css-a74edy']")]
        private IList<IWebElement> Title_challenges;



        By ele_Learn_More = By.XPath("//button[@class='chakra-button css-n70wdt']");

        public IList<IWebElement> getLearn_More()
        {
            return Learn_More;
        }


        public IList<IWebElement> getTitlechallenges()
        {
            return Title_challenges;
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




        public challengesPage user_Can_View_challenges(String challenge)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IList<IWebElement> challengestext = getTitlechallenges();


            for (int i = 0; i < challengestext.Count; i++)
            {
                if (challenge.Contains(challengestext[i].Text))
                {
                    driver.FindElement(By.XPath("(//button[@class='chakra-button css-n70wdt'])[" + (i + 1) + "]")).Click();
                    break;
                }
            }

            return new challengesPage(driver);
        }


        public challengesdetailsPage user_Can_join_challenges()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='chakra-button css-ke83f5']")));
            Join_More.Click();
            return new challengesdetailsPage(driver);

        }

    }
}
