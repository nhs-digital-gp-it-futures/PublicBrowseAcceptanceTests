Feature: ViewASolution
	As a Public User
	I want to view the Solution information
	So that I can understand what the Solution is

@SmokeTest
Scenario: Solution Details
	Given that a User views a Solution 
	When the User is viewing the Solution Page
	Then the page will contain Supplier Name
	And Solution Name
	And Solution Summary
	And Solution Full Description
	And About Solution URL
	And Contact Details
	And list of Capabilities
	And Solution ID
	And Features

@SmokeTest
Scenario: Foundation Solution Indicator
	Given that a User views a Foundation Solution
	When the User is viewing the Solution Page
	Then the page will contain an indication that the Solution meets the criteria for a Foundation Solution Set

@SmokeTest
Scenario: Capabilities displayed correctly
	Given that a User views a Solution	
	When the User is viewing the Solution Page
	Then the capabilities listed match the expected capabilities in the database
