using NUnit.Framework;
using OpenQA.Selenium;
using ProjectCore.Drivers;
using TestScript.Configs;
using TestScript.Models;
using TestScript.Pages;
using TestScript.TestCase;
using TestScript.UI.Pages;

namespace TestScript.UI
{
    public class ProfilePageTest : TestBase
    {

        [TestCase("FirstName", "LastName", "01")]
        public void Scenario2(string firstName, string lastName, string suffixUserName)
        {
            HomePage homePage = new HomePage();
            LoginPage loginPage = new LoginPage();
            ProfilePage profile = new ProfilePage();
            var baseUrl = Application.GetConfig()["Application:BaseUrl"];
            homePage.GoToUrl($"{baseUrl}login");

            Account account = new Account
            {
                Email = Application.GetConfig()["Application:Account:Email"],
                Password = Application.GetConfig()["Application:Account:Password"],
                FirstName = firstName,
                LastName = lastName
            };

            loginPage.Login(account);

            // Process GoTo Profile
            profile.ShowLoggedinMenu();
            profile.ViewProfile();
            profile.GoToEditProfile();
            // GetOldData
            var realData = profile.GetAccountInfo();
            var newUserName = $"{realData.UserName}_{suffixUserName}";
            account.UserName = newUserName;

            var isUpdated = profile.UpdateAccount(account);
            if (isUpdated)
            {
                // https://unsplash.com/@haihoangm
                homePage.GoToUrl($"{baseUrl}@{newUserName}");
                // Compare full name TODO
            }

            profile.GoToEditProfile();
            var newAccountProfile = profile.GetAccountInfo();
            
            Assert.AreEqual(account.FirstName, newAccountProfile.FirstName);
            Assert.AreEqual(account.LastName, newAccountProfile.LastName);
            Assert.AreEqual(account.UserName, newAccountProfile.UserName);
            // Compare Alert TODO

            // Revert data test
            profile.UpdateAccount(realData);
        }

    }
}
