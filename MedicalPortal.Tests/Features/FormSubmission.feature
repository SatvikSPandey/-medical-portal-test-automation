Feature: FormSubmission
  As a medical portal user
  I want to interact with forms and dropdowns
  So that I can submit data accurately

  Scenario: User selects an option from the dropdown
    Given the user is on the dropdown page
    When the user selects "Option 1" from the dropdown
    Then the selected option should be "Option 1"

  Scenario: User checks a checkbox
    Given the user is on the checkboxes page
    When the user checks the first checkbox
    Then the first checkbox should be checked