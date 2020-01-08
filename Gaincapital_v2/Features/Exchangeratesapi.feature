Feature: Exchangeratesapi
 This test was created for Gaincapital recruitment process

Scenario: I don't have response status codes error
	Given I have an endpoint https://api.exchangeratesapi.io
	When I try get data
	Then I don't have error status <code>

	Examples:
		| code |
		| 401  |
		| 402  |
		| 403  |
		| 404  |
		| 405  |
		| 406  |
		| 407  |
		| 408  |
		| 409  |
		| 410  |
		| 500  |
		| 501  |
		| 502  |
		| 503  |
		| 504  |
		| 505  |

Scenario: I have 200 response status code
	Given I have an endpoint https://api.exchangeratesapi.io
	When I try get data
	Then I have 200 status code

Scenario: I don't have empty response
	Given I have an endpoint https://api.exchangeratesapi.io
	When I try get data
	Then I don't have empty response

Scenario: Value from currency is bigger than zero
	Given I have an endpoint https://api.exchangeratesapi.io
	When I try get data
	Then Value from <currency> is bigger than zero

	Examples:
		| currency |
		| CAD      |
		| HKD      |
		| ISK      |
		| PHP      |
		| DKK      |
		| HUF      |
		| CZK      |
		| AUD      |
		| RON      |
		| SEK      |
		| IDR      |
		| INR      |
		| BRL      |
		| RUB      |
		| HRK      |
		| JPY      |
		| THB      |
		| CHF      |
		| SGD      |
		| PLN      |
		| BGN      |
		| TRY      |
		| CNY      |
		| NOK      |
		| NZD      |
		| ZAR      |
		| USD      |
		| MXN      |
		| ILS      |
		| GBP      |
		| KRW      |
		| MYR      |

Scenario:  My base currency is an euro
	Given I have an endpoint https://api.exchangeratesapi.io
	When I try get data
	Then My base currency is an EUR