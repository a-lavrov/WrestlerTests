using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrestler.Driver.Extentions;
using Wrestler.Pages.BasePages;

namespace WrestlerTests.Pages.Wrestler
{
    public class WrestlerPageValidator : BasePageValidator<WrestlerPageElementMap>
    {
        public virtual void ValidateThatNewWrestlerTabIsDisplayed()
        {
            BrowserWait.WaitForElementIsVisible(Map.NewWrestlerTabHeading);
        }

        public virtual void ValidateThatSaveIconIsAvailable()
        {
            BrowserWait.WaitForElementIsVisible(Map.SaveButton);
        }
    }
}
