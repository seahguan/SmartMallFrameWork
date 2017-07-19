using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AventStack;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter.Configuration.Defaults;
using NUnit.Framework.Interfaces;

namespace PefaMallFramework
{
    [TestFixture]
    public class GenerateExtendReports
    {
        public ExtentHtmlReporter htmlReporter;
        public ExtentReports extent;
        public ExtentTest test;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [OneTimeSetUp]
        public void StartReport()
        {
            htmlReporter = new ExtentHtmlReporter(Path.GetDirectoryName("user.dir") + "/test-output/MyOwnReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("OS", "Windows 10");
            extent.AddSystemInfo("Host Name", "Seahguan");
            extent.AddSystemInfo("Environment", "QA - PEFAMALL Staging");
            extent.AddSystemInfo("User Name", "seahguan");
            extent.AddSystemInfo("Version", "PEFA Test V 0.1");

            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().DocumentTitle = "PEFAMall Selenium Automation testing";
            htmlReporter.Configuration().ReportName = "PEFA-Mall - QA Report";
            htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
            htmlReporter.Configuration().Theme = Theme.Dark;
        }

        [Test]
        public void demoTestPass()
        {
            test = extent.CreateTest("demoTestPass", "This test will demonstrate the PASS test case");
            Assert.IsTrue(true);
        }

        [Test]
        public void demoTestFail()
        {
            test = extent.CreateTest("demoTestFail", "This test will demonstrate the FAIL test case");
            Assert.IsTrue(false);
        }


        [Test]
        public void demoTestSkip()
        {
            test = extent.CreateTest("demoTestSkip", "This test will demonstrate the FAIL test case");
            throw new AssertionException("This test will demonstrate the FAIL test case");
        }


        [TearDown]
        public void getResult(ITestResult result)
        {
            if (ITestResult.Equals(result.ResultState, (ResultState.Failure)))
            {
                test.Log(Status.Fail, MarkupHelper.CreateLabel(result.FullName + " Test case FAILED due to below issues:", ExtentColor.Red));
                Exception e;
                try {
                    throw new InvalidOperationException("Invalid OPeration");
                }
                catch (Exception ex)
                {
                    e = ex;
                }
                test.Log(Status.Fail, "Description").Fail(e);
                
                
            }
            else if (ITestResult.Equals(result.ResultState, (ResultState.Success)))
            {
                test.Log(Status.Pass, MarkupHelper.CreateLabel(result.Name + " Test Case PASSED", ExtentColor.Green));
            }
            else
            {
                test.Log(Status.Skip, MarkupHelper.CreateLabel(result.Name + " Test Case SKIPPED", ExtentColor.Yellow));
                // test.Skip(result.);
            }
        }

        [OneTimeTearDown]
        public void tearsDown()
        {
            extent.Flush();
        }



    }
}
