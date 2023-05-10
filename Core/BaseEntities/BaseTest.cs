using NUnit.Framework;
using System;
using Core.Core;
using Core.Helper;
using NUnit.Framework.Interfaces;
using log4net;

namespace Core.BaseEntities
{
    public class BaseTest
    {
        protected ILog Log
        {
            get { return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); }
        }

        [SetUp]
        public void SetUp()
        {
           Log.Info("Browser set up");
           DriverHolder.Driver.Manage().Window.Maximize();
           DriverHolder.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
           DriverHolder.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
           DriverHolder.Driver.Navigate().GoToUrl(ConfigurationsManager.GetUrl());
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Log.Info("Test failed((( Making screenshot...");
                ScreenshotMaker.TakeBrowserScreenshot();
                ScreenshotMaker.TakeFullDisplayScreenshot();
            }      
        }
    }
}
