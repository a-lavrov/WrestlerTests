using AllureCSharpCommons;
using AllureCSharpCommons.Events;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;
using Wrestler.Driver;
using Wrestler.Driver.Extentions;

namespace Wrestler.Utils
{
    public class AllureReport
    {
        private IWebDriver _browser => DriverFactory.GetDriverInstance().Browser;
        //private ThreadLocal<Allure> _threadLocalLifecycle = new ThreadLocal<Allure>(() => Allure.Lifecycle);
        
        private Allure _lifecycle;
        private const string _suiteUid = "suiteUid";
        
        private bool _errorIncluded;
        private int LevelCount { get; set; }
        private int StepCount { get; set; }
        private int OperationCount { get; set; }
        private string StepName { get; set; }

        public AllureReport()
        {
            AllureConfig.ResultsPath = @"C:\UITests\Reports\" + ConfigSettingsReader.BrowserName + "AllureResults\\";
            Directory.CreateDirectory(AllureConfig.ResultsPath);
            //_lifecycle = _threadLocalLifecycle.Value;
            _lifecycle = Allure.Lifecycle;
        }

        public void StartSuite(string suiteName)
        {
            LevelCount = 0;
            StepCount = 0;
            OperationCount = 0;
            _errorIncluded = false;
            _lifecycle.Fire(new TestSuiteStartedEvent(_suiteUid, suiteName));
        }

        public void FinishSuite()
        {
            _lifecycle.Fire(new TestSuiteFinishedEvent(_suiteUid));
        }

        public void StartTestCase(string caseName)
        {
            _lifecycle.Fire(new TestCaseStartedEvent(_suiteUid, caseName));
        }

        public void FinishTestCase()
        {
            var somethingWrong = (LevelCount > 0);
            while (LevelCount > 0)
                FinishStep();
            if (somethingWrong)
                TakeScreenShot();
            _lifecycle.Fire(new TestCaseFinishedEvent());
        }

        public void FailedTestCase(Exception e)
        {
            _lifecycle.Fire(new TestCaseFailureEvent()
            {
                Throwable = e,
                StackTrace = e.StackTrace,
                SuiteUid = _suiteUid
            });

            TakeScreenShot();
        }

        public void LogFailedStep(string errormessage)
        {
            while (LevelCount > 0)
                FinishStep();

            StartStep(errormessage);
            StartFailedStep();
            FinishStep();
        }

        public void LogFailedStepWithFailedTestCase(Exception e)
        {
            if (_errorIncluded) return;
            _errorIncluded = true;
            LogFailedStep(e.Message);
            FailedTestCase(e);
        }

        public void StartStep(string currentStepName)
        {
            OperationCount++;
            if (LevelCount++ == 0)
            {
                if (!_errorIncluded)
                {
                    StepCount++;
                } 
                StepName = currentStepName;
            }
            //error message (_errorIncluded==true) has step name only information
            //nested levels have additionally step number and step name information
            var step = $"STEP {StepCount}: {(LevelCount > 1 ? $"{StepName}: " : "")}";
            var nesting = $"{(LevelCount > 1 ? $"(nesting level {LevelCount - 1}): " : "")}{currentStepName}";
            var error = $"{(_errorIncluded ? "FAILED " : "")}";
            var ev = new StepStartedEvent($"Action {OperationCount}")
            {
                Title = LevelCount < 2 ? $"{error}{step}{nesting}" : $"{error}{nesting}"
            };
            _lifecycle.Fire(ev);
        }

        public void FinishStep()
        {
            if (LevelCount == 0) return;
            LevelCount--;
            _lifecycle.Fire(new StepFinishedEvent());
        }

        public void StartFailedStep()
        {
            _lifecycle.Fire(new StepFailureEvent());
        }

        public void TakeScreenShot()
        {
            //_lifecycle.Fire(new MakeAttachmentEvent(AllureResultsUtils.TakeScreenShot(), "Screenshot", "image/png"));
            _lifecycle.Fire(new MakeAttachmentEvent(_browser.TakeScreenshot(), "Screenshot", "image/png"));
        }
        

    }
}
