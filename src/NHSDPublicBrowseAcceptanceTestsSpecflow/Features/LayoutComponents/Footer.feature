Feature: Footer
	As a Public User
	I want a Footer on every page of the application
	So that I have a familiar experience throughout the application

Scenario: Footer Presented
	Given the User chooses any Page in the application
	When they are on a Page
	Then the Footer is presented

Scenario Outline: Link in Footer
	Given the User chooses to select a URL in the Footer
	When they select <text>
	Then they are directed according to the URL <href>

	# Add href when available
	Examples: 
	| text								| href  |
	|  Buyer's Guide					|   /   |
	|  Catalogue Submissions			|   /   |
	|  NHS Digital						|   /   |
	|  NHS Digital service desk			|   /   |
	|  About GPIT Futures				|   /   |
	|  Capabilities and Standards Model	|   /   |