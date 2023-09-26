using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;
using AventStack.ExtentReports.Reporter;
using ProjectCore.Reports;

namespace TestScript.TestCase
{
    public class TestBase
    {
        public static ExtentReports extent;
        public static ExtentTest testlog;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = ExtentManager.getExtentReports();
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            LoggingTestStatusExtentReport();
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
                        testlog.Log(Status.Fail, "Test steps NOT Completed for Test case " + TestContext.CurrentContext.Test.Name + " ");
                        testlog.Log(Status.Fail, "Test ended with " + Status.Fail + " – " + errorMessage);
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        testlog.Log(Status.Skip, "Test ended with " + Status.Skip);
                        break;
                    default:
                        logstatus = Status.Pass;
                        testlog.Log(Status.Pass, "Test steps finished for test case " + TestContext.CurrentContext.Test.Name);
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
