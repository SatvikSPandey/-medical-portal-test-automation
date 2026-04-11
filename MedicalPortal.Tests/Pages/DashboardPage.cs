using OpenQA.Selenium;

namespace MedicalPortal.Tests.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly By _welcomeMessage = By.CssSelector("h2");
        private readonly By _logoutButton = By.CssSelector("a.button");
        private readonly By _flashMessage = By.Id("flash");

        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetWelcomeMessage()
        {
            return GetText(_welcomeMessage);
        }

        public void ClickLogout()
        {
            Click(_logoutButton);
        }

        public string GetFlashMessage()
        {
            return GetText(_flashMessage);
        }

        public bool IsWelcomeMessageDisplayed()
        {
            return IsElementVisible(_welcomeMessage);
        }
    }
}