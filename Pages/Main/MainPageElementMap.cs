using OpenQA.Selenium;
using Wrestler.Pages.BasePages;
using Wrestler.Driver.Extentions;
using System.Collections.Generic;

namespace Wrestler.Pages.Main
{
    public class MainPageElementMap : BasePageElementMap
    {
        public IWebElement WrestlersTabHeading => Browser.FindElementByClassName("tab-heading");
        public IWebElement SearchInput => Browser.FindElement(By.CssSelector("input[ng-model='searchFor']"));

        public IWebElement NewButton => FindButtonByInnerText("New");
        public IWebElement SearchButton => FindButtonByInnerText("Search");

        public IWebElement GetWrestlersTable()
        {
            var tbody = Browser.FindElement(By.TagName("tbody"));
            return Browser.GetParentOfElement(tbody);
        }

        public int GetWrestlersTableRowsCount()
        {
            return Browser.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).Count;
        }
    }
}
