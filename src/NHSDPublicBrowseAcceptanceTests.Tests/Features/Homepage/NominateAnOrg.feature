Feature: RegisterAProxyOrganisation
    As a Registered User, 
    I want to register a Proxy Organisation relationship,
    So that a Proxy Organisation can be set up to conduct Buying Catalogue activities on my behalf

Scenario: Register A Proxy Organisation - Nominate Added to Homepage
    Given that the user wants to begin the Proxy Buyer registration journey 
    When the user navigates to the Buying Catalogue Homepage 
    Then there is a control to nominate an organisation

Scenario: Register A Proxy Organisation - View Proxy Buyer Information Page
    Given that the user is on the Buying Catalogue Homepage
    When the user chooses to nominate an organisation
    Then the Proxy Buyer Information page is presented
    And there is a Link to nominate an organisation
    And there is a link for the Procurement Hub

Scenario: Register A Proxy Organisation - Go Back
    Given that the user is on the Buying Catalogue Homepage
    And the user chooses to nominate an organisation
    When the user chooses to go back
    Then the Buying Catalogue homepage is presented
