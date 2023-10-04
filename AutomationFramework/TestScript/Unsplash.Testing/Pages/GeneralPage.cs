using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScript.Unsplash.Testing.Pages
{
    internal class GeneralPage
    {

        private readonly IWebDriver _driver;

        public GeneralPage()
        {
        }
        public GeneralPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToLoginPage()
        {
            this._driver.Navigate().GoToUrl(Constant.Constant.UnsplashConstants.LOGIN_URL);
        }
        public void GoToColectionDetailsPage(string collectionId)
        {
            this._driver.Navigate().GoToUrl(Constant.Constant.UnsplashConstants.COLLECTION_URL + collectionId);
        }

    }
}
