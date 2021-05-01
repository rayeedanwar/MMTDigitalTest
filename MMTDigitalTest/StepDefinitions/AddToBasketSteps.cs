using System;
using System.Linq;
using SauceDemoInteractionLibrary;
using SauceDemoInteractionLibrary.Components;
using TechTalk.SpecFlow;
using Xunit;

namespace MMTDigitalTest.StepDefinitions
{
    [Binding]
    public class AddToBasketSteps : Steps
    {
        public static string BasketCountKey = "BasketCount";
        public static string SelectedProductKey = "SelectedProduct";
        private SauceDemoApp _sauceDemoApp;

        public AddToBasketSteps(SauceDemoApp sauceDemoApp)
        {
            _sauceDemoApp = sauceDemoApp;
        }

        [Given(@"I want to remove (.*) product")]
        [Given(@"I want to select (.*) product")]
        public void GivenIWantToSelectAnyProduct(string productName)
        {
            InventoryItem selectedProduct;

            if (_sauceDemoApp.Driver.Url.EndsWith("inventory.html"))
            {
                selectedProduct = productName == "any" ?
                   _sauceDemoApp.InventoryPage.InventoryItems.First()
                   : _sauceDemoApp.InventoryPage.InventoryItems
                       .Single(item => item.Name.Text == productName);
            } else // else handles basket page, can also use switch for better extensibility with other pages
            {
                selectedProduct = productName == "any" ?
                   _sauceDemoApp.BasketPage.CartItems.First()
                   : _sauceDemoApp.BasketPage.CartItems
                       .Single(item => item.Name.Text == productName);
            }
           
            ScenarioContext.Add(SelectedProductKey, selectedProduct);
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheADDTOCARTButton(string buttonName)
        {
            var selectedProductName = ScenarioContext.Get<InventoryItem>(SelectedProductKey).Name.Text;

            switch (buttonName)
            {
                case "ADD TO CART": _sauceDemoApp.AddInventoryItemToCart(selectedProductName); break;
                case "REMOVE": _sauceDemoApp.RemoveInventoryItemFromCart(selectedProductName); break;
                default:
                    throw new InvalidOperationException($"{buttonName} button not configured in test script");
            }
        }

        [Given(@"the button for the product shows ""(.*)""")]
        [Then(@"the button for the product shows ""(.*)""")]
        public void ThenTheButtonForTheProductShows(string expectedButtonText)
        {
            var selectedProductActualButtonText = ScenarioContext.Get<InventoryItem>(SelectedProductKey).Button.Text;
            Assert.True(expectedButtonText == selectedProductActualButtonText);
        }

        [Given(@"I click “Add to cart” on the (.*) product")]
        [When(@"I click “Add to cart” on the (.*) product")]
        public void WhenIClickAddToCartOnAProduct(string productName)
        {
            // normally would prefer to avoid having data written in gherkins 
            // as it becomes difficult to maintiain if it's a large / changing dataset
            _sauceDemoApp.AddInventoryItemToCart(productName);
        }

        [Given(@"it creates a counter on the basket icon with the value ""(.*)"" in it")]
        [Then(@"it creates a counter on the basket icon with the value ""(.*)"" in it")]
        public void ThenItCreatesACounterOnTheBasketIconWithTheValueInIt(int expectedCount)
        {
            var actualCount = _sauceDemoApp.InventoryPage.ShoppingCartIcon.Count;
            Assert.True(expectedCount == actualCount);
        }
    }
}
