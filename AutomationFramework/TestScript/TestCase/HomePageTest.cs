using NUnit.Framework;
using TestScript.Pages;

namespace TestScript.TestCase
{
    public class HomePageTest : TestBase
    {
        [Test]
        public void Scenario1()
        {
            HomePage homePage = new HomePage(this.Driver);
            homePage.Open(this.Configurations.AppUrl);
        }
    }
}
