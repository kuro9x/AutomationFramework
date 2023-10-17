using OpenQA.Selenium;
using ProjectCore.Drivers;
using ProjectCore.WebElement;

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

        protected Element GetInputElementByText(string text)
        {
            return new Element(By.XPath($"//input[@value='{text}']"));
        }

        protected Element GetButtonElementByText(string textShow)
        {
            return new Element(By.XPath($"//button[text()='{textShow.Trim()}']"));
        }
    }
}
