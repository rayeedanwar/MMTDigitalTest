Feature: LoginSuccess
	As a subscribed member I can log in using my credentials so that my account is securely accessible

Scenario: Login fails with no username and password
	Given that I am on the login page,
	When I click “Log in” with no username or password,
	Then an error will be thrown below the form stating “Epic sadface: Username is required”

Scenario: Login fails with a username and no password
	Given that I have entered a username but no password,
	When I click “Log in”,
	Then an error will be thrown below the form stating “Epic sadface: Password is required”

Scenario: Login fails with incorrect credentials
	Given that I have entered an incorrect username and password,
	When I click “Log in”,
	Then an error will be thrown below the form stating “Epic sadface: Username and password do not	match any user in this service”

Scenario: Login successful with correct username and password
	Given that I have entered a valid username and password,
	When I attempt to login,
	Then it will successfully redirect me to /inventory.html