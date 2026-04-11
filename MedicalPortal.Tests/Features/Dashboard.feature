Feature: Dashboard
  As an authenticated medical portal user
  I want to access the secure dashboard
  So that I can view protected content and log out safely

  Scenario: Authenticated user sees welcome message
    Given the user has logged in with valid credentials
    Then the user should see the secure area welcome message

  Scenario: Logout returns user to login page
    Given the user has logged in with valid credentials
    When the user clicks the logout button
    Then the user should be redirected to the login page