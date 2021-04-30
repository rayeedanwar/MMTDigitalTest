using SauceDemoInteractionLibrary;
using SauceDemoInteractionLibrary.Utils;
using TechTalk.SpecFlow;

namespace MMTDigitalTest.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private SauceDemoApp _sauceDemoApp;

        public CommonSteps(SauceDemoApp sauceDemoApp)
        {
            _sauceDemoApp = sauceDemoApp;
        }

        [Given(@"that I am on the login page")]
        public void GivenThatIAmOnTheInventoryShopPageWithAnEmptyBasket(PageName pageName)
        {
            _sauceDemoApp.NavigateTo(pageName);
        }

    }
}
