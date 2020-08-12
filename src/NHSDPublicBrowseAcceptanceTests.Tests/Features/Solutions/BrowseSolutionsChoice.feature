@SmokeTest
Feature: Browse Solutions by Foundation Solutions or All Solutions
	As a Public User
	I want to browse all the Solutions according to their Foundation or Non-Foundation type
	So that I can view all the Solutions of both type

Scenario: Browse Foundation Solutions Only
	Given the User wants to view Foundation Solutions only
	When the User chooses to view Foundation Solutions
	Then only Foundation Solutions are presented in the results
	And all the Foundation Solutions are included in the results

Scenario: Browse All Solutions
	Given the User wants to view all Solutions
	When the User chooses to view all Solutions
	Then all the Foundation Solutions are included in the results
	And all Non-Foundation Solutions are included in the results