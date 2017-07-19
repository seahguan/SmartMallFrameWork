using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartMallFramework
{
    class ThankYouPageObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ThankYouPageObjects()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".details.details-link")]
        public IWebElement DetailsLink { get; set; }
        // .section.order-completed.buttons
        [FindsBy(How = How.CssSelector, Using = ".button-1.order-completed-continue-button")]
        public IWebElement btnContinue { get; set; }

        /// <summary>
        /// Click on the details and go to the details of the orders.
        /// </summary>
        public void ClickDetailsLink()
        {
            DetailsLink.Click();
        }

        /// <summary>
        /// click on the continue button.
        /// </summary>
        public void ClickContinueBtn()
        {
            btnContinue.Click();
        }
    }
}
