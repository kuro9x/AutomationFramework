using NUnit.Framework;
using TestScript.Unsplash.Testing.Pages;
using ProjectCore.Unsplash.Services.Services;
using ProjectCore.Unsplash.Services.Model;
using Newtonsoft.Json;
using TestScript.TestCase;
using OpenQA.Selenium;
using ProjectCore.Drivers;
using OpenQA.Selenium.Interactions;

namespace TestScript.Unsplash.Testing.Testcases
{
    internal class RemovePhotoFromCollection : TestBase
    {
        [Test]
        [TestCase("bearerToken", "15dh110148@gmail.com", "Abcd@1234", "true", 2)]
        public async Task RemovePhotoFromCollectionSuccessfully(string bearerToken, string email, string password, string isPrivate, int imgNumber)
        {
            IWebDriver driver = WebDriverManager.GetCurrentDriver();
            Actions action = new(driver);

            string collectionTitle = Guid.NewGuid().ToString();
            string description = new Random().Next().ToString();

            CollectionService collectionService = new();

            var response = await collectionService.CreateANewCollection(bearerToken, collectionTitle, isPrivate, description);

            var collection = JsonConvert.DeserializeObject<AddCollectionDto>(response.Content);
            string collectionId = collection.Id;

            LoginPage.InputEmailTextBox(email);
            LoginPage.InputPasswordTextBox(password);
            LoginPage.ClickTheLoginButton();


            HomePage.ClickAFirstPhoto();

            for (int i = 0; i < imgNumber; i++)
            {
                ImageDetailsPage.ClickTheAddCollectionButton();
                ImageDetailsPage.ClickTheCollectionItemByTitle(collectionTitle);
                if (i == imgNumber - 1)
                {
                    ImageDetailsPage.ClickTheCollectionItemByTitle(collectionTitle);
                    break;
                }
                action.SendKeys(Keys.Escape);
                ImageDetailsPage.ClickTheNextButton();
            }

            GeneralPage generalPage = new();

            generalPage.GoToColectionDetailsPage(collectionId);

            CollectionDetailsPage collectionDetailsPage = new();

            Assert.That(collectionDetailsPage.GetListAllPhoto(), Has.Count.EqualTo(imgNumber - 1));

            await collectionService.DeleteACollection(bearerToken, collectionId);

        }
    }
}
