using AllureCSharpCommons;
using AllureCSharpCommons.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Wrestler.BaseTests;
using Wrestler.Driver;
using Wrestler.Pages.Login;
using Wrestler.Pages.Main;
using WrestlerTests.Data;
using WrestlerTests.Pages.BasePages;

namespace Wrestler.Tests.Login
{

    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    //[Parallelizable]
    public class LoginTests : BaseTest
    {
        [Test, TestCaseSource(typeof(DataProvider), "LoginTestCases")]
        public void LoginCorrectTest(string login, string password)
        {
            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn(login, password);

            //var mainPage = new MainPage();
            //mainPage.Validate().ThatMainPageIsOpened();

            //Assert.Fail("Intended fail!");

        }

        [Test]
        public void LoginCorrectTest1()
        {
            //var page = new LoginPage();
            //page.Navigate();
            //page.FillPageAndLogIn(Login, Password);

            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn("auto", "test");
        }

        [Test]
        public void LoginCorrectTest2()
        {
            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn("auto", "test");
        }

        [Test]
        public void LoginCorrectTest3()
        {
            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn("auto", "test");
        }

        [Test]
        public void LoginCorrectTest4()
        {
            var logInPage = PageFactory.GetPage<LoginPage>();
            logInPage.Navigate();
            logInPage.LogIn("auto", "test");
        }

    }
}
