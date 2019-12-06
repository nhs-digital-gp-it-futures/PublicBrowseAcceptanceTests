Feature: View Solution only when Published
	As a Public User
	I want to view Solutions which are set to Published
	So that I only view Solutions which are Published

	# Published status 3 = Displayed on public browse

Scenario Outline: Solution Status Determines Published
	Given that a Solution has a PublishedStatus of <Code>	
	When the User chooses to view all Solutions	
	Then the Solution's Marketing Page availability is <Published>	

	Examples: 
	| Code | Published |
	| 1    | false     |
	| 2    | false     |
	| 3    | true      |
	| 4    | false     |
	| 100  | false     |
	| 20   | false     |
