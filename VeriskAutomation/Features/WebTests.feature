Feature: WebTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: verify log in 
Given I Navigate to login page
When I log in with <UserType>
Then The User should be logged in successfully
Examples: 
| UserType  |
| Admin |
| Reviewer  |
| Author    |

Scenario Outline: verify search operation
Given I Navigate to login page
When I log in with <UserType>
Then search page should diaplay successfully
Examples: 
| UserType  |
| Admin |


@mytag
Scenario Outline: Search Login Operation
Given I Navigate to login page
When I log in with <UserType>
Then I verified the result
Examples: 
| UserType  |
| Admin |
| Reviewer  |
| Author    |

@my search
Scenario Outline: verifying select operation
Given I Navigate to login page
When I log in with "<UserType>" user
And I perform "Self" forms Search 
And I click View Info icon
Then View Info is displayed
Examples: 
| UserType  |
| Admin |

Scenario: verifying select check box operation
Given I Navigate to login page
When I log in with ISO_Admin user
And I perform "Self" forms Search
And I select form by form Number 
| FormNumber     |
| IL 12 08 11 12 |
| IL 09 85 01 08 |
Then Action menu is enabled

Scenario: verifying select check box operation1
Given I Navigate to login page
When I log in with Admin user
And I perform "Self" forms Search
And I select form by form Number and verify Action menu options
| FormNumber     |
| IL 12 08 11 12 |
| IL 09 85 01 08 |
Scenario: verifying select check box operation2
Given I Navigate to login page
When I log in with Admin user
And I Select "Propritery" forms Search
When selcting "AG" in "Line of Business"

