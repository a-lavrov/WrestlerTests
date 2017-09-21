using OpenQA.Selenium;
using Wrestler.Pages.BasePages;
using Wrestler.Driver.Extentions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using WrestlerTests.Utils;
using System;

namespace WrestlerTests.Pages.Wrestler
{
    public class WrestlerPageElementMap : BasePageElementMap
    {
        private readonly string prefixValue = "wr.";

        public IWebElement NewWrestlerTabHeading => FindTabHeadingByInnerText("New Wrestler");

        public IWebElement LastName => Browser.FindElement(By.CssSelector("input[placeholder='Last name']"));
        public IWebElement FirstName => Browser.FindElement(By.CssSelector("input[placeholder='First name']"));
        public IWebElement DateOfBirth => Browser.FindElement(By.CssSelector("input[placeholder='Date of Birth']"));
        public IWebElement MiddleName => Browser.FindElement(By.CssSelector("input[placeholder='Middle name']"));
        public IWebElement SaveButton => Browser.GetParentOfElement(Browser.FindElement(By.CssSelector("ico[icon='glyphicon-ok']")));
        
        public virtual void SelectOptionOrSetInputValue(ParentElementValue partOfParentAfterWrValue, string valueToSet, ElementTagName tagName)
        {
            var parentValueAttr = $"{prefixValue}{partOfParentAfterWrValue.ToString().ToLower()}";
            var element = Browser.FindSelectOrInputElement(parentValueAttr, tagName.ToString());
            
            Assert.IsNotNull(element, 
                $"{tagName.ToString()} element was not found with parent element's value attribute - 'value={parentValueAttr}.'");

            switch (tagName)
            {
                case ElementTagName.Input:
                    Browser.SetInputValue(element, valueToSet);
                    break;
                case ElementTagName.Select:
                    var s = new SelectElement(element);
                    s.SelectByText(valueToSet);
                    break;
            }
            
        }

        
    }
}
