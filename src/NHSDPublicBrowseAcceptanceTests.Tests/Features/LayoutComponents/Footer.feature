﻿Feature: Footer
	As a Public User
	I want a Footer on every page of the application
	So that I have a familiar experience throughout the application

@SmokeTest
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
	| text                              | href                                                     |
	| NHS Digital                       | https://digital.nhs.uk/                                  |
	| NHS Digital Helpdesk              | /guide#contact-us                                        |
	| About GP IT Futures               | https://digital.nhs.uk/services/gp-it-futures-systems    |
	| Capabilities and Standards models | https://gpitbjss.atlassian.net/wiki/spaces/DCSH/overview |
	| Buyer's Guide                     | /guide                                                   |
