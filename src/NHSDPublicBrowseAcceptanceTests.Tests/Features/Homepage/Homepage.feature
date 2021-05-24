@SmokeTest
Feature: Homepage
	As a Public User
	I want to view the Buying Catalogue Homepage
	So that I can use the Buying Catalogue

Scenario: Homepage - View Homepage
	Given the User chooses to view the Buying Catalogue Homepage
	When the Homepage is presented
	Then it contains a Header
	And content about the Buying Catalogue
	And it contains a Footer
	And a control to access Browse Solutions
	And a control to access Guidance Content for Buyers

Scenario: Homepage - Information to clearly identify privacy and cookie policy on first visit
    Given that the User is visiting the Buying Catalogue for the first time
    When the Homepage is presented
    Then they are informed that there is a Privacy policy and cookies they can visit (e.g. via a banner)
    And this can be dismissed by the User

Scenario: Homepage - Select dismiss
    Given that the User is visiting the Buying Catalogue for the first time
    And the Homepage is presented
    When the User chooses to dismiss
    Then the Privacy policy and cookies banner disappears

Scenario: Homepage - Subsequent visit
    Given a User has previously visited the Buying Catalogue
    And the Privacy policy and cookies banner has been previously dismissed
    When a page is presented
    Then the Privacy policy and cookies banner disappears 

Scenario: Homepage - Privacy policy and cookies link on banner
    Given the Privacy policy and cookies banner is displayed
    When the User chooses to select the Privacy policy and cookies link from the banner
    Then the Privacy policy and cookies page is presented 
