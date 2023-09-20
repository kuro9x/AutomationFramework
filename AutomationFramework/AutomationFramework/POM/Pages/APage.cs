using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V114.Network;

namespace ProjectCore.POM.Pages
{
    public abstract class APage : IPage
    {
        private readonly IWebDriver _driver;

        protected APage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open(string url)
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(url);
        }

        public void GoBack()
        {
            _driver.Navigate().Back();
        }

        public virtual void ConfirmAlert()
        {
            //using driver to swith to alert and click confirm button
        }

        public virtual void CloseAdvertisement()
        {
            //Each page will have diff Ad, so implement it in derived class
        }
    }
}
