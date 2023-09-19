﻿using OpenQA.Selenium;

namespace ProjectCore.Drivers
{
    public class DriverFactory
    {
        public IWebDriver? GetDriverProvider(DriverType driverType)
        {
            IWebDriver? webDriver = null;

            switch (driverType)
            {
                case DriverType.Chrome:
                    webDriver = new ChromeDriverProvider().CreateDriver();
                    break;
                case DriverType.Firefox:
                    webDriver = new FirefoxDriverProvider().CreateDriver();
                    break;
                default:
                    break;
            }

            return webDriver;
        }
    }

    public enum DriverType
    {
        Chrome,
        Firefox,
        IE
    }
}