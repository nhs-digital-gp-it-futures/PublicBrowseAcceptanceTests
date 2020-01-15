Feature: ViewSolutionsList
	As a Public User
	I want to view a list of Solutions
	So that I know what those Solutions are

Scenario: List of Solution Cards
	Given that a User has chosen to view a list of all Solutions
	When Solutions are presented
	Then there is a Card for each Solution
	And the Card contains the Supplier Name
	And the Solution Name
	And the Solution Summary Description
	And the names of the Capabilities provided by the Solution
	And capability 'Productivity' is listed in the solution capabilities
