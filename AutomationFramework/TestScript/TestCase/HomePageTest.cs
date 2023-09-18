using NUnit.Framework;
using TestScript.Pages;

namespace TestScript.TestCase
{
    public class HomePageTest
    {
        [Test]
        public void Scenario1()
        {
            HomePage homePage = new HomePage();
            homePage.OpenBrowserByUrl(Constant.APP_URL_HOME_PAGE);
        }
    }
}
