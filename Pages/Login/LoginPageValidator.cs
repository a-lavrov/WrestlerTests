using System;
using Wrestler.Pages.BasePages;

namespace Wrestler.Pages.Login
{
    public class LoginPageValidator : BasePageValidator<LoginPageElementMap>
    {
        public virtual void ValidateThatLoginButtonIsEnabled()
        {
            if (!Map.LoginButton.Enabled)
            {
                throw new Exception("Login button is not enabled.");
            }
        }

    }
}
