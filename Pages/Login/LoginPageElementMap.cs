using OpenQA.Selenium;
using Wrestler.Pages.BasePages;

namespace Wrestler.Pages.Login
{
    public class LoginPageElementMap : BasePageElementMap
    {
        private IWebElement _loginform => Browser.FindElement(By.Name("loginform"));

        public IWebElement LoginInput => Browser.FindElement(By.CssSelector("#username input"));
        public IWebElement PasswInput => _loginform.FindElement(By.XPath(".//input[@placeholder='Password']"));
        public IWebElement LoginButton => _loginform.FindElement(By.TagName("button"));
    }

}
