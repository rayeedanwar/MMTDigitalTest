using System.Collections.Generic;
using OpenQA.Selenium;
using SauceDemoInteractionLibrary.Components;

namespace SauceDemoInteractionLibrary.Pages
{
    public class Inventory : BasePage
    {
        public IEnumerable<InventoryItem> InventoryItems { 
            get {
                var allItems = Driver.FindElements(By.XPath("//div[@class='inventory_item']"));
                
                List<InventoryItem> items = new List<InventoryItem>();
                for (int i = 0; i < allItems.Count; i++)
                {
                    items.Add(new InventoryItem(this, i+1));
                }

                return items;
            } 
        }

        public ShoppingCartIcon ShoppingCartIcon { get; }

        public Inventory(IWebDriver driver) : base(driver)
        {
            ShoppingCartIcon = new ShoppingCartIcon(this);
        }
    }
}
