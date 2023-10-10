using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.Reporting
{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;

        private static ExtentTest extentTest;

        public static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(typeof(ExtentReporting).Assembly.Location) + @"..\..\..\..\reports\";

            if (extentReports == null)
            {
                
                extentReports = new ExtentReports();
                var htmlReporter = new ExtentSparkReporter(path + $"report{DateTime.Now:yyyy-dd-M--HH-mm-ss}.html");

                extentReports.AttachReporter(htmlReporter);
            }
            return extentReports;
        }

        public static void CreateTest(string testName)
        {
            extentTest = StartReporting().CreateTest(testName);
        }

        public static void EndReporting()
        {
            StartReporting().Flush();
        }

        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }

        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        public static void LogScreenShoot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}
