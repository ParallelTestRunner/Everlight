@ComputerDatabase
Feature: ComputerDatabase
	Testing of ComputerDatabase website

Scenario Outline: 1001- User can add a new computer
Given I open the home page of computer-database website
And I make sure that there is no computer with name <AutomationComputerName>
When I go to Add-a-computer page and create a new computer with <AutomationComputerName>, <IntroducedDate1>, <DiscontinuedDate1> and <Company1>
Then Newly created computer with <AutomationComputerName>, <IntroducedDate2>, <DiscontinuedDate2> and <Company2> could be found on home page of computer-database website
Examples: 
 | AutomationComputerName   | IntroducedDate1 | IntroducedDate2 | DiscontinuedDate1 | DiscontinuedDate2 | Company1             | Company2             |
 | Automation Computer Name | 1990-05-12      | 12 May 1990     | 2000-12-05        | 05 Dec 2000       | IMS Associates, Inc. | IMS Associates, Inc. |
 | Automation Computer Name |                 | -               | 1995-02-15        | 15 Feb 1995       |                      | -                    |
 | Automation Computer Name | 2003-10-10      | 10 Oct 2003     |                   | -                 | Evans & Sutherland   | Evans & Sutherland   |
 | Automation Computer Name |                 | -               |                   | -                 |                      | -                    |


Scenario Outline: 1002- User can edit a computer
Given I open the home page of computer-database website
And I make sure that there is no computer with name <AutomationComputerName>
When I go to a random page of computer-table
And I go to edit-or-delete-computer page of a random computer and edit it with <AutomationComputerName>, <IntroducedDate1>, <DiscontinuedDate1> and <Company1>
Then Edited computer with <AutomationComputerName>, <IntroducedDate2>, <DiscontinuedDate2> and <Company2> could be found on home page of computer-database website
Examples: 
 | AutomationComputerName   | IntroducedDate1 | IntroducedDate2 | DiscontinuedDate1 | DiscontinuedDate2 | Company1           | Company2           |
 | Automation Computer Name | 2003-10-10      | 10 Oct 2003     | 1995-02-15        | 15 Feb 1995       | Evans & Sutherland | Evans & Sutherland |


Scenario Outline: 1003- User can search and delete a computer
Given I open the home page of computer-database website
And I make sure that there is no computer with name <AutomationComputerName>
When I go to Add-a-computer page and create a new computer with <AutomationComputerName>, <IntroducedDate1>, <DiscontinuedDate1> and <Company1>
Then Newly created computer with <AutomationComputerName>, <IntroducedDate2>, <DiscontinuedDate2> and <Company2> could be found on home page of computer-database website
When I delete a computer with <AutomationComputerName>, <IntroducedDate2>, <DiscontinuedDate2> and <Company2>
Then Deleted computer with <AutomationComputerName>, <IntroducedDate2>, <DiscontinuedDate2> and <Company2> could be not found on home page of computer-database website
Examples: 
 | AutomationComputerName   | IntroducedDate1 | IntroducedDate2 | DiscontinuedDate1 | DiscontinuedDate2 | Company1             | Company2             |
 | Automation Computer Name | 1990-05-12      | 12 May 1990     | 2000-12-05        | 05 Dec 2000       | IMS Associates, Inc. | IMS Associates, Inc. |
