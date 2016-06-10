Feature: LoginWithPageObject
	Login Page tests

@mytag
Scenario: Login on existing Account
	Given I am on start page
	When I go to login page
	Then I should be on login page
	
	When I enter login "qwe@qwe.qwe"
	And I enter password "Password1+"
	And I press login button
	Then I should be on home page