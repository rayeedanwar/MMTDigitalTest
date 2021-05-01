using System;
using System.Linq;
using OpenQA.Selenium;
using SauceDemoInteractionLibrary.Pages;
using SauceDemoInteractionLibrary.Utils;

namespace SauceDemoInteractionLibrary
{
    public class SauceDemoApp : BasePage
    {
        public Login LoginPage;
        public Inventory InventoryPage;
        public Basket BasketPage;

        public SauceDemoApp(IWebDriver driver) : base(driver)
        {
            LoginPage = new Login(driver);
            InventoryPage = new Inventory(driver);
            BasketPage = new Basket(driver);
        }

        public void NavigateTo(PageName pageNames)
        {
            var url = pageNames switch
            {
                PageName.Login => "https://www.saucedemo.com/",
                PageName.Inventory => "https://www.saucedemo.com/inventory.html",
                PageName.Basket => "https://www.saucedemo.com/cart.html",
                _ => throw new InvalidOperationException("PageName not recognised in test suite")

            };
                
            Driver.Navigate().GoToUrl(url);
        }

        public void Login(string userName, string password)
        {
            if (Driver.Url != "https://www.saucedemo.com/")
            {
                NavigateTo(PageName.Login);
            }

            LoginPage.UserNameInput.SendKeys(userName);
            LoginPage.PasswordInput.SendKeys(password);
            LoginPage.LoginButton.Click();
        }

        public void AddInventoryItemToCart(string itemName)
        {
            var matchingItem = itemName == "any" ?
                InventoryPage.InventoryItems.First()
                : InventoryPage.InventoryItems
                    .Where(item => item.Name.Text == itemName)
                    .Single();

            // exception below is more for the sake of completion and having the method do only one thing: add item to cart
            // normally wouldn't validate like this in the application interaction library unless required in specific usecases
            // which means I would avoid putting in another method for removing item from cart
            // and that assertions like this happen in the test suite only

            var expectedButtonText = "ADD TO CART";
            if (matchingItem.Button.Text != expectedButtonText)
                throw new InvalidElementStateException($"{itemName} button does not say \"{expectedButtonText}\"");

            matchingItem.AddToCart();
        }

        public void RemoveInventoryItemFromCart(string itemName)
        {
            var matchingItem = InventoryPage.InventoryItems.Single(item => item.Name.Text == itemName);

            var expectedButtonText = "REMOVE";
            if (matchingItem.Button.Text != expectedButtonText)
                throw new InvalidElementStateException($"{itemName} button does not say \"{expectedButtonText}\"");

            matchingItem.AddToCart();
        }
    }
}
