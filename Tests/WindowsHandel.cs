/*using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace Csharp_Selenium_WebDriver_Project
{


    [Parallelizable(ParallelScope.Self)]
    class WindowsHandel : BaseClass
    {

        [Test]
        public void WindowHandel()
        {

            String email = "mentor@rahulshettyacademy.com";
            String parenentCurrentWindowHandle = driver.Value.CurrentWindowHandle;
            driver.Value.FindElement(By.CssSelector(".blinkingText")).Click();
            TestContext.Progress.WriteLine(driver.Value.WindowHandles.Count);
            Assert.AreEqual(2, driver.Value.WindowHandles.Count);

            String child = driver.Value.WindowHandles[1];

            ////////////////////////////////
            driver.Value.SwitchTo().Window(child);
            //////////////////////////////////
            ///
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector(".red")).Text);
            String text = driver.Value.FindElement(By.CssSelector(".red")).Text;

            // Please email us at mentor@rahulshettyacademy.com with below template to receive response
            // _mentor@rahulshettyacademy.com with below template to receive response

            String[] arraySplit = text.Split("at");
            //arraySplit[1]
            //TestContext.Progress.WriteLine(arraySplit[1].Trim().Split(""));
            String[] trimValue = arraySplit[1].Trim().Split(" ");
            Assert.AreEqual(email, trimValue[0]);

            ////////////////////////////////
            driver.Value.SwitchTo().Window(parenentCurrentWindowHandle);
            ////////////////////////////////

            driver.Value.FindElement(By.Id("username")).SendKeys(trimValue[0]);


        }

    }
}
*/