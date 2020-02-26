Feature: DownloadAttachments
	As a Public User
	I want to download attached documents
	So that I can view additional information about the Solution
	
Background: 
	Given that a new Solution has been created to view attachments

Scenario: Download Integrations Attachment - Download Attachment
	Given an NHS Assured Integrations attachment has been provided for the Solution
	And the User views the created solution
	And the Integrations section is presented
	When the User chooses to download the Integrations attachment
	Then the Integrations attachment is downloaded
	And the attachment contains the Supplier's NHS Assured Integrations

Scenario: Download Integrations Attachment - No File
	Given an NHS Assured Integrations attachment has not been provided for the Solution
	When the User views the created solution
	Then there is no call to action to download a file in the Integrations section

Scenario: Download Roadmap Attachment - Download Attachment
	Given a Roadmap attachment has been provided for the Solution
	And the User views the created solution
	And the Roadmap section is presented
	When the User chooses to download the Roadmap attachment
	Then the Roadmap attachment is downloaded
	And the attachment contains the Supplier's Roadmap

Scenario: Download Roadmap Attachment - No File
	Given a Roadmap attachment has not been provided for the Solution
	When the User views the created solution
	Then there is no call to action to download a file in the Roadmap section

Scenario: Download Authority Provided Data Document - Download Attachment
	Given an Authority Provided Solution Document attachment has been provided for the Solution
	And the User views the created solution
	And the Learn more section is presented
	When the User chooses to download the Authority Provided Data Document
	Then the Authority Provided Data Document is downloaded
	And the attachment contains the Supplier's Authority Provided Data Document

Scenario: Download Authority Provided Data Document - Section not shown
	Given an Authority Provided Solution Document attachment has not been provided for the Solution
	When the User views the created solution
	Then the Learn more section is not presented


