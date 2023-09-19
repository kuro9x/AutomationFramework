﻿using OpenQA.Selenium;
using ProjectCore.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScript.Pages
{
    public class GeneralPage
    {
        public IWebDriver _driver => TestConfigs.InitDriver(ProjectCore.Drivers.DriverType.Chrome);

        public void OpenBrowserByUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}