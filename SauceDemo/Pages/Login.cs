using OpenQA.Selenium;

namespace SauceDemoInteractionLibrary.Pages
{
    public class Login : BasePage
    {
        public IWebElement UserNameInput { get { return Driver.FindElement(By.XPath("//input[@id='user-name']")); } }
        public IWebElement PasswordInput { get { return Driver.FindElement(By.XPath("//input[@id='password']")); } }
        public IWebElement LoginButton { get { return Driver.FindElement(By.XPath("//input[@id='login-button']")); } }
        public IWebElement ErrorMessage { get { return Driver.FindElement(By.XPath("//h3[@data-test='error']")); } }

        public Login(IWebDriver driver) : base(driver)
        {
        }

    }
}
