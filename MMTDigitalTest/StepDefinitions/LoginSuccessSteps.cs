using System;
using SauceDemoInteractionLibrary;
using TechTalk.SpecFlow;
using Xunit;

namespace MMTDigitalTest.StepDefinitions
{
    [Binding]
    public class LoginSuccessSteps
    {
        private SauceDemoApp _sauceDemoApp;

        public LoginSuccessSteps(SauceDemoApp sauceDemoApp)
        {
            _sauceDemoApp = sauceDemoApp;
        }

        [When(@"I click “Log in” with (.*) and (.*)")]
        public void WhenIClickLogInWithOr(string userName, string password)
        {
            _sauceDemoApp.Login(userName, password);
        }
        
        
        [Then(@"an error will be thrown below the form stating (.*)")]
        public void ThenAnErrorWillBeThrownBelowTheFormStatingEpicSadfaceUsernameIsRequired(string expectedErrorMessage)
        {
            var actualErrorMessage = _sauceDemoApp.LoginPage.ErrorMessage.Text;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }
        
        [Then(@"it will successfully redirect me to (.*)")]
        public void ThenItWillSuccessfullyRedirectMeToInventory_Html(string urlEnding)
        {
            Assert.True(_sauceDemoApp.Driver.Url.EndsWith(urlEnding));
        }
    }
}
