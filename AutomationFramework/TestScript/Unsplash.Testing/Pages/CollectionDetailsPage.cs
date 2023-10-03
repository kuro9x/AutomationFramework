using OpenQA.Selenium;
using ProjectCore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScript.Unsplash.Testing.Pages
{
    internal class CollectionDetailsPage
    {
        private static readonly By listAllPhoto = By.XPath("//figure");

        public List<IWebElement> GetListAllPhoto()
        {
            return BaseAction.FindElements(listAllPhoto);
        }

    }
}
