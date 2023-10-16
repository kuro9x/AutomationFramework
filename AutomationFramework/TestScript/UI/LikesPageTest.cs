using AppService.Services;
using NUnit.Framework;
using ProjectCore.Configurations;
using ProjectCore.Reports.ExtentReport;
using UnsplashTest.Models;
using UnsplashTest.TestCase;

namespace UnsplashTest.UI
{
    public class LikesPageTest : TestBase
    {
        [TestCase("Account1", 5)]
        public async Task UnlikePhoto_Should_Success(string accountKey, int numberOfPhoto)
        {
            PhotoService photoService = new PhotoService(new ApiClient(new RestSharp.RestClient()));
            ExtentTestManager.GetTest().Info("1. Prepare data - like 5 photo lastest");
            var photos = await photoService.GetPhotosLatest(1, numberOfPhoto);
            var responseLikePhoto = await photoService.LikePhotos(photos.Select(x => x.Id).ToList());

            ExtentTestManager.GetTest().Info("2. Login");


            homePage.GoToUrl($"{Application.GetConfig()["Application:BaseUrl"]}login");
            AccountModel account = new AccountModel
            {
                Email = Application.GetConfig()["Application:Account:Email"],
                Password = Application.GetConfig()["Application:Account:Password"]
            };

            loginPage.Login(account);

            ExtentTestManager.GetTest().Info("3. GoTolikesTab");
            likesPage.GoTolikedTab();

            ExtentTestManager.GetTest().Info("4. ProcessUnlikePhotos");
            homePage.ProcessUnlikePhotos(photos.Select(x => x.Slug).ToList());

            ExtentTestManager.GetTest().Info("5. Verify data");
            Assert.IsTrue(likesPage.VerifyUnlikeProcess(photos.Select(x => x.Slug).ToList()));
        }
    }
}
