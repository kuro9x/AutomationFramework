using AppService.Models;
using NUnit.Framework;
using ProjectCore.Reports.ExtentReport;
using UnsplashTest.TestCase;
using UnsplashTest.UI.Pages;

namespace UnsplashTest.UI
{
    [TestFixture]
    public class CollectionsPageTest : TestBase
    {
        [TestCase("Account1")]
        public async Task DeleteCollection_Should_Success(string accountKey)
        {

            ExtentTestManager.GetTest().Info("1. Prepare Add new Collection");
            var collection = DataStorage.DataStorage.GetCollections().FirstOrDefault();
            var accessToken = DataStorage.DataStorage.GetAccountInfo(accountKey).AccessToken;
            var resultAddCollection = await collectionService.AddCollection(new CollectionRequestModel
                                        {
                                            Title = collection.Title,
                                            Description = collection.Description,
                                            Private = collection.Private
                                        }, accessToken);

            collection.Id = resultAddCollection.Id;

            ExtentTestManager.GetTest().Info("2. Login");
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.ProcessLogin(accountKey);

            ExtentTestManager.GetTest().Info("3. Go to collection tab");
            CollectionsPage collectionsPage = homePage.GoToCollectionsTab();

            ExtentTestManager.GetTest().Info("4. Process delete collection");
            collectionsPage.ProcessDeleteCollection(resultAddCollection.Id);

            ExtentTestManager.GetTest().Info("5. Verify data");
            var expectData = collectionsPage.VerifyDeleteCollectionProcess(resultAddCollection);

            Assert.IsTrue(expectData);
        }

        [SetUp]
        public void BeforeLikesPageTest()
        {
            var collections = DataStorage.DataStorage.GetListCollectionTestConfig();
            DataStorage.DataStorage.ProcessAddCollectionData(collections.ToList());
            var listAccount = DataStorage.DataStorage.GetListAccountTestConfig();
            DataStorage.DataStorage.ProcessAddAccountData(listAccount.Take(1).ToList());
        }

        [TearDown]
        public async Task AfterLikesPageTest()
        {
            var collections = DataStorage.DataStorage.GetCollections();
            var accessToken = DataStorage.DataStorage.GetAccounts().FirstOrDefault().AccessToken;
            await collectionService.DeleteCollections(collections.Select(x => x.Id).ToList(), accessToken);
            DataStorage.DataStorage.ClearDataByType("Collection");
        }
    }
}
