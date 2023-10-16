using OpenQA.Selenium;
using ProjectCore.Drivers;
using ProjectCore.WebElement;
using UnsplashTest.Pages;

namespace UnsplashTest.UI.Pages
{
    public class LikesPage: HomePage
    {
        private readonly Element navToLikeTab = new Element(By.XPath($"//a[@data-test='user-nav-link-likes']"));

        public void GoTolikedTab()
        {
            ShowLoggedinMenu();
            ViewProfile();
            navToLikeTab.Click();
        }

        public bool VerifyUnlikeProcess(List<string> photoNames)
        {
            try
            {
                DriverManager.GetCurrentDriver().Refresh();
                
                foreach(var photoName in photoNames)
                {
                    var isVisible = ElementByPhotoName(photoName).IsElementVisible();

                    if (isVisible)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
