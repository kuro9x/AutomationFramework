using OpenQA.Selenium;

namespace ProjectCore.Drivers
{
    public static class WebDriverManager
    {
        private static AsyncLocal<WebDriver> Driver = new AsyncLocal<WebDriver>();

        public static IWebDriver? GetDriverProvider(DriverConfig driverConfig)
        {
            IWebDriver? webDriver = null;

            if(driverConfig != null && driverConfig.DriverMode.Equals("remote", StringComparison.OrdinalIgnoreCase))
            {
                switch (driverConfig.BrowserName)
                {
                    case "Chrome":
                        return new RemoteChromeDriver().CreateDriver(driverConfig);
                    case "Firefox":
                        return new RemotelFirefoxDriver().CreateDriver(driverConfig);
                }
            }

            switch (driverConfig.BrowserName)
            {
                case "Chrome":
                    return new LocalChromeDriver().CreateDriver(driverConfig);
                case "Firefox":
                    return new LocalFirefoxDriver().CreateDriver(driverConfig);
            }

            return webDriver;
        }

        public static WebDriver GetCurrentDriver()
        {
            return Driver.Value;
        }
    }

    public class DriverConfig
    {
        public string BrowserName { get; set; }
        public string DriverMode { get; set; }
        public string Version { get; set; }
        public string RemoteUrl { get; set; }
    }
}
