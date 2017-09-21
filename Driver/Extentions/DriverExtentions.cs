using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Wrestler.Driver.Extentions
{
    public static class DriverExtentions
    {
        public static object Execute(this IWebDriver browser, string script, params object[] args)
        {
            return ((IJavaScriptExecutor)browser).ExecuteScript(script, args);
        }

        public static byte[] TakeScreenshot(this IWebDriver browser)
        {
            var screenshot = ((ITakesScreenshot)browser).GetScreenshot();
            byte[] screenshotAsByteArray = screenshot.AsByteArray;
            return screenshotAsByteArray;
        }

        public static IWebElement FindElementById(this IWebDriver browser, string id)
        {
            return browser.FindElement(By.Id(id));
        }

        public static IWebElement FindElementByClassName(this IWebDriver browser, string className)
        {
            return browser.FindElement(By.ClassName(className));
        }

        public static ReadOnlyCollection<IWebElement> FindElementsByClassName(this IWebDriver browser, string className)
        {
            return (ReadOnlyCollection<IWebElement>)browser.Execute("return document.getElementsByClassName(arguments[0]);", className);
        }

        public static ReadOnlyCollection<IWebElement> FindElementsByTagName(this IWebDriver browser, string tagName)
        {
            return (ReadOnlyCollection<IWebElement>)browser.Execute("return document.getElementsByTagName(arguments[0]);", tagName);
        }

        public static IWebElement FindSelectOrInputElement(this IWebDriver browser, string valueOfParentValueAttribute, string elementTagName)
        {
            return (IWebElement)browser.Execute(@"
                var tagNames = ['fg-select', 'fg-typeahead', 'f-select'];
                for (var j = 0; j < tagNames.length; j++) {
                    var parents = document.getElementsByTagName(tagNames[j]);
	                for (var i = 0; i < parents.length; i++){
		                if (parents[i].getAttribute('value') == arguments[0]) {
			                return parents[i].getElementsByTagName(arguments[1])[0];
				}}} return; ", valueOfParentValueAttribute, elementTagName);
        }

        public static void SetInputValue(this IWebDriver browser, IWebElement element, string value)
        {
            Assert.IsNotNull(element, $"Input element is null, can't set value '{value}'.");
            browser.Execute("arguments[0].value = arguments[1];", element, value);
        }

        public static IWebElement GetParentOfElement(this IWebDriver browser, IWebElement element)
        {
            Assert.IsNotNull(element, $"Element is null, can't get its parent.");
            return (IWebElement)browser.Execute("return arguments[0].parentNode;", element);
        }
        
    }
}
