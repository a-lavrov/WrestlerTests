using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Wrestler.Driver.Extentions
{
    public static class DriverWaitExtentions
    {
        public static bool WaitForElementIsVisible(this WebDriverWait driverWait, IWebElement element)
        {
            return driverWait.Until(d => element.Displayed && element.Enabled);
        }

        public static IWebElement WaitForElementIsClickable(this WebDriverWait driverWait, IWebElement element)
        {
            return driverWait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        //public static void WaitForDocumentReadyStateComplete(this WebDriverWait driverWait)
        //{
        //    driverWait.Until(d => d.ReadyState().Equals("complete"));
        //}


    }
}
