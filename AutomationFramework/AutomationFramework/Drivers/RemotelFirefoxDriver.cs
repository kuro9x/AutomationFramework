﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace ProjectCore.Drivers
{
    public class RemotelFirefoxDriver : IDriver
    {
        public RemotelFirefoxDriver()
        {

        }

        public WebDriver CreateDriver(DriverConfig config)
        {
            var firefoxOption = new FirefoxOptions();
            var driver = new RemoteWebDriver(new Uri(config.RemoteUrl), firefoxOption.ToCapabilities(), TimeSpan.FromMinutes(1));

            return driver;
        }
    }
}
