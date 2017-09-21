using Wrestler.Pages.BasePages;
using Wrestler.Pages.Main;
using Wrestler.Driver.Extentions;

namespace Wrestler.Pages.Login
{
    public class LoginPage : BasePage<LoginPageElementMap, LoginPageValidator>
    {
        public virtual LoginPage LogIn(string login, string password)
        {
            Map.LoginInput.SendKeys(login);
            Map.PasswInput.SendKeys(password);

            Validate.ValidateThatLoginButtonIsEnabled();
            Map.LoginButton.Click();
            
            return this;
        }
        
    }
}
