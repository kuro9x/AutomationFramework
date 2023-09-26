using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace ProjectCore.Drivers
{
    public class RemoteChromeDriver : IDriver
    {
        public RemoteChromeDriver()
        {

        }

        public IWebDriver CreateDriver(DriverConfig config)
        {
            var chromeOptions = new ChromeOptions();
            var driver = new RemoteWebDriver(new Uri(config.RemoteUrl), chromeOptions.ToCapabilities(), TimeSpan.FromMinutes(1));

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
