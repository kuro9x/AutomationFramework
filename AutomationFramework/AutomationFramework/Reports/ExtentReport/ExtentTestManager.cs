using AventStack.ExtentReports;
using System.Runtime.CompilerServices;

namespace ProjectCore.Reports.ExtentReport
{
    public static class ExtentTestManager
    {
        public static AsyncLocal<ExtentTest> _parentTest = new AsyncLocal<ExtentTest>();

        public static AsyncLocal<ExtentTest> childTest = new AsyncLocal<ExtentTest>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            _parentTest.Value = ExtentReportManager.Instance.CreateTest(testName, description);
            return _parentTest.Value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        {
            childTest.Value = _parentTest.Value.CreateNode(testName, description);
            return childTest.Value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return childTest.Value;
        }
    }
}
