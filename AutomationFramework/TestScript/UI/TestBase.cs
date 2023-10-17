using AppService.Services;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ProjectCore.Configurations;
using ProjectCore.Drivers;
using ProjectCore.Reports.ExtentReport;
using ProjectCore.Service;
using UnsplashTest.Pages;
using ProjectCore.Helpper;

namespace UnsplashTest.TestCase
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class TestBase
    {
        protected static HomePage homePage = new HomePage();
        protected PhotoService photoService;
        protected CollectionService collectionService ;

        [SetUp]
        public void BeforeTest()
        {
            SetUpBrowser();

            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            photoService = new PhotoService(new ApiClient(new RestSharp.RestClient()));
            collectionService = new CollectionService(new ApiClient(new RestSharp.RestClient()));
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            Application.Configure();
            DataStorage.DataStorage.InitDataStorage();
            ExtentTestManager.CreateParentTest(TestContext.CurrentContext.Test.ClassName);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DataStorage.DataStorage.ClearAllData();
            DriverManager.QuitDriver();
            ExtentReportManager.Instance.Flush();
        }

        [TearDown]
        public void AfterTest()
        {
            DataStorage.DataStorage.ClearAllData();
            UpdateTestStatus();
            DriverManager.QuitDriver();
        }

        private static void SetUpBrowser()
        {
            var selectBrowser = Application.GetConfig()["SetUpBrowser"];
            var driver = ApplicationHelper.GetDriverConfigs().Find(x => x.BrowserName.Equals(selectBrowser, StringComparison.OrdinalIgnoreCase));
            DriverManager.InitDriverProvider(driver);
        }

        private static void UpdateTestStatus()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    ExtentTestManager.GetTest().Log(logstatus, $"Message: {TestContext.CurrentContext.Result.Message}");
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            ExtentTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stacktrace);
        }
    }
}
