using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartMallFramework
{
    class PhoneVerificationObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PhoneVerificationObjects()
        {
            // to initialize all the object in this page  
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        public IWebElement txtPhoneNumber { get; set; }

        [FindsBy(How = How.Id, Using = "phone-verification-button")]
        public IWebElement btnphoneverification { get; set; }

        [FindsBy(How = How.Id, Using = "PhoneVerificationId")]
        public IWebElement txtPhoneVerificationId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.master-wrapper-content > div.master-column-wrapper > div > div > div.page-body > form > div.buttons > input")]
        public IWebElement btnContinue { get; set; }


        
    }
}
