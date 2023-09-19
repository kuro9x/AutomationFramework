using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.WebElementProvider
{
    public class WebDriverManager
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public static void CloseDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
                driver.Value = null;
            }
        }
    }
}
