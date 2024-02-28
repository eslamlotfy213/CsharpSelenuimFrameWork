using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Csharp_Selenium_WebDriver_Project
{
    public class PostPage
    {
        private IWebDriver driver;

        public PostPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }



        [FindsBy(How = How.Id, Using = "postSubject")]
        private IWebElement title_text;


        [FindsBy(How = How.Id, Using = "tinymce")]
        private IWebElement message_text;


        [FindsBy(How = How.XPath, Using = "//button[@class='chakra-button css-1pbbitw']")]
        private IWebElement post_button;


        [FindsBy(How = How.Id, Using = "post_submit")]
        private IWebElement Post_new_Topic;



        public PostPage user_Can_create_Post(String postname)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='chakra-button css-1pbbitw']")));
            post_button.Click();


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("post")));

            IWebElement framescroll = driver.FindElement(By.Id("post"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);


            driver.SwitchTo().Frame("post");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("postSubject")));
            title_text.SendKeys(postname);


            driver.SwitchTo().Frame("message_ifr");
            message_text.SendKeys("individual. All health practitioners are required to sign a federal law, the Health Insurance Portability and Accountability Act (HIPAA) (Huntington, 2010). This is an indication and proof that they are ready to abide by the patients confidentiality act.");

            driver.SwitchTo().ParentFrame();

            IWebElement post_submit = driver.FindElement(By.Id("post_submit"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", post_submit);

            //IWebElement category_Dropdown = driver.FindElement(By.Id("categoryDropdown"));
            //category_Dropdown.Click();

            //IWebElement Search_Dropdown = driver.FindElement(By.Id("input-search"));
            //Search_Dropdown.SendKeys("Community");


            /*IList<IWebElement> categorylinks = driver.FindElements(By.XPath("//div[@id='categoryTree']/ul/li"));
            foreach (IWebElement catlink in categorylinks)
            {
                if (catlink.Text.Equals("Community"))
                {
                    catlink.Click();
                }
            }
            */
            Post_new_Topic.Click();
            return new PostPage(driver);

        }










    }
}