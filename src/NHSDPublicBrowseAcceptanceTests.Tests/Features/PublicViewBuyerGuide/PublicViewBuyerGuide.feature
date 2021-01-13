@SmokeTest
Feature: PublicViewBuyerGuide
	As a Public User
	I want to view the Buyer Guide
	So that it can help me do my work

	
Scenario: Public View Buyer Guide
	Given the User chooses to view the Buying Catalogue Homepage
	When the choose to access the Buyer Guide dedicated content page	
	Then they are presented with guidance content about the Buying Catalogue
	And they are presented with guidance content about the Service Desk
