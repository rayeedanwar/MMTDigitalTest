using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using SauceDemoInteractionLibrary;
using TechTalk.SpecFlow;
using System;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

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
            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true)
                            // .AddEnvironmentVariables() if needed via pipelines
                            .Build();

            var selectedBrowser = config.GetSection("Browser").Value;
            var driverDirectory = $"{Directory.GetCurrentDirectory()}/Drivers";
            var options = new InternetExplorerOptions { EnableNativeEvents = false };
            options.AddAdditionalCapability("disable-popup-blocking", true);

            IWebDriver driver = selectedBrowser.ToLower() switch
            {
                "chrome" => new ChromeDriver(driverDirectory),
                "firefox" => new FirefoxDriver(driverDirectory), // firefox driver is very slow - haven't investigated but test starts and executes
                "edge" => new EdgeDriver(driverDirectory),
                "ie11" => new InternetExplorerDriver(driverDirectory), // throws NoSuchWindowException after navigating to site
                _ => throw new InvalidOperationException($"{selectedBrowser} not recognised in test suite")
            };

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
