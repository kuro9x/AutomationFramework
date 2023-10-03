using OpenQA.Selenium;
using ProjectCore.WebElement;
using TestScript.Models;
using TestScript.Pages;

namespace TestScript.UI.Pages
{
    public class ProfilePage : HomePage
    {
        private Element showLoggedinMenu = new Element(By.Id("popover-avatar-loggedin-menu"));
        private Element viewProfileButton = new Element(By.XPath($"//a[text()='View profile']"));

        private Element user_first_name = new Element(By.Id("user_first_name"));
        private Element user_last_name = new Element(By.Id("user_last_name"));
        private Element user_username = new Element(By.Id("user_username"));
        private Element updateAccountElement = new Element(By.XPath("//input[@value='Update account']"));
        private Element editProfileButton = new Element(By.XPath("//a[text()='Edit profile']"), 60);
        private By fullName = By.XPath("////div[text()={0}']");

        public Account GetAccountInfo()
        {
            try
            {
                var firstName = user_first_name.GetAttribute("value");
                var lastName = user_last_name.GetAttribute("value");
                var userName = user_username.GetAttribute("value");

                return new Account
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userName
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                user_first_name.ClearData();
                user_last_name.ClearData();
                user_username.ClearData();

                user_first_name.SendKeys(account.FirstName);
                user_last_name.SendKeys(account.LastName);
                user_username.SendKeys(account.UserName);

                updateAccountElement.Click();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void GoToEditProfile()
        {
            Thread.Sleep(3000); // TODO
            editProfileButton.Click();
        }

        public void ShowLoggedinMenu()
        {
            showLoggedinMenu.Click();
        }

        public void ViewProfile()
        {
            viewProfileButton.Click();
        }
    }
}
