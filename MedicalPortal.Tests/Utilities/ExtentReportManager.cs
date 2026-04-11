using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace MedicalPortal.Tests.Utilities
{
    public class ExtentReportManager
    {
        private static ExtentReports? _extent;

        private static readonly string ReportPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Reports", "TestReport.html");

        public static ExtentReports GetInstance()
        {
            if (_extent == null)
            {
                var reportDir = Path.GetDirectoryName(ReportPath)!;
                Directory.CreateDirectory(reportDir);

                var htmlReporter = new ExtentHtmlReporter(ReportPath);
                htmlReporter.Config.DocumentTitle = "Medical Portal Test Report";
                htmlReporter.Config.ReportName = "BDD Automation Test Results";
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
                _extent.AddSystemInfo("Application", "Medical Portal");
                _extent.AddSystemInfo("Browser", "Chrome");
                _extent.AddSystemInfo("Environment", "Test");
            }
            return _extent;
        }

        public static void FlushReports()
        {
            _extent?.Flush();
        }
    }
}