using OpenQA.Selenium;
using ProjectCore.Drivers;

namespace ProjectCore.Configurations
{
    public class TestConfigs
    {
        public static IWebDriver _driver;

        public static IWebDriver InitDriver(DriverType type)
        {
            var driverFactory = new DriverFactory();
            _driver = driverFactory.GetDriverProvider(type);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);

            return _driver;
        }
    }
}
