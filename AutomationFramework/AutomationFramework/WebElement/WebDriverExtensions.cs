using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Drivers;

namespace ProjectCore.WebElement
{
    public static class WebDriverExtensions
    {
        public static void Quit(this IWebDriver driver) => driver.Quit();

        public static void GoToUrl(this IWebDriver driver, string url)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Navigate().GoToUrl(url);
            driver.WaitForPageReady();
        }

        public static void Click(this IWebDriver driver, By locator, float timeOut = 40)
        {
            Actions action = new Actions(driver);
            IWebElement element = driver.WaitUntilClickable(locator, timeOut);
            action.MoveToElement(element).Click().Build().Perform();
        }

        public static void WaitForPageReady(this IWebDriver driver, float timeOut = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(w => ((IJavaScriptExecutor)w).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public static IWebElement WaitUntilClickable(this IWebDriver driver, By locator, float timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public static IWebElement WaitUntilVisible(this IWebDriver driver, By locator, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public static bool IsElementVisible(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.FindElementSafe(locator);
            return element != null && element.Displayed && element.Enabled;
        }

        public static IWebElement FindElementSafe(this IWebDriver driver, By locator)
        {
            try
            {
                return DriverManager.GetCurrentDriver().FindElement(locator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static IList<IWebElement> FindElementsSafe(this IWebDriver driver, By locator)
        {
            try
            {
                return DriverManager.GetCurrentDriver().FindElements(locator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static void Refresh(this IWebDriver driver)
        {
            DriverManager.GetCurrentDriver().Navigate().Refresh();
        }
    }
}
