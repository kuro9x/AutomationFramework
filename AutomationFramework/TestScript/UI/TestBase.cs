using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;
using AventStack.ExtentReports.Reporter;
using ProjectCore.Reports;
using ProjectCore.Drivers;
using TestScript.Configs;

namespace TestScript.TestCase
{
    public class TestBase
    {
        public static ExtentReports extent;
        public static ExtentTest testlog;

        [SetUp]
        public void BeforeTest()
        {
            DriverManager.InitDriverProvider(new DriverConfig
            {
                BrowserName = Application.GetConfig()["DriverConfig:BrowserName"],
                Version = Application.GetConfig()["DriverConfig:Version"]
            });
        }

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = ExtentManager.getExtentReports();
            Application.Configure();
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            //LoggingTestStatusExtentReport();
            extent.Flush();
        }

        public static void LoggingTestStatusExtentReport()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.Empty + TestContext.CurrentContext.Result.StackTrace + string.Empty;
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        testlog.Log(Status.Fail, "Test ended with " + Status.Fail + " – " + errorMessage);
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        testlog.Log(Status.Skip, "Test ended with " + Status.Skip);
                        break;
                    default:
                        logstatus = Status.Pass;
                        testlog.Log(Status.Pass, "Test ended with " + Status.Pass);
                        break;
                }
            }
            catch (WebDriverException ex)
            {
                throw ex;
            }

        }

    }
}
