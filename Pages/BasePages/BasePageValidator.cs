using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Wrestler.Driver;
using Wrestler.Utils;
using WrestlerTests.Pages.BasePages;

namespace Wrestler.Pages.BasePages
{
    public class BasePageValidator<M>
        where M : BasePageElementMap, new()
    {
        protected IWebDriver Browser => DriverFactory.GetDriverInstance().Browser;
        protected WebDriverWait BrowserWait => DriverFactory.GetDriverInstance().BrowserWait;
        protected AllureReport Report => DriverFactory.GetDriverInstance().Report;

        protected M Map => PageFactory.GetPage<M>(); //new M();

        /// <summary>
        /// Method asserts that element is not null
        /// </summary>
        /// <param name="element">Element to assert</param>
        /// <param name="elementName">Elements whatever name for log</param>
        public virtual void AssertThatElementIsNotNull(IWebElement element, string elementName)
        {
            Assert.That(element != null, $"'{elementName}' web element is null, it was not found!");
        }
        

    }
}
