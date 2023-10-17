using AppService.Models;
using OpenQA.Selenium;
using ProjectCore.WebElement;
using UnsplashTest.Pages;

namespace UnsplashTest.UI.Pages
{
    public class CollectionsPage : HomePage
    {
        public void ProcessDeleteCollection(string idCollection)
        {
            CollectionElementById(idCollection).Click();
            GetButtonElementByText("Edit").Click(); //TODO: Dynamic languae
            GetButtonElementByText("Delete Collection").Click();
            GetButtonElementByText("Delete").Click();
        }

        public bool VerifyDeleteCollectionProcess(CollectionResponseModel responseModel)
        {
            try
            {
                var isVisible = CollectionElementById(responseModel.Id).IsElementVisible();

                return !isVisible;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected Element CollectionElementById(string id)
        {
            return new Element(By.XPath($"//a[starts-with(@href,'/collections/{id.Trim()}')]"));
        }
    }
}
