Feature: Login
  As a medical portal user
  I want to log into the portal
  So that I can access the secure dashboard

  Scenario: Successful login with valid credentials
    Given the user is on the login page
    When the user enters username "tomsmith" and password "SuperSecretPassword!"
    Then the user should see the secure area welcome message

  Scenario: Failed login with invalid credentials
    Given the user is on the login page
    When the user enters username "wronguser" and password "wrongpassword"
    Then the user should see an error message

  Scenario: Failed login with empty credentials
    Given the user is on the login page
    When the user enters username "" and password ""
    Then the user should see an error message