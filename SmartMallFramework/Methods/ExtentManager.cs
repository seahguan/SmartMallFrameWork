using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;

namespace SmartMallFramework
{
    public static class ExtentManager
    {
        /// <summary>
        /// usign the Avent stack and create the test result the Reports with screen capture evidence.
        /// </summary>
        public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentHtmlReporter htmlReporter;
        // private static string filePath = "./extentreport.html";


        public static ExtentReports GetExtent()
        {
            if (extent != null)
                return extent;  //avoid creating new instance of html file

            extent = new ExtentReports();
            extent.AttachReporter(getHtmlReporter());

            return extent;
        }

        private static ExtentHtmlReporter getHtmlReporter()
        {
            //following is to set the extend confing in the program:
            //htmlReporter = new ExtentHtmlReporter(filePath);

           
            
            // this is to load the config setting from the extend config xml file
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualpath = path.Substring(0, path.LastIndexOf("bin"));
            string projectpath = new Uri(actualpath).LocalPath;

            string reportpath = projectpath + "Reports\\MyOwnReport.html";
            htmlReporter = new ExtentHtmlReporter(reportpath);

            //make the chart visible on report open
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().DocumentTitle = "PEFAMall Selenium Automation testing";
            htmlReporter.Configuration().ReportName = "PEFA-Mall - QA Report";
            htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
            htmlReporter.Configuration().Theme = Theme.Standard;

            //htmlReporter.LoadConfig(projectpath + "./extent-config.xml");

            return htmlReporter;
        }

        public static ExtentTest createTest(string name, string description)
        {
            var test = extent.CreateTest(name, description);
            return test;
        }

    }
}
