

using OpenQA.Selenium;
using ProjectCore.WebElementProvider;

namespace TestScript.Unsplash.Testing.Pages
{
    internal class HomePage
    {
        private static readonly By ListAllPhoto = By.XPath("//figure");

        protected static List<IWebElement> GetListAllPhoto() => BaseAction.FindElements(ListAllPhoto);

        public static void ClickAFirstPhoto()
        {
            GetListAllPhoto()[0].Click();
        }

    }
}
