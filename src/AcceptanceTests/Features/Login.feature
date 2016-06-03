@ApplicationIsOpened
Feature: Login
	Проверяем авторизацию


Scenario: Login on existing Account
	When I enter by user name "qwe@qwe.qwe" and password "Password1+"
	Then I see "Hello qwe@qwe.qwe!"

Scenario: Login with wrong login and password
	When I enter by user name "wrong@login.com" and password "Wrong_Password"
	Then I see "Invalid login attempt"