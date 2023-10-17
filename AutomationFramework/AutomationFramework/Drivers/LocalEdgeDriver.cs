using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace ProjectCore.Drivers
{
    public class LocalEdgeDriver : IDriver
    {
        public LocalEdgeDriver()
        {

        }

        public WebDriver CreateDriver(DriverConfig driverConfig)
        {
            var options = new EdgeOptions();
            options.BinaryLocation = $"{driverConfig.BinaryLocation}";
            options.AddAdditionalOption("BrowserVersion", driverConfig.Version);
            var driver = new EdgeDriver(options);

            return driver;
        }
    }
}
