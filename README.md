# MMT Automation Technical Test 
Rayeed Anwar
___

## Prerequisites
- Latest version of Chrome, Firefox and Edge installed on local machine
- .Net Core 3.1

## Framework / Test Suite
Browser is selected from the appSettings.json file. This takes the following parameters:
- Chrome
- Firefox
- IE11

Safari is not compatible with windows, so I was not able to run the suite with this driver.
IE11 errored after test started, and would need more time to investigate
I tried my best to avoid rewording the scenarios too much to fit the test suite, but still provide the same coverage.

The test can be run from Visual Studio, or command line using the following command in the same directory as the test project.
```sh
dotnet test
```

The overall structure of the test suite is such that the test suite interacts with the application interaction library in order to interact with the application, following the POM. 

Lighthouse results are in the Lighhouse folder. 
- Desktop: The application passes all requirements for desktop, apart from Performance Score for the Inventory Page
- Mobile: Time to interactive was above 3 seconds for all pages tested. Performance was below 90 for all pages tested. SEO requirements were met

## Improvements
- Adding a data structure will allow better reuse than ScenarioContext, and will give the ability to use the interaction library outside of the test suite in different use cases (ie, tooling for generating test data)
- BrowserStack / Selenium Grid to orchestrate tests in different browsers
___
## Feedback
Would greatly appreciate any feedback! 