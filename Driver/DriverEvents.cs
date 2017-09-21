using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System.Globalization;
using Wrestler.Utils;

namespace Wrestler.Driver
{
    /// <summary>
    /// Override selenium methods to add event logs
    /// </summary>
    public class DriverEvents : EventFiringWebDriver
    {
        protected AllureReport Report => DriverFactory.GetDriverInstance().Report;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverEvents"/> class.
        /// </summary>
        /// <param name="parentDriver">The parent driver.</param>
        public DriverEvents(IWebDriver parentDriver)
            : base(parentDriver)
        {
        }

        /// <summary>
        /// Raises the <see cref="E:Navigating" /> event.
        /// </summary>
        /// <param name="e">The <see cref="WebDriverNavigationEventArgs"/> instance containing the event data.</param>
        protected override void OnNavigating(WebDriverNavigationEventArgs e)
        {
            Report.StartStep("Navigating to: " + e.Url);
            base.OnNavigating(e);
            Report.FinishStep();
        }

        /// <summary>
        /// Raises the <see cref="E:ElementClicked" /> event.
        /// </summary>
        /// <param name="e">The <see cref="WebElementEventArgs"/> instance containing the event data.</param>
        protected override void OnElementClicking(WebElementEventArgs e)
        {
            Report.StartStep("Clicking: " + ToStringElement(e));
            base.OnElementClicking(e);
            Report.FinishStep();
        }

        /// <summary>
        /// Raises the <see cref="E:ElementValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="WebElementEventArgs"/> instance containing the event data.</param>
        protected override void OnElementValueChanged(WebElementEventArgs e)
        {
            Report.StartStep("Element value changed: " + ToStringElement(e));
            base.OnElementValueChanged(e);
            Report.FinishStep();
        }

        /// <summary>
        /// Raises the <see cref="E:FindingElement" /> event.
        /// </summary>
        /// <param name="e">The <see cref="FindElementEventArgs"/> instance containing the event data.</param>
        protected override void OnFindingElement(FindElementEventArgs e)
        {
            Report.StartStep("Finding element: " + e.FindMethod);
            base.OnFindingElement(e);
            Report.FinishStep();
        }

        /// <summary>
        /// Raises the <see cref="E:ExceptionThrown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="WebDriverExceptionEventArgs"/> instance containing the event data.</param>
        protected override void OnException(WebDriverExceptionEventArgs e)
        {
            Report.LogFailedStepWithFailedTestCase(e.ThrownException);
            base.OnException(e);
        }

        /// <summary>
        /// To the string element.
        /// </summary>
        /// <param name="e">The <see cref="WebElementEventArgs"/> instance containing the event data.</param>
        /// <returns>Formated issue</returns>
        private static string ToStringElement(WebElementEventArgs e)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0} {{{1}{2}{3}{4}{5}{6}{7}{8}}}",
                e.Element.TagName,
                AppendAttribute(e, "id"),
                AppendAttribute(e, "name"),
                AppendAttribute(e, "value"),
                AppendAttribute(e, "class"),
                AppendAttribute(e, "type"),
                AppendAttribute(e, "role"),
                AppendAttribute(e, "text"),
                AppendAttribute(e, "href"));
        }

        /// <summary>
        /// Appends the attribute.
        /// </summary>
        /// <param name="e">The <see cref="WebElementEventArgs"/> instance containing the event data.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns>Atribute and value</returns>
        private static string AppendAttribute(WebElementEventArgs e, string attribute)
        {
            var attrValue = attribute == "text" ? e.Element.Text : e.Element.GetAttribute(attribute);
            return string.IsNullOrEmpty(attrValue) ? string.Empty : string.Format(CultureInfo.CurrentCulture, " {0}='{1}' ", attribute, attrValue);
        }


    }
}
