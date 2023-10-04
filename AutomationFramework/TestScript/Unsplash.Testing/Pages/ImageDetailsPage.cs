using OpenQA.Selenium;
using ProjectCore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScript.Unsplash.Testing.Pages
{
    internal class ImageDetailsPage
    {
        private static readonly By AddToCollectionButton = By.XPath("//div[@data-test='photos-route']//button[@type='button' and @title='Add to collection']");

        private static readonly By CollectionItems = By.XPath("//h3[text()='Add to Collection']/parent::div//span");

        private static readonly By NextButton = By.XPath("//a[@title='Next']");

        protected static IWebElement GetAddToCollectionButton() => BaseAction.FindElement(AddToCollectionButton);

        protected static List<IWebElement> GetCollectionItems() => BaseAction.FindElements(CollectionItems);

        protected static IWebElement GetNextButton() => BaseAction.FindElement(NextButton);

        public static void ClickTheAddCollectionButton()
        {
            GetAddToCollectionButton().Click();
        }

        public static void ClickTheCollectionItemByTitle(string collectionTitle)
        {
            foreach (IWebElement item in GetCollectionItems())
            {
                if (item.Text == collectionTitle)
                {
                    item.Click();
                }
            }
        }

        public static void ClickTheNextButton()
        {
            GetNextButton().Click();
        }

    }
}
