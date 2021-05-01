using System.Collections.Generic;
using OpenQA.Selenium;
using SauceDemoInteractionLibrary.Components;

namespace SauceDemoInteractionLibrary.Utils
{
    public static class Helpers
    {
        public static IEnumerable<InventoryItem> ReturnInventoryItems(BasePage page, string xPath)
        {
            var allItems = page.Driver.FindElements(By.XPath(xPath));

            List<InventoryItem> items = new List<InventoryItem>();
            for (int i = 0; i < allItems.Count; i++)
            {
                items.Add(new InventoryItem(page, i + 1));
            }

            return items;
        }
    }
}
