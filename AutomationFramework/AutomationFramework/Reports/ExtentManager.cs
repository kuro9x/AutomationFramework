using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Reflection;

namespace ProjectCore.Reports
{
    public class ExtentManager
    {
        private static ExtentReports extentReports = new ExtentReports();

        public static ExtentReports getExtentReports()
        {
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports";

            var sparkReporter = new ExtentSparkReporter($"{reportPath}\\Spark.html");

            extentReports.AttachReporter(sparkReporter);
            extentReports.AddSystemInfo("Author", "Team3");

            return extentReports;
        }
    }
}
