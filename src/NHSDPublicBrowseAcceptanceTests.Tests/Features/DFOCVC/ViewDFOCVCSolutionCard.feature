Feature: ViewDFOCVCSolutionCard
	As a Public User
	I want to view the Solution information
	So that I can understand what the Solution is

Background: 
	Given that the user chooses to view DFOCVC solutions

@SmokeTest
Scenario: Solution Details
	Given that a User views a Random Solution 
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
	And Framework is 'DFOCVC'

@SmokeTest
Scenario: Capabilities displayed correctly
	Given that a User views a Random Solution
	When the User is viewing the Solution Page
	Then the capabilities listed match the expected capabilities in the database