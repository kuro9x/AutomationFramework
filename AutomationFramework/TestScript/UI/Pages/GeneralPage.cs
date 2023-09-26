using OpenQA.Selenium;

namespace TestScript.Pages
{
    public class GeneralPage
    {
        private readonly IWebDriver _driver;

        public GeneralPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
