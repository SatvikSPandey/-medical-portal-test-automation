using OpenQA.Selenium;

namespace MedicalPortal.Tests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameField = By.Id("username");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.CssSelector("button[type='submit']");
        private readonly By _errorMessage = By.Id("flash");
        private readonly By _successMessage = By.Id("flash");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo(string baseUrl)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/login");
        }

        public void EnterUsername(string username)
        {
            TypeText(_usernameField, username);
        }

        public void EnterPassword(string password)
        {
            TypeText(_passwordField, password);
        }

        public void ClickLoginButton()
        {
            Click(_loginButton);
        }

        public string GetFlashMessage()
        {
            return GetText(_successMessage);
        }

        public bool IsErrorDisplayed()
        {
            return IsElementVisible(_errorMessage);
        }

        public void LoginAs(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }
    }
}