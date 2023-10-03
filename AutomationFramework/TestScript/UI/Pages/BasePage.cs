using OpenQA.Selenium;
using ProjectCore.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScript.UI.Pages
{
    public class BasePage
    {
        public IWebDriver WebDriver
        {
            get
            {
                return DriverManager.GetCurrentDriver();
            }
        }

        public void GoToUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
    }
}
