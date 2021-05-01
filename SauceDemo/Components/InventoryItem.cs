using OpenQA.Selenium;

namespace SauceDemoInteractionLibrary.Components
{
    public class InventoryItem
    {
        private BasePage _hostPage;
        public int BaseItemIndex { get; set; }
        public IWebElement Image { get { return _hostPage.Driver.FindElement(By.XPath(addIndex("//div[@class='inventory_item_img']"))); } }
        public IWebElement Name { get { return _hostPage.Driver.FindElement(By.XPath(addIndex("//div[@class='inventory_item_name']"))); } }
        public IWebElement Price { get { return _hostPage.Driver.FindElement(By.XPath(addIndex("//div[@class='inventory_item_price']"))); } }
        public IWebElement Button { get { return _hostPage.Driver.FindElement(By.XPath(addIndex("//div[contains(@class,'pricebar')]/button"))); } }

        public InventoryItem(BasePage page, int index)
        {
            _hostPage = page;
            BaseItemIndex = index;
        }

        public void AddToCart()
        {
            Button.Click();
        }

        private string addIndex(string xpathSelector) => $"({xpathSelector})[{BaseItemIndex}]";
    }
}
