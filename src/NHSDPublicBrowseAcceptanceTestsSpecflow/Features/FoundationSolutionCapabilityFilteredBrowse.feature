Feature: Foundation Solution (Single) Capability-filtered browse
	As a Public User
	I want to use Foundation Capabilities when browsing Solutions
	So that I know what  Solutions (Single) include those Capabilities

Scenario: All the Foundation Capabilities and no other Capabilities are selected
	Given all the Foundation Capabilities are selected
	And no other Capabilities are selected
	When Solutions are presented
	Then only Solutions that deliver all the Foundation Capabilities are included