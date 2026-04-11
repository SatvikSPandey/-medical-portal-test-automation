using MedicalPortal.Tests.Drivers;
using MedicalPortal.Tests.Pages;
using MedicalPortal.Tests.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MedicalPortal.Tests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly BrowserDriver _browserDriver;
        private readonly LoginPage _loginPage;
        private readonly DashboardPage _dashboardPage;

        public LoginSteps(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
            _loginPage = new LoginPage(_browserDriver.Driver);
            _dashboardPage = new DashboardPage(_browserDriver.Driver);
        }

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            _loginPage.NavigateTo(ConfigReader.BaseUrl);
        }

        [When(@"the user enters username ""(.*)"" and password ""(.*)""")]
        public void WhenTheUserEntersUsernameAndPassword(string username, string password)
        {
            _loginPage.LoginAs(username, password);
        }

        [Then(@"the user should see the secure area welcome message")]
        public void ThenTheUserShouldSeeTheSecureAreaWelcomeMessage()
        {
            string message = _dashboardPage.GetWelcomeMessage();
            Assert.That(message, Does.Contain("Secure Area"));
        }

        [Then(@"the user should see an error message")]
        public void ThenTheUserShouldSeeAnErrorMessage()
        {
            Assert.That(_loginPage.IsErrorDisplayed(), Is.True);
        }
    }
}