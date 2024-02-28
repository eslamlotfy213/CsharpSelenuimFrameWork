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
    class EndToEndTestScenario3 : BaseClass
    {
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








    }


}*/