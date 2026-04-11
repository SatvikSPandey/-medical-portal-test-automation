using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MedicalPortal.Tests.Drivers
{
    public class BrowserDriver
    {
        private IWebDriver? _driver;

        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddArgument("--disable-notifications");
                    _driver = new ChromeDriver(options);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
                return _driver;
            }
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}