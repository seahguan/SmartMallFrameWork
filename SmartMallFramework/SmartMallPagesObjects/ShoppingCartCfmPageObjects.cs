using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace SmartMallFramework
{
    class ShoppingCartCfmPageObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ShoppingCartCfmPageObjects()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.Name, Using = "nextstep")]
        public IWebElement btnConfrmation { get; set; }

        [FindsBy(How = How.Id, Using = "ui-id-1")]
        public IWebElement Cfmscreen { get; set; }

        /// <summary>
        /// to get the Ok & Cancel button once click on the 
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[@class='ui-button-text']")]
        public IList<IWebElement> ArrBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='button-1 order-completed-continue-button']")]
        public IWebElement ContinueBtn { get; set; }

        /// <summary>
        /// Click on the confirmation confirmation button on the confirmation page of the shopping cart.
        /// the CXStatus is to provide the action weather to accept or cancel the confirmation action.
        /// True is accept while False is to cancel.
        /// </summary>
        /// <param name="CXstatus"></param>
        public void ClickConfrmationBtn(bool btnstatus)
        {
            try
            {
                btnConfrmation.Clicks();
                IList<IWebElement> ListofBtn = ArrBtn;
                string txtListofBtn = "";

                //Cfmscreen.Click();
                if (btnstatus == true)
                {
                    foreach (IWebElement element in ListofBtn)
                    {
                        txtListofBtn = element.Text;

                        if (txtListofBtn == null || txtListofBtn == "")
                            continue;

                        if (txtListofBtn.Contains("ok") || txtListofBtn.Contains("OK") ||
                            txtListofBtn.Contains("oK") || txtListofBtn.Contains("Ok"))
                        {
                            element.Click();
                            break;
                        }
                    }                    
                }
                else if (btnstatus == false)
                {
                    foreach (IWebElement element in ListofBtn)
                    {
                        txtListofBtn = element.Text;

                        if (txtListofBtn == null || txtListofBtn == "")
                            continue;

                        if (txtListofBtn.Contains("Cancel") || txtListofBtn.Contains("cancel"))
                        {
                            element.Click();
                            break;
                        }
                    }

                    Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    ContinueBtn.Click();
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at Shopping Cart - Confirmation Page. Err Msg : ", e);
            }
        }

    }
}
