using OpenQA.Selenium;
using ProjectCore.WebElement;
using UnsplashTest.Models;
using UnsplashTest.Pages;

namespace UnsplashTest.UI.Pages
{
    public class LoginPage : HomePage
    {
        private Element userNameTextBox = new Element(By.Id("user_email"));
        private Element userPasswordTextBox = new Element(By.Id("user_password"));
        private Element loginButton = new Element(By.XPath("//input[@value='Login']"));

        public void Login(AccountModel account)
        {
            userNameTextBox.SendKeys(account.Email);
            userPasswordTextBox.SendKeys(account.Password);

            loginButton.Click();
        }
    }
}
