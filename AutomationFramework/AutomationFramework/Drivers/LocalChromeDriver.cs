using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using WebDriverManager.DriverConfigs.Impl;

namespace ProjectCore.Drivers
{
    public class LocalChromeDriver : IDriver
    {
        public LocalChromeDriver()
        {

        }

        public WebDriver CreateDriver(DriverConfig config)
        {
            string downloadedPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "downloaded");
            string driverExecutableFileName = new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig()); // dynamic version
            string driverPath = Directory.GetParent(driverExecutableFileName).FullName;

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddUserProfilePreference("download.default_directory", downloadedPath);
            var service = ChromeDriverService.CreateDefaultService(driverPath);

            var driver = new ChromeDriver(service, chromeOptions);

            return driver;
        }
    }
}
