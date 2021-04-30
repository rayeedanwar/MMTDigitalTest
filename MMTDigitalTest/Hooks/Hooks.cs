using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoInteractionLibrary;
using TechTalk.SpecFlow;

namespace MMTDigitalTest.Hooks
{
    [Binding]
    class Hooks
    {
        private readonly IObjectContainer objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void SetupBrowser()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            // might be worth adding chromedriver to run from specific folder but pretty sure it runs with latest stable version because of Selenium.Webdriver? double check
            var sauceDemoApp = new SauceDemoApp(driver);

            objectContainer.RegisterInstanceAs<SauceDemoApp>(sauceDemoApp);
        }

        [AfterScenario]
        public void TeardownBrowser(SauceDemoApp sauceDemoApp)
        {
            sauceDemoApp.Quit();
        }
    }
}
