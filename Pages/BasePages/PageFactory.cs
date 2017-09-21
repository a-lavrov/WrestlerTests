using Castle.DynamicProxy;
using System;
using Wrestler.Driver;
using Wrestler.Utils;

namespace WrestlerTests.Pages.BasePages
{
    internal class PageInterceptor : IInterceptor
    {
        protected AllureReport Report => DriverFactory.GetDriverInstance().Report;

        public void Intercept(IInvocation invocation)
        {
            try
            {
                Report.StartStep(invocation.Method.Name);
                invocation.Proceed();
                Report.FinishStep();
            }
            catch (Exception e)
            {
                Report.LogFailedStepWithFailedTestCase(e);
                throw;
            }
        }
    }

    public class PageFactory
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();
        
        public static T GetPage<T>() where T : class, new()
        {
            var pageInterceptor = new PageInterceptor();
            var proxy = _generator.CreateClassProxy<T>(pageInterceptor);
            return proxy;
        }


    }
}
