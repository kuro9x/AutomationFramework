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
                    case "Firefox":
                        webDriver = new RemotelFirefoxDriver().CreateDriver(driverConfig);
                        break;
                }
            }

            switch (driverConfig?.BrowserName)
            {
                case "Chrome":
                    webDriver = new LocalChromeDriver().CreateDriver(driverConfig);
                    break;
                case "Firefox":
                    webDriver =  new LocalFirefoxDriver().CreateDriver(driverConfig);
                    break;
            }

            webDriver.Manage().Window.Maximize();
            driver.Value = webDriver;
        }

        public static WebDriver GetCurrentDriver()
        {
            return driver.Value;
        }

        public static void KillDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
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
