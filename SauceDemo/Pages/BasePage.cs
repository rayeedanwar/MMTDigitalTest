using OpenQA.Selenium;

namespace SauceDemoInteractionLibrary
{
    public class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void Quit()
        {
            Driver.Close();
        }
    }
}
