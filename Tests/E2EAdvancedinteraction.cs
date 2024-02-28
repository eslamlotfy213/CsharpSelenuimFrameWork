/*using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Csharp_Selenium_WebDriver_Project
{


    [Parallelizable(ParallelScope.Self)]

    class E2EAdvancedinteraction : BaseClass
    {



        [Test]
        public void Test1()
        {

            //login
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Id("password")).SendKeys("learning");


            //radio button
            IList<IWebElement> radio = driver.Value.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement radiobutton in radio)
            {
                if (radiobutton.GetAttribute("value").Equals("user"))
                {
                    radiobutton.Click();
                }
            }

            //ok wait 
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));

            //ok button 
            driver.Value.FindElement(By.Id("okayBtn")).Click();


            //SelectElement
            IWebElement dropdown = driver.Value.FindElement(By.CssSelector("select.form-control"));
            SelectElement sel = new SelectElement(dropdown);
            sel.SelectByText("Consultant");

            //accept
            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            //sign in button 
            driver.Value.FindElement(By.XPath("//input[@value='Sign In']")).Click();




            driver.Value.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

            //scroll  

            IWebElement framescroll = driver.Value.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);

            driver.Value.SwitchTo().Frame(framescroll);
            driver.Value.FindElement(By.LinkText("All Access Plan")).Click();
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector("h1")).Text);
            driver.Value.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector("h1")).Text);


        }



    }
}
*/