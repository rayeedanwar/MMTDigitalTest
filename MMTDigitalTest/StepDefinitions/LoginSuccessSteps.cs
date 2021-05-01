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

        [Given(@"I click “Log in” with (.*) and (.*)")]
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
            Assert.EndsWith(urlEnding, _sauceDemoApp.Driver.Url);
        }
    }
}
