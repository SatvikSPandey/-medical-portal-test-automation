using OpenQA.Selenium;

namespace MedicalPortal.Tests.Utilities
{
    public static class ScreenshotHelper
    {
        private static readonly string ScreenshotDir = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Screenshots");

        public static void CaptureScreenshot(IWebDriver driver, string scenarioTitle)
        {
            try
            {
                Directory.CreateDirectory(ScreenshotDir);

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = $"{scenarioTitle.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var filePath = Path.Combine(ScreenshotDir, fileName);

                screenshot.SaveAsFile(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }
    }
}