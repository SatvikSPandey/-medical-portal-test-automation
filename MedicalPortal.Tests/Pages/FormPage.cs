using OpenQA.Selenium;

namespace MedicalPortal.Tests.Pages
{
    public class FormPage : BasePage
    {
        private readonly By _dropdown = By.Id("dropdown");
        private readonly By _checkboxes = By.CssSelector("input[type='checkbox']");

        public FormPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToDropdown(string baseUrl)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/dropdown");
        }

        public void NavigateToCheckboxes(string baseUrl)
        {
            Driver.Navigate().GoToUrl($"{baseUrl}/checkboxes");
        }

        public void SelectDropdownOption(string optionText)
        {
            var select = new OpenQA.Selenium.Support.UI.SelectElement(WaitForElement(_dropdown));
            select.SelectByText(optionText);
        }

        public string GetSelectedDropdownOption()
        {
            var select = new OpenQA.Selenium.Support.UI.SelectElement(WaitForElement(_dropdown));
            return select.SelectedOption.Text;
        }

        public void CheckFirstCheckbox()
        {
            var checkboxes = Driver.FindElements(_checkboxes);
            if (!checkboxes[0].Selected)
            {
                checkboxes[0].Click();
            }
        }

        public bool IsFirstCheckboxChecked()
        {
            var checkboxes = Driver.FindElements(_checkboxes);
            return checkboxes[0].Selected;
        }
    }
}