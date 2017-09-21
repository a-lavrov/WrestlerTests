using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Wrestler.Utils;
using OpenQA.Selenium.IE;

namespace Wrestler.Driver
{
    public class DriverFactory
    {
        private IWebDriver _browser;
        private WebDriverWait _browserWait;
        private readonly string BrowserName = ConfigSettingsReader.BrowserName;
        
        private static ThreadLocal<DriverFactory> _instance = new ThreadLocal<DriverFactory>(() => new DriverFactory());
        //private static Lazy<DriverFactory> _instance = new Lazy<DriverFactory>(() => new DriverFactory(), LazyThreadSafetyMode.ExecutionAndPublication);

        private ThreadLocal<AllureReport> _report = new ThreadLocal<AllureReport>(() => new AllureReport());

        public IWebDriver Browser => _browser;
        public WebDriverWait BrowserWait => _browserWait;
        public AllureReport Report => _report.Value;

        public static DriverFactory GetDriverInstance()
        {
            return _instance.Value;
        }
        
        public void StartBrowser()
        {   
            switch (BrowserName)
            {
                case "Firefox":
                    _browser = new FirefoxDriver();
                    break;

                case "InternetExplorer":
                    _browser = new InternetExplorerDriver();
                    break;

                case "Chrome":
                    var options = new ChromeOptions();
                    options.AddUserProfilePreference("credentials_enable_service", false);  // for disabling saving passwords notification
                    options.AddArgument("disable-infobars");    // for disabling infobar "Chrome is being controlled by automated software"
                    _browser = new ChromeDriver(options);
                    break;

                default:
                    Assert.Fail("Browser name setting is not applicable: " + BrowserName);
                    break;
            }

            _browser = new DriverEvents(_browser);
            var defaultTimeOut = ConfigSettingsReader.DefaultTimeOut();

            _browserWait = new WebDriverWait(_browser, TimeSpan.FromSeconds(defaultTimeOut));
            _browser.Manage().Window.Maximize();
            _browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(defaultTimeOut);
        }

        public void StopBrowser()
        {
            _browser.Quit();
            _browser = null;
            _browserWait = null;
        }
        
    }

    
}
