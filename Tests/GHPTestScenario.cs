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
    class GHPTestScenario : BaseClass
    {


        // [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource("newAddTestDate"), Category("Smoke")]
        public void LoginEndToEndFlowAndCreateNewpost(String email, String password)
        {
            string postname = "Automation by eslam";
            //Home
            HomePage homePage = new HomePage(driver.Value);

            WelcomePage WelcomePageObj = homePage.user_Can_Create_an_account();

            SigininPage sigininPageobj = WelcomePageObj.user_Can_Signin();

            sigininPageobj.validLogin(email, password);

            String execptedProducts = "Newpost";

            TestContext.Progress.WriteLine(execptedProducts);

           // Assert.That(homePage.Verify_user_name().Length > 0, Is.True, "Verify login successfully");

            PostPage postpageobj = sigininPageobj.user_can_click_on_links("Features");

            postpageobj.user_Can_create_Post(postname);

        }

        String SearhText = "testing";
        [Test, Category("Smoke")]
        public void Guest_User_Can_Observe_Posts_With_Search()
        {
            HomePage homePage = new HomePage(driver.Value);

            homePage.Navigation_links("Home");

            SearchPage searchPageobi = homePage.user_Can_Search_for_Text(SearhText);

            searchPageobi.user_can_clickon_Desired_post(SearhText);


            Console.WriteLine(searchPageobi.getsubject_result());
            Assert.AreEqual(SearhText, searchPageobi.getsubject_result(), "Verify the post is display successfully ");

        }



        [Test, TestCaseSource("AddTestDate"), Category("Smoke")]
        public void LoginEndToEndFlowAndViewChallenges(String email, String password, string challenge)
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










        public static IEnumerable<TestCaseData> newAddTestDate()
        {
            yield return new TestCaseData(getDataparser().extractDate("email"), getDataparser().extractDate("password"));
            yield return new TestCaseData(getDataparser().extractDate("email2"), getDataparser().extractDate("password2"));
            yield return new TestCaseData(getDataparser().extractDate("email3"), getDataparser().extractDate("password3"));

        }


        public static IEnumerable<TestCaseData> AddTestDate()
        {
            yield return new TestCaseData(getDataparser().extractDate("email"), getDataparser().extractDate("password"), getDataparser().extractDate("challenge"));
            yield return new TestCaseData(getDataparser().extractDate("email2"), getDataparser().extractDate("password2"), getDataparser().extractDate("challenge2"));
            yield return new TestCaseData(getDataparser().extractDate("email3"), getDataparser().extractDate("password3"), getDataparser().extractDate("challenge3"));

        }

    }


}*/