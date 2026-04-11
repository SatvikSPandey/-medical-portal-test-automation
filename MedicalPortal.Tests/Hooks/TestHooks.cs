using AventStack.ExtentReports;
using BoDi;
using MedicalPortal.Tests.Drivers;
using MedicalPortal.Tests.Utilities;
using TechTalk.SpecFlow;

namespace MedicalPortal.Tests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;
        private static ExtentReports _extent = null!;
        private ExtentTest _test = null!;

        public TestHooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extent = ExtentReportManager.GetInstance();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var browserDriver = new BrowserDriver();
            _container.RegisterInstanceAs(browserDriver);
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var browserDriver = _container.Resolve<BrowserDriver>();

            if (_scenarioContext.TestError != null)
            {
                ScreenshotHelper.CaptureScreenshot(
                    browserDriver.Driver,
                    _scenarioContext.ScenarioInfo.Title);
                _test.Fail(_scenarioContext.TestError.Message);
            }
            else
            {
                _test.Pass("Scenario passed");
            }

            browserDriver.Dispose();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.FlushReports();
        }
    }
}