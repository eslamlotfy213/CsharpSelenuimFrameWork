using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Csharp_Selenium_WebDriver_Project
{
    public class SigininPage
    {
        private IWebDriver driver;

        public SigininPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement email_Text;


        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password_Text;


        [FindsBy(How = How.Id, Using = "next")]
        private IWebElement continue_button;


 



        [FindsBy(How = How.XPath, Using = "(//div[@class='css-lzb7d6'])[5]")]
        private IWebElement features_button;





        public SigininPage validLogin(String email, String pass)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("email")));

            email_Text.Clear();
            email_Text.SendKeys(email);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("password")));
            password_Text.Clear();
            password_Text.SendKeys(pass);


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("next")));
            continue_button.Click();
            return new SigininPage(driver);
        }




        public PostPage user_can_click_on_links(String selectlink)
        {

            IList<IWebElement> links = driver.FindElements(By.CssSelector("div.css-lzb7d6"));
            foreach (IWebElement link in links)
            {
                if (link.Text.Equals(selectlink))
                {
                    link.Click();
                }
            }
            Thread.Sleep(3000);
            return new PostPage(driver);

        }



    }
}