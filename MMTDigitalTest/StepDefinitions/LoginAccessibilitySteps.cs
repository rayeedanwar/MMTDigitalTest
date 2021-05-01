using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SauceDemoInteractionLibrary;
using TechTalk.SpecFlow;
using Xunit;

namespace MMTDigitalTest.StepDefinitions
{
    [Binding]
    public class LoginAccessibilitySteps
    {
        private SauceDemoApp _sauceDemoApp;

        public LoginAccessibilitySteps(SauceDemoApp sauceDemoApp)
        {
            _sauceDemoApp = sauceDemoApp;
        }

        [Given(@"that I am currently focused on the (.*) button")]
        [Given(@"that I am currently focused on the (.*) field")]
        public void GivenThatIAmCurrentlyFocusedOnAField(string fieldName)
        {
            var js = (IJavaScriptExecutor)_sauceDemoApp.Driver;
            var jsScriptVariable = "arguments[0].focus();";

            switch (fieldName.ToLower())
            {
                case "username":
                    js.ExecuteScript(jsScriptVariable, _sauceDemoApp.LoginPage.UserNameInput); break;
                case "password":
                    js.ExecuteScript(jsScriptVariable, _sauceDemoApp.LoginPage.PasswordInput); break;
                case "login":
                    js.ExecuteScript(jsScriptVariable, _sauceDemoApp.LoginPage.LoginButton); break;
                default:
                    throw new InvalidOperationException($"{fieldName} fieldName not configured in test script");
            }
        }
        
        [When(@"I hit the (.*) key")]
        public void WhenIHitKey(string keyName)
        {
            var keyToSend = keyName.ToLower() switch
            {
                "tab" => Keys.Tab,
                "enter" => Keys.Enter,
                _ => throw new InvalidOperationException($"{keyName} keyName not configured in test script")
            };

            var actions = new Actions(_sauceDemoApp.Driver);
            actions.SendKeys(keyToSend).Perform();

        }

        [Then(@"it will take me to the (.*) button")]
        [Then(@"it will take me to the (.*) field")]
        public void ThenItWillTakeMeToThePasswordField(string fieldName)
        {
            var expectedLocation = fieldName.ToLower() switch
            {
                "username" => _sauceDemoApp.LoginPage.UserNameInput.Location,
                "password" => _sauceDemoApp.LoginPage.PasswordInput.Location,
                "login" => _sauceDemoApp.LoginPage.LoginButton.Location,
                _ => throw new InvalidOperationException($"{fieldName} fieldName not configured in test script")
            };

            var actualLocation = _sauceDemoApp.Driver.SwitchTo().ActiveElement().Location;

            Assert.Equal(expectedLocation, actualLocation);
        }
        
        [Then(@"it will try to log me in")]
        public void ThenItWillTryToLogMeIn()
        {
            Assert.NotNull(_sauceDemoApp.LoginPage.ErrorMessage);
        }
    }
}
