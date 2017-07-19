using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Configuration;
using NUnit;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;




namespace SmartMallFramework
{
    public class testgrid
    {
        static WebDriverException driver;
        static string nodeurl;

        public static void main(String[] args)
        {
            nodeurl = "";
        }
    }
}
