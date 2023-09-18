using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ProjectCore.Drivers
{
    public class FirefoxDriverProvider : IDriver
    {
        public FirefoxDriverProvider()
        {

        }

        public IWebDriver CreateDriver()
        {
            var firefoxOption = new FirefoxOptions();
            var driver = new FirefoxDriver(firefoxOption);

            return driver;
        }

        public void KillDriver(IWebDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
