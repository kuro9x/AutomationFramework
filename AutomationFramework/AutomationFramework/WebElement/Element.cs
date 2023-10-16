using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Drivers;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectCore.WebElement
{
    public class Element
    {
        protected By locator;
        protected float timeout = 30;

        public Element(By locator)
        {
            this.locator = locator;
        }

        public Element(By locator, float timeOutSecond)
        {
            this.locator = locator;
            timeout = timeOutSecond;
        }

        public Element SetTimeOut(float timeOutSecond)
        {
            this.timeout = timeOutSecond;
            return this;
        }

        public By GetLocator() { return this.locator; }

        public void Click()
        {
            DriverManager.GetCurrentDriver().Click(locator, timeout);
        }

        public void SendKeys(string text)
        {
            DriverManager.GetCurrentDriver().FindElementSafe(locator).SendKeys(text);
        }

        public string GetAttribute(string attributeName)
        {
            return DriverManager.GetCurrentDriver().FindElementSafe(locator).GetAttribute(attributeName);
        }

        public void ClearData()
        {
            DriverManager.GetCurrentDriver().FindElementSafe(locator).Clear();
        }

        public IList<IWebElement> FindElementsSafe()
        {
            return DriverManager.GetCurrentDriver().FindElementsSafe(locator);
        }

        public bool IsElementVisible()
        {
            return DriverManager.GetCurrentDriver().IsElementVisible(locator);
        }
    }
}
