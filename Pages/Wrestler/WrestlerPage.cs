using System.Collections.Generic;
using Wrestler.Pages.BasePages;
using WrestlerTests.Utils;

namespace WrestlerTests.Pages.Wrestler
{
    public class WrestlerPage : BasePage<WrestlerPageElementMap, WrestlerPageValidator>
    {
        public virtual WrestlerPage CreateNewWrestler(IDictionary<string, string> data)
        {
            Map.LastName.SendKeys(data["LastName"]);
            Map.FirstName.SendKeys(data["FirstName"]);
            Map.DateOfBirth.SendKeys(data["DateOfBirth"]);
            Map.MiddleName.SendKeys(data["MiddleName"]);
            Map.SelectOptionOrSetInputValue(ParentElementValue.Region1, data["Region1"], ElementTagName.Select);
            Map.SelectOptionOrSetInputValue(ParentElementValue.Region2, data["Region2"], ElementTagName.Select);
            Map.SelectOptionOrSetInputValue(ParentElementValue.FST1, data["Fst1"], ElementTagName.Select);
            Map.SelectOptionOrSetInputValue(ParentElementValue.FST2, data["Fst2"], ElementTagName.Select);
            Map.SelectOptionOrSetInputValue(ParentElementValue.Trainer1, data["Trainer1"], ElementTagName.Input);
            Map.SelectOptionOrSetInputValue(ParentElementValue.Trainer2, data["Trainer2"], ElementTagName.Input);
            Map.SelectOptionOrSetInputValue(ParentElementValue.Style, data["Style"], ElementTagName.Select);
            Map.SelectOptionOrSetInputValue(ParentElementValue.Lictype, data["Age"], ElementTagName.Select);
            Map.SelectOptionOrSetInputValue(ParentElementValue.Expires, data["Year"], ElementTagName.Select);
            Map.SelectOptionOrSetInputValue(ParentElementValue.Card_state, data["Card"], ElementTagName.Select);
            
            Map.SaveButton.Click();

            return this;
        }

    }
}
