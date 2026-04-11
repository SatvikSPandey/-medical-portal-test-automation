using MedicalPortal.Tests.Drivers;
using MedicalPortal.Tests.Pages;
using MedicalPortal.Tests.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MedicalPortal.Tests.Steps
{
    [Binding]
    public class FormSubmissionSteps
    {
        private readonly BrowserDriver _browserDriver;
        private readonly FormPage _formPage;

        public FormSubmissionSteps(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
            _formPage = new FormPage(_browserDriver.Driver);
        }

        [Given(@"the user is on the dropdown page")]
        public void GivenTheUserIsOnTheDropdownPage()
        {
            _formPage.NavigateToDropdown(ConfigReader.BaseUrl);
        }

        [When(@"the user selects ""(.*)"" from the dropdown")]
        public void WhenTheUserSelectsFromTheDropdown(string option)
        {
            _formPage.SelectDropdownOption(option);
        }

        [Then(@"the selected option should be ""(.*)""")]
        public void ThenTheSelectedOptionShouldBe(string expectedOption)
        {
            string actualOption = _formPage.GetSelectedDropdownOption();
            Assert.That(actualOption, Is.EqualTo(expectedOption));
        }

        [Given(@"the user is on the checkboxes page")]
        public void GivenTheUserIsOnTheCheckboxesPage()
        {
            _formPage.NavigateToCheckboxes(ConfigReader.BaseUrl);
        }

        [When(@"the user checks the first checkbox")]
        public void WhenTheUserChecksTheFirstCheckbox()
        {
            _formPage.CheckFirstCheckbox();
        }

        [Then(@"the first checkbox should be checked")]
        public void ThenTheFirstCheckboxShouldBeChecked()
        {
            Assert.That(_formPage.IsFirstCheckboxChecked(), Is.True);
        }
    }
}