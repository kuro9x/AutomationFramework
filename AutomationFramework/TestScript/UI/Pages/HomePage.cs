using OpenQA.Selenium;
using ProjectCore.Configurations;
using ProjectCore.WebElement;
using UnsplashTest.Constant;
using UnsplashTest.UI.Pages;

namespace UnsplashTest.Pages
{
    public class HomePage : BasePage
    {
        protected readonly Element showLoggedinMenu = new Element(By.Id("popover-avatar-loggedin-menu"));
        protected readonly Element buttonInDialog = new Element(By.XPath($"//div[@role='dialog']//button"));

        public LoginPage GoToLoginPage()
        {
            GoToUrl($"{Application.GetConfig()["Application:BaseUrl"]}login");
            return new LoginPage();
        }

        public void GoToViewProfile()
        {
            ShowLoggedinMenu();
            GetViewProfileElement("View profile").Click();
        }

        public LikesPage GoToLikedTab()
        {
            GoToViewProfile();
            NavToProfileTabByType(ProfileTabType.TabLike).Click();
            return new LikesPage();
        }

        public CollectionsPage GoToCollectionsTab()
        {
            GoToViewProfile();
            NavToProfileTabByType(ProfileTabType.TabCollections).Click();
            return new CollectionsPage();
        }


        protected Element NavToProfileTabByType(string type)
        {
            return new Element(By.XPath($"//a[@data-test='{type}']"));
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

        public Element GetViewProfileElement(string text)
        {
            return new Element(By.XPath($"//a[text()='{text}']"));
        }

        public void ShowLoggedinMenu()
        {
            showLoggedinMenu.Click();
        }
    }
}
