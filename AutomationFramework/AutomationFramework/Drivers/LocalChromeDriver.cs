using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjectCore.Drivers
{
    public class LocalChromeDriver : IDriver
    {
        public LocalChromeDriver()
        {

        }

        public IWebDriver CreateDriver(DriverConfig config)
        {
            var chromeOptions = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();

            var driver = new ChromeDriver(service, chromeOptions);

            return driver;
        }

        public void KillDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
