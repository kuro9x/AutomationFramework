using OpenQA.Selenium;
using ProjectCore.WebElement;
using UnsplashTest.Pages;

namespace UnsplashTest.UI.Pages
{
    public class LoginPage : HomePage
    {
        private Element userNameTextBox = new Element(By.Id("user_email"));
        private Element userPasswordTextBox = new Element(By.Id("user_password"));

        public bool ProcessLogin(string accountKey)
        {
            try
            {
                var account = DataStorage.DataStorage.GetAccountInfo(accountKey);
                if (account == null)
                {
                    return false;
                }

                userNameTextBox.SendKeys(account.Email);
                userPasswordTextBox.SendKeys(account.Password);

                GetInputElementByText("Login").Click(); // change Edit => dynamic language
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
