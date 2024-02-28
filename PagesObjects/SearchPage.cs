using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V101.DOMSnapshot;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_Selenium_WebDriver_Project
{
    public class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }



        [FindsBy(How = How.XPath, Using = "//div[@class='panel-title pull-left']")]
        private IWebElement header_search;



        [FindsBy(How = How.Id, Using = "editableSubject")]
        private IWebElement subject_result;




        public string getsubject_result()
        {

            return driver.FindElement(By.XPath("//span[@class='editable']")).Text;
        }


        public SearchPage user_can_clickon_Desired_post(String topic)
        {
            IWebElement framescroll = driver.FindElement(By.Id("search"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.SwitchTo().Frame("search");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='panel-title pull-left']")));


     
            IList<IWebElement> topics = driver.FindElements(By.XPath("//a[@class='topic-title']/span"));

            //radio button
            foreach (IWebElement top in topics)
            {
                if (top.Text.Trim().Contains(topic))
                {
                    top.Click();
                    break;

                }
            }

            return new SearchPage(driver);

        }








    }
}