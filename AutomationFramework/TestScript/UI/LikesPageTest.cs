using NUnit.Framework;
using ProjectCore.Reports.ExtentReport;
using UnsplashTest.TestCase;
using UnsplashTest.UI.Pages;

namespace UnsplashTest.UI
{
    [TestFixture]
    public class LikesPageTest : TestBase
    {
        [TestCase("Account1")]
        public async Task UnlikePhoto_Should_Success(string accountKey)
        {
            ExtentTestManager.GetTest().Info($"1. Prepare data - like photo lastest");
            var photos = DataStorage.DataStorage.GetPhotos();
            var accessToken = DataStorage.DataStorage.GetAccounts().FirstOrDefault().AccessToken;
            await photoService.LikePhotos(photos.Select(x => x.Id).ToList(), accessToken);

            ExtentTestManager.GetTest().Info("2. Login");
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.ProcessLogin(accountKey);

            ExtentTestManager.GetTest().Info("3. GoTolikesTab");
            LikesPage likesPage = homePage.GoToLikedTab();

            ExtentTestManager.GetTest().Info("4. ProcessUnlikePhotos");
            likesPage.ProcessUnlikePhotos(photos.Select(x => x.Slug).ToList());

            ExtentTestManager.GetTest().Info("5. Verify data");
            Assert.IsTrue(likesPage.VerifyUnlikeProcess(photos.Select(x => x.Slug).ToList()));
        }

        [SetUp]
        public void BeforeLikesPageTest()
        {
            var photos = DataStorage.DataStorage.GetListPhotoTestConfig();
            DataStorage.DataStorage.ProcessAddPhotoData(photos.Take(2).ToList());
            var listAccount = DataStorage.DataStorage.GetListAccountTestConfig();
            DataStorage.DataStorage.ProcessAddAccountData(listAccount.Take(1).ToList());
        }

        [TearDown]
        public async Task AfterLikesPageTest()
        {
            var photoIds = DataStorage.DataStorage.GetPhotos();
            var accessToken = DataStorage.DataStorage.GetAccounts().FirstOrDefault().AccessToken;
            await photoService.UnLikePhotos(photoIds.Select(x => x.Id).ToList(), accessToken);
            DataStorage.DataStorage.ClearDataByType("Photo");
        }
    }
}
