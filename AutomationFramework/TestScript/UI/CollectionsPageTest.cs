using AppService.Models;
using AppService.Services;
using NUnit.Framework;
using ProjectCore.Configurations;
using UnsplashTest.Models;
using UnsplashTest.TestCase;

namespace UnsplashTest.UI
{
    public class CollectionsPageTest : TestBase
    {
        private static object[] _sourceLists =
        {
            new CollectionRequestModel
            {
                Title = "Title_1",
                Description = "Description_1",
                Private = true
            }
        };

        [TestCaseSource(nameof(_sourceLists))]
        public async Task DeleteCollection_Should_Success(CollectionRequestModel collectionRequest)
        {
            // 1. Prepare Collection
            CollectionService collectionService = new CollectionService(new ApiClient(new RestSharp.RestClient()));
            var resultAddCollection = await collectionService.AddCollection(collectionRequest);

            // 2. Login
            homePage.GoToUrl($"{Application.GetConfig()["Application:BaseUrl"]}login");
            AccountModel account = new AccountModel
            {
                Email = Application.GetConfig()["Application:Account:Email"],
                Password = Application.GetConfig()["Application:Account:Password"]
            };

            loginPage.Login(account);
            // 3. Go to collection tab
            collectionsPage.GoToCollectionsTab();
            // 4. Process delete collection
            collectionsPage.ProcessDeleteCollection(resultAddCollection.Id);
            // 5. Verify data
            var expectData = collectionsPage.VerifyDeleteCollectionProcess(resultAddCollection);

            Assert.IsTrue(expectData);
        }
    }
}
