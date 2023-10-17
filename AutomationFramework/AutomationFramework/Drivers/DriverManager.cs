using OpenQA.Selenium;

namespace ProjectCore.Drivers
{
    public static class DriverManager
    {
        private static AsyncLocal<WebDriver> driver = new AsyncLocal<WebDriver>();

        public static void InitDriverProvider(DriverConfig driverConfig)
        {
            WebDriver? webDriver = null;

            if(driverConfig != null && "remote".Equals(driverConfig.DriverMode, StringComparison.OrdinalIgnoreCase))
            {
                switch (driverConfig.BrowserName)
                {
                    case "Chrome":
                        webDriver = new RemoteChromeDriver().CreateDriver(driverConfig);
                        break;
                    case "Edge":
                        webDriver = new RemoteEdgeDriver().CreateDriver(driverConfig);
                        break;
                }
            }

            switch (driverConfig?.BrowserName)
            {
                case "Chrome":
                    webDriver = new LocalChromeDriver().CreateDriver(driverConfig);
                    break;
                case "Edge":
                    webDriver =  new LocalEdgeDriver().CreateDriver(driverConfig);
                    break;
            }

            webDriver.Manage().Window.Maximize();
            driver.Value = webDriver;
        }

        public static WebDriver GetCurrentDriver()
        {
            return driver.Value;
        }

        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
            }
        }
    }

    public class DriverConfig
    {
        public string BrowserName { get; set; }
        public string DriverMode { get; set; }
        public string Version { get; set; }
        public string RemoteUrl { get; set; }
        public string BinaryLocation { get; set; }
    }
}
