using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartMallFramework
{
    class SecondLvlPasswdObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SecondLvlPasswdObjects()
        {
            // to initialize all the object in this page
            PageFactory.InitElements(PropertiesCollections.driver, this);
        }

        [FindsBy(How = How.Id, Using = "SecondLevelPassword")]
        public IWebElement txtSecondLevelPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.master-wrapper-content > div.master-column-wrapper > div > div > div.page-body > form > div.buttons > input")]
        public IWebElement btnSave { get; set; }


        public void createSecondLvlPasswd(string secondlvlpassword)
        {
            txtSecondLevelPassword.EnterText(secondlvlpassword);
            btnSave.Submit();
        }

    }
}
