using NUnit.Framework;

namespace TestScript.TestCase
{
    public class HomePageTest : TestBase
    {
        [TestCase("1")]
        [TestCase("2")]
        public void Scenario1(string dataInput)
        {
            extent.CreateTest("ParentWithChild")
                .CreateNode("Child0")
                .Pass("This test is created as a toggle as part of a child test of 'ParentWithChild'");

            extent.Flush();
        }
    }
}
