Feature: ViewASolution
	As a Public User
	I want to view the Solution information
	So that I can understand what the Solution is

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

Scenario: Foundation Solution Indicator
	Given that a User views a Foundation Solution
	When the User is viewing the Solution Page
	Then the page will contain an indication that the Solution meets the criteria for a Foundation Solution Set

Scenario: Capabilities displayed correctly
	Given that a User views a Solution	
	When the User is viewing the Solution Page
	Then the capabilities listed match the expected capabilities in the database

Scenario Outline: Last updated date is updated when solution table is updated
	Given that a User views a created Solution
	And the User is viewing the Solution Page
	When the LastUpdated value in the <table_name> table is updated
	Then the page last updated date shown is updated as expected
	Examples: 
	| table_name		|
	| Solution			|
	| SolutionDetail	|
	| MarketingContact	|
