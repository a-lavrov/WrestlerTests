using NUnit.Framework;
using Wrestler.Pages.BasePages;
using Wrestler.Driver.Extentions;

namespace Wrestler.Pages.Main
{
    public class MainPage : BasePage<MainPageElementMap, MainPageValidator>
    {
        public virtual void ClickNewButton()
        {
            var button = Map.NewButton;
            Validate.AssertThatElementIsNotNull(button, "New button");
            button.Click();
        }

        public virtual void SearchForWrestlers(string searchText, int expectedNumberOfEntries)
        {
            //Browser.SetInputValue(Map.SearchInput, searchText);
            Map.SearchInput.SendKeys(searchText);
            Validate.AssertThatElementIsNotNull(Map.SearchButton, "Search button");
            Map.SearchButton.Click();

            //Validate.AssertTableContainsNextNumberOfEntries(expectedNumberOfEntries);
        }

        
    }
}
