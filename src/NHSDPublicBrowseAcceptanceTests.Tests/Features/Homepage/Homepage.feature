@SmokeTest
Feature: Homepage
	As a Public User
	I want to view the Buying Catalogue Homepage
	So that I can use the Buying Catalogue

Scenario: View Homepage
	Given the User chooses to view the Buying Catalogue Homepage
	When the Homepage is presented
	Then it contains a Header
	And content about the Buying Catalogue
	And it contains a Footer
	And a control to access Browse Solutions
	And a control to access Guidance Content for Buyers
