Feature: LoginAccessibility
	As a subscribed member I can use keyboard controls to navigate the login form so that the page meets accessibility guidelines

Scenario: Tab from username to password
	Given that I am currently focused on the username field,
	When I hit the tab key,
	Then it will take me to the password field

Scenario: Tab from password to submit button
	Given that I am currently focused on the password field,
	When I hit the tab key,
	Then it will take me to the submit button

Scenario: Enter key on submit button attempts to login
	Given that I have the submit button in focus,
	When I hit the enter key,
	Then it will try to log me in
	And the login behaviours will match those described in AC1
