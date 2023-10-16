using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;

namespace ProjectCore.Drivers
{
    public class RemoteEdgeDriver : IDriver
    {
        public RemoteEdgeDriver()
        {

        }

        public WebDriver CreateDriver(DriverConfig config)
        {
            var edgeOptions = new EdgeOptions();
            var driver = new RemoteWebDriver(new Uri(config.RemoteUrl), edgeOptions.ToCapabilities(), TimeSpan.FromMinutes(1));

            return driver;
        }
    }
}
