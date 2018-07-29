# Everlight
Everlight assignment

I took around 10 hours to complete this assignment.

Here is the brief description of the automation project:

I have used Visual Studio 2017, C#, Selenium, SpecFlow, NUnit and .Net environment to develop this framework. I have taken care of all the best practices and industry standards. While compiling/building it the first time, the project will download some NuGet packages and so may take little more time to get compiled.

Please note that one has to install SpecFlow and NUnit Adapter into the visual studio to run test cases.
---------------------------------------------------------------------



How the framework is designed: The framework has 4 projects as below:
Everlight.POM: This framework follows Page-Object-Model and this is the place where all the required web pages have been modelled.

Everlight.Testcases: This is the project where I have written test-cases in BDD form using SpecFlow. One can also provide project configurations in App.config file of this project.

Everlight.Configurations: This module contains all the configurations viz. the website URL, implicit and explicit waits, browser-type etc.
 - ImplicitWaitTimeOutInMilliseconds is the time that selenium wait before considering an element as not found.
 - DefaultExplilicitWaitTimeOutInMilliseconds please ignore this as I didn't find any need to use it.
 - HighlightElementsWhenTheyAreAccessed makes every single element gets highlighted while being accessed by selenium. It makes the automation to run slowly a bit but helps us in knowing what is happning at the browser.
 - HighlightDurationInMilliseconds specify the duration for which we want an element to be highlighted. With this configuration we can increase or decrease the execution time of automation.
---------------------------------------------------------------------



If you find any issues to compile this framework or to run test cases, please let me know that.
