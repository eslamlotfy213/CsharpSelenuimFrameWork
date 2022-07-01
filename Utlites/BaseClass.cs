using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Csharp_Selenium_WebDriver_Project
{
    class BaseClass
    {


        public ExtentReports extent;
        public ExtentTest test;
        [OneTimeSetUp]
        public void SetUp()
        {

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Enviroment", "QA");
            extent.AddSystemInfo("Username ", "Islam");
        }


        string browserName;
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Configuration file 
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];

            }

            // string environmentName = ConfigurationManager.AppSettings["environment"];

            InitBrowser(browserName);
            //  SelectEnviroment(environmentName);
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://www.rahulshettyacademy.com/loginpagePractise/";
        }


        public void SelectEnviroment(string environmentName)
        {
            switch (environmentName)
            {
                case "Test_environmentName":
                    driver.Value.Url = "https://www.rahulshettyacademy.com/loginpagePractise/";
                    break;
                case "production_environmentName":
                    driver.Value.Url = "https://www.google.com/";
                    break;
                default:
                    break;
            }
            TestContext.Progress.WriteLine(" Not suppoted Enviroment ");
        }


        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "FireFox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
                    /* default:
                         break;*/
            }
            //TestContext.Progress.WriteLine("Browser Not Supported Please ?  Choose  Any Of Them [Chrome , FireFox , Edge] In Configuration File only ");
        }


        public static JasonReader getDataparser()
        {

            return new JasonReader();
        }



        [TearDown]
        public void CloseBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "ScreenShot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
                test.Fail("Test failed", CaptureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, "Test is faild with Logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {
            }

            extent.Flush();
            driver.Value.Quit();
        }


        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, String ScreenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScreenshotName).Build();
        }


    }
}
