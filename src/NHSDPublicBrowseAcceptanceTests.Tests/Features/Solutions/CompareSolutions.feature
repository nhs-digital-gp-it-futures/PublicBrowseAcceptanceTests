Feature: Download a document to compare Solution's Capabilities
	As a Public User
	I want to compare Solutions by the Capabilities they claim
	So that I know which capabilities the Solutions meet


Scenario: Compare solutions - tile visible
	Given the user navigates to view catalogue solutions
	Then the compare all solutions tile is displayed

Scenario: Compare solutions - Compare all solutions
	Given the user wants to compare all solutions
	Then the compare document download button is enabled

Scenario: Compare solutions - Compare all solutions from capability selector
	Given no Capability is selected
	When the User chooses to continue
	Then the compare document download button is enabled

Scenario: Compare solutions - Compare filtered solutions from capability selector
	Given one or more Capability is selected
	When the User chooses to continue
	Then the compare document download button is enabled

Scenario: Compare solutions - Compare document is not available for foundation solutions
	Given the User wants to view Foundation Solutions only
	When the User chooses to view Foundation Solutions
	Then the compare document download button is not displayed
