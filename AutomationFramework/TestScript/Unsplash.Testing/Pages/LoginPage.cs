using OpenQA.Selenium;
using ProjectCore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScript.Unsplash.Testing.Pages
{
    internal class LoginPage
    {
        private static readonly By EmailTextBox = By.Id("user_email");
        private static readonly By PasswordTextBox = By.Id("user_password");
        private static readonly By LoginButton = By.XPath("//input[@type='submit' and @value='Login']");

        protected static IWebElement GetEmailTextBox() => BaseAction.FindElement(EmailTextBox);
        protected static IWebElement GetPasswordTextBox() => BaseAction.FindElement(PasswordTextBox);
        protected static IWebElement GetLoginButton() => BaseAction.FindElement(LoginButton);

        public static void InputEmailTextBox(string email)
        {
            GetEmailTextBox().SendKeys(email);
        }
        public static void InputPasswordTextBox(string password)
        {
            GetPasswordTextBox().SendKeys(password);
        }

        public static void ClickTheLoginButton()
        {
            GetLoginButton().Click();
        }
    }
}
