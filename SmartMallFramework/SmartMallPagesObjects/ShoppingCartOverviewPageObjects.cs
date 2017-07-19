using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMallFramework
{
    class ShoppingCartOverviewPageObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ShoppingCartOverviewPageObjects()
        {
            PageFactory.InitElements(PropertiesCollections.driver, this);
        }

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement btnCheckOut { get; set; }

        [FindsBy(How = How.ClassName, Using = "body > div.master-wrapper-page.mobile-sticky-logo > div.master-wrapper-content > div.master-column-wrapper > div > div > div.page-body.checkout-data > div:nth-child(4) > form > input:nth-child(3)")]
        public IWebElement btnPrevPage { get; set; }

        [FindsBy(How = How.Name, Using = "continueshopping")]
        public IWebElement btnContinueShopping { get; set; }
        
        public void ClickCheckOutbtn()
        {
            btnCheckOut.Clicks();
        }

        public void ClickPrevPagebtn()
        {
            btnPrevPage.Clicks();
        }

        public void ClickContinueShoppingbtn()
        {
            btnContinueShopping.Clicks();
        }
    }
}
