using AppService.Models;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ProjectCore.Configurations;
using ProjectCore.Drivers;
using ProjectCore.Reports.ExtentReport;
using RestSharp;
using UnsplashTest.Models;
using UnsplashTest.Pages;
using UnsplashTest.UI.Pages;

namespace UnsplashTest.TestCase
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class TestBase
    {
        protected static HomePage homePage = new HomePage();
        protected static LoginPage loginPage = new LoginPage();
        protected static LikesPage likesPage = new LikesPage();
        protected static CollectionsPage collectionsPage = new CollectionsPage();
        

        [SetUp]
        public void BeforeTest()
        {
            var data = Application.GetTestUsers();
            SetUpAccountData();
            DriverManager.InitDriverProvider(new DriverConfig
            {
                BrowserName = Application.GetConfig()["DriverConfig:BrowserName"],
                Version = Application.GetConfig()["DriverConfig:Version"]
            });

            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            Application.Configure();
            ExtentTestManager.CreateParentTest(TestContext.CurrentContext.Test.ClassName);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DriverManager.QuitDriver();
            ExtentReportManager.Instance.Flush();
        }

        [TearDown]
        public void AfterTest()
        {
            DataStorage.DataStorage.ClearAccountData();
            UpdateTestStatus();
            DriverManager.QuitDriver();
        }

        private void SetUpAccountData()
        {
            var objAccount = Application.GetConfig()["Application"];
            var accounts = JsonConvert.DeserializeObject<List<AccountModel>>(objAccount);
            
            foreach(var account in accounts)
            {
                DataStorage.DataStorage.AddAccountData(account.Key, account);
            }
        }

        public static void UpdateTestStatus()
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
