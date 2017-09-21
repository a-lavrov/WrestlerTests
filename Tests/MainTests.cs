using NUnit.Framework;
using System.Collections.Generic;
using Wrestler.BaseTests;
using Wrestler.Pages.Login;
using Wrestler.Pages.Main;
using WrestlerTests.Data;
using WrestlerTests.Pages.BasePages;
using WrestlerTests.Pages.Wrestler;

namespace Wrestler.Tests.Main
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    //[Parallelizable]
    public class MainTests : BaseTest
    {
        [Test, TestCaseSource(typeof(DataProvider), "CreateNewWrestlerTestCases")]
        public void LoginCorrectTestFromMain(Dictionary<string, string> data)
        {
            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn(data["Login"], data["Password"]);
        }

        [Test, TestCaseSource(typeof(DataProvider), "CreateNewWrestlerTestCases")]
        [Category("Critical")]
        public void LoginCorrectTestFromMain1(Dictionary<string, string> data)
        {
            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn(data["Login"], data["Password"]);
        }

        [Test, TestCaseSource(typeof(DataProvider), "CreateNewWrestlerTestCases")]
        public void LoginCorrectTestFromMain2(Dictionary<string, string> data)
        {
            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn(data["Login"], data["Password"]);
        }


        [Test, TestCaseSource(typeof(DataProvider), "CreateNewWrestler1")]
        public void CreateNewWrestler1(Dictionary<string, string> data)
        {
            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn(data["Login"], data["Password"]); //("auto", "test");

            var mainPage = PageFactory.GetPage<MainPage>();
            mainPage.Validate.ValidateThatMainPageIsOpened();
            mainPage.SearchForWrestlers($"{data["LastName"]} {data["FirstName"]} {data["MiddleName"]}", 3);
            mainPage.ClickNewButton();

            var wrestlerPage = PageFactory.GetPage<WrestlerPage>();
            wrestlerPage.Validate.ValidateThatNewWrestlerTabIsDisplayed();
            wrestlerPage.CreateNewWrestler(data);


            
        }

        [Test, TestCaseSource(typeof(DataProvider), "CreateNewWrestler2")]
        public void CreateNewWrestler2(Dictionary<string, string> data)
        {

            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn(data["Login"], data["Password"]); //("auto", "test");

            var mainPage = PageFactory.GetPage<MainPage>();
            mainPage.Validate.ValidateThatMainPageIsOpened();
            mainPage.ClickNewButton();

            var wrestlerPage = PageFactory.GetPage<WrestlerPage>();
            wrestlerPage.Validate.ValidateThatNewWrestlerTabIsDisplayed();
            wrestlerPage.CreateNewWrestler(data);

        }

        [Test, TestCaseSource(typeof(DataProvider), "CreateNewWrestler3")]
        public void CreateNewWrestler3(Dictionary<string, string> data)
        {

            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn(data["Login"], data["Password"]); //("auto", "test");

            var mainPage = PageFactory.GetPage<MainPage>();
            mainPage.Validate.ValidateThatMainPageIsOpened();
            mainPage.ClickNewButton();

            var wrestlerPage = PageFactory.GetPage<WrestlerPage>();
            wrestlerPage.Validate.ValidateThatNewWrestlerTabIsDisplayed();
            wrestlerPage.CreateNewWrestler(data);

        }

    }
}
