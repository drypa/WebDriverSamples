@Remote
Feature: LoginWithPageObject
	Login Page tests

Scenario: Login on existing Account
	Given I am on start page
	When I go to login page
	Then I should be on login page
	
	When I enter login "qwe@qwe.qwe"
	And I enter password "Password1+"
	And I press login button
	Then I should be on home page


Scenario: Login with wrong login and password
	Given I am on login page
	When I enter login "wrong@login.com"
	And I enter password "Wrong_Password"
	And I press login button
	Then I should be on login page
	And I see login error "Invalid login attempt"