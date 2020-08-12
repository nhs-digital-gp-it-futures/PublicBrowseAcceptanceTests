@SmokeTest
Feature: Header
	As a Public User 
	I want a standard Header
	So that I have a familiar experience throughout the application

Scenario: Header Presented
	Given the User chooses any Page in the application
	When they are on a Page
	Then the Header is presented
	And a Terms of use banner is displayed

Scenario: Header Logo
	Given the User chooses to select the logo in the Header
	When they click the NHS Digital logo
	Then they are directed to the domain URL
