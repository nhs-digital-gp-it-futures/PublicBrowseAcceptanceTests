Feature: Footer
	As a Public User
	I want a Footer on every page of the application
	So that I have a familiar experience throughout the application


Scenario: Footer Presented
	Given the User chooses any Page in the application
	When they are on a Page
	Then the Footer is presented

Scenario: Link in Footer
	Given the User chooses to select a URL in the Footer
	When they select a URL
	Then they are directed according to the URL