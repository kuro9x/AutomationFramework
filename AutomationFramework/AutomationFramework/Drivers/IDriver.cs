using OpenQA.Selenium;

namespace ProjectCore.Drivers
{
    public interface IDriver
    {
        IWebDriver CreateDriver(DriverConfig driverConfig);

        void KillDriver(IWebDriver driver);
    }
}
