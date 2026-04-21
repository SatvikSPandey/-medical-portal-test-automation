
**Author:** Satvik Pandey | [LinkedIn](https://www.linkedin.com/in/satvikpandey-433555365) | [GitHub](https://github.com/SatvikSPandey)

---

# Medical Portal Test Automation Framework

A professional BDD test automation framework built with C#, NUnit, and SpecFlow, demonstrating enterprise-grade testing practices aligned with healthcare software QA standards.

## Tech Stack

- **Language:** C# (.NET 8)
- **Test Framework:** NUnit 3
- **BDD Layer:** SpecFlow 3.9 (Gherkin syntax)
- **Browser Automation:** Selenium WebDriver 4
- **Reporting:** ExtentReports 4 (HTML)
- **Design Pattern:** Page Object Model (POM)

## Project Structure

MedicalPortal.Tests/
├── Features/          # Gherkin BDD feature files
├── Steps/             # Step definitions (Gherkin → C#)
├── Pages/             # Page Object Model classes
├── Hooks/             # SpecFlow lifecycle hooks
├── Drivers/           # WebDriver management
├── Utilities/         # ConfigReader, ExtentReportManager, ScreenshotHelper
└── appsettings.json   # External configuration

## Test Scenarios

### Login Feature (3 scenarios)
- Successful login with valid credentials
- Failed login with invalid credentials
- Failed login with empty credentials

### Dashboard Feature (2 scenarios)
- Authenticated user sees welcome message
- Logout returns user to login page

### Form Submission Feature (2 scenarios)
- User selects an option from the dropdown
- User checks a checkbox

## How to Run

1. Clone the repository
2. Open `MedicalPortal.Tests.sln` in Visual Studio 2022
3. Restore NuGet packages (automatic on build)
4. Open Test Explorer: **Test → Test Explorer**
5. Click **Run All**

## Test Report

After running, an HTML report is generated at:

bin/Debug/net8.0/Reports/index.html

**Live Report:** https://satvikspandey.github.io/-medical-portal-test-automation/

Open this file in any browser to view detailed test results with timestamps and pass/fail status.

## Configuration

All settings are in `appsettings.json`:

```json
{
  "Browser": "chrome",
  "BaseUrl": "https://the-internet.herokuapp.com",
  "TimeoutSeconds": 10
}
```