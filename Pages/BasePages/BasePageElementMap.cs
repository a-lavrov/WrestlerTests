using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Wrestler.Driver;
using Wrestler.Driver.Extentions;
using Wrestler.Utils;

namespace Wrestler.Pages.BasePages
{
    public class BasePageElementMap
    {
        protected IWebDriver Browser => DriverFactory.GetDriverInstance().Browser;
        protected WebDriverWait BrowserWait => DriverFactory.GetDriverInstance().BrowserWait;
        protected AllureReport Report => DriverFactory.GetDriverInstance().Report;

        public virtual IWebElement FindTabHeadingByInnerText(string innerText)
        {
            var tabs = Browser.FindElementsByTagName("tab-heading");
            var list = new List<IWebElement>(tabs);
            return list.Find(e => e.Text.Equals(innerText));
        }

        public virtual IWebElement FindButtonByInnerText(string text)
        {
            var buttons = Browser.FindElements(By.TagName("button"));
            var list = new List<IWebElement>(buttons);
            return list.Find(e => e.Text.Equals(text));
        }

        

    }
}
