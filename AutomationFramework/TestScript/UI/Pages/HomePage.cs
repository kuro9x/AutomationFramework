using OpenQA.Selenium;
using ProjectCore.WebElement;
using UnsplashTest.Constant;
using UnsplashTest.UI.Pages;

namespace UnsplashTest.Pages
{
    public class HomePage : BasePage
    {
        private readonly Element showLoggedinMenu = new Element(By.Id("popover-avatar-loggedin-menu"));
        private readonly Element viewProfileButton = new Element(By.XPath($"//a[text()='View profile']"));
        private readonly Element buttonInDialog = new Element(By.XPath($"//div[@role='dialog']//button"));

        public void ProcessUnlikePhotos(List<string> likedPhotos)
        {
            foreach (var photoName in likedPhotos)
            {
                ElementByPhotoName(photoName).Click();
                ElementPhotoActionButton(ActionButton.Like).Click();
                Thread.Sleep(1000);
                CloseDialogPhoto();
            }
        }

        protected Element ElementByPhotoName(string photoName)
        {
            return new Element(By.XPath($"//a[@itemprop='contentUrl' and @href='/photos/{photoName}']"));
        }

        protected Element ElementPhotoActionButton(string action)
        {
            return new Element(By.XPath($"//div[@data-test='photos-route']//child::header//button[@title='{action}']"));
        }

        protected void CloseDialogPhoto()
        {
            buttonInDialog.FindElementsSafe()?.FirstOrDefault()?.Click();
        }

        public void ViewProfile()
        {
            viewProfileButton.Click();
        }

        public void ShowLoggedinMenu()
        {
            showLoggedinMenu.Click();
        }
    }
}
