using AppService.Models;
using OpenQA.Selenium;
using ProjectCore.Drivers;
using ProjectCore.WebElement;
using UnsplashTest.Pages;

namespace UnsplashTest.UI.Pages
{
    public class CollectionsPage : HomePage
    {
        private readonly Element navToCollectionsTab = new Element(By.XPath($"//a[@data-test='user-nav-link-collections']"));

        
        public void GoToCollectionsTab()
        {
            ShowLoggedinMenu();
            ViewProfile();
            navToCollectionsTab.Click();
        }

        public void ProcessDeleteCollection(string idCollection)
        {
            CollectionElementById(idCollection).Click();
            ButtonCollectionElement("Edit").Click(); //TODO: Dynamic languae
            ButtonCollectionElement("Delete Collection").Click();
            ButtonCollectionElement("Delete").Click();
        }

        public bool VerifyDeleteCollectionProcess(CollectionResponseModel responseModel)
        {
            try
            {
                DriverManager.GetCurrentDriver().Refresh();
                var isVisible = CollectionElementById(responseModel.Id).IsElementVisible();

                return isVisible ? false : true;
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

        protected Element ButtonCollectionElement(string textShow)
        {
            return new Element(By.XPath($"//button[text()='{textShow.Trim()}']"));
        }
    }
}
