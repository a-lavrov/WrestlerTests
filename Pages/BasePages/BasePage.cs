using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Wrestler.Driver;
using Wrestler.Utils;
using WrestlerTests.Pages.BasePages;

namespace Wrestler.Pages.BasePages
{
    public class BasePage<M, V>
        where M : BasePageElementMap, new()
        where V : BasePageValidator<M>, new()
    {
        private readonly string _appUrl = ConfigSettingsReader.AppUrl;

        private V _validator => PageFactory.GetPage<V>(); //new V();

        protected IWebDriver Browser => DriverFactory.GetDriverInstance().Browser;
        protected WebDriverWait BrowserWait => DriverFactory.GetDriverInstance().BrowserWait;
        protected AllureReport Report => DriverFactory.GetDriverInstance().Report;

        public M Map => PageFactory.GetPage<M>(); //new M();
        public V Validate => _validator;
                
        public virtual void Navigate(string itemUrl = "")
        {
            if (itemUrl != "")
            {
                itemUrl = "/" + itemUrl;
            }
            var url = $"{_appUrl}{itemUrl}";
            Browser.Navigate().GoToUrl(url);
        }
        

    }
}
