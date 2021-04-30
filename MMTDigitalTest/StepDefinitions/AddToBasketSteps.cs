using System.Threading;
using SauceDemoInteractionLibrary;
using TechTalk.SpecFlow;

namespace MMTDigitalTest.StepDefinitions
{
    [Binding]
    public class AddToBasketSteps
    {
        private SauceDemoApp _sauceDemoApp;

        public AddToBasketSteps(SauceDemoApp sauceDemoApp)
        {
            _sauceDemoApp = sauceDemoApp;
        }
        [Given(@"that I am on the inventory shop page with an empty basket,")]
        public void GivenThatIAmOnTheInventoryShopPageWithAnEmptyBasket()
        {
            _sauceDemoApp.Login("standard_user", "secret_sauce");
            _sauceDemoApp.AddInventoryItemToCart("Sauce Labs Backpack");
            _sauceDemoApp.AddInventoryItemToCart("Sauce Labs Bike Light");
            var count = _sauceDemoApp.InventoryPage.ShoppingCartIcon.Count;
        }
        
        [Given(@"that I am on the inventory shop page with an item in my basket,")]
        public void GivenThatIAmOnTheInventoryShopPageWithAnItemInMyBasket()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click “Add to cart” on a product,")]
        public void WhenIClickAddToCartOnAProduct()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it will change the “Add to cart” button to a “Remove” button")]
        public void ThenItWillChangeTheAddToCartButtonToARemoveButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it creates a counter on the basket icon with the value “(.*)” in it")]
        public void ThenItCreatesACounterOnTheBasketIconWithTheValueInIt(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it will increment the basket counter by (.*)")]
        public void ThenItWillIncrementTheBasketCounterBy(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
