Feature: No-selection criteria browse
	As a Public User
	I want to browse the Solutions
	So that I know what those Solutions are

Scenario: No selection criteria applied
	Given no selection criteria are applied
	When Solutions are presented
	Then no Solutions are excluded

Scenario: Card Content
	Given that Solutions are presented
	When no selection criteria are applied 
	Then the Card will contain the correct contents