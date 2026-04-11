using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MedicalPortal.Tests.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebElement WaitForElement(By locator)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return wait.Until(d => d.FindElement(locator));
        }

        protected void Click(By locator)
        {
            WaitForElement(locator).Click();
        }

        protected void TypeText(By locator, string text)
        {
            var element = WaitForElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return WaitForElement(locator).Text;
        }

        protected bool IsElementVisible(By locator)
        {
            try
            {
                return WaitForElement(locator).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}