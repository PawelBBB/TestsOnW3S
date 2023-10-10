using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsOnW3S;
using TestsOnW3S.Browsers;
using TestsOnW3S.Common;
using TestsOnW3S.Reporting;
using TestsOnW3S.TestsBase;

namespace UiTests
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected ReadOnlyCollection<Cookie> _cookies;
        protected DriverFactory _driverFactory;

        [OneTimeSetUp]
        public void Initialize()
        {
            _driverFactory = new DriverFactory();
            _driver = _driverFactory.CreateDriver();
            _cookies = PageCookies.ReadPageCookies(_driver);
        }

        [SetUp]
        public void Setup()
        {

            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName!);

            _driver = _driverFactory.CreateDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _driver.Navigate().GoToUrl(AppConfig.HomeUrl);
            PageCookies.LoadSavedCookies(_driver, _cookies);
        }

        [TearDown]
        public void TearDown()
        {
            EndTest();
            _driver.Quit();
            ExtentReporting.EndReporting();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test have failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogFail($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogScreenShoot("Ending test", ScreenshootMaker.GetScreenshoot(_driver));
        }
    }
}
