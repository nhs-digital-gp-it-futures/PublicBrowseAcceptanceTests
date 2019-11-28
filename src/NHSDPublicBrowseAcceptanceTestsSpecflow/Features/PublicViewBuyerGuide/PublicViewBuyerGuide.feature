Feature: PublicViewBuyerGuide
	As a Public User
	I want to view the Buyer Guide
	So that it can help me do my work

	@ignore
	Scenario: Homepage Navigation
		Given the User chooses to view the Buying Catalogue Homepage
		When the choose to access the Buyer Guide dedicated content page
		Then they can do so via a control on the Homepage
	@ignore
	Scenario: Footer Navigation
		Given the User chooses to view the Buying Catalogue Homepage
		When the choose to access the Buyer Guide dedicated content page
		Then they can do so via a control in the Footer
	@ignore
	Scenario: Public View Buyer Guide
		Given the User chooses to view the Buying Catalogue Homepage
		When the choose to access the Buyer Guide dedicated content page
		Then they can do so via a control on the Homepage
		And they are presented with a control to access the Buyer Guide as a digital document download (e.g. a PDF)
		And they are presented with guidance content about the Buying Catalogue
		And they are presented with guidance content about the Service Desk