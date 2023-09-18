using OpenQA.Selenium;

namespace ProjectCore.Drivers
{
    public interface IDriver
    {
        IWebDriver CreateDriver();

        void KillDriver(IWebDriver driver);
    }
}
