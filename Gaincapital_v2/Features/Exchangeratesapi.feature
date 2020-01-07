Feature: Exchangeratesapi
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Check
Scenario: RestSharp Example
	Given I have an example endpoint https://api.exchangeratesapi.io
	When I search for all customers
	Then the result contains customer Laura
