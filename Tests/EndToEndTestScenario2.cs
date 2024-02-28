/*using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using MongoDB.Bson;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Csharp_Selenium_WebDriver_Project
{

   // [Parallelizable(ParallelScope.All)]
    class EndToEndTestScenario2 : BaseClass
    {
       [Test, TestCaseSource("AddTestDate"), Category("Regression")]
        public void LoginEndToEndFlowAndViewChallenges(String email, String password,string challenge)
        {

            //Home
            HomePage homePage = new HomePage(driver.Value);

            WelcomePage WelcomePageObj = homePage.user_Can_Create_an_account();

            SigininPage sigininPageobj = WelcomePageObj.user_Can_Signin();

            sigininPageobj.validLogin(email, password);

            challengesPage challengesPageobj = homePage.user_can_click_on_links("Challenges");

            challengesPageobj.waitForPageDisplay();

            String execptedtitle = challenge;

            challengesPageobj.user_Can_View_challenges(execptedtitle);

            challengesdetailsPage challengesdetailsPageobj = challengesPageobj.user_Can_join_challenges();

            String execptedtitle2 = "Join Challenge is currently not available at this moment. Would you like to be alerted once this feature is available?";

            challengesdetailsPageobj.ConfirmdJoinDisplay(execptedtitle2);


        }

  


        public static IEnumerable<TestCaseData> AddTestDate()
        {
            yield return new TestCaseData(getDataparser().extractDate("email"), getDataparser().extractDate("password"), getDataparser().extractDate("challenge"));
            yield return new TestCaseData(getDataparser().extractDate("email2"), getDataparser().extractDate("password2"), getDataparser().extractDate("challenge2"));
            yield return new TestCaseData(getDataparser().extractDate("email3"), getDataparser().extractDate("password3"), getDataparser().extractDate("challenge3"));

        }

    }


}*/