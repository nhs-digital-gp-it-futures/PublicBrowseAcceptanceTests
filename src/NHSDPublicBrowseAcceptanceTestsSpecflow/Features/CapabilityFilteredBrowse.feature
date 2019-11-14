Feature: Capability-filtered browse
	As a Public User
	I want to use Capabilities when browsing Solutions
	So that I know what Solutions include those Capabilities

@ignore
Scenario: No Capability selected
	Given no Capability is selected
	When Solutions are presented
	Then no Solutions are excluded on the basis of the Capabilities they deliver

@ignore
Scenario: One or more Capability selected
	Given one or more Capability is selected
	When Solutions are presented
	Then only Solutions that deliver all of the selected Capabilities are included
	And Additional Services are not included in the results

@ignore
Scenario: A Capability is de-selected
	Given a Capability is de-selected
	And there is one or more Capability selected
	When Solutions are presented
	Then only Solutions that deliver all of the selected Capabilities are included
	And Additional Services are not included in the results

@ignore
Scenario: Filter is removed when clicking the NHS logo
	Given one or more Capability is selected
	And Solutions are presented
	When the nhs logo is clicked
	Then no Solutions are excluded on the basis of the Capabilities they deliver
	