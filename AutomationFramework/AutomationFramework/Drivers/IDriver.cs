using OpenQA.Selenium;

namespace ProjectCore.Drivers
{
    public interface IDriver
    {
        WebDriver CreateDriver(DriverConfig driverConfig);
    }
}
