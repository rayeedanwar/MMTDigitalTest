using OpenQA.Selenium;

namespace SauceDemoInteractionLibrary.Components
{
    public class ShoppingCartIcon
    {
        private BasePage _hostPage;

        public int Count { get { return int.Parse(_hostPage.Driver.FindElement(By.XPath("//a[@class='shopping_cart_link']/span")).Text); } }

        public ShoppingCartIcon(BasePage page)
        {
            _hostPage = page;
        }
    }
}
