Feature: Login Local
	As a Registered User
	I want to login to the Buying Catalogue without using an external authentication tool
	So that I can do Buying Catalogue Activities 

@ignore #can be included when running locally, but not on devops for now
Scenario: Login
	Given that a User is not logged in
	When a User provides recognised authentication details to login locally
	Then the User will be logged in

@ignore #can be included when running locally, but not on devops for now
Scenario Outline: Login with incorrect credentials
	Given that a User is not logged in
	When a User provides a <Username> username
	And a User provides a <Password> password
	Then the User will not be logged in
	And the User will be informed the login attempt was unsuccessful Email <Username>, password <Password>

	Examples:
	| Username | Password |
	| true     | false    |
	| false    | true     |
	| false    | false    |

@ignore
Scenario: Login Expiry
	Given the User logged in
	And the duration of the session is equal to or greater than the maximum session duration
	When they attempt to access the application
	Then they are redirected to login again