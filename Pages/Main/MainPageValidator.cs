using NUnit.Framework;
using Wrestler.Pages.BasePages;
using Wrestler.Driver.Extentions;

namespace Wrestler.Pages.Main
{
    public class MainPageValidator : BasePageValidator<MainPageElementMap>
    {
        public virtual void ValidateThatMainPageIsOpened()
        {
            //BrowserWait.WaitForDocumentReadyStateComplete();
            var element = Map.WrestlersTabHeading;
            BrowserWait.WaitForElementIsVisible(element);
        }

        public virtual void AssertTableContainsNextNumberOfEntries(int expectedNumberOfWrestlersEntries)
        {
            var actual = Map.GetWrestlersTableRowsCount();
            Assert.That(expectedNumberOfWrestlersEntries == actual,
                $"Expected number of entries is '{expectedNumberOfWrestlersEntries}', but actual is '{actual}'.");
        }


    }
}
