using System.Collections.Generic;
using OpenQA.Selenium;
using SauceDemoInteractionLibrary.Components;

namespace SauceDemoInteractionLibrary.Pages
{
    public class Inventory : BasePage
    {
        public IEnumerable<InventoryItem> InventoryItems { 
            get {
                return Utils.Helpers.ReturnInventoryItems(this, "//div[@class='inventory_item']");
            } 
        }

        public ShoppingCartIcon ShoppingCartIcon { get; }

        public Inventory(IWebDriver driver) : base(driver)
        {
            ShoppingCartIcon = new ShoppingCartIcon(this);
        }
    }
}
