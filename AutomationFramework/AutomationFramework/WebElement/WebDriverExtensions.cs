using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectCore.Drivers;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;

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

        public static void WaitForPageReady(this IWebDriver driver, float timeOut = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(w => ((IJavaScriptExecutor)w).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public static void Click(this IWebDriver driver, string url)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Navigate().GoToUrl(url);
            driver.WaitForPageReady();
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
                throw;
            }
        }
    }
}
