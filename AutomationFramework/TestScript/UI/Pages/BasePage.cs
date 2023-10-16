using OpenQA.Selenium;
using ProjectCore.Drivers;

namespace UnsplashTest.UI.Pages
{
    public class BasePage
    {
        public IWebDriver WebDriver
        {
            get
            {
                return DriverManager.GetCurrentDriver();
            }
        }

        public void GoToUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
    }
}
