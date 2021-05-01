using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SauceDemoInteractionLibrary;
using SauceDemoInteractionLibrary.Components;
using TechTalk.SpecFlow;
using Xunit;

namespace MMTDigitalTest.StepDefinitions
{
    [Binding]
    public class RemoveItemFromBasketSteps : Steps
    {
        private SauceDemoApp _sauceDemoApp;
        // better to have any keys for Scenario context in a separate place as easier to reference in different StepDefinition files
        private string _selectedProductNamesKey = "SelectedProductNames";

        public RemoveItemFromBasketSteps(SauceDemoApp sauceDemoApp)
        {
            _sauceDemoApp = sauceDemoApp;
        }
     
        [Given(@"I select (.*) products?")]
        public void GivenISelectProducts(int numberOfProducts)
        {
            var selectedProductNames = new List<string>();
            var availableProductCount = _sauceDemoApp.InventoryPage.InventoryItems.Count();

            if (numberOfProducts > availableProductCount)
                throw new InvalidOperationException($"Test suite wants to select {numberOfProducts} but page only shows {availableProductCount}");

            for (int i = 1; i <= numberOfProducts; i++)
            {
                var productName = _sauceDemoApp.InventoryPage.InventoryItems
                                    .Single(item => item.BaseItemIndex == i)
                                    .Name.Text;
                _sauceDemoApp.AddInventoryItemToCart(productName);
                selectedProductNames.Add(productName);
            }

            ScenarioContext.Add(_selectedProductNamesKey, selectedProductNames);
            ScenarioContext.Add(AddToBasketSteps.BasketCountKey, numberOfProducts);
        }
        
        [Then(@"I can see options to remove each product present from the basket")]
        public void ThenICanSeeOptionsToRemoveEachProductPresentFromTheBasket()
        {
            var allCartItems = _sauceDemoApp.BasketPage.CartItems;
            foreach (var item in allCartItems)
            {
                Assert.True(item.Button.Text == "REMOVE");
            }
        }
        
        [Then(@"it will remove the item from the basket")]
        public void ThenItWillRemoveTheItemFromTheBasket()
        {
            var removedItem = ScenarioContext.Get<InventoryItem>(AddToBasketSteps.SelectedProductKey);

            Assert.Throws<InvalidOperationException>(
                () => _sauceDemoApp.BasketPage.CartItems.Single(item => item == removedItem)
                );
        }
        
        [Then(@"it will reduce the basket counter icon by (.*)")]
        public void ThenItWillReduceTheBasketCounterIconBy(int reducedBy)
        {
            var basketCount = _sauceDemoApp.InventoryPage.ShoppingCartIcon.Count;
            var numberOfItemsAtStart = ScenarioContext.Get<int>(AddToBasketSteps.BasketCountKey);
            Assert.True((numberOfItemsAtStart - basketCount) == reducedBy);
        }
        
        [Then(@"it will remove the basket counter icon")]
        public void ThenItWillRemoveTheBasketCounterIcon()
        {
            Assert.Throws<NoSuchElementException>(
                () => _sauceDemoApp.BasketPage.ShoppingCartIcon.Count
                );
        }
    }
}
