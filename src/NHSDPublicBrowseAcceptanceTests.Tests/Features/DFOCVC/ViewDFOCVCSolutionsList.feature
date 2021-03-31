Feature: ViewDFOCVCSolutionsList
	As a Public User
	I want to view a list of Solutions
	So that I know what those Solutions are

@SmokeTest
Scenario: List of DFOCVC Solution Cards
	Given that the user chooses to view DFOCVC solutions
	When Solutions are presented
	Then there is a Card for each DFOCVC Solution
	And the Card contains the Supplier Name
	And the Solution Name
	And the Solution Summary Description
	And the names of the Capabilities provided by the Solution

# Back link broken on DFOCVC solutions list page
@ignore 
Scenario: Listof DFOCVC Solution Cards - Go Back
	Given that the user chooses to view DFOCVC solutions
	When they choose to Go Back
	Then the Homepage is presented