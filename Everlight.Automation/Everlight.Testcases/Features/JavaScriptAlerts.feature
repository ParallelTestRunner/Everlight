@JavaScriptAlerts
Feature: JavaScriptAlerts
	Testing of JavaScriptAlerts URL

Scenario: 2001- Automation should be able to handle JS Alert
Given I open the JavaScript-Alerts webpage
When I click the button by text Click for JS Alert
And I click on the ok button of alert
Then I get the result You successfuly clicked an alert


Scenario: 2002- Automation should be able to handle Ok button of JS Confirm
Given I open the JavaScript-Alerts webpage
When I click the button by text Click for JS Confirm
And I click on the ok button of JS Confirm
Then I get the result You clicked: Ok


Scenario: 2003- Automation should be able to handle Cancel button of JS Confirm
Given I open the JavaScript-Alerts webpage
When I click the button by text Click for JS Confirm
And I click on the cancel button of JS Confirm
Then I get the result You clicked: Cancel

Scenario: 2004- Automation should be able to handle Ok button of JS Prompt
Given I open the JavaScript-Alerts webpage
When I click the button by text Click for JS Prompt
And I type Prompt message sent by automation in the text box of JS Prompt
And I click on the ok button of JS Prompt
Then I get the result You entered: Prompt message sent by automation


Scenario: 2005- Automation should be able to handle Cancel button of JS Prompt
Given I open the JavaScript-Alerts webpage
When I click the button by text Click for JS Prompt
And I type Prompt message sent by automation in the text box of JS Prompt
And I click on the cancel button of JS Prompt
Then I get the result You entered: null
