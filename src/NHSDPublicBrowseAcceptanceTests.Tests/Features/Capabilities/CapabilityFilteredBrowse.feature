@SmokeTest
Feature: Capability Filtered Browse
	As a Public User
	I want to use Capabilities when browsing Solutions
	So that I know which Solutions provide features in those Capabilities

Scenario: No Capability selected
	Given no Capability is selected
	When the User chooses to continue
	Then no Solutions are excluded on the basis of the Capabilities they deliver

Scenario: One or more Capability is selected
	Given one or more Capability is selected
	When the User chooses to continue
	Then Solution results are presented	

Scenario: Capabilities to select
	Given there is a set of Capabilities defined in the Capabilities and Standards model
	When the Capabilities are presented for selection
	Then all of the Capabilities defined in the Capabilities and Standards model are displayed
