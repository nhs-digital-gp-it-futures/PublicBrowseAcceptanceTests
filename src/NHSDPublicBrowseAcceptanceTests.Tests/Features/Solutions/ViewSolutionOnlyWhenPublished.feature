Feature: View Solution only when Published
	As a Public User
	I want to view Solutions which are set to Published
	So that I only view Solutions which are Published

Scenario Outline: Solution Status Determines Published
	Given that a Solution has a PublishedStatus of <Code>	
	And that a User has chosen to view a list of all Solutions	
	Then the Solution's Marketing Page availability is <Published>	

	Examples: 
	| Code | Published |
	| 1    | false     |
	| 2    | false     |
	| 3    | true      |
	| 4    | false     |
