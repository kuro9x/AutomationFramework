using OpenQA.Selenium;
using ProjectCore.WebElement;
using TestScript.Models;
using TestScript.Pages;

namespace TestScript.UI.Pages
{
    public class LoginPage : HomePage
    {
        private Element userNameTextBox = new Element(By.Id("user_email"));
        private Element userPasswordTextBox = new Element(By.Id("user_password"));
        private Element loginButton = new Element(By.XPath("//input[@value='Login']"));


        public void Login(Account account)
        {
            userNameTextBox.SendKeys(account.Email);
            userPasswordTextBox.SendKeys(account.Password);

            loginButton.Click();
        }
    }
}
