using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjectCore.Drivers
{
    public class ChromeDriverProvider : IDriver
    {
        public ChromeDriverProvider()
        {

        }

        public IWebDriver CreateDriver()
        {
            var chromeOptions = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();

            var driver = new ChromeDriver(service, chromeOptions);

            return driver;
        }

        public void KillDriver(IWebDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
