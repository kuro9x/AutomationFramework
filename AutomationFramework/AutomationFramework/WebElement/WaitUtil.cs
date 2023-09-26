using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProjectCore.WebElementProvider
{
    public class WaitUtil
    {
        public static WebDriverWait GetWait(int timeOutInSecond = 1)
        {
            IWebDriver driver = WebDriverManager.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSecond));
            return wait;
        }

        public static void WaitForElementsVisible(By by)
        {
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

    }
}
