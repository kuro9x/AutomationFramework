using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectCore.Drivers;

namespace ProjectCore.WebElementProvider
{
    public static class BaseAction
    {
        public static void HoverOnElement(By by)
        {
            IWebDriver driver = WebDriverManager.GetCurrentDriver();
            IWebElement element = driver.FindElement(by);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Build().Perform();
        }

        public static void MoveTo(IWebElement element)
        {
            IWebDriver driver = WebDriverManager.GetCurrentDriver();
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Build().Perform();
        }

        public static IWebElement? FindElement(By by)
        {
            try
            {
                IWebDriver driver = WebDriverManager.GetCurrentDriver();
                IWebElement ele = driver.FindElement(by);
                return ele;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static List<IWebElement>? FindElements(By by)
        {
            try
            {
                WaitUtil.WaitForElementsVisible(by);
                IReadOnlyCollection<IWebElement> collection = WebDriverManager.GetCurrentDriver().FindElements(by);
                List<IWebElement> eles = new List<IWebElement>(collection);
                return eles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
