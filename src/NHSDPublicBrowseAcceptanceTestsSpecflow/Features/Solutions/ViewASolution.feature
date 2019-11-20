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
	And Last Updated Date
	And list of Capabilities
	And Solution ID

Scenario: Attachment Download Link Displayed
	Given that a User views a Solution
	When the User is viewing the Solution Page
	Then there is a link for the User to download an attachment

Scenario: Foundation Solution Indicator
	Given that a User views a Foundation Solution
	When the User is viewing the Solution Page
	Then the page will contain an indication that the Solution meets the criteria for a Foundation Solution Set

Scenario: Capabilities displayed correctly
	Given that a User views a Solution
	When the User is viewing the Solution Page
	Then the capabilities listed match the expected capabilities in the database

Scenario: Download more information
	Given that a User views a Solution
	When the User is viewing the Solution Page
	Then the Download more information button downloads a 'PDF' file