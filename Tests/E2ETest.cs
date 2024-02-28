using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_Selenium_WebDriver_Project
{

    [Parallelizable(ParallelScope.Children)]
    class E2ETest : BaseClass
    {
        //       [TestCase ("rahulshettyacademy", "learning")]
        //       [TestCase("rahulshettyacademy2", "learning2")]
        // 
        [Parallelizable(ParallelScope.Self)]
        [Test, TestCaseSource("AddTestDate"), Category("Regression")]
        public void EndToEndFlow(String username, String password, String[] execptedProducts)
        {

            // String[] execptedProducts = { "iphone X", "Samsung Note 8", "Blackberry" };
            String[] actualProducts = new string[execptedProducts.Length];

            //login
            LoginPage loginPage = new LoginPage(driver.Value);
            ProductPage productsObj = loginPage.validLogin(username, password);

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
            ////-------------------------------------------------------------------------------------------------------------///



            //Checkout wait created through Login
            productsObj.waitForPageDisplay();

            IList<IWebElement> products = productsObj.getCards();

            foreach (IWebElement pro in products)
            {
                //                TestContext.Progress.WriteLine(pro.FindElement(By.CssSelector(".card-title a")).Text);
                if (execptedProducts.Contains(pro.FindElement(productsObj.getCardTitle()).Text))
                {

                    pro.FindElement(productsObj.AddToCardButton()).Click();
                }
            }

            CheckoutPage checkoutobj = productsObj.checkout();
            ////-------------------------------------------------------------------------------------------------------------///


            IList<IWebElement> checkoutcar = checkoutobj.getCards();
            for (int i = 0; i < checkoutcar.Count; i++)
            {

                actualProducts[i] = checkoutcar[i].Text;

            }
            Assert.AreEqual(execptedProducts, actualProducts);



            PurchasePage purchaseobj = checkoutobj.ClickcheckOutbutton();
            ////-------------------------------------------------------------------------------------------------------------///

            purchaseobj.WriteCountry("ind");
            purchaseobj.waitForPageDisplay();
            purchaseobj.ClickIndiaCountry();
            purchaseobj.Clickagreecheckbox2();
            purchaseobj.ClickPurchasebutton();

            String ExpectedText = "Success!";
            String ActualText = purchaseobj.getsuccessMessage();
            StringAssert.Contains(ExpectedText, ActualText);

        }




        [Test, Category("Smoke")]
        public void WindowHandelTestCase()
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




        public static IEnumerable<TestCaseData> AddTestDate()
        {
            yield return new TestCaseData(getDataparser().extractDate("username_Wrong"), getDataparser().extractDate("password_Wrong"), getDataparser().extractDateArray("products"));
            yield return new TestCaseData(getDataparser().extractDate("username"), getDataparser().extractDate("password"), getDataparser().extractDateArray("products"));
           // yield return new TestCaseData(getDataparser().extractDate("username"), getDataparser().extractDate("password"), getDataparser().extractDateArray("products"));

        }

    }


}