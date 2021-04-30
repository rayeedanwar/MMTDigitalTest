Feature: LoginSuccess
	As a subscribed member I can log in using my credentials so that my account is securely accessible

	Background: 
	Given that I am on the login page

Scenario Outline: Login failures
	When I click “Log in” with <username> and <password>
	Then an error will be thrown below the form stating <error>

	Examples:
    | username | password | error                                                                     |
    |          |          | Epic sadface: Username is required                                        |
    |          | test     | Epic sadface: Username is required                                        |
    | test     |          | Epic sadface: Password is required                                        |
    | fakeuser | fakeuser | Epic sadface: Username and password do not match any user in this service |

Scenario: Login successful with correct username and password
	When I click “Log in” with standard_user and secret_sauce
	Then it will successfully redirect me to /inventory.html