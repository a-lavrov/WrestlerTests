using NUnit.Framework;
using System;
using Wrestler.Driver;
using Wrestler.Utils;

namespace Wrestler.BaseTests
{
    public class BaseTest
    {
        protected AllureReport Report => DriverFactory.GetDriverInstance().Report;

        [SetUp]
        public void SetupTest()
        {
            Report.StartSuite(TestContext.CurrentContext.Test.ClassName);
            Report.StartTestCase(TestContext.CurrentContext.Test.Name);

            DriverFactory.GetDriverInstance().StartBrowser();
        }

        [TearDown]
        public void TeardownTest()
        {
            DriverFactory.GetDriverInstance().StopBrowser();

            Report.FinishTestCase();
            Report.FinishSuite();
        }
    }
}
