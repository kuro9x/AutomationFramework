using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ProjectCore.Drivers
{
    public class LocalFirefoxDriver : IDriver
    {
        public LocalFirefoxDriver()
        {

        }

        public IWebDriver CreateDriver(DriverConfig driverConfig)
        {
            var firefoxOption = new FirefoxOptions();
            var driver = new OpenQA.Selenium.Firefox.FirefoxDriver(firefoxOption);

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
