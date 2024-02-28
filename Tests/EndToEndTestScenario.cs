/*using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using MongoDB.Bson;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_Selenium_WebDriver_Project
{

   // [Parallelizable(ParallelScope.All)]
    class EndToEndTestScenario : BaseClass
    {
       // [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource("AddTestDate"), Category("Regression")]
        public void LoginEndToEndFlowAndCreateNewpost(String email, String password)
        {

            //Home
            HomePage homePage = new HomePage(driver.Value);

            WelcomePage WelcomePageObj = homePage.user_Can_Create_an_account();

            SigininPage sigininPageobj = WelcomePageObj.user_Can_Signin();

            sigininPageobj.validLogin(email, password);

            String execptedProducts = "Newone";

            TestContext.Progress.WriteLine(execptedProducts);

            //Assert.That(homePage.Verify_user_name().Length > 0, Is.True, "Verify login successfully");

            PostPage postpageobj = sigininPageobj.user_can_click_on_links("Features");

            postpageobj.user_Can_create_Post("Automation by eslam");

        }





        public static IEnumerable<TestCaseData> AddTestDate()
        {
            yield return new TestCaseData(getDataparser().extractDate("email"), getDataparser().extractDate("password"));
            yield return new TestCaseData(getDataparser().extractDate("email2"), getDataparser().extractDate("password2"));
}

    }


}*/