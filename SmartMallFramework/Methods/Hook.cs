using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using NUnit.Framework;

namespace SmartMallFramework
{
    public enum BrowserType
    {
        Chrome,
        FireFox,
        IE
    }

    [TestFixture]
    public class Hook : Browser
    {
        private BrowserType _browserType;
        
        public Hook(BrowserType browser)
        {
            _browserType = browser;
        }

        [SetUp]
        public void InitializeTest()
        {
            ChooseBrowser(_browserType);
        }

        private void ChooseBrowser(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                driver = new ChromeDriver();
            }
            else if (browserType == BrowserType.FireFox)
            {
                driver = new FirefoxDriver();
            }
            else if (browserType == BrowserType.IE)
            {
                driver = new EdgeDriver();
            }
        }


    }
}
