using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace ProjectCore.Reports.ExtentReport
{
    public class ExtentReportManager
    {
        private static readonly Lazy<ExtentReports> LazyReports = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return LazyReports.Value; } }

        static ExtentReportManager()
        {
            string projectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string reportPath = Path.Combine(projectPath, "TestResults");

            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }

            var htmlReporter = new ExtentHtmlReporter($"{reportPath}\\index.html");
            htmlReporter.LoadConfig(projectPath + @"\ExtentReportConfig.xml");
            Instance.AttachReporter();
        }
    }
}
