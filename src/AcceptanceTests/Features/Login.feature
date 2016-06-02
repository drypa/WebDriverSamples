Feature: Login
	Проверяем авторизацию

@mytag
Scenario: Login on existing Account
	Given Application is opened
	When I enter by user name "qwe@qwe.qwe" and password "Password1+"
	Then I see "Hello qwe@qwe.qwe!"