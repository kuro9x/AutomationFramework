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
            var edgeOption = new EdgeOptions();
            var driver = new EdgeDriver(edgeOption);

            return driver;
        }
    }
}
