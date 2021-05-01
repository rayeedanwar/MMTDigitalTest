using System.Collections.Generic;
using OpenQA.Selenium;
using SauceDemoInteractionLibrary.Components;

namespace SauceDemoInteractionLibrary.Pages
{
    public class Basket : BasePage
    {
        public IEnumerable<InventoryItem> CartItems
        {
            get
            {
                return Utils.Helpers.ReturnInventoryItems(this, "//div[@class='cart_item']");
            }
        }

        public ShoppingCartIcon ShoppingCartIcon { get; }

        public Basket(IWebDriver driver) : base(driver)
        {
            ShoppingCartIcon = new ShoppingCartIcon(this);
        }
    }
}
