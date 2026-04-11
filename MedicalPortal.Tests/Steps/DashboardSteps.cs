using MedicalPortal.Tests.Drivers;
using MedicalPortal.Tests.Pages;
using MedicalPortal.Tests.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MedicalPortal.Tests.Steps
{
    [Binding]
    public class DashboardSteps
    {
        private readonly BrowserDriver _browserDriver;
        private readonly LoginPage _loginPage;
        private readonly DashboardPage _dashboardPage;

        public DashboardSteps(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
            _loginPage = new LoginPage(_browserDriver.Driver);
            _dashboardPage = new DashboardPage(_browserDriver.Driver);
        }

        [Given(@"the user has logged in with valid credentials")]
        public void GivenTheUserHasLoggedInWithValidCredentials()
        {
            _loginPage.NavigateTo(ConfigReader.BaseUrl);
            _loginPage.LoginAs("tomsmith", "SuperSecretPassword!");
        }

        [When(@"the user clicks the logout button")]
        public void WhenTheUserClicksTheLogoutButton()
        {
            _dashboardPage.ClickLogout();
        }

        [Then(@"the user should be redirected to the login page")]
        public void ThenTheUserShouldBeRedirectedToTheLoginPage()
        {
            Assert.That(_browserDriver.Driver.Url, Does.Contain("/login"));
        }
    }
}